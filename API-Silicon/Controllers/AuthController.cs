using API_Silicon.Filters;
using Infrastructure.Context;
using Infrastructure.Factories;
using Infrastructure.Helpers;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API_Silicon.Controllers;

[Route("api/[controller]")]
[ApiController] // Ta bort den här och du får inputfält istället på Swagger
public class AuthController(DataContext context, IConfiguration configuration) : ControllerBase
{
    private readonly DataContext _context = context;
    private readonly IConfiguration _configuration = configuration;

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register(UserRegistrationForm form)
    {
        if (ModelState.IsValid)
        {
            if (!await _context.Users.AnyAsync(x => x.Email == form.Email))
            {
                var userEntity = UserFactory.Create(form);
                _context.Users.Add(userEntity);
                await _context.SaveChangesAsync();
                return Created("", null);
            }
            return Conflict();
        }
        return BadRequest();
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(UserLoginForm form)
    {
        if (ModelState.IsValid)
        {
            var userEntity = await _context.Users.FirstOrDefaultAsync(x => x.Email == form.Email);
            if (userEntity != null && PasswordHasher.ValidateSecurePassword(form.Password, userEntity.HashedPassword, userEntity.Salt, userEntity.SecurityKey))
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]!);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new(ClaimTypes.NameIdentifier, userEntity.Id.ToString()),
                        new(ClaimTypes.Email, userEntity.Email),
                        new(ClaimTypes.Name, userEntity.Email)
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    Issuer = _configuration["Jwt:Issuer"],
                    Audience = _configuration["Jwt:Audience"],
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                return Ok(new { Token = tokenString });
            }
        }
        return Unauthorized();
    }

    [UseApiKey]
    [HttpPost]
    [Route("token")]
    public IActionResult GetToken(UserLoginForm form)
    {
        if (ModelState.IsValid)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]!);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                        new(ClaimTypes.NameIdentifier, form.Email),
                        new(ClaimTypes.Email, form.Email),
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(tokenString);
        }

        return Unauthorized();
    }
}
