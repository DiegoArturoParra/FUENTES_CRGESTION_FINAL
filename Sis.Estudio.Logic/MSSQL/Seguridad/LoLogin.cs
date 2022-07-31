using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Sis.Estudio.Entity;
using Sis.Estudio.Data;
using Sis.Estudio.Data.MSSQL.Seguridad;

namespace Sis.Estudio.Logic.MSSQL.Seguridad
{
    public class LoLogin
    {
        public DataTable GetUsuarioLogin(List<EnLogin> ListEnLogin)
        {
            DataTable dt;
            try
            {
                DaLogin objDaLogin = new DaLogin();
                dt = objDaLogin.GetUsuarioLogin(ListEnLogin);
                return dt;
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public DataTable GetUsuarioLoginAutomatico(List<EnLogin> ListEnLogin)
        {
            DataTable dt;
            try
            {
                DaLogin objDaLogin = new DaLogin();
                dt = objDaLogin.GetUsuarioLoginAutomatico(ListEnLogin);
                return dt;
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }      
        public DataTable GetMenuUsuario(List<EnLogin> ListEnLogin)
        {
            DataTable dt;
            try
            {
                DaLogin objDaLogin = new DaLogin();
                dt = objDaLogin.GetMenuUsuario(ListEnLogin);
                return dt;
            }
            catch (Exception excp)

            {
                 throw excp;
            }
        }
        public DataTable Lista_ModuloPorUsuario(List<EnLogin> ListEnLogin)
        {
            DataTable dt;
            try
            {
                DaLogin objDaLogin = new DaLogin();
                dt = objDaLogin.Lista_ModuloPorUsuario(ListEnLogin);
                return dt;
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public DataTable Obtiene_KeyLogin(List<EnLogin> ListEnLogin)
        {
            DataTable dt;
            try
            {
                DaLogin objDaLogin = new DaLogin();
                dt = objDaLogin.Obtiene_KeyLogin(ListEnLogin);
                return dt;
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public List<EnTransaccion> Genera_KeyLogin(List<EnLogin> ListEnLogin)
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
                    DaLogin objDaLogin = new DaLogin();
                    str_id = objDaLogin.Genera_KeyLogin(ListEnLogin, tran);
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
        public String Cierra_KeyLogin(List<EnLogin> ListEnLogin)
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
                    DaLogin objDaLogin = new DaLogin();
                    objDaLogin.Cierra_KeyLogin(ListEnLogin, tran);
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
    }
}
