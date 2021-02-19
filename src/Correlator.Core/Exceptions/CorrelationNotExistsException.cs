namespace Correlator.Core.Exceptions
{
    public class CorrelationNotExistsException : CorrelationException
    {
        public CorrelationNotExistsException(string key)
            : base($"Correlation not exists. Key: '{key}'.")
        {
        }
    }
}