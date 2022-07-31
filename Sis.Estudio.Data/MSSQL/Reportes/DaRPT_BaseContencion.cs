using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Sis.Estudio.Entity;

namespace Sis.Estudio.Data.MSSQL.Reportes
{
    public class DaRPT_BaseContencion: DaConexion
    {
        //RPT_BaseContencion_sp_ObtenerContecionProducto
        public DataTable RPT_BaseContencion_ObtenerContencionProducto(List<EnRPT_BaseContencion> ListEnRPT_BaseContencion)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "RPT_BaseContencion_sp_ObtenerContencionProducto";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[6];

                paramsToStore[0] = new SqlParameter("@nEmpresa", SqlDbType.Int);
                paramsToStore[0].Value = ListEnRPT_BaseContencion[0].NEmpresa;

                paramsToStore[1] = new SqlParameter("@AnioInt", SqlDbType.Int);
                paramsToStore[1].Value = ListEnRPT_BaseContencion[0].Anio;

                paramsToStore[2] = new SqlParameter("@CodProducto", SqlDbType.Int);
                paramsToStore[2].Value = ListEnRPT_BaseContencion[0].TipoCredito;

                paramsToStore[3] = new SqlParameter("@Tramo", SqlDbType.Int);
                paramsToStore[3].Value = ListEnRPT_BaseContencion[0].Tramo;

                paramsToStore[4] = new SqlParameter("@MesIntInicio", SqlDbType.Int);
                paramsToStore[4].Value = ListEnRPT_BaseContencion[0].MesIntInicio;

                paramsToStore[5] = new SqlParameter("@MesIntFin", SqlDbType.Int);
                paramsToStore[5].Value = ListEnRPT_BaseContencion[0].MesIntFin;

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


        public DataTable RPT_BaseContencion_ObtenerAnio(List<EnRPT_BaseContencion> ListEnRPT_BaseContencion)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "RPT_BaseContencion_sp_ObtenerAnio";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[1];

                paramsToStore[0] = new SqlParameter("@nEmpresa", SqlDbType.Int);
                paramsToStore[0].Value = ListEnRPT_BaseContencion[0].NEmpresa;

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

        public DataTable RPT_BaseContencion_ObtenerMes(List<EnRPT_BaseContencion> ListEnRPT_BaseContencion)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "RPT_BaseContencion_sp_ObtenerMes";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];

                paramsToStore[0] = new SqlParameter("@nEmpresa", SqlDbType.Int);
                paramsToStore[0].Value = ListEnRPT_BaseContencion[0].NEmpresa;

                paramsToStore[1] = new SqlParameter("@AnioInt", SqlDbType.Int);
                paramsToStore[1].Value = ListEnRPT_BaseContencion[0].AnioInt;

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

        public DataTable RPT_BaseContencion_ObtenerMesFinal(List<EnRPT_BaseContencion> ListEnRPT_BaseContencion)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "RPT_BaseContencion_sp_ObtenerMesFinal";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[3];

                paramsToStore[0] = new SqlParameter("@nEmpresa", SqlDbType.Int);
                paramsToStore[0].Value = ListEnRPT_BaseContencion[0].NEmpresa;

                paramsToStore[1] = new SqlParameter("@AnioInt", SqlDbType.Int);
                paramsToStore[1].Value = ListEnRPT_BaseContencion[0].AnioInt;

                paramsToStore[2] = new SqlParameter("@MesIntInicial", SqlDbType.Int);
                paramsToStore[2].Value = ListEnRPT_BaseContencion[0].MesIntInicio;

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

        //RPT_BaseContencion_ObtenerRollRatesTramo
        public DataTable RPT_BaseContencion_ObtenerRollRatesTramo(List<EnRPT_BaseContencion> ListEnRPT_BaseContencion)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "RPT_BaseContencion_sp_ObtenerRollRatesTramo";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[6];

                paramsToStore[0] = new SqlParameter("@nEmpresa", SqlDbType.Int);
                paramsToStore[0].Value = ListEnRPT_BaseContencion[0].NEmpresa;

                paramsToStore[1] = new SqlParameter("@AnioIntInicio", SqlDbType.Int);
                paramsToStore[1].Value = ListEnRPT_BaseContencion[0].AnioIntInicio;
                paramsToStore[2] = new SqlParameter("@AnioIntFin", SqlDbType.Int);
                paramsToStore[2].Value = ListEnRPT_BaseContencion[0].AnioIntFin;

                paramsToStore[3] = new SqlParameter("@Tramo", SqlDbType.Int);
                paramsToStore[3].Value = ListEnRPT_BaseContencion[0].Tramo;

                paramsToStore[4] = new SqlParameter("@MesIntInicio", SqlDbType.Int);
                paramsToStore[4].Value = ListEnRPT_BaseContencion[0].MesIntInicio;

                paramsToStore[5] = new SqlParameter("@MesIntFin", SqlDbType.Int);
                paramsToStore[5].Value = ListEnRPT_BaseContencion[0].MesIntFin;

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
