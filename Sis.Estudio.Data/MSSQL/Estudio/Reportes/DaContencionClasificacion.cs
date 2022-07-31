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
    public class DaContencionClasificacion : DaConexion
    {

        public DataTable ContencionClasificacion_Listar()
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_ClasificacionGestion_sp_Listar";
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

        public DataTable ContencionClasificacion_RPT(List<EnContencionClasificacion> ListEnContencionClasificacion)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "RPT_Contencion_Clasificacion";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[5];

                paramsToStore[0] = new SqlParameter("@NEMPRESA", SqlDbType.Int);
                paramsToStore[0].Value = ListEnContencionClasificacion[0].NEMPRESA;

                paramsToStore[1] = new SqlParameter("@Anio", SqlDbType.Int);
                paramsToStore[1].Value = ListEnContencionClasificacion[0].Anio;

                paramsToStore[2] = new SqlParameter("@Tramo", SqlDbType.Int);
                paramsToStore[2].Value = ListEnContencionClasificacion[0].Tramo;

                paramsToStore[3] = new SqlParameter("@CodSucursal", SqlDbType.Int);
                paramsToStore[3].Value = ListEnContencionClasificacion[0].CodSucursal;

                paramsToStore[4] = new SqlParameter("@CodClasificacion", SqlDbType.Int);
                paramsToStore[4].Value = ListEnContencionClasificacion[0].CodClasificacion;

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
