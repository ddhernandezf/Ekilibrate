using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.Services.Abstract
{
    public abstract class clsServiceBase
    {
        static clsServiceBase()
        {
            Ekilibrate.Data.Access.Common.ContainerConfig.Start();
        }
    }
}
