
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Order.Application.Features.Order.Commands.CancelOrder
{
    public class CancelOrderCommand : IRequest
    {
        [JsonIgnore]
        public long Id { get; set; }
        [JsonIgnore]
        public Guid LastModifiedBy { get; set; }
    }
}
