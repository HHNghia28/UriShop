using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Infrastructure.RabbitMQ.Events
{
    public class OrderCreatedEvent
    {
        public long Id { get; set; }
        public List<Product> Products { get; set; }
    }

    public class Product
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
    }
}
