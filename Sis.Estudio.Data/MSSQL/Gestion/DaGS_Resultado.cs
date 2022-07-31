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
    public class DaGS_Resultado : DaConexion
    {
        
        public DataTable GS_Resultado_Lista_Todos()
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_Resultado_sp_Listar_Todos";
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
        public DataTable GS_Resultado_Lista(List<EnGS_Resultado> ListEnGS_Resultado)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_Resultado_sp_Listar";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[1];

                paramsToStore[0] = new SqlParameter("@descripcion", SqlDbType.VarChar);
                paramsToStore[0].Value = ListEnGS_Resultado[0].Descripcion;
                paramsToStore[0].Size = 250;

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

        public string GS_Resultado_INS(List<EnGS_Resultado> ListEnGS_Resultado, SqlTransaction tran)
        {
            string IdReturn = String.Empty;
            SqlDataReader drParamReturn;

            SqlParameter prm_Descripcion = new SqlParameter();
            SqlParameter prm_CodUsuario = new SqlParameter();
            try
            {

                #region Values

                #region prm_Descripcion
                prm_Descripcion.ParameterName = "@Descripcion";
                prm_Descripcion.SqlDbType = SqlDbType.VarChar;
                prm_Descripcion.Direction = ParameterDirection.Input;
                prm_Descripcion.Size = 250;
                prm_Descripcion.Value = ListEnGS_Resultado[0].Descripcion;
                #endregion prm_Descripcion


                #region prm_CodUsuario
                prm_CodUsuario.ParameterName = "@CodUsuarioRegistra";
                prm_CodUsuario.SqlDbType = SqlDbType.Int;
                prm_CodUsuario.Direction = ParameterDirection.Input;
                prm_CodUsuario.Value = ListEnGS_Resultado[0].CodUsuario;
                #endregion prm_CodUsuario 

                #endregion Values


                drParamReturn = SqlHelper.ExecuteReader(tran, "dbo.GS_Resultado_sp_Insertar",
                                               prm_Descripcion,
                                             prm_CodUsuario
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


        public void GS_Resultado_UPD(List<EnGS_Resultado> ListEnGS_Resultado, SqlTransaction tran)
        {
            try
            {
                #region Parametros
                SqlParameter prm_CodResultado = new SqlParameter();
                SqlParameter prm_Descripcion = new SqlParameter();
                SqlParameter prm_CodUsuario = new SqlParameter();
                #endregion Parametros


                #region Values

                #region prm_CodResultado
                prm_CodResultado.ParameterName = "@CodResultado";
                prm_CodResultado.SqlDbType = SqlDbType.Int;
                prm_CodResultado.Direction = ParameterDirection.Input;
                prm_CodResultado.Value = ListEnGS_Resultado[0].CodResultado;
                #endregion prm_CodResultado
                #region prm_Descripcion
                prm_Descripcion.ParameterName = "@Descripcion";
                prm_Descripcion.SqlDbType = SqlDbType.VarChar;
                prm_Descripcion.Direction = ParameterDirection.Input;
                prm_Descripcion.Size = 250;
                prm_Descripcion.Value = ListEnGS_Resultado[0].Descripcion;
                #endregion prm_Descripcion



                #region prm_CodUsuario
                prm_CodUsuario.ParameterName = "@CodUsuarioRegistra";
                prm_CodUsuario.SqlDbType = SqlDbType.Int;
                prm_CodUsuario.Direction = ParameterDirection.Input;
                prm_CodUsuario.Value = ListEnGS_Resultado[0].CodUsuario;
                #endregion prm_CodUsuario 
                
                #endregion Values



                #region Execute
                SqlHelper.ExecuteNonQuery(tran, "GS_Resultado_sp_Modificar",
                                               prm_CodResultado,
                                               prm_Descripcion,
                                                prm_CodUsuario
                                               );
                #endregion Execute
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GS_Resultado_Reg(List<EnGS_Resultado> ListEnGS_Resultado)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_Resultado_sp_Registro";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[1];


                paramsToStore[0] = new SqlParameter("@CodResultado", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_Resultado[0].CodResultado;

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

        public void GS_Resultado_DEL(List<EnGS_Resultado> ListEnGS_Resultado, SqlTransaction tran)
        {
            try
            {
                #region Parametros
                SqlParameter prm_CodResultado = new SqlParameter();
                SqlParameter prm_CodUsuario = new SqlParameter();
                #endregion Parametros


                #region Values

                #region prm_CodResultado
                prm_CodResultado.ParameterName = "@CodResultado";
                prm_CodResultado.SqlDbType = SqlDbType.Int;
                prm_CodResultado.Direction = ParameterDirection.Input;
                prm_CodResultado.Value = ListEnGS_Resultado[0].CodResultado;
                #endregion prm_CodResultado

                #region prm_CodUsuario
                prm_CodUsuario.ParameterName = "@CodUsuarioRegistra";
                prm_CodUsuario.SqlDbType = SqlDbType.Int;
                prm_CodUsuario.Direction = ParameterDirection.Input;
                prm_CodUsuario.Value = ListEnGS_Resultado[0].CodUsuario;
                #endregion prm_CodUsuario 

                #endregion Values

                #region Execute
                SqlHelper.ExecuteNonQuery(tran, "GS_Resultado_sp_Eliminar",
                                               prm_CodResultado, prm_CodUsuario
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
