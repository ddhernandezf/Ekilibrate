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
    public class clsCuidado : Ekilibrate.ad.Participante.clsActividadFisica
    {
        public clsCuidado(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task Create(Ekilibrate.Model.Entity.Participante.clsCuidado Data)
        {
            Ekilibrate.BL.ad.Participante.clsPadecimiento objPadecimiento = new Ekilibrate.BL.ad.Participante.clsPadecimiento(_lifetimescope);
            //Ekilibrate.BL.ad.Participante.clsCondicionPreExistente objCondicionPre = new clsCondicionPreExistente(_lifetimescope);

            await base.Insert(Data.ActividadFisica);
            await objPadecimiento.Insert(Data.Padecimiento);
        }

        public async Task Update(Ekilibrate.Model.Entity.Participante.clsCuidado Data)
        {
            Ekilibrate.BL.ad.Participante.clsPadecimiento objPadecimiento = new Ekilibrate.BL.ad.Participante.clsPadecimiento(_lifetimescope);
            //Ekilibrate.BL.ad.Participante.clsCondicionPreExistente objCondicionPre = new clsCondicionPreExistente(_lifetimescope);

            await base.Update(Data.ActividadFisica);
            await objPadecimiento.Update(Data.Padecimiento);
        }
    }
}
