using System;
using Xunit;

namespace WordWrap.Tests
{
    public class WordWrapTests
    {
        [Theory]
        [InlineData("This is a test", 7)]
        [InlineData("This is a test", 8)]
        public void Wrap_It(string input, int maxLength)
        {
            var actual = WordWrap.Wrap(input, maxLength);
            Assert.Equal("This is\na test", actual);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Wrap_EmptyOrNull_String(string value)
        {
            var actual = WordWrap.Wrap(value, 1);
            Assert.Equal(value, actual);
        }

        [Fact]
        public void Wrap_It_LargeString()
        {
            var expected = "Fernando\nBotelho de\nAlmeida &\nMarilia\nMesquita\nBotelho";
            var actual = WordWrap.Wrap("Fernando Botelho de Almeida & Marilia Mesquita Botelho", 10);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Wrap_Under_Limit()
        {
            var expected = "Matt and Louise";
            var actual = WordWrap.Wrap(expected, 15);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Wrap_At_5()
        {
            var expected = "01234\n56789";
            var actual = WordWrap.Wrap("01234 56789", 5);
            Assert.Equal(expected, actual);
        }
    }
}