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
    public class LoZona
    {
        public List<EnTransaccion> Zona_INS(List<EnZona> ListEnZona)
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
                    DaZona objDaZona = new DaZona();
                    str_id = objDaZona.Zona_INS(ListEnZona, tran);
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
        public String Zona_UPD(List<EnZona> ListEnZona)
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
                    DaZona objDaZona = new DaZona();
                    objDaZona.Zona_UPD(ListEnZona, tran);
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

        public DataTable Zona_Listar(List<EnZona> ListEnZona)
        {
            try
            {
                DaZona objDaZona = new DaZona();
                return objDaZona.Zona_Listar(ListEnZona);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public DataTable Zona_Listar_Reg(List<EnZona> ListEnZona)
        {
            try
            {
                DaZona objDaZona = new DaZona();
                return objDaZona.Zona_Listar_Reg(ListEnZona);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public DataTable Zona_Listar_X_Gerencia(List<EnZona> ListEnZona)
        {
            try
            {
                DaZona objDaZona = new DaZona();
                return objDaZona.Zona_Listar_X_Gerencia(ListEnZona);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }


    }
}
