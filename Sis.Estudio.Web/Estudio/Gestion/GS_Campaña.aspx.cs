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


public partial class Estudio_Gestion_GS_Campaña : System.Web.UI.Page
{
    #region Declaraciones
    private string PaginaDetalle = "GS_CampañaDetalle.aspx";
    private const string PaginaRetorno = "";
    #endregion  Declaraciones
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
            this.Master.TituloModulo = "Campañas";
            btnGrabar.Attributes.Add("onClick", "document.getElementById('hdnContinuar').value = confirm('Los datos se guardarán, ¿Desea continuar?');");
            //btnProcesar.Attributes.Add("onClick", "document.getElementById('hdnContinuar').value = confirm('¿Se Autorizará El efectivo, ¿Desea continuar?');");
            InicioOperacion();
            Cargar_Modulos();
            //RefrescarGrid();
            #region accesos
            //Accesos();
            #endregion accesos
            //ConfiguracionInicial();
            cargagrillavacia();
        }
        //upBotonera.Update();
    }
    #endregion Eventos_Form
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


    protected void cargagrillavacia()
    {
        DataTable dt = new DataTable();
        try
        {
            #region Carga_Variables
            LoGS_ClaseGestionesxTipoGestion objLoGS_ClaseGestionesxTipoGestion = new LoGS_ClaseGestionesxTipoGestion();
            EnGS_ClaseGestionesxTipoGestion objEnGS_ClaseGestionesxTipoGestion = new EnGS_ClaseGestionesxTipoGestion();
            List<EnGS_ClaseGestionesxTipoGestion> ListEnGS_ClaseGestionesxTipoGestion = new List<EnGS_ClaseGestionesxTipoGestion>();

            objEnGS_ClaseGestionesxTipoGestion.CodClaseGestion = "0";

            ListEnGS_ClaseGestionesxTipoGestion.Add(objEnGS_ClaseGestionesxTipoGestion);

            #endregion Carga_Variables

            dt = objLoGS_ClaseGestionesxTipoGestion.GS_ClaseGestionesxTipoGestion_Lista(ListEnGS_ClaseGestionesxTipoGestion);

            gv2.DataSource = dt;
            gv2.DataBind();


            //*** cargando el valor de los check en la grilla ****//
            /*
            foreach (GridViewRow row in gv.Rows)
            {
                Int32 chk = Convert.ToInt32((row.Cells[2].Text));

                if (chk == 1)
                {
                    ((CheckBox)row.FindControl("chkPermiso")).Checked = true;
                }

                if (chk == 0)
                {
                    ((CheckBox)row.FindControl("chkPermiso")).Checked = false;
                }

            }
            */
            //*****************************************************//


        }
        catch (Exception ex)
        {
            Master.MostrarMensaje(ex.Message.ToString(), TipoMensaje.Error, ex);
        }
    }











    #endregion ToolBar
    #region Limpiar_Filtro

    #endregion Limpiar_Filtro
    #region Datos

    private void RefrescarGrid()
    {
        DataTable DT_Datos = new DataTable();

        LoGS_Campaña objLoGS_Campaña = new LoGS_Campaña();
        EnGS_Campaña objEnGS_Campaña = new EnGS_Campaña();
        List<EnGS_Campaña> ListEnGS_Campaña = new List<EnGS_Campaña>();


        objEnGS_Campaña.nEmpresa = (String)this.Session["cempresa"];
        objEnGS_Campaña.Dias_deuda = txt_dias_deuda.Text.Trim();

        objEnGS_Campaña.Capital = txt_capital.Text.ToString();
        objEnGS_Campaña.SaldoCapital = txt_saldo_capital.Text.ToString();

        objEnGS_Campaña.CodCalificacionSBS = cmb_CalificacionSBS.SelectedValue.ToString().Trim();
        objEnGS_Campaña.CodEstadoDir = cmb_EstadoDir.SelectedValue.ToString().Trim();

        objEnGS_Campaña.condicion_dias = cmb_condicion_dias.SelectedValue.ToString().Trim();
        objEnGS_Campaña.condicion_capital = cmb_condicion_capital.SelectedValue.ToString().Trim();
        objEnGS_Campaña.condicion_saldocapital = cmb_condicion_saldocapital.SelectedValue.ToString().Trim();

        ListEnGS_Campaña.Add(objEnGS_Campaña);

        try
        {
            DT_Datos = objLoGS_Campaña.GS_Campaña_Lista(ListEnGS_Campaña);
            gv.DataSource = DT_Datos;
            gv.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }


    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        RefrescarGrid();
    }

    protected void btnGrabar_Click(object sender, EventArgs e)
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

        //*** recorre la grilla de ejecutado para validar que haya elegido minimo uno ****//

        string marco = "";

        foreach (GridViewRow row in gv2.Rows)
        {
            //Int32 chk = Convert.ToInt32((row.Cells[2].Text));

            if (((CheckBox)row.FindControl("chkPermiso")).Checked == true)
            {
                marco = "S";
            }

        }

        if (marco == "")
        {
            Master.MostrarMensaje("Deje seleccionar como minimo un registro", TipoMensaje.Advertencia);
        }
        
        //*****************************************************//

        //*** recorre la grilla de detalle para validar que haya registros ****//

        int cantidad_detalle = 0;

        foreach (GridViewRow row in gv.Rows)
        {

            cantidad_detalle = cantidad_detalle + 1;
        }

        if (cantidad_detalle == 0)
        {
            Master.MostrarMensaje("Debe seleccionar un detalle en el resultado como minimo", TipoMensaje.Advertencia);
        }

        //*****************************************************//

        //**** accion de proceso *********//
        if (marco == "S" && cantidad_detalle > 0)
        {

            //**************** graba cabecera *********//
            bool continuar;
            bool.TryParse(Request.Form["hdnContinuar"], out continuar);
            if (continuar)
            {
                        //*** graba ***//
                        string str_Id = "";
                        string msg = "";
                        string Exito = "";
                        LoGS_Campaña ObjLoGS_Campaña = new LoGS_Campaña();
                        try
                        {
                            #region Cargar_Variables
                            EnGS_Campaña ObjEnGS_Campaña = new EnGS_Campaña();
                            List<EnGS_Campaña> ListEnGS_Campaña = new List<EnGS_Campaña>();

                            ObjEnGS_Campaña.desc_campaña = txt_desc_campaña.Text.Trim().ToString();
                            ObjEnGS_Campaña.condicion_campaña = txt_condicion_campaña.Text.Trim().ToString();
                            ObjEnGS_Campaña.nEmpresa = (String)this.Session["cempresa"];
                            ObjEnGS_Campaña.CodUsuario = (String)this.Session["codusuario"];



                            ListEnGS_Campaña.Add(ObjEnGS_Campaña);
                            #endregion Cargar_Variables
                            List<EnTransaccion> RetornoT = ObjLoGS_Campaña.GS_Campaña_INS(ListEnGS_Campaña);
                            msg = RetornoT[0].MENSAJE.ToString();
                            str_Id = RetornoT[0].ID.ToString();


                                            //**** ejecuta inserts ****//
                                        LoGS_Gestion_Cobranza ObjLoGS_Gestion_Cobranza = new LoGS_Gestion_Cobranza();
                                        EnGS_Gestion_Cobranza ObjEnGS_Gestion_Cobranza = new EnGS_Gestion_Cobranza();
                                        List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza = new List<EnGS_Gestion_Cobranza>();

                                            //**** recorre el tipo gestion *****//
                                            foreach (GridViewRow row in gv2.Rows)
                                            {
                                                Int32 CodTipoGestion = 0;

                                                if (((CheckBox)row.FindControl("chkPermiso")).Checked == true)
                                                {
                                                    CodTipoGestion = Convert.ToInt32((row.Cells[0].Text));

                                                    //***** se recorre el detalle de la grilla ***//
                                                    foreach (GridViewRow rowDetalle in gv.Rows)
                                                    {
                                                        Int32 IdRegProductos = 0;

                                                        IdRegProductos = Convert.ToInt32((rowDetalle.Cells[3].Text));

                                                        //***** se realiza el insert ***//
                                                        ObjEnGS_Gestion_Cobranza.IdReg = IdRegProductos.ToString();
                                                        ObjEnGS_Gestion_Cobranza.CodTipoGestion = CodTipoGestion.ToString();
                                                        ObjEnGS_Gestion_Cobranza.nEmpresa = (String)this.Session["cempresa"];
                                                        ObjEnGS_Gestion_Cobranza.CodUsuario = (String)this.Session["codusuario"];
                                                        ObjEnGS_Gestion_Cobranza.id_campaña = str_Id;


                                                        ListEnGS_Gestion_Cobranza.Add(ObjEnGS_Gestion_Cobranza);
                                                        List<EnTransaccion> RetornoT2 = ObjLoGS_Gestion_Cobranza.GS_Campaña_SubTarea_INS(ListEnGS_Gestion_Cobranza);
                                                        //******************************//

                                                    }
                                                    //********************************************//

                                                }

                                            }
                                            //*******************************//
                                            //***********************//






                            if (msg == "exito") { Exito = FlagsPrograma.FLG_VALOREXITOSI; } else { Master.MostrarMensaje(msg, TipoMensaje.Error, msg); Exito = FlagsPrograma.FLG_VALOREXITONO; return; }
                        }
                        catch (SqlException ex)
                        {
                            msg = HttpUtility.HtmlEncode(ex.Message);
                            Exito = FlagsPrograma.FLG_VALOREXITONO;
                        }
                        catch (Exception ex)
                        {
                            msg = HttpUtility.HtmlEncode(ex.Message);
                            Exito = FlagsPrograma.FLG_VALOREXITONO;
                        }
                        if (Exito == FlagsPrograma.FLG_VALOREXITOSI)
                        {
                            Master.MostrarMensaje(Mensaje.M_PROCESO_CORRECTO, TipoMensaje.Exito);
                        }

                        //************//






            }
            else
            {
                Master.MostrarMensaje("La operación se cancelo", TipoMensaje.Advertencia);

            }


            //*****************************************//




        }

        //********************************//


    }

    #endregion Datos
    #region Metodos

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
    #endregion Metodos
    #region UpdatePanel

    #endregion UpdatePanel
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
    #region AccesosAccion

    #endregion AccesosAccion

    #region Modulo

    protected void Cargar_Modulos()
    {
        try
        {

            CargaCalificacionSBS();
            CargaEstadoDir();

        }
        catch (Exception excp)
        {
            throw excp;
        }
    }
    #endregion Modulo




    protected void CargaCalificacionSBS()
    {
        DataTable dt = new DataTable();
        LoGS_Campaña objLoGS_Campaña = new LoGS_Campaña();
        try
        {
            EnGS_Campaña objEnGS_Campaña = new EnGS_Campaña();
            cmb_CalificacionSBS.Items.Clear();

            dt = objLoGS_Campaña.GS_CalificacionSBS_Combo();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["CodCalificacionSBS"].ToString().Trim();
                lista.Text = dt.Rows[i]["CalificacionSBS"].ToString().Trim();
                cmb_CalificacionSBS.Items.Add(lista);
            }
        }
        catch (Exception excp)
        {
            throw excp;
        }
    }

    protected void CargaEstadoDir()
    {
        DataTable dt = new DataTable();
        LoGS_Campaña objLoGS_Campaña = new LoGS_Campaña();
        try
        {
            EnGS_Campaña objEnGS_Campaña = new EnGS_Campaña();
            cmb_EstadoDir.Items.Clear();

            dt = objLoGS_Campaña.GS_EstadoDir_Combo();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["CodEstadoDir"].ToString().Trim();
                lista.Text = dt.Rows[i]["Descrip"].ToString().Trim();
                cmb_EstadoDir.Items.Add(lista);
            }
        }
        catch (Exception excp)
        {
            throw excp;
        }
    }

    protected void InicioOperacion()
    {
        //****************************************************************************************
        //* Nomre       : InicioOperacion
        //* DescripcioN :
        //****************************************************************************************

        try
        {


        }
        catch (Exception excp)
        {
            Master.MostrarMensaje(excp.Message.ToString(), TipoMensaje.Error);

        }

    }


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













    protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv.PageIndex = e.NewPageIndex;
        RefrescarGrid();
    }
}