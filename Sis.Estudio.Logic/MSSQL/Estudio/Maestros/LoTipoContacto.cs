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
    public class LoTipoContacto
    {
        public List<EnTransaccion> TipoContacto_INS(List<EnTipoContacto> ListEnTipoContacto)
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
                    DaTipoContacto objDaTipoContacto = new DaTipoContacto();
                    str_id = objDaTipoContacto.TipoContacto_INS(ListEnTipoContacto, tran);
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
        public String TipoContacto_UPD(List<EnTipoContacto> ListEnTipoContacto)
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
                    DaTipoContacto objDaTipoContacto = new DaTipoContacto();
                    objDaTipoContacto.TipoContacto_UPD(ListEnTipoContacto, tran);
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
        public DataTable TipoContacto_Listar()
        {
            try
            {
                DaTipoContacto objDa = new DaTipoContacto();
                return objDa.TipoContacto_Listar();
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }      
        public DataTable TipoContacto_Listar_Reg(List<EnTipoContacto> ListEnTipoContacto)
        {
            try
            {
                DaTipoContacto objDaTipoContacto = new DaTipoContacto();
                return objDaTipoContacto.TipoContacto_Listar_Reg(ListEnTipoContacto);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
    }
}
