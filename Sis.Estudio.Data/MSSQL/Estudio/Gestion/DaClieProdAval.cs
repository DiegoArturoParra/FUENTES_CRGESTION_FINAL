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
    public class DaClieProdAval : DaConexion
    {

        public void Producto_Aval_INS(List<EnClieProdAval> ListEnClieProdAval, SqlTransaction tran)
        {
            try
            {
                #region Parametros
                SqlParameter prm_NEMPRESA = new SqlParameter();
                SqlParameter prm_CODIGOCLIENTE = new SqlParameter();
                SqlParameter prm_IDREGPRODUCTOS = new SqlParameter();
                SqlParameter prm_DNI = new SqlParameter();
                SqlParameter prm_NOMBRES = new SqlParameter();
                SqlParameter prm_CODSTATUSLABORAL = new SqlParameter();
                SqlParameter prm_TELEFONOS = new SqlParameter();
                SqlParameter prm_OBSERVACION = new SqlParameter();
                SqlParameter prm_ESTADO = new SqlParameter();
                SqlParameter prm_CODUSUARIO = new SqlParameter();
                #endregion Parametros

                #region Values
                #region nempresa
                prm_NEMPRESA.ParameterName = "@nempresa";
                prm_NEMPRESA.SqlDbType = SqlDbType.Int;
                prm_NEMPRESA.Direction = ParameterDirection.Input;
                prm_NEMPRESA.Value = ListEnClieProdAval[0].NEmpresa;
                #endregion nempresa
                #region CodigoCliente
                prm_CODIGOCLIENTE.ParameterName = "@CodigoCliente";
                prm_CODIGOCLIENTE.SqlDbType = SqlDbType.Int;
                prm_CODIGOCLIENTE.Direction = ParameterDirection.Input;
                prm_CODIGOCLIENTE.Value = ListEnClieProdAval[0].CodigoCliente;
                #endregion CodigoCliente
                #region IdRegProductos
                prm_IDREGPRODUCTOS.ParameterName = "@IdRegProductos";
                prm_IDREGPRODUCTOS.SqlDbType = SqlDbType.Int;
                prm_IDREGPRODUCTOS.Direction = ParameterDirection.Input;
                prm_IDREGPRODUCTOS.Value = ListEnClieProdAval[0].IdRegProductos;
                #endregion IdRegProductos
                #region DNI
                prm_DNI.ParameterName = "@DNI";
                prm_DNI.SqlDbType = SqlDbType.Char;
                prm_DNI.Direction = ParameterDirection.Input;
                prm_DNI.Size = 8;
                prm_DNI.Value = ListEnClieProdAval[0].DNI;
                #endregion DNI
                #region Nombres
                prm_NOMBRES.ParameterName = "@Nombres";
                prm_NOMBRES.SqlDbType = SqlDbType.VarChar;
                prm_NOMBRES.Direction = ParameterDirection.Input;
                prm_NOMBRES.Size = 120;
                prm_NOMBRES.Value = ListEnClieProdAval[0].Nombres;
                #endregion Nombres
                #region CodStatusLaboral
                prm_CODSTATUSLABORAL.ParameterName = "@CodStatusLaboral";
                prm_CODSTATUSLABORAL.SqlDbType = SqlDbType.VarChar;
                prm_CODSTATUSLABORAL.Direction = ParameterDirection.Input;
                prm_CODSTATUSLABORAL.Size = 60;
                prm_CODSTATUSLABORAL.Value = ListEnClieProdAval[0].CodStatusLaboral;
                #endregion CodStatusLaboral
                #region Telefonos
                prm_TELEFONOS.ParameterName = "@Telefonos";
                prm_TELEFONOS.SqlDbType = SqlDbType.VarChar;
                prm_TELEFONOS.Direction = ParameterDirection.Input;
                prm_TELEFONOS.Size = 50;
                prm_TELEFONOS.Value = ListEnClieProdAval[0].Telefonos;
                #endregion Telefonos
                #region Observacion
                prm_OBSERVACION.ParameterName = "@Observacion";
                prm_OBSERVACION.SqlDbType = SqlDbType.VarChar;
                prm_OBSERVACION.Direction = ParameterDirection.Input;
                prm_OBSERVACION.Size = 200;
                prm_OBSERVACION.Value = ListEnClieProdAval[0].Observacion;
                #endregion Observacion
                #region Estado
                prm_ESTADO.ParameterName = "@Estado";
                prm_ESTADO.SqlDbType = SqlDbType.Char;
                prm_ESTADO.Direction = ParameterDirection.Input;
                prm_ESTADO.Size = 1;
                prm_ESTADO.Value = ListEnClieProdAval[0].Estado;
                #endregion Estado
                #region CodUsuario
                prm_CODUSUARIO.ParameterName = "@CodUsuario";
                prm_CODUSUARIO.SqlDbType = SqlDbType.Int;
                prm_CODUSUARIO.Direction = ParameterDirection.Input;
                prm_CODUSUARIO.Value = ListEnClieProdAval[0].CodUsuario;
                #endregion CodUsuario
                #endregion Values

                #region Execute
                SqlHelper.ExecuteNonQuery(tran, "CR_Cliente_sp_InsertarAval",
                                               prm_NEMPRESA,
                                               prm_CODIGOCLIENTE,
                                               prm_IDREGPRODUCTOS,
                                               prm_DNI,
                                               prm_NOMBRES,
                                               prm_CODSTATUSLABORAL,
                                               prm_TELEFONOS,
                                               prm_OBSERVACION,
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
        public void Producto_Aval_UPD(List<EnClieProdAval> ListEnClieProdAval, SqlTransaction tran)
        {
            try
            {
                #region Parametros
                SqlParameter prm_IDREG = new SqlParameter();
                SqlParameter prm_NEMPRESA = new SqlParameter();
                SqlParameter prm_CODIGOCLIENTE = new SqlParameter();
                SqlParameter prm_IDREGPRODUCTOS = new SqlParameter();
                SqlParameter prm_DNI = new SqlParameter();
                SqlParameter prm_NOMBRES = new SqlParameter();
                SqlParameter prm_CODSTATUSLABORAL = new SqlParameter();
                SqlParameter prm_TELEFONOS = new SqlParameter();
                SqlParameter prm_OBSERVACION = new SqlParameter();
                SqlParameter prm_ESTADO = new SqlParameter();
                SqlParameter prm_CODUSUARIO = new SqlParameter();
                #endregion Parametros

                #region Values
                #region IdReg
                prm_IDREG.ParameterName = "@IdReg";
                prm_IDREG.SqlDbType = SqlDbType.Int;
                prm_IDREG.Direction = ParameterDirection.Input;
                prm_IDREG.Value = ListEnClieProdAval[0].IdReg;
                #endregion IdReg
                #region nempresa
                prm_NEMPRESA.ParameterName = "@nempresa";
                prm_NEMPRESA.SqlDbType = SqlDbType.Int;
                prm_NEMPRESA.Direction = ParameterDirection.Input;
                prm_NEMPRESA.Value = ListEnClieProdAval[0].NEmpresa;
                #endregion nempresa
                #region CodigoCliente
                prm_CODIGOCLIENTE.ParameterName = "@CodigoCliente";
                prm_CODIGOCLIENTE.SqlDbType = SqlDbType.Int;
                prm_CODIGOCLIENTE.Direction = ParameterDirection.Input;
                prm_CODIGOCLIENTE.Value = ListEnClieProdAval[0].CodigoCliente;
                #endregion CodigoCliente
                #region IdRegProductos
                prm_IDREGPRODUCTOS.ParameterName = "@IdRegProductos";
                prm_IDREGPRODUCTOS.SqlDbType = SqlDbType.Int;
                prm_IDREGPRODUCTOS.Direction = ParameterDirection.Input;
                prm_IDREGPRODUCTOS.Value = ListEnClieProdAval[0].IdRegProductos;
                #endregion IdRegProductos
                #region DNI
                prm_DNI.ParameterName = "@DNI";
                prm_DNI.SqlDbType = SqlDbType.Char;
                prm_DNI.Direction = ParameterDirection.Input;
                prm_DNI.Size = 8;
                prm_DNI.Value = ListEnClieProdAval[0].DNI;
                #endregion DNI
                #region Nombres
                prm_NOMBRES.ParameterName = "@Nombres";
                prm_NOMBRES.SqlDbType = SqlDbType.VarChar;
                prm_NOMBRES.Direction = ParameterDirection.Input;
                prm_NOMBRES.Size = 120;
                prm_NOMBRES.Value = ListEnClieProdAval[0].Nombres;
                #endregion Nombres
                #region CodStatusLaboral
                prm_CODSTATUSLABORAL.ParameterName = "@CodStatusLaboral";
                prm_CODSTATUSLABORAL.SqlDbType = SqlDbType.VarChar;
                prm_CODSTATUSLABORAL.Direction = ParameterDirection.Input;
                prm_CODSTATUSLABORAL.Size = 60;
                prm_CODSTATUSLABORAL.Value = ListEnClieProdAval[0].CodStatusLaboral;
                #endregion CodStatusLaboral
                #region Telefonos
                prm_TELEFONOS.ParameterName = "@Telefonos";
                prm_TELEFONOS.SqlDbType = SqlDbType.VarChar;
                prm_TELEFONOS.Direction = ParameterDirection.Input;
                prm_TELEFONOS.Size = 50;
                prm_TELEFONOS.Value = ListEnClieProdAval[0].Telefonos;
                #endregion Telefonos
                #region Observacion
                prm_OBSERVACION.ParameterName = "@Observacion";
                prm_OBSERVACION.SqlDbType = SqlDbType.VarChar;
                prm_OBSERVACION.Direction = ParameterDirection.Input;
                prm_OBSERVACION.Size = 200;
                prm_OBSERVACION.Value = ListEnClieProdAval[0].Observacion;
                #endregion Observacion
                #region Estado
                prm_ESTADO.ParameterName = "@Estado";
                prm_ESTADO.SqlDbType = SqlDbType.Char;
                prm_ESTADO.Direction = ParameterDirection.Input;
                prm_ESTADO.Size = 1;
                prm_ESTADO.Value = ListEnClieProdAval[0].Estado;
                #endregion Estado
                #region CodUsuario
                prm_CODUSUARIO.ParameterName = "@CodUsuario";
                prm_CODUSUARIO.SqlDbType = SqlDbType.Int;
                prm_CODUSUARIO.Direction = ParameterDirection.Input;
                prm_CODUSUARIO.Value = ListEnClieProdAval[0].CodUsuario;
                #endregion CodUsuario
                #endregion Values

                #region Execute
                SqlHelper.ExecuteNonQuery(tran, "CR_Cliente_sp_ModificarAval",
                                               prm_IDREG,
                                               prm_NEMPRESA,
                                               prm_CODIGOCLIENTE,
                                               prm_IDREGPRODUCTOS,
                                               prm_DNI,
                                               prm_NOMBRES,
                                               prm_CODSTATUSLABORAL,
                                               prm_TELEFONOS,
                                               prm_OBSERVACION,
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
        public DataTable Producto_Aval_Listar(List<EnClieProdAval> ListEnClieProdAval)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                
                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "CR_Cliente_sp_CargaClienteAval";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[3];

                paramsToStore[0] = new SqlParameter("@NEMPRESA", SqlDbType.Int);
                paramsToStore[0].Value = ListEnClieProdAval[0].NEmpresa;

                paramsToStore[1] = new SqlParameter("@CodigoCliente", SqlDbType.Int);
                paramsToStore[1].Value = ListEnClieProdAval[0].CodigoCliente;

                paramsToStore[2] = new SqlParameter("@IdRegPRODUCTOS", SqlDbType.Decimal);
                paramsToStore[2].Value = ListEnClieProdAval[0].IdRegPRODUCTOS;

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
        public DataTable Producto_Aval_Lisrtar_Reg(List<EnClieProdAval> ListEnClieProdAval)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "CR_Cliente_sp_CargaClienteAvalREG";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];

                paramsToStore[0] = new SqlParameter("@NEMPRESA", SqlDbType.Int);
                paramsToStore[0].Value = ListEnClieProdAval[0].NEmpresa;

                paramsToStore[1] = new SqlParameter("@IdReg", SqlDbType.Int);
                paramsToStore[1].Value = ListEnClieProdAval[0].IdReg;

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
