

namespace Infrastructure.Entities;

public class AuthorEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string? Youtube { get; set; }
    public string? Facebook { get; set; }
    public string? AuthorImage { get; set;}
}
