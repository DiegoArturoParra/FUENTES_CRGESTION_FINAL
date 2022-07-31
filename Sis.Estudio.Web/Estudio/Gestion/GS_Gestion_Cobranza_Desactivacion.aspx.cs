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
using System.Text.RegularExpressions;


public partial class Estudio_Gestion_GS_Gestion_Cobranza_Desactivacion : System.Web.UI.Page
{
    #region Declaraciones
    private string PaginaDetalle = "GS_Gestion_CobranzaDetalle.aspx";
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
        if (!Page.IsPostBack)
        {
            this.Master.TituloModulo = "Desactivaci&oacute;n de Action Plans";
            btnDesactivar.Attributes.Add("onClick", "document.getElementById('hdnContinuar').value = confirm('¿Se desactivará El registro, ¿Desea continuar?');");
            InicioOperacion();
            Cargar_Modulos();
            RefrescarGrid();
            CargaComboJerarquiaB();
            CargaComboJerarquiaC("0");
            CargaComboAsesores("0");
        }
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

    #region Comentado
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
    #endregion Comentado
    

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


        //////////////////////////////
        if (this.Session["GS_Gestion_Cobranza_sw"] == "S")
        {
            this.Session["GS_Gestion_Cobranza_sw"] = "N";

            txt_dias_mora.Text = this.Session["GS_Gestion_Cobranza_dias_mora"].ToString();
            txt_dias_mora_hasta.Text = this.Session["GS_Gestion_Cobranza_dias_mora_hasta"].ToString();
            txt_FECHAINI.Text = this.Session["GS_Gestion_Cobranza_fecha_ini"].ToString();
            txt_FECHAFIN.Text = this.Session["GS_Gestion_Cobranza_fecha_fin"].ToString();
            cmb_CodTipoGestion.SelectedValue = this.Session["GS_Gestion_Cobranza_CodTipoGestion"].ToString();
            txt_nombres.Text = this.Session["GS_Gestion_Cobranza_Nombres"].ToString();
            txt_documento.Text = this.Session["GS_Gestion_Cobranza_documento"].ToString();
            cmb_Estado.SelectedValue = this.Session["GS_Gestion_Cobranza_Id_estado_gestion_cobranza"].ToString();
            cmb_JerarquiaB.SelectedValue = this.Session["GS_Gestion_Cobranza_CodJerarquiaB"].ToString();
            cmb_JerarquiaC.SelectedValue = this.Session["GS_Gestion_Cobranza_CodJerarquiaC"].ToString();
            cmb_JerarquiaD.SelectedValue = this.Session["GS_Gestion_Cobranza_CodJerarquiaD"].ToString();
            
            gv.PageIndex = Convert.ToInt32(this.Session["GS_Gestion_Cobranza_PageIndex"]);
        }
        else
        {
            this.Session["GS_Gestion_Cobranza_dias_mora"] = txt_dias_mora.Text.Trim();
            this.Session["GS_Gestion_Cobranza_dias_mora_hasta"] = txt_dias_mora_hasta.Text.Trim();
            this.Session["GS_Gestion_Cobranza_fecha_ini"] = txt_FECHAINI.Text.ToString();
            this.Session["GS_Gestion_Cobranza_fecha_fin"] = txt_FECHAFIN.Text.ToString();
            this.Session["GS_Gestion_Cobranza_CodTipoGestion"] = cmb_CodTipoGestion.SelectedValue.ToString().Trim();
            this.Session["GS_Gestion_Cobranza_Nombres"] = txt_nombres.Text.ToString();
            this.Session["GS_Gestion_Cobranza_documento"] = txt_documento.Text.ToString();
            this.Session["GS_Gestion_Cobranza_Id_estado_gestion_cobranza"] = cmb_Estado.SelectedValue.ToString().Trim();
            this.Session["GS_Gestion_Cobranza_CodJerarquiaB"] = cmb_JerarquiaB.SelectedValue.ToString().Trim();
            this.Session["GS_Gestion_Cobranza_CodJerarquiaC"] = cmb_JerarquiaC.SelectedValue.ToString().Trim();
            this.Session["GS_Gestion_Cobranza_CodJerarquiaD"] = cmb_JerarquiaD.SelectedValue.ToString().Trim();
        }
        /////////////////////////////



        objEnGS_Gestion_Cobranza.Accion = "0";
        objEnGS_Gestion_Cobranza.nEmpresa = (String)this.Session["cempresa"];

        objEnGS_Gestion_Cobranza.dias_mora = this.Session["GS_Gestion_Cobranza_dias_mora"].ToString();
        objEnGS_Gestion_Cobranza.dias_mora_hasta = this.Session["GS_Gestion_Cobranza_dias_mora_hasta"].ToString();

