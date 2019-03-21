namespace MasGlobalTest.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        public int Id { get; set; }

        public int? IdTypeContract { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Cellphone { get; set; }

        [Column("_created")]
        [StringLength(10)]
        public string C_created { get; set; }
    }
}
