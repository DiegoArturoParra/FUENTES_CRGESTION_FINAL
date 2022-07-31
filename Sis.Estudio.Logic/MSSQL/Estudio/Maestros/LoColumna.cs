using Sis.Estudio.Data.MSSQL.Estudio;
using Sis.Estudio.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace Sis.Estudio.Logic.MSSQL.Estudio
{
    public class LoColumna
    {

        public List<EnTransaccion> Columna_INS(List<EnColumna> lstEnColumna)
        {
            string lcMensaje = "";
            string lcIdColumna = "";
            #region InicializoTransaccion
            string lcMensajeReturn = "";
            LoTransaccion loConexion = new LoTransaccion();
            bool llError = false;
            SqlTransaction loTransaccion = loConexion.IniTransaccion(ref llError, ref lcMensajeReturn);
            #endregion InicializoTransaccion
            try
            {
                if (llError == true)
                {
                    DaColumna objDaColumna = new DaColumna();
                    lcIdColumna = objDaColumna.mxColumna_INS(lstEnColumna, ref loTransaccion);
                    objDaColumna.mxColumnaTrabajo_InsertarColumna(lstEnColumna, ref loTransaccion);
                    loTransaccion.Commit();
                    lcMensaje = "exito";
                }
                else
                {
                    throw new ArgumentNullException("IniTransaccion", "Se presentaron errores al inicializar la operación");
                }
            }
            catch (SqlException ex)
            {
                loTransaccion.Rollback();
                throw ex;
            }
            catch (Exception ex)
            {
                loTransaccion.Rollback();
                throw ex;
            }
            finally
            {
                loTransaccion.Dispose();
            }
            return new List<EnTransaccion>
            {
                new EnTransaccion
                {
                    MENSAJE = lcMensaje,
                    ID = lcIdColumna
                }
            };
            //return msg;
        }
        public String mxColumna_UPD(List<EnColumna> ListEnProducto)
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
                    DaColumna loDaColumna = new DaColumna();
                    loDaColumna.mxColumna_UPD(ListEnProducto, tran);
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
        public DataTable mxColumnaTrabajo_Listar(List<EnColumna> plstEnColumna)
        {
            try
            {
                DaColumna loDaColumna = new DaColumna();
                return loDaColumna.mxColumnaTrabajo_Listar(plstEnColumna);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable TablaTrabajo_Listar(List<EnColumna> lstEnColumna)
        {
            try
            {
                DaColumna loDaColumna = new DaColumna();
                return loDaColumna.TablaTrabajo_Listar(lstEnColumna);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public DataTable mxColumnaTrabajo_ListarXRegistro(List<EnColumna> lstEnColumna)
        {
            try
            {
                DaColumna loDaColumna = new DaColumna();
                return loDaColumna.mxColumnaTrabajo_ListarXRegistro(lstEnColumna);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public List<EnColumna> mxColumnaTrabajo_LlenarDropDownList(List<EnColumna> lstEnColumna)
        {
            try
            {
                DaColumna loDaColumna = new DaColumna();
                return loDaColumna.mxColumnaTrabajo_LlenarDropDownList(lstEnColumna);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public string mxObtenerTipoDatoXColumna(List<EnColumna> lstEnColumna)
        {
            try
            {
                DaColumna loDaColumna = new DaColumna();
                return loDaColumna.mxObtenerTipoDatoXColumna(lstEnColumna);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public List<EnOperador> mxOperadores_ListaXTipoDato()
        {
            try
            {
                DaColumna loDaColumna = new DaColumna();
                return loDaColumna.mxOperadores_ListaXTipoDato();
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

    }
}
