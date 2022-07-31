using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Data.SqlClient;
using System.IO;
using AjaxControlToolkit;

namespace IABaseWeb
{
    public partial class BaseMantDetalle : BaseWeb
    {
        #region Declaraciones
        #region Controles
        #endregion Controles
        #region Variables
        //public string G_idopcion = "";
        //public string PaginaRetorno = "";
        public string mstrEstado;
        public string strEmpresa;
        #endregion Variables        
        #endregion  Declaraciones
        #region Eventos
        #endregion Eventos
        #region Procedimientos

        protected void Cursor_Control(TextBox Nombre_Control)
        {
            //****************************************************************************************
            //* Nomre       : SetFocus()                         
            //****************************************************************************************
            try
            {
                ScriptManager scriptManager1 = ScriptManager.GetCurrent(this.Page);
                scriptManager1.SetFocus(Nombre_Control);
            }
            catch
            {
                return;
            }
        }

        protected void PostAnular(string Mensaje, string PageRetorno)
        {

            //System.Threading.Thread.Sleep(4000);
            //Response.Redirect("MantUsuario.aspx");

            StringBuilder sb = new StringBuilder();
            //sb.Append("<script>     alert('El registro se anuló correctamente');  var startTime = new Date().getTime(); while (new Date().getTime() < startTime + 1000);  window.location.href('MantUsuario.aspx');    </script>");
            //sb.Append("<script> var startTime = new Date().getTime(); while (new Date().getTime() < startTime + 2000);  window.location.href('MantUsuario.aspx');    </script>");
            //sb.Append("<script>     alert(' " + Mensaje + "');  window.location.href('"  + PageRetorno +    "');    </script>");
            sb.Append("<script>     alert(' " + Mensaje + "');  window.location.replace('" + PageRetorno + "');    </script>");
            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", sb.ToString(), false);
            
        }

        #endregion Procedimientos
        #region Funciones
        private bool ValidaEntero(string str_imput)
        {
            //****************************************************************************************
            //* Nomre       : ValidaEntero
            //* DescripcioN : valida el ingreso de Datos enteros
            //* creado      : Jhonny Aroni Eslava   21-agosto-2009
            //****************************************************************************************
            int Codigo = 0;
            if (int.TryParse(str_imput, out Codigo))
            {
                return true;
            }
            return false;
        }
        #endregion Funciones        
    }
}
