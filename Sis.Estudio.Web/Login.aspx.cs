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
using System.Security.Principal;
using System.ServiceModel;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using System.Drawing;
using System.Threading;

using Sis.Estudio.Entity;
using Sis.Estudio.Logic.MSSQL.Funcionabilidad;
using Sis.Estudio.Logic.MSSQL.Seguridad;


public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //this.Master.IniciarSesionVisible(false);
        //this.Master.CerrarSesionVisible(false);
        txtUserName.Focus();
    }
    #region Eventos
    protected void btnLogin_Click(object sender, ImageClickEventArgs e)
    {
     limpiarMensaje();

        //Thread.Sleep(5000);
        //MostrarMensaje("tiempo transcurrido", true);
        Loguear();

    }
    #endregion Eventos

    #region Metodos
    private void Loguear()
    {
        List<EnLogin> ListEnLogin = null;
        EnLogin objEnLogin = null;
        LoLogin objLoLogin = null;
        LoEncripta objLoLoEncripta = null;
        DataTable dt = null;
        try
        {
            #region servicios

            ListEnLogin = new List<EnLogin>();
            objEnLogin = new EnLogin();
            objLoLogin = new LoLogin();
            objLoLoEncripta = new LoEncripta();

            objEnLogin.CEMPRESA = FlagsPrograma.FLG_VALOREMPRESA;
            objEnLogin.LOGIN = txtUserName.Text.Trim();

            //objEnLogin.PASSWORD = objLoLoEncripta.f_Encripta_Desencripta(1, txtPassword.Text.Trim());
            objEnLogin.PASSWORD = objLoLoEncripta.Cl_Encripta(txtPassword.Text.Trim());
            //objEnLogin.PASSWORD = txtPassword.Text.Trim().ToString();

            ListEnLogin.Add(objEnLogin);

            limpiarMensaje();
            dt = objLoLogin.GetUsuarioLogin(ListEnLogin);
            #endregion servicios
            if (dt.Rows.Count > 0)
            {
                #region AsignaValores
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //Cempresa
                    this.Session["Masteridmodulo"] = "1";
                    this.Session["Masterdesmodulo"] = "Seguridad";                    
                    this.Session["dsistema"] = dt.Rows[i]["SISTEMA"].ToString();
                    this.Session["dempresa"] = "desempresa"; // temporalmente mientras dura el desarrollo
                    this.Session["cempresa"] = dt.Rows[i]["Cempresa"].ToString();  //FlagsPrograma.FLG_VALOREMPRESA; // temporalmente mientras dura el desarrollo
                    
                    
                    this.Session["fecha_Logeo"] = dt.Rows[i]["FECHA_LOGEO"].ToString();                    
                    this.Session["codusuario"] = dt.Rows[i]["IdUsuario"].ToString().Trim();
                    this.Session["login"] = dt.Rows[i]["CodUsuario"].ToString().Trim();
                    this.Session["tipoacceso"] = "";
                    this.Session["NombreUsuario"] = dt.Rows[i]["NombresUsuario"].ToString().Trim();
                    this.Session["Perfil"] = dt.Rows[i]["Perfil"].ToString().Trim();

                    this.Session[Global.NEmpresa] = dt.Rows[i]["Cempresa"].ToString();
                    
                    //str_codusuario = (String)this.Session["codusuario"];
                }
                #endregion AsignaValores

                //Login2.DestinationPageUrl = "Modulo/Seguridad/EstablecerModulo.aspx";
                //Response.Redirect("Modulo/Seguridad/EstablecerModulo.aspx");
                Response.Redirect("Default.aspx");
                //FormsAuthentication.RedirectFromLoginPage(str_codusuario, true);
                //e.Authenticated = true;
            }
            else
            {
                MostrarMensaje("Usuario o Password invalido!!", true);
            }
        }
        catch (Exception ex)
        {
            Session["ErrorMessage"] = ex.Message;
            //e.Authenticated = false;
            //Login2.FailureText = ex.ToString();
            MostrarMensaje(ex.Message.ToString(), true);
        }
    }
    #endregion Metodos

    #region Procedimientos
    protected void MostrarMensaje(string str_mensaje, bool error)
    {
        //**********************************************************************************************
        //*	 MostrarMensaje : Muestra el  mensaje de avisos.
        //**********************************************************************************************
        lblMensaje.Text = str_mensaje;
        if (error == true)
        {
            lblMensaje.ForeColor = Color.White;
        }
        else
        {
            lblMensaje.ForeColor = Color.Yellow;
        }
        //upLogin.Update();

    }
    protected void limpiarMensaje()
    {
        //**********************************************************************************************
        //*	 limpiarMensaje : limpia mensaje de avisos.
        //**********************************************************************************************
        lblMensaje.Text = "";
        lblMensaje.ForeColor = Color.Red;
        //upBotonera.Update();
    }

    #endregion Procedimientos
    
}