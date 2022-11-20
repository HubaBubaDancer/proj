using System.Data.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using proj.Models;

namespace proj.Data
{
    public class IdentityDbContext : IdentityDbContext<User>
    {
        
        
        public IdentityDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}