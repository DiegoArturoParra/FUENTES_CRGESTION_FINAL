using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Sis.Estudio.Entity;
using System.IO;

namespace Sis.Estudio.Data.MSSQL.Gestion
{
    public class DaGS_Gestion_Cobranza : DaConexion
    {

        public DataTable GS_Gestion_Cobranza_Lista(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_Gestion_Cobranza_sp_Listar";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[11];

                paramsToStore[0] = new SqlParameter("@Accion", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_Gestion_Cobranza[0].Accion;

                paramsToStore[1] = new SqlParameter("@CEmpresa", SqlDbType.Int);
                paramsToStore[1].Value = ListEnGS_Gestion_Cobranza[0].nEmpresa;

                paramsToStore[2] = new SqlParameter("@dias_mora", SqlDbType.VarChar);
                paramsToStore[2].Value = ListEnGS_Gestion_Cobranza[0].dias_mora;
                paramsToStore[2].Size = 250;

                paramsToStore[3] = new SqlParameter("@dias_mora_hasta", SqlDbType.VarChar);
                paramsToStore[3].Value = ListEnGS_Gestion_Cobranza[0].dias_mora_hasta;
                paramsToStore[3].Size = 250;

                paramsToStore[4] = new SqlParameter("@fecha_ini", SqlDbType.VarChar);
                paramsToStore[4].Value = ListEnGS_Gestion_Cobranza[0].fecha_ini;
                paramsToStore[4].Size = 10;

                paramsToStore[5] = new SqlParameter("@fecha_fin", SqlDbType.VarChar);
                paramsToStore[5].Value = ListEnGS_Gestion_Cobranza[0].fecha_fin;
                paramsToStore[5].Size = 10;

                paramsToStore[6] = new SqlParameter("@CodTipoGestion", SqlDbType.VarChar);
                paramsToStore[6].Value = ListEnGS_Gestion_Cobranza[0].CodTipoGestion;
                paramsToStore[6].Size = 30;

                paramsToStore[7] = new SqlParameter("@CodUsuarioRegistra", SqlDbType.Int);
                paramsToStore[7].Value = ListEnGS_Gestion_Cobranza[0].CodUsuario;

                paramsToStore[8] = new SqlParameter("@nombres", SqlDbType.VarChar);
                paramsToStore[8].Value = ListEnGS_Gestion_Cobranza[0].Nombres;
                paramsToStore[8].Size = 50;

                paramsToStore[9] = new SqlParameter("@documento", SqlDbType.VarChar);
                paramsToStore[9].Value = ListEnGS_Gestion_Cobranza[0].documento;
                paramsToStore[9].Size = 20;

                paramsToStore[10] = new SqlParameter("@id_estado_gestion_cobranza", SqlDbType.Int);
                paramsToStore[10].Value = int.Parse(ListEnGS_Gestion_Cobranza[0].Id_estado_gestion_cobranza);


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

        public string GS_Gestion_Cobranza_Imagen(int id)
        {
            string sqlCommand = "GS_Gestion_Cobranza_Imagen";
            string imagen;
            using (var con = new SqlConnection(MSSQLConnectionString))
            {
                using (var cmd = new SqlCommand(sqlCommand, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdImagen", SqlDbType.Int).Value = id;
                    con.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        imagen = reader["cNombre"].ToString();
                    }
                }
            }
            return imagen;
        }

        public DataTable GS_Gestion_Cobranza_Lista_App(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_Gestion_Cobranza_sp_Listar_App";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[11];

                paramsToStore[0] = new SqlParameter("@Accion", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_Gestion_Cobranza[0].Accion;

                paramsToStore[1] = new SqlParameter("@CEmpresa", SqlDbType.Int);
                paramsToStore[1].Value = ListEnGS_Gestion_Cobranza[0].nEmpresa;

                paramsToStore[2] = new SqlParameter("@dias_mora", SqlDbType.VarChar);
                paramsToStore[2].Value = ListEnGS_Gestion_Cobranza[0].dias_mora;
                paramsToStore[2].Size = 250;

                paramsToStore[3] = new SqlParameter("@dias_mora_hasta", SqlDbType.VarChar);
                paramsToStore[3].Value = ListEnGS_Gestion_Cobranza[0].dias_mora_hasta;
                paramsToStore[3].Size = 250;

                paramsToStore[4] = new SqlParameter("@fecha_ini", SqlDbType.VarChar);
                paramsToStore[4].Value = ListEnGS_Gestion_Cobranza[0].fecha_ini;
                paramsToStore[4].Size = 10;

                paramsToStore[5] = new SqlParameter("@fecha_fin", SqlDbType.VarChar);
                paramsToStore[5].Value = ListEnGS_Gestion_Cobranza[0].fecha_fin;
                paramsToStore[5].Size = 10;

                paramsToStore[6] = new SqlParameter("@CodTipoGestion", SqlDbType.VarChar);
                paramsToStore[6].Value = ListEnGS_Gestion_Cobranza[0].CodTipoGestion;
                paramsToStore[6].Size = 30;

                paramsToStore[7] = new SqlParameter("@CodUsuarioRegistra", SqlDbType.Int);
                paramsToStore[7].Value = ListEnGS_Gestion_Cobranza[0].CodUsuario;

                paramsToStore[8] = new SqlParameter("@nombres", SqlDbType.VarChar);
                paramsToStore[8].Value = ListEnGS_Gestion_Cobranza[0].Nombres;
                paramsToStore[8].Size = 50;

                paramsToStore[9] = new SqlParameter("@documento", SqlDbType.VarChar);
                paramsToStore[9].Value = ListEnGS_Gestion_Cobranza[0].documento;
                paramsToStore[9].Size = 20;

                paramsToStore[10] = new SqlParameter("@id_estado_gestion_cobranza", SqlDbType.Int);
                paramsToStore[10].Value = int.Parse(ListEnGS_Gestion_Cobranza[0].Id_estado_gestion_cobranza);


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

        public DataTable GS_Gestion_Cobranza_Lista_Pendientes(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza, string lcFiltro)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_Gestion_Cobranza_sp_Listar_Pendientes2";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[3];

                //paramsToStore[0] = new SqlParameter("@Accion", SqlDbType.Int);
                //paramsToStore[0].Value = ListEnGS_Gestion_Cobranza[0].Accion;

                paramsToStore[0] = new SqlParameter("@nEmpresa", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_Gestion_Cobranza[0].nEmpresa;

                //paramsToStore[2] = new SqlParameter("@dias_mora", SqlDbType.VarChar);
                //paramsToStore[2].Value = ListEnGS_Gestion_Cobranza[0].dias_mora;
                //paramsToStore[2].Size = 250;

                //paramsToStore[3] = new SqlParameter("@fecha_ini", SqlDbType.VarChar);
                //paramsToStore[3].Value = ListEnGS_Gestion_Cobranza[0].fecha_ini;
                //paramsToStore[3].Size = 10;

                //paramsToStore[4] = new SqlParameter("@fecha_fin", SqlDbType.VarChar);
                //paramsToStore[4].Value = ListEnGS_Gestion_Cobranza[0].fecha_fin;
                //paramsToStore[4].Size = 10;

                //paramsToStore[5] = new SqlParameter("@CodTipoGestion", SqlDbType.VarChar);
                //paramsToStore[5].Value = ListEnGS_Gestion_Cobranza[0].CodTipoGestion;
                //paramsToStore[5].Size = 30;

                paramsToStore[1] = new SqlParameter("@nIdAsesor", SqlDbType.Int);
                paramsToStore[1].Value = ListEnGS_Gestion_Cobranza[0].CodUsuario;

                paramsToStore[2] = new SqlParameter("@cFiltro", SqlDbType.VarChar);
                paramsToStore[2].Value = lcFiltro;
                paramsToStore[2].Size = 3000;

                //paramsToStore[7] = new SqlParameter("@nombres", SqlDbType.VarChar);
                //paramsToStore[7].Value = ListEnGS_Gestion_Cobranza[0].Nombres;
                //paramsToStore[7].Size = 50;

                //paramsToStore[8] = new SqlParameter("@documento", SqlDbType.VarChar);
                //paramsToStore[8].Value = ListEnGS_Gestion_Cobranza[0].documento;
                //paramsToStore[8].Size = 20;

                //paramsToStore[9] = new SqlParameter("@id_estado_gestion_cobranza", SqlDbType.VarChar);
                //paramsToStore[9].Value = ListEnGS_Gestion_Cobranza[0].Id_estado_gestion_cobranza;

                //paramsToStore[10] = new SqlParameter("@tipo", SqlDbType.Int);
                //paramsToStore[10].Value = tipoListado;

                //paramsToStore[11] = new SqlParameter("@dias_mora_hasta", SqlDbType.VarChar);
                //paramsToStore[11].Value = ListEnGS_Gestion_Cobranza[0].dias_mora_hasta;
                //paramsToStore[11].Size = 250;

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

        //GS_Gestion_Cobranza_sp_Listar_Pendientes_Desactivacion
        public DataTable GS_Gestion_Cobranza_Listar_Pendientes_Desactivacion(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza, string tipo)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                int tipoListado = 0;
                if (tipo == "masivo")
                {
                    tipoListado = 1;
                }
                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_Gestion_Cobranza_sp_Listar_Pendientes_Desactivacion";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[15];

                paramsToStore[0] = new SqlParameter("@Accion", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_Gestion_Cobranza[0].Accion;

                paramsToStore[1] = new SqlParameter("@CEmpresa", SqlDbType.Int);
                paramsToStore[1].Value = ListEnGS_Gestion_Cobranza[0].nEmpresa;

                paramsToStore[2] = new SqlParameter("@dias_mora", SqlDbType.VarChar);
                paramsToStore[2].Value = ListEnGS_Gestion_Cobranza[0].dias_mora;
                paramsToStore[2].Size = 250;

                paramsToStore[3] = new SqlParameter("@fecha_ini", SqlDbType.VarChar);
                paramsToStore[3].Value = ListEnGS_Gestion_Cobranza[0].fecha_ini;
                paramsToStore[3].Size = 10;

                paramsToStore[4] = new SqlParameter("@fecha_fin", SqlDbType.VarChar);
                paramsToStore[4].Value = ListEnGS_Gestion_Cobranza[0].fecha_fin;
                paramsToStore[4].Size = 10;

                paramsToStore[5] = new SqlParameter("@CodTipoGestion", SqlDbType.VarChar);
                paramsToStore[5].Value = ListEnGS_Gestion_Cobranza[0].CodTipoGestion;
                paramsToStore[5].Size = 30;

                paramsToStore[6] = new SqlParameter("@CodUsuarioRegistra", SqlDbType.Int);
                paramsToStore[6].Value = ListEnGS_Gestion_Cobranza[0].CodUsuario;

                paramsToStore[7] = new SqlParameter("@nombres", SqlDbType.VarChar);
                paramsToStore[7].Value = ListEnGS_Gestion_Cobranza[0].Nombres;
                paramsToStore[7].Size = 50;

                paramsToStore[8] = new SqlParameter("@documento", SqlDbType.VarChar);
                paramsToStore[8].Value = ListEnGS_Gestion_Cobranza[0].documento;
                paramsToStore[8].Size = 20;

                paramsToStore[9] = new SqlParameter("@id_estado_gestion_cobranza", SqlDbType.VarChar);
                paramsToStore[9].Value = ListEnGS_Gestion_Cobranza[0].Id_estado_gestion_cobranza;

                paramsToStore[10] = new SqlParameter("@tipo", SqlDbType.Int);
                paramsToStore[10].Value = tipoListado;

                paramsToStore[11] = new SqlParameter("@dias_mora_hasta", SqlDbType.VarChar);
                paramsToStore[11].Value = ListEnGS_Gestion_Cobranza[0].dias_mora_hasta;
                paramsToStore[11].Size = 250;

                paramsToStore[12] = new SqlParameter("@CodJerarquiaB", SqlDbType.VarChar);
                paramsToStore[12].Value = ListEnGS_Gestion_Cobranza[0].cod_jerarquiaB;

                paramsToStore[13] = new SqlParameter("@CodJerarquiaC", SqlDbType.VarChar);
                paramsToStore[13].Value = ListEnGS_Gestion_Cobranza[0].cod_jerarquiaC;

                paramsToStore[14] = new SqlParameter("@CodAsesor", SqlDbType.VarChar);
                paramsToStore[14].Value = ListEnGS_Gestion_Cobranza[0].cod_jerarquiaD;

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

        public DataTable GS_Gestion_Cobranza_Lista_Aprobaciones(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_Gestion_Cobranza_sp_Listar_Aprobaciones";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[10];

                paramsToStore[0] = new SqlParameter("@Accion", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_Gestion_Cobranza[0].Accion;

                paramsToStore[1] = new SqlParameter("@CEmpresa", SqlDbType.Int);
                paramsToStore[1].Value = ListEnGS_Gestion_Cobranza[0].nEmpresa;

                paramsToStore[2] = new SqlParameter("@dias_mora", SqlDbType.VarChar);
                paramsToStore[2].Value = ListEnGS_Gestion_Cobranza[0].dias_mora;
                paramsToStore[2].Size = 250;

                paramsToStore[3] = new SqlParameter("@fecha_ini", SqlDbType.VarChar);
                paramsToStore[3].Value = ListEnGS_Gestion_Cobranza[0].fecha_ini;
                paramsToStore[3].Size = 10;

                paramsToStore[4] = new SqlParameter("@fecha_fin", SqlDbType.VarChar);
                paramsToStore[4].Value = ListEnGS_Gestion_Cobranza[0].fecha_fin;
                paramsToStore[4].Size = 10;

                paramsToStore[5] = new SqlParameter("@CodTipoGestion", SqlDbType.VarChar);
                paramsToStore[5].Value = ListEnGS_Gestion_Cobranza[0].CodTipoGestion;
                paramsToStore[5].Size = 30;

                paramsToStore[6] = new SqlParameter("@CodUsuarioRegistra", SqlDbType.Int);
                paramsToStore[6].Value = ListEnGS_Gestion_Cobranza[0].CodUsuario;

                paramsToStore[7] = new SqlParameter("@nombres", SqlDbType.VarChar);
                paramsToStore[7].Value = ListEnGS_Gestion_Cobranza[0].Nombres;
                paramsToStore[7].Size = 50;

                paramsToStore[8] = new SqlParameter("@documento", SqlDbType.VarChar);
                paramsToStore[8].Value = ListEnGS_Gestion_Cobranza[0].documento;
                paramsToStore[8].Size = 20;

                paramsToStore[9] = new SqlParameter("@id_estado_gestion_cobranza", SqlDbType.VarChar);
                paramsToStore[9].Value = ListEnGS_Gestion_Cobranza[0].Id_estado_gestion_cobranza;


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

        public DataTable GS_Gestion_Cobranza_Lista_BandejaSalida(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_Bandeja_Salida_sp_Listar";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[11];

                paramsToStore[0] = new SqlParameter("@Accion", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_Gestion_Cobranza[0].Accion;

                paramsToStore[1] = new SqlParameter("@CEmpresa", SqlDbType.Int);
                paramsToStore[1].Value = ListEnGS_Gestion_Cobranza[0].nEmpresa;

                paramsToStore[2] = new SqlParameter("@dias_mora", SqlDbType.VarChar);
                paramsToStore[2].Value = ListEnGS_Gestion_Cobranza[0].dias_mora;
                paramsToStore[2].Size = 250;

                paramsToStore[3] = new SqlParameter("@fecha_ini", SqlDbType.VarChar);
                paramsToStore[3].Value = ListEnGS_Gestion_Cobranza[0].fecha_ini;
                paramsToStore[3].Size = 10;

                paramsToStore[4] = new SqlParameter("@fecha_fin", SqlDbType.VarChar);
                paramsToStore[4].Value = ListEnGS_Gestion_Cobranza[0].fecha_fin;
                paramsToStore[4].Size = 10;

                paramsToStore[5] = new SqlParameter("@CodTipoGestion", SqlDbType.VarChar);
                paramsToStore[5].Value = ListEnGS_Gestion_Cobranza[0].CodTipoGestion;
                paramsToStore[5].Size = 30;

                paramsToStore[6] = new SqlParameter("@CodUsuarioRegistra", SqlDbType.Int);
                paramsToStore[6].Value = ListEnGS_Gestion_Cobranza[0].CodUsuario;

                paramsToStore[7] = new SqlParameter("@nombres", SqlDbType.VarChar);
                paramsToStore[7].Value = ListEnGS_Gestion_Cobranza[0].Nombres;
                paramsToStore[7].Size = 50;

                paramsToStore[8] = new SqlParameter("@documento", SqlDbType.VarChar);
                paramsToStore[8].Value = ListEnGS_Gestion_Cobranza[0].documento;
                paramsToStore[8].Size = 20;


                paramsToStore[9] = new SqlParameter("@CodUsuarioResponsable", SqlDbType.VarChar);
                paramsToStore[9].Value = ListEnGS_Gestion_Cobranza[0].CodUsuarioNuevo;
                paramsToStore[9].Size = 20;

                paramsToStore[10] = new SqlParameter("@id_estado_gestion_cobranza", SqlDbType.Int);
                paramsToStore[10].Value = ListEnGS_Gestion_Cobranza[0].Id_estado_gestion_cobranza;

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

        public DataTable GS_Reasignacion_Bandeja_sp_Listar_CCI(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_Reasignacion_Bandeja_sp_Listar_CCI";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[10];

                paramsToStore[0] = new SqlParameter("@Accion", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_Gestion_Cobranza[0].Accion;

                paramsToStore[1] = new SqlParameter("@CEmpresa", SqlDbType.Int);
                paramsToStore[1].Value = ListEnGS_Gestion_Cobranza[0].nEmpresa;

                paramsToStore[2] = new SqlParameter("@dias_mora", SqlDbType.VarChar);
                paramsToStore[2].Value = ListEnGS_Gestion_Cobranza[0].dias_mora;

                paramsToStore[3] = new SqlParameter("@dias_mora_hasta", SqlDbType.VarChar);
                paramsToStore[3].Value = ListEnGS_Gestion_Cobranza[0].dias_mora_hasta;


                paramsToStore[4] = new SqlParameter("@fecha_ini", SqlDbType.VarChar);
                paramsToStore[4].Value = ListEnGS_Gestion_Cobranza[0].fecha_ini;
                paramsToStore[4].Size = 10;

                paramsToStore[5] = new SqlParameter("@fecha_fin", SqlDbType.VarChar);
                paramsToStore[5].Value = ListEnGS_Gestion_Cobranza[0].fecha_fin;
                paramsToStore[5].Size = 10;

                paramsToStore[6] = new SqlParameter("@CodTipoGestion", SqlDbType.VarChar);
                paramsToStore[6].Value = ListEnGS_Gestion_Cobranza[0].CodTipoGestion;
                paramsToStore[6].Size = 30;

                paramsToStore[7] = new SqlParameter("@CodUsuarioRegistra", SqlDbType.Int);
                paramsToStore[7].Value = ListEnGS_Gestion_Cobranza[0].CodUsuario;

                paramsToStore[8] = new SqlParameter("@nombres", SqlDbType.VarChar);
                paramsToStore[8].Value = ListEnGS_Gestion_Cobranza[0].Nombres;
                paramsToStore[8].Size = 50;

                paramsToStore[9] = new SqlParameter("@documento", SqlDbType.VarChar);
                paramsToStore[9].Value = ListEnGS_Gestion_Cobranza[0].documento;
                paramsToStore[9].Size = 20;



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

        public DataTable GS_Gestion_CarteraCobranza_Lista(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_Gestion_CarteraCobranza_sp_Listar";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[10];

                paramsToStore[0] = new SqlParameter("@Accion", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_Gestion_Cobranza[0].Accion;

                paramsToStore[1] = new SqlParameter("@CEmpresa", SqlDbType.Int);
                paramsToStore[1].Value = ListEnGS_Gestion_Cobranza[0].nEmpresa;

                paramsToStore[2] = new SqlParameter("@dias_mora", SqlDbType.VarChar);
                paramsToStore[2].Value = ListEnGS_Gestion_Cobranza[0].dias_mora;
                paramsToStore[2].Size = 250;

                paramsToStore[3] = new SqlParameter("@fecha_ini", SqlDbType.VarChar);
                paramsToStore[3].Value = ListEnGS_Gestion_Cobranza[0].fecha_ini;
                paramsToStore[3].Size = 10;

                paramsToStore[4] = new SqlParameter("@fecha_fin", SqlDbType.VarChar);
                paramsToStore[4].Value = ListEnGS_Gestion_Cobranza[0].fecha_fin;
                paramsToStore[4].Size = 10;

                paramsToStore[5] = new SqlParameter("@CodTipoGestion", SqlDbType.VarChar);
                paramsToStore[5].Value = ListEnGS_Gestion_Cobranza[0].CodTipoGestion;
                paramsToStore[5].Size = 30;

                paramsToStore[6] = new SqlParameter("@cod_JerarquiaA", SqlDbType.Int);
                paramsToStore[6].Value = ListEnGS_Gestion_Cobranza[0].cod_jerarquiaA;

                paramsToStore[7] = new SqlParameter("@cod_JerarquiaB", SqlDbType.Int);
                paramsToStore[7].Value = ListEnGS_Gestion_Cobranza[0].cod_jerarquiaB;

                paramsToStore[8] = new SqlParameter("@cod_JerarquiaC", SqlDbType.Int);
                paramsToStore[8].Value = ListEnGS_Gestion_Cobranza[0].cod_jerarquiaC;

                paramsToStore[9] = new SqlParameter("@cod_JerarquiaD", SqlDbType.Int);
                paramsToStore[9].Value = ListEnGS_Gestion_Cobranza[0].cod_jerarquiaD;

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

        public void GS_Gestion_Cobranza_UPD_Estado(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza, SqlTransaction tran)
        {
            try
            {
                #region Parametros
                SqlParameter prm_IdReg_Gestion_Cobranza = new SqlParameter();
                SqlParameter prm_id_estado_gestion_cobranza = new SqlParameter();
                SqlParameter prm_CodUsuario = new SqlParameter();
                #endregion Parametros


                #region Values


                prm_IdReg_Gestion_Cobranza.ParameterName = "@IdReg_Gestion_Cobranza";
                prm_IdReg_Gestion_Cobranza.SqlDbType = SqlDbType.Int;
                prm_IdReg_Gestion_Cobranza.Direction = ParameterDirection.Input;
                prm_IdReg_Gestion_Cobranza.Value = ListEnGS_Gestion_Cobranza[0].IdReg_Gestion_Cobranza;

                prm_id_estado_gestion_cobranza.ParameterName = "@id_estado_gestion_cobranza";
                prm_id_estado_gestion_cobranza.SqlDbType = SqlDbType.Int;
                prm_id_estado_gestion_cobranza.Direction = ParameterDirection.Input;
                prm_id_estado_gestion_cobranza.Value = ListEnGS_Gestion_Cobranza[0].Id_estado_gestion_cobranza;

                prm_CodUsuario.ParameterName = "@CodUsuarioRegistra";
                prm_CodUsuario.SqlDbType = SqlDbType.Int;
                prm_CodUsuario.Direction = ParameterDirection.Input;
                prm_CodUsuario.Value = ListEnGS_Gestion_Cobranza[0].CodUsuario;


                #endregion Values

                #region Execute
                SqlHelper.ExecuteNonQuery(tran, "GS_Gestion_Cobranza_sp_Modificar_Estado",
                                               prm_IdReg_Gestion_Cobranza, prm_id_estado_gestion_cobranza, prm_CodUsuario
                                               );
                #endregion Execute
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GS_Gestion_Cobranza_Cliente_Lista(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_Cliente_sp_Listar";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[1];


                paramsToStore[0] = new SqlParameter("@NEMPRESA", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_Gestion_Cobranza[0].nEmpresa;

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

        public DataTable GS_Gestion_Cobranza_Cliente_x_Producto_Lista(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "CR_Cliente_sp_CargaClienteProductos";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];


                paramsToStore[0] = new SqlParameter("@NEMPRESA", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_Gestion_Cobranza[0].nEmpresa;

                paramsToStore[1] = new SqlParameter("@CodigoCliente", SqlDbType.Int);
                paramsToStore[1].Value = ListEnGS_Gestion_Cobranza[0].CodigoCliente;
                //paramsToStore[1].Value = 1;

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

        public string GS_Gestion_Cobranza_INS(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza, SqlTransaction tran)
        {
            string IdReturn = String.Empty;
            SqlDataReader drParamReturn;

            SqlParameter prm_IdReg = new SqlParameter();

            SqlParameter prm_CodTipoGestion = new SqlParameter();
            SqlParameter prm_CEMPRESA = new SqlParameter();
            SqlParameter prm_CodUsuario = new SqlParameter();
            SqlParameter prm_comentario = new SqlParameter();
            SqlParameter prm_CodCLaseGestion = new SqlParameter();
            SqlParameter prm_CodEjecutado = new SqlParameter();




            try
            {

                #region Values


                prm_IdReg.ParameterName = "@IdReg";
                prm_IdReg.SqlDbType = SqlDbType.Int;
                prm_IdReg.Direction = ParameterDirection.Input;
                prm_IdReg.Value = ListEnGS_Gestion_Cobranza[0].IdReg;

                prm_CodTipoGestion.ParameterName = "@CodTipoGestion";
                prm_CodTipoGestion.SqlDbType = SqlDbType.Int;
                prm_CodTipoGestion.Direction = ParameterDirection.Input;
                prm_CodTipoGestion.Value = ListEnGS_Gestion_Cobranza[0].CodTipoGestion;

                prm_CEMPRESA.ParameterName = "@CEMPRESA";
                prm_CEMPRESA.SqlDbType = SqlDbType.Char;
                prm_CEMPRESA.Direction = ParameterDirection.Input;
                prm_CEMPRESA.Size = 2;
                prm_CEMPRESA.Value = ListEnGS_Gestion_Cobranza[0].nEmpresa;

                prm_CodUsuario.ParameterName = "@CodUsuarioRegistra";
                prm_CodUsuario.SqlDbType = SqlDbType.Int;
                prm_CodUsuario.Direction = ParameterDirection.Input;
                prm_CodUsuario.Value = ListEnGS_Gestion_Cobranza[0].CodUsuario;

                prm_comentario.ParameterName = "@comentario";
                prm_comentario.SqlDbType = SqlDbType.VarChar;
                prm_comentario.Direction = ParameterDirection.Input;
                prm_comentario.Size = 5000;
                prm_comentario.Value = ListEnGS_Gestion_Cobranza[0].comentario;

                prm_CodCLaseGestion.ParameterName = "@CodCLaseGestion";
                prm_CodCLaseGestion.SqlDbType = SqlDbType.Int;
                prm_CodCLaseGestion.Direction = ParameterDirection.Input;
                prm_CodCLaseGestion.Value = ListEnGS_Gestion_Cobranza[0].CodCLaseGestion;

                prm_CodEjecutado.ParameterName = "@CodEjecutado";
                prm_CodEjecutado.SqlDbType = SqlDbType.Int;
                prm_CodEjecutado.Direction = ParameterDirection.Input;
                prm_CodEjecutado.Value = ListEnGS_Gestion_Cobranza[0].CodEjecutado;

                //prm_CodEjecutado.ParameterName = "@FechaReagenda";
                //prm_CodEjecutado.SqlDbType = SqlDbType.DateTime;
                //prm_CodEjecutado.Direction = ParameterDirection.Input;
                //prm_CodEjecutado.Value = ListEnGS_Gestion_Cobranza[0].FechaReagenda;

                #endregion Values


                drParamReturn = SqlHelper.ExecuteReader(tran, "dbo.GS_Gestion_Cobranza_sp_Insertar",
                                               prm_IdReg, prm_CodTipoGestion, prm_CEMPRESA, prm_CodUsuario, prm_comentario, prm_CodCLaseGestion, prm_CodEjecutado
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


        //GESTION UPDATE **********************

        public string GS_Gestion_Cobranza_UPD(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza, SqlTransaction tran)
        {
            string IdReturn = String.Empty;
            SqlDataReader drParamReturn;

            SqlParameter prm_IdReg_Gestion_Cobranza = new SqlParameter();
            SqlParameter prm_CodTipoGestion = new SqlParameter();
            SqlParameter prm_IdReg = new SqlParameter();

            SqlParameter prm_CodUsuario = new SqlParameter();
            SqlParameter prm_CodCLaseGestion = new SqlParameter();
            SqlParameter prm_CodEjecutado = new SqlParameter();
            SqlParameter prm_comentario = new SqlParameter();

            SqlParameter prm_FechaVisita_dmy = new SqlParameter();
            SqlParameter prm_FechaVisita_hh = new SqlParameter();
            SqlParameter prm_FechaVisita_mm = new SqlParameter();
            SqlParameter prm_dias_mora = new SqlParameter();
            try
            {
                #region Values

                prm_IdReg_Gestion_Cobranza.ParameterName = "@IdReg_Gestion_Cobranza";
                prm_IdReg_Gestion_Cobranza.SqlDbType = SqlDbType.Int;
                prm_IdReg_Gestion_Cobranza.Direction = ParameterDirection.Input;
                prm_IdReg_Gestion_Cobranza.Value = ListEnGS_Gestion_Cobranza[0].IdReg_Gestion_Cobranza;

                prm_CodTipoGestion.ParameterName = "@CodTipoGestion";
                prm_CodTipoGestion.SqlDbType = SqlDbType.Int;
                prm_CodTipoGestion.Direction = ParameterDirection.Input;
                prm_CodTipoGestion.Value = ListEnGS_Gestion_Cobranza[0].CodTipoGestion;

                prm_IdReg.ParameterName = "@IdReg";
                prm_IdReg.SqlDbType = SqlDbType.Int;
                prm_IdReg.Direction = ParameterDirection.Input;
                prm_IdReg.Value = ListEnGS_Gestion_Cobranza[0].IdReg;

                prm_CodUsuario.ParameterName = "@CodUsuarioRegistra";
                prm_CodUsuario.SqlDbType = SqlDbType.Int;
                prm_CodUsuario.Direction = ParameterDirection.Input;
                prm_CodUsuario.Value = ListEnGS_Gestion_Cobranza[0].CodUsuario;

                prm_CodCLaseGestion.ParameterName = "@CodCLaseGestion";
                prm_CodCLaseGestion.SqlDbType = SqlDbType.Int;
                prm_CodCLaseGestion.Direction = ParameterDirection.Input;
                prm_CodCLaseGestion.Value = ListEnGS_Gestion_Cobranza[0].CodCLaseGestion;

                prm_CodEjecutado.ParameterName = "@CodEjecutado";
                prm_CodEjecutado.SqlDbType = SqlDbType.Int;
                prm_CodEjecutado.Direction = ParameterDirection.Input;
                prm_CodEjecutado.Value = ListEnGS_Gestion_Cobranza[0].CodEjecutado;

                prm_comentario.ParameterName = "@comentario";
                prm_comentario.SqlDbType = SqlDbType.VarChar;
                prm_comentario.Direction = ParameterDirection.Input;
                prm_comentario.Size = 5000;
                prm_comentario.Value = ListEnGS_Gestion_Cobranza[0].comentario;

                prm_FechaVisita_dmy.ParameterName = "@FechaVisita_dmy";
                prm_FechaVisita_dmy.SqlDbType = SqlDbType.VarChar;
                prm_FechaVisita_dmy.Direction = ParameterDirection.Input;
                prm_FechaVisita_dmy.Size = 10;
                prm_FechaVisita_dmy.Value = ListEnGS_Gestion_Cobranza[0].FechaVisita_dmy;

                prm_FechaVisita_hh.ParameterName = "@FechaVisita_hh";
                prm_FechaVisita_hh.SqlDbType = SqlDbType.VarChar;
                prm_FechaVisita_hh.Direction = ParameterDirection.Input;
                prm_FechaVisita_hh.Size = 2;
                prm_FechaVisita_hh.Value = ListEnGS_Gestion_Cobranza[0].FechaVisita_hh;

                prm_FechaVisita_mm.ParameterName = "@FechaVisita_mm";
                prm_FechaVisita_mm.SqlDbType = SqlDbType.VarChar;
                prm_FechaVisita_mm.Direction = ParameterDirection.Input;
                prm_FechaVisita_mm.Size = 2;
                prm_FechaVisita_mm.Value = ListEnGS_Gestion_Cobranza[0].FechaVisita_mm;

                prm_dias_mora.ParameterName = "@dias_mora";
                prm_dias_mora.SqlDbType = SqlDbType.Int;
                prm_dias_mora.Direction = ParameterDirection.Input;
                prm_dias_mora.Value = ListEnGS_Gestion_Cobranza[0].dias_mora;

                #endregion Values


                drParamReturn = SqlHelper.ExecuteReader(tran, "dbo.GS_Gestion_Cobranza_sp_Modificar",
                                               prm_IdReg_Gestion_Cobranza, prm_CodTipoGestion, prm_IdReg, prm_CodUsuario, prm_CodCLaseGestion, prm_CodEjecutado,
                                               prm_comentario, prm_FechaVisita_dmy, prm_FechaVisita_hh, prm_FechaVisita_mm, prm_dias_mora
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
        //GS_Gestion_Cobranza_sp_Modificar_Carta_Cobranza
        public string GS_Gestion_Cobranza_UPD_Carta_Cobranza(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza, SqlTransaction tran)
        {
            string IdReturn = String.Empty;
            SqlDataReader drParamReturn;

            SqlParameter prm_IdReg_Gestion_Cobranza = new SqlParameter();
            SqlParameter prm_CodUsuario = new SqlParameter();
            SqlParameter prm_CodCLaseGestion = new SqlParameter();
            SqlParameter prm_CodEjecutado = new SqlParameter();
            SqlParameter prm_comentario = new SqlParameter();
            try
            {

                #region Values

                prm_IdReg_Gestion_Cobranza.ParameterName = "@IdReg_Gestion_Cobranza";
                prm_IdReg_Gestion_Cobranza.SqlDbType = SqlDbType.Int;
                prm_IdReg_Gestion_Cobranza.Direction = ParameterDirection.Input;
                prm_IdReg_Gestion_Cobranza.Value = ListEnGS_Gestion_Cobranza[0].IdReg_Gestion_Cobranza;

                prm_CodUsuario.ParameterName = "@CodUsuarioRegistra";
                prm_CodUsuario.SqlDbType = SqlDbType.Int;
                prm_CodUsuario.Direction = ParameterDirection.Input;
                prm_CodUsuario.Value = ListEnGS_Gestion_Cobranza[0].CodUsuario;

                prm_CodCLaseGestion.ParameterName = "@CodCLaseGestion";
                prm_CodCLaseGestion.SqlDbType = SqlDbType.Int;
                prm_CodCLaseGestion.Direction = ParameterDirection.Input;
                prm_CodCLaseGestion.Value = ListEnGS_Gestion_Cobranza[0].CodCLaseGestion;

                prm_CodEjecutado.ParameterName = "@CodEjecutado";
                prm_CodEjecutado.SqlDbType = SqlDbType.Int;
                prm_CodEjecutado.Direction = ParameterDirection.Input;
                prm_CodEjecutado.Value = ListEnGS_Gestion_Cobranza[0].CodEjecutado;

                prm_comentario.ParameterName = "@comentario";
                prm_comentario.SqlDbType = SqlDbType.VarChar;
                prm_comentario.Direction = ParameterDirection.Input;
                prm_comentario.Size = 5000;
                prm_comentario.Value = ListEnGS_Gestion_Cobranza[0].comentario;


                #endregion Values


                drParamReturn = SqlHelper.ExecuteReader(tran, "dbo.GS_Gestion_Cobranza_sp_Modificar_Carta_Cobranza",
                                               prm_IdReg_Gestion_Cobranza, prm_CodUsuario, prm_CodCLaseGestion, prm_CodEjecutado,
                                             prm_comentario);
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

        public string GS_Gestion_Cobranza_Reagendar_UPD(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza, SqlTransaction tran)
        {
            string IdReturn = String.Empty;
            SqlDataReader drParamReturn;

            SqlParameter prm_IdReg_Gestion_Cobranza = new SqlParameter();
            SqlParameter prm_CodUsuario = new SqlParameter();
            SqlParameter prm_FechaReagenda_dmy = new SqlParameter();
            SqlParameter prm_FechaReagenda_hh = new SqlParameter();
            SqlParameter prm_FechaReagenda_mm = new SqlParameter();

            try
            {

                #region Values

                prm_IdReg_Gestion_Cobranza.ParameterName = "@IdReg_Gestion_Cobranza";
                prm_IdReg_Gestion_Cobranza.SqlDbType = SqlDbType.Int;
                prm_IdReg_Gestion_Cobranza.Direction = ParameterDirection.Input;
                prm_IdReg_Gestion_Cobranza.Value = ListEnGS_Gestion_Cobranza[0].IdReg_Gestion_Cobranza;

                prm_CodUsuario.ParameterName = "@CodUsuarioRegistra";
                prm_CodUsuario.SqlDbType = SqlDbType.Int;
                prm_CodUsuario.Direction = ParameterDirection.Input;
                prm_CodUsuario.Value = ListEnGS_Gestion_Cobranza[0].CodUsuario;

                prm_FechaReagenda_dmy.ParameterName = "@FechaReagenda_dmy";
                prm_FechaReagenda_dmy.SqlDbType = SqlDbType.VarChar;
                prm_FechaReagenda_dmy.Direction = ParameterDirection.Input;
                prm_FechaReagenda_dmy.Size = 10;
                prm_FechaReagenda_dmy.Value = ListEnGS_Gestion_Cobranza[0].FechaReagenda_dmy;

                prm_FechaReagenda_hh.ParameterName = "@FechaReagenda_hh";
                prm_FechaReagenda_hh.SqlDbType = SqlDbType.VarChar;
                prm_FechaReagenda_hh.Direction = ParameterDirection.Input;
                prm_FechaReagenda_hh.Size = 2;
                prm_FechaReagenda_hh.Value = ListEnGS_Gestion_Cobranza[0].FechaReagenda_hh;

                prm_FechaReagenda_mm.ParameterName = "@FechaReagenda_mm";
                prm_FechaReagenda_mm.SqlDbType = SqlDbType.VarChar;
                prm_FechaReagenda_mm.Direction = ParameterDirection.Input;
                prm_FechaReagenda_mm.Size = 2;
                prm_FechaReagenda_mm.Value = ListEnGS_Gestion_Cobranza[0].FechaReagenda_mm;

                #endregion Values


                drParamReturn = SqlHelper.ExecuteReader(tran, "GS_Gestion_Cobranza_Reagendar_sp_Modificar",
                                               prm_IdReg_Gestion_Cobranza, prm_CodUsuario, prm_FechaReagenda_dmy, prm_FechaReagenda_hh, prm_FechaReagenda_mm
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


        /*
         * Actualizar la fecha de reagendación         
         */
        public string GS_Gestion_Cobranza_Reagendar_UPD_Fecha(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza, SqlTransaction tran)
        {
            string IdReturn = String.Empty;
            SqlDataReader drParamReturn;

            SqlParameter prm_IdReg_Gestion_Cobranza = new SqlParameter();
            SqlParameter prm_FechaReagenda_dmy = new SqlParameter();
            SqlParameter prm_FechaReagenda_hh = new SqlParameter();
            SqlParameter prm_FechaReagenda_mm = new SqlParameter();

            try
            {

                #region Values

                prm_IdReg_Gestion_Cobranza.ParameterName = "@IdReg_Gestion_Cobranza";
                prm_IdReg_Gestion_Cobranza.SqlDbType = SqlDbType.Int;
                prm_IdReg_Gestion_Cobranza.Direction = ParameterDirection.Input;
                prm_IdReg_Gestion_Cobranza.Value = ListEnGS_Gestion_Cobranza[0].IdReg_Gestion_Cobranza;

                prm_FechaReagenda_dmy.ParameterName = "@FechaReagenda_dmy";
                prm_FechaReagenda_dmy.SqlDbType = SqlDbType.VarChar;
                prm_FechaReagenda_dmy.Direction = ParameterDirection.Input;
                prm_FechaReagenda_dmy.Size = 10;
                prm_FechaReagenda_dmy.Value = ListEnGS_Gestion_Cobranza[0].FechaReagenda_dmy;

                prm_FechaReagenda_hh.ParameterName = "@FechaReagenda_hh";
                prm_FechaReagenda_hh.SqlDbType = SqlDbType.VarChar;
                prm_FechaReagenda_hh.Direction = ParameterDirection.Input;
                prm_FechaReagenda_hh.Size = 2;
                prm_FechaReagenda_hh.Value = ListEnGS_Gestion_Cobranza[0].FechaReagenda_hh;

                prm_FechaReagenda_mm.ParameterName = "@FechaReagenda_mm";
                prm_FechaReagenda_mm.SqlDbType = SqlDbType.VarChar;
                prm_FechaReagenda_mm.Direction = ParameterDirection.Input;
                prm_FechaReagenda_mm.Size = 2;
                prm_FechaReagenda_mm.Value = ListEnGS_Gestion_Cobranza[0].FechaReagenda_mm;

                #endregion Values


                drParamReturn = SqlHelper.ExecuteReader(tran, "GS_Gestion_Cobranza_Reagendar_sp_Modificar_Fecha",
                                               prm_IdReg_Gestion_Cobranza, prm_FechaReagenda_dmy, prm_FechaReagenda_hh, prm_FechaReagenda_mm
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


        public DataTable GS_Gestion_Cobranza_Reg(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_Gestion_Cobranza_sp_Registro";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];


                paramsToStore[0] = new SqlParameter("@IdReg_Gestion_Cobranza", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_Gestion_Cobranza[0].IdReg_Gestion_Cobranza;
                /*Modif. Gestiones Internas 15/06/17*/
                paramsToStore[1] = new SqlParameter("@NEmpresa", SqlDbType.Int);
                paramsToStore[1].Value = ListEnGS_Gestion_Cobranza[0].nEmpresa;
                /*Fin Modif.*/

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

        public DataTable GS_Gestion_Cobranza_GestionesInternas_Registro(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_Gestion_Cobranza_GestionesInternas_sp_Registro";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];


                paramsToStore[0] = new SqlParameter("@IdReg_Gestion_Cobranza", SqlDbType.VarChar);
                paramsToStore[0].Value = ListEnGS_Gestion_Cobranza[0].IdReg_Gestion_Cobranza;
                /*Modif. Gestiones Internas 15/06/17*/
                paramsToStore[1] = new SqlParameter("@NEmpresa", SqlDbType.Int);
                paramsToStore[1].Value = ListEnGS_Gestion_Cobranza[0].nEmpresa;
                /*Fin Modif.*/

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

        public string GS_Gestion_Cobranza_SubTarea_INS(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza, SqlTransaction tran)
        {
            string IdReturn = String.Empty;
            SqlDataReader drParamReturn;

            /*Modif. 101016*/
            SqlParameter prm_IdReg_Gestion_Cobranza = new SqlParameter();
            /*Fin modif.*/
            SqlParameter prm_IdReg = new SqlParameter();
            SqlParameter prm_CodTipoGestion = new SqlParameter();
            SqlParameter prm_CEMPRESA = new SqlParameter();
            SqlParameter prm_CodUsuario = new SqlParameter();
            SqlParameter prm_TramoAcelerado = new SqlParameter();
            SqlParameter prm_FechaLimite = new SqlParameter();
            SqlParameter prm_CodUsuarioNuevo = new SqlParameter();

            try
            {

                #region Values

                /*Modif. 101016*/
                prm_IdReg_Gestion_Cobranza.ParameterName = "@IdReg_Gestion_Cobranza_Padre";
                prm_IdReg_Gestion_Cobranza.SqlDbType = SqlDbType.Int;
                prm_IdReg_Gestion_Cobranza.Direction = ParameterDirection.Input;
                prm_IdReg_Gestion_Cobranza.Value = ListEnGS_Gestion_Cobranza[0].IdReg_Gestion_Cobranza;
                /*Fin modif.*/
                prm_IdReg.ParameterName = "@IdReg";
                prm_IdReg.SqlDbType = SqlDbType.Int;
                prm_IdReg.Direction = ParameterDirection.Input;
                prm_IdReg.Value = ListEnGS_Gestion_Cobranza[0].IdReg;

                prm_CodTipoGestion.ParameterName = "@CodTipoGestion";
                prm_CodTipoGestion.SqlDbType = SqlDbType.Int;
                prm_CodTipoGestion.Direction = ParameterDirection.Input;
                prm_CodTipoGestion.Value = ListEnGS_Gestion_Cobranza[0].CodTipoGestion;

                prm_CEMPRESA.ParameterName = "@CEMPRESA";
                prm_CEMPRESA.SqlDbType = SqlDbType.Char;
                prm_CEMPRESA.Direction = ParameterDirection.Input;
                prm_CEMPRESA.Size = 2;
                prm_CEMPRESA.Value = ListEnGS_Gestion_Cobranza[0].nEmpresa;

                prm_CodUsuario.ParameterName = "@CodUsuarioRegistra";
                prm_CodUsuario.SqlDbType = SqlDbType.Int;
                prm_CodUsuario.Direction = ParameterDirection.Input;
                prm_CodUsuario.Value = ListEnGS_Gestion_Cobranza[0].CodUsuario;

                prm_TramoAcelerado.ParameterName = "@TramoAcelerado";
                prm_TramoAcelerado.SqlDbType = SqlDbType.Int;
                prm_TramoAcelerado.Direction = ParameterDirection.Input;
                prm_TramoAcelerado.Value = ListEnGS_Gestion_Cobranza[0].TramoAcelerado;

                prm_FechaLimite.ParameterName = "@FechaLimite";
                prm_FechaLimite.SqlDbType = SqlDbType.DateTime;
                prm_FechaLimite.Direction = ParameterDirection.Input;
                prm_FechaLimite.Value = ListEnGS_Gestion_Cobranza[0].FechaLimite;

                prm_CodUsuarioNuevo.ParameterName = "@CodUsuarioNuevo";
                prm_CodUsuarioNuevo.SqlDbType = SqlDbType.Int;
                prm_CodUsuarioNuevo.Direction = ParameterDirection.Input;
                prm_CodUsuarioNuevo.Value = ListEnGS_Gestion_Cobranza[0].CodUsuarioNuevo;


                #endregion Values


                drParamReturn = SqlHelper.ExecuteReader(tran, "dbo.GS_Gestion_Cobranza_SubTarea_sp_Insertar",
                                               prm_IdReg, prm_CodTipoGestion, prm_CEMPRESA, prm_CodUsuario, prm_IdReg_Gestion_Cobranza, prm_TramoAcelerado
                                               , prm_FechaLimite, prm_CodUsuarioNuevo
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

        public string GS_Gestion_Cobranza_SubTarea_INS_JEFE(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza, SqlTransaction tran)
        {
            string IdReturn = String.Empty;
            SqlDataReader drParamReturn;

            SqlParameter prm_IdReg = new SqlParameter();
            SqlParameter prm_CodTipoGestion = new SqlParameter();
            SqlParameter prm_CEMPRESA = new SqlParameter();
            SqlParameter prm_CodUsuario = new SqlParameter();
            try
            {

                #region Values


                prm_IdReg.ParameterName = "@IdReg";
                prm_IdReg.SqlDbType = SqlDbType.Int;
                prm_IdReg.Direction = ParameterDirection.Input;
                prm_IdReg.Value = ListEnGS_Gestion_Cobranza[0].IdReg;

                prm_CodTipoGestion.ParameterName = "@CodTipoGestion";
                prm_CodTipoGestion.SqlDbType = SqlDbType.Int;
                prm_CodTipoGestion.Direction = ParameterDirection.Input;
                prm_CodTipoGestion.Value = ListEnGS_Gestion_Cobranza[0].CodTipoGestion;

                prm_CEMPRESA.ParameterName = "@CEMPRESA";
                prm_CEMPRESA.SqlDbType = SqlDbType.Char;
                prm_CEMPRESA.Direction = ParameterDirection.Input;
                prm_CEMPRESA.Size = 2;
                prm_CEMPRESA.Value = ListEnGS_Gestion_Cobranza[0].nEmpresa;

                prm_CodUsuario.ParameterName = "@CodUsuarioRegistra";
                prm_CodUsuario.SqlDbType = SqlDbType.Int;
                prm_CodUsuario.Direction = ParameterDirection.Input;
                prm_CodUsuario.Value = ListEnGS_Gestion_Cobranza[0].CodUsuario;

                #endregion Values


                drParamReturn = SqlHelper.ExecuteReader(tran, "dbo.GS_Gestion_Cobranza_SubTarea_sp_Insertar_JEFE",
                                               prm_IdReg, prm_CodTipoGestion, prm_CEMPRESA, prm_CodUsuario
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

        public DataTable GS_Gestion_Cobranza_SubTarea_Gestion_ClasexEjecutado_Lista(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_ClaseGestionesxEjecutado_SubTarea_sp_Listar";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[1];

                paramsToStore[0] = new SqlParameter("@CodClaseGestion", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_Gestion_Cobranza[0].CodCLaseGestion;


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

        public DataTable GS_Gestion_Cobranza_SubTarea_Gestion_ClasexTipoGestion_Lista(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_ClaseGestionesxTipoGestion_SubTarea_sp_Listar";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[1];

                paramsToStore[0] = new SqlParameter("@CodClaseGestion", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_Gestion_Cobranza[0].CodCLaseGestion;


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

        public DataTable GS_Gestion_Cobranza_SubTarea_Gestion_ClasexTipoGestion_Lista_Todos()
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_ClaseGestionesxTipoGestion_SubTarea_sp_Listar_Todos";
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

        #region campaña
        public string GS_Campaña_SubTarea_INS(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza, SqlTransaction tran)
        {
            string IdReturn = String.Empty;
            SqlDataReader drParamReturn;

            SqlParameter prm_IdReg = new SqlParameter();
            SqlParameter prm_CodTipoGestion = new SqlParameter();
            SqlParameter prm_CEMPRESA = new SqlParameter();
            SqlParameter prm_CodUsuario = new SqlParameter();
            SqlParameter prm_id_campaña = new SqlParameter();
            try
            {

                #region Values


                prm_IdReg.ParameterName = "@IdReg";
                prm_IdReg.SqlDbType = SqlDbType.Int;
                prm_IdReg.Direction = ParameterDirection.Input;
                prm_IdReg.Value = ListEnGS_Gestion_Cobranza[0].IdReg;

                prm_CodTipoGestion.ParameterName = "@CodTipoGestion";
                prm_CodTipoGestion.SqlDbType = SqlDbType.Int;
                prm_CodTipoGestion.Direction = ParameterDirection.Input;
                prm_CodTipoGestion.Value = ListEnGS_Gestion_Cobranza[0].CodTipoGestion;

                prm_CEMPRESA.ParameterName = "@CEMPRESA";
                prm_CEMPRESA.SqlDbType = SqlDbType.Char;
                prm_CEMPRESA.Direction = ParameterDirection.Input;
                prm_CEMPRESA.Size = 2;
                prm_CEMPRESA.Value = ListEnGS_Gestion_Cobranza[0].nEmpresa;

                prm_CodUsuario.ParameterName = "@CodUsuarioRegistra";
                prm_CodUsuario.SqlDbType = SqlDbType.Int;
                prm_CodUsuario.Direction = ParameterDirection.Input;
                prm_CodUsuario.Value = ListEnGS_Gestion_Cobranza[0].CodUsuario;

                prm_id_campaña.ParameterName = "@id_campaña";
                prm_id_campaña.SqlDbType = SqlDbType.Int;
                prm_id_campaña.Direction = ParameterDirection.Input;
                prm_id_campaña.Value = ListEnGS_Gestion_Cobranza[0].id_campaña;

                #endregion Values


                drParamReturn = SqlHelper.ExecuteReader(tran, "dbo.GS_Campaña_SubTarea_sp_Insertar",
                                               prm_IdReg, prm_CodTipoGestion, prm_CEMPRESA, prm_CodUsuario, prm_id_campaña
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

        public DataTable GS_Gestion_Cobranza_x_Campaña_Lista(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_Gestion_Cobranza_x_Campaña_sp_Listar";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[6];

                paramsToStore[0] = new SqlParameter("@Accion", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_Gestion_Cobranza[0].Accion;

                paramsToStore[1] = new SqlParameter("@CEmpresa", SqlDbType.Int);
                paramsToStore[1].Value = ListEnGS_Gestion_Cobranza[0].nEmpresa;

                paramsToStore[2] = new SqlParameter("@dias_mora", SqlDbType.VarChar);
                paramsToStore[2].Value = ListEnGS_Gestion_Cobranza[0].dias_mora;
                paramsToStore[2].Size = 250;

                paramsToStore[3] = new SqlParameter("@fecha_ini", SqlDbType.VarChar);
                paramsToStore[3].Value = ListEnGS_Gestion_Cobranza[0].fecha_ini;
                paramsToStore[3].Size = 10;

                paramsToStore[4] = new SqlParameter("@fecha_fin", SqlDbType.VarChar);
                paramsToStore[4].Value = ListEnGS_Gestion_Cobranza[0].fecha_fin;
                paramsToStore[4].Size = 10;

                paramsToStore[5] = new SqlParameter("@CodTipoGestion", SqlDbType.VarChar);
                paramsToStore[5].Value = ListEnGS_Gestion_Cobranza[0].CodTipoGestion;
                paramsToStore[5].Size = 30;

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

        #endregion campaña

        #region visitas
        public DataSet GS_Gestion_Cobranza_x_Visitas_Lista(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza, string pcFiltro)
        {
            DataSet DS = new DataSet();
            //DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_Visitas_sp_Listar2";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];

                paramsToStore[0] = new SqlParameter("@cEmpresa", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_Gestion_Cobranza[0].nEmpresa;

                paramsToStore[1] = new SqlParameter("@cFiltro", SqlDbType.VarChar);
                paramsToStore[1].Value = pcFiltro;
                paramsToStore[1].Size = 5000;

                //paramsToStore[2] = new SqlParameter("@fecha_fin", SqlDbType.VarChar);
                //paramsToStore[2].Value = ListEnGS_Gestion_Cobranza[0].fecha_fin;
                //paramsToStore[2].Size = 10;

                //paramsToStore[3] = new SqlParameter("@CodUsuario_Asesores", SqlDbType.Int);
                //paramsToStore[3].Value = ListEnGS_Gestion_Cobranza[0].CodUsuario_Asesores;

                //paramsToStore[4] = new SqlParameter("@MontoCuota", SqlDbType.VarChar);
                //paramsToStore[4].Value = ListEnGS_Gestion_Cobranza[0].MontoCuota;
                //paramsToStore[4].Size = 30;

                //paramsToStore[5] = new SqlParameter("@dias_mora", SqlDbType.VarChar);
                //paramsToStore[5].Value = ListEnGS_Gestion_Cobranza[0].dias_mora;
                //paramsToStore[5].Size = 30;

                //paramsToStore[6] = new SqlParameter("@Distrito", SqlDbType.VarChar);
                //paramsToStore[6].Value = ListEnGS_Gestion_Cobranza[0].Distrito;
                //paramsToStore[6].Size = 60;

                //paramsToStore[7] = new SqlParameter("@CodTipoDir", SqlDbType.Int);
                //paramsToStore[7].Value = ListEnGS_Gestion_Cobranza[0].CodTipoDir;

                //paramsToStore[8] = new SqlParameter("@Convenio", SqlDbType.VarChar);
                //paramsToStore[8].Value = ListEnGS_Gestion_Cobranza[0].Convenio;
                //paramsToStore[8].Size = 1;

                //paramsToStore[9] = new SqlParameter("@TelefonoSi", SqlDbType.VarChar);
                //paramsToStore[9].Value = ListEnGS_Gestion_Cobranza[0].TelefonoSi;
                //paramsToStore[9].Size = 1;

                //paramsToStore[10] = new SqlParameter("@Id_carga", SqlDbType.Int);
                //paramsToStore[10].Value = ListEnGS_Gestion_Cobranza[0].Id_carga;

                //paramsToStore[11] = new SqlParameter("@codUsuario_Reasignado", SqlDbType.Int);
                //paramsToStore[11].Value = ListEnGS_Gestion_Cobranza[0].CodUsuario_Reasignado;

                //paramsToStore[12] = new SqlParameter("@codTipoGestion", SqlDbType.Int);
                //paramsToStore[12].Value = ListEnGS_Gestion_Cobranza[0].CodTipoGestion;

                adp.SelectCommand.Parameters.AddRange(paramsToStore);

                //adp.Fill(DS, "DataTable1");
                adp.Fill(DS);

                //dt = DS.Tables["DataTable1"];

                return DS;
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public string GS_Gestion_Cobranza_x_Visitas_UPD(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza, SqlTransaction tran)
        {
            string IdReturn = String.Empty;
            SqlDataReader drParamReturn;

            SqlParameter prm_IdReg_Gestion_Cobranza = new SqlParameter();

            SqlParameter prm_FechaVisita_dmy = new SqlParameter();
            SqlParameter prm_FechaVisita_hh = new SqlParameter();
            SqlParameter prm_FechaVisita_mm = new SqlParameter();

            SqlParameter prm_CodUsuario = new SqlParameter();
            try
            {
                #region Values

                prm_IdReg_Gestion_Cobranza.ParameterName = "@IdReg_Gestion_Cobranza";
                prm_IdReg_Gestion_Cobranza.SqlDbType = SqlDbType.Int;
                prm_IdReg_Gestion_Cobranza.Direction = ParameterDirection.Input;
                prm_IdReg_Gestion_Cobranza.Value = ListEnGS_Gestion_Cobranza[0].IdReg_Gestion_Cobranza;

                prm_FechaVisita_dmy.ParameterName = "@FechaVisita_dmy";
                prm_FechaVisita_dmy.SqlDbType = SqlDbType.VarChar;
                prm_FechaVisita_dmy.Direction = ParameterDirection.Input;
                prm_FechaVisita_dmy.Size = 10;
                prm_FechaVisita_dmy.Value = ListEnGS_Gestion_Cobranza[0].FechaVisita_dmy;

                prm_FechaVisita_hh.ParameterName = "@FechaVisita_hh";
                prm_FechaVisita_hh.SqlDbType = SqlDbType.VarChar;
                prm_FechaVisita_hh.Direction = ParameterDirection.Input;
                prm_FechaVisita_hh.Size = 2;
                prm_FechaVisita_hh.Value = ListEnGS_Gestion_Cobranza[0].FechaVisita_hh;

                prm_FechaVisita_mm.ParameterName = "@FechaVisita_mm";
                prm_FechaVisita_mm.SqlDbType = SqlDbType.VarChar;
                prm_FechaVisita_mm.Direction = ParameterDirection.Input;
                prm_FechaVisita_mm.Size = 2;
                prm_FechaVisita_mm.Value = ListEnGS_Gestion_Cobranza[0].FechaVisita_mm;

                prm_CodUsuario.ParameterName = "@CodUsuarioRegistra";
                prm_CodUsuario.SqlDbType = SqlDbType.Int;
                prm_CodUsuario.Direction = ParameterDirection.Input;
                prm_CodUsuario.Value = ListEnGS_Gestion_Cobranza[0].CodUsuario;


                #endregion Values

                drParamReturn = SqlHelper.ExecuteReader(tran, "dbo.GS_Visitas_sp_Modificar",
                                               prm_IdReg_Gestion_Cobranza, prm_FechaVisita_dmy, prm_FechaVisita_hh, prm_FechaVisita_mm, prm_CodUsuario
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

        public DataSet GS_Visitas_Calendario_DS(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "dbo.GS_Visitas_Calendario_sp_Listar";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[4];

                paramsToStore[0] = new SqlParameter("@CEmpresa", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_Gestion_Cobranza[0].nEmpresa;


                paramsToStore[1] = new SqlParameter("@fechaini", SqlDbType.VarChar);
                paramsToStore[1].Value = ListEnGS_Gestion_Cobranza[0].fecha_ini;
                paramsToStore[1].Size = 30;

                paramsToStore[2] = new SqlParameter("@CodUsuario_Asesores", SqlDbType.Int);
                paramsToStore[2].Value = ListEnGS_Gestion_Cobranza[0].CodUsuario_Asesores;

                paramsToStore[3] = new SqlParameter("@codUsuario_Asignado", SqlDbType.Int);
                paramsToStore[3].Value = ListEnGS_Gestion_Cobranza[0].CodUsuario_Reasignado;

                adp.SelectCommand.Parameters.AddRange(paramsToStore);
                adp.Fill(DS, "DataSet1");
                //dt = DS.Tables["DataTable1"];
                Conn.Close();
                return DS;
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable GS_Visitas_DesCargaMasiva(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "CR_Cliente_sp_ListarCargasMasiva";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[1];

                paramsToStore[0] = new SqlParameter("@NEMPRESA", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_Gestion_Cobranza[0].nEmpresa;

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

        public DataTable GS_Gestion_Cobranza_Asesores_x_Administrador_Lista(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString);
                /*Modificado 16/05/17 Filtros*/
                sqlCommand = "GS_Asesores_x_Administrador_sp_Listar";
                //sqlCommand = "GS_JerarquiaD_x_Administrador_sp_Listar";
                /*Fin modif.*/
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];

                paramsToStore[0] = new SqlParameter("@nEMPRESA", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_Gestion_Cobranza[0].nEmpresa;
                paramsToStore[1] = new SqlParameter("@codAdm", SqlDbType.Int);
                paramsToStore[1].Value = ListEnGS_Gestion_Cobranza[0].CodUsuario;

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

        public DataTable GS_Gestion_Cobranza_UsuarioRol_Lista(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString);
                /*Modificado 16/05/17 Filtros*/
                //sqlCommand = "GS_Asesores_x_Administrador_sp_Listar";
                sqlCommand = "GS_UsuarioRol_sp_Listar";
                //sqlCommand = "GS_JerarquiaD_x_Administrador_sp_Listar";
                /*Fin modif.*/
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];

                paramsToStore[0] = new SqlParameter("@nEMPRESA", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_Gestion_Cobranza[0].nEmpresa;
                paramsToStore[1] = new SqlParameter("@codAdm", SqlDbType.Int);
                paramsToStore[1].Value = ListEnGS_Gestion_Cobranza[0].CodUsuario;

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

        public DataTable GS_JerarquiaD_x_Administrador_sp_Listar(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString);
                /*Modificado 16/05/17 Filtros*/
                sqlCommand = "GS_JerarquiaD_x_Administrador_sp_Listar";
                /*Fin modif.*/
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];

                paramsToStore[0] = new SqlParameter("@nEMPRESA", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_Gestion_Cobranza[0].nEmpresa;
                paramsToStore[1] = new SqlParameter("@codAdm", SqlDbType.Int);
                paramsToStore[1].Value = ListEnGS_Gestion_Cobranza[0].CodUsuario;

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

        public DataTable GS_Gestion_Cobranza_Ejecutores_Listar(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString);
                /*Modificado Gestiones Internas 09/06/17 */
                sqlCommand = "GS_Gestion_Cobranza_Ejecutores_Listar";
                /*Fin modif.*/
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[3];

                paramsToStore[0] = new SqlParameter("@NEmpresa", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_Gestion_Cobranza[0].nEmpresa;
                paramsToStore[1] = new SqlParameter("@Id_Ejectuores", SqlDbType.Int);
                paramsToStore[1].Value = ListEnGS_Gestion_Cobranza[0].Id_ejecutores;
                paramsToStore[2] = new SqlParameter("@IdReg_Gestion_Cobranza", SqlDbType.Int);
                paramsToStore[2].Value = ListEnGS_Gestion_Cobranza[0].IdReg_Gestion_Cobranza;

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

        public DataTable GS_Gestion_Cobranza_Cliente_x_Asesor_Lista(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_Cliente_x_Asesor_sp_Listar";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[4];

                paramsToStore[0] = new SqlParameter("@NEMPRESA", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_Gestion_Cobranza[0].nEmpresa;
                paramsToStore[1] = new SqlParameter("@codAsesor", SqlDbType.Int);
                paramsToStore[1].Value = ListEnGS_Gestion_Cobranza[0].CodUsuario_Asesores;
                paramsToStore[2] = new SqlParameter("@fecha_ini", SqlDbType.VarChar);
                paramsToStore[2].Value = ListEnGS_Gestion_Cobranza[0].fecha_ini;
                paramsToStore[2].Size = 10;
                paramsToStore[3] = new SqlParameter("@fecha_fin", SqlDbType.VarChar);
                paramsToStore[3].Value = ListEnGS_Gestion_Cobranza[0].fecha_fin;
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

        #endregion visitas

        #region clientes
        public DataTable GS_Clientes_x_DireccionLista(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_Clientes_x_Direcciones_sp_Listar";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];

                paramsToStore[0] = new SqlParameter("@CEmpresa", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_Gestion_Cobranza[0].nEmpresa;



                paramsToStore[1] = new SqlParameter("@CodigoCliente", SqlDbType.Int);
                paramsToStore[1].Value = ListEnGS_Gestion_Cobranza[0].CodigoCliente;

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
        #endregion clientes

        #region ProcesosMasivos

        public DataTable GS_Gestion_Cobranza_Carta_Reg(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_Gestion_Cobranza_Carta_sp_Registro";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[3];


                paramsToStore[0] = new SqlParameter("@IdReg_Gestion_Cobranza", SqlDbType.VarChar);
                paramsToStore[0].Value = ListEnGS_Gestion_Cobranza[0].IdReg_Gestion_Cobranza;
                paramsToStore[0].Size = 500;

                //paramsToStore[1] = new SqlParameter("@Num_carta", SqlDbType.Int);
                //paramsToStore[1].Value = ListEnGS_Gestion_Cobranza[0].Num_carta;

                paramsToStore[1] = new SqlParameter("@Id_carta", SqlDbType.Int);
                paramsToStore[1].Value = int.Parse(ListEnGS_Gestion_Cobranza[0].id_carta);

                paramsToStore[2] = new SqlParameter("@CodUsuarioRegistra", SqlDbType.Int);
                paramsToStore[2].Value = ListEnGS_Gestion_Cobranza[0].CodUsuario;



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

        public DataTable GS_Gestion_Cobranza_IVR_Reg(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_Gestion_Cobranza_IVR_sp_Registro";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[3];


                paramsToStore[0] = new SqlParameter("@IdReg_Gestion_Cobranza", SqlDbType.VarChar);
                paramsToStore[0].Value = ListEnGS_Gestion_Cobranza[0].IdReg_Gestion_Cobranza;
                paramsToStore[0].Size = 500;

                //paramsToStore[1] = new SqlParameter("@Num_carta", SqlDbType.Int);
                //paramsToStore[1].Value = ListEnGS_Gestion_Cobranza[0].Num_carta;

                paramsToStore[1] = new SqlParameter("@Id_carta", SqlDbType.Int);
                paramsToStore[1].Value = int.Parse(ListEnGS_Gestion_Cobranza[0].id_carta);

                paramsToStore[2] = new SqlParameter("@CodUsuarioRegistra", SqlDbType.Int);
                paramsToStore[2].Value = int.Parse(ListEnGS_Gestion_Cobranza[0].CodUsuario);

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

        public DataTable GS_Gestion_Cobranza_SMS_Reg(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_Gestion_Cobranza_SMS_sp_Registro";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[3];


                paramsToStore[0] = new SqlParameter("@IdReg_Gestion_Cobranza", SqlDbType.VarChar);
                paramsToStore[0].Value = ListEnGS_Gestion_Cobranza[0].IdReg_Gestion_Cobranza;
                paramsToStore[0].Size = 500;

                paramsToStore[1] = new SqlParameter("@Id_carta", SqlDbType.Int);
                paramsToStore[1].Value = int.Parse(ListEnGS_Gestion_Cobranza[0].id_carta);

                paramsToStore[2] = new SqlParameter("@CodUsuarioRegistra", SqlDbType.Int);
                paramsToStore[2].Value = int.Parse(ListEnGS_Gestion_Cobranza[0].CodUsuario);


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
        public DataTable mxCambiarEstadoActionPlansXTipoGestion(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_Gestion_Cobranza_Carta_sp_Impreso";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[4];


                paramsToStore[0] = new SqlParameter("@NEmpresa", SqlDbType.Int);
                paramsToStore[0].Value = int.Parse(ListEnGS_Gestion_Cobranza[0].nEmpresa);

                paramsToStore[1] = new SqlParameter("@IdReg_Gestion_Cobranza", SqlDbType.VarChar);
                paramsToStore[1].Value = ListEnGS_Gestion_Cobranza[0].IdReg_Gestion_Cobranza;
                paramsToStore[1].Size = 500;

                paramsToStore[2] = new SqlParameter("@CodUsuarioRegistra", SqlDbType.Int);
                paramsToStore[2].Value = int.Parse(ListEnGS_Gestion_Cobranza[0].CodUsuario);

                paramsToStore[3] = new SqlParameter("@TipoActionPlanMasivo", SqlDbType.VarChar);
                paramsToStore[3].Value = ListEnGS_Gestion_Cobranza[0].Id_tipo_accion_gestion;
                paramsToStore[3].Size = 500;


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

        public DataTable GS_Gestion_Cobranza_Correo_Reg(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_Gestion_Cobranza_CORREO_sp_Registro";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[3];


                paramsToStore[0] = new SqlParameter("@IdReg_Gestion_Cobranza", SqlDbType.VarChar);
                paramsToStore[0].Value = ListEnGS_Gestion_Cobranza[0].IdReg_Gestion_Cobranza;
                paramsToStore[0].Size = 500;

                //paramsToStore[1] = new SqlParameter("@Num_carta", SqlDbType.Int);
                //paramsToStore[1].Value = ListEnGS_Gestion_Cobranza[0].Num_carta;

                paramsToStore[1] = new SqlParameter("@Id_carta", SqlDbType.Int);
                paramsToStore[1].Value = int.Parse(ListEnGS_Gestion_Cobranza[0].id_carta);


                paramsToStore[2] = new SqlParameter("@CodUsuarioRegistra", SqlDbType.VarChar);
                paramsToStore[2].Value = ListEnGS_Gestion_Cobranza[0].CodUsuario;
                paramsToStore[2].Size = 20;

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

        public DataTable GS_Gestion_Cobranza_Whatsapp_Reg(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_Gestion_Cobranza_Whatsapp_sp_Registro";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[3];


                paramsToStore[0] = new SqlParameter("@IdReg_Gestion_Cobranza", SqlDbType.VarChar);
                paramsToStore[0].Value = ListEnGS_Gestion_Cobranza[0].IdReg_Gestion_Cobranza;
                paramsToStore[0].Size = 500;

                //paramsToStore[1] = new SqlParameter("@Num_carta", SqlDbType.Int);
                //paramsToStore[1].Value = ListEnGS_Gestion_Cobranza[0].Num_carta;

                paramsToStore[1] = new SqlParameter("@Id_carta", SqlDbType.Int);
                paramsToStore[1].Value = int.Parse(ListEnGS_Gestion_Cobranza[0].id_carta);


                paramsToStore[2] = new SqlParameter("@CodUsuarioRegistra", SqlDbType.VarChar);
                paramsToStore[2].Value = ListEnGS_Gestion_Cobranza[0].CodUsuario;
                paramsToStore[2].Size = 20;

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

        public DataTable GS_Gestion_Cobranza_ExportarTercero(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "CR_Cliente_sp_ExportarTercero";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[3];


                //paramsToStore[1] = new SqlParameter("@Num_carta", SqlDbType.Int);
                //paramsToStore[1].Value = ListEnGS_Gestion_Cobranza[0].Num_carta;

                paramsToStore[0] = new SqlParameter("@nempresa", SqlDbType.Int);
                paramsToStore[0].Value = int.Parse(ListEnGS_Gestion_Cobranza[0].nEmpresa);

                paramsToStore[1] = new SqlParameter("@codusuario", SqlDbType.Int);
                paramsToStore[1].Value = ListEnGS_Gestion_Cobranza[0].CodUsuario;

                paramsToStore[2] = new SqlParameter("@IdReg_Gestion_Cobranza", SqlDbType.VarChar);
                paramsToStore[2].Value = ListEnGS_Gestion_Cobranza[0].IdReg_Gestion_Cobranza.ToString();
                paramsToStore[2].Size = 500;

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

        public DataTable GS_Gestion_Cobranza_ExportarActionPlan(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_Gestion_Cobranza_sp_ExportarActionPlan";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[3];

                paramsToStore[0] = new SqlParameter("@IdReg_Gestion_Cobranza", SqlDbType.VarChar);
                paramsToStore[0].Value = ListEnGS_Gestion_Cobranza[0].IdReg_Gestion_Cobranza;
                paramsToStore[0].Size = 500;

                paramsToStore[1] = new SqlParameter("@CEmpresa", SqlDbType.Int);
                paramsToStore[1].Value = int.Parse(ListEnGS_Gestion_Cobranza[0].nEmpresa);

                paramsToStore[2] = new SqlParameter("@CodUsuarioRegistra", SqlDbType.Int);
                paramsToStore[2].Value = ListEnGS_Gestion_Cobranza[0].CodUsuario;

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

        public DataTable GS_GestionCobranza_ExportarResultados_Masivos(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_GestionCobranza_sp_ExportarResultados_Masivos";
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

        #endregion ProcesosMasivos



        public DataTable GS_Gestion_Cobranza_Asesores_Lista(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_Asesores_sp_Listar";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[1];

                paramsToStore[0] = new SqlParameter("@NEMPRESA", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_Gestion_Cobranza[0].nEmpresa;

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

        public void GS_Gestion_Cobranza_UPD_Asesor(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza, SqlTransaction tran)
        {
            try
            {
                #region Parametros
                SqlParameter prm_IdReg_Gestion_Cobranza = new SqlParameter();
                SqlParameter prm_CodUsuario = new SqlParameter();
                #endregion Parametros


                #region Values


                prm_IdReg_Gestion_Cobranza.ParameterName = "@IdReg_Gestion_Cobranza";
                prm_IdReg_Gestion_Cobranza.SqlDbType = SqlDbType.Int;
                prm_IdReg_Gestion_Cobranza.Direction = ParameterDirection.Input;
                prm_IdReg_Gestion_Cobranza.Value = ListEnGS_Gestion_Cobranza[0].IdReg_Gestion_Cobranza;


                prm_CodUsuario.ParameterName = "@CodUsuarioRegistra";
                prm_CodUsuario.SqlDbType = SqlDbType.Int;
                prm_CodUsuario.Direction = ParameterDirection.Input;
                prm_CodUsuario.Value = ListEnGS_Gestion_Cobranza[0].CodUsuario;


                #endregion Values

                #region Execute
                SqlHelper.ExecuteNonQuery(tran, "GS_Gestion_Cobranza_sp_Modificar_Asesor",
                                               prm_IdReg_Gestion_Cobranza, prm_CodUsuario
                                               );
                #endregion Execute
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GS_Estado_Gestion_Cobranza_Combo()
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_GestionCobranza_sp_Estado";
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

        public DataTable GS_Gestion_Cobranza_ComboCartas(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_Carta_sp_Listar_Combo";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[1];

                paramsToStore[0] = new SqlParameter("@CodTipoGestion", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_Gestion_Cobranza[0].CodTipoGestion;



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

        public void GS_Gestion_Cobranza_Aprobar_Jefe(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza, SqlTransaction tran)
        {
            try
            {
                #region Parametros

                SqlParameter prm_CEMPRESA = new SqlParameter();
                SqlParameter prm_IdReg_Gestion_Cobranza = new SqlParameter();
                SqlParameter prm_comentario = new SqlParameter();
                SqlParameter prm_CodUsuario = new SqlParameter();
                SqlParameter prm_FechaLimite = new SqlParameter();
                SqlParameter prm_CodUsuarioNuevo = new SqlParameter();
                #endregion Parametros

                #region Values

                prm_CEMPRESA.ParameterName = "@NEmpresa";
                prm_CEMPRESA.SqlDbType = SqlDbType.Int;
                prm_CEMPRESA.Direction = ParameterDirection.Input;
                prm_CEMPRESA.Value = ListEnGS_Gestion_Cobranza[0].nEmpresa;


                prm_IdReg_Gestion_Cobranza.ParameterName = "@IdReg_Gestion_Cobranza";
                prm_IdReg_Gestion_Cobranza.SqlDbType = SqlDbType.Int;
                prm_IdReg_Gestion_Cobranza.Direction = ParameterDirection.Input;
                prm_IdReg_Gestion_Cobranza.Value = ListEnGS_Gestion_Cobranza[0].IdReg_Gestion_Cobranza;

                prm_comentario.ParameterName = "@comentario";
                prm_comentario.SqlDbType = SqlDbType.Char;
                prm_comentario.Direction = ParameterDirection.Input;
                prm_comentario.Size = 5000;
                prm_comentario.Value = ListEnGS_Gestion_Cobranza[0].comentario;

                prm_CodUsuario.ParameterName = "@CodUsuarioRegistra";
                prm_CodUsuario.SqlDbType = SqlDbType.Int;
                prm_CodUsuario.Direction = ParameterDirection.Input;
                prm_CodUsuario.Value = ListEnGS_Gestion_Cobranza[0].CodUsuario;

                prm_FechaLimite.ParameterName = "@FechaLimite";
                prm_FechaLimite.SqlDbType = SqlDbType.VarChar;
                prm_FechaLimite.Direction = ParameterDirection.Input;
                prm_FechaLimite.Value = ListEnGS_Gestion_Cobranza[0].FechaLimite;

                prm_CodUsuarioNuevo.ParameterName = "@CodUsuarioNuevo";
                prm_CodUsuarioNuevo.SqlDbType = SqlDbType.Int;
                prm_CodUsuarioNuevo.Direction = ParameterDirection.Input;
                prm_CodUsuarioNuevo.Value = ListEnGS_Gestion_Cobranza[0].CodUsuarioNuevo;

                #endregion Values

                #region Execute
                SqlHelper.ExecuteNonQuery(tran, "GS_Gestion_Cobranza_sp_Aprobar_Jefe",
                                               prm_CEMPRESA, prm_IdReg_Gestion_Cobranza, prm_comentario, prm_CodUsuario
                                               , prm_FechaLimite, prm_CodUsuarioNuevo
                                               );
                #endregion Execute
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GS_Gestion_Cobranza_Bandeja_Salida(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza, SqlTransaction tran)
        {
            try
            {
                #region Parametros

                SqlParameter prm_CEMPRESA = new SqlParameter();
                SqlParameter prm_CodUsuario = new SqlParameter();
                SqlParameter prm_IdReg_Gestion_Cobranza = new SqlParameter();
                SqlParameter prm_Obs = new SqlParameter();

                #endregion Parametros
                #region Values

                prm_CEMPRESA.ParameterName = "@NEmpresa";
                prm_CEMPRESA.SqlDbType = SqlDbType.Int;
                prm_CEMPRESA.Direction = ParameterDirection.Input;
                prm_CEMPRESA.Value = ListEnGS_Gestion_Cobranza[0].nEmpresa;

                prm_CodUsuario.ParameterName = "@CodUsuarioRegistra";
                prm_CodUsuario.SqlDbType = SqlDbType.Int;
                prm_CodUsuario.Direction = ParameterDirection.Input;
                prm_CodUsuario.Value = ListEnGS_Gestion_Cobranza[0].CodUsuario;

                prm_IdReg_Gestion_Cobranza.ParameterName = "@IdReg_Gestion_Cobranza";
                prm_IdReg_Gestion_Cobranza.SqlDbType = SqlDbType.Int;
                prm_IdReg_Gestion_Cobranza.Direction = ParameterDirection.Input;
                prm_IdReg_Gestion_Cobranza.Value = ListEnGS_Gestion_Cobranza[0].IdReg_Gestion_Cobranza;

                prm_Obs.ParameterName = "@Obs";
                prm_Obs.SqlDbType = SqlDbType.Char;
                prm_Obs.Direction = ParameterDirection.Input;
                prm_Obs.Size = 5000;
                prm_Obs.Value = ListEnGS_Gestion_Cobranza[0].Obs;




                #endregion Values
                #region Execute
                SqlHelper.ExecuteNonQuery(tran, "GS_Bandeja_Salida_sp_Grabar",
                                               prm_CEMPRESA, prm_CodUsuario, prm_IdReg_Gestion_Cobranza, prm_Obs
                                               );
                #endregion Execute
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GS_Gestion_Cobranza_Reasignacion_CCI(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza, SqlTransaction tran)
        {
            try
            {
                #region Parametros

                SqlParameter prm_CEMPRESA = new SqlParameter();
                SqlParameter prm_CodUsuario = new SqlParameter();
                SqlParameter prm_IdReg_Gestion_Cobranza = new SqlParameter();

                #endregion Parametros
                #region Values

                prm_CEMPRESA.ParameterName = "@NEmpresa";
                prm_CEMPRESA.SqlDbType = SqlDbType.Int;
                prm_CEMPRESA.Direction = ParameterDirection.Input;
                prm_CEMPRESA.Value = ListEnGS_Gestion_Cobranza[0].nEmpresa;

                prm_CodUsuario.ParameterName = "@CodUsuarioRegistra";
                prm_CodUsuario.SqlDbType = SqlDbType.Int;
                prm_CodUsuario.Direction = ParameterDirection.Input;
                prm_CodUsuario.Value = ListEnGS_Gestion_Cobranza[0].CodUsuario;

                prm_IdReg_Gestion_Cobranza.ParameterName = "@IdReg_Gestion_Cobranza";
                prm_IdReg_Gestion_Cobranza.SqlDbType = SqlDbType.Int;
                prm_IdReg_Gestion_Cobranza.Direction = ParameterDirection.Input;
                prm_IdReg_Gestion_Cobranza.Value = ListEnGS_Gestion_Cobranza[0].IdReg_Gestion_Cobranza;

                #endregion Values

                #region Execute
                SqlHelper.ExecuteNonQuery(tran, "GS_Reasignacion_Cartera_sp_Grabar_CCI",
                                               prm_CEMPRESA, prm_CodUsuario, prm_IdReg_Gestion_Cobranza
                                               );
                #endregion Execute
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GS_Gestion_Cobranza_Rechazar_Jefe(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza, SqlTransaction tran)
        {
            try
            {
                #region Parametros

                SqlParameter prm_CEMPRESA = new SqlParameter();
                SqlParameter prm_IdReg_Gestion_Cobranza = new SqlParameter();
                SqlParameter prm_comentario = new SqlParameter();
                SqlParameter prm_CodUsuario = new SqlParameter();
                #endregion Parametros


                #region Values

                prm_CEMPRESA.ParameterName = "@NEmpresa";
                prm_CEMPRESA.SqlDbType = SqlDbType.Int;
                prm_CEMPRESA.Direction = ParameterDirection.Input;
                prm_CEMPRESA.Value = ListEnGS_Gestion_Cobranza[0].nEmpresa;


                prm_IdReg_Gestion_Cobranza.ParameterName = "@IdReg_Gestion_Cobranza";
                prm_IdReg_Gestion_Cobranza.SqlDbType = SqlDbType.Int;
                prm_IdReg_Gestion_Cobranza.Direction = ParameterDirection.Input;
                prm_IdReg_Gestion_Cobranza.Value = ListEnGS_Gestion_Cobranza[0].IdReg_Gestion_Cobranza;

                prm_comentario.ParameterName = "@comentario";
                prm_comentario.SqlDbType = SqlDbType.Char;
                prm_comentario.Direction = ParameterDirection.Input;
                prm_comentario.Size = 5000;
                prm_comentario.Value = ListEnGS_Gestion_Cobranza[0].comentario;

                prm_CodUsuario.ParameterName = "@CodUsuarioRegistra";
                prm_CodUsuario.SqlDbType = SqlDbType.Int;
                prm_CodUsuario.Direction = ParameterDirection.Input;
                prm_CodUsuario.Value = ListEnGS_Gestion_Cobranza[0].CodUsuario;


                #endregion Values

                #region Execute
                SqlHelper.ExecuteNonQuery(tran, "GS_Gestion_Cobranza_sp_Rechazar_Jefe",
                                               prm_CEMPRESA, prm_IdReg_Gestion_Cobranza, prm_comentario, prm_CodUsuario
                                               );
                #endregion Execute
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GS_Gestion_Cobranza_Carga_ClienteGC_Lista(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "CR_Cliente_sp_CargaClienteGC";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[3];


                paramsToStore[0] = new SqlParameter("@NEMPRESA", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_Gestion_Cobranza[0].nEmpresa;

                paramsToStore[1] = new SqlParameter("@CodigoCliente", SqlDbType.Int);
                paramsToStore[1].Value = ListEnGS_Gestion_Cobranza[0].CodigoCliente;


                paramsToStore[2] = new SqlParameter("@IdRegPRODUCTOS", SqlDbType.VarChar);
                paramsToStore[2].Value = ListEnGS_Gestion_Cobranza[0].IdReg;
                paramsToStore[2].Size = 50;



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

        public DataTable GS_Agente_Combo(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_Ejecutores_sp_Listar";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[1];


                paramsToStore[0] = new SqlParameter("@NEMPRESA", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_Gestion_Cobranza[0].nEmpresa;

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

        public DataTable RPT_CRProductividad_Gestiones(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "RPT_CRProductividad_Gestiones";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[6];


                paramsToStore[0] = new SqlParameter("@NEmpresa", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_Gestion_Cobranza[0].nEmpresa;

                paramsToStore[1] = new SqlParameter("@CodTipoGestion", SqlDbType.Int);
                paramsToStore[1].Value = ListEnGS_Gestion_Cobranza[0].CodTipoGestion;

                paramsToStore[2] = new SqlParameter("@Fecha", SqlDbType.VarChar);
                paramsToStore[2].Value = ListEnGS_Gestion_Cobranza[0].FechaResultado;

                paramsToStore[3] = new SqlParameter("@CodJerarquiaB", SqlDbType.Int);
                paramsToStore[3].Value = ListEnGS_Gestion_Cobranza[0].cod_jerarquiaB;

                paramsToStore[4] = new SqlParameter("@CodJerarquiaC", SqlDbType.Int);
                paramsToStore[4].Value = ListEnGS_Gestion_Cobranza[0].cod_jerarquiaC;

                paramsToStore[5] = new SqlParameter("@CodJerarquiaD", SqlDbType.Int);
                paramsToStore[5].Value = ListEnGS_Gestion_Cobranza[0].cod_jerarquiaD;

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

        public DataSet mxObtenerResultadoReporteProductividad(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            DataSet ldsResultado = new DataSet();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "RPT_CRProductividad_ResultadoReporteProductividad";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[6];

                paramsToStore[0] = new SqlParameter("@nEmpresa", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_Gestion_Cobranza[0].nEmpresa;

                paramsToStore[1] = new SqlParameter("@dFecha", SqlDbType.VarChar);
                paramsToStore[1].Value = ListEnGS_Gestion_Cobranza[0].FechaResultado;

                paramsToStore[2] = new SqlParameter("@cCodJerarquiaB", SqlDbType.Int);
                paramsToStore[2].Value = ListEnGS_Gestion_Cobranza[0].cod_jerarquiaB;

                paramsToStore[3] = new SqlParameter("@cCodJerarquiaC", SqlDbType.Int);
                paramsToStore[3].Value = ListEnGS_Gestion_Cobranza[0].cod_jerarquiaC;

                paramsToStore[4] = new SqlParameter("@cCodJerarquiaD", SqlDbType.Int);
                paramsToStore[4].Value = ListEnGS_Gestion_Cobranza[0].cod_jerarquiaD;

                paramsToStore[5] = new SqlParameter("@cCodAsesor", SqlDbType.Int);
                paramsToStore[5].Value = ListEnGS_Gestion_Cobranza[0].CodUsuario_Asesores;

                adp.SelectCommand.Parameters.AddRange(paramsToStore);
                adp.Fill(ldsResultado, "ldsResultado");
                Conn.Close();
                return ldsResultado;
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable RPT_CRProductividad_Grupos(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "RPT_CRProductividad_Grupos";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[5];


                paramsToStore[0] = new SqlParameter("@NEmpresa", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_Gestion_Cobranza[0].nEmpresa;

                paramsToStore[1] = new SqlParameter("@Fecha", SqlDbType.VarChar);
                paramsToStore[1].Value = ListEnGS_Gestion_Cobranza[0].FechaResultado;

                paramsToStore[2] = new SqlParameter("@CodJerarquiaB", SqlDbType.Int);
                paramsToStore[2].Value = ListEnGS_Gestion_Cobranza[0].cod_jerarquiaB;

                paramsToStore[3] = new SqlParameter("@CodJerarquiaC", SqlDbType.Int);
                paramsToStore[3].Value = ListEnGS_Gestion_Cobranza[0].cod_jerarquiaC;

                paramsToStore[4] = new SqlParameter("@CodAsesor", SqlDbType.Int);
                paramsToStore[4].Value = ListEnGS_Gestion_Cobranza[0].CodUsuario_Asesores;

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
        public DataTable RPT_CRProductividad_TipoGestionesXGrupo(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "RPT_CRProductividad_TipoGestionesXGrupo";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[6];


                paramsToStore[0] = new SqlParameter("@NEmpresa", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_Gestion_Cobranza[0].nEmpresa;

                paramsToStore[1] = new SqlParameter("@Fecha", SqlDbType.VarChar);
                paramsToStore[1].Value = ListEnGS_Gestion_Cobranza[0].FechaResultado;

                paramsToStore[2] = new SqlParameter("@CodJerarquiaB", SqlDbType.Int);
                paramsToStore[2].Value = ListEnGS_Gestion_Cobranza[0].cod_jerarquiaB;

                paramsToStore[3] = new SqlParameter("@CodJerarquiaC", SqlDbType.Int);
                paramsToStore[3].Value = ListEnGS_Gestion_Cobranza[0].cod_jerarquiaC;

                paramsToStore[4] = new SqlParameter("@CodAsesor", SqlDbType.Int);
                paramsToStore[4].Value = ListEnGS_Gestion_Cobranza[0].CodUsuario_Asesores;

                paramsToStore[5] = new SqlParameter("@CodGrupo", SqlDbType.Int);
                paramsToStore[5].Value = ListEnGS_Gestion_Cobranza[0].Grupo;


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
        public DataTable RPT_CRProductividad_EjecutadoXTipoGestion(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "RPT_CRProductividad_EjecutadoXTipoGestion";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[6];


                paramsToStore[0] = new SqlParameter("@NEmpresa", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_Gestion_Cobranza[0].nEmpresa;

                paramsToStore[1] = new SqlParameter("@Fecha", SqlDbType.VarChar);
                paramsToStore[1].Value = ListEnGS_Gestion_Cobranza[0].FechaResultado;

                paramsToStore[2] = new SqlParameter("@CodJerarquiaB", SqlDbType.Int);
                paramsToStore[2].Value = ListEnGS_Gestion_Cobranza[0].cod_jerarquiaB;

                paramsToStore[3] = new SqlParameter("@CodJerarquiaC", SqlDbType.Int);
                paramsToStore[3].Value = ListEnGS_Gestion_Cobranza[0].cod_jerarquiaC;

                paramsToStore[4] = new SqlParameter("@CodAsesor", SqlDbType.Int);
                paramsToStore[4].Value = ListEnGS_Gestion_Cobranza[0].CodUsuario_Asesores;

                paramsToStore[5] = new SqlParameter("@CodTipoGestion", SqlDbType.Int);
                paramsToStore[5].Value = ListEnGS_Gestion_Cobranza[0].CodTipoGestion;


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
        public DataTable RPT_CRProductividad_ClaseGestionesXEjecutado(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "RPT_CRProductividad_ClaseGestionesXEjecutado";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[6];


                paramsToStore[0] = new SqlParameter("@NEmpresa", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_Gestion_Cobranza[0].nEmpresa;

                paramsToStore[1] = new SqlParameter("@Fecha", SqlDbType.VarChar);
                paramsToStore[1].Value = ListEnGS_Gestion_Cobranza[0].FechaResultado;

                paramsToStore[2] = new SqlParameter("@CodJerarquiaB", SqlDbType.Int);
                paramsToStore[2].Value = ListEnGS_Gestion_Cobranza[0].cod_jerarquiaB;

                paramsToStore[3] = new SqlParameter("@CodJerarquiaC", SqlDbType.Int);
                paramsToStore[3].Value = ListEnGS_Gestion_Cobranza[0].cod_jerarquiaC;

                paramsToStore[4] = new SqlParameter("@CodAsesor", SqlDbType.Int);
                paramsToStore[4].Value = ListEnGS_Gestion_Cobranza[0].CodUsuario_Asesores;

                paramsToStore[5] = new SqlParameter("@CodEjecutado", SqlDbType.Int);
                paramsToStore[5].Value = ListEnGS_Gestion_Cobranza[0].CodEjecutado;


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
        public DataTable RPT_CRProductividad_UsuariosXJerarquia(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "RPT_CRProductividad_UsuariosXJerarquia";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[4];

                paramsToStore[0] = new SqlParameter("@NEmpresa", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_Gestion_Cobranza[0].nEmpresa;

                paramsToStore[1] = new SqlParameter("@CodJerarquiaB", SqlDbType.Int);
                paramsToStore[1].Value = ListEnGS_Gestion_Cobranza[0].cod_jerarquiaB;

                paramsToStore[2] = new SqlParameter("@CodJerarquiaC", SqlDbType.Int);
                paramsToStore[2].Value = ListEnGS_Gestion_Cobranza[0].cod_jerarquiaC;

                paramsToStore[3] = new SqlParameter("@CodAsesor", SqlDbType.Int);
                paramsToStore[3].Value = ListEnGS_Gestion_Cobranza[0].CodUsuario_Asesores;

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
        public DataTable GS_Cantidad_TipoGestionesXGrupo(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_Cantidad_TipoGestionesXGrupo";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[1];

                paramsToStore[0] = new SqlParameter("@Grupo", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_Gestion_Cobranza[0].Grupo;

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
        public DataTable GS_Cantidad_EjecutadosXTipoGestion(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_Cantidad_EjecutadosXTipoGestion";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[1];

                paramsToStore[0] = new SqlParameter("@CodTipoGestion", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_Gestion_Cobranza[0].CodTipoGestion;

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
        public DataTable GS_Cantidad_ClasificacionesXEjecutado(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_Cantidad_ClasificacionesXEjecutado";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[1];

                paramsToStore[0] = new SqlParameter("@CodEjecutado", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_Gestion_Cobranza[0].CodEjecutado;

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

        public DataTable GS_ReglasGestiones_Consultar_DiaFinal(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_ReglasGestiones_Consultar_DiaFinal";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = new SqlParameter("@nempresa", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_Gestion_Cobranza[0].nEmpresa;
                paramsToStore[1] = new SqlParameter("@IdReg_Gestion_Cobranza", SqlDbType.Int);
                paramsToStore[1].Value = ListEnGS_Gestion_Cobranza[0].IdReg_Gestion_Cobranza;
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

        public DataTable GS_Gestion_Cobranza_Tramo_Acelerar_Listar(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_Tramo_sp_Acelerar_Listar";
                adp = new SqlDataAdapter(sqlCommand, conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = new SqlParameter("@IdReg_Gestion_Cobranza", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_Gestion_Cobranza[0].IdReg_Gestion_Cobranza;
                paramsToStore[1] = new SqlParameter("@NEmpresa", SqlDbType.Int);
                paramsToStore[1].Value = ListEnGS_Gestion_Cobranza[0].nEmpresa;
                adp.SelectCommand.Parameters.AddRange(paramsToStore);
                adp.Fill(ds, "DataTable1");
                dt = ds.Tables["DataTable1"];
                return dt;
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable GS_Gestion_Cobranza_sp_Modificar_TramoAcelerado(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_Gestion_Cobranza_sp_Modificar_TramoAcelerado";
                adp = new SqlDataAdapter(sqlCommand, conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[3];
                paramsToStore[0] = new SqlParameter("@IdReg_Gestion_Cobranza", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_Gestion_Cobranza[0].IdReg_Gestion_Cobranza;
                paramsToStore[1] = new SqlParameter("@NEmpresa", SqlDbType.Int);
                paramsToStore[1].Value = ListEnGS_Gestion_Cobranza[0].nEmpresa;
                paramsToStore[2] = new SqlParameter("@TramoAcelerado", SqlDbType.Int);
                paramsToStore[2].Value = ListEnGS_Gestion_Cobranza[0].nEmpresa;
                adp.SelectCommand.Parameters.AddRange(paramsToStore);
                adp.Fill(ds, "DataTable1");
                dt = ds.Tables["DataTable1"];
                return dt;
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable GS_ClientePRODCronograma_sp_Modificar_FechaVencimientoReal(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_ClientePRODCronograma_sp_Modificar_FechaVencimientoReal";
                adp = new SqlDataAdapter(sqlCommand, conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[1] = new SqlParameter("@IdReg_Gestion_Cobranza", SqlDbType.Int);
                paramsToStore[1].Value = ListEnGS_Gestion_Cobranza[0].IdReg_Gestion_Cobranza;
                paramsToStore[0] = new SqlParameter("@NEmpresa", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_Gestion_Cobranza[0].nEmpresa;
                adp.Fill(ds, "DataTable1");
                dt = ds.Tables["DataTable1"];
                return dt;
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public DataTable GS_Gestion_Cobranza_GestionesInternas_TomarControl(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_Gestion_Cobranza_GestionesInternas_sp_TomarControl";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];


                paramsToStore[0] = new SqlParameter("@IdReg_Gestion_Cobranza", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_Gestion_Cobranza[0].IdReg_Gestion_Cobranza;
                paramsToStore[1] = new SqlParameter("@NEmpresa", SqlDbType.Int);
                paramsToStore[1].Value = ListEnGS_Gestion_Cobranza[0].nEmpresa;

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

        public DataTable GS_TipoGestiones_ValidarTipoVisita(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_TipoGestiones_sp_ValidarTipoVisita";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];


                paramsToStore[0] = new SqlParameter("@IdReg_Gestion_Cobranza", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_Gestion_Cobranza[0].IdReg_Gestion_Cobranza;
                paramsToStore[1] = new SqlParameter("@NEmpresa", SqlDbType.Int);
                paramsToStore[1].Value = ListEnGS_Gestion_Cobranza[0].nEmpresa;

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

        public DataTable GS_ReglasGestiones_Consultar_DiasRestantesCierreTramo(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_ReglasGestiones_sp_Consultar_DiasRestantesCierreTramo";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = new SqlParameter("@nempresa", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_Gestion_Cobranza[0].nEmpresa;
                paramsToStore[1] = new SqlParameter("@IdReg_Gestion_Cobranza", SqlDbType.Int);
                paramsToStore[1].Value = ListEnGS_Gestion_Cobranza[0].IdReg_Gestion_Cobranza;
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

        public DataTable mxListarReagendados(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_Gestion_Cobranza_sp_Listar_GestionesPendientes";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = new SqlParameter("@nEmpresa", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_Gestion_Cobranza[0].nEmpresa;
                paramsToStore[1] = new SqlParameter("@cIdAsesor", SqlDbType.Int);
                paramsToStore[1].Value = ListEnGS_Gestion_Cobranza[0].CodUsuario;
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
        public DataTable mxListarReagendados_Futuras(List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_Gestion_Cobranza_sp_Listar_GestionesPendientes_Futuras";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = new SqlParameter("@nEmpresa", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGS_Gestion_Cobranza[0].nEmpresa;
                paramsToStore[1] = new SqlParameter("@cIdAsesor", SqlDbType.Int);
                paramsToStore[1].Value = ListEnGS_Gestion_Cobranza[0].CodUsuario;
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


        public DataTable mxTraerRutaDescarga(string cValor)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {
                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "GS_Gestion_Cobranza_sp_Listar_TraerRutaDescarga";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = new SqlParameter("@cValor", SqlDbType.VarChar);
                paramsToStore[0].Value = cValor;
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




        public static MemoryStream databaseFileRead(string varID)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            MemoryStream memoryStream = new MemoryStream();
            //using (var varConnection = Locale.sqlConnectOneTime(Locale.sqlDataConnectionDetails))
            using (var sqlQuery = new SqlCommand(@"SELECT [RaportPlik] FROM [dbo].[Raporty] WHERE [RaportID] = @varID", Conn))
            {
                sqlQuery.Parameters.AddWithValue("@varID", varID);
                using (var sqlQueryResult = sqlQuery.ExecuteReader())
                    if (sqlQueryResult != null)
                    {
                        sqlQueryResult.Read();
                        var blob = new Byte[(sqlQueryResult.GetBytes(0, 0, null, 0, int.MaxValue))];
                        sqlQueryResult.GetBytes(0, 0, blob, 0, blob.Length);
                        //using (var fs = new MemoryStream(memoryStream, FileMode.Create, FileAccess.Write)) {
                        memoryStream.Write(blob, 0, blob.Length);
                        //}
                    }
            }
            return memoryStream;
        }

        //INSERTAR IMAGEN OJOOOOOOOOOOOOOOOOOOOOOOOO

        public string GS_Gestion_Cobranza_INS_Imagen(EnGS_Gestion_Cobranza ListEnGS_Gestion_Cobranza, byte[] oImagen, SqlTransaction tran)
        {
            try
            {

                #region Parametros
                SqlParameter prm_IdReg = new SqlParameter();
                SqlParameter prm_Nombre = new SqlParameter();
                SqlParameter prm_Descripcion = new SqlParameter();
                SqlParameter prm_Ruta = new SqlParameter();
                SqlParameter prm_Imagen = new SqlParameter();

                #endregion Parametros


                #region Values

                #region IdReg
                prm_IdReg.ParameterName = "@nIdReg";
                prm_IdReg.SqlDbType = SqlDbType.Int;
                prm_IdReg.Direction = ParameterDirection.Input;
                prm_IdReg.Value = ListEnGS_Gestion_Cobranza.IdReg;
                #endregion IdReg

                prm_Nombre.ParameterName = "@cNombre";
                prm_Nombre.SqlDbType = SqlDbType.VarChar;
                prm_Nombre.Direction = ParameterDirection.Input;
                prm_Nombre.Value = ListEnGS_Gestion_Cobranza.Nombre;


                prm_Descripcion.ParameterName = "@cDescripcion";
                prm_Descripcion.SqlDbType = SqlDbType.VarChar;
                prm_Descripcion.Direction = ParameterDirection.Input;
                prm_Descripcion.Value = ListEnGS_Gestion_Cobranza.comentario;

                prm_Ruta.ParameterName = "@cRuta";
                prm_Ruta.SqlDbType = SqlDbType.VarChar;
                prm_Ruta.Direction = ParameterDirection.Input;
                prm_Ruta.Value = ListEnGS_Gestion_Cobranza.RazonSocial;

                prm_Imagen.ParameterName = "@oImagen";
                prm_Imagen.SqlDbType = SqlDbType.VarBinary;
                prm_Imagen.Direction = ParameterDirection.Input;
                prm_Imagen.Value = oImagen;


                #endregion Values

                #region Execute
                SqlHelper.ExecuteNonQuery(tran, "GS_Gestion_Cobranza_sp_Insert_Imagen_App",
                                               prm_IdReg, prm_Nombre, prm_Descripcion, prm_Ruta, prm_Imagen
                                               );
                return "exito";
                #endregion Execute
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /*public class MY_ATTACHMENT_TABLE_MODEL
        {
            [Key]
            public byte[] File { get; set; }  // notice this change
            public string Name { get; set; }
            public string Type { get; set; }
        }*/
    }
}
