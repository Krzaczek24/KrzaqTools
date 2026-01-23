using KrzaqTools.Errors;
using System;
using System.Collections.Generic;
using System.Net;

namespace KrzaqTools.Exceptions.Http.Error
{
    public class ConflictException<T> : HttpErrorException<T> where T : IError
    {
        public override HttpStatusCode StatusCode => HttpStatusCode.Conflict;

        public ConflictException(Exception? innerException = null)
            : base(innerException) { }

        public ConflictException(T error, Exception? innerException = null)
            : base(error, innerException) { }

        public ConflictException(IEnumerable<T> errors, Exception? innerException = null, string message = "")
            : base(errors, innerException, message) { }
    }
}
