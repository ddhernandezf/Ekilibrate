using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Ekilibrate.Data.Access.Common
{
    public static class ContainerConfig
    {
        public static IContainer ProxyContainer;

        public static void Start()
        {
            ContainerBuilder builder = new ContainerBuilder();
                        
            builder.Register(c => new DBTrnContext())
                .InstancePerMatchingLifetimeScope("a")
                .OnActivated(e => e.Instance.BeginTransaction());
            
            ProxyContainer = builder.Build();
        }
    }
}
