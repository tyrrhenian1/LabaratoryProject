namespace LogWindow
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("blood_services$")]
    public partial class blood_services
    {
        [Key]
        public int blood { get; set; }

        public double? service { get; set; }

        [StringLength(255)]
        public string result { get; set; }

        public double? finished { get; set; }

        public bool accepted { get; set; }

        [StringLength(255)]
        public string status { get; set; }

        [StringLength(255)]
        public string analyzer { get; set; }

        public double? user { get; set; }
    }
}
