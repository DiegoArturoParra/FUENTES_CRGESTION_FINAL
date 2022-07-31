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
    public class DaAvalDeclaPat : DaConexion
    {

        public void Aval_DeclaPatrimonial_INS(List<EnAvalDeclaPat> ListEnAvalDeclaPat, SqlTransaction tran)
        {
            try
            {

                #region Parametros
                SqlParameter prm_NEMPRESA = new SqlParameter();                                 
                SqlParameter prm_IDREGPRODAVAL = new SqlParameter();
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
                prm_NEMPRESA.Value = ListEnAvalDeclaPat[0].NEmpresa;
                #endregion nempresa

                #region IdRegProdAval
                prm_IDREGPRODAVAL.ParameterName = "@IdRegProdAval";
                prm_IDREGPRODAVAL.SqlDbType = SqlDbType.Int;
                prm_IDREGPRODAVAL.Direction = ParameterDirection.Input;
                prm_IDREGPRODAVAL.Value = ListEnAvalDeclaPat[0].IdRegProdAval;
                #endregion IdRegProdAval

                #region CodigoCliente
                prm_CODIGOCLIENTE.ParameterName = "@CodigoCliente";
                prm_CODIGOCLIENTE.SqlDbType = SqlDbType.Int;
                prm_CODIGOCLIENTE.Direction = ParameterDirection.Input;
                prm_CODIGOCLIENTE.Value = ListEnAvalDeclaPat[0].CodigoCliente;
                #endregion CodigoCliente
                #region CodTipoBien
                prm_CODTIPOBIEN.ParameterName = "@CodTipoBien";
                prm_CODTIPOBIEN.SqlDbType = SqlDbType.Int;
                prm_CODTIPOBIEN.Direction = ParameterDirection.Input;
                prm_CODTIPOBIEN.Value = ListEnAvalDeclaPat[0].CodTipoBien;
                #endregion CodTipoBien
                #region PorPropiedad
                prm_PORPROPIEDAD.ParameterName = "@PorPropiedad";
                prm_PORPROPIEDAD.SqlDbType = SqlDbType.Decimal;
                prm_PORPROPIEDAD.Direction = ParameterDirection.Input;
                prm_PORPROPIEDAD.Value = ListEnAvalDeclaPat[0].PorPropiedad;
                #endregion PorPropiedad
                #region ValorComercial
                prm_VALORCOMERCIAL.ParameterName = "@ValorComercial";
                prm_VALORCOMERCIAL.SqlDbType = SqlDbType.Decimal;
                prm_VALORCOMERCIAL.Direction = ParameterDirection.Input;
                prm_VALORCOMERCIAL.Value = ListEnAvalDeclaPat[0].ValorComercial;
                #endregion ValorComercial
                #region Moneda
                prm_MONEDA.ParameterName = "@Moneda";
                prm_MONEDA.SqlDbType = SqlDbType.Int;
                prm_MONEDA.Direction = ParameterDirection.Input;
                prm_MONEDA.Value = ListEnAvalDeclaPat[0].Moneda;
                #endregion Moneda
                #region PartidaRegistral
                prm_PARTIDAREGISTRAL.ParameterName = "@PartidaRegistral";
                prm_PARTIDAREGISTRAL.SqlDbType = SqlDbType.VarChar;
                prm_PARTIDAREGISTRAL.Direction = ParameterDirection.Input;
                prm_PARTIDAREGISTRAL.Size = 30;
                prm_PARTIDAREGISTRAL.Value = ListEnAvalDeclaPat[0].PartidaRegistral;
                #endregion PartidaRegistral
                #region DatosBien
                prm_DATOSBIEN.ParameterName = "@DatosBien";
                prm_DATOSBIEN.SqlDbType = SqlDbType.VarChar;
                prm_DATOSBIEN.Direction = ParameterDirection.Input;
                prm_DATOSBIEN.Size = 2000;
                prm_DATOSBIEN.Value = ListEnAvalDeclaPat[0].DatosBien;
                #endregion DatosBien
                #region Observacion
                prm_OBSERVACION.ParameterName = "@Observacion";
                prm_OBSERVACION.SqlDbType = SqlDbType.VarChar;
                prm_OBSERVACION.Direction = ParameterDirection.Input;
                prm_OBSERVACION.Size = 200;
                prm_OBSERVACION.Value = ListEnAvalDeclaPat[0].Observacion;
                #endregion Observacion
                #region Estado
                prm_ESTADO.ParameterName = "@Estado";
                prm_ESTADO.SqlDbType = SqlDbType.Char;
                prm_ESTADO.Direction = ParameterDirection.Input;
                prm_ESTADO.Size = 1;
                prm_ESTADO.Value = ListEnAvalDeclaPat[0].Estado;
                #endregion Estado
                #region CodUsuario
                prm_CODUSUARIO.ParameterName = "@CodUsuario";
                prm_CODUSUARIO.SqlDbType = SqlDbType.Int;
                prm_CODUSUARIO.Direction = ParameterDirection.Input;
                prm_CODUSUARIO.Value = ListEnAvalDeclaPat[0].CodUsuario;
                #endregion CodUsuario
                #endregion Values

                #region Execute
                SqlHelper.ExecuteNonQuery(tran, "CR_Cliente_sp_InsertarPRODDecPatrim",
                                               prm_NEMPRESA,
                                               prm_IDREGPRODAVAL,
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
        public void Aval_DeclaPatrimonial_UPD(List<EnAvalDeclaPat> ListEnAvalDeclaPat, SqlTransaction tran)
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
                prm_NEMPRESA.Value = ListEnAvalDeclaPat[0].NEmpresa;
                #endregion NEMPRESA
                #region IdReg
                prm_IDREG.ParameterName = "@IdReg";
                prm_IDREG.SqlDbType = SqlDbType.Int;
                prm_IDREG.Direction = ParameterDirection.Input;
                prm_IDREG.Value = ListEnAvalDeclaPat[0].IdReg;
                #endregion IdReg
                #region CodTipoBien
                prm_CODTIPOBIEN.ParameterName = "@CodTipoBien";
                prm_CODTIPOBIEN.SqlDbType = SqlDbType.Int;
                prm_CODTIPOBIEN.Direction = ParameterDirection.Input;
                prm_CODTIPOBIEN.Value = ListEnAvalDeclaPat[0].CodTipoBien;
                #endregion CodTipoBien
                #region PorPropiedad
                prm_PORPROPIEDAD.ParameterName = "@PorPropiedad";
                prm_PORPROPIEDAD.SqlDbType = SqlDbType.Decimal;
                prm_PORPROPIEDAD.Direction = ParameterDirection.Input;
                prm_PORPROPIEDAD.Value = ListEnAvalDeclaPat[0].PorPropiedad;
                #endregion PorPropiedad
                #region ValorComercial
                prm_VALORCOMERCIAL.ParameterName = "@ValorComercial";
                prm_VALORCOMERCIAL.SqlDbType = SqlDbType.Decimal;
                prm_VALORCOMERCIAL.Direction = ParameterDirection.Input;
                prm_VALORCOMERCIAL.Value = ListEnAvalDeclaPat[0].ValorComercial;
                #endregion ValorComercial
                #region Moneda
                prm_MONEDA.ParameterName = "@Moneda";
                prm_MONEDA.SqlDbType = SqlDbType.Int;
                prm_MONEDA.Direction = ParameterDirection.Input;
                prm_MONEDA.Value = ListEnAvalDeclaPat[0].Moneda;
                #endregion Moneda
                #region PartidaRegistral
                prm_PARTIDAREGISTRAL.ParameterName = "@PartidaRegistral";
                prm_PARTIDAREGISTRAL.SqlDbType = SqlDbType.VarChar;
                prm_PARTIDAREGISTRAL.Direction = ParameterDirection.Input;
                prm_PARTIDAREGISTRAL.Size = 30;
                prm_PARTIDAREGISTRAL.Value = ListEnAvalDeclaPat[0].PartidaRegistral;
                #endregion PartidaRegistral
                #region DatosBien
                prm_DATOSBIEN.ParameterName = "@DatosBien";
                prm_DATOSBIEN.SqlDbType = SqlDbType.VarChar;
                prm_DATOSBIEN.Direction = ParameterDirection.Input;
                prm_DATOSBIEN.Size = 2000;
                prm_DATOSBIEN.Value = ListEnAvalDeclaPat[0].DatosBien;
                #endregion DatosBien
                #region Observacion
                prm_OBSERVACION.ParameterName = "@Observacion";
                prm_OBSERVACION.SqlDbType = SqlDbType.VarChar;
                prm_OBSERVACION.Direction = ParameterDirection.Input;
                prm_OBSERVACION.Size = 200;
                prm_OBSERVACION.Value = ListEnAvalDeclaPat[0].Observacion;
                #endregion Observacion
                #region Estado
                prm_ESTADO.ParameterName = "@Estado";
                prm_ESTADO.SqlDbType = SqlDbType.Char;
                prm_ESTADO.Direction = ParameterDirection.Input;
                prm_ESTADO.Size = 1;
                prm_ESTADO.Value = ListEnAvalDeclaPat[0].Estado;
                #endregion Estado
                #region CodUsuario
                prm_CODUSUARIO.ParameterName = "@CodUsuario";
                prm_CODUSUARIO.SqlDbType = SqlDbType.Int;
                prm_CODUSUARIO.Direction = ParameterDirection.Input;
                prm_CODUSUARIO.Value = ListEnAvalDeclaPat[0].CodUsuario;
                #endregion CodUsuario
                #endregion Values



                #region Execute
                SqlHelper.ExecuteNonQuery(tran, "CR_Cliente_sp_ModificarPRODDecPatrim",
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
        public DataTable Aval_DeclaPatrimonial_Listar(List<EnAvalDeclaPat> ListEnAvalDeclaPat)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "CR_Cliente_sp_CargaClientePRODDecPatrim";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];

                paramsToStore[0] = new SqlParameter("@NEMPRESA", SqlDbType.Int);
                paramsToStore[0].Value = ListEnAvalDeclaPat[0].NEmpresa;

                paramsToStore[1] = new SqlParameter("@IdRegProdAval", SqlDbType.Int);
                paramsToStore[1].Value = ListEnAvalDeclaPat[0].IdRegProdAval;

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
        public DataTable Aval_DeclaPatrimonial_Listar_Reg(List<EnAvalDeclaPat> ListEnAvalDeclaPat)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "CR_Cliente_sp_CargaClientePRODDecPatrimREG";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];

                paramsToStore[0] = new SqlParameter("@NEMPRESA", SqlDbType.Int);
                paramsToStore[0].Value = ListEnAvalDeclaPat[0].NEmpresa;

                paramsToStore[1] = new SqlParameter("@IDReg", SqlDbType.Int);
                paramsToStore[1].Value = ListEnAvalDeclaPat[0].IdReg;

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
