using System;
using System.Collections.Concurrent;

namespace Correlator.Core
{
    public class CorrelationService : ICorrelationService
    {
        private readonly ConcurrentDictionary<string, string> _correlations = new ConcurrentDictionary<string, string>();

        public void AddOrUpdate(string key, string value)
        {
            throw new NotImplementedException();
        }

        public bool Exists(string key)
        {
            throw new System.NotImplementedException();
        }

        public string Get(string key)
        {
            throw new System.NotImplementedException();
        }
    }
}