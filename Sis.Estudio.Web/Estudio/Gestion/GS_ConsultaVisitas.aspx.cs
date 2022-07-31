using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Script.Serialization;
using IABaseWeb;
using Sis.Estudio.Entity;
using Sis.Estudio.Logic.MSSQL.Gestion;
using Sis.Estudio.Logic.MSSQL.Seguridad;
using Sis.Estudio.Logic.MSSQL.Estudio;
using Subgurim.Controles;
using Subgurim.Controles.GoogleChartIconMaker;
using System.Drawing;

public partial class Estudio_Gestion_GS_ConsultaVisitas : System.Web.UI.Page
{
    public string clientesJSON;
    public int cantidadClientes;
    public DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GeneraMenu_CargaModulos();
            Cargar_Modulos();
            GLatLng crAbogados = new GLatLng(-12.103150, -77.022315);// -12.1040187, -77.0255826
            GMap1.setCenter(crAbogados, 14);
            XPinLetter xpinLetter = new XPinLetter(PinShapes.pin, "CR", Color.Red, Color.White, Color.Green);
            GMap1.Add(new GMarker(crAbogados, new GMarkerOptions(new GIcon(xpinLetter.ToString(), xpinLetter.Shadow()))));
            GMap1.Add(new GMapUI());
        }
    }
    private void GeneraMenu_CargaModulos()
    {
        List<EnLogin> ListEnLogin = new List<EnLogin>();
        EnLogin objEnLogin = new EnLogin();
        LoLogin objLoLogin = new LoLogin();

        objEnLogin.CODUSUARIO = (String)this.Session["codusuario"];
        objEnLogin.CEMPRESA = (String)this.Session["cempresa"];
        objEnLogin.IDMODULO = (String)this.Session["Masteridmodulo"];
        objEnLogin.IDMODULO = "1";

        ListEnLogin.Add(objEnLogin);

        #region WCF

        DataTable dt_menu = objLoLogin.GetMenuUsuario(ListEnLogin);
        //DataSet ds = lseguridad.DS_Menu_Modulos(arrParametros.ToArray());
        //DataTable dt_menu = ds.Tables[0];
        //DataTable dt_Modulos = ds.Tables[1];

        #endregion WCF
        //Carga_Modulos(dt_Modulos);
    }
    /// <summary>
    /// Este metodo deberia recibir como parametro la(s) entidade(s) almacenadas en sesion
    /// que contienen informacion del usuario, opciones, etc, etc
    /// </summary>
    /// <returns></returns>
    private void AddMenuItem(ref MenuItem mnuMenuItem, DataTable dt)
    {
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string padre = dt.Rows[i]["PADRE"].ToString();
            string codigo = dt.Rows[i]["CODIGO"].ToString();
            string url = dt.Rows[i]["URL"].ToString();
            string opcion = dt.Rows[i]["OPCION"].ToString();

            if (padre.ToString().Equals(mnuMenuItem.Value) && !codigo.ToString().Equals(padre.ToString()))
            {
                MenuItem mnuNewMenuItem = new MenuItem();
                mnuNewMenuItem.Value = codigo;
                mnuNewMenuItem.Text = opcion;
                mnuNewMenuItem.NavigateUrl = url;
                mnuNewMenuItem.ToolTip = opcion;
                mnuMenuItem.ChildItems.Add(mnuNewMenuItem);
                AddMenuItem(ref mnuNewMenuItem, dt);
            }
        }
    }

    protected void Cargar_Modulos()
    {
        try
        {
            CargaComboAsesores();

        }
        catch (Exception excp)
        {
            throw excp;
        }
    }
    protected void CargaComboAsesores()
    {
        DataTable dt = new DataTable();

        try
        {
            LoGS_Gestion_Cobranza objLoGS_Gestion_Cobranza = new LoGS_Gestion_Cobranza();
            EnGS_Gestion_Cobranza objEnGS_Gestion_Cobranza = new EnGS_Gestion_Cobranza();
            List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza = new List<EnGS_Gestion_Cobranza>();

            objEnGS_Gestion_Cobranza.nEmpresa = (String)this.Session["cempresa"];//8
            objEnGS_Gestion_Cobranza.CodUsuario = (String)this.Session["codusuario"];
            ListEnGS_Gestion_Cobranza.Add(objEnGS_Gestion_Cobranza);


            cmb_Asesores.Items.Clear();

            dt = objLoGS_Gestion_Cobranza.GS_Gestion_Cobranza_UsuarioRol_Lista(ListEnGS_Gestion_Cobranza);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["n_codi_usua"].ToString().Trim();
                lista.Text = dt.Rows[i]["nombres"].ToString().Trim();
                cmb_Asesores.Items.Add(lista);

            }
        }
        catch (Exception excp)
        {
            throw excp;
        }
    }

    protected DataTable GetData()
    {
        DataTable DT_Datos = new DataTable();

        LoGS_Gestion_Cobranza objLoGS_Gestion_Cobranza = new LoGS_Gestion_Cobranza();
        EnGS_Gestion_Cobranza objEnGS_Gestion_Cobranza = new EnGS_Gestion_Cobranza();
        List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza = new List<EnGS_Gestion_Cobranza>();
        objEnGS_Gestion_Cobranza.nEmpresa = (String)this.Session["cempresa"];
        objEnGS_Gestion_Cobranza.CodUsuario_Asesores = cmb_Asesores.SelectedValue.ToString().Trim();
        objEnGS_Gestion_Cobranza.fecha_ini = txt_FECHAINI.Text.ToString();
        objEnGS_Gestion_Cobranza.fecha_fin = txt_FECHAFIN.Text.ToString();
        ListEnGS_Gestion_Cobranza.Add(objEnGS_Gestion_Cobranza);
        DT_Datos = objLoGS_Gestion_Cobranza.GS_Gestion_Cobranza_Cliente_x_Asesor_Lista(ListEnGS_Gestion_Cobranza);
        return DT_Datos;
    }

    public string DataTable_Json_Serializar(DataTable tabla)
    {
        int cant = 0;
        JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
        List<Dictionary<string, object>> filaPadre = new List<Dictionary<string, object>>();
        Dictionary<string, object> filaHijo;
        foreach (DataRow fila in tabla.Rows)
        {
            filaHijo = new Dictionary<string, object>();
            foreach (DataColumn columna in tabla.Columns)
            {
                filaHijo.Add(columna.ColumnName, fila[columna]);
            }
            cant++;
            cantidadClientes = cant;
            filaPadre.Add(filaHijo);
        }
        return jsSerializer.Serialize(filaPadre);
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        double x1, y1;
        GLatLng centro;
        if (IsPostBack)
        {
            txt_CONTADOR.Text = string.Empty;
            txt_CONTADOR_CLIENTES.Text = string.Empty;
            GMap1.reset();
            GMap1.resetMarkers();
            GMap1.resetInfoWindows();
            dt = GetData();
            int cantidad = dt.Rows.Count;
            if (cantidad == 0) 
            {
                x1 = Convert.ToDouble(-12.0672288);
                y1 = Convert.ToDouble(-77.036303);
                centro = new GLatLng(x1, y1);
                GMap1.setCenter(centro, 12);
                return; 
            }
            int cantClientes = Int32.Parse(dt.Rows[0][6].ToString());
            txt_CONTADOR.Text = cantidad.ToString();
            txt_CONTADOR_CLIENTES.Text = cantClientes.ToString();
            x1 = Convert.ToDouble(dt.Rows[0][4]);
            y1 = Convert.ToDouble(dt.Rows[0][5]);
            centro = new GLatLng(x1, y1);
            GMap1.setCenter(centro, 11);
            PinIcon p;
            GMarker gm;
            GInfoWindow win;

            foreach (DataRow fila in dt.Rows)
            {
                p = new PinIcon(PinIcons.home, Color.Cyan);
                gm = new GMarker(new GLatLng(Convert.ToDouble(fila[4].ToString()), Convert.ToDouble(fila[5].ToString())), new GMarkerOptions(new GIcon(p.ToString(), p.Shadow())));
                gm.options.title = fila[0].ToString();
                win = new GInfoWindow(gm, "<strong>" + fila[0].ToString() + "</strong>" + " </br></br><strong>Tipo de Gestión: </strong>&nbsp;&nbsp;&nbsp;" + fila[1].ToString() + " </br>" + "<strong>Resultado:</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + fila[2].ToString() + " </br>" + "<strong>Clasificación: </strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + fila[3].ToString() + " </br>" + "<strong>Nro Visitas: </strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + fila[6].ToString(), false, GListener.Event.click);
                GMap1.Add(win);
                GMap1.Add(new GMapUI());
            }
        }
    }
}