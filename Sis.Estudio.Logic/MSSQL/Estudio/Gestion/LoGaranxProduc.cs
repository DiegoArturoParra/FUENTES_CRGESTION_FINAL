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
    public class LoGaranxProduc
    {

        public String Garantia_Producto_INS(List<EnGaranxProduc> ListEnGaranxProduc)
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
                    DaGaranxProduc objDaGaranxProduc = new DaGaranxProduc();
                    objDaGaranxProduc.Garantia_Producto_INS(ListEnGaranxProduc, tran);
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
        public String Garantia_Producto_UPD(List<EnGaranxProduc> ListEnGaranxProduc)
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
                    DaGaranxProduc objDaGaranxProduc = new DaGaranxProduc();
                    objDaGaranxProduc.Garantia_Producto_UPD(ListEnGaranxProduc, tran);
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
        public DataTable Garantia_Producto_Listar_Reg(List<EnGaranxProduc> ListEnGaranxProduc)
        {
            try
            {
                DaGaranxProduc objDaGaranxProduc = new DaGaranxProduc();
                return objDaGaranxProduc.Garantia_Producto_Listar_Reg(ListEnGaranxProduc);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public DataTable Garantia_Producto_Listar(List<EnGaranxProduc> ListEnGaranxProduc)
        {
            try
            {
                DaGaranxProduc objDaGaranxProduc = new DaGaranxProduc();
                return objDaGaranxProduc.Garantia_Producto_Listar(ListEnGaranxProduc);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

    }
}
