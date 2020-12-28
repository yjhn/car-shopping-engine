using Contracts.Incoming;
using Contracts.Outgoing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Repositories;
using Services.Services;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Server.Controllers
{
    /// <summary>
    /// Get, put, post, delete users, get their liked and uploaded ads
    /// </summary>
    [ApiExplorerSettings(GroupName = "client")]
    [Authorize]
    [Produces("application/json")]
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IRepoServices _services;

        public UsersController(IRepoServices services)
        {
            _services = services;
        }

        /// <summary>
        /// Gets user of the specified username (this method is used for login)
        /// </summary>
        /// <param name="username">Username of the user</param>
        /// <returns></returns>
        [HttpGet("{username}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<OutgoingUserDTO>> GetUser([Required] string username)
        {
            string user = HttpContext.User.Identity.Name;
            if (username == null || user != username)
                return BadRequest();

            var u = await _services.GetUser(user);
            return u == null ? NotFound() : u;
        }

        /// <summary>
        /// Gets vehicles liked by the specified user
        /// </summary>
        /// <param name="username">Username of the user whose liked vehicles are requested</param>
        /// <param name="sortBy">How to sort the vehicles</param>
        /// <param name="sortAscending">true - sort ascending, false - sort descending</param>
        /// <param name="startIndex">How many vehicles to skip from the start of the sorted list</param>
        /// <param name="amount">How many results to return</param>
        /// <returns></returns>
        [HttpGet("liked/{username}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IEnumerable<OutgoingVehicleDTO>>> GetUserLikedAds(
            [Required] string username,
            [FromHeader][DefaultValue(SortingCriteria.UploadDate)] SortingCriteria sortBy,
            [FromHeader][DefaultValue(false)] bool sortAscending,
            [FromHeader][DefaultValue(0)] int startIndex,
            [FromHeader][DefaultValue(10)] int amount)
        {
            string user = HttpContext.User.Identity.Name;
            if (username == null || user != username)
                return BadRequest();

            var ads = await _services.GetUserLikedAds(username, sortBy, sortAscending, startIndex, amount);
            return ads == null ? 
                NoContent() : 
                new ActionResult<IEnumerable<OutgoingVehicleDTO>>(ads);
        }

        /// <summary>
        /// Gets vehicles uploaded by the specified user
        /// </summary>
        /// <param name="username">Username of the user whose uploaded ads are requested</param>
        /// <param name="sortBy">How to sort the vehicles</param>
        /// <param name="sortAscending">true - sort ascending, false - sort descending</param>
        /// <param name="startIndex">How many vehicles to skip from the start of the sorted list</param>
        /// <param name="amount">How many results to return</param>
        /// <returns></returns>
        [HttpGet("uploaded/{username}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<OutgoingVehicleDTO>>> GetUserUploadedAds(
            [Required] string username,
            [FromHeader][DefaultValue(SortingCriteria.UploadDate)] SortingCriteria sortBy,
            [FromHeader][DefaultValue(false)] bool sortAscending,
            [FromHeader][DefaultValue(0)] int startIndex,
            [FromHeader][DefaultValue(10)] int amount)
        {
            if (username == null)
                return BadRequest();

            var ads = await _services.GetUserUploadedAds(username, sortBy, sortAscending, startIndex, amount);
            return ads == null ? 
                NotFound() : 
                new ActionResult<IEnumerable<OutgoingVehicleDTO>>(ads);
        }

        /// <summary>
        /// Adds new user
        /// </summary>
        /// <param name="value">New user info</param>
        /// <returns></returns>
        [HttpPost("new")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<IncomingUserDTO>> PostUser([FromBody][Required] IncomingUserDTO value)
        {
            if (value == null)
                return BadRequest();

            return await _services.AddUser(value) == null ? 
                Conflict() : 
                StatusCode(201, value);
        }

        /// <summary>
        /// Updates an existing user. Users can only update themselves
        /// </summary>
        /// <param name="username">Username of the user to update</param>
        /// <param name="value">Updated user info</param>
        /// <returns></returns>
        [HttpPut("{username}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutUser([Required] string username, [FromBody][Required] IncomingUserDTO value)
        {
            string user = HttpContext.User.Identity.Name;
            if (value == null || value.Username != username || user != username || user != value.Username)
                return BadRequest();

            return await _services.UpdateUser(username, value) ? Ok() : NotFound();
        }

        /// <summary>
        /// Deletes the specified user. Users can only delete themselves. CAUTION: also deletes all ads uploaded by the user
        /// </summary>
        /// <param name="username">Username of the user to delete</param>
        /// <returns></returns>
        [HttpDelete("{username}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteUser([Required] string username)
        {
            string user = HttpContext.User.Identity.Name;
            if (user != username)
                return BadRequest();

            return await _services.DeleteUser(username) ? Ok() : NotFound();
        }
    }
}
