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
    public class DaTipoContacto : DaConexion
    {

        public string TipoContacto_INS(List<EnTipoContacto> ListEnTipoContacto, SqlTransaction tran)
        {
            string IdReturn = String.Empty;
            SqlDataReader drParamReturn;
            try
            {
                #region Parametros
                SqlParameter prm_CODTIPOCONTACTO = new SqlParameter();
                SqlParameter prm_TIPOCONTACTO = new SqlParameter();
                SqlParameter prm_ESTADO = new SqlParameter();
                SqlParameter prm_CODUSUARIO = new SqlParameter();
                #endregion Parametros

                #region Values
                #region CodTipoContacto
                prm_CODTIPOCONTACTO.ParameterName = "@CodTipoContacto";
                prm_CODTIPOCONTACTO.SqlDbType = SqlDbType.Int;
                prm_CODTIPOCONTACTO.Direction = ParameterDirection.Input;
                prm_CODTIPOCONTACTO.Value = ListEnTipoContacto[0].CodTipoContacto;
                #endregion CodTipoContacto
                #region TipoContacto
                prm_TIPOCONTACTO.ParameterName = "@TipoContacto";
                prm_TIPOCONTACTO.SqlDbType = SqlDbType.VarChar;
                prm_TIPOCONTACTO.Direction = ParameterDirection.Input;
                prm_TIPOCONTACTO.Size = 60;
                prm_TIPOCONTACTO.Value = ListEnTipoContacto[0].TipoContacto;
                #endregion TipoContacto
                #region Estado
                prm_ESTADO.ParameterName = "@Estado";
                prm_ESTADO.SqlDbType = SqlDbType.Char;
                prm_ESTADO.Direction = ParameterDirection.Input;
                prm_ESTADO.Size = 1;
                prm_ESTADO.Value = ListEnTipoContacto[0].Estado;
                #endregion Estado
                #region CodUsuario
                prm_CODUSUARIO.ParameterName = "@CodUsuario";
                prm_CODUSUARIO.SqlDbType = SqlDbType.Int;
                prm_CODUSUARIO.Direction = ParameterDirection.Input;
                prm_CODUSUARIO.Value = ListEnTipoContacto[0].CodUsuario;
                #endregion CodUsuario
                #endregion Values

                #region Execute
                drParamReturn = SqlHelper.ExecuteReader(tran, "CR_TipoContacto_sp_Insertar",
                                               prm_CODTIPOCONTACTO,
                                               prm_TIPOCONTACTO,
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
        public void TipoContacto_UPD(List<EnTipoContacto> ListEnTipoContacto, SqlTransaction tran)
        {
            try
            {
                #region Parametros
                SqlParameter prm_CODTIPOCONTACTO = new SqlParameter();
                SqlParameter prm_TIPOCONTACTO = new SqlParameter();
                SqlParameter prm_ESTADO = new SqlParameter();
                SqlParameter prm_CODUSUARIO = new SqlParameter();
                #endregion Parametros


                #region Values
                #region CodTipoContacto
                prm_CODTIPOCONTACTO.ParameterName = "@CodTipoContacto";
                prm_CODTIPOCONTACTO.SqlDbType = SqlDbType.Int;
                prm_CODTIPOCONTACTO.Direction = ParameterDirection.Input;
                prm_CODTIPOCONTACTO.Value = ListEnTipoContacto[0].CodTipoContacto;
                #endregion CodTipoContacto
                #region TipoContacto
                prm_TIPOCONTACTO.ParameterName = "@TipoContacto";
                prm_TIPOCONTACTO.SqlDbType = SqlDbType.VarChar;
                prm_TIPOCONTACTO.Direction = ParameterDirection.Input;
                prm_TIPOCONTACTO.Size = 60;
                prm_TIPOCONTACTO.Value = ListEnTipoContacto[0].TipoContacto;
                #endregion TipoContacto
                #region Estado
                prm_ESTADO.ParameterName = "@Estado";
                prm_ESTADO.SqlDbType = SqlDbType.Char;
                prm_ESTADO.Direction = ParameterDirection.Input;
                prm_ESTADO.Size = 1;
                prm_ESTADO.Value = ListEnTipoContacto[0].Estado;
                #endregion Estado
                #region CodUsuario
                prm_CODUSUARIO.ParameterName = "@CodUsuario";
                prm_CODUSUARIO.SqlDbType = SqlDbType.Int;
                prm_CODUSUARIO.Direction = ParameterDirection.Input;
                prm_CODUSUARIO.Value = ListEnTipoContacto[0].CodUsuario;
                #endregion CodUsuario
                #endregion Values



                #region Execute
                SqlHelper.ExecuteNonQuery(tran, "CR_TipoContacto_sp_Modificar",
                                               prm_CODTIPOCONTACTO,
                                               prm_TIPOCONTACTO,
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
        public DataTable TipoContacto_Listar()
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "CR_Cliente_sp_CargaTipoContacto";
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
        public DataTable TipoContacto_Listar_Reg(List<EnTipoContacto> ListEnTipoContacto)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {


                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "CR_TipoContacto_sp_CargaREG";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];

                paramsToStore[0] = new SqlParameter("@NEMPRESA", SqlDbType.Int);
                paramsToStore[0].Value = ListEnTipoContacto[0].NEmpresa;

                paramsToStore[1] = new SqlParameter("@CodTipoContacto", SqlDbType.Int);
                paramsToStore[1].Value = ListEnTipoContacto[0].CodTipoContacto;

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
