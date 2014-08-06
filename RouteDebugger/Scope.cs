using System.Collections.Generic;

namespace RouteDebugger
{
    public class Scope
    {
	    public Scope(object tag)
        {
            Tag = tag;
            Entries = new List<object>();
            Children = new List<object>();
	    }

        public object Tag { get; set; }

        public List<object> Entries { get; set; }

        public List<object> Children { get; set; }
    }
}