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

public partial class Estudio_Reportes_RPT_GestionEjecutores : System.Web.UI.Page
{
    #region Declaraciones
    private string TipoGestion = string.Empty;
    private string Ejecutado = string.Empty;
    private bool primerRegistro = false;
    #endregion  Declaraciones

    #region Eventos_Form
    protected void Page_Load(object sender, EventArgs e)
    {

        btn_Imprimir.Focus();
        if (!Page.IsPostBack)
        {

            this.Master.TituloModulo = "Reporte Gestion Asesores";
            #region accesos
            //Accesos();
            #endregion accesos

            Inicio();
        }
        //upBotonera.Update();
    }
    #endregion Eventos_Form

    #region eventos
    protected void cmb_TipoSW_SelectedIndexChanged(object sender, EventArgs e)
    {
        string tipo = "rango";
        if (cmb_TipoSW.SelectedValue.ToString() == "1")
        {
            tipo = "AnioMes";
        }
        else
        {
            tipo = "rango";
        }
        Controles_Periodo(tipo);
    }
    protected void gv_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.DataItem != null)
        {

            #region EsPrimero
            if (primerRegistro == false)
            {
                TipoGestion = e.Row.Cells[0].Text.Trim();
                Ejecutado = e.Row.Cells[1].Text.Trim();
            }
            #endregion EsPrimero

            #region TipoGestion
            if (e.Row.Cells[0].Text.Trim() == TipoGestion)
            {
                if (primerRegistro == false)
                {
                    e.Row.Cells[0].BackColor = Color.Silver;
                }
                else
                {
                    e.Row.Cells[0].Text = "";
                    e.Row.Cells[0].BackColor = Color.White;
                    e.Row.Cells[0].BorderColor = Color.White;
                }
            }
            else
            {
                e.Row.Cells[0].BackColor = Color.Silver;
                TipoGestion = e.Row.Cells[0].Text.Trim();
            }
            #endregion TipoGestion

            #region Ejecutado
            if (e.Row.Cells[1].Text.Trim() == Ejecutado)
            {
                if (primerRegistro == false)
                {
                    e.Row.Cells[1].BackColor = Color.Beige;
                }
                else
                {
                    e.Row.Cells[1].Text = "";
                    e.Row.Cells[1].BackColor = Color.White;
                    e.Row.Cells[1].BorderColor = Color.White;
                }
            }
            else
            {
                e.Row.Cells[1].BackColor = Color.Beige;
                Ejecutado = e.Row.Cells[1].Text.Trim();
            }
            #endregion Ejecutado

            #region EsPrimero
            if (primerRegistro == false)
            {
                primerRegistro = true;
            }
            #endregion EsPrimero

        }

    }
    #endregion eventos

    #region ToolBar
    protected void btn_Excel_Click(object sender, EventArgs e)
    {
        try
        {
            Master.OcultarMensaje();

            #region Sesion
            string cempresa = (String)this.Session["cempresa"]; ;
            if (cempresa == "" || cempresa == null)
            {
                this.Session.Abandon();
                Response.Redirect("../Login.aspx?rd=0");
                return;
            }
            #endregion Sesion

            Exportar(Extencion.Excel);


        }
        catch (Exception ex)
        {

            Master.MostrarMensaje(ex.Message.ToString(), TipoMensaje.Error);
        }

    }
    protected void btn_Imprimir_Click(object sender, EventArgs e)
    {

        try
        {
            Master.OcultarMensaje();
            #region Sesion
            string cempresa = (String)this.Session["cempresa"]; ;
            if (cempresa == "" || cempresa == null)
            {
                this.Session.Abandon();
                Response.Redirect("../Login.aspx?rd=0");
                return;
            }
            #endregion Sesion

            Exportar(Extencion.Pdf);

        }
        catch (Exception ex)
        {
            Master.MostrarMensaje(ex.Message.ToString(), TipoMensaje.Error);
        }

    }
    #endregion ToolBar

    #region Limpiar_Filtro

    #endregion Limpiar_Filtro

    #region Datos


    protected void Combo_EstadoGestion()
    {
        DataTable dt = new DataTable();
        LoGS_Gestion_Cobranza objLoGS_Gestion_Cobranza = new LoGS_Gestion_Cobranza();
        try
        {
            EnGS_Gestion_Cobranza objEnGS_Gestion_Cobranza = new EnGS_Gestion_Cobranza();
            cmb_EstadoGestion.Items.Clear();


            dt = objLoGS_Gestion_Cobranza.GS_Estado_Gestion_Cobranza_Combo();

            #region Todos
            ListItem listaTodos = new ListItem();
            listaTodos.Value = "-1";
            listaTodos.Text = "-- Todos --";
            cmb_EstadoGestion.Items.Add(listaTodos);
            #endregion Todos
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                if (dt.Rows[i]["desc_estado_gestion_cobranza"].ToString().Trim() != "-- seleccione --")
                {
                    ListItem lista = new ListItem();
                    lista.Value = dt.Rows[i]["id_estado_gestion_cobranza"].ToString().Trim();
                    lista.Text = dt.Rows[i]["desc_estado_gestion_cobranza"].ToString().Trim();
                    cmb_EstadoGestion.Items.Add(lista);
                }

            }
        }
        catch (Exception excp)
        {
            throw excp;
        }
    }
    protected void Combo_TipoGestion()
    {
        DataTable dt = new DataTable();

        try
        {

            #region Carga_Variables
            LoGS_TipoGestiones objLoGS_TipoGestiones = new LoGS_TipoGestiones();
            EnGS_TipoGestiones objEnGS_TipoGestiones = new EnGS_TipoGestiones();
            List<EnGS_TipoGestiones> ListEnGS_TipoGestiones = new List<EnGS_TipoGestiones>();

            objEnGS_TipoGestiones.nempresa = (String)this.Session["cempresa"];
            objEnGS_TipoGestiones.Descripcion = "";
            ListEnGS_TipoGestiones.Add(objEnGS_TipoGestiones);
            #endregion Carga_Variables

            cmb_TipoGestion.Items.Clear();

            dt = objLoGS_TipoGestiones.GS_TipoGestiones_Lista(ListEnGS_TipoGestiones);

            #region Todos
            ListItem listaTodos = new ListItem();
            listaTodos.Value = "-1";
            listaTodos.Text = "-- Todos --";
            cmb_TipoGestion.Items.Add(listaTodos);
            #endregion Todos
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["CodTipoGestion"].ToString().Trim();
                lista.Text = dt.Rows[i]["Descripcion"].ToString().Trim();
                cmb_TipoGestion.Items.Add(lista);
            }
        }
        catch (Exception excp)
        {
            throw excp;
        }
    }

    protected void Combo_Anio()
    {
        try
        {
            cmb_Anio.Items.Clear();

            int AnioInicio = 2014;
            int AnioActual = DateTime.Now.Year;

            for (int i = AnioActual; i >= AnioInicio; i--)
            {
                ListItem lista = new ListItem();
                lista.Value = i.ToString();
                lista.Text = i.ToString();
                cmb_Anio.Items.Add(lista);
            }
        }
        catch (Exception excp)
        {
            throw excp;
        }
    }
    protected void Combo_Mes()
    {
        DataTable dt = new DataTable();
        try
        {

            #region Carga_Variables
            LoGS_TipoGestiones objLoGS_TipoGestiones = new LoGS_TipoGestiones();
            EnGS_TipoGestiones objEnGS_TipoGestiones = new EnGS_TipoGestiones();
            List<EnGS_TipoGestiones> ListEnGS_TipoGestiones = new List<EnGS_TipoGestiones>();

            objEnGS_TipoGestiones.nempresa = (String)this.Session["cempresa"];
            objEnGS_TipoGestiones.Descripcion = "";
            ListEnGS_TipoGestiones.Add(objEnGS_TipoGestiones);
            #endregion Carga_Variables

            cmb_TipoGestion.Items.Clear();

            dt = objLoGS_TipoGestiones.GS_TipoGestiones_Lista(ListEnGS_TipoGestiones);

            #region Todos
            ListItem listaTodos = new ListItem();
            listaTodos.Value = "-1";
            listaTodos.Text = "-- Todos --";
            cmb_TipoGestion.Items.Add(listaTodos);
            #endregion Todos
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["CodTipoGestion"].ToString().Trim();
                lista.Text = dt.Rows[i]["Descripcion"].ToString().Trim();
                cmb_TipoGestion.Items.Add(lista);
            }
        }
        catch (Exception excp)
        {
            throw excp;
        }
    }


    private void RefrescarGrid()
    {

        DataTable dt = new DataTable();

        LoGS_Reportes objLogica = new LoGS_Reportes();
        EnGS_Reportes objEntidad = new EnGS_Reportes();
        List<EnGS_Reportes> ListEntidad = new List<EnGS_Reportes>();



        objEntidad.NEMPRESA = (String)Session[Global.NEmpresa].ToString();
        objEntidad.CodUsuarioRegistra = (String)Session["codusuario"].ToString();
        objEntidad.sw = cmb_TipoSW.SelectedValue.ToString();
        objEntidad.fecha_ini = txt_FECHAINI.Text.ToString();
        objEntidad.fecha_fin = txt_FECHAFIN.Text.ToString();
        objEntidad.Id_Estado_Gestion_Cobranza = cmb_EstadoGestion.SelectedValue.ToString();
        objEntidad.CodTipoGestion = cmb_TipoGestion.SelectedValue.ToString();
        objEntidad.anio = cmb_Anio.SelectedValue.ToString();
        objEntidad.mes = cmb_Mes.SelectedValue.ToString();

        ListEntidad.Add(objEntidad);
        try
        {
            dt = objLogica.RPT_Gestion_Ejecutores(ListEntidad);
            gv.DataSource = dt;
            gv.DataBind();

            gv.SelectedIndex = -1;
            HD_Continuar.Value = "";
            if (dt.Rows.Count > 0)
            {
                lblCantidad.Text = dt.Rows.Count.ToString();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    #endregion Datos

    #region Metodos
    private void Inicio()
    {
        try
        {
            lbl_Asesor.Text = (String)Session["NombreUsuario"].ToString();
            Controles_Periodo("AnioMes");

            #region Fecha

            DateTime? Fecha_Hoy = null;
            DateTime? Fecha_Ini = null;

            Fecha_Hoy = DateTime.Today;
            Fecha_Ini = new DateTime(Fecha_Hoy.Value.Year, Fecha_Hoy.Value.Month, 1);

            txt_FECHAINI.Text = Convert.ToDateTime(Fecha_Ini).ToString("dd/MM/yyyy");
            txt_FECHAFIN.Text = Convert.ToDateTime(Fecha_Hoy).ToString("dd/MM/yyyy");

            #endregion Fecha

            Combo_EstadoGestion();
            Combo_TipoGestion();
            Combo_Anio();

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
            string str_Parametros = "";
            string str_tiporeporte = "?tiporerporte=" + Formato;
            string str_nempresa = "&nempresa=" + (String)Session[Global.NEmpresa].ToString();
            string str_codusureg = "&codusureg=" + (String)Session["codusuario"].ToString();
            string str_sw = "&sw=" + cmb_TipoSW.SelectedValue.ToString();
            string str_fechaini = "&fechaini=" + txt_FECHAINI.Text.ToString();
            string str_fechafin = "&fechafin=" + txt_FECHAFIN.Text.ToString();
            string str_idstgescob = "&idstgescob=" + cmb_EstadoGestion.SelectedValue.ToString();
            string str_codtges = "&codtges=" + cmb_TipoGestion.SelectedValue.ToString();
            string str_anio = "&anio=" + cmb_Anio.SelectedValue.ToString();
            string str_mes = "&mes=" + cmb_Mes.SelectedValue.ToString();
            string str_asesor = "&asesor=" + lbl_Asesor.Text.Trim();

            str_Parametros = str_tiporeporte + str_nempresa + str_codusureg + str_sw + str_fechaini + str_fechafin + str_idstgescob + str_codtges + str_anio + str_mes + str_asesor;

            string CONFIG = "'resizable = yes, scrollbars = yes, toolbar=no, height = 500, width = 800,left=200,top=100,status=yes, location=no, menubar=no'";
            StringBuilder sb = new StringBuilder();
            sb.Append("<script>var win=window.open('../../Reportes/Reportes/ReporteGestionEjecutoresC.aspx" + str_Parametros + "', 'ReporteC', " + CONFIG + ");</script>");
            ScriptManager.RegisterStartupScript(this, typeof(Page), "ReporteAccion", sb.ToString(), false);
        }
        catch (Exception excp)
        {
            Master.MostrarMensaje(excp.ToString(), TipoMensaje.Error);
        }
    }

    private void Controles_Periodo(string periodo)
    {
        if (periodo == "rango")
        {
            lbl_Inicio.Visible = true;
            lbl_Final.Visible = true;

            txt_FECHAINI.Visible = true;
            txt_FECHAFIN.Visible = true;

            imgCal1.Visible = true;
            imgCal2.Visible = true;

            lbl_Anio.Visible = false;
            lbl_Mes.Visible = false;

            cmb_Anio.Visible = false;
            cmb_Mes.Visible = false;
        }
        else
        {

            lbl_Inicio.Visible = false;
            lbl_Final.Visible = false;

            txt_FECHAINI.Visible = false;
            txt_FECHAFIN.Visible = false;

            imgCal1.Visible = false;
            imgCal2.Visible = false;

            lbl_Anio.Visible = true;
            lbl_Mes.Visible = true;

            cmb_Anio.Visible = true;
            cmb_Mes.Visible = true;
        }
    }
    #endregion Metodos



    protected void cmb_Anio_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}