using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using Correlator.Providers.MediatR.Core.Exceptions;

namespace Correlator.Providers.MediatR.Core
{
    /// <summary>
    /// Implementation of correlation map to use along with MediatR Requests and Notifications.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class CorrelationMap<T> : ICorrelationMap<T>
    {
        public IDictionary<string, PropertyInfo> MappedProperties { get; } = new Dictionary<string, PropertyInfo>();
        public IDictionary<string, FieldInfo> MappedFields { get; } = new Dictionary<string, FieldInfo>();

        /// <summary>
        /// Adds property to correlation map.
        /// </summary>
        public void UseProperty<TProperty>(Expression<Func<T, TProperty>> propertyExpression)
        {
            var type = typeof(T);

            if (!(propertyExpression.Body is MemberExpression member))
                throw new CorrelationMapInvalidException($"Expression '{propertyExpression}' refers to a method, not a property.");

            var propInfo = member.Member as PropertyInfo;
            if (propInfo == null)
                throw new CorrelationMapInvalidException($"Expression '{propertyExpression}' refers to a field, not a property.");

            if (type != propInfo.ReflectedType && !type.IsSubclassOf(propInfo.ReflectedType!))
                throw new CorrelationMapInvalidException($"Expression '{propertyExpression}' refers to a property that is not from type {type}.");

            if (MappedProperties.ContainsKey(propInfo.Name))
                throw new CorrelationMapInvalidException($"Expression '{propertyExpression}' refers to already mapped property.");
            
            MappedProperties.Add(propInfo.Name, propInfo);
        }
        
        /// <summary>
        /// Adds field to correlation map.
        /// </summary>
        public void UseField<TField>(Expression<Func<T, TField>> fieldExpression)
        {
            var type = typeof(T);

            if (!(fieldExpression.Body is MemberExpression member))
                throw new CorrelationMapInvalidException($"Expression '{fieldExpression}' refers to a method, not a field.");

            var fieldInfo = member.Member as FieldInfo;
            if (fieldInfo == null)
                throw new CorrelationMapInvalidException($"Expression '{fieldExpression}' refers to a property, not a field.");

            if (type != fieldInfo.ReflectedType && !type.IsSubclassOf(fieldInfo.ReflectedType!))
                throw new CorrelationMapInvalidException($"Expression '{fieldExpression}' refers to a field that is not from type {type}.");

            if (MappedProperties.ContainsKey(fieldInfo.Name))
                throw new CorrelationMapInvalidException($"Expression '{fieldExpression}' refers to already mapped field.");
            
            MappedFields.Add(fieldInfo.Name, fieldInfo);
        }
    }
}