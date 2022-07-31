using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Sis.Estudio.Entity;

namespace Sis.Estudio.Data.MSSQL.Gestion
{
    public class DaGS_JerarquiaC : DaConexion
    {


        public string GS_JerarquiaC_INS(List<EnGS_JerarquiaC> ListEnGS_JerarquiaC, SqlTransaction tran)
        {
            string IdReturn = String.Empty;
            SqlDataReader drParamReturn;

            SqlParameter prm_cod_jerarquiaB = new SqlParameter();
            SqlParameter prm_cod_jerarquiaA = new SqlParameter();
            SqlParameter prm_desc_jerarquiaC = new SqlParameter();
            SqlParameter prm_CodUsuario = new SqlParameter();
            SqlParameter prm_CEMPRESA = new SqlParameter();
            try
            {

                #region Values

                prm_cod_jerarquiaB.ParameterName = "@cod_jerarquiaB";
                prm_cod_jerarquiaB.SqlDbType = SqlDbType.Int;
                prm_cod_jerarquiaB.Direction = ParameterDirection.Input;
                prm_cod_jerarquiaB.Value = ListEnGS_JerarquiaC[0].cod_jerarquiaB;

                prm_cod_jerarquiaA.ParameterName = "@cod_jerarquiaA";
                prm_cod_jerarquiaA.SqlDbType = SqlDbType.Int;
                prm_cod_jerarquiaA.Direction = ParameterDirection.Input;
                prm_cod_jerarquiaA.Value = ListEnGS_JerarquiaC[0].cod_jerarquiaA;

                prm_desc_jerarquiaC.ParameterName = "@desc_jerarquiaC";
                prm_desc_jerarquiaC.SqlDbType = SqlDbType.VarChar;
                prm_desc_jerarquiaC.Direction = ParameterDirection.Input;
                prm_desc_jerarquiaC.Size = 250;
                prm_desc_jerarquiaC.Value = ListEnGS_JerarquiaC[0].desc_jerarquiaC;

                #region prm_CodUsuario
                prm_CodUsuario.ParameterName = "@CodUsuarioRegistra";
                prm_CodUsuario.SqlDbType = SqlDbType.Int;
                prm_CodUsuario.Direction = ParameterDirection.Input;
                prm_CodUsuario.Value = ListEnGS_JerarquiaC[0].CodUsuario;
                #endregion prm_CodUsuario 

                prm_CEMPRESA.ParameterName = "@CEMPRESA";
                prm_CEMPRESA.SqlDbType = SqlDbType.Char;
                prm_CEMPRESA.Direction = ParameterDirection.Input;
                prm_CEMPRESA.Size = 2;
                prm_CEMPRESA.Value = ListEnGS_JerarquiaC[0].nempresa;

                #endregion Values


                drParamReturn = SqlHelper.ExecuteReader(tran, "dbo.GS_JerarquiaC_sp_Insertar",
                                            prm_cod_jerarquiaB,                    
                                            prm_cod_jerarquiaA,
                                            prm_desc_jerarquiaC, prm_CodUsuario, prm_CEMPRESA
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

        public void GS_JerarquiaC_UPD(List<EnGS_JerarquiaC> ListEnGS_JerarquiaC, SqlTransaction tran)
        {
            try
            {
                #region Parametros
                SqlParameter prm_cod_jerarquiaC = new SqlParameter();
                SqlParameter prm_cod_jerarquiaB = new SqlParameter();
                SqlParameter prm_cod_jerarquiaA = new SqlParameter();
                SqlParameter prm_desc_jerarquiaC = new SqlParameter();
                SqlParameter prm_CodUsuario = new SqlParameter();
                #endregion Parametros


                #region Values



                prm_cod_jerarquiaC.ParameterName = "@cod_jerarquiaC";
                prm_cod_jerarquiaC.SqlDbType = SqlDbType.Int;
                prm_cod_jerarquiaC.Direction = ParameterDirection.Input;
                prm_cod_jerarquiaC.Value = ListEnGS_JerarquiaC[0].cod_jerarquiaC;

                prm_cod_jerarquiaB.ParameterName = "@cod_jerarquiaB";
                prm_cod_jerarquiaB.SqlDbType = SqlDbType.Int;
                prm_cod_jerarquiaB.Direction = ParameterDirection.Input;
                prm_cod_jerarquiaB.Value = ListEnGS_JerarquiaC[0].cod_jerarquiaB;

                prm_cod_jerarquiaA.ParameterName = "@cod_jerarquiaA";
                prm_cod_jerarquiaA.SqlDbType = SqlDbType.Int;
                prm_cod_jerarquiaA.Direction = ParameterDirection.Input;
                prm_cod_jerarquiaA.Value = ListEnGS_JerarquiaC[0].cod_jerarquiaA;

                prm_desc_jerarquiaC.ParameterName = "@desc_jerarquiaC";
                prm_desc_jerarquiaC.SqlDbType = SqlDbType.VarChar;
                prm_desc_jerarquiaC.Direction = ParameterDirection.Input;
                prm_desc_jerarquiaC.Size = 250;
                prm_desc_jerarquiaC.Value = ListEnGS_JerarquiaC[0].desc_jerarquiaC;

                #region prm_CodUsuario
                prm_CodUsuario.ParameterName = "@CodUsuarioRegistra";
                prm_CodUsuario.SqlDbType = SqlDbType.Int;
                prm_CodUsuario.Direction = ParameterDirection.Input;
                prm_CodUsuario.Value = ListEnGS_JerarquiaC[0].CodUsuario;
                #endregion prm_CodUsuario 

                #endregion Values



                #region Execute
                SqlHelper.ExecuteNonQuery(tran, "GS_JerarquiaC_sp_Modificar",
                                                prm_cod_jerarquiaC,
                                                prm_cod_jerarquiaB,
                                                prm_cod_jerarquiaA,
                                               prm_desc_jerarquiaC, prm_CodUsuario
                                               );
                #endregion Execute
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GS_JerarquiaC_Reg(List<EnGS_JerarquiaC> ListEnGS_JerarquiaC)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_JerarquiaC_sp_Registro";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[1];


                paramsToStore[0] = new SqlParameter("@cod_jerarquiaC", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_JerarquiaC[0].cod_jerarquiaC;

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

        public void GS_JerarquiaC_DEL(List<EnGS_JerarquiaC> ListEnGS_JerarquiaC, SqlTransaction tran)
        {
            try
            {
                #region Parametros
                SqlParameter prm_cod_jerarquiaC = new SqlParameter();
                SqlParameter prm_CodUsuario = new SqlParameter();
                #endregion Parametros


                #region Values


                prm_cod_jerarquiaC.ParameterName = "@cod_jerarquiaC";
                prm_cod_jerarquiaC.SqlDbType = SqlDbType.Int;
                prm_cod_jerarquiaC.Direction = ParameterDirection.Input;
                prm_cod_jerarquiaC.Value = ListEnGS_JerarquiaC[0].cod_jerarquiaC;

                #region prm_CodUsuario
                prm_CodUsuario.ParameterName = "@CodUsuarioRegistra";
                prm_CodUsuario.SqlDbType = SqlDbType.Int;
                prm_CodUsuario.Direction = ParameterDirection.Input;
                prm_CodUsuario.Value = ListEnGS_JerarquiaC[0].CodUsuario;
                #endregion prm_CodUsuario 

                #endregion Values

                #region Execute
                SqlHelper.ExecuteNonQuery(tran, "GS_JerarquiaC_sp_Eliminar",
                                               prm_cod_jerarquiaC, prm_CodUsuario
                                               );
                #endregion Execute
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GS_JerarquiaC_Lista(List<EnGS_JerarquiaC> ListEnGS_JerarquiaC)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_JerarquiaC_sp_Listar";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];

                paramsToStore[0] = new SqlParameter("@desc_jerarquiaC", SqlDbType.VarChar);
                paramsToStore[0].Value = ListEnGS_JerarquiaC[0].desc_jerarquiaC;
                paramsToStore[0].Size = 250;

                paramsToStore[1] = new SqlParameter("@CEmpresa", SqlDbType.Char);
                paramsToStore[1].Value = ListEnGS_JerarquiaC[0].nempresa;
                paramsToStore[1].Size = 2;

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

        public DataTable GS_JerarquiaC_Combo(List<EnGS_JerarquiaC> ListEnGS_JerarquiaC)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_JerarquiaC_sp_Listar_Combo";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];

                paramsToStore[0] = new SqlParameter("@cod_jerarquiaB", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_JerarquiaC[0].cod_jerarquiaB;

                paramsToStore[1] = new SqlParameter("@CEmpresa", SqlDbType.Char);
                paramsToStore[1].Value = ListEnGS_JerarquiaC[0].nempresa;
                paramsToStore[1].Size = 2;

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

        public DataTable GS_JerarquiaC_sp_ObtenerUsuario(List<EnGS_JerarquiaC> ListEnGS_JerarquiaC)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_JerarquiaC_sp_ObtenerUsuario";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];

                paramsToStore[0] = new SqlParameter("@cod_jerarquiaC", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_JerarquiaC[0].cod_jerarquiaC;

                paramsToStore[1] = new SqlParameter("@CEmpresa", SqlDbType.Char);
                paramsToStore[1].Value = ListEnGS_JerarquiaC[0].nempresa;
                paramsToStore[1].Size = 2;

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
