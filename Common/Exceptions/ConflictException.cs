using System.Net;

namespace InSharpAssessment.Common.Exceptions
{
    public class ConflictException : ApiException
    {
        public ConflictException(HttpStatusCode httpStatusCode,
            string message) :
            base(httpStatusCode, message)
        {

        }
    }
}
