using System.Collections.Generic;

namespace RouteDebugger
{
    public class RouteDebuggerContext
    {
        public RouteDebuggerContext()
        {
            Scopes = new Stack<Scope>();
        }

        public bool IsEnabled { get; set; }

        public Scope Root { get; set; }

        public Stack<Scope> Scopes { get; private set; }
    }
}