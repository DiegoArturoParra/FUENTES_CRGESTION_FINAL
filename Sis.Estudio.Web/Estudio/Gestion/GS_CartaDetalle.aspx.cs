
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
using System.Text.RegularExpressions;
using System.Globalization;

public partial class Estudio_Gestion_GS_CartaDetalle : BaseMantDetalle
{
    #region Declaraciones
    private const string PaginaRetorno = "GS_Carta.aspx";
    //public string mstrEstado;
    public string mstrId;
    //string strEmpresa;
    public int lnCantMaxCaracter;
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
            
            
            G_idopcion = OpcionModulo.MantTipoGestiones;
            this.Master.TituloModulo = "Detalle de Documentos";
            #region accesos
            Accesos();
            #endregion accesos

            CargaComboTipoDocumento();

            Botonera("consulta");
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

        mxAsignarCantidadMaximaCaracteres(cmb_TipoDocumento.SelectedValue.ToString());

        /*var ctrlName = Request.Params[Page.postEventSourceID];
        var args = Request.Params[Page.postEventArgumentID];

        if (ctrlName == this.txt_descripcion.UniqueID && args == "OnKeyPress")
        {
            txt_descripcion_OnKeyPress(ctrlName, args);
        }*/

    }
    private void txt_descripcion_OnKeyPress(string ctrlName, string args)
    {
        lblContCaracter.Text = txt_descripcion.Text.Length.ToString() + "/" + lnCantMaxCaracter.ToString();
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

    protected void CargaComboTipoDocumento()
    {
        DataTable dt = new DataTable();
        LoGS_Carta objLoGS_Carta = new LoGS_Carta();
        try
        {
            EnGS_Carta objEnGS_Carta = new EnGS_Carta();
            cmb_TipoDocumento.Items.Clear();

            dt = objLoGS_Carta.GS_Carta_Tipo_Documento_Combo();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["CodTipoDocum"].ToString().Trim();
                lista.Text = dt.Rows[i]["Descrip"].ToString().Trim();
                cmb_TipoDocumento.Items.Add(lista);
            }
        }
        catch (Exception excp)
        {
            throw excp;
        }
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

            LoGS_Carta ObjLoGS_Carta = new LoGS_Carta();
            EnGS_Carta ObjEnGS_Carta = new EnGS_Carta();
            List<EnGS_Carta> ListEnGS_Carta = new List<EnGS_Carta>();

            ObjEnGS_Carta.id_carta = str_ID;
            ListEnGS_Carta.Add(ObjEnGS_Carta);
            dt =  ObjLoGS_Carta.GS_Carta_Reg(ListEnGS_Carta);
            if (dt.Rows.Count > 0)
            {
                #region CONTROLES_MANTENIMIENTO
                txt_codigo.Text = dt.Rows[0]["id_carta"].ToString();
                txt_descripcion.Text = dt.Rows[0]["Descripcion"].ToString();
                txt_pie.Text = dt.Rows[0]["Pie"].ToString();
                //cmb_Num_carta.SelectedValue = dt.Rows[0]["Num_carta"].ToString();
                cmb_TipoDocumento.SelectedValue = dt.Rows[0]["CodTipoDocum"].ToString();

                txt_nombre.Text = dt.Rows[0]["nombre"].ToString();

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
        Cursor_Control(txt_descripcion);

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
        Cursor_Control(txt_descripcion);
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
        txt_descripcion.Enabled = dato;
        txt_pie.Enabled = dato;
        //cmb_Num_carta.Enabled = dato;

        txt_nombre.Enabled = dato;

        cmb_TipoDocumento.Enabled = dato;


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
        txt_descripcion.Text = String.Empty;
        txt_pie.Text = String.Empty;
        //cmb_Num_carta.SelectedValue = "1";

        txt_nombre.Text = string.Empty;

        lbl_CODUSUARIOREGISTRA.Text = String.Empty;
        lbl_FECHAREGISTRA.Text = String.Empty;
        lbl_ESTADOREGISTRA.Text = String.Empty;

        lbl_CODUSUARIOMODIFICA.Text = String.Empty;
        lbl_FECHAMODIFICA.Text = String.Empty;
        lbl_ESTADOMODIFICA.Text = String.Empty;

        lbl_CODUSUARIOANULA.Text = String.Empty;
        lbl_FECHAANULA.Text = String.Empty;
        lbl_ESTADOANULA.Text = String.Empty;

        cmb_TipoDocumento.SelectedValue = "-1";

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
        if (txt_descripcion.Text == "")
        {
            MostrarMensaje("Ingrese una descripción.", true);
            Cursor_Control(txt_descripcion);
            return false;
        }

        if (txt_nombre.Text == "")
        {
            MostrarMensaje("Ingrese un nombre.", true);
            Cursor_Control(txt_nombre);
            return false;
        }

        if (cmb_TipoDocumento.SelectedValue == "" || cmb_TipoDocumento.SelectedValue == "-1")
        {
            MostrarMensaje("Seleccione un Tipo de Documento.", true);
            return false;
        }
        if (lnCantMaxCaracter<txt_descripcion.Text.Length)
        {
            MostrarMensaje("La cantidad de texto supera el límite permitido", true);
            txt_descripcion.Focus();
            return false;
        }
        string cadenaA = mxRemoverAcentos(txt_descripcion.Text);


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
    public static string mxRemoverAcentos(string pcCadena)
    {
        string lcCadenaNormalizada = pcCadena.Normalize(NormalizationForm.FormD);
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < lcCadenaNormalizada.Length; i++)
        {
            UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(lcCadenaNormalizada[i]);
            if (uc != UnicodeCategory.NonSpacingMark)
            {
                sb.Append(lcCadenaNormalizada[i]);
            }
        }
        return (sb.ToString().Normalize(NormalizationForm.FormC));
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
        LoGS_Carta ObjLoGS_Carta = new LoGS_Carta();
        try
        {
            #region Cargar_Variables
            EnGS_Carta ObjEnGS_Carta = new EnGS_Carta();
            List<EnGS_Carta> ListEnGS_Carta = new List<EnGS_Carta>();

            ObjEnGS_Carta.Descripcion = txt_descripcion.Text.Trim();
            ObjEnGS_Carta.Pie = txt_pie.Text.Trim();
            /*Modificado 04/10/16*/
            //ObjEnGS_Carta.id_carta = txt_codigo.ToString();
            //ObjEnGS_Carta.Num_carta = cmb_Num_carta.SelectedValue.ToString();
            /**/
            ObjEnGS_Carta.nEmpresa = (String)this.Session["cempresa"];
            ObjEnGS_Carta.CodUsuario = (String)this.Session["codusuario"];

            ObjEnGS_Carta.nombre = txt_nombre.Text.Trim();

            ObjEnGS_Carta.CodTipoDocum = cmb_TipoDocumento.SelectedValue.ToString();


            ListEnGS_Carta.Add(ObjEnGS_Carta);
            #endregion Cargar_Variables
            List<EnTransaccion> RetornoT = ObjLoGS_Carta.GS_Carta_INS(ListEnGS_Carta);
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
        LoGS_Carta ObjLoGS_Carta = new LoGS_Carta();
        try
        {

            #region Cargar_Variables
            EnGS_Carta ObjEnGS_Carta = new EnGS_Carta();
            List<EnGS_Carta> ListEnGS_Carta = new List<EnGS_Carta>();

            ObjEnGS_Carta.id_carta = txt_codigo.Text.Trim();
            ObjEnGS_Carta.Descripcion = txt_descripcion.Text.Trim();
            ObjEnGS_Carta.Pie = txt_pie.Text.Trim();
            //ObjEnGS_Carta.Num_carta = cmb_Num_carta.SelectedValue.ToString();
            ObjEnGS_Carta.nEmpresa = (String)this.Session["cempresa"];
            ObjEnGS_Carta.CodUsuario = (String)this.Session["codusuario"];

            ObjEnGS_Carta.nombre = txt_nombre.Text.Trim();

            ObjEnGS_Carta.CodTipoDocum = cmb_TipoDocumento.SelectedValue.ToString();


            ListEnGS_Carta.Add(ObjEnGS_Carta);
            #endregion Cargar_Variables                       
            msg = ObjLoGS_Carta.GS_Carta_UPD(ListEnGS_Carta);
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

        LoGS_Carta ObjLoGS_Carta = new LoGS_Carta();

        try
        {
            #region Cargar_Variables
            EnGS_Carta ObjEnGS_Carta = new EnGS_Carta();
            List<EnGS_Carta> ListEnGS_Carta = new List<EnGS_Carta>();

            ObjEnGS_Carta.id_carta = txt_codigo.Text.Trim();
            ObjEnGS_Carta.CodUsuario = (String)this.Session["codusuario"];


            ListEnGS_Carta.Add(ObjEnGS_Carta);
            #endregion Cargar_Variables

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
            msg = Mensaje.M_ANULO_REGISTRO_CORRECTAMENTE;
            MostrarMensaje(msg, false);
            upControles.Update();
            PostAnular(msg, PaginaRetorno);
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
    protected void cmb_TipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.mxAsignarCantidadMaximaCaracteres(cmb_TipoDocumento.SelectedValue.ToString());
    }

    public void mxAsignarCantidadMaximaCaracteres(string pcTipoDocumento)
    {
        switch (pcTipoDocumento)
        {
            case TipoDocumento.C_TIPDOC_CARTA:
                lnCantMaxCaracter = CantMaxCaracter.C_MAXCAR_CARTA;
                break;
            case TipoDocumento.C_TIPDOC_IVR:
                lnCantMaxCaracter = CantMaxCaracter.C_MAXCAR_IVR;
                break;
            case TipoDocumento.C_TIPDOC_CORREO:
                lnCantMaxCaracter = CantMaxCaracter.C_MAXCAR_CORREO;
                break;
            case TipoDocumento.C_TIPDOC_SMS:
                lnCantMaxCaracter = CantMaxCaracter.C_MAXCAR_SMS;
                break;
            case TipoDocumento.C_TIPDOC_CARTA_CAMPO:
                lnCantMaxCaracter = CantMaxCaracter.C_MAXCAR_CARTA_CAMPO;
                break;
            case TipoDocumento.C_TIPDOC_CARTA_AVAL:
                lnCantMaxCaracter = CantMaxCaracter.C_MAXCAR_CARTA_AVAL;
                break;
            case TipoDocumento.C_TIPDOC_SMS_AVAL:
                lnCantMaxCaracter = CantMaxCaracter.C_MAXCAR_SMS_AVAL;
                break;
            case TipoDocumento.C_TIPDOC_IVR_AVAL:
                lnCantMaxCaracter = CantMaxCaracter.C_MAXCAR_IVR_AVAL;
                break;
            case TipoDocumento.C_TIPDOC_CORREO_AVAL:
                lnCantMaxCaracter = CantMaxCaracter.C_MAXCAR_CORREO_AVAL;
                break;
            case TipoDocumento.C_TIPDOC_WHATSAPP:
                lnCantMaxCaracter = CantMaxCaracter.C_MAXCAR_WHATSAPP;
                break;
            case TipoDocumento.C_TIPDOC_WHATSAPP_AVAL:
                lnCantMaxCaracter = CantMaxCaracter.C_MAXCAR_WHATSAPP_AVAL;
                break;
        }
    }
}