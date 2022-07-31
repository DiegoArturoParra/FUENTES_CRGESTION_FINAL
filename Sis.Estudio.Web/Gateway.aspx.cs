using System;
using System.Data;
using System.Data.SqlClient;
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
using Sis.Estudio.Logic.MSSQL.Funcionabilidad;
using Sis.Estudio.Logic.MSSQL.Seguridad;
using Sis.Estudio.Entity;

public partial class Gateway : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            Master.CerrarSesionVisible(false);
            Master.IniciarSesionVisible(false);

            string str_Keylogin = "";

            if (Request["keylogin"] != null)
            {
                str_Keylogin = Request["keylogin"];

                #region Valida
                if (str_Keylogin.Length < 1)
                {
                    Master.MostrarMensaje("Acceso No permitido", TipoMensaje.Error);
                    return;
                }

                #endregion Valida
                Obtiene_KeyLogin(str_Keylogin);
            }
            else
            {
                Master.MostrarMensaje("Acceso No permitido", TipoMensaje.Error);
            }
        }

    }

    #region Eventos
    #endregion Eventos
    #region Metodos
    private void Obtiene_KeyLogin(string str_KeyLogin)
    {
        try
        {
            this.Master.TituloModulo = "";
            #region Carga_Variables
            LoEncripta objLoEncripta = new LoEncripta();            
            str_KeyLogin = objLoEncripta.ObtenerMd52(str_KeyLogin);

            DataTable DT_Datos = new DataTable();
            LoLogin objLoLogin = new LoLogin();
            EnLogin objEnLogin = new EnLogin();
            List<EnLogin> ListEnLogin = new List<EnLogin>();

            objEnLogin.CEMPRESA = FlagsPrograma.FLG_VALOREMPRESA;
            objEnLogin.KeyLogin = str_KeyLogin;

            ListEnLogin.Add(objEnLogin);
            DT_Datos = objLoLogin.Obtiene_KeyLogin(ListEnLogin);
            #endregion Carga_Variables

            if (DT_Datos.Rows.Count > 0)
            {
                string str_Login = DT_Datos.Rows[0]["login3"].ToString();
                string str_DesModulo = DT_Datos.Rows[0]["DesModulo"].ToString();

                IngresoWeb(str_Login, str_DesModulo, str_KeyLogin);
            }
            else
            {
                Master.MostrarMensaje("No se establecio Acceso.", TipoMensaje.Error);
            }
        }
        catch (Exception ex)
        {
            Master.MostrarMensaje(ex.Message.ToString(), TipoMensaje.Error);
        }
    }
    private void IngresoWeb(string str_Login, string str_DesModulo, string str_KeyLogin)
    {
        #region servicios

        List<EnLogin> ListEnLogin = new List<EnLogin>();
        EnLogin objEnLogin = new EnLogin();
        LoLogin objLoLogin = new LoLogin();
        LoEncripta objLoLoEncripta = new LoEncripta();

        objEnLogin.CEMPRESA = FlagsPrograma.FLG_VALOREMPRESA;
        objEnLogin.LOGIN = str_Login;
        ListEnLogin.Add(objEnLogin);

        DataTable dt = objLoLogin.GetUsuarioLoginAutomatico(ListEnLogin);
        #endregion servicios
        if (dt.Rows.Count > 0)
        {
            #region AsignaValores
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                this.Session["Masterdesmodulo"] = str_DesModulo;
                this.Session["dsistema"] = dt.Rows[i]["SISTEMA"].ToString();
                this.Session["dempresa"] = "desempresa"; // temporalmente mientras dura el desarrollo
                this.Session["cempresa"] = FlagsPrograma.FLG_VALOREMPRESA; // temporalmente mientras dura el desarrollo
                this.Session["fecha_Logeo"] = dt.Rows[i]["FECHA_LOGEO"].ToString();
                this.Session["codusuario"] = dt.Rows[i]["IdUsuario"].ToString().Trim();
                this.Session["login"] = dt.Rows[i]["CodUsuario"].ToString().Trim();
                this.Session["tipoacceso"] = "";
                this.Session["NombreUsuario"] = dt.Rows[i]["NombresUsuario"].ToString().Trim();

                string str_codusuario = (String)this.Session["codusuario"];
                FormsAuthentication.RedirectFromLoginPage(str_codusuario, false);
            }
            #endregion AsignaValores
            #region CerrarKeyLogin
            if (Cerrar_KeyLogin(str_KeyLogin))
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                Master.MostrarMensaje("No se Completo la operación de Logueo", TipoMensaje.Error);
            }
            #endregion CerrarKeyLogin            
        }
    }
    private bool Cerrar_KeyLogin(string str_KeyLogin)
    {
        bool bool_Retorno = false;
        string msg = "";
        string Exito = "";        
        LoLogin objLoLogin = new LoLogin();
        try
        {
            #region Cargar_Variables
            EnLogin objEnLogin = new EnLogin();
            List<EnLogin> ListEnLogin = new List<EnLogin>();
            objEnLogin.CEMPRESA = (String)this.Session["cempresa"];
            objEnLogin.KeyLogin = str_KeyLogin;
            ListEnLogin.Add(objEnLogin);

            #endregion Cargar_Variables                       
            msg = objLoLogin.Cierra_KeyLogin(ListEnLogin);
            #region Validacion
            if (msg == "") 
            { Exito = FlagsPrograma.FLG_VALOREXITOSI; } 
            else 
            { 
                Master.MostrarMensaje(msg, TipoMensaje.Error, msg); 
                Exito = FlagsPrograma.FLG_VALOREXITONO; 
                bool_Retorno =  false; 
            }
            #endregion Validacion
        }
        catch (Exception ex)
        {
            msg = HttpUtility.HtmlEncode(ex.Message);
            Master.MostrarMensaje(msg, TipoMensaje.Error);
            Exito = FlagsPrograma.FLG_VALOREXITONO;
        }

        if (Exito == FlagsPrograma.FLG_VALOREXITOSI)
        {
            bool_Retorno = true;
        }

        return bool_Retorno;
    }
    #endregion Metodos
   
}