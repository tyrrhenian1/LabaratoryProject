namespace LogWindow
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("users$")]
    public partial class users
    {
        public int id { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        [StringLength(255)]
        public string login { get; set; }

        [StringLength(255)]
        public string password { get; set; }

        [StringLength(255)]
        public string ip { get; set; }

        [StringLength(255)]
        public string lastenter { get; set; }

        [StringLength(255)]
        public string services { get; set; }

        public int? type { get; set; }
    }
}
