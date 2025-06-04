using System.ComponentModel.DataAnnotations;

namespace PangandusProjectv1.Models
{
    public class LoginViewModel
    {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            public bool RememberMe { get; set; } //Not Sure if this will work, just more so added this in for style more than anything else
        }

    }

