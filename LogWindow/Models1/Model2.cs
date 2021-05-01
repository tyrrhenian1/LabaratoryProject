namespace LogWindow
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model2 : DbContext
    {
        public Model2()
            : base("name=Model2")
        {
        }

        public virtual DbSet<blood> blood_{ get; set; }
        public virtual DbSet<blood_services> blood_services { get; set; }
        public virtual DbSet<patients> patients { get; set; }
        public virtual DbSet<users> users { get; set; }
        public virtual DbSet<services> services { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
