using System;
namespace MAR.Infra.Data
{
    public static class Program
    {
        public void Main(string[] args)
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
        public static IWebHost SeedData(this IWebHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                SeedCountries(context);
            }
            return host;
        }
    }
}
