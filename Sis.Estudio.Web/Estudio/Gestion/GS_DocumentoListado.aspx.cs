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

public partial class Estudio_Gestion_GS_DocumentoListado : BaseMantListado
{
    string STR_id_Carta = "";
    string STR_estado = "";
    string lcActPla = string.Empty;
    string PaginaRetorno = "GS_Gestion_Cobranza_Carta_Masiva.aspx";
    protected void Page_Load(object sender, EventArgs e)
    {
        //postback: acción por la cual una página hace un llamado al servidor para 
        //realizar una acción en el mismo. Generalmente se da por un evento.
        //IsPostBack: Obtiene un valor que indica si la página se está cargando como respuesta a 
        //un valor devuelto por el cliente, o si es la primera vez que se carga y 
        //se obtiene acceso a la misma.
        STR_id_Carta = Request["idCarta"];
        lcActPla = Request["codTipoDocumento"];
        STR_estado = "request";
        IABaseAsignaControles();
        if (!Page.IsPostBack)
        {
            //this.Master.lblTituloModulo = "Tipos de Documentos";
            ConfiguracionInicial();
            CargarTipoDocumento();
            //string tipoDocumento = Request["codTipoDocumento"];
            //cboTipoDocumento.SelectedValue = lcActPla;
            //cboTipoDocumento.Items.FindByValue(tipoDocumento).Selected = true;
        }
    }

    protected void IABaseAsignaControles()
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
    protected override void ActivaAccionesComunes()
    {
        try
        {
            //Propiedades_Boton(btnSalir, "salir");
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message.ToString(),true);
        }
    }
    /*protected override void Ejecutar_Busqueda()
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
            str_retorno = AccionListado.Filtrado.ToString();
        }
        return str_retorno;

    }*/

    protected override void Obtener_Datos()
    {
        DT_Datos = new DataTable();
        LoGS_Carta objLoGS_Carta = new LoGS_Carta();
        EnGS_Carta objEnGS_Carta = new EnGS_Carta();
        List<EnGS_Carta> ListEnGS_Carta = new List<EnGS_Carta>();

        try
        {
            //if (STR_estado == "request")
            //{
            //    objEnGS_Carta.nEmpresa = (String)this.Session["cempresa"];
            //    objEnGS_Carta.id_carta = STR_id_Carta;
            //    objEnGS_Carta.CodTipoDocum = "-1";
            //    ListEnGS_Carta.Add(objEnGS_Carta);
            //    DT_Datos = objLoGS_Carta.GS_Documento_Lista(ListEnGS_Carta);
            //}
            //if (STR_estado == "eligeCombo")
            //{
            if (!string.IsNullOrEmpty(lcActPla))
            {
                objEnGS_Carta.nEmpresa = (String)this.Session["cempresa"];
                objEnGS_Carta.id_carta = "-1";
                objEnGS_Carta.CodTipoDocum = lcActPla;
                ListEnGS_Carta.Add(objEnGS_Carta);
                DT_Datos = objLoGS_Carta.GS_Documento_Lista(ListEnGS_Carta);
            }
            //}
            
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void cboTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
    {
        STR_estado="eligeCombo";
        RefrescarGrid();
        //CargarDocumento();
    }
    //protected void cboDocumento_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    RefrescarGrid();
    //}

    protected void CargarTipoDocumento()
    {
        DataTable dt = new DataTable();

        try
        {
            LoGS_Carta objLoGS_Carta = new LoGS_Carta();
            EnGS_Carta objEnGS_Carta = new EnGS_Carta();
            List<EnGS_Carta> ListEnGS_Carta = new List<EnGS_Carta>();

            objEnGS_Carta.nEmpresa = (String)this.Session["cempresa"];
            objEnGS_Carta.id_carta = STR_id_Carta;

            ListEnGS_Carta.Add(objEnGS_Carta);

            //cboTipoDocumento.Items.Clear();

            dt = objLoGS_Carta.GS_TipoDocumento_Lista(ListEnGS_Carta);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["CodTipoDocum"].ToString().Trim();
                lista.Text = dt.Rows[i]["Descrip"].ToString().Trim();
                //cboTipoDocumento.Items.Add(lista);
                //tipo = dt.Rows[i]["CodTipoDocum"].ToString().Trim();
            }
            
            
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //protected void CargarDocumento()
    //{
    //    DataTable dt = new DataTable();
    //    try
    //    {
    //        LoGS_Carta objLoGS_Carta = new LoGS_Carta();
    //        EnGS_Carta objEnGS_Carta = new EnGS_Carta();
    //        List<EnGS_Carta> ListEnGS_Carta=new List<EnGS_Carta>();

    //        objEnGS_Carta.nEmpresa = (String)this.Session["cempresa"];
    //        objEnGS_Carta.CodTipoDocum = cboTipoDocumento.SelectedValue.ToString();
    //        ListEnGS_Carta.Add(objEnGS_Carta);
    //        cboDocumento.Items.Clear();

    //        dt = objLoGS_Carta.GS_Documento_X_Tipo(ListEnGS_Carta);
    //        for (int i = 0; i < dt.Rows.Count; i++)
    //        {
    //            ListItem lista = new ListItem();
    //            lista.Value = dt.Rows[i]["id_carta"].ToString().Trim();
    //            lista.Text = dt.Rows[i]["Nombre"].ToString().Trim();
    //            cboDocumento.Items.Add(lista);
    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}
}