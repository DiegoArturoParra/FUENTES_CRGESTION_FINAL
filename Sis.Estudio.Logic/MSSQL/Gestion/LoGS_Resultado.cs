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
    public class LoGS_Resultado
    {


        public List<EnTransaccion> GS_Resultado_INS(List<EnGS_Resultado> ListEnGS_Resultado)
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
                    DaGS_Resultado objDaGS_Resultado = new DaGS_Resultado();
                    str_id = objDaGS_Resultado.GS_Resultado_INS(ListEnGS_Resultado, tran);
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


        public String GS_Resultado_UPD(List<EnGS_Resultado> ListEnGS_Resultado)
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
                    DaGS_Resultado objDaGS_Resultado = new DaGS_Resultado();
                    objDaGS_Resultado.GS_Resultado_UPD(ListEnGS_Resultado, tran);
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

        public DataTable GS_Resultado_Listar_Todos()
        {
            try
            {
                DaGS_Resultado objDaGS_Resultado = new DaGS_Resultado();
                return objDaGS_Resultado.GS_Resultado_Lista_Todos();
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public DataTable GS_Resultado_Lista(List<EnGS_Resultado> ListEnGS_Resultado)
        {
            try
            {
                DaGS_Resultado objDaGS_Resultado = new DaGS_Resultado();
                return objDaGS_Resultado.GS_Resultado_Lista(ListEnGS_Resultado);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable GS_Resultado_Reg(List<EnGS_Resultado> ListEnGS_Resultado)
        {
            try
            {
                DaGS_Resultado objDaGS_Resultado = new DaGS_Resultado();
                return objDaGS_Resultado.GS_Resultado_Reg(ListEnGS_Resultado);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public String GS_Resultado_DEL(List<EnGS_Resultado> ListEnGS_Resultado)
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
                    DaGS_Resultado objDaGS_Resultado = new DaGS_Resultado();
                    objDaGS_Resultado.GS_Resultado_DEL(ListEnGS_Resultado, tran);
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
