using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Sis.Estudio.Data.MSSQL.Seguridad;
using Sis.Estudio.Entity;
using Sis.Estudio.Logic.MSSQL.Seguridad;
using Sis.Estudio.Logic;
//using Enumerador;
using Sis.Estudio.Entity;
namespace Sis.Estudio.Logic.MSSQL.Seguridad
{
        public class LoOpcion
        {
            #region Opcion
            #region Listado
            public DataTable Listado_Opcion(List<EnOpcion> ListEnOpcion)
            {
                
                DaOpcion objDaOpcion = new DaOpcion();
                return objDaOpcion.Listado_Opcion(ListEnOpcion);
            }
            public DataTable Listado_OpcionHijo(List<EnOpcion> ListEnOpcion)
            {
                DaOpcion objDaOpcion = new DaOpcion();
                return objDaOpcion.Listado_OpcionHijo(ListEnOpcion);
            }
            public DataTable Listado_OpcionAccion(List<EnOpcion> ListEnOpcion)
            {
                DaOpcion objDaOpcion = new DaOpcion();
                return objDaOpcion.Listado_OpcionAccion(ListEnOpcion);
            }
            #endregion Listado

            #region Menu
            public DataTable MostrarDatos_Opcion(List<EnOpcion> ListEnOpcion)
            {
                DaOpcion objDaOpcion = new DaOpcion();
                return objDaOpcion.MostrarDatos_Opcion(ListEnOpcion);
            }
            public String Insertar_OpcionMenu(List<EnOpcion> ListEnOpcion)
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
                        DaOpcion objDaOpcion = new DaOpcion();
                        objDaOpcion.Insertar_OpcionMenu(ListEnOpcion, tran);
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
            public String Modifica_OpcionMenu(List<EnOpcion> ListEnOpcion)
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
                        DaOpcion objDaOpcion = new DaOpcion();
                        objDaOpcion.Modifica_OpcionMenu(ListEnOpcion, tran);
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
            public String Elimina_OpcionMenu(List<EnOpcion> ListEnOpcion)
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
                        DaOpcion objDaOpcion = new DaOpcion();
                        objDaOpcion.Elimina_OpcionMenu(ListEnOpcion, tran);
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

            public String Menu_SubirNivel(List<EnOpcion> ListEnOpcion)
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
                        DaOpcion objDaOpcion = new DaOpcion();
                        objDaOpcion.Menu_SubirNivel(ListEnOpcion, tran);
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
            public String Menu_BajarNivel(List<EnOpcion> ListEnOpcion)
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
                        DaOpcion objDaOpcion = new DaOpcion();
                        objDaOpcion.Menu_BajarNivel(ListEnOpcion, tran);
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
            #endregion Menu

            #region Opcion
            public String Insertar_OpcionOpcion(List<EnOpcion> ListEnOpcion)
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
                        DaOpcion objDaOpcion = new DaOpcion();
                        objDaOpcion.Insertar_OpcionOpcion(ListEnOpcion, tran);
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
            public String Modifica_OpcionOpcion(List<EnOpcion> ListEnOpcion)
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
                        DaOpcion objDaOpcion = new DaOpcion();
                        objDaOpcion.Modifica_OpcionOpcion(ListEnOpcion, tran);
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
            public String Opcion_SubirNivel(List<EnOpcion> ListEnOpcion)
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
                        DaOpcion objDaOpcion = new DaOpcion();
                        objDaOpcion.Opcion_SubirNivel(ListEnOpcion, tran);
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
            public String Opcion_BajarNivel(List<EnOpcion> ListEnOpcion)
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
                        DaOpcion objDaOpcion = new DaOpcion();
                        objDaOpcion.Opcion_BajarNivel(ListEnOpcion, tran);
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
            #endregion Opcion

            #region OpcionAccion

            public String Insertar_OpcionAccion(List<EnOpcion> ListEnOpcion)
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
                        DaOpcion objDaOpcion = new DaOpcion();
                        objDaOpcion.Insertar_OpcionAccion(ListEnOpcion, tran);
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
            public String Elimina_OpcionAccion(List<EnOpcion> ListEnOpcion)
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
                        DaOpcion objDaOpcion = new DaOpcion();
                        objDaOpcion.Elimina_OpcionAccion(ListEnOpcion, tran);
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
            #endregion OpcionAccion

            #region Comun
            public DataTable Seguridad_CargaAccionesDeOpcion(List<EnOpcion> ListEnOpcion)
            {
                DaOpcion objDaOpcion = new DaOpcion();
                return objDaOpcion.Seguridad_CargaAccionesDeOpcion(ListEnOpcion);
            }
            #endregion Comun

            #region Reporte
            public DataTable Opcion_Reporte(List<EnOpcion> ListEnOpcion)
            {
                DaOpcion objDaOpcion = new DaOpcion();
                return objDaOpcion.Opcion_Reporte(ListEnOpcion);
            }
            #endregion Reporte
            #endregion Opcion
        }
}