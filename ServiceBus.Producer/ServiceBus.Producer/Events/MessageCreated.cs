using ServiceBus.Producer.Dtos;
using System;

namespace ServiceBus.Producer.Events
{
    public class MessageCreated
    {
        public MessageCreated(CreateMessageRequest request)
        {
            Id = Guid.NewGuid();
            Content = $"User {request.CreatedBy} create a message at {DateTime.UtcNow:G} with payload: {request.Payload}";
        }

        public Guid Id { get; set; }
        public string Content { get; set; }
    }
}