        objEnGS_Gestion_Cobranza.fecha_ini = this.Session["GS_Gestion_Cobranza_fecha_ini"].ToString();
        objEnGS_Gestion_Cobranza.fecha_fin = this.Session["GS_Gestion_Cobranza_fecha_fin"].ToString();
        objEnGS_Gestion_Cobranza.CodTipoGestion = this.Session["GS_Gestion_Cobranza_CodTipoGestion"].ToString();
        
        objEnGS_Gestion_Cobranza.CodUsuario = (String)this.Session["codusuario"];

        objEnGS_Gestion_Cobranza.Nombres = this.Session["GS_Gestion_Cobranza_Nombres"].ToString();
        objEnGS_Gestion_Cobranza.documento = this.Session["GS_Gestion_Cobranza_documento"].ToString();
        objEnGS_Gestion_Cobranza.Id_estado_gestion_cobranza = this.Session["GS_Gestion_Cobranza_Id_estado_gestion_cobranza"].ToString();

        objEnGS_Gestion_Cobranza.cod_jerarquiaB = this.Session["GS_Gestion_Cobranza_CodJerarquiaB"].ToString();
        objEnGS_Gestion_Cobranza.cod_jerarquiaC = this.Session["GS_Gestion_Cobranza_CodJerarquiaC"].ToString();
        objEnGS_Gestion_Cobranza.cod_jerarquiaD = this.Session["GS_Gestion_Cobranza_CodJerarquiaD"].ToString();

        ListEnGS_Gestion_Cobranza.Add(objEnGS_Gestion_Cobranza);

