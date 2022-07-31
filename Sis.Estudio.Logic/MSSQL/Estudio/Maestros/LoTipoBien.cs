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
    public class LoTipoBien
    {
        public List<EnTransaccion> TipoBien_INS(List<EnTipoBien> ListEnTipoBien)
        {
            string msg = "";
            string str_id = "";
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
                    DaTipoBien objDaTipoBien = new DaTipoBien();
                    str_id = objDaTipoBien.TipoBien_INS(ListEnTipoBien, tran);
                    tran.Commit();
                    //msg = "exito";
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
        public String TipoBien_UPD(List<EnTipoBien> ListEnTipoBien)
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
                    DaTipoBien objDaTipoBien = new DaTipoBien();
                    objDaTipoBien.TipoBien_UPD(ListEnTipoBien, tran);
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
        public DataTable TipoBien_Listar_Reg(List<EnTipoBien> ListEnTipoBien)
        {
            try
            {
                DaTipoBien objDaTipoBien = new DaTipoBien();
                return objDaTipoBien.TipoBien_Listar_Reg(ListEnTipoBien);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public DataTable TipoBien_Listar()
        {
            try
            {

                DaTipoBien objDa = new DaTipoBien();
                return objDa.TipoBien_Listar();
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

    }
}
