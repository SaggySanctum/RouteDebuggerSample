using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Glimpse.Core.Extensibility;
using Glimpse.Core.Framework;

namespace RouteDebugger
{
    public class RouteDebuggerMiddleware
    {
        public static readonly string RootScopeContextKey = "RouteDebuggerRoot";
        public static readonly string RootScopeTag = "Route debugger root";
        private RequestDelegate _next;
        private IRouteDebuggerContextProvider _debuggerContextProvider;

        public RouteDebuggerMiddleware(RequestDelegate next, IRouteDebuggerContextProvider debuggerContextProvider)
	    {
            _next = next;
            _debuggerContextProvider = debuggerContextProvider;
        }

        public async Task Invoke(HttpContext context)
        {
            var debuggerContext = new RouteDebuggerContext();
            _debuggerContextProvider.Context = debuggerContext;

            debuggerContext.IsEnabled = GlimpseRuntime.Instance.CurrentRequestContext.CurrentRuntimePolicy.Equals(RuntimePolicy.On);
            if (debuggerContext.IsEnabled)
            {
                debuggerContext.Root = new Scope(RootScopeTag);
                debuggerContext.Scopes.Push(debuggerContext.Root);

                context.Items[RootScopeContextKey] = debuggerContext.Root;
            }

            await _next.Invoke(context);
        }
    }
}