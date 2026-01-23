using System;
using System.Net;

namespace KrzaqTools.Exceptions.Http
{
    public class NotFoundException : HttpException
    {
        public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;

        public NotFoundException() { }

        public NotFoundException(string errorMessage, Exception? innerException = null)
            : base(errorMessage, innerException) { }
    }
}
