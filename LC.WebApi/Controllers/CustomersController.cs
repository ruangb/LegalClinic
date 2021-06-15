using LC.Core;
using LC.Manager.Interfaces;
using LC.Manager.Validator;
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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await customerManager.GetCustomersAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await customerManager.GetCustomerAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Customer customer)
        {
            var insertedCustomer = await customerManager.InsertCustomerAsync(customer);

            return CreatedAtAction(nameof(Get), new { id = customer.Id }, customer);
        }
        
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Customer customer)
        {
            var updatedCustomer = await customerManager.UpdateCustomerAsync(customer);

            if (updatedCustomer == null)
                return NotFound();

            return Ok(updatedCustomer);
        }
 
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await customerManager.DeleteCustomerAsync(id);
            
            return NoContent();
        }
    }
}
