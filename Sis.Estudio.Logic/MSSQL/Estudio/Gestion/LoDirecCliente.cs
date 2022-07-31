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
    public class LoDirecCliente
    {

        public String DirecCliente_INS(List<EnDirecCliente> ListEnDirecCliente)
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
                    DaDirecCliente objDaDirecCliente = new DaDirecCliente();
                    objDaDirecCliente.DirecCliente_INS(ListEnDirecCliente, tran);
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
        public String DirecCliente_UPD(List<EnDirecCliente> ListEnDirecCliente)
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
                    DaDirecCliente objDaDirecCliente = new DaDirecCliente();
                    objDaDirecCliente.DirecCliente_UPD(ListEnDirecCliente, tran);
                    tran.Commit();

                    msg = @"{'res':'exito'}";




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
        public DataTable DirecCliente_Lista(List<EnDirecCliente> ListEnDirecCliente)
        {
            try
            {
                DaDirecCliente objDaDirecCliente = new DaDirecCliente();
                return objDaDirecCliente.DirecCliente_Lista(ListEnDirecCliente);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public DataTable DirecCliente_Lista_Reg(List<EnDirecCliente> ListEnDirecCliente)
        {
            try
            {
                DaDirecCliente objDaDirecCliente = new DaDirecCliente();
                return objDaDirecCliente.DirecCliente_Lista_Reg(ListEnDirecCliente);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

  

    }
}
