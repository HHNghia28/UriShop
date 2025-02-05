using MassTransit;
using Order.Infrastructure.RabbitMQ.Config;
using Infrastructure.RabbitMQ.Events;
using System.Reflection;
using Order.Application.MessageBus;

namespace Order.API.Extensions
{
    public static class AddConfigRebbitMQ
    {
        public static IServiceCollection AddConfigMasstransitRebbitMQ(this IServiceCollection services, IConfiguration configuration)
        {
            var masstransitConfiguration = new RabbitMQConfig();
            configuration.GetSection(RabbitMQConfig.ConfigName).Bind(masstransitConfiguration);

            services.AddMassTransit(mt =>
            {
                mt.AddConsumer<UpdateStatusOrderConsumer>();

                mt.UsingRabbitMq((context, bus) =>
                {
                    bus.Host(masstransitConfiguration.Host, masstransitConfiguration.VHost, h =>
                    {
                        h.Username(masstransitConfiguration.Username);
                        h.Password(masstransitConfiguration.Password);
                    });

                    bus.ConfigureEndpoints(context);

                    bus.ReceiveEndpoint("update-status-order-queue", e =>
                    {
                        e.ConfigureConsumer<UpdateStatusOrderConsumer>(context);
                    });
                });
            });

            return services;
        }
    }
}
