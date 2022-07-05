using NLog;

namespace BracketsRemoval
{
    public static class BracketsService
    {
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Removes the useless external brackets from the passed string.
        /// </summary>
        /// <param name="dirtyText">The input string, to be cleaned.</param>
        /// <returns></returns>
        public static string RemoveExternalBrackets(string dirtyText)
        {
            ValidateBrackets(dirtyText);
            string cleanText = dirtyText;

            while (!string.IsNullOrEmpty(cleanText)
                && cleanText[0] == '('                  // the first character is an open bracket
                && cleanText[^1] == ')')                // the last character is a closed bracket
            {
                int index = FindClosingBracket(cleanText);  // get the index of the closing bracket corrisponding to the first open one

                if (index == cleanText.Length - 1)      // the corresponding bracket is the last one
                    cleanText = cleanText[1..^1];       // first and last characters are removed
                else
                    break;
            }

            logger.Info("Dirty text [{DirtyText}] is cleaned into [{CleanText}].", dirtyText, cleanText);
            return cleanText;
        }

        /// <summary>
        /// Finds the closing bracket corresponding to the first open one.
        /// </summary>
        /// <param name="text">The input string, containing brackets.</param>
        /// <returns></returns>
        /// <exception cref="BracketsRemoval.PathologicalBracketsException">There is no closing bracket associated to the first open bracket: the string is pathological.</exception>
        private static int FindClosingBracket(string text)
        {
            int bracketsCounter = 1;

            for (int i = 1; i < text.Length; i++)
            {
                if (text[i] == '(')                     // a new bracket is opened
                    bracketsCounter++;
                else if (text[i] == ')')                // a new bracket is closed
                {
                    bracketsCounter--;
                    if (bracketsCounter == 0)           // all the brackets starting from the first one are closed
                        return i;                       // you've found the bracket corresponding to the first one
                }
            }

            logger.Error("Input text [{PathologicalText}] is pathological: no closing bracket is found for the first open one.", text);
            throw new PathologicalBracketsException("There is no closing bracket associated to the first open bracket");
        }

        /// <summary>
        /// Validates the brackets present in the passed text.
        /// </summary>
        /// <param name="text">The text to be validated.</param>
        /// <exception cref="BracketsRemoval.PathologicalBracketsException">The passed text is pathological.</exception>
        private static void ValidateBrackets(string text)
        {
            int bracketsCounter = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '(')
                    bracketsCounter++;
                else if (text[i] == ')')
                    bracketsCounter--;

                if (bracketsCounter < 0)                        // you have at least one more closing bracket
                {
                    logger.Error("Input text [{PathologicalText}] is pathological: closing bracket at position [{ClosingBracketIndex}] does not have a corresponding open one.", text, i);
                    throw new PathologicalBracketsException($"Closing bracket at position [{i}] does not have a corresponding open one");
                }
            }

            if (bracketsCounter != 0)                           // not all brackets are closed
            {
                logger.Error("Input text [{PathologicalText}] is pathological: not all brackets are closed.", text);
                throw new PathologicalBracketsException("Not all brackets are closed");
            }
        }
    }
}