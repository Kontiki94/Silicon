namespace Infrastructure.Entities;

public class CourseEntity
{
    public string Id { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string? Subtitle { get; set; }
    public string CourseImage { get; set; } = null!;
    public string? Rating { get; set; }
    public int? Reviews { get; set; }
    public decimal? Views { get; set; }
    public string? Likes { get; set; }
    public int? ViewHours { get; set; }
    public decimal Price { get; set; }
    public decimal? DiscountPrice { get; set; }
    public int? Articles { get; set; }
    public int? Resources { get; set; }
    public string? AccessTime { get; set; }
    public string? CourseDescription { get; set; }
    public List<string>? LearnPoints { get; set; }
    public List<string>? ProgramDetails { get; set; }
    public List<string>? Categories { get; set; }
    public AuthorEntity Author { get; set; } = new AuthorEntity();
}
