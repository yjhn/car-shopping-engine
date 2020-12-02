using Backend;
using DataTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServerV2.Controllers
{
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

        // GET api/<UsersController>/5
        [Authorize]
        [HttpGet("{username}")]
        public ActionResult<User> GetUser(string username)
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

        // GET api/<UsersController>/5
        [Authorize]
        [HttpGet("liked/{username}")]
        public ActionResult<IEnumerable<Car>> GetUserLikedAds(string username, [FromHeader] SortingCriteria sortBy, [FromHeader] bool sortAscending, [FromHeader] int startIndex, [FromHeader] int amount)
        {
            string user = HttpContext.User.Identity.Name;
            if (username == null || user != username)
            {
                return BadRequest();
            }

            var ads = _db.GetUserLikedAds(username, sortBy, sortAscending, startIndex, amount);
            if (ads == null)
            {
                return NotFound();
            }
            else
            {
                return new ActionResult<IEnumerable<Car>>(ads);
            }
        }

        // GET api/<UsersController>/5
        [HttpGet("uploaded/{username}")]
        public ActionResult<IEnumerable<Car>> GetUserUploadedAds(string username, [FromHeader] SortingCriteria sortBy, [FromHeader] bool sortAscending, [FromHeader] int startIndex, [FromHeader] int amount)
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

        /// <response code="201">Returns the newly created item</response>
        /// <response code="409">If the item is duplicate</response> 
        // POST api/<UsersController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public ActionResult<User> PostUser([FromBody] User value)
        {
            if (value == null)
            {
                return BadRequest();
            }

            return _db.AddUser(value) == null ? Conflict() : StatusCode(201, value);
        }

        // PUT api/<UsersController>/5
        [Authorize]
        [HttpPut("{username}")]
        public IActionResult PutUser(string username, [FromBody] User value)
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

        // DELETE api/<UsersController>/5
        [Authorize]
        [HttpDelete("{username}")]
        public IActionResult DeleteUser(string username)
        {
            string user = HttpContext.User.Identity.Name;
            if (user != username)
            {
                return BadRequest();
            }

            return _db.DeleteUser(username) ? NoContent() : NotFound();
        }
    }
}
