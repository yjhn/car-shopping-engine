using Backend;
using DataTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server.Controllers
{
    [Authorize]
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

        [HttpGet("{id}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Car))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Car> GetAd([Required] int id)
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

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Car>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<Car>> GetAds([FromHeader][Required] int[] ids)
        {
            IEnumerable<Car> cars = _db.GetCars(ids);
            if (cars == null)
            {
                return NotFound();
            }
            else
            {
                return new ActionResult<IEnumerable<Car>>(cars);
            }
        }

        [HttpGet("sorted")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Car>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<IEnumerable<Car>> GetSortedAds([FromHeader][Required] SortingCriteria sortBy,
                                                                [FromHeader][Required] bool sortAscending,
                                                                [FromHeader][Required] int startIndex,
                                                                [FromHeader][Required] int amount)
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

        [HttpGet("filtered")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Car>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<IEnumerable<Car>> GetFilteredAds([FromHeader] [Required] SortingCriteria sortBy,
                                                                 [FromHeader] [Required] bool sortAscending,
                                                                 [FromHeader] [Required] int startIndex,
                                                                 [FromHeader] [Required] int amount,
                                                                 [FromHeader] string brand = null,
                                                                 [FromHeader] string model = null,
                                                                 [FromHeader] bool? used = null,
                                                                 [FromHeader] int? priceFrom = null,
                                                                 [FromHeader] int? priceTo = null,
                                                                 [FromHeader] string username = null,
                                                                 [FromHeader] int? yearFrom = null,
                                                                 [FromHeader] int? yearTo = null,
                                                                 [FromHeader] FuelType? fuelType = null,
                                                                 [FromHeader] ChassisType? chassisType = null)
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

        [HttpPost("{username}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Car> PostAd([Required] string username, [FromBody] [Required] Car car)
        {
            string user = HttpContext.User.Identity.Name;
            if (car == null || username == null || username != user)
            {
                return BadRequest();
            }


            return _db.AddCar(username, car) ? StatusCode(201, car) : BadRequest();
        }

        [HttpPut("{username}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult PutAd([Required] string username, [Required] Car car)
        {
            string user = HttpContext.User.Identity.Name;
            if (car == null || username == null || user != username)
            {
                return BadRequest();
            }

            return _db.UpdateCar(username, car) ? NoContent() : BadRequest();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteAd([Required] int id)
        {
            string user = HttpContext.User.Identity.Name;
            return _db.DeleteCar(id, user) ? NoContent() : NotFound();
        }


        // Admin methods //

        [HttpDelete]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteAds([Required] int[] ids)
        {
            return _db.DeleteCars(ids) > 0 ? NoContent() : NotFound();
        }

        [HttpPut("disable")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DisableAds([Required] int[] ids)
        {
            Car car;
            foreach (int id in ids)
            {
                car = _db.GetCar(id);
                if (car != null)
                {
                    car.Hidden = true;
                    _db.UpdateCar(car.UploaderUsername, car);
                }
            }
            return NoContent();
        }

        [HttpPut("enable")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult EnableAds([Required] int[] ids)
        {
            Car car;
            foreach (int id in ids)
            {
                car = _db.GetCar(id);
                if (car != null)
                {
                    car.Hidden = false;
                    _db.UpdateCar(car.UploaderUsername, car);
                }
            }
            return NoContent();
        }

        [HttpGet("disabled")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Car>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<IEnumerable<Car>> GetDisabledAds()
        {
            var cars = _db.GetDisabledAds();
            if (cars == null)
            {
                return NoContent();
            }
            else
            {
                return new ActionResult<IEnumerable<Car>>(cars);
            }
        }
    }
}
