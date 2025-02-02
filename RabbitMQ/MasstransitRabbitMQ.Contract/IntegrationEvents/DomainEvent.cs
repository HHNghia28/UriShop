using MasstransitRabbitMQ.Contract.Astractions.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasstransitRabbitMQ.Contract.IntegrationEvents
{
    public static class DomainEvent
    {
        public record EmailNotificationEvent : INotificationEvent
        {
            public Guid Id { get; set; }
            public DateTimeOffset TimeStamp { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string Type { get; set; }
            public Guid TransactionId { get; set; }
        }
        public record SmsNotificationEvent : INotificationEvent
        {
            public Guid Id { get; set; }
            public DateTimeOffset TimeStamp { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string Type { get; set; }
            public Guid TransactionId { get; set; }
        }
    }
}
