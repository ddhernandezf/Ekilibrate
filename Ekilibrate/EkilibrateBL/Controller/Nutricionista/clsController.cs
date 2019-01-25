using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Dapper;
using Autofac;
using Ekilibrate.BL.Queries.General;
using Ekilibrate.Model.Entity.General;

namespace Ekilibrate.BL.Controller.Nutricionista
{
    public class clsController
    {
        private ILifetimeScope _lifetimeScope;        
        
        public clsController(ILifetimeScope lifetimeScope) { _lifetimeScope = lifetimeScope; }

        public async Task SincronizarCuadroMetas(IEnumerable<Model.Entity.Nutricionista.clsSeguimientoAspectos> Metas)
        {
            if (Metas.Count() > 0)
            {
                var objCita = new Ekilibrate.ad.Administrador.clsCita(_lifetimeScope);
                var Cita = await objCita.GetOne(Metas.First().CitaId);

                if (Cita == null)
                    throw new Exception("No puede registrar ya que no existe una cita en el sistema");
                else
                {

                    var objSegumiento = new Ekilibrate.BL.Controller.Nutricionista.clsSeguimientoAspecto(_lifetimeScope);
                    await objSegumiento.Create(Metas);
                }
            }
        }

        public async Task FinalizarCita(Ekilibrate.Model.Entity.Nutricionista.clsSeguimiento data)
        {
            var objController = new Ekilibrate.BL.Controller.Nutricionista.clsSeguimiento(_lifetimeScope);
            await objController.Sincronizar(data);

            var objCita = new Ekilibrate.ad.Administrador.clsCitaProgramacion(_lifetimeScope);
            await objCita.FinalizarCita(data.CitaId);            
        }

        private async Task<int> CrearPersona(Ekilibrate.Model.Entity.Participante.clsParticipante item)
        {
            Ekilibrate.ad.General.clsPersona objPersona = new Ekilibrate.ad.General.clsPersona(_lifetimeScope);
            var p = await objPersona.GetByCorreo(item.Correo);
            if (p == null)
                return await objPersona.Insert(item);
            else
                return p.Id;
        }
        
    }


}
