using MasstransitRabbitMQ.Consumer.API.Abstractions.Messages;
using MasstransitRabbitMQ.Contract.IntegrationEvents;
using MediatR;

namespace MasstransitRabbitMQ.Consumer.API.MessageBus.Consumers.Events
{
    public class SendEmailWhenReceivedEmailEventConsumer(ISender sender) : Consumer<DomainEvent.EmailNotificationEvent>(sender)
    {
    }
}
