namespace BracketsRemoval.WebAPI.DTOs
{
    public class Response
    {
        public Request Request { get; set; }

        public string FixedText { get; set; }

        public int Status { get; set; }

        public string ErrorMessage  { get; set; }

        public DateTimeOffset Timestamp => DateTimeOffset.Now;
    }
}
