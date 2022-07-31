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
    public class DaGarantia : DaConexion
    {

        public string Garantia_INS(List<EnGarantia> ListEnGarantia, SqlTransaction tran)
        {
            string IdReturn = String.Empty;
            SqlDataReader drParamReturn;
            try
            {
                #region Parametros
                SqlParameter prm_CODGARANTIA = new SqlParameter();
                SqlParameter prm_GARANTIA = new SqlParameter();
                SqlParameter prm_ESTADO = new SqlParameter();
                SqlParameter prm_CODUSUARIO = new SqlParameter();
                #endregion Parametros

                #region Values
                #region CodGarantia
                prm_CODGARANTIA.ParameterName = "@CodGarantia";
                prm_CODGARANTIA.SqlDbType = SqlDbType.Int;
                prm_CODGARANTIA.Direction = ParameterDirection.Input;
                prm_CODGARANTIA.Value = ListEnGarantia[0].CodGarantia;
                #endregion CodGarantia
                #region Garantia
                prm_GARANTIA.ParameterName = "@Garantia";
                prm_GARANTIA.SqlDbType = SqlDbType.VarChar;
                prm_GARANTIA.Direction = ParameterDirection.Input;
                prm_GARANTIA.Size = 60;
                prm_GARANTIA.Value = ListEnGarantia[0].Garantia;
                #endregion Garantia
                #region Estado
                prm_ESTADO.ParameterName = "@Estado";
                prm_ESTADO.SqlDbType = SqlDbType.Char;
                prm_ESTADO.Direction = ParameterDirection.Input;
                prm_ESTADO.Size = 1;
                prm_ESTADO.Value = ListEnGarantia[0].Estado;
                #endregion Estado
                #region CodUsuario
                prm_CODUSUARIO.ParameterName = "@CodUsuario";
                prm_CODUSUARIO.SqlDbType = SqlDbType.Int;
                prm_CODUSUARIO.Direction = ParameterDirection.Input;
                prm_CODUSUARIO.Value = ListEnGarantia[0].CodUsuario;
                #endregion CodUsuario
                #endregion Values

                #region Execute
                drParamReturn = SqlHelper.ExecuteReader(tran, "CR_Garantia_sp_Insertar",
                                               prm_CODGARANTIA,
                                               prm_GARANTIA,
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
        public void Garantia_UPD(List<EnGarantia> ListEnGarantia, SqlTransaction tran)
        {
            try
            {
                #region Parametros
                SqlParameter prm_CODGARANTIA = new SqlParameter();
                SqlParameter prm_GARANTIA = new SqlParameter();
                SqlParameter prm_ESTADO = new SqlParameter();
                SqlParameter prm_CODUSUARIO = new SqlParameter();
                #endregion Parametros


                #region Values
                #region CodGarantia
                prm_CODGARANTIA.ParameterName = "@CodGarantia";
                prm_CODGARANTIA.SqlDbType = SqlDbType.Int;
                prm_CODGARANTIA.Direction = ParameterDirection.Input;
                prm_CODGARANTIA.Value = ListEnGarantia[0].CodGarantia;
                #endregion CodGarantia
                #region Garantia
                prm_GARANTIA.ParameterName = "@Garantia";
                prm_GARANTIA.SqlDbType = SqlDbType.VarChar;
                prm_GARANTIA.Direction = ParameterDirection.Input;
                prm_GARANTIA.Size = 60;
                prm_GARANTIA.Value = ListEnGarantia[0].Garantia;
                #endregion Garantia
                #region Estado
                prm_ESTADO.ParameterName = "@Estado";
                prm_ESTADO.SqlDbType = SqlDbType.Char;
                prm_ESTADO.Direction = ParameterDirection.Input;
                prm_ESTADO.Size = 1;
                prm_ESTADO.Value = ListEnGarantia[0].Estado;
                #endregion Estado
                #region CodUsuario
                prm_CODUSUARIO.ParameterName = "@CodUsuario";
                prm_CODUSUARIO.SqlDbType = SqlDbType.Int;
                prm_CODUSUARIO.Direction = ParameterDirection.Input;
                prm_CODUSUARIO.Value = ListEnGarantia[0].CodUsuario;
                #endregion CodUsuario
                #endregion Values



                #region Execute
                SqlHelper.ExecuteNonQuery(tran, "CR_Garantia_sp_Modificar",
                                               prm_CODGARANTIA,
                                               prm_GARANTIA,
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
        public DataTable Garantia_Listar(List<EnGarantia> ListEnGarantia)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "CR_Cliente_sp_Garantia";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[1];

                paramsToStore[0] = new SqlParameter("@nempresa", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGarantia[0].NEmpresa;

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
        public DataTable Garantia_Listar_Reg(List<EnGarantia> ListEnGarantia)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "CR_Garantia_sp_CargaREG";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];

                paramsToStore[0] = new SqlParameter("@NEMPRESA", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGarantia[0].NEmpresa;

                paramsToStore[1] = new SqlParameter("@CodGarantia", SqlDbType.Int);
                paramsToStore[1].Value = ListEnGarantia[0].CodGarantia;

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
