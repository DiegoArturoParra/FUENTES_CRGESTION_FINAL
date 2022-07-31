using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Sis.Estudio.Data
{
    public class DaTransaction : DaConexion
    {
        #region Funciones        
        public SqlTransaction InitTransaccion(ref bool bolError, ref string strMensaje)
        {

            SqlTransaction Trans;
            SqlConnection conex = new SqlConnection();
            conex = new SqlConnection(MSSQLConnectionString);
            conex.Open();
            Trans = conex.BeginTransaction();
            try
            {
                bolError = true;
                strMensaje = "Inicio de Transaccion Satisfactoria";
            }
            catch (Exception excp)
            {
                bolError = false;
                strMensaje = "Error en Inicio Transaccion";
            }
            return Trans;
        }
        public SqlTransaction InitTransaccion_Seg(ref bool bolError, ref string strMensaje)
        {

            SqlTransaction Trans;
            SqlConnection conex = new SqlConnection();
            conex = new SqlConnection(MSSQLConnectionString2);
            conex.Open();
            Trans = conex.BeginTransaction();
            try
            {
                bolError = true;
                strMensaje = "Inicio de Transaccion Satisfactoria";
            }
            catch (Exception excp)
            {
                bolError = false;
                strMensaje = "Error en Inicio Transaccion";
            }
            return Trans;
        }

        public SqlTransaction InitTransaccion_Tres(ref bool bolError, ref string strMensaje)
        {

            SqlTransaction Trans;
            SqlConnection conex = new SqlConnection();
            conex = new SqlConnection(MSSQLConnectionString3);
            conex.Open();
            Trans = conex.BeginTransaction();
            try
            {
                bolError = true;
                strMensaje = "Inicio de Transaccion Satisfactoria";
            }
            catch (Exception excp)
            {
                bolError = false;
                strMensaje = "Error en Inicio Transaccion";
            }
            return Trans;
        }
        public SqlTransaction InitTransaccion_Cuar(ref bool bolError, ref string strMensaje)
        {

            SqlTransaction Trans;
            SqlConnection conex = new SqlConnection();
            conex = new SqlConnection(MSSQLConnectionString4);
            conex.Open();
            Trans = conex.BeginTransaction();
            try
            {
                bolError = true;
                strMensaje = "Inicio de Transaccion Satisfactoria";
            }
            catch (Exception excp)
            {
                bolError = false;
                strMensaje = "Error en Inicio Transaccion";
            }
            return Trans;
        }
        #endregion        
    }
}
