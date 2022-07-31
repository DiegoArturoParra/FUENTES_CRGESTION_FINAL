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
    public class DaSucursal : DaConexion
    {
        public string Sucursal_INS(List<EnSucursal> ListEnSucursal, SqlTransaction tran)
        {
            string IdReturn = String.Empty;
            SqlDataReader drParamReturn;
            try
            {
                #region Parametros
                SqlParameter prm_NEMPRESA = new SqlParameter();
                SqlParameter prm_CODSUCURSAL = new SqlParameter();
                SqlParameter prm_SUCURSAL = new SqlParameter();
                SqlParameter prm_CODIGOINTERNO = new SqlParameter();
                SqlParameter prm_ESTADO = new SqlParameter();
                SqlParameter prm_CODUSUARIO = new SqlParameter();
                #endregion Parametros

                #region Values
                #region nempresa
                prm_NEMPRESA.ParameterName = "@nempresa";
                prm_NEMPRESA.SqlDbType = SqlDbType.Int;
                prm_NEMPRESA.Direction = ParameterDirection.Input;
                prm_NEMPRESA.Value = ListEnSucursal[0].NEmpresa;
                #endregion nempresa
                #region CodSucursal
                prm_CODSUCURSAL.ParameterName = "@CodSucursal";
                prm_CODSUCURSAL.SqlDbType = SqlDbType.Int;
                prm_CODSUCURSAL.Direction = ParameterDirection.Input;
                prm_CODSUCURSAL.Value = ListEnSucursal[0].CodSucursal;
                #endregion CodSucursal
                #region Sucursal
                prm_SUCURSAL.ParameterName = "@Sucursal";
                prm_SUCURSAL.SqlDbType = SqlDbType.VarChar;
                prm_SUCURSAL.Direction = ParameterDirection.Input;
                prm_SUCURSAL.Size = 120;
                prm_SUCURSAL.Value = ListEnSucursal[0].Sucursal;
                #endregion Sucursal
                #region CodigoInterno
                prm_CODIGOINTERNO.ParameterName = "@CodigoInterno";
                prm_CODIGOINTERNO.SqlDbType = SqlDbType.Int;
                prm_CODIGOINTERNO.Direction = ParameterDirection.Input;
                prm_CODIGOINTERNO.Value = ListEnSucursal[0].CodigoInterno;
                #endregion CodigoInterno
                #region Estado
                prm_ESTADO.ParameterName = "@Estado";
                prm_ESTADO.SqlDbType = SqlDbType.Char;
                prm_ESTADO.Direction = ParameterDirection.Input;
                prm_ESTADO.Size = 1;
                prm_ESTADO.Value = ListEnSucursal[0].Estado;
                #endregion Estado
                #region CodUsuario
                prm_CODUSUARIO.ParameterName = "@CodUsuario";
                prm_CODUSUARIO.SqlDbType = SqlDbType.Int;
                prm_CODUSUARIO.Direction = ParameterDirection.Input;
                prm_CODUSUARIO.Value = ListEnSucursal[0].CodUsuario;
                #endregion CodUsuario
                #endregion Values

                #region Execute
                drParamReturn = SqlHelper.ExecuteReader(tran, "CR_Sucursal_sp_Insertar",
                                               prm_NEMPRESA,
                                               prm_CODSUCURSAL,
                                               prm_SUCURSAL,
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
        public void Sucursal_UPD(List<EnSucursal> ListEnSucursal, SqlTransaction tran)
        {
            try
            {
                #region Parametros
                SqlParameter prm_CODSUCURSAL = new SqlParameter();
                SqlParameter prm_SUCURSAL = new SqlParameter();
                SqlParameter prm_CODIGOINTERNO = new SqlParameter();
                SqlParameter prm_ESTADO = new SqlParameter();
                SqlParameter prm_CODUSUARIO = new SqlParameter();
                #endregion Parametros


                #region Values
                #region CodSucursal
                prm_CODSUCURSAL.ParameterName = "@CodSucursal";
                prm_CODSUCURSAL.SqlDbType = SqlDbType.Int;
                prm_CODSUCURSAL.Direction = ParameterDirection.Input;
                prm_CODSUCURSAL.Value = ListEnSucursal[0].CodSucursal;
                #endregion CodSucursal
                #region Sucursal
                prm_SUCURSAL.ParameterName = "@Sucursal";
                prm_SUCURSAL.SqlDbType = SqlDbType.VarChar;
                prm_SUCURSAL.Direction = ParameterDirection.Input;
                prm_SUCURSAL.Size = 120;
                prm_SUCURSAL.Value = ListEnSucursal[0].Sucursal;
                #endregion Sucursal
                #region CodigoInterno
                prm_CODIGOINTERNO.ParameterName = "@CodigoInterno";
                prm_CODIGOINTERNO.SqlDbType = SqlDbType.Int;
                prm_CODIGOINTERNO.Direction = ParameterDirection.Input;
                prm_CODIGOINTERNO.Value = ListEnSucursal[0].CodigoInterno;
                #endregion CodigoInterno
                #region Estado
                prm_ESTADO.ParameterName = "@Estado";
                prm_ESTADO.SqlDbType = SqlDbType.Char;
                prm_ESTADO.Direction = ParameterDirection.Input;
                prm_ESTADO.Size = 1;
                prm_ESTADO.Value = ListEnSucursal[0].Estado;
                #endregion Estado
                #region CodUsuario
                prm_CODUSUARIO.ParameterName = "@CodUsuario";
                prm_CODUSUARIO.SqlDbType = SqlDbType.Int;
                prm_CODUSUARIO.Direction = ParameterDirection.Input;
                prm_CODUSUARIO.Value = ListEnSucursal[0].CodUsuario;
                #endregion CodUsuario
                #endregion Values



                #region Execute
                SqlHelper.ExecuteNonQuery(tran, "CR_Sucursal_sp_Modificar",
                                               prm_CODSUCURSAL,
                                               prm_SUCURSAL,
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
        public DataTable Sucursal_Listar(List<EnSucursal> ListEnSucursal)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "CR_Cliente_sp_Sucursal";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[1];

                paramsToStore[0] = new SqlParameter("@nempresa", SqlDbType.Int);
                paramsToStore[0].Value = ListEnSucursal[0].NEmpresa;

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
        public DataTable Sucursal_Listar_Reg(List<EnSucursal> ListEnSucursal)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "CR_Sucursal_sp_CargaREG";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];

                paramsToStore[0] = new SqlParameter("@nempresa", SqlDbType.Int);
                paramsToStore[0].Value = ListEnSucursal[0].NEmpresa;

                paramsToStore[1] = new SqlParameter("@CodSucursal", SqlDbType.Int);
                paramsToStore[1].Value = ListEnSucursal[0].CodSucursal;

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
