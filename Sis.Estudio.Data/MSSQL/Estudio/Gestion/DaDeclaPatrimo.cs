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
    public class DaDeclaPatrimo : DaConexion
    {
       
        public void DeclaPatrimo_INS(List<EnDeclaPatrimo> ListEnDeclaPatrimo, SqlTransaction tran)
        {
            try
            {
                #region Parametros
                SqlParameter prm_NEMPRESA = new SqlParameter();
                SqlParameter prm_CODIGOCLIENTE = new SqlParameter();
                SqlParameter prm_CODTIPOBIEN = new SqlParameter();
                SqlParameter prm_PORPROPIEDAD = new SqlParameter();
                SqlParameter prm_VALORCOMERCIAL = new SqlParameter();
                SqlParameter prm_MONEDA = new SqlParameter();
                SqlParameter prm_PARTIDAREGISTRAL = new SqlParameter();
                SqlParameter prm_DATOSBIEN = new SqlParameter();
                SqlParameter prm_OBSERVACION = new SqlParameter();
                SqlParameter prm_ESTADO = new SqlParameter();
                SqlParameter prm_CODUSUARIO = new SqlParameter();
                #endregion Parametros


                #region Values
                #region nempresa
                prm_NEMPRESA.ParameterName = "@nempresa";
                prm_NEMPRESA.SqlDbType = SqlDbType.Int;
                prm_NEMPRESA.Direction = ParameterDirection.Input;
                prm_NEMPRESA.Value = ListEnDeclaPatrimo[0].nempresa;
                #endregion nempresa
                #region CodigoCliente
                prm_CODIGOCLIENTE.ParameterName = "@CodigoCliente";
                prm_CODIGOCLIENTE.SqlDbType = SqlDbType.Int;
                prm_CODIGOCLIENTE.Direction = ParameterDirection.Input;
                prm_CODIGOCLIENTE.Value = ListEnDeclaPatrimo[0].CodigoCliente;
                #endregion CodigoCliente
                #region CodTipoBien
                prm_CODTIPOBIEN.ParameterName = "@CodTipoBien";
                prm_CODTIPOBIEN.SqlDbType = SqlDbType.Int;
                prm_CODTIPOBIEN.Direction = ParameterDirection.Input;
                prm_CODTIPOBIEN.Value = ListEnDeclaPatrimo[0].CodTipoBien;
                #endregion CodTipoBien
                #region PorPropiedad
                prm_PORPROPIEDAD.ParameterName = "@PorPropiedad";
                prm_PORPROPIEDAD.SqlDbType = SqlDbType.Decimal;
                prm_PORPROPIEDAD.Direction = ParameterDirection.Input;
                prm_PORPROPIEDAD.Value = ListEnDeclaPatrimo[0].PorPropiedad;
                #endregion PorPropiedad
                #region ValorComercial
                prm_VALORCOMERCIAL.ParameterName = "@ValorComercial";
                prm_VALORCOMERCIAL.SqlDbType = SqlDbType.Decimal;
                prm_VALORCOMERCIAL.Direction = ParameterDirection.Input;
                prm_VALORCOMERCIAL.Value = ListEnDeclaPatrimo[0].ValorComercial;
                #endregion ValorComercial
                #region Moneda
                prm_MONEDA.ParameterName = "@Moneda";
                prm_MONEDA.SqlDbType = SqlDbType.Int;
                prm_MONEDA.Direction = ParameterDirection.Input;
                prm_MONEDA.Value = ListEnDeclaPatrimo[0].Moneda;
                #endregion Moneda
                #region PartidaRegistral
                prm_PARTIDAREGISTRAL.ParameterName = "@PartidaRegistral";
                prm_PARTIDAREGISTRAL.SqlDbType = SqlDbType.VarChar;
                prm_PARTIDAREGISTRAL.Direction = ParameterDirection.Input;
                prm_PARTIDAREGISTRAL.Size = 30;
                prm_PARTIDAREGISTRAL.Value = ListEnDeclaPatrimo[0].PartidaRegistral;
                #endregion PartidaRegistral
                #region DatosBien
                prm_DATOSBIEN.ParameterName = "@DatosBien";
                prm_DATOSBIEN.SqlDbType = SqlDbType.VarChar;
                prm_DATOSBIEN.Direction = ParameterDirection.Input;
                prm_DATOSBIEN.Size = 2000;
                prm_DATOSBIEN.Value = ListEnDeclaPatrimo[0].DatosBien;
                #endregion DatosBien
                #region Observacion
                prm_OBSERVACION.ParameterName = "@Observacion";
                prm_OBSERVACION.SqlDbType = SqlDbType.VarChar;
                prm_OBSERVACION.Direction = ParameterDirection.Input;
                prm_OBSERVACION.Size = 200;
                prm_OBSERVACION.Value = ListEnDeclaPatrimo[0].Observacion;
                #endregion Observacion
                #region Estado
                prm_ESTADO.ParameterName = "@Estado";
                prm_ESTADO.SqlDbType = SqlDbType.Char;
                prm_ESTADO.Direction = ParameterDirection.Input;
                prm_ESTADO.Size = 1;
                prm_ESTADO.Value = ListEnDeclaPatrimo[0].Estado;
                #endregion Estado
                #region CodUsuario
                prm_CODUSUARIO.ParameterName = "@CodUsuario";
                prm_CODUSUARIO.SqlDbType = SqlDbType.Int;
                prm_CODUSUARIO.Direction = ParameterDirection.Input;
                prm_CODUSUARIO.Value = ListEnDeclaPatrimo[0].CodUsuario;
                #endregion CodUsuario
                #endregion Values

                #region Execute
                SqlHelper.ExecuteNonQuery(tran, "CR_Cliente_sp_InsertarDecPatrim",
                                               prm_NEMPRESA,
                                               prm_CODIGOCLIENTE,
                                               prm_CODTIPOBIEN,
                                               prm_PORPROPIEDAD,
                                               prm_VALORCOMERCIAL,
                                               prm_MONEDA,
                                               prm_PARTIDAREGISTRAL,
                                               prm_DATOSBIEN,
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
        public void DeclaPatrimo_UPD(List<EnDeclaPatrimo> ListEnDeclaPatrimo, SqlTransaction tran)
        {
            try
            {
                #region Parametros
                SqlParameter prm_NEMPRESA = new SqlParameter();
                SqlParameter prm_IDREG = new SqlParameter();
                SqlParameter prm_CODTIPOBIEN = new SqlParameter();
                SqlParameter prm_PORPROPIEDAD = new SqlParameter();
                SqlParameter prm_VALORCOMERCIAL = new SqlParameter();
                SqlParameter prm_MONEDA = new SqlParameter();
                SqlParameter prm_PARTIDAREGISTRAL = new SqlParameter();
                SqlParameter prm_DATOSBIEN = new SqlParameter();
                SqlParameter prm_OBSERVACION = new SqlParameter();
                SqlParameter prm_ESTADO = new SqlParameter();
                SqlParameter prm_CODUSUARIO = new SqlParameter();
                #endregion Parametros


                #region Values
                #region NEMPRESA
                prm_NEMPRESA.ParameterName = "@NEMPRESA";
                prm_NEMPRESA.SqlDbType = SqlDbType.Int;
                prm_NEMPRESA.Direction = ParameterDirection.Input;
                prm_NEMPRESA.Value = ListEnDeclaPatrimo[0].nempresa;
                #endregion NEMPRESA
                #region IdReg
                prm_IDREG.ParameterName = "@IdReg";
                prm_IDREG.SqlDbType = SqlDbType.Int;
                prm_IDREG.Direction = ParameterDirection.Input;
                prm_IDREG.Value = ListEnDeclaPatrimo[0].IdReg;
                #endregion IdReg
                #region CodTipoBien
                prm_CODTIPOBIEN.ParameterName = "@CodTipoBien";
                prm_CODTIPOBIEN.SqlDbType = SqlDbType.Int;
                prm_CODTIPOBIEN.Direction = ParameterDirection.Input;
                prm_CODTIPOBIEN.Value = ListEnDeclaPatrimo[0].CodTipoBien;
                #endregion CodTipoBien
                #region PorPropiedad
                prm_PORPROPIEDAD.ParameterName = "@PorPropiedad";
                prm_PORPROPIEDAD.SqlDbType = SqlDbType.Decimal;
                prm_PORPROPIEDAD.Direction = ParameterDirection.Input;
                prm_PORPROPIEDAD.Value = ListEnDeclaPatrimo[0].PorPropiedad;
                #endregion PorPropiedad
                #region ValorComercial
                prm_VALORCOMERCIAL.ParameterName = "@ValorComercial";
                prm_VALORCOMERCIAL.SqlDbType = SqlDbType.Decimal;
                prm_VALORCOMERCIAL.Direction = ParameterDirection.Input;
                prm_VALORCOMERCIAL.Value = ListEnDeclaPatrimo[0].ValorComercial;
                #endregion ValorComercial
                #region Moneda
                prm_MONEDA.ParameterName = "@Moneda";
                prm_MONEDA.SqlDbType = SqlDbType.Int;
                prm_MONEDA.Direction = ParameterDirection.Input;
                prm_MONEDA.Value = ListEnDeclaPatrimo[0].Moneda;
                #endregion Moneda
                #region PartidaRegistral
                prm_PARTIDAREGISTRAL.ParameterName = "@PartidaRegistral";
                prm_PARTIDAREGISTRAL.SqlDbType = SqlDbType.VarChar;
                prm_PARTIDAREGISTRAL.Direction = ParameterDirection.Input;
                prm_PARTIDAREGISTRAL.Size = 30;
                prm_PARTIDAREGISTRAL.Value = ListEnDeclaPatrimo[0].PartidaRegistral;
                #endregion PartidaRegistral
                #region DatosBien
                prm_DATOSBIEN.ParameterName = "@DatosBien";
                prm_DATOSBIEN.SqlDbType = SqlDbType.VarChar;
                prm_DATOSBIEN.Direction = ParameterDirection.Input;
                prm_DATOSBIEN.Size = 2000;
                prm_DATOSBIEN.Value = ListEnDeclaPatrimo[0].DatosBien;
                #endregion DatosBien
                #region Observacion
                prm_OBSERVACION.ParameterName = "@Observacion";
                prm_OBSERVACION.SqlDbType = SqlDbType.VarChar;
                prm_OBSERVACION.Direction = ParameterDirection.Input;
                prm_OBSERVACION.Size = 200;
                prm_OBSERVACION.Value = ListEnDeclaPatrimo[0].Observacion;
                #endregion Observacion
                #region Estado
                prm_ESTADO.ParameterName = "@Estado";
                prm_ESTADO.SqlDbType = SqlDbType.Char;
                prm_ESTADO.Direction = ParameterDirection.Input;
                prm_ESTADO.Size = 1;
                prm_ESTADO.Value = ListEnDeclaPatrimo[0].Estado;
                #endregion Estado
                #region CodUsuario
                prm_CODUSUARIO.ParameterName = "@CodUsuario";
                prm_CODUSUARIO.SqlDbType = SqlDbType.Int;
                prm_CODUSUARIO.Direction = ParameterDirection.Input;
                prm_CODUSUARIO.Value = ListEnDeclaPatrimo[0].CodUsuario;
                #endregion CodUsuario
                #endregion Values



                #region Execute
                SqlHelper.ExecuteNonQuery(tran, "CR_Cliente_sp_ModificarDecPatrim",
                                               prm_NEMPRESA,
                                               prm_IDREG,
                                               prm_CODTIPOBIEN,
                                               prm_PORPROPIEDAD,
                                               prm_VALORCOMERCIAL,
                                               prm_MONEDA,
                                               prm_PARTIDAREGISTRAL,
                                               prm_DATOSBIEN,
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
        public DataTable DeclaPatrimo_Lista(List<EnDeclaPatrimo> ListEnDeclaPatrimo)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "CR_Cliente_sp_CargaClienteDecPatrim";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];

                paramsToStore[0] = new SqlParameter("@NEMPRESA", SqlDbType.Int);
                paramsToStore[0].Value = ListEnDeclaPatrimo[0].nempresa;

                paramsToStore[1] = new SqlParameter("@CodigoCliente", SqlDbType.Int);
                paramsToStore[1].Value = ListEnDeclaPatrimo[0].CodigoCliente;

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
        public DataTable DeclaPatrimo_Lista_Reg(List<EnDeclaPatrimo> ListEnDeclaPatrimo)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "CR_Cliente_sp_CargaClienteDecPatrimREG";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];

                paramsToStore[0] = new SqlParameter("@NEMPRESA", SqlDbType.Int);
                paramsToStore[0].Value = ListEnDeclaPatrimo[0].nempresa;

                paramsToStore[1] = new SqlParameter("@IDReg", SqlDbType.Int);
                paramsToStore[1].Value = ListEnDeclaPatrimo[0].IdReg;

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

        public DataTable DeclaPatrimo_TipoBien_Lista()
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "CR_Cliente_sp_TipoBien";
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
