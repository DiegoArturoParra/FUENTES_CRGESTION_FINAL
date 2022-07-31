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

public partial class Estudio_Gestion_07FrmAvalDireccio : System.Web.UI.Page
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
        Response.Redirect("07FrmClieProdAval.aspx");
    }
    #endregion Botones
    #endregion Eventos
    #region Metodos
    private void Inicio()
    {
        try
        {

            #region Parametros
            if (Request[Global.IdRegProdAval] != null)
            {
                hd_IdRegProdAval.Value = Request[Global.IdRegProdAval];
            }
            #endregion Parametros

            Combo_TipoDireccion();
            Combo_EstadoDireccion();
            Listar();
            metodo_consultar();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void Combo_TipoDireccion()
    {
        DataTable dt = new DataTable();
        try
        {
            cmb_TipoDireccion.Items.Clear();
            LoTipoDireccion objLo = new LoTipoDireccion();
            dt = objLo.TipoDireccion_Listar();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["CodTipoDir"].ToString().Trim();
                lista.Text = dt.Rows[i]["TipoDireccion"].ToString().Trim();
                cmb_TipoDireccion.Items.Add(lista);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void Combo_EstadoDireccion()
    {
        DataTable dt = new DataTable();
        try
        {
            cmb_EstadoDir.Items.Clear();
            LoEstadoDireccion objLo = new LoEstadoDireccion();
            dt = objLo.EstadoDireccion_Listar();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["CodEstadoDir"].ToString().Trim();
                lista.Text = dt.Rows[i]["Descrip"].ToString().Trim();
                cmb_EstadoDir.Items.Add(lista);
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
            List<EnAvalDireccio> ListEnAvalDireccio = new List<EnAvalDireccio>();
            EnAvalDireccio objEnAvalDireccio = new EnAvalDireccio();
            objEnAvalDireccio.NEmpresa = (String)this.Session[Global.NEmpresa].ToString();
            objEnAvalDireccio.IdRegProdAval = hd_IdRegProdAval.Value.ToString();
            //objEnAvalDireccio.CodigoCliente = (String)this.Session[Global.CodCliente].ToString();
            ListEnAvalDireccio.Add(objEnAvalDireccio);
            #endregion Carga_Variable
            LoAvalDireccio objLo = new LoAvalDireccio();
            dt = objLo.Aval_Direccion_Listar(ListEnAvalDireccio);

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
            txt_CodigoCliente.Enabled = false;
            Cursor_Control(txt_Dir);
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
            txt_CodigoCliente.Enabled = false;
            Cursor_Control(txt_Dir);
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
            List<EnAvalDireccio> ListEnAvalDireccio = new List<EnAvalDireccio>();
            EnAvalDireccio objEnAvalDireccio = new EnAvalDireccio();
            objEnAvalDireccio.NEmpresa = (String)this.Session[Global.NEmpresa].ToString();
            objEnAvalDireccio.IdReg = str_Codigo;
            objEnAvalDireccio.Dir = txt_Dir.Text.Trim();
            objEnAvalDireccio.CodUsuario = (String)this.Session[Global.CodUsuario].ToString(); ;
            ListEnAvalDireccio.Add(objEnAvalDireccio);
            #endregion Carga_Variable
            LoAvalDireccio objLo = new LoAvalDireccio();

            dt = objLo.Aval_Direccion_Listar_Reg(ListEnAvalDireccio);

            if (dt.Rows.Count > 0)
            {
                #region CONTROLES_MANTENIMIENTO
                txt_IdReg.Text = dt.Rows[0]["IdReg"].ToString().Trim();
                txt_CodigoCliente.Text = dt.Rows[0]["CodigoCliente"].ToString().Trim();

                cmb_TipoDireccion.SelectedValue = dt.Rows[0]["CodTipoDir"].ToString().Trim();
                txt_Dir.Text = dt.Rows[0]["Dir"].ToString().Trim();

                txt_Ubigeo.Text = dt.Rows[0]["ubigeo"].ToString().Trim();
                txt_Referencia.Text = dt.Rows[0]["Referencia"].ToString().Trim();
                txt_GeoX.Text = dt.Rows[0]["GeoX"].ToString().Trim();
                txt_GeoY.Text = dt.Rows[0]["GeoY"].ToString().Trim();
                cmb_EstadoDir.SelectedValue = dt.Rows[0]["CodEstadoDir"].ToString().Trim();
                txt_Orden.Text = dt.Rows[0]["Orden"].ToString().Trim();

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
            //txt_CodigoCliente.Text = String.Empty;

            txt_Dir.Text = String.Empty;
            txt_Ubigeo.Text = String.Empty;
            txt_Referencia.Text = String.Empty;
            txt_GeoX.Text = String.Empty;
            txt_GeoY.Text = String.Empty;            
            txt_Orden.Text = String.Empty;

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
        txt_CodigoCliente.Enabled = estado;


        txt_Dir.Enabled = estado;        
        cmb_TipoDireccion.Enabled = estado;
        txt_Dir.Enabled = estado;
        txt_Ubigeo.Enabled = estado;
        txt_Referencia.Enabled = estado;
        txt_GeoX.Enabled = estado;
        txt_GeoY.Enabled = estado;
        cmb_EstadoDir.Enabled = estado;
        txt_Orden.Enabled = estado;

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
            List<EnAvalDireccio> ListEnAvalDireccio = new List<EnAvalDireccio>();
            EnAvalDireccio objEnAvalDireccio = new EnAvalDireccio();

            objEnAvalDireccio.NEmpresa = (String)this.Session[Global.NEmpresa].ToString();
            objEnAvalDireccio.CodigoCliente = (String)this.Session[Global.CodCliente].ToString();
            objEnAvalDireccio.IdRegProdAval = hd_IdRegProdAval.Value.ToString();
            objEnAvalDireccio.CodTipoDir = cmb_TipoDireccion.SelectedValue.Trim();
            objEnAvalDireccio.Dir = txt_Dir.Text.Trim();
            objEnAvalDireccio.ubigeo = txt_Ubigeo.Text.Trim();
            objEnAvalDireccio.Referencia = txt_Referencia.Text.Trim();
            objEnAvalDireccio.GeoX = Util.FormateaDecimal(txt_GeoX.Text);
            objEnAvalDireccio.GeoY = Util.FormateaDecimal(txt_GeoY.Text);
            objEnAvalDireccio.CodEstadoDir = cmb_EstadoDir.SelectedValue.Trim();
            objEnAvalDireccio.Orden = Util.FormateaEntero(txt_Orden.Text);
            objEnAvalDireccio.CodUsuario = (String)this.Session[Global.CodUsuario].ToString();

            ListEnAvalDireccio.Add(objEnAvalDireccio);
            #endregion Carga_Variable
            LoAvalDireccio objLo = new LoAvalDireccio();
            msg = objLo.Aval_Direccion_INS(ListEnAvalDireccio);

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
            List<EnAvalDireccio> ListEnAvalDireccio = new List<EnAvalDireccio>();
            EnAvalDireccio objEnAvalDireccio = new EnAvalDireccio();
            objEnAvalDireccio.IdReg = hd_Codigo.Value.Trim();
            objEnAvalDireccio.NEmpresa = (String)this.Session[Global.NEmpresa].ToString();
            objEnAvalDireccio.CodigoCliente = (String)this.Session[Global.CodCliente].ToString();
            objEnAvalDireccio.CodTipoDir = cmb_TipoDireccion.SelectedValue.Trim();
            objEnAvalDireccio.Dir = txt_Dir.Text.Trim();
            objEnAvalDireccio.ubigeo = txt_Ubigeo.Text.Trim();
            objEnAvalDireccio.Referencia = txt_Referencia.Text.Trim();
            objEnAvalDireccio.GeoX = txt_GeoX.Text.Trim();
            objEnAvalDireccio.GeoY = txt_GeoY.Text.Trim();
            objEnAvalDireccio.CodEstadoDir = cmb_EstadoDir.SelectedValue.Trim();
            objEnAvalDireccio.Orden = txt_Orden.Text.Trim();
            objEnAvalDireccio.CodUsuario = (String)this.Session[Global.CodUsuario].ToString();

            ListEnAvalDireccio.Add(objEnAvalDireccio);
            #endregion Carga_Variable            
            LoAvalDireccio objLo = new LoAvalDireccio();
            msg = objLo.Aval_Direccion_UPD(ListEnAvalDireccio);
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


        if (txt_Dir.Text.Trim().Length < 1)
        {
            Master.MostrarMensaje("Ingrese Dirección", TipoMensaje.Advertencia);
            Cursor_Control(txt_Dir);
            return false;

        }

        if (txt_GeoX.Text.Trim().Length > 0)
        {
            if (Util.esDecimal(txt_GeoX.Text.Trim()) == false)
            {
                Master.MostrarMensaje("Ingrese Decimales", TipoMensaje.Advertencia);
                Cursor_Control(txt_GeoX);
                return false;
            }
        }


        if (txt_GeoY.Text.Trim().Length > 0)
        {
            if (Util.esDecimal(txt_GeoY.Text.Trim()) == false)
            {
                Master.MostrarMensaje("Ingrese Decimales", TipoMensaje.Advertencia);
                Cursor_Control(txt_GeoY);
                return false;
            }
        }

        if (txt_Orden.Text.Trim().Length > 0)
        {
            if (Util.esDecimal(txt_Orden.Text.Trim()) == false)
            {
                Master.MostrarMensaje("Ingrese Numeros", TipoMensaje.Advertencia);
                Cursor_Control(txt_Orden);
                return false;
            }
        }

        return true;
    }
    #endregion funciones
}