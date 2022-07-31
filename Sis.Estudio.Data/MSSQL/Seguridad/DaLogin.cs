using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Sis.Estudio.Entity;

namespace Sis.Estudio.Data.MSSQL.Seguridad
{
    public class DaLogin : DaConexion
    {
        
        public DataTable GetUsuarioLogin(List<EnLogin> ListEnLogin)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString2);
                sqlCommand = "SEG_Login_sp_UsuarioLogin";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[3];

                paramsToStore[0] = new SqlParameter("@CODUSUARIO", SqlDbType.VarChar);
                paramsToStore[0].Value = ListEnLogin[0].LOGIN;
                paramsToStore[0].Size = 50;

                paramsToStore[1] = new SqlParameter("@PASSWORD", SqlDbType.VarChar);
                paramsToStore[1].Value = ListEnLogin[0].PASSWORD;
                paramsToStore[1].Size = 256;

                paramsToStore[2] = new SqlParameter("@CEMPRESA", SqlDbType.Char);
                paramsToStore[2].Value = ListEnLogin[0].CEMPRESA;
                paramsToStore[2].Size = 2;

                adp.SelectCommand.Parameters.AddRange(paramsToStore);
                adp.Fill(DS, "DataTable1");
                dt = DS.Tables["DataTable1"];
                Conn.Close();

                return dt;
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public DataTable GetUsuarioLoginAutomatico(List<EnLogin> ListEnLogin)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString2);
                sqlCommand = "SEG_Login_sp_UsuarioLoginAutomatico";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];

                paramsToStore[0] = new SqlParameter("@CODUSUARIO", SqlDbType.VarChar);
                paramsToStore[0].Value = ListEnLogin[0].LOGIN;
                paramsToStore[0].Size = 50;

                paramsToStore[1] = new SqlParameter("@CEMPRESA", SqlDbType.Char);
                paramsToStore[1].Value = ListEnLogin[0].CEMPRESA;
                paramsToStore[1].Size = 2;

                adp.SelectCommand.Parameters.AddRange(paramsToStore);
                adp.Fill(DS, "DataTable1");
                dt = DS.Tables["DataTable1"];
                Conn.Close();

                return dt;
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public DataTable GetMenuUsuario(List<EnLogin> ListEnLogin)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString2);
                sqlCommand = "SEG_Login_sp_GeneraMenu";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[3];

                paramsToStore[0] = new SqlParameter("@IDUSUARIO", SqlDbType.Int);
                paramsToStore[0].Value = ListEnLogin[0].CODUSUARIO;

                paramsToStore[1] = new SqlParameter("@CEMPRESA", SqlDbType.VarChar);
                paramsToStore[1].Value = ListEnLogin[0].CEMPRESA;
                paramsToStore[1].Size = 2;

                paramsToStore[2] = new SqlParameter("@IDMODULO", SqlDbType.Int);
                paramsToStore[2].Value = ListEnLogin[0].IDMODULO;

                adp.SelectCommand.Parameters.AddRange(paramsToStore);
                adp.Fill(DS, "DataTable1");
                dt = DS.Tables["DataTable1"];
                Conn.Close();
                return dt;
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public DataTable Lista_ModuloPorUsuario(List<EnLogin> ListEnLogin)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString2);
                sqlCommand = "SEG_Login_sp_ListaModulosPorUsuario";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];

                paramsToStore[0] = new SqlParameter("@idusuario", SqlDbType.VarChar);
                paramsToStore[0].Value = ListEnLogin[0].CODUSUARIO;
                paramsToStore[0].Size = 12;

                paramsToStore[1] = new SqlParameter("@CEMPRESA", SqlDbType.VarChar);
                paramsToStore[1].Value = ListEnLogin[0].CEMPRESA;
                paramsToStore[1].Size = 2;

                adp.SelectCommand.Parameters.AddRange(paramsToStore);
                adp.Fill(DS, "DataTable1");
                dt = DS.Tables["DataTable1"];
                Conn.Close();

                return dt;
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public string Genera_KeyLogin(List<EnLogin> ListEnLogin, SqlTransaction tran)
        {
            string IdReturn = String.Empty;
            SqlDataReader drParamReturn;

            SqlParameter prm_CEmpresa = new SqlParameter();            
            SqlParameter prm_Login3	 = new SqlParameter();
            SqlParameter prm_IdModulo = new SqlParameter();

            try
            {
                prm_CEmpresa.ParameterName = "@CEmpresa";
                prm_CEmpresa.SqlDbType = SqlDbType.Char;
                prm_CEmpresa.Direction = ParameterDirection.Input;
                prm_CEmpresa.Size = 2;
                prm_CEmpresa.Value = ListEnLogin[0].CEMPRESA;
                              
                prm_Login3.ParameterName = "@Login3";
                prm_Login3.SqlDbType = SqlDbType.VarChar;
                prm_Login3.Direction = ParameterDirection.Input;
                prm_Login3.Size = 50;
                prm_Login3.Value = ListEnLogin[0].LOGIN;
                
                prm_IdModulo.ParameterName = "@IdModulo";
                prm_IdModulo.SqlDbType = SqlDbType.Int;
                prm_IdModulo.Direction = ParameterDirection.Input;
                prm_IdModulo.Value = Convert.ToInt32(ListEnLogin[0].IDMODULO);

                drParamReturn = SqlHelper.ExecuteReader(tran, "SEG_Login_sp_GeneraKeyLogin",
                                               prm_CEmpresa,                                               
                                               prm_Login3,
                                               prm_IdModulo 
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
        public DataTable Obtiene_KeyLogin(List<EnLogin> ListEnLogin)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString2);
                sqlCommand = "SEG_Login_sp_ObtieneKeyLogin";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];

                paramsToStore[0] = new SqlParameter("@CEmpresa", SqlDbType.VarChar);
                paramsToStore[0].Value = ListEnLogin[0].CEMPRESA;
                paramsToStore[0].Size = 2;

                paramsToStore[1] = new SqlParameter("@KeyLogin", SqlDbType.Int);
                paramsToStore[1].Value = ListEnLogin[0].KeyLogin;

                adp.SelectCommand.Parameters.AddRange(paramsToStore);
                adp.Fill(DS, "DataTable1");
                dt = DS.Tables["DataTable1"];
                Conn.Close();
                return dt;
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public void Cierra_KeyLogin(List<EnLogin> ListEnLogin, SqlTransaction tran)
        {
            
            SqlParameter prm_CEMPRESA = new SqlParameter();
            SqlParameter prm_KeyLogin = new SqlParameter();        
            try
            {
                prm_CEMPRESA.ParameterName = "@CEMPRESA";
                prm_CEMPRESA.SqlDbType = SqlDbType.Char;
                prm_CEMPRESA.Direction = ParameterDirection.Input;
                prm_CEMPRESA.Size = 2;
                prm_CEMPRESA.Value = ListEnLogin[0].CEMPRESA;

                prm_KeyLogin.ParameterName = "@KeyLogin";
                prm_KeyLogin.SqlDbType = SqlDbType.Int;
                prm_KeyLogin.Direction = ParameterDirection.Input;
                prm_KeyLogin.Value = Convert.ToInt32(ListEnLogin[0].KeyLogin);

                SqlHelper.ExecuteNonQuery(tran, "SEG_Login_sp_CierraKeyLogin",
                                               prm_CEMPRESA,
                                               prm_KeyLogin
                                             );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }       
    }
}
