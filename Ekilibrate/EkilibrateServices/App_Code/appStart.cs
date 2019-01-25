using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ekilibrate.Services.App_Code
{
    public static class appStart
    {
        public static void AppInitialize()
        {
            Ekilibrate.Services.ServiceContainer.AppStart.Start();
        }

    }
}