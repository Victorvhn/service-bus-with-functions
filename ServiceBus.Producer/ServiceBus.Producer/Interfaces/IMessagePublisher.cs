using System.Threading.Tasks;

namespace ServiceBus.Producer.Interfaces
{
    public interface IMessagePublisher
    {
        Task Publish<T>(T obj);
    }
}