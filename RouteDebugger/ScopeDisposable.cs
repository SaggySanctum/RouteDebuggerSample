using System;
using System.Collections.Generic;

namespace RouteDebugger
{
    public class ScopeDisposable : IDisposable
    {
        private bool _disposed;

        private readonly Scope _scope;

        private readonly Stack<Scope> _scopes;

	    public ScopeDisposable(Scope scope, Stack<Scope> scopes)
	    {
            _scope = scope;
            _scopes = scopes;

            _scopes.Peek().Children.Add(_scope);

            _scopes.Push(_scope);
	    }

        public void Dispose()
        {
            if (!_disposed)
            {
                var scope = _scopes.Pop();

                if (!object.ReferenceEquals(_scope, scope))
                {
                    throw new InvalidOperationException("scope is not the same _scope");
                }

                _disposed = true;
            }
        }
    }
}