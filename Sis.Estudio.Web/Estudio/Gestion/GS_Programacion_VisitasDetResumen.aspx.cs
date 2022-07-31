using System;
using System.Drawing;
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
using System.Text;
using System.Data.SqlClient;
using System.IO;
using Sis.Estudio.Entity;
using Sis.Estudio.Logic.MSSQL.Seguridad;

public partial class Estudio_Gestion_GS_Programacion_VisitasDetResumen : System.Web.UI.Page
{
    public string mstrEstado;
    #region Eventos
    protected void Page_Load(object sender, EventArgs e)
    {
        #region windows_mod
        Response.Expires = 0;
        Response.AddHeader("pragma", "no-cache");
        Response.AddHeader("cache-control", "private");
        Response.CacheControl = "no-cache";
        #endregion windows_mod
        if (!IsPostBack)
        {
            Master.TituloModulo = "Resumen";
            InicioOperacion();
        }
    }
    
    protected void btn_SALIR_Click(object sender, EventArgs e)
    {
        StringBuilder sb1 = new StringBuilder();
        sb1.Append("<script>");
        sb1.Append("window.returnValue = 1;");
        sb1.Append("window.close();");
        sb1.Append("</script>");
        ScriptManager.RegisterStartupScript(this, typeof(Page), "", sb1.ToString(), false);
    }
    #endregion Eventos
    #region Metodos
    protected void InicioOperacion()
    {
        //****************************************************************************************
        //* Nomre       : InicioOperacion
        //* DescripcioN :
        //****************************************************************************************
        try
        {

            if (Request["distrito"] != null)
            {
               
                txt_Distrito.Text = Request["distrito"];
                txt_TotalDistrito.Text = Request["totaldistrito"];
                txt_MontoCuota.Text = Request["montocuota"];

            }

        }
        catch (Exception ex)
        {
            Master.MostrarMensaje(ex.Message, TipoMensaje.Advertencia, ex);
        }
    }

    
    #endregion Metodos
    #region funciones
    
    #endregion funciones
    #region Datos
  



    #endregion Datos
}








