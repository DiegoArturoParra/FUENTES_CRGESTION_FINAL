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

public partial class Estudio_Gestion_06FrmProduClienteDet : System.Web.UI.Page
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
        Response.Redirect("06FrmProduCliente.aspx");
    }
    #endregion Botones
    #region Combos
    protected void cmb_Producto_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Master.OcultarMensaje();

            Combo_SubProducto();
        }
        catch (Exception ex)
        {
            Master.MostrarMensaje(ex.Message.ToString(), TipoMensaje.Error);
        }

    }
    protected void cmb_Gerente_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            Master.OcultarMensaje();

            Combo_Zona();
            Combo_Sectorista();

        }
        catch (Exception ex)
        {
            Master.MostrarMensaje(ex.Message.ToString(), TipoMensaje.Error);
        }
    }

    protected void cmb_Zona_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Master.OcultarMensaje();

            Combo_Sectorista();
        }
        catch (Exception ex)
        {
            Master.MostrarMensaje(ex.Message.ToString(), TipoMensaje.Error);
        }

    }
    #endregion Combos
    #endregion Eventos
    #region Metodos
    private void Inicio()
    {
        try
        {
            Combo_Producto();
            Combo_SubProducto();
            Combo_Moneda();
            Combo_Sucursal();
            Combo_Gerente();
            Combo_Zona();
            Combo_Sectorista();

            Listar();

            metodo_consultar();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void Combo_Producto()
    {
        DataTable dt = new DataTable();
        try
        {

            cmb_Producto.Items.Clear();

            #region Carga_Variable
            List<EnProducto> ListE = new List<EnProducto>();
            EnProducto objEn = new EnProducto();
            objEn.NEmpresa = (String)this.Session[Global.NEmpresa].ToString();
            ListE.Add(objEn);
            #endregion Carga_Variable
            LoProducto objLo = new LoProducto();
            dt = objLo.Producto_Listar(ListE);


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["CodProducto"].ToString().Trim();
                lista.Text = dt.Rows[i]["Producto"].ToString().Trim();
                cmb_Producto.Items.Add(lista);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void Combo_SubProducto()
    {
        DataTable dt = new DataTable();
        try
        {

            cmb_SubProducto.Items.Clear();
            #region Carga_Variable

            List<EnSubProducto> ListEn = new List<EnSubProducto>();
            EnSubProducto objEn = new EnSubProducto();
            objEn.NEmpresa = (String)this.Session[Global.NEmpresa].ToString();
            objEn.CodProducto = cmb_Producto.SelectedValue.ToString();
            ListEn.Add(objEn);
            #endregion Carga_Variable
            LoSubProducto objLo = new LoSubProducto();
            dt = objLo.SubProducto_Listar_X_Producto(ListEn);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["CodSubProducto"].ToString().Trim();
                lista.Text = dt.Rows[i]["SubProducto"].ToString().Trim();
                cmb_SubProducto.Items.Add(lista);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void Combo_Moneda()
    {
        DataTable dt = new DataTable();
        try
        {
            cmb_Moneda.Items.Clear();            
            LoAplicacion objLo = new LoAplicacion();
            dt = objLo.Aplicacion_Moneda();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["Moneda"].ToString().Trim();
                lista.Text = dt.Rows[i]["descrip"].ToString().Trim();
                cmb_Moneda.Items.Add(lista);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void Combo_Sucursal()
    {
        DataTable dt = new DataTable();
        try
        {
            cmb_Sucursal.Items.Clear();
            #region Carga_Variable
            List<EnSucursal> ListEnSucursal = new List<EnSucursal>();
            EnSucursal objEn = new EnSucursal();
            objEn.NEmpresa = (String)this.Session[Global.NEmpresa].ToString();
            ListEnSucursal.Add(objEn);
            #endregion Carga_Variable
            LoSucursal objLo = new LoSucursal();
            dt = objLo.Sucursal_Listar(ListEnSucursal);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["CodSucursal"].ToString().Trim();
                lista.Text = dt.Rows[i]["Sucursal"].ToString().Trim();
                cmb_Sucursal.Items.Add(lista);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void Combo_Gerente()
    {
        DataTable dt = new DataTable();
        try
        {
            cmb_Gerente.Items.Clear();
            #region Carga_Variable
            List<EnGerencia> ListEn = new List<EnGerencia>();
            EnGerencia objEn = new EnGerencia();
            objEn.NEmpresa = (String)this.Session[Global.NEmpresa].ToString();
            ListEn.Add(objEn);
            #endregion Carga_Variable

            LoGerencia objLo = new LoGerencia();
            dt = objLo.Gerencia_Listar(ListEn);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["CodGerencia"].ToString().Trim();
                lista.Text = dt.Rows[i]["Gerencia"].ToString().Trim();
                cmb_Gerente.Items.Add(lista);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void Combo_Zona()
    {
        DataTable dt = new DataTable();
        try
        {

            cmb_Zona.Items.Clear();
            #region Carga_Variable

            List<EnZona> ListEn = new List<EnZona>();
            EnZona objEn = new EnZona();
            objEn.NEmpresa = (String)this.Session[Global.NEmpresa].ToString();
            objEn.CodGerencia = cmb_Gerente.SelectedValue.ToString();
            ListEn.Add(objEn);
            #endregion Carga_Variable

            LoZona objLo = new LoZona();
            dt = objLo.Zona_Listar_X_Gerencia(ListEn);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["CodZona"].ToString().Trim();
                lista.Text = dt.Rows[i]["Zona"].ToString().Trim();
                cmb_Zona.Items.Add(lista);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void Combo_Sectorista()
    {
        DataTable dt = new DataTable();
        try
        {

            cmb_Sectorista.Items.Clear();
            #region Carga_Variable

            List<EnSectorista> ListEnSectorista = new List<EnSectorista>();
            EnSectorista objEn = new EnSectorista();
            objEn.NEmpresa = (String)this.Session[Global.NEmpresa].ToString();
            objEn.CodZona = cmb_Zona.SelectedValue.ToString();
            ListEnSectorista.Add(objEn);
            #endregion Carga_Variable

            LoSectorista objLo = new LoSectorista();
            dt = objLo.Sectorista_Litar_X_Zona(ListEnSectorista);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["CodSectorista"].ToString().Trim();
                lista.Text = dt.Rows[i]["Sectorista"].ToString().Trim();
                cmb_Sectorista.Items.Add(lista);
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
            List<EnProduCliente> ListEnProduCliente = new List<EnProduCliente>();
            EnProduCliente objEnProduCliente = new EnProduCliente();
            objEnProduCliente.NEMPRESA = (String)this.Session[Global.NEmpresa].ToString();
            objEnProduCliente.CodigoCliente = (String)this.Session[Global.CodCliente].ToString();
            ListEnProduCliente.Add(objEnProduCliente);
            #endregion Carga_Variable

            LoProduCliente objLo = new LoProduCliente();
            dt = objLo.Cliente_Productos_Listar(ListEnProduCliente);

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
            Cursor_Control(txt_CodigoInterno);
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

            Cursor_Control(txt_CodigoInterno);
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
            List<EnProduCliente> ListEnProduCliente = new List<EnProduCliente>();
            EnProduCliente objEnProduCliente = new EnProduCliente();
            objEnProduCliente.NEMPRESA = (String)this.Session[Global.NEmpresa].ToString();
            objEnProduCliente.IdReg = str_Codigo;
            //objEnProduCliente.CodUsuario = (String)this.Session[Global.CodUsuario].ToString(); ;
            ListEnProduCliente.Add(objEnProduCliente);
            #endregion Carga_Variable
            LoProduCliente objLo = new LoProduCliente();

            dt = objLo.Cliente_Productos_Listar_Reg(ListEnProduCliente);

            if (dt.Rows.Count > 0)
            {
                #region CONTROLES_MANTENIMIENTO
                txt_IdReg.Text = dt.Rows[0]["IdReg"].ToString().Trim();


                cmb_Producto.SelectedValue = dt.Rows[0]["CodProducto"].ToString().Trim();
                Combo_SubProducto();
                cmb_SubProducto.SelectedValue = dt.Rows[0]["CodSubProducto"].ToString().Trim();
                txt_CodigoInterno.Text = dt.Rows[0]["CodigoInterno"].ToString().Trim();
                txt_SaldoCapital.Text = dt.Rows[0]["SaldoCapital"].ToString().Trim();
                cmb_Moneda.SelectedValue = dt.Rows[0]["Moneda"].ToString().Trim();

                txt_CalifRiesgo.Text = dt.Rows[0]["CalifRiesgo"].ToString().Trim();
                txt_PorProvision.Text = dt.Rows[0]["PorProvision"].ToString().Trim();
                cmb_Sucursal.SelectedValue = dt.Rows[0]["CodSucursal"].ToString().Trim();
                cmb_Gerente.SelectedValue = dt.Rows[0]["CodGerencia"].ToString().Trim();
                Combo_Zona();
                cmb_Zona.SelectedValue = dt.Rows[0]["CodZona"].ToString().Trim();
                Combo_Sectorista();
                cmb_Sectorista.SelectedValue = dt.Rows[0]["CodSectorista"].ToString().Trim();

                txt_DiasMora.Text = dt.Rows[0]["DiasMora"].ToString().Trim();
                txt_MontoDesemb.Text = dt.Rows[0]["MontoDesemb"].ToString().Trim();
                txt_TEA.Text = dt.Rows[0]["TEA"].ToString().Trim();
                txt_TotCuotasPact.Text = dt.Rows[0]["TotCuotasPact"].ToString().Trim();
                txt_MontoCuota.Text = dt.Rows[0]["MontoCuota"].ToString().Trim();
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
            txt_CodigoInterno.Text = String.Empty;
            txt_SaldoCapital.Text = String.Empty;            
            txt_CalifRiesgo.Text = String.Empty;
            txt_PorProvision.Text = String.Empty;
            txt_DiasMora.Text = String.Empty;
            txt_MontoDesemb.Text = String.Empty;
            txt_TEA.Text = String.Empty;
            txt_TotCuotasPact.Text = String.Empty;
            txt_MontoCuota.Text = String.Empty;

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



        cmb_Producto.Enabled = estado;
        cmb_SubProducto.Enabled = estado;
        txt_CodigoInterno.Enabled = estado;
        txt_SaldoCapital.Enabled = estado;
        cmb_Moneda.Enabled = estado;
        txt_CalifRiesgo.Enabled = estado;
        txt_PorProvision.Enabled = estado;
        cmb_Sucursal.Enabled = estado;
        cmb_Sectorista.Enabled = estado;
        cmb_Zona.Enabled = estado;
        cmb_Gerente.Enabled = estado;
        txt_DiasMora.Enabled = estado;
        txt_MontoDesemb.Enabled = estado;
        txt_TEA.Enabled = estado;
        txt_TotCuotasPact.Enabled = estado;
        txt_MontoCuota.Enabled = estado;
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
            List<EnProduCliente> ListEnProduCliente = new List<EnProduCliente>();
            EnProduCliente objEnProduCliente = new EnProduCliente();

            objEnProduCliente.nempresa = (String)this.Session[Global.NEmpresa].ToString();
            objEnProduCliente.CodigoCliente = (String)this.Session[Global.CodCliente].ToString();
            objEnProduCliente.CodProducto = cmb_Producto.SelectedValue.ToString();
            objEnProduCliente.CodSubProducto = cmb_SubProducto.SelectedValue.ToString();
            objEnProduCliente.CodigoInterno = Util.FormateaEntero(txt_CodigoInterno.Text);
            objEnProduCliente.SaldoCapital =  Util.FormateaDecimal(txt_SaldoCapital.Text);
            objEnProduCliente.Moneda = cmb_Moneda.SelectedValue.ToString();
            objEnProduCliente.CalifRiesgo = txt_CalifRiesgo.Text.Trim();
            objEnProduCliente.PorProvision = txt_PorProvision.Text.Trim();
            objEnProduCliente.CodSucursal = cmb_Sucursal.SelectedValue.ToString();
            objEnProduCliente.CodSectorista = cmb_Sectorista.SelectedValue.ToString();
            objEnProduCliente.CodZona =  cmb_Zona.SelectedValue.ToString();
            objEnProduCliente.CodGerente = cmb_Gerente.SelectedValue.ToString();
            objEnProduCliente.dias_mora = Util.FormateaEntero(txt_DiasMora.Text);
            objEnProduCliente.MontoDesemb = Util.FormateaDecimal(txt_MontoDesemb.Text);
            objEnProduCliente.tea = Util.FormateaDecimal(txt_TEA.Text);
            objEnProduCliente.TotCuotasPact = Util.FormateaDecimal(txt_TotCuotasPact.Text);
            objEnProduCliente.MontoCuota = Util.FormateaDecimal(txt_MontoCuota.Text);
            objEnProduCliente.Estado = cmb_Estado.SelectedValue.ToString();
            objEnProduCliente.CodUsuario = (String)this.Session[Global.CodUsuario].ToString();

            ListEnProduCliente.Add(objEnProduCliente);
            #endregion Carga_Variable

            LoProduCliente objLo = new LoProduCliente();
            msg = objLo.Cliente_Productos_INS(ListEnProduCliente);

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
            List<EnProduCliente> ListEnProduCliente = new List<EnProduCliente>();
            EnProduCliente objEnProduCliente = new EnProduCliente();

            objEnProduCliente.nempresa = (String)this.Session[Global.NEmpresa].ToString();
            objEnProduCliente.IdReg = txt_IdReg.Text.Trim();
            objEnProduCliente.CodigoCliente = (String)this.Session[Global.CodCliente].ToString();
            objEnProduCliente.CodProducto = cmb_Producto.SelectedValue.ToString();
            objEnProduCliente.CodSubProducto = cmb_SubProducto.SelectedValue.ToString();
            objEnProduCliente.CodigoInterno = Util.FormateaEntero(txt_CodigoInterno.Text);
            objEnProduCliente.SaldoCapital = Util.FormateaDecimal(txt_SaldoCapital.Text);
            objEnProduCliente.Moneda = cmb_Moneda.SelectedValue.ToString();
            objEnProduCliente.CalifRiesgo = txt_CalifRiesgo.Text.Trim();
            objEnProduCliente.PorProvision = txt_PorProvision.Text.Trim();
            objEnProduCliente.CodSucursal = cmb_Sucursal.SelectedValue.ToString();
            objEnProduCliente.CodSectorista = cmb_Sectorista.SelectedValue.ToString();
            objEnProduCliente.CodZona = cmb_Zona.SelectedValue.ToString();
            objEnProduCliente.CodGerente = cmb_Gerente.SelectedValue.ToString();
            objEnProduCliente.dias_mora = Util.FormateaEntero(txt_DiasMora.Text);
            objEnProduCliente.MontoDesemb = Util.FormateaDecimal(txt_MontoDesemb.Text);
            objEnProduCliente.tea = Util.FormateaDecimal(txt_TEA.Text);
            objEnProduCliente.TotCuotasPact = Util.FormateaDecimal(txt_TotCuotasPact.Text);
            objEnProduCliente.MontoCuota = Util.FormateaDecimal(txt_MontoCuota.Text);
            objEnProduCliente.Estado = cmb_Estado.SelectedValue.ToString();
            objEnProduCliente.CodUsuario = (String)this.Session[Global.CodUsuario].ToString();

            ListEnProduCliente.Add(objEnProduCliente);
            #endregion Carga_Variable
            LoProduCliente objLo = new LoProduCliente();
            msg = objLo.Cliente_Productos_UPD(ListEnProduCliente);
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


        if (txt_CodigoInterno.Text.Trim().Length < 1)
        {
            Master.MostrarMensaje("Ingrese Producto", TipoMensaje.Advertencia);
            Cursor_Control(txt_CodigoInterno);
            return false;
        }

        return true;
    }
    #endregion funciones
    
}