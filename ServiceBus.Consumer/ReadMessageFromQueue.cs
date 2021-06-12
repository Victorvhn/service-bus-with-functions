using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace ServiceBus.Consumer
{
    public static class ReadMessageFromQueue
    {
        [FunctionName("ReadMessageFromQueue")]
        public static void Run([
            ServiceBusTrigger("messagecreated", Connection = "ServiceBusConnection")
        ] string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }
    }
}
