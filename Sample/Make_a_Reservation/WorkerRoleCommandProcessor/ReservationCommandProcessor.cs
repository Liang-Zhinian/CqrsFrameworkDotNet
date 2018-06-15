using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;


namespace WorkerRoleCommandProcessor
{
    public class ReservationCommandProcessor : IDisposable
    {
        private ServiceProvider serviceProvider;

        public ReservationCommandProcessor()
        {
            this.serviceProvider = CreateServiceProvider();
            RegisterHandlers(serviceProvider);
        }

        public void Start()
        {
        }

        public void Stop()
        { 
        }

        public void Dispose()
        {
        }

        private static ServiceProvider CreateServiceProvider()
        {

            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .BuildServiceProvider();


        //configure console logging

            return serviceProvider;
        }


        private static void RegisterHandlers(ServiceProvider serviceProvider)
        {
        }
    }
}
