namespace FinalProjectKidsHealthCenter.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CheckingTable")]
    public partial class CheckingTable
    {
        [Key]
        public int Checking_ID { get; set; }

        public int Child_ID { get; set; }

        public int Emp_ID { get; set; }

        public int Di_ID { get; set; }

        public int? CheckResult_ID { get; set; }

        public decimal? Weight { get; set; }

        public decimal? Height { get; set; }

        public DateTime? date { get; set; }

        public virtual CheckResTable CheckResTable { get; set; }

        public virtual ChildTable ChildTable { get; set; }

        public virtual DissessesTable DissessesTable { get; set; }

        public virtual EmployeeTable EmployeeTable { get; set; }
    }
}
