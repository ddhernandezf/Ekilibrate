using Autofac;
using Autofac.Integration.Wcf;
using System.ServiceModel;

namespace EkilibrateSendMail.Autofac
{
    public static class ContainerConfig
    {
        public static IContainer ProxyContainer;

        public static void Start()
        {
            ContainerBuilder builder = new ContainerBuilder();
            //Process Model Services
            builder.Register(c => new ChannelFactory<Ekilibrate.Model.Services.Administrador.IDataRetriever>(System.Configuration.ConfigurationManager.AppSettings["EndPointAdministradorDataRetriever"])).SingleInstance();
            builder.Register(c => c.Resolve<ChannelFactory<Ekilibrate.Model.Services.Administrador.IDataRetriever>>().CreateChannel()).UseWcfSafeRelease();

            builder.Register(c => new ChannelFactory<Ekilibrate.Model.Services.Administrador.IDataInjector>(System.Configuration.ConfigurationManager.AppSettings["EndPointAdministradorDataInjector"])).SingleInstance();
            builder.Register(c => c.Resolve<ChannelFactory<Ekilibrate.Model.Services.Administrador.IDataInjector>>().CreateChannel()).UseWcfSafeRelease();

            ProxyContainer = builder.Build();
        }
    }
}
