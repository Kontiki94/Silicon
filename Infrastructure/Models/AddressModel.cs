namespace Infrastructure.Models;

public class AddressModel
{
    public string Id { get; set; } = null!;
    public string AddressLine1 { get; set; } = null!;
    public string? AddressLine2 { get; set; }
    public string PostalCode { get; set; } = null!;
    public string City { get; set; } = null!;
    public string UserId { get; set; } = null!;
}
