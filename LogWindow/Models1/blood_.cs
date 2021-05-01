namespace LogWindow
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("blood$")]
    public partial class blood
    {
        public int id { get; set; }

        public double? patient { get; set; }

        public double? barcode { get; set; }

        public double? date { get; set; }
    }
}
