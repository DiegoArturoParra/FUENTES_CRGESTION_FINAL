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
    public class LoContencionClasificacion
    {
        public DataTable ContencionClasificacion_Listar()
        {
            try
            {
                DaContencionClasificacion objDaContencionClasificacion = new DaContencionClasificacion();
                return objDaContencionClasificacion.ContencionClasificacion_Listar();
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public DataTable ContencionClasificacion_RPT(List<EnContencionClasificacion> ListEnContencionClasificacion)
        {
            try
            {
                DaContencionClasificacion objDaContencionClasificacion = new DaContencionClasificacion();
                return objDaContencionClasificacion.ContencionClasificacion_RPT(ListEnContencionClasificacion);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
    }
}
