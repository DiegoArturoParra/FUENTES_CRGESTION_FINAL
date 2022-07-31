using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Sis.Estudio.Entity;
using Sis.Estudio.Data;
using Sis.Estudio.Data.MSSQL.Gestion;
namespace Sis.Estudio.Logic.MSSQL.Gestion
{
    public class LoGS_EnvioCorreoMasivo
    {

        public DataTable GS_EnvioCorreoMasivo_Lista(List<EnGS_EnvioCorreoMasivo> ListEnGS_EnvioCorreoMasivo)
        {
            try
            {
                DaGS_EnvioCorreoMasivo objDaGS_EnvioCorreoMasivo = new DaGS_EnvioCorreoMasivo();
                return objDaGS_EnvioCorreoMasivo.GS_EnvioCorreoMasivo_Lista(ListEnGS_EnvioCorreoMasivo);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public String GS_EnvioCorreoMasivo_DEL(List<EnGS_EnvioCorreoMasivo> ListEnGS_EnvioCorreoMasivo)
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
                    DaGS_EnvioCorreoMasivo objDaGS_EnvioCorreoMasivo = new DaGS_EnvioCorreoMasivo();
                    objDaGS_EnvioCorreoMasivo.GS_EnvioCorreoMasivo_DEL(ListEnGS_EnvioCorreoMasivo, tran);
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

        public String GS_EnvioCorreoMasivo_UPD(List<EnGS_EnvioCorreoMasivo> ListEnGS_EnvioCorreoMasivo)
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
                    DaGS_EnvioCorreoMasivo objDaGS_EnvioCorreoMasivo = new DaGS_EnvioCorreoMasivo();
                    objDaGS_EnvioCorreoMasivo.GS_EnvioCorreoMasivo_UPD(ListEnGS_EnvioCorreoMasivo, tran);
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


        public String mxInsertarRegistrosAEnvioCorreoMasivo(List<EnGS_EnvioCorreoMasivo> ListEnGS_EnvioCorreoMasivo)
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
                    DaGS_EnvioCorreoMasivo objDaGS_EnvioCorreoMasivo = new DaGS_EnvioCorreoMasivo();
                    objDaGS_EnvioCorreoMasivo.mxInsertarRegistrosAEnvioCorreoMasivo(ListEnGS_EnvioCorreoMasivo, tran);
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
    }
}
