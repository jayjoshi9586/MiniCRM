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
    public class LoginTestBindingModel
    {
        [Required]
        [Display(Name = "UserName")]
        public string Username { get; set; }


        [Required]
       // [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

    }

    public class UsernameSpecificBindingModel
    {
        [Required]
        [Display(Name = "UserName")]
        public string Username { get; set; }
    }

    public class CreateUserRoleBindingModel
    {
        [Required]
        [Display(Name ="Admin_type_id")]
        public int Admin_type_id { get; set; }

        [Required]
        [Display(Name = "Admin_type_name")]
        public string Admin_type_name { get; set; }
    }

    public class CreateAccountBindingModel
    {
        [Required]
        [Display(Name = "AccountID")]
        public int Account_id { get; set; }

        [Required]
        [Display(Name = "Accountname")]
        public string Account_name { get; set; }

        [Display(Name = "AccountBrandLogo")]
        [Column(TypeName = "image")]
        public byte[] Account_brand_logo { get; set; }

        [Required]
        [Display(Name = "AccountGlobalEmail")]
        public string Account_global_email { get; set; }
    }

    public class EditAccountBindingModel
    {
        [Required]
        [Display(Name = "AccountID")]
        public int Account_id { get; set; }

        [Display(Name = "Accountname")]
        public string Account_name { get; set; }

        [Display(Name = "AccountBrandLogo")]
        [Column(TypeName = "image")]
        public byte[] Account_brand_logo { get; set; }

        [Display(Name = "AccountGlobalEmail")]
        public string Account_global_email { get; set; }
    }

    public class EditBeaconBindingModel
    {
        [Required]
        [Display(Name = "BeaconID")]
        public int Beacon_id { get; set; }

        [Required]
        [Display(Name = "BeaconTitle")]
        public string Beacon_title { get; set; }
    }

    public class AddBeaconBindingModel
    {
        [Required]
        [Display(Name = "BeaconID")]
        public int Beacon_id { get; set; }

        [Required]
        [Display(Name = "BeaconTitle")]
        [StringLength(50)]
        public string Beacon_title { get; set; }

        [Required]
        [Display(Name = "UUID")]
        [StringLength(50)]
        public string Beacon_uuid { get; set; }

        [Required]
        [Display(Name = "Major")]
        public int Beacon_major { get; set; }

        [Required]
        [Display(Name = "Minor")]
        public int Beacon_minor { get; set; }

        [Required]
        [Display(Name = "RSSI")]
        public int Beacon_rssi { get; set; }

        [Display(Name = "TriggerInterval")]
        public TimeSpan? Beacon_trigger_interval { get; set; }

        [Display(Name = "BeaconProximity")]
        [StringLength(10)]
        public string Beacon_trigger_proximity { get; set; }

        [Display(Name = "BeaconMessage")]
        [StringLength(50)]
        public string Beacon_message { get; set; }
    }

    public class CreateAccountBranchBindingModel
    {
        [Required]
        [Display(Name = "BranchID")]
        public int Account_branch_id { get; set; }

        [Required]
        [Display(Name = "TimingID")]
        public int Timing_id { get; set; }

        [Column(TypeName = "image")]
        [Display(Name = "AccountImage")]
        public byte[] Account_images { get; set; }

        [Required]
        [Display(Name = "AccountAddress")]
        public string Account_address { get; set; }

        [Required]
        [Display(Name = "Phonenumber")]
        [Column(TypeName = "numeric")]
        public decimal? Account_phone { get; set; }

        [Required]
        [Display(Name = "AccountEmail")]
        public string Account_email { get; set; }
    }

    public class EditBranchBindingModel
    {
        [Required]
        [Display(Name = "BranchID")]
        public int Account_branch_id { get; set; }

        [Required]
        [Display(Name = "TimingID")]
        public int Timing_id { get; set; }

        [Column(TypeName = "image")]
        [Display(Name = "AccountImage")]
        public byte[] Account_images { get; set; }

        [Required]
        [Display(Name = "AccountAddress")]
        public string Account_address { get; set; }

        [Required]
        [Display(Name = "Phonenumber")]
        [Column(TypeName = "numeric")]
        public decimal? Account_phone { get; set; }

        [Required]
        [Display(Name = "AccountEmail")]
        public string Account_email { get; set; }
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
        [Display(Name ="Admin_id")]
        public int Admin_id { get; set; }

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

        //public int Admin_id { get; set; }

        //[StringLength(50)]
        //public string Admin_firstname { get; set; }

        //[StringLength(50)]
        //public string Admin_lastname { get; set; }

        //[StringLength(50)]
        //public string Admin_gender { get; set; }

        //[Column(TypeName = "numeric")]
        //public decimal? Admin_contact_no { get; set; }

        //[Required]
        //public string Admin_email { get; set; }

        //public int Admin_type_id { get; set; }

        //[Required]
        //[StringLength(88)]
        //public string Admin_pwd { get; set; }

        //[Column(TypeName = "date")]
        //public DateTime? Admin_dob { get; set; }

        //[Column(TypeName = "numeric")]
        //public decimal? Admin_aadhar_id { get; set; }

        //[Column(TypeName = "numeric")]
        //public decimal? Admin_pan_card { get; set; }

        //[Column(TypeName = "numeric")]
        //public decimal? Admin_gst_id { get; set; }

        //[Required]
        //[StringLength(10)]
        //public string Admin_status { get; set; }

        //[Required]
        //public string Admin_username { get; set; }
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
