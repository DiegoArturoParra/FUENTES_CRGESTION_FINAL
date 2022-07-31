using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Sis.Estudio.Entity;

namespace Sis.Estudio.Data.MSSQL.Seguridad
{
    public class DaPerfil : DaConexion
    {
        
        
        #region Listado
        public DataTable Buscar_Perfil(List<EnPerfil> ListEnPerfil)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString2);
                sqlCommand = "SEG_Perfil_sp_BuscarPerfil";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[5];

                paramsToStore[0] = new SqlParameter("@Accion", SqlDbType.Int);
                paramsToStore[0].Value = Convert.ToInt16(ListEnPerfil[0].Accion);

                paramsToStore[1] = new SqlParameter("@CEmpresa", SqlDbType.Char);
                paramsToStore[1].Value = ListEnPerfil[0].CEmpresa;
                paramsToStore[1].Size = 2;

                paramsToStore[2] = new SqlParameter("@IdModulo", SqlDbType.Int);
                paramsToStore[2].Value = Convert.ToInt32(ListEnPerfil[0].IdModulo);

                paramsToStore[3] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                paramsToStore[3].Value = ListEnPerfil[0].Nombre;
                paramsToStore[3].Size = 50;

                paramsToStore[4] = new SqlParameter("@Descripcion", SqlDbType.VarChar);
                paramsToStore[4].Value = ListEnPerfil[0].Descripcion;
                paramsToStore[4].Size = 50;

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
        public DataTable ComboFiltroModulos(EnPerfil objEnPerfil)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString2);
                sqlCommand = "SEG_Perfil_sp_ComboFiltroModulos";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[1];

                paramsToStore[0] = new SqlParameter("@CEMPRESA", SqlDbType.Char);
                paramsToStore[0].Value = objEnPerfil.CEmpresa;
                paramsToStore[0].Size = 2;

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

        #region Detalla
        public DataTable CargaDatosPerfil(string str_Tipo, List<EnPerfil> ListEnPerfil)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString2);
                sqlCommand = "SEG_Perfil_sp_CargaDatosPerfil";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 100000;

                SqlParameter[] paramsToStore = new SqlParameter[3];

                paramsToStore[0] = new SqlParameter("@CEMPRESA", SqlDbType.Char);
                paramsToStore[0].Size = 2;
                paramsToStore[0].Value = ListEnPerfil[0].CEmpresa;

                paramsToStore[1] = new SqlParameter("@TIPO", SqlDbType.Char);
                paramsToStore[1].Size = 1;
                paramsToStore[1].Value = str_Tipo;

                paramsToStore[2] = new SqlParameter("@IDPERFIL", SqlDbType.Int);
                paramsToStore[2].Value = Convert.ToInt32(ListEnPerfil[0].IdPerfil);

                adp.SelectCommand.Parameters.AddRange(paramsToStore);
                adp.Fill(DS, "DataTable1");
                dt = DS.Tables["DataTable1"];
                return dt;
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public string Insertar_Perfil(List<EnPerfil> ListEnPerfil, SqlTransaction tran)
        {
            string IdReturn = String.Empty;
            SqlDataReader drParamReturn;
            SqlParameter prm_CEMPRESA = new SqlParameter();
            SqlParameter prm_IDMODULO = new SqlParameter();
            SqlParameter prm_NOMBRE = new SqlParameter();
            SqlParameter prm_DESCRIPCION = new SqlParameter();
            SqlParameter prm_CODUSUARIOREGISTRA = new SqlParameter();
            try
            {
                prm_CEMPRESA.ParameterName = "@CEMPRESA";
                prm_CEMPRESA.SqlDbType = SqlDbType.Char;
                prm_CEMPRESA.Direction = ParameterDirection.Input;
                prm_CEMPRESA.Size = 2;
                prm_CEMPRESA.Value = ListEnPerfil[0].CEmpresa;

                prm_IDMODULO.ParameterName = "@IdModulo";
                prm_IDMODULO.SqlDbType = SqlDbType.Int;
                prm_IDMODULO.Direction = ParameterDirection.Input;
                prm_IDMODULO.Value = Convert.ToInt32(ListEnPerfil[0].IdModulo);

                prm_NOMBRE.ParameterName = "@NOMBRE";
                prm_NOMBRE.SqlDbType = SqlDbType.VarChar;
                prm_NOMBRE.Direction = ParameterDirection.Input;
                prm_NOMBRE.Size = 50;
                prm_NOMBRE.Value = ListEnPerfil[0].Nombre;

                prm_DESCRIPCION.ParameterName = "@DESCRIPCION";
                prm_DESCRIPCION.SqlDbType = SqlDbType.VarChar;
                prm_DESCRIPCION.Direction = ParameterDirection.Input;
                prm_DESCRIPCION.Size = 50;
                prm_DESCRIPCION.Value = ListEnPerfil[0].Descripcion;

                prm_CODUSUARIOREGISTRA.ParameterName = "@CODUSUARIOREGISTRA";
                prm_CODUSUARIOREGISTRA.SqlDbType = SqlDbType.VarChar;
                prm_CODUSUARIOREGISTRA.Direction = ParameterDirection.Input;
                prm_CODUSUARIOREGISTRA.Size = 12;
                prm_CODUSUARIOREGISTRA.Value = ListEnPerfil[0].CodUsuario;

                drParamReturn = SqlHelper.ExecuteReader(tran, "SEG_Perfil_sp_InsertaPerfil",
                                               prm_CEMPRESA,
                                               prm_IDMODULO,
                                               prm_NOMBRE,
                                               prm_DESCRIPCION,
                                               prm_CODUSUARIOREGISTRA
                                             );

                while (drParamReturn.Read())
                {
                    IdReturn = drParamReturn.GetValue(0).ToString();
                }
                drParamReturn.Close();
                return IdReturn;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Modifica_Perfil(List<EnPerfil> ListEnPerfil, SqlTransaction tran)
        {
            SqlParameter prm_IDPERFIL = new SqlParameter();
            SqlParameter prm_CEMPRESA = new SqlParameter();
            SqlParameter prm_IDMODULO = new SqlParameter();
            SqlParameter prm_NOMBRE = new SqlParameter();
            SqlParameter prm_DESCRIPCION = new SqlParameter();
            SqlParameter prm_CODUSUARIOMODIFICA = new SqlParameter();
            try
            {
                prm_IDPERFIL.ParameterName = "@IDPERFIL";
                prm_IDPERFIL.SqlDbType = SqlDbType.Int;
                prm_IDPERFIL.Direction = ParameterDirection.Input;
                prm_IDPERFIL.Value = Convert.ToInt32(ListEnPerfil[0].IdPerfil);

                prm_CEMPRESA.ParameterName = "@CEMPRESA";
                prm_CEMPRESA.SqlDbType = SqlDbType.Char;
                prm_CEMPRESA.Direction = ParameterDirection.Input;
                prm_CEMPRESA.Size = 2;
                prm_CEMPRESA.Value = ListEnPerfil[0].CEmpresa;

                prm_IDMODULO.ParameterName = "@IdModulo";
                prm_IDMODULO.SqlDbType = SqlDbType.Int;
                prm_IDMODULO.Direction = ParameterDirection.Input;
                prm_IDMODULO.Value = Convert.ToInt32(ListEnPerfil[0].IdModulo);

                prm_NOMBRE.ParameterName = "@NOMBRE";
                prm_NOMBRE.SqlDbType = SqlDbType.VarChar;
                prm_NOMBRE.Direction = ParameterDirection.Input;
                prm_NOMBRE.Size = 50;
                prm_NOMBRE.Value = ListEnPerfil[0].Nombre;

                prm_DESCRIPCION.ParameterName = "@DESCRIPCION";
                prm_DESCRIPCION.SqlDbType = SqlDbType.VarChar;
                prm_DESCRIPCION.Direction = ParameterDirection.Input;
                prm_DESCRIPCION.Size = 50;
                prm_DESCRIPCION.Value = ListEnPerfil[0].Descripcion;

                prm_CODUSUARIOMODIFICA.ParameterName = "@CODUSUARIOMODIFICA";
                prm_CODUSUARIOMODIFICA.SqlDbType = SqlDbType.VarChar;
                prm_CODUSUARIOMODIFICA.Direction = ParameterDirection.Input;
                prm_CODUSUARIOMODIFICA.Size = 12;
                prm_CODUSUARIOMODIFICA.Value = ListEnPerfil[0].CodUsuario;

                SqlHelper.ExecuteNonQuery(tran, "SEG_Perfil_sp_ModificaPerfil",
                                              prm_IDPERFIL,
                                              prm_CEMPRESA,
                                              prm_IDMODULO,
                                              prm_NOMBRE,
                                              prm_DESCRIPCION,
                                              prm_CODUSUARIOMODIFICA
                                            );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Anula_Perfil(List<EnPerfil> ListEnPerfil, SqlTransaction tran)
        {

            SqlParameter prm_IDPERFIL = new SqlParameter();
            SqlParameter prm_CEMPRESA = new SqlParameter();
            SqlParameter prm_NOMBRE = new SqlParameter();
            SqlParameter prm_DESCRIPCION = new SqlParameter();
            SqlParameter prm_CODUSUARIOANULA = new SqlParameter();
            try
            {
                prm_IDPERFIL.ParameterName = "@IDPERFIL";
                prm_IDPERFIL.SqlDbType = SqlDbType.Int;
                prm_IDPERFIL.Direction = ParameterDirection.Input;
                prm_IDPERFIL.Value = Convert.ToInt32(ListEnPerfil[0].IdPerfil);

                prm_CEMPRESA.ParameterName = "@CEMPRESA";
                prm_CEMPRESA.SqlDbType = SqlDbType.Char;
                prm_CEMPRESA.Direction = ParameterDirection.Input;
                prm_CEMPRESA.Size = 2;
                prm_CEMPRESA.Value = ListEnPerfil[0].CEmpresa;

                prm_CODUSUARIOANULA.ParameterName = "@CODUSUARIOANULA";
                prm_CODUSUARIOANULA.SqlDbType = SqlDbType.VarChar;
                prm_CODUSUARIOANULA.Direction = ParameterDirection.Input;
                prm_CODUSUARIOANULA.Size = 12;
                prm_CODUSUARIOANULA.Value = ListEnPerfil[0].CodUsuario;

                SqlHelper.ExecuteNonQuery(tran, "SEG_Perfil_sp_AnulaPerfil",
                                              prm_IDPERFIL,
                                              prm_CEMPRESA,
                                              prm_CODUSUARIOANULA
                                            );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion Detalla

        #region Perfil_Opcion
        public DataTable Carga_OpcionesParaArbol(List<EnPerfil> ListEnPerfil)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString2);
                sqlCommand = "SEG_Perfil_sp_CargaOpcionesParaArbol";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];

                paramsToStore[0] = new SqlParameter("@CEMPRESA", SqlDbType.Char);
                paramsToStore[0].Value = ListEnPerfil[0].CEmpresa;
                paramsToStore[0].Size = 2;

                paramsToStore[1] = new SqlParameter("@IdModulo", SqlDbType.Int);
                paramsToStore[1].Value = Convert.ToInt32(ListEnPerfil[0].IdModulo);

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
        public DataTable Carga_AccionesParaArbol(List<EnPerfil> ListEnPerfil)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString2);
                sqlCommand = "SEG_Perfil_sp_CargaAccionesParaArbol";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];

                paramsToStore[0] = new SqlParameter("@CEMPRESA", SqlDbType.Char);
                paramsToStore[0].Value = ListEnPerfil[0].CEmpresa;
                paramsToStore[0].Size = 2;

                paramsToStore[1] = new SqlParameter("@IdModulo", SqlDbType.Int);
                paramsToStore[1].Value = Convert.ToInt32(ListEnPerfil[0].IdModulo);

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

        public DataTable Carga_PerfilOpcionesParaArbol(List<EnPerfil> ListEnPerfil)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString2);
                sqlCommand = "SEG_Perfil_sp_CargaPerfilOpcionesParaArbol";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];


                paramsToStore[0] = new SqlParameter("@IDPERFIL", SqlDbType.Int);
                paramsToStore[0].Value = Convert.ToInt32(ListEnPerfil[0].IdPerfil);

                paramsToStore[1] = new SqlParameter("@CEMPRESA", SqlDbType.Char);
                paramsToStore[1].Value = ListEnPerfil[0].CEmpresa;
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
        public DataTable Carga_PerfilAccionesParaArbol(List<EnPerfil> ListEnPerfil)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString2);
                sqlCommand = "SEG_Perfil_sp_CargaPerfilAccionesParaArbol";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];

                paramsToStore[0] = new SqlParameter("@IDPERFIL", SqlDbType.Int);
                paramsToStore[0].Value = Convert.ToInt32(ListEnPerfil[0].IdPerfil);

                paramsToStore[1] = new SqlParameter("@CEMPRESA", SqlDbType.Char);
                paramsToStore[1].Value = ListEnPerfil[0].CEmpresa;
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

        public void EliminaPerfilOpcion(List<EnPerfil> ListEnPerfil, SqlTransaction tran)
        {
            SqlParameter prm_IDPERFIL = new SqlParameter();
            SqlParameter prm_CEMPRESA = new SqlParameter();
            

            try
            {

                prm_IDPERFIL.ParameterName = "@IDPERFIL";
                prm_IDPERFIL.SqlDbType = SqlDbType.Int;
                prm_IDPERFIL.Direction = ParameterDirection.Input;
                prm_IDPERFIL.Value = Convert.ToInt32(ListEnPerfil[0].IdPerfil);   //Convert.ToInt32(Entidad_Perfil.IdPerfil);

                prm_CEMPRESA.ParameterName = "@CEMPRESA";
                prm_CEMPRESA.SqlDbType = SqlDbType.Char;
                prm_CEMPRESA.Direction = ParameterDirection.Input;
                prm_CEMPRESA.Size = 2;
                prm_CEMPRESA.Value = ListEnPerfil[0].CEmpresa;// Entidad_Perfil.CEmpresa;

                


                SqlHelper.ExecuteNonQuery(tran, "SEG_Perfil_sp_EliminaPerfilOpcion",
                                            prm_IDPERFIL,
                                            prm_CEMPRESA                                           

                 );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void InsertaPerfilOpcion(List<EnPerfil> ListEnPerfil, string strIdOpcion, SqlTransaction tran)
        {
            SqlParameter prm_IDPERFIL = new SqlParameter();
            SqlParameter prm_CEMPRESA = new SqlParameter();            
            SqlParameter prm_CODUSUARIOREGISTRA = new SqlParameter();
            SqlParameter prm_IDOPCION = new SqlParameter();

            try
            {
                prm_IDPERFIL.ParameterName = "@IDPERFIL";
                prm_IDPERFIL.SqlDbType = SqlDbType.Int;
                prm_IDPERFIL.Direction = ParameterDirection.Input;
                prm_IDPERFIL.Value = Convert.ToInt32(ListEnPerfil[0].IdPerfil);  //Convert.ToInt32(Entidad_Perfil.IdPerfil);


                prm_CEMPRESA.ParameterName = "@CEMPRESA";
                prm_CEMPRESA.SqlDbType = SqlDbType.Char;
                prm_CEMPRESA.Direction = ParameterDirection.Input;
                prm_CEMPRESA.Size = 2;
                prm_CEMPRESA.Value = ListEnPerfil[0].CEmpresa;//Entidad_Perfil.CEmpresa;

                prm_CODUSUARIOREGISTRA.ParameterName = "@CODUSUARIOREGISTRA";
                prm_CODUSUARIOREGISTRA.SqlDbType = SqlDbType.VarChar;
                prm_CODUSUARIOREGISTRA.Direction = ParameterDirection.Input;
                prm_CODUSUARIOREGISTRA.Size = 12;
                prm_CODUSUARIOREGISTRA.Value = ListEnPerfil[0].CodUsuario;//Entidad_Perfil.CodUsuarioRegistra;

                prm_IDOPCION.ParameterName = "@IDOPCION";
                prm_IDOPCION.SqlDbType = SqlDbType.Int;
                prm_IDOPCION.Direction = ParameterDirection.Input;
                prm_IDOPCION.Value = Convert.ToInt32(strIdOpcion);

                SqlHelper.ExecuteNonQuery(tran, "SEG_Perfil_sp_InsertaPerfilOpcion",
                          prm_IDPERFIL,
                          prm_CEMPRESA,                          
                          prm_CODUSUARIOREGISTRA,
                          prm_IDOPCION
                );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void InsertaPerfilAccion(List<EnPerfil> ListEnPerfil, string OPC_idopcion, string ACC_idaccion, SqlTransaction tran)
        {
            SqlParameter prm_IDPERFIL = new SqlParameter();
            SqlParameter prm_CEMPRESA = new SqlParameter();            
            SqlParameter prm_CODUSUARIOREGISTRA = new SqlParameter();
            SqlParameter prm_IDOPCION = new SqlParameter();
            SqlParameter prm_IDACCION = new SqlParameter();

            try
            {
                prm_IDPERFIL.ParameterName = "@IDPERFIL";
                prm_IDPERFIL.SqlDbType = SqlDbType.Int;
                prm_IDPERFIL.Direction = ParameterDirection.Input;
                prm_IDPERFIL.Value = Convert.ToInt32(ListEnPerfil[0].IdPerfil);  //Convert.ToInt32(Entidad_Perfil.IdPerfil);

                prm_CEMPRESA.ParameterName = "@CEMPRESA";
                prm_CEMPRESA.SqlDbType = SqlDbType.Char;
                prm_CEMPRESA.Direction = ParameterDirection.Input;
                prm_CEMPRESA.Size = 2;
                prm_CEMPRESA.Value = ListEnPerfil[0].CEmpresa;//Entidad_Perfil.CEmpresa;

                prm_CODUSUARIOREGISTRA.ParameterName = "@CODUSUARIOREGISTRA";
                prm_CODUSUARIOREGISTRA.SqlDbType = SqlDbType.VarChar;
                prm_CODUSUARIOREGISTRA.Direction = ParameterDirection.Input;
                prm_CODUSUARIOREGISTRA.Size = 12;
                prm_CODUSUARIOREGISTRA.Value = ListEnPerfil[0].CodUsuario;//Entidad_Perfil.CodUsuarioRegistra;

                prm_IDOPCION.ParameterName = "@IDOPCION";
                prm_IDOPCION.SqlDbType = SqlDbType.Int;
                prm_IDOPCION.Direction = ParameterDirection.Input;
                prm_IDOPCION.Value = Convert.ToInt32(OPC_idopcion);

                prm_IDACCION.ParameterName = "@IDACCION";
                prm_IDACCION.SqlDbType = SqlDbType.Int;
                prm_IDACCION.Direction = ParameterDirection.Input;
                prm_IDACCION.Value = Convert.ToInt32(ACC_idaccion);

                SqlHelper.ExecuteNonQuery(tran, "SEG_Perfil_sp_InsertaPerfilOpcionAccion",
                          prm_IDPERFIL,
                          prm_CEMPRESA,                          
                          prm_CODUSUARIOREGISTRA,
                          prm_IDOPCION,
                          prm_IDACCION
                );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion Perfil_Opcion
    }
}
