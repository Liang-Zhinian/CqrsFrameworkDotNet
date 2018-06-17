
namespace SaaSEqt.IdentityAccess.Infra.Data.Models
{
	using System;
	using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


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

        [Key]
        public Guid Id { get; set; }

        public Guid TenantId { get; set; }

        public Guid MemberId { get; set; }

        public Guid GroupId { get; set; }

        public int MemberType { get; set; }

        [NotMapped]
        public MemberTypes Type
        {
            get { return (MemberTypes)this.MemberType; }
            set { this.MemberType = (int)value; }
        }

        public virtual Tenant Tenant { get; set; }
        public virtual Group Group { get; set; }
        //public virtual Group GroupAsMember { get; set; }
        //public virtual User UserAsMember { get; set; }

		#endregion

	}
}