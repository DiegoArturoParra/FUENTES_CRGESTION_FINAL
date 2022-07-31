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
    public class LoGS_Carta
    {


        public List<EnTransaccion> GS_Carta_INS(List<EnGS_Carta> ListEnGS_Carta)
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
                    DaGS_Carta objDaGS_Carta = new DaGS_Carta();
                    str_id = objDaGS_Carta.GS_Carta_INS(ListEnGS_Carta, tran);
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


        public String GS_Carta_UPD(List<EnGS_Carta> ListEnGS_Carta)
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
                    DaGS_Carta objDaGS_Carta = new DaGS_Carta();
                    objDaGS_Carta.GS_Carta_UPD(ListEnGS_Carta, tran);
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

        public DataTable GS_Carta_Lista(List<EnGS_Carta> ListEnGS_Carta)
        {
            try
            {
                DaGS_Carta objDaGS_Carta = new DaGS_Carta();
                return objDaGS_Carta.GS_Carta_Lista(ListEnGS_Carta);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable GS_Carta_Reg(List<EnGS_Carta> ListEnGS_Carta)
        {
            try
            {
                DaGS_Carta objDaGS_Carta = new DaGS_Carta();
                return objDaGS_Carta.GS_Carta_Reg(ListEnGS_Carta);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public String GS_Carta_DEL(List<EnGS_Carta> ListEnGS_Carta)
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
                    DaGS_Carta objDaGS_Carta = new DaGS_Carta();
                    objDaGS_Carta.GS_Carta_DEL(ListEnGS_Carta, tran);
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

        public DataTable GS_Carta_Tipo_Documento_Combo()
        {
            try
            {
                DaGS_Carta objDaGS_Carta = new DaGS_Carta();
                return objDaGS_Carta.GS_Carta_Tipo_Documento_Combo();
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public int GS_ValidarCanalContacto(int idGestionCobranza)
        {
            try
            {
                DaGS_Carta objDaGS_Carta = new DaGS_Carta();
                return objDaGS_Carta.GS_ValidarCanalContacto(idGestionCobranza);
            }
            catch (Exception excp)
            {
                
                throw excp;
            }
        }

        public DataTable GS_Documento_Lista(List<EnGS_Carta> ListEnGS_Carta)
        {
            try
            {
                DaGS_Carta objDaGS_Carta = new DaGS_Carta();
                return objDaGS_Carta.GS_Documento_Lista(ListEnGS_Carta);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }


        public DataTable GS_TipoDocumento_Lista(List<EnGS_Carta> ListEnGS_Carta)
        {
            try
            {
                DaGS_Carta objDaGS_Carta = new DaGS_Carta();
                return objDaGS_Carta.GS_TipoDocumento_Lista(ListEnGS_Carta);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable GS_Documento_X_Tipo(List<EnGS_Carta> ListEnGS_Carta)
        {
            try
            {
                DaGS_Carta objDaGS_Carta = new DaGS_Carta();
                return objDaGS_Carta.GS_Documento_X_Tipo(ListEnGS_Carta);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }


}
