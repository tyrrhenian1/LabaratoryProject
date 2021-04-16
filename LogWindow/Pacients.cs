namespace LogWindow
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Pacients
    {
        [Key]
        [StringLength(255)]
        public string fullname { get; set; }

        [StringLength(255)]
        public string login { get; set; }

        [StringLength(255)]
        public string pwd { get; set; }

        [StringLength(255)]
        public string guid { get; set; }

        [StringLength(255)]
        public string email { get; set; }

        [StringLength(255)]
        public string social_sec_number { get; set; }

        [StringLength(255)]
        public string social_type { get; set; }

        [StringLength(30)]
        public string phone { get; set; }

        public double? passport_s { get; set; }

        public double? passport_n { get; set; }

        public double? birthdate_timestamp { get; set; }

        public int idPacient { get; set; }

        [StringLength(255)]
        public string country { get; set; }

        [StringLength(255)]
        public string insurance_name { get; set; }
    }
}
