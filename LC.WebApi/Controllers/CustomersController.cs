using LC.Core;
using LC.Core.Shared.ModelViews;
using LC.Manager.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SerilogTimings;
using System.Threading.Tasks;

namespace LC.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerManager customerManager;
        private readonly ILogger<CustomersController> logger;

        public CustomersController(ICustomerManager customerManager, ILogger<CustomersController> logger)
        {
            this.customerManager = customerManager;
            this.logger = logger;
        }

        /// <summary>
        /// Return all the customers in the database
        /// </summary> 
        [HttpGet]
        [ProducesResponseType(typeof(Customer), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            throw new System.Exception("Exceção teste");
            return Ok(await customerManager.GetCustomersAsync());
        }

        /// <summary>
        /// Return a customer searched by id
        /// </summary>
        /// <param name="id" example="1">customer id</param>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Customer), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await customerManager.GetCustomerAsync(id));
        }

        /// <summary>
        /// Insert a new customer
        /// </summary>
        /// <param name="newCustomer">a new customer to insert</param>
        [HttpPost]
        [ProducesResponseType(typeof(Customer), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] NewCustomer newCustomer)
        {
            Customer insertedCustomer;

            using (Operation.Time("Tempo de adição de um novo cliente"))
            {
                logger.LogInformation("Foi solicitada a inserção de um novo cliente");
                insertedCustomer = await customerManager.InsertCustomerAsync(newCustomer);
            }

            return CreatedAtAction(nameof(Get), new { id = insertedCustomer.Id }, insertedCustomer);
        }
        
        /// <summary>
        /// Update a customer
        /// </summary>
        /// <param name="updateCustomer">custober to be updated</param>
        [HttpPut]
        [ProducesResponseType(typeof(Customer), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put([FromBody] UpdateCustomer updateCustomer)
        {
            var updatedCustomer = await customerManager.UpdateCustomerAsync(updateCustomer);

            if (updatedCustomer == null)
                return NotFound();

            return Ok(updatedCustomer);
        }
 
        /// <summary>
        /// Delete customer by id
        /// </summary>
        /// <param name="id">customer id</param>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Customer), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            await customerManager.DeleteCustomerAsync(id);
            
            return NoContent();
        }
    }
}
