namespace DataAccessCore.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Admin")]
    public partial class Admin
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Admin()
        {
            Accounts = new HashSet<Account>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Admin_id { get; set; }

        [StringLength(50)]
        public string Admin_firstname { get; set; }

        [StringLength(50)]
        public string Admin_lastname { get; set; }

        [StringLength(50)]
        public string Admin_gender { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Admin_contact_no { get; set; }

        [Required]
        public string Admin_email { get; set; }

        public int Admin_type_id { get; set; }

        [Required]
        [StringLength(88)]
        public string Admin_pwd { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Admin_dob { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Admin_aadhar_id { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Admin_pan_card { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Admin_gst_id { get; set; }

        [StringLength(10)]
        public string Admin_status { get; set; }

        [Required]
        public string Admin_username { get; set; }

        public bool? IsDeleted { get; set; }

        public virtual AdminType AdminType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
