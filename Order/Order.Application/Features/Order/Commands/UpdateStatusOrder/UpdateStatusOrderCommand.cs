using MediatR;
using Order.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Order.Application.Features.Order.Commands.UpdateStatusOrder
{
    public class UpdateStatusOrderCommand : IRequest
    {
        [JsonIgnore]
        public long Id { get; set; }

        public OrderStatus Status { get; set; }
    }
}
