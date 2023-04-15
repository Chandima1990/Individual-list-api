using System.Net;

namespace InSharpAssessment.Common.Exceptions
{
    public class ServerErrorException : ApiException
    {
        public ServerErrorException(Exception ex) :
            base(HttpStatusCode.InternalServerError, ex.Message)
        {

        }
    }
}
