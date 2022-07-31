using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Sis.Estudio.Entity;

namespace Sis.Estudio.Data.MSSQL.Estudio
{
    public class DaSubProducto : DaConexion
    {

        public string SubProducto_INS(List<EnSubProducto> ListEnSubProducto, SqlTransaction tran)
        {
            string IdReturn = String.Empty;
            SqlDataReader drParamReturn;
            try
            {
                #region Parametros
                SqlParameter prm_NEMPRESA = new SqlParameter();
                SqlParameter prm_CODPRODUCTO = new SqlParameter();
                SqlParameter prm_CODSUBPRODUCTO = new SqlParameter();
                SqlParameter prm_SUBPRODUCTO = new SqlParameter();
                SqlParameter prm_CODIGOINTERNO = new SqlParameter();
                SqlParameter prm_ESTADO = new SqlParameter();
                SqlParameter prm_CODUSUARIO = new SqlParameter();
                #endregion Parametros

                #region Values
                #region NEmpresa
                prm_NEMPRESA.ParameterName = "@NEmpresa";
                prm_NEMPRESA.SqlDbType = SqlDbType.Int;
                prm_NEMPRESA.Direction = ParameterDirection.Input;
                prm_NEMPRESA.Value = ListEnSubProducto[0].NEmpresa;
                #endregion NEmpresa
                #region CodProducto
                prm_CODPRODUCTO.ParameterName = "@CodProducto";
                prm_CODPRODUCTO.SqlDbType = SqlDbType.Int;
                prm_CODPRODUCTO.Direction = ParameterDirection.Input;
                prm_CODPRODUCTO.Value = ListEnSubProducto[0].CodProducto;
                #endregion CodProducto
                #region CodSubProducto
                prm_CODSUBPRODUCTO.ParameterName = "@CodSubProducto";
                prm_CODSUBPRODUCTO.SqlDbType = SqlDbType.Int;
                prm_CODSUBPRODUCTO.Direction = ParameterDirection.Input;
                prm_CODSUBPRODUCTO.Value = ListEnSubProducto[0].CodSubProducto;
                #endregion CodSubProducto
                #region SubProducto
                prm_SUBPRODUCTO.ParameterName = "@SubProducto";
                prm_SUBPRODUCTO.SqlDbType = SqlDbType.VarChar;
                prm_SUBPRODUCTO.Direction = ParameterDirection.Input;
                prm_SUBPRODUCTO.Size = 120;
                prm_SUBPRODUCTO.Value = ListEnSubProducto[0].SubProducto;
                #endregion SubProducto
                #region CodigoInterno
                prm_CODIGOINTERNO.ParameterName = "@CodigoInterno";
                prm_CODIGOINTERNO.SqlDbType = SqlDbType.Int;
                prm_CODIGOINTERNO.Direction = ParameterDirection.Input;
                prm_CODIGOINTERNO.Value = ListEnSubProducto[0].CodigoInterno;
                #endregion CodigoInterno
                #region Estado
                prm_ESTADO.ParameterName = "@Estado";
                prm_ESTADO.SqlDbType = SqlDbType.Char;
                prm_ESTADO.Direction = ParameterDirection.Input;
                prm_ESTADO.Size = 1;
                prm_ESTADO.Value = ListEnSubProducto[0].Estado;
                #endregion Estado
                #region CodUsuario
                prm_CODUSUARIO.ParameterName = "@CodUsuario";
                prm_CODUSUARIO.SqlDbType = SqlDbType.Int;
                prm_CODUSUARIO.Direction = ParameterDirection.Input;
                prm_CODUSUARIO.Value = ListEnSubProducto[0].CodUsuario;
                #endregion CodUsuario
                #endregion Values

                #region Execute
                drParamReturn = SqlHelper.ExecuteReader(tran, "CR_SubProducto_sp_Insertar",
                                               prm_NEMPRESA,
                                               prm_CODPRODUCTO,
                                               prm_CODSUBPRODUCTO,
                                               prm_SUBPRODUCTO,
                                               prm_CODIGOINTERNO,
                                               prm_ESTADO,
                                               prm_CODUSUARIO
                                               );
                #endregion Execute

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
        public void SubProducto_UPD(List<EnSubProducto> ListEnSubProducto, SqlTransaction tran)
        {
            try
            {
                #region Parametros
                SqlParameter prm_NEMPRESA = new SqlParameter();
                SqlParameter prm_CODPRODUCTO = new SqlParameter();
                SqlParameter prm_CODSUBPRODUCTO = new SqlParameter();
                SqlParameter prm_SUBPRODUCTO = new SqlParameter();
                SqlParameter prm_CODIGOINTERNO = new SqlParameter();
                SqlParameter prm_ESTADO = new SqlParameter();
                SqlParameter prm_CODUSUARIO = new SqlParameter();
                #endregion Parametros


                #region Values

                #region NEmpresa
                prm_NEMPRESA.ParameterName = "@nempresa";
                prm_NEMPRESA.SqlDbType = SqlDbType.Int;
                prm_NEMPRESA.Direction = ParameterDirection.Input;
                prm_NEMPRESA.Value = ListEnSubProducto[0].NEmpresa;
                #endregion NEmpresa

                #region CodProducto
                prm_CODPRODUCTO.ParameterName = "@CodProducto";
                prm_CODPRODUCTO.SqlDbType = SqlDbType.Int;
                prm_CODPRODUCTO.Direction = ParameterDirection.Input;
                prm_CODPRODUCTO.Value = ListEnSubProducto[0].CodProducto;
                #endregion CodProducto
                #region CodSubProducto
                prm_CODSUBPRODUCTO.ParameterName = "@CodSubProducto";
                prm_CODSUBPRODUCTO.SqlDbType = SqlDbType.Int;
                prm_CODSUBPRODUCTO.Direction = ParameterDirection.Input;
                prm_CODSUBPRODUCTO.Value = ListEnSubProducto[0].CodSubProducto;
                #endregion CodSubProducto
                #region SubProducto
                prm_SUBPRODUCTO.ParameterName = "@SubProducto";
                prm_SUBPRODUCTO.SqlDbType = SqlDbType.VarChar;
                prm_SUBPRODUCTO.Direction = ParameterDirection.Input;
                prm_SUBPRODUCTO.Size = 120;
                prm_SUBPRODUCTO.Value = ListEnSubProducto[0].SubProducto;
                #endregion SubProducto
                #region CodigoInterno
                prm_CODIGOINTERNO.ParameterName = "@CodigoInterno";
                prm_CODIGOINTERNO.SqlDbType = SqlDbType.Int;
                prm_CODIGOINTERNO.Direction = ParameterDirection.Input;
                prm_CODIGOINTERNO.Value = ListEnSubProducto[0].CodigoInterno;
                #endregion CodigoInterno
                #region Estado
                prm_ESTADO.ParameterName = "@Estado";
                prm_ESTADO.SqlDbType = SqlDbType.Char;
                prm_ESTADO.Direction = ParameterDirection.Input;
                prm_ESTADO.Size = 1;
                prm_ESTADO.Value = ListEnSubProducto[0].Estado;
                #endregion Estado
                #region CodUsuario
                prm_CODUSUARIO.ParameterName = "@CodUsuario";
                prm_CODUSUARIO.SqlDbType = SqlDbType.Int;
                prm_CODUSUARIO.Direction = ParameterDirection.Input;
                prm_CODUSUARIO.Value = ListEnSubProducto[0].CodUsuario;
                #endregion CodUsuario
                #endregion Values



                #region Execute
                SqlHelper.ExecuteNonQuery(tran, "CR_SubProducto_sp_Modificar",
                                               prm_NEMPRESA,
                                               prm_CODPRODUCTO,
                                               prm_CODSUBPRODUCTO,
                                               prm_SUBPRODUCTO,
                                               prm_CODIGOINTERNO,
                                               prm_ESTADO,
                                               prm_CODUSUARIO
                                               );
                #endregion Execute
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SubProducto_Listar(List<EnSubProducto> ListEnSubProducto)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "CR_SubProducto_sp_Carga";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[1];

                paramsToStore[0] = new SqlParameter("@NEMPRESA", SqlDbType.Int);
                paramsToStore[0].Value = ListEnSubProducto[0].NEmpresa;

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
        public DataTable SubProducto_Listar_Reg(List<EnSubProducto> ListEnSubProducto)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "CR_SubProducto_sp_CargaREG";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];

                paramsToStore[0] = new SqlParameter("@NEMPRESA", SqlDbType.Int);
                paramsToStore[0].Value = ListEnSubProducto[0].NEmpresa;

                paramsToStore[1] = new SqlParameter("@CodSubProducto", SqlDbType.Int);
                paramsToStore[1].Value = ListEnSubProducto[0].CodSubProducto;

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
        public DataTable SubProducto_Listar_X_Producto(List<EnSubProducto> ListEnSubProducto)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                                 
                sqlCommand = "CR_Cliente_sp_SubProducto";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];

                paramsToStore[0] = new SqlParameter("@NEmpresa", SqlDbType.Int);
                paramsToStore[0].Value = ListEnSubProducto[0].NEmpresa;

                paramsToStore[1] = new SqlParameter("@CodProducto", SqlDbType.Int);
                paramsToStore[1].Value = ListEnSubProducto[0].CodProducto;

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

    }
}
