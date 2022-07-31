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
    public class DaGS_Campaña : DaConexion
    {

        public DataTable GS_Campaña_Lista(List<EnGS_Campaña> ListEnGS_Campaña)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_Campaña_sp_Listar";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[9];

                paramsToStore[0] = new SqlParameter("@CEmpresa", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_Campaña[0].nEmpresa;

                paramsToStore[1] = new SqlParameter("@dias_deuda", SqlDbType.VarChar);
                paramsToStore[1].Value = ListEnGS_Campaña[0].Dias_deuda;
                paramsToStore[1].Size = 30;

                paramsToStore[2] = new SqlParameter("@Capital", SqlDbType.VarChar);
                paramsToStore[2].Value = ListEnGS_Campaña[0].Capital;
                paramsToStore[2].Size = 30;

                paramsToStore[3] = new SqlParameter("@SaldoCapital", SqlDbType.VarChar);
                paramsToStore[3].Value = ListEnGS_Campaña[0].SaldoCapital;
                paramsToStore[3].Size = 30;

                paramsToStore[4] = new SqlParameter("@CodCalificacionSBS", SqlDbType.VarChar);
                paramsToStore[4].Value = ListEnGS_Campaña[0].CodCalificacionSBS;
                paramsToStore[4].Size = 30;

                paramsToStore[5] = new SqlParameter("@CodEstadoDir", SqlDbType.VarChar);
                paramsToStore[5].Value = ListEnGS_Campaña[0].CodEstadoDir;
                paramsToStore[5].Size = 30;

                paramsToStore[6] = new SqlParameter("@condicion_dias", SqlDbType.VarChar);
                paramsToStore[6].Value = ListEnGS_Campaña[0].condicion_dias;
                paramsToStore[6].Size = 1;

                paramsToStore[7] = new SqlParameter("@condicion_capital", SqlDbType.VarChar);
                paramsToStore[7].Value = ListEnGS_Campaña[0].condicion_capital;
                paramsToStore[7].Size = 1;

                paramsToStore[8] = new SqlParameter("@condicion_saldocapital", SqlDbType.VarChar);
                paramsToStore[8].Value = ListEnGS_Campaña[0].condicion_saldocapital;
                paramsToStore[8].Size = 1;


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

        public DataTable GS_CalificacionSBS_Combo()
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_Cliente_sp_EstadoCalificacionSBS_Combo";
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

        public DataTable GS_EstadoDir_Combo()
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_Cliente_sp_CargaEstadoDireccion_Combo";
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

        public string GS_Campaña_INS(List<EnGS_Campaña> ListEnGS_Campaña, SqlTransaction tran)
        {
            string IdReturn = String.Empty;
            SqlDataReader drParamReturn;

            SqlParameter prm_desc_campaña = new SqlParameter();
            SqlParameter prm_condicion_campaña = new SqlParameter();
            SqlParameter prm_CEMPRESA = new SqlParameter();
            SqlParameter prm_CodUsuario = new SqlParameter();
            try
            {

                #region Values


                prm_desc_campaña.ParameterName = "@desc_campaña";
                prm_desc_campaña.SqlDbType = SqlDbType.VarChar;
                prm_desc_campaña.Direction = ParameterDirection.Input;
                prm_desc_campaña.Value = ListEnGS_Campaña[0].desc_campaña;

                prm_condicion_campaña.ParameterName = "@condicion_campaña";
                prm_condicion_campaña.SqlDbType = SqlDbType.Int;
                prm_condicion_campaña.Direction = ParameterDirection.Input;
                prm_condicion_campaña.Value = ListEnGS_Campaña[0].condicion_campaña;

                prm_CEMPRESA.ParameterName = "@CEMPRESA";
                prm_CEMPRESA.SqlDbType = SqlDbType.Char;
                prm_CEMPRESA.Direction = ParameterDirection.Input;
                prm_CEMPRESA.Size = 2;
                prm_CEMPRESA.Value = ListEnGS_Campaña[0].nEmpresa;

                prm_CodUsuario.ParameterName = "@CodUsuarioRegistra";
                prm_CodUsuario.SqlDbType = SqlDbType.Int;
                prm_CodUsuario.Direction = ParameterDirection.Input;
                prm_CodUsuario.Value = ListEnGS_Campaña[0].CodUsuario;

                #endregion Values


                drParamReturn = SqlHelper.ExecuteReader(tran, "dbo.GS_Campaña_sp_Insertar",
                                               prm_desc_campaña, prm_condicion_campaña, prm_CEMPRESA, prm_CodUsuario
                                             );
                while (drParamReturn.Read())
                {
                    IdReturn = drParamReturn.GetValue(0).ToString();
                }
                drParamReturn.Close();

                return IdReturn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GS_Campaña_Mantenimiento_Lista(List<EnGS_Campaña> ListEnGS_Campaña)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_Campaña_sp_Mantenimiento_Listar";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[4];

                paramsToStore[0] = new SqlParameter("@CEmpresa", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_Campaña[0].nEmpresa;

                paramsToStore[1] = new SqlParameter("@desc_campaña", SqlDbType.VarChar);
                paramsToStore[1].Value = ListEnGS_Campaña[0].desc_campaña;
                paramsToStore[1].Size = 5000;

                paramsToStore[2] = new SqlParameter("@fecha_ini", SqlDbType.VarChar);
                paramsToStore[2].Value = ListEnGS_Campaña[0].fecha_ini;
                paramsToStore[2].Size = 10;

                paramsToStore[3] = new SqlParameter("@fecha_fin", SqlDbType.VarChar);
                paramsToStore[3].Value = ListEnGS_Campaña[0].fecha_fin;
                paramsToStore[3].Size = 10;


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

        public void GS_Campaña_DEL(List<EnGS_Campaña> ListEnGS_Campaña, SqlTransaction tran)
        {
            try
            {
                #region Parametros
                SqlParameter prm_id_campaña = new SqlParameter();
                #endregion Parametros


                #region Values

                prm_id_campaña.ParameterName = "@id_campaña";
                prm_id_campaña.SqlDbType = SqlDbType.Int;
                prm_id_campaña.Direction = ParameterDirection.Input;
                prm_id_campaña.Value = ListEnGS_Campaña[0].id_campaña;

                #endregion Values

                #region Execute
                SqlHelper.ExecuteNonQuery(tran, "GS_Campaña_sp_Eliminar",
                                               prm_id_campaña
                                               );
                #endregion Execute
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
