using Contracts.Incoming;
using Contracts.Outgoing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Services;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Server.Controllers
{
    /// <summary>
    /// These methods are only accessible with an administrator account
    /// </summary>
    [ApiExplorerSettings(GroupName = "admin")]
    [Authorize(Roles = UserRole.Admin)]
    [Produces("application/json")]
    [Route("api/admin-actions")]
    [ApiController]
    public class AdminActionsController : ControllerBase
    {
        private readonly IRepoServices _services;

        public AdminActionsController(IRepoServices services)
        {
            _services = services;
        }

        /// <summary>
        /// Adds new user (all properties can be specified)
        /// </summary>
        /// <param name="value">New user info</param>
        /// <returns></returns>
        [HttpPost("new")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<IncomingFullUserDTO>> PostFullUser([FromBody][Required] IncomingFullUserDTO value)
        {
            return value == null ? 
                BadRequest() :
                await _services.AddFullUser(value) == null ? Conflict() : StatusCode(201, value);
        }

        /// <summary>
        /// Gets all user info
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        [HttpGet("user/{username}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<OutgoingFullUserDTO>> GetFullUser([Required] string username)
        {
            if (username == null)
                return BadRequest();

            var u = await _services.GetFullUser(username);
            return u == null ? NotFound() : u;
        }

        /// <summary>
        /// Deletes users with specified usernames. CAUTION: also deletes all ads uploaded by them
        /// </summary>
        /// <param name="usernames">Username of the users to be deleted</param>
        /// <returns></returns>
        [HttpDelete("users")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<int>> DeleteUsers([Required] string[] usernames)
        {
            return Ok(await _services.DeleteUsers(usernames));
        }

        /// <summary>
        /// Disables users with specified usernames
        /// </summary>
        /// <param name="usernames">Usernames of the users to be disabled</param>
        /// <returns></returns>
        [HttpPut("users/disable")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<int>> DisableUsers([Required] string[] usernames)
        {
            return Ok(await _services.DisableUsers(usernames));
        }

        /// <summary>
        /// Enables users with specified usernames
        /// </summary>
        /// <param name="usernames">Usernames of the users to be enabled</param>
        /// <returns></returns>
        [HttpPut("users/enable")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<int>> EnableUsers([Required] string[] usernames)
        {
            return Ok(await _services.EnableUsers(usernames));
        }

        /// <summary>
        /// Gets all disabled users
        /// </summary>
        /// <returns></returns>
        [HttpGet("users/disabled")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<IEnumerable<OutgoingFullUserDTO>> GetDisabledUsers()
        {
            var users = _services.GetDisabledUsers();
            return users == null ? 
                NoContent() :
                new ActionResult<IEnumerable<OutgoingFullUserDTO>>(users);
        }

        /// <summary>
        /// Deletes ads with specified IDs
        /// </summary>
        /// <param name="ids">IDs of the ads to be deleted</param>
        /// <returns></returns>
        [HttpDelete("ads")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<int>> DeleteAds([Required] IList<int> ids)
        {
            return Ok(await _services.DeleteVehicles(ids));
        }

        /// <summary>
        /// Hides ads with specified IDs
        /// </summary>
        /// <param name="ids">IDs of the adds to hide</param>
        /// <returns></returns>
        [HttpPut("ads/hide")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<int>> HideAds([Required] IList<int> ids)
        {
            return Ok(await _services.HideAds(ids));
        }

        /// <summary>
        /// Unhides ads with the specified IDs
        /// </summary>
        /// <param name="ids">IDs of the ads to unhide</param>
        /// <returns></returns>
        [HttpPut("ads/unhide")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<int>> UnhideAds([Required] IList<int> ids)
        {
            return Ok(await _services.UnhideAds(ids));
        }

        /// <summary>
        /// Gets all hidden ads
        /// </summary>
        /// <returns></returns>
        [HttpGet("ads/hidden")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<IEnumerable<OutgoingFullVehicleDTO>> GetHiddenAds()
        {
            var cars = _services.GetDisabledAds();
            return cars == null ?
                NoContent() :
                new ActionResult<IEnumerable<OutgoingFullVehicleDTO>>(cars);
        }

        /// <summary>
        /// Gets ads with specified IDs
        /// </summary>
        /// <param name="ids">IDs of the ads</param>
        /// <returns></returns>
        [HttpGet("ads")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<IEnumerable<OutgoingFullVehicleDTO>> GetAds([FromHeader][Required] IList<int> ids)
        {
            IEnumerable<OutgoingFullVehicleDTO> vs = _services.GetVehicles(ids);
            return vs == null ? 
                NoContent() : 
                new ActionResult<IEnumerable<OutgoingFullVehicleDTO>>(vs);
        }

        /// <summary>
        /// Gets an ad with specified ID
        /// </summary>
        /// <param name="id">ID of the ad</param>
        /// <returns></returns>
        [HttpGet("ad/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OutgoingFullVehicleDTO>> GetAd([Required] int id)
        {
            OutgoingFullVehicleDTO v = await _services.GetVehicle(id);
            return v == null ? NotFound() : v;
        }
    }
}
