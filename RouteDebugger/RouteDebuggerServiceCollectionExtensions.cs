using Microsoft.Framework.Logging;
using RouteDebugger;

namespace Microsoft.Framework.DependencyInjection
{
    public static class RouteDebuggerServiceCollectionExtensions
    {
        public static IServiceCollection AddRouteDebugging(this IServiceCollection services)
        {
            services.AddSingleton<IRouteDebuggerContextProvider, RouteDebuggerContextProvider>();
            services.AddSingleton<ILoggerFactory, RouteDebuggerLoggerFactory>();
            return services;
        }
    }
}