using Contracts.Incoming;
using Contracts.Outgoing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Repositories;
using Services.Services;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/vehicles")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IRepoServices _services;
        private readonly string _carNetApiKey;
        //private readonly Uri _carNetApiUri = new Uri("https://http://api.carnet.ai/v2/mmg");

        public VehiclesController(IRepoServices services, ApiKeyContainer key)
        {
            _services = services;
            _carNetApiKey = key.ApiKey;
        }

        [HttpGet("photo")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public /*async Task<*/ActionResult<IEnumerable<OutgoingVehicleDTO>> GetVehiclesByPhoto([FromHeader][Required] string base64EncodedImage)
        {
            //return NotFound($"Api key = {_carNetApiKey}");

            //using (var carNetRequest = new HttpRequestMessage())
            //{
            //    var content = new ByteArrayContent(Convert.FromBase64String(base64EncodedImage));
            //    content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/octet-stream");
            //    carNetRequest.Headers.Add("api-key", _carNetApiKey);
            //    carNetRequest.Content = content;
            //    carNetRequest.Method = new HttpMethod("POST");
            //    carNetRequest.RequestUri = _carNetApiUri;
            //    carNetRequest.Headers.Accept.Add(.MediaTypeWithQualityHeaderValue.Parse("application/json"));
            //    var response = await _httpClient.SendAsync(carNetRequest);
            //}


            // for now
            var cars = _services.GetSortedVehicles(SortingCriteria.UploadDate, true, 0, 10);
            return new ActionResult<IEnumerable<OutgoingVehicleDTO>>(cars);
        }


        [HttpGet("sorted")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<IEnumerable<OutgoingVehicleDTO>> GetSortedAds(
            [FromHeader][DefaultValue(SortingCriteria.UploadDate)] SortingCriteria sortBy,
            [FromHeader][DefaultValue(false)] bool sortAscending,
            [FromHeader][DefaultValue(0)] int startIndex,
            [FromHeader][DefaultValue(10)] int amount)
        {
            var cars = _services.GetSortedVehicles(sortBy, sortAscending, startIndex, amount);
            if (cars == null)
            {
                return NoContent();
            }
            else
            {
                return new ActionResult<IEnumerable<OutgoingVehicleDTO>>(cars);
            }
        }

        [HttpGet("filtered")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IEnumerable<OutgoingVehicleDTO>>> GetFilteredAds(
            [FromHeader][DefaultValue(SortingCriteria.UploadDate)] SortingCriteria sortBy,
            [FromHeader][DefaultValue(false)] bool sortAscending,
            [FromHeader][DefaultValue(0)] int startIndex,
            [FromHeader][DefaultValue(10)] int amount,
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
            VehicleFilters filters = new VehicleFilters
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
            var cars = await _services.GetFilteredVehicles(filters, sortBy, sortAscending, startIndex, amount);
            if (cars == null)
            {
                return NoContent();
            }
            else
            {
                return new ActionResult<IEnumerable<OutgoingVehicleDTO>>(cars);
            }
        }

        [HttpPost("{username}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IncomingVehicleDTO>> PostAd([Required] string username, [FromBody][Required] IncomingVehicleDTO car)
        {
            string user = HttpContext.User.Identity.Name;
            if (car == null || username == null || username != user)
            {
                return BadRequest();
            }


            return await _services.AddVehicle(username, car) ? StatusCode(201, car) : BadRequest();
        }

        [HttpPut("{username}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutAd([Required] string username, [Required] IncomingVehicleDTO car)
        {
            string user = HttpContext.User.Identity.Name;
            if (car == null || username == null || user != username)
            {
                return BadRequest();
            }

            return await _services.UpdateVehicle(username, car) ? Ok() : BadRequest();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAd([Required] int id)
        {
            string user = HttpContext.User.Identity.Name;
            return await _services.DeleteVehicle(id, user) ? Ok() : NotFound();
        }


        // Admin methods //

        [HttpDelete]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteAds([Required] IList<int> ids)
        {
            return Ok(await _services.DeleteVehicles(ids));
        }

        [HttpPut("disable")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DisableAds([Required] IList<int> ids)
        {
            return Ok(await _services.HideAds(ids));
        }

        [HttpPut("enable")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> EnableAds([Required] IList<int> ids)
        {
            return Ok(await _services.UnhideAds(ids));
        }

        [HttpGet("disabled")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<IEnumerable<Vehicle>> GetDisabledAds()
        {
            var cars = _services.GetDisabledAds();
            if (cars == null)
            {
                return NoContent();
            }
            else
            {
                return new ActionResult<IEnumerable<Vehicle>>(cars);
            }
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<Vehicle>> GetAds([FromHeader][Required] IList<int> ids)
        {
            IEnumerable<Vehicle> vs = _services.GetVehicles(ids);
            if (vs == null)
            {
                return NotFound();
            }
            else
            {
                return new ActionResult<IEnumerable<Vehicle>>(vs);
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Vehicle>> GetAd([Required] int id)
        {
            Vehicle v = await _services.GetVehicle(id);
            if (v == null)
            {
                return NotFound();
            }
            else
            {
                return v;
            }
        }
    }
}
