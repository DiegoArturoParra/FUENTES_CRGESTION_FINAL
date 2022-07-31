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
using Sis.Estudio.Entity;
using Sis.Estudio.Logic.MSSQL.Seguridad;
using IABaseWeb;

public partial class Consultas_Busquedas_BuscarPerfil : BaseBusqueda
{
    #region Perfil
    #region Eventos_Form
    protected void Page_Load(object sender, EventArgs e)
    {
        IABaseAsginaControles();
        btnBuscar.Focus();
        if (!Page.IsPostBack)
        {
            this.Master.TituloModulo = "Buscar Perfil";
            Cargar_Modulos();
            Recupera_IdModulo();
            ConfiguracionInicial();
        }
    }
    #endregion Eventos_Form
    #region Limpiar_Filtro
    protected override void Limpiar_Filtros()
    {
        txt_DESCRIPCION.Text = "";
        txt_NOMBRE.Text = "";
        txt_NOMBRE.Focus();
    }
    #endregion Limpiar_Filtro
    #region Datos
    protected override bool Obtener_Datos()
    {
        DT_Datos = new DataTable();

        LoPerfil objLoPerfil = new LoPerfil();
        List<EnPerfil> ListEnPerfil = new List<EnPerfil>();
        EnPerfil objEnPerfil = new EnPerfil();

       objEnPerfil.Accion = G_Accion.ToString();
       objEnPerfil.CEmpresa = (String)this.Session["cempresa"]; //0=empresa
       objEnPerfil.IdModulo = cmb_MODULO.SelectedValue.ToString(); // 1 = MODULO
       objEnPerfil.Nombre = Util.FormateaTexto(txt_NOMBRE.Text.Trim()); //2= NOMBRE
       objEnPerfil.Descripcion = Util.FormateaTexto(txt_DESCRIPCION.Text.Trim());//3=DESCRIPCION
       ListEnPerfil.Add(objEnPerfil);
        try
        {
            DT_Datos = objLoPerfil.GetBuscar_Perfil(ListEnPerfil);
            return base.Obtener_Datos();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion Datos
    #region Metodos
    protected override void Ejecutar_Busqueda()
    {
        try
        {
            #region Filtro
            if (txt_NOMBRE.Text.Length < 1 && txt_DESCRIPCION.Text.Length < 1 && cmb_MODULO.SelectedItem.ToString() == "«Todos»")
            {
                return;
            }
            G_Accion = AccionListado.Filtrado;
            RefrescarGrid();

            #endregion Filtro
        }
        catch (Exception excp)
        {
            MostrarMensaje(excp.ToString(), true);
        }
    }
    #endregion Metodos
    #region AsignaControles
    protected void IABaseAsginaControles()
    {
        try
        {
            BaseBusqueda.lblMensaje = lblMensaje;
            BaseBusqueda.gv = gv;
            BaseBusqueda.ddlPaginaIr = ddlPaginaIr;
            BaseBusqueda.ddlPaginado = ddlPaginado;
            BaseBusqueda.hfOrden = hfOrden;
            BaseBusqueda.lblCantidad = lblCantidad;
            BaseBusqueda.lblPaginaGrilla = lblPaginaGrilla;
        }
        catch (Exception ex)
        {
            lblMensaje.ForeColor = System.Drawing.Color.Red;
            lblMensaje.Text = ex.Message.ToString();
        }
    }
    #endregion AsignaControles
    #endregion Perfil
    #region Modulo
    private void Recupera_IdModulo()
    {
        try
        {
            string str_idModulo = "";
            if (Request["idmodulo"] != null)
            {
                str_idModulo = Request["idmodulo"];
                if (Util.fap_EsNumerico(str_idModulo))
                {
                    cmb_MODULO.SelectedValue = str_idModulo;
                }
            }
            else
            {
                return;
            }

        }
        catch (Exception excp)
        {
            MostrarMensaje(excp.ToString(), true);
        }
    }
    protected void cmb_MODULO_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            RefrescarGrid();
        }
        catch (Exception excp)
        {
            MostrarMensaje(excp.ToString(), true);
        }

    }
    protected void Cargar_Modulos()
    {
        try
        {
            cmb_MODULO.Items.Clear();
            LoPerfil objLoPerfil = new LoPerfil();            
            EnPerfil objEnPerfil = new EnPerfil();
            objEnPerfil.CEmpresa = (String)this.Session["cempresa"];            
            DataTable dt = new DataTable();
            dt = objLoPerfil.ComboFiltroModulos(objEnPerfil);                       
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i][0].ToString().Trim();
                lista.Text = dt.Rows[i][1].ToString().Trim();
                cmb_MODULO.Items.Add(lista);
            }
        }
        catch (Exception excp)
        {
            MostrarMensaje(excp.ToString(), true);
        }
    }
    #endregion Modulo

    protected void btn_SELECCIONAR_Click(object sender, EventArgs e)
    {
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
            string str_codigo = gv.SelectedRow.Cells[1].Text;
            string str_descripcion = HttpUtility.HtmlDecode(gv.SelectedRow.Cells[4].Text);

            StringBuilder sb = new StringBuilder();
            sb.Append("<script>");
            //sb.Append("window.opener.CargarEmpleado('" + lstIdEmpleado + "');");
            sb.Append("window.opener.CargaPerfil('" + str_codigo + "','" + str_descripcion + "');");
            sb.Append("window.close();");
            sb.Append("</script>");
            ScriptManager.RegisterStartupScript(this, typeof(Page), "", sb.ToString(), false);
        }
        else
        {
            Util.MensajeModal(Mensaje.M_SELECCIONAR_REGISTRO, this);
        }
    }

}