using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Xml;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Sis.Estudio.Data
{
    public class DaConexion
    {
        public string MSSQLConnectionString = ConfigurationManager.ConnectionStrings["MSSQL_ConnectionString"].ToString();
        public string MSSQLConnectionString2 = ConfigurationManager.ConnectionStrings["MSSQL_ConnectionString2"].ToString();
        public string MSSQLConnectionString3 = ConfigurationManager.ConnectionStrings["MSSQL_ConnectionString3"].ToString();
        public string MSSQLConnectionString4 = ConfigurationManager.ConnectionStrings["MSSQL_ConnectionString4"].ToString();
    }
}
