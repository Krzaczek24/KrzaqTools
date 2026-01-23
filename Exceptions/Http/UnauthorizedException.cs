using System;
using System.Net;

namespace KrzaqTools.Exceptions.Http
{
    public class UnauthorizedException : HttpException
    {
        internal override HttpStatusCode StatusCode => HttpStatusCode.Unauthorized;

        public UnauthorizedException() { }

        public UnauthorizedException(string errorMessage, Exception? innerException = null)
            : base(errorMessage, innerException) { }
    }
}
