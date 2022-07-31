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
    public class LoGS_TipoGestiones
    {


        public List<EnTransaccion> GS_TipoGestiones_INS(List<EnGS_TipoGestiones> ListEnGS_TipoGestiones)
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
                    DaGS_TipoGestiones objDaGS_TipoGestiones = new DaGS_TipoGestiones();
                    str_id = objDaGS_TipoGestiones.GS_TipoGestiones_INS(ListEnGS_TipoGestiones, tran);
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


        public String GS_TipoGestiones_UPD(List<EnGS_TipoGestiones> ListEnGS_TipoGestiones)
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
                    DaGS_TipoGestiones objDaGS_TipoGestiones = new DaGS_TipoGestiones();
                    objDaGS_TipoGestiones.GS_TipoGestiones_UPD(ListEnGS_TipoGestiones, tran);
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

        public DataTable GS_TipoGestiones_Lista(List<EnGS_TipoGestiones> ListEnGS_TipoGestiones)
        {
            try
            {
                DaGS_TipoGestiones objDaGS_TipoGestiones = new DaGS_TipoGestiones();
                return objDaGS_TipoGestiones.GS_TipoGestiones_Lista(ListEnGS_TipoGestiones);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable GS_TipoGestiones_Reg(List<EnGS_TipoGestiones> ListEnGS_TipoGestiones)
        {
            try
            {
                DaGS_TipoGestiones objDaGS_TipoGestiones = new DaGS_TipoGestiones();
                return objDaGS_TipoGestiones.GS_TipoGestiones_Reg(ListEnGS_TipoGestiones);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public String GS_TipoGestiones_DEL(List<EnGS_TipoGestiones> ListEnGS_TipoGestiones)
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
                    DaGS_TipoGestiones objDaGS_TipoGestiones = new DaGS_TipoGestiones();
                    objDaGS_TipoGestiones.GS_TipoGestiones_DEL(ListEnGS_TipoGestiones, tran);
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



        public DataTable GS_TipoGestiones_Aprob_Lista(List<EnGS_TipoGestiones> ListEnGS_TipoGestiones)
        {
            try
            {
                DaGS_TipoGestiones objDaGS_TipoGestiones = new DaGS_TipoGestiones();
                return objDaGS_TipoGestiones.GS_TipoGestiones_Aprob_Lista(ListEnGS_TipoGestiones);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public String GS_TipoGestiones_Aprob_UPD(List<EnGS_TipoGestiones> ListEnGS_TipoGestiones)
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
                    DaGS_TipoGestiones objDaGS_TipoGestiones = new DaGS_TipoGestiones();
                    objDaGS_TipoGestiones.GS_TipoGestiones_Aprob_UPD(ListEnGS_TipoGestiones, tran);
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


        public DataTable GS_TipoGestionesGrupo_Combo(List<EnGS_TipoGestiones> ListEnGS_TipoGestiones)
        {
            try
            {
                DaGS_TipoGestiones objDaGS_TipoGestiones = new DaGS_TipoGestiones();
                return objDaGS_TipoGestiones.GS_TipoGestionesGrupo_Combo(ListEnGS_TipoGestiones);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }


        public DataTable GS_TipoGestiones_ValidarFlujo(List<EnGS_TipoGestiones> ListEnGS_TipoGestiones)
        {
            try
            {
                DaGS_TipoGestiones objDaGS_TipoGestiones = new DaGS_TipoGestiones();
                return objDaGS_TipoGestiones.GS_TipoGestiones_ValidarFlujo(ListEnGS_TipoGestiones);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
    }
}
