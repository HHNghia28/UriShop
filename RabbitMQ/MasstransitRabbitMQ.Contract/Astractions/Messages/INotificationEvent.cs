using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasstransitRabbitMQ.Contract.Astractions.Messages
{
    public interface INotificationEvent : IMessage
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public Guid TransactionId { get; set; }
    }
}
