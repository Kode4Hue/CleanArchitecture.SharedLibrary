using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.SharedLibrary.Account.Services.MessageBroker
{
    public interface IMessagingService<T> where T : class
    {
        Task PublishMessage(string topic, T messageContent, CancellationToken cancellationToken);
    }
}