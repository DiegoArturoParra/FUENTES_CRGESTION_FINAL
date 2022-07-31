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
using Sis.Estudio.Logic.MSSQL.Seguridad;
using IABaseWeb;

public partial class Mantenimientos_Seguridad_MantPerfilDetalle : BaseMantDetalle
{
    #region Declaraciones
    public string mstrEstado;
    public string mstrId;
    string strEmpresa;
    private const string PaginaRetorno = "MantPerfil.aspx";

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
            G_idopcion = OpcionModulo.MantPerfil;
            this.Master.TituloModulo = "Detalle de Perfil";
            #region accesos
            Accesos();
            #endregion accesos

            Botonera("consulta");
            Cargar_Modulos();
            EnableControl(false);
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
    protected void btnSalir_Click(object sender, ImageClickEventArgs e)
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
            string str_idmodulo = "?idmodulo=" + Convert.ToString(cmb_MODULO.SelectedValue.ToString());
            Response.Redirect(PaginaRetorno + str_idmodulo);
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message.ToString(), true);
        }
    }

    protected void lkb_Perfil_Click(object sender, EventArgs e)
    {
        try
        {
            if (txt_IDPERFIL.Text.Trim() != "")
            {
                #region ValidaEstado
                string str_paramestado = "";
                string estado = (String)ViewState[Mant_ViewState.Estado];
                if (estado == Mant_Estado.Consulta)
                {
                    str_paramestado = "c";
                }
                else if (estado == Mant_Estado.Modifica)
                {
                    str_paramestado = "m";
                }
                #endregion ValidaEstado

                string str_idperfil = "?idperfil=" + txt_IDPERFIL.Text.Trim();
                string str_idmodulo = "&idmodulo=" + cmb_MODULO.SelectedValue.ToString();
                string str_desmodulo = "&desmodulo=" + cmb_MODULO.SelectedItem.ToString();
                string str_nombre = "&nombre=" + txt_NOMBRE.Text;
                string str_estadon = "&estado=" + str_paramestado;

                Response.Redirect("MantPerfilOpcion.aspx" + str_idperfil + str_idmodulo + str_desmodulo + str_nombre + str_estadon);
            }
            else
            {
                MostrarMensaje("Debe Guardar el Registro.", true);
            }
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message.ToString(), true);
        }
    }

    #endregion Eventos
    #region Metodos
    protected void InicioOperacion()
    {
        try
        {
            string str_Estado = "";
            string str_IDPERFIL = "";
            string str_TIPO = "";
            string str_idModulo = "";

            if (Request["estado"] != null)
            {
                str_Estado = Request["estado"];
            }

            if (str_Estado == "n")
            {
                #region idmodulo
                if (Request["idmodulo"] != null)
                {
                    str_idModulo = Request["idmodulo"];
                    if (Util.fap_EsNumerico(str_idModulo))
                    {
                        cmb_MODULO.SelectedValue = str_idModulo;
                    }
                }
                #endregion idmodulo
                metodo_agregar();
            }
            else if (str_Estado == "m")
            {
                str_IDPERFIL = Request["idperfil"];
                str_TIPO = "1";
                mstrId = str_IDPERFIL;
                ViewState.Add("id", mstrId);
                MostrarDatos(str_TIPO, str_IDPERFIL);
                metodo_modificar();
            }
            else if (str_Estado == "c")
            {
                str_IDPERFIL = Request["idperfil"];
                mstrId = str_IDPERFIL;
                ViewState.Add("id", mstrId);
                metodo_Consulta();
            }
        }
        catch (Exception excp)
        {
            MostrarMensaje(excp.Message.ToString(), true);
        }
    }
    protected void metodo_Consulta()
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
            lkb_Perfil.Enabled = true;
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message.ToString(), true);
        }
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
        lkb_Perfil.Enabled = false;
        Cursor_Control(txt_NOMBRE);

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
        lkb_Perfil.Enabled = true;
        Cursor_Control(txt_NOMBRE);
    }
    #endregion Metodos
    #region Procedimientos
    protected void Cargar_Modulos()
    {
        try
        {            
            LoModulo objLoModulo = new LoModulo();                       
            List<EnModulo> ListEnModulo = new List<EnModulo> ();
            EnModulo objEnModulo = new EnModulo();
           
            cmb_MODULO.Items.Clear();                       
            objEnModulo.CEmpresa = (String)this.Session["cempresa"];
            ListEnModulo.Add(objEnModulo);            
            DataTable dt = new DataTable();
            dt = objLoModulo.Lista_TodosLosModulos(ListEnModulo);                       
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
    protected void MostrarDatos(string str_TIPO, string str_IDPERFIL)
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


            LoPerfil objLoPerfil = new LoPerfil();
            List<EnPerfil> ListEnPerfil = new List<EnPerfil>();
            EnPerfil objEnPerfil = new EnPerfil();

            objEnPerfil.CEmpresa = (String)this.Session["cempresa"];
            objEnPerfil.IdPerfil = str_IDPERFIL;

            ListEnPerfil.Add(objEnPerfil);
            dt = objLoPerfil.CargaDatosPerfil(str_TIPO, ListEnPerfil);
                      
            if (dt.Rows.Count > 0)
            {
                //========= CONTROLES DE MANTENIMIENTO j. Aroni E.=========//
                txt_IDPERFIL.Text = dt.Rows[0]["IDPERFIL"].ToString();
                cmb_MODULO.SelectedValue = dt.Rows[0]["idModulo"].ToString();
                txt_NOMBRE.Text = dt.Rows[0]["NOMBRE"].ToString();
                txt_DESCRIPCION.Text = dt.Rows[0]["DESCRIPCION"].ToString();
                //=========================================================//

                //========= CONTROLES INFORMATIVOS j. Aroni E.=============//
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
                //=========================================================//

                mstrId = txt_IDPERFIL.Text.Trim();
                ViewState.Add("id", mstrId);

            }
            upBotonera.Update();
            upControles.Update();
        }
        catch (Exception ex)
        {
            throw ex;
            
        }
    }
    private void EnableControl(bool dato)
    {
        //********************************************************************************
        //**  EnableControl  : Cambia el estado de los controles.
        //**                   Bloquea desbloquea controles :
        //********************************************************************************
        //==== controles de ingreso ====//        
        //txT.Enabled = dato;
        txt_IDPERFIL.Enabled = dato;
        cmb_MODULO.Enabled = dato;
        txt_NOMBRE.Enabled = dato;
        txt_DESCRIPCION.Enabled = dato;

        //==== botones ====//   
        //panelbtnBuscaBanco.Visible = dato;	    //Los controles panel contienen un control boton html por lo tanto se usa la propiedad visible

        upControles.Update();
    }
    protected void Botonera(string strEstado)
    {
        //****************************************************************************************
        //* Nomre       : Botonera
        //* DescripcioN : establece estado de botones consulta - Manteniento
        //****************************************************************************************
        switch (strEstado)
        {
            case "consulta":
                btnGrabar.Visible = false;
                //  btnCancelar.Visible = false;

                //  btnAgregar.Visible = true;
                //  btnModificar.Visible = true;
                //  btnEliminar.Visible = true;
                //  btnSalir.Visible = true;

                upBotonera.Update();
                upControles.Update();

                break;
            case "mantenimiento":

                btnGrabar.Visible = true;
                // btnCancelar.Visible = true;

                // btnAgregar.Visible = false;
                // btnModificar.Visible = false;
                // btnEliminar.Visible = false;
                // btnSalir.Visible = false;

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
        txt_IDPERFIL.Text = String.Empty;
        txt_NOMBRE.Text = String.Empty;
        txt_DESCRIPCION.Text = String.Empty;


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
        if (txt_NOMBRE.Text == "")
        {
            MostrarMensaje("Ingrese Nombre.", true);
            Cursor_Control(txt_NOMBRE);
            return false;
        }

        if (txt_DESCRIPCION.Text == "")
        {
            MostrarMensaje("Ingrese Descripcion.", true);
            Cursor_Control(txt_DESCRIPCION);
            return false;
        }
        #endregion para_Todo
        #region para_Modificar
        string estado = (String)ViewState["estado"];
        if (estado == "modificar")
        {
            if (txt_IDPERFIL.Text.Length < 1)
            {
                MostrarMensaje("codigo perfil no Válido.", true);
                return false;
            }
        }
        #endregion para_Modificar
        return true;
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

        LoPerfil objLoPerfil = new LoPerfil();        
        try
        {           
            #region Cargar_Variables
            List<EnPerfil> ListEnPerfil = new List<EnPerfil>();
            EnPerfil objEnPerfil = new EnPerfil();
                                         
            objEnPerfil.CEmpresa = (String)this.Session["cempresa"];
            objEnPerfil.IdModulo = cmb_MODULO.SelectedValue.ToString();
            objEnPerfil.Nombre =  txt_NOMBRE.Text.Trim();
            objEnPerfil.Descripcion = txt_DESCRIPCION.Text.Trim();
            objEnPerfil.IdPerfil = txt_IDPERFIL.Text;
            objEnPerfil.CodUsuario = (String)this.Session["codusuario"];

            ListEnPerfil.Add(objEnPerfil);
               
            #endregion Cargar_Variables

            List<EnTransaccion> RetornoT = objLoPerfil.Insertar_Perfil(ListEnPerfil);

            msg = RetornoT[0].MENSAJE.ToString();
            str_Id = RetornoT[0].ID.ToString();

            if (msg == "") { Exito = FlagsPrograma.FLG_VALOREXITOSI; } else { Master.MostrarMensaje(msg, TipoMensaje.Error, msg); Exito = FlagsPrograma.FLG_VALOREXITONO; return; }
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
            MostrarMensaje("Se Registró Correctamente.", false);
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
        LoPerfil objLoPerfil = new LoPerfil();
        try
        {
           
            #region Cargar_Variables
            List<EnPerfil> ListEnPerfil = new List<EnPerfil>();
            EnPerfil objEnPerfil = new EnPerfil();

            objEnPerfil.CEmpresa = (String)this.Session["cempresa"];
            objEnPerfil.IdModulo = cmb_MODULO.SelectedValue.ToString();
            objEnPerfil.Nombre = txt_NOMBRE.Text.Trim();
            objEnPerfil.Descripcion = txt_DESCRIPCION.Text.Trim();
            objEnPerfil.IdPerfil = txt_IDPERFIL.Text;
            objEnPerfil.CodUsuario = (String)this.Session["codusuario"];

            ListEnPerfil.Add(objEnPerfil);

            #endregion Cargar_Variables
            msg = objLoPerfil.Modifica_Perfil(ListEnPerfil);


            if (msg == "") { Exito = FlagsPrograma.FLG_VALOREXITOSI; } else { Master.MostrarMensaje(msg, TipoMensaje.Error, msg); Exito = FlagsPrograma.FLG_VALOREXITONO; return; }
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
            metodo_Consulta();
            MostrarMensaje(Mensaje.M_MODIFICO_REGISTRO_CORRECTAMENTE, false);
            upControles.Update();
        }
    }
    private void Anular()
    {
        //****************************************************************************************
        //* Nomre       : Modificar()
        //* DescripcioN :
        //****************************************************************************************

        string msg = "";
        string Exito = "";
        LoPerfil objLoPerfil = new LoPerfil();       
        try
        {
            #region carga_variables

            List<EnPerfil> ListEnPerfil = new List<EnPerfil>();
            EnPerfil objEnPerfil = new EnPerfil();
            objEnPerfil.IdPerfil = txt_IDPERFIL.Text.Trim();
            objEnPerfil.CEmpresa = (String)this.Session["cempresa"];
            objEnPerfil.CodUsuario = (String)this.Session["codusuario"];
            ListEnPerfil.Add(objEnPerfil);
            #endregion carga_variables
            msg = objLoPerfil.Anula_Perfil(ListEnPerfil);
            if (msg == "") { Exito = FlagsPrograma.FLG_VALOREXITOSI; } else { Master.MostrarMensaje(msg, TipoMensaje.Error, msg); Exito = FlagsPrograma.FLG_VALOREXITONO; return; }

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

            string str_idmodulo = "?idmodulo=" + Convert.ToString(cmb_MODULO.SelectedValue.ToString());            
            PostAnular(msg, PaginaRetorno + str_idmodulo);
        }
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
    protected void txt_NOMBRE_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txt_IDPERFIL_TextChanged(object sender, EventArgs e)
    {

    }
}