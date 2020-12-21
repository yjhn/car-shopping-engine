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
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IRepoServices _services;

        public UsersController(IRepoServices services)
        {
            _services = services;
        }

        [HttpGet("{username}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<OutgoingUserDTO>> GetUser([Required] string username)
        {
            string user = HttpContext.User.Identity.Name;
            if (username == null || user != username)
            {
                return BadRequest();
            }

            var u = await _services.GetUser(user);
            if (u == null)
            {
                return NotFound();
            }
            else
            {
                return u;
            }
        }

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
            {
                return BadRequest();
            }

            var ads = await _services.GetUserLikedAds(username, sortBy, sortAscending, startIndex, amount);
            if (ads == null)
            {
                return NoContent();
            }
            else
            {
                return new ActionResult<IEnumerable<OutgoingVehicleDTO>>(ads);
            }
        }

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
            {
                return BadRequest();
            }

            var ads = await _services.GetUserUploadedAds(username, sortBy, sortAscending, startIndex, amount);
            if (ads == null)
            {
                return NotFound();
            }
            else
            {
                return new ActionResult<IEnumerable<OutgoingVehicleDTO>>(ads);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<IncomingUserDTO>> PostUser([FromBody][Required] IncomingUserDTO value)
        {
            if (value == null)
            {
                return BadRequest();
            }

            return await _services.AddUser(value) == null ? Conflict() : StatusCode(201, value);
        }

        [HttpPut("{username}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutUser([Required] string username, [FromBody][Required] IncomingUserDTO value)
        {
            string user = HttpContext.User.Identity.Name;
            if (user != username || user != value.Username || value == null)
            {
                return BadRequest();
            }

            if (await _services.UpdateUser(username, value))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{username}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteUser([Required] string username)
        {
            string user = HttpContext.User.Identity.Name;
            if (user != username)
            {
                return BadRequest();
            }

            return await _services.DeleteUser(username) ? Ok() : NotFound();
        }


        // Admin methods //

        [HttpGet("full/{username}")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<User>> GetFullUser([Required] string username)
        {
            if (username == null)
            {
                return BadRequest();
            }

            var u = await _services.GetFullUser(username);
            if (u == null)
            {
                return NotFound();
            }
            else
            {
                return u;
            }
        }

        [HttpDelete]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteUsers([Required] string[] usernames)
        {
            return Ok(await _services.DeleteUsers(usernames));
        }

        [HttpPut("disable")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DisableUsers([Required] string[] usernames)
        {
            return Ok(await _services.DisableUsers(usernames));
        }

        [HttpPut("enable")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> EnableUsers([Required] string[] usernames)
        {
            return Ok(await _services.EnableUsers(usernames));
        }

        [HttpGet("disabled")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<IEnumerable<User>> GetDisabledUsers()
        {
            var users = _services.GetDisabledUsers();
            if (users == null)
            {
                return NoContent();
            }
            else
            {
                return new ActionResult<IEnumerable<User>>(users);
            }
        }
    }
}
