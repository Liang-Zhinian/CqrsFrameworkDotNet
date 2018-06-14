using System;
using Xunit;
using Business.Domain.Models.Security;

namespace Business.Domain.UnitTests
{
	public class LocationTests
    {
        private Tenant newTenant;
        private Location newLocation;

        public LocationTests()
        {
            newTenant = new Tenant();
            newLocation = new Location(newTenant.Id);
        }

        [Fact]
        public void Location_should_have_valid_Guid()
        {
            //
            // Arrange
            //
            // Act

            //
            // Assert
            Assert.NotNull(newLocation.Id);
            Assert.NotEqual<Guid>(newLocation.Id, Guid.Empty);
        }

        [Fact]
        public void Location_Address_should_be_valid()
        {
            //
            // Arrange

            //
            // Act

            //
            // Assert
            Assert.NotNull(newLocation.Address);
            Assert.NotNull(newLocation.Address.Id);
            Assert.NotEqual<Guid>(newLocation.Address.Id, Guid.Empty);
            Assert.Equal(newLocation.Id, newLocation.Address.LocationId);
            Assert.Equal(newTenant.Id, newLocation.Address.TenantId);
        }

        [Fact]
        public void Location_Contact_should_be_valid()
        {
            //
            // Arrange

            //
            // Act

            //
            // Assert
            Assert.NotNull(newLocation.Contact);
            Assert.NotNull(newLocation.Contact.Id);
            Assert.NotEqual<Guid>(newLocation.Contact.Id, Guid.Empty);
            Assert.Equal(newLocation.Id, newLocation.Contact.LocationId);
            Assert.Equal(newTenant.Id, newLocation.Contact.TenantId);
        }
    }
}
