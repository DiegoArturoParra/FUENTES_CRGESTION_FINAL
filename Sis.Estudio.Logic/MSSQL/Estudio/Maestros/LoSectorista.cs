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
    public class LoSectorista
    {

        public List<EnTransaccion> Sectorista_INS(List<EnSectorista> ListEnSectorista)
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
                    DaSectorista objDaSectorista = new DaSectorista();
                    str_id = objDaSectorista.Sectorista_INS(ListEnSectorista, tran);
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

        public String Sectorista_UPD(List<EnSectorista> ListEnSectorista)
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
                    DaSectorista objDaSectorista = new DaSectorista();
                    objDaSectorista.Sectorista_UPD(ListEnSectorista, tran);
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
        public DataTable Sectorista_Listar(List<EnSectorista> ListEnSectorista)
        {
            try
            {
                DaSectorista objDaSectorista = new DaSectorista();
                return objDaSectorista.Sectorista_Listar(ListEnSectorista);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public DataTable Sectorista_Listar_Reg(List<EnSectorista> ListEnSectorista)
        {
            try
            {
                DaSectorista objDaSectorista = new DaSectorista();
                return objDaSectorista.Sectorista_Listar_Reg(ListEnSectorista);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public DataTable Sectorista_Litar_X_Zona(List<EnSectorista> ListEnSectorista)
        {
            try
            {
                DaSectorista objDaSectorista = new DaSectorista();
                return objDaSectorista.Sectorista_Litar_X_Zona(ListEnSectorista);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }




    }
}
