using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketsRemoval
{
    internal class OpenBracket
    {
        public int Index { get; }
        public int? ClosingBracketIndex { get; private set; }
        public bool IsClosed => ClosingBracketIndex != null;
        public string ContainedText { get; private set; }
        public char? PreviousChar { get; private set; }
        public char? NextChar { get; private set; }
        public bool IsUseless => (PreviousChar == null && NextChar == null /*&& !string.IsNullOrEmpty(ContainedText)*/)
                              || ((PreviousChar != null || NextChar != null) && string.IsNullOrEmpty(ContainedText));

        public OpenBracket(int index, char? previousChar)
        {
            Index = index;
            ContainedText = string.Empty;
            PreviousChar = previousChar;
            NextChar = null;
        }

        public void SetCorrespondingClosingBracket(int index)
        {
            if (index <= Index)
                throw new ArgumentException("The corresponding closing bracket must be placed after the open one");

            ClosingBracketIndex = index;
        }

        public void AddText(char letter)
        {
            ContainedText += letter;
        }

        public void SetNextChar(char letter) => NextChar = letter;
    }
}
