namespace LogWindow
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("services$")]
    public partial class services
    {
        [Key]
        public int Code { get; set; }

        [StringLength(255)]
        public string Service { get; set; }

        [StringLength(255)]
        public string Price { get; set; }
    }
}
