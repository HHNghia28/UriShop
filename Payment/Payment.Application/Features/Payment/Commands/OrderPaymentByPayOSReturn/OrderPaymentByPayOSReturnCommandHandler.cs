using MediatR;
using Microsoft.Extensions.Options;
using Payment.Application.Features.Payment.Commands.OrderPaymentByPayOSReturn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Payment.Application.Exceptions;
using Payment.Application.Interfaces;
using Payment.Infrastructure.PayOS.Config;
using MassTransit;
using Infrastructure.RabbitMQ.Events;

namespace Payment.Application.Features.Payment.Commands.OrderPaymentByPayOSReturn
{
    public class OrderPaymentByPayOSReturnCommandHandler(IPaymentRepository _paymentRepository
        , ISendEndpointProvider _sendEndpointProvider
        , IOptions<PayOSConfig> payosConfigOptions) 
        : IRequestHandler<OrderPaymentByPayOSReturnCommand, string>
    {
        private readonly PayOSConfig _payOSConfig = payosConfigOptions.Value;

        public async Task<string> Handle(OrderPaymentByPayOSReturnCommand request, CancellationToken cancellationToken)
        {
            long orderId = long.Parse(request.OrderCode);
            var payment = await _paymentRepository.GetByIdAsync(orderId) ?? throw new NotFoundException("Payment not found");

            if (request.Code == "00" && request.Status == "PAID")
            {
                payment.Status = Domain.Enums.PaymentStatus.PAIDED;
            }
            else
            {
                payment.Status = Domain.Enums.PaymentStatus.CANCEL;
            }

            await _paymentRepository.UpdateAsync(payment);

            var endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue:update-status-order-queue"));
            await endpoint.Send(new PaymentPayOSReturnEvent { OrderId = orderId, IsSuccess = request.Code == "00" && request.Status == "PAID" }, cancellationToken);

            return _payOSConfig.ClientRedirectUrl;
        }
    }
}
