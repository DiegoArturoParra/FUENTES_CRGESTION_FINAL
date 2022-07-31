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
    public class LoGS_ReglasGestionesxTipoGestion
    {

        public List<EnTransaccion> GS_ReglasGestionesxTipoGestion_INS(List<EnGS_ReglasGestionesxTipoGestion> ListEnGS_ReglasGestionesxTipoGestion)
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
                    DaGS_ReglasGestionesxTipoGestion objDaGS_ReglasGestionesxTipoGestion = new DaGS_ReglasGestionesxTipoGestion();
                    str_id = objDaGS_ReglasGestionesxTipoGestion.GS_ReglasGestionesxTipoGestion_INS(ListEnGS_ReglasGestionesxTipoGestion, tran);
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


        public String GS_ReglasGestionesxTipoGestion_DEL(List<EnGS_ReglasGestionesxTipoGestion> ListEnGS_ReglasGestionesxTipoGestion)
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
                    DaGS_ReglasGestionesxTipoGestion objDaGS_ReglasGestionesxTipoGestion = new DaGS_ReglasGestionesxTipoGestion();
                    objDaGS_ReglasGestionesxTipoGestion.GS_ReglasGestionesxTipoGestion_DEL(ListEnGS_ReglasGestionesxTipoGestion, tran);
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

        public DataTable GS_ReglasGestionesxTipoGestion_Lista(List<EnGS_ReglasGestionesxTipoGestion> ListEnGS_ReglasGestionesxTipoGestion)
        {
            try
            {
                DaGS_ReglasGestionesxTipoGestion objDaGS_ReglasGestionesxTipoGestion = new DaGS_ReglasGestionesxTipoGestion();
                return objDaGS_ReglasGestionesxTipoGestion.GS_ReglasGestionesxTipoGestion_Lista(ListEnGS_ReglasGestionesxTipoGestion);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
    }
}
