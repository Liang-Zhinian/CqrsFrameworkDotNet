
namespace SaaSEqt.IdentityAccess.Domain.Models.ReadModels
{
	using System;
	using System.Collections.Generic;

	using SaaSEqt.Common.Domain.Model;

	/// <summary>
	/// A value object, based on either <see cref="User"/> or <see cref="Group"/>,
	/// which may be among the <see cref="Group.GroupMembers"/> of a group.
	/// </summary>
	/// <remarks>
	/// The <see cref="User"/> and <see cref="Group"/> entities include factory methods
	/// <see cref="User.ToGroupMember"/> and <see cref="Group.ToGroupMember"/>,
	/// respectively, which are used to create instances of this value.
	/// </remarks>
	
	public class GroupMember
	{
		#region [ Public Properties ]

		public string TenantId { get; set; }

		public string Name { get; set; }

		public GroupMemberType Type { get; set; }

		#endregion

	}
}