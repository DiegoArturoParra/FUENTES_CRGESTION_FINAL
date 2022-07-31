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
    public class LoGS_JerarquiaC
    {

        public List<EnTransaccion> GS_JerarquiaC_INS(List<EnGS_JerarquiaC> ListEnGS_JerarquiaC)
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
                    DaGS_JerarquiaC objDaGS_JerarquiaC = new DaGS_JerarquiaC();
                    str_id = objDaGS_JerarquiaC.GS_JerarquiaC_INS(ListEnGS_JerarquiaC, tran);
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

        public String GS_JerarquiaC_UPD(List<EnGS_JerarquiaC> ListEnGS_JerarquiaC)
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
                    DaGS_JerarquiaC objDaGS_JerarquiaC = new DaGS_JerarquiaC();
                    objDaGS_JerarquiaC.GS_JerarquiaC_UPD(ListEnGS_JerarquiaC, tran);
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

        public DataTable GS_JerarquiaC_Lista(List<EnGS_JerarquiaC> ListEnGS_JerarquiaC)
        {
            try
            {
                DaGS_JerarquiaC objDaGS_JerarquiaC = new DaGS_JerarquiaC();
                return objDaGS_JerarquiaC.GS_JerarquiaC_Lista(ListEnGS_JerarquiaC);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable GS_JerarquiaC_Reg(List<EnGS_JerarquiaC> ListEnGS_JerarquiaC)
        {
            try
            {
                DaGS_JerarquiaC objDaGS_JerarquiaC = new DaGS_JerarquiaC();
                return objDaGS_JerarquiaC.GS_JerarquiaC_Reg(ListEnGS_JerarquiaC);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public String GS_JerarquiaC_DEL(List<EnGS_JerarquiaC> ListEnGS_JerarquiaC)
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
                    DaGS_JerarquiaC objDaGS_JerarquiaC = new DaGS_JerarquiaC();
                    objDaGS_JerarquiaC.GS_JerarquiaC_DEL(ListEnGS_JerarquiaC, tran);
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

        public DataTable GS_JerarquiaC_Combo(List<EnGS_JerarquiaC> ListEnGS_JerarquiaC)
        {
            try
            {
                DaGS_JerarquiaC objDaGS_JerarquiaC = new DaGS_JerarquiaC();
                return objDaGS_JerarquiaC.GS_JerarquiaC_Combo(ListEnGS_JerarquiaC);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable GS_JerarquiaC_sp_ObtenerUsuario(List<EnGS_JerarquiaC> ListEnGS_JerarquiaC)
        {
            try
            {
                DaGS_JerarquiaC objDaGS_JerarquiaC = new DaGS_JerarquiaC();
                return objDaGS_JerarquiaC.GS_JerarquiaC_sp_ObtenerUsuario(ListEnGS_JerarquiaC);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

    }
}
