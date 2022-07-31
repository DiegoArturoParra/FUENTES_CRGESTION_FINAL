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
    public class LoSituacionLaboral
    {

        public List<EnTransaccion> SituacionLaboral_INS(List<EnSituacionLaboral> ListEnSituacionLaboral)
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
                    DaSituacionLaboral objDaSituacionLaboral = new DaSituacionLaboral();
                    str_id = objDaSituacionLaboral.SituacionLaboral_INS(ListEnSituacionLaboral, tran);
                    tran.Commit();
                    //msg = "exito";
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
        public String SituacionLaboral_UPD(List<EnSituacionLaboral> ListEnSituacionLaboral)
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
                    DaSituacionLaboral objDaSituacionLaboral = new DaSituacionLaboral();
                    objDaSituacionLaboral.SituacionLaboral_UPD(ListEnSituacionLaboral, tran);
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
        public DataTable SituacionLaboral_Listar()
        {
            try
            {
                DaSituacionLaboral objDa = new DaSituacionLaboral();
                return objDa.SituacionLaboral_Listar();
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public DataTable SituacionLaboral_Listar_Reg(List<EnSituacionLaboral> ListEnSituacionLaboral)
        {
            try
            {
                DaSituacionLaboral objDaSituacionLaboral = new DaSituacionLaboral();
                return objDaSituacionLaboral.SituacionLaboral_Listar_Reg(ListEnSituacionLaboral);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }        
    }
}
