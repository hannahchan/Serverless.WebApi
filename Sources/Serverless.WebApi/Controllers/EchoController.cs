﻿namespace Serverless.WebApi.Controllers
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
                    Environment.MachineName,
                    OSVersion = Environment.OSVersion.ToString(),
                    Environment.ProcessorCount,
                },

                HttpConnection = new
                {
                    RemoteIpAddress = this.HttpContext.Connection.RemoteIpAddress.ToString(),
                    LocalIpAddress = this.HttpContext.Connection.LocalIpAddress?.ToString(),
                },

                HttpRequest = new
                {
                    this.HttpContext.Request.Method,
                    this.HttpContext.Request.Scheme,
                    Host = this.HttpContext.Request.Host.ToString(),
                    Path = this.HttpContext.Request.Path.ToString(),
                    Headers = this.HttpContext.Request.Headers
                        .ToDictionary(header => header.Key, header => header.Value.ToString()),
                },
            };
        }
    }
}
