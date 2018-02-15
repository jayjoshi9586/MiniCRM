namespace DataAccessCore.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Beacon")]
    public partial class Beacon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Beacon()
        {
            Accounts = new HashSet<Account>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Beacon_id { get; set; }

        [Required]
        [StringLength(50)]
        public string Beacon_title { get; set; }

        [Required]
        [StringLength(50)]
        public string Beacon_uuid { get; set; }

        public int Beacon_major { get; set; }

        public int Beacon_minor { get; set; }

        public int Beacon_rssi { get; set; }

        public TimeSpan? Beacon_trigger_interval { get; set; }

        [StringLength(10)]
        public string Beacon_trigger_proximity { get; set; }

        [StringLength(50)]
        public string Beacon_message { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
