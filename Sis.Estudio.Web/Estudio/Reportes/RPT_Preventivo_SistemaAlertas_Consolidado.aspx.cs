using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Reflection;
using System.Drawing;
using System.Text;
using System.Xml.Linq;
using System.IO;
using System.Data.SqlClient;
using IABaseWeb;
using Sis.Estudio.Entity;
using Sis.Estudio.Logic.MSSQL.Gestion;
using System.Diagnostics;

public partial class Estudio_Reportes_RPT_Preventivo_SistemaAlertas_Consolidado : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
        scriptManager.RegisterPostBackControl(this.btn_Excel);
        btn_Excel.Focus();
        if (!Page.IsPostBack)
        {

            this.Master.TituloModulo = "Reporte Preventivo: Sistema de Alertas - Consolidado";
            Inicio();
        }
    }

    private void Inicio()
    {
        Cargar_Modulos();
    }

    protected void Cargar_Modulos()
    {
        Cargar_Anio();
        Cargar_Mes();
    }

    protected void Cargar_Anio()
    {
        DataTable dt = new DataTable();
        try
        {
            LoGS_BaseReportes objLoGS_BaseReportes = new LoGS_BaseReportes();
            EnGS_BaseReportes objEnGS_BaseReportes = new EnGS_BaseReportes();
            List<EnGS_BaseReportes> ListEnGS_BaseReportes = new List<EnGS_BaseReportes>();

            objEnGS_BaseReportes.NEmpresa = (String)this.Session["cempresa"];
            ListEnGS_BaseReportes.Add(objEnGS_BaseReportes);

            cmb_Anio.Items.Clear();
            dt = objLoGS_BaseReportes.RPT_BaseReporte_ObtenerAnio(ListEnGS_BaseReportes);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["Año"].ToString().Trim();
                lista.Text = dt.Rows[i]["Año"].ToString().Trim();
                cmb_Anio.Items.Add(lista);
            }
            
        }
        catch (Exception excp)
        {
            throw excp;
        }
    }

    protected void Cargar_Mes()
    {
        DataTable dt = new DataTable();

        try
        {
            LoGS_BaseReportes objLoGS_BaseReportes = new LoGS_BaseReportes();
            EnGS_BaseReportes objEnGS_BaseReportes = new EnGS_BaseReportes();
            List<EnGS_BaseReportes> ListEnGS_BaseReportes = new List<EnGS_BaseReportes>();

            objEnGS_BaseReportes.NEmpresa = (String)this.Session["cempresa"];
            objEnGS_BaseReportes.Anio = cmb_Anio.SelectedItem.Value.ToString().Trim();
            ListEnGS_BaseReportes.Add(objEnGS_BaseReportes);

            cmb_mes.Items.Clear();

            dt = objLoGS_BaseReportes.RPT_BaseReporte_ObtenerMes(ListEnGS_BaseReportes);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["Mes"].ToString().Trim();
                lista.Text = dt.Rows[i]["Mes"].ToString().Trim();
                cmb_mes.Items.Add(lista);
            }
        }
        catch (Exception excp)
        {
            throw excp;
        }
    }
    protected void btn_Excel_Click(object sender, EventArgs e)
    {
        try
        {
            Master.OcultarMensaje();
            string cempresa = (String)this.Session["cempresa"];
            if (cempresa == "" || cempresa == null)
            {
                this.Session.Abandon();
                Response.Redirect("../Login.aspx?rd=0");
                return;
            }
            //Exportar(Extencion.Excel);
            //Process.Start(Server.MapPath("~/ReportesGerencialesModelo/TableroAlertas-28022017-130300.xlsx"));
            this.mxDescargarReporteSistemaAlerta();
        }
        catch (Exception ex)
        {
            Master.MostrarMensaje(ex.Message.ToString(), TipoMensaje.Error);
        }
    }

    private void Exportar(string Formato)
    {
        try
        {
            string str_parametros = "";
            string str_tiporeporte = "?tiporeporte=" + Formato;
            string str_nempresa = "&nempresa=" + (String)Session[Global.NEmpresa].ToString();
            string str_anio = "&anio=" + cmb_Anio.SelectedValue.ToString();
            string str_mes = "&mes=" + cmb_mes.SelectedValue.ToString();

            str_parametros = str_tiporeporte + str_nempresa + str_anio + str_mes;

            string CONFIG = "'resizable = yes, scrollbars = yes, toolbar=no, height = 500, width = 800,left=200,top=100,status=yes, location=no, menubar=no'";

            StringBuilder sb = new StringBuilder();
            sb.Append("<script>var win=window.open('../../Reportes/Reportes/ReportePreventivo_SistemaAlertas_Consolidado.aspx" + str_parametros + "', 'ReportePreventivo_SistemaAlertas_Consolidado', " + CONFIG + ");</script>");
            ScriptManager.RegisterStartupScript(this, typeof(Page), "ReporteAccion", sb.ToString(), false);
        }
        catch (Exception excp)
        {
            Master.MostrarMensaje(excp.ToString(),TipoMensaje.Error);
        }
    }
    protected void btn_Imprimir_Click(object sender, EventArgs e)
    {

    }
    protected void cmb_Anio_SelectedIndexChanged(object sender, EventArgs e)
    {
        Cargar_Mes();
    }
    private void mxDescargarReporteSistemaAlerta()
    {
        string lcNomArchivo = "..\\..\\ReportesGerencialesModelo\\TableroAlertas-28022017-130300.xlsx";
        string lcArcDestino = "ReporteAlertas.xls";
        this.mxDescargarArchivo(lcNomArchivo, lcArcDestino);
    }
    private void mxDescargarArchivo(string pcNomArchivo, string lcArcDestino)
    {
        if (!string.IsNullOrEmpty(pcNomArchivo))
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=" + lcArcDestino);
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.xls";
            Response.TransmitFile(pcNomArchivo);
            Response.End();
        }
    }
}