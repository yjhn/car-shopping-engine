using Contracts.Incoming;
using Contracts.Outgoing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Repositories;
using Services.Services;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Server.Controllers
{
    /// <summary>
    /// Get sorted or filtered vehicles, upload, update or delete vehicles
    /// </summary>
    [ApiExplorerSettings(GroupName = "client")]
    [Authorize]
    [Produces("application/json")]
    [Route("api/vehicles")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IRepoServices _services;

        public VehiclesController(IRepoServices services)
        {
            _services = services;
        }

        /// <summary>
        /// Gets vehicles similar to the one in the image
        /// </summary>
        /// <param name="_">Image file to process</param>
        /// <param name="sortBy">How to sort the vehicles</param>
        /// <param name="sortAscending">true - sort ascending, false - sort descending</param>
        /// <param name="startIndex">How many vehicles to skip from the start of the sorted list</param>
        /// <param name="amount">How many results to return</param>
        /// <returns></returns>
        [HttpPost("by-photo")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Consumes("application/octet-stream")]
        public async Task<ActionResult<IEnumerable<OutgoingVehicleDTO>>> GetVehiclesByPhoto(
            [FromForm, Required, SwaggerRequestBody("Image file to process")] object _,
            [FromHeader, DefaultValue(SortingCriteria.UploadDate)] SortingCriteria sortBy,
            [FromHeader, DefaultValue(false)] bool sortAscending,
            [FromHeader, DefaultValue(0)] int startIndex,
            [FromHeader, DefaultValue(10)] int amount)
        {
            // We have to define ethod parameter as otherwise Swagger thinks that there are no parameters

            // Because ASP .NET cannot map "application/octet-stream" to any type, we have to read http body manually
            var image = HttpContext.Request.Body;

            var result = await _services.GetVehiclesByImage(image, sortBy, sortAscending, startIndex, amount);
            if (result == null)
            {
                // cannot return NoContent, because then it return nothing (but should return empty array [])
                return new ActionResult<IEnumerable<OutgoingVehicleDTO>>(Array.Empty<OutgoingVehicleDTO>());
            }
            else
                return new ActionResult<IEnumerable<OutgoingVehicleDTO>>(result);
        }

        /// <summary>
        /// Gets sorted vehicles
        /// </summary>
        /// <param name="sortBy">How to sort the vehicles</param>
        /// <param name="sortAscending">true - sort ascending, false - sort descending</param>
        /// <param name="startIndex">How many vehicles to skip from the start of the sorted list</param>
        /// <param name="amount">How many results to return</param>
        /// <returns></returns>
        [HttpGet("sorted")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<IEnumerable<OutgoingVehicleDTO>> GetSortedAds(
            [FromHeader, DefaultValue(SortingCriteria.UploadDate)] SortingCriteria sortBy,
            [FromHeader, DefaultValue(false)] bool sortAscending,
            [FromHeader, DefaultValue(0)] int startIndex,
            [FromHeader, DefaultValue(10)] int amount)
        {
            var cars = _services.GetSortedVehicles(sortBy, sortAscending, startIndex, amount);
            return cars == null ? NoContent() : new ActionResult<IEnumerable<OutgoingVehicleDTO>>(cars);
        }

        /// <summary>
        /// Gets vehicles that satisfy certain search criteria
        /// </summary>
        /// <param name="sortBy">How to sort the vehicles</param>
        /// <param name="sortAscending">true - sort ascending, false - sort descending</param>
        /// <param name="startIndex">How many vehicles to skip from the start of the sorted list</param>
        /// <param name="amount">How many results to return</param>
        /// <param name="brand">Brand of the vehicle</param>
        /// <param name="model">Model of the vehicle</param>
        /// <param name="used">true - vehicle is used, false - vehicle is new</param>
        /// <param name="priceFrom">Lower price limit</param>
        /// <param name="priceTo">Upper price limit</param>
        /// <param name="uploaderUsername">Username of the user who uploaded the vehicle</param>
        /// <param name="yearFrom">Lower year limit</param>
        /// <param name="yearTo">Upper year limit</param>
        /// <param name="fuelType">Fuel type of the vehicle</param>
        /// <param name="chassisType">Type of the vehicle</param>
        /// <returns></returns>
        [HttpGet("filtered")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<IEnumerable<OutgoingVehicleDTO>> GetFilteredAds(
            [FromHeader, DefaultValue(SortingCriteria.UploadDate)] SortingCriteria sortBy,
            [FromHeader, DefaultValue(false)] bool sortAscending,
            [FromHeader, DefaultValue(0)] int startIndex,
            [FromHeader, DefaultValue(10)] int amount,
            [FromHeader] string brand = null,
            [FromHeader] string model = null,
            [FromHeader] bool? used = null,
            [FromHeader] int? priceFrom = null,
            [FromHeader] int? priceTo = null,
            [FromHeader] string uploaderUsername = null,
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
                Username = uploaderUsername,
                YearFrom = yearFrom,
                YearTo = yearTo,
                FuelType = fuelType,
                ChassisType = chassisType
            };
            var cars = _services.GetFilteredVehicles(filters, sortBy, sortAscending, startIndex, amount);
            return cars == null ? NoContent() : new ActionResult<IEnumerable<OutgoingVehicleDTO>>(cars);
        }

        /// <summary>
        /// Uploads vehicle data. Vehicle's uploader is the user who sent the request
        /// </summary>
        /// <param name="vehicle">Vehicle data</param>
        /// <returns></returns>
        [HttpPost("new")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PostVehicleDTO>> PostAd([FromBody, Required] PostVehicleDTO vehicle)
        {
            string username = HttpContext.User.Identity.Name;
            if (vehicle == null || !HttpContext.User.Identity.IsAuthenticated)
                return BadRequest();

            return await _services.AddVehicle(username, vehicle) ? StatusCode(201, vehicle) : BadRequest();
        }

        /// <summary>
        /// Updates existing vehicle data. Only the user who uploaded the vehicle data can update it
        /// </summary>
        /// <param name="vehicle">Updated vehicle data</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutAd([FromBody, Required] PutVehicleDTO vehicle)
        {
            string username = HttpContext.User.Identity.Name;
            if (vehicle == null || !HttpContext.User.Identity.IsAuthenticated)
                return BadRequest();

            return await _services.UpdateVehicle(username, vehicle) ? Ok() : NotFound();
        }

        /// <summary>
        /// Deletes data of a specific vehicle. Only the user who uploaded the vehicle data can delete it
        /// </summary>
        /// <param name="id">Vehicle id</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAd([Required] int id)
        {
            string user = HttpContext.User.Identity.Name;
            return await _services.DeleteVehicle(id, user) ? Ok() : NotFound();
        }
    }
}
