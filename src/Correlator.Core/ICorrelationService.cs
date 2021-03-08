namespace Correlator.Core
{
    public interface ICorrelationService
    {
        /// <summary>
        /// Adds correlation to service or updates it.
        /// </summary>
        /// <param name="key">Key of correlation.</param>
        /// <param name="value">Value of correlation.</param>
        void AddOrUpdate(string key, string value);

        /// <summary>
        /// Checks if correlation exists.
        /// </summary>
        /// <param name="key">Key of correlation to check.</param>
        /// <returns>True when correlation exists.</returns>
        bool Exists(string key);
        
        /// <summary>
        /// Returns correlation value.
        /// </summary>
        /// <param name="key">Key of correlation to get.</param>
        /// <returns>Value of correlation.</returns>
        string Get(string key);
    }
}