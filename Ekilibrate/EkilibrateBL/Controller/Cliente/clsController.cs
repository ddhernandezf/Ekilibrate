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

namespace Ekilibrate.BL.Controller.Cliente
{
    public class clsController
    {
        private ILifetimeScope _lifetimeScope;        
        private const string sk = "3kiP@rt";
        private const string tranuser = "paguilar";
        private const string EstadoProyectoEnRegistro = "EN REGISTRO";
        private const string EstadoProyectoCreacionParticipantes = "CREACIÓN DE PARTICIPANTES";
        private const string EstadoProyectoPreparacion = "PREPARACIÓN";
        private const string EstadoProyectoEnEjecucion = "EN EJECUCIÓN";
        private const string EstadoProyectoFinalizado = "FINALIZADO";
        private const int TipoProyectoTransform = 3;

        public clsController(ILifetimeScope lifetimeScope) { _lifetimeScope = lifetimeScope; }

        public async Task CargarParticipantes(Int32 ProyectoId, IEnumerable<Ekilibrate.Model.Entity.Participante.clsParticipante> Data)
        {
            //Obtener información del proyecto
            Ekilibrate.BL.DataRetriever.clsProyecto objProyecto = new Ekilibrate.BL.DataRetriever.clsProyecto(_lifetimeScope);
            Ekilibrate.Model.Entity.Administrador.clsProyecto dProyecto = new Ekilibrate.Model.Entity.Administrador.clsProyecto();
            dProyecto = await objProyecto.GetProyecto(ProyectoId);
            List<Ekilibrate.Model.Entity.Proyecto.clsGrupo> ListaGrupos = new List<Ekilibrate.Model.Entity.Proyecto.clsGrupo>();
            
            //if (dProyecto.CrearUsuarios)
            //{ 
                if (dProyecto.Estado == EstadoProyectoCreacionParticipantes)
                {
                    //Crear Grupos
                    Ekilibrate.ad.Administrador.clsGrupo adGrupo = new Ekilibrate.ad.Administrador.clsGrupo(_lifetimeScope);
                    var Grupos = Data.GroupBy(test => test.Grupo)
                       .Select(grp => grp.First())
                       .ToList();
                    foreach (var item in Grupos)                
                    {
                        if (item.Grupo != null && item.Grupo.Length > 0)
                        {
                            Ekilibrate.Model.Entity.Proyecto.clsGrupo dGrupo = await CrearGrupo(ProyectoId, item);
                            ListaGrupos.Add(dGrupo);
                        }
                    }
                
                    //Crear Participante
                    foreach (var item in Data)
                    {
                        item.Id = await CrearPersona(item);

                        //Insertar Participante
                        await CrearParticipante(ProyectoId, item, ListaGrupos);
                    }

                    if (dProyecto.TipoProyectoId == TipoProyectoTransform)
                    { 
                        //Asociar compas
                        foreach (var item in Data)
                        {
                            if (item.Compa.HasValue)
                            { 
                                Ekilibrate.ad.Participante.clsParticipante objParticipante = new Ekilibrate.ad.Participante.clsParticipante(_lifetimeScope);
                                Ekilibrate.Model.Entity.Participante.clsParticipanteBase dParticipante = new Model.Entity.Participante.clsParticipanteBase();
                                dParticipante.Id = item.Id;
                                dParticipante.Compa = Data.Where(x => x.No == item.Compa).First().Id;
                                await objParticipante.AsignarCompa(dParticipante);
                            }
                        }
                    }
                }
                else
                    throw new FaultException("El estado actual del proyecto no permite la acción solicitada.");
            //}
            //else
            //    throw new FaultException("La parametrización del proyecto no admite carga de usuarios por Excel, comuníquese con el administrador del proyecto.");
        }

        private async Task<Ekilibrate.Model.Entity.Proyecto.clsGrupo> CrearGrupo(int ProyectoId,
                                                                                 Ekilibrate.Model.Entity.Participante.clsParticipante item)
        {
            Ekilibrate.ad.Administrador.clsGrupo adGrupo = new Ekilibrate.ad.Administrador.clsGrupo(_lifetimeScope);
            Ekilibrate.Model.Entity.Proyecto.clsGrupo dGrupo = await adGrupo.GetByNombre(item.Grupo, ProyectoId);
            
            if (dGrupo == null)
            { 
                dGrupo = new Ekilibrate.Model.Entity.Proyecto.clsGrupo();
                dGrupo.Nombre = item.Grupo;
                dGrupo.ProyectoId = ProyectoId;
                dGrupo.Id = await adGrupo.Insert(dGrupo);
            }
            
            return dGrupo;
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

        private async Task CrearParticipante(int ProyectoId, 
                                             Ekilibrate.Model.Entity.Participante.clsParticipante item,
                                             List<Ekilibrate.Model.Entity.Proyecto.clsGrupo> ListaGrupos)
        {
            Ekilibrate.ad.Participante.clsParticipante objParticipante = new Ekilibrate.ad.Participante.clsParticipante(_lifetimeScope);
            Ekilibrate.Model.Entity.Participante.clsParticipanteBase dParticipante = await objParticipante.GetById(item.Id, ProyectoId);
            if (dParticipante == null)
            {
                dParticipante = new Model.Entity.Participante.clsParticipanteBase();
                dParticipante.Id = item.Id;
                dParticipante.ProyectoId = ProyectoId;
                dParticipante.GrupoId = ListaGrupos.Where(x => x.Nombre == item.Grupo).First().Id;
                await objParticipante.Insert(dParticipante);
            }
            else
            {
                dParticipante.ProyectoId = ProyectoId;
                dParticipante.GrupoId = ListaGrupos.Where(x => x.Nombre == item.Grupo).First().Id;
                await objParticipante.Update(dParticipante);
            }
        }

        
    }


}
