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
using Sis.Estudio.Logic.MSSQL.Seguridad;


public partial class Estudio_Gestion_GS_Gestion_CarteraCobranza : System.Web.UI.Page
{
    #region Declaraciones
    private string PaginaDetalle = "GS_Gestion_CarteraCobranzaDetalle.aspx";
    private const string PaginaRetorno = "";

    public string val_cod_JerarquiaA = "";
    public string val_cod_JerarquiaB = "";
    public string val_cod_JerarquiaC = "";
    public string val_cod_JerarquiaD = "";

    #endregion  Declaraciones
    #region Eventos_Form

    #region Seleccionar
    protected override void Render(System.Web.UI.HtmlTextWriter writer)
    {
        AddRowSelectToGridView(gv);
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

                row.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(gv, "Select$" + row.RowIndex.ToString(), true));
            }
        }
        Metodo_Pintar();
        #endregion select


    }
    #endregion Seleccionar

    protected void Page_Load(object sender, EventArgs e)
    {

        IABaseAsginaControles();
        //btnBuscar.Focus();
        if (!Page.IsPostBack)
        {
            //G_idopcion = OpcionModulo.MantModulo;
            this.Master.TituloModulo = "Gestion Cartera de Cobranzas";
            //btnDesactivar.Attributes.Add("onClick", "document.getElementById('hdnContinuar').value = confirm('¿Se desactivará El registro, ¿Desea continuar?');");
            //btnProcesar.Attributes.Add("onClick", "document.getElementById('hdnContinuar').value = confirm('¿Se Autorizará El efectivo, ¿Desea continuar?');");
            InicioOperacion();
            Cargar_Modulos();
            CargaComboJerarquiaA();

            PermisosdeJerarquiaSegunUsuario();

            //RefrescarGrid();
            #region accesos
            //Accesos();
            #endregion accesos
            //ConfiguracionInicial();

        }
        //upBotonera.Update();
    }
    #endregion Eventos_Form
    #region ToolBar



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

    /*
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
                Response.Redirect("../../Login.aspx?rd=0");
                return;
            }
            #endregion Sesion

            if (gv.SelectedIndex != -1)
            {
                Exportar(Extencion.Excel);
            }
            else
            {
                Master.MostrarMensaje(Mensaje.M_SELECCIONAR_REGISTRO, TipoMensaje.Advertencia);
                return;
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
                Response.Redirect("../../Login.aspx?rd=0");
                return;
            }
            #endregion Sesion

                    Exportar(Extencion.Pdf);
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message.ToString(), true);
        }

    }
    */













    #endregion ToolBar
    #region Limpiar_Filtro

    #endregion Limpiar_Filtro
    #region Datos

    private void RefrescarGrid()
    {
        DataTable DT_Datos = new DataTable();

        LoGS_Gestion_Cobranza objLoGS_Gestion_Cobranza = new LoGS_Gestion_Cobranza();
        EnGS_Gestion_Cobranza objEnGS_Gestion_Cobranza = new EnGS_Gestion_Cobranza();
        List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza = new List<EnGS_Gestion_Cobranza>();

        objEnGS_Gestion_Cobranza.Accion = "0";
        objEnGS_Gestion_Cobranza.nEmpresa = (String)this.Session["cempresa"];
        objEnGS_Gestion_Cobranza.dias_mora = txt_dias_mora.Text.Trim();

        objEnGS_Gestion_Cobranza.fecha_ini = txt_FECHAINI.Text.ToString();
        objEnGS_Gestion_Cobranza.fecha_fin = txt_FECHAFIN.Text.ToString();
        objEnGS_Gestion_Cobranza.CodTipoGestion = cmb_CodTipoGestion.SelectedValue.ToString().Trim();

        string dato_jerarquiaA = "";
        string dato_jerarquiaB = "";
        string dato_jerarquiaC = "";
        string dato_jerarquiaD = "";

        if (cmb_JerarquiaA.SelectedValue.ToString().Trim() == "") { dato_jerarquiaA = "0"; } else { dato_jerarquiaA = cmb_JerarquiaA.SelectedValue.ToString().Trim(); }
        if (cmb_JerarquiaB.SelectedValue.ToString().Trim() == "") { dato_jerarquiaB = "0"; } else { dato_jerarquiaB = cmb_JerarquiaB.SelectedValue.ToString().Trim(); }
        if (cmb_JerarquiaC.SelectedValue.ToString().Trim() == "") { dato_jerarquiaC = "0"; } else { dato_jerarquiaC = cmb_JerarquiaC.SelectedValue.ToString().Trim(); }
        if (cmb_JerarquiaD.SelectedValue.ToString().Trim() == "") { dato_jerarquiaD = "0"; } else { dato_jerarquiaD = cmb_JerarquiaD.SelectedValue.ToString().Trim(); }

        objEnGS_Gestion_Cobranza.cod_jerarquiaA = dato_jerarquiaA.Trim();
        objEnGS_Gestion_Cobranza.cod_jerarquiaB = dato_jerarquiaB.Trim();
        objEnGS_Gestion_Cobranza.cod_jerarquiaC = dato_jerarquiaC.Trim();
        objEnGS_Gestion_Cobranza.cod_jerarquiaD = dato_jerarquiaD.Trim();


        ListEnGS_Gestion_Cobranza.Add(objEnGS_Gestion_Cobranza);

        try
        {
            DT_Datos = objLoGS_Gestion_Cobranza.GS_Gestion_CarteraCobranza_Lista(ListEnGS_Gestion_Cobranza);
            gv.DataSource = DT_Datos;
            gv.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    private void Desactivar(string str_cod1)
    {
        //****************************************************************************************
        //* Nomre       : Grabar
        //* DescripcioN :
        //****************************************************************************************
        LoGS_Gestion_Cobranza objLoGS_Gestion_Cobranza = new LoGS_Gestion_Cobranza();

        string msg = "";
        string Exito = "";
        try
        {
            #region Carga_Variable

            List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza = new List<EnGS_Gestion_Cobranza>();
            EnGS_Gestion_Cobranza objEnGS_Gestion_Cobranza = new EnGS_Gestion_Cobranza();

            objEnGS_Gestion_Cobranza.IdReg_Gestion_Cobranza = str_cod1;
            objEnGS_Gestion_Cobranza.Id_estado_gestion_cobranza = "4";
            objEnGS_Gestion_Cobranza.CodUsuario = (String)this.Session["codusuario"];

            ListEnGS_Gestion_Cobranza.Add(objEnGS_Gestion_Cobranza);
            #endregion Carga_Variable
            msg = objLoGS_Gestion_Cobranza.GS_Gestion_Cobranza_UPD_Estado(ListEnGS_Gestion_Cobranza);

            if (msg == "exito") { Exito = FlagsPrograma.FLG_VALOREXITOSI; } else { Master.MostrarMensaje(msg, TipoMensaje.Error, msg); Exito = FlagsPrograma.FLG_VALOREXITONO; return; }

            Exito = FlagsPrograma.FLG_VALOREXITOSI;
        }
        catch (SqlException ex)
        {
            msg = HttpUtility.HtmlEncode(ex.Message);
            Master.MostrarMensaje(msg, TipoMensaje.Error);
            Exito = FlagsPrograma.FLG_VALOREXITONO;
        }
        catch (Exception ex)
        {
            msg = HttpUtility.HtmlEncode(ex.Message);
            Master.MostrarMensaje(msg, TipoMensaje.Error);
            Exito = FlagsPrograma.FLG_VALOREXITONO;

        }
        if (Exito == FlagsPrograma.FLG_VALOREXITOSI)
        {
            Master.MostrarMensaje(Mensaje.M_DESACTIVACION_CORRECTA, TipoMensaje.Exito);
            //Refresca_Grid("1");
            RefrescarGrid();
            //up_GV.Update();
        }
    }

    private void Metodo_Pintar()
    {
        try
        {
            #region Validacion
            if (gv.Rows.Count < 1)
            {
                return;
            }
            #endregion Validacion
            /*
            foreach (GridViewRow fila in gv.Rows)
            {

                if (fila.Cells[12].Text.ToString() == "1")
                {
                    fila.Cells[13].BackColor = Color.Yellow;
                }

                if (fila.Cells[12].Text.ToString() == "2")
                {
                    fila.Cells[13].BackColor = Color.Green;
                }

                if (fila.Cells[12].Text.ToString() == "3")
                {
                    fila.Cells[13].BackColor = Color.Red;
                }


            }
            */
            foreach (GridViewRow fila in gv.Rows)
            {
                if (fila.RowType == DataControlRowType.DataRow)
                {
                    HyperLink hlnk = new HyperLink();
                    hlnk.NavigateUrl = "";

                    if (fila.Cells[15].Text.ToString() == "1")
                    {
                        hlnk.ImageUrl = "~/Imagenes/sem_amarillo.png";
                    }
                    if (fila.Cells[15].Text.ToString() == "2")
                    {
                        hlnk.ImageUrl = "~/Imagenes/sem_verde.png";
                    }
                    if (fila.Cells[15].Text.ToString() == "3")
                    {
                        hlnk.ImageUrl = "~/Imagenes/sem_rojo.png";
                    }
                    if (fila.Cells[15].Text.ToString() == "4")
                    {
                        hlnk.ImageUrl = "~/Imagenes/sem_negro.png";
                    }

                    fila.Cells[16].Controls.Add(hlnk);
                }
            }



        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void CargaComboJerarquiaA()
    {
        DataTable dt = new DataTable();
        LoGS_JerarquiaA objLoGS_JerarquiaA = new LoGS_JerarquiaA();
        try
        {
            EnGS_JerarquiaA objEnGS_JerarquiaA = new EnGS_JerarquiaA();
            List<EnGS_JerarquiaA> ListEnGS_JerarquiaA = new List<EnGS_JerarquiaA>();
            cmb_JerarquiaA.Items.Clear();

            objEnGS_JerarquiaA.nempresa = (String)this.Session["cempresa"];

            ListEnGS_JerarquiaA.Add(objEnGS_JerarquiaA);

            dt = objLoGS_JerarquiaA.GS_JerarquiaA_Combo(ListEnGS_JerarquiaA);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["cod_jerarquiaA"].ToString().Trim();
                lista.Text = dt.Rows[i]["desc_jerarquiaA"].ToString().Trim();
                cmb_JerarquiaA.Items.Add(lista);
            }

        }
        catch (Exception excp)
        {
            throw excp;
        }
    }

    protected void CargaComboJerarquiaB()
    {
        DataTable dt = new DataTable();
        LoGS_JerarquiaB objLoGS_JerarquiaB = new LoGS_JerarquiaB();
        try
        {
            EnGS_JerarquiaB objEnGS_JerarquiaB = new EnGS_JerarquiaB();
            List<EnGS_JerarquiaB> ListEnGS_JerarquiaB = new List<EnGS_JerarquiaB>();
            cmb_JerarquiaB.Items.Clear();


            objEnGS_JerarquiaB.cod_jerarquiaA = cmb_JerarquiaA.SelectedValue.ToString();
            objEnGS_JerarquiaB.nempresa = (String)this.Session["cempresa"];
            ListEnGS_JerarquiaB.Add(objEnGS_JerarquiaB);


            dt = objLoGS_JerarquiaB.GS_JerarquiaB_Combo(ListEnGS_JerarquiaB);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["cod_jerarquiaB"].ToString().Trim();
                lista.Text = dt.Rows[i]["desc_jerarquiaB"].ToString().Trim();
                cmb_JerarquiaB.Items.Add(lista);
            }
        }
        catch (Exception excp)
        {
            throw excp;
        }
    }

    protected void CargaComboJerarquiaC()
    {
        DataTable dt = new DataTable();
        LoGS_JerarquiaC objLoGS_JerarquiaC = new LoGS_JerarquiaC();
        try
        {
            EnGS_JerarquiaC objEnGS_JerarquiaC = new EnGS_JerarquiaC();
            List<EnGS_JerarquiaC> ListEnGS_JerarquiaC = new List<EnGS_JerarquiaC>();
            cmb_JerarquiaC.Items.Clear();


            objEnGS_JerarquiaC.cod_jerarquiaB = cmb_JerarquiaB.SelectedValue.ToString();
            objEnGS_JerarquiaC.nempresa = (String)this.Session["cempresa"];
            ListEnGS_JerarquiaC.Add(objEnGS_JerarquiaC);


            dt = objLoGS_JerarquiaC.GS_JerarquiaC_Combo(ListEnGS_JerarquiaC);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["cod_jerarquiaC"].ToString().Trim();
                lista.Text = dt.Rows[i]["desc_jerarquiaC"].ToString().Trim();
                cmb_JerarquiaC.Items.Add(lista);
            }
        }
        catch (Exception excp)
        {
            throw excp;
        }
    }

    protected void CargaComboJerarquiaD()
    {
        DataTable dt = new DataTable();
        LoGS_JerarquiaD objLoGS_JerarquiaD = new LoGS_JerarquiaD();
        try
        {
            EnGS_JerarquiaD objEnGS_JerarquiaD = new EnGS_JerarquiaD();
            List<EnGS_JerarquiaD> ListEnGS_JerarquiaD = new List<EnGS_JerarquiaD>();
            cmb_JerarquiaD.Items.Clear();


            objEnGS_JerarquiaD.cod_jerarquiaC = cmb_JerarquiaC.SelectedValue.ToString();
            objEnGS_JerarquiaD.nempresa = (String)this.Session["cempresa"];
            ListEnGS_JerarquiaD.Add(objEnGS_JerarquiaD);


            dt = objLoGS_JerarquiaD.GS_JerarquiaD_Combo(ListEnGS_JerarquiaD);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["cod_jerarquiaD"].ToString().Trim();
                lista.Text = dt.Rows[i]["desc_jerarquiaD"].ToString().Trim();
                cmb_JerarquiaD.Items.Add(lista);
            }
        }
        catch (Exception excp)
        {
            throw excp;
        }
    }


    protected void CargaComboJerarquiaB_consulta(string cod_JerarquiaA)
    {
        DataTable dt = new DataTable();
        LoGS_JerarquiaB objLoGS_JerarquiaB = new LoGS_JerarquiaB();
        try
        {
            EnGS_JerarquiaB objEnGS_JerarquiaB = new EnGS_JerarquiaB();
            List<EnGS_JerarquiaB> ListEnGS_JerarquiaB = new List<EnGS_JerarquiaB>();
            cmb_JerarquiaB.Items.Clear();


            objEnGS_JerarquiaB.cod_jerarquiaA = cod_JerarquiaA;
            objEnGS_JerarquiaB.nempresa = (String)this.Session["cempresa"];
            ListEnGS_JerarquiaB.Add(objEnGS_JerarquiaB);


            dt = objLoGS_JerarquiaB.GS_JerarquiaB_Combo(ListEnGS_JerarquiaB);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["cod_jerarquiaB"].ToString().Trim();
                lista.Text = dt.Rows[i]["desc_jerarquiaB"].ToString().Trim();
                cmb_JerarquiaB.Items.Add(lista);
            }
        }
        catch (Exception excp)
        {
            throw excp;
        }
    }

    protected void CargaComboJerarquiaC_consulta(string cod_JerarquiaB)
    {
        DataTable dt = new DataTable();
        LoGS_JerarquiaC objLoGS_JerarquiaC = new LoGS_JerarquiaC();
        try
        {
            EnGS_JerarquiaC objEnGS_JerarquiaC = new EnGS_JerarquiaC();
            List<EnGS_JerarquiaC> ListEnGS_JerarquiaC = new List<EnGS_JerarquiaC>();
            cmb_JerarquiaC.Items.Clear();


            objEnGS_JerarquiaC.cod_jerarquiaB = cod_JerarquiaB;
            objEnGS_JerarquiaC.nempresa = (String)this.Session["cempresa"];
            ListEnGS_JerarquiaC.Add(objEnGS_JerarquiaC);


            dt = objLoGS_JerarquiaC.GS_JerarquiaC_Combo(ListEnGS_JerarquiaC);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["cod_jerarquiaC"].ToString().Trim();
                lista.Text = dt.Rows[i]["desc_jerarquiaC"].ToString().Trim();
                cmb_JerarquiaC.Items.Add(lista);
            }
        }
        catch (Exception excp)
        {
            throw excp;
        }
    }

    protected void CargaComboJerarquiaD_consulta(string cod_JerarquiaC)
    {
        DataTable dt = new DataTable();
        LoGS_JerarquiaD objLoGS_JerarquiaD = new LoGS_JerarquiaD();
        try
        {
            EnGS_JerarquiaD objEnGS_JerarquiaD = new EnGS_JerarquiaD();
            List<EnGS_JerarquiaD> ListEnGS_JerarquiaD = new List<EnGS_JerarquiaD>();
            cmb_JerarquiaD.Items.Clear();


            objEnGS_JerarquiaD.cod_jerarquiaC = cod_JerarquiaC;
            objEnGS_JerarquiaD.nempresa = (String)this.Session["cempresa"];
            ListEnGS_JerarquiaD.Add(objEnGS_JerarquiaD);


            dt = objLoGS_JerarquiaD.GS_JerarquiaD_Combo(ListEnGS_JerarquiaD);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["cod_jerarquiaD"].ToString().Trim();
                lista.Text = dt.Rows[i]["desc_jerarquiaD"].ToString().Trim();
                cmb_JerarquiaD.Items.Add(lista);
            }
        }
        catch (Exception excp)
        {
            throw excp;
        }
    }
    
    protected void PermisosdeJerarquiaSegunUsuario()
    {
        CargaDatosCabecera();

        cmb_JerarquiaA.Enabled = false;
        cmb_JerarquiaB.Enabled = false;
        cmb_JerarquiaC.Enabled = false;
        cmb_JerarquiaD.Enabled = false;

        //// verifica permisos ////

        if (val_cod_JerarquiaA != "" && val_cod_JerarquiaB != "" && val_cod_JerarquiaC != "" && val_cod_JerarquiaD != "")
        {
            // niveles A //
            if (val_cod_JerarquiaA != "0" && val_cod_JerarquiaB == "0" && val_cod_JerarquiaC == "0" && val_cod_JerarquiaD == "0"){

                cmb_JerarquiaA.Enabled = false;
                cmb_JerarquiaB.Enabled = true;
                cmb_JerarquiaC.Enabled = true;
                cmb_JerarquiaD.Enabled = true;

                CargaComboJerarquiaA();
                cmb_JerarquiaA.SelectedValue = val_cod_JerarquiaA;
                CargaComboJerarquiaB_consulta(val_cod_JerarquiaA);


            }
            //////////////

            // niveles B //
            if (val_cod_JerarquiaA != "0" && val_cod_JerarquiaB != "0" && val_cod_JerarquiaC == "0" && val_cod_JerarquiaD == "0"){

                cmb_JerarquiaA.Enabled = false;
                cmb_JerarquiaB.Enabled = false;
                cmb_JerarquiaC.Enabled = true;
                cmb_JerarquiaD.Enabled = true;

                CargaComboJerarquiaA();
                cmb_JerarquiaA.SelectedValue = val_cod_JerarquiaA;
                CargaComboJerarquiaB_consulta(val_cod_JerarquiaA);
                cmb_JerarquiaB.SelectedValue = val_cod_JerarquiaB;
                CargaComboJerarquiaC_consulta(val_cod_JerarquiaB);


            }
            //////////////

            // niveles C //
            if (val_cod_JerarquiaA != "0" && val_cod_JerarquiaB != "0" && val_cod_JerarquiaC != "0" && val_cod_JerarquiaD == "0"){


                cmb_JerarquiaA.Enabled = false;
                cmb_JerarquiaB.Enabled = false;
                cmb_JerarquiaC.Enabled = false;
                cmb_JerarquiaD.Enabled = true;

                CargaComboJerarquiaA();
                cmb_JerarquiaA.SelectedValue = val_cod_JerarquiaA;
                CargaComboJerarquiaB_consulta(val_cod_JerarquiaA);
                cmb_JerarquiaB.SelectedValue = val_cod_JerarquiaB;
                CargaComboJerarquiaC_consulta(val_cod_JerarquiaB);
                cmb_JerarquiaC.SelectedValue = val_cod_JerarquiaC;
                CargaComboJerarquiaD_consulta(val_cod_JerarquiaC);

            }
            //////////////

            // niveles D //
            if (val_cod_JerarquiaA != "0" && val_cod_JerarquiaB != "0" && val_cod_JerarquiaC != "0" && val_cod_JerarquiaD != "0")
            {

                cmb_JerarquiaA.Enabled = false;
                cmb_JerarquiaB.Enabled = false;
                cmb_JerarquiaC.Enabled = false;
                cmb_JerarquiaD.Enabled = false;

                CargaComboJerarquiaA();
                cmb_JerarquiaA.SelectedValue = val_cod_JerarquiaA;
                CargaComboJerarquiaB_consulta(val_cod_JerarquiaA);
                cmb_JerarquiaB.SelectedValue = val_cod_JerarquiaB;
                CargaComboJerarquiaC_consulta(val_cod_JerarquiaB);
                cmb_JerarquiaC.SelectedValue = val_cod_JerarquiaC;
                CargaComboJerarquiaD_consulta(val_cod_JerarquiaC);
                cmb_JerarquiaD.SelectedValue = val_cod_JerarquiaD;
            }
            //////////////


        }

        if (val_cod_JerarquiaA == "0" && val_cod_JerarquiaB == "0" && val_cod_JerarquiaC == "0" && val_cod_JerarquiaD == "0")
        {
            Master.MostrarMensaje("No se ha asignado perfil al usuario", TipoMensaje.Error);
            btnBuscar.Enabled = false;
            btnConsultar.Enabled = false;
        }
    }

    protected void CargaDatosCabecera()
    {


        //****************************************************************************************
        //* Nombre      : MostrarDatos
        //* DescripcioN :
        //*
        //****************************************************************************************
        try
        {
            DataTable dt = new DataTable();

            LoUsuario objLoUsuario = new LoUsuario();
            List<EnUsuario> ListEnUsuario = new List<EnUsuario>();
            EnUsuario objEnUsuario = new EnUsuario();


            objEnUsuario.CEmpresa = (String)this.Session["cempresa"];
            objEnUsuario.Tipo = "1";
            objEnUsuario.codUsuario = (String)this.Session["codusuario"];
            ListEnUsuario.Add(objEnUsuario);

            dt = objLoUsuario.CargaDatosUsuario(ListEnUsuario);

            if (dt.Rows.Count > 0)
            {
                txt_desc_jerarquia.Text = dt.Rows[0]["desc_jerarquia"].ToString();
                txt_asesor.Text = dt.Rows[0]["NOMBREUSUARIO"].ToString();

                val_cod_JerarquiaA = dt.Rows[0]["cod_JerarquiaA"].ToString();
                val_cod_JerarquiaB = dt.Rows[0]["cod_JerarquiaB"].ToString();
                val_cod_JerarquiaC = dt.Rows[0]["cod_JerarquiaC"].ToString();
                val_cod_JerarquiaD = dt.Rows[0]["cod_JerarquiaD"].ToString();
            }

        }
        catch (Exception excp)
        {
            throw excp;
        }



    }
    


    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        RefrescarGrid();
    }


    /*
    private void Procesar(string str_n_anio_cier, string str_n_mes_cier)
    {
        //****************************************************************************************
        //* Nomre       : Grabar
        //* DescripcioN :
        //****************************************************************************************
        LoCierre objLoCierre = new LoCierre();

        string msg = "";
        string Exito = "";
        try
        {
            #region Carga_Variable

            List<EnCierre> ListEnCierre = new List<EnCierre>();
            EnCierre objEnCierre = new EnCierre();

            objEnCierre.vsw = "0";
            objEnCierre.n_anio_cier = str_n_anio_cier;
            objEnCierre.n_mes_cier = str_n_mes_cier;
            objEnCierre.c_codi_pers = "";
            objEnCierre.Codidenest = (String)this.Session["codidenest"]; ;



            ListEnCierre.Add(objEnCierre);
            #endregion Carga_Variable
            msg = objLoCierre.Procesar_Cierre(ListEnCierre);

            if (msg == "") { Exito = FlagsPrograma.FLG_VALOREXITOSI; } else { Master.MostrarMensaje(msg, TipoMensaje.Error, msg); Exito = FlagsPrograma.FLG_VALOREXITONO; return; }

            Exito = FlagsPrograma.FLG_VALOREXITOSI;
        }
        catch (SqlException ex)
        {
            msg = HttpUtility.HtmlEncode(ex.Message);
            Master.MostrarMensaje(msg, TipoMensaje.Error);
            Exito = FlagsPrograma.FLG_VALOREXITONO;
        }
        catch (Exception ex)
        {
            msg = HttpUtility.HtmlEncode(ex.Message);
            Master.MostrarMensaje(msg, TipoMensaje.Error);
            Exito = FlagsPrograma.FLG_VALOREXITONO;

        }
        if (Exito == FlagsPrograma.FLG_VALOREXITOSI)
        {
            Master.MostrarMensaje(Mensaje.M_PROCESO_CORRECTO, TipoMensaje.Exito);
            RefrescarGrid();
        }
    }
    */
    #endregion Datos
    #region Metodos

    private string AccionStore()
    {
        string str_retorno;
        /* if (chk_TODOS.Checked)
         {
             str_retorno = AccionListado.Todos.ToString();
         }
         else
         {*/
        /*
        if (txt_login.Text.Length < 1)
        {*/
        str_retorno = AccionListado.Top.ToString();
        /*}
        else
        {
            str_retorno = AccionListado.Filtrado.ToString();
        }
         * */
        /*}*/

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
            string str_nombre = "&n_codi_cier=" + gv.SelectedRow.Cells[1].Text.ToString(); 
            string str_descripcion = "&codidenest=" + (String)this.Session["codidenest"];
            string str_anio = "&anio=" + gv.SelectedRow.Cells[3].Text.ToString();
            string str_mes = "&mes=" + gv.SelectedRow.Cells[4].Text.ToString(); 

            string flag_asistencia;
            flag_asistencia = ""; 
            if (chkAsistencia.Checked==true){
                flag_asistencia = "S";
            }else{
                flag_asistencia = "N";
            }


            string str_flag_empresa = "&flag_asistencia=" + flag_asistencia.ToString();
            string str_TIPOCONSULTA = "&tipoconsulta=" + "0";

            str_Parametros = str_tiporeporte + str_accionstore + str_nombre + str_descripcion + str_flag_empresa + str_TIPOCONSULTA + str_anio + str_mes;

            string CONFIG = "'resizable = yes, scrollbars = yes, toolbar=no, height = 500, width = 800,left=200,top=100,status=yes, location=no, menubar=no'";
            StringBuilder sb = new StringBuilder();
            sb.Append("<script>var win=window.open('../../Reportes/SGO/ReporteCierre_EfectivoC.aspx" + str_Parametros + "', 'ReporteCierreEfectivo', " + CONFIG + ");win.focus();</script>");
            ScriptManager.RegisterStartupScript(this, typeof(Page), "ReporteAccion", sb.ToString(), false);
        }
        catch (Exception excp)
        {
            MostrarMensaje(excp.ToString(), true);
        }
        */
    }
    #endregion Metodos
    #region UpdatePanel

    #endregion UpdatePanel
    #region AsignaControles
    protected void IABaseAsginaControles()
    {
        try
        {
            BaseMantListado.lblMensaje = lblMensaje;
            BaseMantListado.gv = gv;

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

    #endregion AccesosAccion

    #region Modulo

    protected void Cargar_Modulos()
    {
        try
        {

            CargaComboTipoGestion();

        }
        catch (Exception excp)
        {
            throw excp;
        }
    }
    #endregion Modulo

    protected void InicioOperacion()
    {
        //****************************************************************************************
        //* Nomre       : InicioOperacion
        //* DescripcioN :
        //****************************************************************************************

        try
        {
            #region Fecha
            DateTime? Fecha_Hoy = null;
            DateTime? Fecha_Ini = null;
            DateTime? Fecha_Fin = null;

            Fecha_Hoy = DateTime.Today;
            Fecha_Ini = new DateTime(Fecha_Hoy.Value.Year, Fecha_Hoy.Value.Month, 1);
            Fecha_Fin = new DateTime(Fecha_Hoy.Value.Year, Fecha_Hoy.Value.Month, 1).AddDays(-1);

            txt_FECHAINI.Text = Convert.ToDateTime(Fecha_Ini).ToString("dd/MM/yyyy");
            txt_FECHAFIN.Text = Convert.ToDateTime(Fecha_Hoy).ToString("dd/MM/yyyy");
            #endregion Fecha


        }
        catch (Exception excp)
        {
            Master.MostrarMensaje(excp.Message.ToString(), TipoMensaje.Error);

        }

    }


    protected void CargaComboTipoGestion()
    {
        DataTable dt = new DataTable();
        LoGS_ClaseGestiones objLoGS_ClaseGestiones = new LoGS_ClaseGestiones();
        try
        {
            EnGS_ClaseGestiones objEnGS_ClaseGestiones = new EnGS_ClaseGestiones();
            cmb_CodTipoGestion.Items.Clear();

            dt = objLoGS_ClaseGestiones.GS_TipoGestiones_Combo();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["CodTipoGestion"].ToString().Trim();
                lista.Text = dt.Rows[i]["Descripcion"].ToString().Trim();
                cmb_CodTipoGestion.Items.Add(lista);
            }
        }
        catch (Exception excp)
        {
            throw excp;
        }
    }



    #region Procedimientos
    protected void MostrarMensaje(string str_mensaje, bool error)
    {
        //**********************************************************************************************
        //*	 MostrarMensaje : Muestra el  mensaje de avisos.
        //**********************************************************************************************
        lblMensaje.Text = str_mensaje;
        if (error == true)
        {
            lblMensaje.ForeColor = Color.Red;
        }
        else
        {
            lblMensaje.ForeColor = Color.Green;
        }

        //upBotonera.Update();

    }
    protected void limpiarMensaje()
    {
        //**********************************************************************************************
        //*	 limpiarMensaje : limpia mensaje de avisos.
        //**********************************************************************************************
        lblMensaje.Text = "";
        lblMensaje.ForeColor = Color.Red;

    }
    #endregion Procedimientos











    protected void btnConsultar_Click(object sender, EventArgs e)
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
    protected void cmb_JerarquiaA_SelectedIndexChanged(object sender, EventArgs e)
    {
        cmb_JerarquiaC.Items.Clear();
        cmb_JerarquiaD.Items.Clear();
        CargaComboJerarquiaB();
    }
    protected void cmb_JerarquiaB_SelectedIndexChanged(object sender, EventArgs e)
    {
        cmb_JerarquiaD.Items.Clear();
        CargaComboJerarquiaC();
    }
    protected void cmb_JerarquiaC_SelectedIndexChanged(object sender, EventArgs e)
    {
        CargaComboJerarquiaD();
    }

    protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv.PageIndex = e.NewPageIndex;
        RefrescarGrid();
    }
    protected void gv_PageIndexChanged(object sender, EventArgs e)
    {
        if (gv.Rows.Count > 0)
        {
            gv.SelectedIndex = -1;
        }
    }
}