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
    public class DaGS_Ejecutado : DaConexion
    {

        public DataTable GS_Ejecutado_Lista(List<EnGS_Ejecutado> ListEnGS_Ejecutado)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_Ejecutado_sp_Listar";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[1];

                paramsToStore[0] = new SqlParameter("@descripcion", SqlDbType.VarChar);
                paramsToStore[0].Value = ListEnGS_Ejecutado[0].Descripcion;
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

        public string GS_Ejecutado_INS(List<EnGS_Ejecutado> ListEnGS_Ejecutado, SqlTransaction tran)
        {
            string IdReturn = String.Empty;
            SqlDataReader drParamReturn;

            SqlParameter prm_Descripcion = new SqlParameter();
            SqlParameter prm_CodTipoGestion = new SqlParameter();
            SqlParameter prm_dias = new SqlParameter();
            SqlParameter prm_Tiempo = new SqlParameter();
            SqlParameter prm_CodUsuario = new SqlParameter();
            try
            {

                #region Values

                #region prm_Descripcion
                prm_Descripcion.ParameterName = "@Descripcion";
                prm_Descripcion.SqlDbType = SqlDbType.VarChar;
                prm_Descripcion.Direction = ParameterDirection.Input;
                prm_Descripcion.Size = 250;
                prm_Descripcion.Value = ListEnGS_Ejecutado[0].Descripcion;
                #endregion prm_Descripcion
                #region prm_CodTipoGestion
                prm_CodTipoGestion.ParameterName = "@CodTipoGestion";
                prm_CodTipoGestion.SqlDbType = SqlDbType.Int;
                prm_CodTipoGestion.Direction = ParameterDirection.Input;
                prm_CodTipoGestion.Value = ListEnGS_Ejecutado[0].CodTipoGestion;
                #endregion prm_CodTipoGestion
                #region prm_dias
                prm_dias.ParameterName = "@dias";
                prm_dias.SqlDbType = SqlDbType.Int;
                prm_dias.Direction = ParameterDirection.Input;
                prm_dias.Value = ListEnGS_Ejecutado[0].dias;
                #endregion prm_dias
                #region prm_Tiempo
                prm_Tiempo.ParameterName = "@tiempo";
                prm_Tiempo.SqlDbType = SqlDbType.Int;
                prm_Tiempo.Direction = ParameterDirection.Input;
                prm_Tiempo.Value = ListEnGS_Ejecutado[0].Tiempo;
                #endregion prm_Tiempo

                #region prm_CodUsuario
                prm_CodUsuario.ParameterName = "@CodUsuarioRegistra";
                prm_CodUsuario.SqlDbType = SqlDbType.Int;
                prm_CodUsuario.Direction = ParameterDirection.Input;
                prm_CodUsuario.Value = ListEnGS_Ejecutado[0].CodUsuario;
                #endregion prm_CodUsuario 

                #endregion Values


                drParamReturn = SqlHelper.ExecuteReader(tran, "dbo.GS_Ejecutado_sp_Insertar",
                                               prm_Descripcion,
                                               prm_CodTipoGestion,
                                               prm_dias,
                                               prm_Tiempo, prm_CodUsuario
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

        public void GS_Ejecutado_UPD(List<EnGS_Ejecutado> ListEnGS_Ejecutado, SqlTransaction tran)
        {
            try
            {
                #region Parametros
                SqlParameter prm_CodEjecutado = new SqlParameter();
                SqlParameter prm_Descripcion = new SqlParameter();
                SqlParameter prm_CodTipoGestion = new SqlParameter();
                SqlParameter prm_dias = new SqlParameter();
                SqlParameter prm_Tiempo = new SqlParameter();
                SqlParameter prm_CodUsuario = new SqlParameter();
                #endregion Parametros


                #region Values

                #region prm_CodEjecutado
                prm_CodEjecutado.ParameterName = "@CodEjecutado";
                prm_CodEjecutado.SqlDbType = SqlDbType.Int;
                prm_CodEjecutado.Direction = ParameterDirection.Input;
                prm_CodEjecutado.Value = ListEnGS_Ejecutado[0].CodEjecutado;
                #endregion prm_CodEjecutado
                #region prm_Descripcion
                prm_Descripcion.ParameterName = "@Descripcion";
                prm_Descripcion.SqlDbType = SqlDbType.VarChar;
                prm_Descripcion.Direction = ParameterDirection.Input;
                prm_Descripcion.Size = 250;
                prm_Descripcion.Value = ListEnGS_Ejecutado[0].Descripcion;
                #endregion prm_Descripcion
                #region prm_CodTipoGestion
                prm_CodTipoGestion.ParameterName = "@CodTipoGestion";
                prm_CodTipoGestion.SqlDbType = SqlDbType.Int;
                prm_CodTipoGestion.Direction = ParameterDirection.Input;
                prm_CodTipoGestion.Value = ListEnGS_Ejecutado[0].CodTipoGestion;
                #endregion prm_CodTipoGestion
                #region prm_dias
                prm_dias.ParameterName = "@dias";
                prm_dias.SqlDbType = SqlDbType.Int;
                prm_dias.Direction = ParameterDirection.Input;
                prm_dias.Value = ListEnGS_Ejecutado[0].dias;
                #endregion prm_dias
                #region prm_Tiempo
                prm_Tiempo.ParameterName = "@tiempo";
                prm_Tiempo.SqlDbType = SqlDbType.Int;
                prm_Tiempo.Direction = ParameterDirection.Input;
                prm_Tiempo.Value = ListEnGS_Ejecutado[0].Tiempo;
                #endregion prm_Tiempo

                #region prm_CodUsuario
                prm_CodUsuario.ParameterName = "@CodUsuarioRegistra";
                prm_CodUsuario.SqlDbType = SqlDbType.Int;
                prm_CodUsuario.Direction = ParameterDirection.Input;
                prm_CodUsuario.Value = ListEnGS_Ejecutado[0].CodUsuario;
                #endregion prm_CodUsuario 

                #endregion Values



                #region Execute
                SqlHelper.ExecuteNonQuery(tran, "GS_Ejecutado_sp_Modificar",
                                               prm_CodEjecutado,
                                               prm_Descripcion,
                                               prm_CodTipoGestion,
                                               prm_dias,
                                               prm_Tiempo, prm_CodUsuario
                                               );
                #endregion Execute
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GS_Ejecutado_Reg(List<EnGS_Ejecutado> ListEnGS_Ejecutado)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_Ejecutado_sp_Registro";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[1];


                paramsToStore[0] = new SqlParameter("@CodEjecutado", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_Ejecutado[0].CodEjecutado;

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

        public void GS_Ejecutado_DEL(List<EnGS_Ejecutado> ListEnGS_Ejecutado, SqlTransaction tran)
        {
            try
            {
                #region Parametros
                SqlParameter prm_CodEjecutado = new SqlParameter();
                SqlParameter prm_CodUsuario = new SqlParameter();
                #endregion Parametros


                #region Values

                #region prm_CodEjecutado
                prm_CodEjecutado.ParameterName = "@CodEjecutado";
                prm_CodEjecutado.SqlDbType = SqlDbType.Int;
                prm_CodEjecutado.Direction = ParameterDirection.Input;
                prm_CodEjecutado.Value = ListEnGS_Ejecutado[0].CodEjecutado;
                #endregion prm_CodEjecutado

                #region prm_CodUsuario
                prm_CodUsuario.ParameterName = "@CodUsuarioRegistra";
                prm_CodUsuario.SqlDbType = SqlDbType.Int;
                prm_CodUsuario.Direction = ParameterDirection.Input;
                prm_CodUsuario.Value = ListEnGS_Ejecutado[0].CodUsuario;
                #endregion prm_CodUsuario 

                #endregion Values

                #region Execute
                SqlHelper.ExecuteNonQuery(tran, "GS_Ejecutado_sp_Eliminar",
                                               prm_CodEjecutado, prm_CodUsuario
                                               );
                #endregion Execute
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GS_TipoGestiones_Combo()
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_TipoGestiones_sp_Listar_Combo";
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

        public DataTable GS_Ejecutado_TipoGestiones_Combo(List<EnGS_Ejecutado> ListEnGS_Ejecutado)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_Ejecutado_TipoGestiones_Combo";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[1];

                paramsToStore[0] = new SqlParameter("@CodTipoGestion", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_Ejecutado[0].CodTipoGestion;

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
