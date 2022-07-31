
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
    public class LoGS_ReglasGestionesxEjecutado
    {

        public List<EnTransaccion> GS_ReglasGestionesxEjecutado_INS(List<EnGS_ReglasGestionesxEjecutado> ListEnGS_ReglasGestionesxEjecutado)
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
                    DaGS_ReglasGestionesxEjecutado objDaGS_ReglasGestionesxEjecutado = new DaGS_ReglasGestionesxEjecutado();
                    str_id = objDaGS_ReglasGestionesxEjecutado.GS_ReglasGestionesxEjecutado_INS(ListEnGS_ReglasGestionesxEjecutado, tran);
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


        public String GS_ReglasGestionesxEjecutado_DEL(List<EnGS_ReglasGestionesxEjecutado> ListEnGS_ReglasGestionesxEjecutado)
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
                    DaGS_ReglasGestionesxEjecutado objDaGS_ReglasGestionesxEjecutado = new DaGS_ReglasGestionesxEjecutado();
                    objDaGS_ReglasGestionesxEjecutado.GS_ReglasGestionesxEjecutado_DEL(ListEnGS_ReglasGestionesxEjecutado, tran);
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

        public DataTable GS_ReglasGestionesxEjecutado_Lista(List<EnGS_ReglasGestionesxEjecutado> ListEnGS_ReglasGestionesxEjecutado)
        {
            try
            {
                DaGS_ReglasGestionesxEjecutado objDaGS_ReglasGestionesxEjecutado = new DaGS_ReglasGestionesxEjecutado();
                return objDaGS_ReglasGestionesxEjecutado.GS_ReglasGestionesxEjecutado_Lista(ListEnGS_ReglasGestionesxEjecutado);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
    }
}
