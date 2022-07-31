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
using Sis.Estudio.Logic.MSSQL.Seguridad;

public partial class Estudio_Gestion_GS_ReglasGestionesDetalle : BaseMantDetalle
{
    #region Declaraciones
    private const string PaginaRetorno = "GS_ReglasGestiones.aspx";
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

            G_idopcion = OpcionModulo.MantReglasGestiones;
            this.Master.TituloModulo = "Detalle de Reglas de Gestiones";
            #region accesos
            Accesos();
            #endregion accesos

            cargagrillavacia();
            CargaComboEjecutores();
            CargaComboEmpresa();
            CargaComboTramo();
            Botonera("consulta");
            EnableControl(false);
            strEmpresa = (String)this.Session["cempresa"];


            InicioOperacion();

            //====================== Funcionabilidad JavaScript de botones j. Aroni E.=============================================//
            btnGrabar.Attributes.Add("onClick", "document.getElementById('hdnContinuar').value = confirm('Los datos se guardarán, ¿Desea continuar?');");
            //btnEliminar.Attributes.Add("onClick", "document.getElementById('hdnContinuar').value = confirm('¿Se anulará El registro, ¿Desea continuar?');");


            //=================================== Fin  Funcionabilidad JavaScript =================================================//

            /*Visibilidad de controles para AP de Bandeja Gestiones Internas - Flujo 2*/
            lblTituloEjecutor.Visible = false; 
            
            lblTipoEjecutor.Visible = false;
            CargaComboTipoEjecutores();
            cmb_TipoEjecutor.Visible = false;
            cmb_TipoEjecutor.Enabled = false;
            
            lblUsuarioEjecutor.Visible = false;
            CargaComboUsuarioEjecutor("0");
            //cmb_UsuarioEjecutor.Text = "-1";
            cmb_UsuarioEjecutor.Visible = false;
            cmb_UsuarioEjecutor.Enabled = false;

            
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


