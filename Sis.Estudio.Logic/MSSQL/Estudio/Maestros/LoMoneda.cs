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


namespace Sis.Estudio.Logic.MSSQL.Estudio.Maestros
{
     public class LoMoneda
    {



        public List<EnTransaccion> Moneda_INS(List<EnMoneda> ListEnMoneda)
        {
            string msg = "";
            string str_id = "";
            #region InicializoTransaccion
            string strMensaje = "";
            LoTransaccion Transaccion = new LoTransaccion();
            bool bolError = false;
            SqlTransaction tran = Transaccion.IniTransaccion_Tres(ref bolError, ref strMensaje);
            String rollback = String.Empty;
            #endregion InicializoTransaccion
            try
            {
                if (bolError == true)
                {
                    DaMoneda objDaMoneda = new DaMoneda();
                    str_id = objDaMoneda.Moneda_INS(ListEnMoneda, tran);
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
        public String Moneda_UPD(List<EnMoneda> ListEnMoneda)
        {
            string msg = "";
            #region InicializoTransaccion
            string strMensaje = "";
            LoTransaccion Transaccion = new LoTransaccion();
            bool bolError = false;
            SqlTransaction tran = Transaccion.IniTransaccion_Tres(ref bolError, ref strMensaje);
            String rollback = String.Empty;
            #endregion InicializoTransaccion
            try
            {
                if (bolError == true)
                {
                    DaMoneda objDaMoneda= new DaMoneda();
                    objDaMoneda.Moneda_UPD(ListEnMoneda, tran);
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


        public DataTable Moneda_Listar(List<EnMoneda> ListEnMoneda)
        {
            try
            {
                DaMoneda objDaMoneda = new DaMoneda();
                return objDaMoneda.Moneda_Listar(ListEnMoneda);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public String Moneda_DEL(List<EnMoneda> ListEnMoneda)
        {
            string msg = "";
            #region InicializoTransaccion
            string strMensaje = "";
            LoTransaccion Transaccion = new LoTransaccion();
            bool bolError = false;
            SqlTransaction tran = Transaccion.IniTransaccion_Tres(ref bolError, ref strMensaje);
            String rollback = String.Empty;
            #endregion InicializoTransaccion
            try

            {
                if (bolError == true)
                {
                    DaMoneda objDaMoneda = new DaMoneda();
                    objDaMoneda.Moneda_DEL(ListEnMoneda, tran);
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
        public DataTable Moneda_Listar_Reg(List<EnMoneda> ListEnMoneda)
        {
            try
            {
                DaMoneda objDaMoneda = new DaMoneda();
                return objDaMoneda.Moneda_Listar_Reg(ListEnMoneda);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
    }
}
