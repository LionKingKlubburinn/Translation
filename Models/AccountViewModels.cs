using System.ComponentModel.DataAnnotations;

namespace Translation.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Notendanafn")]
        public string UserName { get; set; }
    }

    public class ManageUserViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Lykilorð")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Lykilorð verður að vera að minnsta kosti 6 stafir.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nýtt lykilorð")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Staðfesta nýtt lykilorð")]
        [Compare("NewPassword", ErrorMessage = "Lykilorð og staðfesta lykilorð stemma ekki.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Notendanafn")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Lykilorð")]
        public string Password { get; set; }

        [Display(Name = "Muna eftir mér")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Display(Name = "Notendanafn")]
        [Required(ErrorMessage = "UserNameRequired")]
        [StringLength(30, ErrorMessage = "UserNameLong")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "PasswordRequired")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Lykilorð")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Staðfesta lykilorð")]
        [Required(ErrorMessage = "ConfirmPasswordRequired")]
        [Compare("Password", ErrorMessage = "PasswordCompare")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Land")]
        public string Nationality { get; set; }

        [Display(Name = "Netfang")]
        [Required(ErrorMessage = "EmailRequired" )]
        [RegularExpression(".+@.+\\..+")]
        public string Email { get; set; }

    }
}
