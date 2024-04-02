

using Infrastructure.Entities;

namespace Infrastructure.Models;

public class ContactModel                   //Kan nog ta bort
{
    public int Id { get; set; } 
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Service { get; set; }
    public string Message { get; set; } = null!;

    public static implicit operator ContactModel(ContactEntity contactentity)
    {
        return new ContactModel
        {
            Id = contactentity.Id,
            Name = contactentity.Name,
            Email = contactentity.Email,
            Service = contactentity.Service,
            Message = contactentity.Message
        };
    }
}
