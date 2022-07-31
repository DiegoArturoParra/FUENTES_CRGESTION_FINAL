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
    public class DaAccion : DaConexion
    {
              
        #region Busqueda
        public DataTable Lista_TodasLasAcciones(List<EnAccion> ListEnAccion)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString2);
                sqlCommand = "SEG_Modulo_sp_ListaTodasLasAcciones";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[1];

                paramsToStore[0] = new SqlParameter("@CEMPRESA", SqlDbType.Char);
                paramsToStore[0].Value = ListEnAccion[0].CEmpresa;
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
        #endregion Busqueda

        #region Listado
        public DataTable Listado_Accion(List<EnAccion> ListEnAccion)
        {

            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString2);
                sqlCommand = "SEG_Accion_sp_Matenimiento";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[4];

                paramsToStore[0] = new SqlParameter("@Accion", SqlDbType.Int);
                paramsToStore[0].Value = ListEnAccion[0].Accion;

                paramsToStore[1] = new SqlParameter("@CEmpresa", SqlDbType.Char);
                paramsToStore[1].Value = ListEnAccion[0].CEmpresa;
                paramsToStore[1].Size = 2;

                paramsToStore[2] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                paramsToStore[2].Value = ListEnAccion[0].Nombre;
                paramsToStore[2].Size = 50;

                paramsToStore[3] = new SqlParameter("@Descripcion", SqlDbType.VarChar);
                paramsToStore[3].Value = ListEnAccion[0].Descripcion;
                paramsToStore[3].Size = 100;

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

        #region Detalle
        public DataTable CargaDatosAccion(List<EnAccion> ListEnAccion)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString2);
                sqlCommand = "SEG_Accion_sp_Matenimiento";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 100000;

                SqlParameter[] paramsToStore = new SqlParameter[4];

                paramsToStore[0] = new SqlParameter("@Accion", SqlDbType.Int);
                paramsToStore[0].Value = Convert.ToInt16(3);// Carga Datos

                paramsToStore[1] = new SqlParameter("@CEMPRESA", SqlDbType.Char);
                paramsToStore[1].Size = 2;
                paramsToStore[1].Value = ListEnAccion[0].CEmpresa;

                paramsToStore[2] = new SqlParameter("@TIPO", SqlDbType.Char);
                paramsToStore[2].Size = 1;
                paramsToStore[2].Value = ListEnAccion[0].Tipo;

                paramsToStore[3] = new SqlParameter("@Id", SqlDbType.Int);
                paramsToStore[3].Value = Convert.ToInt32(ListEnAccion[0].Id);

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
        public string Insertar_Accion(List<EnAccion> ListEnAccion, SqlTransaction tran)
        {
            string IdReturn = String.Empty;
            SqlDataReader drParamReturn;

            SqlParameter prm_CEMPRESA = new SqlParameter();
            SqlParameter prm_NOMBRE = new SqlParameter();
            SqlParameter prm_DESCRIPCION = new SqlParameter();
            SqlParameter prm_CODUSUARIOREGISTRA = new SqlParameter();
            try
            {

                prm_CEMPRESA.ParameterName = "@CEMPRESA";
                prm_CEMPRESA.SqlDbType = SqlDbType.Char;
                prm_CEMPRESA.Direction = ParameterDirection.Input;
                prm_CEMPRESA.Size = 2;
                prm_CEMPRESA.Value = ListEnAccion[0].CEmpresa;

                prm_NOMBRE.ParameterName = "@Nombre";
                prm_NOMBRE.SqlDbType = SqlDbType.VarChar;
                prm_NOMBRE.Direction = ParameterDirection.Input;
                prm_NOMBRE.Size = 50;
                prm_NOMBRE.Value = ListEnAccion[0].Nombre;

                prm_DESCRIPCION.ParameterName = "@Descripcion";
                prm_DESCRIPCION.SqlDbType = SqlDbType.VarChar;
                prm_DESCRIPCION.Direction = ParameterDirection.Input;
                prm_DESCRIPCION.Size = 100;
                prm_DESCRIPCION.Value = ListEnAccion[0].Descripcion;

                prm_CODUSUARIOREGISTRA.ParameterName = "@CodUsuReg";
                prm_CODUSUARIOREGISTRA.SqlDbType = SqlDbType.Int;
                prm_CODUSUARIOREGISTRA.Direction = ParameterDirection.Input;
                prm_CODUSUARIOREGISTRA.Value = ListEnAccion[0].CodUsuario;

                drParamReturn = SqlHelper.ExecuteReader(tran, "SEG_Accion_sp_MatenimientoInserta",
                                               prm_CEMPRESA,
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
        public void Modifica_Accion(List<EnAccion> ListEnAccion, SqlTransaction tran)
        {
            
            SqlParameter prm_CEMPRESA = new SqlParameter();
            SqlParameter prm_NOMBRE = new SqlParameter();
            SqlParameter prm_DESCRIPCION = new SqlParameter();
            SqlParameter prm_CODUSUARIOREGISTRA = new SqlParameter();
            SqlParameter prm_ID = new SqlParameter();
            try
            {

                prm_CEMPRESA.ParameterName = "@CEMPRESA";
                prm_CEMPRESA.SqlDbType = SqlDbType.Char;
                prm_CEMPRESA.Direction = ParameterDirection.Input;
                prm_CEMPRESA.Size = 2;
                prm_CEMPRESA.Value = ListEnAccion[0].CEmpresa;

                prm_NOMBRE.ParameterName = "@Nombre";
                prm_NOMBRE.SqlDbType = SqlDbType.VarChar;
                prm_NOMBRE.Direction = ParameterDirection.Input;
                prm_NOMBRE.Size = 50;
                prm_NOMBRE.Value = ListEnAccion[0].Nombre;

                prm_DESCRIPCION.ParameterName = "@Descripcion";
                prm_DESCRIPCION.SqlDbType = SqlDbType.VarChar;
                prm_DESCRIPCION.Direction = ParameterDirection.Input;
                prm_DESCRIPCION.Size = 100;
                prm_DESCRIPCION.Value = ListEnAccion[0].Descripcion;

                prm_CODUSUARIOREGISTRA.ParameterName = "@CodUsuReg";
                prm_CODUSUARIOREGISTRA.SqlDbType = SqlDbType.Int;
                prm_CODUSUARIOREGISTRA.Direction = ParameterDirection.Input;
                prm_CODUSUARIOREGISTRA.Value = ListEnAccion[0].CodUsuario;

                prm_ID.ParameterName = "@Id";
                prm_ID.SqlDbType = SqlDbType.Int;
                prm_ID.Direction = ParameterDirection.Input;
                prm_ID.Value = Convert.ToInt32(ListEnAccion[0].Id);


                SqlHelper.ExecuteNonQuery(tran, "SEG_Accion_sp_MatenimientoModifica",                                               
                                               prm_CEMPRESA,
                                               prm_NOMBRE,
                                               prm_DESCRIPCION,
                                               prm_CODUSUARIOREGISTRA,
                                               prm_ID
                                             );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Anula_Accion(List<EnAccion> ListEnAccion, SqlTransaction tran)
        {
            SqlParameter prm_ID = new SqlParameter();
            SqlParameter prm_CEMPRESA = new SqlParameter();
            SqlParameter prm_CODUSUARIOREGISTRA = new SqlParameter();
            try
            {
                prm_ID.ParameterName = "@Id";
                prm_ID.SqlDbType = SqlDbType.Int;
                prm_ID.Direction = ParameterDirection.Input;
                prm_ID.Value = Convert.ToInt32(ListEnAccion[0].Id);

                prm_CEMPRESA.ParameterName = "@CEMPRESA";
                prm_CEMPRESA.SqlDbType = SqlDbType.Char;
                prm_CEMPRESA.Direction = ParameterDirection.Input;
                prm_CEMPRESA.Size = 2;
                prm_CEMPRESA.Value = ListEnAccion[0].CEmpresa;

                prm_CODUSUARIOREGISTRA.ParameterName = "@CodUsuReg";
                prm_CODUSUARIOREGISTRA.SqlDbType = SqlDbType.Int;
                prm_CODUSUARIOREGISTRA.Direction = ParameterDirection.Input;
                prm_CODUSUARIOREGISTRA.Value = ListEnAccion[0].CodUsuario;

                SqlHelper.ExecuteNonQuery(tran, "SEG_Accion_sp_MatenimientoAnula",
                                               prm_ID,
                                               prm_CEMPRESA,
                                               prm_CODUSUARIOREGISTRA
                                             );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion Detalle

    }
}
