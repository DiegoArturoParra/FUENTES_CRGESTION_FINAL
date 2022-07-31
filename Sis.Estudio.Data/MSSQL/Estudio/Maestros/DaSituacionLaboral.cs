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
    public class DaSituacionLaboral : DaConexion
    {

        public string SituacionLaboral_INS(List<EnSituacionLaboral> ListEnSituacionLaboral, SqlTransaction tran)
        {
            string IdReturn = String.Empty;
            SqlDataReader drParamReturn;
            try
            {
                #region Parametros
                SqlParameter prm_CODSITLAB = new SqlParameter();
                SqlParameter prm_SITLAB = new SqlParameter();
                SqlParameter prm_ESTADO = new SqlParameter();
                SqlParameter prm_CODUSUARIO = new SqlParameter();
                #endregion Parametros

                #region Values
                #region CodSitLab
                prm_CODSITLAB.ParameterName = "@CodSitLab";
                prm_CODSITLAB.SqlDbType = SqlDbType.Int;
                prm_CODSITLAB.Direction = ParameterDirection.Input;
                prm_CODSITLAB.Value = ListEnSituacionLaboral[0].CodSitLab;
                #endregion CodSitLab
                #region SitLab
                prm_SITLAB.ParameterName = "@SitLab";
                prm_SITLAB.SqlDbType = SqlDbType.VarChar;
                prm_SITLAB.Direction = ParameterDirection.Input;
                prm_SITLAB.Size = 60;
                prm_SITLAB.Value = ListEnSituacionLaboral[0].SitLab;
                #endregion SitLab
                #region Estado
                prm_ESTADO.ParameterName = "@Estado";
                prm_ESTADO.SqlDbType = SqlDbType.Char;
                prm_ESTADO.Direction = ParameterDirection.Input;
                prm_ESTADO.Size = 1;
                prm_ESTADO.Value = ListEnSituacionLaboral[0].Estado;
                #endregion Estado
                #region CodUsuario
                prm_CODUSUARIO.ParameterName = "@CodUsuario";
                prm_CODUSUARIO.SqlDbType = SqlDbType.Int;
                prm_CODUSUARIO.Direction = ParameterDirection.Input;
                prm_CODUSUARIO.Value = ListEnSituacionLaboral[0].CodUsuario;
                #endregion CodUsuario
                #endregion Values

                #region Execute
                drParamReturn = SqlHelper.ExecuteReader(tran, "CR_SituacionLaboral_sp_Insertar",
                                               prm_CODSITLAB,
                                               prm_SITLAB,
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
        public void SituacionLaboral_UPD(List<EnSituacionLaboral> ListEnSituacionLaboral, SqlTransaction tran)
        {
            try
            {
                #region Parametros
                SqlParameter prm_CODSITLAB = new SqlParameter();
                SqlParameter prm_SITLAB = new SqlParameter();
                SqlParameter prm_ESTADO = new SqlParameter();
                SqlParameter prm_CODUSUARIO = new SqlParameter();
                #endregion Parametros


                #region Values
                #region CodSitLab
                prm_CODSITLAB.ParameterName = "@CodSitLab";
                prm_CODSITLAB.SqlDbType = SqlDbType.Int;
                prm_CODSITLAB.Direction = ParameterDirection.Input;
                prm_CODSITLAB.Value = ListEnSituacionLaboral[0].CodSitLab;
                #endregion CodSitLab
                #region SitLab
                prm_SITLAB.ParameterName = "@SitLab";
                prm_SITLAB.SqlDbType = SqlDbType.VarChar;
                prm_SITLAB.Direction = ParameterDirection.Input;
                prm_SITLAB.Size = 60;
                prm_SITLAB.Value = ListEnSituacionLaboral[0].SitLab;
                #endregion SitLab
                #region Estado
                prm_ESTADO.ParameterName = "@Estado";
                prm_ESTADO.SqlDbType = SqlDbType.Char;
                prm_ESTADO.Direction = ParameterDirection.Input;
                prm_ESTADO.Size = 1;
                prm_ESTADO.Value = ListEnSituacionLaboral[0].Estado;
                #endregion Estado
                #region CodUsuario
                prm_CODUSUARIO.ParameterName = "@CodUsuario";
                prm_CODUSUARIO.SqlDbType = SqlDbType.Int;
                prm_CODUSUARIO.Direction = ParameterDirection.Input;
                prm_CODUSUARIO.Value = ListEnSituacionLaboral[0].CodUsuario;
                #endregion CodUsuario
                #endregion Values



                #region Execute
                SqlHelper.ExecuteNonQuery(tran, "CR_SituacionLaboral_sp_Modificar",
                                               prm_CODSITLAB,
                                               prm_SITLAB,
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
        public DataTable SituacionLaboral_Listar()
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "CR_Cliente_sp_CargaSitLab";
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
        public DataTable SituacionLaboral_Listar_Reg(List<EnSituacionLaboral> ListEnSituacionLaboral)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "CR_SituacionLaboral_sp_CargaREG";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];

                paramsToStore[0] = new SqlParameter("@NEMPRESA", SqlDbType.Int);
                paramsToStore[0].Value = ListEnSituacionLaboral[0].NEmpresa;

                paramsToStore[1] = new SqlParameter("@CodSitLab", SqlDbType.Int);
                paramsToStore[1].Value = ListEnSituacionLaboral[0].CodSitLab;

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
