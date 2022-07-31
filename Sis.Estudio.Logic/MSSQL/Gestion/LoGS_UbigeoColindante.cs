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
    public class LoGS_UbigeoColindante
    {



        public DataTable GS_UbigeoColindante_Lista(List<EnGS_UbigeoColindante> ListEnGS_UbigeoColindante)
        {
            try
            {
                DaGS_UbigeoColindante objDaGS_UbigeoColindante = new DaGS_UbigeoColindante();
                return objDaGS_UbigeoColindante.GS_UbigeoColindante_Lista(ListEnGS_UbigeoColindante);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }



        public DataTable GS_UbigeoColindante_Departamentos_Combo()
        {
            try
            {
                DaGS_UbigeoColindante objDaGS_UbigeoColindante = new DaGS_UbigeoColindante();
                return objDaGS_UbigeoColindante.GS_UbigeoColindante_Departamentos_Combo();
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable GS_UbigeoColindante_Provincias_Combo(List<EnGS_UbigeoColindante> ListEnGS_UbigeoColindante)
        {
            try
            {
                DaGS_UbigeoColindante objDaGS_UbigeoColindante = new DaGS_UbigeoColindante();
                return objDaGS_UbigeoColindante.GS_UbigeoColindante_Provincias_Combo(ListEnGS_UbigeoColindante);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable GS_UbigeoColindante_Distritos_Combo(List<EnGS_UbigeoColindante> ListEnGS_UbigeoColindante)
        {
            try
            {
                DaGS_UbigeoColindante objDaGS_UbigeoColindante = new DaGS_UbigeoColindante();
                return objDaGS_UbigeoColindante.GS_UbigeoColindante_Distritos_Combo(ListEnGS_UbigeoColindante);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }


        public String GS_UbigeoColindante_DEL(List<EnGS_UbigeoColindante> ListEnGS_UbigeoColindante)
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
                    DaGS_UbigeoColindante objDaGS_UbigeoColindante = new DaGS_UbigeoColindante();
                    objDaGS_UbigeoColindante.GS_UbigeoColindante_DEL(ListEnGS_UbigeoColindante, tran);
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

        public List<EnTransaccion> GS_UbigeoColindante_INS(List<EnGS_UbigeoColindante> ListEnGS_UbigeoColindante)
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
                    DaGS_UbigeoColindante objDaGS_UbigeoColindante = new DaGS_UbigeoColindante();
                    str_id = objDaGS_UbigeoColindante.GS_UbigeoColindante_INS(ListEnGS_UbigeoColindante, tran);
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

    }
}
