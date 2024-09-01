using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Ironika_Theme1
{
    public class MyCustomConstaint : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            return routeDirection == RouteDirection.IncomingRequest;
        }
    }
   
}