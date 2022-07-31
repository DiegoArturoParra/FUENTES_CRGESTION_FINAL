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
using Sis.Estudio.Logic.MSSQL.Seguridad;
using Sis.Estudio.Logic.MSSQL.Estudio;
using System.Text.RegularExpressions;

public partial class Estudio_Gestion_GS_Programacion_Visitas : System.Web.UI.Page
{
    #region Declaraciones
    private string PaginaDetalle = "GS_Programacion_VisitasDetalle.aspx";
    private const string PaginaRetorno = "";
    #endregion  Declaraciones
    #region Eventos
    #region Eventos_Form

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
        }
        Metodo_Enumerar();
        #endregion select


    }
    #endregion Seleccionar

    protected void Page_Load(object sender, EventArgs e)
    {

        IABaseAsginaControles();
        //btnBuscar.Focus();
        if (!Page.IsPostBack)
        {
            //G_idopcion = OpcionModulo.MantModulo;
            this.Master.TituloModulo = "Programación de Visitas";
            btnReasignar.Attributes.Add("onClick", "document.getElementById('hdnContinuar').value = confirm('¿Se reasignará El registro, ¿Desea continuar?');");
            //btnProcesar.Attributes.Add("onClick", "document.getElementById('hdnContinuar').value = confirm('¿Se Autorizará El efectivo, ¿Desea continuar?');");
            InicioOperacion();
            Cargar_Modulos();
            Combo_TipoDireccion();
            CargaComboAsesores();
            Combo_DesCargaMasiva();
            CargaCombo_Cartas();
            RefrescarGrid();
            #region accesos
            //Accesos();
            #endregion accesos
            //ConfiguracionInicial();

        }
        /*
        if (Session["SessionFiltro"] != null && !string.IsNullOrEmpty(Session["SessionFiltro"].ToString()))
        {
            this.lblFiltro.Text = "Usted esta filtrando por los siguientes elementos:";
            this.mxFormatearCadenaParaMostrar(Session["SessionFiltro"].ToString());
        }
        else
            this.lblFiltro.Text = "No se ha seleccionando ningún filtro de búsqueda.";
        */

        //upBotonera.Update();
    }
    #endregion Eventos_Form
    #region GridView
    protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv.PageIndex = e.NewPageIndex;
        RefrescarGrid();
    }
    #endregion GridView
    #region Botones

    protected void btnFiltrar_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", "<script type='text/javascript'>javascript:fnAbrirPopUpFiltro()</script>", false);
    }
    protected void btnConsultar_Click(object sender, EventArgs e)
    {
        try
        {
            if (gv.SelectedIndex != -1)
            {
                string str_estado = "?estado=c";
                string str_id = "&id=" + gv.SelectedRow.Cells[1].Text.ToString();
                string str_nombre = "&nombre=" + gv.SelectedRow.Cells[2].Text.ToString();
                Response.Redirect(PaginaDetalle + str_estado + str_id + str_nombre);
            }
            else
            {
                MostrarMensaje(Mensajes.MSG_MENSAJESELECCIONARREGISTRO, true);
            }

        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message.ToString(), true);
        }
    }
    protected void btnProgramar_Click(object sender, EventArgs e)
    {
        try
        {
            if (gv.SelectedIndex != -1)
            {

                string str_estado = "?estado=m";

                string str_id = "&id=" + gv.SelectedRow.Cells[2].Text.ToString();
                string str_nombre = "&nombre=" + gv.SelectedRow.Cells[3].Text.ToString();
                Response.Redirect(PaginaDetalle + str_estado + str_id + str_nombre);
            }
            else
            {
                Master.MostrarMensaje(Mensajes.MSG_MENSAJESELECCIONARREGISTRO, TipoMensaje.Advertencia);
            }
        }
        catch (Exception ex)
        {
            Master.MostrarMensaje(ex.Message.ToString(), TipoMensaje.Error);
        }
    }
    protected void btnReasignar_Click(object sender, EventArgs e)
    {
        string msg = "";
        string Exito = "";
        try
        {
            limpiarMensaje();
            this.Master.OcultarMensaje();
            #region Sesion
            string cempresa = (String)this.Session["cempresa"]; ;
            if (cempresa == "" || cempresa == null)
            {
                this.Session.Abandon();
                Response.Redirect("../Login.aspx?rd=0");
                return;
            }
            #endregion Sesion

            if (gv.SelectedIndex != -1)
            {
                bool continuar;
                bool.TryParse(Request.Form["hdnContinuar"], out continuar);
                if (continuar)
                {
                    LoGS_Gestion_Cobranza ObjLoGS_Gestion_Cobranza = new LoGS_Gestion_Cobranza();
                    EnGS_Gestion_Cobranza ObjEnGS_Gestion_Cobranza = new EnGS_Gestion_Cobranza();
                    List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza = new List<EnGS_Gestion_Cobranza>();
                    //**** graba subtareas ****//
                    if (cmb_Asesores.SelectedIndex != 0)
                    {
                        foreach (GridViewRow row in gv.Rows)
                        {
                            //Int32 chk = Convert.ToInt32((row.Cells[2].Text));

                            if (((CheckBox)row.FindControl("chkPermiso")).Checked == true)
                            {
                                ObjEnGS_Gestion_Cobranza.IdReg_Gestion_Cobranza = row.Cells[2].Text.ToString();
                                ObjEnGS_Gestion_Cobranza.CodUsuario = cmb_Asesores.SelectedValue.ToString();

                                ListEnGS_Gestion_Cobranza.Add(ObjEnGS_Gestion_Cobranza);

                                msg = ObjLoGS_Gestion_Cobranza.GS_Gestion_Cobranza_UPD_Asesor(ListEnGS_Gestion_Cobranza);

                                if (msg == "exito") { Exito = FlagsPrograma.FLG_VALOREXITOSI; } else { Master.MostrarMensaje(msg, TipoMensaje.Error, msg); Exito = FlagsPrograma.FLG_VALOREXITONO; return; }

                                Exito = FlagsPrograma.FLG_VALOREXITOSI;
                                
                            }
                        }
                    }
                    else
                    {
                        Master.MostrarMensaje(Mensajes.MSG_MENSAJE_SELECCIONAR_ASESOR, TipoMensaje.Advertencia);
                        return;
                    }
                    //***********************************************************//
                }
                else
                {
                    MostrarMensaje("Operacion Anular Cancelada", true);
                    return;
                }
            }
            else
            {
                //MostrarMensaje(Mensajes.MSG_MENSAJESELECCIONARREGISTRO, TipoMensaje.Advertencia);
                Master.MostrarMensaje(Mensajes.MSG_MENSAJESELECCIONARREGISTRO, TipoMensaje.Advertencia);
                return;
            }
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message.ToString(), true);
        }

        if (Exito == FlagsPrograma.FLG_VALOREXITOSI)
        {
            Master.MostrarMensaje("Se Reasignó Correctamente.", TipoMensaje.Exito);
            //Refresca_Grid("1");
            RefrescarGrid();
            //up_GV.Update();
        }
    }

    protected void btnFormatoCarta_Click(object sender, EventArgs e)
    {
        this.Master.OcultarMensaje();
        //*** recorre la grilla de ejecutado para validar que haya elegido minimo uno ****//
        string marco = "N";
        string carta = "";
        int nNumSeleccionados = 0;
        carta = cmb_Carta.SelectedValue.ToString();
        if (carta != "0")
        {
            foreach (GridViewRow row in gv.Rows)
            {
                if (((CheckBox)row.FindControl("chkPermiso")).Checked == true)
                {
                    marco = "S";
                }
            }

            if (marco == "N")
            {
                Master.MostrarMensaje("Deje seleccionar como minimo un registro", TipoMensaje.Advertencia);
            }
            //*****************************************************//

            //*** recorre la grilla para validar que todos sean de "carta cobranza" ****//
            string es_tipo_carta = "S";
            string IdReg_Gestion_Cobranza = "";
            foreach (GridViewRow row in gv.Rows)
            {
                if (((CheckBox)row.FindControl("chkPermiso")).Checked == true)
                {
                    if (((row.Cells[14].Text)) == "3")
                    {
                        IdReg_Gestion_Cobranza = IdReg_Gestion_Cobranza + row.Cells[2].Text + ",";
                        nNumSeleccionados++;
                    }
                    else
                    {
                        es_tipo_carta = "N";
                    }
                }
            }
            if (nNumSeleccionados < 1)
            {
                Master.MostrarMensaje("Debe seleccionar al menos un registro de la lista.", TipoMensaje.Advertencia);
                return;
            }
            
            if (es_tipo_carta == "N")
            {
                Master.MostrarMensaje("No se puede procesar la información, existen registros que no son de tipo carta", TipoMensaje.Advertencia);
            }
            if (IdReg_Gestion_Cobranza.Length > 0)
            {
                //string MyString = "Hello World!";
                //char[] MyChar = { 'r', 'o', 'W', 'l', 'd', '!', ' ' };
                IdReg_Gestion_Cobranza = IdReg_Gestion_Cobranza.TrimEnd(',');
            }
            //*****************************************************//

            //*** procesa cartas ****//
            //if (marco == "S" && es_tipo_carta == "S")
            //{
            //    foreach (GridViewRow row in gv.Rows)
            //    {
            //        if (((CheckBox)row.FindControl("chkPermiso")).Checked == true)
            //        {
            //            //// envia la carta /////
            //            //IdReg_Gestion_Cobranza = row.Cells[2].Text;
            //            ExportarCarta(Extencion.Pdf, IdReg_Gestion_Cobranza, carta);
            //            ////////////////////////
            //        }
            //    }
            //}
            //*****************************************************//
            ExportarCarta(Extencion.Pdf, IdReg_Gestion_Cobranza, carta);
            return;
        }

        this.Master.MostrarMensaje("Debe seleccionar un tipo de carta.", TipoMensaje.Advertencia);
        
    }
    protected void btnFormato1_Click(object sender, EventArgs e)
    {
        this.Master.OcultarMensaje();
        //*** recorre la grilla de ejecutado para validar que haya elegido minimo uno ****//
        string marco = "N";
        string carta = "";
        carta = cmb_Carta.SelectedValue.ToString();
        foreach (GridViewRow row in gv.Rows)
        {
            if (((CheckBox)row.FindControl("chkPermiso")).Checked == true)
            {
                marco = "S";
            }
        }

        if (marco == "N")
        {
            Master.MostrarMensaje("Deje seleccionar como minimo un registro", TipoMensaje.Advertencia);
        }
        //*****************************************************//
        
        //*** recorre la grilla para validar que todos sean de "carta cobranza" ****//
        string es_tipo_carta = "S";
        foreach (GridViewRow row in gv.Rows)
        {
            if (((CheckBox)row.FindControl("chkPermiso")).Checked == true)
            {
                if (((row.Cells[13].Text)) == "3")
                {


                }
                else
                {
                    es_tipo_carta = "N";
                }
            }
        }
        if (es_tipo_carta == "N")
        {
            Master.MostrarMensaje("No se puede procesar la información, existen registros que no son de tipo carta", TipoMensaje.Advertencia);
        }
        //*****************************************************//

        //*** procesa cartas ****//
        if (marco == "S" && es_tipo_carta == "S")
        {
            foreach (GridViewRow row in gv.Rows)
            {
                if (((CheckBox)row.FindControl("chkPermiso")).Checked == true)
                {
                    //// envia la carta /////
                    string IdReg_Gestion_Cobranza = "";
                    IdReg_Gestion_Cobranza = row.Cells[2].Text;
                    ExportarCarta(Extencion.Pdf, IdReg_Gestion_Cobranza, carta);
                    ////////////////////////
                }
            }
        }
        //*****************************************************//
    }

    protected void btnFormato2_Click(object sender, EventArgs e)
    {


        this.Master.OcultarMensaje();
        //*** recorre la grilla de ejecutado para validar que haya elegido minimo uno ****//

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

            Master.MostrarMensaje("Deje seleccionar como minimo un registro", TipoMensaje.Advertencia);
        }

        //*****************************************************//


        //*** recorre la grilla para validar que todos sean de "carta cobranza" ****//

        string es_tipo_carta = "S";

        foreach (GridViewRow row in gv.Rows)
        {

            if (((CheckBox)row.FindControl("chkPermiso")).Checked == true)
            {

                if (((row.Cells[13].Text)) == "3")
                {


                }
                else
                {
                    es_tipo_carta = "N";
                }


            }

        }

        if (es_tipo_carta == "N")
        {

            Master.MostrarMensaje("No se puede procesar la información, existen registros que no son de tipo carta", TipoMensaje.Advertencia);
        }

        //*****************************************************//

        //*** procesa cartas ****//
        if (marco == "S" && es_tipo_carta == "S")
        {

            foreach (GridViewRow row in gv.Rows)
            {

                if (((CheckBox)row.FindControl("chkPermiso")).Checked == true)
                {

                    //// envia la carta /////
                    string IdReg_Gestion_Cobranza = "";
                    IdReg_Gestion_Cobranza = row.Cells[2].Text;
                    ExportarCarta(Extencion.Pdf, IdReg_Gestion_Cobranza, "2");
                    ////////////////////////

                }

            }

        }

        //*****************************************************//




    }
    protected void btnFormato3_Click(object sender, EventArgs e)
    {

        this.Master.OcultarMensaje();
        //*** recorre la grilla de ejecutado para validar que haya elegido minimo uno ****//

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

            Master.MostrarMensaje("Deje seleccionar como minimo un registro", TipoMensaje.Advertencia);
        }

        //*****************************************************//


        //*** recorre la grilla para validar que todos sean de "carta cobranza" ****//

        string es_tipo_carta = "S";

        foreach (GridViewRow row in gv.Rows)
        {

            if (((CheckBox)row.FindControl("chkPermiso")).Checked == true)
            {

                if (((row.Cells[13].Text)) == "3")
                {


                }
                else
                {
                    es_tipo_carta = "N";
                }


            }

        }

        if (es_tipo_carta == "N")
        {

            Master.MostrarMensaje("No se puede procesar la información, existen registros que no son de tipo carta", TipoMensaje.Advertencia);
        }

        //*****************************************************//

        //*** procesa cartas ****//
        if (marco == "S" && es_tipo_carta == "S")
        {

            foreach (GridViewRow row in gv.Rows)
            {

                if (((CheckBox)row.FindControl("chkPermiso")).Checked == true)
                {

                    //// envia la carta /////
                    string IdReg_Gestion_Cobranza = "";
                    IdReg_Gestion_Cobranza = row.Cells[2].Text;
                    ExportarCarta(Extencion.Pdf, IdReg_Gestion_Cobranza, "3");
                    ////////////////////////

                }

            }

        }

        //*****************************************************//


    }
    protected void btnFormato4_Click(object sender, EventArgs e)
    {

        this.Master.OcultarMensaje();
        //*** recorre la grilla de ejecutado para validar que haya elegido minimo uno ****//

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

            Master.MostrarMensaje("Deje seleccionar como minimo un registro", TipoMensaje.Advertencia);
        }

        //*****************************************************//


        //*** recorre la grilla para validar que todos sean de "carta cobranza" ****//

        string es_tipo_carta = "S";

        foreach (GridViewRow row in gv.Rows)
        {

            if (((CheckBox)row.FindControl("chkPermiso")).Checked == true)
            {

                if (((row.Cells[13].Text)) == "3")
                {


                }
                else
                {
                    es_tipo_carta = "N";
                }


            }

        }

        if (es_tipo_carta == "N")
        {

            Master.MostrarMensaje("No se puede procesar la información, existen registros que no son de tipo carta", TipoMensaje.Advertencia);
        }

        //*****************************************************//

        //*** procesa cartas ****//
        if (marco == "S" && es_tipo_carta == "S")
        {

            foreach (GridViewRow row in gv.Rows)
            {

                if (((CheckBox)row.FindControl("chkPermiso")).Checked == true)
                {

                    //// envia la carta /////
                    string IdReg_Gestion_Cobranza = "";
                    IdReg_Gestion_Cobranza = row.Cells[2].Text;
                    ExportarCarta(Extencion.Pdf, IdReg_Gestion_Cobranza, "4");
                    ////////////////////////

                }

            }

        }

        //*****************************************************//



    }
    protected void btnFormato5_Click(object sender, EventArgs e)
    {

        this.Master.OcultarMensaje();
        //*** recorre la grilla de ejecutado para validar que haya elegido minimo uno ****//

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

            Master.MostrarMensaje("Deje seleccionar como minimo un registro", TipoMensaje.Advertencia);
        }

        //*****************************************************//


        //*** recorre la grilla para validar que todos sean de "carta cobranza" ****//

        string es_tipo_carta = "S";

        foreach (GridViewRow row in gv.Rows)
        {

            if (((CheckBox)row.FindControl("chkPermiso")).Checked == true)
            {

                if (((row.Cells[13].Text)) == "3")
                {


                }
                else
                {
                    es_tipo_carta = "N";
                }


            }

        }

        if (es_tipo_carta == "N")
        {

            Master.MostrarMensaje("No se puede procesar la información, existen registros que no son de tipo carta", TipoMensaje.Advertencia);
        }

        //*****************************************************//

        //*** procesa cartas ****//
        if (marco == "S" && es_tipo_carta == "S")
        {

            foreach (GridViewRow row in gv.Rows)
            {

                if (((CheckBox)row.FindControl("chkPermiso")).Checked == true)
                {

                    //// envia la carta /////
                    string IdReg_Gestion_Cobranza = "";
                    IdReg_Gestion_Cobranza = row.Cells[2].Text;
                    ExportarCarta(Extencion.Pdf, IdReg_Gestion_Cobranza, "5");
                    ////////////////////////

                }

            }

        }

        //*****************************************************//


    }

    protected void btnPanelDetalle_Click(object sender, EventArgs e)
    {
        try
        {
            Master.OcultarMensaje();            
            #region Validacion
            if (gv.Rows.Count<1)
            {
                Master.MostrarMensaje("0 Registros para mostrar.", TipoMensaje.Advertencia);
                return;
            }
            #endregion Validacion
            Ventana_Visible(true);
            //ListarHistoricoPerfilesDet(hd_VersionGv.Value.Trim(), hd_ClienteGv.Value.Trim(), hd_InformeGv.Value.Trim());
        }
        catch (Exception ex)
        {
            Master.MostrarMensaje(ex.Message.ToString(), TipoMensaje.Error);
        }
    }
    protected void btnCerrarPopDetalle_Click(object sender, EventArgs e)
    {
        try
        {
            Master.OcultarMensaje();
            Ventana_Visible(false);
        }
        catch (Exception ex)
        {
            Master.MostrarMensaje(ex.Message.ToString(), TipoMensaje.Error);
        }
    }
    #endregion Botones
    #endregion Eventos
    #region ToolBar


    protected void btnSalir_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            Response.Redirect("../../Principal.aspx");
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message.ToString(), true);
        }
    }




    #endregion ToolBar
    #region Limpiar_Filtro

    #endregion Limpiar_Filtro
    #region Datos
    private void RefrescarGrid()
    {
        DataSet DS = new DataSet();
        DataTable DT_Datos = new DataTable();
        DataTable DT_Resum = new DataTable();
        string lcFiltro = string.Empty;
        
        LoGS_Gestion_Cobranza objLoGS_Gestion_Cobranza = new LoGS_Gestion_Cobranza();
        EnGS_Gestion_Cobranza objEnGS_Gestion_Cobranza = new EnGS_Gestion_Cobranza();
        List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza = new List<EnGS_Gestion_Cobranza>();

        try
        {
            #region Carga_Variables
            lcFiltro = Session["SessionFiltro"]!=null?Session["SessionFiltro"].ToString():string.Empty;
            objEnGS_Gestion_Cobranza.nEmpresa = (String)this.Session[Global.NEmpresa].ToString();
            //objEnGS_Gestion_Cobranza.fecha_ini = txt_FECHAINI.Text.ToString();
            //objEnGS_Gestion_Cobranza.fecha_fin = txt_FECHAFIN.Text.ToString();
            //objEnGS_Gestion_Cobranza.CodUsuario_Asesores = (String)this.Session["codusuario"];
            //objEnGS_Gestion_Cobranza.CodTipoGestion = cmb_CodTipoGestion.SelectedValue.ToString();
            //objEnGS_Gestion_Cobranza.CodUsuario_Reasignado = cmb_Asesores.SelectedValue.ToString().Trim();

            //objEnGS_Gestion_Cobranza.MontoCuota = txtMontoCuota.Text.ToString();
            //objEnGS_Gestion_Cobranza.dias_mora = txtDiasMora.Text.ToString();
            //objEnGS_Gestion_Cobranza.Distrito = txtDistrito.Text.ToString();
            //objEnGS_Gestion_Cobranza.CodTipoDir = cmb_TipoDir.SelectedValue.ToString().Trim();
            //objEnGS_Gestion_Cobranza.Convenio = cmb_convenio.SelectedValue.ToString().Trim();
            //objEnGS_Gestion_Cobranza.TelefonoSi = cmb_telefonosi.SelectedValue.ToString().Trim();
            //objEnGS_Gestion_Cobranza.Id_carga = Util.FormateaEntero(cmb_DesCargaMasiva.SelectedValue.ToString().Trim());
            
            ListEnGS_Gestion_Cobranza.Add(objEnGS_Gestion_Cobranza);
            #endregion Carga_Variables

            DS = objLoGS_Gestion_Cobranza.GS_Gestion_Cobranza_x_Visitas_Lista(ListEnGS_Gestion_Cobranza, lcFiltro);
            DT_Datos = DS.Tables[0];
            DT_Resum = DS.Tables[1];

            #region Listado
            gv.DataSource = DT_Datos;
            gv.DataBind();

            #region Contador
            if (DT_Datos.Rows.Count > 0)
            {
                lblCantidad.Text = "Total: " + DT_Datos.Rows.Count.ToString() + " Registros";
                lblPaginaGrilla.Text = "[Registros: " + Convert.ToString((gv.PageIndex * gv.PageSize) + 1) + "-" + Convert.ToString(gv.PageIndex * gv.PageSize + (DT_Datos.Rows.Count < gv.PageSize ? DT_Datos.Rows.Count : gv.PageSize)) + "]";
            }
            else
            {
                lblCantidad.Text = "Total: 0 Registros";
                lblPaginaGrilla.Text = "[Registros: 0-0 ]";
            }
            #endregion Contador
            #endregion Listado

            #region Resumen
            if (DT_Resum.Rows.Count > 0)
            {
                hd_Distrito.Value = DT_Resum.Rows[0]["cDistrito"].ToString().Trim();
                hd_TotalDistrito.Value = DT_Resum.Rows[0]["nTotalDistrito"].ToString().Trim();
                hd_MontoCuota.Value = DT_Resum.Rows[0]["nMontoCuota"].ToString().Trim();

                gv_Resumen.DataSource = DT_Resum;
                gv_Resumen.DataBind();
            }
            #region Contador_Resumen
            if (DT_Resum.Rows.Count > 0)
            {
                lbl_CantRegResumen.Text = "Total: " + DT_Resum.Rows.Count.ToString() + " Registros";
                
            }
            else
            {
                lbl_CantRegResumen.Text = "Total: 0 Registros";                
            }
            #endregion Contador_Resumen

            #endregion Resumen
            //string lcCadena = this.mxFormatearCadenaParaMostrar(Session["SessionFiltro"].ToString());
            //string lcScript = "alert(\"" + lcCadena + "\")";
            //mxEjeuctarJavaScript(lcScript);
            //mxEjeuctarJavaScript(mxFormatearCadenaParaMostrar(lcCadena));
        }
        catch (Exception ex)
        {
            //throw ex;
            if (ex is SqlException)
            {
                // Handle more specific SqlException exception here.
                Master.MostrarMensaje("ERROR DE SINTAXIS, FAVOR REALIZAR CORRECTAMENTE EL FILTRO!!!", TipoMensaje.Error);
            }
        }
    }
    private void mxEjeuctarJavaScript(string pcCadena)
    {
        ScriptManager.RegisterStartupScript(this, typeof(Page), "", "<script type='text/javascript'>" + pcCadena + "</script>", false);
    }
    private void Cargadia1()
    {
        DataTable DT_Datos = new DataTable();

        LoGS_Gestion_Cobranza objLoGS_Gestion_Cobranza = new LoGS_Gestion_Cobranza();
        EnGS_Gestion_Cobranza objEnGS_Gestion_Cobranza = new EnGS_Gestion_Cobranza();
        List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza = new List<EnGS_Gestion_Cobranza>();


        objEnGS_Gestion_Cobranza.nEmpresa = (String)this.Session["cempresa"];

        //objEnGS_Gestion_Cobranza.fecha_ini = txt_FECHAINI.Text.ToString();
        //objEnGS_Gestion_Cobranza.CodUsuario_Asesores = (String)this.Session["codusuario"];
        //objEnGS_Gestion_Cobranza.CodUsuario_Reasignado = cmb_Asesores.SelectedValue.ToString().Trim();

        ListEnGS_Gestion_Cobranza.Add(objEnGS_Gestion_Cobranza);

        try
        {
            DataSet ds = objLoGS_Gestion_Cobranza.GS_Visitas_Calendario_DS(ListEnGS_Gestion_Cobranza);
            DataTable DT_dia1 = ds.Tables[0];
            DataTable DT_dia2 = ds.Tables[1];
            DataTable DT_dia3 = ds.Tables[2];
            DataTable DT_dia4 = ds.Tables[3];
            DataTable DT_dia5 = ds.Tables[4];
            DataTable DT_dia6 = ds.Tables[5];
            DataTable DT_dia7 = ds.Tables[6];

            gv1.DataSource = DT_dia1;
            gv1.DataBind();
            pintar_dia1();
            gv2.DataSource = DT_dia2;
            gv2.DataBind();
            pintar_dia2();
            gv3.DataSource = DT_dia3;
            gv3.DataBind();
            pintar_dia3();
            gv4.DataSource = DT_dia4;
            gv4.DataBind();
            pintar_dia4();
            gv5.DataSource = DT_dia5;
            gv5.DataBind();
            pintar_dia5();
            gv6.DataSource = DT_dia6;
            gv6.DataBind();
            pintar_dia6();
            gv7.DataSource = DT_dia7;
            gv7.DataBind();
            pintar_dia7();

            
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    private void pintar_dia1()
    {
        try
        {
            #region Validacion
            if (gv1.Rows.Count < 1)
            {
                return;
            }
            #endregion Validacion

            foreach (GridViewRow fila in gv1.Rows)
            {

                if (fila.Cells[0].Text.ToString() == "1")
                {
                    fila.Cells[1].BackColor = Color.Yellow;
                }
                if (fila.Cells[0].Text.ToString() == "2")
                {
                    fila.Cells[1].BackColor = Color.Green;
                }
                if (fila.Cells[0].Text.ToString() == "3")
                {
                    fila.Cells[1].BackColor = Color.Red;
                }
                if (fila.Cells[0].Text.ToString() == "4")
                {
                    fila.Cells[1].BackColor = Color.LightGray;
                }


            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void pintar_dia2()
    {
        try
        {
            #region Validacion
            if (gv2.Rows.Count < 1)
            {
                return;
            }
            #endregion Validacion

            foreach (GridViewRow fila in gv2.Rows)
            {

                if (fila.Cells[0].Text.ToString() == "1")
                {
                    fila.Cells[1].BackColor = Color.Yellow;
                }
                if (fila.Cells[0].Text.ToString() == "2")
                {
                    fila.Cells[1].BackColor = Color.Green;
                }
                if (fila.Cells[0].Text.ToString() == "3")
                {
                    fila.Cells[1].BackColor = Color.Red;
                }
                if (fila.Cells[0].Text.ToString() == "4")
                {
                    fila.Cells[1].BackColor = Color.LightGray;
                }


            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void pintar_dia3()
    {
        try
        {
            #region Validacion
            if (gv3.Rows.Count < 1)
            {
                return;
            }
            #endregion Validacion

            foreach (GridViewRow fila in gv3.Rows)
            {

                if (fila.Cells[0].Text.ToString() == "1")
                {
                    fila.Cells[1].BackColor = Color.Yellow;
                }
                if (fila.Cells[0].Text.ToString() == "2")
                {
                    fila.Cells[1].BackColor = Color.Green;
                }
                if (fila.Cells[0].Text.ToString() == "3")
                {
                    fila.Cells[1].BackColor = Color.Red;
                }
                if (fila.Cells[0].Text.ToString() == "4")
                {
                    fila.Cells[1].BackColor = Color.LightGray;
                }


            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void pintar_dia4()
    {
        try
        {
            #region Validacion
            if (gv4.Rows.Count < 1)
            {
                return;
            }
            #endregion Validacion

            foreach (GridViewRow fila in gv4.Rows)
            {

                if (fila.Cells[0].Text.ToString() == "1")
                {
                    fila.Cells[1].BackColor = Color.Yellow;
                }
                if (fila.Cells[0].Text.ToString() == "2")
                {
                    fila.Cells[1].BackColor = Color.Green;
                }
                if (fila.Cells[0].Text.ToString() == "3")
                {
                    fila.Cells[1].BackColor = Color.Red;
                }
                if (fila.Cells[0].Text.ToString() == "4")
                {
                    fila.Cells[1].BackColor = Color.LightGray;
                }


            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void pintar_dia5()
    {
        try
        {
            #region Validacion
            if (gv5.Rows.Count < 1)
            {
                return;
            }
            #endregion Validacion

            foreach (GridViewRow fila in gv5.Rows)
            {

                if (fila.Cells[0].Text.ToString() == "1")
                {
                    fila.Cells[1].BackColor = Color.Yellow;
                }
                if (fila.Cells[0].Text.ToString() == "2")
                {
                    fila.Cells[1].BackColor = Color.Green;
                }
                if (fila.Cells[0].Text.ToString() == "3")
                {
                    fila.Cells[1].BackColor = Color.Red;
                }
                if (fila.Cells[0].Text.ToString() == "4")
                {
                    fila.Cells[1].BackColor = Color.LightGray;
                }


            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void pintar_dia6()
    {
        try
        {
            #region Validacion
            if (gv6.Rows.Count < 1)
            {
                return;
            }
            #endregion Validacion

            foreach (GridViewRow fila in gv6.Rows)
            {

                if (fila.Cells[0].Text.ToString() == "1")
                {
                    fila.Cells[1].BackColor = Color.Yellow;
                }
                if (fila.Cells[0].Text.ToString() == "2")
                {
                    fila.Cells[1].BackColor = Color.Green;
                }
                if (fila.Cells[0].Text.ToString() == "3")
                {
                    fila.Cells[1].BackColor = Color.Red;
                }
                if (fila.Cells[0].Text.ToString() == "4")
                {
                    fila.Cells[1].BackColor = Color.LightGray;
                }


            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void pintar_dia7()
    {
        try
        {
            #region Validacion
            if (gv7.Rows.Count < 1)
            {
                return;
            }
            #endregion Validacion

            foreach (GridViewRow fila in gv7.Rows)
            {

                if (fila.Cells[0].Text.ToString() == "1")
                {
                    fila.Cells[1].BackColor = Color.Yellow;
                }
                if (fila.Cells[0].Text.ToString() == "2")
                {
                    fila.Cells[1].BackColor = Color.Green;
                }
                if (fila.Cells[0].Text.ToString() == "3")
                {
                    fila.Cells[1].BackColor = Color.Red;
                }
                if (fila.Cells[0].Text.ToString() == "4")
                {
                    fila.Cells[1].BackColor = Color.LightGray;
                }


            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }



    private void Metodo_Enumerar()
    {
        try
        {
            #region Validacion
            if (gv.Rows.Count < 1)
            {
                return;
            }
            #endregion Validacion

            int contador = 0;

            foreach (GridViewRow fila in gv.Rows)
            {
                if (fila.RowType == DataControlRowType.DataRow)
                {
                    contador = contador + 1;
                    fila.Cells[1].Text = contador.ToString();

                }
            }



        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //protected void btnBuscar_Click(object sender, EventArgs e)
    //{

    //    try
    //    {
    //        Master.OcultarMensaje();

    //        RefrescarGrid();

    //        //Cargadia1();
    //    }
    //    catch (Exception ex)
    //    {
            
    //        Master.MostrarMensaje(ex.Message.ToString(), TipoMensaje.Error);

    //    }
    //}



    #endregion Datos
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

        }
        catch (Exception excp)
        {
            Master.MostrarMensaje(excp.Message.ToString(), TipoMensaje.Error);

        }

    }
    protected void CargaComboEjecutores()
    {
        DataTable dt = new DataTable();

        try
        {

            LoGS_ClaseGestionesxTipoGestion objLoGS_ClaseGestionesxTipoGestion = new LoGS_ClaseGestionesxTipoGestion();
            EnGS_ClaseGestionesxTipoGestion objEnGS_ClaseGestionesxTipoGestion = new EnGS_ClaseGestionesxTipoGestion();
            List<EnGS_ClaseGestionesxTipoGestion> ListEnGS_ClaseGestionesxTipoGestion = new List<EnGS_ClaseGestionesxTipoGestion>();

            objEnGS_ClaseGestionesxTipoGestion.CodClaseGestion = "0";
            ListEnGS_ClaseGestionesxTipoGestion.Add(objEnGS_ClaseGestionesxTipoGestion);

            //cmb_CodTipoGestion.Items.Clear();

            dt = objLoGS_ClaseGestionesxTipoGestion.GS_ClaseGestionesxTipoGestion_Lista(ListEnGS_ClaseGestionesxTipoGestion);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //if (dt.Rows[i]["CodTipoGestion"].ToString().Trim() == "3")
                //{
                //    ListItem lista = new ListItem();
                //    lista.Value = dt.Rows[i]["CodTipoGestion"].ToString().Trim();
                //    lista.Text = dt.Rows[i]["Descripcion"].ToString().Trim();
                //    cmb_CodTipoGestion.Items.Add(lista);
                //}
                //ListItem lista = new ListItem();
                //lista.Value = dt.Rows[i]["CodTipoGestion"].ToString().Trim();
                //lista.Text = dt.Rows[i]["Descripcion"].ToString().Trim();
                //cmb_CodTipoGestion.Items.Add(lista);
            }
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

            objEnGS_Gestion_Cobranza.nEmpresa = (String)this.Session["cempresa"];
            ListEnGS_Gestion_Cobranza.Add(objEnGS_Gestion_Cobranza);


            cmb_Asesores.Items.Clear();

            dt = objLoGS_Gestion_Cobranza.GS_Gestion_Cobranza_Asesores_Lista(ListEnGS_Gestion_Cobranza);

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
    protected void Combo_TipoDireccion()
    {
        DataTable dt = new DataTable();
        try
        {

            //cmb_TipoDir.Items.Clear();

            //LoTipoDireccion objLo = new LoTipoDireccion();
            //dt = objLo.TipoDireccion_Listar();

            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    ListItem lista = new ListItem();
            //    lista.Value = dt.Rows[i]["CodTipoDir"].ToString().Trim();
            //    lista.Text = dt.Rows[i]["TipoDireccion"].ToString().Trim();
            //    cmb_TipoDir.Items.Add(lista);
            //}
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void Combo_DesCargaMasiva()
    {
        DataTable dt = new DataTable();
        try
        {

            //cmb_DesCargaMasiva.Items.Clear();
            //LoGS_Gestion_Cobranza objLo = new LoGS_Gestion_Cobranza();
            //List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza = new List<EnGS_Gestion_Cobranza>();
            //EnGS_Gestion_Cobranza objEnGS_Gestion_Cobranza = new EnGS_Gestion_Cobranza();
            //#region Carga_Variables
            //objEnGS_Gestion_Cobranza.nEmpresa = (String)this.Session[Global.NEmpresa].ToString();
            //ListEnGS_Gestion_Cobranza.Add(objEnGS_Gestion_Cobranza);
            //#endregion Carga_Variables


            //dt = objLo.GS_Visitas_DesCargaMasiva(ListEnGS_Gestion_Cobranza);

            //#region Ninguno
            //ListItem listaTodos = new ListItem();
            //listaTodos.Value = "0";
            //listaTodos.Text = "--";
            //cmb_DesCargaMasiva.Items.Add(listaTodos);
            //#endregion Ninguno
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    ListItem lista = new ListItem();
            //    lista.Value = dt.Rows[i]["Id_Carga"].ToString().Trim();
            //    lista.Text = dt.Rows[i]["Descrip"].ToString().Trim();
            //    cmb_DesCargaMasiva.Items.Add(lista);
            //}
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void CargaDatosCabecera()
    {


        //****************************************************************************************
        //* Nombre      : MostrarDatos
        //* DescripcioN :
        //*
        //****************************************************************************************
        try
        {
            DataTable dt = new DataTable();

            LoUsuario objLoUsuario = new LoUsuario();
            List<EnUsuario> ListEnUsuario = new List<EnUsuario>();
            EnUsuario objEnUsuario = new EnUsuario();

            objEnUsuario.CEmpresa = (String)this.Session["cempresa"];
            objEnUsuario.Tipo = "1";
            objEnUsuario.codUsuario = (String)this.Session["codusuario"];
            ListEnUsuario.Add(objEnUsuario);

            dt = objLoUsuario.CargaDatosUsuario(ListEnUsuario);

            if (dt.Rows.Count > 0)
            {
                //txt_desc_jerarquia.Text = dt.Rows[0]["desc_jerarquia"].ToString();
                //txt_asesor.Text = dt.Rows[0]["NOMBREUSUARIO"].ToString();
            }

        }
        catch (Exception excp)
        {
            throw excp;
        }
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

            objEnGS_Gestion_Cobranza.CodTipoGestion = "4"; //cmb_CodTipoGestion.SelectedValue.ToString();

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

    private string AccionStore()
    {
        string str_retorno;
        /* if (chk_TODOS.Checked)
         {
             str_retorno = AccionListado.Todos.ToString();
         }
         else
         {*/
        /*
        if (txt_login.Text.Length < 1)
        {*/
        str_retorno = AccionListado.Top.ToString();
        /*}
        else
        {
            str_retorno = AccionListado.Filtrado.ToString();
        }
         * */
        /*}*/

        return str_retorno;

    }
    private void Exportar(string Formato)
    {
        /*
        try
        {
            string str_Parametros = "";

            string str_tiporeporte = "?tiporerporte=" + Formato;
            string str_accionstore = "&accionstore=" + AccionStore();
            string str_nombre = "&n_codi_cier=" + gv.SelectedRow.Cells[1].Text.ToString(); 
            string str_descripcion = "&codidenest=" + (String)this.Session["codidenest"];
            string str_anio = "&anio=" + gv.SelectedRow.Cells[3].Text.ToString();
            string str_mes = "&mes=" + gv.SelectedRow.Cells[4].Text.ToString(); 

            string flag_asistencia;
            flag_asistencia = ""; 
            if (chkAsistencia.Checked==true){
                flag_asistencia = "S";
            }else{
                flag_asistencia = "N";
            }


            string str_flag_empresa = "&flag_asistencia=" + flag_asistencia.ToString();
            string str_TIPOCONSULTA = "&tipoconsulta=" + "0";

            str_Parametros = str_tiporeporte + str_accionstore + str_nombre + str_descripcion + str_flag_empresa + str_TIPOCONSULTA + str_anio + str_mes;

            string CONFIG = "'resizable = yes, scrollbars = yes, toolbar=no, height = 500, width = 800,left=200,top=100,status=yes, location=no, menubar=no'";
            StringBuilder sb = new StringBuilder();
            sb.Append("<script>var win=window.open('../../Reportes/SGO/ReporteCierre_EfectivoC.aspx" + str_Parametros + "', 'ReporteCierreEfectivo', " + CONFIG + ");win.focus();</script>");
            ScriptManager.RegisterStartupScript(this, typeof(Page), "ReporteAccion", sb.ToString(), false);
        }
        catch (Exception excp)
        {
            MostrarMensaje(excp.ToString(), true);
        }
        */
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
    private void Ventana_Visible(bool estado)
    {
        if (estado == true)
        {            
            PanelDetalle.Visible = true;             
        }
        else
        {            
            PanelDetalle.Visible = false;                    
        }
    }
    /*
    private string mxFormatearCadenaParaMostrar(string plCadena)
    {
          string[] stringSeparators = new string[] {" AND "};
          string[] substrings = plCadena.Split(stringSeparators, StringSplitOptions.None);
          this.divFiltro.InnerHtml = string.Empty;
          foreach (var substring in substrings)
          {
              this.divFiltro.InnerHtml += substring.ToString() + "<br>";
          }
        return plCadena;
    }*/

    #endregion Metodos    
    #region AsignaControles
    protected void IABaseAsginaControles()
    {
        try
        {
            BaseMantListado.lblMensaje = lblMensaje;
            BaseMantListado.gv = gv;

            BaseMantListado.hfOrden = hfOrden;
            BaseMantListado.lblCantidad = lblCantidad;
            BaseMantListado.lblPaginaGrilla = lblPaginaGrilla;
        }
        catch (Exception ex)
        {
            lblMensaje.ForeColor = System.Drawing.Color.Red;
            lblMensaje.Text = ex.Message.ToString();
        }
    }
    #endregion AsignaControles    
    #region Modulo
    protected void Cargar_Modulos()
    {
        try
        {

            CargaComboEjecutores();
            CargaDatosCabecera();

        }
        catch (Exception excp)
        {
            throw excp;
        }
    }
    #endregion Modulo
    #region Procedimientos
    protected void MostrarMensaje(string str_mensaje, bool error)
    {
        //**********************************************************************************************
        //*	 MostrarMensaje : Muestra el  mensaje de avisos.
        //**********************************************************************************************
        lblMensaje.Text = str_mensaje;
        if (error == true)
        {
            lblMensaje.ForeColor = Color.Red;
        }
        else
        {
            lblMensaje.ForeColor = Color.Green;
        }

        //upBotonera.Update();

    }
    protected void limpiarMensaje()
    {
        //**********************************************************************************************
        //*	 limpiarMensaje : limpia mensaje de avisos.
        //**********************************************************************************************
        lblMensaje.Text = "";
        lblMensaje.ForeColor = Color.Red;

    }
    #endregion Procedimientos


    protected void cmb_CodTipoGestion_SelectedIndexChanged(object sender, EventArgs e)
    {
        CargaCombo_Cartas();
    }
}