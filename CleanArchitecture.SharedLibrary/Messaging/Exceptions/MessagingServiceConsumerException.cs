using System;

namespace CleanArchitecture.SharedLibrary.Messaging.Exceptions
{
    [Serializable]
    public class MessagingServiceConsumerException : Exception
    {
        public MessagingServiceConsumerException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected MessagingServiceConsumerException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {
            throw new NotImplementedException();
        }
    }
}
