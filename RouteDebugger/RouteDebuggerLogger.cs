using System;
using Microsoft.Framework.Logging;

namespace RouteDebugger
{
    public class RouteDebuggerLogger : ILogger
    {
        private IRouteDebuggerContextProvider _contextProvider;

        public RouteDebuggerLogger(IRouteDebuggerContextProvider contextProvider)
        {
            _contextProvider = contextProvider;
        }

        public bool WriteCore(TraceType eventType, int eventId, object state, Exception exception, Func<object, Exception, string> formatter)
        {
            var context = _contextProvider.Context;

            if (!context.IsEnabled)
            {
                return false;
            }

            if(state != null && formatter != null)
            {
                context.Scopes.Peek().Entries.Add(state);
            }

            return true;
        }
        
        public IDisposable BeginScope(object state)
        {
            var context = _contextProvider.Context;

            if (!context.IsEnabled)
            {
                return NullDisposable.Instance;
            }

            return new ScopeDisposable(new Scope(state), context.Scopes);
        }

        private class NullDisposable : IDisposable
        {
            public static readonly NullDisposable Instance = new NullDisposable();

            public void Dispose()
            {
                // intentionally does nothing
            }
        }
    }
}