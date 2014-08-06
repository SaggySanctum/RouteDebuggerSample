using Microsoft.Framework.Logging;

namespace RouteDebugger
{
    public class RouteDebuggerLoggerFactory : ILoggerFactory
    {
        private IRouteDebuggerContextProvider _contextProvider;

        public RouteDebuggerLoggerFactory(IRouteDebuggerContextProvider contextProvider)
        {
            _contextProvider = contextProvider;
        }

        public ILogger Create(string name)
        {
            return new RouteDebuggerLogger(_contextProvider);
        }
    }
}