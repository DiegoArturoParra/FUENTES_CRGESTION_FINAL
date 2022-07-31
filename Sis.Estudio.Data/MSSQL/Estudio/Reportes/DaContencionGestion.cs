using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Sis.Estudio.Entity;

namespace Sis.Estudio.Data.MSSQL.Estudio
{
    public class DaContencionGestion : DaConexion
    {

        public DataTable ContencionGestion_Listar()
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_TipoGestiones_sp_Listar_solo";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;

                adp.Fill(DS, "DataTable1");
                dt = DS.Tables["DataTable1"];
                return dt;
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable ContencionGestion_Sucursal_Listar(List<EnContencionGestion> ListEnContencionGestion)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "TAB_Sucursal_Listar";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[1];

                paramsToStore[0] = new SqlParameter("@NEMPRESA", SqlDbType.Int);
                paramsToStore[0].Value = ListEnContencionGestion[0].NEMPRESA;

                adp.SelectCommand.Parameters.AddRange(paramsToStore);

                adp.Fill(DS, "DataTable1");
                dt = DS.Tables["DataTable1"];

                return dt;
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable ContencionGestion_RPT(List<EnContencionGestion> ListEnContencionGestion)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "RPT_Contencion_TipoGestion";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[5];

                paramsToStore[0] = new SqlParameter("@NEMPRESA", SqlDbType.Int);
                paramsToStore[0].Value = ListEnContencionGestion[0].NEMPRESA;

                paramsToStore[1] = new SqlParameter("@Anio", SqlDbType.Int);
                paramsToStore[1].Value = ListEnContencionGestion[0].Anio;

                paramsToStore[2] = new SqlParameter("@Tramo", SqlDbType.Int);
                paramsToStore[2].Value = ListEnContencionGestion[0].Tramo;

                paramsToStore[3] = new SqlParameter("@CodSucursal", SqlDbType.Int);
                paramsToStore[3].Value = ListEnContencionGestion[0].CodSucursal;

                paramsToStore[4] = new SqlParameter("@CodTipoGestion", SqlDbType.Int);
                paramsToStore[4].Value = ListEnContencionGestion[0].CodTipoGestion;

                adp.SelectCommand.Parameters.AddRange(paramsToStore);

                adp.Fill(DS, "DataTable1");
                dt = DS.Tables["DataTable1"];

                return dt;
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }


    }
}
