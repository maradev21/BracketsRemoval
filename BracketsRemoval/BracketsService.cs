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

        public static string RemoveExternalBrackets(string input)
        {
            string result = input;

            while (!string.IsNullOrEmpty(result)
                && result[0] == '('
                && result[^1] == ')')
            {
                int index = FindClosingBracket(result);

                if (index == result.Length - 1)
                    result = result[1..^1];
                else
                    break;
            }

            return result;
        }

        private static int FindClosingBracket(string input)
        {
            int counter = 1;

            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] == '(')
                    counter++;
                else if (input[i] == ')')
                {
                    counter--;
                    if (counter == 0)
                        return i;
                }
            }

            throw new InvalidOperationException("There is no closing bracket associated to the first open bracket: the string is pathological.");
        }
    }
}