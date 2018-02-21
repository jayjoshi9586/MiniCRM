namespace DataAccessCore.Entities
{
    using DataAccessCore.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            Accounts = new HashSet<Account>();
        }

        public Category(CategoryResponseModel category)
        {
            this.Category_id = category.Category_id;
            this.Category_name = category.Category_name;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Category_id { get; set; }

        [Required]
        public string Category_name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
