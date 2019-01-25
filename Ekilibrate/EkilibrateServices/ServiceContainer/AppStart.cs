using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Autofac.Integration.Wcf;

namespace Ekilibrate.Services.ServiceContainer
{
    public static class AppStart
    {
        public static void Start()
        {
            var builder = new ContainerBuilder();

            //Administrador
            builder.RegisterType<Ekilibrate.Services.Administrador.clsDataRetriever>().SingleInstance();
            builder.RegisterType<Ekilibrate.Services.Administrador.clsDataInjector>();
            
            //Cliente
            builder.RegisterType<Ekilibrate.Services.Cliente.clsDataRetriever>().SingleInstance();
            builder.RegisterType<Ekilibrate.Services.Cliente.clsDataInjector>();

            //Nutricionista
            builder.RegisterType<Ekilibrate.Services.Nutricionista.clsDataRetriever>().SingleInstance();
            builder.RegisterType<Ekilibrate.Services.Nutricionista.clsDataInjector>();

            //Participante
            builder.RegisterType<Ekilibrate.Services.Participante.clsDataRetriever>().SingleInstance();
            builder.RegisterType<Ekilibrate.Services.Participante.clsDataInjector>();
            AutofacHostFactory.Container = builder.Build();
        }
    }
}