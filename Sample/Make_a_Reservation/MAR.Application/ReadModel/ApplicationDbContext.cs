namespace MAR.Application.ReadModel
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

         public virtual DbSet<Employee> Employees { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //     modelBuilder.Entity<Employee>()
            //         .HasMany(e => e.MovieReviews)
            //         .WithRequired(e => e.Movie)
            //         .WillCascadeOnDelete(false);
        }
    }
}