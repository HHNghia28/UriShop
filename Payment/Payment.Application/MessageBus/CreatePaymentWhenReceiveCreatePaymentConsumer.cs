using MassTransit;
using MediatR;
using Payment.Application.Features.Payment.Commands.CreatePaymentOrder;
using Infrastructure.RabbitMQ.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Application.MessageBus
{
    public class CreatePaymentWhenReceiveCreatePaymentConsumer(ISender _sender) : IConsumer<CreatePaymentEvent>
    {
        public async Task Consume(ConsumeContext<CreatePaymentEvent> context)
        {
            await _sender.Send(new CreateOrderPaymentByPayOSCommand
            {
                OrderId = context.Message.OrderId,
                CreatedById = context.Message.CreatedById,
                RequiredAmount = context.Message.RequiredAmount,
            });
        }
    }
}
