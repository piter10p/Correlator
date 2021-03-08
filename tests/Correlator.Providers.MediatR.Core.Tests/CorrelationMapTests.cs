using Correlator.Providers.MediatR.Core.Exceptions;
using FluentAssertions;
using Xunit;

namespace Correlator.Providers.MediatR.Core.Tests
{
    public class CorrelationMapTests
    {
        [Fact]
        public void MapProperty_Property_ShouldSucceed()
        {
            var sut = new TestCorrelationMap();
            sut.UseProperty(x => x.Property);
            
            sut.MappedProperties.Should().NotBeEmpty();
            sut.MappedProperties.Should().ContainKey(TestMessage.PropertyName);
            sut.MappedProperties[TestMessage.PropertyName].Should().BeSameAs(TestMessage.PropertyInfo);
        }
        
        [Fact]
        public void MapProperty_Field_ShouldThrowException()
        {
            var sut = new TestCorrelationMap();
            Assert.Throws<CorrelationMapInvalidException>(() => sut.UseProperty(x => x.Field));
        }
        
        [Fact]
        public void MapProperty_Method_ShouldThrowException()
        {
            var sut = new TestCorrelationMap();
            Assert.Throws<CorrelationMapInvalidException>(() => sut.UseProperty(x => x.Method()));
        }
        
        [Fact]
        public void MapField_Field_ShouldSucceed()
        {
            var sut = new TestCorrelationMap();
            sut.UseField(x => x.Field);
            
            sut.MappedFields.Should().NotBeEmpty();
            sut.MappedFields.Should().ContainKey(TestMessage.FieldName);
            sut.MappedFields[TestMessage.FieldName].Should().BeSameAs(TestMessage.FieldInfo);
        }
        
        [Fact]
        public void MapField_Property_ShouldThrowException()
        {
            var sut = new TestCorrelationMap();
            Assert.Throws<CorrelationMapInvalidException>(() => sut.UseField(x => x.Property));
        }
        
        [Fact]
        public void MapField_Method_ShouldThrowException()
        {
            var sut = new TestCorrelationMap();
            Assert.Throws<CorrelationMapInvalidException>(() => sut.UseField(x => x.Method()));
        }
    }
}