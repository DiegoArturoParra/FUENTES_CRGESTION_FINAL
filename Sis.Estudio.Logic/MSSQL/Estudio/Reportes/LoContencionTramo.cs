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
    public class LoContencionTramo
    {
        public DataTable ContencionTramo_Tramos_Lista(List<EnContencionTramo> ListEnContencionTramo)
        {
            try
            {
                DaContencionTramo objDaContencionTramo = new DaContencionTramo();
                return objDaContencionTramo.ContencionTramo_Tramos_Lista(ListEnContencionTramo);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public DataTable ContencionTramo_Anios_Lista(List<EnContencionTramo> ListEnContencionTramo)
        {
            try
            {
                DaContencionTramo objDaContencionTramo = new DaContencionTramo();
                return objDaContencionTramo.ContencionTramo_Anios_Lista(ListEnContencionTramo);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public DataTable ContencionTramo_RPT(List<EnContencionTramo> ListEnContencionTramo)
        {
            try
            {
                DaContencionTramo objDaContencionTramo = new DaContencionTramo();
                return objDaContencionTramo.ContencionTramo_RPT(ListEnContencionTramo);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

    }
}
