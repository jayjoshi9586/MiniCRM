using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Microsoft.Owin.Security.OAuth;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessCore.Entities
{
    // Models used as parameters to AccountController actions.

    public class AddExternalLoginBindingModel
    {
        [Required]
        [Display(Name = "External access token")]
        public string ExternalAccessToken { get; set; }
    }

    public class ChangePasswordBindingModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
    public class ForgotPasswordBindingModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
    public class RegisterBindingModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "UserName")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Admin_type_ID")]
        public int Admin_type_id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class CreateAccountBiningModel
    {
        [Required]
        public int Account_id { get; set; }

        [Required]
        public string Account_name { get; set; }


        [Column(TypeName = "image")]
        public byte[] Account_brand_logo { get; set; }

        [Required]
        public string Account_global_email { get; set; }
    }

    public class EditProfileBindingModel
    {
        [Required]
        [Display(Name = "Username")]
        public string username { get; set; }

        //[Display(Name = "Email")]
        //public string Email { get; set; }

        [Display(Name = "Firstname")]
        public string Admin_firstname { get; set; }

        [Display(Name = "Lastname")]
        public string Admin_lastname { get; set; }

        [Display(Name = "DateOfBirth")]
        public DateTime? Admin_dob { get; set; }

        [Display(Name = "Aadhaar ID")]
        public decimal? Admin_aadhar_id { get; set; }

        [Display(Name = "PAN Card Number")]
        public decimal? Admin_pan_card { get; set; }

        [Display(Name = "GST ID")]
        public decimal? Admin_gst_id { get; set; }

        [Display(Name = "Gender")]
        public string Admin_gender { get; set; }
    }

    public class CreateAdminBindingModel
    {

    }

    public class LoginBindingModel
    {
        [Required]
        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }

    public class RegisterExternalBindingModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class RemoveLoginBindingModel
    {
        [Required]
        [Display(Name = "Login provider")]
        public string LoginProvider { get; set; }

        [Required]
        [Display(Name = "Provider key")]
        public string ProviderKey { get; set; }
    }

    public class SetPasswordBindingModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
