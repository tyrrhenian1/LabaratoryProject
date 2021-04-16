namespace LogWindow
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InsureCompany")]
    public partial class InsureCompany
    {
        [Required]
        [StringLength(255)]
        public string insurance_name { get; set; }

        [StringLength(255)]
        public string insurance_address { get; set; }

        [Key]
        [StringLength(255)]
        public string insurance_inn { get; set; }

        [StringLength(255)]
        public string insurance_pc { get; set; }

        [StringLength(255)]
        public string insurance_bik { get; set; }
    }
}
