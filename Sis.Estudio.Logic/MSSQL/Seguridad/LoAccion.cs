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
    public class LoAccion
    {

        #region Accion
        public DataTable Listado_Accion(List<EnAccion> ListEnAccion)
        {
            DaAccion objDaAccion = new DaAccion();
            return objDaAccion.Listado_Accion(ListEnAccion);
        }
        public DataTable CargaDatosAccion(List<EnAccion> ListEnAccion)
        {
            DaAccion objDaAccion = new DaAccion();
            return objDaAccion.CargaDatosAccion(ListEnAccion);
        }
        public DataTable Lista_TodasLasAcciones(List<EnAccion> ListEnAccion)
        {
            DaAccion objDaAccion = new DaAccion();
            return objDaAccion.Lista_TodasLasAcciones(ListEnAccion);
        }
        public List<EnTransaccion> Insertar_Accion(List<EnAccion> ListEnAccion)
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
                    DaAccion objDaAccion = new DaAccion();
                    str_id = objDaAccion.Insertar_Accion(ListEnAccion, tran);
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
        public String Modifica_Accion(List<EnAccion> ListEnAccion)
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
                    DaAccion objDaAccion = new DaAccion();
                    objDaAccion.Modifica_Accion(ListEnAccion, tran);
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
        public String Anula_Accion(List<EnAccion> ListEnAccion)
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
                    DaAccion objDaAccion = new DaAccion();
                    objDaAccion.Anula_Accion(ListEnAccion, tran);
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
        #endregion Accion
    }
}