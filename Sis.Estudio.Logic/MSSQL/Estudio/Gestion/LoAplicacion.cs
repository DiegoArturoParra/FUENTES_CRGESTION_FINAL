using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Sis.Estudio.Entity;
using Sis.Estudio.Data;
using Sis.Estudio.Data.MSSQL.Estudio;

namespace Sis.Estudio.Logic.MSSQL.Estudio
{
    public class LoAplicacion
    {

        public DataTable Aplicacion_TipoPersona_Lista()
        {
            try
            {
                DaAplicacion objDa = new DaAplicacion();
                return objDa.Aplicacion_TipoPersona_Lista();
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public DataTable Aplicacion_StatusLaboral_Lista()
        {
            try
            {
                DaAplicacion objDa = new DaAplicacion();
                return objDa.Aplicacion_StatusLaboral_Lista();
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public DataTable Aplicacion_EstadoCivil_Lista()
        {
            try
            {
                DaAplicacion objDa = new DaAplicacion();
                return objDa.Aplicacion_EstadoCivil_Lista();
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable Aplicacion_Moneda()
        {
            try
            {
                DaAplicacion objDa = new DaAplicacion();
                return objDa.Aplicacion_Moneda();
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
               
                              
        public DataTable Aplicacion_EstadoCronograma(List<EnAplicacion> ListEnAplicacion)
        {
            try
            {
                DaAplicacion objDaAplicacion = new DaAplicacion();
                return objDaAplicacion.Aplicacion_EstadoCronograma(ListEnAplicacion);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }       
        
    }
}
