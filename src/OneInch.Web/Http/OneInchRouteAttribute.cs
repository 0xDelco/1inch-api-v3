
using System;

namespace OneInch.Web
{
    public class OneInchRouteAttribute : System.Attribute
    {
        public OneInchRouteAttribute(string route = null)
        {
            this.Route = new(route);
        }

        public Uri Route {get;set;}
    }
}