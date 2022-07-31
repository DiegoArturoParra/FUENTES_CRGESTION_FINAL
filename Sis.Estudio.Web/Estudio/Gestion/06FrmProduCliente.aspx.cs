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
using Sis.Estudio.Logic.MSSQL.Estudio.Gestion;
using Sis.Estudio.Entity;

public partial class Estudio_Gestion_06FrmProduCliente : System.Web.UI.Page
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
            AddRowSelectToGridView2(gv_Gastos);
            
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

    private void AddRowSelectToGridView2(GridView gv_Gastos)
    {
        #region select
        if (gv_Gastos.EditIndex == -1)
        {
            foreach (GridViewRow row in gv_Gastos.Rows)
            {

                #region Old
                //row.Attributes["OnMouseOut"] = "this.className = this.orignalclassName;";
                //row.Attributes["OnMouseOver"] = "this.orignalclassName = this.className;this.className = 'selectedrow4';";
                //row.Attributes["onMouseDown"] = "this.className = 'selectedrow';";
                #endregion Old
                row.Attributes["OnMouseOut"] = "this.className = this.orignalclassName;";
                row.Attributes["OnMouseOver"] = "javascript:if (this.className == 'selectedrow') {this.orignalclassName = this.className; this.className = 'selectedrow';}else {this.orignalclassName = this.className; this.className = 'selectedrow4';}";
                row.Attributes["onMouseDown"] = "this.className = 'selectedrow';";
                row.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(gv_Gastos, "Select$" + row.RowIndex.ToString(), true));

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
                btn_Grabar_Gastos.Attributes.Add("onClick", "document.getElementById('hdnContinuar').value = confirm('¿Se guardara el registro de gastos, ¿Desea continuar?');");
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
            Metodo_Pintar();
        }
        catch (Exception ex)
        {
            Master.MostrarMensaje(ex.Message.ToString(), TipoMensaje.Error);
        }
    }
    

    #endregion Grid
    #region Botones
    protected void btn_MantProducto_Click(object sender, EventArgs e)
    {
        Response.Redirect("06FrmProduClienteDet.aspx");
        //Response.Redirect("Prueba.aspx");        
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
            Listar();
            metodo_consultar();

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
    private void Listar_Gastos(string codigo)
    {
        DataTable dt;
        try
        {

            gv_Gastos.DataSource = null;
            gv_Gastos.DataBind();

            #region validacion
            #endregion validacion

            #region Carga_Variable
            List<EnCliente_Gastos> ListEnCliente_Gastos = new List<EnCliente_Gastos>();
            EnCliente_Gastos objEnCliente_Gastos = new EnCliente_Gastos();
            objEnCliente_Gastos.NEMPRESA = (String)this.Session[Global.NEmpresa].ToString();
            objEnCliente_Gastos.CodigoCliente = (String)this.Session[Global.CodCliente].ToString();
            objEnCliente_Gastos.IdRegProductos = codigo;
            ListEnCliente_Gastos.Add(objEnCliente_Gastos);
            #endregion Carga_Variable
            
            LoCliente_Gastos objLo = new LoCliente_Gastos();
            dt = objLo.Cliente_Gastos_Lista(ListEnCliente_Gastos);

            gv_Gastos.DataSource = dt;
            gv_Gastos.DataBind();
            //if (dt.Rows.Count > 0)
            //{
            //    lbl_Cantidad.Text = dt.Rows.Count.ToString() + Mensaje.M_TEXTO_REGISTROS;
            //}
            //else
            //{
            //    lbl_Cantidad.Text = Mensaje.M_CERO_REGISTROS;
            //}
            gv_Gastos.SelectedIndex = -1;
            gv_Gastos.EditIndex = -1;
            gv_Gastos.PageIndex = 0;
            //ClearRow();

        }

        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void Listar_GCobra(string codigo)
    {
        DataTable dt;
        try
        {

            gv_GC.DataSource = null;
            gv_GC.DataBind();

            #region validacion
            #endregion validacion

            #region Carga_Variable
            List<EnProduCliente> ListEnProduCliente = new List<EnProduCliente>();
            EnProduCliente objEnProduCliente = new EnProduCliente();
            objEnProduCliente.NEMPRESA = (String)this.Session[Global.NEmpresa].ToString();
            objEnProduCliente.CodigoCliente = (String)this.Session[Global.CodCliente].ToString();
            objEnProduCliente.IdRegPRODUCTOS = codigo;
            ListEnProduCliente.Add(objEnProduCliente);
            #endregion Carga_Variable

            LoProduCliente objLo = new LoProduCliente();
            dt = objLo.Cliente_Productos_GC_Listar(ListEnProduCliente);

            gv_GC.DataSource = dt;
            gv_GC.DataBind();
            //if (dt.Rows.Count > 0)
            //{
            //    lbl_Cantidad.Text = dt.Rows.Count.ToString() + Mensaje.M_TEXTO_REGISTROS;
            //}
            //else
            //{
            //    lbl_Cantidad.Text = Mensaje.M_CERO_REGISTROS;
            //}
            gv_GC.SelectedIndex = -1;
            gv_GC.EditIndex = -1;
            gv_GC.PageIndex = 0;
            //ClearRow();

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
                Listar_Gastos(str_Codigo);
                Listar_GCobra(str_Codigo);
                Listar_Cronograma(str_Codigo);
                
                
                
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

    private void SeleccionarGastos()
    {
        try
        {
            if (gv_Gastos.SelectedIndex != -1)
            {
                string str_Codigo_Gastos = gv_Gastos.SelectedRow.Cells[1].Text.ToString();
                MostrarDatos_Gastos(str_Codigo_Gastos);
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



    protected void metodo_agregar_gastos()
    {
        try
        {
            #region accesos_opcion

            #endregion accesos_opcion


            mstrEstado = "agregar";
            ViewState.Add("estado", mstrEstado);
            LimpiarControles();
            Estado_Controles(false);

            txt_IdReg_ClienteGastos.Enabled = false;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void metodo_modificar_gastos()
    {
        try
        {

            #region accesos_opcion
            #endregion accesos_opcion
            mstrEstado = "modificar";
            ViewState.Add("estado", mstrEstado);
            Estado_Controles(false);
            txt_IdReg_ClienteGastos.Enabled = false;

        }
        catch (Exception ex)
        {
            throw ex;
        }
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
           // Cursor_Control(txt_CodigoInterno);
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
            //Cursor_Control(txt_CodigoInterno);
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
            Solo_Lectura();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    protected void CargaComboTipoTramite()
    {
        DataTable dt = new DataTable();
        LoCliente_Gastos objLoCliente_Gastos = new LoCliente_Gastos();
        try
        {
            EnCliente_Gastos objEnCliente_Gastos = new EnCliente_Gastos();
            cmb_tipo_tramite.Items.Clear();

            dt = objLoCliente_Gastos.Cliente_Gastos_Combo();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["id_tipo_tramite"].ToString().Trim();
                lista.Text = dt.Rows[i]["tipo_tramite"].ToString().Trim();
                cmb_tipo_tramite.Items.Add(lista);
            }
        }
        catch (Exception excp)
        {
            throw excp;
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

                txt_Producto.Text = dt.Rows[0]["Producto"].ToString().Trim();


                txt_PorProvision.Text = dt.Rows[0]["PorProvision"].ToString().Trim();
                txt_MontoDesemb.Text = dt.Rows[0]["MontoDesemb"].ToString().Trim();
                txt_TEA.Text = dt.Rows[0]["TEA"].ToString().Trim();                
                txt_TotCuotasPact.Text = dt.Rows[0]["TotCuotasPact"].ToString().Trim();
                txt_DeuCapitalActual.Text = dt.Rows[0]["DeuCapitalActual"].ToString().Trim();
                txt_CuotasPag.Text = dt.Rows[0]["CuotasPag"].ToString().Trim();
                txt_CuotasVen.Text = dt.Rows[0]["CuotasVen"].ToString().Trim();
                //txt_dias_mora.Text = dt.Rows[0]["dias_mora"].ToString().Trim();
                txt_dias_mora.Text = dt.Rows[0]["diasmorosos"].ToString().Trim();
                txt_FecVenCuotasMasVenc.Text = dt.Rows[0]["FecVenCuotasMasVenc"].ToString().Trim();                                              
                txt_MontoCuota.Text = dt.Rows[0]["MontoCuota"].ToString().Trim();
                txt_INTComp.Text = dt.Rows[0]["INTComp"].ToString().Trim();
                txt_INTMor.Text = dt.Rows[0]["INTMor"].ToString().Trim();
                txt_Estado.Text = dt.Rows[0]["Estado"].ToString().Trim();

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

    protected void MostrarDatos_Gastos(string str_Codigo_Gastos)
    {
        DataTable dt = new DataTable();
        try
        {
            Master.OcultarMensaje();
            LimpiarControles();

            #region Validacion
            if (str_Codigo_Gastos.Trim().Length < 1)
            {
                return;
            }
            #endregion Validacion

            #region Carga_Variable
            List<EnCliente_Gastos> ListEnCliente_Gastos = new List<EnCliente_Gastos>();
            EnCliente_Gastos objEnCliente_Gastos = new EnCliente_Gastos();
            objEnCliente_Gastos.IdReg_ClienteGastos = str_Codigo_Gastos;

            ListEnCliente_Gastos.Add(objEnCliente_Gastos);
            #endregion Carga_Variable
            LoCliente_Gastos objLo = new LoCliente_Gastos();

            dt = objLo.Cliente_Gastos_Reg(ListEnCliente_Gastos);

            if (dt.Rows.Count > 0)
            {
                #region CONTROLES_MANTENIMIENTO

                txt_IdReg_ClienteGastos.Text = dt.Rows[0]["IdReg_ClienteGastos"].ToString().Trim();
                txt_Fecha_gastos.Text = dt.Rows[0]["Fecha"].ToString().Trim();
                txt_ruc_gastos.Text = dt.Rows[0]["ruc"].ToString().Trim();
                txt_RazonSocial.Text = dt.Rows[0]["RazonSocial"].ToString().Trim();
                txt_Monto.Text = dt.Rows[0]["Monto"].ToString().Trim();

                //**** carga combo tipo ***//
                CargaComboTipoTramite();
                //************************//

                cmb_tipo_tramite.SelectedValue = dt.Rows[0]["id_tipo_tramite"].ToString();                
                txt_Observacion_gastos.Text = dt.Rows[0]["Observacion"].ToString().Trim();
                txt_FechaRendicion.Text = dt.Rows[0]["FechaRendicion"].ToString().Trim();




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
            txt_IdReg_ClienteGastos.Text = String.Empty; 
            txt_Fecha_gastos.Text = String.Empty; 
            txt_ruc_gastos.Text = String.Empty; 
            txt_RazonSocial.Text = String.Empty; 
            txt_Monto.Text = String.Empty; 
            txt_Observacion_gastos.Text = String.Empty; 
            txt_FechaRendicion.Text = String.Empty; 


            //txt_IdReg.Text = String.Empty;            
            //txt_CodigoInterno.Text = String.Empty;
            //txt_SaldoCapital.Text = String.Empty;
            //txt_CalifRiesgo.Text = String.Empty;
            //txt_PorProvision.Text = String.Empty;
            //txt_DiasMora.Text = String.Empty;
            //txt_MontoDesemb.Text = String.Empty;
            //txt_TEA.Text = String.Empty;
            //txt_TotCuotasPact.Text = String.Empty;
            //txt_MontoCuota.Text = String.Empty;

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void Estado_Controles(bool estado)
    {

        btn_Agregar_Gastos.Visible = estado;
        btn_Modificar_Gastos.Visible = estado;
        

        gv.Enabled = estado;

        gv_Gastos.Enabled = estado;


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



        btn_Grabar_Gastos.Visible = estado;
        btn_Cancelar_Gastos.Visible = estado;

        //txt_IdReg.Enabled = estado;
        //btn_Grabar.Visible = estado;
        //btn_Cancelar.Visible = estado;

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

    private void Solo_Lectura()
    { 
            txt_IdReg.ReadOnly = true;
            txt_Producto.ReadOnly = true;
            txt_MontoDesemb.ReadOnly = true;
            txt_TEA.ReadOnly = true;
            txt_TotCuotasPact.ReadOnly = true;
            txt_DeuCapitalActual.ReadOnly = true;
            txt_CuotasPag.ReadOnly = true;
            txt_CuotasVen.ReadOnly = true;
            txt_PorProvision.ReadOnly = true;
            txt_dias_mora.ReadOnly = true;
            txt_FecVenCuotasMasVenc.ReadOnly = true;
            txt_MontoCuota.ReadOnly = true;
            txt_INTComp.ReadOnly = true;
            txt_INTMor.ReadOnly = true;
            txt_Estado.ReadOnly = true;    
    }


    #endregion Metodos
    #region Estructura

    #endregion Estructura
    #region Datos

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



        return true;
    }
    #endregion funciones
    protected void gv_Gastos_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Master.OcultarMensaje();
            SeleccionarGastos();
        }
        catch (Exception ex)
        {
            Master.MostrarMensaje(ex.Message.ToString(), TipoMensaje.Error);
        }
    }

    protected void btn_Agregar_Gastos_Click(object sender, EventArgs e)
    {
        try
        {
            CargaComboTipoTramite();
            metodo_agregar_gastos();
        }
        catch (Exception ex)
        {
            Master.MostrarMensaje(ex.Message.ToString(), TipoMensaje.Error);
        }

    }
    protected void btn_Modificar_Gastos_Click(object sender, EventArgs e)
    {
        try
        {
            Master.OcultarMensaje();
            if (gv_Gastos.SelectedIndex != -1)
            {
                metodo_modificar_gastos();
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
    protected void btn_Grabar_Gastos_Click(object sender, EventArgs e)
    {
        if (gv.SelectedIndex != -1)
        {
        
                try
                {

                            Master.OcultarMensaje();
                            bool continuar;
                            bool.TryParse(Request.Form["hdnContinuar"], out continuar);
                            if (continuar)
                            {

                                if (txt_Fecha_gastos.Text == "")
                                {
                                    Master.MostrarMensaje(Mensaje.M_VALIDACION_FECHA, TipoMensaje.Advertencia);
                                    return;
                                }

                                if (txt_ruc_gastos.Text == "")
                                {
                                    Master.MostrarMensaje(Mensaje.M_VALIDACION_RUC, TipoMensaje.Advertencia);
                                    return;
                                }

                                if (txt_RazonSocial.Text == "")
                                {
                                    Master.MostrarMensaje(Mensaje.M_VALIDACION_RAZON_SOCIAL, TipoMensaje.Advertencia);
                                    return;
                                }

                                if (txt_Monto.Text == "")
                                {
                                    Master.MostrarMensaje(Mensaje.M_VALIDACION_MONTO, TipoMensaje.Advertencia);
                                    return;
                                }

                                if (txt_FechaRendicion.Text == "")
                                {
                                    Master.MostrarMensaje(Mensaje.M_VALIDACION_FECHA_RENDICION, TipoMensaje.Advertencia);
                                    return;
                                }



                                string estado = (String)ViewState["estado"];
                                if (estado == "agregar")
                                {
                                    Graba_gastos();  // GRABA
                                }

                                if (estado == "modificar")
                                {
                                    Modifica_gastos();  // ACTUALIZA
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
        else
        {
            Master.MostrarMensaje(Mensaje.M_SELECCIONAR_REGISTRO, TipoMensaje.Advertencia);
        }
    }
    protected void btn_Cancelar_Gastos_Click(object sender, EventArgs e)
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


    private void Graba_gastos()
    {
        //****************************************************************************************
        //* Nomre       : Grabar
        //* DescripcioN :
        //****************************************************************************************
        string str_Id = "";
        string msg = "";
        string Exito = "";
        LoCliente_Gastos ObjLoCliente_Gastos = new LoCliente_Gastos();
        try
        {
            #region Cargar_Variables
            EnCliente_Gastos ObjEnCliente_Gastos = new EnCliente_Gastos();
            List<EnCliente_Gastos> ListEnCliente_Gastos = new List<EnCliente_Gastos>();

            ObjEnCliente_Gastos.NEMPRESA = (String)this.Session[Global.NEmpresa].ToString();
            ObjEnCliente_Gastos.CodigoCliente = "0";
            ObjEnCliente_Gastos.IdRegProductos = gv.SelectedRow.Cells[1].Text.ToString();
            ObjEnCliente_Gastos.Fecha = txt_Fecha_gastos.Text.ToString();
            ObjEnCliente_Gastos.ruc = txt_ruc_gastos.Text.ToString();
            ObjEnCliente_Gastos.RazonSocial = txt_RazonSocial.Text.ToString();
            ObjEnCliente_Gastos.Monto = txt_Monto.Text.ToString();
            ObjEnCliente_Gastos.id_tipo_tramite = cmb_tipo_tramite.SelectedValue.Trim();
            ObjEnCliente_Gastos.Observacion = txt_Observacion_gastos.Text.ToString();
            ObjEnCliente_Gastos.FechaRendicion = txt_FechaRendicion.Text.ToString();
            ObjEnCliente_Gastos.CodUsuario = (String)this.Session[Global.CodUsuario].ToString();



            ListEnCliente_Gastos.Add(ObjEnCliente_Gastos);
            #endregion Cargar_Variables
            List<EnTransaccion> RetornoT = ObjLoCliente_Gastos.Cliente_Gastos_INS(ListEnCliente_Gastos);
            msg = RetornoT[0].MENSAJE.ToString();
            str_Id = RetornoT[0].ID.ToString();
            if (msg == "exito") { Exito = FlagsPrograma.FLG_VALOREXITOSI; } else { Master.MostrarMensaje(msg, TipoMensaje.Error); Exito = FlagsPrograma.FLG_VALOREXITONO; return; }
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
            Master.MostrarMensaje(Mensaje.M_OPERACION_SATISFACTORIA, TipoMensaje.Exito);
            Listar_Gastos(gv.SelectedRow.Cells[1].Text.ToString());
            metodo_consultar();
        }
    }
    private void Modifica_gastos()
    {
        //****************************************************************************************
        //* Nomre       : Grabar
        //* DescripcioN :
        //****************************************************************************************
        string str_Id = "";
        string msg = "";
        string Exito = "";
        LoCliente_Gastos ObjLoCliente_Gastos = new LoCliente_Gastos();
        try
        {
            #region Cargar_Variables
            EnCliente_Gastos ObjEnCliente_Gastos = new EnCliente_Gastos();
            List<EnCliente_Gastos> ListEnCliente_Gastos = new List<EnCliente_Gastos>();

            ObjEnCliente_Gastos.IdReg_ClienteGastos = gv_Gastos.SelectedRow.Cells[1].Text.ToString();
            ObjEnCliente_Gastos.NEMPRESA = (String)this.Session[Global.NEmpresa].ToString();
            ObjEnCliente_Gastos.CodigoCliente = "0";
            ObjEnCliente_Gastos.IdRegProductos = gv.SelectedRow.Cells[1].Text.ToString();
            ObjEnCliente_Gastos.Fecha = txt_Fecha_gastos.Text.ToString();
            ObjEnCliente_Gastos.ruc = txt_ruc_gastos.Text.ToString();
            ObjEnCliente_Gastos.RazonSocial = txt_RazonSocial.Text.ToString();
            ObjEnCliente_Gastos.Monto = txt_Monto.Text.ToString();
            ObjEnCliente_Gastos.id_tipo_tramite = cmb_tipo_tramite.SelectedValue.Trim();
            ObjEnCliente_Gastos.Observacion = txt_Observacion_gastos.Text.ToString();
            ObjEnCliente_Gastos.FechaRendicion = txt_FechaRendicion.Text.ToString();
            ObjEnCliente_Gastos.CodUsuario = (String)this.Session[Global.CodUsuario].ToString();
                 
            ListEnCliente_Gastos.Add(ObjEnCliente_Gastos);
            #endregion Cargar_Variables
            msg = ObjLoCliente_Gastos.Cliente_Gastos_UPD(ListEnCliente_Gastos);

            if (msg == "exito") { Exito = FlagsPrograma.FLG_VALOREXITOSI; } else { Master.MostrarMensaje(msg, TipoMensaje.Error); Exito = FlagsPrograma.FLG_VALOREXITONO; return; }
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
            Master.MostrarMensaje(Mensaje.M_OPERACION_SATISFACTORIA, TipoMensaje.Exito);
            Listar_Gastos(gv.SelectedRow.Cells[1].Text.ToString());
            metodo_consultar();
        }
    }

    #region Cronograma_Pagos

    #region Eventos
    #region Grid
    
    #endregion Grid
    #region Botones
    protected void btn_MantCronograma_Click(object sender, EventArgs e)
    {
        try
        {
            Master.OcultarMensaje();
            if (gv.SelectedIndex != -1)
            {
                string str_IdRegProducto = "?" + Global.IdRegProducto + "=" + hd_Codigo.Value.Trim();
                Response.Redirect("09FrmCronogDePagoDet.aspx" + str_IdRegProducto);
            }
            else
            {
                Master.MostrarMensaje("Seleccione un Producto", TipoMensaje.Error);
            }
        }
        catch (Exception ex)
        {
            Master.MostrarMensaje(ex.Message.ToString(), TipoMensaje.Error);
        }
    }
    #endregion Botones
    #endregion Eventos


    #region Metodos

    
    private void Listar_Cronograma(string codigo)
    {
        DataTable dt;
        try
        {
            gv_Cronograma.DataSource = null;
            gv_Cronograma.DataBind();
            #region validacion
            #endregion validacion
            #region Carga_Variable
            List<EnCronogDePago> ListEnCronogDePago = new List<EnCronogDePago>();
            EnCronogDePago objEnCronogDePago = new EnCronogDePago();
            objEnCronogDePago.NEmpresa = (String)this.Session[Global.NEmpresa].ToString();
            objEnCronogDePago.CodigoCliente = (String)this.Session[Global.CodCliente].ToString();
            objEnCronogDePago.IdRegPRODUCTOS = codigo;
            ListEnCronogDePago.Add(objEnCronogDePago);
            #endregion Carga_Variable

            LoCronogDePago objLo = new LoCronogDePago();
            dt = objLo.CronogramaPago_Listar(ListEnCronogDePago);

            gv_Cronograma.DataSource = dt;
            gv_Cronograma.DataBind();
            //if (dt.Rows.Count > 0)
            //{
            //    lbl_Cantidad.Text = dt.Rows.Count.ToString() + Mensaje.M_TEXTO_REGISTROS;
            //}
            //else
            //{
            //    lbl_Cantidad.Text = Mensaje.M_CERO_REGISTROS;
            //}
            gv_Cronograma.SelectedIndex = -1;
            gv_Cronograma.EditIndex = -1;
            gv_Cronograma.PageIndex = 0;


        }

        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void Seleccionar_Cronograma()
    {
        try
        {
            if (gv.SelectedIndex != -1)
            {
                string str_Codigo = gv.SelectedRow.Cells[1].Text.ToString();
                hd_Codigo.Value = str_Codigo;
                //MostrarDatos(str_Codigo);                
                Listar_Cronograma(str_Codigo);
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
    protected void ClearRow_Cronograma()
    {
        hd_Codigo.Value = "";
    }


    #endregion Metodos

    #endregion Cronograma_Pagos


    protected void gv_GC_SelectedIndexChanged(object sender, EventArgs e)
    {

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

            int Estado = 7;

            foreach (GridViewRow fila in gv_GC .Rows)
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
                    fila.Cells[Estado].Controls.Add(hlnk);
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}

