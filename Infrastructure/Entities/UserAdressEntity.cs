
namespace Infrastructure.Entities
{
    public class UserAdressEntity
    {
        public string? UserId { get; set; }
        public UserEntity User { get; set; } = null!;

        public int AddressId { get; set; }
        public AddressEntity Address { get; set; } = null!;
    }
}
