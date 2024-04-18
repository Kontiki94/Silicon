<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities;

public class UserEntity : IdentityUser
{
    [Required]
    [ProtectedPersonalData]
    public string FirstName { get; set; } = null!;

    [Required]
    [ProtectedPersonalData]
    public string LastName { get; set; } = null!;

    [ProtectedPersonalData]
    public string? Biography { get; set; }
    public string? ProfileImageUrl { get; set; } = "profile-avatar.jpeg";
    public DateTime? Created { get; set; }
    public DateTime? Updated { get; set; }
    public bool IsExternalAccount { get; set; } = false;
    public List<int>? SavedCourseIds { get; set; } = new List<int>();

    public ICollection<UserAddressEntity> UserAddresses { get; set; } = new List<UserAddressEntity>();
}



=======
﻿namespace Infrastructure.Entities;

public class UserEntity
{
    public string Id { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string HashedPassword { get; set; } = null!;
    public string Salt { get; set; } = null!;
    public string SecurityKey { get; set; } = null!;
}
>>>>>>> 5093d5ff2a66cda979cdb5cac84ee5629d1021ef
