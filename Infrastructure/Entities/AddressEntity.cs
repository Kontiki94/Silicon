namespace Infrastructure.Entitys;

public class AddressEntity
{
    public int Id { get; set; }
    public string UserId { get; set; } = null!;
    public UserEntity User { get; set; } = null!;
    public string StreetName { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string City { get; set; } = null!;
}
