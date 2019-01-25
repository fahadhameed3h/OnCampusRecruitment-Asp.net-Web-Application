using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnCampusRecruitment.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public enum Department
    {
        [Display(Name = "CS")]
        CS,
        [Display(Name = "BN")]
        Botny,
        [Display(Name = "AB")]
        AB,
        [Display(Name = "EN")]
        English,
        [Display(Name = "Ue")]
        Urdu
    }
    public enum Degree
    {
        BS,
        BA,        
        [Display(Name = "BCom")] BCom,
        [Display(Name = "BSc")]  Bsc,
        MA,
        MS,
        MBA,
        [Display(Name = "M.Phil")] MPhil,
        [Display(Name = "Ph.D")]   PhD
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        public int UserType { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]       
        [Range(0001,9999, ErrorMessage = "Must be of format 0012")]
        ///[StringLength(4, MinimumLength = 4, ErrorMessage = "Must be of format 0012")]
        [Display(Name = "Roll No. ")]
        public int RollNo { get; set; }

        [Required]
        public Degree degree { get; set; }
        [Required]
        public Department department { get; set; }
        [Required]
        public int Year { get; set; }

        [Required(ErrorMessage = "Must be of format 6 Words Long")]
        [Display(Name = "Company Name ")]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
