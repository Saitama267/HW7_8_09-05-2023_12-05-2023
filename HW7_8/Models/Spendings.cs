namespace HW7_8
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Spendings
    {
        public int Id { get; set; }

        public int? CategoryId { get; set; }

        public double? Price { get; set; }

        [StringLength(100)]
        public string Comment { get; set; }

        public DateTime? Date { get; set; }

        public virtual Categories Categories { get; set; }
    }
}
