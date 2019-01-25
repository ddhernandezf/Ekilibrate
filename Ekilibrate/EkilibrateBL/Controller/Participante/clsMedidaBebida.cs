using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Autofac;
using Ekilibrate.BL.Queries;
using Ekilibrate.Model.Entity.Participante;
using Ekilibrate.BL.ad.Participante;

namespace Ekilibrate.BL.Controller.Participante
{
    public class clsMedidaBebida : Ekilibrate.BL.ad.Participante.clsMedidaBebida
    {
        public clsMedidaBebida(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task Create(clsMedidaBebidaBase Data)
        {
            await base.Insert(Data);
        }
    }
}
