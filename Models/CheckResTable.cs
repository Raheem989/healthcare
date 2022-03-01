namespace FinalProjectKidsHealthCenter.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CheckResTable")]
    public partial class CheckResTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CheckResTable()
        {
            CheckingTables = new HashSet<CheckingTable>();
        }

        [Key]
        public int CheckingRes_ID { get; set; }

        [StringLength(50)]
        public string CheckResName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CheckingTable> CheckingTables { get; set; }
    }
}
