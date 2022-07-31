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

public partial class Estudio_Reportes_RPT_GestionCampo : System.Web.UI.Page
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

            this.Master.TituloModulo = "Reporte Gestion Campo";
            #region accesos
            //Accesos();
            #endregion accesos

            Inicio();
        }
        //upBotonera.Update();
    }
    #endregion Eventos_Form

    #region eventos
    
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

    //private void RefrescarGrid()
    //{

    //    DataTable dt = new DataTable();

    //    LoGS_Reportes objLogica = new LoGS_Reportes();
    //    EnGS_Reportes objEntidad = new EnGS_Reportes();
    //    List<EnGS_Reportes> ListEntidad = new List<EnGS_Reportes>();



    //    objEntidad.NEMPRESA = (String)Session[Global.NEmpresa].ToString();
    //    objEntidad.CodUsuarioRegistra = (String)Session["codusuario"].ToString();
    //    objEntidad.sw = cmb_TipoSW.SelectedValue.ToString();
    //    objEntidad.fecha_ini = txt_FECHAINI.Text.ToString();
    //    objEntidad.fecha_fin = txt_FECHAFIN.Text.ToString();
    //    objEntidad.Id_Estado_Gestion_Cobranza = cmb_EstadoGestion.SelectedValue.ToString();
    //    objEntidad.CodTipoGestion = cmb_TipoGestion.SelectedValue.ToString();
    //    objEntidad.anio = cmb_Anio.SelectedValue.ToString();
    //    objEntidad.mes = cmb_Mes.SelectedValue.ToString();

    //    ListEntidad.Add(objEntidad);
    //    try
    //    {
    //        dt = objLogica.RPT_Gestion_Ejecutores(ListEntidad);
    //        gv.DataSource = dt;
    //        gv.DataBind();

    //        gv.SelectedIndex = -1;
    //        HD_Continuar.Value = "";
    //        if (dt.Rows.Count > 0)
    //        {
    //            lblCantidad.Text = dt.Rows.Count.ToString();
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}


    #endregion Datos

    #region Metodos
    private void Inicio()
    {
        try
        {
            
            Cargar_Modulos();
            //lbl_Asesor.Text = (String)Session["NombreUsuario"].ToString();
            //Controles_Periodo("AnioMes");
            //#region Fecha

            DateTime? Fecha_Hoy = null;
            DateTime? Fecha_Ini = null;

            Fecha_Hoy = DateTime.Today;
            Fecha_Ini = new DateTime(Fecha_Hoy.Value.Year, Fecha_Hoy.Value.Month, 1);

            txt_FECHAINI.Text = Convert.ToDateTime(Fecha_Ini).ToString("dd/MM/yyyy");
            txt_FECHAFIN.Text = Convert.ToDateTime(Fecha_Hoy).ToString("dd/MM/yyyy");

            //#endregion Fecha

            //Combo_EstadoGestion();
            //Combo_TipoGestion();
            //Combo_Anio();

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
            string str_fechaini = "&fechaini=" + txt_FECHAINI.Text.ToString();
            string str_fechafin = "&fechafin=" + txt_FECHAFIN.Text.ToString();
            string str_asesor = "&asesor=" + cmb_Asesores.SelectedValue.ToString();
            
            

            str_Parametros = str_tiporeporte + str_nempresa + str_codusureg  + str_fechaini + str_fechafin + str_asesor;

            string CONFIG = "'resizable = yes, scrollbars = yes, toolbar=no, height = 500, width = 800,left=200,top=100,status=yes, location=no, menubar=no'";
            StringBuilder sb = new StringBuilder();
            sb.Append("<script>var win=window.open('../../Reportes/Reportes/ReporteGestionCampo.aspx" + str_Parametros + "', 'ReporteGestionCampo', " + CONFIG + ");</script>");
            ScriptManager.RegisterStartupScript(this, typeof(Page), "ReporteAccion", sb.ToString(), false);
        }
        catch (Exception excp)
        {
            Master.MostrarMensaje(excp.ToString(), TipoMensaje.Error);
        }
    }

    protected void Cargar_Modulos()
    {
        try
        {
            CargaComboAsesores();

        }
        catch (Exception excp)
        {
            throw excp;
        }
    }
    protected void CargaComboAsesores()
    {
        DataTable dt = new DataTable();

        try
        {
            LoGS_Gestion_Cobranza objLoGS_Gestion_Cobranza = new LoGS_Gestion_Cobranza();
            EnGS_Gestion_Cobranza objEnGS_Gestion_Cobranza = new EnGS_Gestion_Cobranza();
            List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza = new List<EnGS_Gestion_Cobranza>();

            objEnGS_Gestion_Cobranza.nEmpresa = (String)this.Session["cempresa"];//8
            objEnGS_Gestion_Cobranza.CodUsuario = (String)this.Session["codusuario"];
            ListEnGS_Gestion_Cobranza.Add(objEnGS_Gestion_Cobranza);


            cmb_Asesores.Items.Clear();

            dt = objLoGS_Gestion_Cobranza.GS_Gestion_Cobranza_Asesores_x_Administrador_Lista(ListEnGS_Gestion_Cobranza);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["n_codi_usua"].ToString().Trim();
                lista.Text = dt.Rows[i]["nombres"].ToString().Trim();
                cmb_Asesores.Items.Add(lista);

            }
        }
        catch (Exception excp)
        {
            throw excp;
        }
    }
    #endregion Metodos
}