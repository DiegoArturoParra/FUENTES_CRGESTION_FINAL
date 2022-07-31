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
    public class DaDatosCliente : DaConexion
    {
        public int CodigoCliente_Dni(EnDatosCliente EnDatosCliente)
        {
            int codigoCliente = 0;
            SqlConnection Conn = new SqlConnection();
            Conn = new SqlConnection(MSSQLConnectionString);
            Conn.Open();
            String dni = EnDatosCliente.DNI.ToString();

            using (SqlConnection conexion = Conn)
            {
                SqlCommand cmd = new SqlCommand("CR_Cliente_sp_ObtenerCodigoPorDni", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@dni", dni));
                SqlParameter codigo = new SqlParameter("@codigo", SqlDbType.Decimal);
                codigo.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(codigo);
                //Conn.Open();
                cmd.ExecuteNonQuery();
                codigoCliente = Int32.Parse(cmd.Parameters["@codigo"].Value.ToString());

                return codigoCliente;
            }
            Conn.Close();
        }
        public DataTable DatosCliente_Lista_Reg(List<EnDatosCliente> ListEnDatosCliente)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "CR_Cliente_sp_CargaCliente";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];

                paramsToStore[0] = new SqlParameter("@NEMPRESA", SqlDbType.Int);
                paramsToStore[0].Value = ListEnDatosCliente[0].NEMPRESA;

                paramsToStore[1] = new SqlParameter("@CodigoCliente", SqlDbType.Int);
                paramsToStore[1].Value = ListEnDatosCliente[0].CodigoCliente;

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
        public void DatosCliente_UPD(List<EnDatosCliente> ListEnDatosCliente, SqlTransaction tran)
        {
            try
            {
                #region Parametros
                SqlParameter prm_NEMPRESA = new SqlParameter();
                SqlParameter prm_CODIGOCLIENTE = new SqlParameter();
                SqlParameter prm_CODIGOSBS = new SqlParameter();
                SqlParameter prm_DNI = new SqlParameter();
                SqlParameter prm_RUC = new SqlParameter();
                SqlParameter prm_APEPAT = new SqlParameter();
                SqlParameter prm_APEMAT = new SqlParameter();
                SqlParameter prm_NOMBRES = new SqlParameter();
                SqlParameter prm_CODTIPOPERSONA = new SqlParameter();
                SqlParameter prm_CODSTATUSLAB = new SqlParameter();
                SqlParameter prm_RAZONSOCIAL = new SqlParameter();
                SqlParameter prm_PROFESION = new SqlParameter();
                SqlParameter prm_CODESTCIVIL = new SqlParameter();
                #endregion Parametros

                #region Values
                #region NEMPRESA
                prm_NEMPRESA.ParameterName = "@NEMPRESA";
                prm_NEMPRESA.SqlDbType = SqlDbType.Int;
                prm_NEMPRESA.Direction = ParameterDirection.Input;
                prm_NEMPRESA.Value = ListEnDatosCliente[0].NEMPRESA;
                #endregion NEMPRESA
                #region CodigoCliente
                prm_CODIGOCLIENTE.ParameterName = "@CodigoCliente";
                prm_CODIGOCLIENTE.SqlDbType = SqlDbType.Int;
                prm_CODIGOCLIENTE.Direction = ParameterDirection.Input;
                prm_CODIGOCLIENTE.Value = ListEnDatosCliente[0].CodigoCliente;
                #endregion CodigoCliente
                #region CodigoSBS
                prm_CODIGOSBS.ParameterName = "@CodigoSBS";
                prm_CODIGOSBS.SqlDbType = SqlDbType.VarChar;
                prm_CODIGOSBS.Direction = ParameterDirection.Input;
                prm_CODIGOSBS.Size = 50;
                prm_CODIGOSBS.Value = ListEnDatosCliente[0].CodigoSBS;
                #endregion CodigoSBS
                #region DNI
                prm_DNI.ParameterName = "@DNI";
                prm_DNI.SqlDbType = SqlDbType.Char;
                prm_DNI.Direction = ParameterDirection.Input;
                prm_DNI.Size = 8;
                prm_DNI.Value = ListEnDatosCliente[0].DNI;
                #endregion DNI
                #region RUC
                prm_RUC.ParameterName = "@RUC";
                prm_RUC.SqlDbType = SqlDbType.Char;
                prm_RUC.Direction = ParameterDirection.Input;
                prm_RUC.Size = 11;
                prm_RUC.Value = ListEnDatosCliente[0].RUC;
                #endregion RUC
                #region ApePat
                prm_APEPAT.ParameterName = "@ApePat";
                prm_APEPAT.SqlDbType = SqlDbType.VarChar;
                prm_APEPAT.Direction = ParameterDirection.Input;
                prm_APEPAT.Size = 60;
                prm_APEPAT.Value = ListEnDatosCliente[0].ApePat;
                #endregion ApePat
                #region ApeMat
                prm_APEMAT.ParameterName = "@ApeMat";
                prm_APEMAT.SqlDbType = SqlDbType.VarChar;
                prm_APEMAT.Direction = ParameterDirection.Input;
                prm_APEMAT.Size = 60;
                prm_APEMAT.Value = ListEnDatosCliente[0].ApeMat;
                #endregion ApeMat
                #region Nombres
                prm_NOMBRES.ParameterName = "@Nombres";
                prm_NOMBRES.SqlDbType = SqlDbType.VarChar;
                prm_NOMBRES.Direction = ParameterDirection.Input;
                prm_NOMBRES.Size = 60;
                prm_NOMBRES.Value = ListEnDatosCliente[0].Nombres;
                #endregion Nombres
                #region CodTipoPersona
                prm_CODTIPOPERSONA.ParameterName = "@CodTipoPersona";
                prm_CODTIPOPERSONA.SqlDbType = SqlDbType.Int;
                prm_CODTIPOPERSONA.Direction = ParameterDirection.Input;
                prm_CODTIPOPERSONA.Value = ListEnDatosCliente[0].CodTipoPersona;
                #endregion CodTipoPersona
                #region CodStatusLab
                prm_CODSTATUSLAB.ParameterName = "@CodStatusLab";
                prm_CODSTATUSLAB.SqlDbType = SqlDbType.Int;
                prm_CODSTATUSLAB.Direction = ParameterDirection.Input;
                prm_CODSTATUSLAB.Value = ListEnDatosCliente[0].CodStatusLab;
                #endregion CodStatusLab
                #region RazonSocial
                prm_RAZONSOCIAL.ParameterName = "@RazonSocial";
                prm_RAZONSOCIAL.SqlDbType = SqlDbType.VarChar;
                prm_RAZONSOCIAL.Direction = ParameterDirection.Input;
                prm_RAZONSOCIAL.Size = 120;
                prm_RAZONSOCIAL.Value = ListEnDatosCliente[0].RazonSocial;
                #endregion RazonSocial
                #region Profesion
                prm_PROFESION.ParameterName = "@Profesion";
                prm_PROFESION.SqlDbType = SqlDbType.VarChar;
                prm_PROFESION.Direction = ParameterDirection.Input;
                prm_PROFESION.Size = 120;
                prm_PROFESION.Value = ListEnDatosCliente[0].Profesion;
                #endregion Profesion
                #region CodEstCivil
                prm_CODESTCIVIL.ParameterName = "@CodEstCivil";
                prm_CODESTCIVIL.SqlDbType = SqlDbType.Int;
                prm_CODESTCIVIL.Direction = ParameterDirection.Input;
                prm_CODESTCIVIL.Value = ListEnDatosCliente[0].CodEstCivil;
                #endregion CodEstCivil
                #endregion Values

                #region Execute
                SqlHelper.ExecuteNonQuery(tran, "CR_Cliente_sp_Modifica",
                                               prm_NEMPRESA,
                                               prm_CODIGOCLIENTE,
                                               prm_CODIGOSBS,
                                               prm_DNI,
                                               prm_RUC,
                                               prm_APEPAT,
                                               prm_APEMAT,
                                               prm_NOMBRES,
                                               prm_CODTIPOPERSONA,
                                               prm_CODSTATUSLAB,
                                               prm_RAZONSOCIAL,
                                               prm_PROFESION,
                                               prm_CODESTCIVIL
                                               );
                #endregion Execute
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
