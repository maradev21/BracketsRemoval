namespace BracketsRemoval.WebAPI.DTOs
{
    public class Request
    {
        public string OriginalText { get; set; }

        public DateTimeOffset Timestamp { get; set; }
    }
}
