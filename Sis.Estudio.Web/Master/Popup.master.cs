using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Collections.Specialized;

public partial class Master_Popup : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HtmlGenericControl link = new HtmlGenericControl("LINK");
            link.Attributes.Add("rel", "stylesheet");
            link.Attributes.Add("type", "text/css");
            link.Attributes.Add("href", string.Format("../../App_Themes/{0}/{0}.css", Page.StyleSheetTheme));
            Controls.Add(link);
        }
    }

    #region Titulomodulo
    public string TituloModulo
    {
        set { lblTituloModulo.Text = value; }
    }

    public string Mensaje
    {
        get { return lblMensaje.Text; }
        set { lblMensaje.Text = value; }
    }

    public void OcultarMensaje()
    {
        lblMensaje.Text = string.Empty;
        pMensaje.Visible = false;
    }

    public void MostrarMensaje(string mensaje, TipoMensaje tipo)
    {
        mensaje = ObtenerMensaje(mensaje);
        lblMensaje.Text = mensaje;
        switch (tipo)
        {
            case TipoMensaje.Advertencia: lblMensaje.ForeColor = System.Drawing.Color.Blue; imgMensaje.ImageUrl = UrlImagenTipoMensaje.URLIMAGE_ADVERTENCIA; break;
            case TipoMensaje.Error: lblMensaje.ForeColor = System.Drawing.Color.Red; imgMensaje.ImageUrl = UrlImagenTipoMensaje.URLIMAGE_ERROR; break;
            case TipoMensaje.Exito: lblMensaje.ForeColor = System.Drawing.Color.Blue; imgMensaje.ImageUrl = UrlImagenTipoMensaje.URLIMAGE_EXITO; break;
            case TipoMensaje.Informacion: lblMensaje.ForeColor = System.Drawing.Color.Blue; imgMensaje.ImageUrl = UrlImagenTipoMensaje.URLIMAGE_INFORMACION; break;
            default: lblMensaje.ForeColor = System.Drawing.Color.Black; imgMensaje.ImageUrl = UrlImagenTipoMensaje.URLIMAGE_INFORMACION; break;
        }
        pMensaje.Visible = true;
    }
    public void MostrarMensaje(string mensaje, TipoMensaje tipo, Exception ex)
    {
        mensaje = ObtenerMensaje(mensaje);
        int flagExcepcion = 0;
        try
        {   //flag seteado en el webconfig
            flagExcepcion = int.Parse(ConfigurationManager.AppSettings.Get("MostrarException"));
        }
        catch
        {
            flagExcepcion = 0;
        }
        lblMensaje.Text = flagExcepcion == 1 ? mensaje + " MessageException: " + ex.Message.Replace("'", "") : mensaje;
        lblMensaje.Text = flagExcepcion == 1 ? mensaje + " Source: " + ex.Source.Replace("'", "") : mensaje;
        lblMensaje.Text = flagExcepcion == 1 ? mensaje + " StackTrace: " + ex.StackTrace.Replace("'", "") : mensaje;
        switch (tipo)
        {
            case TipoMensaje.Advertencia: lblMensaje.ForeColor = System.Drawing.Color.Blue; imgMensaje.ImageUrl = UrlImagenTipoMensaje.URLIMAGE_ADVERTENCIA; break;
            case TipoMensaje.Error: lblMensaje.ForeColor = System.Drawing.Color.Red; imgMensaje.ImageUrl = UrlImagenTipoMensaje.URLIMAGE_ERROR; break;
            case TipoMensaje.Exito: lblMensaje.ForeColor = System.Drawing.Color.Blue; imgMensaje.ImageUrl = UrlImagenTipoMensaje.URLIMAGE_EXITO; break;
            case TipoMensaje.Informacion: lblMensaje.ForeColor = System.Drawing.Color.Black; imgMensaje.ImageUrl = UrlImagenTipoMensaje.URLIMAGE_INFORMACION; break;
            default: lblMensaje.ForeColor = System.Drawing.Color.Black; imgMensaje.ImageUrl = UrlImagenTipoMensaje.URLIMAGE_INFORMACION; break;
        }
        pMensaje.Visible = true;
    }
    public void MostrarMensaje(string mensaje, TipoMensaje tipo, string exceptionMessage)
    {
        mensaje = ObtenerMensaje(mensaje);
        int flagExcepcion = 0;
        try
        {   //flag seteado en el webconfig
            flagExcepcion = int.Parse(ConfigurationManager.AppSettings.Get("MostrarException"));
        }
        catch
        {
            flagExcepcion = 0;
        }
        lblMensaje.Text = flagExcepcion == 1 ? mensaje + " MessageException: " + exceptionMessage : mensaje;
        //lblMensaje.Text = flagExcepcion == 1 ? mensaje + "Code: " + code + " MessageException: " + ex.Message.Replace("'", "") : mensaje;
        //lblMensaje.Text = flagExcepcion == 1 ? lblMensaje.Text + " Source: " + ex.Source.Replace("'", "") : mensaje;
        //lblMensaje.Text = flagExcepcion == 1 ? lblMensaje.Text + " StackTrace: " + ex.StackTrace.Replace("'", "") : mensaje;

        switch (tipo)
        {
            case TipoMensaje.Advertencia: lblMensaje.ForeColor = System.Drawing.Color.Blue; imgMensaje.ImageUrl = UrlImagenTipoMensaje.URLIMAGE_ADVERTENCIA; break;
            case TipoMensaje.Error: lblMensaje.ForeColor = System.Drawing.Color.Red; imgMensaje.ImageUrl = UrlImagenTipoMensaje.URLIMAGE_ERROR; break;
            case TipoMensaje.Exito: lblMensaje.ForeColor = System.Drawing.Color.Blue; imgMensaje.ImageUrl = UrlImagenTipoMensaje.URLIMAGE_EXITO; break;
            case TipoMensaje.Informacion: lblMensaje.ForeColor = System.Drawing.Color.Black; imgMensaje.ImageUrl = UrlImagenTipoMensaje.URLIMAGE_INFORMACION; break;
            default: lblMensaje.ForeColor = System.Drawing.Color.Black; imgMensaje.ImageUrl = UrlImagenTipoMensaje.URLIMAGE_INFORMACION; break;
        }
        pMensaje.Visible = true;
    }
    public string ObtenerMensaje(string descripcion)
    {
        string codigo = descripcion.Substring(0, 2);
        if (descripcion.Length > 2)
            descripcion = descripcion.Substring(2, descripcion.Length - 2);
        else
            descripcion = string.Empty;
        switch (codigo)
        {

            default: descripcion = codigo + descripcion; break;
        }
        return descripcion;
    }
    #endregion
}
