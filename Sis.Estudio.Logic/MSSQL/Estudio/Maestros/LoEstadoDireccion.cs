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
    public class LoEstadoDireccion
    {

        public List<EnTransaccion> EstadoDireccion_INS(List<EnEstadoDireccion> ListEnEstadoDireccion)
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
                    DaEstadoDireccion objDaEstadoDireccion = new DaEstadoDireccion();
                    str_id = objDaEstadoDireccion.EstadoDireccion_INS(ListEnEstadoDireccion, tran);
                    tran.Commit();
                    //msg = "exito";
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
        public String EstadoDireccion_UPD(List<EnEstadoDireccion> ListEnEstadoDireccion)
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
                    DaEstadoDireccion objDaEstadoDireccion = new DaEstadoDireccion();
                    objDaEstadoDireccion.EstadoDireccion_UPD(ListEnEstadoDireccion, tran);
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
        public DataTable EstadoDireccion_Listar()
        {
            try
            {
                DaEstadoDireccion objDaEstadoDireccion = new DaEstadoDireccion();
                return objDaEstadoDireccion.EstadoDireccion_Listar();
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public DataTable EstadoDireccion_Listar_Reg(List<EnEstadoDireccion> ListEnEstadoDireccion)
        {
            try
            {
                DaEstadoDireccion objDaEstadoDireccion = new DaEstadoDireccion();
                return objDaEstadoDireccion.EstadoDireccion_Listar_Reg(ListEnEstadoDireccion);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

    }
}
