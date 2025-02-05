using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RabbitMQ.Events
{
    public class CreatePaymentEvent
    {
        public long OrderId { get; set; }
        public int RequiredAmount { get; set; }
        public Guid CreatedById { get; set; }
    }
}
