using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.SharedLibrary.Messaging.Services
{
    public interface IMessagingService<T> where T : class
    {
        Task PublishMessage(string messageKey, T messageContent, CancellationToken cancellationToken);
    }
}