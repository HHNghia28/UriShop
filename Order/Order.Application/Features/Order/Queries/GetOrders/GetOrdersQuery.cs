using MediatR;
using Order.Application.DTO;
using Order.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Features.Order.Queries.GetOrders
{
    public class GetOrdersQuery : IRequest<PagedResponse<List<OrdersResponse>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
