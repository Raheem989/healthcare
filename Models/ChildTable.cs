namespace FinalProjectKidsHealthCenter.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChildTable")]
    public partial class ChildTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ChildTable()
        {
            CheckingTables = new HashSet<CheckingTable>();
            VaccineCampingTranasactions = new HashSet<VaccineCampingTranasaction>();
            VaccineTranasactionTables = new HashSet<VaccineTranasactionTable>();
        }

        [Key]
        public int Child_ID { get; set; }

        [StringLength(20)]
        public string Child_FName { get; set; }

        [StringLength(20)]
        public string Child_MiniName { get; set; }

        [StringLength(20)]
        public string Child_LName { get; set; }

        public int? Re_ID { get; set; }

        public int? Child_GenderID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Child_BirthDate { get; set; }

        public int? Child_CovernorateID { get; set; }

        public int? Child_AreaID { get; set; }

        public int? Child_NeighborhoodID { get; set; }

        [StringLength(100)]
        public string Child_Address { get; set; }

        public virtual AreaTable AreaTable { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CheckingTable> CheckingTables { get; set; }

        public virtual CovernorateTable CovernorateTable { get; set; }

        public virtual GenderTable GenderTable { get; set; }

        public virtual NeighborhoodTable NeighborhoodTable { get; set; }

        public virtual RelativeTable RelativeTable { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VaccineCampingTranasaction> VaccineCampingTranasactions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VaccineTranasactionTable> VaccineTranasactionTables { get; set; }
    }
}
