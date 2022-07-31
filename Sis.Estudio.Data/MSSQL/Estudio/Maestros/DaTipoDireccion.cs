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
    public class DaTipoDireccion : DaConexion
    {
        public string TipoDireccion_INS(List<EnTipoDireccion> ListEnTipoDireccion, SqlTransaction tran)
        {
            string IdReturn = String.Empty;
            SqlDataReader drParamReturn;
            try
            {
                #region Parametros
                SqlParameter prm_CODTIPODIRECCION = new SqlParameter();
                SqlParameter prm_TIPODIRECCION = new SqlParameter();
                SqlParameter prm_ESTADO = new SqlParameter();
                SqlParameter prm_CODUSUARIO = new SqlParameter();
                #endregion Parametros

                #region Values
                #region CodTipoDireccion
                prm_CODTIPODIRECCION.ParameterName = "@CodTipoDireccion";
                prm_CODTIPODIRECCION.SqlDbType = SqlDbType.Int;
                prm_CODTIPODIRECCION.Direction = ParameterDirection.Input;
                prm_CODTIPODIRECCION.Value = ListEnTipoDireccion[0].CodTipoDireccion;
                #endregion CodTipoDireccion
                #region TipoDireccion
                prm_TIPODIRECCION.ParameterName = "@TipoDireccion";
                prm_TIPODIRECCION.SqlDbType = SqlDbType.VarChar;
                prm_TIPODIRECCION.Direction = ParameterDirection.Input;
                prm_TIPODIRECCION.Size = 60;
                prm_TIPODIRECCION.Value = ListEnTipoDireccion[0].TipoDireccion;
                #endregion TipoDireccion
                #region Estado
                prm_ESTADO.ParameterName = "@Estado";
                prm_ESTADO.SqlDbType = SqlDbType.Char;
                prm_ESTADO.Direction = ParameterDirection.Input;
                prm_ESTADO.Size = 1;
                prm_ESTADO.Value = ListEnTipoDireccion[0].Estado;
                #endregion Estado
                #region CodUsuario
                prm_CODUSUARIO.ParameterName = "@CodUsuario";
                prm_CODUSUARIO.SqlDbType = SqlDbType.Int;
                prm_CODUSUARIO.Direction = ParameterDirection.Input;
                prm_CODUSUARIO.Value = ListEnTipoDireccion[0].CodUsuario;
                #endregion CodUsuario
                #endregion Values

                #region Execute
                drParamReturn = SqlHelper.ExecuteReader(tran, "CR_TipoDireccion_sp_Insertar",
                                               prm_CODTIPODIRECCION,
                                               prm_TIPODIRECCION,
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
        public void TipoDireccion_UPD(List<EnTipoDireccion> ListEnTipoDireccion, SqlTransaction tran)
        {
            try
            {
                #region Parametros
                SqlParameter prm_CODTIPODIR = new SqlParameter();
                SqlParameter prm_TIPODIRECCION = new SqlParameter();
                SqlParameter prm_ESTADO = new SqlParameter();
                SqlParameter prm_CODUSUARIO = new SqlParameter();
                #endregion Parametros


                #region Values
                #region CodTipoDir
                prm_CODTIPODIR.ParameterName = "@CodTipoDir";
                prm_CODTIPODIR.SqlDbType = SqlDbType.Int;
                prm_CODTIPODIR.Direction = ParameterDirection.Input;
                prm_CODTIPODIR.Value = ListEnTipoDireccion[0].CodTipoDir;
                #endregion CodTipoDir
                #region TipoDireccion
                prm_TIPODIRECCION.ParameterName = "@TipoDireccion";
                prm_TIPODIRECCION.SqlDbType = SqlDbType.VarChar;
                prm_TIPODIRECCION.Direction = ParameterDirection.Input;
                prm_TIPODIRECCION.Size = 60;
                prm_TIPODIRECCION.Value = ListEnTipoDireccion[0].TipoDireccion;
                #endregion TipoDireccion
                #region Estado
                prm_ESTADO.ParameterName = "@Estado";
                prm_ESTADO.SqlDbType = SqlDbType.Char;
                prm_ESTADO.Direction = ParameterDirection.Input;
                prm_ESTADO.Size = 1;
                prm_ESTADO.Value = ListEnTipoDireccion[0].Estado;
                #endregion Estado
                #region CodUsuario
                prm_CODUSUARIO.ParameterName = "@CodUsuario";
                prm_CODUSUARIO.SqlDbType = SqlDbType.Int;
                prm_CODUSUARIO.Direction = ParameterDirection.Input;
                prm_CODUSUARIO.Value = ListEnTipoDireccion[0].CodUsuario;
                #endregion CodUsuario
                #endregion Values



                #region Execute
                SqlHelper.ExecuteNonQuery(tran, "CR_TipoDireccion_sp_Modificar",
                                               prm_CODTIPODIR,
                                               prm_TIPODIRECCION,
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

        public DataTable TipoDireccion_Listar()
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "CR_Cliente_sp_CargaTipoDireccion";
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
        public DataTable TipoDireccion_Listar_Reg(List<EnTipoDireccion> ListEnTipoDireccion)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "CR_TipoDireccion_sp_CargaREG";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];

                paramsToStore[0] = new SqlParameter("@NEMPRESA", SqlDbType.Int);
                paramsToStore[0].Value = ListEnTipoDireccion[0].NEmpresa;

                paramsToStore[1] = new SqlParameter("@CodTipoDir", SqlDbType.Int);
                paramsToStore[1].Value = ListEnTipoDireccion[0].CodTipoDir;

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
