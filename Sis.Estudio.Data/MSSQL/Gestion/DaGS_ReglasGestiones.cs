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
    public class DaGS_ReglasGestiones : DaConexion
    {
        public DataTable GS_ReglasGestiones_ListaTodos(List<EnGS_ReglasGestiones> ListEnGS_ReglasGestiones)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_ReglasGestiones_sp_ListarTodos";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];

                paramsToStore[0] = new SqlParameter("@nEmepresa", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_ReglasGestiones[0].nempresa;


                paramsToStore[1] = new SqlParameter("@descripcion", SqlDbType.VarChar);
                paramsToStore[1].Value = ListEnGS_ReglasGestiones[0].descripcion;
                paramsToStore[1].Size = 250;

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
        public DataTable GS_ReglasGestiones_Lista(List<EnGS_ReglasGestiones> ListEnGS_ReglasGestiones)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_ReglasGestiones_sp_Listar";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[3];

                paramsToStore[0] = new SqlParameter("@nEmepresa", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_ReglasGestiones[0].nempresa;

                paramsToStore[1] = new SqlParameter("@Tramo", SqlDbType.Int);
                paramsToStore[1].Value = ListEnGS_ReglasGestiones[0].Tramo;


                paramsToStore[2] = new SqlParameter("@descripcion", SqlDbType.VarChar);
                paramsToStore[2].Value = ListEnGS_ReglasGestiones[0].descripcion;
                paramsToStore[2].Size = 250;

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

        public string GS_ReglasGestiones_INS(List<EnGS_ReglasGestiones> ListEnGS_ReglasGestiones, SqlTransaction tran)
        {
            string IdReturn = String.Empty;
            SqlDataReader drParamReturn;


            SqlParameter prm_Empresa = new SqlParameter();
            SqlParameter prm_id_ejecutores = new SqlParameter();
            SqlParameter prm_Tramo = new SqlParameter();

            SqlParameter prm_dias_mora_de = new SqlParameter();
            SqlParameter prm_dias_mora_hasta = new SqlParameter();
            SqlParameter prm_descripcion = new SqlParameter();
            SqlParameter prm_garantias = new SqlParameter();
            SqlParameter prm_provisiones = new SqlParameter();
            SqlParameter prm_CodUsuario = new SqlParameter();

            try
            {

                #region Values


                #region prm_Empresa
                prm_Empresa.ParameterName = "@nEmpresa";
                prm_Empresa.SqlDbType = SqlDbType.Int;
                prm_Empresa.Direction = ParameterDirection.Input;
                prm_Empresa.Value = ListEnGS_ReglasGestiones[0].nempresa;
                #endregion prm_Empresa

                #region prm_id_ejecutores
                prm_id_ejecutores.ParameterName = "@id_ejecutores";
                prm_id_ejecutores.SqlDbType = SqlDbType.Int;
                prm_id_ejecutores.Direction = ParameterDirection.Input;
                prm_id_ejecutores.Value = ListEnGS_ReglasGestiones[0].id_ejecutores;
                #endregion prm_id_ejecutores





                #region prm_Tramo
                prm_Tramo.ParameterName = "@Tramo";
                prm_Tramo.SqlDbType = SqlDbType.Int;
                prm_Tramo.Direction = ParameterDirection.Input;
                prm_Tramo.Value = ListEnGS_ReglasGestiones[0].Tramo;
                #endregion prm_Tramo

                #region prm_dias_mora_de
                prm_dias_mora_de.ParameterName = "@dias_mora_de";
                prm_dias_mora_de.SqlDbType = SqlDbType.Int;
                prm_dias_mora_de.Direction = ParameterDirection.Input;
                prm_dias_mora_de.Value = ListEnGS_ReglasGestiones[0].dias_mora_de;
                #endregion prm_dias_mora_de

                #region prm_dias_mora_hasta
                prm_dias_mora_hasta.ParameterName = "@dias_mora_hasta";
                prm_dias_mora_hasta.SqlDbType = SqlDbType.Int;
                prm_dias_mora_hasta.Direction = ParameterDirection.Input;
                prm_dias_mora_hasta.Value = ListEnGS_ReglasGestiones[0].dias_mora_hasta;
                #endregion prm_dias_mora_hasta

                #region prm_descripcion
                prm_descripcion.ParameterName = "@Descripcion";
                prm_descripcion.SqlDbType = SqlDbType.VarChar;
                prm_descripcion.Direction = ParameterDirection.Input;
                prm_descripcion.Size = 500;
                prm_descripcion.Value = ListEnGS_ReglasGestiones[0].descripcion;
                #endregion prm_descripcion

                #region prm_garantias
                prm_garantias.ParameterName = "@garantias";
                prm_garantias.SqlDbType = SqlDbType.VarChar;
                prm_garantias.Direction = ParameterDirection.Input;
                prm_garantias.Size = 1;
                prm_garantias.Value = ListEnGS_ReglasGestiones[0].garantias;
                #endregion prm_garantias

                #region prm_provisiones
                prm_provisiones.ParameterName = "@proviciones";
                prm_provisiones.SqlDbType = SqlDbType.VarChar;
                prm_provisiones.Direction = ParameterDirection.Input;
                prm_provisiones.Size = 1;
                prm_provisiones.Value = ListEnGS_ReglasGestiones[0].provisiones;
                #endregion prm_provisiones

                #region prm_CodUsuario
                prm_CodUsuario.ParameterName = "@CodUsuarioRegistra";
                prm_CodUsuario.SqlDbType = SqlDbType.Int;
                prm_CodUsuario.Direction = ParameterDirection.Input;
                prm_CodUsuario.Value = ListEnGS_ReglasGestiones[0].CodUsuario;
                #endregion prm_CodUsuario

                #endregion Values


                drParamReturn = SqlHelper.ExecuteReader(tran, "dbo.GS_ReglasGestiones_sp_Insertar",
                                               prm_Empresa, prm_id_ejecutores, prm_Tramo, prm_dias_mora_de, prm_dias_mora_hasta,
                                               prm_descripcion, prm_garantias, prm_provisiones, prm_CodUsuario
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

        public void GS_ReglasGestiones_UPD(List<EnGS_ReglasGestiones> ListEnGS_ReglasGestiones, SqlTransaction tran)
        {
            try
            {
                #region Parametros

                SqlParameter prm_id_ReglasGestiones = new SqlParameter();
                SqlParameter prm_Empresa = new SqlParameter();
                SqlParameter prm_id_ejecutores = new SqlParameter();
                SqlParameter prm_Tramo = new SqlParameter();
                SqlParameter prm_dias_mora_de = new SqlParameter();
                SqlParameter prm_dias_mora_hasta = new SqlParameter();
                SqlParameter prm_descripcion = new SqlParameter();
                SqlParameter prm_garantias = new SqlParameter();
                SqlParameter prm_provisiones = new SqlParameter();
                SqlParameter prm_CodUsuario = new SqlParameter();



                #endregion Parametros


                #region Values

                #region prm_id_ReglasGestiones
                prm_id_ReglasGestiones.ParameterName = "@id_ReglasGestiones";
                prm_id_ReglasGestiones.SqlDbType = SqlDbType.Int;
                prm_id_ReglasGestiones.Direction = ParameterDirection.Input;
                prm_id_ReglasGestiones.Value = ListEnGS_ReglasGestiones[0].id_ReglasGestiones;
                #endregion prm_id_ReglasGestiones

                #region prm_Empresa
                prm_Empresa.ParameterName = "@nEmpresa";
                prm_Empresa.SqlDbType = SqlDbType.Int;
                prm_Empresa.Direction = ParameterDirection.Input;
                prm_Empresa.Value = ListEnGS_ReglasGestiones[0].nempresa;
                #endregion prm_Empresa

                #region prm_id_ejecutores
                prm_id_ejecutores.ParameterName = "@id_ejecutores";
                prm_id_ejecutores.SqlDbType = SqlDbType.Int;
                prm_id_ejecutores.Direction = ParameterDirection.Input;
                prm_id_ejecutores.Value = ListEnGS_ReglasGestiones[0].id_ejecutores;
                #endregion prm_id_ejecutores


                #region prm_Tramo
                prm_Tramo.ParameterName = "@Tramo";
                prm_Tramo.SqlDbType = SqlDbType.Int;
                prm_Tramo.Direction = ParameterDirection.Input;
                prm_Tramo.Value = ListEnGS_ReglasGestiones[0].Tramo;
                #endregion prm_Tramo



                #region prm_dias_mora_de
                prm_dias_mora_de.ParameterName = "@dias_mora_de";
                prm_dias_mora_de.SqlDbType = SqlDbType.Int;
                prm_dias_mora_de.Direction = ParameterDirection.Input;
                prm_dias_mora_de.Value = ListEnGS_ReglasGestiones[0].dias_mora_de;
                #endregion prm_dias_mora_de

                #region prm_dias_mora_hasta
                prm_dias_mora_hasta.ParameterName = "@dias_mora_hasta";
                prm_dias_mora_hasta.SqlDbType = SqlDbType.Int;
                prm_dias_mora_hasta.Direction = ParameterDirection.Input;
                prm_dias_mora_hasta.Value = ListEnGS_ReglasGestiones[0].dias_mora_hasta;
                #endregion prm_dias_mora_hasta

                #region prm_descripcion
                prm_descripcion.ParameterName = "@Descripcion";
                prm_descripcion.SqlDbType = SqlDbType.VarChar;
                prm_descripcion.Direction = ParameterDirection.Input;
                prm_descripcion.Size = 500;
                prm_descripcion.Value = ListEnGS_ReglasGestiones[0].descripcion;
                #endregion prm_descripcion

                #region prm_garantias
                prm_garantias.ParameterName = "@garantias";
                prm_garantias.SqlDbType = SqlDbType.VarChar;
                prm_garantias.Direction = ParameterDirection.Input;
                prm_garantias.Size = 1;
                prm_garantias.Value = ListEnGS_ReglasGestiones[0].garantias;
                #endregion prm_garantias

                #region prm_provisiones
                prm_provisiones.ParameterName = "@proviciones";
                prm_provisiones.SqlDbType = SqlDbType.VarChar;
                prm_provisiones.Direction = ParameterDirection.Input;
                prm_provisiones.Size = 1;
                prm_provisiones.Value = ListEnGS_ReglasGestiones[0].provisiones;
                #endregion prm_provisiones

                #region prm_CodUsuario
                prm_CodUsuario.ParameterName = "@CodUsuarioRegistra";
                prm_CodUsuario.SqlDbType = SqlDbType.Int;
                prm_CodUsuario.Direction = ParameterDirection.Input;
                prm_CodUsuario.Value = ListEnGS_ReglasGestiones[0].CodUsuario;
                #endregion prm_CodUsuario



                #endregion Values



                #region Execute
                SqlHelper.ExecuteNonQuery(tran, "GS_ReglasGestiones_sp_Modificar",
                                                prm_id_ReglasGestiones,
                                               prm_Empresa, prm_id_ejecutores,prm_Tramo, prm_dias_mora_de, prm_dias_mora_hasta,
                                               prm_descripcion, prm_garantias, prm_provisiones, prm_CodUsuario
                                               );
                #endregion Execute
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GS_ReglasGestiones_Reg(List<EnGS_ReglasGestiones> ListEnGS_ReglasGestiones)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_ReglasGestiones_sp_Registro";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[1];


                paramsToStore[0] = new SqlParameter("@id_ReglasGestiones", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_ReglasGestiones[0].id_ReglasGestiones;

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

        public void GS_ReglasGestiones_DEL(List<EnGS_ReglasGestiones> ListEnGS_ReglasGestiones, SqlTransaction tran)
        {
            try
            {
                #region Parametros
                SqlParameter prm_id_ReglasGestiones = new SqlParameter();
                SqlParameter prm_CodUsuario = new SqlParameter();
                #endregion Parametros


                #region Values

                #region prm_id_ReglasGestiones
                prm_id_ReglasGestiones.ParameterName = "@id_ReglasGestiones";
                prm_id_ReglasGestiones.SqlDbType = SqlDbType.Int;
                prm_id_ReglasGestiones.Direction = ParameterDirection.Input;
                prm_id_ReglasGestiones.Value = ListEnGS_ReglasGestiones[0].id_ReglasGestiones;
                #endregion prm_CodClaseGestion

                #region prm_CodUsuario
                prm_CodUsuario.ParameterName = "@CodUsuarioRegistra";
                prm_CodUsuario.SqlDbType = SqlDbType.Int;
                prm_CodUsuario.Direction = ParameterDirection.Input;
                prm_CodUsuario.Value = ListEnGS_ReglasGestiones[0].CodUsuario;
                #endregion prm_CodUsuario

                #endregion Values

                #region Execute
                SqlHelper.ExecuteNonQuery(tran, "GS_ReglasGestiones_sp_Eliminar",
                                               prm_id_ReglasGestiones, prm_CodUsuario
                                               );
                #endregion Execute
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GS_Empresa_Combo()
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_Empresa_sp_Listar_Combo";
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


        public DataTable GS_Tramo_Combo()
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_Tramo_sp_Listar_Combo";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[1];


                paramsToStore[0] = new SqlParameter("@CodEmpresa", SqlDbType.Int);
                paramsToStore[0].Value = 1;//Falta implementar empresas

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

        public DataTable GS_Tramo_Combo(List<EnGS_ReglasGestiones> ListEnGS_ReglasGestiones)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_Tramo_sp_Listar_Combo";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[1];


                paramsToStore[0] = new SqlParameter("@CodEmpresa", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_ReglasGestiones[0].nempresa;

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
