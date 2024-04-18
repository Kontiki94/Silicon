using API_Silicon.Filters;
using Infrastructure.Context;
using Infrastructure.DTOs;
using Infrastructure.Entities;
using Infrastructure.Models;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Silicon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [UseApiKey]

    public class ContactController(DataContext context, ContactRepository contactRepository) : ControllerBase        
    {
        private readonly DataContext _context = context;
        private readonly ContactRepository _contactRepository = contactRepository;

        #region Create
        [HttpPost]
        public async Task<IActionResult> Create(ContactRegistrationDto ContactDto)
        {          
            
            try
            {
                if (ModelState.IsValid)
                {
                    ContactEntity contactEntity = ContactDto;
                    await _contactRepository.CreateAsync(contactEntity);

                    return Created("", null);
                }                                    
            }
            catch
            {
                return Problem("Something went wrong");
            }
            
            return BadRequest();
        }
        #endregion
               

    }
}
