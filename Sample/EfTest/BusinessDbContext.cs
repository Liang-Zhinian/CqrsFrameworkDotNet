using System;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Business.Infra.Data.Context
{
    public class Site
    {
        public Guid Id { get; set; }

        //public Guid BrandingId {get;set;}
        private Branding _branding;
        public Branding Branding { get { return _branding; } }

        public TenantId TenantId { get; set; }

        public void CreateBranding(){
            Branding branding = new Branding();
            branding.Id = Guid.NewGuid();
            branding.TenantId = this.TenantId;
            branding.SiteId = this.Id;
            //branding.Site = this;
            this._branding = branding;
        }
    }

    public class Branding
    {
        public Guid Id { get; set; }
        //public string Logo { get; set; }

        public Guid SiteId { get; set; }
        //public virtual Site Site { get; set; }

        public TenantId TenantId { get; set; }
    }

    public class TenantId{
        public string Id { get; set; }
    }
    
    public class BusinessDbContext : DbContext
    {
        public DbSet<Site> Sites { get; set; }
        public DbSet<Branding> Brandings { get; set; }

        protected BusinessDbContext()
        {

        }

        public BusinessDbContext(DbContextOptions<BusinessDbContext> options) : base(options)
        {
            //Database.SetInitializer<BusinessDbContext>(null);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Site>()
                        .HasOne(typeof(Branding), "Branding")
                        .WithOne().HasForeignKey(typeof(Branding), "SiteId");
            
            //modelBuilder.Entity<Site>().Property("Id").HasColumnType("char(36)");
            modelBuilder.Entity<Site>().OwnsOne(_ => _.TenantId, t => {
                t.Property("Id").HasColumnType("varchar(36)");
            });


            //modelBuilder.Entity<Branding>().Property("Id").HasColumnType("char(36)");
            modelBuilder.Entity<Branding>().OwnsOne(_ => _.TenantId, t=>{
                t.Property("Id").HasColumnType("varchar(36)");
            });
        }
    }
}
