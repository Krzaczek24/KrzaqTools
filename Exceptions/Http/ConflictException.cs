using System;
using System.Net;

namespace KrzaqTools.Exceptions.Http
{
    public class ConflictException : HttpException
    {
        internal override HttpStatusCode StatusCode => HttpStatusCode.Conflict;

        public ConflictException() { }

        public ConflictException(string errorMessage, Exception? innerException = null)
            : base(errorMessage, innerException) { }
    }
}
