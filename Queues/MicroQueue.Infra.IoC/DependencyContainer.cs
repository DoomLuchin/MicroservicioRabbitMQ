using MediatR;
using MicroQueue.Publisher.Application.Interfaces;
using MicroQueue.Publisher.Application.Services;
using MicroQueue.Publisher.Domain.CommandHandlers;
using MicroQueue.Publisher.Domain.Commands;
using MicroQueue.Domain.Core.Bus;
using MicroQueue.Infra.Bus;
using MicroQueue.Consumer.Application.Interfaces;
using MicroQueue.Consumer.Application.Services;
using MicroQueue.Consumer.Domain.EventHandlers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace MicroQueue.Infra.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            //MediatR Mediator
            services.AddMediatR(Assembly.GetExecutingAssembly());

            //Domain Bus
            services.AddSingleton<IEventBus, RabbitMQBus>(sp => { 
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                var optionsFactory = sp.GetService<IOptions<RabbitMQSettings>>();
                return new RabbitMQBus(sp.GetService<IMediator>(), scopeFactory, optionsFactory );
            });
            
            return services;
        }

    }
}