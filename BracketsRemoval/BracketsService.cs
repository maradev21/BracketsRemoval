namespace BracketsRemoval
{
    public static class BracketsService
    {
        public static string RemoveExtraBrackets(string input)
        {
            List<OpenBracket> brackets = new List<OpenBracket>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                    brackets.Add(new OpenBracket(i, i > 0 ? input[i - 1] : null));
                else if (input[i] == ')')
                {
                    if (brackets.Where(b => b.IsClosed == false).Any())
                    {
                        var lastOpenedBracket = brackets.Last(b => b.IsClosed == false);
                        lastOpenedBracket.SetCorrespondingClosingBracket(i);

                        if (i < input.Length - 2)
                            lastOpenedBracket.SetNextChar(input[i + 1]);
                    }
                    else
                        throw new InvalidOperationException($"There is no open bracket to be closed at index {i}");
                }
                else if (input[i] != ' ')
                    brackets.Last(b => !b.IsClosed).AddText(input[i]);
            }

            if (brackets.Where(b => !b.IsClosed).Any())
                throw new InvalidOperationException("Not all open brackets are closed. String is invalid.");

            if (brackets.Where(b => b.IsUseless).Any())
            {
                var trimIndex = brackets.Last(b => b.IsUseless).Index + 1;
                string result = input[trimIndex..(input.Length - trimIndex)];
                return result;
            }
            else
                return input;
        }

        /// <summary>
        /// Removes the useless external brackets from the passed string.
        /// </summary>
        /// <param name="dirtyText">The input string, to be cleaned.</param>
        /// <returns></returns>
        public static string RemoveExternalBrackets(string dirtyText)
        {
            string cleanText = dirtyText;

            while (!string.IsNullOrEmpty(cleanText)
                && cleanText[0] == '('                  // the first character is an open bracket
                && cleanText[^1] == ')')                // the last character is a closed bracket
            {
                int index = FindClosingBracket(cleanText);

                if (index == cleanText.Length - 1)      // the corresponding bracket is the last one
                    cleanText = cleanText[1..^1];       // first and last characters are removed
                else
                    break;
            }

            return cleanText;
        }

        /// <summary>
        /// Finds the closing bracket corresponding to the first open one.
        /// </summary>
        /// <param name="text">The input string, containing brackets.</param>
        /// <returns></returns>
        /// <exception cref="System.InvalidOperationException">There is no closing bracket associated to the first open bracket: the string is pathological.</exception>
        private static int FindClosingBracket(string text)
        {
            int bracketCounter = 1;

            for (int i = 1; i < text.Length; i++)
            {
                if (text[i] == '(')
                    bracketCounter++;
                else if (text[i] == ')')
                {
                    bracketCounter--;
                    if (bracketCounter == 0)
                        return i;
                }
            }

            throw new InvalidOperationException("There is no closing bracket associated to the first open bracket: the string is pathological.");
        }
    }
}