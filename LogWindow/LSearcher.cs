namespace LogWindow
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LSearcher")]
    public partial class LSearcher
    {
        public int id { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; }

        [Required]
        [StringLength(100)]
        public string login { get; set; }

        [Required]
        [StringLength(100)]
        public string password { get; set; }

        [StringLength(255)]
        public string ip { get; set; }

        [Required]
        [StringLength(100)]
        public string lastenter { get; set; }

        [Required]
        [StringLength(100)]
        public string services { get; set; }
    }
}
