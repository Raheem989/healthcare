namespace FinalProjectKidsHealthCenter.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VaccineTranasactionTable")]
    public partial class VaccineTranasactionTable
    {
        [Key]
        public int VT_ID { get; set; }

        public int? Child_ID { get; set; }

        public int? Emp_ID { get; set; }

        public int? Vacc_ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DueDate { get; set; }

        public virtual ChildTable ChildTable { get; set; }

        public virtual EmployeeTable EmployeeTable { get; set; }

        public virtual VaccineTable VaccineTable { get; set; }
    }
}