    protected void CargaComboEmpresa()
    {
        DataTable dt = new DataTable();
        LoGS_ReglasGestiones objLoGS_ReglasGestiones = new LoGS_ReglasGestiones();
        try
        {
            EnGS_ReglasGestiones objEnGS_ReglasGestiones = new EnGS_ReglasGestiones();
            cmb_Empresa.Items.Clear();

            dt = objLoGS_ReglasGestiones.GS_Empresa_Combo();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["cEmpresa"].ToString().Trim();
                lista.Text = dt.Rows[i]["dEmpresa"].ToString().Trim();
                cmb_Empresa.Items.Add(lista);
            }
        }
        catch (Exception excp)
        {
            throw excp;
        }
    }

    protected void CargaComboTramo()
    {
        DataTable dt = new DataTable();
        LoGS_ReglasGestiones objLoGS_ReglasGestiones = new LoGS_ReglasGestiones();
        try
        {
            EnGS_ReglasGestiones objEnGS_ReglasGestiones = new EnGS_ReglasGestiones();
            cmb_Tramo.Items.Clear();

            dt = objLoGS_ReglasGestiones.GS_Tramo_Combo();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["Tramo"].ToString().Trim();
                lista.Text = dt.Rows[i]["Descrip"].ToString().Trim();
                cmb_Tramo.Items.Add(lista);
            }
        }
        catch (Exception excp)
        {
            throw excp;
        }
    }


    protected void CargaComboUsuarioEjecutor(string id_Ejecutores)
    {
        DataTable dt = new DataTable();
        LoGS_Gestion_Cobranza objLoGS_Gestion_Cobranza = new LoGS_Gestion_Cobranza();
        string str_ID = Request["id"];
        //string id_Ejecutores = "0";//Lista todos los usuarios, -1 lista según el flujo del AP
        try
        {
            EnGS_Gestion_Cobranza objEnGS_Gestion_Cobranza = new EnGS_Gestion_Cobranza();
            List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza = new List<EnGS_Gestion_Cobranza>();
            cmb_UsuarioEjecutor.Items.Clear();
            if (id_Ejecutores=="0")
            {
                ListItem lista2 = new ListItem();
                lista2.Value = "0";
                lista2.Text = "--seleccione--";
                cmb_UsuarioEjecutor.Items.Add(lista2);
            }
            else
            {
                objEnGS_Gestion_Cobranza.nEmpresa = (String)this.Session["cempresa"];
                objEnGS_Gestion_Cobranza.CodUsuario = (String)this.Session["codusuario"];
                objEnGS_Gestion_Cobranza.IdReg_Gestion_Cobranza = str_ID;
                objEnGS_Gestion_Cobranza.Id_ejecutores = id_Ejecutores;
                ListEnGS_Gestion_Cobranza.Add(objEnGS_Gestion_Cobranza);
                dt = objLoGS_Gestion_Cobranza.GS_Gestion_Cobranza_Ejecutores_Listar(ListEnGS_Gestion_Cobranza);
                // llena el --seleccione -- ///
                ListItem lista2 = new ListItem();
                lista2.Value = "0";
                lista2.Text = "--seleccione--";
                cmb_UsuarioEjecutor.Items.Add(lista2);
                ///////////////////////////////
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ListItem lista = new ListItem();
                    lista.Value = dt.Rows[i]["CodigoUsuario"].ToString().Trim();
                    lista.Text = dt.Rows[i]["NombreUsuario"].ToString().Trim();
                    cmb_UsuarioEjecutor.Items.Add(lista);
                }
            }
        }
        catch (Exception excp)
        {
            throw excp;
        }
    }


    protected void CargaComboEjecutores()
    {
        DataTable dt = new DataTable();
        LoUsuario objLoUsuario = new LoUsuario();
        try
        {
            EnUsuario objEnUsuario = new EnUsuario();
            List<EnUsuario> ListEnUsuario = new List<EnUsuario>();
            cmb_Ejecutores.Items.Clear();


            dt = objLoUsuario.GS_Ejecutores_Combo();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["id_ejecutores"].ToString().Trim();
                lista.Text = dt.Rows[i]["desc_ejecutores"].ToString().Trim();
                cmb_Ejecutores.Items.Add(lista);
                //cmb_TipoEjecutor.Items.Add(lista);
            }

        }
        catch (Exception excp)
        {
            throw excp;
        }
    }

    protected void CargaComboTipoEjecutores()
    {
        DataTable dt = new DataTable();
        LoUsuario objLoUsuario = new LoUsuario();
        try
        {
            EnUsuario objEnUsuario = new EnUsuario();
            List<EnUsuario> ListEnUsuario = new List<EnUsuario>();
            cmb_TipoEjecutor.Items.Clear();


            dt = objLoUsuario.GS_Ejecutores_Combo();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["id_ejecutores"].ToString().Trim();
                lista.Text = dt.Rows[i]["desc_ejecutores"].ToString().Trim();
                //cmb_Ejecutores.Items.Add(lista);
                cmb_TipoEjecutor.Items.Add(lista);
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


            LoGS_ReglasGestiones ObjLoGS_ReglasGestiones = new LoGS_ReglasGestiones();
            EnGS_ReglasGestiones ObjEnGS_ReglasGestiones = new EnGS_ReglasGestiones();
            List<EnGS_ReglasGestiones> ListEnGS_ReglasGestiones = new List<EnGS_ReglasGestiones>();

            ObjEnGS_ReglasGestiones.id_ReglasGestiones = str_ID;
            ListEnGS_ReglasGestiones.Add(ObjEnGS_ReglasGestiones);
            dt = ObjLoGS_ReglasGestiones.GS_ReglasGestiones_Reg(ListEnGS_ReglasGestiones);
            if (dt.Rows.Count > 0)
            {
                #region CONTROLES_MANTENIMIENTO
                txt_codigo.Text = dt.Rows[0]["id_ReglasGestiones"].ToString();
                cmb_Empresa.SelectedValue = dt.Rows[0]["nEmpresa"].ToString();
                cmb_Tramo.SelectedValue = dt.Rows[0]["Tramo"].ToString();
                cmb_Ejecutores.SelectedValue = dt.Rows[0]["id_ejecutores"].ToString();
           

                txt_dias_mora_de.Text = dt.Rows[0]["dias_mora_de"].ToString();
                txt_dias_mora_hasta.Text = dt.Rows[0]["dias_mora_hasta"].ToString();
                txt_descripcion.Text = dt.Rows[0]["descripcion"].ToString();

                cmb_garantias.SelectedValue = dt.Rows[0]["garantias"].ToString();
                cmb_provisiones.SelectedValue = dt.Rows[0]["provisiones"].ToString();

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
            LoGS_ReglasGestionesxTipoGestion objLoGS_ReglasGestionesxTipoGestion = new LoGS_ReglasGestionesxTipoGestion();
            EnGS_ReglasGestionesxTipoGestion objEnGS_ReglasGestionesxTipoGestion = new EnGS_ReglasGestionesxTipoGestion();
            List<EnGS_ReglasGestionesxTipoGestion> ListEnGS_ReglasGestionesxTipoGestion = new List<EnGS_ReglasGestionesxTipoGestion>();

            objEnGS_ReglasGestionesxTipoGestion.id_ReglasGestiones = txt_codigo.Text;

            ListEnGS_ReglasGestionesxTipoGestion.Add(objEnGS_ReglasGestionesxTipoGestion);
            #endregion Carga_Variables

            dt = objLoGS_ReglasGestionesxTipoGestion.GS_ReglasGestionesxTipoGestion_Lista(ListEnGS_ReglasGestionesxTipoGestion);

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
            LoGS_ReglasGestionesxTipoGestion objLoGS_ReglasGestionesxTipoGestion = new LoGS_ReglasGestionesxTipoGestion();
            EnGS_ReglasGestionesxTipoGestion objEnGS_ReglasGestionesxTipoGestion = new EnGS_ReglasGestionesxTipoGestion();
            List<EnGS_ReglasGestionesxTipoGestion> ListEnGS_ReglasGestionesxTipoGestion = new List<EnGS_ReglasGestionesxTipoGestion>();

            objEnGS_ReglasGestionesxTipoGestion.id_ReglasGestiones = "0";

            ListEnGS_ReglasGestionesxTipoGestion.Add(objEnGS_ReglasGestionesxTipoGestion);
            #endregion Carga_Variables

            dt = objLoGS_ReglasGestionesxTipoGestion.GS_ReglasGestionesxTipoGestion_Lista(ListEnGS_ReglasGestionesxTipoGestion);

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
        cmb_Empresa.Enabled = dato;
        cmb_Tramo.Enabled = dato;
        cmb_Ejecutores.Enabled = dato;
        txt_dias_mora_de.Enabled = dato;
        txt_dias_mora_hasta.Enabled = dato;
        txt_descripcion.Enabled = dato;
        cmb_garantias.Enabled = dato;
        cmb_provisiones.Enabled = dato;


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

        txt_dias_mora_de.Text = String.Empty;
        txt_dias_mora_hasta.Text = String.Empty;
        txt_descripcion.Text = String.Empty;

        //cmb_CodTipoGestion.SelectedValue = "-1";
        

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

        if (txt_dias_mora_de.Text == "")
        {
            MostrarMensaje("Ingrese dias de mora.", true);
            Cursor_Control(txt_dias_mora_de);
            return false;
        }

        if (txt_dias_mora_hasta.Text == "")
        {
            MostrarMensaje("Ingrese dias de mora.", true);
            Cursor_Control(txt_dias_mora_hasta);
            return false;
        }


        /*
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
        */
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
        LoGS_ReglasGestiones ObjLoGS_ReglasGestiones = new LoGS_ReglasGestiones();
        try
        {
            #region Cargar_Variables
            EnGS_ReglasGestiones ObjEnGS_ReglasGestiones = new EnGS_ReglasGestiones();
            List<EnGS_ReglasGestiones> ListEnGS_ReglasGestiones = new List<EnGS_ReglasGestiones>();

            ObjEnGS_ReglasGestiones.nempresa = cmb_Empresa.SelectedValue.ToString();
            ObjEnGS_ReglasGestiones.Tramo = cmb_Tramo.SelectedValue.ToString();
            ObjEnGS_ReglasGestiones.id_ejecutores = cmb_Ejecutores.SelectedValue.ToString();
            ObjEnGS_ReglasGestiones.dias_mora_de = txt_dias_mora_de.Text.Trim();
            ObjEnGS_ReglasGestiones.dias_mora_hasta = txt_dias_mora_hasta.Text.Trim();
            ObjEnGS_ReglasGestiones.descripcion = txt_descripcion.Text.Trim();
            ObjEnGS_ReglasGestiones.garantias = cmb_garantias.SelectedValue.ToString();
            ObjEnGS_ReglasGestiones.provisiones = cmb_provisiones.SelectedValue.ToString();
            ObjEnGS_ReglasGestiones.CodUsuario = (String)this.Session["codusuario"];


            ListEnGS_ReglasGestiones.Add(ObjEnGS_ReglasGestiones);
            #endregion Cargar_Variables
            List<EnTransaccion> RetornoT = ObjLoGS_ReglasGestiones.GS_ReglasGestiones_INS(ListEnGS_ReglasGestiones);
            msg = RetornoT[0].MENSAJE.ToString();
            str_Id = RetornoT[0].ID.ToString();


            // graba grilla //
            LoGS_ReglasGestionesxTipoGestion ObjLoGS_ReglasGestionesxTipoGestion = new LoGS_ReglasGestionesxTipoGestion();
            EnGS_ReglasGestionesxTipoGestion ObjEnGS_ReglasGestionesxTipoGestion = new EnGS_ReglasGestionesxTipoGestion();
            List<EnGS_ReglasGestionesxTipoGestion> ListEnGS_ReglasGestionesxTipoGestion = new List<EnGS_ReglasGestionesxTipoGestion>();

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
                CheckBox checkUsuario = row.FindControl("chkUsuarioEjecutor") as CheckBox;

                if (check.Checked)
                {

                    ObjEnGS_ReglasGestionesxTipoGestion.id_ReglasGestiones = str_Id;
                    ObjEnGS_ReglasGestionesxTipoGestion.CodTipoGestion = row.Cells[0].Text.ToString();

                    if (checkUsuario.Checked)
                    {
                        ObjEnGS_ReglasGestionesxTipoGestion.CodUsuarioEjecutor = cmb_UsuarioEjecutor.SelectedValue.ToString().Trim();
                    }

                    ListEnGS_ReglasGestionesxTipoGestion.Add(ObjEnGS_ReglasGestionesxTipoGestion);
                    List<EnTransaccion> RetornoT2 = ObjLoGS_ReglasGestionesxTipoGestion.GS_ReglasGestionesxTipoGestion_INS(ListEnGS_ReglasGestionesxTipoGestion);

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
        LoGS_ReglasGestiones ObjLoGS_ReglasGestiones = new LoGS_ReglasGestiones();
        try
        {
            #region Cargar_Variables
            EnGS_ReglasGestiones ObjEnGS_ReglasGestiones = new EnGS_ReglasGestiones();
            List<EnGS_ReglasGestiones> ListEnGS_ReglasGestiones = new List<EnGS_ReglasGestiones>();
            ObjEnGS_ReglasGestiones.id_ReglasGestiones = txt_codigo.Text.Trim();
            ObjEnGS_ReglasGestiones.nempresa = cmb_Empresa.SelectedValue.ToString();
            ObjEnGS_ReglasGestiones.Tramo = cmb_Tramo.SelectedValue.ToString();
            ObjEnGS_ReglasGestiones.id_ejecutores = cmb_Ejecutores.SelectedValue.ToString();
            ObjEnGS_ReglasGestiones.dias_mora_de = txt_dias_mora_de.Text.Trim();
            ObjEnGS_ReglasGestiones.dias_mora_hasta = txt_dias_mora_hasta.Text.Trim();
            ObjEnGS_ReglasGestiones.descripcion = txt_descripcion.Text.Trim();
            ObjEnGS_ReglasGestiones.garantias = cmb_garantias.SelectedValue.ToString();
            ObjEnGS_ReglasGestiones.provisiones = cmb_provisiones.SelectedValue.ToString();
            ObjEnGS_ReglasGestiones.CodUsuario = (String)this.Session["codusuario"];
            ListEnGS_ReglasGestiones.Add(ObjEnGS_ReglasGestiones);
            #endregion Cargar_Variables                       
            msg = ObjLoGS_ReglasGestiones.GS_ReglasGestiones_UPD(ListEnGS_ReglasGestiones);
            // graba grilla //
            LoGS_ReglasGestionesxTipoGestion ObjLoGS_ReglasGestionesxTipoGestion = new LoGS_ReglasGestionesxTipoGestion();
            EnGS_ReglasGestionesxTipoGestion ObjEnGS_ReglasGestionesxTipoGestion = new EnGS_ReglasGestionesxTipoGestion();
            List<EnGS_ReglasGestionesxTipoGestion> ListEnGS_ReglasGestionesxTipoGestion = new List<EnGS_ReglasGestionesxTipoGestion>();
            // borra grilla //
            ObjEnGS_ReglasGestionesxTipoGestion.id_ReglasGestiones = txt_codigo.Text.Trim();
            ListEnGS_ReglasGestionesxTipoGestion.Add(ObjEnGS_ReglasGestionesxTipoGestion);
            msg = ObjLoGS_ReglasGestionesxTipoGestion.GS_ReglasGestionesxTipoGestion_DEL(ListEnGS_ReglasGestionesxTipoGestion);
            //////////////////
            // agrega nueva combinacion //
            foreach (GridViewRow row in gv.Rows)
            {
                CheckBox check = row.FindControl("chkPermiso") as CheckBox;
                CheckBox checkUsuario = row.FindControl("chkUsuarioEjecutor") as CheckBox;
                if (check.Checked)
                {
                    ObjEnGS_ReglasGestionesxTipoGestion.id_ReglasGestiones = txt_codigo.Text.Trim();
                    ObjEnGS_ReglasGestionesxTipoGestion.CodTipoGestion = row.Cells[0].Text.ToString();
                    if (checkUsuario.Checked)
                    {
                        ObjEnGS_ReglasGestionesxTipoGestion.CodUsuarioEjecutor = cmb_UsuarioEjecutor.SelectedValue.ToString().Trim();
                    }
                    ListEnGS_ReglasGestionesxTipoGestion.Add(ObjEnGS_ReglasGestionesxTipoGestion);
                    List<EnTransaccion> RetornoT2 = ObjLoGS_ReglasGestionesxTipoGestion.GS_ReglasGestionesxTipoGestion_INS(ListEnGS_ReglasGestionesxTipoGestion);
                }
            }
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

        LoGS_ReglasGestiones ObjLoGS_ReglasGestiones = new LoGS_ReglasGestiones();

        try
        {
            #region Cargar_Variables
            List<EnGS_ReglasGestiones> ListEnGS_ReglasGestiones = new List<EnGS_ReglasGestiones>();
            EnGS_ReglasGestiones ObjEnGS_ReglasGestiones = new EnGS_ReglasGestiones();

            ObjEnGS_ReglasGestiones.id_ReglasGestiones = txt_codigo.Text.Trim();
            ObjEnGS_ReglasGestiones.CodUsuario = (String)this.Session["codusuario"];

            ListEnGS_ReglasGestiones.Add(ObjEnGS_ReglasGestiones);
            #endregion Cargar_Variables

            msg = ObjLoGS_ReglasGestiones.GS_ReglasGestiones_DEL(ListEnGS_ReglasGestiones);

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

    protected void chkUsuarioEjecutor_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            CheckBox chk = (CheckBox)sender;
            if (chk.Checked)
            {
                filaUsuarioEjecutor.BackColor = System.Drawing.Color.Aquamarine;

                lblTituloEjecutor.Visible = true;

                lblTipoEjecutor.Visible = true;
                cmb_TipoEjecutor.Visible = true;
                cmb_TipoEjecutor.Enabled = true;

                lblUsuarioEjecutor.Visible = true;
                cmb_UsuarioEjecutor.Visible = true;
                cmb_UsuarioEjecutor.Enabled = true;

                //cmb_UsuarioEjecutor.SelectedIndex = 0;
            }
            else
            {
                filaUsuarioEjecutor.BackColor = System.Drawing.Color.Empty;
                lblTituloEjecutor.Visible = false;

                lblTipoEjecutor.Visible = false;
                cmb_TipoEjecutor.Visible = false;
                cmb_TipoEjecutor.Enabled = false;

                lblUsuarioEjecutor.Visible = false;
                cmb_UsuarioEjecutor.Visible = false;
                cmb_UsuarioEjecutor.Enabled = false;
            }
            
        }
        catch (Exception excp)
        {

            throw excp;
        }
    }



    protected void cmb_TipoEjecutor_SelectedIndexChanged(object sender, EventArgs e)
    {
        string id_ejecutores = "0";
        id_ejecutores = cmb_TipoEjecutor.SelectedValue.Trim().ToString();
        cmb_UsuarioEjecutor.Items.Clear();
        CargaComboUsuarioEjecutor(id_ejecutores);
    }
}