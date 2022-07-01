namespace BracketsRemoval.WebAPI.DTOs
{
    public class Request
    {
        /// <summary>
        /// Gets or sets the original text containing extra brackets.
        /// </summary>
        /// <value>
        /// The original text.
        /// </value>
        public string DirtyText { get; set; }

        /// <summary>
        /// Gets or sets the timestamp of when the request is done.
        /// </summary>
        /// <value>
        /// The timestamp.
        /// </value>
        public DateTimeOffset Timestamp { get; set; }
    }
}
