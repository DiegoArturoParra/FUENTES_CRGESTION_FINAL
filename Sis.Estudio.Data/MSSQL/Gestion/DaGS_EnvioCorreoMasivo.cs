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
    public class DaGS_EnvioCorreoMasivo : DaConexion
    {

        public DataTable GS_EnvioCorreoMasivo_Lista(List<EnGS_EnvioCorreoMasivo> ListEnGS_EnvioCorreoMasivo)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_EnvioCorreoMasivo_sp_Listar";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[1];

                paramsToStore[0] = new SqlParameter("@nEmpresa", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_EnvioCorreoMasivo[0].nEmpresa;

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

        public void GS_EnvioCorreoMasivo_DEL(List<EnGS_EnvioCorreoMasivo> ListEnGS_EnvioCorreoMasivo, SqlTransaction tran)
        {
            try
            {
                #region Parametros
                SqlParameter prm_nEmpresa = new SqlParameter();
                #endregion Parametros


                #region Values

                #region prm_nEmpresa
                prm_nEmpresa.ParameterName = "@nEmpresa";
                prm_nEmpresa.SqlDbType = SqlDbType.Int;
                prm_nEmpresa.Direction = ParameterDirection.Input;
                prm_nEmpresa.Value = ListEnGS_EnvioCorreoMasivo[0].nEmpresa;
                #endregion prm_nEmpresa



                #endregion Values

                #region Execute
                SqlHelper.ExecuteNonQuery(tran, "GS_EnvioCorreoMasivo_sp_Eliminar",
                                               prm_nEmpresa
                                               );
                #endregion Execute
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GS_EnvioCorreoMasivo_UPD(List<EnGS_EnvioCorreoMasivo> ListEnGS_EnvioCorreoMasivo, SqlTransaction tran)
        {
            try
            {
                #region Parametros
                SqlParameter prm_nEmpresa = new SqlParameter();
                #endregion Parametros


                #region Values

                #region prm_nEmpresa
                prm_nEmpresa.ParameterName = "@nEmpresa";
                prm_nEmpresa.SqlDbType = SqlDbType.Int;
                prm_nEmpresa.Direction = ParameterDirection.Input;
                prm_nEmpresa.Value = ListEnGS_EnvioCorreoMasivo[0].nEmpresa;
                #endregion prm_nEmpresa

                #endregion Values



                #region Execute
                SqlHelper.ExecuteNonQuery(tran, "GS_EnvioCorreoMasivo_sp_Modificar",
                                               prm_nEmpresa
                                               );
                #endregion Execute
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public String mxInsertarRegistrosAEnvioCorreoMasivo(List<EnGS_EnvioCorreoMasivo> ListEnGS_EnvioCorreoMasivo, SqlTransaction tran)
        {
            string IdReturn = String.Empty;
            SqlDataReader drParamReturn;

            SqlParameter prm_nIdGestionCobranza = new SqlParameter();
            SqlParameter prm_nEmpresa = new SqlParameter();
            SqlParameter prm_cCorreoRemitente = new SqlParameter();
            SqlParameter prm_cCorreoDestino = new SqlParameter();
            SqlParameter prm_cCorreoAsunto = new SqlParameter();
            SqlParameter prm_cCorreoCuerpo = new SqlParameter();
            SqlParameter prm_dFechaEnvio = new SqlParameter();
            SqlParameter prm_cEstado = new SqlParameter();

            try
            {

                #region Values

                prm_nIdGestionCobranza.ParameterName = "@IdReg_Gestion_Cobranza";
                prm_nIdGestionCobranza.SqlDbType = SqlDbType.Int;
                prm_nIdGestionCobranza.Direction = ParameterDirection.Input;
                prm_nIdGestionCobranza.Value = ListEnGS_EnvioCorreoMasivo[0].Id_Reg_Gestion_Cobranza;

                prm_nEmpresa.ParameterName = "@nEmpresa";
                prm_nEmpresa.SqlDbType = SqlDbType.Int;
                prm_nEmpresa.Direction = ParameterDirection.Input;
                prm_nEmpresa.Value = ListEnGS_EnvioCorreoMasivo[0].nEmpresa;

                prm_cCorreoRemitente.ParameterName = "@cCorreoRemitente";
                prm_cCorreoRemitente.SqlDbType = SqlDbType.NVarChar;
                prm_cCorreoRemitente.Direction = ParameterDirection.Input;
                prm_cCorreoRemitente.Size = 3000;
                prm_cCorreoRemitente.Value = ListEnGS_EnvioCorreoMasivo[0].correo_remitente;

                prm_cCorreoDestino.ParameterName = "@cCorreoDestino";
                prm_cCorreoDestino.SqlDbType = SqlDbType.NVarChar;
                prm_cCorreoDestino.Direction = ParameterDirection.Input;
                prm_cCorreoDestino.Size = 3000;
                prm_cCorreoDestino.Value = ListEnGS_EnvioCorreoMasivo[0].correo_destinatario;

                prm_cCorreoAsunto.ParameterName = "@cCorreoAsunto";
                prm_cCorreoAsunto.SqlDbType = SqlDbType.NVarChar;
                prm_cCorreoAsunto.Direction = ParameterDirection.Input;
                prm_cCorreoAsunto.Size = 3000;
                prm_cCorreoAsunto.Value = ListEnGS_EnvioCorreoMasivo[0].correo_asunto;

                prm_cCorreoCuerpo.ParameterName = "@cCorreoCuerpo";
                prm_cCorreoCuerpo.SqlDbType = SqlDbType.NVarChar;
                prm_cCorreoCuerpo.Direction = ParameterDirection.Input;
                prm_cCorreoCuerpo.Size = 3000;
                prm_cCorreoCuerpo.Value = ListEnGS_EnvioCorreoMasivo[0].correo_cuerpo;

                /*prm_dFechaEnvio.ParameterName = "@dFechaEnvio";
                prm_dFechaEnvio.SqlDbType = SqlDbType.DateTime;
                prm_dFechaEnvio.Direction = ParameterDirection.Input;
                prm_dFechaEnvio.Value = ListEnGS_Gestion_Cobranza[0].dFechaEnvio;

                prm_cEstado.ParameterName = "@cEstado";
                prm_cEstado.SqlDbType = SqlDbType.VarChar;
                prm_cEstado.Direction = ParameterDirection.Input;
                prm_cEstado.Size = 50;
                prm_cEstado.Value = ListEnGS_Gestion_Cobranza[0].;*/

                #endregion Values


                drParamReturn = SqlHelper.ExecuteReader(tran, "GS_EnvioCorreoMasivo_sp_Insertar",
                                               prm_nIdGestionCobranza, prm_nEmpresa, prm_cCorreoRemitente, prm_cCorreoDestino, prm_cCorreoAsunto, prm_cCorreoCuerpo
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
    }
}
