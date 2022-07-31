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
    public class DaUsuario : DaConexion
    {
        

        #region Busqueda
        public DataTable Lista_TodosLosUsuarios(List<EnUsuario> ListEnUsuario)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString2);
                sqlCommand = "SEG_Usuario_sp_ListaTodosLosUsuarios";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[1];

                paramsToStore[0] = new SqlParameter("@codusuario", SqlDbType.Int);
                paramsToStore[0].Value = ListEnUsuario[0].codUsuario;

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
        #endregion Busqueda

        #region Listado
        public DataTable Listado_Usuario(List<EnUsuario> ListEnUsuario)
        {

            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString2);
                sqlCommand = "SEG_Usuario_sp_BuscarUsuario";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[6];

                paramsToStore[0] = new SqlParameter("@Accion", SqlDbType.Int);
                paramsToStore[0].Value = ListEnUsuario[0].Accion;

                paramsToStore[1] = new SqlParameter("@pvclogin3", SqlDbType.VarChar);
                paramsToStore[1].Value = ListEnUsuario[0].login3;
                paramsToStore[1].Size = 50;

                paramsToStore[2] = new SqlParameter("@pvcNOMUSUARIO", SqlDbType.VarChar);
                paramsToStore[2].Value = ListEnUsuario[0].nombreusuario;
                paramsToStore[2].Size = 600;

                paramsToStore[3] = new SqlParameter("@pvcESTADO", SqlDbType.Char);
                paramsToStore[3].Value = ListEnUsuario[0].Sbloqueado;
                paramsToStore[3].Size = 1;

                paramsToStore[4] = new SqlParameter("@CEmpresa", SqlDbType.Char);
                paramsToStore[4].Value = ListEnUsuario[0].CEmpresa;
                paramsToStore[4].Size = 2;

                paramsToStore[5] = new SqlParameter("@Jerarquia", SqlDbType.Int);
                paramsToStore[5].Value = ListEnUsuario[0].cod_jerarquiaA;


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
        #endregion Listado

        #region Detalle
        public DataTable CargaDatosUsuario(List<EnUsuario> ListEnUsuario)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString2);
                sqlCommand = "SEG_Usuario_sp_CargaDatosUsuario";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 100000;

                SqlParameter[] paramsToStore = new SqlParameter[3];

                paramsToStore[0] = new SqlParameter("@CEMPRESA", SqlDbType.Char);
                paramsToStore[0].Size = 2;
                paramsToStore[0].Value = ListEnUsuario[0].CEmpresa;

                paramsToStore[1] = new SqlParameter("@TIPO", SqlDbType.Char);
                paramsToStore[1].Size = 1;
                paramsToStore[1].Value = ListEnUsuario[0].Tipo;

                paramsToStore[2] = new SqlParameter("@IDUSUARIO", SqlDbType.Int);
                paramsToStore[2].Value = Convert.ToInt32(ListEnUsuario[0].codUsuario);

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
        public DataTable VerificiaLogin(List<EnUsuario> ListEnUsuario)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString2);
                sqlCommand = "SEG_Usuario_sp_VerificiaLogin";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];

                paramsToStore[0] = new SqlParameter("@Login3", SqlDbType.VarChar);
                paramsToStore[0].Value = ListEnUsuario[0].login3;
                paramsToStore[0].Size = 12;

                paramsToStore[1] = new SqlParameter("@CEmpresa", SqlDbType.VarChar);
                paramsToStore[1].Value = ListEnUsuario[0].CEmpresa;
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
        public void Modifica_Usuario(List<EnUsuario> ListEnUsuario, SqlTransaction tran)
        {
            SqlParameter prm_Login = new SqlParameter();
            SqlParameter prm_ID = new SqlParameter();
            SqlParameter prm_CEMPRESA = new SqlParameter();
            SqlParameter prm_SBLOQUEADO = new SqlParameter();
            SqlParameter prm_CODUSUARIO = new SqlParameter();

            SqlParameter prm_email = new SqlParameter();
            SqlParameter prm_paterno = new SqlParameter();
            SqlParameter prm_materno = new SqlParameter();
            SqlParameter prm_nombre1 = new SqlParameter();
            SqlParameter prm_dni = new SqlParameter();

            SqlParameter prm_cod_jerarquiaA = new SqlParameter();
            SqlParameter prm_cod_jerarquiaB = new SqlParameter();
            SqlParameter prm_cod_jerarquiaC = new SqlParameter();
            SqlParameter prm_cod_jerarquiaD = new SqlParameter();

            SqlParameter prm_id_ejecutores = new SqlParameter();

            

            try
            {

                prm_Login.ParameterName = "@login3";
                prm_Login.SqlDbType = SqlDbType.VarChar;
                prm_Login.Direction = ParameterDirection.Input;
                prm_Login.Size = 50;
                prm_Login.Value = ListEnUsuario[0].login3;

                prm_ID.ParameterName = "@idUsuario";
                prm_ID.SqlDbType = SqlDbType.Int;
                prm_ID.Direction = ParameterDirection.Input;
                prm_ID.Value = ListEnUsuario[0].id;

                prm_CEMPRESA.ParameterName = "@CEMPRESA";
                prm_CEMPRESA.SqlDbType = SqlDbType.Char;
                prm_CEMPRESA.Direction = ParameterDirection.Input;
                prm_CEMPRESA.Size = 2;
                prm_CEMPRESA.Value = ListEnUsuario[0].CEmpresa;

                prm_SBLOQUEADO.ParameterName = "@Sbloqueado";
                prm_SBLOQUEADO.SqlDbType = SqlDbType.Char;
                prm_SBLOQUEADO.Direction = ParameterDirection.Input;
                prm_SBLOQUEADO.Size = 1;
                prm_SBLOQUEADO.Value = ListEnUsuario[0].Sbloqueado;

                prm_CODUSUARIO.ParameterName = "@codUsuario";
                prm_CODUSUARIO.SqlDbType = SqlDbType.Int;
                prm_CODUSUARIO.Direction = ParameterDirection.Input;
                prm_CODUSUARIO.Value = ListEnUsuario[0].codUsuario;

                prm_email.ParameterName = "@email";
                prm_email.SqlDbType = SqlDbType.VarChar;
                prm_email.Direction = ParameterDirection.Input;
                prm_email.Size = 250;
                prm_email.Value = ListEnUsuario[0].email;

                prm_paterno.ParameterName = "@paterno";
                prm_paterno.SqlDbType = SqlDbType.VarChar;
                prm_paterno.Direction = ParameterDirection.Input;
                prm_paterno.Size = 500;
                prm_paterno.Value = ListEnUsuario[0].paterno;

                prm_materno.ParameterName = "@materno";
                prm_materno.SqlDbType = SqlDbType.VarChar;
                prm_materno.Direction = ParameterDirection.Input;
                prm_materno.Size = 500;
                prm_materno.Value = ListEnUsuario[0].materno;

                prm_nombre1.ParameterName = "@nombre1";
                prm_nombre1.SqlDbType = SqlDbType.VarChar;
                prm_nombre1.Direction = ParameterDirection.Input;
                prm_nombre1.Size = 500;
                prm_nombre1.Value = ListEnUsuario[0].nombre1;

                prm_dni.ParameterName = "@dni";
                prm_dni.SqlDbType = SqlDbType.VarChar;
                prm_dni.Direction = ParameterDirection.Input;
                prm_dni.Size = 50;
                prm_dni.Value = ListEnUsuario[0].dni;

                prm_cod_jerarquiaA.ParameterName = "@cod_jerarquiaA";
                prm_cod_jerarquiaA.SqlDbType = SqlDbType.Int;
                prm_cod_jerarquiaA.Direction = ParameterDirection.Input;
                prm_cod_jerarquiaA.Value = ListEnUsuario[0].cod_jerarquiaA;

                prm_cod_jerarquiaB.ParameterName = "@cod_jerarquiaB";
                prm_cod_jerarquiaB.SqlDbType = SqlDbType.Int;
                prm_cod_jerarquiaB.Direction = ParameterDirection.Input;
                prm_cod_jerarquiaB.Value = ListEnUsuario[0].cod_jerarquiaB;

                prm_cod_jerarquiaC.ParameterName = "@cod_jerarquiaC";
                prm_cod_jerarquiaC.SqlDbType = SqlDbType.Int;
                prm_cod_jerarquiaC.Direction = ParameterDirection.Input;
                prm_cod_jerarquiaC.Value = ListEnUsuario[0].cod_jerarquiaC;

                prm_cod_jerarquiaD.ParameterName = "@cod_jerarquiaD";
                prm_cod_jerarquiaD.SqlDbType = SqlDbType.Int;
                prm_cod_jerarquiaD.Direction = ParameterDirection.Input;
                prm_cod_jerarquiaD.Value = ListEnUsuario[0].cod_jerarquiaD;

                prm_id_ejecutores.ParameterName = "@id_ejecutores";
                prm_id_ejecutores.SqlDbType = SqlDbType.Int;
                prm_id_ejecutores.Direction = ParameterDirection.Input;
                prm_id_ejecutores.Value = ListEnUsuario[0].id_ejecutores;

                SqlHelper.ExecuteNonQuery(tran, "SEG_Usuario_sp_ModificaUsuario",
                                                prm_Login,
                                                prm_ID,
                                                prm_CEMPRESA,
                                                prm_SBLOQUEADO,
                                                prm_CODUSUARIO,
                                                prm_email,
                                                prm_paterno,
                                                prm_materno,
                                                prm_nombre1,
                                                prm_dni

                                                ,prm_cod_jerarquiaA,
                                                prm_cod_jerarquiaB,
                                                prm_cod_jerarquiaC,
                                                prm_cod_jerarquiaD,
                                                prm_id_ejecutores
                                        );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Insertar_Usuario(List<EnUsuario> ListEnUsuario, SqlTransaction tran)
        {
            string IdReturn = String.Empty;
            SqlDataReader drParamReturn;

            SqlParameter prm_Login = new SqlParameter();
            SqlParameter prm_SBLOQUEADO = new SqlParameter();
            SqlParameter prm_CODUSUARIO = new SqlParameter();

            SqlParameter prm_email = new SqlParameter();
            SqlParameter prm_paterno = new SqlParameter();
            SqlParameter prm_materno = new SqlParameter();
            SqlParameter prm_nombre1 = new SqlParameter();
            SqlParameter prm_dni = new SqlParameter();
            SqlParameter prm_Password = new SqlParameter();

            SqlParameter prm_CEmpresa = new SqlParameter();

            SqlParameter prm_cod_jerarquiaA = new SqlParameter();
            SqlParameter prm_cod_jerarquiaB = new SqlParameter();
            SqlParameter prm_cod_jerarquiaC = new SqlParameter();
            SqlParameter prm_cod_jerarquiaD = new SqlParameter();
            SqlParameter prm_id_ejecutores = new SqlParameter();

            try
            {

                prm_Login.ParameterName = "@login3";
                prm_Login.SqlDbType = SqlDbType.VarChar;
                prm_Login.Direction = ParameterDirection.Input;
                prm_Login.Size = 50;
                prm_Login.Value = ListEnUsuario[0].login3;

                prm_SBLOQUEADO.ParameterName = "@Sbloqueado";
                prm_SBLOQUEADO.SqlDbType = SqlDbType.Char;
                prm_SBLOQUEADO.Direction = ParameterDirection.Input;
                prm_SBLOQUEADO.Size = 1;
                prm_SBLOQUEADO.Value = ListEnUsuario[0].Sbloqueado;

                prm_CODUSUARIO.ParameterName = "@codUsuario";
                prm_CODUSUARIO.SqlDbType = SqlDbType.Int;
                prm_CODUSUARIO.Direction = ParameterDirection.Input;
                prm_CODUSUARIO.Value = ListEnUsuario[0].codUsuario;

                prm_email.ParameterName = "@email";
                prm_email.SqlDbType = SqlDbType.VarChar;
                prm_email.Direction = ParameterDirection.Input;
                prm_email.Size = 250;
                prm_email.Value = ListEnUsuario[0].email;

                prm_paterno.ParameterName = "@paterno";
                prm_paterno.SqlDbType = SqlDbType.VarChar;
                prm_paterno.Direction = ParameterDirection.Input;
                prm_paterno.Size = 500;
                prm_paterno.Value = ListEnUsuario[0].paterno;

                prm_materno.ParameterName = "@materno";
                prm_materno.SqlDbType = SqlDbType.VarChar;
                prm_materno.Direction = ParameterDirection.Input;
                prm_materno.Size = 500;
                prm_materno.Value = ListEnUsuario[0].materno;

                prm_nombre1.ParameterName = "@nombre1";
                prm_nombre1.SqlDbType = SqlDbType.VarChar;
                prm_nombre1.Direction = ParameterDirection.Input;
                prm_nombre1.Size = 500;
                prm_nombre1.Value = ListEnUsuario[0].nombre1;

                prm_dni.ParameterName = "@dni";
                prm_dni.SqlDbType = SqlDbType.VarChar;
                prm_dni.Direction = ParameterDirection.Input;
                prm_dni.Size = 50;
                prm_dni.Value = ListEnUsuario[0].dni;

                prm_Password.ParameterName = "@Password";
                prm_Password.SqlDbType = SqlDbType.VarChar;
                prm_Password.Direction = ParameterDirection.Input;
                prm_Password.Size = 15;
                prm_Password.Value = ListEnUsuario[0].Password;

                prm_CEmpresa.ParameterName = "@CEmpresa";
                prm_CEmpresa.SqlDbType = SqlDbType.Char;
                prm_CEmpresa.Direction = ParameterDirection.Input;
                prm_CEmpresa.Size = 2;
                prm_CEmpresa.Value = ListEnUsuario[0].CEmpresa;

                prm_cod_jerarquiaA.ParameterName = "@cod_jerarquiaA";
                prm_cod_jerarquiaA.SqlDbType = SqlDbType.Int;
                prm_cod_jerarquiaA.Direction = ParameterDirection.Input;
                prm_cod_jerarquiaA.Value = ListEnUsuario[0].cod_jerarquiaA;

                prm_cod_jerarquiaB.ParameterName = "@cod_jerarquiaB";
                prm_cod_jerarquiaB.SqlDbType = SqlDbType.Int;
                prm_cod_jerarquiaB.Direction = ParameterDirection.Input;
                prm_cod_jerarquiaB.Value = ListEnUsuario[0].cod_jerarquiaB;

                prm_cod_jerarquiaC.ParameterName = "@cod_jerarquiaC";
                prm_cod_jerarquiaC.SqlDbType = SqlDbType.Int;
                prm_cod_jerarquiaC.Direction = ParameterDirection.Input;
                prm_cod_jerarquiaC.Value = ListEnUsuario[0].cod_jerarquiaC;

                prm_cod_jerarquiaD.ParameterName = "@cod_jerarquiaD";
                prm_cod_jerarquiaD.SqlDbType = SqlDbType.Int;
                prm_cod_jerarquiaD.Direction = ParameterDirection.Input;
                prm_cod_jerarquiaD.Value = ListEnUsuario[0].cod_jerarquiaD;

                prm_id_ejecutores.ParameterName = "@id_ejecutores";
                prm_id_ejecutores.SqlDbType = SqlDbType.Int;
                prm_id_ejecutores.Direction = ParameterDirection.Input;
                prm_id_ejecutores.Value = ListEnUsuario[0].id_ejecutores;

                drParamReturn = SqlHelper.ExecuteReader(tran, "SEG_Usuario_sp_InsertaUsuario",
                                                prm_Login,
                                                prm_SBLOQUEADO,
                                                prm_CODUSUARIO,
                                                prm_email,
                                                prm_paterno,
                                                prm_materno,
                                                prm_nombre1,
                                                prm_dni,
                                                prm_Password,
                                                prm_CEmpresa
                                                , prm_cod_jerarquiaA,
                                                prm_cod_jerarquiaB,
                                                prm_cod_jerarquiaC,
                                                prm_cod_jerarquiaD,
                                                prm_id_ejecutores
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

        #endregion Detalle

        #region  UsuarioPerfil
        public DataTable Lista_UsuarioPorPerfil(List<EnUsuario> ListEnUsuario)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString2);
                sqlCommand = "SEG_Usuario_sp_ListaUsuarioPorPerfil";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];

                paramsToStore[0] = new SqlParameter("@CEMPRESA", SqlDbType.Char);
                paramsToStore[0].Value = ListEnUsuario[0].CEmpresa;
                paramsToStore[0].Size = 2;

                paramsToStore[1] = new SqlParameter("@idusuario", SqlDbType.Int);
                paramsToStore[1].Value = Convert.ToInt32(ListEnUsuario[0].id);
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
        public void Insertar_UsuarioPerfil(List<EnUsuario> ListEnUsuario, SqlTransaction tran)
        {
            SqlParameter prm_CEmpresa = new SqlParameter();
            SqlParameter prm_IdUsuario = new SqlParameter();
            SqlParameter prm_IdPerfil = new SqlParameter();
            SqlParameter prm_CodUsuReg = new SqlParameter();
            try
            {
                prm_CEmpresa.ParameterName = "@CEMPRESA";
                prm_CEmpresa.SqlDbType = SqlDbType.Char;
                prm_CEmpresa.Direction = ParameterDirection.Input;
                prm_CEmpresa.Size = 2;
                prm_CEmpresa.Value = ListEnUsuario[0].CEmpresa;

                prm_IdUsuario.ParameterName = "@IdUsuario";
                prm_IdUsuario.SqlDbType = SqlDbType.Int;
                prm_IdUsuario.Direction = ParameterDirection.Input;
                prm_IdUsuario.Value = Convert.ToInt32(ListEnUsuario[0].id);

                prm_IdPerfil.ParameterName = "@IdPerfil";
                prm_IdPerfil.SqlDbType = SqlDbType.Int;
                prm_IdPerfil.Direction = ParameterDirection.Input;
                prm_IdPerfil.Value = Convert.ToInt32(ListEnUsuario[0].IdPerfil);

                prm_CodUsuReg.ParameterName = "@CodUsuReg";
                prm_CodUsuReg.SqlDbType = SqlDbType.VarChar;
                prm_CodUsuReg.Direction = ParameterDirection.Input;
                prm_CodUsuReg.Size = 15;
                prm_CodUsuReg.Value = ListEnUsuario[0].codUsuario;

                SqlHelper.ExecuteNonQuery(tran, "SEG_Usuario_sp_InsertaUsuarioPorPerfil",
                                                prm_CEmpresa,
                                                prm_IdUsuario,
                                                prm_IdPerfil,
                                                prm_CodUsuReg
                                             );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Elimina_UsuarioPerfil(List<EnUsuario> ListEnUsuario, SqlTransaction tran)
        {
            SqlParameter prm_CEmpresa = new SqlParameter();
            SqlParameter prm_IdUsuarioPerfil = new SqlParameter();

            try
            {

                prm_CEmpresa.ParameterName = "@CEMPRESA";
                prm_CEmpresa.SqlDbType = SqlDbType.Char;
                prm_CEmpresa.Direction = ParameterDirection.Input;
                prm_CEmpresa.Size = 2;
                prm_CEmpresa.Value = ListEnUsuario[0].CEmpresa;

                prm_IdUsuarioPerfil.ParameterName = "@IdUsuarioPerfil";
                prm_IdUsuarioPerfil.SqlDbType = SqlDbType.Int;
                prm_IdUsuarioPerfil.Direction = ParameterDirection.Input;
                prm_IdUsuarioPerfil.Value = Convert.ToInt32(ListEnUsuario[0].IdUsuarioPerfil);

                SqlHelper.ExecuteNonQuery(tran, "SEG_Usuario_sp_EliminaUsuarioPorPerfil",
                                                prm_CEmpresa,
                                                prm_IdUsuarioPerfil
                                             );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion  UsuarioPerfil


        public void Actualizar_Password(List<EnUsuario> ListEnUsuario, SqlTransaction tran)
        {

            SqlParameter prm_login3 = new SqlParameter();
            SqlParameter prm_Password = new SqlParameter();
            SqlParameter prm_PasswordNuevo = new SqlParameter();
            SqlParameter prm_CodUsuarioModifica = new SqlParameter();

            try
            {

                prm_login3.ParameterName = "@login3";
                prm_login3.SqlDbType = SqlDbType.VarChar;
                prm_login3.Direction = ParameterDirection.Input;
                prm_login3.Size = 50;
                prm_login3.Value = ListEnUsuario[0].login3;

                prm_Password.ParameterName = "@Password";
                prm_Password.SqlDbType = SqlDbType.VarChar;
                prm_Password.Direction = ParameterDirection.Input;
                prm_Password.Size = 15;
                prm_Password.Value = ListEnUsuario[0].Password;

                prm_PasswordNuevo.ParameterName = "@PasswordNuevo";
                prm_PasswordNuevo.SqlDbType = SqlDbType.VarChar;
                prm_PasswordNuevo.Direction = ParameterDirection.Input;
                prm_PasswordNuevo.Size = 15;
                prm_PasswordNuevo.Value = ListEnUsuario[0].PasswordNuevo;

                prm_CodUsuarioModifica.ParameterName = "@CodUsuarioModifica";
                prm_CodUsuarioModifica.SqlDbType = SqlDbType.Int;
                prm_CodUsuarioModifica.Direction = ParameterDirection.Input;
                prm_CodUsuarioModifica.Value = Convert.ToInt32(ListEnUsuario[0].id);



                SqlHelper.ExecuteNonQuery(tran, "SEG_Usuario_sp_ModificaPassword",
                                               prm_login3,
                                               prm_Password,
                                               prm_PasswordNuevo,
                                               prm_CodUsuarioModifica
                                             );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Actualizar_Password_Administrador(List<EnUsuario> ListEnUsuario, SqlTransaction tran)
        {

            SqlParameter prm_login3 = new SqlParameter();
            SqlParameter prm_PasswordNuevo = new SqlParameter();
            SqlParameter prm_RepetirPasswordNuevo = new SqlParameter();
            SqlParameter prm_CodUsuarioModifica = new SqlParameter();

            try
            {

                prm_login3.ParameterName = "@login3";
                prm_login3.SqlDbType = SqlDbType.VarChar;
                prm_login3.Direction = ParameterDirection.Input;
                prm_login3.Size = 50;
                prm_login3.Value = ListEnUsuario[0].login3;

                prm_PasswordNuevo.ParameterName = "@PasswordNuevo";
                prm_PasswordNuevo.SqlDbType = SqlDbType.VarChar;
                prm_PasswordNuevo.Direction = ParameterDirection.Input;
                prm_PasswordNuevo.Size = 15;
                prm_PasswordNuevo.Value = ListEnUsuario[0].Password;

                prm_RepetirPasswordNuevo.ParameterName = "@RepetirPasswordNuevo";
                prm_RepetirPasswordNuevo.SqlDbType = SqlDbType.VarChar;
                prm_RepetirPasswordNuevo.Direction = ParameterDirection.Input;
                prm_RepetirPasswordNuevo.Size = 15;
                prm_RepetirPasswordNuevo.Value = ListEnUsuario[0].PasswordNuevo;

                prm_CodUsuarioModifica.ParameterName = "@CodUsuarioModifica";
                prm_CodUsuarioModifica.SqlDbType = SqlDbType.Int;
                prm_CodUsuarioModifica.Direction = ParameterDirection.Input;
                prm_CodUsuarioModifica.Value = Convert.ToInt32(ListEnUsuario[0].id);



                SqlHelper.ExecuteNonQuery(tran, "SEG_Usuario_sp_ModificaPassword_Administrador",
                                               prm_login3,
                                               prm_PasswordNuevo,
                                               prm_RepetirPasswordNuevo,
                                               prm_CodUsuarioModifica
                                             );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Anula_Usuario(List<EnUsuario> ListEnUsuario, SqlTransaction tran)
        {
            SqlParameter prm_ID = new SqlParameter();
            SqlParameter prm_CEMPRESA = new SqlParameter();
            SqlParameter prm_CODUSUARIOREGISTRA = new SqlParameter();
            try
            {
                prm_ID.ParameterName = "@Id";
                prm_ID.SqlDbType = SqlDbType.Int;
                prm_ID.Direction = ParameterDirection.Input;
                prm_ID.Value = Convert.ToInt32(ListEnUsuario[0].id);

                prm_CEMPRESA.ParameterName = "@CEMPRESA";
                prm_CEMPRESA.SqlDbType = SqlDbType.Char;
                prm_CEMPRESA.Direction = ParameterDirection.Input;
                prm_CEMPRESA.Size = 2;
                prm_CEMPRESA.Value = ListEnUsuario[0].CEmpresa;

                prm_CODUSUARIOREGISTRA.ParameterName = "@CodUsuReg";
                prm_CODUSUARIOREGISTRA.SqlDbType = SqlDbType.Int;
                prm_CODUSUARIOREGISTRA.Direction = ParameterDirection.Input;
                prm_CODUSUARIOREGISTRA.Value = ListEnUsuario[0].codUsuario;

                SqlHelper.ExecuteNonQuery(tran, "SEG_Usuario_sp_AnulaUsuario",
                                               prm_ID,
                                               prm_CEMPRESA,
                                               prm_CODUSUARIOREGISTRA
                                             );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GS_Ejecutores_Combo()
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_Ejecutores_sp_Listar_Combo";
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


        public DataTable GS_Ejecutores_Combo2()
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_Ejecutores_sp_Listar_Combo2";
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

        public void SEG_Usuario_ObtenerJerarquias(List<EnUsuario> ListEnUsuario, SqlTransaction tran)
        {
            SqlParameter prm_CEmpresa = new SqlParameter();
            SqlParameter prm_CodUsuario = new SqlParameter();
            try
            {
                prm_CEmpresa.ParameterName = "@CEMPRESA";
                prm_CEmpresa.SqlDbType = SqlDbType.Char;
                prm_CEmpresa.Direction = ParameterDirection.Input;
                prm_CEmpresa.Size = 2;
                prm_CEmpresa.Value = ListEnUsuario[0].CEmpresa;

                prm_CodUsuario.ParameterName = "@CodUsuario";
                prm_CodUsuario.SqlDbType = SqlDbType.Int;
                prm_CodUsuario.Direction = ParameterDirection.Input;
                prm_CodUsuario.Value = Convert.ToInt32(ListEnUsuario[0].codUsuario);

                SqlHelper.ExecuteNonQuery(tran, "SEG_Usuario_sp_ObtenerJerarquias",
                                                prm_CEmpresa,
                                                prm_CodUsuario
                                             );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
