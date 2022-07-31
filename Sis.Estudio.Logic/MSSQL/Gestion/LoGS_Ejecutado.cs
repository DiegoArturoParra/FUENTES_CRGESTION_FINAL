using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Sis.Estudio.Entity;
using Sis.Estudio.Data;
using Sis.Estudio.Data.MSSQL.Gestion;
namespace Sis.Estudio.Logic.MSSQL.Gestion
{
    public class LoGS_Ejecutado
    {

        public List<EnTransaccion> GS_Ejecutado_INS(List<EnGS_Ejecutado> ListEnGS_Ejecutado)
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
                    DaGS_Ejecutado objDaGS_Ejecutado = new DaGS_Ejecutado();
                    str_id = objDaGS_Ejecutado.GS_Ejecutado_INS(ListEnGS_Ejecutado, tran);
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


        public String GS_Ejecutado_UPD(List<EnGS_Ejecutado> ListEnGS_Ejecutado)
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
                    DaGS_Ejecutado objDaGS_Ejecutado = new DaGS_Ejecutado();
                    objDaGS_Ejecutado.GS_Ejecutado_UPD(ListEnGS_Ejecutado, tran);
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

        public DataTable GS_Ejecutado_Lista(List<EnGS_Ejecutado> ListEnGS_Ejecutado)
        {
            try
            {
                DaGS_Ejecutado objDaGS_Ejecutado = new DaGS_Ejecutado();
                return objDaGS_Ejecutado.GS_Ejecutado_Lista(ListEnGS_Ejecutado);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable GS_Ejecutado_Reg(List<EnGS_Ejecutado> ListEnGS_Ejecutado)
        {
            try
            {
                DaGS_Ejecutado objDaGS_Ejecutado = new DaGS_Ejecutado();
                return objDaGS_Ejecutado.GS_Ejecutado_Reg(ListEnGS_Ejecutado);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public String GS_Ejecutado_DEL(List<EnGS_Ejecutado> ListEnGS_Ejecutado)
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
                    DaGS_Ejecutado objDaGS_Ejecutado = new DaGS_Ejecutado();
                    objDaGS_Ejecutado.GS_Ejecutado_DEL(ListEnGS_Ejecutado, tran);
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

        public DataTable GS_TipoGestiones_Combo()
        {
            try
            {
                DaGS_Ejecutado objDaGS_Ejecutado = new DaGS_Ejecutado();
                return objDaGS_Ejecutado.GS_TipoGestiones_Combo();
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }


        public DataTable GS_Ejecutado_TipoGestiones_Combo(List<EnGS_Ejecutado> ListEnGS_Ejecutado)
        {
            try
            {
                DaGS_Ejecutado objDaGS_Ejecutado = new DaGS_Ejecutado();
                return objDaGS_Ejecutado.GS_Ejecutado_TipoGestiones_Combo(ListEnGS_Ejecutado);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }


    }
}
