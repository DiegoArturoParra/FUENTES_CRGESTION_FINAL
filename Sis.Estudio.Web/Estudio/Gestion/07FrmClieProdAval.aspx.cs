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

public partial class Estudio_Gestion_07FrmClieProdAval : System.Web.UI.Page
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
            AddRowSelectToGridView(gv_Aval);
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
        #region Redim
        string idifame = AcetPanel.ClieProdAval.iframe_id;
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
    protected void gv_Aval_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Master.OcultarMensaje();
            Seleccionar_Aval();
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
    protected void btn_MantAval_Click(object sender, EventArgs e)
    {
        try
        {
            Master.OcultarMensaje();
            if (gv.SelectedIndex != -1)
            {
                string str_IdRegProducto = "?" + Global.IdRegProducto + "=" + hd_Codigo.Value.Trim();
                Response.Redirect("07FrmClieProdAvalDet.aspx" + str_IdRegProducto);
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
    protected void btn_MantAvalPatri_Click(object sender, EventArgs e)
    {
        try
        {
            Master.OcultarMensaje();
            if (gv_Aval.SelectedIndex != -1)
            {

                string str_IdRegProdAval = "?" + Global.IdRegProdAval + "=" + hd_IdRegProdAval.Value.Trim();
                Response.Redirect("07FrmAvalDeclaPat.aspx" + str_IdRegProdAval);
            }
            else
            {
                Master.MostrarMensaje("Seleccione un Aval", TipoMensaje.Error);
            }
        }
        catch (Exception ex)
        {
            Master.MostrarMensaje(ex.Message.ToString(), TipoMensaje.Error);
        }
    }
    protected void btn_MantAvalDirec_Click(object sender, EventArgs e)
    {
        try
        {
            Master.OcultarMensaje();
            if (gv_Aval.SelectedIndex != -1)
            {

                string str_IdRegProdAval = "?" + Global.IdRegProdAval + "=" + hd_IdRegProdAval.Value.Trim();
                Response.Redirect("07FrmAvalDireccio.aspx" + str_IdRegProdAval);
            }
            else
            {
                Master.MostrarMensaje("Seleccione un Aval", TipoMensaje.Error);
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
    private void Listar_Aval(string codigo)
    {
        DataTable dt;
        try
        {

            gv_Aval.DataSource = null;
            gv_Aval.DataBind();

            #region validacion
            #endregion validacion

            #region Carga_Variable
            List<EnClieProdAval> ListEnClieProdAval = new List<EnClieProdAval>();
            EnClieProdAval objEnClieProdAval = new EnClieProdAval();
            objEnClieProdAval.NEmpresa = (String)this.Session[Global.NEmpresa].ToString();
            objEnClieProdAval.CodigoCliente = (String)this.Session[Global.CodCliente].ToString();
            objEnClieProdAval.IdRegPRODUCTOS = codigo;
            ListEnClieProdAval.Add(objEnClieProdAval);
            #endregion Carga_Variable

            LoClieProdAval objLo = new LoClieProdAval();
            dt = objLo.Producto_Aval_Listar(ListEnClieProdAval);

            gv_Aval.DataSource = dt;
            gv_Aval.DataBind();

            //if (dt.Rows.Count > 0)
            //{
            //    lbl_Cantidad.Text = dt.Rows.Count.ToString() + Mensaje.M_TEXTO_REGISTROS;
            //}
            //else
            //{
            //    lbl_Cantidad.Text = Mensaje.M_CERO_REGISTROS;
            //}

            gv_Aval.SelectedIndex = -1;
            gv_Aval.EditIndex = -1;
            gv_Aval.PageIndex = 0;


        }

        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void Listar_AvalPatrimonio(string codigo)
    {
        DataTable dt;
        try
        {
            gv_AvalPatri.DataSource = null;
            gv_AvalPatri.DataBind();

            #region validacion
            #endregion validacion
            #region Carga_Variable
            List<EnAvalDeclaPat> ListEnAvalDeclaPat = new List<EnAvalDeclaPat>();
            EnAvalDeclaPat objEnAvalDeclaPat = new EnAvalDeclaPat();
            objEnAvalDeclaPat.NEmpresa = (String)this.Session[Global.NEmpresa].ToString();
            objEnAvalDeclaPat.IdRegProdAval = codigo;
            ListEnAvalDeclaPat.Add(objEnAvalDeclaPat);
            #endregion Carga_Variable
            LoAvalDeclaPat objLo = new LoAvalDeclaPat();
            dt = objLo.Aval_DeclaPatrimonial_Listar(ListEnAvalDeclaPat);
            gv_AvalPatri.DataSource = dt;
            gv_AvalPatri.DataBind();
            //if (dt.Rows.Count > 0)
            //{
            //    lbl_Cantidad.Text = dt.Rows.Count.ToString() + Mensaje.M_TEXTO_REGISTROS;
            //}
            //else
            //{
            //    lbl_Cantidad.Text = Mensaje.M_CERO_REGISTROS;
            //}
            gv_AvalPatri.SelectedIndex = -1;
            gv_AvalPatri.EditIndex = -1;
            gv_AvalPatri.PageIndex = 0;

        }

        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void Listar_AvalDireccion(string codigo)
    {
        DataTable dt;
        try
        {

            gv_AvalDireccion.DataSource = null;
            gv_AvalDireccion.DataBind();

            #region validacion
            #endregion validacion

            #region Carga_Variable
            List<EnAvalDireccio> ListEnAvalDireccio = new List<EnAvalDireccio>();
            EnAvalDireccio objEnAvalDireccio = new EnAvalDireccio();
            objEnAvalDireccio.NEmpresa = (String)this.Session[Global.NEmpresa].ToString();
            objEnAvalDireccio.IdRegProdAval = codigo;
            //objEnAvalDireccio.CodigoCliente = (String)this.Session[Global.CodCliente].ToString();
            ListEnAvalDireccio.Add(objEnAvalDireccio);
            #endregion Carga_Variable
            LoAvalDireccio objLo = new LoAvalDireccio();
            dt = objLo.Aval_Direccion_Listar(ListEnAvalDireccio);

            gv_AvalDireccion.DataSource = dt;
            gv_AvalDireccion.DataBind();
            //if (dt.Rows.Count > 0)
            //{
            //    lbl_Cantidad.Text = dt.Rows.Count.ToString() + Mensaje.M_TEXTO_REGISTROS;
            //}
            //else
            //{
            //    lbl_Cantidad.Text = Mensaje.M_CERO_REGISTROS;
            //}
            gv_AvalDireccion.SelectedIndex = -1;
            gv_AvalDireccion.EditIndex = -1;
            gv_AvalDireccion.PageIndex = 0;


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


                gv_Aval.DataSource = null;
                gv_Aval.DataBind();

                gv_AvalPatri.DataSource = null;
                gv_AvalPatri.DataBind();

                gv_AvalDireccion.DataSource = null;
                gv_AvalDireccion.DataBind();



                Listar_Aval(str_Codigo);
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


    private void Seleccionar_Aval()
    {
        try
        {
            if (gv_Aval.SelectedIndex != -1)
            {

                gv_AvalPatri.DataSource = null;
                gv_AvalPatri.DataBind();

                gv_AvalDireccion.DataSource = null;
                gv_AvalDireccion.DataBind();


                string str_Codigo = gv_Aval.SelectedRow.Cells[1].Text.ToString();
                hd_IdRegProdAval.Value = str_Codigo;



                Listar_AvalPatrimonio(str_Codigo);
                Listar_AvalDireccion(str_Codigo);
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
    protected void ClearRow_Aval()
    {
        hd_IdRegProdAval.Value = "";
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