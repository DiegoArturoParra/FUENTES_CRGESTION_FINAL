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
    public class LoGS_ReglasGestiones
    {


        public DataTable GS_ReglasGestiones_ListaTodos(List<EnGS_ReglasGestiones> ListEnGS_ReglasGestiones)
        {
            try
            {
                DaGS_ReglasGestiones objDaGS_ReglasGestiones = new DaGS_ReglasGestiones();
                return objDaGS_ReglasGestiones.GS_ReglasGestiones_ListaTodos(ListEnGS_ReglasGestiones);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public DataTable GS_ReglasGestiones_Lista(List<EnGS_ReglasGestiones> ListEnGS_ReglasGestiones)
        {
            try
            {
                DaGS_ReglasGestiones objDaGS_ReglasGestiones = new DaGS_ReglasGestiones();
                return objDaGS_ReglasGestiones.GS_ReglasGestiones_Lista(ListEnGS_ReglasGestiones);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public String GS_ReglasGestiones_DEL(List<EnGS_ReglasGestiones> ListEnGS_ReglasGestiones)
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
                    DaGS_ReglasGestiones objDaGS_ReglasGestiones = new DaGS_ReglasGestiones();
                    objDaGS_ReglasGestiones.GS_ReglasGestiones_DEL(ListEnGS_ReglasGestiones, tran);
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

        public DataTable GS_Empresa_Combo()
        {
            try
            {
                DaGS_ReglasGestiones objDaGS_ReglasGestiones = new DaGS_ReglasGestiones();
                return objDaGS_ReglasGestiones.GS_Empresa_Combo();
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable GS_Tramo_Combo()
        {
            try
            {
                DaGS_ReglasGestiones objDaGS_ReglasGestiones = new DaGS_ReglasGestiones();
                return objDaGS_ReglasGestiones.GS_Tramo_Combo();
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable GS_Tramo_Combo(List<EnGS_ReglasGestiones> ListEnGS_ReglasGestiones)
        {
            try
            {
                DaGS_ReglasGestiones objDaGS_ReglasGestiones = new DaGS_ReglasGestiones();
                return objDaGS_ReglasGestiones.GS_Tramo_Combo(ListEnGS_ReglasGestiones);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable GS_ReglasGestiones_Reg(List<EnGS_ReglasGestiones> ListEnGS_ReglasGestiones)
        {
            try
            {
                DaGS_ReglasGestiones objDaGS_ReglasGestiones = new DaGS_ReglasGestiones();
                return objDaGS_ReglasGestiones.GS_ReglasGestiones_Reg(ListEnGS_ReglasGestiones);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }


        public List<EnTransaccion> GS_ReglasGestiones_INS(List<EnGS_ReglasGestiones> ListEnGS_ReglasGestiones)
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
                    DaGS_ReglasGestiones objDaGS_ReglasGestiones = new DaGS_ReglasGestiones();
                    str_id = objDaGS_ReglasGestiones.GS_ReglasGestiones_INS(ListEnGS_ReglasGestiones, tran);
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


        public String GS_ReglasGestiones_UPD(List<EnGS_ReglasGestiones> ListEnGS_ReglasGestiones)
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
                    DaGS_ReglasGestiones objDaGS_ReglasGestiones = new DaGS_ReglasGestiones();
                    objDaGS_ReglasGestiones.GS_ReglasGestiones_UPD(ListEnGS_ReglasGestiones, tran);
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
    }
}
