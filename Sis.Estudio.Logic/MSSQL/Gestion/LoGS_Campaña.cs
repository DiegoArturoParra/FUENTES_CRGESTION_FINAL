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
    public class LoGS_Campaña
    {


        public DataTable GS_Campaña_Lista(List<EnGS_Campaña> ListEnGS_Campaña)
        {
            try
            {
                DaGS_Campaña objDaGS_Campaña = new DaGS_Campaña();
                return objDaGS_Campaña.GS_Campaña_Lista(ListEnGS_Campaña);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable GS_CalificacionSBS_Combo()
        {
            try
            {
                DaGS_Campaña objDaGS_Campaña = new DaGS_Campaña();
                return objDaGS_Campaña.GS_CalificacionSBS_Combo();
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable GS_EstadoDir_Combo()
        {
            try
            {
                DaGS_Campaña objDaGS_Campaña = new DaGS_Campaña();
                return objDaGS_Campaña.GS_EstadoDir_Combo();
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public List<EnTransaccion> GS_Campaña_INS(List<EnGS_Campaña> ListEnGS_Campaña)
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
                    DaGS_Campaña objDaGS_Campaña = new DaGS_Campaña();
                    str_id = objDaGS_Campaña.GS_Campaña_INS(ListEnGS_Campaña, tran);
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

        public DataTable GS_Campaña_Mantenimiento_Lista(List<EnGS_Campaña> ListEnGS_Campaña)
        {
            try
            {
                DaGS_Campaña objDaGS_Campaña = new DaGS_Campaña();
                return objDaGS_Campaña.GS_Campaña_Mantenimiento_Lista(ListEnGS_Campaña);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public String GS_Campaña_DEL(List<EnGS_Campaña> ListEnGS_Campaña)
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
                    DaGS_Campaña objDaGS_Campaña = new DaGS_Campaña();
                    objDaGS_Campaña.GS_Campaña_DEL(ListEnGS_Campaña, tran);
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
