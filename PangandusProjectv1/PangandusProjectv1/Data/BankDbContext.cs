using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PangandusProjectv1.Models;

namespace PangandusProjectv1.Data
{
    public class BankDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public DbSet<Log> Logs { get; set; }

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
                entity.Property(u => u.DateJoined).IsRequired(); 
                entity.Property(u => u.LastLoginDate); 
            });

            builder.Entity<IdentityRole<Guid>>().HasData(
              new IdentityRole<Guid>
              {
                  Id = new Guid("a1b2c3d4-1234-5678-9012-345678901234"),
                  Name = "Admin",
                  NormalizedName = "ADMIN"
              }
          );


            builder.Entity<Log>(entity =>
            {
                entity.Property(l => l.Message).IsRequired();
                entity.Property(l => l.Level).HasMaxLength(20);
                entity.Property(l => l.Timestamp).IsRequired();
            });
        }


    }
}


