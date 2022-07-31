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
    public class LoCanalContact
    {
        public String CanalContact_INS(List<EnCanalContact> ListEnCanalContact)
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
                    DaCanalContact objDaCanalContact = new DaCanalContact();
                    objDaCanalContact.CanalContact_INS(ListEnCanalContact, tran);
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
        public String CanalContact_UPD(List<EnCanalContact> ListEnCanalContact)
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
                    DaCanalContact objDaCanalContact = new DaCanalContact();
                    objDaCanalContact.CanalContact_UPD(ListEnCanalContact, tran);
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
        public DataTable CanalContact_Listar(List<EnCanalContact> ListEnCanalContact)
        {
            try
            {
                DaCanalContact objDaCanalContact = new DaCanalContact();
                return objDaCanalContact.CanalContact_Listar(ListEnCanalContact);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public DataTable CanalContact_Listar_Reg(List<EnCanalContact> ListEnCanalContact)
        {
            try
            {
                DaCanalContact objDaCanalContact = new DaCanalContact();
                return objDaCanalContact.CanalContact_Listar_Reg(ListEnCanalContact);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        
    }
}
