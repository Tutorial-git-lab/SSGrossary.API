using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SSGrossary.Application.DTO;
using SSGrossary.Infranstructure;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace SSGrossary.API.Controllerss
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;
        public LoginController(ApplicationDbContext context,IConfiguration config)
        {

            _context = context;
            _config = config;
        }

        [HttpPost("Login")]

        public IActionResult Login(LoginRequest loginRequest)
        {
            var userData = _context.Users.FirstOrDefault(x => x.Email == loginRequest.Email && x.Password == loginRequest.Password);
            if (userData == null)
            {
                return Ok(new { name = "", success = "400" });


            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds=new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: null,
                expires: DateTime.Now.AddHours(Convert.ToDouble(_config["Jwt:ExpiresInHours"])),
                signingCredentials: creds
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(new {token=jwt, user = userData, success = "200" });

        }
    }
}
