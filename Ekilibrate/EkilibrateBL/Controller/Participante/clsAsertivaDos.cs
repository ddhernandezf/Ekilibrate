using System.Text;
using System.Threading.Tasks;
using Dapper;
using Autofac;
using Ekilibrate.BL.Queries;
using Ekilibrate.Model.Entity.Participante;
using Ekilibrate.BL.ad.Participante;

namespace Ekilibrate.BL.Controller.Participante
{
    public class clsAsertivaDos : Ekilibrate.BL.ad.Participante.clsAsertivaDos
    {
        public clsAsertivaDos(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task Create(Ekilibrate.Model.Entity.Participante.clsAsertivaDos Data)
        {
            await base.Insert(Data);
        }
    }
}
