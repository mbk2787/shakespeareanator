namespace Shakespeareanator.Api.Models
{
    /// <summary>
    /// The error response.
    /// </summary>
    public class ErrorResponse
    {
        public ErrorResponseDetails Error { get; set; }
    }

    public class ErrorResponseDetails
    {
        public string CorrelationId { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }
    }
}