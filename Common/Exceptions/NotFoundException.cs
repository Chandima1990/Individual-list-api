using InSharpAssessment.Common.Exceptions;
using System.Net;

namespace Common.Exceptions
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
