using Xunit;
using FluentAssertions;
using BracketsRemoval;

namespace Tests     // just a comment
{
    public class BracketsServiceTests
    {
        [Theory]
        [InlineData("(abc)", "abc")]
        [InlineData("((abc))", "abc")]
        [InlineData("(abc", "(abc")]
        [InlineData("()", "")]
        [InlineData("(ab) (cd)", "(ab) (cd)")]
        [InlineData("((ab) (cd))", "(ab) (cd)")]
        [InlineData("ab(cd)", "ab(cd)")]
        [InlineData("((ab)(c(d)))", "(ab)(c(d))")]
        [InlineData("(((((ab)(c(d))))))", "(ab)(c(d))")]
        [InlineData("(((a)b)c)", "((a)b)c")]
        [InlineData("(a(b(c)))", "a(b(c))")]
        //[InlineData("((abc)", "(abc")]
        //[InlineData("(((a(b(c))(d))", "a(b(c))(d)")]
        public void Should_ReturnCorrectResult(string input, string expected)
        {
            string result = BracketsService.RemoveExternalBrackets(input);
            result.Should().BeEquivalentTo(expected);
        }

        private void CountBrackets(string input)        // works
        {
            System.Diagnostics.Debug.WriteLine(input);
            int counter = 0;

            for (int i = 0; i < input.Length; i++)
            {
                int x;

                if (input[i] == '(')
                {
                    counter++;
                    x = counter;
                }
                else if (input[i] == ')')
                {
                    x = counter;
                    counter--;
                }
                else
                    x = 0;

                System.Diagnostics.Debug.WriteLine($"{input[i]}:\t{x}");
            }
        }

        #region 3

        private string R3(string input)
        {
            int counter = 0;
            bool opening = true;
            bool closing = false;

            for (int i = 0; i < input.Length; i++)
            {
                if (opening && input[i] == '(')
                    counter++;
                if (opening && input[i] != '(')
                    opening = false;

                if (input[i] == ')')
                {
                    closing = true;
                }

                if (input[i] != ')' && closing)
                {
                    closing = false;
                    counter--;
                }    
            }

            string result = input[counter..(input.Length - counter)];
            return result;
        }

        #endregion

        #region 2

        private string RemoveExternal(string input)
        {
            int removalIndex = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                    removalIndex++;
                else if (input[i] == ')')
                {
                    removalIndex--;
                    break;
                }
            }

            string result = input[removalIndex..(input.Length - removalIndex)];
            return result;
        }

        #endregion

        #region 1

        private string RemoveExternalBrackets(string input)
        {
            int i = 0;

            for (; i < input.Length / 2; i++)
            {
                if (!IsMatching(input, i))
                    break;
            }

            string result = input[i..(input.Length - i)];
            return result;
        }

        private bool IsMatching(string input, int index)
        {
            int matchingIndex = input.Length - index - 1;
            return input[index] == '('
                && input[matchingIndex] == ')'
                && input[(index + 1)..(matchingIndex - 1)].Contains(')');
        }

        #endregion
    }
}