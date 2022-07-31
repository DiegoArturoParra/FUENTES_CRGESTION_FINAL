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
    public class LoGarantia
    {

        public List<EnTransaccion> Garantia_INS(List<EnGarantia> ListEnGarantia)
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
                    DaGarantia objDaGarantia = new DaGarantia();
                    str_id = objDaGarantia.Garantia_INS(ListEnGarantia, tran);
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
        public String Garantia_UPD(List<EnGarantia> ListEnGarantia)
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
                    DaGarantia objDaGarantia = new DaGarantia();
                    objDaGarantia.Garantia_UPD(ListEnGarantia, tran);
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
        public DataTable Garantia_Listar(List<EnGarantia> ListEnGarantia)
        {
            try
            {
                DaGarantia objDaGarantia = new DaGarantia();
                return objDaGarantia.Garantia_Listar(ListEnGarantia);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public DataTable Garantia_Listar_Reg(List<EnGarantia> ListEnGarantia)
        {
            try
            {
                DaGarantia objDaGarantia = new DaGarantia();
                return objDaGarantia.Garantia_Listar_Reg(ListEnGarantia);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

    }
}
