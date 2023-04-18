using Mapster;
using System.Net;

namespace InSharpAssessment.Common.Exceptions
{
    public class ApiException : Exception
    {
        public HttpStatusCode HttpStatusCode { get; }
        public string? message { get; } = null;

        /// <summary>
        /// Api Exceptions Base
        /// </summary>
        /// <param name="httpStatusCode"></param>
        /// <param name="_message"></param>
        public ApiException(HttpStatusCode httpStatusCode,
            string _message) :
            base(_message)
        {
            HttpStatusCode = httpStatusCode;
            message = _message;
        }

        public AppExceptionResult AppExceptionResult
        {
            get
            {
                var msgList = new List<string>
                {
                    Message
                };
                var innerEx = InnerException;
                while (innerEx != null)
                {
                    msgList.Add(innerEx.Message);
                    innerEx = innerEx.InnerException;
                }

                var result = this.Adapt<AppExceptionResult>();
                result.DebugMessages = msgList;
                result.DebugStackTrace = StackTrace;

                return result;
            }
        }
    }
}
