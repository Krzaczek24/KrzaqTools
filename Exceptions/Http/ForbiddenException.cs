using Krzaq.Exceptions.Http.Base;
using System;
using System.Net;

namespace Krzaq.Exceptions.Http
{
    public class ForbiddenException : HttpException
    {
        public override HttpStatusCode StatusCode => HttpStatusCode.Forbidden;

        public ForbiddenException() { }

        public ForbiddenException(string errorMessage, Exception? innerException = null)
            : base(errorMessage, innerException) { }
    }
}
