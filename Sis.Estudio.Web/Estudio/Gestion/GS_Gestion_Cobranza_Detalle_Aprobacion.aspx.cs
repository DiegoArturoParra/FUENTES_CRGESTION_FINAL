using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Data.SqlClient;
using System.IO;
using Sis.Estudio.Entity;
using IABaseWeb;
using Sis.Estudio.Logic.MSSQL.Gestion;

public partial class Estudio_Gestion_GS_Gestion_Cobranza_Detalle_Aprobacion : BaseMantDetalle
{
    #region Declaraciones
    private const string PaginaRetorno = "GS_Gestion_Cobranza_Aprobacion.aspx";
    //public string mstrEstado;
    public string mstrId;
    //string strEmpresa;
    /*Modif. Gestiones internas 08/06/17*/
    public bool cambioFechaLimite = false;
    public bool cambioUsuarioNuevo = false;
    /*Fin modif.*/



    #endregion  Declaraciones
    #region Eventos
    protected void Page_Load(object sender, EventArgs e)
    {
        //****************************************************************************************
        //* Nomre       : Page_Load
        //* DescripcioN :
        //****************************************************************************************
        if (!IsPostBack)
        {

            G_idopcion = OpcionModulo.MantGestionCobranza;
            this.Master.TituloModulo = "Mantenimiento de Action Plan";
            #region accesos
            Accesos();
            #endregion accesos

            CargaComboClientes();
            CargaComboTipoGestion();
            Botonera("consulta");
            EnableControl(false);
            strEmpresa = (String)this.Session["cempresa"];
            CargaComboUsuarioReasignado();

            InicioOperacion();

            //====================== Funcionabilidad JavaScript de botones j. Aroni E.=============================================//
            btnGrabar.Attributes.Add("onClick", "document.getElementById('hdnContinuar').value = confirm('Los datos se guardarán, ¿Desea continuar?');");
            btnReagendar.Attributes.Add("onClick", "document.getElementById('hdnContinuar').value = confirm('¿Desea reagendar el Action Plan?');");
            //btnEliminar.Attributes.Add("onClick", "document.getElementById('hdnContinuar').value = confirm('¿Se anulará El registro, ¿Desea continuar?');");
            btnAprobar.Attributes.Add("onClick", "document.getElementById('hdnContinuar').value = confirm('Se aprobará el Action Plan, ¿Desea continuar?');");
            btnRechazar.Attributes.Add("onClick", "document.getElementById('hdnContinuar').value = confirm('Se rechazará el Action Plan, ¿Desea continuar?');");

            //=================================== Fin  Funcionabilidad JavaScript =================================================//
        }
        if (Request.Params["__EVENTTARGET"] == "RefrescarBusqueda")
        {
            //RefrescarBusqueda();
        }

        /*Visibilidad de controles para AP de Bandeja Gestiones Internas - Flujo 2*/
        //txt_FECHALIMITE.Visible = false;
        
        //cmb_Usuario_Reasignado.Text = "0";
        //cmb_Usuario_Reasignado.Visible = false;
        //cmb_Usuario_Reasignado.Enabled = false;
        //lblReasignarUsuario.Visible = false;
        //lblFechaLimite.Visible = false;
        //txt_FECHALIMITE.Visible = false;
        //txt_FECHALIMITE.Enabled = false;
        //calFechaLimite.Enabled = false;
        //img_FechaLimite.Visible = false;
    }


    protected void btnAgregar_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            #region valida_estado
            string estado = (String)ViewState["estado"];
            if (estado == "agregar" || estado == "modificar")
            {
                return;
            }
            #endregion valida_estado
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
            metodo_agregar();
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
            #region valida_estado
            string estado = (String)ViewState["estado"];
            if (estado == "agregar" || estado == "modificar")
            {
                return;
            }
            #endregion valida_estado
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
            metodo_modificar();
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
            limpiarMensaje();
            this.Master.OcultarMensaje();

