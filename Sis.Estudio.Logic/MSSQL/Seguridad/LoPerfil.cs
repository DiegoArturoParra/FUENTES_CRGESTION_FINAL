using System;
using System.Diagnostics.CodeAnalysis;
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
    public class LoPerfil
    {
        #region Perfil

        public DataTable GetBuscar_Perfil(List<EnPerfil> ListEnPerfil)
        {
            DaPerfil objDaPerfil = new DaPerfil();           
            return objDaPerfil.Buscar_Perfil(ListEnPerfil);
        }
        public DataTable ComboFiltroModulos(EnPerfil objEnPerfil)
        {
            DaPerfil objDaPerfil = new DaPerfil();
            return objDaPerfil.ComboFiltroModulos(objEnPerfil);
        }

        public DataTable CargaDatosPerfil(string str_TIPO, List<EnPerfil> ListEnPerfil)
        {
            
            DaPerfil objDaPerfil = new DaPerfil();


            return objDaPerfil.CargaDatosPerfil(str_TIPO, ListEnPerfil);
        }
        public String Anula_Perfil(List<EnPerfil> ListEnPerfil)
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
                    
                    DaPerfil objDaPerfil = new DaPerfil();
                    objDaPerfil.Anula_Perfil(ListEnPerfil, tran); // ANULA
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
        public String Modifica_Perfil(List<EnPerfil> ListEnPerfil)
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
                    DaPerfil objDaPerfil = new DaPerfil();

                    objDaPerfil.Modifica_Perfil(ListEnPerfil, tran); // ANULA
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
        public List<EnTransaccion> Insertar_Perfil(List<EnPerfil> ListEnPerfil)
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
                    DaPerfil objDaPerfil = new DaPerfil();


                    str_id = objDaPerfil.Insertar_Perfil(ListEnPerfil, tran);
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

        public DataTable Carga_OpcionesParaArbol(List<EnPerfil> ListEnPerfil)
        {
            DaPerfil objDaPerfil = new DaPerfil();
            return objDaPerfil.Carga_OpcionesParaArbol(ListEnPerfil);
        }

        public DataTable Carga_AccionesParaArbol(List<EnPerfil> ListEnPerfil)
        {
            DaPerfil objDaPerfil = new DaPerfil();
            return objDaPerfil.Carga_AccionesParaArbol(ListEnPerfil);
        }

        public DataTable Carga_PerfilOpcionesParaArbol(List<EnPerfil> ListEnPerfil)
        {
            
            DaPerfil objDaPerfil = new DaPerfil();



            return objDaPerfil.Carga_PerfilOpcionesParaArbol(ListEnPerfil);
        }

        public DataTable Carga_PerfilAccionesParaArbol(List<EnPerfil> ListEnPerfil)
        {            
            DaPerfil objDaPerfil = new DaPerfil();
            return objDaPerfil.Carga_PerfilAccionesParaArbol(ListEnPerfil);
        }

        public void TransaccionPerfilOpcion(List<EnPerfil> ListEnPerfil , List<EnOpcion> ListEnOpcion , List<EnOpcionAccion> ListOpcionAccion)
        {
            //****************************************************************************************
            //* Nomre       : TransaccionUsuarioOpcion
            //* DescripcioN :
            //****************************************************************************************
            # region InicializoTransaccion
            string strMensaje = "";           
            LoTransaccion Transaccion = new LoTransaccion();

            bool bolError = false;
            SqlTransaction tran = Transaccion.IniTransaccion_Seg(ref bolError, ref strMensaje);
            String rollback = String.Empty;
            #endregion
            DaPerfil Data_Perfil = new DaPerfil();

            string msg = "";
            string Exito = "";
            try
            {
                if (bolError == true)
                {
                    // Primero eliminar todas las opciones del sistema y modulo para ese Usuario                                                           
                    Data_Perfil.EliminaPerfilOpcion(ListEnPerfil, tran);
                    string strIdOpcion;

                    // insertar todas las opciones del sistema  para ese Perfil
                    ////ArrayList arrInsertaOpciones = new ArrayList();
                    ////ArrayList arrInsertaAcciones = new ArrayList();
                    

                    ////for (int i = 0; i < arrOpcion.Count; i++)
                    ////{
                    ////    arrInsertaOpciones.Add(arrcab[0].ToString());   // idperfil
                    ////    arrInsertaOpciones.Add(arrcab[1].ToString());   // @CEMPRESA
                    ////    arrInsertaOpciones.Add(arrcab[2].ToString());   // @CODSISTEMA
                    ////    arrInsertaOpciones.Add(arrcab[3].ToString());   // @CODUSUARIOREGISTRA

                    ////    arrInsertaOpciones.Add(arrOpcion[i].ToString());
                    ////    Data_Perfil.InsertaPerfilOpcion(arrInsertaOpciones, tran);
                    ////    arrInsertaOpciones.Clear();
                    ////}

                    foreach (EnOpcion EO in ListEnOpcion)
                    {
                        strIdOpcion = EO.IdOpcion;
                        Data_Perfil.InsertaPerfilOpcion(ListEnPerfil,strIdOpcion, tran);                                        
                    }

                    //for (int e = 0; e < arrOpcion.Count; e++)
                    //{
                    //    string OPC_idopcion = arrOpcion[e].ToString().Trim();  // @IDOPCION

                    //    foreach (EnOpcionAccion item in ListOpcionAccion)
                    //    {
                    //        string ACC_idopcion = item.IdOpcion.ToString();
                    //        string ACC_idaccion = item.IdAccion.ToString();

                    //        if (OPC_idopcion == ACC_idopcion)
                    //        {
                    //            arrInsertaAcciones.Add(arrcab[0].ToString());   // idperfil
                    //            arrInsertaAcciones.Add(arrcab[1].ToString());   // @CEMPRESA
                    //            arrInsertaAcciones.Add(arrcab[2].ToString());   // @CODSISTEMA
                    //            arrInsertaAcciones.Add(arrcab[3].ToString());   // @CODUSUARIOREGISTRA

                    //            arrInsertaAcciones.Add(OPC_idopcion);    // @IDOPCION
                    //            arrInsertaAcciones.Add(ACC_idaccion);    // @IDACCION

                    //            Data_Perfil.InsertaPerfilAccion(arrInsertaAcciones, tran);
                    //            arrInsertaAcciones.Clear();
                    //        }
                    //    }
                    //}

                    foreach (EnOpcion EO in ListEnOpcion)
                    {
                        
                        string OPC_idopcion = EO.IdOpcion;  // @IDOPCION

                        foreach (EnOpcionAccion item in ListOpcionAccion)
                        {
                            string ACC_idopcion = item.IdOpcion.ToString();
                            string ACC_idaccion = item.IdAccion.ToString();

                            if (OPC_idopcion == ACC_idopcion)
                            {
                                Data_Perfil.InsertaPerfilAccion(ListEnPerfil,ACC_idopcion,ACC_idaccion, tran);                                
                            }
                        }
                    }
                    tran.Commit();
                    Exito = "si";
                }
            }
            catch (SqlException ex)
            {
                tran.Rollback();
                msg = Convert.ToString(ex.Message);
                Exito = "no";
                throw ex;
            }
            catch (Exception Exp)
            {
                tran.Rollback();
                throw Exp;
            }
            finally
            {
                tran.Dispose();
            }
            if (Exito == "si")
            {
                //DESPUES DE LA TRANSACCION
            }
        }
        #endregion Perfil

    }
}
