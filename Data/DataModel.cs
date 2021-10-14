using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace ReBlaze.DataModel
{

public class DataModelContext : DbContext
    {
        public DataModelContext (DbContextOptions<DataModelContext> options)
            : base(options)
        {
        }

        public DbSet<Model> Models { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Command> Commands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Model>().ToTable("Model");
            modelBuilder.Entity<Device>().ToTable("Device");
            modelBuilder.Entity<Command>().ToTable("Command");
        }
    }

    public class Model
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Command> Commands { get; set; }
        public ICollection<Device> Devices { get; set;}
    }

    public class Device
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public int Port { get; set; }

        public int ModelId {get;set;}
        public Model Model {get;set;}

    }


    public class Command
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CommandType Type { get; set; }
        public string Payload { get; set; }
        public Model Model {get;set;}
    }

    public enum CommandType
    {
        AsciiString,
        UtfString,
        ByteArray,
        Binary,
    }
}