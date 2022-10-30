using FuelQueueManagement.models;
using FuelQueueManagement.Services;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FuelQueueManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        // GET: api/<UserController>
        [HttpGet]
        public ActionResult<List<models.User>> Get()
        {
            return userService.Get();
        }

        // GET api/<UserController>/5
        [HttpGet("/user/{email}")]
        public ActionResult<User> GetByEmail(string email)
        {
            var user = userService.GetByEmail(email);
            if (user == null)
                return NotFound($"Email: {email} not found");
            return Ok(user);
        }

        // POST api/<UserController>
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            userService.Create(user);
            return CreatedAtAction(nameof(Get), new {id = user.Id}, user);
        }

        // PUT api/<UserController>/5
        /*[HttpPut("/email/{email}")]
        public ActionResult Put(string email, [FromBody] User user)
        {
            var IsExistUser = userService.GetByEmail(email);
            if (IsExistUser == null)
                return NotFound($"User : {email} not found");
            userService.Update(IsExistUser.Id, user);
            return Ok(user);
        }*/

        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] User user)
        {
            var IsExistUser = userService.Get(id);
            if (IsExistUser == null)
                return NotFound($"User : {id} not found");
            userService.Update(id, user);
            return Ok(user);
        }

        // DELETE api/<UserController>/5
        /* [HttpDelete("{id}")]
         public void Delete(int id)
         {
         }*/
    }
}
