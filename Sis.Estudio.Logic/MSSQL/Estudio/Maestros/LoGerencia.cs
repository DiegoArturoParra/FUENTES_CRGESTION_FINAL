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
    public class LoGerencia
    {
        public List<EnTransaccion> Gerencia_INS(List<EnGerencia> ListEnGerencia)
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
                    DaGerencia objDaGerencia = new DaGerencia();
                    str_id = objDaGerencia.Gerencia_INS(ListEnGerencia, tran);
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
        public String Gerencia_UPD(List<EnGerencia> ListEnGerencia)
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
                    DaGerencia objDaGerencia = new DaGerencia();
                    objDaGerencia.Gerencia_UPD(ListEnGerencia, tran);
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
        public DataTable Gerencia_Listar(List<EnGerencia> ListEnGerencia)
        {
            try
            {
                DaGerencia objDaGerencia = new DaGerencia();
                return objDaGerencia.Gerencia_Listar(ListEnGerencia);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public DataTable Gerencia_Listar_Reg(List<EnGerencia> ListEnGerencia)
        {
            try
            {
                DaGerencia objDaGerencia = new DaGerencia();
                return objDaGerencia.Gerencia_Listar_Reg(ListEnGerencia);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }        
    }
}
