using Infrastructure.RabbitMQ.Events;
using MassTransit;
using Payment.Application.MessageBus;
using Payment.Infrastructure.RabbitMQ.Config;
using System.Reflection;

namespace Payment.API.Extensions
{
    public static class AddConfigRebbitMQ
    {
        public static IServiceCollection AddConfigMasstransitRebbitMQ(this IServiceCollection services, IConfiguration configuration)
        {
            var masstransitConfiguration = new RabbitMQConfig();
            configuration.GetSection(RabbitMQConfig.ConfigName).Bind(masstransitConfiguration);

            services.AddMassTransit(mt =>
            {
                mt.AddConsumer<CreatePaymentWhenReceiveCreatePaymentConsumer>();

                mt.UsingRabbitMq((context, bus) =>
                {
                    bus.Host(masstransitConfiguration.Host, masstransitConfiguration.VHost, h =>
                    {
                        h.Username(masstransitConfiguration.Username);
                        h.Password(masstransitConfiguration.Password);
                    });

                    bus.ConfigureEndpoints(context);

                    bus.ReceiveEndpoint("create-payment-queue", e =>
                    {
                        e.ConfigureConsumer<CreatePaymentWhenReceiveCreatePaymentConsumer>(context);
                    });
                });
            });

            return services;
        }
    }
}
