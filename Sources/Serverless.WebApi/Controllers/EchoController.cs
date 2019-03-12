namespace Serverless.WebApi.Controllers
{
    using System;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;

    [Route("{*path}")]
    [ApiController]
    public class EchoController : ControllerBase
    {
        [HttpDelete]
        [HttpGet]
        [HttpHead]
        [HttpOptions]
        [HttpPatch]
        [HttpPost]
        [HttpPut]
        public ActionResult<object> Echo()
        {
            return new
            {
                Environment = new
                {
                    MachineName = Environment.MachineName,
                    OSVersion = Environment.OSVersion.ToString(),
                    ProcessorCount = Environment.ProcessorCount
                },

                HttpConnection = new
                {
                    RemoteIpAddress = this.HttpContext.Connection.RemoteIpAddress.ToString(),
                    LocalIpAddress = this.HttpContext.Connection.LocalIpAddress.ToString()
                },

                HttpRequest = new
                {
                    Method = this.HttpContext.Request.Method,
                    Scheme = this.HttpContext.Request.Scheme,
                    Host = this.HttpContext.Request.Host.ToString(),
                    Path = this.HttpContext.Request.Path.ToString(),

                    Headers = this.HttpContext.Request.Headers
                        .ToDictionary(header => header.Key, header => header.Value.ToString()),

                    Form = this.HttpContext.Request.HasFormContentType ?
                        this.HttpContext.Request.Form.ToDictionary(form => form.Key, form => form.Value.ToString()) : null,
                }
            };
        }
    }
}
