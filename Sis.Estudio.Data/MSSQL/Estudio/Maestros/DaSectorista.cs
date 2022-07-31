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

    public class DaSectorista : DaConexion
    {
        public string Sectorista_INS(List<EnSectorista> ListEnSectorista, SqlTransaction tran)
        {
            string IdReturn = String.Empty;
            SqlDataReader drParamReturn;
            try
            {
                #region Parametros
                SqlParameter prm_NEMPRESA = new SqlParameter();
                SqlParameter prm_CODSECTORISTA = new SqlParameter();
                SqlParameter prm_CODZONA = new SqlParameter();
                SqlParameter prm_SECTORISTA = new SqlParameter();
                SqlParameter prm_CODIGOINTERNO = new SqlParameter();
                SqlParameter prm_ESTADO = new SqlParameter();
                SqlParameter prm_CODUSUARIO = new SqlParameter();
                #endregion Parametros

                #region Values
                #region nempresa
                prm_NEMPRESA.ParameterName = "@nempresa";
                prm_NEMPRESA.SqlDbType = SqlDbType.Int;
                prm_NEMPRESA.Direction = ParameterDirection.Input;
                prm_NEMPRESA.Value = ListEnSectorista[0].NEmpresa;
                #endregion nempresa
                #region CodSectorista
                prm_CODSECTORISTA.ParameterName = "@CodSectorista";
                prm_CODSECTORISTA.SqlDbType = SqlDbType.Int;
                prm_CODSECTORISTA.Direction = ParameterDirection.Input;
                prm_CODSECTORISTA.Value = ListEnSectorista[0].CodSectorista;
                #endregion CodSectorista
                #region CodZona
                prm_CODZONA.ParameterName = "@CodZona";
                prm_CODZONA.SqlDbType = SqlDbType.Int;
                prm_CODZONA.Direction = ParameterDirection.Input;
                prm_CODZONA.Value = ListEnSectorista[0].CodZona;
                #endregion CodZona
                #region Sectorista
                prm_SECTORISTA.ParameterName = "@Sectorista";
                prm_SECTORISTA.SqlDbType = SqlDbType.VarChar;
                prm_SECTORISTA.Direction = ParameterDirection.Input;
                prm_SECTORISTA.Size = 120;
                prm_SECTORISTA.Value = ListEnSectorista[0].Sectorista;
                #endregion Sectorista
                #region CodigoInterno
                prm_CODIGOINTERNO.ParameterName = "@CodigoInterno";
                prm_CODIGOINTERNO.SqlDbType = SqlDbType.Int;
                prm_CODIGOINTERNO.Direction = ParameterDirection.Input;
                prm_CODIGOINTERNO.Value = ListEnSectorista[0].CodigoInterno;
                #endregion CodigoInterno
                #region Estado
                prm_ESTADO.ParameterName = "@Estado";
                prm_ESTADO.SqlDbType = SqlDbType.Char;
                prm_ESTADO.Direction = ParameterDirection.Input;
                prm_ESTADO.Size = 1;
                prm_ESTADO.Value = ListEnSectorista[0].Estado;
                #endregion Estado
                #region CodUsuario
                prm_CODUSUARIO.ParameterName = "@CodUsuario";
                prm_CODUSUARIO.SqlDbType = SqlDbType.Int;
                prm_CODUSUARIO.Direction = ParameterDirection.Input;
                prm_CODUSUARIO.Value = ListEnSectorista[0].CodUsuario;
                #endregion CodUsuario
                #endregion Values

                #region Execute
                drParamReturn = SqlHelper.ExecuteReader(tran, "CR_Sectorista_sp_Insertar",
                                               prm_NEMPRESA,
                                               prm_CODSECTORISTA,
                                               prm_CODZONA,
                                               prm_SECTORISTA,
                                               prm_CODIGOINTERNO,
                                               prm_ESTADO,
                                               prm_CODUSUARIO
                                               );
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
        public void Sectorista_UPD(List<EnSectorista> ListEnSectorista, SqlTransaction tran)
        {
            try
            {
                #region Parametros
                SqlParameter prm_CODSECTORISTA = new SqlParameter();
                SqlParameter prm_CODZONA = new SqlParameter();
                SqlParameter prm_SECTORISTA = new SqlParameter();
                SqlParameter prm_CODIGOINTERNO = new SqlParameter();
                SqlParameter prm_ESTADO = new SqlParameter();
                SqlParameter prm_CODUSUARIO = new SqlParameter();
                #endregion Parametros


                #region Values
                #region CodSectorista
                prm_CODSECTORISTA.ParameterName = "@CodSectorista";
                prm_CODSECTORISTA.SqlDbType = SqlDbType.Int;
                prm_CODSECTORISTA.Direction = ParameterDirection.Input;
                prm_CODSECTORISTA.Value = ListEnSectorista[0].CodSectorista;
                #endregion CodSectorista
                #region CodZona
                prm_CODZONA.ParameterName = "@CodZona";
                prm_CODZONA.SqlDbType = SqlDbType.Int;
                prm_CODZONA.Direction = ParameterDirection.Input;
                prm_CODZONA.Value = ListEnSectorista[0].CodZona;
                #endregion CodZona
                #region Sectorista
                prm_SECTORISTA.ParameterName = "@Sectorista";
                prm_SECTORISTA.SqlDbType = SqlDbType.VarChar;
                prm_SECTORISTA.Direction = ParameterDirection.Input;
                prm_SECTORISTA.Size = 120;
                prm_SECTORISTA.Value = ListEnSectorista[0].Sectorista;
                #endregion Sectorista
                #region CodigoInterno
                prm_CODIGOINTERNO.ParameterName = "@CodigoInterno";
                prm_CODIGOINTERNO.SqlDbType = SqlDbType.Int;
                prm_CODIGOINTERNO.Direction = ParameterDirection.Input;
                prm_CODIGOINTERNO.Value = ListEnSectorista[0].CodigoInterno;
                #endregion CodigoInterno
                #region Estado
                prm_ESTADO.ParameterName = "@Estado";
                prm_ESTADO.SqlDbType = SqlDbType.Char;
                prm_ESTADO.Direction = ParameterDirection.Input;
                prm_ESTADO.Size = 1;
                prm_ESTADO.Value = ListEnSectorista[0].Estado;
                #endregion Estado
                #region CodUsuario
                prm_CODUSUARIO.ParameterName = "@CodUsuario";
                prm_CODUSUARIO.SqlDbType = SqlDbType.Int;
                prm_CODUSUARIO.Direction = ParameterDirection.Input;
                prm_CODUSUARIO.Value = ListEnSectorista[0].CodUsuario;
                #endregion CodUsuario
                #endregion Values



                #region Execute
                SqlHelper.ExecuteNonQuery(tran, "CR_Sectorista_sp_Modificar",
                                               prm_CODSECTORISTA,
                                               prm_CODZONA,
                                               prm_SECTORISTA,
                                               prm_CODIGOINTERNO,
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
        public DataTable Sectorista_Listar(List<EnSectorista> ListEnSectorista)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "CR_Cliente_sp_Sectorista";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[1];

                paramsToStore[0] = new SqlParameter("@nempresa", SqlDbType.Int);
                paramsToStore[0].Value = ListEnSectorista[0].NEmpresa;

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
        public DataTable Sectorista_Listar_Reg(List<EnSectorista> ListEnSectorista)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "CR_Sectorista_sp_CargaREG";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];

                paramsToStore[0] = new SqlParameter("@nempresa", SqlDbType.Int);
                paramsToStore[0].Value = ListEnSectorista[0].NEmpresa;

                paramsToStore[1] = new SqlParameter("@CodSectorista", SqlDbType.Int);
                paramsToStore[1].Value = ListEnSectorista[0].CodSectorista;

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
        public DataTable Sectorista_Litar_X_Zona(List<EnSectorista> ListEnSectorista)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "CR_Cliente_sp_Sectorista_x_Zona";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];

                paramsToStore[0] = new SqlParameter("@nempresa", SqlDbType.Int);
                paramsToStore[0].Value = ListEnSectorista[0].NEmpresa;

                paramsToStore[1] = new SqlParameter("@CodZona", SqlDbType.Int);
                paramsToStore[1].Value = ListEnSectorista[0].CodZona;

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
