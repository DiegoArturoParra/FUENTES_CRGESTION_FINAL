using Sis.Estudio.Entity;
using Sis.Estudio.Logic.MSSQL.Gestion;
using Sis.Estudio.Logic.MSSQL.Reportes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Estudio_Reportes_RPT_Gerencia_Cosechas_Tramo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
        scriptManager.RegisterPostBackControl(this.btn_Excel);
        btn_Excel.Focus();
        if (!Page.IsPostBack)
        {

            this.Master.TituloModulo = "Reporte Gerencial: Cosecha Total Carteras";
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
        CargaComboTramo();
        //Cargar_Mes_Inicial();
        //Cargar_Mes_Final();
        //Cargar_Tramo();
        //Cargar_Producto();
        //Cargar_Zona();
    }

    protected void Cargar_Anio()
    {
        DataTable dt = new DataTable();
        try
        {
            LoRPT_BaseContencion objLoRPT_BaseContencion = new LoRPT_BaseContencion();
            EnRPT_BaseContencion objEnRPT_BaseContencion = new EnRPT_BaseContencion();
            List<EnRPT_BaseContencion> ListEnRPT_BaseContencion = new List<EnRPT_BaseContencion>();

            objEnRPT_BaseContencion.NEmpresa = (String)this.Session["cempresa"];
            ListEnRPT_BaseContencion.Add(objEnRPT_BaseContencion);

            cmb_Anio.Items.Clear();
            cmb_Anio_Fin.Items.Clear();
            dt = objLoRPT_BaseContencion.RPT_BaseContencion_ObtenerAnio(ListEnRPT_BaseContencion);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["IdAnio"].ToString().Trim();
                lista.Text = dt.Rows[i]["Año"].ToString().Trim();
                cmb_Anio.Items.Add(lista);
                cmb_Anio_Fin.Items.Add(lista);
            }

        }
        catch (Exception excp)
        {
            throw excp;
        }
    }

    protected void Cargar_Mes_Inicial()
    {
        DataTable dt = new DataTable();

        try
        {
            LoRPT_BaseContencion objLoRPT_BaseContencion = new LoRPT_BaseContencion();
            EnRPT_BaseContencion objEnRPT_BaseContencion = new EnRPT_BaseContencion();
            List<EnRPT_BaseContencion> ListEnRPT_BaseContencion = new List<EnRPT_BaseContencion>();

            objEnRPT_BaseContencion.NEmpresa = (String)this.Session["cempresa"];
            objEnRPT_BaseContencion.AnioInt = cmb_Anio.SelectedItem.Value.ToString().Trim();
            ListEnRPT_BaseContencion.Add(objEnRPT_BaseContencion);

            cmb_mes_Inicial.Items.Clear();

            dt = objLoRPT_BaseContencion.RPT_BaseContencion_ObtenerMes(ListEnRPT_BaseContencion);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["IdMes"].ToString().Trim();
                lista.Text = dt.Rows[i]["Mes"].ToString().Trim();
                cmb_mes_Inicial.Items.Add(lista);
            }
        }
        catch (Exception excp)
        {
            throw excp;
        }
    }

    protected void Cargar_Mes_Final()
    {
        DataTable dt = new DataTable();

        try
        {
            LoRPT_BaseContencion objLoRPT_BaseContencion = new LoRPT_BaseContencion();
            EnRPT_BaseContencion objEnRPT_BaseContencion = new EnRPT_BaseContencion();
            List<EnRPT_BaseContencion> ListEnRPT_BaseContencion = new List<EnRPT_BaseContencion>();

            objEnRPT_BaseContencion.NEmpresa = (String)this.Session["cempresa"];
            objEnRPT_BaseContencion.AnioInt = cmb_Anio.SelectedItem.Value.ToString().Trim();
            objEnRPT_BaseContencion.MesIntInicio = cmb_mes_Inicial.SelectedItem.Value.ToString().Trim();
            ListEnRPT_BaseContencion.Add(objEnRPT_BaseContencion);

            cmb_mes_Final.Items.Clear();

            dt = objLoRPT_BaseContencion.RPT_BaseContencion_ObtenerMesFinal(ListEnRPT_BaseContencion);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["IdMes"].ToString().Trim();
                lista.Text = dt.Rows[i]["Mes"].ToString().Trim();
                cmb_mes_Final.Items.Add(lista);
            }
        }
        catch (Exception excp)
        {
            throw excp;
        }
    }

    protected void CargaComboTramo()
    {
        DataTable dt = new DataTable();
        try
        {
            LoGS_ReglasGestiones objLoGS_ReglasGestiones = new LoGS_ReglasGestiones();
            EnGS_ReglasGestiones objEnGS_ReglasGestiones = new EnGS_ReglasGestiones();
            List<EnGS_ReglasGestiones> ListEnGS_ReglasGestiones = new List<EnGS_ReglasGestiones>();

            objEnGS_ReglasGestiones.nempresa = (String)this.Session["cempresa"];
            ListEnGS_ReglasGestiones.Add(objEnGS_ReglasGestiones);

            cmb_tramo.Items.Clear();

            dt = objLoGS_ReglasGestiones.GS_Tramo_Combo(ListEnGS_ReglasGestiones);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["Tramo"].ToString().Trim();
                lista.Text = dt.Rows[i]["Descrip"].ToString().Trim();
                cmb_tramo.Items.Add(lista);
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
            //Process.Start(Server.MapPath("~/ReportesGerencialesModelo/MoraPorCosechas-22022017-111725.xlsx"));
            this.mxDescargarReporteCosechas();
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
            string str_anio = "&anioInicial=" + cmb_Anio.SelectedValue.ToString();
            string str_anio_final = "&anioFinal=" + cmb_Anio.SelectedValue.ToString();
            string str_mes = "&mesInicial=" + cmb_mes_Inicial.SelectedValue.ToString();
            string str_mes_final = "&mesFinal=" + cmb_mes_Final.SelectedValue.ToString();
            string str_tramo = "&tramo=" + cmb_tramo.SelectedValue.ToString();
            //string str_tramo = "&mes=" + cmb_mes_Final.SelectedValue.ToString();
            //string str_zona = "&mes=" + cmb_mes_Final.SelectedValue.ToString();
            //string str_producto = "&mes=" + cmb_mes_Final.SelectedValue.ToString();

            str_parametros = str_tiporeporte + str_nempresa + str_anio + str_anio_final + str_mes + str_mes_final + str_tramo;

            string CONFIG = "'resizable = yes, scrollbars = yes, toolbar=no, height = 500, width = 800,left=200,top=100,status=yes, location=no, menubar=no'";

            StringBuilder sb = new StringBuilder();
            sb.Append("<script>var win=window.open('../../Reportes/Reportes/ReporteGerencial_Cosechas_Tramo.aspx" + str_parametros + "', 'ReporteGerencial_RollRates_Tramo', " + CONFIG + ");</script>");
            ScriptManager.RegisterStartupScript(this, typeof(Page), "ReporteAccion", sb.ToString(), false);
        }
        catch (Exception excp)
        {
            Master.MostrarMensaje(excp.ToString(), TipoMensaje.Error);
        }
    }
    protected void btn_Imprimir_Click(object sender, EventArgs e)
    {

    }
    protected void cmb_Anio_SelectedIndexChanged(object sender, EventArgs e)
    {
        Cargar_Mes_Inicial();
    }
    protected void cmb_mes_Inicial_SelectedIndexChanged(object sender, EventArgs e)
    {
        Cargar_Mes_Final();
    }
    private void mxDescargarReporteCosechas()
    {
        string lcNomArchivo = "..\\..\\ReportesGerencialesModelo\\MoraPorCosechas-22022017-111725.xlsx";
        string lcArcDestino = "ReporteCosechas.xls";
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