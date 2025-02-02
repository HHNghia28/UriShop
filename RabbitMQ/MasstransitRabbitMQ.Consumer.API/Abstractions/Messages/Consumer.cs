using MassTransit;
using MasstransitRabbitMQ.Contract.Astractions.Messages;
using MediatR;

namespace MasstransitRabbitMQ.Consumer.API.Abstractions.Messages
{
    public abstract class Consumer<T>(ISender sender) : IConsumer<T> where T : class, INotificationEvent
    {
        private readonly ISender _sender = sender;

        public async Task Consume(ConsumeContext<T> context)
            => await _sender.Send(context.Message);
    }
}
