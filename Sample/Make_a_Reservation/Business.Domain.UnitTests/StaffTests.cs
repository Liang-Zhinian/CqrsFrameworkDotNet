using System;
using Xunit;
using Business.Domain.Models.Security;

namespace Business.Domain.UnitTests
{
	public class StaffTests
    {
        private Tenant newTenant;
        private Location newLocation;
        private Staff newStaff;

        public StaffTests()
        {
            newTenant = new Tenant();
            newLocation = new Location(newTenant.Id);
            newStaff = new Staff(newTenant.Id);
        }

        [Fact]
        public void Staff_should_have_valid_Guid()
        {
            //
            // Arrange
            Staff staff = new Staff();
            //
            // Act

            //
            // Assert
            Assert.NotNull(staff.Id);
            Assert.NotEqual<Guid>(staff.Id, Guid.Empty);
            Assert.NotNull(newStaff.Id);
            Assert.NotEqual<Guid>(newStaff.Id, Guid.Empty);
        }

        [Fact]
        public void Staff_Address_should_be_valid()
        {
            //
            // Arrange

            StaffAddress staffAddress = new StaffAddress();
            //
            // Act

            //
            // Assert
            Assert.NotNull(staffAddress.Id);
            Assert.NotEqual<Guid>(staffAddress.Id, Guid.Empty);
            Assert.NotNull(newStaff.Address);
            Assert.NotNull(newStaff.Address.Id);
            Assert.NotEqual<Guid>(newStaff.Address.Id, Guid.Empty);
            Assert.Equal(newStaff.Id, newStaff.Address.StaffId);
            Assert.Equal(newTenant.Id, newStaff.Address.TenantId);
        }

        [Fact]
        public void Staff_Contact_should_be_valid()
        {
            //
            // Arrange

            StaffContact staffContact = new StaffContact();
            //
            // Act

            //
            // Assert
            Assert.NotNull(staffContact.Id);
            Assert.NotEqual<Guid>(staffContact.Id, Guid.Empty);
            Assert.NotNull(newStaff.Contact);
            Assert.NotNull(newStaff.Contact.Id);
            Assert.NotEqual<Guid>(newStaff.Contact.Id, Guid.Empty);
            Assert.Equal(newStaff.Id, newStaff.Contact.StaffId);
            Assert.Equal(newTenant.Id, newStaff.Contact.TenantId);
        }
    }
}
