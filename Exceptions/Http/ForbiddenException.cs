using System;
using System.Net;

namespace KrzaqTools.Exceptions.Http
{
    public class ForbiddenException : HttpException
    {
        internal override HttpStatusCode StatusCode => HttpStatusCode.Forbidden;

        public ForbiddenException() { }

        public ForbiddenException(string errorMessage, Exception? innerException = null)
            : base(errorMessage, innerException) { }
    }
}
