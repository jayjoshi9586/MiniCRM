namespace DataAccessCore.Entities
{
    using DataAccessCore.Models;
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

        public Beacon(BeaconGetModel beacon)
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

        public bool IsDeleted { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Account> Accounts { get; set; }
    }

     
    }

