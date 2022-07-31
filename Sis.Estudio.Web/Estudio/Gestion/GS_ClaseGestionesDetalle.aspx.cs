﻿using System;
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

public partial class Estudio_Gestion_GS_ClaseGestionesDetalle : BaseMantDetalle
{
    #region Declaraciones
    private const string PaginaRetorno = "GS_ClaseGestiones.aspx";
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

            G_idopcion = OpcionModulo.MantClaseGestiones;
            this.Master.TituloModulo = "Detalle de Resultado de Clasificación del Action Plan";
            #region accesos
            Accesos();
            #endregion accesos

            cargagrillavacia();
            CargaComboTipoGestion();
            Botonera("consulta");
            EnableControl(false);
            strEmpresa = (String)this.Session["cempresa"];

            CargaComboResultado();


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

    protected void CargaComboResultado()
    {
        DataTable dt = new DataTable();
        LoGS_ClaseGestiones objLoGS_ClaseGestiones = new LoGS_ClaseGestiones();
        try
        {
            EnGS_ClaseGestiones objEnGS_ClaseGestiones = new EnGS_ClaseGestiones();
            cmb_Resultado.Items.Clear();

            dt = objLoGS_ClaseGestiones.GS_Resultado_Combo();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["CodResultado"].ToString().Trim();
                lista.Text = dt.Rows[i]["Descripcion"].ToString().Trim();
                cmb_Resultado.Items.Add(lista);
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
            
            
            LoGS_ClaseGestiones ObjLoGS_ClaseGestiones = new LoGS_ClaseGestiones();
            EnGS_ClaseGestiones ObjEnGS_ClaseGestiones = new EnGS_ClaseGestiones();
            List<EnGS_ClaseGestiones> ListEnGS_ClaseGestiones = new List<EnGS_ClaseGestiones>();

            ObjEnGS_ClaseGestiones.CodClaseGestion = str_ID;
            ListEnGS_ClaseGestiones.Add(ObjEnGS_ClaseGestiones);
            dt = ObjLoGS_ClaseGestiones.GS_ClaseGestiones_Reg(ListEnGS_ClaseGestiones);
            if (dt.Rows.Count > 0)
            {
                #region CONTROLES_MANTENIMIENTO
                txt_codigo.Text = dt.Rows[0]["CodClaseGestion"].ToString();
                cmb_CodTipoGestion.SelectedValue = dt.Rows[0]["CodTipoGestion"].ToString();
                txt_descripcion.Text = dt.Rows[0]["descripcion"].ToString();
                CargaComboEjecutado_consulta(dt.Rows[0]["CodTipoGestion"].ToString());
                cmb_CodEjecutado.SelectedValue = dt.Rows[0]["CodEjecutado"].ToString();

                cmb_Resultado.SelectedValue = dt.Rows[0]["CodResultado"].ToString();

                cargagrilla();

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
        DataTable dt = new DataTable();
        try
        {
            #region Carga_Variables
            LoGS_ClaseGestionesxTipoGestion objLoGS_ClaseGestionesxTipoGestion = new LoGS_ClaseGestionesxTipoGestion();
            EnGS_ClaseGestionesxTipoGestion objEnGS_ClaseGestionesxTipoGestion = new EnGS_ClaseGestionesxTipoGestion();
            List<EnGS_ClaseGestionesxTipoGestion> ListEnGS_ClaseGestionesxTipoGestion = new List<EnGS_ClaseGestionesxTipoGestion>();

            objEnGS_ClaseGestionesxTipoGestion.CodClaseGestion = txt_codigo.Text;

            ListEnGS_ClaseGestionesxTipoGestion.Add(objEnGS_ClaseGestionesxTipoGestion);
            #endregion Carga_Variables

            dt = objLoGS_ClaseGestionesxTipoGestion.GS_ClaseGestionesxTipoGestion_Lista(ListEnGS_ClaseGestionesxTipoGestion);

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
    }

    protected void cargagrillavacia()
    {
        DataTable dt = new DataTable();
        try
        {
            #region Carga_Variables
            LoGS_ClaseGestionesxTipoGestion objLoGS_ClaseGestionesxTipoGestion = new LoGS_ClaseGestionesxTipoGestion();
            EnGS_ClaseGestionesxTipoGestion objEnGS_ClaseGestionesxTipoGestion = new EnGS_ClaseGestionesxTipoGestion();
            List<EnGS_ClaseGestionesxTipoGestion> ListEnGS_ClaseGestionesxTipoGestion = new List<EnGS_ClaseGestionesxTipoGestion>();

            objEnGS_ClaseGestionesxTipoGestion.CodClaseGestion = "0";

            ListEnGS_ClaseGestionesxTipoGestion.Add(objEnGS_ClaseGestionesxTipoGestion);
            #endregion Carga_Variables

            dt = objLoGS_ClaseGestionesxTipoGestion.GS_ClaseGestionesxTipoGestion_Lista(ListEnGS_ClaseGestionesxTipoGestion);

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
        cmb_CodTipoGestion.Enabled = dato;
        cmb_CodEjecutado.Enabled = dato;
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

        cmb_CodTipoGestion.SelectedValue = "-1";
        

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
        /*
        if (txt_descripcion.Text == "")
        {
            MostrarMensaje("Ingrese una descripción.", true);
            Cursor_Control(txt_descripcion);
            return false;
        }
        */
        if (cmb_CodTipoGestion.SelectedValue == "" || cmb_CodTipoGestion.SelectedValue == "-1")
        {
            MostrarMensaje("Seleccione un Tipo de Gestion.", true);
            return false;
        }

        if (cmb_CodEjecutado.SelectedValue == "")
        {
            MostrarMensaje("Seleccione un Ejecutado.", true);
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
        LoGS_ClaseGestiones ObjLoGS_ClaseGestiones = new LoGS_ClaseGestiones();
        try
        {
            #region Cargar_Variables
            EnGS_ClaseGestiones ObjEnGS_ClaseGestiones = new EnGS_ClaseGestiones();
            List<EnGS_ClaseGestiones> ListEnGS_ClaseGestiones = new List<EnGS_ClaseGestiones>();

            //ObjEnGS_ClaseGestiones.Descripcion = txt_descripcion.Text.Trim();
            ObjEnGS_ClaseGestiones.Descripcion = cmb_Resultado.SelectedItem.ToString();
            ObjEnGS_ClaseGestiones.CodTipoGestion = cmb_CodTipoGestion.SelectedValue.ToString();
            ObjEnGS_ClaseGestiones.CodUsuario = (String)this.Session["codusuario"];
            ObjEnGS_ClaseGestiones.CodEjecutado = cmb_CodEjecutado.SelectedValue.ToString();
            ObjEnGS_ClaseGestiones.CodResultado = cmb_Resultado.SelectedValue.ToString();

            ListEnGS_ClaseGestiones.Add(ObjEnGS_ClaseGestiones);
            #endregion Cargar_Variables
            List<EnTransaccion> RetornoT = ObjLoGS_ClaseGestiones.GS_ClaseGestiones_INS(ListEnGS_ClaseGestiones);
            msg = RetornoT[0].MENSAJE.ToString();
            str_Id = RetornoT[0].ID.ToString();


            // graba grilla //
            LoGS_ClaseGestionesxTipoGestion ObjLoGS_ClaseGestionesxTipoGestion = new LoGS_ClaseGestionesxTipoGestion();
            EnGS_ClaseGestionesxTipoGestion ObjEnGS_ClaseGestionesxTipoGestion = new EnGS_ClaseGestionesxTipoGestion();
            List<EnGS_ClaseGestionesxTipoGestion> ListEnGS_ClaseGestionesxTipoGestion = new List<EnGS_ClaseGestionesxTipoGestion>();

            // borra grilla //
            /*
            ObjEnGS_ClaseGestionesxEjecutado.CodClaseGestion = txt_codigo.Text.Trim();
            ListEnGS_ClaseGestionesxEjecutado.Add(ObjEnGS_ClaseGestionesxEjecutado);
            msg = ObjLoGS_ClaseGestionesxEjecutado.GS_ClaseGestionesxEjecutado_DEL(ListEnGS_ClaseGestionesxEjecutado);
             */
            //////////////////


            // agrega nueva combinacion //
            foreach (GridViewRow row in gv.Rows)
            {

                CheckBox check = row.FindControl("chkPermiso") as CheckBox;

                if (check.Checked)
                {

                    ObjEnGS_ClaseGestionesxTipoGestion.CodClaseGestion = str_Id;
                    ObjEnGS_ClaseGestionesxTipoGestion.CodTipoGestion = row.Cells[0].Text.ToString();

                    ListEnGS_ClaseGestionesxTipoGestion.Add(ObjEnGS_ClaseGestionesxTipoGestion);
                    List<EnTransaccion> RetornoT2 = ObjLoGS_ClaseGestionesxTipoGestion.GS_ClaseGestionesxTipoGestion_INS(ListEnGS_ClaseGestionesxTipoGestion);

                }


            }
            ///////////////////////////////

            /////////////////



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
        LoGS_ClaseGestiones ObjLoGS_ClaseGestiones = new LoGS_ClaseGestiones();
        try
        {

            #region Cargar_Variables
            EnGS_ClaseGestiones ObjEnGS_ClaseGestiones = new EnGS_ClaseGestiones();
            List<EnGS_ClaseGestiones> ListEnGS_ClaseGestiones = new List<EnGS_ClaseGestiones>();

            ObjEnGS_ClaseGestiones.CodClaseGestion = txt_codigo.Text.Trim();
            ObjEnGS_ClaseGestiones.Descripcion = cmb_Resultado.SelectedItem.ToString();
            //ObjEnGS_ClaseGestiones.Descripcion = txt_descripcion.Text.Trim();
            ObjEnGS_ClaseGestiones.CodTipoGestion = cmb_CodTipoGestion.SelectedValue.ToString();
            ObjEnGS_ClaseGestiones.CodUsuario = (String)this.Session["codusuario"];
            ObjEnGS_ClaseGestiones.CodEjecutado = cmb_CodEjecutado.SelectedValue.ToString();
            ObjEnGS_ClaseGestiones.CodResultado = cmb_Resultado.SelectedValue.ToString();

            ListEnGS_ClaseGestiones.Add(ObjEnGS_ClaseGestiones);
            #endregion Cargar_Variables                       
            msg = ObjLoGS_ClaseGestiones.GS_ClaseGestiones_UPD(ListEnGS_ClaseGestiones);


            // graba grilla //
            LoGS_ClaseGestionesxTipoGestion ObjLoGS_ClaseGestionesxTipoGestion = new LoGS_ClaseGestionesxTipoGestion();
            EnGS_ClaseGestionesxTipoGestion ObjEnGS_ClaseGestionesxTipoGestion = new EnGS_ClaseGestionesxTipoGestion();
            List<EnGS_ClaseGestionesxTipoGestion> ListEnGS_ClaseGestionesxTipoGestion = new List<EnGS_ClaseGestionesxTipoGestion>();

            // borra grilla //

            ObjEnGS_ClaseGestionesxTipoGestion.CodClaseGestion = txt_codigo.Text.Trim();
            ListEnGS_ClaseGestionesxTipoGestion.Add(ObjEnGS_ClaseGestionesxTipoGestion);
            msg = ObjLoGS_ClaseGestionesxTipoGestion.GS_ClaseGestionesxTipoGestion_DEL(ListEnGS_ClaseGestionesxTipoGestion);

            //////////////////


            // agrega nueva combinacion //
            foreach (GridViewRow row in gv.Rows)
            {

                CheckBox check = row.FindControl("chkPermiso") as CheckBox;

                if (check.Checked)
                {

                    ObjEnGS_ClaseGestionesxTipoGestion.CodClaseGestion = txt_codigo.Text.Trim();
                    ObjEnGS_ClaseGestionesxTipoGestion.CodTipoGestion = row.Cells[0].Text.ToString();

                    ListEnGS_ClaseGestionesxTipoGestion.Add(ObjEnGS_ClaseGestionesxTipoGestion);
                    List<EnTransaccion> RetornoT2 = ObjLoGS_ClaseGestionesxTipoGestion.GS_ClaseGestionesxTipoGestion_INS(ListEnGS_ClaseGestionesxTipoGestion);

                }


            }
            ///////////////////////////////

            /////////////////


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

        LoGS_ClaseGestiones ObjLoGS_ClaseGestiones = new LoGS_ClaseGestiones();

        try
        {
            #region Cargar_Variables
            EnGS_ClaseGestiones ObjEnGS_ClaseGestiones = new EnGS_ClaseGestiones();
            List<EnGS_ClaseGestiones> ListEnGS_ClaseGestiones = new List<EnGS_ClaseGestiones>();

            ObjEnGS_ClaseGestiones.CodClaseGestion = txt_codigo.Text.Trim();
            ObjEnGS_ClaseGestiones.CodUsuario = (String)this.Session["codusuario"];


            ListEnGS_ClaseGestiones.Add(ObjEnGS_ClaseGestiones);
            #endregion Cargar_Variables

            msg = ObjLoGS_ClaseGestiones.GS_ClaseGestiones_DEL(ListEnGS_ClaseGestiones);

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
    protected void cmb_CodTipoGestion_SelectedIndexChanged(object sender, EventArgs e)
    {
        CargaComboEjecutado();
    }
    protected void cmb_Resultado_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void txt_descripcion_TextChanged(object sender, EventArgs e)
    {

    }
    protected void cmb_CodEjecutado_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}