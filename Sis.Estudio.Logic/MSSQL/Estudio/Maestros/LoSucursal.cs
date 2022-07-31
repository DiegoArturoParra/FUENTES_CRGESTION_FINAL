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
    public class LoSucursal
    {
        public List<EnTransaccion> Sucursal_INS(List<EnSucursal> ListEnSucursal)
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
                    DaSucursal objDaSucursal = new DaSucursal();
                    str_id =  objDaSucursal.Sucursal_INS(ListEnSucursal, tran);
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
        public String Sucursal_UPD(List<EnSucursal> ListEnSucursal)
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
                    DaSucursal objDaSucursal = new DaSucursal();
                    objDaSucursal.Sucursal_UPD(ListEnSucursal, tran);
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
        public DataTable Sucursal_Listar(List<EnSucursal> ListEnSucursal)
        {
            try
            {
                DaSucursal objDaSucursal = new DaSucursal();
                return objDaSucursal.Sucursal_Listar(ListEnSucursal);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public DataTable Sucursal_Listar_Reg(List<EnSucursal> ListEnSucursal)
        {
            try
            {
                DaSucursal objDaSucursal = new DaSucursal();
                return objDaSucursal.Sucursal_Listar_Reg(ListEnSucursal);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
    }
}
