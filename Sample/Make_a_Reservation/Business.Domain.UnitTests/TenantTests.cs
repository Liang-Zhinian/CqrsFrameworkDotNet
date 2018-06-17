using System;
using Xunit;
using Business.Domain.Models.Security;
using Business.Infra.Data;
using Business.Domain.Repositories.Interfaces;
using Business.Infra.Data.Repositories;
using Business.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Moq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Business.Domain.UnitTests
{
	public class TenantTests
    {
        /*
        private ITenantRepository repository;
        public TenantTests()
        {
            BusinessDbContext dbContext = new BusinessDbContext();
            repository = new TenantRepository(dbContext);
        }

        [Fact]
        public void Tenant_should_have_valid_Guid()
        {
            //
            // Arrange
            Tenant newTenant = new Tenant();

            //
            // Act

            //
            // Assert
            Assert.NotNull(newTenant.Id);
            Assert.NotEqual<Guid>(newTenant.Id, Guid.Empty);
        }

        [Fact]
        public void Tenant_Address_should_be_valid()
        {
            //
            // Arrange
            Tenant newTenant = new Tenant();

            //
            // Act

            //
            // Assert
            Assert.NotNull(newTenant.Address);
            Assert.NotNull(newTenant.Address.Id);
            Assert.NotEqual<Guid>(newTenant.Address.Id, Guid.Empty);
            Assert.Equal(newTenant.Id, newTenant.Address.TenantId);
        }

        [Fact]
        public void Tenant_Address_should_be_valid2()
        {
            //
            // Arrange
            TenantAddress newAddress = new TenantAddress();

            //
            // Act

            //
            // Assert
            Assert.NotNull(newAddress.Id);
            Assert.NotEqual<Guid>(newAddress.Id, Guid.Empty);
        }

        [Fact]
        public void Tenant_Contact_should_be_valid()
        {
            //
            // Arrange
            Tenant newTenant = new Tenant();

            //
            // Act

            //
            // Assert
            Assert.NotNull(newTenant.Contact);
            Assert.NotNull(newTenant.Contact.Id);
            Assert.NotEqual<Guid>(newTenant.Contact.Id, Guid.Empty);
            Assert.Equal(newTenant.Id, newTenant.Contact.TenantId);
        }

        [Fact]
        public void Tenant_Contact_should_be_valid2()
        {
            //
            // Arrange
            TenantContact newContact = new TenantContact();

            //
            // Act

            //
            // Assert
            Assert.NotNull(newContact.Id);
            Assert.NotEqual<Guid>(newContact.Id, Guid.Empty);
        }

        [Fact]
        public void Tenant_Branding_should_be_valid()
        {
            //
            // Arrange
            Tenant newTenant = new Tenant();

            //
            // Act

            //
            // Assert
            Assert.NotNull(newTenant.Branding);
            Assert.NotNull(newTenant.Branding.Id);
            Assert.NotEqual<Guid>(newTenant.Branding.Id, Guid.Empty);
            Assert.Equal(newTenant.Id, newTenant.Branding.TenantId);
        }

        [Fact]
        public void Tenant_Branding_should_be_valid2()
        {
            //
            // Arrange
            Branding newBranding = new Branding();

            //
            // Act

            //
            // Assert
            Assert.NotNull(newBranding.Id);
            Assert.NotEqual<Guid>(newBranding.Id, Guid.Empty);
        }

        [Fact]
        public void Tenant_should_create_new_record(){
                var tenants = new List<Tenant>() {
                new Tenant("abc", "abc"),
                new Tenant("def", "def"),
            }.AsQueryable();


            var expected = new Collection<Tenant>
            {

                new Tenant("abc", "abc"),
                new Tenant("def", "def"),
            };

            var actual = new Collection<Tenant>();

            var mockSet = new Mock<DbSet<Tenant>>();


            mockSet.Setup(r => r.Add(It.IsAny<Tenant>())) 
            // 在Callback函数里把SavePatient的入参添加到actual列表中  
                   .Callback<Tenant>(p => actual.Add(p));

            mockSet.As<IQueryable<Tenant>>()
                .Setup(m => m.Provider)
                   .Returns(tenants.Provider);

            mockSet.As<IQueryable<Tenant>>().Setup(m => m.Expression).Returns(tenants.Expression);
            mockSet.As<IQueryable<Tenant>>().Setup(m => m.ElementType).Returns(tenants.ElementType);
            mockSet.As<IQueryable<Tenant>>().Setup(m => m.GetEnumerator()).Returns(() => tenants.GetEnumerator());

            var mockContext = new Mock<BusinessDbContext>();
            mockContext.Setup(c => c.Set<Tenant>()).Returns(mockSet.Object);

            var entityRepository = new DomainRepository<Tenant>(mockContext.Object);


            var result = entityRepository.Find(Guid.NewGuid());

            Assert.Null(result);


            entityRepository.Add(new Tenant("abc", "abc"));
            entityRepository.Add(new Tenant("def", "def"));
            entityRepository.SaveChanges();

            // Assert  
            Assert.Equal(expected.Count(), actual.Count());  
        }
        */
    }
}
