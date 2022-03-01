namespace FinalProjectKidsHealthCenter.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VaccineNameTable")]
    public partial class VaccineNameTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VaccineNameTable()
        {
            VaccineTables = new HashSet<VaccineTable>();
        }

        [Key]
        public int VaccineName_ID { get; set; }

        [StringLength(100)]
        public string VacineName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VaccineTable> VaccineTables { get; set; }
    }
}
