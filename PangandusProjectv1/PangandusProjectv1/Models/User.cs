using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace PangandusProjectv1.Models
{
    public class User : IdentityUser<Guid>
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        [DataType(DataType.Currency)]
        public decimal AccountBalance { get; set; } = 0;

        public bool IsAdministrator { get; set; } = false;
        public DateTime? AdminSince { get; set; }
    }
}
