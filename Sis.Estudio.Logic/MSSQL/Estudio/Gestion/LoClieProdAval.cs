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
    public class LoClieProdAval
    {
        public String Producto_Aval_INS(List<EnClieProdAval> ListEnClieProdAval)
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
                    DaClieProdAval objDaClieProdAval = new DaClieProdAval();
                    objDaClieProdAval.Producto_Aval_INS(ListEnClieProdAval, tran);
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
        public String Producto_Aval_UPD(List<EnClieProdAval> ListEnClieProdAval)
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
                    DaClieProdAval objDaClieProdAval = new DaClieProdAval();
                    objDaClieProdAval.Producto_Aval_UPD(ListEnClieProdAval, tran);
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
        public DataTable Producto_Aval_Listar(List<EnClieProdAval> ListEnClieProdAval)
        {
            try
            {
                DaClieProdAval objDaClieProdAval = new DaClieProdAval();
                return objDaClieProdAval.Producto_Aval_Listar(ListEnClieProdAval);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public DataTable Producto_Aval_Lisrtar_Reg(List<EnClieProdAval> ListEnClieProdAval)
        {
            try
            {
                DaClieProdAval objDaClieProdAval = new DaClieProdAval();
                return objDaClieProdAval.Producto_Aval_Lisrtar_Reg(ListEnClieProdAval);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

    }
}
