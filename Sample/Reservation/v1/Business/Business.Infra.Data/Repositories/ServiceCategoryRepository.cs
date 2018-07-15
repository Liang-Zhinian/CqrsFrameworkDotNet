using Business.Domain.Entities.ServiceCategories;
using Business.Domain.Repositories;
using Business.Infrastructure.Context;

namespace Business.Infrastructure.Repositories
{
    public class ServiceCategoryRepository : DomainRepository<ServiceCategory>, IServiceCategoryRepository
    {
        public ServiceCategoryRepository(BusinessDbContext context):base(context){}

    }
}