            metodo_Consulta();
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
            #region valida_estado
            string estado = (String)ViewState["estado"];
            if (estado == "agregar")
            {
                return;
            }
            #endregion valida_estado
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
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message.ToString(), true);
        }
    }
    protected void btnGrabar_Click(object sender, ImageClickEventArgs e)
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
            bool continuar;
            bool.TryParse(Request.Form["hdnContinuar"], out continuar);
            if (continuar)
            {
                //VALIDACION
                if (Valida_Datos() == false)  //VALIDA
                {
                    return;
                }

                string estado = (String)ViewState["estado"];
                if (estado == "agregar")
                {
                    Grabar();  // GRABA
                }

                if (estado == "modificar")
                {
                    Modificar();  // ACTUALIZA
                }
            }
            else
            {
                MostrarMensaje(Mensaje.M_OPERACION_CANCELADA, true);
            }
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message.ToString(), true);
        }
    }
    protected void btnSalir_Click(object sender, ImageClickEventArgs e)
    {
        this.Session["GS_Gestion_Cobranza_sw"] = "S";

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

        Response.Redirect(PaginaRetorno);
    }


    protected void CargaComboTipoGestion()
    {
        DataTable dt = new DataTable();
        LoGS_Ejecutado objLoGS_Ejecutado = new LoGS_Ejecutado();
        try
        {
            EnGS_Ejecutado objEnGS_Ejecutado = new EnGS_Ejecutado();
            cmb_CodTipoGestion.Items.Clear();

            dt = objLoGS_Ejecutado.GS_TipoGestiones_Combo();

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

    
    #endregion Eventos
    #region Metodos

    protected void CargaComboClientes()
    {
        DataTable dt = new DataTable();
        LoGS_Gestion_Cobranza objLoGS_Gestion_Cobranza = new LoGS_Gestion_Cobranza();
        try
        {
            EnGS_Gestion_Cobranza objEnGS_Gestion_Cobranza = new EnGS_Gestion_Cobranza();
            List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza = new List<EnGS_Gestion_Cobranza>();
            cmb_Cliente.Items.Clear();

            objEnGS_Gestion_Cobranza.nEmpresa = (String)this.Session["cempresa"];

            ListEnGS_Gestion_Cobranza.Add(objEnGS_Gestion_Cobranza);

            dt = objLoGS_Gestion_Cobranza.GS_Gestion_Cobranza_Cliente_Lista(ListEnGS_Gestion_Cobranza);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["CodigoCliente"].ToString().Trim();
                lista.Text = dt.Rows[i]["RazonSocial"].ToString().Trim();
                cmb_Cliente.Items.Add(lista);
            }

        }
        catch (Exception excp)
        {
            throw excp;
        }
    }


    protected void CargaComboProductos()
    {
        DataTable dt = new DataTable();
        LoGS_Gestion_Cobranza objLoGS_Gestion_Cobranza = new LoGS_Gestion_Cobranza();
        try
        {
            EnGS_Gestion_Cobranza objEnGS_Gestion_Cobranza = new EnGS_Gestion_Cobranza();
            List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza = new List<EnGS_Gestion_Cobranza>();
            cmb_Producto.Items.Clear();


            objEnGS_Gestion_Cobranza.CodigoCliente = cmb_Cliente.SelectedValue.ToString();
            objEnGS_Gestion_Cobranza.nEmpresa = (String)this.Session["cempresa"];

            ListEnGS_Gestion_Cobranza.Add(objEnGS_Gestion_Cobranza);


            dt = objLoGS_Gestion_Cobranza.GS_Gestion_Cobranza_Cliente_x_Producto_Lista(ListEnGS_Gestion_Cobranza);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["IdReg"].ToString().Trim();
                lista.Text = dt.Rows[i]["SubProducto"].ToString().Trim();
                cmb_Producto.Items.Add(lista);
            }
        }
        catch (Exception excp)
        {
            throw excp;
        }
    }

    protected void CargaComboProductos_consulta(string CodigoCliente)
    {
        DataTable dt = new DataTable();
        LoGS_Gestion_Cobranza objLoGS_Gestion_Cobranza = new LoGS_Gestion_Cobranza();
        try
        {
            EnGS_Gestion_Cobranza objEnGS_Gestion_Cobranza = new EnGS_Gestion_Cobranza();
            List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza = new List<EnGS_Gestion_Cobranza>();
            cmb_Producto.Items.Clear();


            objEnGS_Gestion_Cobranza.CodigoCliente = CodigoCliente;
            objEnGS_Gestion_Cobranza.nEmpresa = (String)this.Session["cempresa"];

            ListEnGS_Gestion_Cobranza.Add(objEnGS_Gestion_Cobranza);

            dt = objLoGS_Gestion_Cobranza.GS_Gestion_Cobranza_Cliente_x_Producto_Lista(ListEnGS_Gestion_Cobranza);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["IdReg"].ToString().Trim();
                lista.Text = dt.Rows[i]["SubProducto"].ToString().Trim();
                cmb_Producto.Items.Add(lista);
            }
        }
        catch (Exception excp)
        {
            throw excp;
        }
    }
   
    protected void CargaComboResultado_consulta(string CodEjecutado)
    {
        DataTable dt = new DataTable();
        LoGS_ClaseGestiones objLoGS_ClaseGestiones = new LoGS_ClaseGestiones();
        try
        {
            EnGS_ClaseGestiones objEnGS_ClaseGestiones = new EnGS_ClaseGestiones();
            List<EnGS_ClaseGestiones> ListEnGS_ClaseGestiones = new List<EnGS_ClaseGestiones>();
            cmb_ClaseGestiones.Items.Clear();


            objEnGS_ClaseGestiones.CodEjecutado = CodEjecutado;

            ListEnGS_ClaseGestiones.Add(objEnGS_ClaseGestiones);


            dt = objLoGS_ClaseGestiones.GS_ClaseGestionesxEjecutado_Combo(ListEnGS_ClaseGestiones);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["CodClaseGestion"].ToString().Trim();
                lista.Text = dt.Rows[i]["Descripcion"].ToString().Trim();
                cmb_ClaseGestiones.Items.Add(lista);
            }
        }
        catch (Exception excp)
        {
            throw excp;
        }
    }

    protected void CargaComboEjecutado()
    {
        DataTable dt = new DataTable();
        LoGS_Ejecutado objLoGS_Ejecutado = new LoGS_Ejecutado();
        try
        {
            EnGS_Ejecutado objEnGS_Ejecutado = new EnGS_Ejecutado();
            List<EnGS_Ejecutado> ListEnGS_Ejecutado = new List<EnGS_Ejecutado>();
            cmb_CodEjecutado.Items.Clear();


            objEnGS_Ejecutado.CodTipoGestion = cmb_CodTipoGestion.SelectedValue.ToString();

            ListEnGS_Ejecutado.Add(objEnGS_Ejecutado);


            dt = objLoGS_Ejecutado.GS_Ejecutado_TipoGestiones_Combo(ListEnGS_Ejecutado);

            //// llena el --seleccione -- ///
            ListItem lista2 = new ListItem();
            lista2.Value = "0";
            lista2.Text = "--seleccione--";
            cmb_CodEjecutado.Items.Add(lista2);
            /////////////////////////////////

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["CodEjecutado"].ToString().Trim();
                lista.Text = dt.Rows[i]["Descripcion"].ToString().Trim();
                cmb_CodEjecutado.Items.Add(lista);
            }
        }
        catch (Exception excp)
        {
            throw excp;
        }
    }

    protected void CargaComboEjecutado_consulta(string CodTipoGestion)
    {
        DataTable dt = new DataTable();
        LoGS_Ejecutado objLoGS_Ejecutado = new LoGS_Ejecutado();
        try
        {
            EnGS_Ejecutado objEnGS_Ejecutado = new EnGS_Ejecutado();
            List<EnGS_Ejecutado> ListEnGS_Ejecutado = new List<EnGS_Ejecutado>();
            cmb_CodEjecutado.Items.Clear();


            objEnGS_Ejecutado.CodTipoGestion = CodTipoGestion;

            ListEnGS_Ejecutado.Add(objEnGS_Ejecutado);


            dt = objLoGS_Ejecutado.GS_Ejecutado_TipoGestiones_Combo(ListEnGS_Ejecutado);


            //// llena el --seleccione -- ///
            ListItem lista2 = new ListItem();
            lista2.Value = "0";
            lista2.Text = "--seleccione--";
            cmb_CodEjecutado.Items.Add(lista2);
            /////////////////////////////////

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["CodEjecutado"].ToString().Trim();
                lista.Text = dt.Rows[i]["Descripcion"].ToString().Trim();
                cmb_CodEjecutado.Items.Add(lista);
            }


        }
        catch (Exception excp)
        {
            throw excp;
        }
    }

    protected void CargaComboUsuarioReasignado()
    {
        DataTable dt = new DataTable();
        LoGS_Gestion_Cobranza objLoGS_Gestion_Cobranza = new LoGS_Gestion_Cobranza();
        string str_ID = Request["id"];
        string id_Ejecutores = "0";
        try
        {
            EnGS_Gestion_Cobranza objEnGS_Gestion_Cobranza = new EnGS_Gestion_Cobranza();
            List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza = new List<EnGS_Gestion_Cobranza>();
            cmb_Usuario_Reasignado.Items.Clear();
            objEnGS_Gestion_Cobranza.nEmpresa = (String)this.Session["cempresa"];
            objEnGS_Gestion_Cobranza.CodUsuario = (String)this.Session["codusuario"];
            objEnGS_Gestion_Cobranza.IdReg_Gestion_Cobranza = str_ID;
            objEnGS_Gestion_Cobranza.Id_ejecutores = id_Ejecutores;
            ListEnGS_Gestion_Cobranza.Add(objEnGS_Gestion_Cobranza);
            dt = objLoGS_Gestion_Cobranza.GS_Gestion_Cobranza_Ejecutores_Listar(ListEnGS_Gestion_Cobranza);
            //// llena el --seleccione -- ///
            //ListItem lista2 = new ListItem();
            //lista2.Value = "0";
            //lista2.Text = "--seleccione--";
            //cmb_Tramo.Items.Add(lista2);
            /////////////////////////////////
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["CodigoUsuario"].ToString().Trim();
                lista.Text = dt.Rows[i]["NombreUsuario"].ToString().Trim();
                cmb_Usuario_Reasignado.Items.Add(lista);
            }
        }
        catch (Exception excp)
        {
            throw excp;
        }
    }

    protected void InicioOperacion()
    {
        //****************************************************************************************
        //* Nomre       : InicioOperacion
        //* DescripcioN :
        //****************************************************************************************
        try
        {
            string str_Estado = "";
            string str_ID = "1";
            string str_TIPO = "1";

            if (Request["estado"] != null)
            {
                str_Estado = Request["estado"];
            }

            if (str_Estado == "n")
            {
                btnReagendar.Enabled = false;
                btnProponer.Enabled = false;

                metodo_agregar();
                txt_comentario.Enabled = false;
                cmb_ClaseGestiones.Enabled = false;

                cmb_horas.Enabled = false;
                cmb_minutos.Enabled = false;
                imgCal2.Enabled = false;
                
            }
            if (str_Estado == "m")
            {
                str_ID = Request["id"];
                str_TIPO = "1";
                mstrId = str_ID;
                ViewState.Add("id", mstrId);
                MostrarDatos(str_TIPO, str_ID);
                metodo_modificar();
            }
            else if (str_Estado == "c")
            {
                
                str_ID = Request["id"];
                mstrId = str_ID;
                ViewState.Add("id", mstrId);
                metodo_Consulta();
            }
        }
        catch (Exception excp)
        {
            MostrarMensaje(excp.Message.ToString(), true);
        }
    }
    protected void MostrarDatos(string str_TIPO, string str_ID)
    {
        //****************************************************************************************
        //* Nombre      : MostrarDatos
        //* DescripcioN :
        //*                                                    JHONNY ARONI ESLAVA  31/AGOSTO/2010
        //****************************************************************************************
        try
        {
            limpiarMensaje();
            LimpiarControles();
            DataTable dt = new DataTable();

            LoGS_Gestion_Cobranza ObjLoGS_Gestion_Cobranza = new LoGS_Gestion_Cobranza();
            EnGS_Gestion_Cobranza ObjEnGS_Gestion_Cobranza = new EnGS_Gestion_Cobranza();
            List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza = new List<EnGS_Gestion_Cobranza>();

            ObjEnGS_Gestion_Cobranza.IdReg_Gestion_Cobranza = str_ID;
            /*Modif. Gestiones Internas 15/06/17*/
            string cempresa = (String)this.Session["cempresa"];
            ObjEnGS_Gestion_Cobranza.nEmpresa = cempresa;
            /*Fin Modif.*/
            ListEnGS_Gestion_Cobranza.Add(ObjEnGS_Gestion_Cobranza);
            dt = ObjLoGS_Gestion_Cobranza.GS_Gestion_Cobranza_Reg(ListEnGS_Gestion_Cobranza);
            if (dt.Rows.Count > 0)
            {
                #region CONTROLES_MANTENIMIENTO

                Session[Global.CodCliente] = dt.Rows[0]["CodigoCliente"].ToString();


                CargaComboProductos_consulta(dt.Rows[0]["CodigoCliente"].ToString());
                CargaComboResultado_consulta(dt.Rows[0]["CodEjecutado"].ToString());


                txt_codigo.Text = dt.Rows[0]["IdReg_Gestion_Cobranza"].ToString();
                txt_FechaRegistra.Text = dt.Rows[0]["FechaRegistra"].ToString();

                cmb_Cliente.SelectedValue = dt.Rows[0]["CodigoCliente"].ToString();
                cmb_Producto.SelectedValue = dt.Rows[0]["IdReg"].ToString();
                cmb_CodTipoGestion.SelectedValue = dt.Rows[0]["CodTipoGestion"].ToString();
                cmb_ClaseGestiones.SelectedValue = dt.Rows[0]["CodCLaseGestion"].ToString();

                CargaComboEjecutado_consulta(dt.Rows[0]["CodTipoGestion"].ToString());
                cmb_CodEjecutado.SelectedValue = dt.Rows[0]["CodEjecutado"].ToString();

                txt_dias_mora.Text = dt.Rows[0]["dias_mora"].ToString();
                txt_Jerarquia.Text = dt.Rows[0]["Jerarquia_Asesores"].ToString();
                txt_Asesor_Comercial.Text = dt.Rows[0]["Asesores"].ToString();
                txt_dias_control.Text = dt.Rows[0]["Tiempo"].ToString();
                txt_comentario.Text = dt.Rows[0]["comentario"].ToString();

                /***** datos de la fecha de visita *****/

                txt_FECHAVISITA.Text = dt.Rows[0]["FechaVisita_dmy"].ToString();

                cmb_horas.SelectedValue = dt.Rows[0]["FechaVisita_hh"].ToString();
                cmb_minutos.SelectedValue = dt.Rows[0]["FechaVisita_mm"].ToString();

                /***************************************/

                /*Modif Gestiones Internas 08/06/17*/
                cmb_Usuario_Reasignado.SelectedValue = dt.Rows[0]["CodUsuarioNuevo"].ToString();
                txt_FECHALIMITE.Text = dt.Rows[0]["FechaLimite"].ToString();
                /*Fin modif.*/


                //cargagrilla();

                cargagrillacliente();

                //CargaComboResultado_consulta(cmb_CodEjecutado.SelectedValue.ToString());

                #endregion CONTROLES_MANTENIMIENTO

                #region CONTROLES_INFORMATIVOS
                lbl_CODUSUARIOREGISTRA.Text = dt.Rows[0]["CODUSUARIOREGISTRA"].ToString();
                lbl_FECHAREGISTRA.Text = dt.Rows[0]["FECHAREGISTRA"].ToString();
                lbl_ESTADOREGISTRA.Text = "";

                lbl_CODUSUARIOMODIFICA.Text = dt.Rows[0]["CODUSUARIOMODIFICA"].ToString();
                lbl_FECHAMODIFICA.Text = dt.Rows[0]["FECHAMODIFICA"].ToString();
                lbl_ESTADOMODIFICA.Text = "";

                lbl_CODUSUARIOANULA.Text = dt.Rows[0]["CODUSUARIOANULA"].ToString();
                lbl_FECHAANULA.Text = dt.Rows[0]["FECHAANULA"].ToString();
                lbl_ESTADOANULA.Text = dt.Rows[0]["SANULAD"].ToString();

                if (lbl_ESTADOANULA.Text == "S")
                {
                    lbl_ESTADOANULA.ForeColor = Color.Red;
                    lbl_ESTADOANULA.Text = "ANULADO";
                }
                else
                {
                    lbl_ESTADOANULA.Text = "";
                }
                #endregion CONTROLES_INFORMATIVOS
                
                mstrId = txt_codigo.Text.Trim();
                ViewState.Add("id", mstrId);

            }
            upBotonera.Update();
            upControles.Update();
        }
        catch (Exception excp)
        {
            throw excp;
        }
    }

    protected void cargagrilla()
    {

            //if (cmb_ClaseGestiones.SelectedValue.ToString() != "0")
            //{
                    DataTable dt = new DataTable();
                    try
                    {
                        #region Carga_Variables
                        LoGS_Gestion_Cobranza objLoGS_Gestion_Cobranza = new LoGS_Gestion_Cobranza();
                        EnGS_Gestion_Cobranza objEnGS_Gestion_Cobranza = new EnGS_Gestion_Cobranza();
                        List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza = new List<EnGS_Gestion_Cobranza>();

                        objEnGS_Gestion_Cobranza.CodCLaseGestion = cmb_ClaseGestiones.SelectedValue.ToString();

                        ListEnGS_Gestion_Cobranza.Add(objEnGS_Gestion_Cobranza);
                        #endregion Carga_Variables

                        dt = objLoGS_Gestion_Cobranza.GS_Gestion_Cobranza_SubTarea_Gestion_ClasexTipoGestion_Lista(ListEnGS_Gestion_Cobranza);

                        gv.DataSource = dt;
                        gv.DataBind();


                        //*** cargando el valor de los check en la grilla ****//

                        foreach (GridViewRow row in gv.Rows)
                        {
                            Int32 chk = Convert.ToInt32((row.Cells[2].Text));

                            if (chk == 1)
                            {
                                ((CheckBox)row.FindControl("chkPermiso")).Checked = true;
                            }

                            if (chk == 0)
                            {
                                ((CheckBox)row.FindControl("chkPermiso")).Checked = false;
                            }

                        }

                        //*****************************************************//


                    }
                    catch (Exception ex)
                    {
                        Master.MostrarMensaje(ex.Message.ToString(), TipoMensaje.Error, ex);
                    }
            //}
    }




    protected void cargagrilla_todos()
    {



        //if (cmb_ClaseGestiones.SelectedValue.ToString() != "0")
        //{
        DataTable dt = new DataTable();
        try
        {
            #region Carga_Variables
            LoGS_Gestion_Cobranza objLoGS_Gestion_Cobranza = new LoGS_Gestion_Cobranza();
            EnGS_Gestion_Cobranza objEnGS_Gestion_Cobranza = new EnGS_Gestion_Cobranza();
            List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza = new List<EnGS_Gestion_Cobranza>();



            ListEnGS_Gestion_Cobranza.Add(objEnGS_Gestion_Cobranza);
            #endregion Carga_Variables

            dt = objLoGS_Gestion_Cobranza.GS_Gestion_Cobranza_SubTarea_Gestion_ClasexTipoGestion_Lista_Todos();

            gv.DataSource = dt;
            gv.DataBind();


        }
        catch (Exception ex)
        {
            Master.MostrarMensaje(ex.Message.ToString(), TipoMensaje.Error, ex);
        }
        //}
    }


    protected void cargagrillacliente()
    {


        DataTable dt = new DataTable();
        try
        {
            #region Carga_Variables
            LoGS_Gestion_Cobranza objLoGS_Gestion_Cobranza = new LoGS_Gestion_Cobranza();
            EnGS_Gestion_Cobranza objEnGS_Gestion_Cobranza = new EnGS_Gestion_Cobranza();
            List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza = new List<EnGS_Gestion_Cobranza>();


            objEnGS_Gestion_Cobranza.nEmpresa = (String)this.Session["cempresa"];
            objEnGS_Gestion_Cobranza.CodigoCliente = cmb_Cliente.SelectedValue.ToString();
            objEnGS_Gestion_Cobranza.IdReg = cmb_Producto.SelectedValue.ToString();
            
            

            ListEnGS_Gestion_Cobranza.Add(objEnGS_Gestion_Cobranza);
            #endregion Carga_Variables

            dt = objLoGS_Gestion_Cobranza.GS_Gestion_Cobranza_Carga_ClienteGC_Lista(ListEnGS_Gestion_Cobranza);

            gv2.DataSource = dt;
            gv2.DataBind();





        }
        catch (Exception ex)
        {
            Master.MostrarMensaje(ex.Message.ToString(), TipoMensaje.Error, ex);
        }

    }


    protected void metodo_Consulta()
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
        #region ID
        string strID = (String)ViewState["id"];
        if (strID != "" && strID != null)
        {
            MostrarDatos("1", strID);
        }
        else
        {
            MostrarDatos("2", "0");
        }
        #endregion ID
        mstrEstado = "consulta";
        ViewState.Add("estado", mstrEstado);
        EnableControl(false);
        Botonera("consulta");
    }
    protected void metodo_agregar()
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
        #region accesos_opcion

        #endregion accesos_opcion

        mstrEstado = "agregar";
        ViewState.Add("estado", mstrEstado);
        Botonera("mantenimiento");
        EnableControl(true);
        LimpiarControles();
        Cursor_Control(txt_FechaRegistra);

    }
    protected void metodo_modificar()
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
        #region accesos_opcion

        #endregion accesos_opcion
        mstrEstado = "modificar";
        ViewState.Add("estado", mstrEstado);
        Botonera("mantenimiento");
        EnableControl(true);

        cmb_CodTipoGestion.Enabled = false;
        cmb_Cliente.Enabled = false;
        cmb_Producto.Enabled = false;
        
        
        //cmb_CodEjecutado.Enabled = false;


        ////////////////////////
        //btnGrabar.Visible = false;
        btnReagendar.Visible = false;
        btnProponer.Visible = false;
        btnAprobar.Visible = true;
        btnRechazar.Visible = true;
        ///////////////////////

        Cursor_Control(txt_FechaRegistra);

        /****** bloquea los que no son tipo visita (3) ****/
        if (cmb_CodTipoGestion.SelectedValue.ToString() != "3")
        {
            
            cmb_horas.Enabled = false;
            cmb_minutos.Enabled = false;
            imgCal2.Enabled = false;
            
        }
        /**************************************************/
    }
    #endregion Metodos
    #region Procedimientos

    private void EnableControl(bool dato)
    {
        //********************************************************************************
        //**  EnableControl  : Cambia el estado de los controles.
        //**                   Bloquea desbloquea controles :
        //********************************************************************************
        //==== controles de ingreso ====//        
        //txT.Enabled = dato;

        txt_codigo.Enabled = dato;
        txt_FechaRegistra.Enabled = dato;
        txt_dias_mora.Enabled = dato;
        txt_Jerarquia.Enabled = dato;
        txt_Asesor_Comercial.Enabled = dato;
        txt_dias_control.Enabled = dato;
        txt_comentario.Enabled = dato;

        cmb_CodTipoGestion.Enabled = dato;
        cmb_Cliente.Enabled = dato;
        cmb_Producto.Enabled = dato;
        cmb_ClaseGestiones.Enabled = dato;
        cmb_CodEjecutado.Enabled = dato;

        cmb_horas.Enabled = dato;
        cmb_minutos.Enabled = dato;
        imgCal2.Enabled = dato;

        gv.Enabled = dato;






        //==== botones ====//   
        //panelbtnBuscaBanco.Visible = dato;	    //Los controles panel contienen un control boton html por lo tanto se usa la propiedad visible

        upControles.Update();
    }
    protected void Botonera(string strEstado)
    {
        //****************************************************************************************
        //* Nomre       : Botonera
        //* DescripcioN : establece estado de botones Vista - Manteniento
        //****************************************************************************************
        switch (strEstado)
        {
            case "consulta":
                btnGrabar.Visible = false;
                //btnCancelar.Visible = false;
                btnReagendar.Visible = false;
                btnProponer.Visible = false;

                //btnAgregar.Visible = true;
                //btnModificar.Visible = true;
                //btnEliminar.Visible = true;
                //btnSalir.Visible = true;

                upBotonera.Update();
                upControles.Update();




                break;
            case "mantenimiento":

                btnGrabar.Visible = true;
                btnProponer.Visible = true;
                btnReagendar.Visible = true;
                //btnCancelar.Visible = true;

                //btnAgregar.Visible = false;
                //btnModificar.Visible = false;
                //btnEliminar.Visible = false;
                //btnSalir.Visible = false;

                string estado = (String)ViewState["estado"];
                if (estado == "agregar")
                {
                    MostrarMensaje(Mensaje.M_INGRESE_DATOS, false);

                }
                if (estado == "modificar")
                {
                    MostrarMensaje(Mensaje.M_MODIFIQUE_DATOS, false);
                }

                upBotonera.Update();
                upControles.Update();
                break;
        }
    }
    protected void LimpiarControles()
    {
        //****************************************************************************************
        //* Nomre       : LimpiarControles() 
        //* DescripcioN : limpia controles.
        //****************************************************************************************

        txt_codigo.Text = String.Empty;
        txt_FechaRegistra.Text = String.Empty;
        txt_dias_mora.Text = String.Empty;
        txt_Jerarquia.Text = String.Empty;
        txt_Asesor_Comercial.Text = String.Empty;
        txt_dias_control.Text = String.Empty;
        txt_comentario.Text = String.Empty;

        cmb_Cliente.SelectedValue = "0";
        //cmb_JerarquiaB.SelectedValue = "0";

        cmb_CodTipoGestion.SelectedValue = "-1";
        //cmb_ClaseGestiones.SelectedValue = "0";


        lbl_CODUSUARIOREGISTRA.Text = String.Empty;
        lbl_FECHAREGISTRA.Text = String.Empty;
        lbl_ESTADOREGISTRA.Text = String.Empty;

        lbl_CODUSUARIOMODIFICA.Text = String.Empty;
        lbl_FECHAMODIFICA.Text = String.Empty;
        lbl_ESTADOMODIFICA.Text = String.Empty;

        lbl_CODUSUARIOANULA.Text = String.Empty;
        lbl_FECHAANULA.Text = String.Empty;
        lbl_ESTADOANULA.Text = String.Empty;


    }

    #endregion Procedimientos
    #region Funciones
    private bool Valida_Datos()
    {
        //****************************************************************************************
        //* Nomre       : Valida_Datos
        //* DescripcioN :
        //****************************************************************************************
        #region para_Todo


        if (cmb_CodTipoGestion.SelectedValue == "-1")
        {
            MostrarMensaje("Seleccione un tipo de Gestion.", true);
            return false;
        }

        if (cmb_Cliente.SelectedValue == "" || cmb_Cliente.SelectedValue == "0")
        {
            MostrarMensaje("Seleccione un Cliente.", true);
            return false;
        }

        if (cmb_Producto.SelectedValue == "" || cmb_Producto.SelectedValue == "0")
        {
            MostrarMensaje("Seleccione un Producto.", true);
            return false;
        }

        /*
        if (cmb_CodEjecutado.SelectedValue == "")
        {
            MostrarMensaje("Seleccione un Ejecutado.", true);
            return false;
        }
        */
        /*Gestiones Internas 05/06/17*/
        if (cmb_Usuario_Reasignado.SelectedValue == "" || cmb_Usuario_Reasignado.SelectedValue == "0")
        {
            if (cmb_Usuario_Reasignado.Visible)
            {
                MostrarMensaje("Debe seleccionar un Usuario.", true);
                return false;
            }
        }
        if (txt_FECHALIMITE.Text.Length == 0)
        {
            if (cmb_Usuario_Reasignado.Visible)
            {
                MostrarMensaje(Mensaje.M_VALIDACION_FECHA, true);
                return false;
            }
        }
        /*Fin Gestiones Internas 05/06/17*/
        #endregion para_Todo
        #region para_Modificar
        string estado = (String)ViewState["estado"];
        if (estado == "modificar")
        {
            if (txt_codigo.Text.Length < 1)
            {
                MostrarMensaje(Mensaje.M_CODIGO_INVALIDO, true);
                return false;
            }
            
            if (cmb_ClaseGestiones.SelectedValue != "" && cmb_ClaseGestiones.SelectedValue != "0")
            {

                //**** valida que se haya eleguido al menos un ejecutado ****//
                string marco = "";

                foreach (GridViewRow row in gv.Rows)
                {
                    //Int32 chk = Convert.ToInt32((row.Cells[2].Text));

                    if (((CheckBox)row.FindControl("chkPermiso")).Checked == true)
                    {
                        marco = "S";
                    }

                }

                if (marco == "")
                {
                    //MostrarMensaje("Debe seleccione como minimo un Tipo de Ejecutado.", true);
                    //return false;
                }

                //***********************************************************//

            }
            
        }
        #endregion para_Modificar
        return true;
    }
    private bool ValidaEntero(string str_imput)
    {
        //****************************************************************************************
        //* Nomre       : ValidaEntero
        //* DescripcioN : valida el ingreso de Datos enteros
        //* creado      : Jhonny Aroni Eslava   21-agosto-2009
        //****************************************************************************************
        int Codigo = 0;
        if (int.TryParse(str_imput, out Codigo))
        {
            return true;
        }
        return false;
    }
    #endregion Funciones
    #region Datos
    private void Grabar()
    {
        //****************************************************************************************
        //* Nomre       : Grabar
        //* DescripcioN :
        //****************************************************************************************
        string str_Id = "";
        string msg = "";
        string Exito = "";
        LoGS_Gestion_Cobranza ObjLoGS_Gestion_Cobranza = new LoGS_Gestion_Cobranza();
        try
        {
            #region Cargar_Variables
            EnGS_Gestion_Cobranza ObjEnGS_Gestion_Cobranza = new EnGS_Gestion_Cobranza();
            List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza = new List<EnGS_Gestion_Cobranza>();

            ObjEnGS_Gestion_Cobranza.IdReg = cmb_Producto.SelectedValue.ToString();
            ObjEnGS_Gestion_Cobranza.CodTipoGestion = cmb_CodTipoGestion.SelectedValue.ToString();
            ObjEnGS_Gestion_Cobranza.nEmpresa = (String)this.Session["cempresa"];
            ObjEnGS_Gestion_Cobranza.CodUsuario = (String)this.Session["codusuario"];
            



            ListEnGS_Gestion_Cobranza.Add(ObjEnGS_Gestion_Cobranza);
            #endregion Cargar_Variables
            List<EnTransaccion> RetornoT = ObjLoGS_Gestion_Cobranza.GS_Gestion_Cobranza_INS(ListEnGS_Gestion_Cobranza);
            msg = RetornoT[0].MENSAJE.ToString();
            str_Id = RetornoT[0].ID.ToString();
            if (msg == "exito") { Exito = FlagsPrograma.FLG_VALOREXITOSI; } else { Master.MostrarMensaje(msg, TipoMensaje.Error, msg); Exito = FlagsPrograma.FLG_VALOREXITONO; return; }
        }
        catch (SqlException ex)
        {
            msg = HttpUtility.HtmlEncode(ex.Message);
            //MostrarMensaje(msg, true);
            Exito = FlagsPrograma.FLG_VALOREXITONO;
        }
        catch (Exception ex)
        {
            msg = HttpUtility.HtmlEncode(ex.Message);
            Exito = FlagsPrograma.FLG_VALOREXITONO;
        }
        if (Exito == FlagsPrograma.FLG_VALOREXITOSI)
        {
            mstrId = str_Id;
            ViewState.Add("id", mstrId);
            metodo_Consulta();
            MostrarMensaje(Mensaje.M_REGISTRO_CORRECTO, false);
            upControles.Update();
        }
    }
    private void Modificar()
    {
        //****************************************************************************************
        //* Nomre       : Modificar()
        //* DescripcioN :
        //****************************************************************************************
        string msg = "";
        string Exito = "";
        LoGS_Gestion_Cobranza ObjLoGS_Gestion_Cobranza = new LoGS_Gestion_Cobranza();
        try
        {

            #region Cargar_Variables
            EnGS_Gestion_Cobranza ObjEnGS_Gestion_Cobranza = new EnGS_Gestion_Cobranza();
            List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza = new List<EnGS_Gestion_Cobranza>();


            /********************************************/

            ListEnGS_Gestion_Cobranza.Add(ObjEnGS_Gestion_Cobranza);
            #endregion Cargar_Variables                       
            msg = ObjLoGS_Gestion_Cobranza.GS_Gestion_Cobranza_UPD(ListEnGS_Gestion_Cobranza);


                //**** graba subtareas ****//
                foreach (GridViewRow row in gv.Rows)
                {
                    //Int32 chk = Convert.ToInt32((row.Cells[2].Text));

                    if (((CheckBox)row.FindControl("chkPermiso")).Checked == true)
                    {
                        ObjEnGS_Gestion_Cobranza.IdReg = cmb_Producto.SelectedValue.ToString();
                        ObjEnGS_Gestion_Cobranza.CodTipoGestion = row.Cells[0].Text.ToString();
                        ObjEnGS_Gestion_Cobranza.nEmpresa = (String)this.Session["cempresa"];
                        ObjEnGS_Gestion_Cobranza.CodUsuario = (String)this.Session["codusuario"];

                        ListEnGS_Gestion_Cobranza.Add(ObjEnGS_Gestion_Cobranza);
                        List<EnTransaccion> RetornoT2 = ObjLoGS_Gestion_Cobranza.GS_Gestion_Cobranza_SubTarea_INS_JEFE(ListEnGS_Gestion_Cobranza);

                    }

                }
                //***********************************************************//




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
            gv.Visible = false;
            metodo_Consulta();
            MostrarMensaje(Mensaje.M_MODIFICO_REGISTRO_CORRECTAMENTE, false);
            upControles.Update();
        }
    }

    private void Reagendar()
    {
        //****************************************************************************************
        //* Nomre       : Reagendar()
        //* DescripcioN :
        //****************************************************************************************
        string msg = "";
        string Exito = "";
        LoGS_Gestion_Cobranza ObjLoGS_Gestion_Cobranza = new LoGS_Gestion_Cobranza();
        try
        {

            #region Cargar_Variables
            EnGS_Gestion_Cobranza ObjEnGS_Gestion_Cobranza = new EnGS_Gestion_Cobranza();
            List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza = new List<EnGS_Gestion_Cobranza>();

            ObjEnGS_Gestion_Cobranza.IdReg_Gestion_Cobranza = txt_codigo.Text.Trim();
            ObjEnGS_Gestion_Cobranza.CodUsuario = (String)this.Session["codusuario"];

            ObjEnGS_Gestion_Cobranza.FechaReagenda_dmy = "";
            ObjEnGS_Gestion_Cobranza.FechaReagenda_hh = "";
            ObjEnGS_Gestion_Cobranza.FechaReagenda_mm = "";

            ListEnGS_Gestion_Cobranza.Add(ObjEnGS_Gestion_Cobranza);
            #endregion Cargar_Variables
            msg = ObjLoGS_Gestion_Cobranza.GS_Gestion_Cobranza_Reagendar_UPD(ListEnGS_Gestion_Cobranza);






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
            gv.Visible = false;
            metodo_Consulta();
            MostrarMensaje(Mensaje.M_MODIFICO_REGISTRO_CORRECTAMENTE, false);
            upControles.Update();
        }
    }
    private void Anular()
    {
        /*
        //****************************************************************************************
        //* Nomre       : Modificar()
        //* DescripcioN :
        //****************************************************************************************

        string msg = "";
        string Exito = "";

        LoGS_JerarquiaC ObjLoGS_JerarquiaC = new LoGS_JerarquiaC();

        try
        {
            #region Cargar_Variables
            EnGS_JerarquiaC ObjEnGS_JerarquiaC = new EnGS_JerarquiaC();
            List<EnGS_JerarquiaC> ListEnGS_JerarquiaC = new List<EnGS_JerarquiaC>();

            ObjEnGS_JerarquiaC.cod_jerarquiaC = txt_codigo.Text.Trim();
            ObjEnGS_JerarquiaC.CodUsuario = (String)this.Session["codusuario"];


            ListEnGS_JerarquiaC.Add(ObjEnGS_JerarquiaC);
            #endregion Cargar_Variables

            msg = ObjLoGS_JerarquiaC.GS_JerarquiaC_DEL(ListEnGS_JerarquiaC);

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
            msg = Mensaje.M_ANULO_REGISTRO_CORRECTAMENTE;
            MostrarMensaje(msg, false);
            upControles.Update();
            PostAnular(msg, PaginaRetorno);
        }
         */ 
    }
    #endregion Datos
    #region Mensajes
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
    }
    protected void limpiarMensaje()
    {
        //**********************************************************************************************
        //*	 limpiarMensaje : limpia mensaje de avisos.
        //**********************************************************************************************
        lblMensaje.Text = "";
        lblMensaje.ForeColor = Color.Red;
        upBotonera.Update();
    }
    #endregion Mensajes
    #region AsignaControles
    protected void IABaseAsginaControles()
    {
        try
        {
            BaseMantDetalle.lblMensaje = lblMensaje;            
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
            btnConsultar.Enabled = false;
            btnEliminar.Enabled = false;

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
            //Propiedades_Boton(btnGrabar, "grabar");
            //Propiedades_Boton(btnSalir, "salir");
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message.ToString(), true);
        }
    }

    /*
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

                case Accion.Consultar:
                    Propiedades_Boton(btnConsultar, "consultar");
                    break;

                case Accion.Eliminar:
                    Propiedades_Boton(btnEliminar, "eliminar");
                    break;
            }
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message.ToString(), true);
        }
    }
    */

    #endregion AccesosAccion
    
    protected void cmb_Cliente_SelectedIndexChanged(object sender, EventArgs e)
    {
        CargaComboProductos();
    }
    protected void cmb_CodTipoGestion_SelectedIndexChanged(object sender, EventArgs e)
    {
        //CargaComboEjecutado();
    }
    protected void cmb_ClaseGestiones_SelectedIndexChanged(object sender, EventArgs e)
    {
        //cargagrilla();
    }
    protected void cmb_CodEjecutado_SelectedIndexChanged(object sender, EventArgs e)
    {
        CargaComboResultado_consulta(cmb_CodEjecutado.SelectedValue.ToString());
    }
    protected void btnReagendar_Click(object sender, EventArgs e)
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
            bool continuar;
            bool.TryParse(Request.Form["hdnContinuar"], out continuar);
            if (continuar)
            {
                //VALIDACION
                if (Valida_Datos() == false)  //VALIDA
                {
                    return;
                }

                string estado = (String)ViewState["estado"];
                if (estado == "agregar")
                {
                    //Grabar();  // GRABA
                }

                if (estado == "modificar")
                {
                    Modificar();  // ACTUALIZA
                    Reagendar(); // REAGENDA


                    ////// regresa pagina padre //////
                    this.Session["GS_Gestion_Cobranza_sw"] = "S";
                    limpiarMensaje();
                    Response.Redirect(PaginaRetorno);
                    /////////////////////////////////

 
                }
            }
            else
            {
                MostrarMensaje(Mensaje.M_OPERACION_CANCELADA, true);
            }
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message.ToString(), true);
        }

    }
    protected void btnProponer_Click(object sender, EventArgs e)
    {


        if (cmb_ClaseGestiones.SelectedValue != "" && cmb_ClaseGestiones.SelectedValue != "0" && cmb_CodEjecutado.SelectedValue != "" && cmb_CodEjecutado.SelectedValue != "0")
        {
            cargagrilla();
        }
        else {

            Master.MostrarMensaje("Debe seleccionar una clasificación", TipoMensaje.Advertencia);
        }
    }

    protected void btnAprobar_Click(object sender, EventArgs e)
    {
        this.Master.OcultarMensaje();
        string msg = "";
        string Exito = "";
        try
        {
            #region Carga_Variable

            LoGS_Gestion_Cobranza objLoGS_Gestion_Cobranza = new LoGS_Gestion_Cobranza();
            EnGS_Gestion_Cobranza objEnGS_Gestion_Cobranza = new EnGS_Gestion_Cobranza();
            List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza = new List<EnGS_Gestion_Cobranza>();
            objEnGS_Gestion_Cobranza.nEmpresa = (String)this.Session["cempresa"];
            objEnGS_Gestion_Cobranza.IdReg_Gestion_Cobranza = txt_codigo.Text.Trim();;
            objEnGS_Gestion_Cobranza.comentario = txt_comentario.Text.ToString();
            objEnGS_Gestion_Cobranza.CodUsuario = (String)this.Session["codusuario"];
            objEnGS_Gestion_Cobranza.FechaLimite = txt_FECHALIMITE.Text;
            objEnGS_Gestion_Cobranza.CodUsuarioNuevo = cmb_Usuario_Reasignado.SelectedValue.ToString();
            //if (cambioUsuarioNuevo || cambioFechaLimite)
            //{
            //    if (cambioFechaLimite && cambioUsuarioNuevo)
            //    {
            //        objEnGS_Gestion_Cobranza.FechaLimite = txt_FECHALIMITE.Text;
            //        objEnGS_Gestion_Cobranza.CodUsuarioNuevo = cmb_Usuario_Reasignado.SelectedValue.ToString();
            //    }
            //    else
            //    {
            //        if (cambioFechaLimite)
            //        {
            //            objEnGS_Gestion_Cobranza.FechaLimite = txt_FECHALIMITE.Text;
            //        }
            //        else
            //        {
            //            objEnGS_Gestion_Cobranza.CodUsuarioNuevo = cmb_Usuario_Reasignado.SelectedValue.ToString();
            //        }
            //    }
            //}
            
            

            ListEnGS_Gestion_Cobranza.Add(objEnGS_Gestion_Cobranza);
                            
            #endregion Carga_Variable
            msg = objLoGS_Gestion_Cobranza.GS_Gestion_Cobranza_Aprobar_Jefe(ListEnGS_Gestion_Cobranza);

            if (msg == "exito") { Exito = FlagsPrograma.FLG_VALOREXITOSI; } else { Master.MostrarMensaje(msg, TipoMensaje.Error, msg); Exito = FlagsPrograma.FLG_VALOREXITONO; return; }

            Exito = FlagsPrograma.FLG_VALOREXITOSI;
        }
        catch (SqlException ex)
        {
            msg = HttpUtility.HtmlEncode(ex.Message);
            Master.MostrarMensaje(msg, TipoMensaje.Error);
            Exito = FlagsPrograma.FLG_VALOREXITONO;
        }

        if (Exito == FlagsPrograma.FLG_VALOREXITOSI)
        {
        //RefrescarGrid();
            Master.MostrarMensaje("Se Aprobó Correctamente", TipoMensaje.Exito);
            /// regresa al menu anterior ///
            this.Session["GS_Gestion_Cobranza_sw"] = "S";

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

            Response.Redirect(PaginaRetorno);
            ////////////////////////////////
        //Refresca_Grid("1");

        //up_GV.Update();
        }


            //*****************************************************//
        }

    protected void btnRechazar_Click(object sender, EventArgs e)
    {
        this.Master.OcultarMensaje();
        string msg = "";
        string Exito = "";
        try
        {
            #region Carga_Variable
            LoGS_Gestion_Cobranza objLoGS_Gestion_Cobranza = new LoGS_Gestion_Cobranza();
            EnGS_Gestion_Cobranza objEnGS_Gestion_Cobranza = new EnGS_Gestion_Cobranza();
            List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza = new List<EnGS_Gestion_Cobranza>();
            objEnGS_Gestion_Cobranza.nEmpresa = (String)this.Session["cempresa"];
            objEnGS_Gestion_Cobranza.IdReg_Gestion_Cobranza = txt_codigo.Text.Trim();;
            objEnGS_Gestion_Cobranza.comentario = txt_comentario.Text.ToString();
            objEnGS_Gestion_Cobranza.CodUsuario = (String)this.Session["codusuario"];
            ListEnGS_Gestion_Cobranza.Add(objEnGS_Gestion_Cobranza);
            #endregion Carga_Variable
            msg = objLoGS_Gestion_Cobranza.GS_Gestion_Cobranza_Rechazar_Jefe(ListEnGS_Gestion_Cobranza);
            if (msg == "exito") { Exito = FlagsPrograma.FLG_VALOREXITOSI; } else { Master.MostrarMensaje(msg, TipoMensaje.Error, msg); Exito = FlagsPrograma.FLG_VALOREXITONO; return; }

            Exito = FlagsPrograma.FLG_VALOREXITOSI;
        }
        catch (SqlException ex)
        {
            msg = HttpUtility.HtmlEncode(ex.Message);
            Master.MostrarMensaje(msg, TipoMensaje.Error);
            Exito = FlagsPrograma.FLG_VALOREXITONO;
        }

        if (Exito == FlagsPrograma.FLG_VALOREXITOSI)
        {

        Master.MostrarMensaje("Se Rechazó Correctamente", TipoMensaje.Exito);


            //// habilita el flujo normal ////
            btnGrabar.Visible = true;
            btnAprobar.Visible = false;
            btnRechazar.Visible = false;
            /////////////////////////////////

            cargagrilla_todos();

        }
        //*****************************************************//
    }

    protected void chkPermiso_CheckedChanged(object sender, EventArgs e)
    {
        int resultadoValidacion = 0;
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            string codTipoGestion = "";// gv.SelectedRow.Cells[2].Text.ToString();
            CheckBox chk = (CheckBox)sender;
            GridViewRow fila = (GridViewRow)chk.Parent.Parent;
            codTipoGestion = fila.Cells[0].Text.ToString();
            EnGS_TipoGestiones objEnGS_TipoGestiones = new EnGS_TipoGestiones();
            LoGS_TipoGestiones objLoGS_TipoGestiones = new LoGS_TipoGestiones();
            List<EnGS_TipoGestiones> ListEnGS_TipoGestiones = new List<EnGS_TipoGestiones>();
            objEnGS_TipoGestiones.CodTipoGestion = codTipoGestion;
            ListEnGS_TipoGestiones.Add(objEnGS_TipoGestiones);
            dt = objLoGS_TipoGestiones.GS_TipoGestiones_ValidarFlujo(ListEnGS_TipoGestiones);
            ds.Tables.Add(dt.Copy());
            ds.Tables[0].TableName = "DTValidacionFlujo";
            resultadoValidacion = int.Parse(ds.Tables[0].Rows[0].ItemArray[0].ToString());
            if (resultadoValidacion == 2)
            {
                if (chk.Checked)
                {
                    //CargaComboUsuarioReasignado();
                    //filaGestionesInternas.BackColor = System.Drawing.Color.Aquamarine;
                    lblReasignarUsuario.Visible = true;
                    lblFechaLimite.Visible = true;
                    cmb_Usuario_Reasignado.Visible = true;
                    cmb_Usuario_Reasignado.Enabled = true;
                    txt_FECHALIMITE.Visible = true;
                    txt_FECHALIMITE.Enabled = true;
                    calFechaLimite.Enabled = true;
                    img_FechaLimite.Visible = true;

                }
                else
                {
                    //filaGestionesInternas.BackColor = System.Drawing.Color.Empty;
                    lblReasignarUsuario.Visible = false;
                    lblFechaLimite.Visible = false;
                    cmb_Usuario_Reasignado.Visible = false;
                    cmb_Usuario_Reasignado.Enabled = false;
                    txt_FECHALIMITE.Visible = false;
                    txt_FECHALIMITE.Enabled = false;
                    calFechaLimite.Enabled = false;
                    img_FechaLimite.Visible = false;
                }

            }
        }
        catch (Exception excp)
        {

            throw excp;
        }
    }




    protected void cmb_Usuario_Reasignado_SelectedIndexChanged(object sender, EventArgs e)
    {
        cambioUsuarioNuevo = true;
    }
    protected void txt_FECHALIMITE_TextChanged(object sender, EventArgs e)
    {
        cambioFechaLimite = true;
    }


    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        try
        {
            #region valida_estado
            string estado = (String)ViewState["estado"];
            if (estado == "agregar" || estado == "modificar")
            {
                return;
            }
            #endregion valida_estado
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
            metodo_agregar();
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message.ToString(), true);
        }
    }
    protected void btnModificar_Click(object sender, EventArgs e)
    {
        try
        {
            #region valida_estado
            string estado = (String)ViewState["estado"];
            if (estado == "agregar" || estado == "modificar")
            {
                return;
            }
            #endregion valida_estado
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
            metodo_modificar();
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message.ToString(), true);
        }
    }
    protected void btnConsultar_Click(object sender, EventArgs e)
    {
        try
        {
            limpiarMensaje();
            this.Master.OcultarMensaje();

            metodo_Consulta();
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message.ToString(), true);
        }
    }
    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            #region valida_estado
            string estado = (String)ViewState["estado"];
            if (estado == "agregar")
            {
                return;
            }
            #endregion valida_estado
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
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message.ToString(), true);
        }
    }
    protected void btnGrabar_Click(object sender, EventArgs e)
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
            bool continuar;
            bool.TryParse(Request.Form["hdnContinuar"], out continuar);
            if (continuar)
            {
                //VALIDACION
                if (Valida_Datos() == false)  //VALIDA
                {
                    return;
                }

                string estado = (String)ViewState["estado"];
                if (estado == "agregar")
                {
                    Grabar();  // GRABA
                }

                if (estado == "modificar")
                {
                    Modificar();  // ACTUALIZA
                }
            }
            else
            {
                MostrarMensaje(Mensaje.M_OPERACION_CANCELADA, true);
            }
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message.ToString(), true);
        }
    }
    protected void btnSalir_Click(object sender, EventArgs e)
    {
        this.Session["GS_Gestion_Cobranza_sw"] = "S";

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

        Response.Redirect(PaginaRetorno);
    }
}
