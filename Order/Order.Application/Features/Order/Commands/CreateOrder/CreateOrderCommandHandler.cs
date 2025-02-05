using MediatR;
using Order.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Order.Application.Exceptions;
using Order.Domain.Entities;
using Order.Domain.Shares;
using Polly.Retry;
using Polly;
using Infrastructure.RabbitMQ.Events;
using MassTransit;

namespace Order.Application.Features.Order.Commands.CreateOrder
{
    public class CreateOrderCommandHandler(IOrderRepository _orderRepository, ISendEndpointProvider _sendEndpointProvider)
    : IRequestHandler<CreateOrderCommand, long>
    {
        private readonly AsyncRetryPolicy _retryPolicy = Policy
            .Handle<Exception>()
            .WaitAndRetryAsync(3, retryAttempt =>
                TimeSpan.FromMilliseconds(100),
                (exception, timeSpan, retryCount, context) =>
                {
                    Console.WriteLine($"Retry {retryCount} due to: {exception.Message}");
                });

        public async Task<long> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            List<OrderDetail> orderDetails = [];
            long orderId = OrderIdUtility.GetNewOrderId();

            foreach (var item in request.Details)
            {
                orderDetails.Add(new OrderDetail()
                {
                    Id = Guid.NewGuid(),
                    Discount = item.Discount,
                    Name = item.Name,
                    OrderId = orderId,
                    Photo = item.Photo,
                    Price = item.Price,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Category = item.Category,
                });
            }

            var totalPrice = orderDetails.Sum(d => (d.Price * (1 - (d.Discount / 100))) * d.Quantity)
                             * (1 - (request.VoucherValue / 100))
                             + request.ShippingFee - request.DiscountFee;

            var order = new Domain.Entities.Order()
            {
                Id = orderId,
                Address = request.Address,
                DiscountFee = request.DiscountFee,
                FullName = request.FullName,
                Note = request.Note,
                Phone = request.Phone,
                CreatedById = request.CreatedBy,
                LastModifiedById = request.CreatedBy,
                ShippingFee = request.ShippingFee,
                VoucherCode = request.VoucherCode,
                VoucherName = request.VoucherName,
                VoucherValue = request.VoucherValue,
                TotalPrice = totalPrice,
                Details = orderDetails
            };

            await _orderRepository.AddAsync(order);

            await _retryPolicy.ExecuteAsync(async () => await _orderRepository.SaveAsync());

            var endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue:create-payment-queue"));
            await endpoint.Send(new CreatePaymentEvent { OrderId = orderId, RequiredAmount = totalPrice, CreatedById = request.CreatedBy }, cancellationToken);

            return orderId;
        }
    }
}
