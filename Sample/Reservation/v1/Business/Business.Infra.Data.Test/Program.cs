using System;
using Business.Domain.Entities;
using Business.Domain.Repositories;
using Business.Infra.Data.Context;
using Business.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Business.Infra.Data.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            ISiteRepository repository;
            BusinessDbContext dbContext;

            var optionsBuilder = new DbContextOptionsBuilder<BusinessDbContext>();
            optionsBuilder.UseMySql("Server=localhost;database=book2site;uid=root;pwd=P@ssword;charset=utf8;port=3306;SslMode=None");

            dbContext = new BusinessDbContext(optionsBuilder.Options);
            repository = new SiteRepository(dbContext);

            var entityRepository = new DomainRepository<Site>(dbContext);
            var site = new Site(new TenantId("abc"), "def", "def", true);
            entityRepository.Add(site);
            entityRepository.SaveChanges();

            var result = entityRepository.Find(site.Id);
        }
    }
}
