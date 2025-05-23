using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SSGrossary.Domain.Entities;
using SSGrossary.Domain.Interfaces;

namespace SSGrossary.API.Controllerss
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRole _role;
        public RoleController(IRole role)
        {
            _role = role;
        }
        [HttpPost("AddRole")]
        public IActionResult AddRole(Role role)
        {
            if (role == null)
                return BadRequest("InvalId Role data.");
            var result = _role.Add(role);
            return Ok("Role added successfully.");
        }
        [HttpGet("GetAllRole")]
        public IActionResult GetAllRole()
        {
            return Ok(_role.GetAll());
        }

        [HttpGet("GetRoleById/{Id}")]
        public IActionResult GetRole(int Id)
        {
            var role = _role.GetById(Id);
            if (role == null)
                return NotFound($"role with Id {Id} not found.");

            return Ok(role);
        }

        [HttpPut("UpdateRole/{Id}")]
        public IActionResult UpdateRole(int Id, Role role)
        {
            if (role == null || role.Id != Id)
                return BadRequest("InvalId role data.");
            var result = _role.Update(role);
            return Ok("Role updated successfully.");

        }

        [HttpDelete("DeleteRole/{Id}")]
        public IActionResult DeleteCountry(int Id)
        {
            var result = _role.Delete(Id);
            return Ok("Role deleted successfully.");
        }
    }
}
