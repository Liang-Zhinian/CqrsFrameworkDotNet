
namespace SaaSEqt.IdentityAccess.Infra.Data.Models
{
	using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

	/// <summary>
	/// An entity representing an authentication role for a
	/// particular <see cref="Tenant"/>, which determines
	/// the types of access granted or denied to a
	/// <see cref="User"/> or <see cref="Group"/>.
	/// </summary>
	/// <remarks>
	/// <para>
	/// This class borrows functionality from an internal
	/// instance of <see cref="Group"/> to be able to
	/// assign users and groups to this role.
	/// </para>
	/// <para>
	/// A role might also be called a "claim" in some
	/// authentication approaches.
	/// </para>
	/// </remarks>
	
    public class Role
	{
        #region [ Public Properties ]

        [Key]
        public Guid Id { get; set; }

		public string Description { get; set; }

		public string Name { get; set; }

		public bool SupportsNesting { get; set; }

        public Guid TenantId { get; set; }

        public virtual Tenant Tenant { get; set; }

        public virtual ICollection<RoleMember> RoleMembers { get; set; }

		#endregion

	}
}