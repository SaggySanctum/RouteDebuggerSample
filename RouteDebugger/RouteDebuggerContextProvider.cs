using System.Runtime.Remoting;
using System.Runtime.Remoting.Messaging;

namespace RouteDebugger
{
    public class RouteDebuggerContextProvider : IRouteDebuggerContextProvider
    {
        public static readonly string CallContextKey = "RouteDebuggerContext";

        public RouteDebuggerContext Context
        {
            get
            {
                var handle = CallContext.LogicalGetData(CallContextKey) as ObjectHandle;
                return handle != null ? handle.Unwrap() as RouteDebuggerContext : null;
            }

            set
            {
                CallContext.LogicalSetData(CallContextKey, new ObjectHandle(value));
            }
        }
    }
}