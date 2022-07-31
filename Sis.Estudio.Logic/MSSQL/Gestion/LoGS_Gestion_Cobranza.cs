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
    public class LoGS_Gestion_Cobranza
    {
        public DataTable GS_Gestion_Cobranza_Lista(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            try
            {
                DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                return objDaGS_Gestion_Cobranza.GS_Gestion_Cobranza_Lista(ListEnGS_Gestion_Cobranza);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public DataTable GS_Gestion_Cobranza_Lista_App(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            try
            {
                DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                return objDaGS_Gestion_Cobranza.GS_Gestion_Cobranza_Lista_App(ListEnGS_Gestion_Cobranza);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public Response GS_Gestion_Cobranza_Imagen(int id)
        {
            Response response = new Response();
            try
            {
                string imagen = new DaGS_Gestion_Cobranza().GS_Gestion_Cobranza_Imagen(id);
                if (!string.IsNullOrWhiteSpace(imagen))
                {
                    response.Data = imagen;
                    response.Mensaje = "encontrada";
                    response.StatusCode = System.Net.HttpStatusCode.OK;
                }
                else
                {
                    response.Mensaje = "No se encontro ninguna imagen.";
                    response.StatusCode = System.Net.HttpStatusCode.NotFound;
                }
            }
            catch (Exception ex)
            {
                response.Mensaje = ex.Message;
                response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
            }
            return response;
        }

        public DataTable GS_Gestion_Cobranza_Lista_Pendientes(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza, string lcFiltro)
        {
            try
            {
                DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                return objDaGS_Gestion_Cobranza.GS_Gestion_Cobranza_Lista_Pendientes(ListEnGS_Gestion_Cobranza, lcFiltro);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable GS_Gestion_Cobranza_Listar_Pendientes_Desactivacion(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza, string tipo)
        {
            try
            {
                DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                return objDaGS_Gestion_Cobranza.GS_Gestion_Cobranza_Listar_Pendientes_Desactivacion(ListEnGS_Gestion_Cobranza, tipo);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable GS_Gestion_Cobranza_Lista_Aprobaciones(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            try
            {
                DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                return objDaGS_Gestion_Cobranza.GS_Gestion_Cobranza_Lista_Aprobaciones(ListEnGS_Gestion_Cobranza);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable GS_Gestion_Cobranza_Lista_BandejaSalida(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            try
            {
                DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                return objDaGS_Gestion_Cobranza.GS_Gestion_Cobranza_Lista_BandejaSalida(ListEnGS_Gestion_Cobranza);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }


        public DataTable GS_Reasignacion_Bandeja_sp_Listar_CCI(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            try
            {
                DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                return objDaGS_Gestion_Cobranza.GS_Reasignacion_Bandeja_sp_Listar_CCI(ListEnGS_Gestion_Cobranza);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }



        public DataTable GS_Gestion_CarteraCobranza_Lista(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            try
            {
                DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                return objDaGS_Gestion_Cobranza.GS_Gestion_CarteraCobranza_Lista(ListEnGS_Gestion_Cobranza);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public String GS_Gestion_Cobranza_UPD_Estado(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
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
                    DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                    objDaGS_Gestion_Cobranza.GS_Gestion_Cobranza_UPD_Estado(ListEnGS_Gestion_Cobranza, tran);
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

        public DataTable GS_Gestion_Cobranza_Cliente_Lista(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            try
            {
                DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                return objDaGS_Gestion_Cobranza.GS_Gestion_Cobranza_Cliente_Lista(ListEnGS_Gestion_Cobranza);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable GS_Gestion_Cobranza_Cliente_x_Producto_Lista(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            try
            {
                DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                return objDaGS_Gestion_Cobranza.GS_Gestion_Cobranza_Cliente_x_Producto_Lista(ListEnGS_Gestion_Cobranza);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public List<EnTransaccion> GS_Gestion_Cobranza_INS(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
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
                    DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                    str_id = objDaGS_Gestion_Cobranza.GS_Gestion_Cobranza_INS(ListEnGS_Gestion_Cobranza, tran);
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

        //********************************************
        public String GS_Gestion_Cobranza_UPD(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
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
                    DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                    objDaGS_Gestion_Cobranza.GS_Gestion_Cobranza_UPD(ListEnGS_Gestion_Cobranza, tran);
                    tran.Commit();
                    msg = @"{'resp':'exito'}";
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

        public String GS_Gestion_Cobranza_UPD_Carta_Cobranza(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
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
                    DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                    objDaGS_Gestion_Cobranza.GS_Gestion_Cobranza_UPD_Carta_Cobranza(ListEnGS_Gestion_Cobranza, tran);
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

        //GS_GestionCobranza_ExportarResultados_Masivos
        public DataTable GS_GestionCobranza_ExportarResultados_Masivos(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            try
            {
                DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                return objDaGS_Gestion_Cobranza.GS_GestionCobranza_ExportarResultados_Masivos(ListEnGS_Gestion_Cobranza);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public String GS_Gestion_Cobranza_Reagendar_UPD(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
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
                    DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                    objDaGS_Gestion_Cobranza.GS_Gestion_Cobranza_Reagendar_UPD(ListEnGS_Gestion_Cobranza, tran);
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

        /*
         * Actualizar la fecha de reagendación
         */

        public String GS_Gestion_Cobranza_Reagendar_UPD_Fecha(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
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
                    DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                    objDaGS_Gestion_Cobranza.GS_Gestion_Cobranza_Reagendar_UPD_Fecha(ListEnGS_Gestion_Cobranza, tran);
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


        public DataTable GS_Gestion_Cobranza_Reg(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            try
            {
                DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                return objDaGS_Gestion_Cobranza.GS_Gestion_Cobranza_Reg(ListEnGS_Gestion_Cobranza);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable GS_Gestion_Cobranza_GestionesInternas_Registro(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            try
            {
                DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                return objDaGS_Gestion_Cobranza.GS_Gestion_Cobranza_GestionesInternas_Registro(ListEnGS_Gestion_Cobranza);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public List<EnTransaccion> GS_Gestion_Cobranza_SubTarea_INS(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
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
                    DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                    str_id = objDaGS_Gestion_Cobranza.GS_Gestion_Cobranza_SubTarea_INS(ListEnGS_Gestion_Cobranza, tran);
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


        public List<EnTransaccion> GS_Gestion_Cobranza_SubTarea_INS_JEFE(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
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
                    DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                    str_id = objDaGS_Gestion_Cobranza.GS_Gestion_Cobranza_SubTarea_INS_JEFE(ListEnGS_Gestion_Cobranza, tran);
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


        public DataTable GS_Gestion_Cobranza_SubTarea_Gestion_ClasexEjecutado_Lista(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            try
            {
                DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                return objDaGS_Gestion_Cobranza.GS_Gestion_Cobranza_SubTarea_Gestion_ClasexEjecutado_Lista(ListEnGS_Gestion_Cobranza);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }


        public DataTable GS_Gestion_Cobranza_SubTarea_Gestion_ClasexTipoGestion_Lista(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            try
            {
                DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                return objDaGS_Gestion_Cobranza.GS_Gestion_Cobranza_SubTarea_Gestion_ClasexTipoGestion_Lista(ListEnGS_Gestion_Cobranza);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }


        public DataTable GS_Gestion_Cobranza_SubTarea_Gestion_ClasexTipoGestion_Lista_Todos()
        {
            try
            {
                DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                return objDaGS_Gestion_Cobranza.GS_Gestion_Cobranza_SubTarea_Gestion_ClasexTipoGestion_Lista_Todos();
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }



        #region campaña
        public List<EnTransaccion> GS_Campaña_SubTarea_INS(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
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
                    DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                    str_id = objDaGS_Gestion_Cobranza.GS_Campaña_SubTarea_INS(ListEnGS_Gestion_Cobranza, tran);
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
        public DataTable GS_Gestion_Cobranza_x_Campaña_Lista(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            try
            {
                DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                return objDaGS_Gestion_Cobranza.GS_Gestion_Cobranza_x_Campaña_Lista(ListEnGS_Gestion_Cobranza);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        #endregion campaña

        #region visitas
        public DataSet GS_Gestion_Cobranza_x_Visitas_Lista(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza, string pcFiltro)
        {
            try
            {
                DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                return objDaGS_Gestion_Cobranza.GS_Gestion_Cobranza_x_Visitas_Lista(ListEnGS_Gestion_Cobranza, pcFiltro);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public String GS_Gestion_Cobranza_x_Visitas_UPD(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
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
                    DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                    objDaGS_Gestion_Cobranza.GS_Gestion_Cobranza_x_Visitas_UPD(ListEnGS_Gestion_Cobranza, tran);
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

        public DataTable GS_Visitas_DesCargaMasiva(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            try
            {
                DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                return objDaGS_Gestion_Cobranza.GS_Visitas_DesCargaMasiva(ListEnGS_Gestion_Cobranza);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataSet GS_Visitas_Calendario_DS(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            DataSet ds;
            try
            {
                DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                ds = objDaGS_Gestion_Cobranza.GS_Visitas_Calendario_DS(ListEnGS_Gestion_Cobranza);
                return ds;
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        #endregion visitas

        #region clientes
        public DataTable GS_Clientes_x_DireccionLista(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            try
            {
                DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                return objDaGS_Gestion_Cobranza.GS_Clientes_x_DireccionLista(ListEnGS_Gestion_Cobranza);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        #endregion clientes

        #region carta


        public DataTable GS_Gestion_Cobranza_Carta_Reg(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            try
            {
                DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                return objDaGS_Gestion_Cobranza.GS_Gestion_Cobranza_Carta_Reg(ListEnGS_Gestion_Cobranza);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }


        #endregion carta



        public DataTable GS_Gestion_Cobranza_ExportarTercero(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            try
            {
                DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                return objDaGS_Gestion_Cobranza.GS_Gestion_Cobranza_ExportarTercero(ListEnGS_Gestion_Cobranza);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable GS_Gestion_Cobranza_ExportarActionPlan(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            try
            {
                DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                return objDaGS_Gestion_Cobranza.GS_Gestion_Cobranza_ExportarActionPlan(ListEnGS_Gestion_Cobranza);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }


        public DataTable GS_Gestion_Cobranza_Asesores_Lista(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            try
            {
                DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                return objDaGS_Gestion_Cobranza.GS_Gestion_Cobranza_Asesores_Lista(ListEnGS_Gestion_Cobranza);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public DataTable GS_Gestion_Cobranza_Asesores_x_Administrador_Lista(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            try
            {
                DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                return objDaGS_Gestion_Cobranza.GS_Gestion_Cobranza_Asesores_x_Administrador_Lista(ListEnGS_Gestion_Cobranza);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable GS_Gestion_Cobranza_UsuarioRol_Lista(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            try
            {
                DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                return objDaGS_Gestion_Cobranza.GS_Gestion_Cobranza_UsuarioRol_Lista(ListEnGS_Gestion_Cobranza);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable GS_Gestion_Cobranza_Cliente_x_Asesor_Lista(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            try
            {
                DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                return objDaGS_Gestion_Cobranza.GS_Gestion_Cobranza_Cliente_x_Asesor_Lista(ListEnGS_Gestion_Cobranza);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public String GS_Gestion_Cobranza_UPD_Asesor(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
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
                    DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                    objDaGS_Gestion_Cobranza.GS_Gestion_Cobranza_UPD_Asesor(ListEnGS_Gestion_Cobranza, tran);
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

        public DataTable GS_Estado_Gestion_Cobranza_Combo()
        {
            try
            {
                DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                return objDaGS_Gestion_Cobranza.GS_Estado_Gestion_Cobranza_Combo();
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable GS_Gestion_Cobranza_ComboCartas(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            try
            {
                DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                return objDaGS_Gestion_Cobranza.GS_Gestion_Cobranza_ComboCartas(ListEnGS_Gestion_Cobranza);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }


        public DataTable GS_Gestion_Cobranza_IVR_Reg(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            try
            {
                DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                return objDaGS_Gestion_Cobranza.GS_Gestion_Cobranza_IVR_Reg(ListEnGS_Gestion_Cobranza);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable GS_Gestion_Cobranza_SMS_Reg(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            try
            {
                DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                return objDaGS_Gestion_Cobranza.GS_Gestion_Cobranza_SMS_Reg(ListEnGS_Gestion_Cobranza);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }


        public DataTable mxCambiarEstadoActionPlansXTipoGestion(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            try
            {
                DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                return objDaGS_Gestion_Cobranza.mxCambiarEstadoActionPlansXTipoGestion(ListEnGS_Gestion_Cobranza);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public DataTable GS_Gestion_Cobranza_Correo_Reg(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            try
            {
                DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                return objDaGS_Gestion_Cobranza.GS_Gestion_Cobranza_Correo_Reg(ListEnGS_Gestion_Cobranza);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable GS_Gestion_Cobranza_Whatsapp_Reg(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            try
            {
                DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                return objDaGS_Gestion_Cobranza.GS_Gestion_Cobranza_Whatsapp_Reg(ListEnGS_Gestion_Cobranza);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }









        public String GS_Gestion_Cobranza_Aprobar_Jefe(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
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
                    DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                    objDaGS_Gestion_Cobranza.GS_Gestion_Cobranza_Aprobar_Jefe(ListEnGS_Gestion_Cobranza, tran);
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

        public String GS_Gestion_Cobranza_Rechazar_Jefe(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
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
                    DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                    objDaGS_Gestion_Cobranza.GS_Gestion_Cobranza_Rechazar_Jefe(ListEnGS_Gestion_Cobranza, tran);
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


        public String GS_Gestion_Cobranza_Bandeja_Salida(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
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
                    DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                    objDaGS_Gestion_Cobranza.GS_Gestion_Cobranza_Bandeja_Salida(ListEnGS_Gestion_Cobranza, tran);
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

        public String GS_Gestion_Cobranza_Reasignacion_CCI(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
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
                    DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                    objDaGS_Gestion_Cobranza.GS_Gestion_Cobranza_Reasignacion_CCI(ListEnGS_Gestion_Cobranza, tran);
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





        public DataTable GS_Gestion_Cobranza_Carga_ClienteGC_Lista(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            try
            {
                DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                return objDaGS_Gestion_Cobranza.GS_Gestion_Cobranza_Carga_ClienteGC_Lista(ListEnGS_Gestion_Cobranza);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }



        public DataTable GS_Agente_Combo(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            try
            {
                DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                return objDaGS_Gestion_Cobranza.GS_Agente_Combo(ListEnGS_Gestion_Cobranza);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable RPT_CRProductividad_Gestiones(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            try
            {
                DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                return objDaGS_Gestion_Cobranza.RPT_CRProductividad_Gestiones(ListEnGS_Gestion_Cobranza);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataSet mxObtenerResultadoReporteProductividad(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            try
            {
                DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                return objDaGS_Gestion_Cobranza.mxObtenerResultadoReporteProductividad(ListEnGS_Gestion_Cobranza);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public DataTable RPT_CRProductividad_Grupos(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            try
            {
                DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                return objDaGS_Gestion_Cobranza.RPT_CRProductividad_Grupos(ListEnGS_Gestion_Cobranza);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable RPT_CRProductividad_TipoGestionesXGrupo(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            try
            {
                DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                return objDaGS_Gestion_Cobranza.RPT_CRProductividad_TipoGestionesXGrupo(ListEnGS_Gestion_Cobranza);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable RPT_CRProductividad_EjecutadoXTipoGestion(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            try
            {
                DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                return objDaGS_Gestion_Cobranza.RPT_CRProductividad_EjecutadoXTipoGestion(ListEnGS_Gestion_Cobranza);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable RPT_CRProductividad_ClaseGestionesXEjecutado(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            try
            {
                DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                return objDaGS_Gestion_Cobranza.RPT_CRProductividad_ClaseGestionesXEjecutado(ListEnGS_Gestion_Cobranza);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable RPT_CRProductividad_UsuariosXJerarquia(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            try
            {
                DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                return objDaGS_Gestion_Cobranza.RPT_CRProductividad_UsuariosXJerarquia(ListEnGS_Gestion_Cobranza);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable GS_Cantidad_TipoGestionesXGrupo(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            try
            {
                DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                return objDaGS_Gestion_Cobranza.GS_Cantidad_TipoGestionesXGrupo(ListEnGS_Gestion_Cobranza);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable GS_Cantidad_EjecutadosXTipoGestion(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            try
            {
                DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                return objDaGS_Gestion_Cobranza.GS_Cantidad_EjecutadosXTipoGestion(ListEnGS_Gestion_Cobranza);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable GS_Cantidad_ClasificacionesXEjecutado(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            try
            {
                DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                return objDaGS_Gestion_Cobranza.GS_Cantidad_ClasificacionesXEjecutado(ListEnGS_Gestion_Cobranza);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }


        /*
         * Consulta a la base de datos para determinar si un AP ha llegado al último día de su tramo.
         * El SP GS_ReglasGestiones_Consultar_DiaFinal devuelve la variable flag con valor 0 o diferente de 0.
         * Si es diferente de 0 ha llegado al final del tramo y deben activarse los botones de grabar y
         * proponer en el detalle del AP
         */
        public DataTable GS_ReglasGestiones_Consultar_DiaFinal(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            try
            {
                DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                return objDaGS_Gestion_Cobranza.GS_ReglasGestiones_Consultar_DiaFinal(ListEnGS_Gestion_Cobranza);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable GS_Gestion_Cobranza_Tramo_Acelerar_Listar(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            try
            {
                DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                return objDaGS_Gestion_Cobranza.GS_Gestion_Cobranza_Tramo_Acelerar_Listar(ListEnGS_Gestion_Cobranza);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public DataTable GS_Gestion_Cobranza_sp_Modificar_TramoAcelerado(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            try
            {
                DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                return objDaGS_Gestion_Cobranza.GS_Gestion_Cobranza_sp_Modificar_TramoAcelerado(ListEnGS_Gestion_Cobranza);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable GS_ClientePRODCronograma_sp_Modificar_FechaVencimientoReal(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            try
            {
                DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                return objDaGS_Gestion_Cobranza.GS_ClientePRODCronograma_sp_Modificar_FechaVencimientoReal(ListEnGS_Gestion_Cobranza);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable GS_Gestion_Cobranza_Ejecutores_Listar(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            try
            {
                DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                return objDaGS_Gestion_Cobranza.GS_Gestion_Cobranza_Ejecutores_Listar(ListEnGS_Gestion_Cobranza);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable GS_Gestion_Cobranza_GestionesInternas_TomarControl(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            try
            {
                DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                return objDaGS_Gestion_Cobranza.GS_Gestion_Cobranza_GestionesInternas_TomarControl(ListEnGS_Gestion_Cobranza);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable GS_TipoGestiones_ValidarTipoVisita(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            try
            {
                DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                return objDaGS_Gestion_Cobranza.GS_TipoGestiones_ValidarTipoVisita(ListEnGS_Gestion_Cobranza);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable GS_ReglasGestiones_Consultar_DiasRestantesCierreTramo(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            try
            {
                DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                return objDaGS_Gestion_Cobranza.GS_ReglasGestiones_Consultar_DiasRestantesCierreTramo(ListEnGS_Gestion_Cobranza);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable mxListarReagendados(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            try
            {
                DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                return objDaGS_Gestion_Cobranza.mxListarReagendados(ListEnGS_Gestion_Cobranza);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public DataTable mxListarReagendados_Futuras(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            try
            {
                DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                return objDaGS_Gestion_Cobranza.mxListarReagendados_Futuras(ListEnGS_Gestion_Cobranza);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public DataTable mxTraerRutaDescarga(string cValor)
        {
            try
            {
                DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                return objDaGS_Gestion_Cobranza.mxTraerRutaDescarga(cValor);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public List<EnTransaccion> GS_Gestion_Cobranza_INS_Imagen(EnGS_Gestion_Cobranza ListEnGS_Gestion_Cobranza, byte[] oImagen)
        {
            string msg = "";
            string str_id = "";
            # region InicializoTransaccion
            string strMensaje = "";
            LoTransaccion Transaccion = new LoTransaccion();
            bool bolError = false;
            SqlTransaction tran = Transaccion.IniTransaccion_Cuar(ref bolError, ref strMensaje);
            String rollback = String.Empty;
            #endregion
            try
            {
                if (bolError == true)
                {
                    DaGS_Gestion_Cobranza objDaGS_Gestion_Cobranza = new DaGS_Gestion_Cobranza();
                    str_id = objDaGS_Gestion_Cobranza.GS_Gestion_Cobranza_INS_Imagen(ListEnGS_Gestion_Cobranza, oImagen, tran);
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
