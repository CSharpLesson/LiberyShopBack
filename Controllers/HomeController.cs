using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iTextSharp.text.pdf;
using LiberyShop.Db;
using LiberyShop.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LiberyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IUser _user;

        public ValuesController(IUser user)
        {
            _user = user;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var a = _user.GetById(1);        
            return Ok(a);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
