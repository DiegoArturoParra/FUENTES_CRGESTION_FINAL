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
    public class LoCalificacionSBS
    {
        public List<EnTransaccion> CalificacionSBS_INS(List<EnCalificacionSBS> ListEnCalificacionSBS)
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
                    DaCalificacionSBS objDaCalificacionSBS = new DaCalificacionSBS();
                    str_id = objDaCalificacionSBS.CalificacionSBS_INS(ListEnCalificacionSBS, tran);
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
        public String CalificacionSBS_UPD(List<EnCalificacionSBS> ListEnCalificacionSBS)
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
                    DaCalificacionSBS objDaCalificacionSBS = new DaCalificacionSBS();
                    objDaCalificacionSBS.CalificacionSBS_UPD(ListEnCalificacionSBS, tran);
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
        public DataTable CalificacionSBS_Listar()
        {
            try
            {
                DaCalificacionSBS objDa = new DaCalificacionSBS();
                return objDa.CalificacionSBS_Listar();
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public DataTable CalificacionSBS_Listar_Reg(List<EnCalificacionSBS> ListEnCalificacionSBS)
        {
            try
            {
                DaCalificacionSBS objDaCalificacionSBS = new DaCalificacionSBS();
                return objDaCalificacionSBS.CalificacionSBS_Listar_Reg(ListEnCalificacionSBS);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }       
    }
}
