using System;
using System.Text;
using System.Text.Json.Serialization;
using ServiceBus.Producer.Interfaces;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace ServiceBus.Producer.Implementations
{
    public class MessagePublisher : IMessagePublisher
    {
        private readonly IConfiguration _configuration;

        public MessagePublisher(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task Publish<T>(T obj)
        {
            await using var client = new ServiceBusClient(_configuration["AzureServiceBus:ConnectionString"]);

            var sender = client.CreateSender(_configuration["AzureServiceBus:QueueName"]);

            var objAsTest = JsonConvert.SerializeObject(obj);
            var message = new ServiceBusMessage(Encoding.UTF8.GetBytes(objAsTest));

            await sender.SendMessageAsync(message);
        }
    }
}