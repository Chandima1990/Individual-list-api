using System.Net;

namespace InSharpAssessment.Common.Exceptions
{
    public class ApiException : Exception
    {
        public HttpStatusCode HttpStatusCode { get; }

        /// <summary>
        /// Api Exceptions Base
        /// </summary>
        /// <param name="httpStatusCode"></param>
        /// <param name="message"></param>
        public ApiException(HttpStatusCode httpStatusCode,
            string message) :
            base(message)
        {
            HttpStatusCode = httpStatusCode;
        }
    }
}
