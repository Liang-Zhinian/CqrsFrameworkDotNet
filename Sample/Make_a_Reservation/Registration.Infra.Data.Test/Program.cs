using System;
using Registration.Domain.ReadModel.Security;
using Registration.Domain.Repositories.Interfaces;
using Registration.Infra.Data.Repositories;

namespace Registration.Infra.Data.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            ITenantRepository repository = new TenantRepository(new Context.Book2DbContext());

            for (int i = 0; i < 100; i++)
            {
                Tenant tenant = new Tenant();
                tenant.Id = Guid.NewGuid().ToString();
                //var profile = message.StaffProfile;
                tenant.Name = "tenant#"+ ++i;
                tenant.DisplayName = "tenant#" + ++i;

                tenant.Contact = new TenantContact()
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = "tenant#" + ++i+ "@abc.com",
                    Email2 = "",
                    Phone = "123",
                    Phone2 = "",
                    Phone3 = "",
                    TenantId = tenant.Id
                };
                tenant.Address = new TenantAddress()
                {
                    Id = Guid.NewGuid().ToString(),
                    Street = "123",
                    Street2 = "123",
                    State = "123",
                    City = "123",
                    Country = "United States of America",
                    TenantId = tenant.Id
                };

                repository.Add(tenant);
            }
            repository.SaveChanges();

            var tenants = repository.GetAll();
            foreach (var tenant in tenants)
            {
                Console.WriteLine(tenant.Name);
            }
        }
    }
}
