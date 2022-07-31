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
    public class DaGS_ReglasGestionesxEjecutado : DaConexion
    {

        public string GS_ReglasGestionesxEjecutado_INS(List<EnGS_ReglasGestionesxEjecutado> ListEnGS_ReglasGestionesxEjecutado, SqlTransaction tran)
        {
            string IdReturn = String.Empty;
            SqlDataReader drParamReturn;


            SqlParameter prm_id_ReglasGestiones = new SqlParameter();
            SqlParameter prm_CodEjecutado = new SqlParameter();
            try
            {

                #region Values


                #region prm_id_ReglasGestiones
                prm_id_ReglasGestiones.ParameterName = "@id_ReglasGestiones";
                prm_id_ReglasGestiones.SqlDbType = SqlDbType.Int;
                prm_id_ReglasGestiones.Direction = ParameterDirection.Input;
                prm_id_ReglasGestiones.Value = ListEnGS_ReglasGestionesxEjecutado[0].id_ReglasGestiones;
                #endregion prm_id_ReglasGestiones
                #region prm_CodEjecutado
                prm_CodEjecutado.ParameterName = "@CodEjecutado";
                prm_CodEjecutado.SqlDbType = SqlDbType.Int;
                prm_CodEjecutado.Direction = ParameterDirection.Input;
                prm_CodEjecutado.Value = ListEnGS_ReglasGestionesxEjecutado[0].CodEjecutado;
                #endregion prm_CodEjecutado


                #endregion Values


                drParamReturn = SqlHelper.ExecuteReader(tran, "dbo.GS_ReglasGestionesxEjecutado_sp_Insertar",
                                               prm_id_ReglasGestiones,
                                               prm_CodEjecutado
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


        public void GS_ReglasGestionesxEjecutado_DEL(List<EnGS_ReglasGestionesxEjecutado> ListEnGS_ReglasGestionesxEjecutado, SqlTransaction tran)
        {
            try
            {
                #region Parametros
                SqlParameter prm_id_ReglasGestiones = new SqlParameter();
                #endregion Parametros


                #region Values

                #region prm_id_ReglasGestiones
                prm_id_ReglasGestiones.ParameterName = "@id_ReglasGestiones";
                prm_id_ReglasGestiones.SqlDbType = SqlDbType.Int;
                prm_id_ReglasGestiones.Direction = ParameterDirection.Input;
                prm_id_ReglasGestiones.Value = ListEnGS_ReglasGestionesxEjecutado[0].id_ReglasGestiones;
                #endregion prm_id_ReglasGestiones

                #endregion Values

                #region Execute
                SqlHelper.ExecuteNonQuery(tran, "GS_ReglasGestionesxEjecutado_sp_Eliminar",
                                               prm_id_ReglasGestiones
                                               );
                #endregion Execute
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GS_ReglasGestionesxEjecutado_Lista(List<EnGS_ReglasGestionesxEjecutado> ListEnGS_ReglasGestionesxEjecutado)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_ReglasGestionesxEjecutado_sp_Listar";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[1];

                paramsToStore[0] = new SqlParameter("@id_ReglasGestiones", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_ReglasGestionesxEjecutado[0].id_ReglasGestiones;

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
