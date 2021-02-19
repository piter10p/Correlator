namespace Correlator.Core.Exceptions
{
    public class CorrelationExistsAlreadyException : CorrelationException
    {
        public CorrelationExistsAlreadyException(string key)
            : base($"Correlation exists already. Key: '{key}'.")
        {
        }
    }
}