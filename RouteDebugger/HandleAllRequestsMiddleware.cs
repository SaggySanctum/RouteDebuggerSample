using System.Threading.Tasks;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Builder;

namespace RouteDebugger
{
    public class HandleAllRequestsMiddleware
    {
        private RequestDelegate _next;

        public HandleAllRequestsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            await context.Response.WriteAsync("<html><body>The request went unhandled.</body></html>");
            context.Response.Body.Flush();
        }
    }
}