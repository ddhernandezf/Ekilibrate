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
using Ekilibrate.Model.Entity.Catalogos;

namespace Ekilibrate.BL.Controller.Nutricionista
{
    public class clsDiagnosticoAnamnesis : Ekilibrate.BL.ad.Nutricionista.clsDiagnosticoAnamnesis
    {
        public clsDiagnosticoAnamnesis(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<Int32> Create(IEnumerable<DiagnosticoAnamnesisTiempo> Data)
        {
            int Result = 0;

            foreach (DiagnosticoAnamnesisTiempo item in Data)
            {
                DiagnosticoItem anamnesis = null;
                List<DiagnosticoItem> ListaAnamnesis = new List<DiagnosticoItem>();

                if (item.Lacteos_Enteros != 0)
                {
                    anamnesis = new DiagnosticoItem();
                    anamnesis.GrupoAlimentoId = 1;
                    anamnesis.NutricionistaId = item.NutricionistaId;
                    anamnesis.CitaId = item.CitaId;
                    anamnesis.ParticipanteId = item.ParticipanteId;
                    anamnesis.Porciones = item.Lacteos_Enteros;
                    anamnesis.TiempoComidaId = item.TiempoComidaId;

                    ListaAnamnesis.Add(anamnesis);
                }

                if (item.Azucares != 0)
                {
                    anamnesis = new DiagnosticoItem();
                    anamnesis.GrupoAlimentoId = 7;
                    anamnesis.NutricionistaId = item.NutricionistaId;
                    anamnesis.CitaId = item.CitaId;
                    anamnesis.ParticipanteId = item.ParticipanteId;
                    anamnesis.Porciones = item.Azucares;
                    anamnesis.TiempoComidaId = item.TiempoComidaId;

                    ListaAnamnesis.Add(anamnesis);
                }

                if (item.Carnes != 0)
                {
                    anamnesis = new DiagnosticoItem();
                    anamnesis.GrupoAlimentoId = 5;
                    anamnesis.NutricionistaId = item.NutricionistaId;
                    anamnesis.CitaId = item.CitaId;
                    anamnesis.ParticipanteId = item.ParticipanteId;
                    anamnesis.Porciones = item.Carnes;
                    anamnesis.TiempoComidaId = item.TiempoComidaId;

                    ListaAnamnesis.Add(anamnesis);
                }

                if (item.Cereales != 0)
                {
                    anamnesis = new DiagnosticoItem();
                    anamnesis.GrupoAlimentoId = 2;
                    anamnesis.NutricionistaId = item.NutricionistaId;
                    anamnesis.CitaId = item.CitaId;
                    anamnesis.ParticipanteId = item.ParticipanteId;
                    anamnesis.Porciones = item.Cereales;
                    anamnesis.TiempoComidaId = item.TiempoComidaId;

                    ListaAnamnesis.Add(anamnesis);
                }

                if (item.Frutas != 0)
                {
                    anamnesis = new DiagnosticoItem();
                    anamnesis.GrupoAlimentoId = 4;
                    anamnesis.NutricionistaId = item.NutricionistaId;
                    anamnesis.CitaId = item.CitaId;
                    anamnesis.ParticipanteId = item.ParticipanteId;
                    anamnesis.Porciones = item.Frutas;
                    anamnesis.TiempoComidaId = item.TiempoComidaId;

                    ListaAnamnesis.Add(anamnesis);
                }

                if (item.Grasas != 0)
                {
                    anamnesis = new DiagnosticoItem();
                    anamnesis.GrupoAlimentoId = 6;
                    anamnesis.NutricionistaId = item.NutricionistaId;
                    anamnesis.CitaId = item.CitaId;
                    anamnesis.ParticipanteId = item.ParticipanteId;
                    anamnesis.Porciones = item.Grasas;
                    anamnesis.TiempoComidaId = item.TiempoComidaId;

                    ListaAnamnesis.Add(anamnesis);
                }

                if (item.Lacteos_Descremados != 0)
                {
                    anamnesis = new DiagnosticoItem();
                    anamnesis.GrupoAlimentoId = 9;
                    anamnesis.NutricionistaId = item.NutricionistaId;
                    anamnesis.CitaId = item.CitaId;
                    anamnesis.ParticipanteId = item.ParticipanteId;
                    anamnesis.Porciones = item.Lacteos_Descremados;
                    anamnesis.TiempoComidaId = item.TiempoComidaId;

                    ListaAnamnesis.Add(anamnesis);
                }

                if (item.Lacteos_Semi_descremados != 0)
                {
                    anamnesis = new DiagnosticoItem();
                    anamnesis.GrupoAlimentoId = 8;
                    anamnesis.NutricionistaId = item.NutricionistaId;
                    anamnesis.CitaId = item.CitaId;
                    anamnesis.ParticipanteId = item.ParticipanteId;
                    anamnesis.Porciones = item.Lacteos_Semi_descremados;
                    anamnesis.TiempoComidaId = item.TiempoComidaId;

                    ListaAnamnesis.Add(anamnesis);
                }

                if (item.Vegetales != 0)
                {
                    anamnesis = new DiagnosticoItem();
                    anamnesis.GrupoAlimentoId = 3;
                    anamnesis.NutricionistaId = item.NutricionistaId;
                    anamnesis.CitaId = item.CitaId;
                    anamnesis.ParticipanteId = item.ParticipanteId;
                    anamnesis.Porciones = item.Vegetales;
                    anamnesis.TiempoComidaId = item.TiempoComidaId;

                    ListaAnamnesis.Add(anamnesis);
                }

                foreach (DiagnosticoItem diagnosticoAnam in ListaAnamnesis)
                {
                    Result = await base.InsertAnamnesis(diagnosticoAnam);    
                }

                
            }
            

            return Result;
        }
    }
}
