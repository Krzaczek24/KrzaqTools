using Krzaq.Errors.Model;
using Krzaq.Exceptions.Http.Error.Base;
using System;
using System.Collections.Generic;
using System.Net;

namespace Krzaq.Exceptions.Http.Error
{
    public class InternalServerException<T> : HttpErrorException<T> where T : IError
    {
        public override HttpStatusCode StatusCode => HttpStatusCode.InternalServerError;

        public InternalServerException(Exception? innerException = null)
            : base(innerException) { }

        public InternalServerException(T error, Exception? innerException = null)
            : base(error, innerException) { }

        public InternalServerException(IEnumerable<T> errors, Exception? innerException = null, string message = "")
            : base(errors, innerException, message) { }
    }
}
