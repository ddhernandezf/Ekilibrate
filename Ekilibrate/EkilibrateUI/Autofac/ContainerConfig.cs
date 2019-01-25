using Autofac;
using Autofac.Integration.Wcf;
using System.ServiceModel;

namespace EkilibrateUI.Autofac
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

            builder.Register(c => new ChannelFactory<Ekilibrate.Model.Services.Cliente.IDataRetriever>(System.Configuration.ConfigurationManager.AppSettings["EndPointClienteDataRetriever"])).SingleInstance();
            builder.Register(c => c.Resolve<ChannelFactory<Ekilibrate.Model.Services.Cliente.IDataRetriever>>().CreateChannel()).UseWcfSafeRelease();

            builder.Register(c => new ChannelFactory<Ekilibrate.Model.Services.Cliente.IDataInjector>(System.Configuration.ConfigurationManager.AppSettings["EndPointClienteDataInjector"])).SingleInstance();
            builder.Register(c => c.Resolve<ChannelFactory<Ekilibrate.Model.Services.Cliente.IDataInjector>>().CreateChannel()).UseWcfSafeRelease();

            builder.Register(c => new ChannelFactory<Ekilibrate.Model.Services.Participante.IDataRetriever>(System.Configuration.ConfigurationManager.AppSettings["EndPointParticipanteDataRetriever"])).SingleInstance();
            builder.Register(c => c.Resolve<ChannelFactory<Ekilibrate.Model.Services.Participante.IDataRetriever>>().CreateChannel()).UseWcfSafeRelease();

            builder.Register(c => new ChannelFactory<Ekilibrate.Model.Services.Participante.IDataInjector>(System.Configuration.ConfigurationManager.AppSettings["EndPointParticipanteDataInjector"])).SingleInstance();
            builder.Register(c => c.Resolve<ChannelFactory<Ekilibrate.Model.Services.Participante.IDataInjector>>().CreateChannel()).UseWcfSafeRelease();

            builder.Register(c => new ChannelFactory<Ekilibrate.Model.Services.Nutricionista.IDataRetriever>(System.Configuration.ConfigurationManager.AppSettings["EndPointNutricionistaDataRetriever"])).SingleInstance();
            builder.Register(c => c.Resolve<ChannelFactory<Ekilibrate.Model.Services.Nutricionista.IDataRetriever>>().CreateChannel()).UseWcfSafeRelease();

            builder.Register(c => new ChannelFactory<Ekilibrate.Model.Services.Nutricionista.IDataInjector>(System.Configuration.ConfigurationManager.AppSettings["EndPointNutricionistaDataInjector"])).SingleInstance();
            builder.Register(c => c.Resolve<ChannelFactory<Ekilibrate.Model.Services.Nutricionista.IDataInjector>>().CreateChannel()).UseWcfSafeRelease();

            ProxyContainer = builder.Build();
        }
    }
}
