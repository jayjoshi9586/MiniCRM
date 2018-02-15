namespace DataAccessCore.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Right
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Right()
        {
            Modules = new HashSet<Module>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Right_id { get; set; }

        [Required]
        public string Right_name { get; set; }

        [StringLength(1)]
        public string Right_delete { get; set; }

        [StringLength(1)]
        public string Right_update { get; set; }

        [StringLength(1)]
        public string Right_view { get; set; }

        [StringLength(1)]
        public string Right_add { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Module> Modules { get; set; }

        public virtual Right Rights1 { get; set; }

        public virtual Right Right1 { get; set; }
    }
}
