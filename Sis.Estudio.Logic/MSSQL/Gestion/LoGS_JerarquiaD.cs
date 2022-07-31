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
    public class LoGS_JerarquiaD
    {

        public List<EnTransaccion> GS_JerarquiaD_INS(List<EnGS_JerarquiaD> ListEnGS_JerarquiaD)
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
                    DaGS_JerarquiaD objDaGS_JerarquiaD = new DaGS_JerarquiaD();
                    str_id = objDaGS_JerarquiaD.GS_JerarquiaD_INS(ListEnGS_JerarquiaD, tran);
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

        public String GS_JerarquiaD_UPD(List<EnGS_JerarquiaD> ListEnGS_JerarquiaD)
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
                    DaGS_JerarquiaD objDaGS_JerarquiaD = new DaGS_JerarquiaD();
                    objDaGS_JerarquiaD.GS_JerarquiaD_UPD(ListEnGS_JerarquiaD, tran);
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

        public DataTable GS_JerarquiaD_Lista(List<EnGS_JerarquiaD> ListEnGS_JerarquiaD)
        {
            try
            {
                DaGS_JerarquiaD objDaGS_JerarquiaD = new DaGS_JerarquiaD();
                return objDaGS_JerarquiaD.GS_JerarquiaD_Lista(ListEnGS_JerarquiaD);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable GS_JerarquiaD_Reg(List<EnGS_JerarquiaD> ListEnGS_JerarquiaD)
        {
            try
            {
                DaGS_JerarquiaD objDaGS_JerarquiaD = new DaGS_JerarquiaD();
                return objDaGS_JerarquiaD.GS_JerarquiaD_Reg(ListEnGS_JerarquiaD);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public String GS_JerarquiaD_DEL(List<EnGS_JerarquiaD> ListEnGS_JerarquiaD)
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
                    DaGS_JerarquiaD objDaGS_JerarquiaD = new DaGS_JerarquiaD();
                    objDaGS_JerarquiaD.GS_JerarquiaD_DEL(ListEnGS_JerarquiaD, tran);
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


        public DataTable GS_JerarquiaD_Combo(List<EnGS_JerarquiaD> ListEnGS_JerarquiaD)
        {
            try
            {
                DaGS_JerarquiaD objDaGS_JerarquiaD = new DaGS_JerarquiaD();
                return objDaGS_JerarquiaD.GS_JerarquiaD_Combo(ListEnGS_JerarquiaD);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }


    }
}
