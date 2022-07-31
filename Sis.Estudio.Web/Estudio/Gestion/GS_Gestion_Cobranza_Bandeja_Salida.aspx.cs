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


public partial class Estudio_Gestion_GS_Gestion_Cobranza_Bandeja_Salida : System.Web.UI.Page
{
    #region Declaraciones
    private string PaginaDetalle = ".....................................";
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
        Metodo_Pintar();
        Metodo_Link();
       //Metodo_Link2();
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
            this.Master.TituloModulo = "Bandeja de Action Plans Administrativos Pendientes";
            //btnDesactivar.Attributes.Add("onClick", "document.getElementById('hdnContinuar').value = confirm('¿Se desactivará El registro, ¿Desea continuar?');");
            //btnProcesar.Attributes.Add("onClick", "document.getElementById('hdnContinuar').value = confirm('¿Se Autorizará El efectivo, ¿Desea continuar?');");
            InicioOperacion();
            Cargar_Modulos();
            RefrescarGrid();
            #region accesos
            //Accesos();
            #endregion accesos
            //ConfiguracionInicial();

        }
        //upBotonera.Update();
    }
    #endregion Eventos_Form

    #region ToolBar
    protected void btnModificar_Click(object sender, EventArgs e)
    {
        try
        {
            if (gv.SelectedIndex != -1)
            {
                if (gv.SelectedRow.Cells[15].Text.ToString() == "4" || gv.SelectedRow.Cells[17].Text.ToString() != "0" || gv.SelectedRow.Cells[15].Text.ToString() == "6")
                {
                    Master.MostrarMensaje("El Action Plan se encuentra desactivo ó ya se finalzó ó pendiente de aprobar", TipoMensaje.Advertencia);
                }
                else
                {
                    string str_estado = "?estado=m";
                    string str_id = "&id=" + gv.SelectedRow.Cells[1].Text.ToString();
                    string str_nombre = "&nombre=" + gv.SelectedRow.Cells[2].Text.ToString();
                    Response.Redirect(PaginaDetalle + str_estado + str_id + str_nombre);
                }
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

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        try
        {
            string str_estado = "?estado=n";
            Response.Redirect(PaginaDetalle + str_estado);
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message.ToString(), true);
        }
    }
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

    private void RefrescarGrid()
    {
        this.Master.OcultarMensaje();

        DataTable DT_Datos = new DataTable();

        LoGS_Gestion_Cobranza objLoGS_Gestion_Cobranza = new LoGS_Gestion_Cobranza();
        EnGS_Gestion_Cobranza objEnGS_Gestion_Cobranza = new EnGS_Gestion_Cobranza();
        List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza = new List<EnGS_Gestion_Cobranza>();


        objEnGS_Gestion_Cobranza.Accion = "0";
        objEnGS_Gestion_Cobranza.nEmpresa = (String)this.Session["cempresa"];

        objEnGS_Gestion_Cobranza.dias_mora = "";//txt_dias_mora.Text.Trim();

        objEnGS_Gestion_Cobranza.fecha_ini = txt_FECHAINI.Text.ToString();
        objEnGS_Gestion_Cobranza.fecha_fin = txt_FECHAFIN.Text.ToString();
        objEnGS_Gestion_Cobranza.CodTipoGestion = cmb_CodTipoGestionGrupo.SelectedValue.ToString().Trim();
        objEnGS_Gestion_Cobranza.CodUsuario = (String)this.Session["codusuario"];

        objEnGS_Gestion_Cobranza.Nombres = txt_nombres.Text.ToString();
        objEnGS_Gestion_Cobranza.documento = txt_documento.Text.ToString();
        objEnGS_Gestion_Cobranza.CodUsuarioNuevo = cmb_UsuarioResponsable.SelectedValue.ToString().Trim();

        objEnGS_Gestion_Cobranza.Id_estado_gestion_cobranza = cmb_Estado.SelectedValue.ToString().Trim();

        ListEnGS_Gestion_Cobranza.Add(objEnGS_Gestion_Cobranza);

        try
        {
            DT_Datos = objLoGS_Gestion_Cobranza.GS_Gestion_Cobranza_Lista_BandejaSalida(ListEnGS_Gestion_Cobranza);
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

    private void Desactivar(string str_cod1)
    {
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
    }

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
            
            int Estado = 23;

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



                    fila.Cells[18].Controls.Add(hlnk);
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

                    string str_id_cliente = fila.Cells[21].Text.ToString();

                    hlnk2.NavigateUrl = "00Load.aspx?id_cliente=" + str_id_cliente;

                    hlnk2.ImageUrl = "~/Imagenes/ficha.png";

                    fila.Cells[20].Controls.Add(hlnk2);
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

                        if (gv.SelectedRow.Cells[15].Text.ToString() == "4" || gv.SelectedRow.Cells[17].Text.ToString() != "0")
                        {
                            Master.MostrarMensaje("Advertencia, El Action Plan o los Actions Plan se encuentran desactivados ó finalizados.", TipoMensaje.Advertencia);
                            

                        }
                        else
                        {
                            string str_estado = "?estado=m";

                            string str_id = "&id=" + gv.SelectedRow.Cells[1].Text.ToString();
                            string str_nombre = "&nombre=" + gv.SelectedRow.Cells[2].Text.ToString();
                            //Response.Redirect(PaginaDetalle + str_estado + str_id + str_nombre);

                            hlnk2.NavigateUrl = PaginaDetalle + str_estado + str_id + str_nombre;
                        }

                    }
                    else
                    {
                        //MostrarMensaje(Mensajes.MSG_MENSAJESELECCIONARREGISTRO, true);
                    }



                    hlnk2.ImageUrl = "~/Imagenes/lapiz.png";

                    fila.Cells[22].Controls.Add(hlnk2);
                }
            }



        }
        catch (Exception ex)
        {
            throw ex;
        }
    }



    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        Master.OcultarMensaje();
        limpiarMensaje();

        //gv.PageIndex = 0;

        RefrescarGrid();
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

            CargaComboTipoGestionGrupo();
            CargaComboUsuarioResponsable();
            CargaComboEstado();

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
            #region Fecha
            DateTime? Fecha_Hoy = null;
            DateTime? Fecha_Ini = null;
            DateTime? Fecha_Fin = null;

            Fecha_Hoy = DateTime.Today;
            Fecha_Ini = new DateTime(Fecha_Hoy.Value.Year, Fecha_Hoy.Value.Month, 1);
            Fecha_Fin = new DateTime(Fecha_Hoy.Value.Year, Fecha_Hoy.Value.Month, 1).AddDays(-1);

            txt_FECHAINI.Text = Convert.ToDateTime(Fecha_Ini).ToString("dd/MM/yyyy");
            txt_FECHAFIN.Text = Convert.ToDateTime(Fecha_Hoy).ToString("dd/MM/yyyy");
            #endregion Fecha


        }
        catch (Exception excp)
        {
            Master.MostrarMensaje(excp.Message.ToString(), TipoMensaje.Error);

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
            cmb_CodTipoGestionGrupo.Items.Clear();

            objEnGS_TipoGestiones.grupo = "3";

            ListEnGS_TipoGestiones.Add(objEnGS_TipoGestiones);

            dt = objLoGS_TipoGestiones.GS_TipoGestionesGrupo_Combo(ListEnGS_TipoGestiones);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["CodTipoGestion"].ToString().Trim();
                lista.Text = dt.Rows[i]["Descripcion"].ToString().Trim();
                cmb_CodTipoGestionGrupo.Items.Add(lista);
            }
        }
        catch (Exception excp)
        {
            throw excp;
        }
    }

    protected void CargaComboUsuarioResponsable()
    {
        DataTable dt = new DataTable();
        LoGS_Gestion_Cobranza objLoGS_Gestion_Cobranza = new LoGS_Gestion_Cobranza(); 
        
        try
        {
            EnGS_Gestion_Cobranza objEnGS_Gestion_Cobranza = new EnGS_Gestion_Cobranza();
            List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza = new List<EnGS_Gestion_Cobranza>();
            cmb_UsuarioResponsable.Items.Clear();

            objEnGS_Gestion_Cobranza.nEmpresa = (String)this.Session["cempresa"];
            objEnGS_Gestion_Cobranza.Id_ejecutores = "4";
            objEnGS_Gestion_Cobranza.IdReg_Gestion_Cobranza = "0";

            ListEnGS_Gestion_Cobranza.Add(objEnGS_Gestion_Cobranza);

            dt = objLoGS_Gestion_Cobranza.GS_Gestion_Cobranza_Ejecutores_Listar(ListEnGS_Gestion_Cobranza);

            ListItem lista2 = new ListItem();
            lista2.Value = "0";
            lista2.Text = "--seleccione--";
            cmb_UsuarioResponsable.Items.Add(lista2);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["CodigoUsuario"].ToString().Trim();
                lista.Text = dt.Rows[i]["NombreUsuario"].ToString().Trim();
                cmb_UsuarioResponsable.Items.Add(lista);
            }
        }
        catch (Exception excp)
        {
            throw excp;
        }
    }

    protected void CargaComboEstado()
    {
        DataTable dt = new DataTable();
        LoGS_Gestion_Cobranza objLoGS_Gestion_Cobranza = new LoGS_Gestion_Cobranza();
        try
        {
            EnGS_Gestion_Cobranza objEnGS_Gestion_Cobranza = new EnGS_Gestion_Cobranza();
            cmb_Estado.Items.Clear();


            dt = objLoGS_Gestion_Cobranza.GS_Estado_Gestion_Cobranza_Combo();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["id_estado_gestion_cobranza"].ToString().Trim();
                lista.Text = dt.Rows[i]["desc_estado_gestion_cobranza"].ToString().Trim();
                cmb_Estado.Items.Add(lista);
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

    protected void btnDesactivar_Click(object sender, EventArgs e)
    {

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
                    string str_codigo = gv.SelectedRow.Cells[1].Text.ToString();
                    Desactivar(str_codigo);
                }
                else
                {
                    MostrarMensaje("Operacion Anular Cancelada", true);
                }
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




    private void ExportarCarta(string Formato, string IdReg_Gestion_Cobranza, string id_carta)
    {
        try
        {

            string str_Parametros = "";

            string str_tiporeporte = "?tiporerporte=" + Formato;
            string str_accionstore = "&accionstore=" + AccionStore();
            string str_IdReg_Gestion_Cobranza = "&IdReg_Gestion_Cobranza=" + IdReg_Gestion_Cobranza;
            //string str_Num_carta = "&Num_carta=" + num_carta;
            string str_Id_carta = "&Id_carta=" + id_carta;
            string str_cempresa = "&cempresa=" + (String)this.Session["cempresa"];
            string str_TIPOCONSULTA = "&tipoconsulta=" + "0";


            str_Parametros = str_tiporeporte + str_accionstore + str_IdReg_Gestion_Cobranza + str_Id_carta + str_cempresa + str_TIPOCONSULTA;

            string CONFIG = "'resizable = yes, scrollbars = yes, toolbar=no, height = 500, width = 800,left=200,top=100,status=yes, location=no, menubar=no'";
            StringBuilder sb = new StringBuilder();
            sb.Append("<script>var win=window.open('../../Reportes/Gestion/ReporteModeloCartaC.aspx" + str_Parametros + "', 'ReportePersonal', " + CONFIG + ");</script>");
            ScriptManager.RegisterStartupScript(this, typeof(Page), "ReporteAccion", sb.ToString(), false);

        }
        catch (Exception excp)
        {
            MostrarMensaje(excp.ToString(), true);
        }

    }

    protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        this.Session["GS_Gestion_Cobranza_PageIndex"] = e.NewPageIndex;

        gv.PageIndex = Convert.ToInt32(this.Session["GS_Gestion_Cobranza_PageIndex"]);

        RefrescarGrid();
    }
    protected void gv_PageIndexChanged(object sender, EventArgs e)
    {
        if (gv.Rows.Count > 0)
        {
            gv.SelectedIndex = -1;
        }
    }

    protected void btnGrabarObs_Click(object sender, EventArgs e)
    {

    }
    protected void GrabarComentario()
    {
        this.Master.OcultarMensaje();

        string msg = "";
        string Exito = "";

        try
        {
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

            //***  ****//
            if (marco == "S")
            {
                #region carga_variables
                string IdReg_Gestion_Cobranza = "";
                foreach (GridViewRow row in gv.Rows)
                {
                    if (((CheckBox)row.FindControl("chkPermiso")).Checked == true)
                    {
                        IdReg_Gestion_Cobranza = row.Cells[1].Text;
                        try
                        {
                            #region Carga_Variable
                            LoGS_Gestion_Cobranza objLoGS_Gestion_Cobranza = new LoGS_Gestion_Cobranza();
                            EnGS_Gestion_Cobranza objEnGS_Gestion_Cobranza = new EnGS_Gestion_Cobranza();
                            List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza = new List<EnGS_Gestion_Cobranza>();
                            objEnGS_Gestion_Cobranza.nEmpresa = (String)this.Session["cempresa"];
                            objEnGS_Gestion_Cobranza.IdReg_Gestion_Cobranza = IdReg_Gestion_Cobranza;
                            objEnGS_Gestion_Cobranza.Obs = txt_obs.Text.ToString();
                            objEnGS_Gestion_Cobranza.CodUsuario = (String)this.Session["codusuario"];
                            ListEnGS_Gestion_Cobranza.Add(objEnGS_Gestion_Cobranza);
                            #endregion Carga_Variable
                            msg = objLoGS_Gestion_Cobranza.GS_Gestion_Cobranza_Bandeja_Salida(ListEnGS_Gestion_Cobranza);

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
                }
                if (Exito == FlagsPrograma.FLG_VALOREXITOSI)
                {
                    //RefrescarGrid();
                    Master.MostrarMensaje("Se Grabó Correctamente.", TipoMensaje.Exito);
                    //Refresca_Grid("1");
                    //up_GV.Update();
                }


                #endregion carga_variables
                #region envia_carta
                #endregion envia_carta
            }
            //*****************************************************//
        }
        catch (Exception ex)
        {
            Master.MostrarMensaje(ex.Message.ToString(), TipoMensaje.Error);
        }



    }
    protected void btnExportarGestiones_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        LoGS_Gestion_Cobranza objLoGS_Gestion_Cobranza = new LoGS_Gestion_Cobranza();
        EnGS_Gestion_Cobranza objEnGS_Gestion_Cobranza = new EnGS_Gestion_Cobranza();
        List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza = new List<EnGS_Gestion_Cobranza>();
        try
        {
            limpiarMensaje();
            #region Sesion
            string cempresa = (String)this.Session["cempresa"];
            string codUsuario = (String)this.Session["codusuario"];
            bool validaUsuario=true;
            if (cempresa == "" || cempresa == null)
            {
                this.Session.Abandon();
                Response.Redirect("../../Login.aspx?rd=0");
                return;
            }
            #endregion Sesion

            if (gv.SelectedIndex != -1)
            {
                #region carga_variables
                string IdReg_Gestion_Cobranza = "";
                foreach (GridViewRow row in gv.Rows)
                {
                    if (((CheckBox)row.FindControl("chkPermiso")).Checked == true)
                    {
                        IdReg_Gestion_Cobranza = IdReg_Gestion_Cobranza + row.Cells[1].Text + ",";
                        if (codUsuario != row.Cells[22].Text)
                        {
                            validaUsuario = false;
                        }
                        else
                        {
                            objEnGS_Gestion_Cobranza.nEmpresa = cempresa;
                            objEnGS_Gestion_Cobranza.IdReg_Gestion_Cobranza = row.Cells[1].Text;
                            ListEnGS_Gestion_Cobranza.Add(objEnGS_Gestion_Cobranza);
                            dt = objLoGS_Gestion_Cobranza.GS_Gestion_Cobranza_GestionesInternas_TomarControl(ListEnGS_Gestion_Cobranza);
                        }
                    }
                }

                if (IdReg_Gestion_Cobranza.Length > 0)
                {
                    IdReg_Gestion_Cobranza = IdReg_Gestion_Cobranza.TrimEnd(',');
                }

                #endregion carga_variables
                if (validaUsuario)
                {
                    GrabarComentario();
                    //Exportar(Extencion.Excel, IdReg_Gestion_Cobranza);
                    RefrescarGrid();
                }
                else
                {
                    Master.MostrarMensaje("Está intentando tomar control de una gestión asignada a otro usuario.", TipoMensaje.Error);
                }
                
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

    private void Exportar(string Formato, string IdReg_Gestion_Cobranza)
    {
        try
        {
            string str_Parametros = "";
            string str_tiporeporte = "?tiporeporte=" + Formato;
            string str_IdReg_Gestion_Cobranza = "&IdReg_Gestion_Cobranza=" + IdReg_Gestion_Cobranza;
            string str_cempresa = "&cempresa=" + (String)this.Session["cempresa"];
            string str_codusuario = "&CodUsuario=" + (String)this.Session["codusuario"];
            string str_TIPOCONSULTA = "&tipoconsulta=" + "0";
            str_Parametros = str_tiporeporte + str_IdReg_Gestion_Cobranza + str_cempresa + str_codusuario + str_TIPOCONSULTA;
            string CONFIG = "'resizable = yes, scrollbars = yes, toolbar=no, height = 500, width = 800,left=200,top=100,status=yes, location=no, menubar=no'";
            StringBuilder sb = new StringBuilder();
            sb.Append("<script>var win=window.open('../../Reportes/Gestion/GestionesInternas_Excel_GestionesUsuario.aspx" + str_Parametros + "', 'ReportePersonal', " + CONFIG + ");win.focus();</script>");
            ScriptManager.RegisterStartupScript(this, typeof(Page), "ReporteAccion", sb.ToString(), false);
        }
        catch (Exception excp)
        {
            MostrarMensaje(excp.ToString(), true);
        }
    }
    protected void cmb_Estado_SelectedIndexChanged(object sender, EventArgs e)
    {
        RefrescarGrid();
    }
    
    protected void txt_documento_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txt_nombres_TextChanged(object sender, EventArgs e)
    {

    }
    protected void cmb_CodTipoGestionGrupo_SelectedIndexChanged(object sender, EventArgs e)
    {
        RefrescarGrid();
    }

    //private void Metodo_Pintar()
    //{
    //    try
    //    {
    //        #region Validacion
    //        if (gv.Rows.Count < 1)
    //        {
    //            return;
    //        }
    //        #endregion Validacion
    //        /*
    //        foreach (GridViewRow fila in gv.Rows)
    //        {

    //            if (fila.Cells[12].Text.ToString() == "1")
    //            {
    //                fila.Cells[13].BackColor = Color.Yellow;
    //            }

    //            if (fila.Cells[12].Text.ToString() == "2")
    //            {
    //                fila.Cells[13].BackColor = Color.Green;
    //            }

    //            if (fila.Cells[12].Text.ToString() == "3")
    //            {
    //                fila.Cells[13].BackColor = Color.Red;
    //            }


    //        }
    //        */

    //        int Estado = 16;

    //        foreach (GridViewRow fila in gv.Rows)
    //        {
    //            if (fila.RowType == DataControlRowType.DataRow)
    //            {
    //                HyperLink hlnk = new HyperLink();
    //                hlnk.NavigateUrl = "";

    //                if (fila.Cells[Estado].Text.ToString() == "1")
    //                {
    //                    hlnk.ImageUrl = "~/Imagenes/sem_amarillo.png";
    //                }
    //                if (fila.Cells[Estado].Text.ToString() == "2")
    //                {
    //                    hlnk.ImageUrl = "~/Imagenes/sem_verde.png";
    //                }
    //                if (fila.Cells[Estado].Text.ToString() == "3")
    //                {
    //                    hlnk.ImageUrl = "~/Imagenes/sem_rojo.png";
    //                }
    //                if (fila.Cells[Estado].Text.ToString() == "4")
    //                {
    //                    hlnk.ImageUrl = "~/Imagenes/sem_negro.png";
    //                }
    //                if (fila.Cells[Estado].Text.ToString() == "5")
    //                {
    //                    hlnk.ImageUrl = "~/Imagenes/sem_naranja.png";
    //                }
    //                if (fila.Cells[Estado].Text.ToString() == "6")
    //                {
    //                    hlnk.ImageUrl = "~/Imagenes/sem_azul.png";
    //                }
    //                fila.Cells[17].Controls.Add(hlnk);
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}


    //private void Metodo_Link()
    //{
    //    try
    //    {
    //        #region Validacion
    //        if (gv.Rows.Count < 1)
    //        {
    //            return;
    //        }
    //        #endregion Validacion

    //        foreach (GridViewRow fila in gv.Rows)
    //        {
    //            if (fila.RowType == DataControlRowType.DataRow)
    //            {
    //                HyperLink hlnk2 = new HyperLink();

    //                string str_id_cliente = fila.Cells[20].Text.ToString();

    //                hlnk2.NavigateUrl = "00Load.aspx?id_cliente=" + str_id_cliente;

    //                hlnk2.ImageUrl = "~/Imagenes/ficha.png";

    //                fila.Cells[19].Controls.Add(hlnk2);
    //            }
    //        }



    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}
    protected void btnExportar_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        LoGS_Gestion_Cobranza objLoGS_Gestion_Cobranza = new LoGS_Gestion_Cobranza();
        EnGS_Gestion_Cobranza objEnGS_Gestion_Cobranza = new EnGS_Gestion_Cobranza();
        List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza = new List<EnGS_Gestion_Cobranza>();
        try
        {
            limpiarMensaje();
            #region Sesion
            string cempresa = (String)this.Session["cempresa"];
            string codUsuario = (String)this.Session["codusuario"];
            bool validaUsuario = true;
            if (cempresa == "" || cempresa == null)
            {
                this.Session.Abandon();
                Response.Redirect("../../Login.aspx?rd=0");
                return;
            }
            #endregion Sesion

            if (gv.SelectedIndex != -1)
            {
                #region carga_variables
                string IdReg_Gestion_Cobranza = "";
                foreach (GridViewRow row in gv.Rows)
                {
                    if (((CheckBox)row.FindControl("chkPermiso")).Checked == true)
                    {
                        IdReg_Gestion_Cobranza = IdReg_Gestion_Cobranza + row.Cells[1].Text + ",";
                        //if (codUsuario != row.Cells[22].Text)
                        //{
                        //    validaUsuario = false;
                        //}
                    }
                }

                if (IdReg_Gestion_Cobranza.Length > 0)
                {
                    IdReg_Gestion_Cobranza = IdReg_Gestion_Cobranza.TrimEnd(',');
                }

                #endregion carga_variables
                if (validaUsuario)
                {
                    //GrabarComentario();
                    Exportar(Extencion.Excel, IdReg_Gestion_Cobranza);
                }
                else
                {
                    Master.MostrarMensaje("Está intentando tomar control de una gestión asignada a otro usuario.", TipoMensaje.Error);
                }

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
}