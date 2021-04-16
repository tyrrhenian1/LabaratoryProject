namespace LogWindow
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Services
    {
        [Key]
        public int Code { get; set; }

        [Required]
        [StringLength(255)]
        public string ServiceName { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }
    }
}
