using StringCalculator;
using System;
using Xunit;

namespace StringCalculatoirTests
{
    public class StringCalculatorTests
    {
        [Fact]
        public void EmptyStringReturnsZero()
        {
            int res = StringCalculator.StringCalculator.CalculateString("");
            Assert.Equal(0, res);
        }

        [Theory]
        [InlineData("25", 25)]
        [InlineData("0", 0)]
        [InlineData("5", 5)]
        public void SingleNumberReturnsTheValue(string s, int expected)
        {
            int res = StringCalculator.StringCalculator.CalculateString(s);
            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData("25,15", 40)]
        [InlineData("0,10", 10)]
        [InlineData("5,3", 8)]
        public void TwoNumbersCommaDelimetedReturnsTheSum(string s, int expected)
        {
            int res = StringCalculator.StringCalculator.CalculateString(s);
            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData("29\n11", 40)]
        [InlineData("0\n10", 10)]
        [InlineData("6\n3", 9)]
        public void TwoNumbersNewLineDelimetedReturnsTheSum(string s, int x)
        {
            int res = StringCalculator.StringCalculator.CalculateString(s);
            Assert.Equal(x, res);
        }

        [Theory]
        [InlineData("29\n11,12", 52)]
        [InlineData("0\n10\n5", 15)]
        [InlineData("10,5\n3", 18)]
        [InlineData("10,5,13", 28)]
        public void ThreeNumbersDelimetedEitherWayReturnsTheSum(string s, int x)
        {
            int res = StringCalculator.StringCalculator.CalculateString(s);
            Assert.Equal(x, res);
        }

        [Theory]
        [InlineData("-5")]
        [InlineData("-7,12")]
        [InlineData("12\n-7")]
        public void NegativeNumbersThrowAnException(string s)
        {
            _ = Assert.Throws<ArgumentException>(
                () => StringCalculator.StringCalculator.CalculateString(s)
            );
        }

        [Theory]
        [InlineData("29\n11,1111", 40)]
        [InlineData("0\n10\n65536", 10)]
        [InlineData("1000", 1000)]
        [InlineData("1001", 0)]
        public void NumbersGreaterThan1000AreIgnored(string s, int x)
        {
            int res = StringCalculator.StringCalculator.CalculateString(s);
            Assert.Equal(x, res);
        }

        [Theory]
        [InlineData("//#\n29#11", 40)]
        [InlineData("//$\n29$11", 40)]
        [InlineData("//$\n29$11,10\n10", 60)]
        public void SingleCharDelimeter(string s, int x)
        {
            int res = StringCalculator.StringCalculator.CalculateString(s);
            Assert.Equal(x, res);
        }

        [Theory]
        [InlineData("//[###]\n29###11", 40)]
        [InlineData("//[$$$]\n29$$$11", 40)]
        [InlineData("//[$:]\n29$:11,10\n10", 60)]
        public void MultiCharDelimeter(string s, int x)
        {
            int res = StringCalculator.StringCalculator.CalculateString(s);
            Assert.Equal(x, res);
        }
    }
}
