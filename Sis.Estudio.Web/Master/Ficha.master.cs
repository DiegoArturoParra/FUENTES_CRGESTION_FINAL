using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Master_Ficha : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        #region Sesion
        string cempresa = (String)this.Session["cempresa"]; ;
        if (cempresa == "" || cempresa == null)
        {
            this.Session.Abandon();
            Response.Redirect("SessionExpirada.aspx");
            return;
        }
        #endregion Sesion
    }


    #region Mensajes
    /// <summary>
    /// Metodo para ocultar los mensajes en la pagina
    /// </summary>
    public void OcultarMensaje()
    {
        lblMensaje.Text = string.Empty;
        pMensaje.Visible = false;
    }
    /// <summary>
    /// Metodo para mostrar mensajes en la pagina
    /// </summary>
    /// <param name="mensaje">Mensaje a mostrar</param>
    /// <param name="tipo">Tipo de error</param>
    public void MostrarMensaje(string mensaje, TipoMensaje tipo)
    {
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



    #endregion

}
