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

public partial class Estudio_Gestion_07FrmAvalDeclaPat : System.Web.UI.Page
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
            Combo_TipoBien();
            Listar();
            metodo_consultar();
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
            List<EnAvalDeclaPat> ListEnAvalDeclaPat = new List<EnAvalDeclaPat>();
            EnAvalDeclaPat objEnAvalDeclaPat = new EnAvalDeclaPat();
            objEnAvalDeclaPat.NEmpresa = (String)this.Session[Global.NEmpresa].ToString();
            objEnAvalDeclaPat.IdRegProdAval = hd_IdRegProdAval.Value.ToString();
            ListEnAvalDeclaPat.Add(objEnAvalDeclaPat);
            #endregion Carga_Variable
            LoAvalDeclaPat objLo = new LoAvalDeclaPat();
            dt = objLo.Aval_DeclaPatrimonial_Listar(ListEnAvalDeclaPat);
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
            Cursor_Control(txt_PorPropiedad);
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

            Cursor_Control(txt_PorPropiedad);
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
            List<EnAvalDeclaPat> ListEnAvalDeclaPat = new List<EnAvalDeclaPat>();
            EnAvalDeclaPat objEnAvalDeclaPat = new EnAvalDeclaPat();
            objEnAvalDeclaPat.NEmpresa = (String)this.Session[Global.NEmpresa].ToString();
            objEnAvalDeclaPat.IdReg = str_Codigo;
            objEnAvalDeclaPat.CodUsuario = (String)this.Session[Global.CodUsuario].ToString(); ;
            ListEnAvalDeclaPat.Add(objEnAvalDeclaPat);
            #endregion Carga_Variable
            LoAvalDeclaPat objLo = new LoAvalDeclaPat();

            dt = objLo.Aval_DeclaPatrimonial_Listar_Reg(ListEnAvalDeclaPat);

            if (dt.Rows.Count > 0)
            {
                #region CONTROLES_MANTENIMIENTO
                txt_IdReg.Text = dt.Rows[0]["IdReg"].ToString().Trim();
                txt_ValorComercial.Text = dt.Rows[0]["ValorComercial"].ToString().Trim();
                txt_PorPropiedad.Text = dt.Rows[0]["PorPropiedad"].ToString().Trim();
                txt_Moneda.Text = dt.Rows[0]["Moneda"].ToString().Trim();
                txt_PartidaRegistral.Text = dt.Rows[0]["partidaRegistral"].ToString().Trim();
                cmb_TipoBien.SelectedValue = dt.Rows[0]["CodTipoBien"].ToString().Trim();
                txt_DatosBien.Text = dt.Rows[0]["DatosBien"].ToString().Trim();
                txt_Observacion.Text = dt.Rows[0]["Observacion"].ToString().Trim();
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

            txt_ValorComercial.Text = String.Empty;
            txt_PorPropiedad.Text = String.Empty;
            txt_Moneda.Text = String.Empty;
            txt_PartidaRegistral.Text = String.Empty;

            txt_DatosBien.Text = String.Empty;
            txt_Observacion.Text = String.Empty;



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

        txt_ValorComercial.Enabled = estado;
        txt_PorPropiedad.Enabled = estado;
        txt_Moneda.Enabled = estado;
        txt_PartidaRegistral.Enabled = estado;
        cmb_TipoBien.Enabled = estado;
        txt_DatosBien.Enabled = estado;
        txt_Observacion.Enabled = estado;
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
            List<EnAvalDeclaPat> ListEnAvalDeclaPat = new List<EnAvalDeclaPat>();
            EnAvalDeclaPat objEnAvalDeclaPat = new EnAvalDeclaPat();

            objEnAvalDeclaPat.NEmpresa = (String)this.Session[Global.NEmpresa].ToString();
            objEnAvalDeclaPat.IdRegProdAval = hd_IdRegProdAval.Value.ToString();
            objEnAvalDeclaPat.CodigoCliente = (String)this.Session[Global.CodCliente].ToString();
            objEnAvalDeclaPat.CodTipoBien = cmb_TipoBien.SelectedValue.Trim();
            objEnAvalDeclaPat.PorPropiedad = Util.FormateaDecimal(txt_PorPropiedad.Text);
            objEnAvalDeclaPat.ValorComercial = Util.FormateaDecimal(txt_ValorComercial.Text);
            objEnAvalDeclaPat.Moneda = Util.FormateaEntero(txt_Moneda.Text);
            objEnAvalDeclaPat.PartidaRegistral = txt_PartidaRegistral.Text.Trim();
            objEnAvalDeclaPat.DatosBien = txt_DatosBien.Text.Trim();
            objEnAvalDeclaPat.Observacion = txt_Observacion.Text.Trim();
            objEnAvalDeclaPat.Estado = cmb_Estado.SelectedValue.Trim();
            objEnAvalDeclaPat.CodUsuario = (String)this.Session[Global.CodUsuario].ToString();

            ListEnAvalDeclaPat.Add(objEnAvalDeclaPat);
            #endregion Carga_Variable

            LoAvalDeclaPat objLo = new LoAvalDeclaPat();
            msg = objLo.Aval_DeclaPatrimonial_INS(ListEnAvalDeclaPat);

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
            List<EnAvalDeclaPat> ListEnAvalDeclaPat = new List<EnAvalDeclaPat>();
            EnAvalDeclaPat objEnAvalDeclaPat = new EnAvalDeclaPat();
            objEnAvalDeclaPat.IdReg = hd_Codigo.Value.Trim();
            objEnAvalDeclaPat.NEmpresa = (String)this.Session[Global.NEmpresa].ToString();
            objEnAvalDeclaPat.CodigoCliente = (String)this.Session[Global.CodCliente].ToString();


            objEnAvalDeclaPat.CodTipoBien = cmb_TipoBien.SelectedValue.Trim();
            objEnAvalDeclaPat.PorPropiedad = Util.FormateaDecimal(txt_PorPropiedad.Text);
            objEnAvalDeclaPat.ValorComercial = Util.FormateaDecimal(txt_ValorComercial.Text);
            objEnAvalDeclaPat.Moneda = Util.FormateaEntero(txt_Moneda.Text);
            objEnAvalDeclaPat.PartidaRegistral = txt_PartidaRegistral.Text.Trim();
            objEnAvalDeclaPat.DatosBien = txt_DatosBien.Text.Trim();

            objEnAvalDeclaPat.Observacion = txt_Observacion.Text.Trim();
            objEnAvalDeclaPat.Estado = cmb_Estado.SelectedValue.Trim();
            objEnAvalDeclaPat.CodUsuario = (String)this.Session[Global.CodUsuario].ToString();

            ListEnAvalDeclaPat.Add(objEnAvalDeclaPat);
            #endregion Carga_Variable
            LoAvalDeclaPat objLo = new LoAvalDeclaPat();
            msg = objLo.Aval_DeclaPatrimonial_UPD(ListEnAvalDeclaPat);
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


        if (txt_PorPropiedad.Text.Trim().Length < 1)
        {
            Master.MostrarMensaje("Ingrese % Propiedad", TipoMensaje.Advertencia);
            Cursor_Control(txt_PorPropiedad);
            return false;
        }

        if (txt_PorPropiedad.Text.Trim().Length > 0)
        {
            if (Util.esDecimal(txt_PorPropiedad.Text.Trim()) == false)
            {
                Master.MostrarMensaje("Ingrese Decimal", TipoMensaje.Advertencia);
                Cursor_Control(txt_PorPropiedad);
                return false;
            }
        }

        if (txt_DatosBien.Text.Trim().Length < 1)
        {
            Master.MostrarMensaje("Ingrese Datos del Bien", TipoMensaje.Advertencia);
            Cursor_Control(txt_DatosBien);
            return false;
        }




        return true;
    }
    #endregion funciones
}