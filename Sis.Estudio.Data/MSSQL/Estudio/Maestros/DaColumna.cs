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
    public class DaColumna : DaConexion
    {

        #region Parametros
        SqlParameter pnIdColumna = new SqlParameter();
        SqlParameter pnIdUser = new SqlParameter();
        SqlParameter pnIdTabla = new SqlParameter();
        SqlParameter pcNombreColumna = new SqlParameter();
        SqlParameter pcValor = new SqlParameter();
        SqlParameter plActivo = new SqlParameter();
        SqlParameter plVisible = new SqlParameter();
        SqlParameter pnOrden = new SqlParameter();
        SqlParameter pcDescripcion = new SqlParameter();
        SqlParameter plModificable = new SqlParameter();
        SqlParameter plCampoOrigen = new SqlParameter();
        SqlParameter pcTipoCampo = new SqlParameter();
        SqlParameter pcTipoDato = new SqlParameter();
        SqlParameter pnLongDato = new SqlParameter();
        SqlParameter plObligatorio = new SqlParameter();
        SqlParameter pnEmpresa = new SqlParameter();
        #endregion Parametros
        public string mxColumna_INS(List<EnColumna> lstEnColumna, ref SqlTransaction loTransaccion)
        {
            string IdReturn = String.Empty;
            SqlDataReader drParamReturn;
            try
            {
                #region Parametros
                //SqlParameter pnIdColumna= new SqlParameter();
                SqlParameter pnIdUser = new SqlParameter();
                SqlParameter pnIdTabla = new SqlParameter();
                SqlParameter pcNombreColumna = new SqlParameter();
                SqlParameter pcValor = new SqlParameter();
                SqlParameter plActivo = new SqlParameter();
                SqlParameter plVisible = new SqlParameter();
                SqlParameter pnOrden = new SqlParameter();
                SqlParameter pcDescripcion = new SqlParameter();
                SqlParameter plModificable = new SqlParameter();
                SqlParameter plCampoOrigen = new SqlParameter();
                SqlParameter pcTipoCampo = new SqlParameter();
                SqlParameter pcTipoDato = new SqlParameter();
                SqlParameter pnLongDato = new SqlParameter();
                SqlParameter plObligatorio = new SqlParameter();
                SqlParameter pnEmpresa = new SqlParameter();
                #endregion Parametros

                #region Values

                //#region pnIdColumna
                //pnIdColumna.ParameterName = "@pnIdColumna";
                //pnIdColumna.SqlDbType = SqlDbType.Int;
                //pnIdColumna.Direction = ParameterDirection.Input;
                //pnIdColumna.Value = lstEnColumna[0].nIdColumna;
                //#endregion pnIdColumna
                #region pnIdUser
                pnIdUser.ParameterName = "@pnIdUser";
                pnIdUser.SqlDbType = SqlDbType.Int;
                pnIdUser.Direction = ParameterDirection.Input;
                pnIdUser.Value = lstEnColumna[0].nIdUser;
                #endregion pnIdUser
                #region pnIdTabla
                pnIdTabla.ParameterName = "@pnIdTabla";
                pnIdUser.SqlDbType = SqlDbType.Int;
                pnIdUser.Direction = ParameterDirection.Input;
                pnIdTabla.Value = lstEnColumna[0].nIdTabla;
                #endregion pnIdTabla
                #region pcNombreColumna
                pcNombreColumna.ParameterName = "@pcNombreColumna";
                pcNombreColumna.SqlDbType = SqlDbType.VarChar;
                pcNombreColumna.Direction = ParameterDirection.Input;
                pcNombreColumna.Size = 50;
                pcNombreColumna.Value = lstEnColumna[0].cNombreColumna;
                #endregion pcNombreColumna
                #region pcValor
                pcValor.ParameterName = "@pcValor";
                pcValor.SqlDbType = SqlDbType.VarChar;
                pcValor.Direction = ParameterDirection.Input;
                pcValor.Size = 50;
                pcValor.Value = lstEnColumna[0].cValor;
                #endregion pcValor
                #region plActivo
                plActivo.ParameterName = "@plActivo";
                plActivo.SqlDbType = SqlDbType.Bit;
                plActivo.Direction = ParameterDirection.Input;
                plActivo.Value = lstEnColumna[0].lActivo;
                #endregion plActivo
                #region plVisible
                plVisible.ParameterName = "@plVisible";
                plVisible.SqlDbType = SqlDbType.Bit;
                plVisible.Direction = ParameterDirection.Input;
                plVisible.Value = lstEnColumna[0].lVisible;
                #endregion plVisible
                #region pnOrden
                pnOrden.ParameterName = "@pnOrden";
                pnOrden.SqlDbType = SqlDbType.Int;
                pnOrden.Direction = ParameterDirection.Input;
                pnOrden.Value = lstEnColumna[0].nOrden;
                #endregion pnOrden
                #region pcDescripcion
                pcDescripcion.ParameterName = "@pcDescripcion";
                pcDescripcion.SqlDbType = SqlDbType.VarChar;
                pcDescripcion.Direction = ParameterDirection.Input;
                pcDescripcion.Size = 50;
                pcDescripcion.Value = lstEnColumna[0].cDescripcion;
                #endregion pcDescripcion
                #region plModificable
                plModificable.ParameterName = "@plModificable";
                plModificable.SqlDbType = SqlDbType.Bit;
                plModificable.Direction = ParameterDirection.Input;
                plModificable.Value = lstEnColumna[0].lModificable;
                #endregion plModificable
                #region plCampoOrigen
                plCampoOrigen.ParameterName = "@plCampoOrigen";
                plCampoOrigen.SqlDbType = SqlDbType.Bit;
                plCampoOrigen.Direction = ParameterDirection.Input;
                plCampoOrigen.Value = lstEnColumna[0].lCampoOrigen;
                #endregion plCampoOrigen
                #region pcTipoCampo
                pcTipoCampo.ParameterName = "@pcTipoCampo";
                pcTipoCampo.SqlDbType = SqlDbType.VarChar;
                pcTipoCampo.Direction = ParameterDirection.Input;
                pcTipoCampo.Size = 15;
                pcTipoCampo.Value = lstEnColumna[0].cTipoCampo;
                #endregion pcTipoCampo
                #region pcTipoDato
                pcTipoDato.ParameterName = "@pcTipoDato";
                pcTipoDato.SqlDbType = SqlDbType.VarChar;
                pcTipoDato.Direction = ParameterDirection.Input;
                pcTipoDato.Size = 50;
                pcTipoDato.Value = lstEnColumna[0].cTipoDato;
                #endregion pcTipoDato
                #region pnLongDato
                pnLongDato.ParameterName = "@pnLongDato";
                pnLongDato.SqlDbType = SqlDbType.Int;
                pnLongDato.Direction = ParameterDirection.Input;
                pnLongDato.Value = lstEnColumna[0].nLongDato;
                #endregion pnLongDato
                #region plObligatorio
                plObligatorio.ParameterName = "@plObligatorio";
                plObligatorio.SqlDbType = SqlDbType.Bit;
                plObligatorio.Direction = ParameterDirection.Input;
                plObligatorio.Value = lstEnColumna[0].lObligatorio;
                #endregion plObligatorio
                #region pnEmpresa
                pnEmpresa.ParameterName = "@pnEmpresa";
                pnEmpresa.SqlDbType = SqlDbType.Int;
                pnEmpresa.Direction = ParameterDirection.Input;
                pnEmpresa.Value = lstEnColumna[0].nEmpresa;
                #endregion pnEmpresa
                #endregion Values

                #region Execute
                drParamReturn = SqlHelper.ExecuteReader(loTransaccion, "CR_Columna_sp_Insertar",
                                                        //pnIdColumna,
                                                        pnIdUser,
                                                        pnIdTabla,
                                                        pcNombreColumna,
                                                        pcValor,
                                                        plActivo,
                                                        plVisible,
                                                        pnOrden,
                                                        pcDescripcion,
                                                        plModificable,
                                                        plCampoOrigen,
                                                        pcTipoCampo,
                                                        pcTipoDato,
                                                        pnLongDato,
                                                        plObligatorio,
                                                        pnEmpresa);
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
        public void mxColumna_UPD(List<EnColumna> lstEnColumna, SqlTransaction loTransaccion)
        {
            try
            {
                #region Parametros
                SqlParameter pnIdColumna = new SqlParameter();
                SqlParameter pnIdUser = new SqlParameter();
                SqlParameter pnIdTabla = new SqlParameter();
                SqlParameter pcNombreColumna = new SqlParameter();
                SqlParameter pcValor = new SqlParameter();
                SqlParameter plActivo = new SqlParameter();
                SqlParameter plVisible = new SqlParameter();
                SqlParameter pnOrden = new SqlParameter();
                SqlParameter pcDescripcion = new SqlParameter();
                SqlParameter plModificable = new SqlParameter();
                SqlParameter plCampoOrigen = new SqlParameter();
                SqlParameter pcTipoCampo = new SqlParameter();
                SqlParameter pcTipoDato = new SqlParameter();
                SqlParameter pnLongDato = new SqlParameter();
                SqlParameter plObligatorio = new SqlParameter();
                SqlParameter pnEmpresa = new SqlParameter();
                #endregion Parametros

                #region Values

                #region pnIdColumna
                pnIdColumna.ParameterName = "@pnIdColumna";
                pnIdColumna.SqlDbType = SqlDbType.Int;
                pnIdColumna.Direction = ParameterDirection.Input;
                pnIdColumna.Value = lstEnColumna[0].nIdColumna;
                #endregion pnIdColumna
                #region pnIdUser
                pnIdUser.ParameterName = "@pnIdUser";
                pnIdUser.SqlDbType = SqlDbType.Int;
                pnIdUser.Direction = ParameterDirection.Input;
                pnIdUser.Value = lstEnColumna[0].nIdUser;
                #endregion pnIdUser
                #region pnIdTabla
                pnIdTabla.ParameterName = "@pnIdTabla";
                pnIdUser.SqlDbType = SqlDbType.Int;
                pnIdUser.Direction = ParameterDirection.Input;
                pnIdTabla.Value = lstEnColumna[0].nIdTabla;
                #endregion pnIdTabla
                #region pcNombreColumna
                pcNombreColumna.ParameterName = "@pcNombreColumna";
                pcNombreColumna.SqlDbType = SqlDbType.VarChar;
                pcNombreColumna.Direction = ParameterDirection.Input;
                pcNombreColumna.Size = 50;
                pcNombreColumna.Value = lstEnColumna[0].cNombreColumna;
                #endregion pcNombreColumna
                #region pcValor
                pcValor.ParameterName = "@pcValor";
                pcValor.SqlDbType = SqlDbType.VarChar;
                pcValor.Direction = ParameterDirection.Input;
                pcValor.Size = 50;
                pcValor.Value = lstEnColumna[0].cValor;
                #endregion pcValor
                #region plActivo
                plActivo.ParameterName = "@plActivo";
                plActivo.SqlDbType = SqlDbType.Bit;
                plActivo.Direction = ParameterDirection.Input;
                plActivo.Value = lstEnColumna[0].lActivo;
                #endregion plActivo
                #region plVisible
                plVisible.ParameterName = "@plVisible";
                plVisible.SqlDbType = SqlDbType.Bit;
                plVisible.Direction = ParameterDirection.Input;
                plVisible.Value = lstEnColumna[0].lVisible;
                #endregion plVisible
                #region pnOrden
                pnOrden.ParameterName = "@pnOrden";
                pnOrden.SqlDbType = SqlDbType.Int;
                pnOrden.Direction = ParameterDirection.Input;
                pnOrden.Value = lstEnColumna[0].nOrden;
                #endregion pnOrden
                #region pcDescripcion
                pcDescripcion.ParameterName = "@pcDescripcion";
                pcDescripcion.SqlDbType = SqlDbType.VarChar;
                pcDescripcion.Direction = ParameterDirection.Input;
                pcDescripcion.Size = 50;
                pcDescripcion.Value = lstEnColumna[0].cDescripcion;
                #endregion pcDescripcion
                #region plModificable
                plModificable.ParameterName = "@plModificable";
                plModificable.SqlDbType = SqlDbType.Bit;
                plModificable.Direction = ParameterDirection.Input;
                plModificable.Value = lstEnColumna[0].lModificable;
                #endregion plModificable
                #region plCampoOrigen
                plCampoOrigen.ParameterName = "@plCampoOrigen";
                plCampoOrigen.SqlDbType = SqlDbType.Bit;
                plCampoOrigen.Direction = ParameterDirection.Input;
                plCampoOrigen.Value = lstEnColumna[0].lCampoOrigen;
                #endregion plCampoOrigen
                #region pcTipoCampo
                pcTipoCampo.ParameterName = "@pcTipoCampo";
                pcTipoCampo.SqlDbType = SqlDbType.VarChar;
                pcTipoCampo.Direction = ParameterDirection.Input;
                pcTipoCampo.Size = 15;
                pcTipoCampo.Value = lstEnColumna[0].cTipoCampo;
                #endregion pcTipoCampo
                #region pcTipoDato
                pcTipoDato.ParameterName = "@pcTipoDato";
                pcTipoDato.SqlDbType = SqlDbType.VarChar;
                pcTipoDato.Direction = ParameterDirection.Input;
                pcTipoDato.Size = 50;
                pcTipoDato.Value = lstEnColumna[0].cTipoDato;
                #endregion pcTipoDato
                #region pnLongDato
                pnLongDato.ParameterName = "@pnLongDato";
                pnLongDato.SqlDbType = SqlDbType.Int;
                pnLongDato.Direction = ParameterDirection.Input;
                pnLongDato.Value = lstEnColumna[0].nLongDato;
                #endregion pnLongDato
                #region plObligatorio
                plObligatorio.ParameterName = "@plObligatorio";
                plObligatorio.SqlDbType = SqlDbType.Bit;
                plObligatorio.Direction = ParameterDirection.Input;
                plObligatorio.Value = lstEnColumna[0].lObligatorio;
                #endregion plObligatorio
                #region pnEmpresa
                pnEmpresa.ParameterName = "@pnEmpresa";
                pnEmpresa.SqlDbType = SqlDbType.Int;
                pnEmpresa.Direction = ParameterDirection.Input;
                pnEmpresa.Value = lstEnColumna[0].nEmpresa;
                #endregion pnEmpresa
                #endregion Values

                #region Execute

                mxCrearVariables(lstEnColumna);
                SqlHelper.ExecuteNonQuery(loTransaccion, "CR_Columna_sp_Modificar",
                                          pnIdColumna,
                                          pnIdUser,
                                          pnIdTabla,
                                          pcNombreColumna,
                                          pcValor,
                                          plActivo,
                                          plVisible,
                                          pnOrden,
                                          pcDescripcion,
                                          plModificable,
                                          plCampoOrigen,
                                          pcTipoCampo,
                                          pcTipoDato,
                                          pnLongDato,
                                          plObligatorio,
                                          pnEmpresa
                                          );
                #endregion Execute
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable mxColumnaTrabajo_Listar(List<EnColumna> lstEnColumna)
        {
            DataSet ldsColumna = new DataSet();
            DataTable ldtColuma = new DataTable();
            SqlConnection loConexion = new SqlConnection();
            SqlDataAdapter ldaAdaptador = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                loConexion = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "CR_ColumnaTrabajo_sp_Listar";
                ldaAdaptador = new SqlDataAdapter(sqlCommand, loConexion);
                ldaAdaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
                ldaAdaptador.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[1];

                paramsToStore[0] = new SqlParameter("@nEmpresa", SqlDbType.Int);
                paramsToStore[0].Value = lstEnColumna[0].nEmpresa;

                ldaAdaptador.SelectCommand.Parameters.AddRange(paramsToStore);

                ldaAdaptador.Fill(ldsColumna, "DataTable1");
                ldtColuma = ldsColumna.Tables["DataTable1"];

                return ldtColuma;
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public DataTable mxColumnaTrabajo_ListarXRegistro(List<EnColumna> lstEnColumna)
        {
            DataSet ldsColumna = new DataSet();
            DataTable ldtColumna = new DataTable();
            SqlConnection loConexion = new SqlConnection();
            SqlDataAdapter loAdaptador = new SqlDataAdapter();
            string loCommand;
            try
            {
                loConexion = new SqlConnection(MSSQLConnectionString);
                loCommand = "sp_ColumnaTrabajo_ListarXRegistro";
                loAdaptador = new SqlDataAdapter(loCommand, loConexion);
                loAdaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
                loAdaptador.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];

                paramsToStore[0] = new SqlParameter("@nEmpresa", SqlDbType.Int);
                paramsToStore[0].Value = lstEnColumna[0].nEmpresa;

                paramsToStore[1] = new SqlParameter("@nIdColumna", SqlDbType.Int);
                paramsToStore[1].Value = lstEnColumna[0].nIdColumna;

                loAdaptador.SelectCommand.Parameters.AddRange(paramsToStore);

                loAdaptador.Fill(ldsColumna, "DataTable1");
                ldtColumna = ldsColumna.Tables["DataTable1"];

                return ldtColumna;
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public List<EnColumna> mxColumnaTrabajo_LlenarDropDownList(List<EnColumna> lstEnColumna)
        {
            DataSet ldsColumna = new DataSet();
            DataTable ldtColumna = new DataTable();
            SqlConnection loConexion = new SqlConnection();
            SqlDataAdapter loAdaptador = new SqlDataAdapter();
            List<EnColumna> lstColumna = new List<EnColumna>();
            string loCommand;
            try
            {
                loConexion = new SqlConnection(MSSQLConnectionString);
                loCommand = "sp_ColumnaTrabajo_LlenarDropDownList";
                loAdaptador = new SqlDataAdapter(loCommand, loConexion);
                loAdaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
                loAdaptador.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];

                paramsToStore[0] = new SqlParameter("@nEmpresa", SqlDbType.Int);
                paramsToStore[0].Value = lstEnColumna[0].nEmpresa;

                paramsToStore[1] = new SqlParameter("@nIdTabla", SqlDbType.Int);
                paramsToStore[1].Value = lstEnColumna[0].nIdTabla;

                loAdaptador.SelectCommand.Parameters.AddRange(paramsToStore);

                loAdaptador.Fill(ldsColumna, "DataTable1");
                ldtColumna = ldsColumna.Tables["DataTable1"];
                //lstColumna = new List<EnColumna>(ldtColumna.Rows.Count); //= ldtColumna.AsEnumerable().ToList();
                lstColumna = ldtColumna.AsEnumerable().
                                        Select(ldrEnColumna => new EnColumna { 
                                                                        nIdColumna = ldrEnColumna.Field<Int32>("nIdColumna").ToString(),
                                                                        cNombreColumna = ldrEnColumna.Field<string>("cNombreColumna"),
                                                                        cTipoDato = ldrEnColumna.Field<string>("cTipoDato"),
                                                                        cDescripcion = ldrEnColumna.Field<string>("cDescripcion")
                                                                        }).
                                                                        ToList();

                return lstColumna;
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public string mxObtenerTipoDatoXColumna(List<EnColumna> lstEnColumna)
        {
            string lcTipoDato;
            DataSet ldsColumna = new DataSet();
            //DataTable ldtColumna = new DataTable();
            SqlConnection loConexion = new SqlConnection();
            SqlDataAdapter loAdaptador = new SqlDataAdapter();
            string loCommand;
            try
            {
                loConexion = new SqlConnection(MSSQLConnectionString);
                loCommand = "sp_ColumnaTrabajo_Listar_X_nIdTabla";
                loAdaptador = new SqlDataAdapter(loCommand, loConexion);
                loAdaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
                loAdaptador.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];

                paramsToStore[0] = new SqlParameter("@nEmpresa", SqlDbType.Int);
                paramsToStore[0].Value = lstEnColumna[0].nEmpresa;

                paramsToStore[1] = new SqlParameter("@nIdColumna", SqlDbType.Int);
                paramsToStore[1].Value = lstEnColumna[0].nIdColumna;

                loAdaptador.SelectCommand.Parameters.AddRange(paramsToStore);

                loAdaptador.Fill(ldsColumna, "DataTable1");
                lcTipoDato = ldsColumna.Tables["DataTable1"].Rows[0]["cTipoDato"].ToString();

                return lcTipoDato;
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public List<EnOperador> mxOperadores_ListaXTipoDato()
        {
            DataSet ldsTablaTrabajo = new DataSet();
            DataTable ldtTablaTrabajo = new DataTable();
            SqlConnection loConexion = new SqlConnection();
            SqlDataAdapter loAdapatador = new SqlDataAdapter();
            List<EnOperador> lstOperador = new List<EnOperador>();
            string sqlCommand;
            try
            {
                loConexion = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "sp_Operadores_ListaXTipoDato";
                loAdapatador = new SqlDataAdapter(sqlCommand, loConexion);
                loAdapatador.SelectCommand.CommandType = CommandType.StoredProcedure;
                loAdapatador.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[1];

                paramsToStore[0] = new SqlParameter("@nEmpresa", SqlDbType.Int);
                paramsToStore[0].Value = "1";

                loAdapatador.SelectCommand.Parameters.AddRange(paramsToStore);

                loAdapatador.Fill(ldsTablaTrabajo, "DataTable1");
                ldtTablaTrabajo = ldsTablaTrabajo.Tables["DataTable1"];

                lstOperador = ldtTablaTrabajo.AsEnumerable().
                                        Select(ldrEnOperador => new EnOperador
                                        {
                                            nIdOperador = ldrEnOperador.Field<Int32>("nIdOperador").ToString(),
                                            cOperador = ldrEnOperador.Field<string>("cOperador"),
                                            cLogica = ldrEnOperador.Field<string>("cLogica"),
                                            lNumero = ldrEnOperador.Field<bool>("lNumero").ToString(),
                                            lCadena = ldrEnOperador.Field<bool>("lCadena").ToString(),
                                            lFecha = ldrEnOperador.Field<bool>("lFecha").ToString()
                                        }).ToList();
                return lstOperador;
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable TablaTrabajo_Listar(List<EnColumna> lstColumna)
        {
            DataSet ldsTablaTrabajo = new DataSet();
            DataTable ldtTablaTrabajo = new DataTable();
            SqlConnection loConexion = new SqlConnection();
            SqlDataAdapter loAdapatador = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                loConexion = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "CR_TablaTrabajo_sp_Listar";
                loAdapatador = new SqlDataAdapter(sqlCommand, loConexion);
                loAdapatador.SelectCommand.CommandType = CommandType.StoredProcedure;
                loAdapatador.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[1];

                paramsToStore[0] = new SqlParameter("@nEmpresa", SqlDbType.Int);
                paramsToStore[0].Value = lstColumna[0].nEmpresa;

                loAdapatador.SelectCommand.Parameters.AddRange(paramsToStore);

                loAdapatador.Fill(ldsTablaTrabajo, "DataTable1");
                ldtTablaTrabajo = ldsTablaTrabajo.Tables["DataTable1"];

                return ldtTablaTrabajo;
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }


        private void mxCrearVariables(List<EnColumna> lstEnColumna)
        {
            #region Values

            #region pnIdColumna
            pnIdColumna.ParameterName = "@pnIdColumna";
            pnIdColumna.SqlDbType = SqlDbType.Int;
            pnIdColumna.Direction = ParameterDirection.Input;
            pnIdColumna.Value = lstEnColumna[0].nIdColumna;
            #endregion pnIdColumna
            #region pnIdUser
            pnIdUser.ParameterName = "@pnIdUser";
            pnIdUser.SqlDbType = SqlDbType.Int;
            pnIdUser.Direction = ParameterDirection.Input;
            pnIdUser.Value = lstEnColumna[0].nIdUser;
            #endregion pnIdUser
            #region pnIdTabla
            pnIdTabla.ParameterName = "@pnIdTabla";
            pnIdUser.SqlDbType = SqlDbType.Int;
            pnIdUser.Direction = ParameterDirection.Input;
            pnIdTabla.Value = lstEnColumna[0].nIdTabla;
            #endregion pnIdTabla
            #region pcNombreColumna
            pcNombreColumna.ParameterName = "@pcNombreColumna";
            pcNombreColumna.SqlDbType = SqlDbType.VarChar;
            pcNombreColumna.Direction = ParameterDirection.Input;
            pcNombreColumna.Size = 50;
            pcNombreColumna.Value = lstEnColumna[0].cNombreColumna;
            #endregion pcNombreColumna
            #region pcValor
            pcValor.ParameterName = "@pcValor";
            pcValor.SqlDbType = SqlDbType.VarChar;
            pcValor.Direction = ParameterDirection.Input;
            pcValor.Size = 50;
            pcValor.Value = lstEnColumna[0].cValor;
            #endregion pcValor
            #region plActivo
            plActivo.ParameterName = "@plActivo";
            plActivo.SqlDbType = SqlDbType.Bit;
            plActivo.Direction = ParameterDirection.Input;
            plActivo.Value = lstEnColumna[0].lActivo;
            #endregion plActivo
            #region plVisible
            plVisible.ParameterName = "@plVisible";
            plVisible.SqlDbType = SqlDbType.Bit;
            plVisible.Direction = ParameterDirection.Input;
            plVisible.Value = lstEnColumna[0].lVisible;
            #endregion plVisible
            #region pnOrden
            pnOrden.ParameterName = "@pnOrden";
            pnOrden.SqlDbType = SqlDbType.Int;
            pnOrden.Direction = ParameterDirection.Input;
            pnOrden.Value = lstEnColumna[0].nOrden;
            #endregion pnOrden
            #region pcDescripcion
            pcDescripcion.ParameterName = "@pcDescripcion";
            pcDescripcion.SqlDbType = SqlDbType.VarChar;
            pcDescripcion.Direction = ParameterDirection.Input;
            pcDescripcion.Size = 50;
            pcDescripcion.Value = lstEnColumna[0].cDescripcion;
            #endregion pcDescripcion
            #region plModificable
            plModificable.ParameterName = "@plModificable";
            plModificable.SqlDbType = SqlDbType.Bit;
            plModificable.Direction = ParameterDirection.Input;
            plModificable.Value = lstEnColumna[0].lModificable;
            #endregion plModificable
            #region plCampoOrigen
            plCampoOrigen.ParameterName = "@plCampoOrigen";
            plCampoOrigen.SqlDbType = SqlDbType.Bit;
            plCampoOrigen.Direction = ParameterDirection.Input;
            plCampoOrigen.Value = lstEnColumna[0].lCampoOrigen;
            #endregion plCampoOrigen
            #region pcTipoCampo
            pcTipoCampo.ParameterName = "@pcTipoCampo";
            pcTipoCampo.SqlDbType = SqlDbType.VarChar;
            pcTipoCampo.Direction = ParameterDirection.Input;
            pcTipoCampo.Size = 15;
            pcTipoCampo.Value = lstEnColumna[0].cTipoCampo;
            #endregion pcTipoCampo
            #region pcTipoDato
            pcTipoDato.ParameterName = "@pcTipoDato";
            pcTipoDato.SqlDbType = SqlDbType.VarChar;
            pcTipoDato.Direction = ParameterDirection.Input;
            pcTipoDato.Size = 50;
            pcTipoDato.Value = lstEnColumna[0].cTipoDato;
            #endregion pcTipoDato
            #region pnLongDato
            pnLongDato.ParameterName = "@pnLongDato";
            pnLongDato.SqlDbType = SqlDbType.Int;
            pnLongDato.Direction = ParameterDirection.Input;
            pnLongDato.Value = lstEnColumna[0].nLongDato;
            #endregion pnLongDato
            #region plObligatorio
            plObligatorio.ParameterName = "@plObligatorio";
            plObligatorio.SqlDbType = SqlDbType.Bit;
            plObligatorio.Direction = ParameterDirection.Input;
            plObligatorio.Value = lstEnColumna[0].lObligatorio;
            #endregion plObligatorio
            #region pnEmpresa
            pnEmpresa.ParameterName = "@pnEmpresa";
            pnEmpresa.SqlDbType = SqlDbType.Int;
            pnEmpresa.Direction = ParameterDirection.Input;
            pnEmpresa.Value = lstEnColumna[0].nEmpresa;
            #endregion pnEmpresa
            #endregion Values
        }

        private void mxTablaTrabajo_Columna_Agregar(List<EnColumna> lstEnColumna, SqlTransaction loTransaccion)
        {
            this.mxCrearVariables(lstEnColumna);
            #region Execute

            SqlHelper.ExecuteNonQuery(loTransaccion, "CR_Columna_sp_Modificar",
                                      pnIdColumna,
                                      pnIdUser,
                                      pnIdTabla,
                                      pcNombreColumna,
                                      pcValor,
                                      plActivo,
                                      plVisible,
                                      pnOrden,
                                      pcDescripcion,
                                      plModificable,
                                      plCampoOrigen,
                                      pcTipoCampo,
                                      pcTipoDato,
                                      pnLongDato,
                                      plObligatorio,
                                      pnEmpresa
                                      );
            #endregion Execute
        }
        public void mxColumnaTrabajo_InsertarColumna(List<EnColumna> lstEnColumna, ref SqlTransaction loTransaccion)
        {
            try
            {
                #region Values
                #region pnIdTabla
                pnIdTabla.ParameterName = "@pnIdTabla";
                pnIdUser.SqlDbType = SqlDbType.Int;
                pnIdUser.Direction = ParameterDirection.Input;
                pnIdTabla.Value = lstEnColumna[0].nIdTabla;
                #endregion pnIdTabla
                #region pcNombreColumna
                pcNombreColumna.ParameterName = "@pcNombreColumna";
                pcNombreColumna.SqlDbType = SqlDbType.VarChar;
                pcNombreColumna.Direction = ParameterDirection.Input;
                pcNombreColumna.Size = 50;
                pcNombreColumna.Value = lstEnColumna[0].cNombreColumna;
                #endregion pcNombreColumna                
                #region pcTipoCampo
                pcTipoCampo.ParameterName = "@pcTipoCampo";
                pcTipoCampo.SqlDbType = SqlDbType.VarChar;
                pcTipoCampo.Direction = ParameterDirection.Input;
                pcTipoCampo.Size = 15;
                pcTipoCampo.Value = lstEnColumna[0].cTipoCampo;
                #endregion pcTipoCampo
                #region pcTipoDato
                pcTipoDato.ParameterName = "@pcTipoDato";
                pcTipoDato.SqlDbType = SqlDbType.VarChar;
                pcTipoDato.Direction = ParameterDirection.Input;
                pcTipoDato.Size = 50;
                pcTipoDato.Value = lstEnColumna[0].cTipoDato;
                #endregion pcTipoDato
                #region pnLongDato
                pnLongDato.ParameterName = "@pnLongDato";
                pnLongDato.SqlDbType = SqlDbType.Int;
                pnLongDato.Direction = ParameterDirection.Input;
                pnLongDato.Value = lstEnColumna[0].nLongDato;
                #endregion pnLongDato
                #endregion Values

                #region Execute

                mxCrearVariables(lstEnColumna);
                SqlHelper.ExecuteNonQuery(loTransaccion, "CR_ColumnaTrabajo_sp_InsertarColumna",
                                          pnIdTabla,
                                          pcNombreColumna,
                                          pcTipoCampo,
                                          pcTipoDato,
                                          pnLongDato
                                          );
                #endregion Execute
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
