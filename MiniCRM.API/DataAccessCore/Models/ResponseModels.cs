using DataAccessCore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessCore.Models
{
    public class ResponseDTO 
    {
        public int Code { get; set; }
        public String Message { get; set; }
    }

    public class AdminGetModel
    {
        public AdminGetModel() { }
        public AdminGetModel(Admin a)
        {
            this.Admin_aadhar_id = a.Admin_aadhar_id;
            this.Admin_contact_no = a.Admin_contact_no;
            this.Admin_dob = a.Admin_dob;
            this.Admin_email = a.Admin_email;
            this.Admin_firstname = a.Admin_firstname;
            this.Admin_gender = a.Admin_gender;
            this.Admin_gst_id = a.Admin_gst_id;
            this.Admin_id = a.Admin_id;
            this.Admin_lastname = a.Admin_lastname;
            this.Admin_pan_card = a.Admin_pan_card;
            this.Admin_status = a.Admin_status;
            this.Admin_status = a.Admin_status;
            this.Admin_type_id = a.Admin_type_id;
            this.Admin_username = a.Admin_username;
            this.IsDeleted = a.IsDeleted;
        }

        [Display(Name = "Admin_id")]
        public int Admin_id { get; set; }

        [Display(Name = "Admin_type_ID")]
        public int Admin_type_id { get; set; }

        [Display(Name = "Admin_firstname")]
        public string Admin_firstname { get; set; }

        [Display(Name = "Admin_lastname")]
        public string Admin_lastname { get; set; }

        [Display(Name = "Admin_gender")]
        public string Admin_gender { get; set; }

        [Display(Name = "Admin_contact_no")]
        public decimal? Admin_contact_no { get; set; }

        [Display(Name = "Admin_email")]
        public string Admin_email { get; set; }

        [Display(Name = "Admin_dob")]
        public DateTime? Admin_dob { get; set; }

        [Display(Name = "Admin_aadhar_id")]
        public decimal? Admin_aadhar_id { get; set; }

        [Display(Name = "Admin_pan_card")]
        public decimal? Admin_pan_card { get; set; }

        [Display(Name = "Admin_gst_id")]
        public decimal? Admin_gst_id { get; set; }

        [Display(Name = "Admin_status")]
        public string Admin_status { get; set; }

        [Display(Name = "Admin_username")]
        public string Admin_username { get; set; }

        [Display(Name = "IsDeleted")]
        public bool? IsDeleted { get; set; }

    }

    public class AccountGetModel
    {
        public AccountGetModel() { }

        public AccountGetModel(Account account)
        {
            this.Account_brand_logo = account.Account_brand_logo;
            this.Account_global_email = account.Account_global_email;
            this.Account_id = account.Account_id;
            this.Account_name = account.Account_name;
            this.IsDeleted = account.IsDeleted;
        }

        [Display(Name = "Account_id")]
        public int Account_id { get; set; }

        [Display(Name = "Account_name")]
        public string Account_name { get; set; }

        [Column(TypeName = "image")]
        [Display(Name = "Account_brand_logo")]
        public byte[] Account_brand_logo { get; set; }

        [Display(Name = "Account_global_email")]
        public string Account_global_email { get; set; }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted { get; set; }
    }

    public class BeaconGetModel
    {
        public BeaconGetModel() { }

        public BeaconGetModel(Beacon beacon)
        {
            this.Beacon_id = beacon.Beacon_id;
            this.Beacon_major = beacon.Beacon_major;
            this.Beacon_message = beacon.Beacon_message;
            this.Beacon_minor = beacon.Beacon_minor;
            this.Beacon_rssi = beacon.Beacon_rssi;
            this.Beacon_title = beacon.Beacon_title;
            this.Beacon_trigger_interval = beacon.Beacon_trigger_interval;
            this.Beacon_trigger_proximity = beacon.Beacon_trigger_proximity;
            this.Beacon_uuid = beacon.Beacon_uuid;
            this.IsDeleted = beacon.IsDeleted;
        }

        [Display(Name = "Beacon_id")]
        public int Beacon_id { get; set; }

        [Display(Name = "Beacon_title")]
        public string Beacon_title { get; set; }

        [Display(Name = "Beacon_uuid")]
        public string Beacon_uuid { get; set; }

        [Display(Name = "Beacon_major")]
        public int Beacon_major { get; set; }

        [Display(Name = "Beacon_minor")]
        public int Beacon_minor { get; set; }

        [Display(Name = "Beacon_rssi")]
        public int Beacon_rssi { get; set; }

        [Display(Name = "Beacon_trigger_interval")]
        public TimeSpan? Beacon_trigger_interval { get; set; }

        [Display(Name = "Beacon_trigger_proximity")]
        public string Beacon_trigger_proximity { get; set; }

        [Display(Name = "Beacon_message")]
        public string Beacon_message { get; set; }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted { get; set; }
    }

    public class LoginResponseModel
    {
        public string accesstoken { get; set; }

        public int Admin_id { get; set; }

        public bool success { get; set; }
    }

    public class CategoryResponseModel
    {
        public CategoryResponseModel() { }

        public CategoryResponseModel(Category category)
        {
            this.Category_id = category.Category_id;
            this.Category_name = category.Category_name;
        }
        [Display(Name = "categoryID")]
        public int Category_id { get; set; }

        [Display(Name = "CategoryName")]
        public string Category_name { get; set; }
    }
}
