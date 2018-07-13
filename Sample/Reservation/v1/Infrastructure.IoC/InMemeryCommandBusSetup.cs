using System;
using CqrsFramework.Commands;
using CqrsFramework.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.IoC
{
    public static class InMemeryCommandBusSetup
    {
        public static void AddInMemeryCommandBusSetup(this IServiceCollection services)
        {
            services.AddSingleton<Router>(new Router());
            services.AddSingleton<ICommandSender>(y => y.GetService<Router>());
            services.AddSingleton<IHandlerRegistrar>(y => y.GetService<Router>());
        }
    }
}
