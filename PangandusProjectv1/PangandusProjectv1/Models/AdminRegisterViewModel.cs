using System.ComponentModel.DataAnnotations;

namespace PangandusProjectv1.Models
{
    public class AdminRegisterViewModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public string DateOfBirth { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string AdminSecretKey { get; set; } // For admin registration validation as i dont know how else to do admins at the moment, may change later so
                                                   // i dont have to have seperate models and views for Admin
    }
}
