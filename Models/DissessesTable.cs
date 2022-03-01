namespace FinalProjectKidsHealthCenter.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DissessesTable")]
    public partial class DissessesTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DissessesTable()
        {
            CheckingTables = new HashSet<CheckingTable>();
            VaccineTables = new HashSet<VaccineTable>();
        }

        [Key]
        public int Di_ID { get; set; }

        [StringLength(50)]
        public string Di_Name { get; set; }

        [StringLength(200)]
        public string DI_SideEffect { get; set; }

        public int? Vaccine_ID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CheckingTable> CheckingTables { get; set; }

        public virtual VaccineTable VaccineTable { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VaccineTable> VaccineTables { get; set; }
    }
}
