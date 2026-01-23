using Krzaq.Exceptions.Http.Base;
using System;
using System.Net;

namespace Krzaq.Exceptions.Http
{
    public class NotFoundException : HttpException
    {
        public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;

        public NotFoundException() { }

        public NotFoundException(string errorMessage, Exception? innerException = null)
            : base(errorMessage, innerException) { }
    }
}
