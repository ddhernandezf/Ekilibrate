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
    public class clsEnfermedad : Ekilibrate.BL.ad.Participante.clsEnfermedad
    {
        public clsEnfermedad(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task Create(clsEnfermedadBase Data)
        {
            var row = await base.GetEnfermedad(Data.ID_PARTICIPANTE, Data.ID_ENFERMEDAD);
            if (row == null || row.Count() == 0)
                await base.Insert(Data);
        }
    }
}
