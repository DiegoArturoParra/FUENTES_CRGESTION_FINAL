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
    public class LoContencionGestion
    {
        public DataTable ContencionGestion_Listar()
        {
            try
            {
                DaContencionGestion objDaContencionGestion = new DaContencionGestion();
                return objDaContencionGestion.ContencionGestion_Listar();
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public DataTable ContencionGestion_Sucursal_Listar(List<EnContencionGestion> ListEnContencionGestion)
        {
            try
            {
                DaContencionGestion objDaContencionGestion = new DaContencionGestion();
                return objDaContencionGestion.ContencionGestion_Sucursal_Listar(ListEnContencionGestion);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public DataTable ContencionGestion_RPT(List<EnContencionGestion> ListEnContencionGestion)
        {
            try
            {
                DaContencionGestion objDaContencionGestion = new DaContencionGestion();
                return objDaContencionGestion.ContencionGestion_RPT(ListEnContencionGestion);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
    }
}
