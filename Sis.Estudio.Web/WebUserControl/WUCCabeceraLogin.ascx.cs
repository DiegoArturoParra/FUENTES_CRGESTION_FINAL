using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebUserControl_WUCCabeceraLogin : System.Web.UI.UserControl
{

    #region Eventos
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void LKB_Login_Click(object sender, EventArgs e)
    {
        //Page.Response.Redirect(Pagina.URLLOGIN);

        HttpContext.Current.Response.Redirect(Pagina.URLPAGINAPUBLICA, true);
    }
    protected void linkCerrar_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Session.Clear();

        //comentario NSE
        HttpContext.Current.Response.Redirect(Pagina.URLPAGINAPUBLICA, true);

        //    COMENTARIO ORIGINAL
        //ScriptManager.RegisterStartupScript(this, typeof(Page), "PublicSTS", " window.location.replace('../PublicSTS.aspx');", true);
    }
    #endregion Eventos
    #region Metodos

    //public string NombreModulo
    //{
    //    set { lbl_LOGO.Text = value; }
    //}

    public void CerrarSesionVisible(bool estado)
    {
        linkCerrar.Visible = estado;
    }

    public void IniciarSesionVisible(bool estado)
    {
        LKB_Login.Visible = estado;

    }

    #endregion Metodos
}