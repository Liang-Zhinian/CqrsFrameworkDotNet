using System;
using Xunit;
using Business.Infra.Data.Repositories;
using Business.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Moq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Business.Domain.Repositories;
using Business.Domain.Entities;

namespace Business.Domain.UnitTests
{
	public class SiteTests
    {
        
        private ISiteRepository repository;
        private BusinessDbContext dbContext;

        public SiteTests()
        {
            var optionsBuilder = new DbContextOptionsBuilder<BusinessDbContext>();
            optionsBuilder.UseMySql("Server=localhost;database=book2site;uid=root;pwd=P@ssword;charset=utf8;port=3306;SslMode=None");

            dbContext = new BusinessDbContext(optionsBuilder.Options);
            repository = new SiteRepository(dbContext);
        }

        [Fact]
        public void Site_should_create_new_record(){
                var sites = new List<Site>() {
                new Site(new TenantId("abc"), "abc", "abc", true),
                new Site(new TenantId("abc"), "def", "def", true),
            }.AsQueryable();


            var expected = new Collection<Site>
            {

                new Site(new TenantId("abc"), "abc", "abc", true),
                new Site(new TenantId("abc"), "def", "def", true),
            };

            var actual = new Collection<Site>();

            var mockSet = new Mock<DbSet<Site>>();


            mockSet.Setup(r => r.Add(It.IsAny<Site>())) 
            // 在Callback函数里把SavePatient的入参添加到actual列表中  
                   .Callback<Site>(p => actual.Add(p));

            mockSet.As<IQueryable<Site>>()
                .Setup(m => m.Provider)
                   .Returns(sites.Provider);

            mockSet.As<IQueryable<Site>>().Setup(m => m.Expression).Returns(sites.Expression);
            mockSet.As<IQueryable<Site>>().Setup(m => m.ElementType).Returns(sites.ElementType);
            mockSet.As<IQueryable<Site>>().Setup(m => m.GetEnumerator()).Returns(() => sites.GetEnumerator());

            var mockContext = new Mock<BusinessDbContext>();
            mockContext.Setup(c => c.Set<Site>()).Returns(mockSet.Object);

            var entityRepository = new DomainRepository<Site>(mockContext.Object);


            var result = entityRepository.Find(Guid.NewGuid());

            Assert.Null(result);

            entityRepository.Add(new Site(new TenantId("abc"), "abc", "abc", true));
            entityRepository.Add(new Site(new TenantId("abc"), "def", "def", true));
            entityRepository.SaveChanges();

            // Assert  
            Assert.Equal(expected.Count(), actual.Count());  
        }


        [Fact]
        public void Site_should_save_new_record()
        {
            var entityRepository = new DomainRepository<Site>(dbContext);
            var site = new Site(new TenantId("abc"), "def", "def", true);
            entityRepository.Add(site);
            dbContext.Entry(site).State = EntityState.Added;
            entityRepository.SaveChanges();

            var result = entityRepository.Find(site.Id);

            Assert.NotNull(result);

            Assert.Equal("def", result.Name);
        }
    }
}
