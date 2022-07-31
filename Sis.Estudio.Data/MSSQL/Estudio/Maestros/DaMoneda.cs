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
      public class DaMoneda :DaConexion
      {

        public string Moneda_INS(List<EnMoneda> ListEnMoneda, SqlTransaction tran)
        {
            string IdReturn = String.Empty;
            SqlDataReader drParamReturn;
            try
            {
               
                  SqlParameter prm_CodEmpMoneda = new SqlParameter();

           



                  #region CodEmpMoneda
                  prm_CodEmpMoneda.ParameterName = "@CodEmpMoneda";
                prm_CodEmpMoneda.SqlDbType = SqlDbType.Int;
                prm_CodEmpMoneda.Direction = ParameterDirection.Input;
                prm_CodEmpMoneda.Size = 120;
                prm_CodEmpMoneda.Value = ListEnMoneda[0].CodEmpMoneda;
                  #endregion CodEmpMoneda
           

              

            

                SqlParameter prm_DesMoneda = new SqlParameter();



                #region DesMoneda
                prm_DesMoneda.ParameterName = "@DesMoneda";
                prm_DesMoneda.SqlDbType = SqlDbType.VarChar;
                prm_DesMoneda.Direction = ParameterDirection.Input;
                prm_DesMoneda.Size = 120;
                prm_DesMoneda.Value = ListEnMoneda[0].DesMoneda;
                #endregion DesMoneda

                SqlParameter prm_CodUsuario = new SqlParameter();

                #region prm_CodUsuario
                prm_CodUsuario.ParameterName = "@CodUsuarioRegistra";
                prm_CodUsuario.SqlDbType = SqlDbType.Int;
                prm_CodUsuario.Direction = ParameterDirection.Input;
                prm_CodUsuario.Value = ListEnMoneda[0].CodUsuario;
                #endregion prm_CodUsuario 





                drParamReturn = SqlHelper.ExecuteReader(tran, "MonedaS_sp_Insertar",
                                                 prm_CodEmpMoneda,
                                                
                                               
                                               prm_DesMoneda,
                                               prm_CodUsuario
                                               
                                              
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
        public void Moneda_UPD(List<EnMoneda> ListEnMoneda, SqlTransaction tran)
        {
        try
            {
                #region Parametros

                SqlParameter prm_CodEmpMoneda = new SqlParameter();
                SqlParameter prm_CodMoneda = new SqlParameter();
                SqlParameter prm_DesMoneda = new SqlParameter();

                SqlParameter prm_CodUsuario = new SqlParameter();

           
                #endregion Parametros


                #region CodEmpMoneda
                prm_CodEmpMoneda.ParameterName = "@CodEmpMoneda";
                prm_CodEmpMoneda.SqlDbType = SqlDbType.Int;
                prm_CodEmpMoneda.Direction = ParameterDirection.Input;
                prm_CodEmpMoneda.Value = ListEnMoneda[0].CodEmpMoneda;
                #endregion  prm_CodEmpMoneda






                #region CodMoneda
                prm_CodMoneda.ParameterName = "@CodMoneda";
                prm_CodMoneda.SqlDbType = SqlDbType.Int;
                prm_CodMoneda.Direction = ParameterDirection.Input;
                prm_CodMoneda.Value = ListEnMoneda[0].CodMoneda;
                #endregion CodMoneda

                #region DesMoneda
                prm_DesMoneda.ParameterName = "@DesMoneda";
                prm_DesMoneda.SqlDbType = SqlDbType.VarChar;
                prm_DesMoneda.Direction = ParameterDirection.Input;
                prm_DesMoneda.Size = 120;
                prm_DesMoneda.Value = ListEnMoneda[0].DesMoneda;
                #endregion DesMoneda


                #region prm_CodUsuario
                prm_CodUsuario.ParameterName = "@CodUsuarioRegistra";
                prm_CodUsuario.SqlDbType = SqlDbType.Int;
                prm_CodUsuario.Direction = ParameterDirection.Input;
                prm_CodUsuario.Value = ListEnMoneda[0].CodUsuario;
                #endregion prm_CodUsuario 
              


                #region Execute
                SqlHelper.ExecuteNonQuery(tran, "Monedas_sp_Modificar",
                                                 prm_CodEmpMoneda,
                                              
                                               prm_CodMoneda,
                                              
                                               prm_DesMoneda,
                                                prm_CodUsuario
                                            
                                               );
                #endregion Execute
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Moneda_Listar(List<EnMoneda> ListEnMoneda)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString3);
                sqlCommand = "Monedas_sp_Carga";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];

                paramsToStore[0] = new SqlParameter("@CodEmpMoneda", SqlDbType.Int);
                paramsToStore[0].Value = ListEnMoneda[0].CodEmpMoneda;

                paramsToStore[1] = new SqlParameter("@DesMoneda", SqlDbType.VarChar);
                paramsToStore[1].Value = ListEnMoneda[0].DesMoneda;
    

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


        public void Moneda_DEL(List<EnMoneda> ListEnMoneda, SqlTransaction tran)
        {
            try
            {

            

                SqlParameter prm_CodEmpMoneda = new SqlParameter();
                

                SqlParameter prm_CodMoneda = new SqlParameter();


                #region prm_CodEmpMoneda
                prm_CodEmpMoneda.ParameterName = "@CodEmpMoneda";
                prm_CodEmpMoneda.SqlDbType = SqlDbType.Int;
                prm_CodEmpMoneda.Direction = ParameterDirection.Input;

                prm_CodEmpMoneda.Value = ListEnMoneda[0].CodEmpMoneda;
                #endregion prm_CodEmpMoneda



       

                #region prm_CodMoneda
                prm_CodMoneda.ParameterName = "@CodMoneda";
                prm_CodMoneda.SqlDbType = SqlDbType.Int;
                prm_CodMoneda.Direction = ParameterDirection.Input;
                prm_CodMoneda.Value = ListEnMoneda[0].CodMoneda;
                #endregion prm_CodMoneda

                SqlParameter prm_CodUsuario = new SqlParameter();

                #region prm_CodUsuario
                prm_CodUsuario.ParameterName = "@CodUsuarioRegistra";
                prm_CodUsuario.SqlDbType = SqlDbType.Int;
                prm_CodUsuario.Direction = ParameterDirection.Input;
                prm_CodUsuario.Value = ListEnMoneda[0].CodUsuario;
                #endregion prm_CodUsuario 


                SqlHelper.ExecuteNonQuery(tran, "Moneda_sp_Eliminar",
                                                 prm_CodEmpMoneda,
                                                 
                                               prm_CodMoneda,
                                               prm_CodUsuario);

  
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable Moneda_Listar_Reg(List<EnMoneda> ListEnMoneda)
         {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString3);
                sqlCommand = "Moneda_sp_CargaREG";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];

                paramsToStore[0] = new SqlParameter("@CodEmpMoneda", SqlDbType.Int);
                paramsToStore[0].Value = ListEnMoneda[0].CodEmpMoneda;

                paramsToStore[1] = new SqlParameter("@CodMoneda", SqlDbType.Int);
                paramsToStore[1].Value = ListEnMoneda[0].CodMoneda;




    


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
