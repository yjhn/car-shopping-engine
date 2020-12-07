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
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IDatabase _db;

        public UsersController(IDatabase db)
        {
            _db = db;
        }

        [HttpGet("{username}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<User> GetUser([Required] string username)
        {
            string user = HttpContext.User.Identity.Name;
            if (username == null || user != username)
            {
                return BadRequest();
            }

            var u = _db.GetUser(user);
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<User>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<Car>> GetUserLikedAds([Required] string username,
                                                              [FromHeader][Required] SortingCriteria sortBy,
                                                              [FromHeader][Required] bool sortAscending,
                                                              [FromHeader][Required] int startIndex,
                                                              [FromHeader][Required] int amount)
        {
            string user = HttpContext.User.Identity.Name;
            if (username == null || user != username)
            {
                return BadRequest();
            }

            var ads = _db.GetUserLikedAds(username, sortBy, sortAscending, startIndex, amount);
            if (ads == null)
            {
                return NoContent();
            }
            else
            {
                return new ActionResult<IEnumerable<Car>>(ads);
            }
        }

        [HttpGet("uploaded/{username}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Car>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<Car>> GetUserUploadedAds([Required] string username,
                                                                 [FromHeader][Required] SortingCriteria sortBy,
                                                                 [FromHeader][Required] bool sortAscending,
                                                                 [FromHeader][Required] int startIndex,
                                                                 [FromHeader][Required] int amount)
        {
            if (username == null)
            {
                return BadRequest();
            }

            var ads = _db.GetUserUploadedAds(username, sortBy, sortAscending, startIndex, amount);
            if (ads == null)
            {
                return NotFound();
            }
            else
            {
                return new ActionResult<IEnumerable<Car>>(ads);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public ActionResult<User> PostUser([FromBody][Required] User value)
        {
            if (value == null)
            {
                return BadRequest();
            }

            return _db.AddUser(value) == null ? Conflict() : StatusCode(201, value);
        }

        [HttpPut("{username}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult PutUser([Required] string username, [FromBody][Required] User value)
        {
            string user = HttpContext.User.Identity.Name;
            if (user != username || user != value.Username || value == null)
            {
                return BadRequest();
            }

            if (_db.UpdateUser(username, value))
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{username}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteUser([Required] string username)
        {
            string user = HttpContext.User.Identity.Name;
            if (user != username)
            {
                return BadRequest();
            }

            return _db.DeleteUser(username) ? NoContent() : NotFound();
        }


        // Admin methods //

        [HttpGet("full/{username}")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<User> GetFullUser([Required] string username)
        {
            if (username == null)
            {
                return BadRequest();
            }

            var u = _db.GetUser(username);
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
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteUsers([Required] string[] usernames)
        {
            return _db.DeleteUsers(usernames) > 0 ? NoContent() : NotFound();
        }

        [HttpPut("disable")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DisableUsers([Required] string[] usernames)
        {
            User user;
            foreach (string u in usernames)
            {
                user = _db.GetUser(u);
                if (user != null)
                {
                    user.Disabled = true;
                    _db.UpdateUser(u, user);
                }
            }
            return NoContent();
        }

        [HttpPut("enable")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult EnableUsers([Required] string[] usernames)
        {
            User user;
            foreach (string u in usernames)
            {
                user = _db.GetUser(u);
                if (user != null)
                {
                    user.Disabled = false;
                    _db.UpdateUser(u, user);
                }
            }
            return NoContent();
        }

        [HttpGet("disabled")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<User>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<IEnumerable<User>> GetDisabledUsers()
        {
            var users = _db.GetDisabledUsers();
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
