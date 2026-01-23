using Krzaq.Errors.Model;
using Krzaq.Exceptions.Http.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Krzaq.Exceptions.Http.Error.Base
{
    public abstract class HttpErrorException<T> : HttpException where T : IError
    {
        public IReadOnlyCollection<T> Errors { get; }

        public HttpErrorException(Exception? innerException = null)
            : base(string.Empty, innerException)
        {
            Errors = new List<T>().AsReadOnly();
        }

        public HttpErrorException(T error, Exception? innerException = null)
            : base(error.Message, innerException)
        {
            Errors = new List<T>() { { error } }.AsReadOnly();
        }

        public HttpErrorException(IEnumerable<T> errors, Exception? innerException = null, string message = "")
            : base(message ?? errors.FirstOrDefault()?.Message ?? string.Empty, innerException)
        {
            Errors = errors.ToList().AsReadOnly();
        }
    }
}
