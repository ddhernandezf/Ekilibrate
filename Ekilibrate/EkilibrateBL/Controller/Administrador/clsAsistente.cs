using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Autofac;
using Ekilibrate.BL.Queries;
using Ekilibrate.Model.Administrador;
using Ekilibrate.ad.Administrador;
using Ekilibrate.Model.Entity.Administrador;

namespace Ekilibrate.BL.Controller
{
    public class clsAsistente : Ekilibrate.ad.Administrador.clsAsistente
    {
        public clsAsistente(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task Create(clsAsistenteBase Data)
        {
             await base.Insert(Data);
        }
    }
}
