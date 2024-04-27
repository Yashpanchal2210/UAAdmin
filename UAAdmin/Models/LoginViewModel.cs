using System.ComponentModel.DataAnnotations;

namespace UAAdmin.Models
{
    public class LoginViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The Username is required")]
        [Display(Name = "Username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "The Password is required")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public string? ErrorMessage { get; set; }
        public string? ReturnUrl { get; set; }
    }
}
