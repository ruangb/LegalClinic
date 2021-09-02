using LC.Core.Domain;
using LC.Core.Shared.ModelViews;
using LC.Manager.Interfaces.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SerilogTimings;
using System.Threading.Tasks;

namespace LC.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorManager customerManager;
        private readonly ILogger<DoctorsController> logger;

        public DoctorsController(IDoctorManager customerManager, ILogger<DoctorsController> logger)
        {
            this.customerManager = customerManager;
            this.logger = logger;
        }

        /// <summary>
        /// Return all the customers in the database
        /// </summary> 
        [HttpGet]
        [ProducesResponseType(typeof(Doctor), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            return Ok(await customerManager.GetDoctorsAsync());
        }

        /// <summary>
        /// Return a customer searched by id
        /// </summary>
        /// <param name="id" example="1">customer id</param>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Doctor), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await customerManager.GetDoctorAsync(id));
        }

        /// <summary>
        /// Insert a new customer
        /// </summary>
        /// <param name="newDoctor">a new customer to insert</param>
        [HttpPost]
        [ProducesResponseType(typeof(Doctor), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] NewDoctor newDoctor)
        {
            Doctor insertedDoctor;

            using (Operation.Time("Tempo de adição de um novo cliente"))
            {
                logger.LogInformation("Foi solicitada a inserção de um novo cliente");
                insertedDoctor = await customerManager.InsertDoctorAsync(newDoctor);
            }

            return CreatedAtAction(nameof(Get), new { id = insertedDoctor.Id }, insertedDoctor);
        }
        
        /// <summary>
        /// Update a customer
        /// </summary>
        /// <param name="updateDoctor">custober to be updated</param>
        [HttpPut]
        [ProducesResponseType(typeof(Doctor), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put([FromBody] UpdateDoctor updateDoctor)
        {
            var updatedDoctor = await customerManager.UpdateDoctorAsync(updateDoctor);

            if (updatedDoctor == null)
                return NotFound();

            return Ok(updatedDoctor);
        }
 
        /// <summary>
        /// Delete customer by id
        /// </summary>
        /// <param name="id">customer id</param>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Doctor), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            await customerManager.DeleteDoctorAsync(id);
            
            return NoContent();
        }
    }
}
