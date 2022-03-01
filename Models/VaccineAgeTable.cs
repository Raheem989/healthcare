namespace FinalProjectKidsHealthCenter.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VaccineAgeTable")]
    public partial class VaccineAgeTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VaccineAgeTable()
        {
            VaccineTables = new HashSet<VaccineTable>();
        }

        [Key]
        public int VaccineAge_ID { get; set; }

        [StringLength(50)]
        public string VaccineAgeName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VaccineTable> VaccineTables { get; set; }
    }
}
