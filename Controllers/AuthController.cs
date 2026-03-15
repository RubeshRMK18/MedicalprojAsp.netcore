using MedicalprojAsp.netcore.Data;
using MedicalprojAsp.netcore.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MedicalprojAsp.netcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly IConfiguration _configuration;
        private PasswordHasher<Login> _PasswordHasher;

        public AuthController(AppDbContext appDbContext, IConfiguration configuration)
        {
            _appDbContext = appDbContext;
            _configuration = configuration;
            _PasswordHasher = new PasswordHasher<Login>();
        }

        [HttpPost("Register")]
        public IActionResult RegisterUser(Login Register)
        {
            var r = _appDbContext.Logins.FirstOrDefault(x => x.Username == Register.Username);
            if (r != null)
            {
                return BadRequest("User already registered");
            }
            //For hashing the password
            Register.Password = _PasswordHasher.HashPassword(Register , Register.Password);

            _appDbContext.Logins.Add(Register);
            _appDbContext.SaveChanges();
            return Ok("RegisteredUser Added Sucessfully");
        }

        [HttpPost("Login")]
        public IActionResult LoginUser(Login login)
        {
            var l = _appDbContext.Logins
                .FirstOrDefault(x => x.Username == login.Username);

            if (l == null)
            {
                return Unauthorized("Invalid Username");
            }

            var result = _PasswordHasher.VerifyHashedPassword(
                l,
                l.Password,
                login.Password);

            if (result == PasswordVerificationResult.Failed)
            {
                return Unauthorized("Invalid Username and password");
            }

            var token = GeneratejwtToken(l);

            return Ok(token);
        }

        private string GeneratejwtToken(Login login)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, login.Username)
            };

            var Key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["JWT:Key"])
                );
            var creds = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
