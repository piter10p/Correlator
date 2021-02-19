namespace Correlator.Core
{
    public interface ICorrelationService
    {
        /// <summary>
        /// Adds correlation to service.
        /// </summary>
        /// <param name="key">Key of correlation.</param>
        /// <param name="value">Value of correlation.</param>
        void AddCorrelation(string key, string value);
        
        /// <summary>
        /// Updates existing correlation.
        /// </summary>
        /// <param name="key">Key of correlation.</param>
        /// <param name="value">Value of correlation.</param>
        void UpdateCorrelation(string key, string value);
        
        /// <summary>
        /// Checks if correlation exists.
        /// </summary>
        /// <param name="key">Key of correlation to check.</param>
        /// <returns>True when correlation exists.</returns>
        bool CorrelationExists(string key);
        
        /// <summary>
        /// Returns correlation value.
        /// </summary>
        /// <param name="key">Key of correlation to get.</param>
        /// <returns>Value of correlation.</returns>
        string GetCorrelation(string key);
    }
}