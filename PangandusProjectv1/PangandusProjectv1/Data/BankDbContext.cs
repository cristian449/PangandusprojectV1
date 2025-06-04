using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PangandusProjectv1.Models;

namespace PangandusProjectv1.Data
{
    public class BankDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
    
        public BankDbContext(DbContextOptions<BankDbContext> options) 
            : base(options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>(entity =>
            {
                entity.Property(u => u.FirstName).HasMaxLength(50);
                entity.Property(u => u.LastName).HasMaxLength(50);
                entity.Property(u => u.DateOfBirth).IsRequired();
            });
        }
    }
}


