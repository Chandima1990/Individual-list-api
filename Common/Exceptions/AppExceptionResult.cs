using System.Net;

namespace InSharpAssessment.Common.Exceptions
{
    public class AppExceptionResult
    {
        public HttpStatusCode HttpStatusCode { get; set; }

        public string? HttpErrorCode { get; set; }

        public int? ApiErrorCode { get; set; }

        public string? Message { get; set; }

        public string? DebugStackTrace { get; set; }

        public List<string>? DebugMessages { get; set; }
    }
}
