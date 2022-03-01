namespace FinalProjectKidsHealthCenter.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NeighborhoodTable")]
    public partial class NeighborhoodTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NeighborhoodTable()
        {
            ChildTables = new HashSet<ChildTable>();
            HealthOffices = new HashSet<HealthOffice>();
            RelativeTables = new HashSet<RelativeTable>();
        }

        [Key]
        public int NeighborhoodID { get; set; }

        [StringLength(50)]
        public string NeighborhoodName { get; set; }

        public int? AreaID { get; set; }

        public virtual AreaTable AreaTable { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChildTable> ChildTables { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HealthOffice> HealthOffices { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RelativeTable> RelativeTables { get; set; }
    }
}
