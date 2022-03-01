namespace FinalProjectKidsHealthCenter.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MinistryRepresentator")]
    public partial class MinistryRepresentator
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MinistryRepresentator()
        {
            HealthOffices = new HashSet<HealthOffice>();
            VaccineCampingTables = new HashSet<VaccineCampingTable>();
        }

        [Key]
        public int MR_ID { get; set; }

        [StringLength(20)]
        public string MR_FName { get; set; }

        [StringLength(20)]
        public string MR_MiniName { get; set; }

        [StringLength(20)]
        public string MR_LName { get; set; }

        public int? GenderID { get; set; }

        [StringLength(20)]
        public string MR_Email { get; set; }

        [StringLength(200)]
        public string MR_PhoneNo { get; set; }

        public virtual GenderTable GenderTable { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HealthOffice> HealthOffices { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VaccineCampingTable> VaccineCampingTables { get; set; }
    }
}
