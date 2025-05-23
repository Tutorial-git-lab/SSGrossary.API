using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SSGrossary.Domain.Entities;
using SSGrossary.Domain.Interfaces;

namespace SSGrossary.API.Controllerss
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRole _userRole;
        public UserRoleController(IUserRole userRole)
        {
            _userRole = userRole;
        }
        [HttpGet("GetAllUserRole")]
        public IActionResult GetAllUserRole()
        {
            return Ok(_userRole.GetAll());
        }

        [HttpPost("AddUserRole")]
        public IActionResult AddUserRole(UserRole userRole)
        {
            return Ok(_userRole.Add(userRole));
        }
        
    }
}
