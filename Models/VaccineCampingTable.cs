namespace FinalProjectKidsHealthCenter.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VaccineCampingTable")]
    public partial class VaccineCampingTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VaccineCampingTable()
        {
            VaccineCampingTranasactions = new HashSet<VaccineCampingTranasaction>();
        }

        [Key]
        public int VC_ID { get; set; }

        public int? VC_MRID { get; set; }

        [StringLength(50)]
        public string VC_Name { get; set; }

        [StringLength(200)]
        public string VC_Description { get; set; }

        [Column(TypeName = "date")]
        public DateTime? VC_Date { get; set; }

        public TimeSpan? VC_Time { get; set; }

        public virtual MinistryRepresentator MinistryRepresentator { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VaccineCampingTranasaction> VaccineCampingTranasactions { get; set; }
    }
}
