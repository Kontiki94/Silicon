using Infrastructure.Context;
using Infrastructure.Factories;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Silicon.Controllers;

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
                _context.Users.Add(UserFactory.Create(form));
                await _context.SaveChangesAsync();
                return Created("", null);
            }
            return Conflict();
        }
        return BadRequest();
    }
}
