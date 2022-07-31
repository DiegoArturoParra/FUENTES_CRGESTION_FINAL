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
    public class LoGS_ClaseGestiones
    {

        public List<EnTransaccion> GS_ClaseGestiones_INS(List<EnGS_ClaseGestiones> ListEnGS_ClaseGestiones)
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
                    DaGS_ClaseGestiones objDaGS_ClaseGestiones = new DaGS_ClaseGestiones();
                    str_id = objDaGS_ClaseGestiones.GS_ClaseGestiones_INS(ListEnGS_ClaseGestiones, tran);
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


        public String GS_ClaseGestiones_UPD(List<EnGS_ClaseGestiones> ListEnGS_ClaseGestiones)
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
                    DaGS_ClaseGestiones objDaGS_ClaseGestiones = new DaGS_ClaseGestiones();
                    objDaGS_ClaseGestiones.GS_ClaseGestiones_UPD(ListEnGS_ClaseGestiones, tran);
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

        public DataTable GS_ClaseGestiones_Lista(List<EnGS_ClaseGestiones> ListEnGS_ClaseGestiones)
        {
            try
            {
                DaGS_ClaseGestiones objDaGS_ClaseGestiones = new DaGS_ClaseGestiones();
                return objDaGS_ClaseGestiones.GS_ClaseGestiones_Lista(ListEnGS_ClaseGestiones);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable GS_ClaseGestiones_Reg(List<EnGS_ClaseGestiones> ListEnGS_ClaseGestiones)
        {
            try
            {
                DaGS_ClaseGestiones objDaGS_ClaseGestiones = new DaGS_ClaseGestiones();
                return objDaGS_ClaseGestiones.GS_ClaseGestiones_Reg(ListEnGS_ClaseGestiones);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public String GS_ClaseGestiones_DEL(List<EnGS_ClaseGestiones> ListEnGS_ClaseGestiones)
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
                    DaGS_ClaseGestiones objDaGS_ClaseGestiones = new DaGS_ClaseGestiones();
                    objDaGS_ClaseGestiones.GS_ClaseGestiones_DEL(ListEnGS_ClaseGestiones, tran);
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
                DaGS_ClaseGestiones objDaGS_ClaseGestiones = new DaGS_ClaseGestiones();
                return objDaGS_ClaseGestiones.GS_TipoGestiones_Combo();
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public DataTable GS_TipoGestionesMasivos_Combo()
        {
            try
            {
                DaGS_ClaseGestiones objDaGS_ClaseGestiones = new DaGS_ClaseGestiones();
                return objDaGS_ClaseGestiones.GS_TipoGestionesMasivos_Combo();
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable GS_ClaseGestiones_Combo(List<EnGS_ClaseGestiones> ListEnGS_ClaseGestiones)
        {
            try
            {
                DaGS_ClaseGestiones objDaGS_ClaseGestiones = new DaGS_ClaseGestiones();
                return objDaGS_ClaseGestiones.GS_ClaseGestiones_Combo(ListEnGS_ClaseGestiones);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable GS_ClaseGestionesxEjecutado_Combo(List<EnGS_ClaseGestiones> ListEnGS_ClaseGestiones)
        {
            try
            {
                DaGS_ClaseGestiones objDaGS_ClaseGestiones = new DaGS_ClaseGestiones();
                return objDaGS_ClaseGestiones.GS_ClaseGestionesxEjecutado_Combo(ListEnGS_ClaseGestiones);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable GS_Resultado_Combo()
        {
            try
            {
                DaGS_ClaseGestiones objDaGS_ClaseGestiones = new DaGS_ClaseGestiones();
                return objDaGS_ClaseGestiones.GS_Resultado_Combo();
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

    }
}
