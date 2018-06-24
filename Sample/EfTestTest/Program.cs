using System;
using Business.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace EfTestTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

			//BusinessDbContext dbContext;

            var optionsBuilder = new DbContextOptionsBuilder<BusinessDbContext>();
            optionsBuilder.UseMySql("Server=localhost;database=test;uid=root;pwd=P@ssword;charset=utf8;port=3306;SslMode=None");




            TenantId tenantId = new TenantId();
            tenantId.Id = "abc";

            Guid siteId = Guid.NewGuid();


            var site = new Site();
            site.Id = siteId;
            site.TenantId = tenantId;


            //Branding branding = new Branding();
            //branding.Id = Guid.NewGuid();
            //branding.TenantId = tenantId;
            //branding.SiteId = siteId;
            //branding.Site = site;


            using (var dbContext = new BusinessDbContext(optionsBuilder.Options))
            {
                //dbContext.Entry(site).State = EntityState.Added;
                //dbContext.Entry(site.Branding).State = EntityState.Added;

                /* not worked
                 site.CreateBranding();
                dbContext.Add(site);
                dbContext.Entry(site.Branding).State = EntityState.Added;
                */

                /* worked
                dbContext.Add(site);
                site.CreateBranding();

                */

                //dbContext.Entry(site).State = EntityState.Detached;
                site.CreateBranding();
                dbContext.Add(site);
                dbContext.Entry(site).State = EntityState.Added;
                dbContext.Entry(site.Branding).State = EntityState.Added;
                //dbContext.Entry(site.Branding.TenantId).State = EntityState.Added;
                //dbContext.Entry(site.TenantId).State = EntityState.Added;

                //site.CreateBranding();
                //dbContext

                //dbContext.Entry(site.TenantId).State = EntityState.Added;
                //site.Branding = branding; // error
                //dbContext.Entry(site).State = EntityState.Unchanged;
                //dbContext.Entry(branding).State = EntityState.Added;
                dbContext.SaveChanges();

                //var site2 = dbContext.Set<Site>().Find(siteId);

                //site2.Branding = new Branding();
                //site2.Branding.Id = Guid.NewGuid();
                //site2.Branding.TenantId = site2.TenantId;
                //site2.Branding.SiteId = site2.Id;

                //dbContext.Set<Site>().Update(site2);
                //dbContext.SaveChanges();
            }
        }
    }
}
