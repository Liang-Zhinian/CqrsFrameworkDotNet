using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaaSEqt.IdentityAccess.Infra.Data.Models
{


    public class RoleMember
    {
        
        #region [ Public Properties ]

        [Key]
        public Guid Id { get; set; }

        public Guid TenantId { get; set; }

        public Guid MemberId { get; set; }

        public Guid RoleId { get; set; }

        public int MemberType { get; set; }

        [NotMapped]
        public MemberTypes Type
        {
            get { return (MemberTypes)this.MemberType; }
            set { this.MemberType = (int)value; }
        }

        public virtual Tenant Tenant { get; set; }
        public virtual Role Role { get; set; }
        //public virtual Group Group { get; set; }
        //public virtual User User { get; set; }

        #endregion
    }
}
