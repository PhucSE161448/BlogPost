using System.ComponentModel.DataAnnotations;

namespace Assignment2PRN221_BlogPost.ViewModels
{
    public class Login
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
