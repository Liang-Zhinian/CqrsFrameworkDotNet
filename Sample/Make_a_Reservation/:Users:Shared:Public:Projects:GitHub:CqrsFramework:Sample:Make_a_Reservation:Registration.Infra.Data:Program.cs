using System;
namespace Registration.Infra.Data
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var host = BuildWebHost(args);
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                DataSeeder.SeedCountries(context);
            }
            host.Run();
        }
    }
}
