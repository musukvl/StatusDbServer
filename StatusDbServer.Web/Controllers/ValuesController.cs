using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace StatusDbServer.Web.Controllers
{
    [Route("health-check")]
    public class HealthCheckController : Controller
    {
        // GET api/values
        [HttpGet]
        public string Test()
        {
            return "PC: " + Environment.MachineName;
        }
    }

    [Route("api/hw")]
    public class HelloWorldController : Controller
    {
        // GET api/values
        [HttpGet]
        [Route("test")]
        public string Test1()
        {
            return "Hello world";
        }
    }

    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
