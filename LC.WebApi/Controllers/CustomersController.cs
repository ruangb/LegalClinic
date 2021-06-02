using LC_Core;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LC.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        // GET: api/<CustomerssController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new List<Customer>() {
                new Customer() { Id = 1, Name = "Ruan", BirthDate = Convert.ToDateTime("27/09/1995")}
                , new Customer() { Id = 2, Name = "Micilene", BirthDate = Convert.ToDateTime("05/01/1979")}});
        }

        // GET api/<CustomerssController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CustomerssController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CustomerssController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomerssController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
