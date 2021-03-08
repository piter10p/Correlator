using System;
using System.Collections.Concurrent;
using Correlator.Core.Exceptions;

namespace Correlator.Core
{
    public class CorrelationService : ICorrelationService
    {
        private readonly ConcurrentDictionary<string, string> _correlations = new ConcurrentDictionary<string, string>();

        public void AddOrUpdate(string key, string value)
        {
            if (key is null) throw new ArgumentNullException(nameof(key));
            if (value is null) throw new ArgumentNullException(nameof(value));

            _correlations.GetOrAdd(key, value);
        }

        public bool Exists(string key)
        {
            if (key is null) throw new ArgumentNullException(nameof(key));

            return _correlations.ContainsKey(key);
        }

        public string Get(string key)
        {
            if (key is null) throw new ArgumentNullException(nameof(key));

            if (!Exists(key))
                throw new CorrelationNotExistsException(key);

            return _correlations[key];
        }
    }
}