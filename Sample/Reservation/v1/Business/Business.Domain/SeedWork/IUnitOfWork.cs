using System;
namespace Business.Domain.SeedWork
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
