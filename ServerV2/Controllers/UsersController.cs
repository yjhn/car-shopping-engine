using Backend;
using DataTypes;
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
        [HttpGet("{user}")]
        public ActionResult<User> GetUser(string user, [FromHeader] string username, [FromHeader] string password)
        {
            if (username == null || password == null || user != username)
            {
                return BadRequest();
            }

            var u = _db.GetUser(username, password);
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
        [HttpGet("liked/{user}")]
        public ActionResult<IEnumerable<Car>> GetUserLikedAds(string user, [FromHeader] string username, [FromHeader] string password, [FromHeader] SortingCriteria sortBy, [FromHeader] bool sortAscending, [FromHeader] int startIndex, [FromHeader] int amount)
        {
            if (username == null || password == null || user != username)
            {
                return BadRequest();
            }

            var ads = _db.GetUserLikedAds(username, password, sortBy, sortAscending, startIndex, amount);
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
        [HttpPut("{user}")]
        public IActionResult PutUser(string user, [FromHeader] string username, [FromHeader] string password, [FromBody] User value)
        {
            if (user != username || user != value.Username || value == null)
            {
                return BadRequest();
            }

            if (_db.UpdateUser(username, password, value))
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{user}")]
        public IActionResult DeleteUser(string user, [FromHeader] string username, [FromHeader] string password)
        {
            if (user != username)
            {
                return BadRequest();
            }

            return _db.DeleteUser(username, password) ? NoContent() : NotFound();
        }
    }
}
