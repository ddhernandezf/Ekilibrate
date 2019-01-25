using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Ekilibrate.Model.Services.Administrador;
using Ekilibrate.Services.Abstract;
using System.Threading.Tasks;
using Dapper;

namespace Ekilibrate.Services.Administrador
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single,
                     ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class clsDataRetriever : clsServiceBase, IDataRetriever
    {
        async Task<IEnumerable<Ekilibrate.Model.Entity.Administrador.clsEmpresaContacto>> IDataRetriever.GetEmpresas(Ekilibrate.Model.Entity.Administrador.clsEmpresaFiltro Filtro)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                var objDataRetriever = new Ekilibrate.BL.DataRetriever.Administrador.clsEmpresa(scope);
                return await objDataRetriever.GetEmpresas(Filtro);
            }
        }

        async Task<IEnumerable<Model.Entity.Administrador.clsSalonBase>> IDataRetriever.GetSalones(Model.Entity.Administrador.clsSalonFiltro Filtro)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                var objDataRetriever = new Ekilibrate.BL.DataRetriever.clsSalon(scope);
                return await objDataRetriever.GetSalon(Filtro);
            }
        }

        async Task<IEnumerable<Ekilibrate.Model.Entity.Administrador.clsProyecto>> IDataRetriever.GetProyectos()
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                var objDataRetriever = new Ekilibrate.BL.DataRetriever.clsProyecto(scope);
                return await objDataRetriever.GetProyectos();
            }
        }

        async Task<Ekilibrate.Model.Entity.Administrador.clsProyecto> IDataRetriever.GetProyecto(int ProyectoId)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                var objDataRetriever = new Ekilibrate.BL.DataRetriever.clsProyecto(scope);
                return await objDataRetriever.GetProyecto(ProyectoId);
            }
        }

        async Task<IEnumerable<Ekilibrate.Model.Entity.Administrador.clsProyecto>> IDataRetriever.GetProyectosEmpresa(int EmpresaId)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                var objDataRetriever = new Ekilibrate.BL.DataRetriever.clsProyecto(scope);
                return await objDataRetriever.GetProyectos(EmpresaId);
            }
        }

        async Task<IEnumerable<Ekilibrate.Model.Entity.Administrador.clsProyectoSalon>> IDataRetriever.GetSalonesProyecto(Ekilibrate.Model.Entity.Administrador.clsProyectoSalonFiltro Filtro)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                var objDataRetriever = new Ekilibrate.BL.DataRetriever.Administrador.clsProyectoSalon(scope);
                return await objDataRetriever.GetPrpyectoSalon(Filtro);
            }
        }

        async Task<IEnumerable<Ekilibrate.Model.Entity.Administrador.clsProyectoContacto>> IDataRetriever.GetContactosProyecto(Ekilibrate.Model.Entity.Administrador.clsProyectoContactoFiltro Filtro)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                var objDataRetriever = new Ekilibrate.BL.DataRetriever.Administrador.clsProyectoContacto(scope);
                return await objDataRetriever.GetProyectoContacto(Filtro);
            }
        }

        async Task<IEnumerable<Ekilibrate.Model.Catalogos.clsTipoUsoSalonBase>> IDataRetriever.GetTipoUsoSalon(Ekilibrate.Model.Catalogos.clsTipoUsoSalonFiltro Filtro)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                var objDataRetriever = new Ekilibrate.BL.DataRetriever.clsTipoUsoSalon(scope);
                return await objDataRetriever.GetTipoUsoSalon(Filtro);
            }
        }

        async Task<IEnumerable<Ekilibrate.Model.Entity.Administrador.clsProyectoArea>> IDataRetriever.GetAreasProyecto(int ProyectoId)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                var objDataRetriever = new Ekilibrate.BL.DataRetriever.Administrador.clsProyectoArea(scope);
                return await objDataRetriever.GetProyectoArea(ProyectoId);
            }
        }

        async Task<IEnumerable<Ekilibrate.Model.Entity.Administrador.clsColaboradorBase>> IDataRetriever.GetColaborador(Ekilibrate.Model.Entity.Administrador.clsColaboradorFiltro Filtro)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                var objDataRetriever = new Ekilibrate.BL.DataRetriever.Administrador.clsColaborador(scope);
                return await objDataRetriever.GetColaborador(Filtro);
            }
        }

        async Task<IEnumerable<Ekilibrate.Model.Entity.Administrador.clsTallerVista>> IDataRetriever.GetTaller(Ekilibrate.Model.Entity.Administrador.clsTallerFiltro Filtro)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                var objDataRetriever = new Ekilibrate.BL.DataRetriever.Administrador.clsTallerProyecto(scope);
                return await objDataRetriever.GetTallerProyecto(Filtro);
            }
        }

        async Task<IEnumerable<Ekilibrate.Model.Entity.Administrador.clsGrupoBase>> IDataRetriever.GetGrupo(Ekilibrate.Model.Entity.Administrador.clsGrupoFiltro Filtro)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                var objDataRetriever = new Ekilibrate.BL.DataRetriever.Administrador.clsGrupo(scope);
                return await objDataRetriever.GetGrupo(Filtro);
            }
        }

        async Task<IEnumerable<Ekilibrate.Model.Entity.Catalogos.clsAreaBase>> IDataRetriever.GetArea(Ekilibrate.Model.Entity.Catalogos.clsAreaFiltro Filtro)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                var objDataRetriever = new Ekilibrate.BL.DataRetriever.clsArea(scope);
                return await objDataRetriever.GetArea(Filtro);
            }
        }


        async Task<IEnumerable<Ekilibrate.Model.Entity.Catalogos.clsTallerBase>> IDataRetriever.GetCatalogoTaller(Ekilibrate.Model.Entity.Catalogos.clsTallerFiltro Filtro)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                var objDataRetriever = new Ekilibrate.BL.DataRetriever.clsTaller(scope);
                return await objDataRetriever.GetTallerCatalogo(Filtro);
            }
        }

        async Task<IEnumerable<Ekilibrate.Model.Entity.Catalogos.clsAseguradoraBase>> IDataRetriever.GetCatalogoAseguradora()
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                var objDataRetriever = new Ekilibrate.BL.DataRetriever.clsAseguradora(scope);
                return await objDataRetriever.GetAseguradoraCatalogo();
            }
        }

        async Task<IEnumerable<Ekilibrate.Model.Entity.Administrador.clsContactoBase>> IDataRetriever.GetContacto(Ekilibrate.Model.Entity.Administrador.clsContactoFiltro Filtro)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                var objDataRetriever = new Ekilibrate.BL.DataRetriever.Administrador.clsContacto(scope);
                return await objDataRetriever.GetContacto(Filtro);
            }
        }

        async Task<IEnumerable<Ekilibrate.Model.Administrador.clsClienteRolBase>> IDataRetriever.GetClienteRol(Ekilibrate.Model.Administrador.clsClienteRolFiltro Filtro)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                var objDataRetriever = new Ekilibrate.BL.DataRetriever.Administrador.clsClienteRol(scope);
                return await objDataRetriever.GetClienteRol(Filtro);
            }
        }

        async Task<IEnumerable<Ekilibrate.Model.Entity.Catalogos.clsGiroEmpresaBase>> IDataRetriever.GetGiroEmpresa()
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                var objDataRetriever = new Ekilibrate.BL.DataRetriever.Catalogos.clsGiroEmpresa(scope);
                return await objDataRetriever.GetGiroEmpresa();
            }
        }

        async Task<IEnumerable<Ekilibrate.Model.Entity.Catalogos.clsRolNutricionista>> IDataRetriever.GetRolNutricionista()
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                var objDataRetriever = new Ekilibrate.BL.DataRetriever.Catalogos.clsRolNutricionista(scope);
                return await objDataRetriever.GetRolNutricionista();
            }
        }

        async Task<IEnumerable<Ekilibrate.Model.Entity.Catalogos.clsTipoProyecto>> IDataRetriever.GetTipoProyecto()
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                var objDataRetriever = new Ekilibrate.BL.DataRetriever.Catalogos.clsTipoProyecto(scope);
                return await objDataRetriever.GetTipoProyecto();
            }
        }


        #region ColaboradoresDeProyecto
        async Task<IEnumerable<Ekilibrate.Model.Entity.Administrador.clsNutricionistaBase>> IDataRetriever.GetNutricionista(Ekilibrate.Model.Entity.Administrador.clsNutricionistaFiltro Filtro)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                var objDataRetriever = new Ekilibrate.BL.DataRetriever.Administrador.clsNutricionista(scope);
                return await objDataRetriever.GetNutricionista(Filtro);
            }
        }

        async Task<IEnumerable<Ekilibrate.Model.Entity.Administrador.clsAsistenteBase>> IDataRetriever.GetAsistente(Ekilibrate.Model.Entity.Administrador.clsAsistenteFiltro Filtro)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                var objDataRetriever = new Ekilibrate.BL.DataRetriever.Administrador.clsAsistente(scope);
                return await objDataRetriever.GetAsistente(Filtro);
            }
        }


        async Task<IEnumerable<Ekilibrate.Model.Entity.Administrador.clsEnfermeraBase>> IDataRetriever.GetEnfermera(Ekilibrate.Model.Entity.Administrador.clsEnfermeraFiltro Filtro)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                var objDataRetriever = new Ekilibrate.BL.DataRetriever.Administrador.clsEnfermera(scope);
                return await objDataRetriever.GetEnfermera(Filtro);
            }
        }


        async Task<IEnumerable<Ekilibrate.Model.Entity.Administrador.clsFacilitador>> IDataRetriever.GetFacilitador(Ekilibrate.Model.Entity.Administrador.clsFacilitadorFiltro Filtro)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                var objDataRetriever = new Ekilibrate.BL.DataRetriever.Administrador.clsFacilitador(scope);
                return await objDataRetriever.GetFacilitador(Filtro);
            }
        }
        #endregion


        #region CorreoElectronico

        async Task<IEnumerable<Ekilibrate.Model.Entity.General.clsMensajeCorreo>> IDataRetriever.GetCorreos()
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                var objDataRetriever = new Ekilibrate.BL.DataRetriever.Administrador.clsMail(scope);
                return await objDataRetriever.GetCorreos();
            }
        }

        async Task<IEnumerable<Ekilibrate.Model.Entity.General.CorreoElectronico>> IDataRetriever.GetInfoCorreo()
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                var objDataRetriever = new Ekilibrate.BL.DataRetriever.Administrador.clsMensajeCorreo(scope);
                return await objDataRetriever.GetInfoCorreo();
            }
        }

        #endregion


    }
}
