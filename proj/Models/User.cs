using System;
using Microsoft.AspNetCore.Identity;

namespace proj.Models
{
    public class User : IdentityUser
    {
        public string Username { get; set; } = default!;
        
        public string FirstName { get; set; } = default!;
        
        public string SecondName { get; set; } = default!;

        public string Role { get; set; } = default!;
        
    }
}