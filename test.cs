
using Xunit;
namespace appveyor.test
{
        public class CalculatorTests
        {
            [Theory]
            [InlineData(3,5,8)]
            [InlineData(5,10,20)]
            [InlineData(6,2,8)]
            public void CanAddNumbers(int x, int y, int expected)
            {
                Assert.Equal(expected, Calculator.Add(x, y));
            }
            [Theory]
            [InlineData(1, 1, 0)]
            [InlineData(-1, -1, 0)]
            [InlineData(100, 5, 95)]
            public void CanSubtract(int x, int y, int expected)
            {
                Assert.Equal(expected, Calculator.Subtract(x, y));
            }
            [Theory]
            [InlineData(1, 1, 1)]
            [InlineData(-1, -1, 1)]
            [InlineData(100, 5, 500)]
            public void CanMultiply(int x, int y, int expected)
            {
                Assert.Equal(expected, Calculator.Multiply(x, y));
            }
            [Theory]
            [InlineData(1, 1, 1)]
            [InlineData(-1, -1, 1)]
            [InlineData(100, 5, 20)]
            public void CanDivide(int x, int y, int expected)
            {
                Assert.Equal(expected, Calculator.Divide(x, y));
            }
        }

}
