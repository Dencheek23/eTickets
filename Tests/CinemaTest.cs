using System;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class RandomExecutionTimeTest
    {
        private static readonly Random _random = new Random();

        [Fact]
        public async Task TestWithRandomExecutionTime()
        {
            // Generate a random delay time between 1 and 5 seconds
            int delayTime = _random.Next(1000, 5000); // milliseconds
            await Task.Delay(delayTime);

            Assert.True(true, "This test will always pass but with random execution time.");
        }
    }
}