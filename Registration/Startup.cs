using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Owin;

namespace Registration
{
    /// <summary>
    /// Owin will automatically look for a startup class
    /// </summary>
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //instruct owin to use nancy with this helper
            app.UseNancy();
        }
    }
}