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
    public class LoDatosLaboral
    {
        public String DatosLaboral_INS(List<EnDatosLaboral> ListEnDatosLaboral)
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
                    DaDatosLaboral objDaDatosLaboral = new DaDatosLaboral();
                    objDaDatosLaboral.DatosLaboral_INS(ListEnDatosLaboral, tran);
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
        public String DatosLaboral_UPD(List<EnDatosLaboral> ListEnDatosLaboral)
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
                    DaDatosLaboral objDaDatosLaboral = new DaDatosLaboral();
                    objDaDatosLaboral.DatosLaboral_UPD(ListEnDatosLaboral, tran);
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
        public DataTable DatosLaboral_Lista(List<EnDatosLaboral> ListEnDatosLaboral)
        {
            try
            {
                DaDatosLaboral objDaDatosLaboral = new DaDatosLaboral();
                return objDaDatosLaboral.DatosLaboral_Lista(ListEnDatosLaboral);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public DataTable DatosLaboral_Lista_Reg(List<EnDatosLaboral> ListEnDatosLaboral)
        {
            try
            {
                DaDatosLaboral objDaDatosLaboral = new DaDatosLaboral();
                return objDaDatosLaboral.DatosLaboral_Lista_Reg(ListEnDatosLaboral);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        
    }
}
