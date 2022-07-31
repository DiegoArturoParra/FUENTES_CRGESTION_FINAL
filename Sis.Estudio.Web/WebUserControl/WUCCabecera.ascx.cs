using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebUserControl_WUCCabecera : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //comentario NSE
        //Usuario _Usuario = (Usuario)HttpContext.Current.Session["UsuarioActual"];
        //ltusuario.Text = _Usuario.NombreCompleto;
        ltusuario.Text = (String)this.Session["NombreUsuario"];
        txcPerfil.Text = (String)this.Session["Perfil"];
    }

    protected void cmb_MODULO_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            #region Validacion
            if (cmb_MODULO.SelectedValue.ToString() == "False")
            {
                return;
            }
            #endregion AbrePagina
            #region AbrePagina
            string str_pagina = "/Principal.aspx";
            string str_Login = "?tipoingreso=Automatico";
            string idusuario = "&passportcodusuario=" + (String)this.Session["codusuario"];
            string idmodulo = "&passportidmodulo=" + cmb_MODULO.SelectedValue.ToString();
            string desmodulo = "&passportdesmodulo=" + cmb_MODULO.SelectedItem.ToString();

            abreVentana(Pagina.URL_HOST + str_pagina + str_Login + idusuario + idmodulo + desmodulo);
            //abreVentana("http://192.168.1.65/Lider.Postventa.App/Principal.aspx" + str_Login + idusuario + idmodulo + desmodulo);
            //abreVentana("http://localhost:9466/Principal.aspx" + str_Login + idusuario + idmodulo + desmodulo);
            //abreVentana("http://localhost:9466/Principal.aspx?tipoingreso=Automatico");
            //abreVentana("http://localhost:9466/Login.aspx?tipoingreso=special");
            //abreVentana("http://192.168.1.65/Lider.Postventa.App/Login.aspx?tipoingreso=special");                               

            #endregion AbrePagina
            cmb_MODULO.SelectedValue = "False";
        }
        catch (Exception excp)
        {
            throw excp;
        }
    }

    public Menu MenuPrincipal
    {
        get { return mnuPrincipal; }
        set { mnuPrincipal = value; }
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
    public Label btnAyuda
    {
        get { return lblAyuda; }
        set { lblAyuda = value; }
    }
    //public Image Logo
    //{
    //    //get { return imgLogo; }
    //    //set { imgLogo = value; }
    //}


//    public string NombreModulo
//    {

////        set { lbl_LOGO.Text = value; }


//    }

    private void abreVentana(string ventana)
    {
        string Clientscript = "<script>window.open('" + ventana + "')</script>";
        ScriptManager.RegisterStartupScript(this, typeof(Page), "WOpen", Clientscript, false);
    }

    public void agrega_items(string codigo, string descripcion)
    {
        ListItem lista = new ListItem();
        lista.Value = codigo;
        lista.Text = descripcion;
        cmb_MODULO.Items.Add(lista);
    }

    public void OcultarComboModulo()
    {
        cmb_MODULO.Visible = false;
    }

    protected void lkb_CambiarPass_Click(object sender, EventArgs e)
    {
        HttpContext.Current.Response.Redirect(Pagina.URLACTUALIZARPASSWORD, true);
    }

    protected void mnuPrincipal_MenuItemClick(object sender, MenuEventArgs e)
    {

    }
}