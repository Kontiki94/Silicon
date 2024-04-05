using API_Silicon.Filters;
using Infrastructure.Context;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Silicon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [UseApiKey]
    public class SubscriberController(DataContext context, SubscriberRepo subscriberRepo) : ControllerBase
    {
        private readonly DataContext _context = context;
        private readonly SubscriberRepo _subscriberRepo = subscriberRepo;

        [HttpPost]
        public async Task<IActionResult> Create(string email)
        {
            if (!string.IsNullOrEmpty(email))
            {
                if (!await _context.Subscribe.AnyAsync(x => x.Email == email))
                {
                    try
                    {
                        var subscriberEntity = new SubscribeEntity { Email = email };
                        await _subscriberRepo.CreateAsync(subscriberEntity);
                        return Created("", null);
                    }
                    catch
                    {
                        return Problem("Something went wrong");
                    }
                }
                return Conflict("This email is already registered");
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string email)
        {
            var result = await _subscriberRepo.DeleteOneAsync(x => x.Email == email);
            if (result)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
