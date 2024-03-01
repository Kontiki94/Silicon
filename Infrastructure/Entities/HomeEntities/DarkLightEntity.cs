namespace Infrastructure.Entities.HomeEntities;

public class DarkLightEntity
{
    public int Id { get; set; }
    public string TitleWhite { get; set; } = null!;
    public string TitleBlack { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    public string ImageAlt { get; set; } = null!;
    public string IconUrl { get; set; } = null!;
    public string IconAlt { get; set; } = null!;
}

