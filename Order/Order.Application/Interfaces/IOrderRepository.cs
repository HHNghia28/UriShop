using Order.Application.DTO;
using Order.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Interfaces
{
    public interface IOrderRepository : IRepository<Domain.Entities.Order>
    {
        Task<PagedResponse<List<OrdersResponse>>> GetOrders(PagedRequest request);
        Task<PagedResponse<List<OrdersResponse>>> GetOrdersByUserId(PagedRequest request, Guid userId);
        Task<OrderResponse> GetOrder(Guid id);
    }
}
