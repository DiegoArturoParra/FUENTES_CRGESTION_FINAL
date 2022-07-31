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
    public class LoAvalDeclaPat
    {
        public String Aval_DeclaPatrimonial_INS(List<EnAvalDeclaPat> ListEnAvalDeclaPat)
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
                    DaAvalDeclaPat objDaAvalDeclaPat = new DaAvalDeclaPat();
                    objDaAvalDeclaPat.Aval_DeclaPatrimonial_INS(ListEnAvalDeclaPat, tran);
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
        public String Aval_DeclaPatrimonial_UPD(List<EnAvalDeclaPat> ListEnAvalDeclaPat)
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
                    DaAvalDeclaPat objDaAvalDeclaPat = new DaAvalDeclaPat();
                    objDaAvalDeclaPat.Aval_DeclaPatrimonial_UPD(ListEnAvalDeclaPat, tran);
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
        public DataTable Aval_DeclaPatrimonial_Listar(List<EnAvalDeclaPat> ListEnAvalDeclaPat)
        {
            try
            {
                DaAvalDeclaPat objDaAvalDeclaPat = new DaAvalDeclaPat();
                return objDaAvalDeclaPat.Aval_DeclaPatrimonial_Listar(ListEnAvalDeclaPat);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public DataTable Aval_DeclaPatrimonial_Listar_Reg(List<EnAvalDeclaPat> ListEnAvalDeclaPat)
        {
            try
            {
                DaAvalDeclaPat objDaAvalDeclaPat = new DaAvalDeclaPat();
                return objDaAvalDeclaPat.Aval_DeclaPatrimonial_Listar_Reg(ListEnAvalDeclaPat);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

    }
}
