using Glimpse.Core.Extensibility;
using Microsoft.AspNet.Http;

namespace RouteDebugger
{
    public class RoutingSystemLogTab : TabBase
    {
        public override string Name
        {
            get
            {
                return "Route Debugger";
            }
        }

        public override object GetData(ITabContext context)
        {
            return context.GetRequestContext<HttpContext>().Items[RouteDebuggerMiddleware.RootScopeContextKey];
        }
    }
}