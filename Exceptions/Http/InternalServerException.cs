using System;
using System.Net;

namespace KrzaqTools.Exceptions.Http
{
    public class InternalServerException : HttpException
    {
        public override HttpStatusCode StatusCode => HttpStatusCode.InternalServerError;

        public InternalServerException() { }

        public InternalServerException(string errorMessage, Exception? innerException = null)
            : base(errorMessage, innerException) { }
    }
}
