using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace FinalProjectKidsHealthCenter.Models
{
    public partial class KidsCenterDataContext : DbContext
    {
        public KidsCenterDataContext()
            : base("name=KidsCenterDataContext")
        {
        }

        public virtual DbSet<AreaTable> AreaTables { get; set; }
        public virtual DbSet<CheckingTable> CheckingTables { get; set; }
        public virtual DbSet<CheckResTable> CheckResTables { get; set; }
        public virtual DbSet<ChildTable> ChildTables { get; set; }
        public virtual DbSet<CovernorateTable> CovernorateTables { get; set; }
        public virtual DbSet<DepartmentTable> DepartmentTables { get; set; }
        public virtual DbSet<DissessesTable> DissessesTables { get; set; }
        public virtual DbSet<EmployeeTable> EmployeeTables { get; set; }
        public virtual DbSet<GenderTable> GenderTables { get; set; }
        public virtual DbSet<HealthOffice> HealthOffices { get; set; }
        public virtual DbSet<MinistryRepresentator> MinistryRepresentators { get; set; }
        public virtual DbSet<NeighborhoodTable> NeighborhoodTables { get; set; }
        public virtual DbSet<RelativeTable> RelativeTables { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<VaccineAgeTable> VaccineAgeTables { get; set; }
        public virtual DbSet<VaccineCampingTable> VaccineCampingTables { get; set; }
        public virtual DbSet<VaccineCampingTranasaction> VaccineCampingTranasactions { get; set; }
        public virtual DbSet<VaccineNameTable> VaccineNameTables { get; set; }
        public virtual DbSet<VaccineTable> VaccineTables { get; set; }
        public virtual DbSet<VaccineTranasactionTable> VaccineTranasactionTables { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AreaTable>()
                .HasMany(e => e.ChildTables)
                .WithOptional(e => e.AreaTable)
                .HasForeignKey(e => e.Child_AreaID);

            modelBuilder.Entity<AreaTable>()
                .HasMany(e => e.HealthOffices)
                .WithOptional(e => e.AreaTable)
                .HasForeignKey(e => e.HO_AreaID);

            modelBuilder.Entity<AreaTable>()
                .HasMany(e => e.RelativeTables)
                .WithOptional(e => e.AreaTable)
                .HasForeignKey(e => e.Re_AreaID);

            modelBuilder.Entity<CheckingTable>()
                .Property(e => e.Weight)
                .HasPrecision(18, 5);

            modelBuilder.Entity<CheckingTable>()
                .Property(e => e.Height)
                .HasPrecision(18, 5);

            modelBuilder.Entity<CheckResTable>()
                .HasMany(e => e.CheckingTables)
                .WithOptional(e => e.CheckResTable)
                .HasForeignKey(e => e.CheckResult_ID);

            modelBuilder.Entity<ChildTable>()
                .HasMany(e => e.CheckingTables)
                .WithRequired(e => e.ChildTable)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ChildTable>()
                .HasMany(e => e.VaccineCampingTranasactions)
                .WithRequired(e => e.ChildTable)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CovernorateTable>()
                .HasMany(e => e.ChildTables)
                .WithOptional(e => e.CovernorateTable)
                .HasForeignKey(e => e.Child_CovernorateID);

            modelBuilder.Entity<CovernorateTable>()
                .HasMany(e => e.HealthOffices)
                .WithOptional(e => e.CovernorateTable)
                .HasForeignKey(e => e.HO_CovernorateID);

            modelBuilder.Entity<CovernorateTable>()
                .HasMany(e => e.RelativeTables)
                .WithOptional(e => e.CovernorateTable)
                .HasForeignKey(e => e.Re_CovernorateID);

            modelBuilder.Entity<DepartmentTable>()
                .HasMany(e => e.EmployeeTables)
                .WithOptional(e => e.DepartmentTable)
                .HasForeignKey(e => e.Emp_DepartID);

            modelBuilder.Entity<DissessesTable>()
                .HasMany(e => e.CheckingTables)
                .WithRequired(e => e.DissessesTable)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DissessesTable>()
                .HasMany(e => e.VaccineTables)
                .WithOptional(e => e.DissessesTable)
                .HasForeignKey(e => e.DI_ID);

            modelBuilder.Entity<EmployeeTable>()
                .Property(e => e.Emp_Salary)
                .HasPrecision(18, 0);

            modelBuilder.Entity<EmployeeTable>()
                .HasMany(e => e.CheckingTables)
                .WithRequired(e => e.EmployeeTable)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EmployeeTable>()
                .HasMany(e => e.VaccineCampingTranasactions)
                .WithRequired(e => e.EmployeeTable)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GenderTable>()
                .HasMany(e => e.ChildTables)
                .WithOptional(e => e.GenderTable)
                .HasForeignKey(e => e.Child_GenderID);

            modelBuilder.Entity<GenderTable>()
                .HasMany(e => e.EmployeeTables)
                .WithOptional(e => e.GenderTable)
                .HasForeignKey(e => e.Emp_GenderID);

            modelBuilder.Entity<GenderTable>()
                .HasMany(e => e.RelativeTables)
                .WithOptional(e => e.GenderTable)
                .HasForeignKey(e => e.Re_GenderID);

            modelBuilder.Entity<HealthOffice>()
                .HasMany(e => e.EmployeeTables)
                .WithOptional(e => e.HealthOffice)
                .HasForeignKey(e => e.Emp_HO_ID);

            modelBuilder.Entity<MinistryRepresentator>()
                .HasMany(e => e.VaccineCampingTables)
                .WithOptional(e => e.MinistryRepresentator)
                .HasForeignKey(e => e.VC_MRID);

            modelBuilder.Entity<NeighborhoodTable>()
                .HasMany(e => e.ChildTables)
                .WithOptional(e => e.NeighborhoodTable)
                .HasForeignKey(e => e.Child_NeighborhoodID);

            modelBuilder.Entity<NeighborhoodTable>()
                .HasMany(e => e.HealthOffices)
                .WithOptional(e => e.NeighborhoodTable)
                .HasForeignKey(e => e.HO_NeighborhoodID);

            modelBuilder.Entity<NeighborhoodTable>()
                .HasMany(e => e.RelativeTables)
                .WithOptional(e => e.NeighborhoodTable)
                .HasForeignKey(e => e.Re_NeighborhoodID);

            modelBuilder.Entity<VaccineCampingTable>()
                .HasMany(e => e.VaccineCampingTranasactions)
                .WithRequired(e => e.VaccineCampingTable)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VaccineTable>()
                .HasMany(e => e.DissessesTables)
                .WithOptional(e => e.VaccineTable)
                .HasForeignKey(e => e.Vaccine_ID);
        }
    }
}
