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

public partial class Estudio_Gestion_07FrmClieProdAvalDet : System.Web.UI.Page
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
            Combo_StatusLaboral();          
            Listar();
            metodo_consultar();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void Combo_StatusLaboral()
    {
        DataTable dt = new DataTable();
        try
        {
            cmb_StatusLaboral.Items.Clear();
            LoAplicacion objLo = new LoAplicacion();
            dt = objLo.Aplicacion_StatusLaboral_Lista();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["CodStatusLab"].ToString().Trim();
                lista.Text = dt.Rows[i]["StatusLab"].ToString().Trim();
                cmb_StatusLaboral.Items.Add(lista);
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
            List<EnClieProdAval> ListEnClieProdAval = new List<EnClieProdAval>();
            EnClieProdAval objEnClieProdAval = new EnClieProdAval();
            objEnClieProdAval.NEmpresa = (String)this.Session[Global.NEmpresa].ToString();
            objEnClieProdAval.CodigoCliente = (String)this.Session[Global.CodCliente].ToString();
            objEnClieProdAval.IdRegPRODUCTOS = hd_IdRegProductos.Value.Trim();
            ListEnClieProdAval.Add(objEnClieProdAval);
            #endregion Carga_Variable

            LoClieProdAval objLo = new LoClieProdAval();
            dt = objLo.Producto_Aval_Listar(ListEnClieProdAval);

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
            Cursor_Control(txt_DNI);
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

            Cursor_Control(txt_DNI);
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
            List<EnClieProdAval> ListEnClieProdAval = new List<EnClieProdAval>();
            EnClieProdAval objEnClieProdAval = new EnClieProdAval();
            objEnClieProdAval.NEmpresa = (String)this.Session[Global.NEmpresa].ToString();
            objEnClieProdAval.IdReg = str_Codigo;
            //objEnClieProdAval.CodUsuario = (String)this.Session[Global.CodUsuario].ToString(); ;
            ListEnClieProdAval.Add(objEnClieProdAval);
            #endregion Carga_Variable

            LoClieProdAval objLo = new LoClieProdAval();

            dt = objLo.Producto_Aval_Lisrtar_Reg(ListEnClieProdAval);

            if (dt.Rows.Count > 0)
            {
                #region CONTROLES_MANTENIMIENTO
                txt_IdReg.Text = dt.Rows[0]["IdReg"].ToString().Trim();

                txt_DNI.Text = dt.Rows[0]["DNI"].ToString().Trim();
                txt_Nombres.Text = dt.Rows[0]["Nombres"].ToString().Trim();
                txt_Telefonos.Text = dt.Rows[0]["Telefonos"].ToString().Trim();
                txt_Observacion.Text = dt.Rows[0]["Observacion"].ToString().Trim();

                cmb_StatusLaboral.SelectedValue = dt.Rows[0]["CodStatusLaboral"].ToString().Trim();
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
            txt_DNI.Text = String.Empty;
            txt_Nombres.Text = String.Empty;
            txt_Observacion.Text = String.Empty;
            txt_Telefonos.Text = String.Empty;
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
        cmb_StatusLaboral.Enabled = estado;
        txt_DNI.Enabled = estado;
        txt_Nombres.Enabled = estado;
        txt_Observacion.Enabled = estado;
        txt_Telefonos.Enabled = estado;
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
            List<EnClieProdAval> ListEnClieProdAval = new List<EnClieProdAval>();
            EnClieProdAval objEnClieProdAval = new EnClieProdAval();

            objEnClieProdAval.NEmpresa = (String)this.Session[Global.NEmpresa].ToString();
            objEnClieProdAval.CodigoCliente = (String)this.Session[Global.CodCliente].ToString();
            objEnClieProdAval.IdRegProductos = hd_IdRegProductos.Value.Trim();
            objEnClieProdAval.DNI = txt_DNI.Text.Trim();
            objEnClieProdAval.Nombres = txt_Nombres.Text.Trim();
            objEnClieProdAval.CodStatusLaboral = cmb_StatusLaboral.SelectedValue.Trim();
            objEnClieProdAval.Telefonos = txt_Telefonos.Text.Trim();
            objEnClieProdAval.Observacion = txt_Observacion.Text.Trim();
            objEnClieProdAval.Estado = cmb_Estado.SelectedValue.ToString();
            objEnClieProdAval.CodUsuario = (String)this.Session[Global.CodUsuario].ToString();

            ListEnClieProdAval.Add(objEnClieProdAval);
            #endregion Carga_Variable
            LoClieProdAval objLo = new LoClieProdAval();
            msg = objLo.Producto_Aval_INS(ListEnClieProdAval);

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
            List<EnClieProdAval> ListEnClieProdAval = new List<EnClieProdAval>();
            EnClieProdAval objEnClieProdAval = new EnClieProdAval();

            objEnClieProdAval.NEmpresa = (String)this.Session[Global.NEmpresa].ToString();
            objEnClieProdAval.CodigoCliente = (String)this.Session[Global.CodCliente].ToString();
            objEnClieProdAval.IdReg = txt_IdReg.Text.Trim();
            objEnClieProdAval.IdRegProductos = hd_IdRegProductos.Value.Trim();
            objEnClieProdAval.DNI = txt_DNI.Text.Trim();
            objEnClieProdAval.Nombres = txt_Nombres.Text.Trim();
            objEnClieProdAval.CodStatusLaboral = cmb_StatusLaboral.SelectedValue.Trim();
            objEnClieProdAval.Telefonos = txt_Telefonos.Text.Trim();
            objEnClieProdAval.Observacion = txt_Observacion.Text.Trim();
            objEnClieProdAval.Estado = cmb_Estado.SelectedValue.ToString();
            objEnClieProdAval.CodUsuario = (String)this.Session[Global.CodUsuario].ToString();

            ListEnClieProdAval.Add(objEnClieProdAval);
            #endregion Carga_Variable

            LoClieProdAval objLo = new LoClieProdAval();
            msg = objLo.Producto_Aval_UPD(ListEnClieProdAval);
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

        if (txt_Nombres.Text.Trim().Length < 1)
        {
            Master.MostrarMensaje("Ingrese Nombres", TipoMensaje.Advertencia);
            Cursor_Control(txt_Nombres);
            return false;
        }

        return true;
    }
    #endregion funciones
}