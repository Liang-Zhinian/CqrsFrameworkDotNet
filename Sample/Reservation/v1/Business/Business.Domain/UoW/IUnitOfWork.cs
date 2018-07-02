using System;
namespace Business.Domain.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
