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
    public class DaZona : DaConexion
    {
        public string Zona_INS(List<EnZona> ListEnZona, SqlTransaction tran)
        {
            string IdReturn = String.Empty;
            SqlDataReader drParamReturn;
            try
            {
                #region Parametros
                SqlParameter prm_NEMPRESA = new SqlParameter();
                SqlParameter prm_CODGERENCIA = new SqlParameter();
                SqlParameter prm_CODZONA = new SqlParameter();
                SqlParameter prm_ZONA = new SqlParameter();
                SqlParameter prm_CODIGOINTERNO = new SqlParameter();
                SqlParameter prm_ESTADO = new SqlParameter();
                SqlParameter prm_CODUSUARIO = new SqlParameter();
                #endregion Parametros


                #region Values
                #region nempresa
                prm_NEMPRESA.ParameterName = "@nempresa";
                prm_NEMPRESA.SqlDbType = SqlDbType.Int;
                prm_NEMPRESA.Direction = ParameterDirection.Input;
                prm_NEMPRESA.Value = ListEnZona[0].NEmpresa;
                #endregion nempresa
                #region CodGerencia
                prm_CODGERENCIA.ParameterName = "@CodGerencia";
                prm_CODGERENCIA.SqlDbType = SqlDbType.Int;
                prm_CODGERENCIA.Direction = ParameterDirection.Input;
                prm_CODGERENCIA.Value = ListEnZona[0].CodGerencia;
                #endregion CodGerencia
                #region CodZona
                prm_CODZONA.ParameterName = "@CodZona";
                prm_CODZONA.SqlDbType = SqlDbType.Int;
                prm_CODZONA.Direction = ParameterDirection.Input;
                prm_CODZONA.Value = ListEnZona[0].CodZona;
                #endregion CodZona
                #region Zona
                prm_ZONA.ParameterName = "@Zona";
                prm_ZONA.SqlDbType = SqlDbType.VarChar;
                prm_ZONA.Direction = ParameterDirection.Input;
                prm_ZONA.Size = 120;
                prm_ZONA.Value = ListEnZona[0].Zona;
                #endregion Zona
                #region CodigoInterno
                prm_CODIGOINTERNO.ParameterName = "@CodigoInterno";
                prm_CODIGOINTERNO.SqlDbType = SqlDbType.Int;
                prm_CODIGOINTERNO.Direction = ParameterDirection.Input;
                prm_CODIGOINTERNO.Value = ListEnZona[0].CodigoInterno;
                #endregion CodigoInterno
                #region Estado
                prm_ESTADO.ParameterName = "@Estado";
                prm_ESTADO.SqlDbType = SqlDbType.Char;
                prm_ESTADO.Direction = ParameterDirection.Input;
                prm_ESTADO.Size = 1;
                prm_ESTADO.Value = ListEnZona[0].Estado;
                #endregion Estado
                #region CodUsuario
                prm_CODUSUARIO.ParameterName = "@CodUsuario";
                prm_CODUSUARIO.SqlDbType = SqlDbType.Int;
                prm_CODUSUARIO.Direction = ParameterDirection.Input;
                prm_CODUSUARIO.Value = ListEnZona[0].CodUsuario;
                #endregion CodUsuario
                #endregion Values

                #region Execute
                drParamReturn = SqlHelper.ExecuteReader(tran, "CR_Zona_sp_Insertar",
                                               prm_NEMPRESA,
                                               prm_CODGERENCIA,
                                               prm_CODZONA,
                                               prm_ZONA,
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
        public void Zona_UPD(List<EnZona> ListEnZona, SqlTransaction tran)
        {
            try
            {
                #region Parametros
                SqlParameter prm_CODGERENCIA = new SqlParameter();
                SqlParameter prm_CODZONA = new SqlParameter();
                SqlParameter prm_ZONA = new SqlParameter();
                SqlParameter prm_CODIGOINTERNO = new SqlParameter();
                SqlParameter prm_ESTADO = new SqlParameter();
                SqlParameter prm_CODUSUARIO = new SqlParameter();
                #endregion Parametros


                #region Values
                #region CodGerencia
                prm_CODGERENCIA.ParameterName = "@CodGerencia";
                prm_CODGERENCIA.SqlDbType = SqlDbType.Int;
                prm_CODGERENCIA.Direction = ParameterDirection.Input;
                prm_CODGERENCIA.Value = ListEnZona[0].CodGerencia;
                #endregion CodGerencia
                #region CodZona
                prm_CODZONA.ParameterName = "@CodZona";
                prm_CODZONA.SqlDbType = SqlDbType.Int;
                prm_CODZONA.Direction = ParameterDirection.Input;
                prm_CODZONA.Value = ListEnZona[0].CodZona;
                #endregion CodZona
                #region Zona
                prm_ZONA.ParameterName = "@Zona";
                prm_ZONA.SqlDbType = SqlDbType.VarChar;
                prm_ZONA.Direction = ParameterDirection.Input;
                prm_ZONA.Size = 120;
                prm_ZONA.Value = ListEnZona[0].Zona;
                #endregion Zona
                #region CodigoInterno
                prm_CODIGOINTERNO.ParameterName = "@CodigoInterno";
                prm_CODIGOINTERNO.SqlDbType = SqlDbType.Int;
                prm_CODIGOINTERNO.Direction = ParameterDirection.Input;
                prm_CODIGOINTERNO.Value = ListEnZona[0].CodigoInterno;
                #endregion CodigoInterno
                #region Estado
                prm_ESTADO.ParameterName = "@Estado";
                prm_ESTADO.SqlDbType = SqlDbType.Char;
                prm_ESTADO.Direction = ParameterDirection.Input;
                prm_ESTADO.Size = 1;
                prm_ESTADO.Value = ListEnZona[0].Estado;
                #endregion Estado
                #region CodUsuario
                prm_CODUSUARIO.ParameterName = "@CodUsuario";
                prm_CODUSUARIO.SqlDbType = SqlDbType.Int;
                prm_CODUSUARIO.Direction = ParameterDirection.Input;
                prm_CODUSUARIO.Value = ListEnZona[0].CodUsuario;
                #endregion CodUsuario
                #endregion Values



                #region Execute
                SqlHelper.ExecuteNonQuery(tran, "CR_Zona_sp_Modificar",
                                               prm_CODGERENCIA,
                                               prm_CODZONA,
                                               prm_ZONA,
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
        public DataTable Zona_Listar(List<EnZona> ListEnZona)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "CR_Cliente_sp_Zona";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[1];

                paramsToStore[0] = new SqlParameter("@nempresa", SqlDbType.Int);
                paramsToStore[0].Value = ListEnZona[0].NEmpresa;

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
        public DataTable Zona_Listar_Reg(List<EnZona> ListEnZona)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "CR_Zona_sp_CargaREG";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];

                paramsToStore[0] = new SqlParameter("@NEMPRESA", SqlDbType.Int);
                paramsToStore[0].Value = ListEnZona[0].NEmpresa;

                paramsToStore[1] = new SqlParameter("@CodZona", SqlDbType.Int);
                paramsToStore[1].Value = ListEnZona[0].CodZona;

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
        public DataTable Zona_Listar_X_Gerencia(List<EnZona> ListEnZona)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "CR_Cliente_sp_Zona_X_Gerencia";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];

                paramsToStore[0] = new SqlParameter("@nempresa", SqlDbType.Int);
                paramsToStore[0].Value = ListEnZona[0].NEmpresa;

                paramsToStore[1] = new SqlParameter("@CodGerencia", SqlDbType.Int);
                paramsToStore[1].Value = ListEnZona[0].CodGerencia;

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
