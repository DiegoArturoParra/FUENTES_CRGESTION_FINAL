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

public partial class Estudio_Gestion_08FrmGaranxProduc : System.Web.UI.Page
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
            //AddRowSelectToGridView(gv_Cronograma);
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
                //btn_Grabar.Attributes.Add("onClick", "document.getElementById('hdnContinuar').value = confirm('¿Se guardara el registro, ¿Desea continuar?');");                
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
        if (!Page.IsPostBack)
        {           
            //Master.MostrarMensaje("es primera vez", TipoMensaje.Exito);            
        }

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
    protected void btn_RefreshProducto_Click(object sender, EventArgs e)
    {
        try
        {
            Listar();
        }
        catch (Exception ex)
        {
            Master.MostrarMensaje(ex.Message.ToString(), TipoMensaje.Error);
        }
    }    
    protected void btn_MantGarantia_Click(object sender, EventArgs e)
    {
        try
        {
            Master.OcultarMensaje();
            if (gv.SelectedIndex != -1)
            {
                string str_IdRegProducto = "?" + Global.IdRegProducto + "=" + hd_Codigo.Value.Trim();
                Response.Redirect("08FrmGaranxProducDet.aspx" + str_IdRegProducto);
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
    private void Listar_Garantia(string codigo)
    {
        DataTable dt;
        try
        {

            gv_Garantia.DataSource = null;
            gv_Garantia.DataBind();
            



            #region validacion
            #endregion validacion

            #region Carga_Variable
            List<EnGaranxProduc> ListEnGaranxProduc = new List<EnGaranxProduc>();
            EnGaranxProduc objEnGaranxProduc = new EnGaranxProduc();
            objEnGaranxProduc.NEmpresa = (String)this.Session[Global.NEmpresa].ToString();
            objEnGaranxProduc.CodigoCliente = (String)this.Session[Global.CodCliente].ToString();
            objEnGaranxProduc.IdRegPRODUCTOS = codigo;
            ListEnGaranxProduc.Add(objEnGaranxProduc);
            #endregion Carga_Variable

            LoGaranxProduc objLo = new LoGaranxProduc();
            dt = objLo.Garantia_Producto_Listar(ListEnGaranxProduc);

            gv_Garantia.DataSource = dt;
            gv_Garantia.DataBind();
            //if (dt.Rows.Count > 0)
            //{
            //    lbl_Cantidad.Text = dt.Rows.Count.ToString() + Mensaje.M_TEXTO_REGISTROS;
            //}
            //else
            //{
            //    lbl_Cantidad.Text = Mensaje.M_CERO_REGISTROS;
            //}
            gv_Garantia.SelectedIndex = -1;
            gv_Garantia.EditIndex = -1;
            gv_Garantia.PageIndex = 0;


            //int AltoGarantia = 24;
            //int CalculaAlto = AltoGarantia * dt.Rows.Count;
            //pnlLista.Height = 45 + CalculaAlto;

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
                Listar_Garantia(str_Codigo);
                
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
                //txt_IdReg.Text = dt.Rows[0]["IdReg"].ToString().Trim();



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

        //btn_Agregar.Visible = estado;


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
        //txt_IdReg.ReadOnly = true;

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
}