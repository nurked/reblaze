using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReBlaze.DataModel;
using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReBlaze.Shared
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class SendController : Controller
    {
        [Inject]
        private IDbContextFactory<DataModelContext> Context { get; set; }

        public SendController(IDbContextFactory<DataModelContext> dmc)
        {
            Context = dmc;
        }
        // GET api/<ValuesController>/5
        [HttpGet("{Device}/{Command}")]
        public JsonResult Get(string device, string command)
        {
            try
            {

                CommandRunner c = new(Context.CreateDbContext());
                var answer = c.Run(device, command);
                return Json(new { result = "success", device = device, command=command, payload = answer });

            }
            catch (Exception ex)
            {
                return Json(new { result="error", message= ex.Message });
            }
        }
    }
}
