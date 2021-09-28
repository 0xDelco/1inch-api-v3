
using System;

namespace OneInch.Api
{
    /// <summary>
    /// Attribute to decorate API request classes to identify their route path.
    /// </summary>
    internal class OneInchRouteAttribute : System.Attribute
    {
        /// <summary>
        /// Constructs attribute to assign route with the specified value.
        /// </summary>
        /// <param name="route">Route path for the decorated request.</param>
        public OneInchRouteAttribute(string route)
        {
            this.Route = route;
        }

        /// <summary>
        /// Route path for the decorated request.
        /// </summary>
        /// <value>String route value</value>
        public string Route {get;set;}
    }
}