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
    public class clsComunicacion : Ekilibrate.BL.ad.Participante.clsComunicacion
    {
        public clsComunicacion(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<Int32> Create(clsComunicacionBase Data)
        {
            return await base.Insert(Data);
        }
    }
}
