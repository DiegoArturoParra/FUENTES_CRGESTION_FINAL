using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Sis.Estudio.Entity;
using Sis.Estudio.Logic;
using Sis.Estudio.Data.MSSQL.Seguridad;

namespace Sis.Estudio.Logic.MSSQL.Seguridad
{
    public class LoUsuario
    {
        
        #region Usuario
        public DataTable Listado_Usuario(List<EnUsuario> ListEnUsuario)
        { 
            DaUsuario objDaUsuario = new DaUsuario();
            return objDaUsuario.Listado_Usuario(ListEnUsuario);
        }
        public DataTable CargaDatosUsuario(List<EnUsuario> ListEnUsuario)
        {
            DaUsuario objDaUsuario = new DaUsuario();
            return objDaUsuario.CargaDatosUsuario(ListEnUsuario);
        }

        public DataTable VerificiaLogin(List<EnUsuario> ListEnUsuario)
        {
            try
            {
                DaUsuario objDaUsuario = new DaUsuario();
                return objDaUsuario.VerificiaLogin(ListEnUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public String Modifica_Usuario(List<EnUsuario> ListEnUsuario)
        {
            string msg = "";

            # region InicializoTransaccion
            string strMensaje = "";
            LoTransaccion Transaccion = new LoTransaccion();
            bool bolError = false;
            SqlTransaction tran = Transaccion.IniTransaccion_Seg(ref bolError, ref strMensaje);
            String rollback = String.Empty;
            #endregion

            try
            {
                if (bolError == true)
                {                    
                    DaUsuario Data_Usuario = new DaUsuario();
                    Data_Usuario.Modifica_Usuario(ListEnUsuario, tran);    // Modifica
                    tran.Commit();
                }
                else
                {
                    msg = "Se presentaron errores al inicializar la operación ";
                }
            }
            catch (SqlException ex)
            {
                tran.Rollback();
                msg = ex.Message;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                msg = ex.Message;
            }
            finally
            {
                tran.Dispose();
            }

            return msg;
        }

        public List<EnTransaccion> Insertar_Usuario(List<EnUsuario> ListEnUsuario)
        {
            string msg = "";
            string str_id = "";
            # region InicializoTransaccion
            string strMensaje = "";
            LoTransaccion Transaccion = new LoTransaccion();
            bool bolError = false;
            SqlTransaction tran = Transaccion.IniTransaccion_Seg(ref bolError, ref strMensaje);
            String rollback = String.Empty;
            #endregion
            try
            {
                if (bolError == true)
                {
                    DaUsuario objDaUsuario = new DaUsuario();
                    str_id = objDaUsuario.Insertar_Usuario(ListEnUsuario, tran);
                    tran.Commit();
                }
                else
                {
                    msg = "Se presentaron errores al inicializar la operación ";
                }
            }
            catch (SqlException ex)
            {
                tran.Rollback();
                msg = ex.Message;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                msg = ex.Message;
            }
            finally
            {
                tran.Dispose();
            }

            return new List<EnTransaccion>
            {
                new EnTransaccion
                {
                    MENSAJE = msg,
                    ID = str_id
                }
            };
            //return msg;
        }

        public String Modifica_Password(List<EnUsuario> ListEnUsuario)
        {
            string msg = "";

            # region InicializoTransaccion
            string strMensaje = "";
            LoTransaccion Transaccion = new LoTransaccion();
            bool bolError = false;
            SqlTransaction tran = Transaccion.IniTransaccion_Seg(ref bolError, ref strMensaje);
            String rollback = String.Empty;
            #endregion

            try
            {
                if (bolError == true)
                {
                    DaUsuario Data_Usuario = new DaUsuario();
                    Data_Usuario.Actualizar_Password(ListEnUsuario, tran);    // Modifica Pass
                    tran.Commit();
                }
                else
                {
                    msg = "Se presentaron errores al inicializar la operación ";
                }
            }
            catch (SqlException ex)
            {
                tran.Rollback();
                msg = ex.Message;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                msg = ex.Message;
            }
            finally
            {
                tran.Dispose();
            }

            return msg;
        }




        public String Actualizar_Password_Administrador(List<EnUsuario> ListEnUsuario)
        {
            string msg = "";

            # region InicializoTransaccion
            string strMensaje = "";
            LoTransaccion Transaccion = new LoTransaccion();
            bool bolError = false;
            SqlTransaction tran = Transaccion.IniTransaccion_Seg(ref bolError, ref strMensaje);
            String rollback = String.Empty;
            #endregion

            try
            {
                if (bolError == true)
                {
                    DaUsuario Data_Usuario = new DaUsuario();
                    Data_Usuario.Actualizar_Password_Administrador(ListEnUsuario, tran);    // Modifica Pass
                    tran.Commit();
                }
                else
                {
                    msg = "Se presentaron errores al inicializar la operación ";
                }
            }
            catch (SqlException ex)
            {
                tran.Rollback();
                msg = ex.Message;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                msg = ex.Message;
            }
            finally
            {
                tran.Dispose();
            }

            return msg;
        }

        public String Anula_Usuario(List<EnUsuario> ListEnUsuario)
        {
            string msg = "";
            # region InicializoTransaccion
            string strMensaje = "";
            LoTransaccion Transaccion = new LoTransaccion();
            bool bolError = false;
            SqlTransaction tran = Transaccion.IniTransaccion_Seg(ref bolError, ref strMensaje);
            String rollback = String.Empty;
            #endregion
            try
            {
                if (bolError == true)
                {
                    DaUsuario objDaUsuario = new DaUsuario();
                    objDaUsuario.Anula_Usuario(ListEnUsuario, tran);
                    tran.Commit();
                }
                else
                {
                    msg = "Se presentaron errores al inicializar la operación ";
                }
            }
            catch (SqlException ex)
            {
                tran.Rollback();
                msg = ex.Message;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                msg = ex.Message;
            }
            finally
            {
                tran.Dispose();
            }
            return msg;
        }


        public DataTable GS_Ejecutores_Combo()
        {
            try
            {
                DaUsuario objDaUsuario = new DaUsuario();
                return objDaUsuario.GS_Ejecutores_Combo();
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }


        public DataTable GS_Ejecutores_Combo2()
        {
            try
            {
                DaUsuario objDaUsuario = new DaUsuario();
                return objDaUsuario.GS_Ejecutores_Combo2();
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }


        #endregion Usuario

        #region  UsuarioPerfil
        public DataTable Lista_UsuarioPorPerfil(List<EnUsuario> ListEnUsuario)
        {
            DaUsuario Data_Usuario = new DaUsuario();
            return Data_Usuario.Lista_UsuarioPorPerfil(ListEnUsuario);
        }
        public String Insertar_UsuarioPerfil(List<EnUsuario> ListEnUsuario)
        {
            string msg = "";
            # region InicializoTransaccion
            string strMensaje = "";
            LoTransaccion Transaccion = new LoTransaccion();
            bool bolError = false;
            SqlTransaction tran = Transaccion.IniTransaccion_Seg(ref bolError, ref strMensaje);
            String rollback = String.Empty;
            #endregion
            try
            {
                if (bolError == true)
                {
                    DaUsuario objDaUsuario = new DaUsuario();
                    objDaUsuario.Insertar_UsuarioPerfil(ListEnUsuario, tran);
                    tran.Commit();
                }
                else
                {
                    msg = "Se presentaron errores al inicializar la operación ";
                }
            }
            catch (SqlException ex)
            {
                tran.Rollback();
                msg = ex.Message;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                msg = ex.Message;
            }
            finally
            {
                tran.Dispose();
            }
            return msg;
        }
        public String Elimina_UsuarioPerfil(List<EnUsuario> ListEnUsuario)
        {
            string msg = "";
            # region InicializoTransaccion
            string strMensaje = "";
            LoTransaccion Transaccion = new LoTransaccion();
            bool bolError = false;
            SqlTransaction tran = Transaccion.IniTransaccion_Seg(ref bolError, ref strMensaje);
            String rollback = String.Empty;
            #endregion
            try
            {
                if (bolError == true)
                {
                    DaUsuario objDaUsuario = new DaUsuario();
                    objDaUsuario.Elimina_UsuarioPerfil(ListEnUsuario, tran);
                    tran.Commit();
                }
                else
                {
                    msg = "Se presentaron errores al inicializar la operación ";
                }
            }
            catch (SqlException ex)
            {
                tran.Rollback();
                msg = ex.Message;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                msg = ex.Message;
            }
            finally
            {
                tran.Dispose();
            }
            return msg;
        }
        #endregion  UsuarioPerfil


        public DataTable SEG_Usuario_ObtenerJerarquias(List<EnUsuario> ListEnUsuario)
        {
            try
            {
                DaUsuario objDaUsuario = new DaUsuario();
                return objDaUsuario.VerificiaLogin(ListEnUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
     
}