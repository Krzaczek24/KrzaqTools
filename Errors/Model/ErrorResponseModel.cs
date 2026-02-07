using System;
using System.Collections.Generic;
using System.Linq;

namespace Krzaq.Errors.Model
{
    public abstract class ErrorResponseModel<TErrorCode> where TErrorCode : struct, Enum
    {
        public IReadOnlyCollection<ErrorModel<TErrorCode>> Errors { get; set; }

        public ErrorResponseModel()
        {
            Errors = new List<ErrorModel<TErrorCode>>().AsReadOnly();
        }

        public ErrorResponseModel(ErrorModel<TErrorCode> error)
        {
            Errors = new List<ErrorModel<TErrorCode>>() { { error } }.AsReadOnly();
        }

        public ErrorResponseModel(IEnumerable<ErrorModel<TErrorCode>> errors)
        {
            Errors = errors.ToList().AsReadOnly();
        }
    }
}
