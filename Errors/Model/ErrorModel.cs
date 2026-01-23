using KrzaqTools.Extensions;
using System;

namespace Krzaq.Errors.Model
{
    public interface IError
    {
        string Message { get; }
    }

    public abstract class ErrorModel<TErrorCode> : IError
        where TErrorCode : struct, Enum
    {
        public virtual TErrorCode Code { get; set; }
        public string Message { get; set; } = string.Empty;

        public ErrorModel() { }

        public ErrorModel(TErrorCode code)
        {
            Code = code;
            Message = code.GetDescription() ?? string.Empty;
        }
    }
}
