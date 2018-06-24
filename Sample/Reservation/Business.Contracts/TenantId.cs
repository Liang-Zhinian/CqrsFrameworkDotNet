
namespace Business.Domain.Entities
{
	using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using SaaSEqt.Common.Domain.Model;

    /// <summary>
    /// A value object derived from <see cref="Identity"/>
    /// which identifies a <see cref="Tenant"/>,
    /// </summary>
    /// <remarks>
    /// This is the only implementation of <see cref="IIdentity"/>
    /// in the "Identity and Access" Bounded Context.
    /// </remarks>
    [Serializable]
    [NotMapped]
	public sealed class TenantId : Identity
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TenantId"/> class
		/// with a new <see cref="Guid"/> assigned to the value of the
		/// base <see cref="IIdentity.Id"/> property.
		/// </summary>
		public TenantId()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="TenantId"/> class
		/// using a given <paramref name="id"/> string.
		/// </summary>
		/// <param name="id">
		/// Initial value of the base <see cref="IIdentity.Id"/> property.
		/// </param>
		public TenantId(string id)
			: base(id)
		{
		}
	}
}