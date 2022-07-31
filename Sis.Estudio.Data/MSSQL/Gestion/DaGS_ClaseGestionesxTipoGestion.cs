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
    public class DaGS_ClaseGestionesxTipoGestion : DaConexion
    {

        public string GS_ClaseGestionesxTipoGestion_INS(List<EnGS_ClaseGestionesxTipoGestion> ListEnGS_ClaseGestionesxTipoGestion, SqlTransaction tran)
        {
            string IdReturn = String.Empty;
            SqlDataReader drParamReturn;


            SqlParameter prm_CodClaseGestion = new SqlParameter();
            SqlParameter prm_CodTipoGestion = new SqlParameter();
            try
            {

                #region Values


                #region prm_CodClaseGestion
                prm_CodClaseGestion.ParameterName = "@CodClaseGestion";
                prm_CodClaseGestion.SqlDbType = SqlDbType.Int;
                prm_CodClaseGestion.Direction = ParameterDirection.Input;
                prm_CodClaseGestion.Value = ListEnGS_ClaseGestionesxTipoGestion[0].CodClaseGestion;
                #endregion prm_CodClaseGestion
                #region prm_CodTipoGestion
                prm_CodTipoGestion.ParameterName = "@CodTipoGestion";
                prm_CodTipoGestion.SqlDbType = SqlDbType.Int;
                prm_CodTipoGestion.Direction = ParameterDirection.Input;
                prm_CodTipoGestion.Value = ListEnGS_ClaseGestionesxTipoGestion[0].CodTipoGestion;
                #endregion prm_CodTipoGestion


                #endregion Values


                drParamReturn = SqlHelper.ExecuteReader(tran, "dbo.GS_ClaseGestionesxTipoGestion_sp_Insertar",
                                               prm_CodClaseGestion,
                                               prm_CodTipoGestion
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


        public void GS_ClaseGestionesxTipoGestion_DEL(List<EnGS_ClaseGestionesxTipoGestion> ListEnGS_ClaseGestionesxTipoGestion, SqlTransaction tran)
        {
            try
            {
                #region Parametros
                SqlParameter prm_CodClaseGestion = new SqlParameter();
                #endregion Parametros


                #region Values

                #region prm_CodClaseGestion
                prm_CodClaseGestion.ParameterName = "@CodClaseGestion";
                prm_CodClaseGestion.SqlDbType = SqlDbType.Int;
                prm_CodClaseGestion.Direction = ParameterDirection.Input;
                prm_CodClaseGestion.Value = ListEnGS_ClaseGestionesxTipoGestion[0].CodClaseGestion;
                #endregion prm_CodClaseGestion

                #endregion Values

                #region Execute
                SqlHelper.ExecuteNonQuery(tran, "GS_ClaseGestionesxTipoGestion_sp_Eliminar",
                                               prm_CodClaseGestion
                                               );
                #endregion Execute
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GS_ClaseGestionesxTipoGestion_Lista(List<EnGS_ClaseGestionesxTipoGestion> ListEnGS_ClaseGestionesxTipoGestion)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_ClaseGestionesxTipoGestion_sp_Listar";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[1];

                paramsToStore[0] = new SqlParameter("@CodClaseGestion", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_ClaseGestionesxTipoGestion[0].CodClaseGestion;

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
