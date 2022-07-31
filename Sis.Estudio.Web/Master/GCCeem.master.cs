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
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.IO;
using System.Net;
using Sis.Estudio.Entity;
using Sis.Estudio.Logic.MSSQL.Seguridad;
using Sis.Estudio.Logic.MSSQL.Gestion;

public partial class Master_GCCeem : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            HtmlGenericControl link = new HtmlGenericControl("LINK");
            link.Attributes.Add("rel", "stylesheet");
            link.Attributes.Add("type", "text/css");

            Controls.Add(link);

            InicioOperacion();
            GeneraMenu_CargaModulos();
            //CargarMenuPrincipal();
            AsignaNombreModulo();
            //CargaAgenciaUsuario();
            // url para la ayuda
            //AsignarUrlAyuda();
            //AsignarLogo();
            //AsignarPie();


            if (Session["nIdLoginHistorico"] == null)
                this.mxGenerarAlertaHtml();

            //**************************************************
            //**************************************************
            #region SESION
            int MilliSecondsTimeReminder = (Session.Timeout * 60000) - int.Parse(ConfigurationManager.AppSettings.Get("TiempoSesionMinutos")) * 60000;
            int MilliSecondsTimeOut = Session.Timeout * 60000;

            int hola = (Session.Timeout);
            string uriAdvertencia = "http://" + HttpContext.Current.Request.Url.Authority + Pagina.URL_PROYECTO + Pagina.URL_CONCAT_ADVERTENCIA;
            string uriLogin = "http://" + HttpContext.Current.Request.Url.Authority + Pagina.URL_PROYECTO + Pagina.URL_CONCAT_LOGIN;
            StringBuilder oS = new StringBuilder();
            oS.AppendLine("<script language='javascript' type='text/javascript'>");
            oS.AppendLine("var myTimeReminder, myTimeOut;");
            oS.AppendLine("clearTimeout(myTimeReminder);");
            oS.AppendLine("clearTimeout(myTimeOut);");
            oS.AppendFormat("var sessionTimeReminder = {0};", MilliSecondsTimeReminder);
            oS.AppendLine("");
            oS.AppendFormat("var sessionTimeout = {0};", MilliSecondsTimeOut);
            oS.AppendLine("");
            oS.AppendLine("myTimeReminder = setTimeout('showUserMessage()', sessionTimeReminder);");
            oS.AppendLine("myTimeOut = setTimeout('redirect()', sessionTimeout);");
            oS.AppendLine("</script>");
            Page.RegisterClientScriptBlock("CheckSessionOut", oS.ToString());

            oS = new StringBuilder();
            oS.AppendLine("<script language='javascript' type='text/javascript'>");
            oS.AppendLine("function showUserMessage() {");
            oS.AppendLine("var features = 'scrollbars=no,resizable=no';");
            oS.AppendLine("var w = 300;");
            oS.AppendLine("var h = 400;");
            oS.AppendLine("var winl = (screen.width-w)/2;");
            oS.AppendLine("var wint = (screen.height-h)/2;");
            oS.AppendLine("var settings = 'height=' + h + ',';");
            oS.AppendLine("settings += 'width=' + w + ',';");
            oS.AppendLine("settings += 'top=' + wint + ','; ");
            oS.AppendLine("settings += 'left=' + winl; ");
            oS.AppendLine("settings += features;");
            //oS.AppendFormat("var PageOut= '{0}?Tiempo={1}';", ConfigurationManager.AppSettings.Get(ambiente + "PaginaAdvertencia"), int.Parse(ConfigurationManager.AppSettings.Get("TiempoSesionMinutos")));
            //oS.AppendFormat("var PageOut= 'http://localhost:2579/NSE.WorkFlowConvenios.Web/Advertencia.aspx?';");



            oS.AppendFormat("var PageOut= '" + uriAdvertencia + "?Tiempo=1';");
            oS.AppendLine("");
            oS.AppendLine("x = window.open(PageOut, 'timeoutWindow', settings)");
            oS.AppendLine("x.focus(); }");
            oS.AppendLine("</script>");
            Page.RegisterClientScriptBlock("showUserMessage", oS.ToString());

            oS = new StringBuilder();
            oS.AppendLine("<script language='javascript' type='text/javascript'>");
            oS.AppendLine("function redirect() {");

            //oS.AppendLine("window.location.href = '" + ConfigurationManager.AppSettings.Get(ambiente + "PaginaFinSesion") + "';}");
            //oS.AppendLine("window.location.href = 'http://localhost:2579/NSE.WorkFlowConvenios.Web/Login.aspx';}");
            oS.AppendLine("window.location.href = '" + uriLogin + "';}");
            oS.AppendLine("");
            oS.AppendLine("</script>");
            Page.RegisterClientScriptBlock("redirect", oS.ToString());

            #endregion SESION
            //**************************************************
            //**************************************************
        }
        //divContenedor.Visible = Session["nIdLoginHistorico"] != null ? false : true;
        Session["nIdLoginHistorico"] = "ACTIVO";
    }
    protected void InicioOperacion()
    {
        if (Request["Masteridmodulo"] != null)
        {
            if (Request["Masteridmodulo"] != null)
            {
                string str_idmodulo = Request["Masteridmodulo"];
                this.Session["Masteridmodulo"] = str_idmodulo;
            }
            if (Request["Masterdesmodulo"] != null)
            {
                string str_desmodulo = Request["Masterdesmodulo"];
                this.Session["Masterdesmodulo"] = str_desmodulo;
            }
        }
    }
    #region Datos_Menu_Modulos
    private void GeneraMenu_CargaModulos()
    {
        List<EnLogin> ListEnLogin = new List<EnLogin>();
        EnLogin objEnLogin = new EnLogin();
        LoLogin objLoLogin = new LoLogin();

        objEnLogin.CODUSUARIO = (String)this.Session["codusuario"];
        objEnLogin.CEMPRESA = (String)this.Session["cempresa"];
        objEnLogin.IDMODULO = (String)this.Session["Masteridmodulo"];
        objEnLogin.IDMODULO = "1";

        ListEnLogin.Add(objEnLogin);

        #region WCF

        DataTable dt_menu = objLoLogin.GetMenuUsuario(ListEnLogin);
        //DataSet ds = lseguridad.DS_Menu_Modulos(arrParametros.ToArray());
        //DataTable dt_menu = ds.Tables[0];
        //DataTable dt_Modulos = ds.Tables[1];

        #endregion WCF
        CargarMenuPrincipal(dt_menu);
        //Carga_Modulos(dt_Modulos);
    }
    #endregion Datos_Menu_Modulos
    #region Menu
    /// <summary>
    /// Este metodo deberia recibir como parametro la(s) entidade(s) almacenadas en sesion
    /// que contienen informacion del usuario, opciones, etc, etc
    /// </summary>
    /// <returns></returns>
    public void CargarMenuPrincipal(DataTable dt)
    {

        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string padre = dt.Rows[i]["PADRE"].ToString();
                string codigo = dt.Rows[i]["CODIGO"].ToString();
                string url = dt.Rows[i]["URL"].ToString();
                string opcion = dt.Rows[i]["OPCION"].ToString();
                if (padre.ToString().Equals(codigo.ToString()))
                {
                    MenuItem mnuMenuItem = new MenuItem();
                    mnuMenuItem.Value = codigo;
                    mnuMenuItem.Text = opcion;
                    mnuMenuItem.NavigateUrl = url;
                    mnuMenuItem.ToolTip = opcion;
                    UCCabecera1.MenuPrincipal.Items.Add(mnuMenuItem);
                    AddMenuItem(ref mnuMenuItem, dt);
                }
            }
        }
    }
    private void AddMenuItem(ref MenuItem mnuMenuItem, DataTable dt)
    {
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string padre = dt.Rows[i]["PADRE"].ToString();
            string codigo = dt.Rows[i]["CODIGO"].ToString();
            string url = dt.Rows[i]["URL"].ToString();
            string opcion = dt.Rows[i]["OPCION"].ToString();

            if (padre.ToString().Equals(mnuMenuItem.Value) && !codigo.ToString().Equals(padre.ToString()))
            {
                MenuItem mnuNewMenuItem = new MenuItem();
                mnuNewMenuItem.Value = codigo;
                mnuNewMenuItem.Text = opcion;
                mnuNewMenuItem.NavigateUrl = url;
                mnuNewMenuItem.ToolTip = opcion;
                mnuMenuItem.ChildItems.Add(mnuNewMenuItem);
                AddMenuItem(ref mnuNewMenuItem, dt);
            }
        }
    }
    public bool MenuPrincipalVisible
    {
        get { return UCCabecera1.MenuPrincipal.Visible; }
        set { UCCabecera1.MenuPrincipal.Visible = value; }
    }
    #endregion
    #region Modulos
    private void Carga_Modulos(DataTable dt)
    {
        string str_idmodulo;
        string str_desmodulo;
        if (dt.Rows.Count > 1)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                str_idmodulo = dt.Rows[i][0].ToString().Trim();
                str_desmodulo = dt.Rows[i][1].ToString().Trim();
                UCCabecera1.agrega_items(str_idmodulo, str_desmodulo);
            }
        }
        else
        {
            UCCabecera1.OcultarComboModulo();
        }
    }
    #endregion Modulos
    #region  LLenarSiteMap

    #endregion
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
    public void MostrarMensaje(string mensaje, TipoMensaje tipo, string exceptionMessage, StringCollection code)
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
        for (int i = 0; i < code.Count; i++)
        {
            lblMensaje.Text = lblMensaje.Text + " ASCode: " + code[i].ToString();
        }

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
    public void AgregarMensaje(string mensaje, TipoMensaje tipo)
    {
        mensaje = ObtenerMensaje(mensaje);
        lblMensaje.Text = lblMensaje.Text + mensaje;
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
    public void AgregarMensaje(string mensaje, TipoMensaje tipo, Exception ex)
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
        lblMensaje.Text = flagExcepcion == 1 ? lblMensaje.Text + mensaje + " MessageException: " + ex.Message.Replace("'", "") : mensaje;
        lblMensaje.Text = flagExcepcion == 1 ? lblMensaje.Text + " Source: " + ex.Source.Replace("'", "") : mensaje;
        lblMensaje.Text = flagExcepcion == 1 ? lblMensaje.Text + " StackTrace: " + ex.StackTrace.Replace("'", "") : mensaje;
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
    public void AgregarMensaje(string mensaje, TipoMensaje tipo, string exceptionMessage)
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
        lblMensaje.Text = flagExcepcion == 1 ? lblMensaje.Text + mensaje + " MessageException: " + exceptionMessage : mensaje;
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
    public void AgregarMensaje(string mensaje, TipoMensaje tipo, string exceptionMessage, StringCollection code)
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
        lblMensaje.Text = flagExcepcion == 1 ? lblMensaje.Text + mensaje + " MessageException: " + exceptionMessage : mensaje;
        for (int i = 0; i < code.Count; i++)
        {
            lblMensaje.Text = lblMensaje.Text + " ASCode: " + code[i].ToString();
        }

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
    public void AgregarMensaje_(StringCollection code, TipoMensaje tipo)
    {
        if (tipo == TipoMensaje.Exito)
        {
            if (code.Count > 0)
            {
                lblMensaje.Text = lblMensaje.Text + "Message:" + "</BR>";
                for (int i = 0; i < code.Count; i++)
                {
                    lblMensaje.Text = lblMensaje.Text + " --> " + code[i].ToString();
                }

                switch (tipo)
                {
                    case TipoMensaje.Advertencia: lblMensaje.ForeColor = System.Drawing.Color.Blue; imgMensaje.ImageUrl = UrlImagenTipoMensaje.URLIMAGE_ADVERTENCIA; break;
                    case TipoMensaje.Error: lblMensaje.ForeColor = System.Drawing.Color.Red; imgMensaje.ImageUrl = UrlImagenTipoMensaje.URLIMAGE_ERROR; break;
                    case TipoMensaje.Exito: lblMensaje.ForeColor = System.Drawing.Color.Blue; imgMensaje.ImageUrl = UrlImagenTipoMensaje.URLIMAGE_EXITO; break;
                    case TipoMensaje.Informacion: lblMensaje.ForeColor = System.Drawing.Color.Black; imgMensaje.ImageUrl = UrlImagenTipoMensaje.URLIMAGE_INFORMACION; break;
                    default: lblMensaje.ForeColor = System.Drawing.Color.Black; imgMensaje.ImageUrl = UrlImagenTipoMensaje.URLIMAGE_INFORMACION; break;
                }
            }
        }
        pMensaje.Visible = true;
    }
    public void AgregarMensaje(StringCollection code, TipoMensaje tipo)
    {
        for (int i = 0; i < code.Count; i++)
        {
            ColocarMensaje(tipo, "", code[i]);
        }
        pMensakeList.Visible = true;
    }
    public void ColocarMensaje(TipoMensaje tipo, string exceptionMessage, string mensaje)
    {
        mensaje = ObtenerMensaje(mensaje);
        Label lblMensaje = new Label();
        Image imgMensaje = new Image();

        lblMensaje.Text = "Message: ";
        lblMensaje.Text = lblMensaje.Text + " --> " + mensaje + "</BR>";

        switch (tipo)
        {
            case TipoMensaje.Advertencia: lblMensaje.ForeColor = System.Drawing.Color.Blue; imgMensaje.ImageUrl = UrlImagenTipoMensaje.URLIMAGE_ADVERTENCIA; break;
            case TipoMensaje.Error: lblMensaje.ForeColor = System.Drawing.Color.Red; imgMensaje.ImageUrl = UrlImagenTipoMensaje.URLIMAGE_ERROR; break;
            case TipoMensaje.Exito: lblMensaje.ForeColor = System.Drawing.Color.Blue; imgMensaje.ImageUrl = UrlImagenTipoMensaje.URLIMAGE_EXITO; break;
            case TipoMensaje.Informacion: lblMensaje.ForeColor = System.Drawing.Color.Black; imgMensaje.ImageUrl = UrlImagenTipoMensaje.URLIMAGE_INFORMACION; break;
            default: lblMensaje.ForeColor = System.Drawing.Color.Black; imgMensaje.ImageUrl = UrlImagenTipoMensaje.URLIMAGE_INFORMACION; break;
        }
        this.pMensakeList.Controls.Add(imgMensaje);
        this.pMensakeList.Controls.Add(lblMensaje);
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
    #region Titulomodulo ------------
    public string TituloModulo
    {
        set { lblTituloModulo.Text = value; }
    }
    #endregion
    #region Ayuda -------------------
    public void AsignarUrlAyuda()
    {
        Page page = HttpContext.Current.CurrentHandler as Page;
        string pagina = page.AppRelativeVirtualPath;
        string url = string.Empty;
        string tamanos = "height=600,width=900,scroll=yes,unadorned=yes,resizable:no";
        if (pagina.IndexOf("solcred") > 0)
        {
            url = Request.ApplicationPath + "/help/solcred.htm?url=" + pagina.Replace("~/", "").Replace("aspx", "htm");
        }
        if (pagina.IndexOf("verifica") > 0)
        {
            url = Request.ApplicationPath + "/help/verifica.htm?url=" + pagina.Replace("~/", "").Replace("aspx", "htm");
        }
        if (pagina.IndexOf("adminpol") > 0)
        {
            url = Request.ApplicationPath + "/help/adminpol.htm?url=" + pagina.Replace("~/", "").Replace("aspx", "htm");
        }
        if (pagina.IndexOf("estadistica") > 0)
        {
            url = Request.ApplicationPath + "/help/estadistica.htm?url=" + pagina.Replace("~/", "").Replace("aspx", "htm");
        }
        UCCabecera1.btnAyuda.Attributes.Add("onClick", "javascript:window.open('" + url + "','Ayuda','" + tamanos + "')");
    }

    #endregion
    #region Logo --------------------
    public void AsignarLogo()
    {
        string logoEmpresa = string.Empty;
        try
        {
            // logoEmpresa = ConfigurationManager.AppSettings.Get("logoEmpresa").ToString();
        }
        catch (Exception)
        {

        }



    }
    public void AsignarPie()
    {
        //string urlPaginaAcercaDe = Request.ApplicationPath+"/help/acercade.htm";
        //string urlPrivacidad= Request.ApplicationPath+"/help/privacidad.htm";
        //string urlContacto= Request.ApplicationPath+"/help/contacto.htm";
        //string urlTerminodeuso= Request.ApplicationPath+"/help/terminosdeuso.htm";
        //string parametrosPagina = "toolbar=0,location=0,directories=0,status=1,menubar=0,scrollbars=1,resizable=0,width=350,height=410";
        //UCPie1.AcercaDe.Attributes.Add("onClick",  "javascript:window.open('" + urlPaginaAcercaDe + "','AcercaDe','" + parametrosPagina + "');");
        //UCPie1.Privacidad.Attributes.Add("onClick",  "javascript:window.open('" + urlPrivacidad + "','urlPrivacidad','" + parametrosPagina + "');");
        //UCPie1.Contacto.Attributes.Add("onClick", "javascript:window.open('" + urlContacto + "','urlContacto','" + parametrosPagina + "');");
        //UCPie1.TerminoUso.Attributes.Add("onClick", "javascript:window.open('" + urlTerminodeuso + "','urlTerminodeuso','" + parametrosPagina + "');");
    }
    private void AsignaNombreModulo()
    {
        //UCCabecera1.NombreModulo = (String)this.Session["Masterdesmodulo"].ToString();
        //UCCabecera1.NombreModulo = (String)this.Session["Masterdesmodulo"].ToString();
    }
    #endregion
    /*protected void Timer1_Tick(object sender, EventArgs e)
    {
        Response.Write("<script language=javascript>alert('Hola');</script>");
    }*/
    public string mxGenerarAlertaHtml()
    {
        DataTable ldtListaReagendados;
        string lcHtml;
        ldtListaReagendados = mxListarReagendados();
        lcHtml = string.Empty;

        for(int i=0;i<ldtListaReagendados.Rows.Count;i++)
        {
            lcHtml += "<strong>Atenci&oacute;n!</strong> "+
                     "Tiene reagendado un AP de '" + ldtListaReagendados.Rows[i]["cTipoGestion"] +
                     "' para el cliente '" + ldtListaReagendados.Rows[i]["cRazonSocial"] +
                     "' con Nro Documento '" + ldtListaReagendados.Rows[i]["cDocumento"] + 
                     "'<br />";
        }
        lblHtml.Text = lcHtml;
        /*
         * Validamos si la sesion en la que estamos ya capturo el valor de la Base de Datos para 
         * mostrar el mensaje de alerta en la ventana.
        */

        divContenedor.Visible = lcHtml != string.Empty ? true : false;

        return lcHtml;
    }
    public DataTable mxListarReagendados()
    {
        //DataTable ldtListaReagenadados;
        List<EnGS_Gestion_Cobranza> lstEnGS_Gestion_Cobranza = new List<EnGS_Gestion_Cobranza>();
        EnGS_Gestion_Cobranza loEnGS_Gestion_Cobranza = new EnGS_Gestion_Cobranza();
        LoGS_Gestion_Cobranza loLoGS_Gestion_Cobranza = new LoGS_Gestion_Cobranza();

        loEnGS_Gestion_Cobranza.nEmpresa = (String)this.Session["cempresa"];
        loEnGS_Gestion_Cobranza.CodUsuario = (String)this.Session["codusuario"];

        lstEnGS_Gestion_Cobranza.Add(loEnGS_Gestion_Cobranza);

        return loLoGS_Gestion_Cobranza.mxListarReagendados(lstEnGS_Gestion_Cobranza);
    }
    public string mxGenerarAlertaHtml_Futuras()
    {
        DataTable ldtListaReagendados;
        string lcHtml;
        ldtListaReagendados = mxListarReagendados_Futuras();
        lcHtml = string.Empty;

        for (int i = 0; i < ldtListaReagendados.Rows.Count; i++)
        {
            lcHtml += "<strong>Atenci&oacute;n!</strong> " +
                     "Tiene reagendado un AP de '" + ldtListaReagendados.Rows[i]["cTipoGestion"] +
                     "' para el cliente '" + ldtListaReagendados.Rows[i]["cRazonSocial"] +
                     "' con Nro Documento '" + ldtListaReagendados.Rows[i]["cDocumento"] +
                     "'<br />";
        }
        lblHtml.Text = lcHtml;
        /*
         * Validamos si la sesion en la que estamos ya capturo el valor de la Base de Datos para 
         * mostrar el mensaje de alerta en la ventana.
        */

        divContenedor.Visible = lcHtml != string.Empty ? true : false;

        return lcHtml;
    }
    public DataTable mxListarReagendados_Futuras()
    {
        //DataTable ldtListaReagenadados;
        List<EnGS_Gestion_Cobranza> lstEnGS_Gestion_Cobranza = new List<EnGS_Gestion_Cobranza>();
        EnGS_Gestion_Cobranza loEnGS_Gestion_Cobranza = new EnGS_Gestion_Cobranza();
        LoGS_Gestion_Cobranza loLoGS_Gestion_Cobranza = new LoGS_Gestion_Cobranza();

        loEnGS_Gestion_Cobranza.nEmpresa = (String)this.Session["cempresa"];
        loEnGS_Gestion_Cobranza.CodUsuario = (String)this.Session["codusuario"];

        lstEnGS_Gestion_Cobranza.Add(loEnGS_Gestion_Cobranza);


        return loLoGS_Gestion_Cobranza.mxListarReagendados_Futuras(lstEnGS_Gestion_Cobranza);
    }
    //mxListarReagendados_Futuras
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        /*lblPrueba.Text = "Aqui estoy";
        if (lblPrueba.Visible)
            lblPrueba.Visible = false;
        else
            lblPrueba.Visible = true;*/
        mxGenerarAlertaHtml_Futuras();

    }
}
