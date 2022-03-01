namespace FinalProjectKidsHealthCenter.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DepartmentTable")]
    public partial class DepartmentTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DepartmentTable()
        {
            EmployeeTables = new HashSet<EmployeeTable>();
        }

        [Key]
        public int Depart_ID { get; set; }

        [StringLength(20)]
        public string DepartName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeTable> EmployeeTables { get; set; }
    }
}
