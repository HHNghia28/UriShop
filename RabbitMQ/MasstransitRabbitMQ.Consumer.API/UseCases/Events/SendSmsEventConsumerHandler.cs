using MasstransitRabbitMQ.Contract.IntegrationEvents;
using MediatR;

namespace MasstransitRabbitMQ.Consumer.API.UseCases.Events
{
    public class SendSmsEventConsumerHandler : IRequestHandler<DomainEvent.SmsNotificationEvent>
    {
        public async Task Handle(DomainEvent.SmsNotificationEvent request, CancellationToken cancellationToken)
        {
            Console.WriteLine(request);
        }
    }
}
