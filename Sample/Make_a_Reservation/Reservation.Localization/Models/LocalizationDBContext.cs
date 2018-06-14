using System;
using Microsoft.EntityFrameworkCore;

namespace Reservation.Localization.Models
{
    public class LocalizationDBContext : DbContext
    {
        public DbSet<Culture> Cultures { get; set; }
        public DbSet<Resource> Resources { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("Scratch");
        }
    }
}
