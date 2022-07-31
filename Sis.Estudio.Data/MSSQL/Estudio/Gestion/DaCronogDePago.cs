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
    public class DaCronogDePago : DaConexion
    {
        public void CronogramaPago_INS(List<EnCronogDePago> ListEnCronogDePago, SqlTransaction tran)
        {
            try
            {
                #region Parametros
                SqlParameter prm_NEMPRESA = new SqlParameter();
                SqlParameter prm_CODIGOCLIENTE = new SqlParameter();
                SqlParameter prm_IDREGPRODUCTOS = new SqlParameter();
                SqlParameter prm_NROCUOTAS = new SqlParameter();
                SqlParameter prm_FECHAVENCIMIENTO = new SqlParameter();
                SqlParameter prm_FECHAPAGO = new SqlParameter();
                SqlParameter prm_MONTOCUOTA = new SqlParameter();
                SqlParameter prm_CODESTADOCRONOGRAMA = new SqlParameter();
                SqlParameter prm_CAPITAL = new SqlParameter();
                SqlParameter prm_INTERES = new SqlParameter();
                SqlParameter prm_SALDOCAPITAL = new SqlParameter();
                SqlParameter prm_CODCALIFICACIONSBS = new SqlParameter();
                SqlParameter prm_CODUSUARIO = new SqlParameter();
                #endregion Parametros


                #region Values
                #region nempresa
                prm_NEMPRESA.ParameterName = "@nempresa";
                prm_NEMPRESA.SqlDbType = SqlDbType.Int;
                prm_NEMPRESA.Direction = ParameterDirection.Input;
                prm_NEMPRESA.Value = ListEnCronogDePago[0].NEmpresa;
                #endregion nempresa
                #region CodigoCliente
                prm_CODIGOCLIENTE.ParameterName = "@CodigoCliente";
                prm_CODIGOCLIENTE.SqlDbType = SqlDbType.Int;
                prm_CODIGOCLIENTE.Direction = ParameterDirection.Input;
                prm_CODIGOCLIENTE.Value = ListEnCronogDePago[0].CodigoCliente;
                #endregion CodigoCliente
                #region IdRegProductos
                prm_IDREGPRODUCTOS.ParameterName = "@IdRegProductos";
                prm_IDREGPRODUCTOS.SqlDbType = SqlDbType.Int;
                prm_IDREGPRODUCTOS.Direction = ParameterDirection.Input;
                prm_IDREGPRODUCTOS.Value = ListEnCronogDePago[0].IdRegProductos;
                #endregion IdRegProductos
                #region NroCuotas
                prm_NROCUOTAS.ParameterName = "@NroCuotas";
                prm_NROCUOTAS.SqlDbType = SqlDbType.Int;
                prm_NROCUOTAS.Direction = ParameterDirection.Input;
                prm_NROCUOTAS.Value = ListEnCronogDePago[0].NroCuotas;
                #endregion NroCuotas
                #region FechaVencimiento
                prm_FECHAVENCIMIENTO.ParameterName = "@FechaVencimiento";
                prm_FECHAVENCIMIENTO.SqlDbType = SqlDbType.DateTime;
                prm_FECHAVENCIMIENTO.Direction = ParameterDirection.Input;
                prm_FECHAVENCIMIENTO.Value = ListEnCronogDePago[0].FechaVencimiento;
                #endregion FechaVencimiento
                #region FechaPago
                prm_FECHAPAGO.ParameterName = "@FechaPago";
                prm_FECHAPAGO.SqlDbType = SqlDbType.DateTime;
                prm_FECHAPAGO.Direction = ParameterDirection.Input;
                prm_FECHAPAGO.Value = ListEnCronogDePago[0].FechaPago;
                #endregion FechaPago
                #region MontoCuota
                prm_MONTOCUOTA.ParameterName = "@MontoCuota";
                prm_MONTOCUOTA.SqlDbType = SqlDbType.Decimal;
                prm_MONTOCUOTA.Direction = ParameterDirection.Input;
                prm_MONTOCUOTA.Value = ListEnCronogDePago[0].MontoCuota;
                #endregion MontoCuota
                #region CodEstadoCronograma
                prm_CODESTADOCRONOGRAMA.ParameterName = "@CodEstadoCronograma";
                prm_CODESTADOCRONOGRAMA.SqlDbType = SqlDbType.Int;
                prm_CODESTADOCRONOGRAMA.Direction = ParameterDirection.Input;
                prm_CODESTADOCRONOGRAMA.Value = ListEnCronogDePago[0].CodEstadoCronograma;
                #endregion CodEstadoCronograma
                #region Capital
                prm_CAPITAL.ParameterName = "@Capital";
                prm_CAPITAL.SqlDbType = SqlDbType.Decimal;
                prm_CAPITAL.Direction = ParameterDirection.Input;
                prm_CAPITAL.Value = ListEnCronogDePago[0].Capital;
                #endregion Capital
                #region Interes
                prm_INTERES.ParameterName = "@Interes";
                prm_INTERES.SqlDbType = SqlDbType.Decimal;
                prm_INTERES.Direction = ParameterDirection.Input;
                prm_INTERES.Value = ListEnCronogDePago[0].Interes;
                #endregion Interes
                #region SaldoCapital
                prm_SALDOCAPITAL.ParameterName = "@SaldoCapital";
                prm_SALDOCAPITAL.SqlDbType = SqlDbType.Decimal;
                prm_SALDOCAPITAL.Direction = ParameterDirection.Input;
                prm_SALDOCAPITAL.Value = ListEnCronogDePago[0].SaldoCapital;
                #endregion SaldoCapital
                #region CodCalificacionSBS
                prm_CODCALIFICACIONSBS.ParameterName = "@CodCalificacionSBS";
                prm_CODCALIFICACIONSBS.SqlDbType = SqlDbType.Int;
                prm_CODCALIFICACIONSBS.Direction = ParameterDirection.Input;
                prm_CODCALIFICACIONSBS.Value = ListEnCronogDePago[0].CodCalificacionSBS;
                #endregion CodCalificacionSBS
                #region CodUsuario
                prm_CODUSUARIO.ParameterName = "@CodUsuario";
                prm_CODUSUARIO.SqlDbType = SqlDbType.Int;
                prm_CODUSUARIO.Direction = ParameterDirection.Input;
                prm_CODUSUARIO.Value = ListEnCronogDePago[0].CodUsuario;
                #endregion CodUsuario
                #endregion Values



                #region Execute
                SqlHelper.ExecuteNonQuery(tran, "CR_Cliente_sp_InsertarPRODCron",
                                               prm_NEMPRESA,
                                               prm_CODIGOCLIENTE,
                                               prm_IDREGPRODUCTOS,
                                               prm_NROCUOTAS,
                                               prm_FECHAVENCIMIENTO,
                                               prm_FECHAPAGO,
                                               prm_MONTOCUOTA,
                                               prm_CODESTADOCRONOGRAMA,
                                               prm_CAPITAL,
                                               prm_INTERES,
                                               prm_SALDOCAPITAL,
                                               prm_CODCALIFICACIONSBS,
                                               prm_CODUSUARIO
                                               );
                #endregion Execute
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void CronogramaPago_UPD(List<EnCronogDePago> ListEnCronogDePago, SqlTransaction tran)
        {
            try
            {
                #region Parametros
                SqlParameter prm_IDREG = new SqlParameter();
                SqlParameter prm_NEMPRESA = new SqlParameter();
                SqlParameter prm_CODIGOCLIENTE = new SqlParameter();
                SqlParameter prm_IDREGPRODUCTOS = new SqlParameter();
                SqlParameter prm_NROCUOTAS = new SqlParameter();
                SqlParameter prm_FECHAVENCIMIENTO = new SqlParameter();
                SqlParameter prm_FECHAPAGO = new SqlParameter();
                SqlParameter prm_MONTOCUOTA = new SqlParameter();
                SqlParameter prm_CODESTADOCRONOGRAMA = new SqlParameter();
                SqlParameter prm_CAPITAL = new SqlParameter();
                SqlParameter prm_INTERES = new SqlParameter();
                SqlParameter prm_SALDOCAPITAL = new SqlParameter();
                SqlParameter prm_CODCALIFICACIONSBS = new SqlParameter();
                SqlParameter prm_CODUSUARIO = new SqlParameter();
                #endregion Parametros


                #region Values
                #region IdReg
                prm_IDREG.ParameterName = "@IdReg";
                prm_IDREG.SqlDbType = SqlDbType.Int;
                prm_IDREG.Direction = ParameterDirection.Input;
                prm_IDREG.Value = ListEnCronogDePago[0].IdReg;
                #endregion IdReg
                #region nempresa
                prm_NEMPRESA.ParameterName = "@nempresa";
                prm_NEMPRESA.SqlDbType = SqlDbType.Int;
                prm_NEMPRESA.Direction = ParameterDirection.Input;
                prm_NEMPRESA.Value = ListEnCronogDePago[0].NEmpresa;
                #endregion nempresa
                #region CodigoCliente
                prm_CODIGOCLIENTE.ParameterName = "@CodigoCliente";
                prm_CODIGOCLIENTE.SqlDbType = SqlDbType.Int;
                prm_CODIGOCLIENTE.Direction = ParameterDirection.Input;
                prm_CODIGOCLIENTE.Value = ListEnCronogDePago[0].CodigoCliente;
                #endregion CodigoCliente
                #region IdRegProductos
                prm_IDREGPRODUCTOS.ParameterName = "@IdRegProductos";
                prm_IDREGPRODUCTOS.SqlDbType = SqlDbType.Int;
                prm_IDREGPRODUCTOS.Direction = ParameterDirection.Input;
                prm_IDREGPRODUCTOS.Value = ListEnCronogDePago[0].IdRegProductos;
                #endregion IdRegProductos
                #region NroCuotas
                prm_NROCUOTAS.ParameterName = "@NroCuotas";
                prm_NROCUOTAS.SqlDbType = SqlDbType.Int;
                prm_NROCUOTAS.Direction = ParameterDirection.Input;
                prm_NROCUOTAS.Value = ListEnCronogDePago[0].NroCuotas;
                #endregion NroCuotas
                #region FechaVencimiento
                prm_FECHAVENCIMIENTO.ParameterName = "@FechaVencimiento";
                prm_FECHAVENCIMIENTO.SqlDbType = SqlDbType.DateTime;
                prm_FECHAVENCIMIENTO.Direction = ParameterDirection.Input;
                prm_FECHAVENCIMIENTO.Value = ListEnCronogDePago[0].FechaVencimiento;
                #endregion FechaVencimiento
                #region FechaPago
                prm_FECHAPAGO.ParameterName = "@FechaPago";
                prm_FECHAPAGO.SqlDbType = SqlDbType.DateTime;
                prm_FECHAPAGO.Direction = ParameterDirection.Input;
                prm_FECHAPAGO.Value = ListEnCronogDePago[0].FechaPago;
                #endregion FechaPago
                #region MontoCuota
                prm_MONTOCUOTA.ParameterName = "@MontoCuota";
                prm_MONTOCUOTA.SqlDbType = SqlDbType.Decimal;
                prm_MONTOCUOTA.Direction = ParameterDirection.Input;
                prm_MONTOCUOTA.Value = ListEnCronogDePago[0].MontoCuota;
                #endregion MontoCuota
                #region CodEstadoCronograma
                prm_CODESTADOCRONOGRAMA.ParameterName = "@CodEstadoCronograma";
                prm_CODESTADOCRONOGRAMA.SqlDbType = SqlDbType.Int;
                prm_CODESTADOCRONOGRAMA.Direction = ParameterDirection.Input;
                prm_CODESTADOCRONOGRAMA.Value = ListEnCronogDePago[0].CodEstadoCronograma;
                #endregion CodEstadoCronograma
                #region Capital
                prm_CAPITAL.ParameterName = "@Capital";
                prm_CAPITAL.SqlDbType = SqlDbType.Decimal;
                prm_CAPITAL.Direction = ParameterDirection.Input;
                prm_CAPITAL.Value = ListEnCronogDePago[0].Capital;
                #endregion Capital
                #region Interes
                prm_INTERES.ParameterName = "@Interes";
                prm_INTERES.SqlDbType = SqlDbType.Decimal;
                prm_INTERES.Direction = ParameterDirection.Input;
                prm_INTERES.Value = ListEnCronogDePago[0].Interes;
                #endregion Interes
                #region SaldoCapital
                prm_SALDOCAPITAL.ParameterName = "@SaldoCapital";
                prm_SALDOCAPITAL.SqlDbType = SqlDbType.Decimal;
                prm_SALDOCAPITAL.Direction = ParameterDirection.Input;
                prm_SALDOCAPITAL.Value = ListEnCronogDePago[0].SaldoCapital;
                #endregion SaldoCapital
                #region CodCalificacionSBS
                prm_CODCALIFICACIONSBS.ParameterName = "@CodCalificacionSBS";
                prm_CODCALIFICACIONSBS.SqlDbType = SqlDbType.Int;
                prm_CODCALIFICACIONSBS.Direction = ParameterDirection.Input;
                prm_CODCALIFICACIONSBS.Value = ListEnCronogDePago[0].CodCalificacionSBS;
                #endregion CodCalificacionSBS
                #region CodUsuario
                prm_CODUSUARIO.ParameterName = "@CodUsuario";
                prm_CODUSUARIO.SqlDbType = SqlDbType.Int;
                prm_CODUSUARIO.Direction = ParameterDirection.Input;
                prm_CODUSUARIO.Value = ListEnCronogDePago[0].CodUsuario;
                #endregion CodUsuario
                #endregion Values



                #region Execute
                SqlHelper.ExecuteNonQuery(tran, "CR_Cliente_sp_ModificarPRODCron",
                                               prm_IDREG,
                                               prm_NEMPRESA,
                                               prm_CODIGOCLIENTE,
                                               prm_IDREGPRODUCTOS,
                                               prm_NROCUOTAS,
                                               prm_FECHAVENCIMIENTO,
                                               prm_FECHAPAGO,
                                               prm_MONTOCUOTA,
                                               prm_CODESTADOCRONOGRAMA,
                                               prm_CAPITAL,
                                               prm_INTERES,
                                               prm_SALDOCAPITAL,
                                               prm_CODCALIFICACIONSBS,
                                               prm_CODUSUARIO
                                               );
                #endregion Execute
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable CronogramaPago_Listar(List<EnCronogDePago> ListEnCronogDePago)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "CR_Cliente_sp_CargaClientePRODCron";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[3];

                paramsToStore[0] = new SqlParameter("@NEMPRESA", SqlDbType.Int);
                paramsToStore[0].Value = ListEnCronogDePago[0].NEmpresa;

                paramsToStore[1] = new SqlParameter("@CodigoCliente", SqlDbType.Int);
                paramsToStore[1].Value = ListEnCronogDePago[0].CodigoCliente;

                paramsToStore[2] = new SqlParameter("@IdRegPRODUCTOS", SqlDbType.Decimal);
                paramsToStore[2].Value = ListEnCronogDePago[0].IdRegPRODUCTOS;

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
        public DataTable CronogramaPago_Listar_Reg(List<EnCronogDePago> ListEnCronogDePago)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

               
                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "CR_Cliente_sp_CargaClientePRODCronREG";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];

                paramsToStore[0] = new SqlParameter("@NEMPRESA", SqlDbType.Int);
                paramsToStore[0].Value = ListEnCronogDePago[0].NEmpresa;

                paramsToStore[1] = new SqlParameter("@IdReg", SqlDbType.Int);
                paramsToStore[1].Value = ListEnCronogDePago[0].IdReg;

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
