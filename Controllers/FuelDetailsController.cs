using FuelQueueManagement.models;
using FuelQueueManagement.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FuelQueueManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuelDetailsController : ControllerBase
    {
        private readonly IFuelDetailsService fuelDetailsService;

        public FuelDetailsController(IFuelDetailsService fuelDetailsService)
        {
            this.fuelDetailsService = fuelDetailsService;
        }

        // GET: api/<FuelDetailsController>
        [HttpGet]
        public ActionResult<List<FuelDetails>> Get()
        {
            return fuelDetailsService.Get();
        }

        // GET api/<FuelDetailsController>/5
        [HttpGet("{id}")]
        public ActionResult<FuelDetails> Get(string id)
        {
            var fuelDetails = fuelDetailsService.Get(id);
            if (fuelDetails == null)
                return NotFound($"Fuel Details with Id = {id} not found");
            return Ok(fuelDetails);
        }

        // POST api/<FuelDetailsController>
        [HttpPost]
        public ActionResult<FuelDetails> Post([FromBody] FuelDetails fuelDetails)
        {
            fuelDetailsService.Create(fuelDetails);
            return CreatedAtAction(nameof(Get), new { id = fuelDetails.Id }, fuelDetails);
        }

        // PUT api/<FuelDetailsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] FuelDetails fuelDetails)
        {
            var IsExistFuelDetails = fuelDetailsService.Get(id);
            if (IsExistFuelDetails == null)
                return NotFound($"Fuel Details with Id = {id} not found");
            fuelDetailsService.Update(id, fuelDetails);
            return Ok(fuelDetails);
        }

        // DELETE api/<FuelDetailsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var existingDetails = fuelDetailsService.Get(id);
            if (existingDetails == null)
            {
                return NotFound($"Fuel Details with Id = {id} not found");
            }
            fuelDetailsService.Remove(id);
            return Ok($"Fuel Details with Id = {id} deleted");
        }
    }
}
