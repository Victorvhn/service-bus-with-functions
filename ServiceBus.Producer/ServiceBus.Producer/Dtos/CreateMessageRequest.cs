namespace ServiceBus.Producer.Dtos
{
    public class CreateMessageRequest
    {
        public string Payload { get; set; }
        public string CreatedBy { get; set; }
    }
}