namespace DataAccessCore.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Accounts_branch
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Account_branch_id { get; set; }

        public int Timing_id { get; set; }

        [Column(TypeName = "image")]
        public byte[] Account_images { get; set; }

        public string Account_address { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Account_phone { get; set; }

        public string Account_email { get; set; }

        public int Account_id { get; set; }

        public bool? IsDeleted { get; set; }

        public virtual Account Account { get; set; }

        public virtual Timing_Table Timing_Table { get; set; }
    }
}
