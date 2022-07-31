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
    public class DaGS_UbigeoColindante : DaConexion
    {





        public DataTable GS_UbigeoColindante_Lista(List<EnGS_UbigeoColindante> ListEnGS_UbigeoColindante)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_Distritos_Alrededor_sp_Listar";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[1];


                paramsToStore[0] = new SqlParameter("@ubigeo_central", SqlDbType.Char);
                paramsToStore[0].Value = ListEnGS_UbigeoColindante[0].Ubigeo_central;
                paramsToStore[0].Size = 6;


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

        public DataTable GS_UbigeoColindante_Departamentos_Combo()
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_Departamentos_sp_Listar_Combo";
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

        public DataTable GS_UbigeoColindante_Provincias_Combo(List<EnGS_UbigeoColindante> ListEnGS_UbigeoColindante)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_Provincias_sp_Listar_Combo";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[1];


                paramsToStore[0] = new SqlParameter("@coddepartamento", SqlDbType.VarChar);
                paramsToStore[0].Value = ListEnGS_UbigeoColindante[0].CodDepartamento;
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

        public DataTable GS_UbigeoColindante_Distritos_Combo(List<EnGS_UbigeoColindante> ListEnGS_UbigeoColindante)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_Distritos_sp_Listar_Combo";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];


                paramsToStore[0] = new SqlParameter("@coddepartamento", SqlDbType.VarChar);
                paramsToStore[0].Value = ListEnGS_UbigeoColindante[0].CodDepartamento;
                paramsToStore[0].Size = 2;

                paramsToStore[1] = new SqlParameter("@codprovincia", SqlDbType.VarChar);
                paramsToStore[1].Value = ListEnGS_UbigeoColindante[0].CodProvincia;
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

        public void GS_UbigeoColindante_DEL(List<EnGS_UbigeoColindante> ListEnGS_UbigeoColindante, SqlTransaction tran)
        {
            try
            {
                #region Parametros
                SqlParameter prm_id = new SqlParameter();

                #endregion Parametros


                #region Values

                #region prm_id
                prm_id.ParameterName = "@id";
                prm_id.SqlDbType = SqlDbType.Int;
                prm_id.Direction = ParameterDirection.Input;
                prm_id.Value = ListEnGS_UbigeoColindante[0].id;
                #endregion prm_id

                #endregion Values

                #region Execute
                SqlHelper.ExecuteNonQuery(tran, "GS_UbigeoColindante_sp_Eliminar",
                                               prm_id
                                               );
                #endregion Execute
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GS_UbigeoColindante_INS(List<EnGS_UbigeoColindante> ListEnGS_UbigeoColindante, SqlTransaction tran)
        {
            string IdReturn = String.Empty;
            SqlDataReader drParamReturn;

            SqlParameter prm_ubigeo_central = new SqlParameter();
            SqlParameter prm_ubigeo_alrededor = new SqlParameter();
            SqlParameter prm_CodUsuario = new SqlParameter();
            try
            {

                #region Values


                prm_ubigeo_central.ParameterName = "@ubigeo_central";
                prm_ubigeo_central.SqlDbType = SqlDbType.Char;
                prm_ubigeo_central.Direction = ParameterDirection.Input;
                prm_ubigeo_central.Size = 6;
                prm_ubigeo_central.Value = ListEnGS_UbigeoColindante[0].Ubigeo_central;

                prm_ubigeo_alrededor.ParameterName = "@ubigeo_alrededor";
                prm_ubigeo_alrededor.SqlDbType = SqlDbType.Char;
                prm_ubigeo_alrededor.Direction = ParameterDirection.Input;
                prm_ubigeo_alrededor.Size = 6;
                prm_ubigeo_alrededor.Value = ListEnGS_UbigeoColindante[0].Ubigeo_alrededor;

                #region prm_CodUsuario
                prm_CodUsuario.ParameterName = "@CodUsuarioRegistra";
                prm_CodUsuario.SqlDbType = SqlDbType.Int;
                prm_CodUsuario.Direction = ParameterDirection.Input;
                prm_CodUsuario.Value = ListEnGS_UbigeoColindante[0].CodUsuario;
                #endregion prm_CodUsuario

                #endregion Values


                drParamReturn = SqlHelper.ExecuteReader(tran, "dbo.GS_UbigeoColindate_sp_Insertar",
                                               prm_ubigeo_central, prm_ubigeo_alrededor, prm_CodUsuario
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





    }
}
