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
    public class DaGerencia : DaConexion
    {
        public string Gerencia_INS(List<EnGerencia> ListEnGerencia, SqlTransaction tran)
        {
            string IdReturn = String.Empty;
            SqlDataReader drParamReturn;
            try
            {
                #region Parametros
                SqlParameter prm_NEMPRESA = new SqlParameter();
                SqlParameter prm_CODGERENCIA = new SqlParameter();
                SqlParameter prm_GERENCIA = new SqlParameter();
                SqlParameter prm_CODIGOINTERNO = new SqlParameter();
                SqlParameter prm_ESTADO = new SqlParameter();
                SqlParameter prm_CODUSUARIO = new SqlParameter();
                #endregion Parametros


                #region Values
                #region nempresa
                prm_NEMPRESA.ParameterName = "@nempresa";
                prm_NEMPRESA.SqlDbType = SqlDbType.Int;
                prm_NEMPRESA.Direction = ParameterDirection.Input;
                prm_NEMPRESA.Value = ListEnGerencia[0].NEmpresa;
                #endregion nempresa
                #region CodGerencia
                prm_CODGERENCIA.ParameterName = "@CodGerencia";
                prm_CODGERENCIA.SqlDbType = SqlDbType.Int;
                prm_CODGERENCIA.Direction = ParameterDirection.Input;
                prm_CODGERENCIA.Value = ListEnGerencia[0].CodGerencia;
                #endregion CodGerencia
                #region Gerencia
                prm_GERENCIA.ParameterName = "@Gerencia";
                prm_GERENCIA.SqlDbType = SqlDbType.VarChar;
                prm_GERENCIA.Direction = ParameterDirection.Input;
                prm_GERENCIA.Size = 120;
                prm_GERENCIA.Value = ListEnGerencia[0].Gerencia;
                #endregion Gerencia
                #region CodigoInterno
                prm_CODIGOINTERNO.ParameterName = "@CodigoInterno";
                prm_CODIGOINTERNO.SqlDbType = SqlDbType.Int;
                prm_CODIGOINTERNO.Direction = ParameterDirection.Input;
                prm_CODIGOINTERNO.Value = ListEnGerencia[0].CodigoInterno;
                #endregion CodigoInterno
                #region Estado
                prm_ESTADO.ParameterName = "@Estado";
                prm_ESTADO.SqlDbType = SqlDbType.Char;
                prm_ESTADO.Direction = ParameterDirection.Input;
                prm_ESTADO.Size = 1;
                prm_ESTADO.Value = ListEnGerencia[0].Estado;
                #endregion Estado
                #region CodUsuario
                prm_CODUSUARIO.ParameterName = "@CodUsuario";
                prm_CODUSUARIO.SqlDbType = SqlDbType.Int;
                prm_CODUSUARIO.Direction = ParameterDirection.Input;
                prm_CODUSUARIO.Value = ListEnGerencia[0].CodUsuario;
                #endregion CodUsuario
                #endregion Values


                #region Execute
                drParamReturn = SqlHelper.ExecuteReader(tran, "CR_Gerencia_sp_Insertar",
                                               prm_NEMPRESA,
                                               prm_CODGERENCIA,
                                               prm_GERENCIA,
                                               prm_CODIGOINTERNO,
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
        public void Gerencia_UPD(List<EnGerencia> ListEnGerencia, SqlTransaction tran)
        {
            try
            {
                #region Parametros
                SqlParameter prm_CODGERENCIA = new SqlParameter();
                SqlParameter prm_GERENCIA = new SqlParameter();
                SqlParameter prm_CODIGOINTERNO = new SqlParameter();
                SqlParameter prm_ESTADO = new SqlParameter();
                SqlParameter prm_CODUSUARIO = new SqlParameter();
                #endregion Parametros

                #region Values
                #region CodGerencia
                prm_CODGERENCIA.ParameterName = "@CodGerencia";
                prm_CODGERENCIA.SqlDbType = SqlDbType.Int;
                prm_CODGERENCIA.Direction = ParameterDirection.Input;
                prm_CODGERENCIA.Value = ListEnGerencia[0].CodGerencia;
                #endregion CodGerencia
                #region Gerencia
                prm_GERENCIA.ParameterName = "@Gerencia";
                prm_GERENCIA.SqlDbType = SqlDbType.VarChar;
                prm_GERENCIA.Direction = ParameterDirection.Input;
                prm_GERENCIA.Size = 120;
                prm_GERENCIA.Value = ListEnGerencia[0].Gerencia;
                #endregion Gerencia
                #region CodigoInterno
                prm_CODIGOINTERNO.ParameterName = "@CodigoInterno";
                prm_CODIGOINTERNO.SqlDbType = SqlDbType.Int;
                prm_CODIGOINTERNO.Direction = ParameterDirection.Input;
                prm_CODIGOINTERNO.Value = ListEnGerencia[0].CodigoInterno;
                #endregion CodigoInterno
                #region Estado
                prm_ESTADO.ParameterName = "@Estado";
                prm_ESTADO.SqlDbType = SqlDbType.Char;
                prm_ESTADO.Direction = ParameterDirection.Input;
                prm_ESTADO.Size = 1;
                prm_ESTADO.Value = ListEnGerencia[0].Estado;
                #endregion Estado
                #region CodUsuario
                prm_CODUSUARIO.ParameterName = "@CodUsuario";
                prm_CODUSUARIO.SqlDbType = SqlDbType.Int;
                prm_CODUSUARIO.Direction = ParameterDirection.Input;
                prm_CODUSUARIO.Value = ListEnGerencia[0].CodUsuario;
                #endregion CodUsuario
                #endregion Values

                #region Execute
                SqlHelper.ExecuteNonQuery(tran, "CR_Gerencia_sp_Modificar",
                                               prm_CODGERENCIA,
                                               prm_GERENCIA,
                                               prm_CODIGOINTERNO,
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
        public DataTable Gerencia_Listar(List<EnGerencia> ListEnGerencia)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "CR_Cliente_sp_Gerencia";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[1];

                paramsToStore[0] = new SqlParameter("@nempresa", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGerencia[0].NEmpresa;

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
        public DataTable Gerencia_Listar_Reg(List<EnGerencia> ListEnGerencia)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "CR_Gerencia_sp_CargaREG";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];

                paramsToStore[0] = new SqlParameter("@NEMPRESA", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGerencia[0].NEmpresa;

                paramsToStore[1] = new SqlParameter("@CodGerencia", SqlDbType.Int);
                paramsToStore[1].Value = ListEnGerencia[0].CodGerencia;

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
