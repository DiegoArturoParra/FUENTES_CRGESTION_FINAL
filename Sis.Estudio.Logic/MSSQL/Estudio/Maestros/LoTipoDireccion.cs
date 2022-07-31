using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Sis.Estudio.Entity;
using Sis.Estudio.Data;
using Sis.Estudio.Data.MSSQL.Estudio;
namespace Sis.Estudio.Logic.MSSQL.Estudio
{
    public class LoTipoDireccion
    {
        public List<EnTransaccion> TipoDireccion_INS(List<EnTipoDireccion> ListEnTipoDireccion)
        {
            string msg = "";
            string str_id = "";
            #region InicializoTransaccion
            string strMensaje = "";
            LoTransaccion Transaccion = new LoTransaccion();
            bool bolError = false;
            SqlTransaction tran = Transaccion.IniTransaccion(ref bolError, ref strMensaje);
            String rollback = String.Empty;
            #endregion InicializoTransaccion
            try
            {
                if (bolError == true)
                {
                    DaTipoDireccion objDaTipoDireccion = new DaTipoDireccion();
                    str_id = objDaTipoDireccion.TipoDireccion_INS(ListEnTipoDireccion, tran);
                    tran.Commit();
                    msg = "exito";
                }
                else
                {
                    throw new ArgumentNullException("IniTransaccion", "Se presentaron errores al inicializar la operación");
                }
            }
            catch (SqlException ex)
            {
                tran.Rollback();
                throw ex;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw ex;
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
        public String TipoDireccion_UPD(List<EnTipoDireccion> ListEnTipoDireccion)
        {
            string msg = "";
            #region InicializoTransaccion
            string strMensaje = "";
            LoTransaccion Transaccion = new LoTransaccion();
            bool bolError = false;
            SqlTransaction tran = Transaccion.IniTransaccion(ref bolError, ref strMensaje);
            String rollback = String.Empty;
            #endregion InicializoTransaccion
            try
            {
                if (bolError == true)
                {
                    DaTipoDireccion objDaTipoDireccion = new DaTipoDireccion();
                    objDaTipoDireccion.TipoDireccion_UPD(ListEnTipoDireccion, tran);
                    tran.Commit();
                    msg = "exito";
                }
                else
                {
                    throw new ArgumentNullException("IniTransaccion", "Se presentaron errores al inicializar la operación");
                }
            }
            catch (SqlException ex)
            {
                tran.Rollback();
                throw ex;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw ex;
            }
            finally
            {
                tran.Dispose();
            }
            return msg;
        }
        public DataTable TipoDireccion_Listar()
        {
            try
            {
                DaTipoDireccion objDa = new DaTipoDireccion();
                return objDa.TipoDireccion_Listar();
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public DataTable TipoDireccion_Listar_Reg(List<EnTipoDireccion> ListEnTipoDireccion)
        {
            try
            {
                DaTipoDireccion objDaTipoDireccion = new DaTipoDireccion();
                return objDaTipoDireccion.TipoDireccion_Listar_Reg(ListEnTipoDireccion);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }   
    }
}
