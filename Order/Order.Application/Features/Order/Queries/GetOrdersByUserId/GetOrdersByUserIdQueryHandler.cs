using MediatR;
using Order.Application.DTO;
using Order.Application.Interfaces;
using Order.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Features.Order.Queries.GetOrdersByUserId
{
    public class GetOrdersByUserIdQueryHandler(IOrderRepository _orderRepository) : IRequestHandler<GetOrdersByUserIdQuery, PagedResponse<List<OrdersResponse>>>
    {
        public async Task<PagedResponse<List<OrdersResponse>>> Handle(GetOrdersByUserIdQuery request, CancellationToken cancellationToken)
        {
            return await _orderRepository.GetOrdersByUserId(new PagedRequest { PageNumber = request.PageNumber, PageSize = request.PageSize }, request.UserId);
        }
    }
}
