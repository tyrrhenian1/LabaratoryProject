using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace LogWindow
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Blood> Blood { get; set; }
        public virtual DbSet<Booker> Booker { get; set; }
        public virtual DbSet<InsureCompany> InsureCompany { get; set; }
        public virtual DbSet<Laborant> Laborant { get; set; }
        public virtual DbSet<LSearcher> LSearcher { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Pacients> Pacients { get; set; }
        public virtual DbSet<Services> Services { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<BloodServices> BloodServices { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Services>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);
        }
    }
}
