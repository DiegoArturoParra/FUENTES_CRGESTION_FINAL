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
    public class LoGS_JerarquiaB
    {

        public List<EnTransaccion> GS_JerarquiaB_INS(List<EnGS_JerarquiaB> ListEnGS_JerarquiaB)
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
                    DaGS_JerarquiaB objDaGS_JerarquiaB = new DaGS_JerarquiaB();
                    str_id = objDaGS_JerarquiaB.GS_JerarquiaB_INS(ListEnGS_JerarquiaB, tran);
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

        public String GS_JerarquiaB_UPD(List<EnGS_JerarquiaB> ListEnGS_JerarquiaB)
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
                    DaGS_JerarquiaB objDaGS_JerarquiaB = new DaGS_JerarquiaB();
                    objDaGS_JerarquiaB.GS_JerarquiaB_UPD(ListEnGS_JerarquiaB, tran);
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

        public DataTable GS_JerarquiaB_Lista(List<EnGS_JerarquiaB> ListEnGS_JerarquiaB)
        {
            try
            {
                DaGS_JerarquiaB objDaGS_JerarquiaB = new DaGS_JerarquiaB();
                return objDaGS_JerarquiaB.GS_JerarquiaB_Lista(ListEnGS_JerarquiaB);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable GS_JerarquiaB_Reg(List<EnGS_JerarquiaB> ListEnGS_JerarquiaB)
        {
            try
            {
                DaGS_JerarquiaB objDaGS_JerarquiaB = new DaGS_JerarquiaB();
                return objDaGS_JerarquiaB.GS_JerarquiaB_Reg(ListEnGS_JerarquiaB);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public String GS_JerarquiaB_DEL(List<EnGS_JerarquiaB> ListEnGS_JerarquiaB)
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
                    DaGS_JerarquiaB objDaGS_JerarquiaB = new DaGS_JerarquiaB();
                    objDaGS_JerarquiaB.GS_JerarquiaB_DEL(ListEnGS_JerarquiaB, tran);
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

        public DataTable GS_JerarquiaB_Combo(List<EnGS_JerarquiaB> ListEnGS_JerarquiaB)
        {
            try
            {
                DaGS_JerarquiaB objDaGS_JerarquiaB = new DaGS_JerarquiaB();
                return objDaGS_JerarquiaB.GS_JerarquiaB_Combo(ListEnGS_JerarquiaB);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        



    }
}
