
namespace SaaSEqt.IdentityAccess.Infra.Data.Models
{
	using System;
	using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class User
	{
        #region [ Public Properties ]

        [Key]
        public Guid Id { get; set; }

        public Guid TenantId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public bool IsEnabled { get; set; }

        //[NotMapped]
        public Enablement Enablement { get; set; }

        public PersonalInfo PersonalInfo { get; set; }

        public PostalAddress PostalAddress { get; set; }

        public string PrimaryTelephone { get; set; }

        public string SecondaryTelephone { get; set; }

        public virtual Tenant Tenant { get; set; }

        //public virtual ICollection<GroupMember> GroupMembers { get; set; }
        //public virtual ICollection<GroupMember> ChildGroupMembers { get; set; }
        //public virtual ICollection<RoleMember> RoleMembers { get; set; }
		#endregion
	}
}