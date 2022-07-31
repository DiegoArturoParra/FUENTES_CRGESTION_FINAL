using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Sis.Estudio.Entity;
using Sis.Estudio.Data;
using Sis.Estudio.Data.MSSQL.Gestion;

namespace Sis.Estudio.Logic.MSSQL.Gestion
{
    public class LoGS_BaseReportes
    {
        public DataTable RPT_BaseReporte_ObtenerAnio(List<EnGS_BaseReportes> ListEnGS_BaseReportes)
        {
            try
            {
                DaGS_BaseReportes objData = new DaGS_BaseReportes();
                return objData.RPT_BaseReporte_ObtenerAnio(ListEnGS_BaseReportes);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable RPT_BaseReporte_ObtenerMes(List<EnGS_BaseReportes> ListEnGS_BaseReportes)
        {
            try
            {
                DaGS_BaseReportes objData = new DaGS_BaseReportes();
                return objData.RPT_BaseReporte_ObtenerMes(ListEnGS_BaseReportes);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable RPT_Prevencion_SistemaAlertas_Consolidado(List<EnGS_BaseReportes> ListEnGS_BaseReportes)
        {
            try
            {
                DaGS_BaseReportes objData = new DaGS_BaseReportes();
                return objData.RPT_Prevencion_SistemaAlertas_Consolidado(ListEnGS_BaseReportes);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        //GS_CargaBaseReporte_SaldoVigentesTramo
        public DataTable GS_CargaBaseReporte_SaldoVigentesTramo(List<EnRPT_BaseContencion> ListEnRPT_BaseContencion)
        {
            try
            {
                DaGS_BaseReportes objData = new DaGS_BaseReportes();
                return objData.GS_CargaBaseReporte_SaldoVigentesTramo(ListEnRPT_BaseContencion);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable RPT_BaseReporte_ObtenerCosechas_Tramo(List<EnGS_BaseReportes> ListEnGS_BaseReportes)
        {
            try
            {
                DaGS_BaseReportes objData = new DaGS_BaseReportes();
                return objData.RPT_BaseReporte_ObtenerCosechas_Tramo(ListEnGS_BaseReportes);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable RPT_BaseReporte_ObtenerSaldosMes_Tramo(List<EnGS_BaseReportes> ListEnGS_BaseReportes)
        {
            try
            {
                DaGS_BaseReportes objData = new DaGS_BaseReportes();
                return objData.RPT_BaseReporte_ObtenerSaldosMes_Tramo(ListEnGS_BaseReportes);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        
        ////RPT_BaseContencion_ObtenerContecionProducto
        //public DataTable RPT_BaseContencion_ObtenerContecionProducto(List<EnRPT_BaseContencion> ListEnRPT_BaseContencion)
        //{
        //    try
        //    {
        //        DaGS_BaseReportes objData = new DaGS_BaseReportes();
        //        return objData.RPT_BaseContencion_ObtenerContecionProducto(ListEnRPT_BaseContencion);
        //    }
        //    catch (Exception excp)
        //    {
        //        throw excp;
        //    }
        //}

    }
}
