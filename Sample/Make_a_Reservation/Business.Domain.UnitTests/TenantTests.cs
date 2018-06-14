using System;
using Xunit;
using Business.Domain.Models.Security;

namespace Business.Domain.UnitTests
{
	public class TenantTests
    {
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
    }
}
