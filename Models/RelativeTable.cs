namespace FinalProjectKidsHealthCenter.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RelativeTable")]
    public partial class RelativeTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RelativeTable()
        {
            ChildTables = new HashSet<ChildTable>();
        }

        [Key]
        public int Re_ID { get; set; }

        [StringLength(20)]
        public string Re_FName { get; set; }

        [StringLength(20)]
        public string Re_MiniName { get; set; }

        [StringLength(20)]
        public string Re_LName { get; set; }

        public int? Re_GenderID { get; set; }

        public int? Re_CovernorateID { get; set; }

        public int? Re_AreaID { get; set; }

        public int? Re_NeighborhoodID { get; set; }

        [StringLength(50)]
        public string Re_Address { get; set; }

        [StringLength(20)]
        public string Re_PhoneNo { get; set; }

        [StringLength(20)]
        public string Re_Email { get; set; }

        public virtual AreaTable AreaTable { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChildTable> ChildTables { get; set; }

        public virtual CovernorateTable CovernorateTable { get; set; }

        public virtual GenderTable GenderTable { get; set; }

        public virtual NeighborhoodTable NeighborhoodTable { get; set; }
    }
}
