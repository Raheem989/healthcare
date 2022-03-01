namespace FinalProjectKidsHealthCenter.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VaccineCampingTranasaction")]
    public partial class VaccineCampingTranasaction
    {
        [Key]
        public int CT_ID { get; set; }

        public int Child_ID { get; set; }

        public int Emp_ID { get; set; }

        public int VC_ID { get; set; }

        public DateTime? Date { get; set; }

        public virtual ChildTable ChildTable { get; set; }

        public virtual EmployeeTable EmployeeTable { get; set; }

        public virtual VaccineCampingTable VaccineCampingTable { get; set; }
    }
}
