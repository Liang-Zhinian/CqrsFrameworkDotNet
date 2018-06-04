namespace MAR.Application.ReadModel
{
    using System;
    // using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ApplicationDbContext// : DbContext
    {
        public ApplicationDbContext()
            // : base("name=mar")
        {
        }

        // public virtual DbSet<Employee> Employees { get; set; }

        // protected override void OnModelCreating(DbModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<Employee>()
        //         .HasMany(e => e.MovieReviews)
        //         .WithRequired(e => e.Movie)
        //         .WillCascadeOnDelete(false);
        // }
    }
}