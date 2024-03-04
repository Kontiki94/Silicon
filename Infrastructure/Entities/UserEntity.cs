using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entitys;

public class UserEntity
{
    [Key]
    public string Id { get; set; } = null!;
    [Required]
    public string FirstName { get; set; } = null!;
    [Required]
    public string LastName { get; set; } = null!;
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;
    [Required]
    public string Password { get; set; } = null!;
    public string? Phone { get; set; }
    public string? Biography { get; set; }
    public DateTime? Created { get; set; }
    public DateTime? Updated { get; set; }

    // Creating one to many relations with Credentials and Address
    public ICollection<UserCredentialsEntity> Credentials { get; set; } = new List<UserCredentialsEntity>();
    public ICollection<AddressEntity> Address { get; set; } = new List<AddressEntity>();
}
