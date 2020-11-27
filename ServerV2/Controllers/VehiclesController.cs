using Backend;
using DataTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServerV2.Controllers
{
    [Produces("application/json")]
    [Route("api/vehicles")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IDatabase _db;

        public VehiclesController(IDatabase db)
        {
            _db = db;
        }

        // GET: api/<VehicleController>/5
        [HttpGet("{id}")]
        public ActionResult<Car> GetVehicle(int id)
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

        // GET api/<VehicleController>
        [HttpGet("sorted")]
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
        [HttpGet("filtered")]
        public ActionResult<IEnumerable<Car>> GetFiteredVehicles([FromHeader] SortingCriteria sortBy, [FromHeader] bool sortAscending, [FromHeader] int startIndex, [FromHeader] int amount,
            [FromHeader] string brand = null, [FromHeader] string model = null, [FromHeader] bool? used = null, [FromHeader] int? priceFrom = null, [FromHeader] int? priceTo = null,
            [FromHeader] string username = null, [FromHeader] int? yearFrom = null, [FromHeader] int? yearTo = null, [FromHeader] FuelType? fuelType = null, [FromHeader] ChassisType? chassisType = null)
        {
            CarFilters filters = new CarFilters
            {
                Brand = brand,
                Model = model,
                Used = used,
                PriceFrom = priceFrom,
                PriceTo = priceTo,
                Username = username,
                YearFrom = yearFrom,
                YearTo = yearTo,
                FuelType = fuelType,
                ChassisType = chassisType
            };
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

        /// <response code="201">Returns the newly created item</response>
        // POST api/<VehicleController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Car> PostVehicle([FromHeader] string username, [FromHeader] string password, [FromBody] Car car)
        {
            if (car == null || username == null || password == null)
            {
                return BadRequest();
            }


            return _db.AddCar(username, password, car) ? StatusCode(201, car) : BadRequest();
        }

        // PUT api/<VehicleController>/5
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult PutVehicle([FromHeader] string username, [FromHeader] string password, [FromBody] Car car)
        {
            if (car == null || username == null || password == null)
            {
                return BadRequest();
            }

            return _db.UpdateCar(username, password, car) ? NoContent() : BadRequest();
        }

        // DELETE api/<VehicleController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteVehicle(int id, [FromHeader] string username, [FromHeader] string password)
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
