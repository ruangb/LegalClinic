using LC.Core.Shared.ModelViews;
using LC.Manager.Interfaces;
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

        /// <summary>
        /// Return all the customers in the database
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await customerManager.GetCustomersAsync());
        }

        /// <summary>
        /// return a customer searched by id
        /// </summary>
        /// <param name="id" example="1">customer id</param>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await customerManager.GetCustomerAsync(id));
        }

        /// <summary>
        /// Insert a new customer
        /// </summary>
        /// <param name="newCustomer">a new customer to insert</param>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] NewCustomer newCustomer)
        {
            var insertedCustomer = await customerManager.InsertCustomerAsync(newCustomer);

            return CreatedAtAction(nameof(Get), new { id = insertedCustomer.Id }, insertedCustomer);
        }
        
        /// <summary>
        /// update a customer
        /// </summary>
        /// <param name="updateCustomer">custober to be updated</param>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateCustomer updateCustomer)
        {
            var updatedCustomer = await customerManager.UpdateCustomerAsync(updateCustomer);

            if (updatedCustomer == null)
                return NotFound();

            return Ok(updatedCustomer);
        }
 
        /// <summary>
        /// delete customer by id
        /// </summary>
        /// <param name="id">customer id</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await customerManager.DeleteCustomerAsync(id);
            
            return NoContent();
        }
    }
}
