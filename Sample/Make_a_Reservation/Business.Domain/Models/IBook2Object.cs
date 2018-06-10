using System;
using Business.Domain.Models.Security;

namespace Business.Domain.Models
{
    public interface IBook2Object
    {
        Tenant Tenant { get; set; }
    }
}
