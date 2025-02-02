using MediatR;
using Order.Application.DTO;
using Order.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Order.Application.Wrappers;

namespace Order.Application.Features.Order.Queries.GetOrder
{
    public class GetOrderQueryHandler(IOrderRepository _orderRepository) 
        : IRequestHandler<GetOrderQuery, OrderResponse>
    {
        public async Task<OrderResponse> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrder(request.Id);

            return order;
        }
    }
}
