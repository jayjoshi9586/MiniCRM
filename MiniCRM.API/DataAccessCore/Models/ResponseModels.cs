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
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Admin_id")]
        public int Admin_id { get; set; }

        [Display(Name = "UserName")]
        public string Username { get; set; }

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
}
