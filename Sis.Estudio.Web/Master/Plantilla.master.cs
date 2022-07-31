using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Configuration;
using System.Web.UI.WebControls;

public partial class Master_Plantilla : System.Web.UI.MasterPage
{
    #region Propiedades
    #endregion Propiedades
    #region Eventos
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    #endregion Eventos
    #region Metodos



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

    #endregion Metodos
}
