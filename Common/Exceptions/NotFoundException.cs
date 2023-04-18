using System.Net;

namespace InSharpAssessment.Common.Exceptions
{
    public class NotFoundException : ApiException
    {
        public NotFoundException(HttpStatusCode httpStatusCode,
            string message) :
            base(httpStatusCode, message)
        {

        }
    }
}
