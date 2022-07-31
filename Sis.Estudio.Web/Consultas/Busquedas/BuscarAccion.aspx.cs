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

public partial class Consultas_Busquedas_BuscarAccion : BaseBusqueda
{
    #region Busqueda
    #region Eventos_Form
    protected void Page_Load(object sender, EventArgs e)
    {
        IABaseAsginaControles();
        btnBuscar.Focus();
        if (!Page.IsPostBack)
        {
            this.Master.TituloModulo = "Buscar Acción";

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


        LoAccion objLoAccion = new LoAccion();

        List<EnAccion> ListEnAccion = new List<EnAccion>();
        EnAccion objEnAccion = new EnAccion();
        
        objEnAccion.Accion = G_Accion.ToString();
        objEnAccion.CEmpresa = (String)this.Session["cempresa"];
        objEnAccion.Nombre = Util.FormateaTexto(txt_NOMBRE.Text.Trim());
        objEnAccion.Descripcion = Util.FormateaTexto(txt_DESCRIPCION.Text.Trim());

        ListEnAccion.Add(objEnAccion);
        try
        {
            DT_Datos = objLoAccion.Listado_Accion(ListEnAccion);
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
            if (txt_NOMBRE.Text.Length < 1 && txt_DESCRIPCION.Text.Length < 1)
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
    #endregion Busqueda
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
            string str_descripcion = HttpUtility.HtmlDecode(gv.SelectedRow.Cells[3].Text);

            StringBuilder sb = new StringBuilder();
            sb.Append("<script>");
            //sb.Append("window.opener.CargarEmpleado('" + lstIdEmpleado + "');");
            sb.Append("window.opener.CargaAccion('" + str_codigo + "','" + str_descripcion + "');");
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