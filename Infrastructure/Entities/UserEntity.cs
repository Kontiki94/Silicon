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
    public DateTime? Created { get; set; }
    public DateTime? Updated { get; set; }
    public bool IsExternalAccount { get; set; } = false;

    public ICollection<UserAddressEntity> UserAddresses { get; set; } = new List<UserAddressEntity>();
}