        try
        {
            if (objEnGS_Gestion_Cobranza.Id_estado_gestion_cobranza != "1" && objEnGS_Gestion_Cobranza.Id_estado_gestion_cobranza != "-1")
            {
                DT_Datos = objLoGS_Gestion_Cobranza.GS_Gestion_Cobranza_Lista(ListEnGS_Gestion_Cobranza);
            }else if (objEnGS_Gestion_Cobranza.Id_estado_gestion_cobranza == "-1" || objEnGS_Gestion_Cobranza.Id_estado_gestion_cobranza == "1")
            {
                DT_Datos = objLoGS_Gestion_Cobranza.GS_Gestion_Cobranza_Listar_Pendientes_Desactivacion(ListEnGS_Gestion_Cobranza, "");
            }
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
            objEnGS_Gestion_Cobranza.Id_estado_gestion_cobranza = "7";
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
            int Estado = 16;

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
                    fila.Cells[17].Controls.Add(hlnk);
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

                    string str_id_cliente = fila.Cells[20].Text.ToString();

                    hlnk2.NavigateUrl = "00Load.aspx?id_cliente=" + str_id_cliente;

                    hlnk2.ImageUrl = "~/Imagenes/ficha.png";

                    fila.Cells[19].Controls.Add(hlnk2);
                }
            }



        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*
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
                        if (gv.SelectedIndex<=gv.Rows.Count)
                        {
                            if (gv.SelectedRow.Cells[16].Text.ToString() == "4" || gv.SelectedRow.Cells[18].Text.ToString() != "0" || gv.SelectedRow.Cells[16].Text.ToString() == "6" || gv.SelectedRow.Cells[16].Text.ToString() == "3")
                            {
                                Master.MostrarMensaje("El Action Plan se encuentra  desactivo, pendiente de aprobacion ó ya se finalizó", TipoMensaje.Advertencia);
                            }
                            else
                            {
                                string str_estado = "?estado=m";

                                string str_id = "&id=" + gv.SelectedRow.Cells[1].Text.ToString();
                                string str_id_cliente = "&idcliente=" + gv.SelectedRow.Cells[20].Text.ToString();
                                string str_nombre = "&nombre=" + gv.SelectedRow.Cells[2].Text.ToString();
                                //Response.Redirect(PaginaDetalle + str_estado + str_id + str_nombre);

                                hlnk2.NavigateUrl = PaginaDetalle + str_estado + str_id + str_id_cliente + str_nombre;
                            }
                        }
                    }
                    else
                    {
                        //MostrarMensaje(Mensajes.MSG_MENSAJESELECCIONARREGISTRO, true);
                    }



                    hlnk2.ImageUrl = "~/Imagenes/lapiz.png";

                    fila.Cells[23].Controls.Add(hlnk2);
                }
            }



        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
     * */

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        Master.OcultarMensaje();
        limpiarMensaje();

        gv.PageIndex = 0;

        Regex expRegDni = new Regex(@"^\d{8}$");
        Regex expRegDiasMora = new Regex("^[0-9]+$");
        bool formatoCorrecto = true;
        if (txt_documento.Text.Length > 0) {
            if (expRegDni.IsMatch(txt_documento.Text))
            {
                formatoCorrecto = true;
            }
            else
            {
                formatoCorrecto = false;
                Master.MostrarMensaje("Formato de DNI Incorrecto", TipoMensaje.Error);
            }
        }
        if (txt_dias_mora.Text.Length > 0)
        {
            if (expRegDiasMora.IsMatch(txt_dias_mora.Text))
            {
                formatoCorrecto = true;
            }
            else
            {
                formatoCorrecto = false;
                Master.MostrarMensaje("Días de Mora es numérico", TipoMensaje.Error);
            }
        }
        if (formatoCorrecto == true) {
            RefrescarGrid();
        }
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

            CargaComboTipoGestion();
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

    protected void CargaComboTipoGestion()
    {
        DataTable dt = new DataTable();
        LoGS_ClaseGestiones objLoGS_ClaseGestiones = new LoGS_ClaseGestiones();
        try
        {
            EnGS_ClaseGestiones objEnGS_ClaseGestiones = new EnGS_ClaseGestiones();
            cmb_CodTipoGestion.Items.Clear();

            dt = objLoGS_ClaseGestiones.GS_TipoGestiones_Combo();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["CodTipoGestion"].ToString().Trim();
                lista.Text = dt.Rows[i]["Descripcion"].ToString().Trim();
                cmb_CodTipoGestion.Items.Add(lista);
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
        string str_codigo = "";
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

            foreach (GridViewRow row in gv.Rows)
            {
                if (((CheckBox)row.FindControl("chkPermiso")).Checked == true)
                {
                    if (gv.SelectedIndex != -1)
                    {
                        bool continuar;
                        bool.TryParse(Request.Form["hdnContinuar"], out continuar);
                        if (continuar)
                        {
                            str_codigo = row.Cells[1].Text.ToString();
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
            }
            
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message.ToString(), true);
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
    protected void gv_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void cmb_Estado_SelectedIndexChanged(object sender, EventArgs e)
    {
        Master.OcultarMensaje();
        limpiarMensaje();

        gv.PageIndex = 0;

        Regex expRegDni = new Regex(@"^\d{8}$");
        Regex expRegDiasMora = new Regex("^[0-9]+$");
        bool formatoCorrecto = true;
        if (txt_documento.Text.Length > 0)
        {
            if (expRegDni.IsMatch(txt_documento.Text))
            {
                formatoCorrecto = true;
            }
            else
            {
                formatoCorrecto = false;
                Master.MostrarMensaje("Formato de DNI Incorrecto", TipoMensaje.Error);
            }
        }
        if (txt_dias_mora.Text.Length > 0)
        {
            if (expRegDiasMora.IsMatch(txt_dias_mora.Text))
            {
                formatoCorrecto = true;
            }
            else
            {
                formatoCorrecto = false;
                Master.MostrarMensaje("Días de Mora es numérico", TipoMensaje.Error);
            }
        }
        if (formatoCorrecto == true)
        {
            RefrescarGrid();
        }
    }
    protected void cmb_CodTipoGestion_SelectedIndexChanged(object sender, EventArgs e)
    {
        Master.OcultarMensaje();
        limpiarMensaje();

        gv.PageIndex = 0;

        Regex expRegDni = new Regex(@"^\d{8}$");
        Regex expRegDiasMora = new Regex("^[0-9]+$");
        bool formatoCorrecto = true;
        if (txt_documento.Text.Length > 0)
        {
            if (expRegDni.IsMatch(txt_documento.Text))
            {
                formatoCorrecto = true;
            }
            else
            {
                formatoCorrecto = false;
                Master.MostrarMensaje("Formato de DNI Incorrecto", TipoMensaje.Error);
            }
        }
        if (txt_dias_mora.Text.Length > 0)
        {
            if (expRegDiasMora.IsMatch(txt_dias_mora.Text))
            {
                formatoCorrecto = true;
            }
            else
            {
                formatoCorrecto = false;
                Master.MostrarMensaje("Días de Mora es numérico", TipoMensaje.Error);
            }
        }
        if (formatoCorrecto == true)
        {
            RefrescarGrid();
        }
    }

    protected void cmb_JerarquiaB_SelectedIndexChanged(object sender, EventArgs e)
    {
        string jerarquiaB = "";
        jerarquiaB = cmb_JerarquiaB.SelectedValue.ToString();
        cmb_JerarquiaC.Items.Clear();
        cmb_JerarquiaD.Items.Clear();
        CargaComboJerarquiaC(jerarquiaB);
        CargaComboAsesores("0");
    }
    protected void cmb_JerarquiaC_SelectedIndexChanged(object sender, EventArgs e)
    {
        string jerarquiaC = "";
        jerarquiaC = cmb_JerarquiaC.SelectedValue.ToString().Trim();
        cmb_JerarquiaD.Items.Clear();
        CargaComboAsesores(jerarquiaC);
    }
    protected void cmb_JerarquiaD_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void CargaComboJerarquiaB()
    {
        DataTable dt = new DataTable();
        LoGS_JerarquiaB objLoGS_JerarquiaB = new LoGS_JerarquiaB();
        LoGS_JerarquiaA objLoGS_JerarquiaA = new LoGS_JerarquiaA();
        try
        {
            EnGS_JerarquiaB objEnGS_JerarquiaB = new EnGS_JerarquiaB();
            EnGS_JerarquiaA objEnGS_JerarquiaA = new EnGS_JerarquiaA();
            List<EnGS_JerarquiaB> ListEnGS_JerarquiaB = new List<EnGS_JerarquiaB>();
            List<EnGS_JerarquiaA> ListEnGS_JerarquiaA = new List<EnGS_JerarquiaA>();
            cmb_JerarquiaB.Items.Clear();

            objEnGS_JerarquiaB.nempresa = (String)this.Session["cempresa"];
            objEnGS_JerarquiaA.nempresa = (String)this.Session["cempresa"];
            ListEnGS_JerarquiaA.Add(objEnGS_JerarquiaA);
            dt = objLoGS_JerarquiaA.GS_JerarquiaA_Combo(ListEnGS_JerarquiaA);
            objEnGS_JerarquiaB.cod_jerarquiaA = dt.Rows[1]["cod_jerarquiaA"].ToString().Trim();

            ListEnGS_JerarquiaB.Add(objEnGS_JerarquiaB);

            dt.Clear();
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

    protected void CargaComboJerarquiaC(string jerarquiaB)
    {
        DataTable dt = new DataTable();
        LoGS_JerarquiaC objLoGS_JerarquiaC = new LoGS_JerarquiaC();
        try
        {
            EnGS_JerarquiaC objEnGS_JerarquiaC = new EnGS_JerarquiaC();
            List<EnGS_JerarquiaC> ListEnGS_JerarquiaC = new List<EnGS_JerarquiaC>();
            cmb_JerarquiaC.Items.Clear();


            objEnGS_JerarquiaC.cod_jerarquiaB = jerarquiaB;
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

    protected void CargaComboAsesores(string jerarquiaC)
    {
        DataTable dt = new DataTable();
        LoGS_JerarquiaC objLoGS_JerarquiaC = new LoGS_JerarquiaC();
        EnGS_JerarquiaC objEnGS_JerarquiaC = new EnGS_JerarquiaC();
        List<EnGS_JerarquiaC> ListEnGS_JerarquiaC = new List<EnGS_JerarquiaC>();
        LoGS_Gestion_Cobranza objLoGS_Gestion_Cobranza = new LoGS_Gestion_Cobranza();
        EnGS_Gestion_Cobranza objEnGS_Gestion_Cobranza = new EnGS_Gestion_Cobranza();
        List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza = new List<EnGS_Gestion_Cobranza>();
        objEnGS_Gestion_Cobranza.nEmpresa = (String)this.Session["cempresa"];//8
        try
        {
            //Llenamos empresa y cod de jerarquia B al objeto jerarquiaC
            //Esto para obtener el código del usuario administrador de la agencia seleccionada en cmb_JerarquiaB
            //Ya que para listar los asesores se necesita el código del administrador mediante el objeto objEnGS_GestionCobranza

            if (jerarquiaC == "0")
            {
                objEnGS_Gestion_Cobranza.CodUsuario = "0";
                ListEnGS_Gestion_Cobranza.Add(objEnGS_Gestion_Cobranza);
            }
            else
            {
                objEnGS_JerarquiaC.cod_jerarquiaC = jerarquiaC;
                objEnGS_JerarquiaC.nempresa = (String)this.Session["cempresa"];
                ListEnGS_JerarquiaC.Add(objEnGS_JerarquiaC);
                dt = objLoGS_JerarquiaC.GS_JerarquiaC_sp_ObtenerUsuario(ListEnGS_JerarquiaC);

                objEnGS_Gestion_Cobranza.CodUsuario = dt.Rows[0]["n_codi_usua"].ToString().Trim();
                ListEnGS_Gestion_Cobranza.Add(objEnGS_Gestion_Cobranza);
            }

            dt.Clear();
            cmb_JerarquiaD.Items.Clear();

            dt = objLoGS_Gestion_Cobranza.GS_Gestion_Cobranza_Asesores_x_Administrador_Lista(ListEnGS_Gestion_Cobranza);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListItem lista = new ListItem();
                //lista.Value = dt.Rows[i]["cod_jerarquiaD"].ToString().Trim();
                //lista.Text = dt.Rows[i]["nombres"].ToString().Trim();
                lista.Value = dt.Rows[i]["n_codi_usua"].ToString().Trim();
                lista.Text = dt.Rows[i]["nombres"].ToString().Trim();
                cmb_JerarquiaD.Items.Add(lista);

            }
        }
        catch (Exception excp)
        {
            throw excp;
        }
    }
}