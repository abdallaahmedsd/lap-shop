using System.ComponentModel.DataAnnotations;

namespace LapShop.Models
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } = null!;
        [Required]
        public string FirstName {  get; set; }=null!;
        [Required]
        public string LastName{ get; set; } = null!;

    }

}
