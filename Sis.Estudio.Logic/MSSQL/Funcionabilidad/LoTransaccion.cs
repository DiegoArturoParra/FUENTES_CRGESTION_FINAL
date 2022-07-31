using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Sis.Estudio.Data;

namespace Sis.Estudio.Logic
{
    public class LoTransaccion
    {

        public SqlTransaction IniTransaccion(ref bool bolError, ref string strMensaje)
        {
            DaTransaction objTransacction = new DaTransaction();
            return objTransacction.InitTransaccion(ref bolError, ref strMensaje);
        }

        public SqlTransaction IniTransaccion_Seg(ref bool bolError, ref string strMensaje)
        {
            DaTransaction objTransacction = new DaTransaction();
            return objTransacction.InitTransaccion_Seg(ref bolError, ref strMensaje);
        }

        public SqlTransaction IniTransaccion_Tres(ref bool bolError, ref string strMensaje)
        {
            DaTransaction objTransacction = new DaTransaction();
            return objTransacction.InitTransaccion_Tres(ref bolError, ref strMensaje);
        }

        public SqlTransaction IniTransaccion_Cuar(ref bool bolError, ref string strMensaje)
        {
            DaTransaction objTransacction = new DaTransaction();
            return objTransacction.InitTransaccion_Cuar(ref bolError, ref strMensaje);
        }

    }
}
