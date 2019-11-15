using System;
using System.Globalization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace testRouteConstraint
{
    public partial class Startup
    {
        /// <summary>
        /// .NET Core Routing Constraint
        /// https://www.cnblogs.com/lwqlun/p/9649774.html
        /// </summary>
        public class EmailConstraint : IRouteConstraint
        {
            public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
            {
                if (httpContext == null)
                {
                    throw new ArgumentNullException(nameof(httpContext));
                }

                if (route == null)
                {
                    throw new ArgumentNullException(nameof(route));
                }

                if (routeKey == null)
                {
                    throw new ArgumentNullException(nameof(routeKey));
                }

                if (values == null)
                {
                    throw new ArgumentNullException(nameof(values));
                }

                if (values.TryGetValue(routeKey, out var routeValues))
                {
                    var parameterValueString = Convert.ToString(routeValues, CultureInfo.InvariantCulture);
                    
                    return parameterValueString.Contains("@");
                }

                return false;
            }
        }
    }
}