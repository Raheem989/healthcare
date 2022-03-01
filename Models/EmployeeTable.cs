namespace FinalProjectKidsHealthCenter.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmployeeTable")]
    public partial class EmployeeTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EmployeeTable()
        {
            CheckingTables = new HashSet<CheckingTable>();
            VaccineCampingTranasactions = new HashSet<VaccineCampingTranasaction>();
            VaccineTranasactionTables = new HashSet<VaccineTranasactionTable>();
        }

        [Key]
        public int Emp_ID { get; set; }

        [StringLength(20)]
        public string EMP_FName { get; set; }

        [StringLength(20)]
        public string EMP_MiniName { get; set; }

        [StringLength(10)]
        public string EMP_LName { get; set; }

        public int? Emp_GenderID { get; set; }

        [StringLength(50)]
        public string Emp_Address { get; set; }

        public decimal? Emp_Salary { get; set; }

        [StringLength(20)]
        public string EMP_PhoneNo { get; set; }

        [StringLength(20)]
        public string Emp_Email { get; set; }

        public int? Emp_DepartID { get; set; }

        [StringLength(50)]
        public string Emp_Specilization { get; set; }

        public int? Emp_Years_Of_Experience { get; set; }

        public int? Emp_HO_ID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CheckingTable> CheckingTables { get; set; }

        public virtual DepartmentTable DepartmentTable { get; set; }

        public virtual GenderTable GenderTable { get; set; }

        public virtual HealthOffice HealthOffice { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VaccineCampingTranasaction> VaccineCampingTranasactions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VaccineTranasactionTable> VaccineTranasactionTables { get; set; }
    }
}
