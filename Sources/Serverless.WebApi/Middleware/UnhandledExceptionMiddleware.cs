namespace Serverless.WebApi.Middleware
{
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;

    public class UnhandledExceptionMiddleware
    {
        private readonly RequestDelegate next;

        public UnhandledExceptionMiddleware(RequestDelegate next) => this.next = next;

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await this.next.Invoke(httpContext);
            }
            catch (Exception exception)
            {
                httpContext.Response.ContentType = "text/plain";
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                await httpContext.Response.WriteAsync(exception.ToString());
                return;
            }
        }
    }
}
