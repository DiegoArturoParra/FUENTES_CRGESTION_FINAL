using System;
using acetsoft;
using System.Drawing;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Data.SqlClient;
using System.IO;
using System.ServiceModel;
using AjaxControlToolkit;
using System.Xml;
using System.Xml.Xsl;

using Sis.Estudio.Logic.MSSQL.Estudio;
using Sis.Estudio.Entity;

public partial class Estudio_Gestion_09FrmCronogDePagoDet : System.Web.UI.Page
{    
    public string mstrEstado;
    #region Constructor
    #region Seleccionar
    protected override void Render(System.Web.UI.HtmlTextWriter writer)
    {
        #region Validacion
        string estado = (String)ViewState["estado"];
        if (estado == "consultar")
        {
            AddRowSelectToGridView(gv);
        }
        #endregion Validacion
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

            }
        }
        #endregion select
    }
    #endregion Seleccionar
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                //Master.TituloModulo = TitulosPaginas.TITPAGINA_Parametros;                
                btn_Grabar.Attributes.Add("onClick", "document.getElementById('hdnContinuar').value = confirm('¿Se guardara el registro, ¿Desea continuar?');");
                Inicio();
            }
        }
        catch (Exception ex)
        {
            Master.MostrarMensaje(ex.Message.ToString(), TipoMensaje.Error);
        }
    }
    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        #region Redim
        string idifame = AcetPanel.ProduCliente.iframe_id;
        #region ResizeFicha
        StringBuilder sb = new StringBuilder();
        sb.Append("<script>");
        sb.Append("ResizeFicha('" + idifame + "');");
        sb.Append("</script>");
        ScriptManager.RegisterStartupScript(this, typeof(Page), "", sb.ToString(), false);
        #endregion ResizeFicha
        #endregion Redim
    }
    #endregion Constructor
    #region Eventos
    #region Grid
    protected void gv_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Master.OcultarMensaje();
            Seleccionar();
        }
        catch (Exception ex)
        {
            Master.MostrarMensaje(ex.Message.ToString(), TipoMensaje.Error);
        }
    }
    #endregion Grid
    #region Botones
    protected void btn_Refresca_Click(object sender, EventArgs e)
    {
        try
        {
            Master.OcultarMensaje();
            Listar();

        }
        catch (Exception ex)
        {
            Master.MostrarMensaje(ex.Message.ToString(), TipoMensaje.Error);
        }
    }
    protected void btn_Agregar_Click(object sender, EventArgs e)
    {
        try
        {
            metodo_agregar();
        }
        catch (Exception ex)
        {
            Master.MostrarMensaje(ex.Message.ToString(), TipoMensaje.Error);
        }

    }
    protected void btn_Modificar_Click(object sender, EventArgs e)
    {
        try
        {
            Master.OcultarMensaje();
            if (gv.SelectedIndex != -1)
            {
                metodo_modificar();
            }
            else
            {
                Master.MostrarMensaje(Mensajes.MSG_MENSAJESELECCIONARREGISTRO, TipoMensaje.Error);
            }
        }
        catch (Exception ex)
        {
            Master.MostrarMensaje(ex.Message.ToString(), TipoMensaje.Error);
        }
    }

    protected void btn_Grabar_Click(object sender, EventArgs e)
    {
        try
        {

            Master.OcultarMensaje();
            bool continuar;
            bool.TryParse(Request.Form["hdnContinuar"], out continuar);
            if (continuar)
            {
                if (Valida_Datos() == false)  //VALIDA
                {
                    return;
                }
                string estado = (String)ViewState["estado"];
                if (estado == "agregar")
                {
                    Graba();  // GRABA
                }

                if (estado == "modificar")
                {
                    Modifica();  // ACTUALIZA
                }

            }
            else
            {
                Master.MostrarMensaje(Mensaje.M_OPERACION_CANCELADA, TipoMensaje.Advertencia);
            }

        }
        catch (Exception ex)
        {
            Master.MostrarMensaje(ex.Message.ToString(), TipoMensaje.Error);
        }
    }
    protected void btn_Cancelar_Click(object sender, EventArgs e)
    {
        try
        {
            Master.OcultarMensaje();

            #region Validacion
            string estado = (String)ViewState["estado"];
            if (estado == "agregar" || estado == "modificar")
            {
                MostrarDatos(hd_Codigo.Value.ToString());
            }
            #endregion Validacion
            metodo_consultar();
        }
        catch (Exception ex)
        {
            Master.MostrarMensaje(ex.Message.ToString(), TipoMensaje.Error);
        }
    }

    protected void btn_Retornar_Click(object sender, EventArgs e)
    {
        //Response.Redirect("09FrmCronogDePago.aspx");
        Response.Redirect("06FrmProduCliente.aspx");        
    }
    #endregion Botones
    #region Combos

    #endregion Combos
    #endregion Eventos
    #region Metodos
    private void Inicio()
    {
        try
        {
            #region Parametros
            if (Request[Global.IdRegProducto] != null)
            {
                hd_IdRegProductos.Value = Request[Global.IdRegProducto];
            }
            #endregion Parametros
            Combo_EstadoCronograma();
            Combo_CalificacionSBS();
            Listar();
            metodo_consultar();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void Combo_EstadoCronograma()
    {
        DataTable dt = new DataTable();
        try
        {
            cmb_EstadoCronograma.Items.Clear();
            #region Carga_Variable
            List<EnAplicacion> ListEnAplicacion = new List<EnAplicacion>();
            EnAplicacion objEn = new EnAplicacion();
            objEn.NEmpresa = (String)this.Session[Global.NEmpresa].ToString();            
            ListEnAplicacion.Add(objEn);
            #endregion Carga_Variable
            LoAplicacion objLo = new LoAplicacion();
            dt = objLo.Aplicacion_EstadoCronograma(ListEnAplicacion);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["CodEstadoCronograma"].ToString().Trim();
                lista.Text = dt.Rows[i]["EstadoCronograma"].ToString().Trim();
                cmb_EstadoCronograma.Items.Add(lista);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void Combo_CalificacionSBS()
    {
        DataTable dt = new DataTable();
        try
        {
            cmb_CalificacionSBS.Items.Clear();

            LoCalificacionSBS objLo = new LoCalificacionSBS();
            dt = objLo.CalificacionSBS_Listar();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["CodCalificacionSBS"].ToString().Trim();
                lista.Text = dt.Rows[i]["CalificacionSBS"].ToString().Trim();
                cmb_CalificacionSBS.Items.Add(lista);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void Listar()
    {
        DataTable dt;
        try
        {
            gv.DataSource = null;
            gv.DataBind();

            #region validacion
            #endregion validacion

            #region Carga_Variable
            List<EnCronogDePago> ListEnCronogDePago = new List<EnCronogDePago>();
            EnCronogDePago objEnCronogDePago = new EnCronogDePago();
            objEnCronogDePago.NEmpresa = (String)this.Session[Global.NEmpresa].ToString();
            objEnCronogDePago.CodigoCliente = (String)this.Session[Global.CodCliente].ToString();
            objEnCronogDePago.IdRegPRODUCTOS = hd_IdRegProductos.Value.Trim();
            ListEnCronogDePago.Add(objEnCronogDePago);
            #endregion Carga_Variable

            LoCronogDePago objLo = new LoCronogDePago();
            dt = objLo.CronogramaPago_Listar(ListEnCronogDePago);

            gv.DataSource = dt;
            gv.DataBind();
            if (dt.Rows.Count > 0)
            {
                lbl_Cantidad.Text = dt.Rows.Count.ToString() + Mensaje.M_TEXTO_REGISTROS;
            }
            else
            {
                lbl_Cantidad.Text = Mensaje.M_CERO_REGISTROS;
            }
            gv.SelectedIndex = -1;
            gv.EditIndex = -1;
            gv.PageIndex = 0;
            ClearRow();

        }

        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void Seleccionar()
    {
        try
        {
            if (gv.SelectedIndex != -1)
            {
                string str_Codigo = gv.SelectedRow.Cells[1].Text.ToString();
                hd_Codigo.Value = str_Codigo;
                MostrarDatos(str_Codigo);
            }
            else
            {
                Master.MostrarMensaje(Mensajes.MSG_MENSAJESELECCIONARREGISTRO, TipoMensaje.Error);
            }
        }
        catch (Exception ex)
        {
            Master.MostrarMensaje(ex.Message.ToString(), TipoMensaje.Error);
        }
    }
    protected void ClearRow()
    {
        hd_Codigo.Value = "";
    }

    protected void metodo_agregar()
    {
        try
        {
            #region accesos_opcion

            #endregion accesos_opcion


            mstrEstado = "agregar";
            ViewState.Add("estado", mstrEstado);
            LimpiarControles();
            Estado_Controles(false);

            txt_IdReg.Enabled = false;
            Cursor_Control(txt_NroCuotas);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void metodo_modificar()
    {
        try
        {

            #region accesos_opcion
            #endregion accesos_opcion
            mstrEstado = "modificar";
            ViewState.Add("estado", mstrEstado);
            Estado_Controles(false);
            txt_IdReg.Enabled = false;

            Cursor_Control(txt_NroCuotas);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void metodo_consultar()
    {
        try
        {

            #region accesos_opcion
            #endregion accesos_opcion
            mstrEstado = "consultar";
            ViewState.Add("estado", mstrEstado);
            Estado_Controles(true);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void MostrarDatos(string str_Codigo)
    {
        DataTable dt = new DataTable();
        try
        {
            Master.OcultarMensaje();
            LimpiarControles();

            #region Validacion
            if (str_Codigo.Trim().Length < 1)
            {
                return;
            }
            #endregion Validacion

            #region Carga_Variable
            List<EnCronogDePago> ListEnCronogDePago = new List<EnCronogDePago>();
            EnCronogDePago objEnCronogDePago = new EnCronogDePago();
            objEnCronogDePago.NEmpresa = (String)this.Session[Global.NEmpresa].ToString();
            objEnCronogDePago.IdReg = str_Codigo;
            //objEnCronogDePago.CodUsuario = (String)this.Session[Global.CodUsuario].ToString(); ;
            ListEnCronogDePago.Add(objEnCronogDePago);
            #endregion Carga_Variable

            LoCronogDePago objLo = new LoCronogDePago();

            dt = objLo.CronogramaPago_Listar_Reg(ListEnCronogDePago);

            if (dt.Rows.Count > 0)
            {
                #region CONTROLES_MANTENIMIENTO
                txt_IdReg.Text = dt.Rows[0]["IdReg"].ToString().Trim();

                txt_NroCuotas.Text = dt.Rows[0]["NroCuotas"].ToString().Trim();
                txt_FechaVencimiento.Text = dt.Rows[0]["FechaVencimiento"].ToString().Trim();
                txt_FechaPago.Text = dt.Rows[0]["FechaPago"].ToString().Trim();
                txt_MontoCuota.Text = dt.Rows[0]["MontoCuota"].ToString().Trim();
                cmb_EstadoCronograma.SelectedValue = dt.Rows[0]["CodEstadoCronograma"].ToString().Trim();
                txt_Capital.Text = dt.Rows[0]["Capital"].ToString().Trim();
                txt_Interes.Text = dt.Rows[0]["Interes"].ToString().Trim();
                txt_SaldoCapital.Text = dt.Rows[0]["SaldoCapital"].ToString().Trim();
                cmb_CalificacionSBS.SelectedValue = dt.Rows[0]["CodCalificacionSBS"].ToString().Trim();

                #endregion CONTROLES_MANTENIMIENTO

                #region CONTROLES_INFORMATIVOS
                #endregion CONTROLES_INFORMATIVOS
            }
        }
        catch (Exception excp)
        {
            throw excp;
        }
    }
    protected void LimpiarControles()
    {
        try
        {
            //txt_IdReg.Text = String.Empty;
            txt_NroCuotas.Text = String.Empty;
            txt_FechaVencimiento.Text = String.Empty;
            txt_FechaPago.Text = String.Empty;
            txt_MontoCuota.Text = String.Empty;

            txt_Capital.Text = String.Empty;
            txt_Interes.Text = String.Empty;
            txt_SaldoCapital.Text = String.Empty;




        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void Estado_Controles(bool estado)
    {

        btn_Agregar.Visible = estado;
        btn_Modificar.Visible = estado;
        btn_Retornar.Visible = estado;

        gv.Enabled = estado;

        #region Conmutador
        if (estado == true)
        {
            estado = false;
        }
        else
        {
            estado = true;
        }
        #endregion Conmutador

        txt_IdReg.Enabled = estado;

        txt_IdReg.Enabled = estado;
        txt_NroCuotas.Enabled = estado;
        txt_FechaVencimiento.Enabled = estado;
        txt_FechaPago.Enabled = estado;
        txt_MontoCuota.Enabled = estado;
        cmb_EstadoCronograma.Enabled = estado;
        txt_Capital.Enabled = estado;
        txt_Interes.Enabled = estado;
        txt_SaldoCapital.Enabled = estado;
        cmb_CalificacionSBS.Enabled = estado;


        btn_Grabar.Visible = estado;
        btn_Cancelar.Visible = estado;

    }

    protected void Cursor_Control(TextBox Nombre_Control)
    {
        //****************************************************************************************
        //* Nomre       : SetFocus()                         NSE 04/DICIEMBRE/2009
        //****************************************************************************************
        try
        {
            ScriptManager scriptManager1 = ScriptManager.GetCurrent(this.Page);
            scriptManager1.SetFocus(Nombre_Control);
        }
        catch
        {
            return;
        }
    }
    #endregion Metodos
    #region Estructura

    #endregion Estructura
    #region Datos
    private void Graba()
    {
        try
        {
            string msg = "";
            #region Carga_Variable
            List<EnCronogDePago> ListEnCronogDePago = new List<EnCronogDePago>();
            EnCronogDePago objEnCronogDePago = new EnCronogDePago();

            objEnCronogDePago.NEmpresa = (String)this.Session[Global.NEmpresa].ToString();
            objEnCronogDePago.CodigoCliente = (String)this.Session[Global.CodCliente].ToString();
            objEnCronogDePago.IdRegProductos = hd_IdRegProductos.Value.Trim();
            objEnCronogDePago.NroCuotas =  Util.FormateaEntero(txt_NroCuotas.Text);
            objEnCronogDePago.FechaVencimiento = Util.FormateaFecha(txt_FechaVencimiento.Text);
            objEnCronogDePago.FechaPago = Util.FormateaFecha(txt_FechaPago.Text);
            objEnCronogDePago.MontoCuota = Util.FormateaDecimal(txt_MontoCuota.Text);
            objEnCronogDePago.CodEstadoCronograma = cmb_EstadoCronograma.SelectedValue.ToString();
            objEnCronogDePago.Capital = Util.FormateaDecimal(txt_Capital.Text);
            objEnCronogDePago.Interes = Util.FormateaDecimal(txt_Interes.Text);
            objEnCronogDePago.SaldoCapital = Util.FormateaDecimal(txt_SaldoCapital.Text);
            objEnCronogDePago.CodCalificacionSBS = cmb_CalificacionSBS.SelectedValue.ToString();
            objEnCronogDePago.CodUsuario = (String)this.Session[Global.CodUsuario].ToString();
            ListEnCronogDePago.Add(objEnCronogDePago);
            #endregion Carga_Variable
            LoCronogDePago objLo = new LoCronogDePago();
            msg = objLo.CronogramaPago_INS(ListEnCronogDePago);

            if (msg == "exito")
            {
                Master.MostrarMensaje(Mensaje.M_OPERACION_SATISFACTORIA, TipoMensaje.Exito);
                Listar();
                metodo_consultar();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void Modifica()
    {
        try
        {
            string msg = "";

            #region Carga_Variable
            List<EnCronogDePago> ListEnCronogDePago = new List<EnCronogDePago>();
            EnCronogDePago objEnCronogDePago = new EnCronogDePago();

            objEnCronogDePago.IdReg = txt_IdReg.Text.Trim();
            objEnCronogDePago.NEmpresa = (String)this.Session[Global.NEmpresa].ToString();
            objEnCronogDePago.CodigoCliente = (String)this.Session[Global.CodCliente].ToString();
            objEnCronogDePago.IdRegProductos = hd_IdRegProductos.Value.Trim();
            objEnCronogDePago.NroCuotas = Util.FormateaEntero(txt_NroCuotas.Text);
            objEnCronogDePago.FechaVencimiento = Util.FormateaFecha(txt_FechaVencimiento.Text);
            objEnCronogDePago.FechaPago = Util.FormateaFecha(txt_FechaPago.Text);
            objEnCronogDePago.MontoCuota = Util.FormateaDecimal(txt_MontoCuota.Text);
            objEnCronogDePago.CodEstadoCronograma = cmb_EstadoCronograma.SelectedValue.ToString();
            objEnCronogDePago.Capital = Util.FormateaDecimal(txt_Capital.Text);
            objEnCronogDePago.Interes = Util.FormateaDecimal(txt_Interes.Text);
            objEnCronogDePago.SaldoCapital = Util.FormateaDecimal(txt_SaldoCapital.Text);
            objEnCronogDePago.CodCalificacionSBS = cmb_CalificacionSBS.SelectedValue.ToString();
            objEnCronogDePago.CodUsuario = (String)this.Session[Global.CodUsuario].ToString();
            ListEnCronogDePago.Add(objEnCronogDePago);
            #endregion Carga_Variable

            LoCronogDePago objLo = new LoCronogDePago();
            msg = objLo.CronogramaPago_UPD(ListEnCronogDePago);
            if (msg == "exito")
            {
                Master.MostrarMensaje(Mensaje.M_OPERACION_SATISFACTORIA, TipoMensaje.Exito);
                Listar();
                metodo_consultar();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion Datos
    #region funciones
    private bool Valida_Datos()
    {
        string estado = (String)ViewState["estado"];
        if (estado == "modificar")
        {
            if (hd_Codigo.Value == "")
            {
                Master.MostrarMensaje(Mensaje.M_VALIDACION_DEFINICION_ID, TipoMensaje.Advertencia);
                return false;
            }
        }

        if (txt_NroCuotas.Text.Trim().Length < 1)
        {
            Master.MostrarMensaje("Ingrese Nro Cuotas", TipoMensaje.Advertencia);
            Cursor_Control(txt_NroCuotas);
            return false;
        }

        return true;
    }
    #endregion funciones
}