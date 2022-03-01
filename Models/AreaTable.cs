namespace FinalProjectKidsHealthCenter.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AreaTable")]
    public partial class AreaTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AreaTable()
        {
            ChildTables = new HashSet<ChildTable>();
            HealthOffices = new HashSet<HealthOffice>();
            NeighborhoodTables = new HashSet<NeighborhoodTable>();
            RelativeTables = new HashSet<RelativeTable>();
        }

        [Key]
        public int AreaID { get; set; }

        [StringLength(50)]
        public string AreaName { get; set; }

        public int? CovernorateID { get; set; }

        public virtual CovernorateTable CovernorateTable { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChildTable> ChildTables { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HealthOffice> HealthOffices { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NeighborhoodTable> NeighborhoodTables { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RelativeTable> RelativeTables { get; set; }
    }
}
