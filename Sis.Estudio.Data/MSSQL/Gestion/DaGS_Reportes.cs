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
    public class DaGS_Reportes : DaConexion
    {

        public DataTable RPT_Gestion_Ejecutores(List<EnGS_Reportes> ListEnGS_Reportes)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "RPT_Gestion_sp_Ejecutores";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[9];

                paramsToStore[0] = new SqlParameter("@NEMPRESA", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_Reportes[0].NEMPRESA;

                paramsToStore[1] = new SqlParameter("@CodUsuarioRegistra", SqlDbType.Int);
                paramsToStore[1].Value = ListEnGS_Reportes[0].CodUsuarioRegistra;

                paramsToStore[2] = new SqlParameter("@sw", SqlDbType.Int);
                paramsToStore[2].Value = ListEnGS_Reportes[0].sw;

                paramsToStore[3] = new SqlParameter("@fecha_ini", SqlDbType.VarChar);
                paramsToStore[3].Value = ListEnGS_Reportes[0].fecha_ini;
                paramsToStore[3].Size = 10;

                paramsToStore[4] = new SqlParameter("@fecha_fin", SqlDbType.VarChar);
                paramsToStore[4].Value = ListEnGS_Reportes[0].fecha_fin;
                paramsToStore[4].Size = 10;

                paramsToStore[5] = new SqlParameter("@Id_Estado_Gestion_Cobranza", SqlDbType.Int);
                paramsToStore[5].Value = ListEnGS_Reportes[0].Id_Estado_Gestion_Cobranza;

                paramsToStore[6] = new SqlParameter("@CodTipoGestion", SqlDbType.Int);
                paramsToStore[6].Value = ListEnGS_Reportes[0].CodTipoGestion;

                paramsToStore[7] = new SqlParameter("@anio", SqlDbType.Int);
                paramsToStore[7].Value = ListEnGS_Reportes[0].anio;

                paramsToStore[8] = new SqlParameter("@mes", SqlDbType.Int);
                paramsToStore[8].Value = ListEnGS_Reportes[0].mes;
                                               
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



        public DataTable RPT_Recuperacion_Ejecutores(List<EnGS_Reportes> ListEnGS_Reportes)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "RPT_Recuperacion_sp_Ejecutores";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[5];

                paramsToStore[0] = new SqlParameter("@NEMPRESA", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_Reportes[0].NEMPRESA;

                paramsToStore[1] = new SqlParameter("@CodUsuarioRegistra", SqlDbType.Int);
                paramsToStore[1].Value = ListEnGS_Reportes[0].CodUsuarioRegistra;



                paramsToStore[2] = new SqlParameter("@anio", SqlDbType.Int);
                paramsToStore[2].Value = ListEnGS_Reportes[0].anio;

                paramsToStore[3] = new SqlParameter("@mes", SqlDbType.Int);
                paramsToStore[3].Value = ListEnGS_Reportes[0].mes;


                paramsToStore[4] = new SqlParameter("@RangoDias", SqlDbType.Int);
                paramsToStore[4].Value = ListEnGS_Reportes[0].RangoDias;
                
         

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
        public DataTable RPT_Recuperacion_Ejecutores_Nivel3(List<EnGS_Reportes> ListEnGS_Reportes)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "RPT_Recuperacion_sp_Ejecutores_Nivel3";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[5];

                paramsToStore[0] = new SqlParameter("@NEMPRESA", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_Reportes[0].NEMPRESA;

                paramsToStore[1] = new SqlParameter("@CodUsuarioRegistra", SqlDbType.Int);
                paramsToStore[1].Value = ListEnGS_Reportes[0].CodUsuarioRegistra;



                paramsToStore[2] = new SqlParameter("@anio", SqlDbType.Int);
                paramsToStore[2].Value = ListEnGS_Reportes[0].anio;

                paramsToStore[3] = new SqlParameter("@mes", SqlDbType.Int);
                paramsToStore[3].Value = ListEnGS_Reportes[0].mes;


                paramsToStore[4] = new SqlParameter("@RangoDias", SqlDbType.Int);
                paramsToStore[4].Value = ListEnGS_Reportes[0].RangoDias;



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

        public DataTable RPT_Recuperacion_Ejecutores_Nivel2(List<EnGS_Reportes> ListEnGS_Reportes)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "RPT_Recuperacion_sp_Ejecutores_Nivel2";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[5];

                paramsToStore[0] = new SqlParameter("@NEMPRESA", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_Reportes[0].NEMPRESA;

                paramsToStore[1] = new SqlParameter("@CodUsuarioRegistra", SqlDbType.Int);
                paramsToStore[1].Value = ListEnGS_Reportes[0].CodUsuarioRegistra;



                paramsToStore[2] = new SqlParameter("@anio", SqlDbType.Int);
                paramsToStore[2].Value = ListEnGS_Reportes[0].anio;

                paramsToStore[3] = new SqlParameter("@mes", SqlDbType.Int);
                paramsToStore[3].Value = ListEnGS_Reportes[0].mes;


                paramsToStore[4] = new SqlParameter("@RangoDias", SqlDbType.Int);
                paramsToStore[4].Value = ListEnGS_Reportes[0].RangoDias;



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
        public DataTable RPT_Recuperacion_Ejecutores_Nivel1(List<EnGS_Reportes> ListEnGS_Reportes)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "RPT_Recuperacion_sp_Ejecutores_Nivel1";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[5];

                paramsToStore[0] = new SqlParameter("@NEMPRESA", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_Reportes[0].NEMPRESA;

                paramsToStore[1] = new SqlParameter("@CodUsuarioRegistra", SqlDbType.Int);
                paramsToStore[1].Value = ListEnGS_Reportes[0].CodUsuarioRegistra;



                paramsToStore[2] = new SqlParameter("@anio", SqlDbType.Int);
                paramsToStore[2].Value = ListEnGS_Reportes[0].anio;

                paramsToStore[3] = new SqlParameter("@mes", SqlDbType.Int);
                paramsToStore[3].Value = ListEnGS_Reportes[0].mes;


                paramsToStore[4] = new SqlParameter("@RangoDias", SqlDbType.Int);
                paramsToStore[4].Value = ListEnGS_Reportes[0].RangoDias;



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

        public DataTable RPT_Recuperacion_Piloto(List<EnGS_Reportes> ListEnGS_Reportes)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "RPT_Recuperacion_sp_Piloto";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[6];

                paramsToStore[0] = new SqlParameter("@NEMPRESA", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_Reportes[0].NEMPRESA;

                paramsToStore[1] = new SqlParameter("@CodUsuarioRegistra", SqlDbType.Int);
                paramsToStore[1].Value = ListEnGS_Reportes[0].CodUsuarioRegistra;



                paramsToStore[2] = new SqlParameter("@anio", SqlDbType.Int);
                paramsToStore[2].Value = ListEnGS_Reportes[0].anio;

                paramsToStore[3] = new SqlParameter("@mes", SqlDbType.Int);
                paramsToStore[3].Value = ListEnGS_Reportes[0].mes;


                paramsToStore[4] = new SqlParameter("@RangoDias", SqlDbType.Int);
                paramsToStore[4].Value = ListEnGS_Reportes[0].RangoDias;

                paramsToStore[5] = new SqlParameter("@Jerarquia", SqlDbType.VarChar);
                paramsToStore[5].Value = ListEnGS_Reportes[0].Jerarquia;


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


        public DataTable RPT_Gestion_Ejecutores_Nivel1(List<EnGS_Reportes> ListEnGS_Reportes)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "RPT_Gestion_sp_Ejecutores_Nivel1";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[9];

                paramsToStore[0] = new SqlParameter("@NEMPRESA", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_Reportes[0].NEMPRESA;

                paramsToStore[1] = new SqlParameter("@CodUsuarioRegistra", SqlDbType.Int);
                paramsToStore[1].Value = ListEnGS_Reportes[0].CodUsuarioRegistra;

                paramsToStore[2] = new SqlParameter("@sw", SqlDbType.Int);
                paramsToStore[2].Value = ListEnGS_Reportes[0].sw;

                paramsToStore[3] = new SqlParameter("@fecha_ini", SqlDbType.VarChar);
                paramsToStore[3].Value = ListEnGS_Reportes[0].fecha_ini;
                paramsToStore[3].Size = 10;

                paramsToStore[4] = new SqlParameter("@fecha_fin", SqlDbType.VarChar);
                paramsToStore[4].Value = ListEnGS_Reportes[0].fecha_fin;
                paramsToStore[4].Size = 10;

                paramsToStore[5] = new SqlParameter("@Id_Estado_Gestion_Cobranza", SqlDbType.Int);
                paramsToStore[5].Value = ListEnGS_Reportes[0].Id_Estado_Gestion_Cobranza;

                paramsToStore[6] = new SqlParameter("@CodTipoGestion", SqlDbType.Int);
                paramsToStore[6].Value = ListEnGS_Reportes[0].CodTipoGestion;

                paramsToStore[7] = new SqlParameter("@anio", SqlDbType.Int);
                paramsToStore[7].Value = ListEnGS_Reportes[0].anio;

                paramsToStore[8] = new SqlParameter("@mes", SqlDbType.Int);
                paramsToStore[8].Value = ListEnGS_Reportes[0].mes;

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
        public DataTable RPT_Gestion_Ejecutores_Nivel2(List<EnGS_Reportes> ListEnGS_Reportes)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "RPT_Gestion_sp_Ejecutores_Nivel2";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[9];

                paramsToStore[0] = new SqlParameter("@NEMPRESA", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_Reportes[0].NEMPRESA;

                paramsToStore[1] = new SqlParameter("@CodUsuarioRegistra", SqlDbType.Int);
                paramsToStore[1].Value = ListEnGS_Reportes[0].CodUsuarioRegistra;

                paramsToStore[2] = new SqlParameter("@sw", SqlDbType.Int);
                paramsToStore[2].Value = ListEnGS_Reportes[0].sw;

                paramsToStore[3] = new SqlParameter("@fecha_ini", SqlDbType.VarChar);
                paramsToStore[3].Value = ListEnGS_Reportes[0].fecha_ini;
                paramsToStore[3].Size = 10;

                paramsToStore[4] = new SqlParameter("@fecha_fin", SqlDbType.VarChar);
                paramsToStore[4].Value = ListEnGS_Reportes[0].fecha_fin;
                paramsToStore[4].Size = 10;

                paramsToStore[5] = new SqlParameter("@Id_Estado_Gestion_Cobranza", SqlDbType.Int);
                paramsToStore[5].Value = ListEnGS_Reportes[0].Id_Estado_Gestion_Cobranza;

                paramsToStore[6] = new SqlParameter("@CodTipoGestion", SqlDbType.Int);
                paramsToStore[6].Value = ListEnGS_Reportes[0].CodTipoGestion;

                paramsToStore[7] = new SqlParameter("@anio", SqlDbType.Int);
                paramsToStore[7].Value = ListEnGS_Reportes[0].anio;

                paramsToStore[8] = new SqlParameter("@mes", SqlDbType.Int);
                paramsToStore[8].Value = ListEnGS_Reportes[0].mes;

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





        public DataTable RPT_Gestion_Ejecutores_Nivel3(List<EnGS_Reportes> ListEnGS_Reportes)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

               Conn = new SqlConnection(MSSQLConnectionString);
               sqlCommand = "RPT_Gestion_sp_Ejecutores_Nivel3";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[9];

                paramsToStore[0] = new SqlParameter("@NEMPRESA", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_Reportes[0].NEMPRESA;

                paramsToStore[1] = new SqlParameter("@CodUsuarioRegistra", SqlDbType.Int);
                paramsToStore[1].Value = ListEnGS_Reportes[0].CodUsuarioRegistra;

                paramsToStore[2] = new SqlParameter("@sw", SqlDbType.Int);
                paramsToStore[2].Value = ListEnGS_Reportes[0].sw;

                paramsToStore[3] = new SqlParameter("@fecha_ini", SqlDbType.VarChar);
                paramsToStore[3].Value = ListEnGS_Reportes[0].fecha_ini;
                paramsToStore[3].Size = 10;

                paramsToStore[4] = new SqlParameter("@fecha_fin", SqlDbType.VarChar);
                paramsToStore[4].Value = ListEnGS_Reportes[0].fecha_fin;
                paramsToStore[4].Size = 10;

                paramsToStore[5] = new SqlParameter("@Id_Estado_Gestion_Cobranza", SqlDbType.Int);
                paramsToStore[5].Value = ListEnGS_Reportes[0].Id_Estado_Gestion_Cobranza;

                paramsToStore[6] = new SqlParameter("@CodTipoGestion", SqlDbType.Int);
                paramsToStore[6].Value = ListEnGS_Reportes[0].CodTipoGestion;

                paramsToStore[7] = new SqlParameter("@anio", SqlDbType.Int);
                paramsToStore[7].Value = ListEnGS_Reportes[0].anio;

                paramsToStore[8] = new SqlParameter("@mes", SqlDbType.Int);
                paramsToStore[8].Value = ListEnGS_Reportes[0].mes;
                                               
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

        public DataTable RPT_Gestion_Campo(List<EnGS_Reportes> ListEnGS_Reportes,string codAsesor)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "RPT_Gestion_sp_VisitasCampo";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[4];

                paramsToStore[0] = new SqlParameter("@NEMPRESA", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_Reportes[0].NEMPRESA;

                paramsToStore[1] = new SqlParameter("@codAsesor", SqlDbType.Int);
                paramsToStore[1].Value = codAsesor;

                paramsToStore[2] = new SqlParameter("@fecha_ini", SqlDbType.VarChar);
                paramsToStore[2].Value = ListEnGS_Reportes[0].fecha_ini;
                paramsToStore[2].Size = 10;

                paramsToStore[3] = new SqlParameter("@fecha_fin", SqlDbType.VarChar);
                paramsToStore[3].Value = ListEnGS_Reportes[0].fecha_fin;
                paramsToStore[3].Size = 10;


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










