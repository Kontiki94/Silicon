using Infrastructure.DTOs;
using Infrastructure.Models;

namespace Infrastructure.Entities;

public class ContactEntity
{
    public int Id { get; set; } 
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Service { get; set; }
    public string Message { get; set; } = null!;


    public static implicit operator ContactEntity(ContactRegistrationDto ContactDto)
    {
        return new ContactEntity
        {
            Name = ContactDto.Name,
            Email = ContactDto.Email,
            Service = ContactDto.Service,
            Message = ContactDto.Message
        };
    }
}
