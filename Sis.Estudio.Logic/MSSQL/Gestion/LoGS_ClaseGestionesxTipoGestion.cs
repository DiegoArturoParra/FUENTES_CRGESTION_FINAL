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
    public class LoGS_ClaseGestionesxTipoGestion
    {

        public List<EnTransaccion> GS_ClaseGestionesxTipoGestion_INS(List<EnGS_ClaseGestionesxTipoGestion> ListEnGS_ClaseGestionesxTipoGestion)
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
                    DaGS_ClaseGestionesxTipoGestion objDaGS_ClaseGestionesxTipoGestion = new DaGS_ClaseGestionesxTipoGestion();
                    str_id = objDaGS_ClaseGestionesxTipoGestion.GS_ClaseGestionesxTipoGestion_INS(ListEnGS_ClaseGestionesxTipoGestion, tran);
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


        public String GS_ClaseGestionesxTipoGestion_DEL(List<EnGS_ClaseGestionesxTipoGestion> ListEnGS_ClaseGestionesxTipoGestion)
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
                    DaGS_ClaseGestionesxTipoGestion objDaGS_ClaseGestionesxTipoGestion = new DaGS_ClaseGestionesxTipoGestion();
                    objDaGS_ClaseGestionesxTipoGestion.GS_ClaseGestionesxTipoGestion_DEL(ListEnGS_ClaseGestionesxTipoGestion, tran);
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

        public DataTable GS_ClaseGestionesxTipoGestion_Lista(List<EnGS_ClaseGestionesxTipoGestion> ListEnGS_ClaseGestionesxTipoGestion)
        {
            try
            {
                DaGS_ClaseGestionesxTipoGestion objDaGS_ClaseGestionesxTipoGestion = new DaGS_ClaseGestionesxTipoGestion();
                return objDaGS_ClaseGestionesxTipoGestion.GS_ClaseGestionesxTipoGestion_Lista(ListEnGS_ClaseGestionesxTipoGestion);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
    }
}
