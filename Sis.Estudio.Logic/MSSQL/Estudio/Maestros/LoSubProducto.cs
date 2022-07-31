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
    public class LoSubProducto
    {
        public List<EnTransaccion> SubProducto_INS(List<EnSubProducto> ListEnSubProducto)
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
                    DaSubProducto objDaSubProducto = new DaSubProducto();
                    str_id = objDaSubProducto.SubProducto_INS(ListEnSubProducto, tran);
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
        public String SubProducto_UPD(List<EnSubProducto> ListEnSubProducto)
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
                    DaSubProducto objDaSubProducto = new DaSubProducto();
                    objDaSubProducto.SubProducto_UPD(ListEnSubProducto, tran);
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
        public DataTable SubProducto_Listar(List<EnSubProducto> ListEnSubProducto)
        {
            try
            {
                DaSubProducto objDaSubProducto = new DaSubProducto();
                return objDaSubProducto.SubProducto_Listar(ListEnSubProducto);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public DataTable SubProducto_Listar_Reg(List<EnSubProducto> ListEnSubProducto)
        {
            try
            {
                DaSubProducto objDaSubProducto = new DaSubProducto();
                return objDaSubProducto.SubProducto_Listar_Reg(ListEnSubProducto);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public DataTable SubProducto_Listar_X_Producto(List<EnSubProducto> ListEnSubProducto)
        {
            try
            {
                DaSubProducto objDa = new DaSubProducto();
                return objDa.SubProducto_Listar_X_Producto(ListEnSubProducto);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

    }
}
