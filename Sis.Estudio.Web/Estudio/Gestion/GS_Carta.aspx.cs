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
using System.Data.SqlClient;
using IABaseWeb;
using Sis.Estudio.Entity;
using Sis.Estudio.Logic.MSSQL.Gestion;

public partial class Estudio_Gestion_GS_Carta : BaseMantListado
{
    #region Declaraciones
    private string PaginaDetalle = "GS_CartaDetalle.aspx";
    private const string PaginaRetorno = "";
    #endregion  Declaraciones
    #region Eventos_Form
    protected void Page_Load(object sender, EventArgs e)
    {
        IABaseAsginaControles();
        btnBuscar.Focus();
        if (!Page.IsPostBack)
        {
            G_idopcion = OpcionModulo.MantTipoGestiones;
            this.Master.TituloModulo = "Mantenimiento de Documentos";
            #region accesos
            Accesos();
            #endregion accesos
            ConfiguracionInicial();
            btnEliminar.Attributes.Add("onClick", "document.getElementById('hdnContinuar').value = confirm('¿Se anulará El registro, ¿Desea continuar?');");
        }
        //upBotonera.Update();
    }
    #endregion Eventos_Form
    #region ToolBar
    protected void btnAgregar_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            string str_estado = "?estado=n";
            Response.Redirect(PaginaDetalle + str_estado);
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message.ToString(), true);
        }
    }
    protected void btnModificar_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (gv.SelectedIndex != -1)
            {

                string str_estado = "?estado=m";

                string str_id = "&id=" + gv.SelectedRow.Cells[1].Text.ToString();
                string str_nombre = "&nombre=" + gv.SelectedRow.Cells[2].Text.ToString();
                Response.Redirect(PaginaDetalle + str_estado + str_id + str_nombre);
            }
            else
            {
                MostrarMensaje(Mensajes.MSG_MENSAJESELECCIONARREGISTRO, true);
            }
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message.ToString(), true);
        }
    }
    protected void btnConsultar_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (gv.SelectedIndex != -1)
            {

                string str_estado = "?estado=c";

                string str_id = "&id=" + gv.SelectedRow.Cells[1].Text.ToString();
                string str_nombre = "&nombre=" + gv.SelectedRow.Cells[2].Text.ToString();
                Response.Redirect(PaginaDetalle + str_estado + str_id + str_nombre);
            }
            else
            {
                MostrarMensaje(Mensajes.MSG_MENSAJESELECCIONARREGISTRO, true);
            }

        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message.ToString(), true);
        }

    }
    protected void btnEliminar_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            limpiarMensaje();
            this.Master.OcultarMensaje();
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
                bool continuar;
                bool.TryParse(Request.Form["hdnContinuar"], out continuar);
                if (continuar)
                {
                    Anular();
                }
                else
                {
                    MostrarMensaje("Operacion Anular Cancelada", true);
                }
            }
            else
            {
                MostrarMensaje(Mensajes.MSG_MENSAJESELECCIONARREGISTRO, true);
            }
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message.ToString(), true);
        }
    }
    protected void btnExcel_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            limpiarMensaje();
            #region Sesion
            string cempresa = (String)this.Session["cempresa"]; ;
            if (cempresa == "" || cempresa == null)
            {
                this.Session.Abandon();
                Response.Redirect("../Login.aspx?rd=0");
                return;
            }
            #endregion Sesion
            if (chk_TODOS.Checked)
            {
                bool continuar;
                bool.TryParse(Request.Form["hdnContinuar"], out continuar);
                if (continuar)
                {
                    Exportar(Extencion.Excel);
                }
            }
            else
            {
                Exportar(Extencion.Excel);
            }
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message.ToString(), true);
        }
    }
    protected void btnImprimir_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            limpiarMensaje();
            #region Sesion
            string cempresa = (String)this.Session["cempresa"]; ;
            if (cempresa == "" || cempresa == null)
            {
                this.Session.Abandon();
                Response.Redirect("../Login.aspx?rd=0");
                return;
            }
            #endregion Sesion

            if (chk_TODOS.Checked)
            {
                bool continuar;
                bool.TryParse(Request.Form["hdnContinuar"], out continuar);
                if (continuar)
                {
                    Exportar(Extencion.Pdf);
                }
            }
            else
            {
                Exportar(Extencion.Pdf);
            }
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message.ToString(), true);
        }

    }
    protected void btnSalir_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            Response.Redirect("../../Principal.aspx");
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message.ToString(), true);
        }
    }
    #endregion ToolBar
    #region Limpiar_Filtro
    protected override void Limpiar_Filtros()
    {
        txt_DESCRIPCION.Text = "";
        txt_DESCRIPCION.Focus();
    }
    #endregion Limpiar_Filtro
    #region Datos
    protected override void Obtener_Datos()
    {
        DT_Datos = new DataTable();

        LoGS_Carta objLoGS_Carta = new LoGS_Carta();
        EnGS_Carta objEnGS_Carta = new EnGS_Carta();
        List<EnGS_Carta> ListEnGS_Carta = new List<EnGS_Carta>();

        objEnGS_Carta.nEmpresa = (String)this.Session["cempresa"];
        objEnGS_Carta.Descripcion = Util.FormateaTexto(txt_DESCRIPCION.Text.Trim());
        ListEnGS_Carta.Add(objEnGS_Carta);
        
        try
        {
            //WCF

            DT_Datos = objLoGS_Carta.GS_Carta_Lista(ListEnGS_Carta);

            //return base.Obtener_Datos();
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
            #region Todos
            if (chk_TODOS.Checked)
            {
                bool continuar;
                bool.TryParse(Request.Form["hdnContinuar"], out continuar);
                if (continuar)
                {
                    G_Accion = AccionListado.Todos;
                    RefrescarGrid();
                    return;
                }
            }
            #endregion Todos
            #region Filtro
            else
            {
                if (txt_DESCRIPCION.Text.Length < 1)
                {
                    return;
                }
                G_Accion = AccionListado.Filtrado;
                RefrescarGrid();
            }
            #endregion Filtro
        }
        catch (Exception excp)
        {
            MostrarMensaje(excp.ToString(), true);
        }
    }
    private string AccionStore()
    {
        string str_retorno;
        if (chk_TODOS.Checked)
        {
            str_retorno = AccionListado.Todos.ToString();
        }
        else
        {
            if (txt_DESCRIPCION.Text.Length < 1)
            {
                str_retorno = AccionListado.Top.ToString();
            }
            else
            {
                str_retorno = AccionListado.Filtrado.ToString();
            }
        }
        return str_retorno;

    }
    private void Exportar(string Formato)
    {
        /*
        try
        {

            string str_Parametros = "";

            string str_tiporeporte = "?tiporerporte=" + Formato;
            string str_accionstore = "&accionstore=" + AccionStore();
            string str_descripcion = "&descripcion=" + Util.FormateaTexto(txt_DESCRIPCION.Text.Trim());
            string str_cempresa = "&cempresa=" + (String)this.Session["cempresa"];
            string str_TIPOCONSULTA = "&tipoconsulta=" + "0";

            
            str_Parametros = str_tiporeporte + str_accionstore + str_descripcion + str_cempresa + str_TIPOCONSULTA;

            string CONFIG = "'resizable = yes, scrollbars = yes, toolbar=no, height = 500, width = 800,left=200,top=100,status=yes, location=no, menubar=no'";
            StringBuilder sb = new StringBuilder();
            sb.Append("<script>var win=window.open('../../Reportes/Gestion/ReporteGS_TipoGestionesC.aspx" + str_Parametros + "', 'ReportePersonal', " + CONFIG + ");</script>");
            ScriptManager.RegisterStartupScript(this, typeof(Page), "ReporteAccion", sb.ToString(), false);

        }
        catch (Exception excp)
        {
            MostrarMensaje(excp.ToString(), true);
        }
        */
    }
    #endregion Metodos
    #region Anular
    private void Anular()
    {
        //****************************************************************************************
        //* Nomre       : Anular()
        //* DescripcioN :
        //****************************************************************************************
        string msg = "";
        string Exito = "";

        LoGS_Carta ObjLoGS_Carta = new LoGS_Carta();

        try
        {
            #region carga_variables
            List<EnGS_Carta> ListEnGS_Carta = new List<EnGS_Carta>();
            EnGS_Carta ObjEnGS_Carta = new EnGS_Carta();

            ObjEnGS_Carta.id_carta = gv.SelectedRow.Cells[1].Text.ToString();
            ObjEnGS_Carta.CodUsuario = (String)this.Session["codusuario"];

            ListEnGS_Carta.Add(ObjEnGS_Carta);

            #endregion carga_variables

            msg = ObjLoGS_Carta.GS_Carta_DEL(ListEnGS_Carta);
            
            if (msg == "exito") { Exito = FlagsPrograma.FLG_VALOREXITOSI; } else { Master.MostrarMensaje(msg, TipoMensaje.Error, msg); Exito = FlagsPrograma.FLG_VALOREXITONO; return; }

        }
        catch (SqlException ex)
        {
            msg = HttpUtility.HtmlEncode(ex.Message);
            MostrarMensaje(msg, true);
            Exito = FlagsPrograma.FLG_VALOREXITONO;
        }
        catch (Exception ex)
        {
            msg = HttpUtility.HtmlEncode(ex.Message);
            MostrarMensaje(msg, true);
            Exito = FlagsPrograma.FLG_VALOREXITONO;
        }

        if (Exito == FlagsPrograma.FLG_VALOREXITOSI)
        {
            RefrescarGrid();
            MostrarMensaje(" El registro se eliminó correctamente.", false);
        }
    }
    #endregion Anular
    #region UpdatePanel
    protected override void upBotonera_Update()
    {
        upBotonera.Update();
    }
    #endregion UpdatePanel
    #region AsignaControles
    protected void IABaseAsginaControles()
    {
        try
        {
            BaseMantListado.lblMensaje = lblMensaje;
            BaseMantListado.gv = gv;
            BaseMantListado.ddlPaginaIr = ddlPaginaIr;
            BaseMantListado.ddlPaginado = ddlPaginado;
            BaseMantListado.hfOrden = hfOrden;
            BaseMantListado.lblCantidad = lblCantidad;
            BaseMantListado.lblPaginaGrilla = lblPaginaGrilla;
        }
        catch (Exception ex)
        {
            lblMensaje.ForeColor = System.Drawing.Color.Red;
            lblMensaje.Text = ex.Message.ToString();
        }
    }
    #endregion AsignaControles
    #region AccesosAccion
    protected override void BloqueaAcciones()
    {
        try
        {
            btnAgregar.Enabled = false;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            btnConsultar.Enabled = false;
            btnExcel.Enabled = false;
            btnImprimir.Enabled = false;
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message.ToString(), true);
        }

    }
    protected override void ActivaAccionesComunes()
    {
        try
        {
            Propiedades_Boton(btnSalir, "salir");
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message.ToString(), true);
        }
    }
    protected override void ActivaAccion(string accion)
    {
        try
        {
            switch (accion)
            {
                case Accion.Agregar:
                    Propiedades_Boton(btnAgregar, "agregar");
                    break;

                case Accion.Modificar:
                    Propiedades_Boton(btnModificar, "modificar");
                    break;

                case Accion.Eliminar:
                    Propiedades_Boton(btnEliminar, "eliminar");
                    break;

                case Accion.Consultar:
                    Propiedades_Boton(btnConsultar, "consultar");
                    break;

                case Accion.ExportaExcel:
                    Propiedades_Boton(btnExcel, "excel");
                    break;

                case Accion.Imprimir:
                    Propiedades_Boton(btnImprimir, "imprimir");
                    break;

            }
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message.ToString(), true);
        }
    }
    #endregion AccesosAccion
    protected void btnBuscar_Click(object sender, EventArgs e)
    {

    }
}




