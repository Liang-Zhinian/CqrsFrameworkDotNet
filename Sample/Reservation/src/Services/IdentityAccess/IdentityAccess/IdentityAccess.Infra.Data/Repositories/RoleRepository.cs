using DomainModels = SaaSEqt.IdentityAccess.Domain.Entities;
using SaaSEqt.IdentityAccess.Domain.Repositories;
using SaaSEqt.IdentityAccess.Infra.Data.Context;
//using ReadModels = SaaSEqt.IdentityAccess.Infra.Data.Models;
using System;
using System.Linq;

namespace SaaSEqt.IdentityAccess.Infra.Data.Repositories
{

    /// <summary>
    /// Contract for a collection-oriented repository of <see cref="Role"/> entities.
    /// </summary>
    /// <remarks>
    /// Because this is a collection-oriented repository, the <see cref="Add"/>
    /// method needs to be called no more than once per stored entity.
    /// Subsequent changes to any stored <see cref="Role"/> are implicitly
    /// persisted, and adding the same entity a second time will have no effect.
    /// </remarks>

    public class RoleRepository : DomainRepository<DomainModels.Role>, IRoleRepository
    {
        public RoleRepository(IdentityAccessDbContext context) : base(context) { }

        public void Add(DomainModels.Role role)
        {
            //ReadModels.Role r = new ReadModels.Role
            //{
            //    Id = Guid.NewGuid(),
            //    Description = role.Description,
            //    Name = role.Name,
            //    SupportsNesting = role.SupportsNesting,
            //    TenantId = Guid.Parse(role.TenantId.Id)
            //};
            base.Add(role);
            base.SaveChanges();
        }

        public DomainModels.Role RoleNamed(DomainModels.TenantId tenantId, string roleName)
        {
            DomainModels.Role role = Find(_ => _.TenantId.Equals(tenantId.Id)
                        && _.Name.Equals(roleName)).First();

            return role; //new DomainModels.Role(tenantId, roleName, role.Description, role.SupportsNesting);
        }
    }
}