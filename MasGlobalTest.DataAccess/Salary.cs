namespace MasGlobalTest.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Salary")]
    public partial class Salary
    {
        public int Id { get; set; }

        public int? IdEmployee { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Value { get; set; }

        public bool? State { get; set; }

        [Column("_created")]
        public DateTime? C_created { get; set; }
    }
}
