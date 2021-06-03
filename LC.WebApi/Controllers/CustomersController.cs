using LC.Manager.Interfaces;
using LC.Core;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LC.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerManager customerManager;

        public CustomersController(ICustomerManager customerManager)
        {
            this.customerManager = customerManager;
        }

        // GET: api/<CustomerssController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await customerManager.GetCustomersAsync());
        }

        // GET api/<CustomerssController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await customerManager.GetCustomerAsync(id));
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
