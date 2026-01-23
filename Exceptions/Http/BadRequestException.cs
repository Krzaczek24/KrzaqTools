using System;
using System.Net;

namespace KrzaqTools.Exceptions.Http
{
    public class BadRequestException : HttpException
    {
        public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

        public BadRequestException() { }

        public BadRequestException(string errorMessage, Exception? innerException = null)
            : base(errorMessage, innerException) { }
    }
}
