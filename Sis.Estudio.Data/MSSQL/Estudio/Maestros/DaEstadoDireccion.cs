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
    public class DaEstadoDireccion : DaConexion
    {

        public string EstadoDireccion_INS(List<EnEstadoDireccion> ListEnEstadoDireccion, SqlTransaction tran)
        {
            string IdReturn = String.Empty;
            SqlDataReader drParamReturn;
            try
            {
                #region Parametros
                SqlParameter prm_CODESTADODIR = new SqlParameter();
                SqlParameter prm_DESCRIP = new SqlParameter();
                SqlParameter prm_ESTADO = new SqlParameter();
                SqlParameter prm_CODUSUARIO = new SqlParameter();
                #endregion Parametros

                #region Values
                #region CodEstadoDir
                prm_CODESTADODIR.ParameterName = "@CodEstadoDir";
                prm_CODESTADODIR.SqlDbType = SqlDbType.Int;
                prm_CODESTADODIR.Direction = ParameterDirection.Input;
                prm_CODESTADODIR.Value = ListEnEstadoDireccion[0].CodEstadoDir;
                #endregion CodEstadoDir
                #region Descrip
                prm_DESCRIP.ParameterName = "@Descrip";
                prm_DESCRIP.SqlDbType = SqlDbType.VarChar;
                prm_DESCRIP.Direction = ParameterDirection.Input;
                prm_DESCRIP.Size = 60;
                prm_DESCRIP.Value = ListEnEstadoDireccion[0].Descrip;
                #endregion Descrip
                #region Estado
                prm_ESTADO.ParameterName = "@Estado";
                prm_ESTADO.SqlDbType = SqlDbType.Char;
                prm_ESTADO.Direction = ParameterDirection.Input;
                prm_ESTADO.Size = 1;
                prm_ESTADO.Value = ListEnEstadoDireccion[0].Estado;
                #endregion Estado
                #region CodUsuario
                prm_CODUSUARIO.ParameterName = "@CodUsuario";
                prm_CODUSUARIO.SqlDbType = SqlDbType.Int;
                prm_CODUSUARIO.Direction = ParameterDirection.Input;
                prm_CODUSUARIO.Value = ListEnEstadoDireccion[0].CodUsuario;
                #endregion CodUsuario
                #endregion Values

                #region Execute
                drParamReturn = SqlHelper.ExecuteReader(tran, "CR_EstadoDir_sp_Insertar",
                                               prm_CODESTADODIR,
                                               prm_DESCRIP,
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
        public void EstadoDireccion_UPD(List<EnEstadoDireccion> ListEnEstadoDireccion, SqlTransaction tran)
        {
            try
            {
                #region Parametros
                SqlParameter prm_CODESTADODIR = new SqlParameter();
                SqlParameter prm_DESCRIP = new SqlParameter();
                SqlParameter prm_ESTADO = new SqlParameter();
                SqlParameter prm_CODUSUARIO = new SqlParameter();
                #endregion Parametros


                #region Values
                #region CodEstadoDir
                prm_CODESTADODIR.ParameterName = "@CodEstadoDir";
                prm_CODESTADODIR.SqlDbType = SqlDbType.Int;
                prm_CODESTADODIR.Direction = ParameterDirection.Input;
                prm_CODESTADODIR.Value = ListEnEstadoDireccion[0].CodEstadoDir;
                #endregion CodEstadoDir
                #region Descrip
                prm_DESCRIP.ParameterName = "@Descrip";
                prm_DESCRIP.SqlDbType = SqlDbType.VarChar;
                prm_DESCRIP.Direction = ParameterDirection.Input;
                prm_DESCRIP.Size = 60;
                prm_DESCRIP.Value = ListEnEstadoDireccion[0].Descrip;
                #endregion Descrip
                #region Estado
                prm_ESTADO.ParameterName = "@Estado";
                prm_ESTADO.SqlDbType = SqlDbType.Char;
                prm_ESTADO.Direction = ParameterDirection.Input;
                prm_ESTADO.Size = 1;
                prm_ESTADO.Value = ListEnEstadoDireccion[0].Estado;
                #endregion Estado
                #region CodUsuario
                prm_CODUSUARIO.ParameterName = "@CodUsuario";
                prm_CODUSUARIO.SqlDbType = SqlDbType.Int;
                prm_CODUSUARIO.Direction = ParameterDirection.Input;
                prm_CODUSUARIO.Value = ListEnEstadoDireccion[0].CodUsuario;
                #endregion CodUsuario
                #endregion Values



                #region Execute
                SqlHelper.ExecuteNonQuery(tran, "CR_EstadoDir_sp_Modificar",
                                               prm_CODESTADODIR,
                                               prm_DESCRIP,
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
        public DataTable EstadoDireccion_Listar()
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "CR_Cliente_sp_CargaEstadoDireccion";
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
        public DataTable EstadoDireccion_Listar_Reg(List<EnEstadoDireccion> ListEnEstadoDireccion)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "CR_EstadoDir_sp_CargaREG";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];

                paramsToStore[0] = new SqlParameter("@NEMPRESA", SqlDbType.Int);
                paramsToStore[0].Value = ListEnEstadoDireccion[0].NEmpresa;

                paramsToStore[1] = new SqlParameter("@CodEstadoDir", SqlDbType.Int);
                paramsToStore[1].Value = ListEnEstadoDireccion[0].CodEstadoDir;

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
