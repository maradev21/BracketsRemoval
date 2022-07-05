using Xunit;
using FluentAssertions;
using BracketsRemoval;
using System;

namespace Tests
{
    public class BracketsServiceTests
    {
        [Theory]
        [InlineData("(abc)", "abc")]
        [InlineData("((abc))", "abc")]
        [InlineData("()", "")]
        [InlineData("(ab) (cd)", "(ab) (cd)")]
        [InlineData("((ab) (cd))", "(ab) (cd)")]
        [InlineData("ab(cd)", "ab(cd)")]
        [InlineData("((ab)(c(d)))", "(ab)(c(d))")]
        [InlineData("(((((ab)(c(d))))))", "(ab)(c(d))")]
        [InlineData("(((a)b)c)", "((a)b)c")]
        [InlineData("(a(b(c)))", "a(b(c))")]
        public void Should_ReturnCorrectResult(string input, string expected)
        {
            string result = BracketsService.RemoveExternalBrackets(input);
            result.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData("(abc")]
        [InlineData("((abc)")]
        [InlineData("a)(b")]
        [InlineData("a(b)c)")]
        [InlineData("(((a(b(c))(d))")]
        public void Should_ThrowPathologicalBracketsException_WhenTextIsNotValid(string pathologicalText)
        {
            Action action = () => BracketsService.RemoveExternalBrackets(pathologicalText);
            action.Should().Throw<PathologicalBracketsException>();
        }
    }
}