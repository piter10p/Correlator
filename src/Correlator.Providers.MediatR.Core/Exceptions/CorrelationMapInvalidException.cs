using Correlator.Core.Exceptions;

namespace Correlator.Providers.MediatR.Core.Exceptions
{
    public class CorrelationMapInvalidException : CorrelationException
    {
        public CorrelationMapInvalidException(string message) : base(message)
        {
        }
    }
}