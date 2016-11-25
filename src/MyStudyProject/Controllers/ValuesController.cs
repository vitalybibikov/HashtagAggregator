using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace MyStudyProject.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] {"value1", "value2"};
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            try
            {
                string str = "1";
                string str3 = Environment.GetEnvironmentVariable("APPSETTIING_my-var");
                string str2 = Environment.GetEnvironmentVariable("my-var");

                if (!String.IsNullOrEmpty(str3))
                {
                    str = String.Concat(str, str3);
                }

                if (!String.IsNullOrEmpty(str2))
                {
                    str = String.Concat(str, str2);
                }
                return Environment.GetEnvironmentVariable(str);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
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
