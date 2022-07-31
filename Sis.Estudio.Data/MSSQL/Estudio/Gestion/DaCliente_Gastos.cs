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
    public class DaCliente_Gastos : DaConexion
    {

        public DataTable Cliente_Gastos_Lista(List<EnCliente_Gastos> ListEnCliente_Gastos)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "CR_Cliente_sp_CargaClienteGastos";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[3];

                paramsToStore[0] = new SqlParameter("@nEmpresa", SqlDbType.Int);
                paramsToStore[0].Value = ListEnCliente_Gastos[0].NEMPRESA;

                paramsToStore[1] = new SqlParameter("@CodigoCliente", SqlDbType.Int);
                paramsToStore[1].Value = ListEnCliente_Gastos[0].CodigoCliente;

                paramsToStore[2] = new SqlParameter("@IdRegPRODUCTOS", SqlDbType.Int);
                paramsToStore[2].Value = ListEnCliente_Gastos[0].IdRegProductos;

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

        public string Cliente_Gastos_INS(List<EnCliente_Gastos> ListEnCliente_Gastos, SqlTransaction tran)
        {
            string IdReturn = String.Empty;
            SqlDataReader drParamReturn;

            SqlParameter prm_nEmpresa = new SqlParameter();
            SqlParameter prm_CodigoCliente = new SqlParameter();
            SqlParameter prm_IdRegProductos = new SqlParameter();
            SqlParameter prm_Fecha = new SqlParameter();
            SqlParameter prm_ruc = new SqlParameter();
            SqlParameter prm_RazonSocial = new SqlParameter();
            SqlParameter prm_Monto = new SqlParameter();
            SqlParameter prm_id_tipo_tramite = new SqlParameter();
            SqlParameter prm_Observacion = new SqlParameter();
            SqlParameter prm_FechaRendicion = new SqlParameter();
            SqlParameter prm_CodUsuario = new SqlParameter();
            
            try
            {




                prm_nEmpresa.ParameterName = "@nEmpresa";
                prm_nEmpresa.SqlDbType = SqlDbType.Int;
                prm_nEmpresa.Direction = ParameterDirection.Input;
                prm_nEmpresa.Value = ListEnCliente_Gastos[0].NEMPRESA;

                prm_CodigoCliente.ParameterName = "@CodigoCliente";
                prm_CodigoCliente.SqlDbType = SqlDbType.Int;
                prm_CodigoCliente.Direction = ParameterDirection.Input;
                prm_CodigoCliente.Value = ListEnCliente_Gastos[0].CodigoCliente;


                prm_IdRegProductos.ParameterName = "@IdRegProductos";
                prm_IdRegProductos.SqlDbType = SqlDbType.Int;
                prm_IdRegProductos.Direction = ParameterDirection.Input;
                prm_IdRegProductos.Value = ListEnCliente_Gastos[0].IdRegProductos;


                prm_Fecha.ParameterName = "@Fecha";
                prm_Fecha.SqlDbType = SqlDbType.VarChar;
                prm_Fecha.Direction = ParameterDirection.Input;
                prm_Fecha.Size = 30;
                prm_Fecha.Value = ListEnCliente_Gastos[0].Fecha;


                prm_ruc.ParameterName = "@ruc";
                prm_ruc.SqlDbType = SqlDbType.Char;
                prm_ruc.Direction = ParameterDirection.Input;
                prm_ruc.Size = 11;
                prm_ruc.Value = ListEnCliente_Gastos[0].ruc;

                prm_RazonSocial.ParameterName = "@RazonSocial";
                prm_RazonSocial.SqlDbType = SqlDbType.VarChar;
                prm_RazonSocial.Direction = ParameterDirection.Input;
                prm_RazonSocial.Size = 60;
                prm_RazonSocial.Value = ListEnCliente_Gastos[0].RazonSocial;

                prm_Monto.ParameterName = "@Monto";
                prm_Monto.SqlDbType = SqlDbType.VarChar;
                prm_Monto.Direction = ParameterDirection.Input;
                prm_Monto.Size = 30;
                prm_Monto.Value = ListEnCliente_Gastos[0].Monto;

                prm_id_tipo_tramite.ParameterName = "@id_tipo_tramite";
                prm_id_tipo_tramite.SqlDbType = SqlDbType.Int;
                prm_id_tipo_tramite.Direction = ParameterDirection.Input;
                prm_id_tipo_tramite.Value = ListEnCliente_Gastos[0].id_tipo_tramite;

                prm_Observacion.ParameterName = "@Observacion";
                prm_Observacion.SqlDbType = SqlDbType.VarChar;
                prm_Observacion.Direction = ParameterDirection.Input;
                prm_Observacion.Size = 200;
                prm_Observacion.Value = ListEnCliente_Gastos[0].Observacion;

                prm_FechaRendicion.ParameterName = "@FechaRendicion";
                prm_FechaRendicion.SqlDbType = SqlDbType.VarChar;
                prm_FechaRendicion.Direction = ParameterDirection.Input;
                prm_FechaRendicion.Size = 30;
                prm_FechaRendicion.Value = ListEnCliente_Gastos[0].FechaRendicion;


                prm_CodUsuario.ParameterName = "@CodUsuarioRegistra";
                prm_CodUsuario.SqlDbType = SqlDbType.Int;
                prm_CodUsuario.Direction = ParameterDirection.Input;
                prm_CodUsuario.Value = ListEnCliente_Gastos[0].CodUsuario;


                drParamReturn = SqlHelper.ExecuteReader(tran, "dbo.CR_Cliente_Gastos_Insertar",
                                                prm_nEmpresa,
                                                prm_CodigoCliente,
                                                prm_IdRegProductos,
                                                prm_Fecha
                                                ,
                                                prm_ruc,
                                                prm_RazonSocial,
                                                prm_Monto,
                                                prm_id_tipo_tramite
,
                                                prm_Observacion,
                                                prm_FechaRendicion
                                                ,
                                                prm_CodUsuario

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

        public void Cliente_Gastos_UPD(List<EnCliente_Gastos> ListEnCliente_Gastos, SqlTransaction tran)
        {
            try
            {
                #region Parametros
                SqlParameter prm_IdReg_ClienteGastos = new SqlParameter();
                SqlParameter prm_nEmpresa = new SqlParameter();
                SqlParameter prm_CodigoCliente = new SqlParameter();
                SqlParameter prm_IdRegProductos = new SqlParameter();
                SqlParameter prm_Fecha = new SqlParameter();
                SqlParameter prm_ruc = new SqlParameter();
                SqlParameter prm_RazonSocial = new SqlParameter();
                SqlParameter prm_Monto = new SqlParameter();
                SqlParameter prm_id_tipo_tramite = new SqlParameter();
                SqlParameter prm_Observacion = new SqlParameter();
                SqlParameter prm_FechaRendicion = new SqlParameter();
                SqlParameter prm_CodUsuario = new SqlParameter();
                #endregion Parametros


                #region Values


                prm_IdReg_ClienteGastos.ParameterName = "@IdReg_ClienteGastos";
                prm_IdReg_ClienteGastos.SqlDbType = SqlDbType.Int;
                prm_IdReg_ClienteGastos.Direction = ParameterDirection.Input;
                prm_IdReg_ClienteGastos.Value = ListEnCliente_Gastos[0].IdReg_ClienteGastos;

                prm_nEmpresa.ParameterName = "@nEmpresa";
                prm_nEmpresa.SqlDbType = SqlDbType.Int;
                prm_nEmpresa.Direction = ParameterDirection.Input;
                prm_nEmpresa.Value = ListEnCliente_Gastos[0].NEMPRESA;

                prm_CodigoCliente.ParameterName = "@CodigoCliente";
                prm_CodigoCliente.SqlDbType = SqlDbType.Int;
                prm_CodigoCliente.Direction = ParameterDirection.Input;
                prm_CodigoCliente.Value = ListEnCliente_Gastos[0].CodigoCliente;


                prm_IdRegProductos.ParameterName = "@IdRegProductos";
                prm_IdRegProductos.SqlDbType = SqlDbType.Int;
                prm_IdRegProductos.Direction = ParameterDirection.Input;
                prm_IdRegProductos.Value = ListEnCliente_Gastos[0].IdRegProductos;


                prm_Fecha.ParameterName = "@Fecha";
                prm_Fecha.SqlDbType = SqlDbType.VarChar;
                prm_Fecha.Direction = ParameterDirection.Input;
                prm_Fecha.Size = 10;
                prm_Fecha.Value = ListEnCliente_Gastos[0].Fecha;

                prm_ruc.ParameterName = "@ruc";
                prm_ruc.SqlDbType = SqlDbType.Char;
                prm_ruc.Direction = ParameterDirection.Input;
                prm_ruc.Size = 11;
                prm_ruc.Value = ListEnCliente_Gastos[0].ruc;

                prm_RazonSocial.ParameterName = "@RazonSocial";
                prm_RazonSocial.SqlDbType = SqlDbType.VarChar;
                prm_RazonSocial.Direction = ParameterDirection.Input;
                prm_RazonSocial.Size = 60;
                prm_RazonSocial.Value = ListEnCliente_Gastos[0].RazonSocial;

                prm_Monto.ParameterName = "@Monto";
                prm_Monto.SqlDbType = SqlDbType.VarChar;
                prm_Monto.Direction = ParameterDirection.Input;
                prm_Monto.Size = 30;
                prm_Monto.Value = ListEnCliente_Gastos[0].Monto;

                prm_id_tipo_tramite.ParameterName = "@id_tipo_tramite";
                prm_id_tipo_tramite.SqlDbType = SqlDbType.Int;
                prm_id_tipo_tramite.Direction = ParameterDirection.Input;
                prm_id_tipo_tramite.Value = ListEnCliente_Gastos[0].id_tipo_tramite;

                prm_Observacion.ParameterName = "@Observacion";
                prm_Observacion.SqlDbType = SqlDbType.VarChar;
                prm_Observacion.Direction = ParameterDirection.Input;
                prm_Observacion.Size = 200;
                prm_Observacion.Value = ListEnCliente_Gastos[0].Observacion;

                prm_FechaRendicion.ParameterName = "@FechaRendicion";
                prm_FechaRendicion.SqlDbType = SqlDbType.VarChar;
                prm_FechaRendicion.Direction = ParameterDirection.Input;
                prm_FechaRendicion.Size = 10;
                prm_FechaRendicion.Value = ListEnCliente_Gastos[0].FechaRendicion;


                prm_CodUsuario.ParameterName = "@CodUsuarioRegistra";
                prm_CodUsuario.SqlDbType = SqlDbType.Int;
                prm_CodUsuario.Direction = ParameterDirection.Input;
                prm_CodUsuario.Value = ListEnCliente_Gastos[0].CodUsuario;

                
                #endregion Values



                #region Execute
                SqlHelper.ExecuteNonQuery(tran, "CR_Cliente_Gastos_Modificar",
                                                prm_IdReg_ClienteGastos,
                                                prm_nEmpresa,
                                                prm_CodigoCliente,
                                                prm_IdRegProductos,
                                                prm_Fecha,
                                                prm_ruc,
                                                prm_RazonSocial,
                                                prm_Monto,
                                                prm_id_tipo_tramite,
                                                prm_Observacion,
                                                prm_FechaRendicion,
                                                prm_CodUsuario
                                               );
                #endregion Execute
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Cliente_Gastos_Reg(List<EnCliente_Gastos> ListEnCliente_Gastos)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "CR_Cliente_Gastos_Registro";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[1];


                paramsToStore[0] = new SqlParameter("@IdReg_ClienteGastos", SqlDbType.Int);
                paramsToStore[0].Value = ListEnCliente_Gastos[0].IdReg_ClienteGastos;

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

        public void Cliente_Gastos_DEL(List<EnCliente_Gastos> ListEnCliente_Gastos, SqlTransaction tran)

        {
            try
            {
                #region Parametros
                SqlParameter prm_IdReg_ClienteGastos = new SqlParameter();
                SqlParameter prm_CodUsuario = new SqlParameter();
                #endregion Parametros


                #region Values


                prm_IdReg_ClienteGastos.ParameterName = "@IdReg_ClienteGastos";
                prm_IdReg_ClienteGastos.SqlDbType = SqlDbType.Int;
                prm_IdReg_ClienteGastos.Direction = ParameterDirection.Input;
                prm_IdReg_ClienteGastos.Value = ListEnCliente_Gastos[0].IdReg_ClienteGastos;


                prm_CodUsuario.ParameterName = "@CodUsuarioRegistra";
                prm_CodUsuario.SqlDbType = SqlDbType.Int;
                prm_CodUsuario.Direction = ParameterDirection.Input;
                prm_CodUsuario.Value = ListEnCliente_Gastos[0].CodUsuario;


                #endregion Values

                #region Execute
                SqlHelper.ExecuteNonQuery(tran, "CR_Cliente_Gastos_Eliminar",
                                               prm_IdReg_ClienteGastos, prm_CodUsuario
                                               );
                #endregion Execute
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable Cliente_Gastos_Tipo_Tramite_Combo()
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_TIPO_TRAMITE_sp_Listar_Combo";
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



    }
}
