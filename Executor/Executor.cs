using System;
using System.Collections.Generic;
using System.Net.Sockets;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using ReBlaze.DataModel;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace ReBlaze
{
    public class CommandRunner:ControllerBase
    {
        [Inject]
        ReBlaze.DataModel.DataModelContext DbContext { get; set; }

        //public CommandRunner(IDbContextFactory<ReBlaze.DataModel.DataModelContext> fac) {
        //    DbFactory = fac;
        //}

        public CommandRunner(DataModelContext fac)
        {
            DbContext = fac;
        }

        public string Run(String Device, String Command)
        {


            var dev = DbContext.Devices.Include(p => p.Model).ThenInclude(p => p.Commands).First(p => p.Name.ToLower() == Device.ToLower());
            var com = dev.Model.Commands.First(p => p.Name.ToLower() == Command.ToLower());


            var answer = Executor.Say(com.Payload, com.Type, dev.Address, dev.Port);

            return String.Join(", 0x", answer);
        }


    }
    public static class Executor
    {
        public static Byte[] Say(string What, CommandType Type, string Address, int Port)
        {

            Byte[] bt = Type switch
            {
                CommandType.AsciiString => System.Text.Encoding.ASCII.GetBytes(What),
                CommandType.UtfString => System.Text.Encoding.UTF8.GetBytes(What),
                CommandType.Binary => ProcessBinary(What, 8),
                CommandType.ByteArray => ProcessBytes(What),
                _ => Array.Empty<byte>()
            };


            using TcpClient t = new TcpClient(Address, Port);
            var s = t.GetStream();
            s.Write(bt, 0, bt.Length);
            return bt;
        }

        static Byte[] ProcessBytes(string What)
        {
            if (What.Length % 2 == 1) What += "0"; //If user sent us uneven byte count
            List<Byte> ret = new(What.Length/2);
            foreach (String ch in What.SplitInParts(2))
            {
                var d1 = Convert.ToByte(ch[0].ToString(), 16);
                var d2 = Convert.ToByte(ch[1].ToString(), 16);
                d1 *= 0x10;
                d1 += d2;
                ret.Add(d1);
            }
            return ret.ToArray();
        }

        static Byte[] ProcessBinary(string What, int WordLength)
        {
            List<Byte> ret = new(What.Length);
            foreach (var ch in What.SplitInParts(WordLength))
            {
                ret.Add(Convert.ToByte(ch, 2));
            }
            return ret.ToArray();

        }
    }

    static class StringExtensions
    {

        public static IEnumerable<String> SplitInParts(this String s, Int32 partLength)
        {
            if (s == null)
                throw new ArgumentNullException(nameof(s));
            if (partLength <= 0)
                throw new ArgumentException("Part length has to be positive.", nameof(partLength));

            for (var i = 0; i < s.Length; i += partLength)
                yield return s.Substring(i, Math.Min(partLength, s.Length - i));
        }

    }
}

