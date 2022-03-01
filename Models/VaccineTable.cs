namespace FinalProjectKidsHealthCenter.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VaccineTable")]
    public partial class VaccineTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VaccineTable()
        {
            DissessesTables = new HashSet<DissessesTable>();
            VaccineTranasactionTables = new HashSet<VaccineTranasactionTable>();
        }

        [Key]
        public int Vacc_ID { get; set; }

        public int? VaccineAge_ID { get; set; }

        public int? VaccineName_ID { get; set; }

        public int? DI_ID { get; set; }

        [StringLength(100)]
        public string DoseRoute { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DissessesTable> DissessesTables { get; set; }

        public virtual DissessesTable DissessesTable { get; set; }

        public virtual VaccineAgeTable VaccineAgeTable { get; set; }

        public virtual VaccineNameTable VaccineNameTable { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VaccineTranasactionTable> VaccineTranasactionTables { get; set; }
    }
}
