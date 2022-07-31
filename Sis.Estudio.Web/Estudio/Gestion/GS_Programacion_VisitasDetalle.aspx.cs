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

public partial class Estudio_Gestion_GS_Programacion_VisitasDetalle : BaseMantDetalle
{
    #region Declaraciones
    private const string PaginaRetorno = "GS_Programacion_Visitas.aspx";
    //public string mstrEstado;
    public string mstrId;
    //string strEmpresa;

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

            G_idopcion = G_idopcion = OpcionModulo.MantProgramacionVisitas;
            this.Master.TituloModulo = "Mantenimiento de Programación / Reprogramación de Visitas";
            #region accesos
            Accesos();
            #endregion accesos

            Botonera("consulta");
            //EnableControl(true);
            strEmpresa = (String)this.Session["cempresa"];
            InicioOperacion();

            //====================== Funcionabilidad JavaScript de botones j. Aroni E.=============================================//
            btnGrabar.Attributes.Add("onClick", "document.getElementById('hdnContinuar').value = confirm('Los datos se guardarán, ¿Desea continuar?');");
            //btnEliminar.Attributes.Add("onClick", "document.getElementById('hdnContinuar').value = confirm('¿Se anulará El registro, ¿Desea continuar?');");


            //=================================== Fin  Funcionabilidad JavaScript =================================================//
        }
        if (Request.Params["__EVENTTARGET"] == "RefrescarBusqueda")
        {
            //RefrescarBusqueda();
        }
    }
    
    protected void btnGrabar_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            limpiarMensaje();
            this.Master.OcultarMensaje();
            #region Sesion
            string cempresa = (String)this.Session["cempresa"]; 
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
    #endregion Eventos
    #region Metodos
    protected void InicioOperacion()
    {
        //****************************************************************************************
        //* Nomre       : InicioOperacion
        //* DescripcioN :
        //****************************************************************************************
        try
        {
            string str_Estado = "";
            string str_ID = "";
            string str_TIPO = "";

            if (Request["estado"] != null)
            {
                str_Estado = Request["estado"];
            }

            if (str_Estado == "n")
            {
                metodo_agregar();
            }
            else if (str_Estado == "m")
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

                txt_codigo.Text = dt.Rows[0]["IdReg_Gestion_Cobranza"].ToString();
                txt_Asesor_Comercial.Text = dt.Rows[0]["Asesores"].ToString();

                txt_FECHAVISITA.Text = dt.Rows[0]["FechaVisita_dmy"].ToString();

                cmb_horas.SelectedValue = dt.Rows[0]["FechaVisita_hh"].ToString();
                cmb_minutos.SelectedValue = dt.Rows[0]["FechaVisita_mm"].ToString();

                txt_Cliente.Text = dt.Rows[0]["RazonSocial"].ToString();
                txt_CodigoCliente.Text = dt.Rows[0]["CodigoCliente"].ToString();
                txt_Producto.Text = dt.Rows[0]["Producto"].ToString();
                txt_SubProducto.Text = dt.Rows[0]["SubProducto"].ToString();
                txt_dias_mora.Text = dt.Rows[0]["dias_mora"].ToString();
                txt_TipoAgencia.Text = dt.Rows[0]["desc_ejecutores"].ToString();

                

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
            RefrescarGrid();
            upBotonera.Update();
            upControles.Update();
        }
        catch (Exception excp)
        {
            throw excp;
        }
    }

    private void RefrescarGrid()
    {
        DataTable DT_Datos = new DataTable();

        LoGS_Gestion_Cobranza objLoGS_Gestion_Cobranza = new LoGS_Gestion_Cobranza();
        EnGS_Gestion_Cobranza objEnGS_Gestion_Cobranza = new EnGS_Gestion_Cobranza();
        List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza = new List<EnGS_Gestion_Cobranza>();


        objEnGS_Gestion_Cobranza.nEmpresa = (String)this.Session["cempresa"];
        objEnGS_Gestion_Cobranza.CodigoCliente = txt_CodigoCliente.Text.ToString();

        ListEnGS_Gestion_Cobranza.Add(objEnGS_Gestion_Cobranza);

        try
        {
            DT_Datos = objLoGS_Gestion_Cobranza.GS_Clientes_x_DireccionLista(ListEnGS_Gestion_Cobranza);
            gv.DataSource = DT_Datos;
            gv.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
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
        Cursor_Control(txt_Asesor_Comercial);

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
        Cursor_Control(txt_Asesor_Comercial);
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

        cmb_horas.Enabled = dato;
        cmb_minutos.Enabled = dato;

        /*
        txt_codigo.Enabled = dato;
        txt_Asesor_Comercial.Enabled = dato;
        txt_FECHAVISITA.Enabled = dato;
        txt_Cliente.Enabled = dato;
        txt_CodigoCliente.Enabled = dato;
        txt_Producto.Enabled = dato;
        txt_SubProducto.Enabled = dato;
        txt_dias_mora.Enabled = dato;
        txt_TipoAgencia.Enabled = dato;

        */
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

                //btnAgregar.Visible = true;
                //btnModificar.Visible = true;
                //btnEliminar.Visible = true;
                //btnSalir.Visible = true;

                upBotonera.Update();
                upControles.Update();

                break;
            case "mantenimiento":

                btnGrabar.Visible = true;
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
        txt_Asesor_Comercial.Text = String.Empty;
        //txt_FECHAVISITA.Text = String.Empty;
        txt_Cliente.Text = String.Empty;
        txt_CodigoCliente.Text = String.Empty;
        txt_Producto.Text = String.Empty;
        txt_SubProducto.Text = String.Empty;
        txt_dias_mora.Text = String.Empty;
        txt_TipoAgencia.Text = String.Empty;

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
        if (txt_FECHAVISITA.Text == "")
        {
            MostrarMensaje("Ingrese una fecha de visita.", true);
            Cursor_Control(txt_FECHAVISITA);
            return false;
        }

        if (cmb_minutos.SelectedValue.ToString() == "00" && cmb_horas.SelectedValue.ToString() == "00")
        {
            MostrarMensaje("Ingrese una hora váalida de visita.", true);
            //Cursor_Control(txt_FECHAVISITA);
            return false;
        }

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
        /*
        //****************************************************************************************
        //* Nomre       : Grabar
        //* DescripcioN :
        //****************************************************************************************
        string str_Id = "";
        string msg = "";
        string Exito = "";
        LoGS_JerarquiaA ObjLoGS_JerarquiaA = new LoGS_JerarquiaA();
        try
        {
            #region Cargar_Variables
            EnGS_JerarquiaA ObjEnGS_JerarquiaA = new EnGS_JerarquiaA();
            List<EnGS_JerarquiaA> ListEnGS_JerarquiaA = new List<EnGS_JerarquiaA>();

            ObjEnGS_JerarquiaA.desc_jerarquiaA = txt_descripcion.Text.Trim();
            ObjEnGS_JerarquiaA.CodUsuario = (String)this.Session["codusuario"];
            ObjEnGS_JerarquiaA.nempresa = (String)this.Session["cempresa"];


            ListEnGS_JerarquiaA.Add(ObjEnGS_JerarquiaA);
            #endregion Cargar_Variables
            List<EnTransaccion> RetornoT = ObjLoGS_JerarquiaA.GS_JerarquiaA_INS(ListEnGS_JerarquiaA);
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
         */ 
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

            ObjEnGS_Gestion_Cobranza.IdReg_Gestion_Cobranza = txt_codigo.Text.Trim();
            ObjEnGS_Gestion_Cobranza.FechaVisita_dmy = txt_FECHAVISITA.Text.Trim();
            ObjEnGS_Gestion_Cobranza.FechaVisita_hh = cmb_horas.SelectedValue.ToString();
            ObjEnGS_Gestion_Cobranza.FechaVisita_mm = cmb_minutos.SelectedValue.ToString();

            ObjEnGS_Gestion_Cobranza.CodUsuario = (String)this.Session["codusuario"];



            ListEnGS_Gestion_Cobranza.Add(ObjEnGS_Gestion_Cobranza);
            #endregion Cargar_Variables                       
            msg = ObjLoGS_Gestion_Cobranza.GS_Gestion_Cobranza_x_Visitas_UPD(ListEnGS_Gestion_Cobranza);
            if (msg == "exito") { Exito = FlagsPrograma.FLG_VALOREXITOSI; } else { Master.MostrarMensaje(msg, TipoMensaje.Error, msg); Exito = FlagsPrograma.FLG_VALOREXITONO; return; }
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
            metodo_Consulta();
            Master.MostrarMensaje(Mensaje.M_MODIFICO_REGISTRO_CORRECTAMENTE, TipoMensaje.Exito);
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

        LoGS_JerarquiaA ObjLoGS_JerarquiaA = new LoGS_JerarquiaA();

        try
        {
            #region Cargar_Variables
            EnGS_JerarquiaA ObjEnGS_JerarquiaA = new EnGS_JerarquiaA();
            List<EnGS_JerarquiaA> ListEnGS_JerarquiaA = new List<EnGS_JerarquiaA>();

            ObjEnGS_JerarquiaA.cod_jerarquiaA = txt_codigo.Text.Trim();
            ObjEnGS_JerarquiaA.CodUsuario = (String)this.Session["codusuario"];


            ListEnGS_JerarquiaA.Add(ObjEnGS_JerarquiaA);
            #endregion Cargar_Variables

            msg = ObjLoGS_JerarquiaA.GS_JerarquiaA_DEL(ListEnGS_JerarquiaA);

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
            Propiedades_Boton(btnGrabar, "grabar");
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
    #endregion AccesosAccion
}