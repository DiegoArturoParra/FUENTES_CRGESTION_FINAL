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
    public class LoGS_Reportes
    {

        public DataTable RPT_Gestion_Ejecutores(List<EnGS_Reportes> ListEnGS_Reportes)
        {
            try
            {
                DaGS_Reportes objData = new DaGS_Reportes();
                return objData.RPT_Gestion_Ejecutores(ListEnGS_Reportes);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable RPT_Recuperacion_Ejecutores(List<EnGS_Reportes> ListEnGS_Reportes)
        {
            try
            {
                DaGS_Reportes objData = new DaGS_Reportes();
                return objData.RPT_Recuperacion_Ejecutores(ListEnGS_Reportes);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable RPT_Recuperacion_Ejecutores_Nivel1(List<EnGS_Reportes> ListEnGS_Reportes)
        {
            try
            {
                DaGS_Reportes objData = new DaGS_Reportes();
                return objData.RPT_Recuperacion_Ejecutores_Nivel1(ListEnGS_Reportes);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public DataTable RPT_Recuperacion_Ejecutores_Nivel2(List<EnGS_Reportes> ListEnGS_Reportes)
        {
            try
            {
                DaGS_Reportes objData = new DaGS_Reportes();
                return objData.RPT_Recuperacion_Ejecutores_Nivel2(ListEnGS_Reportes);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable RPT_Recuperacion_Ejecutores_Nivel3(List<EnGS_Reportes> ListEnGS_Reportes)
        {
            try
            {
                DaGS_Reportes objData = new DaGS_Reportes();
                return objData.RPT_Recuperacion_Ejecutores_Nivel3(ListEnGS_Reportes);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
           public DataTable RPT_Gestion_Ejecutores_Nivel3(List<EnGS_Reportes> ListEnGS_Reportes)
        {
            try
            {
                DaGS_Reportes objData = new DaGS_Reportes();
                return objData.RPT_Gestion_Ejecutores_Nivel3(ListEnGS_Reportes);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }



                public DataTable RPT_Gestion_Ejecutores_Nivel2(List<EnGS_Reportes> ListEnGS_Reportes)
        {
            try
            {
                DaGS_Reportes objData = new DaGS_Reportes();
                return objData.RPT_Gestion_Ejecutores_Nivel2(ListEnGS_Reportes);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }



                public DataTable RPT_Gestion_Ejecutores_Nivel1(List<EnGS_Reportes> ListEnGS_Reportes)
                {
                    try
                    {
                        DaGS_Reportes objData = new DaGS_Reportes();
                        return objData.RPT_Gestion_Ejecutores_Nivel1(ListEnGS_Reportes);
                    }
                    catch (Exception excp)
                    {
                        throw excp;
                    }
                }

        public DataTable RPT_Recuperacion_Piloto(List<EnGS_Reportes> ListEnGS_Reportes)
        {
            try
            {
                DaGS_Reportes objData = new DaGS_Reportes();
                return objData.RPT_Recuperacion_Piloto(ListEnGS_Reportes);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable RPT_Gestion_Campo(List<EnGS_Reportes> ListEnGS_Reportes,string codAsesor)
        {
            try
            {
                DaGS_Reportes objData = new DaGS_Reportes();
                return objData.RPT_Gestion_Campo(ListEnGS_Reportes,codAsesor);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

    }
}
