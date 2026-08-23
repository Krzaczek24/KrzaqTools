using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Krzaq.Attributes.ProducesResponse
{
    public class ProducesResponseAttribute(HttpStatusCode httpStatus)
        : ProducesResponseTypeAttribute((int)httpStatus)
    {
    }

    public class ProducesResponseAttribute<TResponse>(HttpStatusCode httpStatus)
        : ProducesResponseTypeAttribute(typeof(TResponse), (int)httpStatus)
    {
    }
}
