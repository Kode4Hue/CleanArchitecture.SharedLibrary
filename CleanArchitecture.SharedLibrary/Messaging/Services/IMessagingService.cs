using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.SharedLibrary.Messaging.Services
{

    /// <summary>
    /// A Contract defining how a message broker should operate
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IMessagingService<T> where T : class
    {

        /// <summary>
        /// Publishes a message using an implementation of IMessagingService
        /// </summary>
        /// <param name="messageKey"></param>
        /// <param name="messageContent"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Returns a string with PublisherMessageStatus (Published/PossiblyPublished/NotPublished</returns>
        Task<string> PublishMessage(string messageKey, T messageContent, CancellationToken cancellationToken);
    }
}