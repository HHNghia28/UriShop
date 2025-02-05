using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Payment.Application.DTO;
using Payment.Application.Wrappers;

namespace Payment.Application.Features.Payment.Commands.CreatePaymentOrder
{
    public class CreateOrderPaymentByPayOSCommand : IRequest<string>
    {
        public long OrderId { get; set; }
        [JsonIgnore]
        public Guid CreatedById { get; set; }
        public int RequiredAmount { get; set; }
    }
}
