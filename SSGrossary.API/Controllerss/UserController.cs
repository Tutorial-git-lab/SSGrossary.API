using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SSGrossary.Domain.Entities;
using SSGrossary.Infranstructure.Repository;

namespace SSGrossary.API.Controllerss
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _user;
        public UserController(IUser user)
        {
            _user = user;
            
        }

        [HttpGet("GetAllUsers")]
        public IActionResult GetAll()
        {
            return Ok(_user.GetAll());
        }

        [HttpPost("AddUser")]
        public IActionResult AddUser(User user)
        {
            return Ok(_user.Add(user));
        }

        [HttpPut("UpdateUser")]
        public IActionResult UpdateUser(User user)
        {
            return Ok(_user.Update(user));
        }

        [HttpDelete("DeleteUser")]
        public IActionResult DeleteUser(int Id)
        {
            return Ok(_user.Delete(Id));
        }

    }
}
