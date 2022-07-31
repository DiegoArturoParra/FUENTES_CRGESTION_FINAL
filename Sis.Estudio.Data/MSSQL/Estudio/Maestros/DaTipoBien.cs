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
    public class DaTipoBien : DaConexion
    {

        public string TipoBien_INS(List<EnTipoBien> ListEnTipoBien, SqlTransaction tran)
        {
            string IdReturn = String.Empty;
            SqlDataReader drParamReturn;

            try
            {
                #region Parametros
                SqlParameter prm_CODTIPOBIEN = new SqlParameter();
                SqlParameter prm_TIPOBIEN = new SqlParameter();
                SqlParameter prm_ESTADO = new SqlParameter();
                SqlParameter prm_CODUSUARIO = new SqlParameter();
                #endregion Parametros


                #region Values
                #region CodTipoBien
                prm_CODTIPOBIEN.ParameterName = "@CodTipoBien";
                prm_CODTIPOBIEN.SqlDbType = SqlDbType.Int;
                prm_CODTIPOBIEN.Direction = ParameterDirection.Input;
                prm_CODTIPOBIEN.Value = ListEnTipoBien[0].CodTipoBien;
                #endregion CodTipoBien
                #region TipoBien
                prm_TIPOBIEN.ParameterName = "@TipoBien";
                prm_TIPOBIEN.SqlDbType = SqlDbType.VarChar;
                prm_TIPOBIEN.Direction = ParameterDirection.Input;
                prm_TIPOBIEN.Size = 60;
                prm_TIPOBIEN.Value = ListEnTipoBien[0].TipoBien;
                #endregion TipoBien
                #region Estado
                prm_ESTADO.ParameterName = "@Estado";
                prm_ESTADO.SqlDbType = SqlDbType.Char;
                prm_ESTADO.Direction = ParameterDirection.Input;
                prm_ESTADO.Size = 1;
                prm_ESTADO.Value = ListEnTipoBien[0].Estado;
                #endregion Estado
                #region CodUsuario
                prm_CODUSUARIO.ParameterName = "@CodUsuario";
                prm_CODUSUARIO.SqlDbType = SqlDbType.Int;
                prm_CODUSUARIO.Direction = ParameterDirection.Input;
                prm_CODUSUARIO.Value = ListEnTipoBien[0].CodUsuario;
                #endregion CodUsuario
                #endregion Values

                #region Execute
                drParamReturn = SqlHelper.ExecuteReader(tran, "CR_TipoBien_sp_Insertar",
                                               prm_CODTIPOBIEN,
                                               prm_TIPOBIEN,
                                               prm_ESTADO,
                                               prm_CODUSUARIO
                                               );
                #endregion Execute

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
        public void TipoBien_UPD(List<EnTipoBien> ListEnTipoBien, SqlTransaction tran)
        {
            try
            {
                #region Parametros
                SqlParameter prm_CODTIPOBIEN = new SqlParameter();
                SqlParameter prm_TIPOBIEN = new SqlParameter();
                SqlParameter prm_ESTADO = new SqlParameter();
                SqlParameter prm_CODUSUARIO = new SqlParameter();
                #endregion Parametros

                #region Values
                #region CodTipoBien
                prm_CODTIPOBIEN.ParameterName = "@CodTipoBien";
                prm_CODTIPOBIEN.SqlDbType = SqlDbType.Int;
                prm_CODTIPOBIEN.Direction = ParameterDirection.Input;
                prm_CODTIPOBIEN.Value = ListEnTipoBien[0].CodTipoBien;
                #endregion CodTipoBien
                #region TipoBien
                prm_TIPOBIEN.ParameterName = "@TipoBien";
                prm_TIPOBIEN.SqlDbType = SqlDbType.VarChar;
                prm_TIPOBIEN.Direction = ParameterDirection.Input;
                prm_TIPOBIEN.Size = 60;
                prm_TIPOBIEN.Value = ListEnTipoBien[0].TipoBien;
                #endregion TipoBien
                #region Estado
                prm_ESTADO.ParameterName = "@Estado";
                prm_ESTADO.SqlDbType = SqlDbType.Char;
                prm_ESTADO.Direction = ParameterDirection.Input;
                prm_ESTADO.Size = 1;
                prm_ESTADO.Value = ListEnTipoBien[0].Estado;
                #endregion Estado
                #region CodUsuario
                prm_CODUSUARIO.ParameterName = "@CodUsuario";
                prm_CODUSUARIO.SqlDbType = SqlDbType.Int;
                prm_CODUSUARIO.Direction = ParameterDirection.Input;
                prm_CODUSUARIO.Value = ListEnTipoBien[0].CodUsuario;
                #endregion CodUsuario
                #endregion Values

                #region Execute
                SqlHelper.ExecuteNonQuery(tran, "CR_TipoBien_sp_Modificar",
                                               prm_CODTIPOBIEN,
                                               prm_TIPOBIEN,
                                               prm_ESTADO,
                                               prm_CODUSUARIO
                                               );
                #endregion Execute
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable TipoBien_Listar()
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "CR_Cliente_sp_TipoBien";
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
        public DataTable TipoBien_Listar_Reg(List<EnTipoBien> ListEnTipoBien)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
               
                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "CR_TipoBien_sp_CargaREG";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];

                paramsToStore[0] = new SqlParameter("@NEMPRESA", SqlDbType.Int);
                paramsToStore[0].Value = ListEnTipoBien[0].NEmpresa;

                paramsToStore[1] = new SqlParameter("@CodTipoBien", SqlDbType.Int);
                paramsToStore[1].Value = ListEnTipoBien[0].CodTipoBien;

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
