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
    public class LoGS_JerarquiaA
    {

        public List<EnTransaccion> GS_JerarquiaA_INS(List<EnGS_JerarquiaA> ListEnGS_JerarquiaA)
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
                    DaGS_JerarquiaA objDaGS_JerarquiaA = new DaGS_JerarquiaA();
                    str_id = objDaGS_JerarquiaA.GS_JerarquiaA_INS(ListEnGS_JerarquiaA, tran);
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

        public String GS_JerarquiaA_UPD(List<EnGS_JerarquiaA> ListEnGS_JerarquiaA)
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
                    DaGS_JerarquiaA objDaGS_JerarquiaA = new DaGS_JerarquiaA();
                    objDaGS_JerarquiaA.GS_JerarquiaA_UPD(ListEnGS_JerarquiaA, tran);
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

        public DataTable GS_JerarquiaA_Lista(List<EnGS_JerarquiaA> ListEnGS_JerarquiaA)
        {
            try
            {
                DaGS_JerarquiaA objDaGS_JerarquiaA = new DaGS_JerarquiaA();
                return objDaGS_JerarquiaA.GS_JerarquiaA_Lista(ListEnGS_JerarquiaA);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable GS_JerarquiaA_Reg(List<EnGS_JerarquiaA> ListEnGS_JerarquiaA)
        {
            try
            {
                DaGS_JerarquiaA objDaGS_JerarquiaA = new DaGS_JerarquiaA();
                return objDaGS_JerarquiaA.GS_JerarquiaA_Reg(ListEnGS_JerarquiaA);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public String GS_JerarquiaA_DEL(List<EnGS_JerarquiaA> ListEnGS_JerarquiaA)
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
                    DaGS_JerarquiaA objDaGS_JerarquiaA = new DaGS_JerarquiaA();
                    objDaGS_JerarquiaA.GS_JerarquiaA_DEL(ListEnGS_JerarquiaA, tran);
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



        public DataTable GS_JerarquiaA_Combo(List<EnGS_JerarquiaA> ListEnGS_JerarquiaA)
        {
            try
            {
                DaGS_JerarquiaA objDaGS_JerarquiaA = new DaGS_JerarquiaA();
                return objDaGS_JerarquiaA.GS_JerarquiaA_Combo(ListEnGS_JerarquiaA);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable GS_JerarquiaA_Ejecutores_Combo(List<EnGS_JerarquiaA> ListEnGS_JerarquiaA)
        {
            try
            {
                DaGS_JerarquiaA objDaGS_JerarquiaA = new DaGS_JerarquiaA();
                return objDaGS_JerarquiaA.GS_JerarquiaA_Ejecutores_Combo(ListEnGS_JerarquiaA);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable GS_ObtenerJerarquiaA(List<EnGS_JerarquiaA> ListEnGS_JerarquiaA)
        {
            try
            {
                DaGS_JerarquiaA objDaGS_JerarquiaA = new DaGS_JerarquiaA();
                return objDaGS_JerarquiaA.GS_ObtenerJerarquiaA(ListEnGS_JerarquiaA);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }


    }
}
