using Business.Domain.Entities.ServiceCategories;
using Business.Domain.Repositories;
using Business.Infra.Data.Context;

namespace Business.Infra.Data.Repositories
{
    public class ServiceItemRepository : DomainRepository<ServiceItem>, IServiceItemRepository
    {
        public ServiceItemRepository(BusinessDbContext context):base(context){}

    }
}
