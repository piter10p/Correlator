using System;
using System.Runtime.Serialization;

namespace Correlator.Core
{
    public abstract class CorrelationException : Exception
    {
        protected CorrelationException()
        {
        }

        protected CorrelationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        protected CorrelationException(string? message) : base(message)
        {
        }

        protected CorrelationException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}