using MassTransit;
using MasstransitRabbitMQ.Producer.API.DependencyInjection.Options;

namespace MasstransitRabbitMQ.Producer.API.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddConfigMasstransitRebbitMQ(this IServiceCollection services, IConfiguration configuration)
        {
            var masstransitConfiguration = new MasstransitConfiguration();
            configuration.GetSection(nameof(masstransitConfiguration)).Bind(masstransitConfiguration);

            services.AddMassTransit(mt =>
            {
                mt.UsingRabbitMq((context, bus) =>
                {
                    bus.Host(masstransitConfiguration.Host, masstransitConfiguration.VHost, h =>
                    {
                        h.Username(masstransitConfiguration.Username);
                        h.Password(masstransitConfiguration.Password);
                    });
                });
            });

            return services;
        }
    }
}
