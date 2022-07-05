namespace BracketsRemoval
{
    public class PathologicalBracketsException : Exception
    {
        public PathologicalBracketsException(string message) : base(GenerateExceptionMessage(message)) { }

        private static string GenerateExceptionMessage(string message) => $"The passed text is pathological: {message}.";
    }
}
