using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PangandusProjectv1.Models;

namespace PangandusProjectv1.Data
{
    public class BankDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
    
    public BankDbContext(DbContextOptions<BankDbContext> options) : base(options) { }
    }
}


