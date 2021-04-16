namespace LogWindow
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BloodServices
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int blood { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int service { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string result { get; set; }

        [StringLength(50)]
        public string finished { get; set; }

        [StringLength(255)]
        public string accepted { get; set; }

        [StringLength(255)]
        public string status { get; set; }

        [StringLength(255)]
        public string analyzer { get; set; }

        public int? user { get; set; }
    }
}
