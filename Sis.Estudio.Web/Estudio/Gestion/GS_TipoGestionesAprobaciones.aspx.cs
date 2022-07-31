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


public partial class Estudio_Gestion_GS_TipoGestionesAprobaciones : System.Web.UI.Page
{
    #region Declaraciones
    private string PaginaDetalle = "";
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
            this.Master.TituloModulo = "Configurar Aprobaciones de Action Plans";
            //btnDesactivar.Attributes.Add("onClick", "document.getElementById('hdnContinuar').value = confirm('¿Se desactivará El registro, ¿Desea continuar?');");
            //btnProcesar.Attributes.Add("onClick", "document.getElementById('hdnContinuar').value = confirm('¿Se Autorizará El efectivo, ¿Desea continuar?');");
            InicioOperacion();
            Cargar_Modulos();
            //RefrescarGrid();
            #region accesos
            //Accesos();
            #endregion accesos
            //ConfiguracionInicial();

            CargaComboJerarquiaA();
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

    #endregion ToolBar
    #region Limpiar_Filtro

    #endregion Limpiar_Filtro
    #region Datos



    protected void CargaComboJerarquiaA()
    {
        DataTable dt = new DataTable();
        LoGS_JerarquiaA objLoGS_JerarquiaA = new LoGS_JerarquiaA();
        try
        {
            EnGS_JerarquiaA objEnGS_JerarquiaA = new EnGS_JerarquiaA();
            List<EnGS_JerarquiaA> ListEnGS_JerarquiaA = new List<EnGS_JerarquiaA>();
            cmb_JerarquiaA.Items.Clear();

            objEnGS_JerarquiaA.nempresa = (String)this.Session["cempresa"];

            ListEnGS_JerarquiaA.Add(objEnGS_JerarquiaA);

            dt = objLoGS_JerarquiaA.GS_JerarquiaA_Combo(ListEnGS_JerarquiaA);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["cod_jerarquiaA"].ToString().Trim();
                lista.Text = dt.Rows[i]["desc_jerarquiaA"].ToString().Trim();
                cmb_JerarquiaA.Items.Add(lista);
            }

        }
        catch (Exception excp)
        {
            throw excp;
        }
    }

    protected void CargaComboJerarquiaB()
    {
        DataTable dt = new DataTable();
        LoGS_JerarquiaB objLoGS_JerarquiaB = new LoGS_JerarquiaB();
        try
        {
            EnGS_JerarquiaB objEnGS_JerarquiaB = new EnGS_JerarquiaB();
            List<EnGS_JerarquiaB> ListEnGS_JerarquiaB = new List<EnGS_JerarquiaB>();
            cmb_JerarquiaB.Items.Clear();


            objEnGS_JerarquiaB.cod_jerarquiaA = cmb_JerarquiaA.SelectedValue.ToString();
            objEnGS_JerarquiaB.nempresa = (String)this.Session["cempresa"];

            ListEnGS_JerarquiaB.Add(objEnGS_JerarquiaB);


            dt = objLoGS_JerarquiaB.GS_JerarquiaB_Combo(ListEnGS_JerarquiaB);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["cod_jerarquiaB"].ToString().Trim();
                lista.Text = dt.Rows[i]["desc_jerarquiaB"].ToString().Trim();
                cmb_JerarquiaB.Items.Add(lista);
            }
        }
        catch (Exception excp)
        {
            throw excp;
        }
    }

    protected void CargaComboJerarquiaC()
    {
        DataTable dt = new DataTable();
        LoGS_JerarquiaC objLoGS_JerarquiaC = new LoGS_JerarquiaC();
        try
        {
            EnGS_JerarquiaC objEnGS_JerarquiaC = new EnGS_JerarquiaC();
            List<EnGS_JerarquiaC> ListEnGS_JerarquiaC = new List<EnGS_JerarquiaC>();
            cmb_JerarquiaC.Items.Clear();


            objEnGS_JerarquiaC.cod_jerarquiaB = cmb_JerarquiaB.SelectedValue.ToString();
            objEnGS_JerarquiaC.nempresa = (String)this.Session["cempresa"];

            ListEnGS_JerarquiaC.Add(objEnGS_JerarquiaC);


            dt = objLoGS_JerarquiaC.GS_JerarquiaC_Combo(ListEnGS_JerarquiaC);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["cod_jerarquiaC"].ToString().Trim();
                lista.Text = dt.Rows[i]["desc_jerarquiaC"].ToString().Trim();
                cmb_JerarquiaC.Items.Add(lista);
            }
        }
        catch (Exception excp)
        {
            throw excp;
        }
    }

    protected void CargaComboJerarquiaB_consulta(string cod_JerarquiaA)
    {
        DataTable dt = new DataTable();
        LoGS_JerarquiaB objLoGS_JerarquiaB = new LoGS_JerarquiaB();
        try
        {
            EnGS_JerarquiaB objEnGS_JerarquiaB = new EnGS_JerarquiaB();
            List<EnGS_JerarquiaB> ListEnGS_JerarquiaB = new List<EnGS_JerarquiaB>();
            cmb_JerarquiaB.Items.Clear();


            objEnGS_JerarquiaB.cod_jerarquiaA = cod_JerarquiaA;
            objEnGS_JerarquiaB.nempresa = (String)this.Session["cempresa"];

            ListEnGS_JerarquiaB.Add(objEnGS_JerarquiaB);


            dt = objLoGS_JerarquiaB.GS_JerarquiaB_Combo(ListEnGS_JerarquiaB);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["cod_jerarquiaB"].ToString().Trim();
                lista.Text = dt.Rows[i]["desc_jerarquiaB"].ToString().Trim();
                cmb_JerarquiaB.Items.Add(lista);
            }
        }
        catch (Exception excp)
        {
            throw excp;
        }
    }

    protected void CargaComboJerarquiaC_consulta(string cod_JerarquiaB)
    {
        DataTable dt = new DataTable();
        LoGS_JerarquiaC objLoGS_JerarquiaC = new LoGS_JerarquiaC();
        try
        {
            EnGS_JerarquiaC objEnGS_JerarquiaC = new EnGS_JerarquiaC();
            List<EnGS_JerarquiaC> ListEnGS_JerarquiaC = new List<EnGS_JerarquiaC>();
            cmb_JerarquiaC.Items.Clear();


            objEnGS_JerarquiaC.cod_jerarquiaB = cod_JerarquiaB;
            objEnGS_JerarquiaC.nempresa = (String)this.Session["cempresa"];

            ListEnGS_JerarquiaC.Add(objEnGS_JerarquiaC);


            dt = objLoGS_JerarquiaC.GS_JerarquiaC_Combo(ListEnGS_JerarquiaC);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["cod_jerarquiaC"].ToString().Trim();
                lista.Text = dt.Rows[i]["desc_jerarquiaC"].ToString().Trim();
                cmb_JerarquiaC.Items.Add(lista);
            }
        }
        catch (Exception excp)
        {
            throw excp;
        }
    }


    private void RefrescarGridNivelA()
    {
        this.Master.OcultarMensaje();

        DataTable DT_Datos = new DataTable();


        LoGS_TipoGestiones objLoGS_TipoGestiones = new LoGS_TipoGestiones();
        EnGS_TipoGestiones objEnGS_TipoGestiones = new EnGS_TipoGestiones();
        List<EnGS_TipoGestiones> ListEnGS_TipoGestiones = new List<EnGS_TipoGestiones>();


        objEnGS_TipoGestiones.nempresa = (String)this.Session["cempresa"];
        objEnGS_TipoGestiones.Nivel ="A";
        objEnGS_TipoGestiones.Cod_Jerarquia = cmb_JerarquiaA.SelectedValue.ToString();


        ListEnGS_TipoGestiones.Add(objEnGS_TipoGestiones);

        try
        {
            DT_Datos = objLoGS_TipoGestiones.GS_TipoGestiones_Aprob_Lista(ListEnGS_TipoGestiones);
            gv.DataSource = DT_Datos;
            gv.DataBind();

            /// carga checks ////
            foreach (GridViewRow row in gv.Rows)
            {

                if (row.Cells[9].Text == "1") //aprobacion
                {
                    ((CheckBox)row.FindControl("chkPermiso")).Checked = true;
                }

                if (row.Cells[10].Text == "1") //correo
                {
                    ((CheckBox)row.FindControl("chkPermiso2")).Checked = true;
                }
            }
            ////////////////////
            


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
    private void RefrescarGridNivelB()
    {
        this.Master.OcultarMensaje();

        DataTable DT_Datos = new DataTable();


        LoGS_TipoGestiones objLoGS_TipoGestiones = new LoGS_TipoGestiones();
        EnGS_TipoGestiones objEnGS_TipoGestiones = new EnGS_TipoGestiones();
        List<EnGS_TipoGestiones> ListEnGS_TipoGestiones = new List<EnGS_TipoGestiones>();


        objEnGS_TipoGestiones.nempresa = (String)this.Session["cempresa"];
        objEnGS_TipoGestiones.Nivel = "B";
        objEnGS_TipoGestiones.Cod_Jerarquia = cmb_JerarquiaB.SelectedValue.ToString();



        ListEnGS_TipoGestiones.Add(objEnGS_TipoGestiones);

        try
        {
            DT_Datos = objLoGS_TipoGestiones.GS_TipoGestiones_Aprob_Lista(ListEnGS_TipoGestiones);
            gv.DataSource = DT_Datos;
            gv.DataBind();

            /// carga checks ////
            foreach (GridViewRow row in gv.Rows)
            {

                if (row.Cells[9].Text == "1") //aprobacion
                {
                    ((CheckBox)row.FindControl("chkPermiso")).Checked = true;
                }

                if (row.Cells[10].Text == "1") //correo
                {
                    ((CheckBox)row.FindControl("chkPermiso2")).Checked = true;
                }
            }
            ////////////////////

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
    private void RefrescarGridNivelC()
    {
        this.Master.OcultarMensaje();

        DataTable DT_Datos = new DataTable();


        LoGS_TipoGestiones objLoGS_TipoGestiones = new LoGS_TipoGestiones();
        EnGS_TipoGestiones objEnGS_TipoGestiones = new EnGS_TipoGestiones();
        List<EnGS_TipoGestiones> ListEnGS_TipoGestiones = new List<EnGS_TipoGestiones>();


        objEnGS_TipoGestiones.nempresa = (String)this.Session["cempresa"];
        objEnGS_TipoGestiones.Nivel = "C";
        objEnGS_TipoGestiones.Cod_Jerarquia = cmb_JerarquiaC.SelectedValue.ToString();



        ListEnGS_TipoGestiones.Add(objEnGS_TipoGestiones);

        try
        {
            DT_Datos = objLoGS_TipoGestiones.GS_TipoGestiones_Aprob_Lista(ListEnGS_TipoGestiones);
            gv.DataSource = DT_Datos;
            gv.DataBind();

            /// carga checks ////
            foreach (GridViewRow row in gv.Rows)
            {

                if (row.Cells[9].Text == "1") //aprobacion
                {
                    ((CheckBox)row.FindControl("chkPermiso")).Checked = true;
                }

                if (row.Cells[10].Text == "1") //correo
                {
                    ((CheckBox)row.FindControl("chkPermiso2")).Checked = true;
                }
            }
            ////////////////////

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





    
    private void Desactivar(string str_cod1)
    {
        /*

        //****************************************************************************************
        //* Nomre       : Grabar
        //* DescripcioN :
        //****************************************************************************************
        LoGS_Gestion_Cobranza objLoGS_Gestion_Cobranza = new LoGS_Gestion_Cobranza();

        string msg = "";
        string Exito = "";
        try
        {
            #region Carga_Variable

            List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza = new List<EnGS_Gestion_Cobranza>();
            EnGS_Gestion_Cobranza objEnGS_Gestion_Cobranza = new EnGS_Gestion_Cobranza();

            objEnGS_Gestion_Cobranza.IdReg_Gestion_Cobranza = str_cod1;
            objEnGS_Gestion_Cobranza.Id_estado_gestion_cobranza = "4";
            objEnGS_Gestion_Cobranza.CodUsuario = (String)this.Session["codusuario"];

            ListEnGS_Gestion_Cobranza.Add(objEnGS_Gestion_Cobranza);
            #endregion Carga_Variable
            msg = objLoGS_Gestion_Cobranza.GS_Gestion_Cobranza_UPD_Estado(ListEnGS_Gestion_Cobranza);

            if (msg == "exito") { Exito = FlagsPrograma.FLG_VALOREXITOSI; } else { Master.MostrarMensaje(msg, TipoMensaje.Error, msg); Exito = FlagsPrograma.FLG_VALOREXITONO; return; }

            Exito = FlagsPrograma.FLG_VALOREXITOSI;
        }
        catch (SqlException ex)
        {
            msg = HttpUtility.HtmlEncode(ex.Message);
            Master.MostrarMensaje(msg, TipoMensaje.Error);
            Exito = FlagsPrograma.FLG_VALOREXITONO;
        }
        catch (Exception ex)
        {
            msg = HttpUtility.HtmlEncode(ex.Message);
            Master.MostrarMensaje(msg, TipoMensaje.Error);
            Exito = FlagsPrograma.FLG_VALOREXITONO;

        }
        if (Exito == FlagsPrograma.FLG_VALOREXITOSI)
        {
            Master.MostrarMensaje(Mensaje.M_DESACTIVACION_CORRECTA, TipoMensaje.Exito);
            //Refresca_Grid("1");
            RefrescarGrid();
            //up_GV.Update();
        }


        */
    }








    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        /*
        Master.OcultarMensaje();
        limpiarMensaje();

        gv.PageIndex = 0;
        */
        //RefrescarGrid();
    }


    /*
    private void Procesar(string str_n_anio_cier, string str_n_mes_cier)
    {
        //****************************************************************************************
        //* Nomre       : Grabar
        //* DescripcioN :
        //****************************************************************************************
        LoCierre objLoCierre = new LoCierre();

        string msg = "";
        string Exito = "";
        try
        {
            #region Carga_Variable

            List<EnCierre> ListEnCierre = new List<EnCierre>();
            EnCierre objEnCierre = new EnCierre();

            objEnCierre.vsw = "0";
            objEnCierre.n_anio_cier = str_n_anio_cier;
            objEnCierre.n_mes_cier = str_n_mes_cier;
            objEnCierre.c_codi_pers = "";
            objEnCierre.Codidenest = (String)this.Session["codidenest"]; ;


            ListEnCierre.Add(objEnCierre);
            #endregion Carga_Variable
            msg = objLoCierre.Procesar_Cierre(ListEnCierre);

            if (msg == "") { Exito = FlagsPrograma.FLG_VALOREXITOSI; } else { Master.MostrarMensaje(msg, TipoMensaje.Error, msg); Exito = FlagsPrograma.FLG_VALOREXITONO; return; }

            Exito = FlagsPrograma.FLG_VALOREXITOSI;
        }
        catch (SqlException ex)
        {
            msg = HttpUtility.HtmlEncode(ex.Message);
            Master.MostrarMensaje(msg, TipoMensaje.Error);
            Exito = FlagsPrograma.FLG_VALOREXITONO;
        }
        catch (Exception ex)
        {
            msg = HttpUtility.HtmlEncode(ex.Message);
            Master.MostrarMensaje(msg, TipoMensaje.Error);
            Exito = FlagsPrograma.FLG_VALOREXITONO;

        }
        if (Exito == FlagsPrograma.FLG_VALOREXITOSI)
        {
            Master.MostrarMensaje(Mensaje.M_PROCESO_CORRECTO, TipoMensaje.Exito);
            RefrescarGrid();
        }
    }
    */
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


        }
        catch (Exception excp)
        {
            throw excp;
        }
    }
    #endregion Modulo

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

    protected void btnDesactivar_Click(object sender, EventArgs e)
    {
        this.Master.OcultarMensaje();
        string msg = "";
        string Exito = "";
        try
        {
            //***  ****//

                #region carga_variables
                string CodTipoGestionAprob = "";
                string Aprobacion = "";
                string Correo = "";

                foreach (GridViewRow row in gv.Rows)
                {

                    //CodTipoGestionAprob = row.Cells[11].Text;


                                             
                    if (((CheckBox)row.FindControl("chkPermiso")).Checked == true)
                    {
                        Aprobacion = "1";
                    }else{
                        Aprobacion = "0";
                    }

                    if (((CheckBox)row.FindControl("chkPermiso2")).Checked == true)
                    {
                        Correo = "1";
                    }else{
                        Correo = "0";
                    }



                        try
                        {
                            #region Carga_Variable



                            LoGS_TipoGestiones objLoGS_TipoGestiones = new LoGS_TipoGestiones();
                            EnGS_TipoGestiones objEnGS_TipoGestiones = new EnGS_TipoGestiones();
                            List<EnGS_TipoGestiones> ListEnGS_TipoGestiones = new List<EnGS_TipoGestiones>();


                            objEnGS_TipoGestiones.nempresa = (String)this.Session["cempresa"];
                            objEnGS_TipoGestiones.CodTipoGestionAprob = row.Cells[1].Text.ToString();

                            objEnGS_TipoGestiones.Aprobacion = Aprobacion;
                            objEnGS_TipoGestiones.Correo = Correo;

                            objEnGS_TipoGestiones.CodUsuario = (String)this.Session["codusuario"];



                            ListEnGS_TipoGestiones.Add(objEnGS_TipoGestiones);
                            #endregion Carga_Variable
                            msg = objLoGS_TipoGestiones.GS_TipoGestiones_Aprob_UPD(ListEnGS_TipoGestiones);

                            if (msg == "exito") { Exito = FlagsPrograma.FLG_VALOREXITOSI; } else { Master.MostrarMensaje(msg, TipoMensaje.Error, msg); Exito = FlagsPrograma.FLG_VALOREXITONO; return; }

                            Exito = FlagsPrograma.FLG_VALOREXITOSI;
                        }
                        catch (SqlException ex)
                        {
                            msg = HttpUtility.HtmlEncode(ex.Message);
                            Master.MostrarMensaje(msg, TipoMensaje.Error);
                            Exito = FlagsPrograma.FLG_VALOREXITONO;
                        }


                }


                if (Exito == FlagsPrograma.FLG_VALOREXITOSI)
                {
                    //RefrescarGrid();
                    Master.MostrarMensaje(Mensaje.M_MODIFICO_REGISTRO_CORRECTAMENTE, TipoMensaje.Exito);
                }


                #endregion carga_variables
                #region envia_carta
                #endregion envia_carta

            //*****************************************************//
        }
        catch (Exception ex)
        {
            Master.MostrarMensaje(ex.Message.ToString(), TipoMensaje.Error);
        }
    }
   
    protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        /*
        this.Session["GS_Gestion_Cobranza_PageIndex"] = e.NewPageIndex;
        gv.PageIndex = Convert.ToInt32(this.Session["GS_Gestion_Cobranza_PageIndex"]);
        RefrescarGrid();
         */ 
    }
    protected void gv_PageIndexChanged(object sender, EventArgs e)
    {
        if (gv.Rows.Count > 0)
        {
            gv.SelectedIndex = -1;
        }
    }

    protected void cmb_JerarquiaA_SelectedIndexChanged(object sender, EventArgs e)
    {
        cmb_JerarquiaC.Items.Clear();
        CargaComboJerarquiaB();

        // carga grilla nivel A //
        if (cmb_JerarquiaA.SelectedValue.ToString() == "0")
        {
            Master.MostrarMensaje("Debe seleccionar una Jerarquía del Nivel A.", TipoMensaje.Advertencia);
            return;
        }
        else
        {
            Master.OcultarMensaje();
            limpiarMensaje();
            gv.PageIndex = 0;
            RefrescarGridNivelA();
        }
        /////////////////////////
    }
    protected void cmb_JerarquiaB_SelectedIndexChanged(object sender, EventArgs e)
    {
        CargaComboJerarquiaC();

        // carga grilla nivel B //
        if (cmb_JerarquiaB.SelectedValue.ToString() == "0")
        {
            Master.MostrarMensaje("Debe seleccionar una Jerarquía del Nivel B.", TipoMensaje.Advertencia);
            return;
        }
        else
        {
            Master.OcultarMensaje();
            limpiarMensaje();
            gv.PageIndex = 0;
            RefrescarGridNivelB();
        }
        /////////////////////////
    }
    protected void cmb_JerarquiaC_SelectedIndexChanged(object sender, EventArgs e)
    {
        // carga grilla nivel C //
        if (cmb_JerarquiaC.SelectedValue.ToString() == "0")
        {
            Master.MostrarMensaje("Debe seleccionar una Jerarquía del Nivel C.", TipoMensaje.Advertencia);
            return;
        }
        else
        {
            Master.OcultarMensaje();
            limpiarMensaje();
            gv.PageIndex = 0;
            RefrescarGridNivelC();
        }
        /////////////////////////
    }
}