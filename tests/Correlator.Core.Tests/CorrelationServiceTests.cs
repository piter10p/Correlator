using System;
using System.Collections.Generic;
using System.Threading;
using Correlator.Core.Exceptions;
using FluentAssertions;
using Xunit;

namespace Correlator.Core.Tests
{
    public class CorrelationServiceTests
    {
        [Fact]
        public void Exists_NotExists_ShouldReturnFalse()
        {
            const string key = "TEST_KEY";
            
            var sut = new CorrelationService();
            sut.Exists(key).Should().BeFalse();
        }

        [Fact]
        public void Get_NotExists_ShouldThrowNotExistsException()
        {
            const string key = "TEST_KEY";
            
            var sut = new CorrelationService();
            Assert.Throws<CorrelationNotExistsException>(() => sut.Get(key));
        }
        
        [Fact]
        public void Parallel_ShouldSucceed()
        {
            var sut = new CorrelationService();
            
            RunParallel((threadId, executionId) =>
            {
                var key = GetKey(threadId, executionId);
                var value = GetValue(threadId, executionId);
                sut.AddOrUpdate(key, value);
            });
            
            RunParallel((threadId, executionId) =>
            {
                var expectedKey = GetKey(threadId, executionId);
                var expectedValue = GetValue(threadId, executionId);
                var newValue = GetValue2(threadId, executionId);
                
                sut.Exists(expectedKey).Should().BeTrue();
                sut.Get(expectedKey).Should().BeEquivalentTo(expectedValue);
                sut.AddOrUpdate(expectedKey, newValue);
            });
            
            RunParallel((threadId, executionId) =>
            {
                var expectedKey = GetKey(threadId, executionId);
                var expectedValue = GetValue2(threadId, executionId);

                sut.Exists(expectedKey).Should().BeTrue();
                sut.Get(expectedKey).Should().BeEquivalentTo(expectedValue);
            });
        }

        private string GetKey(int threadId, int executionId)
            => $"k{threadId}:{executionId}";
        
        private string GetValue(int threadId, int executionId)
            => $"v{threadId}:{executionId}";
        
        private string GetValue2(int threadId, int executionId)
            => $"2v{threadId}:{executionId}";

            private void RunParallel(Action<int, int> action, int threadsCount = 10, int executionCount = 10)
        {
            var threads = new List<Thread>();

            for (var threadIndex = 0; threadIndex < threadsCount; threadIndex++)
            {
                var thread = new Thread((o =>
                {
                    var threadId = (int)o!;
                    
                    for (var executionIndex = 0; executionIndex < executionCount; executionIndex++)
                    {
                        action(threadId, executionIndex);
                    }
                }));
                
                threads.Add(thread);
            }

            for (var i = 0; i < threadsCount; i++)
            {
                threads[i].Start(i);
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }
        }
    }
}