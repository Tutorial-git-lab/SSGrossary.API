using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using SSGrossary.Application.DTO;
using SSGrossary.Domain.Entities;
using SSGrossary.Domain.Interfaces;
using SSGrossary.Infranstructure.Repository;
using LoginRequest = SSGrossary.Application.DTO.LoginRequest;

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

        [HttpPost("Login")]
        public IActionResult Login(LoginRequest loginRequest)
        {
            _user.Login(loginRequest);
            return Ok("LoggedIn successfully");
        }

    }
}
