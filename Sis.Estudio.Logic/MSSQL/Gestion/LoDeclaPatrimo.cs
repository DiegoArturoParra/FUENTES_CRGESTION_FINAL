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
    public class LoDeclaPatrimo
    {

        public String DeclaPatrimo_INS(List<EnDeclaPatrimo> ListEnDeclaPatrimo)
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
                    DaDeclaPatrimo objDaDeclaPatrimo = new DaDeclaPatrimo();
                    objDaDeclaPatrimo.DeclaPatrimo_INS(ListEnDeclaPatrimo, tran);
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
        public String DeclaPatrimo_UPD(List<EnDeclaPatrimo> ListEnDeclaPatrimo)
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
                    DaDeclaPatrimo objDaDeclaPatrimo = new DaDeclaPatrimo();
                    objDaDeclaPatrimo.DeclaPatrimo_UPD(ListEnDeclaPatrimo, tran);
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
        public DataTable DeclaPatrimo_Lista(List<EnDeclaPatrimo> ListEnDeclaPatrimo)
        {
            try
            {
                DaDeclaPatrimo objDaDeclaPatrimo = new DaDeclaPatrimo();
                return objDaDeclaPatrimo.DeclaPatrimo_Lista(ListEnDeclaPatrimo);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public DataTable DeclaPatrimo_Lista_Reg(List<EnDeclaPatrimo> ListEnDeclaPatrimo)
        {
            try
            {
                DaDeclaPatrimo objDaDeclaPatrimo = new DaDeclaPatrimo();
                return objDaDeclaPatrimo.DeclaPatrimo_Lista_Reg(ListEnDeclaPatrimo);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public DataTable DeclaPatrimo_TipoBien_Lista()
        {
            try
            {
                DaDeclaPatrimo objDaDeclaPatrimo = new DaDeclaPatrimo();
                return objDaDeclaPatrimo.DeclaPatrimo_TipoBien_Lista();
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }


    }
}
