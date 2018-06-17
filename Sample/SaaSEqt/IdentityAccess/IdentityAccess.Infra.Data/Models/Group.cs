
namespace SaaSEqt.IdentityAccess.Infra.Data.Models
{
	using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

	/// <summary>
	/// An entity representing a group of users
	/// and possibly of other groups for a
	/// particular <see cref="Tenant"/>.
	/// </summary>
	
    public class Group
	{
        #region [ Public Properties ]

        [Key]
        public Guid Id { get; set; }

        public Guid TenantId { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		/// <summary>
		/// Gets a value indicating whether this group exists only
		/// to manage the membership in an authentication
		/// <see cref="Domain.Model.Access.Role"/>.
		/// If <c>true</c>, this group should not be
		/// shown on any lists of groups.
		/// </summary>
        private bool IsInternalGroup { get; set; }

        public virtual Tenant Tenant { get; set; }

        public virtual ICollection<GroupMember> GroupMembers { get; set; }
        //public virtual ICollection<GroupMember> GroupAsParentGroupMembers { get; set; }
        //public virtual ICollection<GroupMember> ChildGroupMembers { get; set; }
        //public virtual ICollection<RoleMember> RoleMembers { get; set; }
		#endregion

	}
}