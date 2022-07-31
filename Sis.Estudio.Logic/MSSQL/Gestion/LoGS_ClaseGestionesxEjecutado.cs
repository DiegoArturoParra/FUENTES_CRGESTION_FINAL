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
    public class LoGS_ClaseGestionesxEjecutado
    {

        public List<EnTransaccion> GS_ClaseGestionesxEjecutado_INS(List<EnGS_ClaseGestionesxEjecutado> ListEnGS_ClaseGestionesxEjecutado)
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
                    DaGS_ClaseGestionesxEjecutado objDaGS_ClaseGestionesxEjecutado = new DaGS_ClaseGestionesxEjecutado();
                    str_id = objDaGS_ClaseGestionesxEjecutado.GS_ClaseGestionesxEjecutado_INS(ListEnGS_ClaseGestionesxEjecutado, tran);
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


        public String GS_ClaseGestionesxEjecutado_DEL(List<EnGS_ClaseGestionesxEjecutado> ListEnGS_ClaseGestionesxEjecutado)
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
                    DaGS_ClaseGestionesxEjecutado objDaGS_ClaseGestionesxEjecutado = new DaGS_ClaseGestionesxEjecutado();
                    objDaGS_ClaseGestionesxEjecutado.GS_ClaseGestionesxEjecutado_DEL(ListEnGS_ClaseGestionesxEjecutado, tran);
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

        public DataTable GS_ClaseGestionesxEjecutado_Lista(List<EnGS_ClaseGestionesxEjecutado> ListEnGS_ClaseGestionesxEjecutado)
        {
            try
            {
                DaGS_ClaseGestionesxEjecutado objDaGS_ClaseGestionesxEjecutado = new DaGS_ClaseGestionesxEjecutado();
                return objDaGS_ClaseGestionesxEjecutado.GS_ClaseGestionesxEjecutado_Lista(ListEnGS_ClaseGestionesxEjecutado);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
    }
}
