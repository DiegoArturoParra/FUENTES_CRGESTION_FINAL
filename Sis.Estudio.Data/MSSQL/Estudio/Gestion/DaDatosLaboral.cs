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
    public class DaDatosLaboral : DaConexion
    {
        public void DatosLaboral_INS(List<EnDatosLaboral> ListEnDatosLaboral, SqlTransaction tran)
        {
            try
            {
                #region Parametros
                SqlParameter prm_NEMPRESA = new SqlParameter();
                SqlParameter prm_CODIGOCLIENTE = new SqlParameter();
                SqlParameter prm_RUC = new SqlParameter();
                SqlParameter prm_EMPRESA = new SqlParameter();
                SqlParameter prm_CARGO = new SqlParameter();
                SqlParameter prm_FECHAINGRESO = new SqlParameter();
                SqlParameter prm_CODSITLAB = new SqlParameter();
                SqlParameter prm_SUELDO = new SqlParameter();
                SqlParameter prm_TELEF = new SqlParameter();
                SqlParameter prm_ANEXO = new SqlParameter();
                SqlParameter prm_OBSERVACION = new SqlParameter();
                SqlParameter prm_ESTADO = new SqlParameter();
                SqlParameter prm_CODUSUARIO = new SqlParameter();
                #endregion Parametros

                #region Values
                #region nempresa
                prm_NEMPRESA.ParameterName = "@nempresa";
                prm_NEMPRESA.SqlDbType = SqlDbType.Int;
                prm_NEMPRESA.Direction = ParameterDirection.Input;
                prm_NEMPRESA.Value = ListEnDatosLaboral[0].nempresa;
                #endregion nempresa
                #region CodigoCliente
                prm_CODIGOCLIENTE.ParameterName = "@CodigoCliente";
                prm_CODIGOCLIENTE.SqlDbType = SqlDbType.Int;
                prm_CODIGOCLIENTE.Direction = ParameterDirection.Input;
                prm_CODIGOCLIENTE.Value = ListEnDatosLaboral[0].CodigoCliente;
                #endregion CodigoCliente
                #region RUC
                prm_RUC.ParameterName = "@RUC";
                prm_RUC.SqlDbType = SqlDbType.Char;
                prm_RUC.Direction = ParameterDirection.Input;
                prm_RUC.Size = 11;
                prm_RUC.Value = ListEnDatosLaboral[0].RUC;
                #endregion RUC
                #region Empresa
                prm_EMPRESA.ParameterName = "@Empresa";
                prm_EMPRESA.SqlDbType = SqlDbType.VarChar;
                prm_EMPRESA.Direction = ParameterDirection.Input;
                prm_EMPRESA.Size = 120;
                prm_EMPRESA.Value = ListEnDatosLaboral[0].Empresa;
                #endregion Empresa
                #region Cargo
                prm_CARGO.ParameterName = "@Cargo";
                prm_CARGO.SqlDbType = SqlDbType.VarChar;
                prm_CARGO.Direction = ParameterDirection.Input;
                prm_CARGO.Size = 60;
                prm_CARGO.Value = ListEnDatosLaboral[0].Cargo;
                #endregion Cargo
                #region FechaIngreso
                prm_FECHAINGRESO.ParameterName = "@FechaIngreso";
                prm_FECHAINGRESO.SqlDbType = SqlDbType.Char;
                prm_FECHAINGRESO.Direction = ParameterDirection.Input;
                prm_FECHAINGRESO.Size = 8;
                prm_FECHAINGRESO.Value = ListEnDatosLaboral[0].FechaIngreso;
                #endregion FechaIngreso
                #region CodSitLab
                prm_CODSITLAB.ParameterName = "@CodSitLab";
                prm_CODSITLAB.SqlDbType = SqlDbType.Int;
                prm_CODSITLAB.Direction = ParameterDirection.Input;
                prm_CODSITLAB.Value = ListEnDatosLaboral[0].CodSitLab;
                #endregion CodSitLab
                #region Sueldo
                prm_SUELDO.ParameterName = "@Sueldo";
                prm_SUELDO.SqlDbType = SqlDbType.Decimal;
                prm_SUELDO.Direction = ParameterDirection.Input;
                prm_SUELDO.Value = ListEnDatosLaboral[0].Sueldo;
                #endregion Sueldo
                #region Telef
                prm_TELEF.ParameterName = "@Telef";
                prm_TELEF.SqlDbType = SqlDbType.VarChar;
                prm_TELEF.Direction = ParameterDirection.Input;
                prm_TELEF.Size = 20;
                prm_TELEF.Value = ListEnDatosLaboral[0].Telef;
                #endregion Telef
                #region Anexo
                prm_ANEXO.ParameterName = "@Anexo";
                prm_ANEXO.SqlDbType = SqlDbType.VarChar;
                prm_ANEXO.Direction = ParameterDirection.Input;
                prm_ANEXO.Size = 8;
                prm_ANEXO.Value = ListEnDatosLaboral[0].Anexo;
                #endregion Anexo
                #region Observacion
                prm_OBSERVACION.ParameterName = "@Observacion";
                prm_OBSERVACION.SqlDbType = SqlDbType.VarChar;
                prm_OBSERVACION.Direction = ParameterDirection.Input;
                prm_OBSERVACION.Size = 200;
                prm_OBSERVACION.Value = ListEnDatosLaboral[0].Observacion;
                #endregion Observacion
                #region Estado
                prm_ESTADO.ParameterName = "@Estado";
                prm_ESTADO.SqlDbType = SqlDbType.Char;
                prm_ESTADO.Direction = ParameterDirection.Input;
                prm_ESTADO.Size = 1;
                prm_ESTADO.Value = ListEnDatosLaboral[0].Estado;
                #endregion Estado
                #region CodUsuario
                prm_CODUSUARIO.ParameterName = "@CodUsuario";
                prm_CODUSUARIO.SqlDbType = SqlDbType.Int;
                prm_CODUSUARIO.Direction = ParameterDirection.Input;
                prm_CODUSUARIO.Value = ListEnDatosLaboral[0].CodUsuario;
                #endregion CodUsuario
                #endregion Values

                #region Execute
                SqlHelper.ExecuteNonQuery(tran, "CR_Cliente_sp_InsertarLab",
                                               prm_NEMPRESA,
                                               prm_CODIGOCLIENTE,
                                               prm_RUC,
                                               prm_EMPRESA,
                                               prm_CARGO,
                                               prm_FECHAINGRESO,
                                               prm_CODSITLAB,
                                               prm_SUELDO,
                                               prm_TELEF,
                                               prm_ANEXO,
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
        public void DatosLaboral_UPD(List<EnDatosLaboral> ListEnDatosLaboral, SqlTransaction tran)
        {
            try
            {
                #region Parametros
                SqlParameter prm_NEMPRESA = new SqlParameter();
                SqlParameter prm_IDREG = new SqlParameter();
                SqlParameter prm_RUC = new SqlParameter();
                SqlParameter prm_EMPRESA = new SqlParameter();
                SqlParameter prm_CARGO = new SqlParameter();
                SqlParameter prm_FECHAINGRESO = new SqlParameter();
                SqlParameter prm_CODSITLAB = new SqlParameter();
                SqlParameter prm_SUELDO = new SqlParameter();
                SqlParameter prm_TELEF = new SqlParameter();
                SqlParameter prm_ANEXO = new SqlParameter();
                SqlParameter prm_OBSERVACION = new SqlParameter();
                SqlParameter prm_ESTADO = new SqlParameter();
                SqlParameter prm_CODUSUARIO = new SqlParameter();
                #endregion Parametros


                #region Values
                #region NEMPRESA
                prm_NEMPRESA.ParameterName = "@NEMPRESA";
                prm_NEMPRESA.SqlDbType = SqlDbType.Int;
                prm_NEMPRESA.Direction = ParameterDirection.Input;
                prm_NEMPRESA.Value = ListEnDatosLaboral[0].NEMPRESA;
                #endregion NEMPRESA
                #region IdReg
                prm_IDREG.ParameterName = "@IdReg";
                prm_IDREG.SqlDbType = SqlDbType.Int;
                prm_IDREG.Direction = ParameterDirection.Input;
                prm_IDREG.Value = ListEnDatosLaboral[0].IdReg;
                #endregion IdReg
                #region RUC
                prm_RUC.ParameterName = "@RUC";
                prm_RUC.SqlDbType = SqlDbType.Char;
                prm_RUC.Direction = ParameterDirection.Input;
                prm_RUC.Size = 11;
                prm_RUC.Value = ListEnDatosLaboral[0].RUC;
                #endregion RUC
                #region Empresa
                prm_EMPRESA.ParameterName = "@Empresa";
                prm_EMPRESA.SqlDbType = SqlDbType.VarChar;
                prm_EMPRESA.Direction = ParameterDirection.Input;
                prm_EMPRESA.Size = 120;
                prm_EMPRESA.Value = ListEnDatosLaboral[0].Empresa;
                #endregion Empresa
                #region Cargo
                prm_CARGO.ParameterName = "@Cargo";
                prm_CARGO.SqlDbType = SqlDbType.VarChar;
                prm_CARGO.Direction = ParameterDirection.Input;
                prm_CARGO.Size = 60;
                prm_CARGO.Value = ListEnDatosLaboral[0].Cargo;
                #endregion Cargo
                #region FechaIngreso
                prm_FECHAINGRESO.ParameterName = "@FechaIngreso";
                prm_FECHAINGRESO.SqlDbType = SqlDbType.Char;
                prm_FECHAINGRESO.Direction = ParameterDirection.Input;
                prm_FECHAINGRESO.Size = 10;
                prm_FECHAINGRESO.Value = ListEnDatosLaboral[0].FechaIngreso;
                #endregion FechaIngreso
                #region CodSitLab
                prm_CODSITLAB.ParameterName = "@CodSitLab";
                prm_CODSITLAB.SqlDbType = SqlDbType.Int;
                prm_CODSITLAB.Direction = ParameterDirection.Input;
                prm_CODSITLAB.Value = ListEnDatosLaboral[0].CodSitLab;
                #endregion CodSitLab
                #region Sueldo
                prm_SUELDO.ParameterName = "@Sueldo";
                prm_SUELDO.SqlDbType = SqlDbType.Decimal;
                prm_SUELDO.Direction = ParameterDirection.Input;
                prm_SUELDO.Value = ListEnDatosLaboral[0].Sueldo;
                #endregion Sueldo
                #region Telef
                prm_TELEF.ParameterName = "@Telef";
                prm_TELEF.SqlDbType = SqlDbType.VarChar;
                prm_TELEF.Direction = ParameterDirection.Input;
                prm_TELEF.Size = 20;
                prm_TELEF.Value = ListEnDatosLaboral[0].Telef;
                #endregion Telef
                #region Anexo
                prm_ANEXO.ParameterName = "@Anexo";
                prm_ANEXO.SqlDbType = SqlDbType.VarChar;
                prm_ANEXO.Direction = ParameterDirection.Input;
                prm_ANEXO.Size = 8;
                prm_ANEXO.Value = ListEnDatosLaboral[0].Anexo;
                #endregion Anexo
                #region Observacion
                prm_OBSERVACION.ParameterName = "@Observacion";
                prm_OBSERVACION.SqlDbType = SqlDbType.VarChar;
                prm_OBSERVACION.Direction = ParameterDirection.Input;
                prm_OBSERVACION.Size = 200;
                prm_OBSERVACION.Value = ListEnDatosLaboral[0].Observacion;
                #endregion Observacion
                #region Estado
                prm_ESTADO.ParameterName = "@Estado";
                prm_ESTADO.SqlDbType = SqlDbType.Char;
                prm_ESTADO.Direction = ParameterDirection.Input;
                prm_ESTADO.Size = 1;
                prm_ESTADO.Value = ListEnDatosLaboral[0].Estado;
                #endregion Estado
                #region CodUsuario
                prm_CODUSUARIO.ParameterName = "@CodUsuario";
                prm_CODUSUARIO.SqlDbType = SqlDbType.Int;
                prm_CODUSUARIO.Direction = ParameterDirection.Input;
                prm_CODUSUARIO.Value = ListEnDatosLaboral[0].CodUsuario;
                #endregion CodUsuario
                #endregion Values



                #region Execute
                SqlHelper.ExecuteNonQuery(tran, "CR_Cliente_sp_ModificarLab",
                                               prm_NEMPRESA,
                                               prm_IDREG,
                                               prm_RUC,
                                               prm_EMPRESA,
                                               prm_CARGO,
                                               prm_FECHAINGRESO,
                                               prm_CODSITLAB,
                                               prm_SUELDO,
                                               prm_TELEF,
                                               prm_ANEXO,
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
        public DataTable DatosLaboral_Lista(List<EnDatosLaboral> ListEnDatosLaboral)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {


                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "CR_Cliente_sp_CargaClienteLab";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];

                paramsToStore[0] = new SqlParameter("@NEMPRESA", SqlDbType.Int);
                paramsToStore[0].Value = ListEnDatosLaboral[0].NEMPRESA;

                paramsToStore[1] = new SqlParameter("@CodigoCliente", SqlDbType.Int);
                paramsToStore[1].Value = ListEnDatosLaboral[0].CodigoCliente;

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
        public DataTable DatosLaboral_Lista_Reg(List<EnDatosLaboral> ListEnDatosLaboral)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "CR_Cliente_sp_CargaClienteLabREG";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];

                paramsToStore[0] = new SqlParameter("@NEMPRESA", SqlDbType.Int);
                paramsToStore[0].Value = ListEnDatosLaboral[0].NEMPRESA;

                paramsToStore[1] = new SqlParameter("@IDReg", SqlDbType.Int);
                paramsToStore[1].Value = ListEnDatosLaboral[0].IdReg;

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
