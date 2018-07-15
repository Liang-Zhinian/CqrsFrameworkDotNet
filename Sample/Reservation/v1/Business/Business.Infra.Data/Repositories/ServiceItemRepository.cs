using Business.Domain.Entities.ServiceCategories;
using Business.Domain.Repositories;
using Business.Infrastructure.Context;

namespace Business.Infrastructure.Repositories
{
    public class ServiceItemRepository : DomainRepository<SchedulableCatalogItem>, IServiceItemRepository
    {
        public ServiceItemRepository(BusinessDbContext context):base(context){}

    }
}
