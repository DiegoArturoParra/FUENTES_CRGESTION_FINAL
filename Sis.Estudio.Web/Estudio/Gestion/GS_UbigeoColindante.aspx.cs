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


public partial class Estudio_Gestion_GS_UbigeoColindante : System.Web.UI.Page
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
            this.Master.TituloModulo = "Ubigeo Colindante";
            btnEliminar.Attributes.Add("onClick", "document.getElementById('hdnContinuar').value = confirm('¿Se eliminará el registro, ¿Desea continuar?');");
            btnAgregar.Attributes.Add("onClick", "document.getElementById('hdnContinuar').value = confirm('¿Se agregará el distrito, ¿Desea continuar?');");
            InicioOperacion();
            Cargar_Modulos();
            //RefrescarGrid();
            #region accesos
            //Accesos();
            #endregion accesos
            //ConfiguracionInicial();

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














    #endregion ToolBar
    #region Limpiar_Filtro

    #endregion Limpiar_Filtro
    #region Datos

    private void RefrescarGrid()
    {
        DataTable DT_Datos = new DataTable();

        LoGS_UbigeoColindante objGS_UbigeoColindate = new LoGS_UbigeoColindante();
        EnGS_UbigeoColindante objEnGS_UbigeoColindante = new EnGS_UbigeoColindante();
        List<EnGS_UbigeoColindante> ListEnGS_UbigeoColindante = new List<EnGS_UbigeoColindante>();

        if (cmb_Distrito_central.SelectedValue == "")
        {
          Master.MostrarMensaje("Debe seleccionar un distrito.", TipoMensaje.Advertencia );
            
        }else{

                objEnGS_UbigeoColindante.Ubigeo_central = cmb_Distrito_central.SelectedValue.ToString();

                ListEnGS_UbigeoColindante.Add(objEnGS_UbigeoColindante);

                try
                {
                    DT_Datos = objGS_UbigeoColindate.GS_UbigeoColindante_Lista(ListEnGS_UbigeoColindante);
                    gv.DataSource = DT_Datos;
                    gv.DataBind();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
        }
    }



    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        this.Master.OcultarMensaje();
        RefrescarGrid();
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

            CargaComboDepartamentos();
            CargaComboDepartamentos_colindante();

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


    protected void CargaComboDepartamentos()
    {
        DataTable dt = new DataTable();
        LoGS_UbigeoColindante objLoGS_UbigeoColindante = new LoGS_UbigeoColindante();
        try
        {
            EnGS_UbigeoColindante objEnGS_UbigeoColindante = new EnGS_UbigeoColindante();
            cmb_Departamento_central.Items.Clear();

            dt = objLoGS_UbigeoColindante.GS_UbigeoColindante_Departamentos_Combo();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["ubigeo"].ToString().Trim();
                lista.Text = dt.Rows[i]["descrip"].ToString().Trim();
                cmb_Departamento_central.Items.Add(lista);
            }
        }
        catch (Exception excp)
        {
            throw excp;
        }
    }

    protected void CargaComboProvincias()
    {
        DataTable dt = new DataTable();
        LoGS_UbigeoColindante objLoGS_UbigeoColindante = new LoGS_UbigeoColindante();
        try
        {
            EnGS_UbigeoColindante objEnGS_UbigeoColindante = new EnGS_UbigeoColindante();
            List<EnGS_UbigeoColindante> ListEnGS_UbigeoColindante = new List<EnGS_UbigeoColindante>();
            cmb_Provincia_central.Items.Clear();


            objEnGS_UbigeoColindante.CodDepartamento = cmb_Departamento_central.SelectedValue.ToString().Substring(0, 2);

             


            ListEnGS_UbigeoColindante.Add(objEnGS_UbigeoColindante);


            dt = objLoGS_UbigeoColindante.GS_UbigeoColindante_Provincias_Combo(ListEnGS_UbigeoColindante);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["ubigeo"].ToString().Trim();
                lista.Text = dt.Rows[i]["descrip"].ToString().Trim();
                cmb_Provincia_central.Items.Add(lista);
            }
        }
        catch (Exception excp)
        {
            throw excp;
        }
    }

    protected void CargaComboDistritos()
    {
        DataTable dt = new DataTable();
        LoGS_UbigeoColindante objLoGS_UbigeoColindante = new LoGS_UbigeoColindante();
        try
        {
            EnGS_UbigeoColindante objEnGS_UbigeoColindante = new EnGS_UbigeoColindante();
            List<EnGS_UbigeoColindante> ListEnGS_UbigeoColindante = new List<EnGS_UbigeoColindante>();
            cmb_Distrito_central.Items.Clear();


            objEnGS_UbigeoColindante.CodDepartamento = cmb_Departamento_central.SelectedValue.ToString().Substring(0, 2);
            objEnGS_UbigeoColindante.CodProvincia = cmb_Provincia_central.SelectedValue.ToString().Substring(2, 2);


            ListEnGS_UbigeoColindante.Add(objEnGS_UbigeoColindante);


            dt = objLoGS_UbigeoColindante.GS_UbigeoColindante_Distritos_Combo(ListEnGS_UbigeoColindante);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["ubigeo"].ToString().Trim();
                lista.Text = dt.Rows[i]["descrip"].ToString().Trim();
                cmb_Distrito_central.Items.Add(lista);
            }
        }
        catch (Exception excp)
        {
            throw excp;
        }
    }









    protected void CargaComboDepartamentos_colindante()
    {
        DataTable dt = new DataTable();
        LoGS_UbigeoColindante objLoGS_UbigeoColindante = new LoGS_UbigeoColindante();
        try
        {
            EnGS_UbigeoColindante objEnGS_UbigeoColindante = new EnGS_UbigeoColindante();
            cmb_Departamento_colindante.Items.Clear();

            dt = objLoGS_UbigeoColindante.GS_UbigeoColindante_Departamentos_Combo();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["ubigeo"].ToString().Trim();
                lista.Text = dt.Rows[i]["descrip"].ToString().Trim();
                cmb_Departamento_colindante.Items.Add(lista);
            }
        }
        catch (Exception excp)
        {
            throw excp;
        }
    }

    protected void CargaComboProvincias_colindante()
    {
        DataTable dt = new DataTable();
        LoGS_UbigeoColindante objLoGS_UbigeoColindante = new LoGS_UbigeoColindante();
        try
        {
            EnGS_UbigeoColindante objEnGS_UbigeoColindante = new EnGS_UbigeoColindante();
            List<EnGS_UbigeoColindante> ListEnGS_UbigeoColindante = new List<EnGS_UbigeoColindante>();
            cmb_Provincia_colindante.Items.Clear();


            objEnGS_UbigeoColindante.CodDepartamento = cmb_Departamento_colindante.SelectedValue.ToString().Substring(0, 2);




            ListEnGS_UbigeoColindante.Add(objEnGS_UbigeoColindante);


            dt = objLoGS_UbigeoColindante.GS_UbigeoColindante_Provincias_Combo(ListEnGS_UbigeoColindante);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["ubigeo"].ToString().Trim();
                lista.Text = dt.Rows[i]["descrip"].ToString().Trim();
                cmb_Provincia_colindante.Items.Add(lista);
            }
        }
        catch (Exception excp)
        {
            throw excp;
        }
    }

    protected void CargaComboDistritos_colindante()
    {
        DataTable dt = new DataTable();
        LoGS_UbigeoColindante objLoGS_UbigeoColindante = new LoGS_UbigeoColindante();
        try
        {
            EnGS_UbigeoColindante objEnGS_UbigeoColindante = new EnGS_UbigeoColindante();
            List<EnGS_UbigeoColindante> ListEnGS_UbigeoColindante = new List<EnGS_UbigeoColindante>();
            cmb_Distrito_colindante.Items.Clear();


            objEnGS_UbigeoColindante.CodDepartamento = cmb_Departamento_colindante.SelectedValue.ToString().Substring(0, 2);
            objEnGS_UbigeoColindante.CodProvincia = cmb_Provincia_colindante.SelectedValue.ToString().Substring(2, 2);


            ListEnGS_UbigeoColindante.Add(objEnGS_UbigeoColindante);


            dt = objLoGS_UbigeoColindante.GS_UbigeoColindante_Distritos_Combo(ListEnGS_UbigeoColindante);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["ubigeo"].ToString().Trim();
                lista.Text = dt.Rows[i]["descrip"].ToString().Trim();
                cmb_Distrito_colindante.Items.Add(lista);
            }
        }
        catch (Exception excp)
        {
            throw excp;
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




    protected void cmb_Departamento_central_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.Master.OcultarMensaje();
        cmb_Distrito_central.Items.Clear();
        CargaComboProvincias();

        //cmb_Departamento_colindante.SelectedValue = cmb_Departamento_central.SelectedValue.ToString();
    }
    protected void cmb_Provincia_central_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.Master.OcultarMensaje();
        CargaComboDistritos();
    }
    protected void btnEliminar_Click(object sender, EventArgs e)
    {

        
            if (gv.SelectedIndex != -1)
            {

       
                        bool continuar;
                        bool.TryParse(Request.Form["hdnContinuar"], out continuar);
                        if (continuar)
                        {
                            //*** eliminar ***//
                            string msg = "";
                            string Exito = "";
                            LoGS_UbigeoColindante ObjLoGS_UbigeoColindante = new LoGS_UbigeoColindante();
                            try
                            {
                                #region Cargar_Variables
                                EnGS_UbigeoColindante ObjEnGS_UbigeoColindante = new EnGS_UbigeoColindante();
                                List<EnGS_UbigeoColindante> ListEnGS_UbigeoColindante = new List<EnGS_UbigeoColindante>();

                                ObjEnGS_UbigeoColindante.id = gv.SelectedRow.Cells[1].Text.ToString();


                                ListEnGS_UbigeoColindante.Add(ObjEnGS_UbigeoColindante);
                                #endregion Cargar_Variables
                                msg = ObjLoGS_UbigeoColindante.GS_UbigeoColindante_DEL(ListEnGS_UbigeoColindante);

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
                                RefrescarGrid();
                                Master.MostrarMensaje("Se Eliminó Correctamente.", TipoMensaje.Exito);
                            }

                        }

        }else{
            Master.MostrarMensaje(" Debe seleccionar un distrito.", TipoMensaje.Advertencia);


        }
    }
    protected void btnAgregar_Click(object sender, EventArgs e)
    {

        if (cmb_Distrito_central.SelectedValue != "" && cmb_Distrito_colindante.SelectedValue != "")
        {

                            string str_Id = "";
                            string msg = "";
                            string Exito = "";
                            LoGS_UbigeoColindante ObjLoGS_UbigeoColindante = new LoGS_UbigeoColindante();
                            try
                            {
                                #region Cargar_Variables
                                EnGS_UbigeoColindante ObjEnGS_UbigeoColindante = new EnGS_UbigeoColindante();
                                List<EnGS_UbigeoColindante> ListEnGS_UbigeoColindante = new List<EnGS_UbigeoColindante>();

                                ObjEnGS_UbigeoColindante.Ubigeo_central = cmb_Distrito_central.SelectedValue.ToString();
                                ObjEnGS_UbigeoColindante.Ubigeo_alrededor = cmb_Distrito_colindante.SelectedValue.ToString();
                                ObjEnGS_UbigeoColindante.CodUsuario = (String)this.Session["codusuario"];

                                ListEnGS_UbigeoColindante.Add(ObjEnGS_UbigeoColindante);
                                #endregion Cargar_Variables
                                List<EnTransaccion> RetornoT = ObjLoGS_UbigeoColindante.GS_UbigeoColindante_INS(ListEnGS_UbigeoColindante);
                                msg = RetornoT[0].MENSAJE.ToString();
                                str_Id = RetornoT[0].ID.ToString();
                                if (msg == "exito") { Exito = FlagsPrograma.FLG_VALOREXITOSI; } else { Master.MostrarMensaje(msg, TipoMensaje.Error, msg); Exito = FlagsPrograma.FLG_VALOREXITONO; return; }
                            }
                            catch (SqlException ex)
                            {
                                msg = HttpUtility.HtmlEncode(ex.Message);
                                //MostrarMensaje(msg, true);
                                Exito = FlagsPrograma.FLG_VALOREXITONO;
                            }
                            catch (Exception ex)
                            {
                                msg = HttpUtility.HtmlEncode(ex.Message);
                                Exito = FlagsPrograma.FLG_VALOREXITONO;
                            }
                            if (Exito == FlagsPrograma.FLG_VALOREXITOSI)
                            {
                                RefrescarGrid();
                                Master.MostrarMensaje("Se Grabó Correctamente.", TipoMensaje.Exito);

                            }

        }
        else
        {
            Master.MostrarMensaje(" Debe seleccionar el distrito central y el distrito colindante.", TipoMensaje.Advertencia);
        }




    }




    protected void cmb_Departamento_colindante_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.Master.OcultarMensaje();
        cmb_Distrito_colindante.Items.Clear();
        CargaComboProvincias_colindante();
    }
    protected void cmb_Provincia_colindante_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.Master.OcultarMensaje();
        CargaComboDistritos_colindante();
    }
}