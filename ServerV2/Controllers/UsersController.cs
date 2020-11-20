using Backend;
using DataTypes;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServerV2.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IDatabase _db;

        public UsersController(IDatabase db)
        {
            _db = db;
        }

        // GET: api/<UsersController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<UsersController>/5
        [HttpGet("{user}")]
        public ActionResult<User> Get(string user, [FromHeader] string username, [FromHeader] string password)
        {
            if(user != username)
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
        [HttpGet("liked/{username}")]
        public ActionResult<IEnumerable<Car>> GetUserUploadedAds(string username, [FromHeader] SortingCriteria sortBy, [FromHeader] bool sortAscending, [FromHeader] int startIndex, [FromHeader] int amount)
        {
            var ads = _db.GetUserUploadedAds(username, sortBy, sortAscending, startIndex, amount);
            if(ads == null)
            {
                return NotFound();
            }
            else
            {
                return new ActionResult<IEnumerable<Car>>(ads);
            }
        }

        // POST api/<UsersController>
        [HttpPost]
        public ActionResult<User> Post([FromBody] User value)
        {
            return _db.AddUser(value) == null ? Conflict() : CreatedAtAction(nameof(Get), value);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{user}")]
        public IActionResult Put(string user, [FromHeader] string username, [FromHeader] string password, [FromBody] User value)
        {
            if (user != username)
            {
                return BadRequest();
            }

            // users cannot change username
            if (user != value.Username || value == null)
            {
                return BadRequest();
            }

            int result = _db.UpdateUser(username, password, value);
            return result switch
            {
                0 => NoContent(),
                -1 => NotFound(),
                -2 => Conflict(),
                _ => NotFound(),
            };
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{user}")]
        public IActionResult Delete(string user, [FromHeader] string username, [FromHeader] string password)
        {
            if (user != username)
            {
                return BadRequest();
            }

            return _db.DeleteUser(username, password) ? NoContent() : NotFound();
        }
    }
}
