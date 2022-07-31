using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Sis.Estudio.Entity;
using Sis.Estudio.Data;


namespace Sis.Estudio.Data.MSSQL.Seguridad
{
    public class DaOpcion : DaConexion
    {
        
        #region Listado
        public DataTable Listado_Opcion(List<EnOpcion> ListEnOpcion)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString2);
                sqlCommand = "SEG_Opcion_sp_Matenimiento";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[4];

                paramsToStore[0] = new SqlParameter("@Accion", SqlDbType.Int);
                paramsToStore[0].Value = 1;// Listado con

                paramsToStore[1] = new SqlParameter("@CEmpresa", SqlDbType.Char);
                paramsToStore[1].Value = ListEnOpcion[0].CEmpresa;
                paramsToStore[1].Size = 2;

                paramsToStore[2] = new SqlParameter("@IdModulo", SqlDbType.Int);
                paramsToStore[2].Value = ListEnOpcion[0].IdModulo;

                paramsToStore[3] = new SqlParameter("@TipoOpcion", SqlDbType.Int);
                paramsToStore[3].Value = ListEnOpcion[0].TipoOpcion;

                adp.SelectCommand.Parameters.AddRange(paramsToStore);

                adp.Fill(DS, "DataTable1");
                dt = DS.Tables["DataTable1"];
                Conn.Close();
                return dt;
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public DataTable Listado_OpcionHijo(List<EnOpcion> ListEnOpcion)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString2);
                sqlCommand = "SEG_Opcion_sp_Matenimiento";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[5];

                paramsToStore[0] = new SqlParameter("@Accion", SqlDbType.Int);
                paramsToStore[0].Value = 2;// Lista Menu Hijo

                paramsToStore[1] = new SqlParameter("@CEmpresa", SqlDbType.Char);
                paramsToStore[1].Value = ListEnOpcion[0].CEmpresa;
                paramsToStore[1].Size = 2;

                paramsToStore[2] = new SqlParameter("@IdModulo", SqlDbType.Int);
                paramsToStore[2].Value = ListEnOpcion[0].IdModulo;

                paramsToStore[3] = new SqlParameter("@TipoOpcion", SqlDbType.Int);
                paramsToStore[3].Value = ListEnOpcion[0].TipoOpcion;

                paramsToStore[4] = new SqlParameter("@IdOpcionPadre", SqlDbType.Int);
                paramsToStore[4].Value = ListEnOpcion[0].IdOpcionPadre;

                adp.SelectCommand.Parameters.AddRange(paramsToStore);

                adp.Fill(DS, "DataTable1");
                dt = DS.Tables["DataTable1"];
                Conn.Close();
                return dt;
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public DataTable Listado_OpcionAccion(List<EnOpcion> ListEnOpcion)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString2);
                sqlCommand = "SEG_Opcion_sp_Matenimiento";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[4];

                paramsToStore[0] = new SqlParameter("@Accion", SqlDbType.Int);
                paramsToStore[0].Value = 3;// Lista Opcion Accion

                paramsToStore[1] = new SqlParameter("@CEmpresa", SqlDbType.Char);
                paramsToStore[1].Value = ListEnOpcion[0].CEmpresa;
                paramsToStore[1].Size = 2;

                paramsToStore[2] = new SqlParameter("@IdModulo", SqlDbType.Int);
                paramsToStore[2].Value = Convert.ToInt32(ListEnOpcion[0].IdModulo);

                paramsToStore[3] = new SqlParameter("@IdOpcion", SqlDbType.Int);
                paramsToStore[3].Value = Convert.ToInt32(ListEnOpcion[0].IdOpcion);

                adp.SelectCommand.Parameters.AddRange(paramsToStore);

                adp.Fill(DS, "DataTable1");
                dt = DS.Tables["DataTable1"];
                Conn.Close();
                return dt;
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        
        #endregion Listado

        #region Menu
        public DataTable MostrarDatos_Opcion(List<EnOpcion> ListEnOpcion)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString2);
                sqlCommand = "SEG_Opcion_sp_Matenimiento";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[3];

                paramsToStore[0] = new SqlParameter("@Accion", SqlDbType.Int);
                paramsToStore[0].Value = 4;// Mostrar Datos

                paramsToStore[1] = new SqlParameter("@CEmpresa", SqlDbType.Char);
                paramsToStore[1].Value = ListEnOpcion[0].CEmpresa;
                paramsToStore[1].Size = 2;

                paramsToStore[2] = new SqlParameter("@IdOpcion", SqlDbType.Int);
                paramsToStore[2].Value = Convert.ToInt32(ListEnOpcion[0].IdOpcion);

                adp.SelectCommand.Parameters.AddRange(paramsToStore);

                adp.Fill(DS, "DataTable1");
                dt = DS.Tables["DataTable1"];
                Conn.Close();
                return dt;
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public void Insertar_OpcionMenu(List<EnOpcion> ListEnOpcion, SqlTransaction tran)
        {

            SqlParameter prm_IdModulo = new SqlParameter();
            SqlParameter prm_CEmpresa = new SqlParameter();
            SqlParameter prm_Nombre = new SqlParameter();
            SqlParameter prm_Descripcion = new SqlParameter();
            SqlParameter prm_CodUsuReg = new SqlParameter();
            try
            {
                prm_IdModulo.ParameterName = "@IdModulo";
                prm_IdModulo.SqlDbType = SqlDbType.Int;
                prm_IdModulo.Direction = ParameterDirection.Input;
                prm_IdModulo.Value = Convert.ToInt32(ListEnOpcion[0].IdModulo);

                prm_CEmpresa.ParameterName = "@CEMPRESA";
                prm_CEmpresa.SqlDbType = SqlDbType.Char;
                prm_CEmpresa.Direction = ParameterDirection.Input;
                prm_CEmpresa.Size = 2;
                prm_CEmpresa.Value = ListEnOpcion[0].CEmpresa;

                prm_Nombre.ParameterName = "@Nombre";
                prm_Nombre.SqlDbType = SqlDbType.VarChar;
                prm_Nombre.Direction = ParameterDirection.Input;
                prm_Nombre.Size = 50;
                prm_Nombre.Value = ListEnOpcion[0].Nombre;

                prm_Descripcion.ParameterName = "@Descripcion";
                prm_Descripcion.SqlDbType = SqlDbType.VarChar;
                prm_Descripcion.Direction = ParameterDirection.Input;
                prm_Descripcion.Size = 100;
                prm_Descripcion.Value = ListEnOpcion[0].Descripcion;

                prm_CodUsuReg.ParameterName = "@CodUsuReg";
                prm_CodUsuReg.SqlDbType = SqlDbType.VarChar;
                prm_CodUsuReg.Direction = ParameterDirection.Input;
                prm_CodUsuReg.Size = 12;
                prm_CodUsuReg.Value = ListEnOpcion[0].CodUsuario;

                SqlHelper.ExecuteNonQuery(tran, "SEG_Opcion_sp_MatenimientoInsertaMenu",
                                                prm_IdModulo,
                                                prm_CEmpresa,
                                                prm_Nombre,
                                                prm_Descripcion,
                                                prm_CodUsuReg
                                             );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Modifica_OpcionMenu(List<EnOpcion> ListEnOpcion, SqlTransaction tran)
        {

            SqlParameter prm_IdModulo = new SqlParameter();
            SqlParameter prm_CEmpresa = new SqlParameter();
            SqlParameter prm_Nombre = new SqlParameter();
            SqlParameter prm_Descripcion = new SqlParameter();
            SqlParameter prm_CodUsuReg = new SqlParameter();
            SqlParameter prm_IdOpcion = new SqlParameter();

            try
            {

                prm_IdModulo.ParameterName = "@IdModulo";
                prm_IdModulo.SqlDbType = SqlDbType.Int;
                prm_IdModulo.Direction = ParameterDirection.Input;
                prm_IdModulo.Value = Convert.ToInt32(ListEnOpcion[0].IdModulo);

                prm_CEmpresa.ParameterName = "@CEMPRESA";
                prm_CEmpresa.SqlDbType = SqlDbType.Char;
                prm_CEmpresa.Direction = ParameterDirection.Input;
                prm_CEmpresa.Size = 2;
                prm_CEmpresa.Value = ListEnOpcion[0].CEmpresa;

                prm_Nombre.ParameterName = "@Nombre";
                prm_Nombre.SqlDbType = SqlDbType.VarChar;
                prm_Nombre.Direction = ParameterDirection.Input;
                prm_Nombre.Size = 50;
                prm_Nombre.Value = ListEnOpcion[0].Nombre;

                prm_Descripcion.ParameterName = "@Descripcion";
                prm_Descripcion.SqlDbType = SqlDbType.VarChar;
                prm_Descripcion.Direction = ParameterDirection.Input;
                prm_Descripcion.Size = 100;
                prm_Descripcion.Value = ListEnOpcion[0].Descripcion;

                prm_CodUsuReg.ParameterName = "@CodUsuReg";
                prm_CodUsuReg.SqlDbType = SqlDbType.VarChar;
                prm_CodUsuReg.Direction = ParameterDirection.Input;
                prm_CodUsuReg.Size = 12;
                prm_CodUsuReg.Value = ListEnOpcion[0].CodUsuario;


                prm_IdOpcion.ParameterName = "@IdOpcion";
                prm_IdOpcion.SqlDbType = SqlDbType.Int;
                prm_IdOpcion.Direction = ParameterDirection.Input;
                prm_IdOpcion.Value = Convert.ToInt32(ListEnOpcion[0].IdOpcion);

                SqlHelper.ExecuteNonQuery(tran, "SEG_Opcion_sp_MatenimientoModificaMenu",
                                                prm_IdModulo,
                                                prm_CEmpresa,
                                                prm_Nombre,
                                                prm_Descripcion,
                                                prm_CodUsuReg,
                                                prm_IdOpcion
                                             );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Elimina_OpcionMenu(List<EnOpcion> ListEnOpcion, SqlTransaction tran)
        {
            SqlParameter prm_IdModulo = new SqlParameter();
            SqlParameter prm_CEmpresa = new SqlParameter();
            SqlParameter prm_IdOpcion = new SqlParameter();

            try
            {
                prm_IdModulo.ParameterName = "@IdModulo";
                prm_IdModulo.SqlDbType = SqlDbType.Int;
                prm_IdModulo.Direction = ParameterDirection.Input;
                prm_IdModulo.Value = Convert.ToInt32(ListEnOpcion[0].IdModulo);

                prm_CEmpresa.ParameterName = "@CEMPRESA";
                prm_CEmpresa.SqlDbType = SqlDbType.Char;
                prm_CEmpresa.Direction = ParameterDirection.Input;
                prm_CEmpresa.Size = 2;
                prm_CEmpresa.Value = ListEnOpcion[0].CEmpresa;

                prm_IdOpcion.ParameterName = "@IdOpcion";
                prm_IdOpcion.SqlDbType = SqlDbType.Int;
                prm_IdOpcion.Direction = ParameterDirection.Input;
                prm_IdOpcion.Value = Convert.ToInt32(ListEnOpcion[0].IdOpcion);

                SqlHelper.ExecuteNonQuery(tran, "SEG_Opcion_sp_MatenimientoEliminaMenu",
                                                prm_IdModulo,
                                                prm_CEmpresa,
                                                prm_IdOpcion
                                             );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Menu_SubirNivel(List<EnOpcion> ListEnOpcion, SqlTransaction tran)
        {
            SqlParameter prm_IdModulo = new SqlParameter();
            SqlParameter prm_IdOpcion = new SqlParameter();
            try
            {
                prm_IdModulo.ParameterName = "@IdModulo";
                prm_IdModulo.SqlDbType = SqlDbType.Int;
                prm_IdModulo.Direction = ParameterDirection.Input;
                prm_IdModulo.Value = ListEnOpcion[0].IdModulo;

                prm_IdOpcion.ParameterName = "@IdOpcion";
                prm_IdOpcion.SqlDbType = SqlDbType.Int;
                prm_IdOpcion.Direction = ParameterDirection.Input;
                prm_IdOpcion.Value = Convert.ToInt32(ListEnOpcion[0].IdOpcion);

                SqlHelper.ExecuteNonQuery(tran, "SEG_Opcion_sp_NivelMenuSubir",
                                                prm_IdModulo,
                                                prm_IdOpcion
                                             );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Menu_BajarNivel(List<EnOpcion> ListEnOpcion, SqlTransaction tran)
        {

            SqlParameter prm_IdModulo = new SqlParameter();
            SqlParameter prm_IdOpcion = new SqlParameter();
            try
            {
                prm_IdModulo.ParameterName = "@IdModulo";
                prm_IdModulo.SqlDbType = SqlDbType.Int;
                prm_IdModulo.Direction = ParameterDirection.Input;
                prm_IdModulo.Value = ListEnOpcion[0].IdModulo;

                prm_IdOpcion.ParameterName = "@IdOpcion";
                prm_IdOpcion.SqlDbType = SqlDbType.Int;
                prm_IdOpcion.Direction = ParameterDirection.Input;
                prm_IdOpcion.Value = Convert.ToInt32(ListEnOpcion[0].IdOpcion);

                SqlHelper.ExecuteNonQuery(tran, "SEG_Opcion_sp_NivelMenuBajar",
                                                prm_IdModulo,
                                                prm_IdOpcion
                                             );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 

        #endregion Menu

        #region Opcion
        public void Insertar_OpcionOpcion(List<EnOpcion> ListEnOpcion, SqlTransaction tran)
        {
            SqlParameter prm_IdModulo = new SqlParameter();
            SqlParameter prm_CEmpresa = new SqlParameter();
            SqlParameter prm_Nombre = new SqlParameter();
            SqlParameter prm_Descripcion = new SqlParameter();
            SqlParameter prm_CodUsuReg = new SqlParameter();
            SqlParameter prm_IdOpcionPadre = new SqlParameter();
            SqlParameter prm_TopListado = new SqlParameter();

            try
            {
                prm_IdModulo.ParameterName = "@IdModulo";
                prm_IdModulo.SqlDbType = SqlDbType.Int;
                prm_IdModulo.Direction = ParameterDirection.Input;
                prm_IdModulo.Value = ListEnOpcion[0].IdModulo;

                prm_CEmpresa.ParameterName = "@CEMPRESA";
                prm_CEmpresa.SqlDbType = SqlDbType.Char;
                prm_CEmpresa.Direction = ParameterDirection.Input;
                prm_CEmpresa.Size = 2;
                prm_CEmpresa.Value = ListEnOpcion[0].CEmpresa;

                prm_Nombre.ParameterName = "@Nombre";
                prm_Nombre.SqlDbType = SqlDbType.VarChar;
                prm_Nombre.Direction = ParameterDirection.Input;
                prm_Nombre.Size = 50;
                prm_Nombre.Value = ListEnOpcion[0].Nombre;

                prm_Descripcion.ParameterName = "@url";
                prm_Descripcion.SqlDbType = SqlDbType.VarChar;
                prm_Descripcion.Direction = ParameterDirection.Input;
                prm_Descripcion.Size = 400;
                prm_Descripcion.Value = ListEnOpcion[0].url;

                prm_CodUsuReg.ParameterName = "@CodUsuReg";
                prm_CodUsuReg.SqlDbType = SqlDbType.VarChar;
                prm_CodUsuReg.Direction = ParameterDirection.Input;
                prm_CodUsuReg.Size = 12;
                prm_CodUsuReg.Value = ListEnOpcion[0].CodUsuario;

                prm_IdOpcionPadre.ParameterName = "@IdOpcionPadre";
                prm_IdOpcionPadre.SqlDbType = SqlDbType.Int;
                prm_IdOpcionPadre.Direction = ParameterDirection.Input;
                prm_IdOpcionPadre.Value = Convert.ToInt32(ListEnOpcion[0].IdOpcionPadre);


                prm_TopListado.ParameterName = "@TopListado";
                prm_TopListado.SqlDbType = SqlDbType.Int;
                prm_TopListado.Direction = ParameterDirection.Input;
                prm_TopListado.Value = Convert.ToInt32(ListEnOpcion[0].TopListado);


                SqlHelper.ExecuteNonQuery(tran, "SEG_Opcion_sp_MatenimientoInsertaOpcion",
                                                prm_IdModulo,
                                                prm_CEmpresa,
                                                prm_Nombre,
                                                prm_Descripcion,
                                                prm_CodUsuReg,
                                                prm_IdOpcionPadre,
                                                prm_TopListado
                                             );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Modifica_OpcionOpcion(List<EnOpcion> ListEnOpcion, SqlTransaction tran)
        {

            SqlParameter prm_IdModulo = new SqlParameter();
            SqlParameter prm_CEmpresa = new SqlParameter();
            SqlParameter prm_Nombre = new SqlParameter();
            SqlParameter prm_Descripcion = new SqlParameter();
            SqlParameter prm_CodUsuReg = new SqlParameter();
            SqlParameter prm_IdOpcion = new SqlParameter();
            SqlParameter prm_TopListado = new SqlParameter();

            try
            {
                prm_IdModulo.ParameterName = "@IdModulo";
                prm_IdModulo.SqlDbType = SqlDbType.Int;
                prm_IdModulo.Direction = ParameterDirection.Input;
                prm_IdModulo.Value = ListEnOpcion[0].IdModulo;

                prm_CEmpresa.ParameterName = "@CEMPRESA";
                prm_CEmpresa.SqlDbType = SqlDbType.Char;
                prm_CEmpresa.Direction = ParameterDirection.Input;
                prm_CEmpresa.Size = 2;
                prm_CEmpresa.Value = ListEnOpcion[0].CEmpresa;

                prm_Nombre.ParameterName = "@Nombre";
                prm_Nombre.SqlDbType = SqlDbType.VarChar;
                prm_Nombre.Direction = ParameterDirection.Input;
                prm_Nombre.Size = 50;
                prm_Nombre.Value = ListEnOpcion[0].Nombre;

                prm_Descripcion.ParameterName = "@url";
                prm_Descripcion.SqlDbType = SqlDbType.VarChar;
                prm_Descripcion.Direction = ParameterDirection.Input;
                prm_Descripcion.Size = 400;
                prm_Descripcion.Value = ListEnOpcion[0].url;

                prm_CodUsuReg.ParameterName = "@CodUsuReg";
                prm_CodUsuReg.SqlDbType = SqlDbType.VarChar;
                prm_CodUsuReg.Direction = ParameterDirection.Input;
                prm_CodUsuReg.Size = 12;
                prm_CodUsuReg.Value = ListEnOpcion[0].CodUsuario;


                prm_IdOpcion.ParameterName = "@IdOpcion";
                prm_IdOpcion.SqlDbType = SqlDbType.Int;
                prm_IdOpcion.Direction = ParameterDirection.Input;
                prm_IdOpcion.Value = Convert.ToInt32(ListEnOpcion[0].IdOpcion);


                prm_TopListado.ParameterName = "@TopListado";
                prm_TopListado.SqlDbType = SqlDbType.Int;
                prm_TopListado.Direction = ParameterDirection.Input;
                prm_TopListado.Value = Convert.ToInt32(ListEnOpcion[0].TopListado);

                SqlHelper.ExecuteNonQuery(tran, "SEG_Opcion_sp_MatenimientoModificaOpcion",
                                                prm_IdModulo,
                                                prm_CEmpresa,
                                                prm_Nombre,
                                                prm_Descripcion,
                                                prm_CodUsuReg,
                                                prm_IdOpcion,
                                                prm_TopListado
                                             );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Opcion_SubirNivel(List<EnOpcion> ListEnOpcion, SqlTransaction tran)
        {
            SqlParameter prm_IdModulo = new SqlParameter();
            SqlParameter prm_IdOpcion = new SqlParameter();           
            try
            {
                prm_IdModulo.ParameterName = "@IdModulo";
                prm_IdModulo.SqlDbType = SqlDbType.Int;
                prm_IdModulo.Direction = ParameterDirection.Input;
                prm_IdModulo.Value = ListEnOpcion[0].IdModulo;

                prm_IdOpcion.ParameterName = "@IdOpcion";
                prm_IdOpcion.SqlDbType = SqlDbType.Int;
                prm_IdOpcion.Direction = ParameterDirection.Input;
                prm_IdOpcion.Value = Convert.ToInt32(ListEnOpcion[0].IdOpcion);

                SqlHelper.ExecuteNonQuery(tran, "SEG_Opcion_sp_SubirNivel",
                                                prm_IdModulo,
                                                prm_IdOpcion
                                             );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Opcion_BajarNivel(List<EnOpcion> ListEnOpcion, SqlTransaction tran)
        {

            SqlParameter prm_IdModulo = new SqlParameter();
            SqlParameter prm_IdOpcion = new SqlParameter();           
            try
            {
                prm_IdModulo.ParameterName = "@IdModulo";
                prm_IdModulo.SqlDbType = SqlDbType.Int;
                prm_IdModulo.Direction = ParameterDirection.Input;
                prm_IdModulo.Value = ListEnOpcion[0].IdModulo;

                prm_IdOpcion.ParameterName = "@IdOpcion";
                prm_IdOpcion.SqlDbType = SqlDbType.Int;
                prm_IdOpcion.Direction = ParameterDirection.Input;
                prm_IdOpcion.Value = Convert.ToInt32(ListEnOpcion[0].IdOpcion);

                SqlHelper.ExecuteNonQuery(tran, "SEG_Opcion_sp_BajarNivel",
                                                prm_IdModulo,
                                                prm_IdOpcion
                                             );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 
        #endregion Opcion

        #region OpcionAccion
        public void Insertar_OpcionAccion(List<EnOpcion> ListEnOpcion, SqlTransaction tran)
        {

            SqlParameter prm_CEmpresa = new SqlParameter();
            SqlParameter prm_IdOpcion = new SqlParameter();
            SqlParameter prm_IdAccion = new SqlParameter();
            SqlParameter prm_CodUsuReg = new SqlParameter();
            try
            {


                prm_CEmpresa.ParameterName = "@CEMPRESA";
                prm_CEmpresa.SqlDbType = SqlDbType.Char;
                prm_CEmpresa.Direction = ParameterDirection.Input;
                prm_CEmpresa.Size = 2;
                prm_CEmpresa.Value = ListEnOpcion[0].CEmpresa;


                prm_IdOpcion.ParameterName = "@IdOpcion";
                prm_IdOpcion.SqlDbType = SqlDbType.Int;
                prm_IdOpcion.Direction = ParameterDirection.Input;
                prm_IdOpcion.Value = Convert.ToInt32(ListEnOpcion[0].IdOpcion);


                prm_IdAccion.ParameterName = "@IdAccion";
                prm_IdAccion.SqlDbType = SqlDbType.Int;
                prm_IdAccion.Direction = ParameterDirection.Input;
                prm_IdAccion.Value = Convert.ToInt32(ListEnOpcion[0].IdAccion);

                prm_CodUsuReg.ParameterName = "@CodUsuReg";
                prm_CodUsuReg.SqlDbType = SqlDbType.VarChar;
                prm_CodUsuReg.Direction = ParameterDirection.Input;
                prm_CodUsuReg.Size = 15;
                prm_CodUsuReg.Value = ListEnOpcion[0].CodUsuario;



                SqlHelper.ExecuteNonQuery(tran, "SEG_Opcion_sp_MatenimientoInsertaAccion",
                                                prm_CEmpresa,
                                                prm_IdOpcion,
                                                prm_IdAccion,
                                                prm_CodUsuReg
                                             );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Elimina_OpcionAccion(List<EnOpcion> ListEnOpcion, SqlTransaction tran)
        {
            SqlParameter prm_CEmpresa = new SqlParameter();
            SqlParameter prm_idOpcionAccion = new SqlParameter();
            try
            {
                prm_CEmpresa.ParameterName = "@CEMPRESA";
                prm_CEmpresa.SqlDbType = SqlDbType.Char;
                prm_CEmpresa.Direction = ParameterDirection.Input;
                prm_CEmpresa.Size = 2;
                prm_CEmpresa.Value = ListEnOpcion[0].CEmpresa;

                prm_idOpcionAccion.ParameterName = "@idOpcionAccion";
                prm_idOpcionAccion.SqlDbType = SqlDbType.Int;
                prm_idOpcionAccion.Direction = ParameterDirection.Input;

                prm_idOpcionAccion.Value = Convert.ToInt32(ListEnOpcion[0].idOpcionAccion);

                SqlHelper.ExecuteNonQuery(tran, "SEG_Opcion_sp_MatenimientoEliminaAccion",
                                                prm_CEmpresa,
                                                prm_idOpcionAccion
                                             );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion OpcionAccion

        #region Comun

        public DataTable Seguridad_CargaAccionesDeOpcion(List<EnOpcion> ListEnOpcion)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString2);
                sqlCommand = "SEG_Opcion_sp_CargaAccionesDeOpcion";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[4];

                paramsToStore[0] = new SqlParameter("@CEMPRESA", SqlDbType.Char);
                paramsToStore[0].Value = ListEnOpcion[0].CEmpresa;
                paramsToStore[0].Size = 2;

                paramsToStore[1] = new SqlParameter("@IDUSUARIO", SqlDbType.Int);
                paramsToStore[1].Value = Convert.ToInt32(ListEnOpcion[0].CodUsuario);

                paramsToStore[2] = new SqlParameter("@IDMODULO", SqlDbType.Int);
                paramsToStore[2].Value = Convert.ToInt32(ListEnOpcion[0].IdModulo);

                paramsToStore[3] = new SqlParameter("@IDOPCION", SqlDbType.Int);
                paramsToStore[3].Value = Convert.ToInt32(ListEnOpcion[0].IdOpcion);

                adp.SelectCommand.Parameters.AddRange(paramsToStore);

                adp.Fill(DS, "DataTable1");
                dt = DS.Tables["DataTable1"];
                Conn.Close();
                return dt;
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        #endregion Comun

        #region Reporte
        public DataTable Opcion_Reporte(List<EnOpcion> ListEnOpcion)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString2);
                sqlCommand = "SEG_Opcion_sp_Reporte";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];

                paramsToStore[0] = new SqlParameter("@Accion", SqlDbType.Int);
                paramsToStore[0].Value = ListEnOpcion[0].Accion;// Lista Opcion Accion

                paramsToStore[1] = new SqlParameter("@CEmpresa", SqlDbType.Char);
                paramsToStore[1].Value = ListEnOpcion[0].CEmpresa;
                paramsToStore[1].Size = 2;

                adp.SelectCommand.Parameters.AddRange(paramsToStore);

                adp.Fill(DS, "DataTable1");
                dt = DS.Tables["DataTable1"];
                Conn.Close();
                return dt;
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        #endregion Reporte

    }
}
