using Krzaq.Errors.Model;
using Krzaq.Exceptions.Http.Error.Base;
using System;
using System.Collections.Generic;
using System.Net;

namespace Krzaq.Exceptions.Http.Error
{
    public class UnauthorizedException<T> : HttpErrorException<T> where T : IError
    {
        public override HttpStatusCode StatusCode => HttpStatusCode.Unauthorized;

        public UnauthorizedException(Exception? innerException = null)
            : base(innerException) { }

        public UnauthorizedException(T error, Exception? innerException = null)
            : base(error, innerException) { }

        public UnauthorizedException(IEnumerable<T> errors, Exception? innerException = null, string message = "")
            : base(errors, innerException, message) { }
    }
}
