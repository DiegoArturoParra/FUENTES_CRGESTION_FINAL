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

public partial class Estudio_Gestion_GS_JerarquiaDDetalle : BaseMantDetalle
{
    #region Declaraciones
    private const string PaginaRetorno = "GS_JerarquiaD.aspx";
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

            G_idopcion = G_idopcion = OpcionModulo.MantJerarquiaD;
            this.Master.TituloModulo = "Mantenimiento de Detalle de Jerarquia Nivel D";
            #region accesos
            Accesos();
            #endregion accesos

            CargaComboJerarquiaA();
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
    #endregion Eventos
    #region Metodos

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

            LoGS_JerarquiaD ObjLoGS_JerarquiaD = new LoGS_JerarquiaD();
            EnGS_JerarquiaD ObjEnGS_JerarquiaD = new EnGS_JerarquiaD();
            List<EnGS_JerarquiaD> ListEnGS_JerarquiaD = new List<EnGS_JerarquiaD>();

            ObjEnGS_JerarquiaD.cod_jerarquiaD = str_ID;
            ListEnGS_JerarquiaD.Add(ObjEnGS_JerarquiaD);
            dt = ObjLoGS_JerarquiaD.GS_JerarquiaD_Reg(ListEnGS_JerarquiaD);
            if (dt.Rows.Count > 0)
            {
                #region CONTROLES_MANTENIMIENTO

                CargaComboJerarquiaB_consulta(dt.Rows[0]["cod_jerarquiaA"].ToString());
                CargaComboJerarquiaC_consulta(dt.Rows[0]["cod_jerarquiaB"].ToString());

                txt_codigo.Text = dt.Rows[0]["cod_jerarquiaD"].ToString();
                cmb_JerarquiaA.SelectedValue = dt.Rows[0]["cod_jerarquiaA"].ToString();
                cmb_JerarquiaB.SelectedValue = dt.Rows[0]["cod_jerarquiaB"].ToString();
                cmb_JerarquiaC.SelectedValue = dt.Rows[0]["cod_jerarquiaC"].ToString();

                txt_descripcion.Text = dt.Rows[0]["desc_jerarquiaD"].ToString();
                
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
        cmb_JerarquiaA.Enabled = dato;
        cmb_JerarquiaB.Enabled = dato;
        cmb_JerarquiaC.Enabled = dato;


        txt_descripcion.Enabled = dato;


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

        cmb_JerarquiaA.SelectedValue = "0";
        cmb_JerarquiaB.SelectedValue = "0";
        cmb_JerarquiaC.SelectedValue = "0";

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
        if (txt_descripcion.Text == "")
        {
            MostrarMensaje("Ingrese una descripción.", true);
            Cursor_Control(txt_descripcion);
            return false;
        }


        if (cmb_JerarquiaA.SelectedValue == "" || cmb_JerarquiaA.SelectedValue == "0")
        {
            MostrarMensaje("Ingrese una Jerarquia Nivel A.", true);
            return false;
        }

        if (cmb_JerarquiaB.SelectedValue == "" || cmb_JerarquiaB.SelectedValue == "0")
        {
            MostrarMensaje("Ingrese una Jerarquia Nivel B.", true);
            return false;
        }

        if (cmb_JerarquiaC.SelectedValue == "" || cmb_JerarquiaC.SelectedValue == "0")
        {
            MostrarMensaje("Ingrese una Jerarquia Nivel C.", true);
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
        //****************************************************************************************
        //* Nomre       : Grabar
        //* DescripcioN :
        //****************************************************************************************
        string str_Id = "";
        string msg = "";
        string Exito = "";
        LoGS_JerarquiaD ObjLoGS_JerarquiaD = new LoGS_JerarquiaD();
        try
        {
            #region Cargar_Variables
            EnGS_JerarquiaD ObjEnGS_JerarquiaD = new EnGS_JerarquiaD();
            List<EnGS_JerarquiaD> ListEnGS_JerarquiaD = new List<EnGS_JerarquiaD>();

            ObjEnGS_JerarquiaD.cod_jerarquiaA = cmb_JerarquiaA.SelectedValue.ToString();
            ObjEnGS_JerarquiaD.cod_jerarquiaB = cmb_JerarquiaB.SelectedValue.ToString();
            ObjEnGS_JerarquiaD.cod_jerarquiaC = cmb_JerarquiaC.SelectedValue.ToString();

            ObjEnGS_JerarquiaD.desc_jerarquiaD = txt_descripcion.Text.Trim();
            ObjEnGS_JerarquiaD.CodUsuario = (String)this.Session["codusuario"];
            ObjEnGS_JerarquiaD.nempresa = (String)this.Session["cempresa"];



            ListEnGS_JerarquiaD.Add(ObjEnGS_JerarquiaD);
            #endregion Cargar_Variables
            List<EnTransaccion> RetornoT = ObjLoGS_JerarquiaD.GS_JerarquiaD_INS(ListEnGS_JerarquiaD);
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
        LoGS_JerarquiaD ObjLoGS_JerarquiaD = new LoGS_JerarquiaD();
        try
        {

            #region Cargar_Variables
            EnGS_JerarquiaD ObjEnGS_JerarquiaD = new EnGS_JerarquiaD();
            List<EnGS_JerarquiaD> ListEnGS_JerarquiaD = new List<EnGS_JerarquiaD>();

            ObjEnGS_JerarquiaD.cod_jerarquiaD = txt_codigo.Text.Trim();
            ObjEnGS_JerarquiaD.cod_jerarquiaA = cmb_JerarquiaA.SelectedValue.ToString();
            ObjEnGS_JerarquiaD.cod_jerarquiaB = cmb_JerarquiaB.SelectedValue.ToString();
            ObjEnGS_JerarquiaD.cod_jerarquiaC = cmb_JerarquiaC.SelectedValue.ToString();

            ObjEnGS_JerarquiaD.desc_jerarquiaD = txt_descripcion.Text.Trim();
            ObjEnGS_JerarquiaD.CodUsuario = (String)this.Session["codusuario"];



            ListEnGS_JerarquiaD.Add(ObjEnGS_JerarquiaD);
            #endregion Cargar_Variables                       
            msg = ObjLoGS_JerarquiaD.GS_JerarquiaD_UPD(ListEnGS_JerarquiaD);
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

        LoGS_JerarquiaD ObjLoGS_JerarquiaD = new LoGS_JerarquiaD();

        try
        {
            #region Cargar_Variables
            EnGS_JerarquiaD ObjEnGS_JerarquiaD = new EnGS_JerarquiaD();
            List<EnGS_JerarquiaD> ListEnGS_JerarquiaD = new List<EnGS_JerarquiaD>();

            ObjEnGS_JerarquiaD.cod_jerarquiaD = txt_codigo.Text.Trim();
            ObjEnGS_JerarquiaD.CodUsuario = (String)this.Session["codusuario"];


            ListEnGS_JerarquiaD.Add(ObjEnGS_JerarquiaD);
            #endregion Cargar_Variables

            msg = ObjLoGS_JerarquiaD.GS_JerarquiaD_DEL(ListEnGS_JerarquiaD);

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
    protected void cmb_JerarquiaA_SelectedIndexChanged(object sender, EventArgs e)
    {
        cmb_JerarquiaC.Items.Clear();
        CargaComboJerarquiaB();
    }
    protected void cmb_JerarquiaB_SelectedIndexChanged(object sender, EventArgs e)
    {
        CargaComboJerarquiaC();
    }
}
