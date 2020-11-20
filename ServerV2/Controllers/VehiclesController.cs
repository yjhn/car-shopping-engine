using Backend;
using DataTypes;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServerV2.Controllers
{
    [Route("api/vehicles")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IDatabase _db;

        public VehiclesController(IDatabase db)
        {
            _db = db;
        }

        // GET: api/<VehicleController>
        [HttpGet("{id}")]
        public ActionResult<Car> GetCar(int id)
        {
            Car car = _db.GetCar(id);
            if (car == null)
            {
                return NotFound();
            }
            else
            {
                return car;
            }
        }

        // GET api/<VehicleController>/5
        [HttpGet]
        public ActionResult<IEnumerable<Car>> GetSortedVehicles([FromHeader] SortingCriteria sortBy, [FromHeader] bool sortAscending, [FromHeader] int startIndex, [FromHeader] int amount)
        {
            var cars = _db.GetSortedCars(sortBy, sortAscending, startIndex, amount);
            if (cars == null)
            {
                return NoContent();
            }
            else
            {
                return new ActionResult<IEnumerable<Car>>(cars);
            }
        }

        // GET api/<VehicleController>/5
        [HttpGet]
        public ActionResult<IEnumerable<Car>> GetFiteredVehicles([FromHeader] CarFilters filters, [FromHeader] SortingCriteria sortBy, [FromHeader] bool sortAscending, [FromHeader] int startIndex, [FromHeader] int amount)
        {
            var cars = _db.GetFilteredCars(filters, sortBy, sortAscending, startIndex, amount);
            if (cars == null)
            {
                return NoContent();
            }
            else
            {
                return new ActionResult<IEnumerable<Car>>(cars);
            }
        }

        // POST api/<VehicleController>
        [HttpPost]
        public IActionResult Post([FromHeader] string username, [FromHeader] string password, [FromBody] Car car)
        {
            if (!_db.AddCar(username, password, car))
            {
                return BadRequest();
            }
            else
            {
                return NoContent();
            }
        }

        // PUT api/<VehicleController>/5
        [HttpPut]
        public IActionResult Put([FromHeader] string username, [FromHeader] string password, [FromBody] Car car)
        {
            if (!_db.UpdateCar(username, password, car))
            {
                return BadRequest();
            }
            else
            {
                return CreatedAtAction(nameof(GetCar), car);
            }
        }

        // DELETE api/<VehicleController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromHeader] string username, [FromHeader] string password)
        {
            if (!_db.DeleteCar(id, username, password))
            {
                return NotFound();
            }
            else
            {
                return NoContent();
            }
        }
    }
}
