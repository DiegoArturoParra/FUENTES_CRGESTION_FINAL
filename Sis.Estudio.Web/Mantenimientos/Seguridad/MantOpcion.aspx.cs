using System;
using System.Drawing;
using System.Text;
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
using System.Collections.Generic;
using Sis.Estudio.Entity;
using Sis.Estudio.Logic.MSSQL.Seguridad;

public partial class Mantenimientos_Seguridad_MantOpcion : System.Web.UI.Page
{
    #region Constructor

    #region Seleccionar
    protected override void Render(System.Web.UI.HtmlTextWriter writer)
    {
        AddRowSelectToGridView(gv);
        AddRowSelectToGridView(gv2);
        AddRowSelectToGridView(gv3);
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
    {   //****************************************************************************************
        //* Nomre       :Page_Load
        //* DescripcioN :
        //****************************************************************************************


        ClientScriptManager cs = Page.ClientScript;
        String cbReference = cs.GetCallbackEventReference("'" + Page.UniqueID + "'", "arg", "ReceiveServerData", "", "ProcessCallBackError", false);
        String callbackScript = "function CallTheServer(arg, context) {" + cbReference + "; }";
        cs.RegisterClientScriptBlock(this.GetType(), "CallTheServer", callbackScript, true);


        btn_REFRESCAR.Focus();
        if (!Page.IsPostBack)
        {
            this.Master.TituloModulo = "Maestro de Menú y Opciones";

            btn_ELIMINAR.Attributes.Add("onClick", "document.getElementById('hdnContinuar').value = confirm('¿Se anulará El registro, ¿Desea continuar?');");
            btn_ELIMINAR2.Attributes.Add("onClick", "document.getElementById('hdnContinuar').value = confirm('¿Se anulará El registro, ¿Desea continuar?');");
            btn_ELIMINAR3.Attributes.Add("onClick", "document.getElementById('hdnContinuar').value = confirm('¿Se anulará El registro, ¿Desea continuar?');");
            Cargar_Modulos();
            Refresca_Grid("1");// 1=Padre, 2=Hijo
        }

    }
    #endregion Constructor

    #region Modulo
    private void Recupera_IdModulo()
    {
        try
        {
            string str_idModulo = "";
            if (Request["idmodulo"] != null)
            {
                str_idModulo = Request["idmodulo"];
                if (Util.fap_EsNumerico(str_idModulo))
                {
                    cmb_MODULO.SelectedValue = str_idModulo;
                }
            }
            else
            {
                return;
            }
        }
        catch (Exception excp)
        {
            //MostrarMensaje(excp.ToString(), true);
            Master.MostrarMensaje(excp.ToString(), TipoMensaje.Error);
        }
    }

    private void Establece_ValoresModulo()
    {
        hd_idmodulo.Value = cmb_MODULO.SelectedValue.ToString();
        hd_desmodulo.Value = cmb_MODULO.SelectedItem.Text.ToString();
    }

    protected void cmb_MODULO_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Establece_ValoresModulo();
            Refresca_Grid("1");
        }
        catch (Exception excp)
        {
            // MostrarMensaje(excp.ToString(), true);
            Master.MostrarMensaje(excp.ToString(), TipoMensaje.Error);
        }

    }
    protected void Cargar_Modulos()
    {
        try
        {
            cmb_MODULO.Items.Clear();
            DataTable dt = new DataTable();
            LoModulo objLoModulo = new LoModulo();
            List<EnModulo> ListEnModulo = new List<EnModulo>();
            EnModulo objEnModulo = new EnModulo();
            objEnModulo.CEmpresa = (String)this.Session["cempresa"];
            ListEnModulo.Add(objEnModulo);
            
            dt = objLoModulo.Lista_TodosLosModulos(ListEnModulo);
                        
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i][0].ToString().Trim();
                lista.Text = dt.Rows[i][1].ToString().Trim();

                cmb_MODULO.Items.Add(lista);
            }
            Establece_ValoresModulo();
        }
        catch (Exception excp)
        {
            //MostrarMensaje(excp.ToString(), true);
            Master.MostrarMensaje(excp.ToString(), TipoMensaje.Error);
        }
    }
    #endregion Modulo

    #region MENU
    #region eventos

    protected void btn_IMPRIMIR_Click(object sender, EventArgs e)
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


    protected void btn_NUEVO_Click(object sender, EventArgs e)
    {
        Master.OcultarMensaje();
    }
    protected void btn_MODIFICAR_Click(object sender, EventArgs e)
    {
        Master.OcultarMensaje();
    }
    protected void btn_ELIMINAR_Click(object sender, EventArgs e)
    {
        //Master.OcultarMensaje();
        //ClearRowsMenu();
        bool continuar;
        bool.TryParse(Request.Form["hdnContinuar"], out continuar);
        if (continuar)
        {
            if (gv.SelectedIndex != -1)
            {
                string str_codigo = gv.SelectedRow.Cells[1].Text.ToString();
                Eliminar(str_codigo);
            }
            else
            {
                Master.MostrarMensaje(Mensaje.M_SELECCIONAR_REGISTRO, TipoMensaje.Advertencia);
                return;
            }
        }
        else
        {
            Master.MostrarMensaje(Mensaje.M_OPERACION_CANCELADA, TipoMensaje.Advertencia);
        }
    }
    protected void btn_REFRESCAR_Click(object sender, EventArgs e)
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
        lbl_TITULOB.Text = "";
        Refresca_Grid("1");
        up_GV.Update();
        up_GV2.Update();
    }

    protected void btn_MenuSubir_Click(object sender, EventArgs e)
    {
        Master.OcultarMensaje();
        ClearRowsOpcion();
        if (gv.SelectedIndex != -1)
        {
            #region Validacion
            int int_Cant = gv.Rows.Count - 1;
            int int_Indice = gv.SelectedRow.RowIndex;

            if (gv.Rows.Count == 1)
            {
                return;
            }
            if (int_Indice >= int_Cant)
            {
                Master.MostrarMensaje("No se puede mover el registro", TipoMensaje.Error);
                return;
            }

            #endregion Validacion            
            string str_codigo = gv.SelectedRow.Cells[1].Text.ToString();
            Menu_MoverNivel(1, int_Indice, str_codigo); // Subir Nivel
        }
        else
        {
            Master.MostrarMensaje(Mensaje.M_SELECCIONAR_REGISTRO, TipoMensaje.Advertencia);
            return;
        }
    }
    protected void btn_MenuBajar_Click(object sender, EventArgs e)
    {
        Master.OcultarMensaje();
        ClearRowsOpcion();
        if (gv.SelectedIndex != -1)
        {
            #region Validacion
            int int_Cant = gv.Rows.Count - 1;
            int int_Indice = gv.SelectedRow.RowIndex;

            if (gv.Rows.Count == 1)
            {
                return;
            }

            if (int_Indice <= 0)
            {
                Master.MostrarMensaje("No se puede mover el registro", TipoMensaje.Error);
                return;
            }
            #endregion Validacion            
            string str_codigo = gv.SelectedRow.Cells[1].Text.ToString();
            Menu_MoverNivel(0, int_Indice, str_codigo); // bajar Nivel
        }
        else
        {
            Master.MostrarMensaje(Mensaje.M_SELECCIONAR_REGISTRO, TipoMensaje.Advertencia);
            return;
        }
    }
    

    #endregion eventos
    #region metodos
    private void Refresca_Grid(string str_TIPO)
    {
        //****************************************************************************************
        //* Nomre       :Refresca_Grid
        //* DescripcioN :
        //****************************************************************************************
        DataTable dt;
        try
        {
            dt = Obtener_Datos(str_TIPO);

            gv.DataSource = dt;
            gv.DataBind();

            if (dt.Rows.Count > 0)
            {
                lblCantidad.Text = "Total: " + dt.Rows.Count.ToString() + " Registros";
                lblPaginaGrilla.Text = "[Registros: " + Convert.ToString((gv.PageIndex * gv.PageSize) + 1) + "-" + Convert.ToString(gv.PageIndex * gv.PageSize + gv.PageSize) + "]";
            }
            else
            {
                lblCantidad.Text = "Total: 0 Registros";
                lblPaginaGrilla.Text = "[Registros: 0-0 ]";
            }

            ClearRowsMenu();
            gv.SelectedIndex = -1;
            gv.EditIndex = -1;
            gv.PageIndex = 0;
            up_GV.Update();


            ClearRowsOpcion();
            gv2.DataBind();
            gv2.SelectedIndex = -1;
            gv2.EditIndex = -1;
            gv2.PageIndex = 0;
            up_GV2.Update();

            gv3.DataBind();
            ClearRowsAccion();
            gv3.SelectedIndex = -1;
            gv3.EditIndex = -1;
            gv3.PageIndex = 0;
            up_GV3.Update();


        }
        catch (Exception ex)
        {
            Master.MostrarMensaje(ex.Message.ToString(), TipoMensaje.Error, ex);
        }
    }
    protected void ClearRowsMenu()
    {
        hd_IdOpcionMenu.Value = "";
    }
    private void Exportar(string Formato)
    {
        try
        {
            string str_Parametros = "";

            string str_tiporeporte = "?tiporerporte=" + Formato;
            
            str_Parametros = str_tiporeporte ;

            string CONFIG = "'resizable = yes, scrollbars = yes, toolbar=no, height = 500, width = 800,left=200,top=100,status=yes, location=no, menubar=no'";
            StringBuilder sb = new StringBuilder();
            sb.Append("<script>var win=window.open('../../Reportes/Seguridad/ReporteOpcionC.aspx" + str_Parametros + "', 'Reporte', " + CONFIG + ");</script>");
            ScriptManager.RegisterStartupScript(this, typeof(Page), "ReporteAccion", sb.ToString(), false);
        }
        catch (Exception excp)
        {
            Master.MostrarMensaje(excp.ToString(), TipoMensaje.Error);
        }
    }

    #endregion metodos
    #region grid
    protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //****************************************************************************************
        //* Nomre       :gv_PageIndexChanging
        //* DescripcioN :
        //****************************************************************************************
        gv.PageIndex = e.NewPageIndex;
        Refresca_Grid("1");
    }
    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //****************************************************************************************
        //* Nomre       :gv_RowDataBound
        //* DescripcioN :
        //****************************************************************************************
        try
        {

            //***
            //ddlPaginaIr.Items.Clear();
            #region paginador
            for (int i = 0; i < gv.PageCount; i++)
            {
                ListItem pageListItem = new ListItem(string.Concat("Página ", i + 1), i.ToString());
                //  ddlPaginaIr.Items.Add(pageListItem);

                if (i == gv.PageIndex)
                    pageListItem.Selected = true;
            }
            #endregion paginador





        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void gv_Sorting(object sender, GridViewSortEventArgs e)
    {
        //****************************************************************************************
        //* Nomre       :gv_Sorting
        //* DescripcioN :
        //****************************************************************************************
        hfOrden.Value = e.SortExpression;
        Refresca_Grid("1");
    }
    protected void ddlPaginado_SelectedIndexChanged(object sender, EventArgs e)
    {
        //****************************************************************************************
        //* Nomre       :ddlPaginado_SelectedIndexChanged
        //* DescripcioN :
        //****************************************************************************************

        Refresca_Grid("1");
    }
    protected void ddlPaginaIr_SelectedIndexChanged(object sender, EventArgs e)
    {
        //****************************************************************************************
        //* Nomre       :ddlPaginaIr_SelectedIndexChanged
        //* DescripcioN :
        //****************************************************************************************
        //gv.PageIndex = Convert.ToInt32(ddlPaginaIr.SelectedValue);
        //Refresca_Grid("1");
    }
    protected void gv_SelectedIndexChanged(object sender, EventArgs e)
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

        hd_IdOpcionMenu.Value = gv.SelectedRow.Cells[1].Text.ToString();

        if (hd_IdOpcionMenu.Value.Length < 1)
        {
            Master.MostrarMensaje("No se ha definido id paso ", TipoMensaje.Advertencia);
        }
        else
        {
            Refresca_MenuHijo(hd_IdOpcionMenu.Value);
            Titulo_OBS();
        }

    }
    #endregion grid
    #region datos
    private DataTable Obtener_Datos(string str_TIPO)
    {
        //****************************************************************************************
        //* Nomre       :Obtener_Datos
        //* DescripcioN :
        //****************************************************************************************        

       
        LoOpcion objLoOpcion = new LoOpcion();

        #region validacion
        string idmodulo = "0";
        if (Util.fap_EsNumerico(cmb_MODULO.SelectedValue.ToString()))
        {
            idmodulo = cmb_MODULO.SelectedValue.ToString();
        }
        #endregion validacion
        List<EnOpcion> ListEnOpcion = new List<EnOpcion>();
        EnOpcion objEnOpcion = new EnOpcion();

        objEnOpcion.CEmpresa =  (String)this.Session["cempresa"];
        objEnOpcion.IdModulo =  idmodulo;
        objEnOpcion.TipoOpcion = str_TIPO;

        ListEnOpcion.Add(objEnOpcion);

        DataTable dt = null;
        try
        {
            dt = objLoOpcion.Listado_Opcion(ListEnOpcion);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return dt;
    }
    private void Eliminar(string str_cod1)
    {
        //****************************************************************************************
        //* Nomre       : Grabar
        //* DescripcioN :
        //****************************************************************************************
        LoOpcion objLoOpcion = new LoOpcion();

        string msg = "";
        string Exito = "";
        try
        {
            #region Carga_Variable

            List<EnOpcion> ListEnOpcion = new List<EnOpcion>();
            EnOpcion objEnOpcion = new EnOpcion();

            objEnOpcion.IdModulo = hd_idmodulo.Value;
            objEnOpcion.CEmpresa = (String)this.Session["cempresa"];
            objEnOpcion.IdOpcion = str_cod1;

            ListEnOpcion.Add(objEnOpcion);
            #endregion Carga_Variable
            msg = objLoOpcion.Elimina_OpcionMenu(ListEnOpcion);

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
            Master.MostrarMensaje("Se Elimino Correctamente.", TipoMensaje.Exito);
            Refresca_Grid("1");
            up_GV.Update();
        }
    }
    private void Menu_MoverNivel(int int_Tipo, int int_Indice, string str_IdOpcion)
    {
        LoOpcion objLoOpcion = new LoOpcion();
        string msg = "";
        string Exito = "";
        try
        {
            #region Carga_Variable
            List<EnOpcion> ListEnOpcion = new List<EnOpcion>();
            EnOpcion objEnOpcion = new EnOpcion();
            objEnOpcion.IdModulo = hd_idmodulo.Value;
            objEnOpcion.CEmpresa = (String)this.Session["cempresa"];
            objEnOpcion.IdOpcion = str_IdOpcion;
            ListEnOpcion.Add(objEnOpcion);
            #endregion Carga_Variable
            #region MoverNivel
            if (int_Tipo == 1)  // SUBIR
            {
                msg = objLoOpcion.Menu_SubirNivel(ListEnOpcion);
            }
            else if (int_Tipo == 0)// BAJAR
            {
                msg = objLoOpcion.Menu_BajarNivel(ListEnOpcion);
            }
            #endregion MoverNivel

            if (msg == "") { Exito = "si"; } else { Master.MostrarMensaje(msg, TipoMensaje.Error, msg); Exito = "no"; return; }
            Exito = "si";
        }
        catch (SqlException ex)
        {
            msg = HttpUtility.HtmlEncode(ex.Message);
            Master.MostrarMensaje(msg, TipoMensaje.Error);
            Exito = "no";
        }
        catch (Exception ex)
        {
            msg = HttpUtility.HtmlEncode(ex.Message);
            Master.MostrarMensaje(msg, TipoMensaje.Error);
            Exito = "no";
        }
        if (Exito == "si")
        {            
            Refresca_Grid("1");

            #region SeleccionarIndice
            if (int_Tipo == 1)  // SUBIR
            {
                gv.SelectRow(int_Indice + 1);
            }
            else if (int_Tipo == 0)// BAJAR
            {
                gv.SelectRow(int_Indice - 1);
            }
            #endregion SeleccionarIndice
            //up_GV2.Update();
        }
    }
    #endregion datos
    #endregion MENU

    #region OPCION
    #region eventos
    protected void btn_NUEVO2_Click(object sender, EventArgs e)
    {
        Master.OcultarMensaje();
    }
    protected void btn_MODIFICAR2_Click(object sender, EventArgs e)
    {
        Master.OcultarMensaje();
    }
    protected void btn_ELIMINAR2_Click(object sender, EventArgs e)
    {
        Master.OcultarMensaje();
        ClearRowsOpcion();
        bool continuar;
        bool.TryParse(Request.Form["hdnContinuar"], out continuar);
        if (continuar)
        {
            if (gv2.SelectedIndex != -1)
            {
                string str_codigo = gv2.SelectedRow.Cells[1].Text.ToString();
                Eliminar2(str_codigo);
            }
            else
            {
                Master.MostrarMensaje(Mensaje.M_SELECCIONAR_REGISTRO, TipoMensaje.Advertencia);
                return;
            }
        }
        else
        {
            Master.MostrarMensaje(Mensaje.M_OPERACION_CANCELADA, TipoMensaje.Advertencia);
        }
    }
    protected void btn_REFRESCAR2_Click(object sender, EventArgs e)
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
        hd_IdOpcionMenu.Value = gv.SelectedRow.Cells[1].Text.ToString();
        if (hd_IdOpcionMenu.Value.Length < 1)
        {
            Master.MostrarMensaje("No se ha definido id paso ", TipoMensaje.Advertencia);
        }
        else
        {
            Refresca_MenuHijo(hd_IdOpcionMenu.Value);
            Titulo_OBS();
        }
    }
    
    protected void btn_OpcionSubir_Click(object sender, EventArgs e)
    {
        Master.OcultarMensaje();
        ClearRowsOpcion();
        if (gv2.SelectedIndex != -1)
        {
            #region Validacion
            int int_Cant = gv2.Rows.Count -1;
            int int_Indice = gv2.SelectedRow.RowIndex;

            if (gv2.Rows.Count == 1)
            {
                return;
            }
            if (int_Indice >= int_Cant)
            {
                Master.MostrarMensaje("No se puede mover el registro",TipoMensaje.Error);
                return;
            }

            #endregion Validacion
            string str_codigo = gv2.SelectedRow.Cells[1].Text.ToString();            
            Opcion_MoverNivel(1, int_Indice, str_codigo); // Subir Nivel
        }
        else
        {
            Master.MostrarMensaje(Mensaje.M_SELECCIONAR_REGISTRO, TipoMensaje.Advertencia);
            return;
        }
    }
    protected void btn_OpcionBajar_Click(object sender, EventArgs e)
    {
        Master.OcultarMensaje();
        ClearRowsOpcion();
        if (gv2.SelectedIndex != -1)
        {
            #region Validacion
            int int_Cant = gv2.Rows.Count - 1;
            int int_Indice = gv2.SelectedRow.RowIndex;

            if (gv2.Rows.Count == 1)
            {
                return;
            }

            if (int_Indice <= 0)
            {
                Master.MostrarMensaje("No se puede mover el registro", TipoMensaje.Error);
                return;
            }
            #endregion Validacion
            string str_codigo = gv2.SelectedRow.Cells[1].Text.ToString();
            Opcion_MoverNivel(0, int_Indice, str_codigo); // bajar Nivel
        }
        else
        {
            Master.MostrarMensaje(Mensaje.M_SELECCIONAR_REGISTRO, TipoMensaje.Advertencia);
            return;
        }
    }
    #endregion eventos
    #region metodos
    protected void Refresca_MenuHijo(string str_Cod)
    {
        DataTable dt = new DataTable();
        LoOpcion objLoOpcion = new LoOpcion();
        try
        {
            #region Carga_Variables
           
            List<EnOpcion> ListEnOpcion = new List<EnOpcion>();
            EnOpcion objEnOpcion = new EnOpcion();

            objEnOpcion.CEmpresa = (String)this.Session["cempresa"];
            objEnOpcion.IdModulo = hd_idmodulo.Value;
            objEnOpcion.TipoOpcion =  "2";
            objEnOpcion.IdOpcionPadre =  str_Cod;

            ListEnOpcion.Add(objEnOpcion);
            #endregion Carga_Variables

            dt = objLoOpcion.Listado_OpcionHijo(ListEnOpcion);


            gv2.DataSource = dt;
            gv2.DataBind();

            ClearRowsOpcion();
            gv2.SelectedIndex = -1;
            gv2.EditIndex = -1;
            gv2.PageIndex = 0;
            up_GV2.Update();


            gv3.DataBind();
            ClearRowsAccion();
            gv3.SelectedIndex = -1;
            gv3.EditIndex = -1;
            gv3.PageIndex = 0;
            up_GV3.Update();


            if (dt.Rows.Count > 0)
            {
                lblCantidad2.Text = "Total: " + dt.Rows.Count.ToString() + " Registros";
            }
            else
            {
                lblCantidad2.Text = "Total: 0 Registros";
            }
        }
        catch (Exception ex)
        {
            Master.MostrarMensaje(ex.Message.ToString(), TipoMensaje.Error, ex);
        }
    }
    private void Titulo_OBS()
    {
        string str_cantreg = gv2.Rows.Count.ToString();
        string str_des = gv.SelectedRow.Cells[3].Text.ToString();

        lbl_TITULOB.Text = str_cantreg + " Opciones para : " + str_des;
        up_GV2.Update();
    }
    protected void ClearRowsOpcion()
    {

        hd_IdOpcionOpcion.Value = "";
    }
    #endregion metodos
    #region grid
    protected void gv_PageIndexChanging1(object sender, GridViewPageEventArgs e)
    {

    }
    protected void gv_RowDataBound1(object sender, GridViewRowEventArgs e)
    {

        ClientScriptManager cs = Page.ClientScript;


        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.textDecoration='underline'";
            //e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
            //e.Row.Attributes["onclick"] = cs.GetPostBackClientHyperlink(this.gv2, "Select$" + e.Row.RowIndex);

        }
    }

    
    protected void gv_SelectedIndexChanged1(object sender, EventArgs e)
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

        hd_IdOpcionOpcion.Value = gv2.SelectedRow.Cells[1].Text.ToString();


        if (hd_IdOpcionOpcion.Value.Length < 1)
        {
            Master.MostrarMensaje("No se ha definido id paso ", TipoMensaje.Advertencia);
        }
        else
        {
            Refresca_Acciones(hd_IdOpcionOpcion.Value);
            Titulo_Acciones();
        }
    }

    protected void gv_Sorting1(object sender, GridViewSortEventArgs e)
    {

    }
    #endregion grid
    #region datos
    private void Eliminar2(string str_cod1)
    {
        LoOpcion objLoOpcion = new LoOpcion();

        string msg = "";
        string Exito = "";
        try
        {
            #region Carga_Variable


            List<EnOpcion> ListEnOpcion = new List<EnOpcion>();
            EnOpcion objEnOpcion = new EnOpcion();

            objEnOpcion.IdModulo = hd_idmodulo.Value;
            objEnOpcion.CEmpresa = (String)this.Session["cempresa"];
            objEnOpcion.IdOpcion = str_cod1;

            ListEnOpcion.Add(objEnOpcion);
            #endregion Carga_Variable


            msg = objLoOpcion.Elimina_OpcionMenu(ListEnOpcion);
            

            if (msg == "") { Exito = "si"; } else { Master.MostrarMensaje(msg, TipoMensaje.Error, msg); Exito = "no"; return; }

            Exito = "si";
        }
        catch (SqlException ex)
        {
            msg = HttpUtility.HtmlEncode(ex.Message);
            Master.MostrarMensaje(msg, TipoMensaje.Error);
            Exito = "no";
        }
        catch (Exception ex)
        {
            msg = HttpUtility.HtmlEncode(ex.Message);
            Master.MostrarMensaje(msg, TipoMensaje.Error);
            Exito = "no";
        }
        if (Exito == "si")
        {
            Master.MostrarMensaje("Se Elimino Correctamente.", TipoMensaje.Exito);
            Refresca_MenuHijo(hd_IdOpcionMenu.Value.Trim());                      
            up_GV2.Update();
            
        }
    }
    private void Opcion_MoverNivel(int int_Tipo,int int_Indice, string  str_IdOpcion)
    {
        LoOpcion objLoOpcion = new LoOpcion();
        string msg = "";
        string Exito = "";
        try
        {
            #region Carga_Variable
            List<EnOpcion> ListEnOpcion = new List<EnOpcion>();
            EnOpcion objEnOpcion = new EnOpcion();
            objEnOpcion.IdModulo = hd_idmodulo.Value;
            objEnOpcion.CEmpresa = (String)this.Session["cempresa"];
            objEnOpcion.IdOpcion = str_IdOpcion;
            ListEnOpcion.Add(objEnOpcion);
            #endregion Carga_Variable
            #region MoverNivel
            if (int_Tipo == 1)  // SUBIR
            {
                msg = objLoOpcion.Opcion_SubirNivel(ListEnOpcion);
            }
            else if (int_Tipo == 0)// BAJAR
            {
                msg = objLoOpcion.Opcion_BajarNivel(ListEnOpcion);
            }
            #endregion MoverNivel
            
            if (msg == "") { Exito = "si"; } else { Master.MostrarMensaje(msg, TipoMensaje.Error, msg); Exito = "no"; return; }
            Exito = "si";
        }
        catch (SqlException ex)
        {
            msg = HttpUtility.HtmlEncode(ex.Message);
            Master.MostrarMensaje(msg, TipoMensaje.Error);
            Exito = "no";
        }
        catch (Exception ex)
        {
            msg = HttpUtility.HtmlEncode(ex.Message);
            Master.MostrarMensaje(msg, TipoMensaje.Error);
            Exito = "no";
        }
        if (Exito == "si")
        {            
            Refresca_MenuHijo(hd_IdOpcionMenu.Value.Trim());

            #region SeleccionarIndice
            if (int_Tipo == 1)  // SUBIR
            {
                gv2.SelectRow(int_Indice +1);
            }
            else if (int_Tipo == 0)// BAJAR
            {
                gv2.SelectRow(int_Indice - 1);
            }
            #endregion SeleccionarIndice            
            //up_GV2.Update();
        }
    }
    #endregion datos
    #endregion OPCION

    #region ACCION
    #region eventos
    protected void btn_NUEVO3_Click(object sender, EventArgs e)
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
        #region js
        string str_parametro = "?parametro=" + "";
        string str_tipo = "&tipo=0";//0=busqueda con retorno,1= busqueda sin retorno

        string strINI_JS;
        string strFIN_JS;
        string strTamaño;
        string strPos;
        string strScript2;

        strINI_JS = " <script language='javascript'> ";
        strFIN_JS = " </script> ";

        strTamaño = " var ancho = 650;   var alto = 380; ";
        strPos = " xpos=(screen.width/2)-(ancho/2);  ypos=(screen.height/2)-(alto/2); ";

        strScript2 = " win=window.open('../../Consultas/Busquedas/BuscarAccion.aspx" + str_parametro + str_tipo + "','buscar','toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=0,resizable=0,width='+ancho+',height='+alto+',left='+xpos+',top='+ypos+'');";
        strScript2 = strINI_JS + strTamaño + strPos + strScript2 + strFIN_JS;
        ScriptManager.RegisterStartupScript(this, typeof(Page), "win", strScript2.ToString(), false);
        #endregion js
    }
    protected void btn_MODIFICAR3_Click(object sender, EventArgs e)
    {
        Master.OcultarMensaje();
    }
    protected void btn_ELIMINAR3_Click(object sender, EventArgs e)
    {
        Master.OcultarMensaje();
        ClearRowsOpcion();
        bool continuar;
        bool.TryParse(Request.Form["hdnContinuar"], out continuar);
        if (continuar)
        {
            if (gv2.SelectedIndex != -1)
            {
                string str_codigo = gv3.SelectedRow.Cells[1].Text.ToString();
                Eliminar3(str_codigo);
            }
            else
            {
                Master.MostrarMensaje(Mensaje.M_SELECCIONAR_REGISTRO, TipoMensaje.Advertencia);
                return;
            }
        }
        else
        {
            Master.MostrarMensaje(Mensaje.M_OPERACION_CANCELADA, TipoMensaje.Advertencia);
        }
    }
    protected void btn_REFRESCAR3_Click(object sender, EventArgs e)
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
        hd_IdOpcionMenu.Value = gv.SelectedRow.Cells[1].Text.ToString();
        if (hd_IdOpcionMenu.Value.Length < 1)
        {
            Master.MostrarMensaje("No se ha definido id paso ", TipoMensaje.Advertencia);
        }
        else
        {
            Refresca_MenuHijo(hd_IdOpcionMenu.Value);
            Titulo_OBS();
        }
    }
    #endregion eventos
    #region metodos
    protected void Refresca_Acciones(string str_Cod)
    {
        LoOpcion objLoOpcion = new LoOpcion();
        DataTable dt = new DataTable();
        try
        {
            #region Carga_Variables
            List<EnOpcion> ListEnOpcion = new List<EnOpcion>();
            EnOpcion objEnOpcion = new EnOpcion();

            objEnOpcion.CEmpresa =(String)this.Session["cempresa"];
            objEnOpcion.IdModulo = hd_idmodulo.Value;
            objEnOpcion.IdOpcion = str_Cod;

            ListEnOpcion.Add(objEnOpcion);
            #endregion Carga_Variables

            dt = objLoOpcion.Listado_OpcionAccion(ListEnOpcion);
            
            gv3.DataSource = dt;
            gv3.DataBind();

            ClearRowsAccion();
            gv3.SelectedIndex = -1;
            gv3.EditIndex = -1;
            gv3.PageIndex = 0;
            up_GV3.Update();

            if (dt.Rows.Count > 0)
            {
                lblCantidad3.Text = "Total: " + dt.Rows.Count.ToString() + " Registros";
            }
            else
            {
                lblCantidad3.Text = "Total: 0 Registros";
            }
        }
        catch (Exception ex)
        {
            Master.MostrarMensaje(ex.Message.ToString(), TipoMensaje.Error, ex);
        }

    }
    private void Titulo_Acciones()
    {
        string str_cantreg = gv3.Rows.Count.ToString();
        string str_des = gv2.SelectedRow.Cells[4].Text.ToString();

        lblTitulo3.Text = str_cantreg + " Acciones para : " + str_des;
        up_GV3.Update();
    }
    protected void ClearRowsAccion()
    {
        hd_IdOpcionAccion.Value = "";

    }
    #endregion metodos
    #region grid
    protected void gv3_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void gv3_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void gv3_SelectedIndexChanged(object sender, EventArgs e)
    {
        #region Sesion
        string cempresa = (String)this.Session["cempresa"];
        if (cempresa == "" || cempresa == null)
        {
            this.Session.Abandon();
            Response.Redirect("../Login.aspx?rd=0");
            return;
        }
        #endregion Sesion
    }
    protected void gv3_Sorting(object sender, GridViewSortEventArgs e)
    {

    }
    #endregion grid
    #region datos
    private void Grabar_OpcionAccion()
    {
        //****************************************************************************************
        //* Nomre       : Grabar
        //* DescripcioN :
        //****************************************************************************************

        LoOpcion objLoOpcion = new LoOpcion();

        string msg = "";
        string Exito = "";
        try
        {

            #region Carga_Variable

            List<EnOpcion> ListEnOpcion = new List<EnOpcion>();
            EnOpcion objEnOpcion = new EnOpcion();

            objEnOpcion.CEmpresa = ((String)this.Session["cempresa"]);
            objEnOpcion.IdOpcion = hd_IdOpcionOpcion.Value;
            objEnOpcion.IdAccion =  hd_IdAccion.Value;
            objEnOpcion.CodUsuario =  (String)this.Session["codusuario"];

            ListEnOpcion.Add(objEnOpcion);

            #endregion Carga_Variable

            msg = objLoOpcion.Insertar_OpcionAccion(ListEnOpcion);


            if (msg == "") { Exito = "si"; } else { Master.MostrarMensaje(msg, TipoMensaje.Error, msg); Exito = "no"; return; }

            Exito = "si";
        }
        catch (SqlException ex)
        {
            msg = HttpUtility.HtmlEncode(ex.Message);
            Master.MostrarMensaje(msg, TipoMensaje.Error);
            Exito = "no";
        }
        catch (Exception ex)
        {
            msg = HttpUtility.HtmlEncode(ex.Message);
            Master.MostrarMensaje(msg, TipoMensaje.Error);
            Exito = "no";
        }
        if (Exito == "si")
        {
            Master.MostrarMensaje(Mensaje.M_REGISTRO_CORRECTO, TipoMensaje.Exito);

            hd_IdOpcionOpcion.Value = gv2.SelectedRow.Cells[1].Text.ToString();
            Refresca_Acciones(hd_IdOpcionOpcion.Value.Trim());
            up_GV2.Update();
        }
    }
    private void Eliminar3(string str_cod1)
    {
        LoOpcion objLoOpcion = new LoOpcion();
        string msg = "";
        string Exito = "";
        try
        {
            #region Carga_Variable
            
            List<EnOpcion> ListEnOpcion = new List<EnOpcion>();
            EnOpcion objEnOpcion = new EnOpcion();

            objEnOpcion.CEmpresa = (String)this.Session["cempresa"];
            objEnOpcion.idOpcionAccion = str_cod1;

            ListEnOpcion.Add(objEnOpcion);
            #endregion Carga_Variable           
            msg = objLoOpcion.Elimina_OpcionAccion(ListEnOpcion);


            if (msg == "") { Exito = "si"; } else { Master.MostrarMensaje(msg, TipoMensaje.Error, msg); Exito = "no"; return; }

            Exito = "si";
        }
        catch (SqlException ex)
        {
            msg = HttpUtility.HtmlEncode(ex.Message);
            Master.MostrarMensaje(msg, TipoMensaje.Error);
            Exito = "no";
        }
        catch (Exception ex)
        {
            msg = HttpUtility.HtmlEncode(ex.Message);
            Master.MostrarMensaje(msg, TipoMensaje.Error);
            Exito = "no";
        }
        if (Exito == "si")
        {
            Master.MostrarMensaje("Se Elimino Correctamente.", TipoMensaje.Exito);
            hd_IdOpcionOpcion.Value = gv2.SelectedRow.Cells[1].Text.ToString();
            Refresca_Acciones(hd_IdOpcionOpcion.Value.Trim());
            up_GV2.Update();
        }
    }
    #endregion datos

    protected void btn_GrabarAccion_Click(object sender, EventArgs e)
    {
        try
        {
            Grabar_OpcionAccion();
            //Refresca_Acciones(hd_IdOpcionOpcion.Value);
        }
        catch (Exception ex)
        {

            Master.MostrarMensaje(ex.ToString(), TipoMensaje.Error);

        }
    }
    protected void btn_SALIR_Click(object sender, EventArgs e)
    {
        Response.Redirect("../../Default.aspx");
    }
    #endregion ACCION


}