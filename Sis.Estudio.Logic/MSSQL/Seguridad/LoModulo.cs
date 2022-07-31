using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Sis.Estudio.Entity;
using Sis.Estudio.Logic;
using Sis.Estudio.Data.MSSQL.Seguridad;

namespace Sis.Estudio.Logic.MSSQL.Seguridad
{
    public class LoModulo
    {        
        #region Modulo
        public DataTable Listado_Modulo(List<EnModulo> ListEnModulo)
        {
            DaModulo objDaModulo = new DaModulo();
            return objDaModulo.Listado_Modulo(ListEnModulo);
        }
        public DataTable CargaDatosModulo(List<EnModulo> ListEnModulo)
        {
            DaModulo objDaModulo = new DaModulo();
            return objDaModulo.CargaDatosModulo(ListEnModulo);
        }
        public DataTable Lista_TodosLosModulos(List<EnModulo> ListEnModulo)
        {
            DaModulo objDaModulo = new DaModulo();
            return objDaModulo.Lista_TodosLosModulos(ListEnModulo);
        }
        public List<EnTransaccion> Insertar_Modulo(List<EnModulo> ListEnModulo)
        {
            string msg = "";
            string str_id = "";
            # region InicializoTransaccion
            string strMensaje = "";
            LoTransaccion Transaccion = new LoTransaccion();
            bool bolError = false;
            SqlTransaction tran = Transaccion.IniTransaccion_Seg(ref bolError, ref strMensaje);
            String rollback = String.Empty;
            #endregion
            try
            {
                if (bolError == true)
                {
                    DaModulo objDaModulo = new DaModulo();
                    str_id = objDaModulo.Insertar_Modulo(ListEnModulo, tran);
                    tran.Commit();
                }
                else
                {
                    msg = "Se presentaron errores al inicializar la operación ";
                }
            }
            catch (SqlException ex)
            {
                tran.Rollback();
                msg = ex.Message;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                msg = ex.Message;
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
        public String Modifica_Modulo(List<EnModulo> ListEnModulo)
        {
            string msg = "";
            # region InicializoTransaccion
            string strMensaje = "";
            LoTransaccion Transaccion = new LoTransaccion();
            bool bolError = false;
            SqlTransaction tran = Transaccion.IniTransaccion_Seg(ref bolError, ref strMensaje);
            String rollback = String.Empty;
            #endregion
            try
            {
                if (bolError == true)
                {
                    DaModulo objDaModulo = new DaModulo();
                    objDaModulo.Modifica_Modulo(ListEnModulo, tran);
                    tran.Commit();
                }
                else
                {
                    msg = "Se presentaron errores al inicializar la operación ";
                }
            }
            catch (SqlException ex)
            {
                tran.Rollback();
                msg = ex.Message;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                msg = ex.Message;
            }
            finally
            {
                tran.Dispose();
            }
            return msg;
        }
        public String Anula_Modulo(List<EnModulo> ListEnModulo)
        {
            string msg = "";
            # region InicializoTransaccion
            string strMensaje = "";
            LoTransaccion Transaccion = new LoTransaccion();
            bool bolError = false;
            SqlTransaction tran = Transaccion.IniTransaccion_Seg(ref bolError, ref strMensaje);
            String rollback = String.Empty;
            #endregion
            try
            {
                if (bolError == true)
                {
                    DaModulo objDaModulo = new DaModulo();
                    objDaModulo.Anula_Modulo(ListEnModulo, tran);
                    tran.Commit();
                }
                else
                {
                    msg = "Se presentaron errores al inicializar la operación ";
                }
            }
            catch (SqlException ex)
            {
                tran.Rollback();
                msg = ex.Message;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                msg = ex.Message;
            }
            finally
            {
                tran.Dispose();
            }
            return msg;
        }
        #endregion Modulo
    }
}