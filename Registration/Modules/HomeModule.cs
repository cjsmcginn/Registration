using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;

namespace Registration.Modules
{
    /// <summary>
    /// Serves up the default route as a file (because this is a SPA).
    /// Only one route is defined, / to server the index file so that the
    /// client code can handle the rest
    /// </summary>
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            
            Get["/"] = p => { return Response.AsFile("index.html", "text/html");};
        }
    }
}