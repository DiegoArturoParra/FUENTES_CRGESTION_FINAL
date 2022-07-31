using Sis.Estudio.Entity;
using Sis.Estudio.Logic.MSSQL.Estudio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

public partial class Consultas_Busquedas_Filtro : System.Web.UI.Page
{
    public string mstrEstado;
    public string lcFiltro;
    public static List<EnOperador> lstEnOperador = null;
    public static List<EnColumna> lstEnColumna = null;
    public bool llCerrarVentana = true;
    public static bool plVisible = false;
    

    private char SaltoLinea = '|';
    private char SaltoObj = '^';


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
                //btn_Grabar.Attributes.Add("onClick", "document.getElementById('hdnContinuar').value = confirm('¿Se guardara el registro, ¿Desea continuar?');");
                mxPoblarListaColumnas();
                mxPoblarListaOperadores();
                mxLlenarGrillaFiltro();
                //mxLenarGrillaCondicion();
                mxSeleccionarValoresDeSession();
            }
            lnkAvanzado.Text = plVisible ? "Ir a filtro simple..." : "Ir a filtro avanzado...";
        }
        catch (Exception ex)
        {
            Master.MostrarMensaje(ex.Message.ToString(), TipoMensaje.Error);
        }
    }
    #endregion Constructor
    #region Eventos
    #region Grid
    #endregion Grid
    #region Botones
    

    protected void btnFiltrar_Click(object sender, EventArgs e)
    {
        try
        {
            Master.OcultarMensaje();
            bool continuar;
            bool.TryParse(Request.Form["hdnContinuar"], out continuar);
            this.mxFiltrar();
            string lcScript = @"javascript:fnRefrescarPaginaPadre();";
            mxEjeuctarJavaScript(lcScript);

        }
        catch (Exception ex)
        {
            Master.MostrarMensaje(ex.Message.ToString(), TipoMensaje.Error);
        }
    }

    protected void btn_Retornar_Click(object sender, EventArgs e)
    {
        Response.Redirect("Filtro.aspx");
    }
    #endregion Botones
    #endregion Eventos
    #region Metodos
    private void mxEjeuctarJavaScript(string pcCadena)
    {
        ScriptManager.RegisterStartupScript(this, typeof(Page), "", "<script type='text/javascript'>"+pcCadena+"</script>", false);
    }
    #endregion Metodos
    #region funciones
    private bool Valida_Datos()
    {
        //string estado = (String)ViewState["estado"];
        //if (estado == "modificar")
        //{
        //    if (hd_Codigo.Value == "")
        //    {
        //        Master.MostrarMensaje(Mensaje.M_VALIDACION_DEFINICION_ID, TipoMensaje.Advertencia);
        //        return false;
        //    }
        //}


        //if (txt_PorPropiedad.Text.Trim().Length < 1)
        //{
        //    Master.MostrarMensaje("Ingrese % Propiedad", TipoMensaje.Advertencia);
        //    Cursor_Control(txt_PorPropiedad);
        //    return false;
        //}

        //if (txt_PorPropiedad.Text.Trim().Length > 0)
        //{
        //    if (Util.esDecimal(txt_PorPropiedad.Text.Trim()) == false)
        //    {
        //        Master.MostrarMensaje("Ingrese Decimal", TipoMensaje.Advertencia);
        //        Cursor_Control(txt_PorPropiedad);
        //        return false;
        //    }
        //}

        //if (txt_DatosBien.Text.Trim().Length < 1)
        //{
        //    Master.MostrarMensaje("Ingrese Datos del Bien", TipoMensaje.Advertencia);
        //    Cursor_Control(txt_DatosBien);
        //    return false;
        //}

        return true;
    }
    #endregion funciones

    public void mxLlenarGrillaFiltro()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;
        dt.Columns.Add(new DataColumn("Columna", typeof(string)));
        dt.Columns.Add(new DataColumn("Tipo", typeof(string)));
        dt.Columns.Add(new DataColumn("Valor", typeof(string)));
        for (int i = 0; i < Constantes.C_CANTIDAD_ITEMS_FILTROS; i++)
        {
            dr = dt.NewRow();
            dr["Columna"] = string.Empty;
            dr["Tipo"] = string.Empty;
            dr["Valor"] = string.Empty;
            dt.Rows.Add(dr);
        }
        
        gv.DataSource = dt;
        gv.DataBind();
    }
    protected void mxMostrarOcultarColumnas(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = plVisible;
        e.Row.Cells[1].Visible = plVisible;
        e.Row.Cells[5].Visible = plVisible;
    }
    private void mxLenarGrillaCondicion()
    {
        foreach (GridViewRow row in gv.Rows)
        {
            DropDownList ddlCondicion = (DropDownList)row.FindControl("ddlCondicion");
            ddlCondicion.Items.Add(new ListItem("Y", "Y"));
            ddlCondicion.Items.Add(new ListItem("O", "O"));
            ddlCondicion.DataBind();
            ddlCondicion.SelectedValue = "Y";

            //lstListaFiltro.Add("Y");
            //lstListaFiltro.Add("O");

            //ddlCondicion.DataSource = lstEnColumna;
            //ddlCondicion.DataValueField = lstEnColumna[0];
            //ddlCondicion.DataTextField = lstEnColumna[0];
            //ddlCondicion.DataBind();
        }
    }
    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //WebUserControl_WUCDateTimePicker dtpFecha;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            WebUserControl_WUCDateTimePicker dtpFecha = (WebUserControl_WUCDateTimePicker)e.Row.FindControl("dtpFecha");
            DropDownList ddlColumna = (DropDownList)e.Row.FindControl("ddlColumna");
            DropDownList ddlCondicion = (DropDownList)e.Row.FindControl("ddlCondicion");
            
            ddlColumna.DataSource = lstEnColumna;
            ddlColumna.DataValueField = "nIdColumna";
            ddlColumna.DataTextField = "cDescripcion";
            ddlColumna.DataBind();
            ddlColumna.Items.Insert(0, new ListItem("--Seleccionar--", "-1"));

            ddlCondicion.Items.Add(new ListItem("-", "-1"));
            ddlCondicion.Items.Add(new ListItem("Y", "AND"));
            ddlCondicion.Items.Add(new ListItem("O", "OR"));
            ddlCondicion.DataBind();
            
            ddlColumna.SelectedValue = "-1";//gvProducts.DataKeys[e.Row.RowIndex].Value.ToString();
            ddlCondicion.SelectedValue = "Y";
            dtpFecha.Visible = false;

            if (e.Row.RowIndex == 0)
            {
                ddlCondicion.SelectedValue = "-1";
                ddlCondicion.Visible = false;
            }
            //if (gv.Rows[1].Cells[1].Text==)
            //{
            //    ddlCondicion.SelectedValue = "-1";
            //    ddlCondicion.Enabled = false;
            //}
        }
        mxMostrarOcultarColumnas(sender, e);
    }

    protected void ddlColumna_SelectedIndexChanged(object sender, EventArgs e)
    {
        //this.CargarObjTipoDato(sender);
        
        DropDownList ddlColumna = (DropDownList)sender;
        GridViewRow row = (GridViewRow)ddlColumna.NamingContainer;
        
        if (row != null)
        {
            DropDownList ddlTipo = (DropDownList)row.FindControl("ddlTipo");
            DropDownList ddlCondicion = (DropDownList)row.FindControl("ddlCondicion");
            WebUserControl_WUCDateTimePicker dtpFecha = (WebUserControl_WUCDateTimePicker)row.FindControl("dtpFecha");
            System.Web.UI.WebControls.TextBox txcValor = ((System.Web.UI.WebControls.TextBox)row.FindControl("txtValor"));
            System.Web.UI.WebControls.TextBox txdFecha = (System.Web.UI.WebControls.TextBox)row.FindControl("dtpFecha$txtFecha");

            System.Web.UI.WebControls.TextBox lctxtSeparaIni = ((System.Web.UI.WebControls.TextBox)row.FindControl("txtSeparaIni"));
            System.Web.UI.WebControls.TextBox lctxtSeparaFin = ((System.Web.UI.WebControls.TextBox)row.FindControl("txtSeparaFin"));

            ddlTipo.Items.Clear();
            //if ((row.RowState) > 0)
            //{
            if (ddlColumna.SelectedItem.Value != "-1")
            {
                ddlTipo.DataSource = mxObtenerListaOperadoresXTipoDato_Linq(Convert.ToInt32(ddlColumna.SelectedValue));
                ddlTipo.DataValueField = "nIdOperador";
                ddlTipo.DataTextField = "cOperador";
                ddlTipo.DataBind();
                ddlTipo.Items.Insert(0, new ListItem("--Seleccionar--", "-1"));
                ddlCondicion.SelectedValue = "AND";
                dtpFecha.Dispose();
                llCerrarVentana = false;
                if (mxObtenerTipoDatoXColumna_Linq(Convert.ToInt32(ddlColumna.SelectedValue)) == "Fecha")
                {
                    txcValor.Visible = false;
                    dtpFecha.Visible = true;
                }
                else
                {
                    txcValor.Visible = true;
                    dtpFecha.Visible = false;
                }
                if (row.RowIndex == 0)
                {
                    ddlCondicion.SelectedValue = "-1";
                    ddlCondicion.Visible = false;
                }
            }
            else
            {
                txcValor.Text = string.Empty;
                txdFecha.Text = string.Empty;
                lctxtSeparaIni.Text = string.Empty;
                lctxtSeparaFin.Text = string.Empty;
                ddlCondicion.SelectedValue = "-1";
                txcValor.Visible = true;
                dtpFecha.Visible = false;
            }
            //MessageBox.Show(llCerrarVentana.ToString(), "SelectedIndexChange");
            //}
        }
    }
    private void mxMostrarOcultarDateTimePicker()
    {

    }
    private string mxObtenerTipoDatoXColumna_Linq(int pnIdColumna)
    {
        string models = (from p in mxColumnaTrabajo_LlenarDropDownList()
                         where p.nIdColumna == pnIdColumna.ToString()
                         select p.cTipoDato).First().ToString();
        return models;
    }
    private List<EnColumna> mxObtenerListaColumnas_Linq()
    {
        var models = (from p in lstEnColumna
                      select p);
        return models.ToList();
    }
    private List<EnOperador> mxObtenerListaOperadoresXTipoDato_Linq(int pnIdColumna)
    {
        bool llNumero, llCadena, llFecha;
        llNumero = llCadena = llFecha = false;
        List<EnOperador> lstNuevo = new List<EnOperador>();
        //lstNuevo = null;
        if (mxObtenerTipoDatoXColumna_Linq(pnIdColumna) == "Cadena")
        {
            llCadena = true;
            lstNuevo = (from p in lstEnOperador
                        where (p.lCadena == llCadena.ToString())
                        select p).ToList();
        } 
        if (mxObtenerTipoDatoXColumna_Linq(pnIdColumna) == "Entero" || mxObtenerTipoDatoXColumna_Linq(pnIdColumna) == "Decimal")
        {
            llNumero = true;
            lstNuevo = (from p in lstEnOperador
                        where (p.lNumero == llNumero.ToString())
                        select p).ToList();
        } 
        if (mxObtenerTipoDatoXColumna_Linq(pnIdColumna) == "Fecha")
        {
            llFecha = true;
            lstNuevo = (from p in lstEnOperador
                        where (p.lFecha == llFecha.ToString())
                        select p).ToList();
        }

        return lstNuevo;
    }
    private string mxObtenerLogicaFiltro_Linq(int pnIdOperador)
    {
        var models = (from p in lstEnOperador
                      where p.nIdOperador == pnIdOperador.ToString()
                      select p.cLogica).First().ToString();
        return models;
    }

    public void mxActualizarGrilla()
    {

    }


    public List<EnColumna> mxColumnaTrabajo_LlenarDropDownList()
    {
        DataTable ldtColumna = new DataTable();
        LoColumna loLoColumna = new LoColumna();
        lstEnColumna = new List<EnColumna>();
        EnColumna loEnColumna = new EnColumna();
        loEnColumna.nEmpresa = (String)this.Session[Global.NEmpresa].ToString();
        loEnColumna.nIdTabla = "1";
        lstEnColumna.Add(loEnColumna);
        lstEnColumna = loLoColumna.mxColumnaTrabajo_LlenarDropDownList(lstEnColumna);
        return lstEnColumna;
    }
    public void mxPoblarListaColumnas()
    {
        lstEnColumna = new List<EnColumna>();
        EnColumna loEnColumna = new EnColumna();
        LoColumna loLoColumna = new LoColumna();
        loEnColumna.nEmpresa = (String)this.Session[Global.NEmpresa].ToString();
        loEnColumna.nIdTabla = "1";
        lstEnColumna.Add(loEnColumna);
        lstEnColumna = loLoColumna.mxColumnaTrabajo_LlenarDropDownList(lstEnColumna);
    }
    public void mxPoblarListaOperadores()
    {
        LoColumna loLoColumna = new LoColumna();
        EnColumna loEnColumna = new EnColumna();
        lstEnOperador = new List<EnOperador>();
        lstEnOperador = loLoColumna.mxOperadores_ListaXTipoDato();
    }

    private void mxFiltrar()
    {
        bool minimo = false;
        string lcScript = string.Empty;
        foreach (GridViewRow row in gv.Rows)
        {
            DropDownList objCbeCampoLead = (DropDownList)row.FindControl("ddlColumna");
            DropDownList objCbeTipo = (DropDownList)row.FindControl("ddlTipo");
            WebUserControl_WUCDateTimePicker dtpFecha = (WebUserControl_WUCDateTimePicker)row.FindControl("dtpFecha");
            if (objCbeCampoLead.SelectedValue.ToString() != "-1")
            {
                if (objCbeTipo.SelectedValue.ToString() != "-1")
                {
                    string tipoCombo = mxObtenerTipoDatoXColumna_Linq(Int32.Parse(objCbeCampoLead.SelectedValue.ToString()));
                    string objtxtSentencia = ((System.Web.UI.WebControls.TextBox)row.FindControl("txtValor")).Text;
                    //string objtxtFecha = ((System.Web.UI.WebControls.TextBox)row.FindControl("txtFecha")).Text;
                    //Este DateTime lo guardamos para cunado identifiquemos como se obtiene muestra/oculta ambos textbox
                    //DateEdit objdeSentencia = (DateEdit)(this.Controls.Find("deSentencia" + x, true)[0]);
                    if (((string.IsNullOrEmpty(objtxtSentencia.Trim()) && tipoCombo != "Fecha") ||
                     (string.IsNullOrEmpty(dtpFecha.DateTime) && tipoCombo == "Fecha")))
                    {
                        //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "javascript: alert('Debe ingresar la Sentencia.');", true);
                        //MessageBox.Show("Debe ingresar la Sentencia.", "CR Gestión");
                        if (tipoCombo == "Fecha")
                            dtpFecha.Focus();
                        else
                            row.FindControl("txtValor").Focus();
                        //llCerrarVentana = false;
                        //MessageBox.Show(llCerrarVentana.ToString(), "MetodoFiltrar02");
                        lcScript = "alert('Debe ingresar un valor para la lógica.')";
                        mxEjeuctarJavaScript(lcScript);
                        llCerrarVentana = false; 
                        return;
                    }
                }
                else
                {
                    
                    lcScript = "alert('Debe seleccionar una lógica para el filtro.')";
                    mxEjeuctarJavaScript(lcScript);
                    llCerrarVentana = false; 
                    //MessageBox.Show("Debe seleccionar un Tipo de Filtro.", "CR Gestión");
                    objCbeTipo.Focus();
                    return;
                }
                minimo = true;
            }
            //else
            //{
            //    if (row.RowIndex==0 && //Verifica que sea el primer Item de la grillla
            //        objCbeCampoLead.SelectedValue.ToString() == "-1" && //Valida el el dropdownlist de Columna sea diferente de "--Seleccionar--"
            //        (string.IsNullOrEmpty(objCbeTipo.SelectedValue.ToString()) || objCbeTipo.SelectedValue.ToString() == "-1"))//Valida el el dropdownlist de Tipo sea diferente de "--Seleccionar--"
            //    {
            //        return;
            //    }
            //}
        }
        //if (!minimo)
        //{
        //    MessageBox.Show("Debe seleccionar un Campo Lead.", "CR Call");
        //    glueCampoLead1.Focus();
        //    return;
        //}
        string[] sentencia = this.ConstruyeSentencia();
        if (string.IsNullOrEmpty(sentencia[0]))
        {
            Session["SessionFiltro"] = null;
            Session["HistorialFiltro"] = null;

            llCerrarVentana = true; 
            return;
        }
        //Session["cTipoGestion"] = null;
        Session["SessionFiltro"] = sentencia[0].ToString();
        return;
    }

    private string[] ConstruyeSentencia()
    {
        string subsentencia, lcTipoData, lctxtValor, lcNombreColumna, lcLogica, lcIdColumna,
               lcIdLogica, lcValor, lctxtSeparaIni, lctxtSeparaFin, lcddlCondicion;
        string[] sentencia = new string[2];


        //string[] laFiltro = new string[4];
        //List<laFiltro> lstArregoFiltro = null;
        
        // 1.
        // String array
        // 2A.
        // Convert with new List constructor.
        //List<string> l = new List<string>();

        List<string[]> lstListaFiltro = new List<string[]>();
        string[] laArrayFiltro = null;

        subsentencia= lcTipoData = lctxtValor = lcNombreColumna = lcLogica = lcIdColumna = 
        lcIdLogica = lcValor = lctxtSeparaIni = lctxtSeparaFin = lcddlCondicion= string.Empty;
        foreach (GridViewRow row in gv.Rows)
        {
            DropDownList loddlColumna = (DropDownList)row.FindControl("ddlColumna");
            DropDownList loddlTipo = (DropDownList)row.FindControl("ddlTipo");
            DropDownList loddlCondicion = (DropDownList)row.FindControl("ddlCondicion");
            WebUserControl_WUCDateTimePicker dtpFecha = (WebUserControl_WUCDateTimePicker)row.FindControl("dtpFecha");
            //string[] a = new string[4];

            //List<string> lstArregoFiltro = new List<string>();


            if (string.IsNullOrEmpty(loddlColumna.SelectedValue.ToString()) || loddlColumna.SelectedValue.ToString() == "-1")
                break;
            else
            {
                lcTipoData = mxObtenerTipoDatoXColumna_Linq(Int32.Parse(loddlColumna.SelectedValue.ToString()));
                lctxtValor = ((System.Web.UI.WebControls.TextBox)row.FindControl("txtValor")).Text;
                lctxtSeparaIni = ((System.Web.UI.WebControls.TextBox)row.FindControl("txtSeparaIni")).Text;
                lctxtSeparaFin = ((System.Web.UI.WebControls.TextBox)row.FindControl("txtSeparaFin")).Text;

                lcNombreColumna = (from p in lstEnColumna
                                   where p.nIdColumna == loddlColumna.SelectedValue.ToString()
                                   select p.cNombreColumna).First().ToString();
                
                lcLogica = (from p in lstEnOperador
                            where p.nIdOperador == loddlTipo.SelectedValue.ToString()
                            select p.cLogica).First().ToString();

                if (lcLogica != null &&
                            ((!string.IsNullOrEmpty(lctxtValor.Trim()) && lcTipoData != "Fecha") ||
                                (!string.IsNullOrEmpty(dtpFecha.DateTime) && lcTipoData == "Fecha")))
                {
                    //Insertamos los valores por filtro para luego guardarlos y puedan ser cargador al momento de
                    //abrir el formulario de filtros.
                    lcIdColumna = loddlColumna.SelectedValue.ToString();
                    lcIdLogica = loddlTipo.SelectedValue.ToString();
                    lcValor = lcTipoData == "Fecha" ? dtpFecha.DateTime : lctxtValor.Trim();
                    lctxtSeparaIni = lctxtSeparaIni.ToString();
                    lctxtSeparaFin = lctxtSeparaFin.ToString();
                    lcddlCondicion = loddlCondicion.SelectedValue.ToString();
                    laArrayFiltro = new string[7]
                    {
                        lcTipoData,
                        lcIdColumna,
                        lcIdLogica,
                        lcValor,
                        plVisible?lctxtSeparaIni:string.Empty,
                        plVisible?lctxtSeparaFin:string.Empty,
                        plVisible?lcddlCondicion:"AND"
                    };
                    lstListaFiltro.Add(laArrayFiltro);
                    Session["HistorialFiltro"] = lstListaFiltro; 

                    //Verificamos si la sentencia inicia o ya tiene informacion.
                    if (!string.IsNullOrEmpty(sentencia[0]))
                    {
                        if (loddlCondicion.SelectedValue != "-1" && plVisible)
                        {
                            sentencia[0] += " " + loddlCondicion.SelectedValue.ToString() + " ";
                            sentencia[1] += SaltoLinea;
                        }
                        else
                        {
                            if (loddlCondicion.SelectedValue != "-1" && !plVisible)
                            {
                                sentencia[0] += " AND ";
                                sentencia[1] += SaltoLinea;
                            }
                            else
                            {
                                loddlCondicion.Focus();
                                //break;
                            }
                        }
                    }
                    subsentencia = string.Empty;
                    if (lcTipoData == "Fecha")
                    {
                        string cadena = dtpFecha.DateTime;//objdeSentencia.Text;//Esto sera cuando se identifique la fecha del texto
                        string fecha;
                        String[] sfecha = new string[6];
                        cadena = cadena.Replace(' ', '/');
                        cadena = cadena.Replace(':', '/');
                        sfecha = cadena.Split('/');
                        if (sfecha.Length == 6)
                        {
                            if (sfecha[5] == "p.m." && sfecha[3] != "12")
                            {
                                int hora = 0;
                                hora = Convert.ToInt32(sfecha[3]) + 12;
                                sfecha[3] = hora.ToString();
                            }
                            fecha = sfecha[2] + "-" + sfecha[1] + "-" + sfecha[0] + " " + sfecha[3] + ":" + sfecha[4] + ":00";
                        }
                        else
                        {
                            MessageBox.Show("Debe ingresar una fecha correcta para el Filtro.", "CR Gestión");
                        }
                        fecha = sfecha[2] + "-" + sfecha[1] + "-" + sfecha[0] + " " + sfecha[3] + ":" + sfecha[4] + ":00";
                        /*modificar*/
                        //subsentencia += "CONVERT(VARCHAR(),[" + objCbeCampoLead.EditValue.ToString() + "],120)" + " " + new StringBuilder().AppendFormat(tipo.Value, objdeSentencia.Text);
                        //subsentencia += "[" + objCbeCampoLead.EditValue.ToString() + "]" + " " + new StringBuilder().AppendFormat(tipo.Value, "CONVERT(DATETIME," + "'" +fecha+ "'" + ",120)");
                        subsentencia += "[" + lcNombreColumna + "]" + " " + new StringBuilder().AppendFormat(lcLogica, fecha);
                    }
                    else
                    {
                        bool datoNumerico = Util.EsNumerico(lctxtValor.ToString().ToLower());
                        string[] datos = lctxtValor.Trim().Replace("'", "''").Split(',');
                        foreach (string dato in datos)
                        {
                            if (!string.IsNullOrEmpty(subsentencia))
                                subsentencia += " OR ";
                            if (!datoNumerico && lcLogica.IndexOf("'") == -1)
                                subsentencia += "[" + lcNombreColumna.ToString() + "] " + new StringBuilder().AppendFormat(lcLogica, "'" + dato + "'");
                            else
                                subsentencia += "[" + lcNombreColumna.ToString() + "] " + new StringBuilder().AppendFormat(lcLogica, dato);
                        }
                    }
                    sentencia[0] += new StringBuilder().AppendFormat("({0})", lctxtSeparaIni + subsentencia + lctxtSeparaFin);
                    sentencia[1] += "[" + lcNombreColumna.ToString() + "]" + SaltoObj + lcLogica + SaltoObj + (lcTipoData == "Fecha" ? dtpFecha.DateTime : lctxtValor);
                }
            }
        }
        return sentencia;
    }
    private void mxSeleccionarValoresDeSession()
    {
        if (Session["HistorialFiltro"] != null)
        {
            List<string[]> lstListaFiltro = new List<string[]>();
            string[] laArrayFiltro = null;
            lstListaFiltro = (List<string[]>)Session["HistorialFiltro"];
            int lnContador=0;
            foreach (GridViewRow row in gv.Rows)
            {
                if (lnContador < lstListaFiltro.Count())
                {
                    DropDownList loddlColumna = (DropDownList)row.FindControl("ddlColumna");
                    DropDownList loddlTipo = (DropDownList)row.FindControl("ddlTipo");
                    WebUserControl_WUCDateTimePicker dtpFecha = (WebUserControl_WUCDateTimePicker)row.FindControl("dtpFecha");
                    System.Web.UI.WebControls.TextBox txtFecha = ((System.Web.UI.WebControls.TextBox)row.FindControl("txtValor"));
                    System.Web.UI.WebControls.TextBox Fecha = (System.Web.UI.WebControls.TextBox)row.FindControl("dtpFecha$txtFecha");

                    System.Web.UI.WebControls.TextBox lctxtSeparaIni = ((System.Web.UI.WebControls.TextBox)row.FindControl("txtSeparaIni"));
                    System.Web.UI.WebControls.TextBox lctxtSeparaFin = ((System.Web.UI.WebControls.TextBox)row.FindControl("txtSeparaFin"));

                    DropDownList loddlCondicion = (DropDownList)row.FindControl("ddlCondicion");

                    loddlTipo.DataSource = mxObtenerListaOperadoresXTipoDato_Linq(Convert.ToInt32(lstListaFiltro[lnContador][1]));
                    loddlTipo.DataValueField = "nIdOperador";
                    loddlTipo.DataTextField = "cOperador";
                    loddlTipo.DataBind();
                    loddlTipo.Items.Insert(0, new ListItem("--Seleccionar--", "-1"));

                    lctxtSeparaIni.Text = lstListaFiltro[lnContador][4];
                    lctxtSeparaFin.Text = lstListaFiltro[lnContador][5];
                    loddlCondicion.SelectedValue = lstListaFiltro[lnContador][6];

                    loddlColumna.SelectedValue = lstListaFiltro[lnContador][1];
                    loddlTipo.SelectedValue = lstListaFiltro[lnContador][2];
                    if (lstListaFiltro[lnContador][0].ToString() != "Fecha")
                    {
                        ((System.Web.UI.WebControls.TextBox)row.FindControl("txtValor")).Visible = true;
                        dtpFecha.Visible = false;
                        txtFecha.Text = lstListaFiltro[lnContador][3].ToString();
                    }
                    else
                    {
                        ((System.Web.UI.WebControls.TextBox)row.FindControl("txtValor")).Visible = false;
                        dtpFecha.Visible = true;
                        Fecha.Text = lstListaFiltro[lnContador][3].ToString();
                    }
                }
                lnContador++;
            }
        }
    }
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in gv.Rows)
        {
            DropDownList loddlColumna = (DropDownList)row.FindControl("ddlColumna");
            DropDownList loddlTipo = (DropDownList)row.FindControl("ddlTipo");
            WebUserControl_WUCDateTimePicker dtpFecha = (WebUserControl_WUCDateTimePicker)row.FindControl("dtpFecha");
            System.Web.UI.WebControls.TextBox txtFecha = ((System.Web.UI.WebControls.TextBox)row.FindControl("txtValor"));
            System.Web.UI.WebControls.TextBox Fecha = (System.Web.UI.WebControls.TextBox)row.FindControl("dtpFecha$txtFecha");

            System.Web.UI.WebControls.TextBox lctxtSeparaIni = ((System.Web.UI.WebControls.TextBox)row.FindControl("txtSeparaIni"));
            System.Web.UI.WebControls.TextBox lctxtSeparaFin = ((System.Web.UI.WebControls.TextBox)row.FindControl("txtSeparaFin"));

            DropDownList loddlCondicion = (DropDownList)row.FindControl("ddlCondicion");

            if (loddlColumna.SelectedValue != "-1")
            {
                loddlColumna.SelectedValue = "-1";
                loddlCondicion.SelectedValue = "-1";
                loddlTipo.Items.Clear();
                txtFecha.Text = string.Empty;
                Fecha.Text = string.Empty;
                txtFecha.Visible = true;
                dtpFecha.Visible = false;
                lctxtSeparaIni.Text = string.Empty;
                lctxtSeparaFin.Text = string.Empty;

            }
        }
    }
    protected void lnkAvanzado_Click(object sender, EventArgs e)
    {
        plVisible = !plVisible;
        Response.Redirect("Filtro.aspx");        
    }
}