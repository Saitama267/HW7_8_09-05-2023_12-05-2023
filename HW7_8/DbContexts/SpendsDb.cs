using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace HW7_8
{
    public partial class SpendsDb : DbContext
    {
        public SpendsDb()
            : base("name=SpendsDb")
        {
        }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Spendings> Spendings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>()
                .HasMany(e => e.Spendings)
                .WithOptional(e => e.Categories)
                .HasForeignKey(e => e.CategoryId);
        }
    }
}
