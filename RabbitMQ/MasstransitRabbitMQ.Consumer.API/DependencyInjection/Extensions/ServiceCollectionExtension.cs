using MassTransit;
using MasstransitRabbitMQ.Consumer.API.DependencyInjection.Options;
using MasstransitRabbitMQ.Consumer.API.MessageBus.Consumers.Events;
using System.Reflection;

namespace MasstransitRabbitMQ.Consumer.API.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddConfigMasstransitRebbitMQ(this IServiceCollection services, IConfiguration configuration)
        {
            var masstransitConfiguration = new MasstransitConfiguration();
            configuration.GetSection(nameof(masstransitConfiguration)).Bind(masstransitConfiguration);

            services.AddMassTransit(mt =>
            {
                mt.AddConsumers(Assembly.GetExecutingAssembly());

                mt.UsingRabbitMq((context, bus) =>
                {
                    bus.Host(masstransitConfiguration.Host, masstransitConfiguration.VHost, h =>
                    {
                        h.Username(masstransitConfiguration.Username);
                        h.Password(masstransitConfiguration.Password);
                    });

                    bus.ConfigureEndpoints(context);
                });
            });

            return services;
        }
    }
}
