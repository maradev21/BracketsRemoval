namespace BracketsRemoval
{
    public class PathologicalBracketsException : Exception
    {
        public PathologicalBracketsException(string message) : base(message) { }

        public PathologicalBracketsException() : base(GenerateExceptionMessage()) { }

        private static string GenerateExceptionMessage() => "The passed text is pathological: not all brackets are correctly opened or closed.";
    }
}
