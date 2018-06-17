
namespace SaaSEqt.IdentityAccess.Infra.Data.Models
{
	using System;
	using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;


    public class Tenant
	{
        #region [ Public Properties ]

        [Key]
        public Guid Id { get; set; }

		public string Name { get; set; }

		public bool Active { get; set; }

		public string Description { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<GroupMember> GroupMembers { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<RoleMember> RoleMembers { get; set; }

		#endregion
	}
}