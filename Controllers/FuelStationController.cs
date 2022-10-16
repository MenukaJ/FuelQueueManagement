using FuelQueueManagement.models;
using FuelQueueManagement.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FuelQueueManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuelStationController : ControllerBase
    {

        private readonly IFuelStationService fuelStationService;

        public FuelStationController(IFuelStationService fuelStationService)
        {
            this.fuelStationService = fuelStationService;
        }


        // GET: api/<FuelStationController>
        [HttpGet]
        public ActionResult<List<FuelStation>> Get()
        {
            return fuelStationService.Get();
        }

        // GET api/<FuelStationController>/5
        [HttpGet("{id}")]
        public ActionResult<FuelStation> Get(string id)
        {
            var fuelStation = fuelStationService.Get(id);
            if (fuelStation == null)
                return NotFound($"Fuel stattion with Id = {id} not found");
            return Ok(fuelStation);
        }

        // POST api/<FuelStationController>
        [HttpPost]
        public ActionResult<FuelStation> Post([FromBody] FuelStation fuelStation)
        {
            fuelStationService.Create(fuelStation);
            return CreatedAtAction(nameof(Get), new { id = fuelStation.Id }, fuelStation);
        }

        // PUT api/<FuelStationController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] FuelStation fuelStation)
        {
            var IsExistFuelStation = fuelStationService.Get(id);
            if (IsExistFuelStation == null)
                return NotFound($"Fuel stattion with Id = {id} not found");
            
            fuelStationService.Update(id, fuelStation);
            return Ok(fuelStation);

        }

        // DELETE api/<FuelStationController>/5
       /* [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
