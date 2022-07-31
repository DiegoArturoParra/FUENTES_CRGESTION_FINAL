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
    public class LoAvalDireccio
    {

        public String Aval_Direccion_INS(List<EnAvalDireccio> ListEnAvalDireccio)
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
                    DaAvalDireccio objDaAvalDireccio = new DaAvalDireccio();
                    objDaAvalDireccio.Aval_Direccion_INS(ListEnAvalDireccio, tran);
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
        public String Aval_Direccion_UPD(List<EnAvalDireccio> ListEnAvalDireccio)
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
                    DaAvalDireccio objDaAvalDireccio = new DaAvalDireccio();
                    objDaAvalDireccio.Aval_Direccion_UPD(ListEnAvalDireccio, tran);
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
        public DataTable Aval_Direccion_Listar(List<EnAvalDireccio> ListEnAvalDireccio)
        {
            try
            {
                DaAvalDireccio objDaAvalDireccio = new DaAvalDireccio();
                return objDaAvalDireccio.Aval_Direccion_Listar(ListEnAvalDireccio);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public DataTable Aval_Direccion_Listar_Reg(List<EnAvalDireccio> ListEnAvalDireccio)
        {
            try
            {
                DaAvalDireccio objDaAvalDireccio = new DaAvalDireccio();
                return objDaAvalDireccio.Aval_Direccion_Listar_Reg(ListEnAvalDireccio);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }


    }
}
