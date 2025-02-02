using MediatR;
using Order.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Features.Order.Queries.GetOrder
{
    public class GetOrderQuery : IRequest<OrderResponse>
    {
        public Guid Id { get; set; }
    }
}
