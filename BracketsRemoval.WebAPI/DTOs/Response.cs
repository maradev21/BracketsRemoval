namespace BracketsRemoval.WebAPI.DTOs
{
    public class Response
    {
        /// <summary>
        /// Returns the request to which this <see cref="Response"/> instance is replying.
        /// </summary>
        /// <value>
        /// The request.
        /// </value>
        public Request Request { get; }

        /// <summary>
        /// Returns the text that has been fixed, removing extra brackets.
        /// </summary>
        /// <value>
        /// The fixed text.
        /// </value>
        public string CleanText { get; }

        /// <summary>
        /// Returns the error message (e.g. exception).
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        public string ErrorMessage { get; }

        /// <summary>
        /// Returns the timestamp of when the response is generated.
        /// </summary>
        /// <value>
        /// The timestamp.
        /// </value>
        public DateTimeOffset Timestamp => DateTimeOffset.Now;

        /// <summary>
        /// Initializes a new instance of the <see cref="Response"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cleanText">The clean text, without extra brackets.</param>
        public Response(Request request, string cleanText)
        {
            Request = request;
            CleanText = cleanText;
            ErrorMessage = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Response"/> class, to be used when any exception occurs.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="exception">The exception.</param>
        public Response(Request request, Exception exception)
        {
            Request = request;
            CleanText = string.Empty;
            ErrorMessage = exception.Message;
        }
    }
}
