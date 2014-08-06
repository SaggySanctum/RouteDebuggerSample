using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Routing;
using Microsoft.Framework.DependencyInjection;
using Glimpse.Core.Extensibility;
using Glimpse.ProjectK;
using RouteDebugger;
using System;

namespace Sample
{
    public class Startup
    {
        public void Configure(IBuilder app)
        {
            // TODO: fix error that fails the first request to glimpse.
            // Running fiddler seems to circumvent the problem.

            app = app.WithGlimpse();

            app.UseServices(services =>
            {
                services.AddRouteDebugging();
                services.AddMvc();
            });

            app.UseMiddleware<RouteDebuggerMiddleware>();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "area route",
                    "{area}/{controller}/{action}",
                    new { });

                routes.MapRoute(
                    "controller route",
                    "{controller}/{action}",
                    new { });
            });

            app.UseMiddleware<HandleAllRequestsMiddleware>();
        }
    }
}
