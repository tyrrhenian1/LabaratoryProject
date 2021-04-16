namespace LogWindow
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [Key]
        public int IdOrder { get; set; }

        public DateTime DataOrder { get; set; }

        [Required]
        public string Services { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        [StringLength(50)]
        public string StatusServices { get; set; }

        [Required]
        [StringLength(50)]
        public string Times { get; set; }

        public int? IdBlood { get; set; }
    }
}
