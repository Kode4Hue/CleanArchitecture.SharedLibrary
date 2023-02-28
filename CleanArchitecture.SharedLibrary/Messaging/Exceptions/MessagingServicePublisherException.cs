using System;

namespace CleanArchitecture.SharedLibrary.Messaging.Exceptions
{
    [Serializable]
    public class MessagingServicePublisherException: Exception
    {
        public MessagingServicePublisherException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected MessagingServicePublisherException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext)
            :base(serializationInfo, streamingContext) { }
    }
}
