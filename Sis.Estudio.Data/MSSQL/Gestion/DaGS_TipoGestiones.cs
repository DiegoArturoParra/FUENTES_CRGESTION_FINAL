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
    public class DaGS_TipoGestiones : DaConexion
    {

        public DataTable GS_TipoGestiones_Lista(List<EnGS_TipoGestiones> ListEnGS_TipoGestiones)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_TipoGestiones_sp_Listar";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[1];

                paramsToStore[0] = new SqlParameter("@descripcion", SqlDbType.VarChar);
                paramsToStore[0].Value = ListEnGS_TipoGestiones[0].Descripcion;
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

        public string GS_TipoGestiones_INS(List<EnGS_TipoGestiones> ListEnGS_TipoGestiones, SqlTransaction tran)
        {
            string IdReturn = String.Empty;
            SqlDataReader drParamReturn;

            SqlParameter prm_Descripcion = new SqlParameter();
            SqlParameter prm_Tiempo = new SqlParameter();
            SqlParameter prm_Proc_auto = new SqlParameter();
            SqlParameter prm_grupo = new SqlParameter();
            SqlParameter prm_CodUsuario = new SqlParameter();
            SqlParameter prm_Flujo = new SqlParameter();
            SqlParameter prm_FlagFechaVisita = new SqlParameter();
            SqlParameter prm_FlagGeneraNuevo = new SqlParameter();
            SqlParameter prm_FlagProcesoMasivo = new SqlParameter();
            try
            {

                #region Values

                #region prm_Descripcion
                prm_Descripcion.ParameterName = "@Descripcion";
                prm_Descripcion.SqlDbType = SqlDbType.VarChar;
                prm_Descripcion.Direction = ParameterDirection.Input;
                prm_Descripcion.Size = 250;
                prm_Descripcion.Value = ListEnGS_TipoGestiones[0].Descripcion;
                #endregion prm_Descripcion
                #region prm_Tiempo
                prm_Tiempo.ParameterName = "@tiempo";
                prm_Tiempo.SqlDbType = SqlDbType.Int;
                prm_Tiempo.Direction = ParameterDirection.Input;
                prm_Tiempo.Value = ListEnGS_TipoGestiones[0].Tiempo;
                #endregion prm_Tiempo
                #region prm_Proc_auto
                prm_Proc_auto.ParameterName = "@proc_auto";
                prm_Proc_auto.SqlDbType = SqlDbType.Int;
                prm_Proc_auto.Direction = ParameterDirection.Input;
                prm_Proc_auto.Value = ListEnGS_TipoGestiones[0].Proc_auto;
                #endregion prm_Proc_auto

                #region prm_grupo
                prm_grupo.ParameterName = "@grupo";
                prm_grupo.SqlDbType = SqlDbType.Int;
                prm_grupo.Direction = ParameterDirection.Input;
                prm_grupo.Value = ListEnGS_TipoGestiones[0].grupo;
                #endregion prm_grupo


                #region prm_CodUsuario
                prm_CodUsuario.ParameterName = "@CodUsuarioRegistra";
                prm_CodUsuario.SqlDbType = SqlDbType.Int;
                prm_CodUsuario.Direction = ParameterDirection.Input;
                prm_CodUsuario.Value = ListEnGS_TipoGestiones[0].CodUsuario;
                #endregion prm_CodUsuario 

                #region prm_Flujo
                prm_Flujo.ParameterName = "@Flujo";
                prm_Flujo.SqlDbType = SqlDbType.Int;
                prm_Flujo.Direction = ParameterDirection.Input;
                prm_Flujo.Value = ListEnGS_TipoGestiones[0].Flujo;
                #endregion prm_Flujo

                #region prm_FlagFechaVisita
                prm_FlagFechaVisita.ParameterName = "@FlagVisita";
                prm_FlagFechaVisita.SqlDbType = SqlDbType.Int;
                prm_FlagFechaVisita.Direction = ParameterDirection.Input;
                prm_FlagFechaVisita.Value = ListEnGS_TipoGestiones[0].FlagFechaVisita;
                #endregion prm_FlagFechaVisita

                #region prm_FlagGeneraNuevo
                prm_FlagGeneraNuevo.ParameterName = "@FlagGeneraDuplicado";
                prm_FlagGeneraNuevo.SqlDbType = SqlDbType.Int;
                prm_FlagGeneraNuevo.Direction = ParameterDirection.Input;
                prm_FlagGeneraNuevo.Value = ListEnGS_TipoGestiones[0].FlagGeneraNuevo;
                #endregion prm_FlagGeneraNuevo

                #region prm_FlagProcesoMasivo
                prm_FlagProcesoMasivo.ParameterName = "@FlagProcesoMasivo";
                prm_FlagProcesoMasivo.SqlDbType = SqlDbType.Int;
                prm_FlagProcesoMasivo.Direction = ParameterDirection.Input;
                prm_FlagProcesoMasivo.Value = ListEnGS_TipoGestiones[0].FlagProcesoMasivo;
                #endregion prm_FlagProcesoMasivo


                #endregion Values


                drParamReturn = SqlHelper.ExecuteReader(tran, "dbo.GS_TipoGestiones_sp_Insertar",
                                               prm_Descripcion,
                                               prm_Tiempo,
                                               prm_Proc_auto, prm_grupo, prm_CodUsuario, prm_Flujo, prm_FlagFechaVisita, prm_FlagGeneraNuevo,
                                               prm_FlagProcesoMasivo
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


        public void GS_TipoGestiones_UPD(List<EnGS_TipoGestiones> ListEnGS_TipoGestiones, SqlTransaction tran)
        {
            try
            {
                #region Parametros
                SqlParameter prm_CodTipoGestion = new SqlParameter();
                SqlParameter prm_Descripcion = new SqlParameter();
                SqlParameter prm_Tiempo = new SqlParameter();
                SqlParameter prm_Proc_auto = new SqlParameter();
                SqlParameter prm_grupo = new SqlParameter();
                SqlParameter prm_CodUsuario = new SqlParameter();
                SqlParameter prm_Flujo = new SqlParameter();
                SqlParameter prm_FlagVisita = new SqlParameter();
                SqlParameter prm_FlagGeneraNuevo = new SqlParameter();
                SqlParameter prm_FlagProcesoMasivo = new SqlParameter();
                #endregion Parametros


                #region Values

                #region prm_CodTipoGestion
                prm_CodTipoGestion.ParameterName = "@CodTipoGestion";
                prm_CodTipoGestion.SqlDbType = SqlDbType.Int;
                prm_CodTipoGestion.Direction = ParameterDirection.Input;
                prm_CodTipoGestion.Value = ListEnGS_TipoGestiones[0].CodTipoGestion;
                #endregion prm_CodTipoGestion

                #region prm_Descripcion
                prm_Descripcion.ParameterName = "@Descripcion";
                prm_Descripcion.SqlDbType = SqlDbType.VarChar;
                prm_Descripcion.Direction = ParameterDirection.Input;
                prm_Descripcion.Size = 250;
                prm_Descripcion.Value = ListEnGS_TipoGestiones[0].Descripcion;
                #endregion prm_Descripcion

                #region prm_Tiempo
                prm_Tiempo.ParameterName = "@tiempo";
                prm_Tiempo.SqlDbType = SqlDbType.Int;
                prm_Tiempo.Direction = ParameterDirection.Input;
                prm_Tiempo.Value = ListEnGS_TipoGestiones[0].Tiempo;
                #endregion prm_Tiempo

                #region prm_Proc_auto
                prm_Proc_auto.ParameterName = "@proc_auto";
                prm_Proc_auto.SqlDbType = SqlDbType.Int;
                prm_Proc_auto.Direction = ParameterDirection.Input;
                prm_Proc_auto.Value = ListEnGS_TipoGestiones[0].Proc_auto;
                #endregion prm_Proc_auto

                #region prm_grupo
                prm_grupo.ParameterName = "@grupo";
                prm_grupo.SqlDbType = SqlDbType.Int;
                prm_grupo.Direction = ParameterDirection.Input;
                prm_grupo.Value = ListEnGS_TipoGestiones[0].grupo;
                #endregion prm_grupo

                #region prm_CodUsuario
                prm_CodUsuario.ParameterName = "@CodUsuarioRegistra";
                prm_CodUsuario.SqlDbType = SqlDbType.Int;
                prm_CodUsuario.Direction = ParameterDirection.Input;
                prm_CodUsuario.Value = ListEnGS_TipoGestiones[0].CodUsuario;
                #endregion prm_CodUsuario 
                
                #region prm_flujo
                prm_Flujo.ParameterName = "@Flujo";
                prm_Flujo.SqlDbType = SqlDbType.Int;
                prm_Flujo.Direction = ParameterDirection.Input;
                prm_Flujo.Value = ListEnGS_TipoGestiones[0].Flujo;
                #endregion prm_flujo

                #region prm_FlagVisita
                prm_FlagVisita.ParameterName = "@FlagVisita";
                prm_FlagVisita.SqlDbType = SqlDbType.Int;
                prm_FlagVisita.Direction = ParameterDirection.Input;
                prm_FlagVisita.Value = ListEnGS_TipoGestiones[0].FlagFechaVisita;
                #endregion prm_FlagVisita

                #region prm_FlagGeneraNuevo
                prm_FlagGeneraNuevo.ParameterName = "@FlagGeneraDuplicado";
                prm_FlagGeneraNuevo.SqlDbType = SqlDbType.Int;
                prm_FlagGeneraNuevo.Direction = ParameterDirection.Input;
                prm_FlagGeneraNuevo.Value = ListEnGS_TipoGestiones[0].FlagGeneraNuevo;
                #endregion prm_FlagGeneraNuevo

                #region prm_FlagProcesoMasivo
                prm_FlagProcesoMasivo.ParameterName = "@FlagProcesoMasivo";
                prm_FlagProcesoMasivo.SqlDbType = SqlDbType.Int;
                prm_FlagProcesoMasivo.Direction = ParameterDirection.Input;
                prm_FlagProcesoMasivo.Value = ListEnGS_TipoGestiones[0].FlagProcesoMasivo;
                #endregion prm_FlagProcesoMasivo

                #endregion Values



                #region Execute
                SqlHelper.ExecuteNonQuery(tran, "GS_TipoGestiones_sp_Modificar",
                                               prm_CodTipoGestion,
                                               prm_Descripcion,
                                               prm_Tiempo,
                                               prm_Proc_auto, 
                                               prm_grupo, 
                                               prm_CodUsuario,
                                               prm_Flujo, 
                                               prm_FlagVisita, 
                                               prm_FlagGeneraNuevo,
                                               prm_FlagProcesoMasivo
                                               );
                #endregion Execute
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GS_TipoGestiones_Reg(List<EnGS_TipoGestiones> ListEnGS_TipoGestiones)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_TipoGestiones_sp_Registro";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[1];


                paramsToStore[0] = new SqlParameter("@CodTipoGestion", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_TipoGestiones[0].CodTipoGestion;

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

        public void GS_TipoGestiones_DEL(List<EnGS_TipoGestiones> ListEnGS_TipoGestiones, SqlTransaction tran)
        {
            try
            {
                #region Parametros
                SqlParameter prm_CodTipoGestion = new SqlParameter();
                SqlParameter prm_CodUsuario = new SqlParameter();
                #endregion Parametros


                #region Values

                #region prm_CodTipoGestion
                prm_CodTipoGestion.ParameterName = "@CodTipoGestion";
                prm_CodTipoGestion.SqlDbType = SqlDbType.Int;
                prm_CodTipoGestion.Direction = ParameterDirection.Input;
                prm_CodTipoGestion.Value = ListEnGS_TipoGestiones[0].CodTipoGestion;
                #endregion prm_CodTipoGestion

                #region prm_CodUsuario
                prm_CodUsuario.ParameterName = "@CodUsuarioRegistra";
                prm_CodUsuario.SqlDbType = SqlDbType.Int;
                prm_CodUsuario.Direction = ParameterDirection.Input;
                prm_CodUsuario.Value = ListEnGS_TipoGestiones[0].CodUsuario;
                #endregion prm_CodUsuario 

                #endregion Values

                #region Execute
                SqlHelper.ExecuteNonQuery(tran, "GS_TipoGestiones_sp_Eliminar",
                                               prm_CodTipoGestion, prm_CodUsuario
                                               );
                #endregion Execute
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public DataTable GS_TipoGestiones_Aprob_Lista(List<EnGS_TipoGestiones> ListEnGS_TipoGestiones)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_TipoGestiones_Aprob_sp_Listar";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[3];

                paramsToStore[0] = new SqlParameter("@nEmpresa", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_TipoGestiones[0].nempresa;


                paramsToStore[1] = new SqlParameter("@Nivel", SqlDbType.Char);
                paramsToStore[1].Value = ListEnGS_TipoGestiones[0].Nivel;
                paramsToStore[1].Size = 1;

                paramsToStore[2] = new SqlParameter("@Cod_Jerarquia", SqlDbType.Int);
                paramsToStore[2].Value = ListEnGS_TipoGestiones[0].Cod_Jerarquia;


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

        public void GS_TipoGestiones_Aprob_UPD(List<EnGS_TipoGestiones> ListEnGS_TipoGestiones, SqlTransaction tran)
        {
            try
            {
                #region Parametros
                SqlParameter prm_nEmpresa = new SqlParameter();
                SqlParameter prm_CodTipoGestionAprob = new SqlParameter();
                SqlParameter prm_Aprobacion = new SqlParameter();
                SqlParameter prm_Correo = new SqlParameter();
                SqlParameter prm_CodUsuario = new SqlParameter();
                #endregion Parametros


                #region Values

                #region prm_nEmpresa
                prm_nEmpresa.ParameterName = "@nEmpresa";
                prm_nEmpresa.SqlDbType = SqlDbType.Int;
                prm_nEmpresa.Direction = ParameterDirection.Input;
                prm_nEmpresa.Value = ListEnGS_TipoGestiones[0].nempresa;
                #endregion prm_nEmpresa

                #region prm_CodTipoGestionAprob
                prm_CodTipoGestionAprob.ParameterName = "@CodTipoGestionAprob";
                prm_CodTipoGestionAprob.SqlDbType = SqlDbType.Int;
                prm_CodTipoGestionAprob.Direction = ParameterDirection.Input;
                prm_CodTipoGestionAprob.Value = ListEnGS_TipoGestiones[0].CodTipoGestionAprob;
                #endregion prm_CodTipoGestionAprob

                #region prm_Aprobacion
                prm_Aprobacion.ParameterName = "@Aprobacion";
                prm_Aprobacion.SqlDbType = SqlDbType.Char;
                prm_Aprobacion.Direction = ParameterDirection.Input;
                prm_Aprobacion.Value = ListEnGS_TipoGestiones[0].Aprobacion;
                prm_Aprobacion.Size = 1;
                #endregion prm_Aprobacion

                #region prm_Correo
                prm_Correo.ParameterName = "@Correo";
                prm_Correo.SqlDbType = SqlDbType.Char;
                prm_Correo.Direction = ParameterDirection.Input;
                prm_Correo.Value = ListEnGS_TipoGestiones[0].Correo;
                prm_Correo.Size = 1;
                #endregion prm_Correo

                #region prm_CodUsuario
                prm_CodUsuario.ParameterName = "@CodUsuario";
                prm_CodUsuario.SqlDbType = SqlDbType.Int;
                prm_CodUsuario.Direction = ParameterDirection.Input;
                prm_CodUsuario.Value = ListEnGS_TipoGestiones[0].CodUsuario;
                #endregion prm_CodUsuario

                #endregion Values



                #region Execute
                SqlHelper.ExecuteNonQuery(tran, "GS_TipoGestiones_Aprob_sp_Grabar",
                                               prm_nEmpresa,
                                               prm_CodTipoGestionAprob,
                                               prm_Aprobacion,
                                               prm_Correo, prm_CodUsuario
                                               );
                #endregion Execute
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public DataTable GS_TipoGestionesGrupo_Combo(List<EnGS_TipoGestiones> ListEnGS_TipoGestiones)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_TipoGestiones_sp_Listar_Combo_Grupo";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[1];

                paramsToStore[0] = new SqlParameter("@Grupo", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_TipoGestiones[0].grupo;

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

        public DataTable GS_TipoGestiones_ValidarFlujo(List<EnGS_TipoGestiones> ListEnGS_TipoGestiones)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_TipoGestiones_sp_Validar_FLujo";
                adp = new SqlDataAdapter(sqlCommand, conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = new SqlParameter("@CodTipoGestion", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_TipoGestiones[0].CodTipoGestion;
                adp.SelectCommand.Parameters.AddRange(paramsToStore);
                adp.Fill(ds, "DataTable1");
                dt = ds.Tables["DataTable1"];

                return dt;
            }
            catch (Exception excp)
            {
                
                throw excp;
            }
        }
    }
}
