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
    public class DaCalificacionSBS : DaConexion
    {
        
        public string CalificacionSBS_INS(List<EnCalificacionSBS> ListEnCalificacionSBS, SqlTransaction tran)
        {
            string IdReturn = String.Empty;
            SqlDataReader drParamReturn;
            try
            {
                #region Parametros
                SqlParameter prm_CALIFICACIONSBS = new SqlParameter();
                SqlParameter prm_INIDIASMORA = new SqlParameter();
                SqlParameter prm_FINDIASMORA = new SqlParameter();
                SqlParameter prm_ESTADO = new SqlParameter();
                SqlParameter prm_CODUSUARIO = new SqlParameter();
                #endregion Parametros


                #region Values
                
                #region CalificacionSBS
                prm_CALIFICACIONSBS.ParameterName = "@CalificacionSBS";
                prm_CALIFICACIONSBS.SqlDbType = SqlDbType.VarChar;
                prm_CALIFICACIONSBS.Direction = ParameterDirection.Input;
                prm_CALIFICACIONSBS.Size = 60;
                prm_CALIFICACIONSBS.Value = ListEnCalificacionSBS[0].CalificacionSBS;
                #endregion CalificacionSBS
                #region IniDiasMora
                prm_INIDIASMORA.ParameterName = "@IniDiasMora";
                prm_INIDIASMORA.SqlDbType = SqlDbType.Int;
                prm_INIDIASMORA.Direction = ParameterDirection.Input;
                prm_INIDIASMORA.Value = ListEnCalificacionSBS[0].IniDiasMora;
                #endregion IniDiasMora
                #region FinDiasMora
                prm_FINDIASMORA.ParameterName = "@FinDiasMora";
                prm_FINDIASMORA.SqlDbType = SqlDbType.Int;
                prm_FINDIASMORA.Direction = ParameterDirection.Input;
                prm_FINDIASMORA.Value = ListEnCalificacionSBS[0].FinDiasMora;
                #endregion FinDiasMora
                #region Estado
                prm_ESTADO.ParameterName = "@Estado";
                prm_ESTADO.SqlDbType = SqlDbType.Char;
                prm_ESTADO.Direction = ParameterDirection.Input;
                prm_ESTADO.Size = 1;
                prm_ESTADO.Value = ListEnCalificacionSBS[0].Estado;
                #endregion Estado
                #region CodUsuario
                prm_CODUSUARIO.ParameterName = "@CodUsuario";
                prm_CODUSUARIO.SqlDbType = SqlDbType.Int;
                prm_CODUSUARIO.Direction = ParameterDirection.Input;
                prm_CODUSUARIO.Value = ListEnCalificacionSBS[0].CodUsuario;
                #endregion CodUsuario
                #endregion Values

                #region Execute
                drParamReturn = SqlHelper.ExecuteReader(tran, "CR_CalificacionSBS_sp_Insertar",                                               
                                               prm_CALIFICACIONSBS,
                                               prm_INIDIASMORA,
                                               prm_FINDIASMORA,
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
        public void CalificacionSBS_UPD(List<EnCalificacionSBS> ListEnCalificacionSBS, SqlTransaction tran)
        {
            try
            {
                #region Parametros
                SqlParameter prm_CODCALIFICACIONSBS = new SqlParameter();
                SqlParameter prm_CALIFICACIONSBS = new SqlParameter();
                SqlParameter prm_INIDIASMORA = new SqlParameter();
                SqlParameter prm_FINDIASMORA = new SqlParameter();
                SqlParameter prm_ESTADO = new SqlParameter();
                SqlParameter prm_CODUSUARIO = new SqlParameter();
                #endregion Parametros

                #region Values
                #region CodCalificacionSBS
                prm_CODCALIFICACIONSBS.ParameterName = "@CodCalificacionSBS";
                prm_CODCALIFICACIONSBS.SqlDbType = SqlDbType.Int;
                prm_CODCALIFICACIONSBS.Direction = ParameterDirection.Input;
                prm_CODCALIFICACIONSBS.Value = ListEnCalificacionSBS[0].CodCalificacionSBS;
                #endregion CodCalificacionSBS
                #region CalificacionSBS
                prm_CALIFICACIONSBS.ParameterName = "@CalificacionSBS";
                prm_CALIFICACIONSBS.SqlDbType = SqlDbType.VarChar;
                prm_CALIFICACIONSBS.Direction = ParameterDirection.Input;
                prm_CALIFICACIONSBS.Size = 60;
                prm_CALIFICACIONSBS.Value = ListEnCalificacionSBS[0].CalificacionSBS;
                #endregion CalificacionSBS
                #region IniDiasMora
                prm_INIDIASMORA.ParameterName = "@IniDiasMora";
                prm_INIDIASMORA.SqlDbType = SqlDbType.Int;
                prm_INIDIASMORA.Direction = ParameterDirection.Input;
                prm_INIDIASMORA.Value = ListEnCalificacionSBS[0].IniDiasMora;
                #endregion IniDiasMora
                #region FinDiasMora
                prm_FINDIASMORA.ParameterName = "@FinDiasMora";
                prm_FINDIASMORA.SqlDbType = SqlDbType.Int;
                prm_FINDIASMORA.Direction = ParameterDirection.Input;
                prm_FINDIASMORA.Value = ListEnCalificacionSBS[0].FinDiasMora;
                #endregion FinDiasMora
                #region Estado
                prm_ESTADO.ParameterName = "@Estado";
                prm_ESTADO.SqlDbType = SqlDbType.Char;
                prm_ESTADO.Direction = ParameterDirection.Input;
                prm_ESTADO.Size = 1;
                prm_ESTADO.Value = ListEnCalificacionSBS[0].Estado;
                #endregion Estado
                #region CodUsuario
                prm_CODUSUARIO.ParameterName = "@CodUsuario";
                prm_CODUSUARIO.SqlDbType = SqlDbType.Int;
                prm_CODUSUARIO.Direction = ParameterDirection.Input;
                prm_CODUSUARIO.Value = ListEnCalificacionSBS[0].CodUsuario;
                #endregion CodUsuario
                #endregion Values

                #region Execute
                SqlHelper.ExecuteNonQuery(tran, "CR_CalificacionSBS_sp_Modificar",
                                               prm_CODCALIFICACIONSBS,
                                               prm_CALIFICACIONSBS,
                                               prm_INIDIASMORA,
                                               prm_FINDIASMORA,
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
        public DataTable CalificacionSBS_Listar_Reg(List<EnCalificacionSBS> ListEnCalificacionSBS)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "CR_CalificacionSBS_sp_CargaREG";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];

                paramsToStore[0] = new SqlParameter("@NEMPRESA", SqlDbType.Int);
                paramsToStore[0].Value = ListEnCalificacionSBS[0].NEmpresa;

                paramsToStore[1] = new SqlParameter("@CodCalificacionSBS", SqlDbType.Int);
                paramsToStore[1].Value = ListEnCalificacionSBS[0].CodCalificacionSBS;

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
        public DataTable CalificacionSBS_Listar()
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "CR_Cliente_sp_EstadoCalificacionSBS";
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

    }
}
