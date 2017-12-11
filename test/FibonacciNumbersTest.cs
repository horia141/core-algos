using FluentAssertions;
using System;
using Xunit;

using CoreAlgos;

namespace CoreAlgos.Test
{
    public class FibonacciNumbersTest
    {
        #region Naive

        [Fact]
        public void NaiveThrowsForNegativeValues()
        {
            Action action1 = () => FibonacciNumbers.Naive(-1);
            action1.ShouldThrow<ArgumentException>();
            Action action2 = () => FibonacciNumbers.Naive(-10);
            action2.ShouldThrow<ArgumentException>();

        }

        [Fact]
        public void NaiveBaseCases()
        {
            FibonacciNumbers.Naive(0).Should().Be(0);
            FibonacciNumbers.Naive(1).Should().Be(1);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(3, 2)]
        [InlineData(4, 3)]
        [InlineData(5, 5)]
        [InlineData(6, 8)]
        [InlineData(7, 13)]
        [InlineData(8, 21)]
        [InlineData(9, 34)]
        [InlineData(10, 55)]
        [InlineData(11, 89)]
        [InlineData(12, 144)]
        [InlineData(13, 233)]
        [InlineData(14, 377)]
        [InlineData(15, 610)]
        public void NaiveWorks(long n, long fibn)
        {
            FibonacciNumbers.Naive(n).Should().Be(fibn);
        }

        #endregion
    }
}
