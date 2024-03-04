using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entitys;

public class UserCredentialsEntity
{
    [Key]
    public string Id { get; set; } = null!;

    [ForeignKey("User")]
    public string? UserId { get; set; }

    [Required]
    public string Salt { get; set; } = null!;

    [MaxLength(100)]
    public string HashedPassword { get; set; } = null!;

    [Column("Security_Key")]
    [MaxLength(64)]
    public string SecurityKey { get; set; } = null!;

    public void Deconstruct(out string salt, out string hashedPassword)
    {
        salt = Salt;
        hashedPassword = HashedPassword;
    }
}
