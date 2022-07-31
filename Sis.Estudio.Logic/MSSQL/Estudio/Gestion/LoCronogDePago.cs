using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Sis.Estudio.Entity;
using Sis.Estudio.Data;
using Sis.Estudio.Data.MSSQL.Estudio;

namespace Sis.Estudio.Logic.MSSQL.Estudio
{
    public class LoCronogDePago
    {
        public String CronogramaPago_INS(List<EnCronogDePago> ListEnCronogDePago)
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
                    DaCronogDePago objDaCronogDePago = new DaCronogDePago();
                    objDaCronogDePago.CronogramaPago_INS(ListEnCronogDePago, tran);
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
        public String CronogramaPago_UPD(List<EnCronogDePago> ListEnCronogDePago)
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
                    DaCronogDePago objDaCronogDePago = new DaCronogDePago();
                    objDaCronogDePago.CronogramaPago_UPD(ListEnCronogDePago, tran);
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
        public DataTable CronogramaPago_Listar(List<EnCronogDePago> ListEnCronogDePago)
        {
            try
            {
                DaCronogDePago objDaCronogDePago = new DaCronogDePago();
                return objDaCronogDePago.CronogramaPago_Listar(ListEnCronogDePago);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public DataTable CronogramaPago_Listar_Reg(List<EnCronogDePago> ListEnCronogDePago)
        {
            try
            {
                DaCronogDePago objDaCronogDePago = new DaCronogDePago();
                return objDaCronogDePago.CronogramaPago_Listar_Reg(ListEnCronogDePago);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }


    }
}
