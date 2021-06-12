using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceBus.Producer.Events;
using ServiceBus.Producer.Interfaces;
using System.Threading.Tasks;
using ServiceBus.Producer.Dtos;

namespace ServiceBus.Producer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessagingController : ControllerBase
    {
        private readonly ILogger<MessagingController> _logger;
        private readonly IMessagePublisher _messagePublisher;

        public MessagingController(
            ILogger<MessagingController> logger,
            IMessagePublisher messagePublisher)
        {
            _logger = logger;
            _messagePublisher = messagePublisher;
        }

        [HttpPost("publish")]
        public async Task<IActionResult> Publish([FromBody] CreateMessageRequest request)
        {
            _logger.LogInformation("Creating a new message.");

            var message = new MessageCreated(request);

            _logger.LogInformation($"Message created. MessageId: {message.Id}");

            _logger.LogInformation("Starting publisher.");

            await _messagePublisher.Publish(message);

            _logger.LogInformation("Message publisher to Azure Service Bus.");

            return Ok();
        }
    }
}
