using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Sis.Estudio.Entity;

namespace Sis.Estudio.Data.MSSQL.Gestion
{
    public class DaGS_BaseReportes: DaConexion
    {
        public DataTable RPT_BaseReporte_ObtenerAnio(List<EnGS_BaseReportes> ListEnGS_BaseReportes)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "RPT_BaseReporte_sp_ObtenerAnio";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[1];

                paramsToStore[0] = new SqlParameter("@NEMPRESA", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_BaseReportes[0].NEmpresa;

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

        public DataTable RPT_BaseReporte_ObtenerMes(List<EnGS_BaseReportes> ListEnGS_BaseReportes)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "RPT_BaseReporte_sp_ObtenerMes";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];

                paramsToStore[0] = new SqlParameter("@NEMPRESA", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_BaseReportes[0].NEmpresa;


                paramsToStore[1] = new SqlParameter("@Anio", SqlDbType.Char);
                paramsToStore[1].Value = ListEnGS_BaseReportes[0].Anio;
                paramsToStore[1].Size = 4;

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

        public DataTable RPT_Prevencion_SistemaAlertas_Consolidado(List<EnGS_BaseReportes> ListEnGS_BaseReportes)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "RPT_Prevencion_sp_SistemaAlertas_Consolidado";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[3];

                paramsToStore[0] = new SqlParameter("@NEMPRESA", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_BaseReportes[0].NEmpresa;

                paramsToStore[1] = new SqlParameter("@Anio", SqlDbType.Char);
                paramsToStore[1].Value = ListEnGS_BaseReportes[0].Anio;
                paramsToStore[1].Size = 4;

                paramsToStore[2] = new SqlParameter("@Mes", SqlDbType.VarChar);
                paramsToStore[2].Value = ListEnGS_BaseReportes[0].Mes;
                paramsToStore[2].Size = 20;

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

        public DataTable GS_CargaBaseReporte_SaldoVigentesTramo(List<EnRPT_BaseContencion> EnRPT_BaseContencion)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_CargaBaseReporte_sp_SaldoVigentesTramo";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[3];

                paramsToStore[0] = new SqlParameter("@NEMPRESA", SqlDbType.Int);
                paramsToStore[0].Value = EnRPT_BaseContencion[0].NEmpresa;

                paramsToStore[1] = new SqlParameter("@AnioInt", SqlDbType.Int);
                paramsToStore[1].Value = EnRPT_BaseContencion[0].AnioIntFin;

                paramsToStore[2] = new SqlParameter("@MesInt", SqlDbType.Int);
                paramsToStore[2].Value = EnRPT_BaseContencion[0].MesIntFin;

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

        public DataTable RPT_BaseReporte_ObtenerCosechas_Tramo(List<EnGS_BaseReportes> ListEnGS_BaseReportes)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "RPT_BaseReporte_sp_ObtenerCosechas_Tramo";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[6];

                paramsToStore[0] = new SqlParameter("@NEmpresa", SqlDbType.Char);
                paramsToStore[0].Value = ListEnGS_BaseReportes[0].NEmpresa;

                paramsToStore[1] = new SqlParameter("@AnioInicio", SqlDbType.Char);
                paramsToStore[1].Value = ListEnGS_BaseReportes[0].Anio;
                paramsToStore[1].Size = 4;

                paramsToStore[2] = new SqlParameter("@MesInicio", SqlDbType.VarChar);
                paramsToStore[2].Value = ListEnGS_BaseReportes[0].Mes;
                paramsToStore[2].Size = 2;

                paramsToStore[3] = new SqlParameter("@AnioFin", SqlDbType.Char);
                paramsToStore[3].Value = ListEnGS_BaseReportes[0].AnioFin;
                paramsToStore[3].Size = 4;

                paramsToStore[4] = new SqlParameter("@MesFin", SqlDbType.VarChar);
                paramsToStore[4].Value = ListEnGS_BaseReportes[0].MesFin;
                paramsToStore[4].Size = 2;

                paramsToStore[5] = new SqlParameter("@Tramo", SqlDbType.Int);
                paramsToStore[5].Value = ListEnGS_BaseReportes[0].Tramo;

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

        public DataTable RPT_BaseReporte_ObtenerSaldosMes_Tramo(List<EnGS_BaseReportes> ListEnGS_BaseReportes)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "RPT_BaseReporte_sp_ObtenerSaldosMes_Tramo";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[6];

                paramsToStore[0] = new SqlParameter("@NEmpresa", SqlDbType.Char);
                paramsToStore[0].Value = ListEnGS_BaseReportes[0].NEmpresa;

                paramsToStore[1] = new SqlParameter("@AnioInicio", SqlDbType.Char);
                paramsToStore[1].Value = ListEnGS_BaseReportes[0].Anio;
                paramsToStore[1].Size = 4;

                paramsToStore[2] = new SqlParameter("@MesInicio", SqlDbType.VarChar);
                paramsToStore[2].Value = ListEnGS_BaseReportes[0].Mes;
                paramsToStore[2].Size = 2;

                paramsToStore[3] = new SqlParameter("@AnioFin", SqlDbType.Char);
                paramsToStore[3].Value = ListEnGS_BaseReportes[0].AnioFin;
                paramsToStore[3].Size = 4;

                paramsToStore[4] = new SqlParameter("@MesFin", SqlDbType.VarChar);
                paramsToStore[4].Value = ListEnGS_BaseReportes[0].MesFin;
                paramsToStore[4].Size = 2;

                paramsToStore[5] = new SqlParameter("@Tramo", SqlDbType.Int);
                paramsToStore[5].Value = ListEnGS_BaseReportes[0].Tramo;

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
