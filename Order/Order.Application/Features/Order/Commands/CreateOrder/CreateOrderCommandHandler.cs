using MediatR;
using Order.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Features.Order.Commands.CreateOrder
{
    public class CreateOrderCommandHandler(IOrderRepository orderRepository) : IRequestHandler<CreateOrderCommand>
    {
        private readonly IOrderRepository _orderRepository = orderRepository;

        public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            Guid orderId = Guid.NewGuid();

            var orderDetails = request.Details.Select(o => new Domain.Entities.OrderDetail()
            {
                Id = Guid.NewGuid(),
                Discount = o.Discount,
                Name = o.Name,
                OrderId = orderId,
                Photo = o.Photo,
                Price = o.Price,
                ProductId = o.ProductId,
                Quantity = o.Quantity,
                Category = o.Category,
            }).ToList();

            var totalPrice = orderDetails.Sum(d => (d.Price * (1 - (d.Discount / 100))) * d.Quantity) * (1 - (request.VoucherValue / 100)) + request.ShippingFee - request.DiscountFee;

            await _orderRepository.AddAsync(new Domain.Entities.Order()
            {
                Id = orderId,
                Address = request.Address,
                DiscountFee = request.DiscountFee,
                FullName = request.FullName,
                Note = request.Note,
                Phone = request.Phone,
                CreatedBy = request.CreatedBy,
                LastModifiedBy = request.CreatedBy,
                ShippingFee = request.ShippingFee,
                VoucherCode = request.VoucherCode,
                VoucherName = request.VoucherName,
                VoucherValue = request.VoucherValue,
                TotalPrice = totalPrice,
                Details = orderDetails
            });

            await _orderRepository.SaveAsync();
        }

    }
}
