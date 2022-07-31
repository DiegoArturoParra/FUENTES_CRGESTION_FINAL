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
    public class DaGS_JerarquiaB : DaConexion
    {


        public string GS_JerarquiaB_INS(List<EnGS_JerarquiaB> ListEnGS_JerarquiaB, SqlTransaction tran)
        {
            string IdReturn = String.Empty;
            SqlDataReader drParamReturn;

            SqlParameter prm_cod_jerarquiaA = new SqlParameter();
            SqlParameter prm_desc_jerarquiaB = new SqlParameter();
            SqlParameter prm_CodUsuario = new SqlParameter();
            SqlParameter prm_CEMPRESA = new SqlParameter();
            try
            {

                #region Values

                prm_cod_jerarquiaA.ParameterName = "@cod_jerarquiaA";
                prm_cod_jerarquiaA.SqlDbType = SqlDbType.Int;
                prm_cod_jerarquiaA.Direction = ParameterDirection.Input;
                prm_cod_jerarquiaA.Value = ListEnGS_JerarquiaB[0].cod_jerarquiaA;

                prm_desc_jerarquiaB.ParameterName = "@desc_jerarquiaB";
                prm_desc_jerarquiaB.SqlDbType = SqlDbType.VarChar;
                prm_desc_jerarquiaB.Direction = ParameterDirection.Input;
                prm_desc_jerarquiaB.Size = 250;
                prm_desc_jerarquiaB.Value = ListEnGS_JerarquiaB[0].desc_jerarquiaB;

                prm_CEMPRESA.ParameterName = "@CEMPRESA";
                prm_CEMPRESA.SqlDbType = SqlDbType.Char;
                prm_CEMPRESA.Direction = ParameterDirection.Input;
                prm_CEMPRESA.Size = 2;
                prm_CEMPRESA.Value = ListEnGS_JerarquiaB[0].nempresa;

                #region prm_CodUsuario
                prm_CodUsuario.ParameterName = "@CodUsuarioRegistra";
                prm_CodUsuario.SqlDbType = SqlDbType.Int;
                prm_CodUsuario.Direction = ParameterDirection.Input;
                prm_CodUsuario.Value = ListEnGS_JerarquiaB[0].CodUsuario;
                #endregion prm_CodUsuario 

                #endregion Values


                drParamReturn = SqlHelper.ExecuteReader(tran, "dbo.GS_JerarquiaB_sp_Insertar",
                                        prm_cod_jerarquiaA,
                                        prm_desc_jerarquiaB, prm_CodUsuario, prm_CEMPRESA
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

        public void GS_JerarquiaB_UPD(List<EnGS_JerarquiaB> ListEnGS_JerarquiaB, SqlTransaction tran)
        {
            try
            {
                #region Parametros
                SqlParameter prm_cod_jerarquiaB = new SqlParameter();
                SqlParameter prm_cod_jerarquiaA = new SqlParameter();
                SqlParameter prm_desc_jerarquiaB = new SqlParameter();
                SqlParameter prm_CodUsuario = new SqlParameter();
                #endregion Parametros


                #region Values



                prm_cod_jerarquiaB.ParameterName = "@cod_jerarquiaB";
                prm_cod_jerarquiaB.SqlDbType = SqlDbType.Int;
                prm_cod_jerarquiaB.Direction = ParameterDirection.Input;
                prm_cod_jerarquiaB.Value = ListEnGS_JerarquiaB[0].cod_jerarquiaB;

                prm_cod_jerarquiaA.ParameterName = "@cod_jerarquiaA";
                prm_cod_jerarquiaA.SqlDbType = SqlDbType.Int;
                prm_cod_jerarquiaA.Direction = ParameterDirection.Input;
                prm_cod_jerarquiaA.Value = ListEnGS_JerarquiaB[0].cod_jerarquiaA;

                prm_desc_jerarquiaB.ParameterName = "@desc_jerarquiaB";
                prm_desc_jerarquiaB.SqlDbType = SqlDbType.VarChar;
                prm_desc_jerarquiaB.Direction = ParameterDirection.Input;
                prm_desc_jerarquiaB.Size = 250;
                prm_desc_jerarquiaB.Value = ListEnGS_JerarquiaB[0].desc_jerarquiaB;

                #region prm_CodUsuario
                prm_CodUsuario.ParameterName = "@CodUsuarioRegistra";
                prm_CodUsuario.SqlDbType = SqlDbType.Int;
                prm_CodUsuario.Direction = ParameterDirection.Input;
                prm_CodUsuario.Value = ListEnGS_JerarquiaB[0].CodUsuario;
                #endregion prm_CodUsuario 

                #endregion Values



                #region Execute
                SqlHelper.ExecuteNonQuery(tran, "GS_JerarquiaB_sp_Modificar",
                                                prm_cod_jerarquiaB,                           
                                                prm_cod_jerarquiaA,
                                               prm_desc_jerarquiaB, prm_CodUsuario
                                               );
                #endregion Execute
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GS_JerarquiaB_Reg(List<EnGS_JerarquiaB> ListEnGS_JerarquiaB)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_JerarquiaB_sp_Registro";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[1];


                paramsToStore[0] = new SqlParameter("@cod_jerarquiaB", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_JerarquiaB[0].cod_jerarquiaB;

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

        public void GS_JerarquiaB_DEL(List<EnGS_JerarquiaB> ListEnGS_JerarquiaB, SqlTransaction tran)
        {
            try
            {
                #region Parametros
                SqlParameter prm_cod_jerarquiaB = new SqlParameter();
                SqlParameter prm_CodUsuario = new SqlParameter();
                #endregion Parametros


                #region Values


                prm_cod_jerarquiaB.ParameterName = "@cod_jerarquiaB";
                prm_cod_jerarquiaB.SqlDbType = SqlDbType.Int;
                prm_cod_jerarquiaB.Direction = ParameterDirection.Input;
                prm_cod_jerarquiaB.Value = ListEnGS_JerarquiaB[0].cod_jerarquiaB;

                #region prm_CodUsuario
                prm_CodUsuario.ParameterName = "@CodUsuarioRegistra";
                prm_CodUsuario.SqlDbType = SqlDbType.Int;
                prm_CodUsuario.Direction = ParameterDirection.Input;
                prm_CodUsuario.Value = ListEnGS_JerarquiaB[0].CodUsuario;
                #endregion prm_CodUsuario 

                #endregion Values

                #region Execute
                SqlHelper.ExecuteNonQuery(tran, "GS_JerarquiaB_sp_Eliminar",
                                               prm_cod_jerarquiaB, prm_CodUsuario
                                               );
                #endregion Execute
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GS_JerarquiaB_Lista(List<EnGS_JerarquiaB> ListEnGS_JerarquiaB)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_JerarquiaB_sp_Listar";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];

                paramsToStore[0] = new SqlParameter("@desc_jerarquiaB", SqlDbType.VarChar);
                paramsToStore[0].Value = ListEnGS_JerarquiaB[0].desc_jerarquiaB;
                paramsToStore[0].Size = 250;

                paramsToStore[1] = new SqlParameter("@CEmpresa", SqlDbType.Char);
                paramsToStore[1].Value = ListEnGS_JerarquiaB[0].nempresa;
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

        public DataTable GS_JerarquiaB_Combo(List<EnGS_JerarquiaB> ListEnGS_JerarquiaB)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_JerarquiaB_sp_Listar_Combo";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];

                paramsToStore[0] = new SqlParameter("@cod_jerarquiaA", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_JerarquiaB[0].cod_jerarquiaA;

                paramsToStore[1] = new SqlParameter("@CEmpresa", SqlDbType.Char);
                paramsToStore[1].Value = ListEnGS_JerarquiaB[0].nempresa;
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
