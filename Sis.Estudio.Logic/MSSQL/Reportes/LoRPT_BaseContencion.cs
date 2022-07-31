using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Sis.Estudio.Entity;
using Sis.Estudio.Data;
using Sis.Estudio.Data.MSSQL.Reportes;

namespace Sis.Estudio.Logic.MSSQL.Reportes
{
    public class LoRPT_BaseContencion
    {
        //RPT_BaseContencion_ObtenerContecionProducto
        public DataTable RPT_BaseContencion_ObtenerContencionProducto(List<EnRPT_BaseContencion> ListEnRPT_BaseContencion)
        {
            try
            {
                DaRPT_BaseContencion objData = new DaRPT_BaseContencion();
                return objData.RPT_BaseContencion_ObtenerContencionProducto(ListEnRPT_BaseContencion);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable RPT_BaseContencion_ObtenerAnio(List<EnRPT_BaseContencion> ListEnRPT_BaseContencion)
        {
            try
            {
                DaRPT_BaseContencion objData = new DaRPT_BaseContencion();
                return objData.RPT_BaseContencion_ObtenerAnio(ListEnRPT_BaseContencion);
            }
            catch (Exception excp)
            {
                
                throw excp;
            }
        }

        public DataTable RPT_BaseContencion_ObtenerMes(List<EnRPT_BaseContencion> ListEnRPT_BaseContencion)
        {
            try
            {
                DaRPT_BaseContencion objData = new DaRPT_BaseContencion();
                return objData.RPT_BaseContencion_ObtenerMes(ListEnRPT_BaseContencion);
            }
            catch (Exception excp)
            {
                
                throw excp;
            }
        }

        public DataTable RPT_BaseContencion_ObtenerMesFinal(List<EnRPT_BaseContencion> ListEnRPT_BaseContencion)
        {
            try
            {
                DaRPT_BaseContencion objData = new DaRPT_BaseContencion();
                return objData.RPT_BaseContencion_ObtenerMesFinal(ListEnRPT_BaseContencion);
            }
            catch (Exception excp)
            {

                throw excp;
            }
        }


        public DataTable RPT_BaseContencion_ObtenerRollRatesTramo(List<EnRPT_BaseContencion> ListEnRPT_BaseContencion)
        {
            try
            {
                DaRPT_BaseContencion objData = new DaRPT_BaseContencion();
                return objData.RPT_BaseContencion_ObtenerRollRatesTramo(ListEnRPT_BaseContencion);
            }
            catch (Exception excp)
            {

                throw excp;
            }
        }
    }
}
