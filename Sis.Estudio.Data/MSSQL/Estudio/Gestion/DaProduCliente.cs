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
    public class DaProduCliente : DaConexion
    {
        public void Cliente_Productos_INS(List<EnProduCliente> ListEnProduCliente, SqlTransaction tran)
        {
            try
            {
                #region Parametros
                SqlParameter prm_NEMPRESA = new SqlParameter();
                SqlParameter prm_CODIGOCLIENTE = new SqlParameter();
                SqlParameter prm_CODPRODUCTO = new SqlParameter();
                SqlParameter prm_CODSUBPRODUCTO = new SqlParameter();
                SqlParameter prm_CODIGOINTERNO = new SqlParameter();
                SqlParameter prm_SALDOCAPITAL = new SqlParameter();
                SqlParameter prm_MONEDA = new SqlParameter();
                SqlParameter prm_CALIFRIESGO = new SqlParameter();
                SqlParameter prm_PORPROVISION = new SqlParameter();
                SqlParameter prm_CODSUCURSAL = new SqlParameter();
                SqlParameter prm_CODSECTORISTA = new SqlParameter();
                SqlParameter prm_CODZONA = new SqlParameter();
                SqlParameter prm_CODGERENTE = new SqlParameter();
                SqlParameter prm_dias_mora = new SqlParameter();
                SqlParameter prm_ESTADO = new SqlParameter();
                SqlParameter prm_CODUSUARIO = new SqlParameter();
                SqlParameter prm_MONTODESEMB = new SqlParameter();
                SqlParameter prm_TEA = new SqlParameter();
                SqlParameter prm_TOTCUOTASPACT = new SqlParameter();
                SqlParameter prm_MONTOCUOTA = new SqlParameter();
                #endregion Parametros


                #region Values
                #region nempresa
                prm_NEMPRESA.ParameterName = "@nempresa";
                prm_NEMPRESA.SqlDbType = SqlDbType.Int;
                prm_NEMPRESA.Direction = ParameterDirection.Input;
                prm_NEMPRESA.Value = ListEnProduCliente[0].nempresa;
                #endregion nempresa
                #region CodigoCliente
                prm_CODIGOCLIENTE.ParameterName = "@CodigoCliente";
                prm_CODIGOCLIENTE.SqlDbType = SqlDbType.Int;
                prm_CODIGOCLIENTE.Direction = ParameterDirection.Input;
                prm_CODIGOCLIENTE.Value = ListEnProduCliente[0].CodigoCliente;
                #endregion CodigoCliente
                #region CodProducto
                prm_CODPRODUCTO.ParameterName = "@CodProducto";
                prm_CODPRODUCTO.SqlDbType = SqlDbType.Int;
                prm_CODPRODUCTO.Direction = ParameterDirection.Input;
                prm_CODPRODUCTO.Value = ListEnProduCliente[0].CodProducto;
                #endregion CodProducto
                #region CodSubProducto
                prm_CODSUBPRODUCTO.ParameterName = "@CodSubProducto";
                prm_CODSUBPRODUCTO.SqlDbType = SqlDbType.Int;
                prm_CODSUBPRODUCTO.Direction = ParameterDirection.Input;
                prm_CODSUBPRODUCTO.Value = ListEnProduCliente[0].CodSubProducto;
                #endregion CodSubProducto
                #region CodigoInterno
                prm_CODIGOINTERNO.ParameterName = "@CodigoInterno";
                prm_CODIGOINTERNO.SqlDbType = SqlDbType.Int;
                prm_CODIGOINTERNO.Direction = ParameterDirection.Input;
                prm_CODIGOINTERNO.Value = ListEnProduCliente[0].CodigoInterno;
                #endregion CodigoInterno
                #region SaldoCapital
                prm_SALDOCAPITAL.ParameterName = "@SaldoCapital";
                prm_SALDOCAPITAL.SqlDbType = SqlDbType.Decimal;
                prm_SALDOCAPITAL.Direction = ParameterDirection.Input;
                prm_SALDOCAPITAL.Value = ListEnProduCliente[0].SaldoCapital;
                #endregion SaldoCapital
                #region Moneda
                prm_MONEDA.ParameterName = "@Moneda";
                prm_MONEDA.SqlDbType = SqlDbType.Char;
                prm_MONEDA.Direction = ParameterDirection.Input;
                prm_MONEDA.Size = 1;
                prm_MONEDA.Value = ListEnProduCliente[0].Moneda;
                #endregion Moneda
                #region CalifRiesgo
                prm_CALIFRIESGO.ParameterName = "@CalifRiesgo";
                prm_CALIFRIESGO.SqlDbType = SqlDbType.VarChar;
                prm_CALIFRIESGO.Direction = ParameterDirection.Input;
                prm_CALIFRIESGO.Size = 60;
                prm_CALIFRIESGO.Value = ListEnProduCliente[0].CalifRiesgo;
                #endregion CalifRiesgo
                #region PorProvision
                prm_PORPROVISION.ParameterName = "@PorProvision";
                prm_PORPROVISION.SqlDbType = SqlDbType.VarChar;
                prm_PORPROVISION.Direction = ParameterDirection.Input;
                prm_PORPROVISION.Size = 60;
                prm_PORPROVISION.Value = ListEnProduCliente[0].PorProvision;
                #endregion PorProvision
                #region CodSucursal
                prm_CODSUCURSAL.ParameterName = "@CodSucursal";
                prm_CODSUCURSAL.SqlDbType = SqlDbType.Int;
                prm_CODSUCURSAL.Direction = ParameterDirection.Input;
                prm_CODSUCURSAL.Value = ListEnProduCliente[0].CodSucursal;
                #endregion CodSucursal
                #region CodSectorista
                prm_CODSECTORISTA.ParameterName = "@CodSectorista";
                prm_CODSECTORISTA.SqlDbType = SqlDbType.Int;
                prm_CODSECTORISTA.Direction = ParameterDirection.Input;
                prm_CODSECTORISTA.Value = ListEnProduCliente[0].CodSectorista;
                #endregion CodSectorista
                #region CodZona
                prm_CODZONA.ParameterName = "@CodZona";
                prm_CODZONA.SqlDbType = SqlDbType.Int;
                prm_CODZONA.Direction = ParameterDirection.Input;
                prm_CODZONA.Value = ListEnProduCliente[0].CodZona;
                #endregion CodZona
                #region CodGerente
                prm_CODGERENTE.ParameterName = "@CodGerente";
                prm_CODGERENTE.SqlDbType = SqlDbType.Int;
                prm_CODGERENTE.Direction = ParameterDirection.Input;
                prm_CODGERENTE.Value = ListEnProduCliente[0].CodGerente;
                #endregion CodGerente
                #region dias_mora
                prm_dias_mora.ParameterName = "@dias_mora";
                prm_dias_mora.SqlDbType = SqlDbType.Int;
                prm_dias_mora.Direction = ParameterDirection.Input;
                prm_dias_mora.Value = ListEnProduCliente[0].dias_mora;
                #endregion dias_mora
                #region Estado
                prm_ESTADO.ParameterName = "@Estado";
                prm_ESTADO.SqlDbType = SqlDbType.Char;
                prm_ESTADO.Direction = ParameterDirection.Input;
                prm_ESTADO.Size = 1;
                prm_ESTADO.Value = ListEnProduCliente[0].Estado;
                #endregion Estado
                #region CodUsuario
                prm_CODUSUARIO.ParameterName = "@CodUsuario";
                prm_CODUSUARIO.SqlDbType = SqlDbType.Int;
                prm_CODUSUARIO.Direction = ParameterDirection.Input;
                prm_CODUSUARIO.Value = ListEnProduCliente[0].CodUsuario;
                #endregion CodUsuario
                #region MontoDesemb
                prm_MONTODESEMB.ParameterName = "@MontoDesemb";
                prm_MONTODESEMB.SqlDbType = SqlDbType.Decimal;
                prm_MONTODESEMB.Direction = ParameterDirection.Input;
                prm_MONTODESEMB.Value = ListEnProduCliente[0].MontoDesemb;
                #endregion MontoDesemb
                #region tea
                prm_TEA.ParameterName = "@tea";
                prm_TEA.SqlDbType = SqlDbType.Decimal;
                prm_TEA.Direction = ParameterDirection.Input;
                prm_TEA.Value = ListEnProduCliente[0].tea;
                #endregion tea
                #region TotCuotasPact
                prm_TOTCUOTASPACT.ParameterName = "@TotCuotasPact";
                prm_TOTCUOTASPACT.SqlDbType = SqlDbType.Int;
                prm_TOTCUOTASPACT.Direction = ParameterDirection.Input;
                prm_TOTCUOTASPACT.Value = ListEnProduCliente[0].TotCuotasPact;
                #endregion TotCuotasPact
                #region MontoCuota
                prm_MONTOCUOTA.ParameterName = "@MontoCuota";
                prm_MONTOCUOTA.SqlDbType = SqlDbType.Int;
                prm_MONTOCUOTA.Direction = ParameterDirection.Input;
                prm_MONTOCUOTA.Value = ListEnProduCliente[0].MontoCuota;
                #endregion MontoCuota
                #endregion Values



                #region Execute
                SqlHelper.ExecuteNonQuery(tran, "CR_Cliente_sp_InsertarProductos",
                                               prm_NEMPRESA,
                                               prm_CODIGOCLIENTE,
                                               prm_CODPRODUCTO,
                                               prm_CODSUBPRODUCTO,
                                               prm_CODIGOINTERNO,
                                               prm_SALDOCAPITAL,
                                               prm_MONEDA,
                                               prm_CALIFRIESGO,
                                               prm_PORPROVISION,
                                               prm_CODSUCURSAL,
                                               prm_CODSECTORISTA,
                                               prm_CODZONA,
                                               prm_CODGERENTE,
                                               prm_dias_mora,
                                               prm_ESTADO,
                                               prm_CODUSUARIO,
                                               prm_MONTODESEMB,
                                               prm_TEA,
                                               prm_TOTCUOTASPACT,
                                               prm_MONTOCUOTA
                                               );
                #endregion Execute
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Cliente_Productos_UPD(List<EnProduCliente> ListEnProduCliente, SqlTransaction tran)
        {
            try
            {
                #region Parametros
                SqlParameter prm_NEMPRESA = new SqlParameter();
                SqlParameter prm_IDREG = new SqlParameter();
                SqlParameter prm_CODIGOCLIENTE = new SqlParameter();
                SqlParameter prm_CODPRODUCTO = new SqlParameter();
                SqlParameter prm_CODSUBPRODUCTO = new SqlParameter();
                SqlParameter prm_CODIGOINTERNO = new SqlParameter();
                SqlParameter prm_SALDOCAPITAL = new SqlParameter();
                SqlParameter prm_MONEDA = new SqlParameter();
                SqlParameter prm_CALIFRIESGO = new SqlParameter();
                SqlParameter prm_PORPROVISION = new SqlParameter();
                SqlParameter prm_CODSUCURSAL = new SqlParameter();
                SqlParameter prm_CODSECTORISTA = new SqlParameter();
                SqlParameter prm_CODZONA = new SqlParameter();
                SqlParameter prm_CODGERENTE = new SqlParameter();
                SqlParameter prm_dias_mora = new SqlParameter();
                SqlParameter prm_ESTADO = new SqlParameter();
                SqlParameter prm_CODUSUARIO = new SqlParameter();
                SqlParameter prm_MONTODESEMB = new SqlParameter();
                SqlParameter prm_TEA = new SqlParameter();
                SqlParameter prm_TOTCUOTASPACT = new SqlParameter();
                SqlParameter prm_MONTOCUOTA = new SqlParameter();
                #endregion Parametros


                #region Values
                #region NEMPRESA
                prm_NEMPRESA.ParameterName = "@NEMPRESA";
                prm_NEMPRESA.SqlDbType = SqlDbType.Int;
                prm_NEMPRESA.Direction = ParameterDirection.Input;
                prm_NEMPRESA.Value = ListEnProduCliente[0].NEMPRESA;
                #endregion NEMPRESA
                #region IdReg
                prm_IDREG.ParameterName = "@IdReg";
                prm_IDREG.SqlDbType = SqlDbType.Int;
                prm_IDREG.Direction = ParameterDirection.Input;
                prm_IDREG.Value = ListEnProduCliente[0].IdReg;
                #endregion IdReg
                #region CodigoCliente
                prm_CODIGOCLIENTE.ParameterName = "@CodigoCliente";
                prm_CODIGOCLIENTE.SqlDbType = SqlDbType.Int;
                prm_CODIGOCLIENTE.Direction = ParameterDirection.Input;
                prm_CODIGOCLIENTE.Value = ListEnProduCliente[0].CodigoCliente;
                #endregion CodigoCliente
                #region CodProducto
                prm_CODPRODUCTO.ParameterName = "@CodProducto";
                prm_CODPRODUCTO.SqlDbType = SqlDbType.Int;
                prm_CODPRODUCTO.Direction = ParameterDirection.Input;
                prm_CODPRODUCTO.Value = ListEnProduCliente[0].CodProducto;
                #endregion CodProducto
                #region CodSubProducto
                prm_CODSUBPRODUCTO.ParameterName = "@CodSubProducto";
                prm_CODSUBPRODUCTO.SqlDbType = SqlDbType.Int;
                prm_CODSUBPRODUCTO.Direction = ParameterDirection.Input;
                prm_CODSUBPRODUCTO.Value = ListEnProduCliente[0].CodSubProducto;
                #endregion CodSubProducto
                #region CodigoInterno
                prm_CODIGOINTERNO.ParameterName = "@CodigoInterno";
                prm_CODIGOINTERNO.SqlDbType = SqlDbType.Int;
                prm_CODIGOINTERNO.Direction = ParameterDirection.Input;
                prm_CODIGOINTERNO.Value = ListEnProduCliente[0].CodigoInterno;
                #endregion CodigoInterno
                #region SaldoCapital
                prm_SALDOCAPITAL.ParameterName = "@SaldoCapital";
                prm_SALDOCAPITAL.SqlDbType = SqlDbType.Decimal;
                prm_SALDOCAPITAL.Direction = ParameterDirection.Input;
                prm_SALDOCAPITAL.Value = ListEnProduCliente[0].SaldoCapital;
                #endregion SaldoCapital
                #region Moneda
                prm_MONEDA.ParameterName = "@Moneda";
                prm_MONEDA.SqlDbType = SqlDbType.Char;
                prm_MONEDA.Direction = ParameterDirection.Input;
                prm_MONEDA.Size = 1;
                prm_MONEDA.Value = ListEnProduCliente[0].Moneda;
                #endregion Moneda
                #region CalifRiesgo
                prm_CALIFRIESGO.ParameterName = "@CalifRiesgo";
                prm_CALIFRIESGO.SqlDbType = SqlDbType.VarChar;
                prm_CALIFRIESGO.Direction = ParameterDirection.Input;
                prm_CALIFRIESGO.Size = 60;
                prm_CALIFRIESGO.Value = ListEnProduCliente[0].CalifRiesgo;
                #endregion CalifRiesgo
                #region PorProvision
                prm_PORPROVISION.ParameterName = "@PorProvision";
                prm_PORPROVISION.SqlDbType = SqlDbType.VarChar;
                prm_PORPROVISION.Direction = ParameterDirection.Input;
                prm_PORPROVISION.Size = 60;
                prm_PORPROVISION.Value = ListEnProduCliente[0].PorProvision;
                #endregion PorProvision
                #region CodSucursal
                prm_CODSUCURSAL.ParameterName = "@CodSucursal";
                prm_CODSUCURSAL.SqlDbType = SqlDbType.Int;
                prm_CODSUCURSAL.Direction = ParameterDirection.Input;
                prm_CODSUCURSAL.Value = ListEnProduCliente[0].CodSucursal;
                #endregion CodSucursal
                #region CodSectorista
                prm_CODSECTORISTA.ParameterName = "@CodSectorista";
                prm_CODSECTORISTA.SqlDbType = SqlDbType.Int;
                prm_CODSECTORISTA.Direction = ParameterDirection.Input;
                prm_CODSECTORISTA.Value = ListEnProduCliente[0].CodSectorista;
                #endregion CodSectorista
                #region CodZona
                prm_CODZONA.ParameterName = "@CodZona";
                prm_CODZONA.SqlDbType = SqlDbType.Int;
                prm_CODZONA.Direction = ParameterDirection.Input;
                prm_CODZONA.Value = ListEnProduCliente[0].CodZona;
                #endregion CodZona
                #region CodGerente
                prm_CODGERENTE.ParameterName = "@CodGerente";
                prm_CODGERENTE.SqlDbType = SqlDbType.Int;
                prm_CODGERENTE.Direction = ParameterDirection.Input;
                prm_CODGERENTE.Value = ListEnProduCliente[0].CodGerente;
                #endregion CodGerente
                #region dias_mora
                prm_dias_mora.ParameterName = "@dias_mora";
                prm_dias_mora.SqlDbType = SqlDbType.Int;
                prm_dias_mora.Direction = ParameterDirection.Input;
                prm_dias_mora.Value = ListEnProduCliente[0].dias_mora;
                #endregion dias_mora
                #region Estado
                prm_ESTADO.ParameterName = "@Estado";
                prm_ESTADO.SqlDbType = SqlDbType.Char;
                prm_ESTADO.Direction = ParameterDirection.Input;
                prm_ESTADO.Size = 1;
                prm_ESTADO.Value = ListEnProduCliente[0].Estado;
                #endregion Estado
                #region CodUsuario
                prm_CODUSUARIO.ParameterName = "@CodUsuario";
                prm_CODUSUARIO.SqlDbType = SqlDbType.Int;
                prm_CODUSUARIO.Direction = ParameterDirection.Input;
                prm_CODUSUARIO.Value = ListEnProduCliente[0].CodUsuario;
                #endregion CodUsuario
                #region MontoDesemb
                prm_MONTODESEMB.ParameterName = "@MontoDesemb";
                prm_MONTODESEMB.SqlDbType = SqlDbType.Decimal;
                prm_MONTODESEMB.Direction = ParameterDirection.Input;
                prm_MONTODESEMB.Value = ListEnProduCliente[0].MontoDesemb;
                #endregion MontoDesemb
                #region tea
                prm_TEA.ParameterName = "@tea";
                prm_TEA.SqlDbType = SqlDbType.Decimal;
                prm_TEA.Direction = ParameterDirection.Input;
                prm_TEA.Value = ListEnProduCliente[0].tea;
                #endregion tea
                #region TotCuotasPact
                prm_TOTCUOTASPACT.ParameterName = "@TotCuotasPact";
                prm_TOTCUOTASPACT.SqlDbType = SqlDbType.Int;
                prm_TOTCUOTASPACT.Direction = ParameterDirection.Input;
                prm_TOTCUOTASPACT.Value = ListEnProduCliente[0].TotCuotasPact;
                #endregion TotCuotasPact
                #region MontoCuota
                prm_MONTOCUOTA.ParameterName = "@MontoCuota";
                prm_MONTOCUOTA.SqlDbType = SqlDbType.Int;
                prm_MONTOCUOTA.Direction = ParameterDirection.Input;
                prm_MONTOCUOTA.Value = ListEnProduCliente[0].MontoCuota;
                #endregion MontoCuota
                #endregion Values



                #region Execute
                SqlHelper.ExecuteNonQuery(tran, "CR_Cliente_sp_ModificarProductos",
                                               prm_NEMPRESA,
                                               prm_IDREG,
                                               prm_CODIGOCLIENTE,
                                               prm_CODPRODUCTO,
                                               prm_CODSUBPRODUCTO,
                                               prm_CODIGOINTERNO,
                                               prm_SALDOCAPITAL,
                                               prm_MONEDA,
                                               prm_CALIFRIESGO,
                                               prm_PORPROVISION,
                                               prm_CODSUCURSAL,
                                               prm_CODSECTORISTA,
                                               prm_CODZONA,
                                               prm_CODGERENTE,
                                               prm_dias_mora,
                                               prm_ESTADO,
                                               prm_CODUSUARIO,
                                               prm_MONTODESEMB,
                                               prm_TEA,
                                               prm_TOTCUOTASPACT,
                                               prm_MONTOCUOTA
                                               );
                #endregion Execute
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Cliente_Productos_Listar(List<EnProduCliente> ListEnProduCliente)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                
                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "CR_Cliente_sp_CargaClienteProductos";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];

                paramsToStore[0] = new SqlParameter("@NEMPRESA", SqlDbType.Int);
                paramsToStore[0].Value = ListEnProduCliente[0].NEMPRESA;

                paramsToStore[1] = new SqlParameter("@CodigoCliente", SqlDbType.Int);
                paramsToStore[1].Value = ListEnProduCliente[0].CodigoCliente;

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
        public DataTable Cliente_Productos_Listar_Reg(List<EnProduCliente> ListEnProduCliente)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "CR_Cliente_sp_CargaClienteProductosREG";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];

                paramsToStore[0] = new SqlParameter("@NEMPRESA", SqlDbType.Int);
                paramsToStore[0].Value = ListEnProduCliente[0].NEMPRESA;

                paramsToStore[1] = new SqlParameter("@IdReg", SqlDbType.Int);
                paramsToStore[1].Value = ListEnProduCliente[0].IdReg;

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


        public DataTable Cliente_Productos_Gastos_Listar(List<EnProduCliente> ListEnProduCliente)
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

                paramsToStore[0] = new SqlParameter("@NEMPRESA", SqlDbType.Int);
                paramsToStore[0].Value = ListEnProduCliente[0].NEMPRESA;

                paramsToStore[1] = new SqlParameter("@CodigoCliente", SqlDbType.Int);
                paramsToStore[1].Value = ListEnProduCliente[0].CodigoCliente;

                paramsToStore[2] = new SqlParameter("@IdRegPRODUCTOS", SqlDbType.Decimal);
                paramsToStore[2].Value = ListEnProduCliente[0].IdRegPRODUCTOS;

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
        public DataTable Cliente_Productos_GC_Listar(List<EnProduCliente> ListEnProduCliente)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "CR_Cliente_sp_CargaClienteGC";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[3];

                paramsToStore[0] = new SqlParameter("@NEMPRESA", SqlDbType.Int);
                paramsToStore[0].Value = ListEnProduCliente[0].NEMPRESA;

                paramsToStore[1] = new SqlParameter("@CodigoCliente", SqlDbType.Int);
                paramsToStore[1].Value = ListEnProduCliente[0].CodigoCliente;

                paramsToStore[2] = new SqlParameter("@IdRegPRODUCTOS", SqlDbType.Decimal);
                paramsToStore[2].Value = ListEnProduCliente[0].IdRegPRODUCTOS;

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
