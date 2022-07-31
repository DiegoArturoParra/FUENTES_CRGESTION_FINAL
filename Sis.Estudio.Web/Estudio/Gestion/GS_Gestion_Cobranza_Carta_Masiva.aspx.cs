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
using Sis.Estudio.Logic.MSSQL.Seguridad;
using Sis.Estudio.Logic.MSSQL.Gestion;
using System.Data.OleDb;
using System.Text.RegularExpressions;
using Excel = Microsoft.Office.Interop.Excel;
using System.Linq;


public partial class Estudio_Gestion_GS_Gestion_Cobranza_Carta_Masiva : System.Web.UI.Page
{

   
    #region Declaraciones
    private const string PaginaEnviarCorreo = "GS_EnvioCorreoMasivo.aspx";
    public string PaginaDetalle = "GS_Gestion_Cobranza_Carta_MasivaDetalle.aspx";
    private const string PaginaRetorno = "";
    private string PaginaVisualizar = "GS_DocumentoListado.aspx";
    #endregion  Declaraciones

    #region Form
    #region Seleccionar
    protected override void Render(System.Web.UI.HtmlTextWriter writer)
    {
        AddRowSelectToGridView(gv);
        base.Render(writer);

    }
    private void AddRowSelectToGridView(GridView gv)
    {
        #region select
        if (gv.EditIndex == -1)
        {
            foreach (GridViewRow row in gv.Rows)
            {

                #region Old
                //row.Attributes["OnMouseOut"] = "this.className = this.orignalclassName;";
                //row.Attributes["OnMouseOver"] = "this.orignalclassName = this.className;this.className = 'selectedrow4';";
                //row.Attributes["onMouseDown"] = "this.className = 'selectedrow';";
                #endregion Old
                row.Attributes["OnMouseOut"] = "this.className = this.orignalclassName;";
                row.Attributes["OnMouseOver"] = "javascript:if (this.className == 'selectedrow') {this.orignalclassName = this.className; this.className = 'selectedrow';}else {this.orignalclassName = this.className; this.className = 'selectedrow4';}";
                row.Attributes["onMouseDown"] = "this.className = 'selectedrow';";
                row.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(gv, "Select$" + row.RowIndex.ToString(), true));
                row.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(gv, "Select$" + row.RowIndex.ToString(), true));
            }
     // }
        Metodo_Pintar();
        Metodo_Link();
        //Metodo_Link2();
        }
        #endregion select


    }
    #endregion Seleccionar
    protected void Page_Load(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        //btnBuscar.Focus();
        //Page.Form.Attributes.Add("enctype", "multipart/form-data");
        ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
        scriptManager.RegisterPostBackControl(this.btnExportarAP);
        if (!IsPostBack)
        {
            //G_idopcion = OpcionModulo.MantModulo;
            //this.Master.TituloModulo = "Gestion de Cobranzas Carta Masiva";
            this.Master.TituloModulo = "Gestión Cobranzas - Procesos Masivos";
            CargaComboTipoGestion();
          
            //btnProcesar.Attributes.Add("onClick", "document.getElementById('hdnContinuar').value = confirm('¿Se Autorizará El efectivo, ¿Desea continuar?');");
            InicioOperacion();
            cmb_CodTipoGestion.SelectedValue = Session["cTipoGestion"] != null ? Session["cTipoGestion"].ToString() : "-1";
            if (cmb_CodTipoGestion.SelectedValue != "-1")
            {
                //iframe.Attributes["src"] = "GS_DocumentoListado.aspx?idCarta=1&codTipoDocumento=" + Session["cTipoGestion"].ToString();*/

                sb.Append("<script>document.getElementById('iframe').src = 'GS_DocumentoListado.aspx?idCarta=1&codTipoDocumento="+Session["cTipoGestion"]+"'</script>");
                ScriptManager.RegisterStartupScript(this, typeof(Page), "ReporteAccion", sb.ToString(), false);
                CargaCombo_Cartas();
            }
            RefrescarGrid();
        }
    }
    #endregion Form

    #region ToolBar
    

    /*
    protected void btnExcel_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            limpiarMensaje();
            #region Sesion
            string cempresa = (String)this.Session["cempresa"]; ;
            if (cempresa == "" || cempresa == null)
            {
                this.Session.Abandon();
                Response.Redirect("../../Login.aspx?rd=0");
                return;
            }
            #endregion Sesion

            if (gv.SelectedIndex != -1)
            {
                Exportar(Extencion.Excel);
            }
            else
            {
                Master.MostrarMensaje(Mensaje.M_SELECCIONAR_REGISTRO, TipoMensaje.Advertencia);
                return;
            }
             

        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message.ToString(), true);
        }
    }
    protected void btnImprimir_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            limpiarMensaje();
            #region Sesion
            string cempresa = (String)this.Session["cempresa"]; ;
            if (cempresa == "" || cempresa == null)
            {
                this.Session.Abandon();
                Response.Redirect("../../Login.aspx?rd=0");
                return;
            }
            #endregion Sesion

                    Exportar(Extencion.Pdf);
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message.ToString(), true);
        }

    }
    */
    #endregion ToolBar

    #region Eventos
    protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv.PageIndex = e.NewPageIndex;
        RefrescarGrid();
    }
    protected void gv_PageIndexChanged(object sender, EventArgs e)
    {
        if (gv.Rows.Count > 0)
        {
            gv.SelectedIndex = -1;
        }
    }
    protected void cmb_CodTipoGestion_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["cTipoGestion"] = cmb_CodTipoGestion.SelectedValue.ToString();
        CargaCombo_Cartas();
        Master.OcultarMensaje();
        limpiarMensaje();

        gv.PageIndex = 0;

        //Regex expRegDni = new Regex(@"^\d{8}$");
        //Regex expRegDiasMora = new Regex("^[0-9]+$");
        //bool formatoCorrecto = true;
        //if (txt_documento.Text.Length > 0)
        //{
        //    if (expRegDni.IsMatch(txt_documento.Text))
        //    {
        //        formatoCorrecto = true;
        //    }
        //    else
        //    {
        //        formatoCorrecto = false;
        //        Master.MostrarMensaje("Formato de DNI Incorrecto", TipoMensaje.Error);
        //    }
        //}
        //if (txt_dias_mora.Text.Length > 0)
        //{
        //    if (expRegDiasMora.IsMatch(txt_dias_mora.Text))
        //    {
        //        formatoCorrecto = true;
        //    }
        //    else
        //    {
        //        formatoCorrecto = false;
        //        Master.MostrarMensaje("Días de Mora es numérico", TipoMensaje.Error);
        //    }
        //}
        //if (formatoCorrecto == true)
        //{
            RefrescarGrid();
        //}
    }
    protected void cmb_Carta_SelectedIndexChanged(object sender, EventArgs e)
    {

        Session["lcSelTipCarta"] = cmb_Carta.SelectedValue.ToString();
        string str_id = "?idCarta=" + cmb_Carta.SelectedValue.ToString().Trim();
        string str_codTipoDocumento = "&codTipoDocumento=" + cmb_CodTipoGestion.SelectedValue.ToString().Trim();
        //Response.Redirect(PaginaVisualizar + str_id + str_codTipoDocumento);
        //lnkPopUp.HRef = PaginaVisualizar + str_id + str_codTipoDocumento;
        if (cmb_CodTipoGestion.SelectedValue.ToString() == M_Carta.Tipo && cmb_Carta.SelectedValue.ToString() != "-1")
            btnExportPDF.Visible = true;
        else
            btnExportPDF.Visible = false;

    }
    protected void gv_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    #endregion Eventos

    #region Datos
    private void Metodo_Pintar()
    {
        try
        {
            #region Validacion
            if (gv.Rows.Count < 1)
            {
                return;
            }
            #endregion Validacion

            int Estado = 15;

            foreach (GridViewRow fila in gv.Rows)
            {
                if (fila.RowType == DataControlRowType.DataRow)
                {
                    HyperLink hlnk = new HyperLink();
                    hlnk.NavigateUrl = "";

                    if (fila.Cells[Estado].Text.ToString() == "1")
                    {
                        hlnk.ImageUrl = "~/Imagenes/sem_amarillo.png";
                    }
                    if (fila.Cells[Estado].Text.ToString() == "2")
                    {
                        hlnk.ImageUrl = "~/Imagenes/sem_verde.png";
                    }
                    if (fila.Cells[Estado].Text.ToString() == "3")
                    {
                        hlnk.ImageUrl = "~/Imagenes/sem_rojo.png";
                    }
                    if (fila.Cells[Estado].Text.ToString() == "4")
                    {
                        hlnk.ImageUrl = "~/Imagenes/sem_negro.png";
                    }
                    if (fila.Cells[Estado].Text.ToString() == "5")
                    {
                        hlnk.ImageUrl = "~/Imagenes/sem_naranja.png";
                    }

                    if (fila.Cells[Estado].Text.ToString() == "6")
                    {
                        hlnk.ImageUrl = "~/Imagenes/sem_azul.png";
                    }

                    fila.Cells[16].Controls.Add(hlnk);
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void Metodo_Link()
    {
        try
        {
            #region Validacion
            if (gv.Rows.Count < 1)
            {
                return;
            }
            #endregion Validacion

            foreach (GridViewRow fila in gv.Rows)
            {
                if (fila.RowType == DataControlRowType.DataRow)
                {
                    HyperLink hlnk2 = new HyperLink();

                    string str_id_cliente = fila.Cells[19].Text.ToString();

                    hlnk2.NavigateUrl = "00Load.aspx?id_cliente=" + str_id_cliente;

                    hlnk2.ImageUrl = "~/Imagenes/ficha.png";

                    fila.Cells[18].Controls.Add(hlnk2);
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void Metodo_Link2()
    {
        try
        {
            #region Validacion
            if (gv.Rows.Count < 1)
            {
                return;
            }
            #endregion Validacion

            foreach (GridViewRow fila in gv.Rows)
            {
                if (fila.RowType == DataControlRowType.DataRow)
                {
                    HyperLink hlnk2 = new HyperLink();

                    //string str_id_cliente = fila.Cells[19].Text.ToString();


                    if (gv.SelectedIndex != -1)
                    {
                        if (gv.SelectedIndex <= gv.Rows.Count)
                        {
                            if (gv.SelectedRow.Cells[15].Text.ToString() == "4" || gv.SelectedRow.Cells[17].Text.ToString() != "0" || gv.SelectedRow.Cells[15].Text.ToString() == "6")
                            {
                                Master.MostrarMensaje("El Action Plan se encuentra  desactivo, pendiente de aprobacion ó ya se finalizó", TipoMensaje.Advertencia);
                            }
                            else
                            {
                                string str_estado = "?estado=m";

                                string str_id = "&id=" + gv.SelectedRow.Cells[1].Text.ToString();
                                string str_nombre = "&nombre=" + gv.SelectedRow.Cells[2].Text.ToString();
                                string algo = gv.SelectedRow.Cells[15].Text.ToString();
                                //Response.Redirect(PaginaDetalle + str_estado + str_id + str_nombre);

                                hlnk2.NavigateUrl = PaginaDetalle + str_estado + str_id + str_nombre;
                            }
                        }
                    }
                    else
                    {
                        //MostrarMensaje(Mensajes.MSG_MENSAJESELECCIONARREGISTRO, true);
                    }

                }
            }



        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void EnableControl(bool dato)
    {
        //********************************************************************************
        //**  EnableControl  : Cambia el estado de los controles.
        //**                   Bloquea desbloquea controles :
        //********************************************************************************
        //==== controles de ingreso ====//        
        //txT.Enabled = dato;
        
        //cmb_CodTipoGestion.Enabled = dato;
        cmb_Carta.Enabled = dato;
        gv.Enabled = dato;  
    }
    #endregion Datos
    /*Obs: cambio num_carta, ahora se busca por id_carta 041016*/

    #region Metodos
    protected void InicioOperacion()
    {
        //****************************************************************************************
        //* Nomre       : InicioOperacion
        //* DescripcioN :
        //****************************************************************************************
        try
        {
            #region Fecha
            DateTime? Fecha_Hoy = null;
            DateTime? Fecha_Ini = null;
            DateTime? Fecha_Fin = null;

            Fecha_Hoy = DateTime.Today;
            Fecha_Ini = new DateTime(Fecha_Hoy.Value.Year, Fecha_Hoy.Value.Month, 1);
            Fecha_Fin = new DateTime(Fecha_Hoy.Value.Year, Fecha_Hoy.Value.Month, 1).AddDays(-1);

            //txt_FECHAINI.Text = Convert.ToDateTime(Fecha_Ini).ToString("dd/MM/yyyy");
            //txt_FECHAFIN.Text = Convert.ToDateTime(Fecha_Hoy).ToString("dd/MM/yyyy");
            #endregion Fecha
            CargaComboEstado();
            //CargaCombo_Cartas();
            //RefrescarGrid();
        }
        catch (Exception excp)
        {
            Master.MostrarMensaje(excp.Message.ToString(), TipoMensaje.Error);
        }
    }

    #region CargaCombos
    protected void CargaComboTipoGestion()
    {
        DataTable dt = new DataTable();
        LoGS_ClaseGestiones objLoGS_ClaseGestiones = new LoGS_ClaseGestiones();
        try
        {
            EnGS_ClaseGestiones objEnGS_ClaseGestiones = new EnGS_ClaseGestiones();
            cmb_CodTipoGestion.Items.Clear();

            dt = objLoGS_ClaseGestiones.GS_TipoGestionesMasivos_Combo();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["CodTipoGestion"].ToString().Trim();
                lista.Text = dt.Rows[i]["Descripcion"].ToString().Trim();
                cmb_CodTipoGestion.Items.Add(lista);
                cmb_TipoGestion.Items.Add(lista);
            }
        }
        catch (Exception excp)
        {
            throw excp;
        }
    }
    protected void CargaComboEstado()
    {
        //DataTable dt = new DataTable();
        //LoGS_Gestion_Cobranza objLoGS_Gestion_Cobranza = new LoGS_Gestion_Cobranza();
        //try
        //{
        //    EnGS_Gestion_Cobranza objEnGS_Gestion_Cobranza = new EnGS_Gestion_Cobranza();
        //    cmb_Estado.Items.Clear();


        //    dt = objLoGS_Gestion_Cobranza.GS_Estado_Gestion_Cobranza_Combo();

        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        ListItem lista = new ListItem();
        //        lista.Value = dt.Rows[i]["id_estado_gestion_cobranza"].ToString().Trim();
        //        lista.Text = dt.Rows[i]["desc_estado_gestion_cobranza"].ToString().Trim();
        //        cmb_Estado.Items.Add(lista);
        //    }
        //}
        //catch (Exception excp)
        //{
        //    throw excp;
        //}
    }
    protected void CargaCombo_Cartas()
    {
        DataTable dt = new DataTable();
        LoGS_Gestion_Cobranza objLoGS_Gestion_Cobranza = new LoGS_Gestion_Cobranza();
        try
        {
            EnGS_Gestion_Cobranza objEnGS_Gestion_Cobranza = new EnGS_Gestion_Cobranza();
            List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza = new List<EnGS_Gestion_Cobranza>();
            cmb_Carta.Items.Clear();

            objEnGS_Gestion_Cobranza.CodTipoGestion = cmb_CodTipoGestion.SelectedValue.ToString();

            ListEnGS_Gestion_Cobranza.Add(objEnGS_Gestion_Cobranza);


            dt = objLoGS_Gestion_Cobranza.GS_Gestion_Cobranza_ComboCartas(ListEnGS_Gestion_Cobranza);


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["id_carta"].ToString().Trim();
                lista.Text = dt.Rows[i]["Nombre"].ToString().Trim();
                cmb_Carta.Items.Add(lista);
            }
        }
        catch (Exception excp)
        {
            throw excp;
        }
    }
    protected void CargaComboTipoGestionGrupo()
    {
        DataTable dt = new DataTable();
        LoGS_TipoGestiones objLoGS_TipoGestiones = new LoGS_TipoGestiones();
        try
        {
            EnGS_TipoGestiones objEnGS_TipoGestiones = new EnGS_TipoGestiones();
            List<EnGS_TipoGestiones> ListEnGS_TipoGestiones = new List<EnGS_TipoGestiones>();
            cmb_TipoGestion.Items.Clear();

            objEnGS_TipoGestiones.grupo = "1";

            ListEnGS_TipoGestiones.Add(objEnGS_TipoGestiones);

            dt = objLoGS_TipoGestiones.GS_TipoGestionesGrupo_Combo(ListEnGS_TipoGestiones);

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
    #endregion CargaCombos
    
    private void RefrescarGrid()
    {
        this.Master.OcultarMensaje();

        DataTable DT_Datos = new DataTable();

        LoGS_Gestion_Cobranza objLoGS_Gestion_Cobranza = new LoGS_Gestion_Cobranza();
        EnGS_Gestion_Cobranza objEnGS_Gestion_Cobranza = new EnGS_Gestion_Cobranza();
        List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza = new List<EnGS_Gestion_Cobranza>();

        string lcFiltro = string.Empty;

        //objEnGS_Gestion_Cobranza.Accion = "0";
        objEnGS_Gestion_Cobranza.nEmpresa = (String)this.Session["cempresa"];
        //objEnGS_Gestion_Cobranza.dias_mora = txt_dias_mora.Text.Trim();
        //objEnGS_Gestion_Cobranza.dias_mora_hasta = txt_dias_mora_hasta.Text.Trim();

        //objEnGS_Gestion_Cobranza.fecha_ini = txt_FECHAINI.Text.ToString();
        //objEnGS_Gestion_Cobranza.fecha_fin = txt_FECHAFIN.Text.ToString();
        objEnGS_Gestion_Cobranza.CodTipoGestion = cmb_CodTipoGestion.SelectedValue.ToString().Trim();
        //objEnGS_Gestion_Cobranza.id_carta = cmb_Carta.SelectedValue.ToString().Trim();

        if (Session["cTipoGestion"] != null)
        {
            if (cmb_CodTipoGestion.SelectedValue.ToString().Trim() != "-1")
                lcFiltro += " nIdTipoGestion = " + cmb_CodTipoGestion.SelectedValue.ToString().Trim();
            else
                lcFiltro += string.Empty;
                //lcFiltro += Session["SessionFiltro"] != null ? Session["SessionFiltro"] : Session["SessionFiltro"];
        }
        objEnGS_Gestion_Cobranza.CodUsuario = (String)this.Session["codusuario"];
        lcFiltro = Session["SessionFiltro"] != null ? (((lcFiltro != string.Empty) ? lcFiltro +" AND " : lcFiltro) + Session["SessionFiltro"].ToString()) : lcFiltro;
        if (!lcFiltro.Contains("nFlagMasivo"))
        {
            lcFiltro += ((lcFiltro != string.Empty)? " AND ":"") + " nFlagMasivo = 1";
        }
        //objEnGS_Gestion_Cobranza.Nombres = txt_nombres.Text.ToString();
        //objEnGS_Gestion_Cobranza.documento = txt_documento.Text.ToString();

        //objEnGS_Gestion_Cobranza.Id_estado_gestion_cobranza = cmb_Estado.SelectedValue.ToString().Trim();

        ListEnGS_Gestion_Cobranza.Add(objEnGS_Gestion_Cobranza);

        try
        {
            DT_Datos = objLoGS_Gestion_Cobranza.GS_Gestion_Cobranza_Lista_Pendientes(ListEnGS_Gestion_Cobranza, lcFiltro);
            gv.DataSource = DT_Datos;
            gv.DataBind();

            #region Contador
            if (DT_Datos.Rows.Count > 0)
            {
                lblCantidad.Text = "Total: " + DT_Datos.Rows.Count.ToString() + " Registros";
                lblPaginaGrilla.Text = "[Registros: " + Convert.ToString((gv.PageIndex * gv.PageSize) + 1) + "-" + Convert.ToString(gv.PageIndex * gv.PageSize + gv.PageSize) + "]";
            }
            else
            {
                lblCantidad.Text = "Total: 0 Registros";
                lblPaginaGrilla.Text = "[Registros: 0-0 ]";
            }
            #endregion Contador
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void limpiarMensaje()
    {
        //**********************************************************************************************
        //*	 limpiarMensaje : limpia mensaje de avisos.
        //**********************************************************************************************
        lblMensaje.Text = "";
        lblMensaje.ForeColor = Color.Red;
        btnExportPDF.Visible = false;
    }

    private void ValidarUsuario()
    {
        this.Master.OcultarMensaje();

        DataTable DT_Datos = new DataTable();

        LoGS_Gestion_Cobranza objLoGS_Gestion_Cobranza = new LoGS_Gestion_Cobranza();
        EnGS_Gestion_Cobranza objEnGS_Gestion_Cobranza = new EnGS_Gestion_Cobranza();
        List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza = new List<EnGS_Gestion_Cobranza>();

        //objEnGS_Gestion_Cobranza.Accion = "0";
        objEnGS_Gestion_Cobranza.nEmpresa = (String)this.Session["cempresa"];
        //objEnGS_Gestion_Cobranza.dias_mora = txt_dias_mora.Text.Trim();

        //objEnGS_Gestion_Cobranza.fecha_ini = txt_FECHAINI.Text.ToString();
        //objEnGS_Gestion_Cobranza.fecha_fin = txt_FECHAFIN.Text.ToString();
        //objEnGS_Gestion_Cobranza.CodTipoGestion = cmb_CodTipoGestion.SelectedValue.ToString().Trim();
        objEnGS_Gestion_Cobranza.id_carta = cmb_Carta.SelectedValue.ToString().Trim();

        objEnGS_Gestion_Cobranza.CodUsuario = (String)this.Session["codusuario"];

        //objEnGS_Gestion_Cobranza.Nombres = txt_nombres.Text.ToString();
        //objEnGS_Gestion_Cobranza.documento = txt_documento.Text.ToString();
        //objEnGS_Gestion_Cobranza.Id_estado_gestion_cobranza = cmb_Estado.SelectedValue.ToString().Trim();
        ListEnGS_Gestion_Cobranza.Add(objEnGS_Gestion_Cobranza);

        try
        {
            DT_Datos = objLoGS_Gestion_Cobranza.GS_Gestion_Cobranza_Lista_Pendientes(ListEnGS_Gestion_Cobranza, "masivo");
            gv.DataSource = DT_Datos;
            gv.DataBind();
            #region Contador
            if (DT_Datos.Rows.Count > 0)
            {
                lblCantidad.Text = "Total: " + DT_Datos.Rows.Count.ToString() + " Registros";
                lblPaginaGrilla.Text = "[Registros: " + Convert.ToString((gv.PageIndex * gv.PageSize) + 1) + "-" + Convert.ToString(gv.PageIndex * gv.PageSize + gv.PageSize) + "]";
            }
            else
            {
                lblCantidad.Text = "Total: 0 Registros";
                lblPaginaGrilla.Text = "[Registros: 0-0 ]";
            }
            #endregion Contador
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void mxEnviar_Documentos(string pcCodTipo, string pcNombre, string pcMensaje, string pcTipArc, string pcCarta, string pcPlantilla)
    {
        this.Master.OcultarMensaje();
        string lcCodCobranza = string.Empty;
        try
        {
            #region Validacion
            if (Valida_SeleccionGV(pcCodTipo, pcNombre) == false)
            {
                return;
            }
            #endregion Validacion

            #region carga_variables
            foreach (GridViewRow row in gv.Rows)
            {
                if (((CheckBox)row.FindControl("chkPermiso")).Checked == true)
                {
                    lcCodCobranza = lcCodCobranza + row.Cells[1].Text + ",";
                }
            }

            if (lcCodCobranza.Length > 0)
            {
                lcCodCobranza = lcCodCobranza.TrimEnd(',');
            }
            #endregion carga_variables

            #region envia_carta
            string str_carta = cmb_Carta.SelectedValue.ToString();
            if (str_carta == "0")
            {
                Master.MostrarMensaje(pcMensaje , TipoMensaje.Advertencia);
                return;
            }
            this.mxRedireccionarAPlantillaExcel(pcTipArc, lcCodCobranza, pcCarta, pcPlantilla);

            #endregion envia_carta

            limpiarMensaje();
            RefrescarGrid();

        }
        catch (Exception ex)
        {
            Master.MostrarMensaje(ex.Message.ToString(), TipoMensaje.Error);
        }

    }
    
    
    protected void EnvioCartas()
    {
        this.Master.OcultarMensaje();
        try
        {
            #region Validacion
            if (Valida_SeleccionGV(M_Carta.Tipo, M_Carta.Nombre) == false)
            {
                return;
            }
            #endregion Validacion

            #region carga_variables
            string IdReg_Gestion_Cobranza = "";
            foreach (GridViewRow row in gv.Rows)
            {
                if (((CheckBox)row.FindControl("chkPermiso")).Checked == true)
                {
                    IdReg_Gestion_Cobranza = IdReg_Gestion_Cobranza + row.Cells[1].Text + ",";
                }
            }

            if (IdReg_Gestion_Cobranza.Length > 0)
            {
                IdReg_Gestion_Cobranza = IdReg_Gestion_Cobranza.TrimEnd(',');
            }

            #endregion carga_variables

            #region envia_carta
            string str_carta = cmb_Carta.SelectedValue.ToString();
            if (str_carta == "0")
            {
                Master.MostrarMensaje("Seleccione el tipo de mensaje que desea enviar", TipoMensaje.Advertencia);
                return;
            }
            ExportarCarta(Extencion.Pdf, IdReg_Gestion_Cobranza, str_carta);
            #endregion envia_carta

            limpiarMensaje();
            RefrescarGrid();

        }
        catch (Exception ex)
        {
            Master.MostrarMensaje(ex.Message.ToString(), TipoMensaje.Error);
        }
    }
    protected void EnvioSMS()
    {
        Master.OcultarMensaje();
        int idValidarCanalContacto = 0;
        try
        {
            int cantCanalContacto = 0;
            bool error = false;
            LoGS_Carta objLoGS_Carta = new LoGS_Carta();
            #region Validacion
            if (Valida_SeleccionGV(M_SMS.Tipo, M_SMS.Nombre) == false)
            {
                return;
            }
            #endregion Validacion

            #region carga_variables
            string IdReg_Gestion_Cobranza = "";
            string validaEstado = "";
            int Estado = 15;
            foreach (GridViewRow row in gv.Rows)
            {
                if (((CheckBox)row.FindControl("chkPermiso")).Checked == true)
                {
                    IdReg_Gestion_Cobranza = IdReg_Gestion_Cobranza + row.Cells[1].Text + ",";
                    if (row.Cells[Estado].Text.ToString() == "1")
                    {
                        idValidarCanalContacto = int.Parse(row.Cells[1].Text);
                        cantCanalContacto = objLoGS_Carta.GS_ValidarCanalContacto(idValidarCanalContacto);
                        if (cantCanalContacto == 0)
                        {
                            error = true;
                        }
                    }
                    else
                    {
                        validaEstado = "error";
                    }
                }
            }

            if (IdReg_Gestion_Cobranza.Length > 0)
            {
                IdReg_Gestion_Cobranza = IdReg_Gestion_Cobranza.TrimEnd(',');
            }

            #endregion carga_variables

            #region envia_carta
            string str_id_carta = cmb_Carta.SelectedValue.ToString();
            if (str_id_carta == "0")
            {
                Master.MostrarMensaje("Seleccione el tipo de mensaje que desea enviar", TipoMensaje.Advertencia);
                return;
            }

            if (validaEstado == "error")
            {
                Master.MostrarMensaje("Imposible ejecutar acción", TipoMensaje.Error);
            }
            else if (error == true)
            {
                Master.MostrarMensaje("Uno o más registros no presentan Nro Celular", TipoMensaje.Error);
                return;
            }
            else
            {
                ExportarSMS(Extencion.Excel, IdReg_Gestion_Cobranza, str_id_carta);
            }
            #endregion envia_carta

            limpiarMensaje();
            RefrescarGrid();

        }
        catch (Exception ex)
        {
            Master.MostrarMensaje(ex.Message.ToString(), TipoMensaje.Error);
        }
    }
    protected void EnvioCorreos()
    {
        Master.OcultarMensaje();
        int idValidarCanalContacto = 0;

        try
        {
            int cantCanalContacto = 0;
            bool error = false;
            LoGS_Carta objLoGS_Carta = new LoGS_Carta();
            #region Validacion
            if (Valida_SeleccionGV(M_Correo.Tipo, M_Correo.Nombre) == false)
            {
                return;
            }
            #endregion Validacion

            #region carga_variables
            string IdReg_Gestion_Cobranza = "";
            string validaEstado = "";
            int Estado = 15;
            foreach (GridViewRow row in gv.Rows)
            {
                if (((CheckBox)row.FindControl("chkPermiso")).Checked == true)
                {
                    IdReg_Gestion_Cobranza = IdReg_Gestion_Cobranza + row.Cells[1].Text + ",";
                    if (row.Cells[Estado].Text.ToString() == "1")
                    {
                        idValidarCanalContacto = int.Parse(row.Cells[1].Text);
                        cantCanalContacto = objLoGS_Carta.GS_ValidarCanalContacto(idValidarCanalContacto);
                        if (cantCanalContacto == 0)
                        {
                            error = true;
                        }
                    }
                    else
                    {
                        validaEstado = "error";
                    }
                }
            }

            if (IdReg_Gestion_Cobranza.Length > 0)
            {
                IdReg_Gestion_Cobranza = IdReg_Gestion_Cobranza.TrimEnd(',');
            }

            #endregion carga_variables

            #region envia_carta


            string str_id_carta = cmb_Carta.SelectedValue.ToString();
            if (str_id_carta == "0")
            {
                Master.MostrarMensaje("Seleccione el tipo de mensaje que desea enviar", TipoMensaje.Advertencia);
                return;
            }
            if (validaEstado == "error")
            {
                Master.MostrarMensaje("Imposible ejecutar acción", TipoMensaje.Error);
            }
            else if (error == true)
            {
                Master.MostrarMensaje("Uno o más registros no presentan Correo Electrónico", TipoMensaje.Error);
                return;
            }
            else
            {
                ExportarSMS(Extencion.Excel, IdReg_Gestion_Cobranza, str_id_carta);
            }

            int str_carta = int.Parse(cmb_Carta.SelectedValue.ToString());
            ExportarCorreo(Extencion.Excel, IdReg_Gestion_Cobranza, str_id_carta);

            #endregion envia_carta

            limpiarMensaje();
            RefrescarGrid();
        }
        catch (Exception ex)
        {
            Master.MostrarMensaje(ex.Message.ToString(), TipoMensaje.Error);
        }
    }
    protected void EnvioIVR()
    {
        Master.OcultarMensaje();
        int idValidarCanalContacto = 0;
        try
        {
            int cantCanalContacto = 0;
            bool error = false;
            LoGS_Carta objLoGS_Carta = new LoGS_Carta();
            #region Validacion
            if (Valida_SeleccionGV(M_IVR.Tipo, M_IVR.Nombre) == false)
            {
                return;
            }
            #endregion Validacion

            #region carga_variables
            string IdReg_Gestion_Cobranza = "";
            string validaEstado = "";
            int Estado = 15;
            foreach (GridViewRow row in gv.Rows)
            {
                if (((CheckBox)row.FindControl("chkPermiso")).Checked == true)
                {
                    IdReg_Gestion_Cobranza = IdReg_Gestion_Cobranza + row.Cells[1].Text + ",";
                    if (row.Cells[Estado].Text.ToString() == "1")
                    {
                        idValidarCanalContacto = int.Parse(row.Cells[1].Text);
                        cantCanalContacto = objLoGS_Carta.GS_ValidarCanalContacto(idValidarCanalContacto);
                        if (cantCanalContacto == 0)
                        {
                            error = true;
                        }
                    }
                    else
                    {
                        validaEstado = "error";
                    }
                }
            }

            if (IdReg_Gestion_Cobranza.Length > 0)
            {
                IdReg_Gestion_Cobranza = IdReg_Gestion_Cobranza.TrimEnd(',');
            }

            #endregion carga_variables

            #region envia_carta

            string str_id_carta = cmb_Carta.SelectedValue.ToString();
            if (str_id_carta == "0")
            {
                Master.MostrarMensaje("Seleccione el tipo de mensaje que desea enviar", TipoMensaje.Advertencia);
                return;
            }
            if (validaEstado == "error")
            {
                Master.MostrarMensaje("Imposible ejecutar acción", TipoMensaje.Error);
            }
            else if (error == true)
            {
                Master.MostrarMensaje("Uno o más registros no presentan Nro Celular", TipoMensaje.Error);
                return;
            }
            else
            {
                ExportarIVR(Extencion.Excel, IdReg_Gestion_Cobranza, str_id_carta);
            }           

            #endregion envia_carta

            limpiarMensaje();
            RefrescarGrid();
        }
        catch (Exception ex)
        {
            Master.MostrarMensaje(ex.Message.ToString(), TipoMensaje.Error);
        }
    }
    protected void EnvioCartas_Aval()
    {
        this.Master.OcultarMensaje();

        try
        {
            #region Validacion
            if (Valida_SeleccionGV(M_Carta.Tipo, M_Carta.Nombre) == false)
            {
                return;
            }
            #endregion Validacion

            #region carga_variables
            string IdReg_Gestion_Cobranza = "";
            foreach (GridViewRow row in gv.Rows)
            {
                if (((CheckBox)row.FindControl("chkPermiso")).Checked == true)
                {
                    IdReg_Gestion_Cobranza = IdReg_Gestion_Cobranza + row.Cells[1].Text + ",";
                }
            }

            if (IdReg_Gestion_Cobranza.Length > 0)
            {
                IdReg_Gestion_Cobranza = IdReg_Gestion_Cobranza.TrimEnd(',');
            }

            #endregion carga_variables

            #region envia_carta

            string str_carta = cmb_Carta.SelectedValue.ToString();

            if (str_carta=="0")
            {
                Master.MostrarMensaje("Seleccione el tipo de mensaje que desea enviar", TipoMensaje.Advertencia);
                return;
            }

            ExportarCarta(Extencion.Pdf, IdReg_Gestion_Cobranza, str_carta);

            #endregion envia_carta

            limpiarMensaje();
            RefrescarGrid();

        }
        catch (Exception ex)
        {
            Master.MostrarMensaje(ex.Message.ToString(), TipoMensaje.Error);
        }
    }
    protected void EnvioSMS_Aval()
    {
        Master.OcultarMensaje();
        int idValidarCanalContacto = 0;
        try
        {
            int cantCanalContacto = 0;
            bool error = false;
            LoGS_Carta objLoGS_Carta = new LoGS_Carta();
            #region Validacion
            if (Valida_SeleccionGV(M_SMS.Tipo, M_SMS.Nombre) == false)
            {
                return;
            }
            #endregion Validacion

            #region carga_variables
            string IdReg_Gestion_Cobranza = "";
            string validaEstado = "";
            int Estado = 15;
            foreach (GridViewRow row in gv.Rows)
            {
                if (((CheckBox)row.FindControl("chkPermiso")).Checked == true)
                {
                    IdReg_Gestion_Cobranza = IdReg_Gestion_Cobranza + row.Cells[1].Text + ",";
                    if (row.Cells[Estado].Text.ToString() == "1")
                    {
                        idValidarCanalContacto = int.Parse(row.Cells[1].Text);
                        cantCanalContacto = objLoGS_Carta.GS_ValidarCanalContacto(idValidarCanalContacto);
                        if (cantCanalContacto == 0)
                        {
                            error = true;
                        }
                    }
                    else
                    {
                        validaEstado = "error";
                    }
                }
            }

            if (IdReg_Gestion_Cobranza.Length > 0)
            {
                IdReg_Gestion_Cobranza = IdReg_Gestion_Cobranza.TrimEnd(',');
            }

            #endregion carga_variables

            #region envia_carta
            string str_id_carta = cmb_Carta.SelectedValue.ToString();
            if (str_id_carta == "0")
            {
                Master.MostrarMensaje("Seleccione el tipo de mensaje que desea enviar", TipoMensaje.Advertencia);
                return;
            }
            if (validaEstado == "error")
            {
                Master.MostrarMensaje("Imposible ejecutar acción", TipoMensaje.Error);
            }
            else if (error == true)
            {
                Master.MostrarMensaje("Uno o más registros no presentan Nro Celular", TipoMensaje.Error);
                return;
            }
            else
            {
                ExportarSMS(Extencion.Excel, IdReg_Gestion_Cobranza, str_id_carta);
            }
            #endregion envia_carta

            limpiarMensaje();
            RefrescarGrid();
        }
        catch (Exception ex)
        {
            Master.MostrarMensaje(ex.Message.ToString(), TipoMensaje.Error);
        }
    }
    protected void EnvioIVR_Aval()
    {
        Master.OcultarMensaje();
        int idValidarCanalContacto = 0;
        try
        {
            int cantCanalContacto = 0;
            bool error = false;
            LoGS_Carta objLoGS_Carta = new LoGS_Carta();
            #region Validacion
            if (Valida_SeleccionGV(M_IVR.Tipo, M_IVR.Nombre) == false)
            {
                return;
            }
            #endregion Validacion

            #region carga_variables
            string IdReg_Gestion_Cobranza = "";
            string validaEstado = "";
            int Estado = 15;
            foreach (GridViewRow row in gv.Rows)
            {
                if (((CheckBox)row.FindControl("chkPermiso")).Checked == true)
                {
                    IdReg_Gestion_Cobranza = IdReg_Gestion_Cobranza + row.Cells[1].Text + ",";
                    if (row.Cells[Estado].Text.ToString() == "1")
                    {
                        idValidarCanalContacto = int.Parse(row.Cells[1].Text);
                        cantCanalContacto = objLoGS_Carta.GS_ValidarCanalContacto(idValidarCanalContacto);
                        if (cantCanalContacto == 0)
                        {
                            error = true;
                        }
                    }
                    else
                    {
                        validaEstado = "error";
                    }
                }
            }

            if (IdReg_Gestion_Cobranza.Length > 0)
            {
                IdReg_Gestion_Cobranza = IdReg_Gestion_Cobranza.TrimEnd(',');
            }

            #endregion carga_variables

            #region envia_carta

            string str_id_carta = cmb_Carta.SelectedValue.ToString();
            if (str_id_carta == "0")
            {
                Master.MostrarMensaje("Seleccione el tipo de mensaje que desea enviar", TipoMensaje.Advertencia);
                return;
            }
            if (validaEstado == "error")
            {
                Master.MostrarMensaje("Imposible ejecutar acción", TipoMensaje.Error);
            }
            else if (error == true)
            {
                Master.MostrarMensaje("Uno o más registros no presentan Nro Celular", TipoMensaje.Error);
                return;
            }
            else
            {
                ExportarIVR(Extencion.Excel, IdReg_Gestion_Cobranza, str_id_carta);
            }    

            #endregion envia_carta

            limpiarMensaje();
            RefrescarGrid();
        }
        catch (Exception ex)
        {
            Master.MostrarMensaje(ex.Message.ToString(), TipoMensaje.Error);
        }
    }
    protected void EnvioCorreos_Aval()
    {
        Master.OcultarMensaje();
        int idValidarCanalContacto = 0;
        try
        {
            int cantCanalContacto = 0;
            bool error = false;
            LoGS_Carta objLoGS_Carta = new LoGS_Carta();
            #region Validacion
            if (Valida_SeleccionGV(M_Correo.Tipo, M_Correo.Nombre) == false)
            {
                return;
            }
            #endregion Validacion

            #region carga_variables
            string IdReg_Gestion_Cobranza = "";
            string validaEstado = "";
            int Estado = 15;
            foreach (GridViewRow row in gv.Rows)
            {
                if (((CheckBox)row.FindControl("chkPermiso")).Checked == true)
                {
                    IdReg_Gestion_Cobranza = IdReg_Gestion_Cobranza + row.Cells[1].Text + ",";
                    if (row.Cells[Estado].Text.ToString() == "1")
                    {
                        idValidarCanalContacto = int.Parse(row.Cells[1].Text);
                        cantCanalContacto = objLoGS_Carta.GS_ValidarCanalContacto(idValidarCanalContacto);
                        if (cantCanalContacto == 0)
                        {
                            error = true;
                        }
                    }
                    else
                    {
                        validaEstado = "error";
                    }
                }
            }

            if (IdReg_Gestion_Cobranza.Length > 0)
            {
                IdReg_Gestion_Cobranza = IdReg_Gestion_Cobranza.TrimEnd(',');
            }

            #endregion carga_variables

            #region envia_carta

            string str_id_carta = cmb_Carta.SelectedValue.ToString();
            if (str_id_carta == "0")
            {
                Master.MostrarMensaje("Seleccione el tipo de mensaje que desea enviar", TipoMensaje.Advertencia);
                return;
            }
            if (validaEstado == "error")
            {
                Master.MostrarMensaje("Imposible ejecutar acción", TipoMensaje.Error);
            }
            else if (error == true)
            {
                Master.MostrarMensaje("Uno o más registros no presentan Correo Electrónico", TipoMensaje.Error);
                return;
            }
            else
            {
                ExportarCorreo(Extencion.Excel, IdReg_Gestion_Cobranza, str_id_carta);
            }

            #endregion envia_carta

            
        }
        catch (Exception ex)
        {
            Master.MostrarMensaje(ex.Message.ToString(), TipoMensaje.Error);
        }
    }
    protected void EnvioWhatsapp()
    {
        Master.OcultarMensaje();
        int idValidarCanalContacto = 0;
        try
        {
            int cantCanalContacto = 0;
            bool error = false;
            LoGS_Carta objLoGS_Carta = new LoGS_Carta();
            #region Validacion
            if (Valida_SeleccionGV(M_SMS.Tipo, M_SMS.Nombre) == false)
            {
                return;
            }
            #endregion Validacion

            #region carga_variables
            string IdReg_Gestion_Cobranza = "";
            string validaEstado = "";
            int Estado = 15;
            foreach (GridViewRow row in gv.Rows)
            {
                if (((CheckBox)row.FindControl("chkPermiso")).Checked == true)
                {
                    IdReg_Gestion_Cobranza = IdReg_Gestion_Cobranza + row.Cells[1].Text + ",";
                    if (row.Cells[Estado].Text.ToString() == "1")
                    {
                        idValidarCanalContacto = int.Parse(row.Cells[1].Text);
                        cantCanalContacto = objLoGS_Carta.GS_ValidarCanalContacto(idValidarCanalContacto);
                        if (cantCanalContacto == 0)
                        {
                            error = true;
                        }
                    }
                    else
                    {
                        validaEstado = "error";
                    }
                }
            }

            if (IdReg_Gestion_Cobranza.Length > 0)
            {
                IdReg_Gestion_Cobranza = IdReg_Gestion_Cobranza.TrimEnd(',');
            }

            #endregion carga_variables

            #region envia_carta
            string str_id_carta = cmb_Carta.SelectedValue.ToString();
            if (str_id_carta == "0")
            {
                Master.MostrarMensaje("Seleccione el tipo de mensaje que desea enviar", TipoMensaje.Advertencia);
                return;
            }

            if (validaEstado == "error")
            {
                Master.MostrarMensaje("Imposible ejecutar acción", TipoMensaje.Error);
            }
            else if (error == true)
            {
                Master.MostrarMensaje("Uno o más registros no presentan Nro Celular", TipoMensaje.Error);
                return;
            }
            else
            {
                ExportarWhatsapp(Extencion.Excel, IdReg_Gestion_Cobranza, str_id_carta);
            }
            #endregion envia_carta

            limpiarMensaje();
            RefrescarGrid();

        }
        catch (Exception ex)
        {
            Master.MostrarMensaje(ex.Message.ToString(), TipoMensaje.Error);
        }
    }
    protected void EnvioWhatsapp_Aval()
    {
        Master.OcultarMensaje();
        int idValidarCanalContacto = 0;
        try
        {
            int cantCanalContacto = 0;
            bool error = false;
            LoGS_Carta objLoGS_Carta = new LoGS_Carta();
            #region Validacion
            if (Valida_SeleccionGV(M_SMS.Tipo, M_SMS.Nombre) == false)
            {
                return;
            }
            #endregion Validacion

            #region carga_variables
            string IdReg_Gestion_Cobranza = "";
            string validaEstado = "";
            int Estado = 15;
            foreach (GridViewRow row in gv.Rows)
            {
                if (((CheckBox)row.FindControl("chkPermiso")).Checked == true)
                {
                    IdReg_Gestion_Cobranza = IdReg_Gestion_Cobranza + row.Cells[1].Text + ",";
                    if (row.Cells[Estado].Text.ToString() == "1")
                    {

                        idValidarCanalContacto = int.Parse(row.Cells[1].Text);
                        cantCanalContacto = objLoGS_Carta.GS_ValidarCanalContacto(idValidarCanalContacto);
                        if (cantCanalContacto == 0)
                        {
                            error = true;
                        }
                    }
                    else
                    {
                        validaEstado = "error";
                    }
                }
            }

            if (IdReg_Gestion_Cobranza.Length > 0)
            {
                IdReg_Gestion_Cobranza = IdReg_Gestion_Cobranza.TrimEnd(',');
            }

            #endregion carga_variables

            #region envia_carta

            string str_id_carta = cmb_Carta.SelectedValue.ToString();
            if (str_id_carta == "0")
            {
                Master.MostrarMensaje("Seleccione el tipo de mensaje que desea enviar", TipoMensaje.Advertencia);
                return;
            }
            if (validaEstado == "error")
            {
                Master.MostrarMensaje("Imposible ejecutar acción", TipoMensaje.Error);
            }
            else if (error == true)
            {
                Master.MostrarMensaje("Uno o más registros no presentan Nro Celular", TipoMensaje.Error);
                return;
            }
            else
            {
                ExportarWhatsapp(Extencion.Excel, IdReg_Gestion_Cobranza, str_id_carta);

            #endregion envia_carta

                
            }
            limpiarMensaje();
            RefrescarGrid();
        }
        catch (Exception ex)
        {
            Master.MostrarMensaje(ex.Message.ToString(), TipoMensaje.Error);
        }
    }
    

    #endregion Metodos

    #region Funciones

    private bool Valida_SeleccionGV(string p_Tipo, string p_Nombre)
    {
        bool retorno = false;

        #region Marca_minima
        string marco = "N";
        foreach (GridViewRow row in gv.Rows)
        {
            if (((CheckBox)row.FindControl("chkPermiso")).Checked == true)
            {
                marco = "S";
            }
        }

        if (marco == "N")
        {
            Master.MostrarMensaje("Debe seleccionar como minimo un registro", TipoMensaje.Advertencia);
        }
        #endregion Marca_minima

                      
        #region Evalula_Tipo
        bool es_tipo = true;
        foreach (GridViewRow row in gv.Rows)
        {
            if (((CheckBox)row.FindControl("chkPermiso")).Checked == true)
            {
                if (((row.Cells[21].Text)) == p_Tipo)
                {
                    
                }
                else
                {
                    es_tipo = false;
                }
            }
        }

        if (es_tipo == false)
        {
            Master.MostrarMensaje("No se puede procesar la información, existen registros que no son de tipo " + p_Nombre, TipoMensaje.Advertencia);
            return false;
        }
        #endregion Tipo

        if (marco == "S" && es_tipo == true)
        {    
            retorno = true;
        }
        else
        {
            retorno = false;
        }        
        return retorno;
    }

    private void mxRedireccionarAPlantillaExcel(string pcFormato, string pcCodCobranza, string pcCodCarta, string pcPlantilla)
    {
        try
        {
            string str_Parametros = "";
            string str_tiporeporte = "?tiporerporte=" + pcFormato;
            string str_IdReg_Gestion_Cobranza = "&IdReg_Gestion_Cobranza=" + pcCodCobranza;
            //string str_Num_carta = "&Num_carta=" + num_carta;
            string str_Id_carta = "&Id_carta=" + pcCodCarta;
            string str_cempresa = "&cempresa=" + (String)this.Session["cempresa"];
            string str_codusuario = "&CodUsuario=" + (String)this.Session["codusuario"];

            string str_TIPOCONSULTA = "&tipoconsulta=" + "0";

            str_Parametros = str_tiporeporte + str_IdReg_Gestion_Cobranza + str_Id_carta + str_cempresa + str_TIPOCONSULTA + str_codusuario;

            string CONFIG = "'resizable = yes, scrollbars = yes, toolbar=no, height = 500, width = 800,left=200,top=100,status=yes, location=no, menubar=no'";
            StringBuilder sb = new StringBuilder();
            sb.Append("<script>var win=window.open('../../Reportes/Gestion/" + pcPlantilla + ".aspx" + str_Parametros + "', 'ReportePersonal', " + CONFIG + ");</script>");
            ScriptManager.RegisterStartupScript(this, typeof(Page), "ReporteAccion", sb.ToString(), false);
        }
        catch (Exception excp)
        {
            Master.MostrarMensaje(excp.ToString(), TipoMensaje.Error);
        }
    }


    
    private void ExportarCarta(string Formato, string IdReg_Gestion_Cobranza, string id_carta)
    {
        try
        {
            string str_Parametros = "";
            string str_tiporeporte = "?tiporerporte=" + Formato;
            string str_IdReg_Gestion_Cobranza = "&IdReg_Gestion_Cobranza=" + IdReg_Gestion_Cobranza;
            //string str_Num_carta = "&Num_carta=" + num_carta;
            string str_Id_carta = "&Id_carta=" + id_carta;
            string str_cempresa = "&cempresa=" + (String)this.Session["cempresa"];
            string str_codusuario = "&CodUsuario=" + (String)this.Session["codusuario"];

            string str_TIPOCONSULTA = "&tipoconsulta=" + "0";

            str_Parametros = str_tiporeporte + str_IdReg_Gestion_Cobranza + str_Id_carta + str_cempresa + str_TIPOCONSULTA + str_codusuario;

            string CONFIG = "'resizable = yes, scrollbars = yes, toolbar=no, height = 500, width = 800,left=200,top=100,status=yes, location=no, menubar=no'";
            StringBuilder sb = new StringBuilder();
            sb.Append("<script>var win=window.open('../../Reportes/Gestion/ReporteModeloCartaC.aspx" + str_Parametros + "', 'ReportePersonal', " + CONFIG + ");</script>");
            ScriptManager.RegisterStartupScript(this, typeof(Page), "ReporteAccion", sb.ToString(), false);
        }
        catch (Exception excp)
        {
            Master.MostrarMensaje(excp.ToString(), TipoMensaje.Error);
        }
    }
    private void ExportarSMS(string Formato, string IdReg_Gestion_Cobranza, string id_carta)
    {
        try
        {
            string str_Parametros = "";
            string str_tiporeporte = "?tiporerporte=" + Formato;
            string str_IdReg_Gestion_Cobranza = "&IdReg_Gestion_Cobranza=" + IdReg_Gestion_Cobranza;
            string str_Id_carta = "&Id_carta=" + id_carta;
            string str_cempresa = "&cempresa=" + (String)this.Session["cempresa"];
            string str_codusuario = "&CodUsuario=" + (String)this.Session["codusuario"];
            string str_TIPOCONSULTA = "&tipoconsulta=" + "0";
            str_Parametros = str_tiporeporte + str_IdReg_Gestion_Cobranza + str_Id_carta + str_cempresa + str_TIPOCONSULTA + str_codusuario;
            string CONFIG = "'resizable = yes, scrollbars = yes, toolbar=no, height = 500, width = 800,left=200,top=100,status=yes, location=no, menubar=no'";
            StringBuilder sb = new StringBuilder();
            sb.Append("<script>var win=window.open('../../Reportes/Gestion/ProcesosMasivos_Excel_SMS.aspx" + str_Parametros + "', 'ReportePersonal', " + CONFIG + ");</script>");
            ScriptManager.RegisterStartupScript(this, typeof(Page), "ReporteAccion", sb.ToString(), false);
        }
        catch (Exception excp)
        {
            Master.MostrarMensaje(excp.ToString(), TipoMensaje.Error);
        }
    }
    private void ExportarIVR(string Formato, string IdReg_Gestion_Cobranza, string id_carta)
    {
        try
        {
            string str_Parametros = "";
            string str_tiporeporte = "?tiporerporte=" + Formato;
            string str_IdReg_Gestion_Cobranza = "&IdReg_Gestion_Cobranza=" + IdReg_Gestion_Cobranza;
            string str_Id_carta = "&Id_carta=" + id_carta;
            string str_cempresa = "&cempresa=" + (String)this.Session["cempresa"];
            string str_codusuario = "&CodUsuario=" + (String)this.Session["codusuario"];
            string str_TIPOCONSULTA = "&tipoconsulta=" + "0";

            str_Parametros = str_tiporeporte + str_IdReg_Gestion_Cobranza + str_Id_carta + str_cempresa + str_TIPOCONSULTA + str_codusuario;

            string CONFIG = "'resizable = yes, scrollbars = yes, toolbar=no, height = 500, width = 800,left=200,top=100,status=yes, location=no, menubar=no'";
            StringBuilder sb = new StringBuilder();
            sb.Append("<script>var win=window.open('../../Reportes/Gestion/ProcesosMasivos_Excel_IVR.aspx" + str_Parametros + "', 'ReportePersonal', " + CONFIG + ");</script>");
            ScriptManager.RegisterStartupScript(this, typeof(Page), "ReporteAccion", sb.ToString(), false);
        }
        catch (Exception excp)
        {
            Master.MostrarMensaje(excp.ToString(), TipoMensaje.Error);
        }
    }
    private void ExportarCorreo(string Formato, string IdReg_Gestion_Cobranza, string str_id_carta)
    {
        try
        {
            DataTable dt = new DataTable();

            LoGS_Gestion_Cobranza objLoGS_Gestion_Cobranza = new LoGS_Gestion_Cobranza();
            EnGS_Gestion_Cobranza objEnGS_Gestion_Cobranza = new EnGS_Gestion_Cobranza();
            List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza = new List<EnGS_Gestion_Cobranza>();

            objEnGS_Gestion_Cobranza.IdReg_Gestion_Cobranza = IdReg_Gestion_Cobranza;
            objEnGS_Gestion_Cobranza.id_carta = str_id_carta.ToString();
            objEnGS_Gestion_Cobranza.CodUsuario = (String)this.Session["codusuario"];

            ListEnGS_Gestion_Cobranza.Add(objEnGS_Gestion_Cobranza);
            dt = objLoGS_Gestion_Cobranza.GS_Gestion_Cobranza_Correo_Reg(ListEnGS_Gestion_Cobranza);


            //if (dt.Rows.Count > 0)
            //{
            Master.MostrarMensaje("El proceso de realizo correctamente", TipoMensaje.Exito);
            //}
            //else
            //{
            //    Master.MostrarMensaje("El preceso Finalizo, 0 registro afectados.", TipoMensaje.Advertencia);
            //}

            #region comentado
            //string str_Parametros = "";

            //string str_tiporeporte = "?tiporerporte=" + Formato;
            //string str_IdReg_Gestion_Cobranza = "&IdReg_Gestion_Cobranza=" + IdReg_Gestion_Cobranza;
            //string str_Num_carta = "&Num_carta=" + num_carta;
            //string str_cempresa = "&cempresa=" + (String)this.Session["cempresa"];
            //string str_TIPOCONSULTA = "&tipoconsulta=" + "0";

            //str_Parametros = str_tiporeporte + str_IdReg_Gestion_Cobranza + str_Num_carta + str_cempresa + str_TIPOCONSULTA;

            //string CONFIG = "'resizable = yes, scrollbars = yes, toolbar=no, height = 500, width = 800,left=200,top=100,status=yes, location=no, menubar=no'";
            //StringBuilder sb = new StringBuilder();
            //sb.Append("<script>var win=window.open('../../Reportes/Gestion/ProcesosMasivos_Excel_Correo.aspx" + str_Parametros + "', 'ReportePersonal', " + CONFIG + ");</script>");
            //ScriptManager.RegisterStartupScript(this, typeof(Page), "ReporteAccion", sb.ToString(), false);

            #endregion comentado

        }
        catch (Exception excp)
        {
            Master.MostrarMensaje(excp.ToString(), TipoMensaje.Error);
        }

    }
    private void ExportarWhatsapp(string Formato, string IdReg_Gestion_Cobranza, string id_carta)
    {
        try
        {
            string str_Parametros = "";
            string str_tiporeporte = "?tiporerporte=" + Formato;
            string str_IdReg_Gestion_Cobranza = "&IdReg_Gestion_Cobranza=" + IdReg_Gestion_Cobranza;
            string str_Id_carta = "&Id_carta=" + id_carta;
            string str_cempresa = "&cempresa=" + (String)this.Session["cempresa"];
            string str_codusuario = "&CodUsuario=" + (String)this.Session["codusuario"];
            string str_TIPOCONSULTA = "&tipoconsulta=" + "0";

            str_Parametros = str_tiporeporte + str_IdReg_Gestion_Cobranza + str_Id_carta + str_cempresa + str_TIPOCONSULTA + str_codusuario;

            string CONFIG = "'resizable = yes, scrollbars = yes, toolbar=no, height = 500, width = 800,left=200,top=100,status=yes, location=no, menubar=no'";
            StringBuilder sb = new StringBuilder();
            sb.Append("<script>var win=window.open('../../Reportes/Gestion/ProcesosMasivos_Excel_Whatsapp.aspx" + str_Parametros + "', 'ReportePersonal', " + CONFIG + ");</script>");
            ScriptManager.RegisterStartupScript(this, typeof(Page), "ReporteAccion", sb.ToString(), false);
        }
        catch (Exception excp)
        {
            Master.MostrarMensaje(excp.ToString(), TipoMensaje.Error);
        }
    }
    

    private DataSet mxListar_ActionPlans(int lnNumTab, string pcCodTipoGestion, string pcCodGestion, string pcCodCarta, string pcCodUsuario, string lcEmpresa, ref DataSet pdsTablas, ref String[] paColumnas)
    {
        //ds = new DataSet();
        DataTable dt = new DataTable();
        string lcColumnas;
        Char delimiter = ',';
        String[] laColumnas = null;
        

        LoGS_Gestion_Cobranza objLoGS_Gestion_Cobranza = new LoGS_Gestion_Cobranza();
        EnGS_Gestion_Cobranza objEnGS_Gestion_Cobranza = new EnGS_Gestion_Cobranza();
        List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza = new List<EnGS_Gestion_Cobranza>();

        lcColumnas = string.Empty;
        objEnGS_Gestion_Cobranza.IdReg_Gestion_Cobranza = pcCodGestion;
        objEnGS_Gestion_Cobranza.id_carta = pcCodCarta;
        objEnGS_Gestion_Cobranza.CodUsuario = pcCodUsuario;
        objEnGS_Gestion_Cobranza.nEmpresa = lcEmpresa;

        ListEnGS_Gestion_Cobranza.Add(objEnGS_Gestion_Cobranza);
        string lcNomTabla;
        lcNomTabla = string.Empty;

        switch (pcCodTipoGestion)
        {
            case M_ExportarAP.Tipo:
                dt = objLoGS_Gestion_Cobranza.GS_Gestion_Cobranza_ExportarActionPlan(ListEnGS_Gestion_Cobranza);
                lcNomTabla = "ldtExportarAP";
                lcColumnas = "IDREG_GESTION_COBRANZA,CODTIPOGESTION,DESCRIPCION,CODIGOCLIENTE,DNI,RAZONSOCIAL,PRODUCTO,SUBPRODUCTO," +
                             "COD_CLASIFICACION,COD_RESULTADO,COMENTARIO,FECHARESULTADO";
                break;
            case M_Carta.Tipo:
                dt = objLoGS_Gestion_Cobranza.GS_Gestion_Cobranza_Carta_Reg(ListEnGS_Gestion_Cobranza);
                lcNomTabla = "ldtResultCartaCliente";
                lcColumnas = "RAZONSOCIAL,RUC,PRODUCTO,SUBPRODUCTO,DESCRIPCION_CARTA,PIE_CARTA,DESCRIPCION_DIRECCION,REFERENCIA_DIRECCION";
                break;
            case M_Carta_Aval.Tipo:
                dt = objLoGS_Gestion_Cobranza.GS_Gestion_Cobranza_Carta_Reg(ListEnGS_Gestion_Cobranza);
                lcNomTabla = "ldtResultCartaAval";
                lcColumnas = "RAZONSOCIAL,RUC,PRODUCTO,SUBPRODUCTO,DESCRIPCION_CARTA,PIE_CARTA,DESCRIPCION_DIRECCION,REFERENCIA_DIRECCION";
                break;
            case M_SMS.Tipo:
                dt = objLoGS_Gestion_Cobranza.GS_Gestion_Cobranza_SMS_Reg(ListEnGS_Gestion_Cobranza);
                lcNomTabla = "ldtResultSMSCliente";
                lcColumnas = "NROTELEFONICO,DESCRIPCION_CARTA";
                break;
            case M_SMS_Aval.Tipo:
                dt = objLoGS_Gestion_Cobranza.GS_Gestion_Cobranza_SMS_Reg(ListEnGS_Gestion_Cobranza);
                lcNomTabla = "ldtResultSMSAval";
                lcColumnas = "NROTELEFONICO,DESCRIPCION_CARTA";
                break;
            case M_Correo.Tipo:
                dt = objLoGS_Gestion_Cobranza.GS_Gestion_Cobranza_Carta_Reg(ListEnGS_Gestion_Cobranza);
                lcNomTabla = "ldtResultCorreoCliente";
                lcColumnas = "RAZONSOCIAL,RUC,PRODUCTO,SUBPRODUCTO,DESCRIPCION_CARTA,PIE_CARTA,DESCRIPCION_DIRECCION,REFERENCIA_DIRECCION";
                break;
            case M_Correo_Aval.Tipo:
                dt = objLoGS_Gestion_Cobranza.GS_Gestion_Cobranza_Carta_Reg(ListEnGS_Gestion_Cobranza);
                lcNomTabla = "ldtResultCorreoAval";
                lcColumnas = "RAZONSOCIAL,RUC,PRODUCTO,SUBPRODUCTO,DESCRIPCION_CARTA,PIE_CARTA,DESCRIPCION_DIRECCION,REFERENCIA_DIRECCION";
                break;
            case M_IVR.Tipo:
                dt = objLoGS_Gestion_Cobranza.GS_Gestion_Cobranza_IVR_Reg(ListEnGS_Gestion_Cobranza);
                lcNomTabla = "ldtResultIVRCliente";
                lcColumnas = "NROTELEFONICO,DESCRIPCION_CARTA";
                break;
            case M_IVR_Aval.Tipo:
                dt = objLoGS_Gestion_Cobranza.GS_Gestion_Cobranza_IVR_Reg(ListEnGS_Gestion_Cobranza);
                lcNomTabla = "ldtResultIVRAval";
                lcColumnas = "NROTELEFONICO,DESCRIPCION_CARTA";
                break;
            case M_Whatsapp.Tipo:
                dt = objLoGS_Gestion_Cobranza.GS_Gestion_Cobranza_Whatsapp_Reg(ListEnGS_Gestion_Cobranza);
                lcNomTabla = "ldtResultWhatsappCliente";
                lcColumnas = "NROTELEFONICO,DESCRIPCION_CARTA";
                break;
            case M_Whatsapp_Aval.Tipo:
                dt = objLoGS_Gestion_Cobranza.GS_Gestion_Cobranza_Whatsapp_Reg(ListEnGS_Gestion_Cobranza);
                lcNomTabla = "ldtResultWhatsappAval";
                lcColumnas = "NROTELEFONICO,DESCRIPCION_CARTA";
                break;

            case M_Cob_Interna.Tipo:
                dt = objLoGS_Gestion_Cobranza.GS_Gestion_Cobranza_ExportarTercero(ListEnGS_Gestion_Cobranza);
                lcNomTabla = "ldtResultCobranzaInterna";
                lcColumnas = "IDREG,CODIGOCLIENTE,DNI,RUC,APEPAT,APEMAT,NOMBRES,SG_DOCUMENTO,DIR,DISTRITO,DATO,GEOX,GEOY,CODPRODUCTO,PRODUCTO,NROCUOTAS,FECHAVENCIMIENTO,"+
                             "FECHAPAGO,MONTOCUOTA,SALDOCAPITAL,MONEDA,MONTODESEMB,TOTCUOTASPACT,MONTOCUOTA,CODIGOSBS,CODUSUARIO_ASESORES,ASESOR,DIAS_MORA,TRAMO,CODCALIFICACIONSBS";
                break;
            case M_Cob_Externa.Tipo:
                dt = objLoGS_Gestion_Cobranza.GS_Gestion_Cobranza_ExportarTercero(ListEnGS_Gestion_Cobranza);
                lcNomTabla = "ldtResultCobranzaExterna";
                lcColumnas = "DNI,CODPRODUCTO,CODSUBPRODUCTO,CODTIPOGESTION,CODEJECUTADO,CODRESULTADO,CODESTADOGESTIONCOBRANZA,CODUSUARIO_ASESORES,FECHARESULTADO,FECHAREGISTRA,CODUSUARIO_EJECUTOR,COMENTARIO";
                break;
            case M_Bus_Bienes.Tipo:
                dt = objLoGS_Gestion_Cobranza.GS_Gestion_Cobranza_ExportarTercero(ListEnGS_Gestion_Cobranza);
                lcNomTabla = "ldtResultBusquedaBienes";
                lcColumnas = "CODIGOCLIENTE,DNI,RUC,APEPAT,APEMAT,NOMBRES,SG_DOCUMENTO,DIR,DISTRITO,DATO,GEOX,GEOY,CODPRODUCTO,PRODUCTO,NROCUOTAS,FECHAVENCIMIENTO,"+
                             "FECHAPAGO,MONTOCUOTA,SALDOCAPITAL,MONEDA,MONTODESEMB,TOTCUOTASPACT,MONTOCUOTA,CODIGOSBS,ASESOR,DIAS_MORA,TRAMO,CODCALIFICACIONSBS";
                break;
            default:
                break;
        }
        //Creamos un arreglo con la informacion de las columnas consideradas para mostrar en el excel exportado
        laColumnas = lcColumnas.Split(delimiter);

        //Unimos los arreglos para tener un arreglo general y pueda validar que columnas iran en el excel exportado.
        List<String> lstColumnas = new List<String>();
        if (paColumnas != null) { lstColumnas.AddRange(paColumnas); }
        lstColumnas.AddRange(laColumnas);
        String[] paColumnasTemp = lstColumnas.ToArray();

        paColumnas = paColumnasTemp;

        pdsTablas.Tables.Add(dt.Copy());
        pdsTablas.Tables[lnNumTab].TableName = lcNomTabla;
        return pdsTablas;
    }
    private void ExportarGenerarCarta(string Formato, string IdReg_Gestion_Cobranza, string id_carta)
    {
        try
        {
            string str_Parametros = "";
            string str_tiporeporte = "?tiporerporte=" + Formato;
            string str_IdReg_Gestion_Cobranza = "&IdReg_Gestion_Cobranza=" + IdReg_Gestion_Cobranza;
            string str_Id_carta = "&Id_carta=" + id_carta;
            string str_cempresa = "&cempresa=" + (String)this.Session["cempresa"];
            string str_codusuario = "&CodUsuario=" + (String)this.Session["codusuario"];
            string str_TIPOCONSULTA = "&tipoconsulta=" + "0";
            str_Parametros = str_tiporeporte + str_IdReg_Gestion_Cobranza + str_Id_carta + str_cempresa + str_TIPOCONSULTA + str_codusuario;

            string CONFIG = "'resizable = yes, scrollbars = yes, toolbar=no, height = 500, width = 800,left=200,top=100,status=yes, location=no, menubar=no'";
            StringBuilder sb = new StringBuilder();
            sb.Append("<script>var win=window.open('../../Reportes/Gestion/Generar_Excel_cartas.aspx" + str_Parametros + "', 'ReportePersonal', " + CONFIG + ");</script>");
            ScriptManager.RegisterStartupScript(this, typeof(Page), "ReporteAccion", sb.ToString(), false);
        }
        catch (Exception excp)
        {
            Master.MostrarMensaje(excp.ToString(), TipoMensaje.Error);
        }
    }
    private void ExportarTercero(string Formato, string IdReg_Gestion_Cobranza)
    {
        try
        {

            string str_Parametros = "";

            string str_tiporeporte = "?tiporerporte=" + Formato;
            string str_IdReg_Gestion_Cobranza = "&IdReg_Gestion_Cobranza=" + IdReg_Gestion_Cobranza;
            ///*Modif. 041016*/
            ////string str_Num_carta = "&Num_carta=" + num_carta;
            //string str_Id_carta = "&Id_carta=" + id_carta;

            string str_cempresa = "&cempresa=" + (String)this.Session["cempresa"];
            string str_codusuario = "&CodUsuario=" + (String)this.Session["codusuario"];

            //string str_TIPOCONSULTA = "&tipoconsulta=" + "0";

            str_Parametros = str_tiporeporte + str_cempresa + str_codusuario + str_IdReg_Gestion_Cobranza;
            /*Fin Modif.*/
            string CONFIG = "'resizable = yes, scrollbars = yes, toolbar=no, height = 500, width = 800,left=200,top=100,status=yes, location=no, menubar=no'";
            StringBuilder sb = new StringBuilder();
            sb.Append("<script>var win=window.open('../../Reportes/Gestion/Generar_Excel_Tercero.aspx" + str_Parametros + "', 'ReportePersonal', " + CONFIG + ");</script>");
            ScriptManager.RegisterStartupScript(this, typeof(Page), "ReporteAccion", sb.ToString(), false);

        }
        catch (Exception excp)
        {
            Master.MostrarMensaje(excp.ToString(), TipoMensaje.Error);
        }

    }

    protected DataSet ReturnDataSet(string FilePath, string Extension)
    {
        DataSet ds = new DataSet();

        string conStr = "";
        switch (Extension)
        {
            case ".xls": //Excel 97-03
                conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                break;
            case ".xlsx": //Excel 07
                conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
                break;
        }
        conStr = String.Format(conStr, FilePath, "yes");
        OleDbConnection connExcel = new OleDbConnection(conStr);
        OleDbCommand cmdExcel = new OleDbCommand();
        OleDbDataAdapter oda = new OleDbDataAdapter();
        DataTable dt = new DataTable();
        cmdExcel.Connection = connExcel;

        //Get the name of First Sheet
        connExcel.Open();
        DataTable dtExcelSchema;
        dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
        string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
        connExcel.Close();

        //Read Data from First Sheet
        connExcel.Open();
        cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
        oda.SelectCommand = cmdExcel;
        oda.Fill(dt);
        connExcel.Close();

        ds.Tables.Add(dt.Copy());
        ds.Tables[0].TableName = "DTGestiones";

        return ds;
    }

    protected int ValidarTipoVisita(string idGestioncobranza)
    {
        int resultadoValidacion = 0;
        string str_nEmpresa = (String)this.Session["cempresa"];
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            EnGS_Gestion_Cobranza objEnGS_GestionCobranza = new EnGS_Gestion_Cobranza();
            LoGS_Gestion_Cobranza objLoGS_GestionCobranza = new LoGS_Gestion_Cobranza();
            List<EnGS_Gestion_Cobranza> ListEnGS_GestionCobranza = new List<EnGS_Gestion_Cobranza>();
            objEnGS_GestionCobranza.IdReg_Gestion_Cobranza = idGestioncobranza;
            objEnGS_GestionCobranza.nEmpresa = str_nEmpresa;
            ListEnGS_GestionCobranza.Add(objEnGS_GestionCobranza);
            dt = objLoGS_GestionCobranza.GS_TipoGestiones_ValidarTipoVisita(ListEnGS_GestionCobranza);
            ds.Tables.Add(dt.Copy());
            ds.Tables[0].TableName = "DTValidacionVisita";
            resultadoValidacion = int.Parse(ds.Tables[0].Rows[0].ItemArray[0].ToString());
            return resultadoValidacion;
        }
        catch (Exception excp)
        {

            throw excp;
        }
    }

    #endregion Funciones

    #region Estructura

    private struct M_ExportarAP
    {
        public const string Tipo = "0";
        public const string Nombre = "ExportarAP";
    }
    private struct M_Carta
    {
        public const string Tipo = "4";
        public const string Nombre = "Carta";
    }
    private struct M_SMS
    {
        public const string Tipo = "5";
        public const string Nombre = "SMS";
    }
    private struct M_IVR
    {
        public const string Tipo = "6";
        public const string Nombre = "IVR";
    }
    private struct M_Correo
    {
        public const string Tipo = "7";
        public const string Nombre = "Correo";
    }    
    private struct M_Excel
    {
        public const string Tipo = "8";
        public const string Nombre = "Excel";
    }
    private struct M_Cob_Interna
    {
        public const string Tipo = "14";
        public const string Nombre = "CobranzaInterna";
    }
    private struct M_Cob_Externa
    {
        public const string Tipo = "23";
        public const string Nombre = "CobranzaExterna";
    }
    private struct M_Bus_Bienes
    {
        public const string Tipo = "17";
        public const string Nombre = "BusquedaBienes";
    }
    private struct M_Carta_Aval
    {
        public const string Tipo = "27";
        public const string Nombre = "Carta al Aval";
    }
    private struct M_SMS_Aval
    {
        public const string Tipo = "28";
        public const string Nombre = "SMS al Aval";
    }
    private struct M_IVR_Aval
    {
        public const string Tipo = "29";
        public const string Nombre = "IVR al Aval";
    }
    private struct M_Correo_Aval
    {
        public const string Tipo = "30";
        public const string Nombre = "Correo al Aval";
    }
    private struct M_Whatsapp
    {
        public const string Tipo = "33";
        public const string Nombre = "Whatsapp";
    }
    private struct M_Whatsapp_Aval
    {
        public const string Tipo = "34";
        public const string Nombre = "Whatsapp al Aval";
    }
    private struct M_ExportadoGeneral
    {
        public const string Tipo = "35";
        public const string Nombre = "EXPORTADO";
    }
    
    #endregion Estructura


    #region Eventos
    //protected void btnVisualizar_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        //if (cmb_TipoGestion.SelectedValue != "-1" && cmb_Carta.SelectedValue != "-1")
    //        //{
    //            string str_id = "?idCarta=" + cmb_Carta.SelectedValue.ToString().Trim();
    //            string str_codTipoDocumento = "&codTipoDocumento=" + cmb_CodTipoGestion.SelectedValue.ToString().Trim();
    //            Response.Redirect(PaginaVisualizar + str_id + str_codTipoDocumento);
    //        //}
    //        //else
    //        //{
    //        //    Master.MostrarMensaje("Debe seleccionar el Tipo de Documento y un modelo", TipoMensaje.Error);
    //        //}
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}
    protected void btnEvaluarGestiones_Click(object sender, EventArgs e)
    {
        int cantidadRegistros = 0;
        if (FileUpload1.HasFile)
        {
            string FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
            string Extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
            string FolderPath = ConfigurationManager.AppSettings["FolderPath"];

            string FilePath = Server.MapPath(FolderPath + FileName);
            FileUpload1.SaveAs(FilePath);

            DataSet ds = new DataSet();
            ds = ReturnDataSet(FilePath, Extension);

            cantidadRegistros = ds.Tables[0].Rows.Count;
            LoGS_Gestion_Cobranza ObjLoGS_Gestion_Cobranza = new LoGS_Gestion_Cobranza();
            string msg = "";
            string codTipoGestion = cmb_TipoGestion.SelectedValue.ToString().Trim();
            bool error = false;
            int validacionVisita = 0;
            try
            {
                for (int i = 0; i < cantidadRegistros; i++)
                {
                    EnGS_Gestion_Cobranza ObjEnGS_Gestion_Cobranza = new EnGS_Gestion_Cobranza();
                    List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza = new List<EnGS_Gestion_Cobranza>();
                    if (ds.Tables[0].Rows[i].ItemArray[1].ToString().Trim() != string.Empty && ds.Tables[0].Rows[i].ItemArray[1].ToString().Trim()==codTipoGestion)
                    {
                        ObjEnGS_Gestion_Cobranza.nEmpresa = (String)this.Session["cempresa"];
                        ObjEnGS_Gestion_Cobranza.IdReg_Gestion_Cobranza = ds.Tables[0].Rows[i].ItemArray[0].ToString().Trim();
                        ObjEnGS_Gestion_Cobranza.CodUsuario = (String)this.Session["codusuario"];
                        ObjEnGS_Gestion_Cobranza.CodEjecutado = ds.Tables[0].Rows[i].ItemArray[8].ToString().Trim();
                        ObjEnGS_Gestion_Cobranza.CodCLaseGestion = ds.Tables[0].Rows[i].ItemArray[9].ToString().Trim();
                        ObjEnGS_Gestion_Cobranza.comentario = ds.Tables[0].Rows[i].ItemArray[10].ToString().Trim();
                        ObjEnGS_Gestion_Cobranza.FechaResultado = ds.Tables[0].Rows[i].ItemArray[11].ToString().Trim();
                        validacionVisita = ValidarTipoVisita(ObjEnGS_Gestion_Cobranza.IdReg_Gestion_Cobranza);
                        if (validacionVisita == 1)
                        {
                            ObjEnGS_Gestion_Cobranza.FechaVisita = ds.Tables[0].Rows[i].ItemArray[11].ToString().Trim();
                        }
                        ListEnGS_Gestion_Cobranza.Add(ObjEnGS_Gestion_Cobranza);
                    }
                    else
                    {
                        error = true;
                        Master.MostrarMensaje("Uno o más registros no corresponden al Action Plan seleccionado", TipoMensaje.Error);
                        return;
                    }
                    if (!error)
                    {
                        msg = ObjLoGS_Gestion_Cobranza.GS_Gestion_Cobranza_UPD_Carta_Cobranza(ListEnGS_Gestion_Cobranza);
                        Master.MostrarMensaje("Las clasificaciones y resultados de los Action Plans se han registrado correctamente.", TipoMensaje.Exito);
                        RefrescarGrid();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
    protected void cmb_Estado_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Master.OcultarMensaje();
        //limpiarMensaje();

        //gv.PageIndex = 0;

        //Regex expRegDni = new Regex(@"^\d{8}$");
        //Regex expRegDiasMora = new Regex("^[0-9]+$");
        //bool formatoCorrecto = true;
        //if (txt_documento.Text.Length > 0)
        //{
        //    if (expRegDni.IsMatch(txt_documento.Text))
        //    {
        //        formatoCorrecto = true;
        //    }
        //    else
        //    {
        //        formatoCorrecto = false;
        //        Master.MostrarMensaje("Formato de DNI Incorrecto", TipoMensaje.Error);
        //    }
        //}
        //if (txt_dias_mora.Text.Length > 0)
        //{
        //    if (expRegDiasMora.IsMatch(txt_dias_mora.Text))
        //    {
        //        formatoCorrecto = true;
        //    }
        //    else
        //    {
        //        formatoCorrecto = false;
        //        Master.MostrarMensaje("Días de Mora es numérico", TipoMensaje.Error);
        //    }
        //}
        //if (formatoCorrecto == true)
        //{
        //    RefrescarGrid();
        //}
    }
    private string mxIdentificarTipoGestion(string pcCodtipoGestion)
    {
        string lcNombre;
        lcNombre = string.Empty;
        switch (pcCodtipoGestion)
        {
            case M_Carta.Tipo:
                lcNombre = M_Carta.Nombre;
                break;
            case M_Carta_Aval.Tipo:
                lcNombre = M_Carta.Nombre;
                break;
            case M_SMS.Tipo:
                lcNombre = M_SMS.Nombre;
                break;
            case M_SMS_Aval.Tipo:
                lcNombre = M_SMS.Nombre;
                break;
            case M_Correo.Tipo:
                lcNombre = M_Correo.Nombre;
                break;
            case M_Correo_Aval.Tipo:
                lcNombre = M_Correo.Nombre;
                break;
            case M_IVR.Tipo:
                lcNombre = M_IVR.Nombre;
                break;
            case M_IVR_Aval.Tipo:
                lcNombre = M_IVR.Nombre;
                break;
            case M_Whatsapp.Tipo:
                lcNombre = M_Whatsapp.Nombre;
                break;
            case M_Whatsapp_Aval.Tipo:
                lcNombre = M_Whatsapp.Nombre;
                break;
            case M_Cob_Interna.Tipo:
                lcNombre = M_Cob_Interna.Nombre;
                break;
            case M_Cob_Externa.Tipo:
                lcNombre = M_Cob_Externa.Nombre;
                break;
            case M_Bus_Bienes.Tipo:
                lcNombre = M_Bus_Bienes.Nombre;
                break;
            default:
                break;
        }
        return lcNombre;
    }
    private void mxGenerarArchivoParaEjecutar(string pcCodtipoGestion)
    {
        DataSet ds = new DataSet();
        string lcCodTipo, lcNombre, lcMensaje, lcTipArc, lcCarta, lcPlantilla;
        lcCodTipo = lcNombre = lcMensaje = lcTipArc = lcCarta = lcPlantilla = string.Empty;
        switch (pcCodtipoGestion)
        {
            case M_Carta.Tipo:
                lcCodTipo = pcCodtipoGestion;
                lcNombre = M_Carta.Nombre;
                lcMensaje = "Mensaje de Carta";
                lcTipArc = Extencion.Pdf;
                lcCarta = cmb_Carta.SelectedValue.ToString();
                lcPlantilla = "ReporteModeloCartaC";
                break;
            case M_Carta_Aval.Tipo:
                lcCodTipo = pcCodtipoGestion;
                lcNombre = M_Carta_Aval.Nombre;
                lcMensaje = "Seleccione el tipo de mensaje que desea enviar";
                lcTipArc = Extencion.Pdf;
                lcCarta = cmb_Carta.SelectedValue.ToString();
                lcPlantilla = "ReporteModeloCartaC";
                break;
            case M_SMS.Tipo:
                lcCodTipo = pcCodtipoGestion;
                lcNombre = M_SMS.Nombre;
                lcMensaje = "Seleccione el tipo de mensaje que desea enviar";
                lcTipArc = Extencion.Excel;
                lcCarta = cmb_Carta.SelectedValue.ToString();
                lcPlantilla = "ProcesosMasivos_Excel_SMS";
                break;
            case M_SMS_Aval.Tipo:
                lcCodTipo = pcCodtipoGestion;
                lcNombre = M_SMS_Aval.Nombre;
                lcMensaje = "Seleccione el tipo de mensaje que desea enviar";
                lcTipArc = Extencion.Excel;
                lcCarta = cmb_Carta.SelectedValue.ToString();
                lcPlantilla = "ProcesosMasivos_Excel_SMS";
                break;
            case M_Correo.Tipo:
                lcCodTipo = pcCodtipoGestion;
                lcNombre = M_Correo.Nombre;
                lcMensaje = "Seleccione el tipo de mensaje que desea enviar";
                lcTipArc = Extencion.Excel;
                lcCarta = cmb_Carta.SelectedValue.ToString();
                lcPlantilla = "ReporteModeloCartaC";
                break;
            case M_Correo_Aval.Tipo:
                lcCodTipo = pcCodtipoGestion;
                lcNombre = M_Correo_Aval.Nombre;
                lcMensaje = "Seleccione el tipo de mensaje que desea enviar";
                lcTipArc = Extencion.Excel;
                lcCarta = cmb_Carta.SelectedValue.ToString();
                lcPlantilla = "ReporteModeloCartaC";
                break;
            case M_IVR.Tipo:
                lcCodTipo = pcCodtipoGestion;
                lcNombre = M_IVR.Nombre;
                lcMensaje = "Seleccione el tipo de mensaje que desea enviar";
                lcTipArc = Extencion.Excel;
                lcCarta = cmb_Carta.SelectedValue.ToString();
                lcPlantilla = "ProcesosMasivos_Excel_IVR";
                break;
            case M_IVR_Aval.Tipo:
                lcCodTipo = pcCodtipoGestion;
                lcNombre = M_IVR_Aval.Nombre;
                lcMensaje = "Seleccione el tipo de mensaje que desea enviar";
                lcTipArc = Extencion.Excel;
                lcCarta = cmb_Carta.SelectedValue.ToString();
                lcPlantilla = "ProcesosMasivos_Excel_IVR";
                break;
            case M_Whatsapp.Tipo:
                lcCodTipo = pcCodtipoGestion;
                lcNombre = M_Whatsapp.Nombre;
                lcMensaje = "Seleccione el tipo de mensaje que desea enviar";
                lcTipArc = Extencion.Excel;
                lcCarta = cmb_Carta.SelectedValue.ToString();
                lcPlantilla = "ProcesosMasivos_Excel_Whatsapp";
                break;
            case M_Whatsapp_Aval.Tipo:
                lcCodTipo = pcCodtipoGestion;
                lcNombre = M_Whatsapp_Aval.Nombre;
                lcMensaje = "Seleccione el tipo de mensaje que desea enviar";
                lcTipArc = Extencion.Excel;
                lcCarta = cmb_Carta.SelectedValue.ToString();
                lcPlantilla = "ProcesosMasivos_Excel_Whatsapp";
                break;

            default:
                break;
        }

        //this.mxEnviar_Documentos(lcCodTipo, lcNombre, lcMensaje, lcTipArc, lcCarta, lcPlantilla);

    }

    protected void btnEjecutar_Click(object sender, EventArgs e)
    {
        /*switch (cmb_CodTipoGestion.SelectedValue.ToString().Trim())
        {
            case M_Carta.Tipo:
                EnvioCartas();
                break;
            case M_SMS.Tipo:
                EnvioSMS();
                break;
            case M_Correo.Tipo:
                EnvioCorreos();
                break;
            case M_IVR.Tipo:
                EnvioIVR();
                break;
            case M_Carta_Aval.Tipo:
                EnvioCartas_Aval();
                break;
            case M_SMS_Aval.Tipo:
                EnvioSMS_Aval();
                break;
            case M_Correo_Aval.Tipo:
                EnvioCorreos_Aval();
                break;
            case M_IVR_Aval.Tipo:
                EnvioIVR_Aval();
                break;
            case M_Whatsapp.Tipo:
                EnvioWhatsapp();
                break;
            case M_Whatsapp_Aval.Tipo:
                EnvioWhatsapp_Aval();
                break;

            default:
                break;
        }*/
    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        Master.OcultarMensaje();
        try
        {
            //RefrescarGrid()
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", "<script type='text/javascript'>javascript:fnAbrirPopUpFiltro()</script>", false);
        }
        catch (Exception ex)
        {
            Master.MostrarMensaje(ex.Message.ToString(), TipoMensaje.Error);
        }
    }
    //protected void btnTerceros_Click(object sender, EventArgs e)
    //{

    //    Master.OcultarMensaje();
    //    try
    //    {

    //        //#region Validacion
    //        //if (Valida_SeleccionGV(M_IVR.Tipo, M_IVR.Nombre) == false)
    //        //{
    //        //    return;
    //        //}
    //        //#endregion Validacion
    //        string marco = "N";
    //        foreach (GridViewRow row in gv.Rows)
    //        {
    //            if (((CheckBox)row.FindControl("chkPermiso")).Checked == true)
    //            {
    //                marco = "S";
    //            }
    //        }

    //        if (marco == "N")
    //        {
    //            Master.MostrarMensaje("Debe seleccionar como minimo un registro", TipoMensaje.Advertencia);
    //        }
    //        else
    //        {
    //            #region carga_variables
    //            string IdReg_Gestion_Cobranza = "";
    //            string validaEstado = "";
    //            int Estado = 15;
    //            foreach (GridViewRow row in gv.Rows)
    //            {
    //                if (((CheckBox)row.FindControl("chkPermiso")).Checked == true)
    //                {
    //                    if (row.Cells[Estado].Text.ToString() == "1")
    //                        IdReg_Gestion_Cobranza = IdReg_Gestion_Cobranza + row.Cells[1].Text + ",";
    //                    else validaEstado = "error";
    //                }
    //            }
    //            if (IdReg_Gestion_Cobranza.Length > 0)
    //            {
    //                IdReg_Gestion_Cobranza = IdReg_Gestion_Cobranza.TrimEnd(',');
    //            }

    //            #endregion carga_variables

    //            #region exporta_terceros

    //            #endregion exporta_terceros

    //            #region envia_carta

    //            string str_carta = cmb_Carta.SelectedValue.ToString();

    //            if (validaEstado == "error")
    //            {
    //                Master.MostrarMensaje("Imposible ejecutar acción", TipoMensaje.Error);
    //            }
    //            else
    //            {
    //                ExportarTercero(Extencion.Excel, IdReg_Gestion_Cobranza);
    //                LoGS_Gestion_Cobranza objLoGS_Gestion_Cobranza = new LoGS_Gestion_Cobranza();

    //                string msg = "";
    //                string msg1 = "";

    //                //List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza = new List<EnGS_Gestion_Cobranza>();
    //                //EnGS_Gestion_Cobranza objEnGS_Gestion_Cobranza = new EnGS_Gestion_Cobranza();
    //                //foreach (GridViewRow row in gv.Rows)
    //                //{
    //                //    if (((CheckBox)row.FindControl("chkPermiso")).Checked == true)
    //                //    {
    //                //        objEnGS_Gestion_Cobranza.IdReg_Gestion_Cobranza = row.Cells[1].Text;
    //                //        objEnGS_Gestion_Cobranza.Id_estado_gestion_cobranza = "2";
    //                //        objEnGS_Gestion_Cobranza.CodUsuario = (String)this.Session["codusuario"];
    //                //        ListEnGS_Gestion_Cobranza.Add(objEnGS_Gestion_Cobranza);
    //                //        //msg = objLoGS_Gestion_Cobranza.GS_Gestion_Cobranza_UPD(ListEnGS_Gestion_Cobranza);
    //                //        msg1 = objLoGS_Gestion_Cobranza.GS_Gestion_Cobranza_UPD_Estado(ListEnGS_Gestion_Cobranza);
    //                //    }
    //                //}
    //            }
    //            #endregion envia_carta

    //            limpiarMensaje();
    //            RefrescarGrid();
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Master.MostrarMensaje(ex.Message.ToString(), TipoMensaje.Error);
    //    }
    //}
    protected void btnExportarAP_Click(object sender, EventArgs e)
    {
        DataSet ldsTablas = new DataSet();
        String[] laColumnas = null;
        string lcCodTipoGestion, lcCodGestion, lcCodCarta, lcCodUsuario, lcEmpresa;
        lcCodTipoGestion = lcCodGestion = lcCodCarta = lcCodUsuario = lcEmpresa = string.Empty;
        
        Master.OcultarMensaje();
        try
        {
            if (cmb_CodTipoGestion.SelectedValue.ToString() == "-1")
            {
                Master.MostrarMensaje("Debe seleccionar un Tipo de Accion Plan", TipoMensaje.Error);
                return;
            }
            if (cmb_Carta.SelectedValue == "-1" && (cmb_CodTipoGestion.SelectedValue.ToString() != M_Cob_Interna.Tipo && 
                                                    cmb_CodTipoGestion.SelectedValue.ToString() != M_Cob_Externa.Tipo && 
                                                    cmb_CodTipoGestion.SelectedValue.ToString() != M_Bus_Bienes.Tipo)
                )
            {
                Master.MostrarMensaje("Debe seleccionar un modelo de carta", TipoMensaje.Error);
                return;
            }
            #region Validacion
            //if (Valida_SeleccionGV(M_Carta.Tipo, M_Carta.Nombre) == false)
            //{
            //    return;
            //}
            #endregion Validacion

            #region carga_variables
            foreach (GridViewRow row in gv.Rows)
            {
                if (((CheckBox)row.FindControl("chkPermiso")).Checked == true)
                {
                    lcCodGestion = lcCodGestion + row.Cells[1].Text + ",";
                }
            }
            if (lcCodGestion.Length > 0)
            {
                lcCodGestion = lcCodGestion.TrimEnd(',');
            }

            #endregion carga_variables

            #region envia_carta
            lcCodTipoGestion = cmb_CodTipoGestion.SelectedValue.ToString().Trim();
            lcCodCarta = cmb_Carta.SelectedValue.ToString();
            lcCodUsuario = (String)this.Session["codusuario"];
            lcEmpresa = (String)this.Session["cempresa"];
            //this.ExportarGenerarCarta(Extencion.Excel, IdReg_Gestion_Cobranza, str_carta);
            //this.mxGenerarArchivoParaEjecutar(cmb_CodTipoGestion.SelectedValue.ToString().Trim());

            this.mxListar_ActionPlans(0, "0", lcCodGestion, lcCodCarta, lcCodUsuario, lcEmpresa, ref ldsTablas, ref laColumnas);
            this.mxListar_ActionPlans(1, lcCodTipoGestion, lcCodGestion, lcCodCarta, lcCodUsuario, lcEmpresa, ref ldsTablas, ref laColumnas);

            this.mxGenerarExportado(ldsTablas, laColumnas);
            if (cmb_CodTipoGestion.SelectedValue == M_Correo.Tipo || cmb_CodTipoGestion.SelectedValue == M_Correo_Aval.Tipo)
                this.mxInsertarRegistrosAEnvioCorreoMasivo(ldsTablas);

            this.mxCambiarEstadoActionPlans(lcCodTipoGestion, lcCodGestion);

            //RefrescarGrid();
            //Response.Redirect(PaginaDetalle);
            #endregion envia_carta

            
        }
        catch (Exception ex)
        {
            Master.MostrarMensaje(ex.Message.ToString(), TipoMensaje.Error);
        }
    }
    private void mxGenerarExportado(DataSet pdsTablas, String[] laColumnas)
    {
        Excel.Application excel = new Excel.Application();
        var workbook = (Excel._Workbook)(excel.Workbooks.Add(Missing.Value));
        int lnPosicionColumna;
        string lcCelda1;
        for (var i = 0; i < pdsTablas.Tables.Count; i++)
        {
            if (pdsTablas.Tables.Count >= i+1)
            {
                workbook.Sheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
            //NOTE: Excel numbering goes from 1 to n
            var currentSheet = (Excel._Worksheet)workbook.Sheets[1];
            lnPosicionColumna = 1;
            currentSheet.Name = pdsTablas.Tables[i].TableName.Substring(3);
            for (var a = 0; a < pdsTablas.Tables[i].Columns.Count; a++)
            {
                if (Array.IndexOf(laColumnas, pdsTablas.Tables[i].Columns[a].ColumnName.ToUpper()) >= 0)
                {
                    //Convertimos los valores de Numericos a Columnas Excel
                    lcCelda1 = Util.ConvertirNumeroAColumnaExcel(lnPosicionColumna) + 1.ToString();

                    currentSheet.Columns.ColumnWidth = 25;
                    currentSheet.Cells[1, lnPosicionColumna] = pdsTablas.Tables[i].Columns[a].ColumnName.ToUpper();
                    currentSheet.get_Range(lcCelda1, lcCelda1).Cells.Font.Name = "Arial";
                    currentSheet.get_Range(lcCelda1, lcCelda1).Cells.Font.Bold = true;
                    currentSheet.get_Range(lcCelda1, lcCelda1).Interior.Color = Color.LightGray;
                    currentSheet.get_Range(lcCelda1, lcCelda1).Font.Color = Color.Black;

                    lnPosicionColumna++;
                }
            }
            for (var y = 0; y < pdsTablas.Tables[i].Rows.Count; y++)
            {
                lnPosicionColumna = 1;
                for (var x = 0; x < pdsTablas.Tables[i].Rows[y].ItemArray.Count(); x++)
                {
                    if (Array.IndexOf(laColumnas, pdsTablas.Tables[i].Columns[x].ColumnName.ToUpper()) >= 0)
                    {
                        lcCelda1 = Util.ConvertirNumeroAColumnaExcel(lnPosicionColumna) + (y + 2).ToString();

                        currentSheet.Columns.ColumnWidth = 25;
                        currentSheet.get_Range(lcCelda1, lcCelda1).Cells.Font.Name = "Arial";
                        currentSheet.get_Range(lcCelda1, lcCelda1).Font.Color = Color.Black;

                        currentSheet.Cells[y + 2, lnPosicionColumna] = pdsTablas.Tables[i].Rows[y].ItemArray[x];
                        lnPosicionColumna++;

                        //Elimanmos las columnas que ya usamos para que no se repitan en la siguiente hoja del archivo excel exportado.
                        if (y + 1 >= pdsTablas.Tables[i].Rows.Count)
                        {
                            var list = new List<string>(laColumnas);
                            list.Remove(pdsTablas.Tables[i].Columns[x].ColumnName.ToUpper());
                            laColumnas = list.ToArray();
                        }
                    }
                }
            }
        } 
        var convertedFilesDirectory = Path.Combine(@"C:\EXCEL\ExportadoSMS\");

        if (!Directory.Exists(convertedFilesDirectory))
        {
            Directory.CreateDirectory(convertedFilesDirectory);
        }
        string outfile = convertedFilesDirectory + "ExportadoGestiones_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx";
        
        /*workbook.SaveAs(outfile, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlExclusive,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing);*/
        workbook.SaveAs(outfile, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing,
            false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
            Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
        workbook.Close();
        excel.Quit();

        RefrescarGrid();

        mxDescargarReporteProductividad(outfile);

    }
    private void mxDescargarReporteProductividad(string pcNombreArchivo)
    {
        //string lcNomArchivo = @"\\BDVM01\PublicacionCRGestion\ReportesGerencialesModelo\ReporteProductividad\" + pcNombreArchivo;
        string lcNomArchivo = pcNombreArchivo;
        string lcArcDestino = "CR_Envio_de_"+ mxIdentificarTipoGestion(this.cmb_CodTipoGestion.SelectedValue) +".xlsx";
        this.mxDescargarArchivo(lcNomArchivo, lcArcDestino);
    }
    private void mxDescargarArchivo(string pcNomArchivo, string lcArcDestino)
    {
        /*try
        {
            if (!string.IsNullOrEmpty(pcNomArchivo))
            { 
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/vnd.ms-excel";
                Response.AddHeader("content-disposition", string.Format("attachment;filename=" + lcArcDestino));
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
               Response.TransmitFile(pcNomArchivo);
                Response.WriteFile(pcNomArchivo);
                //Response.Flush();
                Response.Close();
                //Response.End();

            }
        }*/


        try
        {
            Response.Clear();
            Response.ContentType = "text/plain";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + lcArcDestino + ";");
            Response.TransmitFile(pcNomArchivo);
            Response.Flush();
            Response.Redirect(PaginaDetalle);
        }
        catch (Exception ex)
        {
            Master.MostrarMensaje(ex.Message.ToString(), TipoMensaje.Error);
        }
        finally
        {
            if (System.IO.File.Exists(pcNomArchivo))
            {
                System.IO.File.Delete(pcNomArchivo);
            }
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
    }


    private void mxCambiarEstadoActionPlans(string pcCodTipoGestion, string pcCodGestion)
    {
        string lcCodTipoAccionGestion;
        lcCodTipoAccionGestion = string.Empty;


        switch (pcCodTipoGestion)
        {
            case M_Carta.Tipo:
                lcCodTipoAccionGestion = M_Carta.Tipo.ToUpper();
                break;
            case M_SMS.Tipo:
                lcCodTipoAccionGestion = M_SMS.Tipo.ToUpper();
                break;
            case M_Correo.Tipo:
                lcCodTipoAccionGestion = M_Correo.Tipo.ToUpper();
                break;
            case M_IVR.Tipo:
                lcCodTipoAccionGestion = M_IVR.Tipo.ToUpper();
                break;
            case M_Whatsapp.Tipo:
                lcCodTipoAccionGestion = M_Whatsapp.Tipo.ToUpper();
                break;
            case M_Carta_Aval.Tipo:
                lcCodTipoAccionGestion = M_Carta.Tipo.ToUpper();
                break;
            case M_SMS_Aval.Tipo:
                lcCodTipoAccionGestion = M_SMS.Tipo.ToUpper();
                break;
            case M_Correo_Aval.Tipo:
                lcCodTipoAccionGestion = M_Correo.Tipo.ToUpper();
                break;
            case M_IVR_Aval.Tipo:
                lcCodTipoAccionGestion = M_IVR.Tipo.ToUpper();
                break;
            case M_Whatsapp_Aval.Tipo:
                lcCodTipoAccionGestion = M_Whatsapp.Tipo.ToUpper();
                break;

            default:
                lcCodTipoAccionGestion = "EXPORTADO";
                break;
        }

        this.mxCambiarEstadoActionPlansXTipoGestion(lcCodTipoAccionGestion, pcCodGestion);

    }

    private void mxCambiarEstadoActionPlansXTipoGestion(string pcCodTipoAccionGestion, string pcCodGestion)
    {

        LoGS_Gestion_Cobranza objLoGS_Gestion_Cobranza = new LoGS_Gestion_Cobranza();
        EnGS_Gestion_Cobranza objEnGS_Gestion_Cobranza = new EnGS_Gestion_Cobranza();
        List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza = new List<EnGS_Gestion_Cobranza>();
        string lnEmpresa = (String)this.Session["cempresa"];
        string lcCodGestionCobranza = pcCodGestion;
        string lcCodUsuario = (String)this.Session["codusuario"];

        objEnGS_Gestion_Cobranza.nEmpresa = lnEmpresa;
        objEnGS_Gestion_Cobranza.IdReg_Gestion_Cobranza = lcCodGestionCobranza;
        objEnGS_Gestion_Cobranza.CodUsuario = lcCodUsuario;
        objEnGS_Gestion_Cobranza.Id_tipo_accion_gestion = pcCodTipoAccionGestion;

        ListEnGS_Gestion_Cobranza.Add(objEnGS_Gestion_Cobranza);
        objLoGS_Gestion_Cobranza.mxCambiarEstadoActionPlansXTipoGestion(ListEnGS_Gestion_Cobranza);
    }
    private void mxInsertarRegistrosAEnvioCorreoMasivo(DataSet pdsTablas)
    {
        //mxInsertarRegistrosAEnvioCorreoMasivo
        DataTable dt = new DataTable();
        LoGS_EnvioCorreoMasivo objLoGS_EnvioCorreoMasivo = new LoGS_EnvioCorreoMasivo();
        EnGS_EnvioCorreoMasivo objEnGS_EnvioCorreoMasivo = new EnGS_EnvioCorreoMasivo();
        List<EnGS_EnvioCorreoMasivo> ListEnGS_EnvioCorreoMasivo = new List<EnGS_EnvioCorreoMasivo>();
        string lnEmpresa = (String)this.Session["cempresa"];
        string lcCodUsuario = (String)this.Session["codusuario"];

        dt = pdsTablas.Tables[1];
        /*
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            ListItem lista = new ListItem();
            lista.Value = dt.Rows[i]["CodTipoGestion"].ToString().Trim();
            lista.Text = dt.Rows[i]["Descripcion"].ToString().Trim();
            cmb_CodTipoGestion.Items.Add(lista);
            cmb_TipoGestion.Items.Add(lista);
        }*/
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            objEnGS_EnvioCorreoMasivo.Id_Reg_Gestion_Cobranza = dt.Rows[i]["IdReg_Gestion_Cobranza"].ToString();
            objEnGS_EnvioCorreoMasivo.nEmpresa = lnEmpresa;
            objEnGS_EnvioCorreoMasivo.correo_remitente = "infomail@CRGESTION.COM.PE";
            objEnGS_EnvioCorreoMasivo.correo_destinatario = dt.Rows[i]["Descripcion_correo"].ToString();
            objEnGS_EnvioCorreoMasivo.correo_asunto = "Notificación Cobranza Judicial - CRGestión";
            objEnGS_EnvioCorreoMasivo.correo_cuerpo = dt.Rows[i]["Descripcion_carta"] != null ? dt.Rows[i]["Descripcion_carta"].ToString() : dt.Rows[i]["Descripcion"].ToString();

            ListEnGS_EnvioCorreoMasivo.Add(objEnGS_EnvioCorreoMasivo);
            objLoGS_EnvioCorreoMasivo.mxInsertarRegistrosAEnvioCorreoMasivo(ListEnGS_EnvioCorreoMasivo);
        }
    }

    #endregion Eventos
    protected void btnExportarResultados_Click(object sender, EventArgs e)
    {
        try
        {
            string str_Parametros = "";
            string str_tiporeporte = "?tiporerporte=excel";
            string str_cempresa = "&cempresa=" + (String)this.Session["cempresa"];
            string str_codusuario = "&CodUsuario=" + (String)this.Session["codusuario"];
            string str_TIPOCONSULTA = "&tipoconsulta=" + "0";
            str_Parametros = str_tiporeporte + str_cempresa + str_TIPOCONSULTA + str_codusuario;
            string CONFIG = "'resizable = yes, scrollbars = yes, toolbar=no, height = 500, width = 800,left=200,top=100,status=yes, location=no, menubar=no'";
            StringBuilder sb = new StringBuilder();
            sb.Append("<script>var win=window.open('../../Reportes/Gestion/Resultados_ProcesosMasivos_Excel.aspx" + str_Parametros + "', 'ReportePersonal', " + CONFIG + ");</script>");
            ScriptManager.RegisterStartupScript(this, typeof(Page), "ReporteAccion", sb.ToString(), false);
        }
        catch (Exception excp)
        {
            Master.MostrarMensaje(excp.ToString(), TipoMensaje.Error);
        }
    }
    protected void btnExportPDF_Click(object sender, ImageClickEventArgs e)
    {
        EnvioCartas();
    }
}
