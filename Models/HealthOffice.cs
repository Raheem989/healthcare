namespace FinalProjectKidsHealthCenter.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HealthOffice")]
    public partial class HealthOffice
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HealthOffice()
        {
            EmployeeTables = new HashSet<EmployeeTable>();
        }

        [Key]
        public int HO_ID { get; set; }

        public int? HO_CovernorateID { get; set; }

        public int? HO_AreaID { get; set; }

        public int? HO_NeighborhoodID { get; set; }

        [StringLength(50)]
        public string HO_OfficeName { get; set; }

        [StringLength(100)]
        public string HO_Address { get; set; }

        [StringLength(20)]
        public string HO_Email { get; set; }

        [StringLength(20)]
        public string HO_PhoneNo { get; set; }

        public int? MR_ID { get; set; }

        public virtual AreaTable AreaTable { get; set; }

        public virtual CovernorateTable CovernorateTable { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeTable> EmployeeTables { get; set; }

        public virtual MinistryRepresentator MinistryRepresentator { get; set; }

        public virtual NeighborhoodTable NeighborhoodTable { get; set; }
    }
}
