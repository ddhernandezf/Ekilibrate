using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Autofac;
using Ekilibrate.BL.Queries.Nutricionista;
using Ekilibrate.Model.Entity.Nutricionista;
using Ekilibrate.BL.ad.Nutricionista;

namespace Ekilibrate.BL.DataRetriever.Catalogos
{
    public class clsGrupoAlimento : Ekilibrate.Data.Access.Common.clsReadOnlyDataAccess<Model.Entity.Catalogos.GrupoAlimento, Int32>
    {
        public clsGrupoAlimento(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }



    }
}
