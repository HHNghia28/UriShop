using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Application.Features.Payment.Commands.OrderPaymentByPayOSReturn
{
    public class OrderPaymentByPayOSReturnCommand : IRequest<string>
    {
        public string Code { get; set; }
        public string Id { get; set; }
        public string Cancel { get; set; }
        public string Status { get; set; }
        public string OrderCode { get; set; }
    }
}
