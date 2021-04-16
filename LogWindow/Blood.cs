namespace LogWindow
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Blood")]
    public partial class Blood
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public int patient { get; set; }

        [Required]
        [StringLength(255)]
        public string barcode { get; set; }

        [StringLength(255)]
        public string date { get; set; }
    }
}
