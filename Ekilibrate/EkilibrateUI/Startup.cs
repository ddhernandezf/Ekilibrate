using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EkilibrateUI.Startup))]
namespace EkilibrateUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Autofac.ContainerConfig.Start();
            ConfigureAuth(app);
        }
    }
}
