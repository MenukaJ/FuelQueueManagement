using FuelQueueManagement.models;
using FuelQueueManagement.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FuelQueueManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuelQueueController : ControllerBase
    {
        private readonly IFuelQueueService fuelQueueService;

        public FuelQueueController(IFuelQueueService fuelQueueService)
        {
            this.fuelQueueService = fuelQueueService;
        }

        // GET: api/<FuelQueueController>
        [HttpGet]
        public ActionResult<List<FuelQueue>> Get()
        {
            return fuelQueueService.Get();
        }

        [HttpGet("fuel-station/{name}")]
        public int GetByFuelQueue(string name)
        {
            List<FuelQueue> fuelQueues = fuelQueueService.GetByFuelStation(name);
            return fuelQueues.Count();

        }

        // GET api/<FuelQueueController>/5
        [HttpGet("{id}")]
        public ActionResult<FuelQueue> Get(string id)
        {
            var fuelQueue = fuelQueueService.Get(id);
            if (fuelQueue == null)
                return NotFound($"Fuel Queue with Id = {id} not found");
            return Ok(fuelQueue);
        }

        // POST api/<FuelQueueController>
        [HttpPost]
        public ActionResult<FuelQueue> Post([FromBody] FuelQueue fuelQueue)
        {
            fuelQueueService.Create(fuelQueue);
            return CreatedAtAction(nameof(Get), new { id = fuelQueue.Id }, fuelQueue);
        }

        // PUT api/<FuelQueueController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] FuelQueue fuelQueue)
        {
            var IsExistFuelQueue = fuelQueueService.Get(id);
            if (IsExistFuelQueue == null)
                return NotFound($"Fuel Queue with Id = {id} not found");
            fuelQueueService.Update(id, fuelQueue);
            return Ok(fuelQueue);
        }

        // DELETE api/<FuelQueueController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var existingDetails = fuelQueueService.Get(id);
            if (existingDetails == null)
            {
                return NotFound($"Fuel Queue with Id = {id} not found");
            }
            fuelQueueService.Remove(id);
            return Ok($"Fuel Queue with Id = {id} deleted");
        }

        // GET api/<FuelQueueController>/5
        [HttpGet("/email/{email}")]
        public ActionResult<List<FuelQueue>> GetByEmail(string email)
        {
            return fuelQueueService.GetByEmail(email);
        }
    }
}
