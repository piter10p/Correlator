using System.Collections.Generic;
using System.Reflection;

namespace Correlator.Providers.MediatR.Core
{
    /// <summary>
    /// Interface providing information about Request fields and properties to use in <see cref="CorrelationBehaviour{TRequest,TResponse}"/> 
    /// </summary>
    /// <typeparam name="T">MediatR Request</typeparam>
    public interface ICorrelationMap<T>
    {
        /// <summary>
        /// List of properties to use.
        /// </summary>
        public IDictionary<string, PropertyInfo> MappedProperties { get; }
        
        /// <summary>
        /// List of fields to use.
        /// </summary>
        public IDictionary<string, FieldInfo> MappedFields { get; }
    }
}