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
    public class LoProducto
    {

        public List<EnTransaccion> Producto_INS(List<EnProducto> ListEnProducto)
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
                    DaProducto objDaProducto = new DaProducto();
                    str_id = objDaProducto.Producto_INS(ListEnProducto, tran);
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
        public String Producto_UPD(List<EnProducto> ListEnProducto)
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
                    DaProducto objDaProducto = new DaProducto();
                    objDaProducto.Producto_UPD(ListEnProducto, tran);
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
        public DataTable Producto_Listar(List<EnProducto> ListEnProducto)
        {
            try
            {
                DaProducto objDaProducto = new DaProducto();
                return objDaProducto.Producto_Listar(ListEnProducto);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public DataTable Producto_Listar_Reg(List<EnProducto> ListEnProducto)
        {
            try
            {
                DaProducto objDaProducto = new DaProducto();
                return objDaProducto.Producto_Listar_Reg(ListEnProducto);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

    }
}
