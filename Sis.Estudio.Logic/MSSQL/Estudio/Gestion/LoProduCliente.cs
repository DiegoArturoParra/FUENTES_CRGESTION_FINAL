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
    public class LoProduCliente
    {

        public String Cliente_Productos_INS(List<EnProduCliente> ListEnProduCliente)
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
                    DaProduCliente objDaProduCliente = new DaProduCliente();
                    objDaProduCliente.Cliente_Productos_INS(ListEnProduCliente, tran);
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
        public String Cliente_Productos_UPD(List<EnProduCliente> ListEnProduCliente)
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
                    DaProduCliente objDaProduCliente = new DaProduCliente();
                    objDaProduCliente.Cliente_Productos_UPD(ListEnProduCliente, tran);
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
        public DataTable Cliente_Productos_Listar(List<EnProduCliente> ListEnProduCliente)
        {
            try
            {
                DaProduCliente objDaProduCliente = new DaProduCliente();
                return objDaProduCliente.Cliente_Productos_Listar(ListEnProduCliente);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public DataTable Cliente_Productos_Listar_Reg(List<EnProduCliente> ListEnProduCliente)
        {
            try
            {
                DaProduCliente objDaProduCliente = new DaProduCliente();
                return objDaProduCliente.Cliente_Productos_Listar_Reg(ListEnProduCliente);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable Cliente_Productos_Gastos_Listar(List<EnProduCliente> ListEnProduCliente)
        {
            try
            {
                DaProduCliente objDaProduCliente = new DaProduCliente();
                return objDaProduCliente.Cliente_Productos_Gastos_Listar(ListEnProduCliente);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public DataTable Cliente_Productos_GC_Listar(List<EnProduCliente> ListEnProduCliente)
        {
            try
            {
                DaProduCliente objDaProduCliente = new DaProduCliente();
                return objDaProduCliente.Cliente_Productos_GC_Listar(ListEnProduCliente);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }


    }
}
