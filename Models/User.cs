﻿using Microsoft.AspNetCore.Identity;

namespace IdentityGuard.Models
{
    public class User : IdentityUser
    {
        public DateTime BirthDate { get; set; }
        public User() : base() { }
    }
}
