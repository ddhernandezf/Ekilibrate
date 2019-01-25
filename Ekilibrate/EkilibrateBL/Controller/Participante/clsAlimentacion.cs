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
    public class clsAlimentacion : Ekilibrate.BL.ad.Participante.clsAlimentacion
    {
        public clsAlimentacion(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<Int32> Create(clsAlimentacionBase Data)
        {
            return await base.Insert(Data);
        }
    }
}
