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
    public class DaGS_ClaseGestiones : DaConexion
    {

        public DataTable GS_ClaseGestiones_Lista(List<EnGS_ClaseGestiones> ListEnGS_ClaseGestiones)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_ClaseGestiones_sp_Listar";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[1];

                paramsToStore[0] = new SqlParameter("@descripcion", SqlDbType.VarChar);
                paramsToStore[0].Value = ListEnGS_ClaseGestiones[0].Descripcion;
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

        public string GS_ClaseGestiones_INS(List<EnGS_ClaseGestiones> ListEnGS_ClaseGestiones, SqlTransaction tran)
        {
            string IdReturn = String.Empty;
            SqlDataReader drParamReturn;


            SqlParameter prm_CodTipoGestion = new SqlParameter();
            SqlParameter prm_Descripcion = new SqlParameter();
            SqlParameter prm_CodUsuario = new SqlParameter();
            SqlParameter prm_CodEjecutado = new SqlParameter();
            SqlParameter prm_CodResultado = new SqlParameter();
            try
            {

                #region Values


                #region prm_CodTipoGestion
                prm_CodTipoGestion.ParameterName = "@CodTipoGestion";
                prm_CodTipoGestion.SqlDbType = SqlDbType.Int;
                prm_CodTipoGestion.Direction = ParameterDirection.Input;
                prm_CodTipoGestion.Value = ListEnGS_ClaseGestiones[0].CodTipoGestion;
                #endregion prm_CodTipoGestion
                #region prm_Descripcion
                prm_Descripcion.ParameterName = "@Descripcion";
                prm_Descripcion.SqlDbType = SqlDbType.VarChar;
                prm_Descripcion.Direction = ParameterDirection.Input;
                prm_Descripcion.Size = 250;
                prm_Descripcion.Value = ListEnGS_ClaseGestiones[0].Descripcion;
                #endregion prm_Descripcion

                #region prm_CodUsuario
                prm_CodUsuario.ParameterName = "@CodUsuarioRegistra";
                prm_CodUsuario.SqlDbType = SqlDbType.Int;
                prm_CodUsuario.Direction = ParameterDirection.Input;
                prm_CodUsuario.Value = ListEnGS_ClaseGestiones[0].CodUsuario;
                #endregion prm_CodUsuario 

                #region prm_CodEjecutado
                prm_CodEjecutado.ParameterName = "@CodEjecutado";
                prm_CodEjecutado.SqlDbType = SqlDbType.Int;
                prm_CodEjecutado.Direction = ParameterDirection.Input;
                prm_CodEjecutado.Value = ListEnGS_ClaseGestiones[0].CodEjecutado;
                #endregion prm_CodEjecutado

                #region prm_CodResultado
                prm_CodResultado.ParameterName = "@CodResultado";
                prm_CodResultado.SqlDbType = SqlDbType.Int;
                prm_CodResultado.Direction = ParameterDirection.Input;
                prm_CodResultado.Value = ListEnGS_ClaseGestiones[0].CodResultado;
                #endregion prm_CodResultado

                #endregion Values


                drParamReturn = SqlHelper.ExecuteReader(tran, "dbo.GS_ClaseGestiones_sp_Insertar",
                                               prm_CodTipoGestion,
                                               prm_Descripcion, prm_CodUsuario, prm_CodEjecutado, prm_CodResultado
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

        public void GS_ClaseGestiones_UPD(List<EnGS_ClaseGestiones> ListEnGS_ClaseGestiones, SqlTransaction tran)
        {
            try
            {
                #region Parametros
                SqlParameter prm_CodClaseGestion = new SqlParameter();
                SqlParameter prm_CodTipoGestion = new SqlParameter();
                SqlParameter prm_Descripcion = new SqlParameter();
                SqlParameter prm_CodUsuario = new SqlParameter();
                SqlParameter prm_CodEjecutado = new SqlParameter();
                SqlParameter prm_CodResultado = new SqlParameter();
                
                #endregion Parametros


                #region Values

                #region prm_CodClaseGestion
                prm_CodClaseGestion.ParameterName = "@CodClaseGestion";
                prm_CodClaseGestion.SqlDbType = SqlDbType.Int;
                prm_CodClaseGestion.Direction = ParameterDirection.Input;
                prm_CodClaseGestion.Value = ListEnGS_ClaseGestiones[0].CodClaseGestion;
                #endregion prm_CodClaseGestion
                #region prm_CodTipoGestion
                prm_CodTipoGestion.ParameterName = "@CodTipoGestion";
                prm_CodTipoGestion.SqlDbType = SqlDbType.Int;
                prm_CodTipoGestion.Direction = ParameterDirection.Input;
                prm_CodTipoGestion.Value = ListEnGS_ClaseGestiones[0].CodTipoGestion;
                #endregion prm_CodTipoGestion
                #region prm_Descripcion
                prm_Descripcion.ParameterName = "@Descripcion";
                prm_Descripcion.SqlDbType = SqlDbType.VarChar;
                prm_Descripcion.Direction = ParameterDirection.Input;
                prm_Descripcion.Size = 250;
                prm_Descripcion.Value = ListEnGS_ClaseGestiones[0].Descripcion;
                #endregion prm_Descripcion

                #region prm_CodUsuario
                prm_CodUsuario.ParameterName = "@CodUsuarioRegistra";
                prm_CodUsuario.SqlDbType = SqlDbType.Int;
                prm_CodUsuario.Direction = ParameterDirection.Input;
                prm_CodUsuario.Value = ListEnGS_ClaseGestiones[0].CodUsuario;
                #endregion prm_CodUsuario 
                
                #region prm_CodEjecutado
                prm_CodEjecutado.ParameterName = "@CodEjecutado";
                prm_CodEjecutado.SqlDbType = SqlDbType.Int;
                prm_CodEjecutado.Direction = ParameterDirection.Input;
                prm_CodEjecutado.Value = ListEnGS_ClaseGestiones[0].CodEjecutado;
                #endregion prm_CodEjecutado

                #region prm_CodResultado
                prm_CodResultado.ParameterName = "@CodResultado";
                prm_CodResultado.SqlDbType = SqlDbType.Int;
                prm_CodResultado.Direction = ParameterDirection.Input;
                prm_CodResultado.Value = ListEnGS_ClaseGestiones[0].CodResultado;
                #endregion prm_CodResultado

                #endregion Values



                #region Execute
                SqlHelper.ExecuteNonQuery(tran, "GS_ClaseGestiones_sp_Modificar",
                                               prm_CodClaseGestion,
                                               prm_CodTipoGestion,
                                               prm_Descripcion, prm_CodUsuario, prm_CodEjecutado, prm_CodResultado
                                               );
                #endregion Execute
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GS_ClaseGestiones_Reg(List<EnGS_ClaseGestiones> ListEnGS_ClaseGestiones)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_ClaseGestiones_sp_Registro";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[1];


                paramsToStore[0] = new SqlParameter("@CodClaseGestion", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_ClaseGestiones[0].CodClaseGestion;

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

        public void GS_ClaseGestiones_DEL(List<EnGS_ClaseGestiones> ListEnGS_ClaseGestiones, SqlTransaction tran)
        {
            try
            {
                #region Parametros
                SqlParameter prm_CodClaseGestion = new SqlParameter();
                SqlParameter prm_CodUsuario = new SqlParameter();
                #endregion Parametros


                #region Values

                #region prm_CodClaseGestion
                prm_CodClaseGestion.ParameterName = "@CodClaseGestion";
                prm_CodClaseGestion.SqlDbType = SqlDbType.Int;
                prm_CodClaseGestion.Direction = ParameterDirection.Input;
                prm_CodClaseGestion.Value = ListEnGS_ClaseGestiones[0].CodClaseGestion;
                #endregion prm_CodClaseGestion

                #region prm_CodUsuario
                prm_CodUsuario.ParameterName = "@CodUsuarioRegistra";
                prm_CodUsuario.SqlDbType = SqlDbType.Int;
                prm_CodUsuario.Direction = ParameterDirection.Input;
                prm_CodUsuario.Value = ListEnGS_ClaseGestiones[0].CodUsuario;
                #endregion prm_CodUsuario 

                #endregion Values

                #region Execute
                SqlHelper.ExecuteNonQuery(tran, "GS_ClaseGestiones_sp_Eliminar",
                                               prm_CodClaseGestion, prm_CodUsuario
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

        public DataTable GS_TipoGestionesMasivos_Combo()
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_TipoGestiones_sp_Listar_Combo_Masivos";
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





        public DataTable GS_ClaseGestiones_Combo(List<EnGS_ClaseGestiones> ListEnGS_ClaseGestiones)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_ClaseGestiones_sp_Listar_Combo";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[1];

                paramsToStore[0] = new SqlParameter("@CodTipoGestion", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_ClaseGestiones[0].CodTipoGestion;

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

        public DataTable GS_ClaseGestionesxEjecutado_Combo(List<EnGS_ClaseGestiones> ListEnGS_ClaseGestiones)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_ClaseGestionesxEjecutado_Combo";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[1];

                paramsToStore[0] = new SqlParameter("@CodEjecutado", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_ClaseGestiones[0].CodEjecutado;

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


        public DataTable GS_Resultado_Combo()
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_Resultado_sp_Listar_Combo";
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
    }
}
