using Krzaq.Errors.Model;
using Krzaq.Exceptions.Http.Error.Base;
using System;
using System.Collections.Generic;
using System.Net;

namespace Krzaq.Exceptions.Http.Error
{
    public class BadRequestException<T> : HttpErrorException<T> where T : IError
    {
        public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

        public BadRequestException(Exception? innerException = null)
            : base(innerException) {}

        public BadRequestException(T error, Exception? innerException = null)
            : base(error, innerException) { }

        public BadRequestException(IEnumerable<T> errors, Exception? innerException = null, string message = "")
            : base(errors, innerException, message) { }
    }
}
