using System;
using System.Net;

namespace Krzaq.Attributes.HttpStatus
{
    public class HttpStatusAttribute : Attribute
    {
        public HttpStatusCode Code { get; }

        public HttpStatusAttribute(HttpStatusCode code)
        {
            Code = code;
        }
    }
}
