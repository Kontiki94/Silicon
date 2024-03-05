using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entitys;

public class UserEntity : IdentityUser
{

    [Required]
    public string FirstName { get; set; } = null!;
    [Required]
    public string LastName { get; set; } = null!;
    public string? Biography { get; set; }
    public DateTime? Created { get; set; }
    public DateTime? Updated { get; set; }

    public ICollection<AddressEntity> Address { get; set; } = new List<AddressEntity>();
}
