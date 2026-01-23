using System;
using System.Net;

namespace Krzaq.Exceptions.Http.Base
{
    public abstract class HttpException : Exception
    {
        public abstract HttpStatusCode StatusCode { get; }

        public HttpException() { }

        public HttpException(string errorMessage, Exception? innerException = null)
            : base(errorMessage, innerException) { }
    }
}
