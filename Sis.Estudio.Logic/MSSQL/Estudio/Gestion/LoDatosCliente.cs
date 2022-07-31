using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Sis.Estudio.Entity;
using Sis.Estudio.Data;
using Sis.Estudio.Data.MSSQL.Estudio;

namespace Sis.Estudio.Logic.MSSQL.Estudio
{
    public class LoDatosCliente
    {
        public int CodigoCliente_Dni(EnDatosCliente EnDatosCliente)
        {
            try
            {
                DaDatosCliente objDaDatosCliente = new DaDatosCliente();
                return objDaDatosCliente.CodigoCliente_Dni(EnDatosCliente);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public DataTable DatosCliente_Lista_Reg(List<EnDatosCliente> ListEnDatosCliente)
        {
            try
            {
                DaDatosCliente objDaDatosCliente = new DaDatosCliente();
                return objDaDatosCliente.DatosCliente_Lista_Reg(ListEnDatosCliente);
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
        public String DatosCliente_UPD(List<EnDatosCliente> ListEnDatosCliente)
        {
            string msg = "";
            #region InicializoTransaccion
            string strMensaje = "";
            LoTransaccion Transaccion = new LoTransaccion();
            bool bolError = false;
            SqlTransaction tran = Transaccion.IniTransaccion(ref bolError, ref strMensaje);
            String rollback = String.Empty;
            #endregion InicializoTransaccion
            try
            {
                if (bolError == true)
                {
                    DaDatosCliente objDaDatosCliente = new DaDatosCliente();
                    objDaDatosCliente.DatosCliente_UPD(ListEnDatosCliente, tran);
                    tran.Commit();
                    msg = "exito";
                }
                else
                {
                    throw new ArgumentNullException("IniTransaccion", "Se presentaron errores al inicializar la operación");
                }
            }
            catch (SqlException ex)
            {
                tran.Rollback();
                throw ex;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw ex;
            }
            finally
            {
                tran.Dispose();
            }
            return msg;
        }




    }
}
