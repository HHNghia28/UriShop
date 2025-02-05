using MediatR;
using Order.Application.Exceptions;
using Order.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Features.Order.Commands.UpdateStatusOrder
{
    public class UpdateStatusOrderCommandHandler(IOrderRepository _orderRepository)
        : IRequestHandler<UpdateStatusOrderCommand>
    {
        public async Task Handle(UpdateStatusOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.Id) ?? throw new NotFoundException("Order not found");

            order.Status = request.Status;

            await _orderRepository.UpdateAsync(order);
            await _orderRepository.SaveAsync();
        }
    }
}
