using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SSGrossary.API.DTO.Request;
using SSGrossary.Domain.Entities;
using SSGrossary.Domain.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SSGrossary.API.Controllerss
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _user;
        private readonly IRole _role;
        private readonly IUserRole _userRole;
        private readonly IConfiguration _config;
        public UserController(IUser user, IRole role, IUserRole userRole, IConfiguration config)
        {
            _user = user;
            _role = role;
            _userRole = userRole;
            _config = config;
        }

        [HttpGet("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            return Ok(_user.GetAll());
        }
        [HttpPost("Register")]
        public IActionResult Register(RegisterRequest registerRequest)
        {
            User user = new User()
            {
                Id = registerRequest.Id,
                Name = registerRequest.Name,
                Email = registerRequest.Email,
                Password = registerRequest.Password,
            };
            var result = _user.Add(user);
            return Ok("Register successfully.");
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginRequest loginRequest)
        {
            var user = _user.Login(loginRequest.Email, loginRequest.Password);
            if (user == null)
                return Ok(new { token = "", name = "", role = "", success = "400" });
            var userRole = _userRole.GetById(user.Id);

            if (userRole == null)
                return Ok(new { token = "", name = "", role = "", success = "401" });
            else
            {
                var role = _role.GetById(userRole.RoleId);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Role, role.Name),
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: _config["Jwt:Issuer"],
                    audience: _config["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddHours(Convert.ToDouble(_config["Jwt:ExpiresInHours"])),
                    signingCredentials: creds
                    );

                var jwt = new JwtSecurityTokenHandler().WriteToken(token);
                return Ok(new { token = jwt, user = user, role = role, success = "200" });
            }

        }
    }
}
