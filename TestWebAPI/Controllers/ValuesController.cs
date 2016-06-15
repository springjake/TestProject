using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TestWebAPI.Controllers
{
    //[Authorize]
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public IHttpActionResult Get(int id)
        {
            TestSerialize ts = new TestSerialize() { Name = "name", Age = 18, Birthday = DateTime.Now };
            var result = Ok(ts);
            string r = result.ToString();
            return result;
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }


    }
}

[Serializable]
public class TestSerialize
{
    public string Name { get; set; }
    public int Age { get; set; }
    public DateTime Birthday { get; set; }
}
