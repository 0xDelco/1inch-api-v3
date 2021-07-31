
using System;

namespace OneInch.Api
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