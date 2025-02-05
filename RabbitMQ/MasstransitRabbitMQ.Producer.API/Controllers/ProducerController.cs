using MassTransit;
using MasstransitRabbitMQ.Contract.IntegrationEvents;
using Microsoft.AspNetCore.Mvc;
using static MasstransitRabbitMQ.Contract.IntegrationEvents.DomainEvent;

namespace MasstransitRabbitMQ.Producer.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProducerController(IPublishEndpoint endpoint) : ControllerBase
    {
        private readonly IPublishEndpoint _endpoint = endpoint;

        [HttpPost(Name = "publish-sms-motification")]
        public async Task<IActionResult> PublishNotification()
        {
            await _endpoint.Publish(new DomainEvent.SmsNotificationEvent
            {
                Id = Guid.NewGuid(),
                Description = "Sms description",
                Name = "Sms notification",
                TimeStamp = DateTime.UtcNow,
                TransactionId = Guid.NewGuid(),
                Type = "sms"
            });

            return Accepted();
        }
    }
}
