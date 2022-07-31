﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Sis.Estudio.Entity;

namespace Sis.Estudio.Data.MSSQL.Estudio
{
    public class DaDirecCliente : DaConexion
    {

        public void DirecCliente_INS(List<EnDirecCliente> ListEnDirecCliente, SqlTransaction tran)
        {
            try
            {
                #region Parametros
                SqlParameter prm_NEMPRESA = new SqlParameter();
                SqlParameter prm_CODIGOCLIENTE = new SqlParameter();
                SqlParameter prm_CODTIPODIR = new SqlParameter();
                SqlParameter prm_DIR = new SqlParameter();
                SqlParameter prm_UBIGEO = new SqlParameter();
                SqlParameter prm_REFERENCIA = new SqlParameter();
                SqlParameter prm_GEOX = new SqlParameter();
                SqlParameter prm_GEOY = new SqlParameter();
                SqlParameter prm_CODESTADODIR = new SqlParameter();
                SqlParameter prm_ORDEN = new SqlParameter();
                SqlParameter prm_CODUSUARIO = new SqlParameter();
                #endregion Parametros
                #region Values
                #region NEMPRESA
                prm_NEMPRESA.ParameterName = "@NEMPRESA";
                prm_NEMPRESA.SqlDbType = SqlDbType.Int;
                prm_NEMPRESA.Direction = ParameterDirection.Input;
                prm_NEMPRESA.Value = ListEnDirecCliente[0].NEMPRESA;
                #endregion NEMPRESA
                #region CodigoCliente
                prm_CODIGOCLIENTE.ParameterName = "@CodigoCliente";
                prm_CODIGOCLIENTE.SqlDbType = SqlDbType.Int;
                prm_CODIGOCLIENTE.Direction = ParameterDirection.Input;
                prm_CODIGOCLIENTE.Value = ListEnDirecCliente[0].CodigoCliente;
                #endregion CodigoCliente
                #region CodTipoDir
                prm_CODTIPODIR.ParameterName = "@CodTipoDir";
                prm_CODTIPODIR.SqlDbType = SqlDbType.Int;
                prm_CODTIPODIR.Direction = ParameterDirection.Input;
                prm_CODTIPODIR.Value = ListEnDirecCliente[0].CodTipoDir;
                #endregion CodTipoDir
                #region Dir
                prm_DIR.ParameterName = "@Dir";
                prm_DIR.SqlDbType = SqlDbType.VarChar;
                prm_DIR.Direction = ParameterDirection.Input;
                prm_DIR.Size = 180;
                prm_DIR.Value = ListEnDirecCliente[0].Dir;
                #endregion Dir
                #region ubigeo
                prm_UBIGEO.ParameterName = "@ubigeo";
                prm_UBIGEO.SqlDbType = SqlDbType.Char;
                prm_UBIGEO.Direction = ParameterDirection.Input;
                prm_UBIGEO.Size = 6;
                prm_UBIGEO.Value = ListEnDirecCliente[0].ubigeo;
                #endregion ubigeo
                #region Referencia
                prm_REFERENCIA.ParameterName = "@Referencia";
                prm_REFERENCIA.SqlDbType = SqlDbType.VarChar;
                prm_REFERENCIA.Direction = ParameterDirection.Input;
                prm_REFERENCIA.Size = 180;
                prm_REFERENCIA.Value = ListEnDirecCliente[0].Referencia;
                #endregion Referencia
                #region GeoX
                prm_GEOX.ParameterName = "@GeoX";
                prm_GEOX.SqlDbType = SqlDbType.Decimal;
                prm_GEOX.Direction = ParameterDirection.Input;
                prm_GEOX.Value = ListEnDirecCliente[0].GeoX;
                #endregion GeoX
                #region GeoY
                prm_GEOY.ParameterName = "@GeoY";
                prm_GEOY.SqlDbType = SqlDbType.Decimal;
                prm_GEOY.Direction = ParameterDirection.Input;
                prm_GEOY.Value = ListEnDirecCliente[0].GeoY;
                #endregion GeoY
                #region CodEstadoDir
                prm_CODESTADODIR.ParameterName = "@CodEstadoDir";
                prm_CODESTADODIR.SqlDbType = SqlDbType.Int;
                prm_CODESTADODIR.Direction = ParameterDirection.Input;
                prm_CODESTADODIR.Value = ListEnDirecCliente[0].CodEstadoDir;
                #endregion CodEstadoDir
                #region Orden
                prm_ORDEN.ParameterName = "@Orden";
                prm_ORDEN.SqlDbType = SqlDbType.Int;
                prm_ORDEN.Direction = ParameterDirection.Input;
                prm_ORDEN.Value = ListEnDirecCliente[0].Orden;
                #endregion Orden
                #region CodUsuario
                prm_CODUSUARIO.ParameterName = "@CodUsuario";
                prm_CODUSUARIO.SqlDbType = SqlDbType.Int;
                prm_CODUSUARIO.Direction = ParameterDirection.Input;
                prm_CODUSUARIO.Value = ListEnDirecCliente[0].CodUsuario;
                #endregion CodUsuario
                #endregion Values
                #region Execute
                SqlHelper.ExecuteNonQuery(tran, "CR_Cliente_sp_InsertarDir",
                                               prm_NEMPRESA,
                                               prm_CODIGOCLIENTE,
                                               prm_CODTIPODIR,
                                               prm_DIR,
                                               prm_UBIGEO,
                                               prm_REFERENCIA,
                                               prm_GEOX,
                                               prm_GEOY,
                                               prm_CODESTADODIR,
                                               prm_ORDEN,
                                               prm_CODUSUARIO
                                               );
                #endregion Execute
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DirecCliente_UPD(List<EnDirecCliente> ListEnDirecCliente, SqlTransaction tran)
        {
            try
            {
                #region Parametros
                SqlParameter prm_NEMPRESA = new SqlParameter();
                SqlParameter prm_IDREG = new SqlParameter();
                SqlParameter prm_CODTIPODIR = new SqlParameter();
                SqlParameter prm_DIR = new SqlParameter();
                SqlParameter prm_UBIGEO = new SqlParameter();
                SqlParameter prm_REFERENCIA = new SqlParameter();
                SqlParameter prm_GEOX = new SqlParameter();
                SqlParameter prm_GEOY = new SqlParameter();
                SqlParameter prm_CODESTADODIR = new SqlParameter();
                SqlParameter prm_ORDEN = new SqlParameter();
                SqlParameter prm_CODUSUARIO = new SqlParameter();
                #endregion Parametros


                #region Values
                #region NEMPRESA
                prm_NEMPRESA.ParameterName = "@NEMPRESA";
                prm_NEMPRESA.SqlDbType = SqlDbType.Int;
                prm_NEMPRESA.Direction = ParameterDirection.Input;
                prm_NEMPRESA.Value = ListEnDirecCliente[0].NEMPRESA;
                #endregion NEMPRESA
                #region IdReg
                prm_IDREG.ParameterName = "@IdReg";
                prm_IDREG.SqlDbType = SqlDbType.Int;
                prm_IDREG.Direction = ParameterDirection.Input;
                prm_IDREG.Value = ListEnDirecCliente[0].IdReg;
                #endregion IdReg
                #region CodTipoDir
                prm_CODTIPODIR.ParameterName = "@CodTipoDir";
                prm_CODTIPODIR.SqlDbType = SqlDbType.Int;
                prm_CODTIPODIR.Direction = ParameterDirection.Input;
                prm_CODTIPODIR.Value = ListEnDirecCliente[0].CodTipoDir;
                #endregion CodTipoDir
                #region Dir
                prm_DIR.ParameterName = "@Dir";
                prm_DIR.SqlDbType = SqlDbType.VarChar;
                prm_DIR.Direction = ParameterDirection.Input;
                prm_DIR.Size = 180;
                prm_DIR.Value = ListEnDirecCliente[0].Dir;
                #endregion Dir
                #region ubigeo
                prm_UBIGEO.ParameterName = "@ubigeo";
                prm_UBIGEO.SqlDbType = SqlDbType.Char;
                prm_UBIGEO.Direction = ParameterDirection.Input;
                prm_UBIGEO.Size = 6;
                prm_UBIGEO.Value = ListEnDirecCliente[0].ubigeo;
                #endregion ubigeo
                #region Referencia
                prm_REFERENCIA.ParameterName = "@Referencia";
                prm_REFERENCIA.SqlDbType = SqlDbType.VarChar;
                prm_REFERENCIA.Direction = ParameterDirection.Input;
                prm_REFERENCIA.Size = 180;
                prm_REFERENCIA.Value = ListEnDirecCliente[0].Referencia;
                #endregion Referencia
                #region GeoX
                prm_GEOX.ParameterName = "@GeoX";
                prm_GEOX.SqlDbType = SqlDbType.Decimal;
                prm_GEOX.Direction = ParameterDirection.Input;
                prm_GEOX.Value = ListEnDirecCliente[0].GeoX;
                #endregion GeoX
                #region GeoY
                prm_GEOY.ParameterName = "@GeoY";
                prm_GEOY.SqlDbType = SqlDbType.Decimal;
                prm_GEOY.Direction = ParameterDirection.Input;
                prm_GEOY.Value = ListEnDirecCliente[0].GeoY;
                #endregion GeoY
                #region CodEstadoDir
                prm_CODESTADODIR.ParameterName = "@CodEstadoDir";
                prm_CODESTADODIR.SqlDbType = SqlDbType.Int;
                prm_CODESTADODIR.Direction = ParameterDirection.Input;
                prm_CODESTADODIR.Value = ListEnDirecCliente[0].CodEstadoDir;
                #endregion CodEstadoDir
                #region Orden
                prm_ORDEN.ParameterName = "@Orden";
                prm_ORDEN.SqlDbType = SqlDbType.Int;
                prm_ORDEN.Direction = ParameterDirection.Input;
                prm_ORDEN.Value = ListEnDirecCliente[0].Orden;
                #endregion Orden
                #region CodUsuario
                prm_CODUSUARIO.ParameterName = "@CodUsuario";
                prm_CODUSUARIO.SqlDbType = SqlDbType.Int;
                prm_CODUSUARIO.Direction = ParameterDirection.Input;
                prm_CODUSUARIO.Value = ListEnDirecCliente[0].CodUsuario;
                #endregion CodUsuario
                #endregion Values



                #region Execute
                SqlHelper.ExecuteNonQuery(tran, "CR_Cliente_sp_ModificarDir",
                                               prm_NEMPRESA,
                                               prm_IDREG,
                                               prm_CODTIPODIR,
                                               prm_DIR,
                                               prm_UBIGEO,
                                               prm_REFERENCIA,
                                               prm_GEOX,
                                               prm_GEOY,
                                               prm_CODESTADODIR,
                                               prm_ORDEN,
                                               prm_CODUSUARIO
                                               );
                #endregion Execute
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable DirecCliente_Lista(List<EnDirecCliente> ListEnDirecCliente)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "CR_Cliente_sp_CargaClienteDir";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];

                paramsToStore[0] = new SqlParameter("@NEMPRESA", SqlDbType.Int);
                paramsToStore[0].Value = ListEnDirecCliente[0].NEMPRESA;

                paramsToStore[1] = new SqlParameter("@CodigoCliente", SqlDbType.Int);
                paramsToStore[1].Value = ListEnDirecCliente[0].CodigoCliente;

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
        public DataTable DirecCliente_Lista_Reg(List<EnDirecCliente> ListEnDirecCliente)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "CR_Cliente_sp_CargaClienteDirREG";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];

                paramsToStore[0] = new SqlParameter("@NEMPRESA", SqlDbType.Int);
                paramsToStore[0].Value = ListEnDirecCliente[0].NEMPRESA;

                paramsToStore[1] = new SqlParameter("@IDReg", SqlDbType.Int);
                paramsToStore[1].Value = ListEnDirecCliente[0].IdReg;

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
