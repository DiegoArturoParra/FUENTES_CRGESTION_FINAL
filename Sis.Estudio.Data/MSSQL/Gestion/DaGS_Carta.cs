
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Sis.Estudio.Entity;

namespace Sis.Estudio.Data.MSSQL.Gestion
{
    public class DaGS_Carta : DaConexion
    {

        public DataTable GS_Carta_Lista(List<EnGS_Carta> ListEnGS_Carta)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_Carta_sp_Listar";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];

                paramsToStore[0] = new SqlParameter("@Descripcion", SqlDbType.VarChar);
                paramsToStore[0].Value = ListEnGS_Carta[0].Descripcion;
                paramsToStore[0].Size = 250;

                paramsToStore[1] = new SqlParameter("@nEmpresa", SqlDbType.Int);
                paramsToStore[1].Value = ListEnGS_Carta[0].nEmpresa;

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

        public string GS_Carta_INS(List<EnGS_Carta> ListEnGS_Carta, SqlTransaction tran)
        {
            string IdReturn = String.Empty;
            SqlDataReader drParamReturn;

            SqlParameter prm_Descripcion = new SqlParameter();
            SqlParameter prm_Pie = new SqlParameter();
            /*Modif. 041016*/
            SqlParameter prm_Id_carta = new SqlParameter();
            //SqlParameter prm_Num_carta = new SqlParameter();
            /**/
            SqlParameter prm_nEmpresa = new SqlParameter();
            SqlParameter prm_CodUsuario = new SqlParameter();
            SqlParameter prm_nombre = new SqlParameter();
            SqlParameter prm_TipoDocumento = new SqlParameter();
            try
            {

                #region Values

                #region prm_Descripcion
                prm_Descripcion.ParameterName = "@Descripcion";
                prm_Descripcion.SqlDbType = SqlDbType.VarChar;
                prm_Descripcion.Direction = ParameterDirection.Input;
                prm_Descripcion.Size = 50000;
                prm_Descripcion.Value = ListEnGS_Carta[0].Descripcion;
                #endregion prm_Descripcion
                #region prm_Pie
                prm_Pie.ParameterName = "@Pie";
                prm_Pie.SqlDbType = SqlDbType.VarChar;
                prm_Pie.Direction = ParameterDirection.Input;
                prm_Descripcion.Size = 50000;
                prm_Pie.Value = ListEnGS_Carta[0].Pie;
                #endregion prm_Pie
                ///*Modif 041016*/
                #region prm_Num_carta
                //prm_Num_carta.ParameterName = "@Num_carta";
                //prm_Num_carta.SqlDbType = SqlDbType.Int;
                //prm_Num_carta.Direction = ParameterDirection.Input;
                //prm_Num_carta.Value = ListEnGS_Carta[0].Num_carta;
                #endregion prm_Num_carta

                #region prm_Id_carta
                prm_Id_carta.ParameterName = "@Id_carta";
                prm_Id_carta.SqlDbType = SqlDbType.Int;
                prm_Id_carta.Direction = ParameterDirection.Input;
                prm_Id_carta.Value = ListEnGS_Carta[0].id_carta;
                #endregion prm_Id_carta
                /*Fin Modif.*/
                #region prm_nEmpresa
                prm_nEmpresa.ParameterName = "@nEmpresa";
                prm_nEmpresa.SqlDbType = SqlDbType.Int;
                prm_nEmpresa.Direction = ParameterDirection.Input;
                prm_nEmpresa.Value = ListEnGS_Carta[0].nEmpresa;
                #endregion prm_nEmpresa


                #region prm_CodUsuario
                prm_CodUsuario.ParameterName = "@CodUsuarioRegistra";
                prm_CodUsuario.SqlDbType = SqlDbType.Int;
                prm_CodUsuario.Direction = ParameterDirection.Input;
                prm_CodUsuario.Value = ListEnGS_Carta[0].CodUsuario;
                #endregion prm_CodUsuario 

                #region prm_nombre
                prm_nombre.ParameterName = "@nombre";
                prm_nombre.SqlDbType = SqlDbType.Int;
                prm_nombre.Direction = ParameterDirection.Input;
                prm_nombre.Value = ListEnGS_Carta[0].nombre;
                #endregion prm_nombre

                #region prm_TipoDocumento
                prm_TipoDocumento.ParameterName = "@CodTipoDocum";
                prm_TipoDocumento.SqlDbType = SqlDbType.Int;
                prm_TipoDocumento.Direction = ParameterDirection.Input;
                prm_TipoDocumento.Value = ListEnGS_Carta[0].CodTipoDocum;
                #endregion prm_TipoDocumento


                #endregion Values


                drParamReturn = SqlHelper.ExecuteReader(tran, "dbo.GS_Carta_sp_Insertar",
                                               prm_Descripcion,
                                               prm_Pie,
                                               /*prm_Num_carta, */
                                               //prm_Id_carta,
                                               prm_nEmpresa, prm_CodUsuario, prm_nombre, prm_TipoDocumento
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

        public void GS_Carta_UPD(List<EnGS_Carta> ListEnGS_Carta, SqlTransaction tran)
        {
            try
            {
                #region Parametros
                SqlParameter prm_id_carta = new SqlParameter();
                SqlParameter prm_Descripcion = new SqlParameter();
                SqlParameter prm_Pie = new SqlParameter();
                //SqlParameter prm_Num_carta = new SqlParameter();
                SqlParameter prm_nEmpresa = new SqlParameter();
                SqlParameter prm_CodUsuario = new SqlParameter();
                SqlParameter prm_nombre = new SqlParameter();

                SqlParameter prm_TipoDocumento = new SqlParameter();

                
                #endregion Parametros


                #region Values


                #region prm_id_carta
                prm_id_carta.ParameterName = "@id_carta";
                prm_id_carta.SqlDbType = SqlDbType.Int;
                prm_id_carta.Direction = ParameterDirection.Input;
                prm_id_carta.Value = ListEnGS_Carta[0].id_carta;
                #endregion prm_id_carta


                #region prm_Descripcion
                prm_Descripcion.ParameterName = "@Descripcion";
                prm_Descripcion.SqlDbType = SqlDbType.VarChar;
                prm_Descripcion.Direction = ParameterDirection.Input;
                prm_Descripcion.Size = 50000;
                prm_Descripcion.Value = ListEnGS_Carta[0].Descripcion;
                #endregion prm_Descripcion
                #region prm_Pie
                prm_Pie.ParameterName = "@Pie";
                prm_Pie.SqlDbType = SqlDbType.VarChar;
                prm_Pie.Direction = ParameterDirection.Input;
                prm_Descripcion.Size = 50000;
                prm_Pie.Value = ListEnGS_Carta[0].Pie;
                #endregion prm_Pie
                //#region prm_Num_carta
                //prm_Num_carta.ParameterName = "@Num_carta";
                //prm_Num_carta.SqlDbType = SqlDbType.Int;
                //prm_Num_carta.Direction = ParameterDirection.Input;
                //prm_Num_carta.Value = ListEnGS_Carta[0].Num_carta;
                //#endregion prm_Num_carta

                #region prm_nEmpresa
                prm_nEmpresa.ParameterName = "@nEmpresa";
                prm_nEmpresa.SqlDbType = SqlDbType.Int;
                prm_nEmpresa.Direction = ParameterDirection.Input;
                prm_nEmpresa.Value = ListEnGS_Carta[0].nEmpresa;
                #endregion prm_nEmpresa


                #region prm_CodUsuario
                prm_CodUsuario.ParameterName = "@CodUsuarioRegistra";
                prm_CodUsuario.SqlDbType = SqlDbType.Int;
                prm_CodUsuario.Direction = ParameterDirection.Input;
                prm_CodUsuario.Value = ListEnGS_Carta[0].CodUsuario;
                #endregion prm_CodUsuario 

                #region prm_nombre
                prm_nombre.ParameterName = "@nombre";
                prm_nombre.SqlDbType = SqlDbType.Int;
                prm_nombre.Direction = ParameterDirection.Input;
                prm_nombre.Value = ListEnGS_Carta[0].nombre;
                #endregion prm_nombre

                #region prm_TipoDocumento
                prm_TipoDocumento.ParameterName = "@CodTipoDocum";
                prm_TipoDocumento.SqlDbType = SqlDbType.Int;
                prm_TipoDocumento.Direction = ParameterDirection.Input;
                prm_TipoDocumento.Value = ListEnGS_Carta[0].CodTipoDocum;
                #endregion prm_TipoDocumento



                #endregion Values



                #region Execute
                SqlHelper.ExecuteNonQuery(tran, "GS_Carta_sp_Modificar",
                                               prm_id_carta,prm_Descripcion,
                                               prm_Pie,
                                               //prm_Num_carta, 
                                               prm_nEmpresa, prm_CodUsuario, prm_nombre, prm_TipoDocumento
                                               );
                #endregion Execute
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GS_Carta_Reg(List<EnGS_Carta> ListEnGS_Carta)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_Carta_sp_Registro";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[1];


                paramsToStore[0] = new SqlParameter("@id_carta", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_Carta[0].id_carta;

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

        public void GS_Carta_DEL(List<EnGS_Carta> ListEnGS_Carta, SqlTransaction tran)
        {
            try
            {
                #region Parametros
                SqlParameter prm_id_carta = new SqlParameter();
                SqlParameter prm_CodUsuario = new SqlParameter();
                #endregion Parametros


                #region Values

                #region prm_id_carta
                prm_id_carta.ParameterName = "@id_carta";
                prm_id_carta.SqlDbType = SqlDbType.Int;
                prm_id_carta.Direction = ParameterDirection.Input;
                prm_id_carta.Value = ListEnGS_Carta[0].id_carta;
                #endregion prm_id_carta

                #region prm_CodUsuario
                prm_CodUsuario.ParameterName = "@CodUsuarioRegistra";
                prm_CodUsuario.SqlDbType = SqlDbType.Int;
                prm_CodUsuario.Direction = ParameterDirection.Input;
                prm_CodUsuario.Value = ListEnGS_Carta[0].CodUsuario;
                #endregion prm_CodUsuario 

                #endregion Values

                #region Execute
                SqlHelper.ExecuteNonQuery(tran, "GS_Carta_sp_Eliminar",
                                               prm_id_carta, prm_CodUsuario
                                               );
                #endregion Execute
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





        public DataTable GS_Carta_Tipo_Documento_Combo()
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_TipoDocumen_sp_Listar";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;


                adp.Fill(DS, "DataTable1");
                dt = DS.Tables["DataTable1"];
                return dt;
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public int GS_ValidarCanalContacto(int idGestionCobranza)
        {
            int cantidadRegistros=0;
            try
            {
                #region Parametros
                SqlParameter prm_CANTIDAD = new SqlParameter();
                SqlParameter prm_IDVALIDAR = new SqlParameter();
                #endregion Parametros

                #region Values
                #region cantidadRegistros
                prm_IDVALIDAR.ParameterName = "@idValidarCanalContacto";
                prm_IDVALIDAR.SqlDbType = SqlDbType.Int;
                prm_IDVALIDAR.Direction = ParameterDirection.Input;
                prm_IDVALIDAR.Value = idGestionCobranza;
                #endregion cantidadRegistros
                #region cantidadRegistros
                prm_CANTIDAD.ParameterName = "@cantidadRegistros";
                prm_CANTIDAD.SqlDbType = SqlDbType.Int;
                prm_CANTIDAD.Direction = ParameterDirection.Output;
                #endregion cantidadRegistros
                #endregion Values

                #region Execute
                SqlHelper.ExecuteNonQuery(MSSQLConnectionString, CommandType.StoredProcedure, "CR_ClienteCanalContac_sp_Validar", prm_IDVALIDAR, prm_CANTIDAD);
                #endregion Execute
                cantidadRegistros = (int)prm_CANTIDAD.Value;
                return cantidadRegistros;
            }
            catch (Exception excp)
            {
                throw excp;
            }
            return cantidadRegistros;
        }

        public DataTable GS_Documento_Lista(List<EnGS_Carta> ListEnGS_Carta)
        { 
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_Documento_Listar";
                adp = new SqlDataAdapter(sqlCommand, conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore =new SqlParameter[3];

                paramsToStore[0] = new SqlParameter("@nEmpresa", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_Carta[0].nEmpresa;

                paramsToStore[1] = new SqlParameter("@idCarta", SqlDbType.Int);
                paramsToStore[1].Value = int.Parse(ListEnGS_Carta[0].id_carta);

                paramsToStore[2] = new SqlParameter("@codTipoDocumento", SqlDbType.Int);
                paramsToStore[2].Value = int.Parse(ListEnGS_Carta[0].CodTipoDocum);

                adp.SelectCommand.Parameters.AddRange(paramsToStore);

                adp.Fill(DS, "DataTable1");
                dt = DS.Tables["DataTable1"];

                return dt;

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public DataTable GS_TipoDocumento_Lista(List<EnGS_Carta> ListEnGS_Carta)
        { 
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_TipoDocumento_Listar";
                adp = new SqlDataAdapter(sqlCommand, conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore =new SqlParameter[1];

                paramsToStore[0] = new SqlParameter("@nEmpresa", SqlDbType.Int);
                paramsToStore[0].Value = int.Parse(ListEnGS_Carta[0].nEmpresa.ToString());

                adp.SelectCommand.Parameters.AddRange(paramsToStore);

                adp.Fill(DS, "DataTable1");
                dt = DS.Tables["DataTable1"];

                return dt;

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public DataTable GS_Documento_X_Tipo(List<EnGS_Carta> ListEnGS_Carta)
        { 
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_Documento_Listar";
                adp = new SqlDataAdapter(sqlCommand, conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore =new SqlParameter[2];

                paramsToStore[0] = new SqlParameter("@nEmpresa", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_Carta[0].nEmpresa;

                paramsToStore[1] = new SqlParameter("@codTipoDocumento", SqlDbType.Int);
                paramsToStore[1].Value = ListEnGS_Carta[0].CodTipoDocum;

                adp.SelectCommand.Parameters.AddRange(paramsToStore);

                adp.Fill(DS, "DataTable1");
                dt = DS.Tables["DataTable1"];

                return dt;

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }    
    }
}
