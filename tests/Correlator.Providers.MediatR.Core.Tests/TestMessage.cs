using System.Reflection;
using System.Runtime.CompilerServices;
using FluentAssertions.Common;

namespace Correlator.Providers.MediatR.Core.Tests
{
    public class TestMessage
    {
        public string Property { get; } = PropertyValue;
        public string Field = FieldValue;
        public string Method() => MethodValue;

        public const string PropertyName = nameof(Property);
        public const string FieldName = nameof(Field);
        public const string MethodName = nameof(Method);

        public const string PropertyValue = "PROPERTY_VALUE";
        public const string FieldValue = "FIELD_VALUE";
        public const string MethodValue = "METHOD_VALUE";

        public static PropertyInfo PropertyInfo { get; } = typeof(TestMessage).GetPropertyByName(PropertyName);
        public static FieldInfo FieldInfo { get; } = typeof(TestMessage).GetField(FieldName);
    }

    public class TestCorrelationMap : CorrelationMap<TestMessage>
    {
        
    }
}