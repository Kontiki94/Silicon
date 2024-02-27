using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entitys;

public class UserCredentialsEntity
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("User")]
    public int UserId { get; set; }

    [Required]
    public string Salt { get; set; } = null!;

    [MaxLength(100)]
    public string HashedPassword { get; set; } = null!;

    [Column("Security_Key")]
    [MaxLength(64)]
    public string SecurityKey { get; set; } = null!;
}
