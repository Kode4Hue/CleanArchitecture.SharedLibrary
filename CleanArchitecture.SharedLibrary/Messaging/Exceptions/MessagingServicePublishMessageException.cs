using System;

namespace CleanArchitecture.SharedLibrary.Messaging.Exceptions
{
    [Serializable]
    public class MessagingServicePublishMessageException: Exception
    {
        public MessagingServicePublishMessageException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected MessagingServicePublishMessageException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext)
            :base(serializationInfo, streamingContext) { }
    }
}
