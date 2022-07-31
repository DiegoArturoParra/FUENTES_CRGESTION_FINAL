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
    public class DaCanalContact : DaConexion
    {
        public void CanalContact_INS(List<EnCanalContact> ListEnCanalContact, SqlTransaction tran)
        {
            try
            {
                #region Parametros
                SqlParameter prm_NEMPRESA = new SqlParameter();
                SqlParameter prm_CODIGOCLIENTE = new SqlParameter();
                SqlParameter prm_CODTIPOCONTACTO = new SqlParameter();
                SqlParameter prm_DATO = new SqlParameter();
                SqlParameter prm_ORDEN = new SqlParameter();
                SqlParameter prm_ESTADO = new SqlParameter();
                SqlParameter prm_CODUSUARIO = new SqlParameter();
                #endregion Parametros

                #region Values
                #region NEMPRESA
                prm_NEMPRESA.ParameterName = "@NEMPRESA";
                prm_NEMPRESA.SqlDbType = SqlDbType.Int;
                prm_NEMPRESA.Direction = ParameterDirection.Input;
                prm_NEMPRESA.Value = ListEnCanalContact[0].NEMPRESA;
                #endregion NEMPRESA
                #region CodigoCliente
                prm_CODIGOCLIENTE.ParameterName = "@CodigoCliente";
                prm_CODIGOCLIENTE.SqlDbType = SqlDbType.Int;
                prm_CODIGOCLIENTE.Direction = ParameterDirection.Input;
                prm_CODIGOCLIENTE.Value = ListEnCanalContact[0].CodigoCliente;
                #endregion CodigoCliente
                #region CodTipoContacto
                prm_CODTIPOCONTACTO.ParameterName = "@CodTipoContacto";
                prm_CODTIPOCONTACTO.SqlDbType = SqlDbType.Int;
                prm_CODTIPOCONTACTO.Direction = ParameterDirection.Input;
                prm_CODTIPOCONTACTO.Value = ListEnCanalContact[0].CodTipoContacto;
                #endregion CodTipoContacto
                #region Dato
                prm_DATO.ParameterName = "@Dato";
                prm_DATO.SqlDbType = SqlDbType.VarChar;
                prm_DATO.Direction = ParameterDirection.Input;
                prm_DATO.Size = 120;
                prm_DATO.Value = ListEnCanalContact[0].Dato;
                #endregion Dato
                #region Orden
                prm_ORDEN.ParameterName = "@Orden";
                prm_ORDEN.SqlDbType = SqlDbType.Int;
                prm_ORDEN.Direction = ParameterDirection.Input;
                prm_ORDEN.Value = ListEnCanalContact[0].Orden;
                #endregion Orden
                #region Estado
                prm_ESTADO.ParameterName = "@Estado";
                prm_ESTADO.SqlDbType = SqlDbType.Char;
                prm_ESTADO.Direction = ParameterDirection.Input;
                prm_ESTADO.Size = 1;
                prm_ESTADO.Value = ListEnCanalContact[0].Estado;
                #endregion Estado
                #region CodUsuario
                prm_CODUSUARIO.ParameterName = "@CodUsuario";
                prm_CODUSUARIO.SqlDbType = SqlDbType.Int;
                prm_CODUSUARIO.Direction = ParameterDirection.Input;
                prm_CODUSUARIO.Value = ListEnCanalContact[0].CodUsuario;
                #endregion CodUsuario
                #endregion Values

                #region Execute
                SqlHelper.ExecuteNonQuery(tran, "CR_Cliente_sp_InsertarContacto",
                                               prm_NEMPRESA,
                                               prm_CODIGOCLIENTE,
                                               prm_CODTIPOCONTACTO,
                                               prm_DATO,
                                               prm_ORDEN,
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
        public void CanalContact_UPD(List<EnCanalContact> ListEnCanalContact, SqlTransaction tran)
        {
            try
            {
                #region Parametros
                SqlParameter prm_IDREG = new SqlParameter();
                SqlParameter prm_NEMPRESA = new SqlParameter();
                SqlParameter prm_CODIGOCLIENTE = new SqlParameter();
                SqlParameter prm_CODTIPOCONTACTO = new SqlParameter();
                SqlParameter prm_DATO = new SqlParameter();
                SqlParameter prm_ORDEN = new SqlParameter();
                SqlParameter prm_ESTADO = new SqlParameter();
                SqlParameter prm_CODUSUARIO = new SqlParameter();
                #endregion Parametros

                #region Values
                #region IdReg
                prm_IDREG.ParameterName = "@IdReg";
                prm_IDREG.SqlDbType = SqlDbType.Int;
                prm_IDREG.Direction = ParameterDirection.Input;
                prm_IDREG.Value = ListEnCanalContact[0].IdReg;
                #endregion IdReg
                #region nempresa
                prm_NEMPRESA.ParameterName = "@nempresa";
                prm_NEMPRESA.SqlDbType = SqlDbType.Int;
                prm_NEMPRESA.Direction = ParameterDirection.Input;
                prm_NEMPRESA.Value = ListEnCanalContact[0].NEMPRESA;
                #endregion nempresa
                #region CodigoCliente
                prm_CODIGOCLIENTE.ParameterName = "@CodigoCliente";
                prm_CODIGOCLIENTE.SqlDbType = SqlDbType.Int;
                prm_CODIGOCLIENTE.Direction = ParameterDirection.Input;
                prm_CODIGOCLIENTE.Value = ListEnCanalContact[0].CodigoCliente;
                #endregion CodigoCliente
                #region CodTipoContacto
                prm_CODTIPOCONTACTO.ParameterName = "@CodTipoContacto";
                prm_CODTIPOCONTACTO.SqlDbType = SqlDbType.Int;
                prm_CODTIPOCONTACTO.Direction = ParameterDirection.Input;
                prm_CODTIPOCONTACTO.Value = ListEnCanalContact[0].CodTipoContacto;
                #endregion CodTipoContacto
                #region Dato
                prm_DATO.ParameterName = "@Dato";
                prm_DATO.SqlDbType = SqlDbType.VarChar;
                prm_DATO.Direction = ParameterDirection.Input;
                prm_DATO.Size = 120;
                prm_DATO.Value = ListEnCanalContact[0].Dato;
                #endregion Dato
                #region Orden
                prm_ORDEN.ParameterName = "@Orden";
                prm_ORDEN.SqlDbType = SqlDbType.Int;
                prm_ORDEN.Direction = ParameterDirection.Input;
                prm_ORDEN.Value = ListEnCanalContact[0].Orden;
                #endregion Orden
                #region Estado
                prm_ESTADO.ParameterName = "@Estado";
                prm_ESTADO.SqlDbType = SqlDbType.Char;
                prm_ESTADO.Direction = ParameterDirection.Input;
                prm_ESTADO.Size = 1;
                prm_ESTADO.Value = ListEnCanalContact[0].Estado;
                #endregion Estado
                #region CodUsuario
                prm_CODUSUARIO.ParameterName = "@CodUsuario";
                prm_CODUSUARIO.SqlDbType = SqlDbType.VarChar;
                prm_CODUSUARIO.Direction = ParameterDirection.Input;
                prm_CODUSUARIO.Size = 15;
                prm_CODUSUARIO.Value = ListEnCanalContact[0].CodUsuario;
                #endregion CodUsuario
                #endregion Values

                #region Execute
                SqlHelper.ExecuteNonQuery(tran, "CR_ClienteCanalContac_sp_UPD",
                                               prm_IDREG,
                                               prm_NEMPRESA,
                                               prm_CODIGOCLIENTE,
                                               prm_CODTIPOCONTACTO,
                                               prm_DATO,
                                               prm_ORDEN,
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
        public DataTable CanalContact_Listar(List<EnCanalContact> ListEnCanalContact)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "CR_Cliente_sp_CargaClienteContacto";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];

                paramsToStore[0] = new SqlParameter("@NEMPRESA", SqlDbType.Int);
                paramsToStore[0].Value = ListEnCanalContact[0].NEMPRESA;

                paramsToStore[1] = new SqlParameter("@CodigoCliente", SqlDbType.Int);
                paramsToStore[1].Value = ListEnCanalContact[0].CodigoCliente;

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
        public DataTable CanalContact_Listar_Reg(List<EnCanalContact> ListEnCanalContact)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "CR_Cliente_sp_CargaClienteContactoREG";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];

                paramsToStore[0] = new SqlParameter("@NEMPRESA", SqlDbType.Int);
                paramsToStore[0].Value = ListEnCanalContact[0].NEMPRESA;

                paramsToStore[1] = new SqlParameter("@IdReg", SqlDbType.Int);
                paramsToStore[1].Value = ListEnCanalContact[0].IdReg;

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
