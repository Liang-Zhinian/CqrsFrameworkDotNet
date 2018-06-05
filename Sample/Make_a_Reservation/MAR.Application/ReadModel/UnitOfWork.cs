using System;
namespace MAR.Application.ReadModel
{
    public class UnitOfWork : IDisposable
    {
        public UnitOfWork()
        {
        }

        private readonly ApplicationDbContext _context = null;
        private EmployeeRepository _employeeRepository = null;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public EmployeeRepository EmployeeRepository
        {
            get { return _employeeRepository ?? (_employeeRepository = new EmployeeRepository(_context)); }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
