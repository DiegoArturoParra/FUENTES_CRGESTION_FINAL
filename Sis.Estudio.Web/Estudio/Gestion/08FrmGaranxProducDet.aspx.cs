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

public partial class Estudio_Gestion_08FrmGaranxProducDet : System.Web.UI.Page
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
        string idifame = AcetPanel.GaranxProduc.iframe_id;
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
        Response.Redirect("08FrmGaranxProduc.aspx");
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

            Combo_TipoGarantia();
            Combo_TipoBien();            
            Listar();
            metodo_consultar();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  
    protected void Combo_TipoGarantia()
    {
        DataTable dt = new DataTable();
        try
        {
            cmb_TipoGarantia.Items.Clear();
            #region Carga_Variable

            List<EnGarantia> ListEn = new List<EnGarantia>();
            EnGarantia objEn = new EnGarantia();
            objEn.NEmpresa = (String)this.Session[Global.NEmpresa].ToString();
            ListEn.Add(objEn);
            #endregion Carga_Variable
            LoGarantia objLo = new LoGarantia();
            dt = objLo.Garantia_Listar(ListEn);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["CodGarantia"].ToString().Trim();
                lista.Text = dt.Rows[i]["Garantia"].ToString().Trim();
                cmb_TipoGarantia.Items.Add(lista);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void Combo_TipoBien()
    {
        DataTable dt = new DataTable();
        try
        {
            cmb_TipoBien.Items.Clear();

            LoTipoBien objLo = new LoTipoBien();
            dt = objLo.TipoBien_Listar();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["codTipoBien"].ToString().Trim();
                lista.Text = dt.Rows[i]["TipoBien"].ToString().Trim();
                cmb_TipoBien.Items.Add(lista);
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
            List<EnGaranxProduc> ListEnGaranxProduc = new List<EnGaranxProduc>();
            EnGaranxProduc objEnGaranxProduc = new EnGaranxProduc();
            objEnGaranxProduc.NEmpresa = (String)this.Session[Global.NEmpresa].ToString();
            objEnGaranxProduc.CodigoCliente = (String)this.Session[Global.CodCliente].ToString();
            objEnGaranxProduc.IdRegPRODUCTOS = hd_IdRegProductos.Value.Trim();
            ListEnGaranxProduc.Add(objEnGaranxProduc);
            #endregion Carga_Variable

            LoGaranxProduc objLo = new LoGaranxProduc();
            dt = objLo.Garantia_Producto_Listar(ListEnGaranxProduc);

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
            Cursor_Control(txt_DescripBien);
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

            Cursor_Control(txt_DescripBien);
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
            List<EnGaranxProduc> ListEnGaranxProduc = new List<EnGaranxProduc>();
            EnGaranxProduc objEnGaranxProduc = new EnGaranxProduc();
            objEnGaranxProduc.NEmpresa = (String)this.Session[Global.NEmpresa].ToString();
            objEnGaranxProduc.IdReg = str_Codigo;
            //objEnGaranxProduc.CodUsuario = (String)this.Session[Global.CodUsuario].ToString(); ;
            ListEnGaranxProduc.Add(objEnGaranxProduc);
            #endregion Carga_Variable

            LoGaranxProduc objLo = new LoGaranxProduc();

            dt = objLo.Garantia_Producto_Listar_Reg(ListEnGaranxProduc);

            if (dt.Rows.Count > 0)
            {
                #region CONTROLES_MANTENIMIENTO
                txt_IdReg.Text = dt.Rows[0]["IdReg"].ToString().Trim();
                cmb_TipoGarantia.SelectedValue = dt.Rows[0]["CodGarantia"].ToString().Trim();
                cmb_TipoBien.SelectedValue = dt.Rows[0]["CodTipoBien"].ToString().Trim();

                txt_DescripBien.Text = dt.Rows[0]["DescripBien"].ToString().Trim();
                txt_Telefonos.Text = dt.Rows[0]["Telefonos"].ToString().Trim();
                txt_Propietarios.Text = dt.Rows[0]["Propietarios"].ToString().Trim();
                txt_NombreGarante.Text = dt.Rows[0]["NombreGarante"].ToString().Trim();

                txt_Beneficiario.Text = dt.Rows[0]["Beneficiario"].ToString().Trim();
                txt_Ubicacion.Text = dt.Rows[0]["Ubicacion"].ToString().Trim();
                txt_Direccion.Text = dt.Rows[0]["Direccion"].ToString().Trim();
                txt_area.Text = dt.Rows[0]["area"].ToString().Trim();
                txt_DNI.Text = dt.Rows[0]["DNI"].ToString().Trim();
                txt_ValorComercial.Text = dt.Rows[0]["ValorComercial"].ToString().Trim();
                txt_MontoGarantia.Text = dt.Rows[0]["MontoGarantia"].ToString().Trim();
                txt_CartaFianza.Text = dt.Rows[0]["CartaFianza"].ToString().Trim();
                txt_FechaUltTasacion.Text = dt.Rows[0]["FechaUltTasacion"].ToString().Trim();
                txt_VencimientoCF.Text = dt.Rows[0]["VencimientoCF"].ToString().Trim();
                txt_ValorGravamen.Text = dt.Rows[0]["ValorGravamen"].ToString().Trim();
                txt_NumPartidaElec.Text = dt.Rows[0]["NumPartidaElec"].ToString().Trim();
                txt_Observacion.Text = dt.Rows[0]["Observacion"].ToString().Trim();
                txt_Restricciones.Text = dt.Rows[0]["Restricciones"].ToString().Trim();
                txt_CoberturaCF.Text = dt.Rows[0]["CoberturaCF"].ToString().Trim();
                cmb_Estado.SelectedValue = dt.Rows[0]["Estado"].ToString().Trim();

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
            txt_DescripBien.Text = String.Empty;
            txt_Telefonos.Text = String.Empty;
            txt_Propietarios.Text = String.Empty;
            txt_NombreGarante.Text = String.Empty;
            txt_Beneficiario.Text = String.Empty;
            txt_Ubicacion.Text = String.Empty;
            txt_Direccion.Text = String.Empty;
            txt_area.Text = String.Empty;
            txt_DNI.Text = String.Empty;
            txt_ValorComercial.Text = String.Empty;
            txt_MontoGarantia.Text = String.Empty;
            txt_CartaFianza.Text = String.Empty;
            txt_FechaUltTasacion.Text = String.Empty;
            txt_VencimientoCF.Text = String.Empty;
            txt_ValorGravamen.Text = String.Empty;
            txt_NumPartidaElec.Text = String.Empty;
            txt_Observacion.Text = String.Empty;
            txt_Restricciones.Text = String.Empty;
            txt_CoberturaCF.Text = String.Empty;

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
        cmb_TipoGarantia.Enabled = estado;
        cmb_TipoBien.Enabled = estado;
        txt_DescripBien.Enabled = estado;
        txt_Telefonos.Enabled = estado;
        txt_Propietarios.Enabled = estado;
        txt_NombreGarante.Enabled = estado;
        txt_Beneficiario.Enabled = estado;
        txt_Ubicacion.Enabled = estado;
        txt_Direccion.Enabled = estado;
        txt_area.Enabled = estado;
        txt_DNI.Enabled = estado;
        txt_ValorComercial.Enabled = estado;
        txt_MontoGarantia.Enabled = estado;
        txt_CartaFianza.Enabled = estado;
        txt_FechaUltTasacion.Enabled = estado;
        txt_VencimientoCF.Enabled = estado;
        txt_ValorGravamen.Enabled = estado;
        txt_NumPartidaElec.Enabled = estado;
        txt_Observacion.Enabled = estado;
        txt_Restricciones.Enabled = estado;
        txt_CoberturaCF.Enabled = estado;
        cmb_Estado.Enabled = estado;

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
            List<EnGaranxProduc> ListEnGaranxProduc = new List<EnGaranxProduc>();
            EnGaranxProduc objEnGaranxProduc = new EnGaranxProduc();

            objEnGaranxProduc.NEmpresa = (String)this.Session[Global.NEmpresa].ToString();
            objEnGaranxProduc.CodigoCliente = (String)this.Session[Global.CodCliente].ToString();
            objEnGaranxProduc.IdRegProductos = hd_IdRegProductos.Value.Trim();

            objEnGaranxProduc.CodGarantia = cmb_TipoGarantia.SelectedValue.ToString().Trim();
            objEnGaranxProduc.CodTipoBien = cmb_TipoBien.SelectedValue.ToString().Trim();
            objEnGaranxProduc.DescripBien = txt_DescripBien.Text.Trim();
            objEnGaranxProduc.Telefonos = txt_Telefonos.Text.Trim();
            objEnGaranxProduc.Propietarios = txt_Propietarios.Text.Trim();
            objEnGaranxProduc.NombreGarante = txt_NombreGarante.Text.Trim();
            objEnGaranxProduc.Beneficiario = txt_Beneficiario.Text.Trim();
            objEnGaranxProduc.Ubicacion = txt_Ubicacion.Text.Trim();
            objEnGaranxProduc.Direccion = txt_Direccion.Text.Trim();
            objEnGaranxProduc.area = txt_area.Text.Trim();
            objEnGaranxProduc.DNI = txt_DNI.Text.Trim();
            objEnGaranxProduc.ValorComercial = Util.FormateaDecimal(txt_ValorComercial.Text.Trim());
            objEnGaranxProduc.MontoGarantia = Util.FormateaDecimal(txt_MontoGarantia.Text.Trim());
            objEnGaranxProduc.CartaFianza = Util.FormateaDecimal(txt_CartaFianza.Text.Trim());
            objEnGaranxProduc.FechaUltTasacion = Util.FormateaFecha(txt_FechaUltTasacion.Text.Trim());
            objEnGaranxProduc.VencimientoCF = Util.FormateaFecha(txt_VencimientoCF.Text.Trim());
            objEnGaranxProduc.ValorGravamen = Util.FormateaDecimal(txt_ValorGravamen.Text.Trim());
            objEnGaranxProduc.NumPartidaElec = txt_NumPartidaElec.Text.Trim();
            objEnGaranxProduc.Observacion = txt_Observacion.Text.Trim();
            objEnGaranxProduc.Restricciones = txt_Restricciones.Text.Trim();
            objEnGaranxProduc.CoberturaCF = txt_CoberturaCF.Text.Trim();
            objEnGaranxProduc.Estado = cmb_Estado.SelectedValue.ToString();
            objEnGaranxProduc.CodUsuario = (String)this.Session[Global.CodUsuario].ToString();

            ListEnGaranxProduc.Add(objEnGaranxProduc);
            #endregion Carga_Variable
            LoGaranxProduc objLo = new LoGaranxProduc();
            msg = objLo.Garantia_Producto_INS(ListEnGaranxProduc);

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
            List<EnGaranxProduc> ListEnGaranxProduc = new List<EnGaranxProduc>();
            EnGaranxProduc objEnGaranxProduc = new EnGaranxProduc();

            objEnGaranxProduc.IdReg = txt_IdReg.Text.Trim();
            objEnGaranxProduc.NEmpresa = (String)this.Session[Global.NEmpresa].ToString();
            objEnGaranxProduc.CodigoCliente = (String)this.Session[Global.CodCliente].ToString();
            objEnGaranxProduc.IdRegProductos = hd_IdRegProductos.Value.Trim();

            objEnGaranxProduc.CodGarantia = cmb_TipoGarantia.SelectedValue.ToString().Trim();
            objEnGaranxProduc.CodTipoBien = cmb_TipoBien.SelectedValue.ToString().Trim();
            objEnGaranxProduc.DescripBien = txt_DescripBien.Text.Trim();
            objEnGaranxProduc.Telefonos = txt_Telefonos.Text.Trim();
            objEnGaranxProduc.Propietarios = txt_Propietarios.Text.Trim();
            objEnGaranxProduc.NombreGarante = txt_NombreGarante.Text.Trim();
            objEnGaranxProduc.Beneficiario = txt_Beneficiario.Text.Trim();
            objEnGaranxProduc.Ubicacion = txt_Ubicacion.Text.Trim();
            objEnGaranxProduc.Direccion = txt_Direccion.Text.Trim();
            objEnGaranxProduc.area = txt_area.Text.Trim();
            objEnGaranxProduc.DNI = txt_DNI.Text.Trim();
            objEnGaranxProduc.ValorComercial = Util.FormateaDecimal(txt_ValorComercial.Text.Trim());
            objEnGaranxProduc.MontoGarantia = Util.FormateaDecimal(txt_MontoGarantia.Text.Trim());
            objEnGaranxProduc.CartaFianza = Util.FormateaDecimal(txt_CartaFianza.Text.Trim());
            objEnGaranxProduc.FechaUltTasacion = Util.FormateaFecha(txt_FechaUltTasacion.Text.Trim());
            objEnGaranxProduc.VencimientoCF = Util.FormateaFecha(txt_VencimientoCF.Text.Trim());
            objEnGaranxProduc.ValorGravamen = Util.FormateaDecimal(txt_ValorGravamen.Text.Trim());
            objEnGaranxProduc.NumPartidaElec = txt_NumPartidaElec.Text.Trim();
            objEnGaranxProduc.Observacion = txt_Observacion.Text.Trim();
            objEnGaranxProduc.Restricciones = txt_Restricciones.Text.Trim();
            objEnGaranxProduc.CoberturaCF = txt_CoberturaCF.Text.Trim();
            objEnGaranxProduc.Estado = cmb_Estado.SelectedValue.ToString();
            objEnGaranxProduc.CodUsuario = (String)this.Session[Global.CodUsuario].ToString();

            ListEnGaranxProduc.Add(objEnGaranxProduc);
            #endregion Carga_Variable

            LoGaranxProduc objLo = new LoGaranxProduc();
            msg = objLo.Garantia_Producto_UPD(ListEnGaranxProduc);
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

        if (txt_DescripBien.Text.Trim().Length < 1)
        {
            Master.MostrarMensaje("Ingrese Descripcion", TipoMensaje.Advertencia);
            Cursor_Control(txt_DescripBien);
            return false;
        }

        return true;
    }
    #endregion funciones

}