namespace Infrastructure.Entities.HomeEntities;

public class ManageWorkEntity
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    public List<string> Features { get; set; } = [];
    public string ButtonText { get; set; } = null!;
    public string ButtonIcon { get; set; } = null!;
}
