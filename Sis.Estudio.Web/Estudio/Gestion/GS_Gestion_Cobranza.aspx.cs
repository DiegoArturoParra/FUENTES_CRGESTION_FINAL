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


public partial class Estudio_Gestion_GS_Gestion_Cobranza : System.Web.UI.Page
{
    #region Declaraciones
    private string PaginaDetalle = "GS_Gestion_CobranzaDetalle.aspx";
    private const string PaginaRetorno = "";
    private bool lcInicio = false;
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
        Metodo_Link2();
        #endregion select


    }
    #endregion Seleccionar

    protected void Page_Load(object sender, EventArgs e)
    {

        IABaseAsginaControles();
        //btnBuscar.Focus();
        if (!Page.IsPostBack)
        {
            lcInicio = true;
            //G_idopcion = OpcionModulo.MantModulo;
            this.Master.TituloModulo = "Gesti&oacute;n de Cobranzas";
            //btnDesactivar.Attributes.Add("onClick", "document.getElementById('hdnContinuar').value = confirm('¿Se desactivará El registro, ¿Desea continuar?');");
            //btnProcesar.Attributes.Add("onClick", "document.getElementById('hdnContinuar').value = confirm('¿Se Autorizará El efectivo, ¿Desea continuar?');");
            InicioOperacion();
            Cargar_Modulos();
            //RefrescarGrid();
            #region accesos
            //Accesos();
            #endregion accesos
            //ConfiguracionInicial();
            cmb_Estado.SelectedValue = "1";
            RefrescarGrid();
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

                if (gv.SelectedRow.Cells[16].Text.ToString() == "4" || gv.SelectedRow.Cells[18].Text.ToString() != "0" || gv.SelectedRow.Cells[16].Text.ToString() == "6" || gv.SelectedRow.Cells[16].Text.ToString() == "3")
                {
                    Master.MostrarMensaje("El Action Plan se encuentra desactivado, ya se ejecutó o está pendiente de aprobar", TipoMensaje.Advertencia);


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
            string str_estado = "?estado=n" ;
            string str_id = "&id=" + gv.SelectedRow.Cells[1].Text.ToString();
            string str_idcliente = "&idcliente=" + gv.SelectedRow.Cells[20].Text.ToString();
            string str_nombre = "&nombre=" + gv.SelectedRow.Cells[2].Text.ToString();
            Response.Redirect(PaginaDetalle + str_estado + str_id + str_idcliente + str_nombre);
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
            this.Session["GS_Gestion_Cobranza_Id_estado_gestion_cobranza"] = lcInicio ? "1" /*Indica que solo traera los "Pendientes" cuando cargue por primera vez la pag*/ : 
                                                                                        cmb_Estado.SelectedValue.ToString().Trim();
        }
        /////////////////////////////



        objEnGS_Gestion_Cobranza.Accion = "0";//Fijo
        objEnGS_Gestion_Cobranza.nEmpresa = (String)this.Session["cempresa"];//Fijo

        objEnGS_Gestion_Cobranza.dias_mora = this.Session["GS_Gestion_Cobranza_dias_mora"].ToString();//Variable
        objEnGS_Gestion_Cobranza.dias_mora_hasta = this.Session["GS_Gestion_Cobranza_dias_mora_hasta"].ToString();//Variable

        objEnGS_Gestion_Cobranza.fecha_ini = this.Session["GS_Gestion_Cobranza_fecha_ini"].ToString();//Variable
        objEnGS_Gestion_Cobranza.fecha_fin = this.Session["GS_Gestion_Cobranza_fecha_fin"].ToString();//Variable
        objEnGS_Gestion_Cobranza.CodTipoGestion = this.Session["GS_Gestion_Cobranza_CodTipoGestion"].ToString();//Fijo

        objEnGS_Gestion_Cobranza.CodUsuario = (String)this.Session["codusuario"];//Variable Quien se loguea

        objEnGS_Gestion_Cobranza.Nombres = this.Session["GS_Gestion_Cobranza_Nombres"].ToString();//Fijo
        objEnGS_Gestion_Cobranza.documento = this.Session["GS_Gestion_Cobranza_documento"].ToString();//Fijo
        objEnGS_Gestion_Cobranza.Id_estado_gestion_cobranza = this.Session["GS_Gestion_Cobranza_Id_estado_gestion_cobranza"].ToString();//Fijo

        ListEnGS_Gestion_Cobranza.Add(objEnGS_Gestion_Cobranza);

        try
        {
            DT_Datos = objLoGS_Gestion_Cobranza.GS_Gestion_Cobranza_Lista(ListEnGS_Gestion_Cobranza);
            /*if (objEnGS_Gestion_Cobranza.Id_estado_gestion_cobranza != "1" && objEnGS_Gestion_Cobranza.Id_estado_gestion_cobranza != "-1")
            {
            }else if (objEnGS_Gestion_Cobranza.Id_estado_gestion_cobranza == "-1" || objEnGS_Gestion_Cobranza.Id_estado_gestion_cobranza == "1")
            {
                DT_Datos = objLoGS_Gestion_Cobranza.GS_Gestion_Cobranza_Lista_Pendientes(ListEnGS_Gestion_Cobranza, "");
            }*/
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
            /*
            foreach (GridViewRow fila in gv.Rows)
            {

                if (fila.Cells[12].Text.ToString() == "1")
                {
                    fila.Cells[13].BackColor = Color.Yellow;
                }

                if (fila.Cells[12].Text.ToString() == "2")
                {
                    fila.Cells[13].BackColor = Color.Green;
                }

                if (fila.Cells[12].Text.ToString() == "3")
                {
                    fila.Cells[13].BackColor = Color.Red;
                }


            }
            */

            int Estado = 17;

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
                            if (gv.SelectedRow.Cells[17].Text.ToString() == EstadoGestion.C_ESTADO_RECHAZADO ||
                                //gv.SelectedRow.Cells[18].Text.ToString() != "0" ||
                                gv.SelectedRow.Cells[17].Text.ToString() == EstadoGestion.C_ESTADO_POR_APROBAR ||
                                gv.SelectedRow.Cells[17].Text.ToString() == EstadoGestion.C_ESTADO_EJECUTADO)
                            {
                                Master.MostrarMensaje("El Action Plan se encuentra desactivo, pendiente de aprobacion ó ya se finalizó", TipoMensaje.Advertencia);
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
            string str_codusuario = "&CodUsuario=" + (String)this.Session["codusuario"];
      
            string str_TIPOCONSULTA = "&tipoconsulta=" + "0";


            str_Parametros = str_tiporeporte + str_accionstore + str_IdReg_Gestion_Cobranza + id_carta + str_cempresa + str_TIPOCONSULTA;

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
    protected void txt_documento_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txt_nombres_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txt_FECHAFIN_TextChanged(object sender, EventArgs e)
    {
        RefrescarGrid();
    }
    protected void imgCal2_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void txt_FECHAINI_TextChanged(object sender, EventArgs e)
    {
        RefrescarGrid();
    }
}