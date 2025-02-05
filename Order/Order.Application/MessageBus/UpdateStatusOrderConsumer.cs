using Infrastructure.RabbitMQ.Events;
using MassTransit;
using MediatR;
using Order.Application.Features.Order.Commands.UpdateOrder;
using Order.Application.Features.Order.Commands.UpdateStatusOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.MessageBus
{
    public class UpdateStatusOrderConsumer(ISender _sender) : IConsumer<PaymentPayOSReturnEvent>
    {
        public async Task Consume(ConsumeContext<PaymentPayOSReturnEvent> context)
        {
            await _sender.Send(new UpdateStatusOrderCommand()
            {
                Id = context.Message.OrderId,
                Status = context.Message.IsSuccess ? Domain.Enums.OrderStatus.PAIDED : Domain.Enums.OrderStatus.CANCEL,
            });
        }
    }
}
