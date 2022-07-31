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


namespace Sis.Estudio.Logic.MSSQL.Estudio.Gestion
{
    public class LoCliente_Gastos
    {


        public List<EnTransaccion> Cliente_Gastos_INS(List<EnCliente_Gastos> ListEnCliente_Gastos)
        {
            string msg = "";
            string str_id = "";
            # region InicializoTransaccion
            string strMensaje = "";
            LoTransaccion Transaccion = new LoTransaccion();
            bool bolError = false;
            SqlTransaction tran = Transaccion.IniTransaccion_Seg(ref bolError, ref strMensaje);
            String rollback = String.Empty;
            #endregion
            try
            {
                if (bolError == true)
                {
                  DaCliente_Gastos objDaCliente_Gastos = new DaCliente_Gastos();
                    str_id = objDaCliente_Gastos.Cliente_Gastos_INS(ListEnCliente_Gastos, tran);
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
                msg = ex.Message;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                msg = ex.Message;
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


        public String Cliente_Gastos_UPD(List<EnCliente_Gastos> ListEnCliente_Gastos)
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
                    DaCliente_Gastos objDaCliente_Gastos = new DaCliente_Gastos();
                    objDaCliente_Gastos.Cliente_Gastos_UPD(ListEnCliente_Gastos, tran);
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

        public DataTable Cliente_Gastos_Lista(List<EnCliente_Gastos> ListEnCliente_Gastos)
        {
            try
            {
                DaCliente_Gastos objDaCliente_Gastos = new DaCliente_Gastos();
                return objDaCliente_Gastos.Cliente_Gastos_Lista(ListEnCliente_Gastos);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable Cliente_Gastos_Reg(List<EnCliente_Gastos> ListEnCliente_Gastos)
        {
            try
            {
                DaCliente_Gastos objDaCliente_Gastos = new DaCliente_Gastos();
                return objDaCliente_Gastos.Cliente_Gastos_Reg(ListEnCliente_Gastos);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public String Cliente_Gastos_DEL(List<EnCliente_Gastos> ListEnCliente_Gastos)
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
                    DaCliente_Gastos objDaCliente_Gastos = new DaCliente_Gastos();
                    objDaCliente_Gastos.Cliente_Gastos_DEL(ListEnCliente_Gastos, tran);
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

        public DataTable Cliente_Gastos_Combo()
        {
            try
            {
                DaCliente_Gastos objDaCliente_Gastos = new DaCliente_Gastos();
                return objDaCliente_Gastos.Cliente_Gastos_Tipo_Tramite_Combo();
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
    }
}
