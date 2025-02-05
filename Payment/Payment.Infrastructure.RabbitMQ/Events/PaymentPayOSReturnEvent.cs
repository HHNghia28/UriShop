using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RabbitMQ.Events
{
    public class PaymentPayOSReturnEvent
    {
        public long OrderId { get; set; }
        public bool IsSuccess { get; set; }
    }
}
