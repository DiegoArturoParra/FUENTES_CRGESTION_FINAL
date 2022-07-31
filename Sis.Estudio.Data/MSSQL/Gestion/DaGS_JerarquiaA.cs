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
    public class DaGS_JerarquiaA : DaConexion
    {


        public string GS_JerarquiaA_INS(List<EnGS_JerarquiaA> ListEnGS_JerarquiaA, SqlTransaction tran)
        {
            string IdReturn = String.Empty;
            SqlDataReader drParamReturn;

            SqlParameter prm_desc_jerarquiaA = new SqlParameter();
            SqlParameter prm_CodUsuario = new SqlParameter();
            SqlParameter prm_CEMPRESA = new SqlParameter();
            SqlParameter prm_id_ejecutores = new SqlParameter();
            try
            {

                #region Values


                prm_desc_jerarquiaA.ParameterName = "@desc_jerarquiaA";
                prm_desc_jerarquiaA.SqlDbType = SqlDbType.VarChar;
                prm_desc_jerarquiaA.Direction = ParameterDirection.Input;
                prm_desc_jerarquiaA.Size = 250;
                prm_desc_jerarquiaA.Value = ListEnGS_JerarquiaA[0].desc_jerarquiaA;

                #region prm_CodUsuario
                prm_CodUsuario.ParameterName = "@CodUsuarioRegistra";
                prm_CodUsuario.SqlDbType = SqlDbType.Int;
                prm_CodUsuario.Direction = ParameterDirection.Input;
                prm_CodUsuario.Value = ListEnGS_JerarquiaA[0].CodUsuario;
                #endregion prm_CodUsuario 
                
                prm_CEMPRESA.ParameterName = "@CEMPRESA";
                prm_CEMPRESA.SqlDbType = SqlDbType.Char;
                prm_CEMPRESA.Direction = ParameterDirection.Input;
                prm_CEMPRESA.Size = 2;
                prm_CEMPRESA.Value = ListEnGS_JerarquiaA[0].nempresa;

                prm_id_ejecutores.ParameterName = "@id_ejecutores";
                prm_id_ejecutores.SqlDbType = SqlDbType.Int;
                prm_id_ejecutores.Direction = ParameterDirection.Input;
                prm_id_ejecutores.Value = ListEnGS_JerarquiaA[0].id_ejecutores;

                #endregion Values


                drParamReturn = SqlHelper.ExecuteReader(tran, "dbo.GS_JerarquiaA_sp_Insertar",
                                               prm_desc_jerarquiaA, prm_CodUsuario, prm_CEMPRESA, prm_id_ejecutores
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

        public void GS_JerarquiaA_UPD(List<EnGS_JerarquiaA> ListEnGS_JerarquiaA, SqlTransaction tran)
        {
            try
            {
                #region Parametros
                SqlParameter prm_cod_jerarquiaA = new SqlParameter();
                SqlParameter prm_desc_jerarquiaA = new SqlParameter();
                SqlParameter prm_CodUsuario = new SqlParameter();
                SqlParameter prm_id_ejecutores = new SqlParameter();
                #endregion Parametros


                #region Values


                prm_cod_jerarquiaA.ParameterName = "@cod_jerarquiaA";
                prm_cod_jerarquiaA.SqlDbType = SqlDbType.Int;
                prm_cod_jerarquiaA.Direction = ParameterDirection.Input;
                prm_cod_jerarquiaA.Value = ListEnGS_JerarquiaA[0].cod_jerarquiaA;

                prm_desc_jerarquiaA.ParameterName = "@desc_jerarquiaA";
                prm_desc_jerarquiaA.SqlDbType = SqlDbType.VarChar;
                prm_desc_jerarquiaA.Direction = ParameterDirection.Input;
                prm_desc_jerarquiaA.Size = 250;
                prm_desc_jerarquiaA.Value = ListEnGS_JerarquiaA[0].desc_jerarquiaA;

                #region prm_CodUsuario
                prm_CodUsuario.ParameterName = "@CodUsuarioRegistra";
                prm_CodUsuario.SqlDbType = SqlDbType.Int;
                prm_CodUsuario.Direction = ParameterDirection.Input;
                prm_CodUsuario.Value = ListEnGS_JerarquiaA[0].CodUsuario;
                #endregion prm_CodUsuario 


                #region prm_id_ejecutores
                prm_id_ejecutores.ParameterName = "@id_ejecutores";
                prm_id_ejecutores.SqlDbType = SqlDbType.Int;
                prm_id_ejecutores.Direction = ParameterDirection.Input;
                prm_id_ejecutores.Value = ListEnGS_JerarquiaA[0].id_ejecutores;
                #endregion prm_id_ejecutores



                #endregion Values



                #region Execute
                SqlHelper.ExecuteNonQuery(tran, "GS_JerarquiaA_sp_Modificar",
                                               prm_cod_jerarquiaA,
                                               prm_desc_jerarquiaA, prm_CodUsuario, prm_id_ejecutores
                                               );
                #endregion Execute
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GS_JerarquiaA_Reg(List<EnGS_JerarquiaA> ListEnGS_JerarquiaA)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_JerarquiaA_sp_Registro";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[1];


                paramsToStore[0] = new SqlParameter("@cod_jerarquiaA", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_JerarquiaA[0].cod_jerarquiaA;

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

        public void GS_JerarquiaA_DEL(List<EnGS_JerarquiaA> ListEnGS_JerarquiaA, SqlTransaction tran)
        {
            try
            {
                #region Parametros
                SqlParameter prm_cod_jerarquiaA = new SqlParameter();
                SqlParameter prm_CodUsuario = new SqlParameter();
                #endregion Parametros


                #region Values

                #region prm_cod_jerarquiaA
                prm_cod_jerarquiaA.ParameterName = "@cod_jerarquiaA";
                prm_cod_jerarquiaA.SqlDbType = SqlDbType.Int;
                prm_cod_jerarquiaA.Direction = ParameterDirection.Input;
                prm_cod_jerarquiaA.Value = ListEnGS_JerarquiaA[0].cod_jerarquiaA;
                #endregion prm_cod_jerarquiaA

                #region prm_CodUsuario
                prm_CodUsuario.ParameterName = "@CodUsuarioRegistra";
                prm_CodUsuario.SqlDbType = SqlDbType.Int;
                prm_CodUsuario.Direction = ParameterDirection.Input;
                prm_CodUsuario.Value = ListEnGS_JerarquiaA[0].CodUsuario;
                #endregion prm_CodUsuario 

                #endregion Values

                #region Execute
                SqlHelper.ExecuteNonQuery(tran, "GS_JerarquiaA_sp_Eliminar",
                                               prm_cod_jerarquiaA, prm_CodUsuario
                                               );
                #endregion Execute
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GS_JerarquiaA_Lista(List<EnGS_JerarquiaA> ListEnGS_JerarquiaA)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_JerarquiaA_sp_Listar";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];

                paramsToStore[0] = new SqlParameter("@desc_jerarquiaA", SqlDbType.VarChar);
                paramsToStore[0].Value = ListEnGS_JerarquiaA[0].desc_jerarquiaA;
                paramsToStore[0].Size = 250;

                paramsToStore[1] = new SqlParameter("@CEmpresa", SqlDbType.Char);
                paramsToStore[1].Value = ListEnGS_JerarquiaA[0].nempresa;
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

        public DataTable GS_JerarquiaA_Combo(List<EnGS_JerarquiaA> ListEnGS_JerarquiaA)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_JerarquiaA_sp_Listar_Combo";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[1];


                paramsToStore[0] = new SqlParameter("@CEmpresa", SqlDbType.Char);
                paramsToStore[0].Value = ListEnGS_JerarquiaA[0].nempresa;
                paramsToStore[0].Size = 2;

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

        public DataTable GS_JerarquiaA_Ejecutores_Combo(List<EnGS_JerarquiaA> ListEnGS_JerarquiaA)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_JerarquiaA_Ejecutores_sp_Listar_Combo";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];


                paramsToStore[0] = new SqlParameter("@CEmpresa", SqlDbType.Char);
                paramsToStore[0].Value = ListEnGS_JerarquiaA[0].nempresa;
                paramsToStore[0].Size = 2;

                paramsToStore[1] = new SqlParameter("@id_ejecutores", SqlDbType.Int);
                paramsToStore[1].Value = ListEnGS_JerarquiaA[0].id_ejecutores;

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

        public DataTable GS_ObtenerJerarquiaA(List<EnGS_JerarquiaA> ListEnGS_JerarquiaA)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_ObtenerJerarquiaA";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[1];

                paramsToStore[0] = new SqlParameter("@CEmpresa", SqlDbType.Int);

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
