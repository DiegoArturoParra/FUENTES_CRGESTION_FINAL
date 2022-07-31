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
using Sis.Estudio.Logic.MSSQL.Seguridad;
using Sis.Estudio.Logic.MSSQL.Estudio;

public partial class Estudio_Maestros_SectoristaDet : BaseMantDetalle
{
    #region Declaraciones
    private const string PaginaRetorno = "Sectorista.aspx";
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

            G_idopcion = OpcionModulo.Sectorista;
            this.Master.TituloModulo = "Detalle de Sectorista";

            #region accesos
            Accesos();
            #endregion accesos

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
    protected void cmb_Gerencia_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Master.OcultarMensaje();
            Combo_Zona();            
        }
        catch (Exception ex)
        {
            Master.MostrarMensaje(ex.Message.ToString(), TipoMensaje.Error);
        }
    }
    protected void cmb_Zona_SelectedIndexChanged(object sender, EventArgs e)
    {

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

            
            Combo_Gerencia();
            Combo_Zona();

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
    protected void Combo_Gerencia()
    {
        DataTable dt = new DataTable();
        try
        {
            
            cmb_Gerencia.Items.Clear();
            #region Carga_Variable
            List<EnGerencia> ListEn = new List<EnGerencia>();
            EnGerencia objEn = new EnGerencia();
            objEn.NEmpresa = (String)this.Session[Global.NEmpresa].ToString();
            ListEn.Add(objEn);
            #endregion Carga_Variable

            LoGerencia objLo = new LoGerencia();
            dt = objLo.Gerencia_Listar(ListEn);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["CodGerencia"].ToString().Trim();
                lista.Text = dt.Rows[i]["Gerencia"].ToString().Trim();
                cmb_Gerencia.Items.Add(lista);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void Combo_Zona()
    {
        DataTable dt = new DataTable();
        try
        {
            cmb_Zona.Items.Clear();
            #region Carga_Variable

            List<EnZona> ListEn = new List<EnZona>();
            EnZona objEn = new EnZona();
            objEn.NEmpresa = (String)this.Session[Global.NEmpresa].ToString();
            objEn.CodGerencia = cmb_Gerencia.SelectedValue.ToString();
            ListEn.Add(objEn);
            #endregion Carga_Variable

            LoZona objLo = new LoZona();
            dt = objLo.Zona_Listar_X_Gerencia(ListEn);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["CodZona"].ToString().Trim();
                lista.Text = dt.Rows[i]["Zona"].ToString().Trim();
                cmb_Zona.Items.Add(lista);
            }
        }
        catch (Exception ex)
        {
            throw ex;
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

            #region Carga_Variable

            List<EnSectorista> objListEn = new List<EnSectorista>();
            EnSectorista objEn = new EnSectorista();

            objEn.NEmpresa = (String)this.Session[Global.NEmpresa].ToString();
            objEn.CodSectorista = str_ID;
            objEn.CodUsuario = (String)this.Session[Global.CodUsuario].ToString();

            objListEn.Add(objEn);
            #endregion Carga_Variable

            LoSectorista objLo = new LoSectorista();

            dt = objLo.Sectorista_Listar_Reg(objListEn);
            if (dt.Rows.Count > 0)
            {

                #region CONTROLES_MANTENIMIENTO
                txt_ID.Text = dt.Rows[0]["CodSectorista"].ToString();
                cmb_Gerencia.SelectedValue = dt.Rows[0]["CodGerencia"].ToString();
                Combo_Zona();
                cmb_Zona.SelectedValue = dt.Rows[0]["CodZona"].ToString();
                txt_NOMBRE.Text = dt.Rows[0]["Sectorista"].ToString();
                txt_CodigoInterno.Text = dt.Rows[0]["CodigoInterno"].ToString();                              
                cmb_Estado.SelectedValue = dt.Rows[0]["Estado"].ToString();
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
                lbl_ESTADOANULA.Text = dt.Rows[0]["Estado"].ToString();

                //if (lbl_ESTADOANULA.Text.ToUpper().Trim() == "N")
                //{
                //    lbl_ESTADOANULA.ForeColor = Color.Red;
                //    lbl_ESTADOANULA.Text = "ANULADO";
                //}
                //else
                //{
                //    lbl_ESTADOANULA.Text = "";
                //}
                #endregion CONTROLES_INFORMATIVOS

                mstrId = txt_ID.Text.Trim();
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
        Cursor_Control(txt_NOMBRE);
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
        txt_ID.Enabled = dato;
        txt_NOMBRE.Enabled = dato;

        cmb_Gerencia.Enabled = dato;
        txt_CodigoInterno.Enabled = dato;

        cmb_Estado.Enabled = dato;

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
        txt_ID.Text = String.Empty;
        txt_NOMBRE.Text = String.Empty;

        txt_CodigoInterno.Text = String.Empty;
        
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

        if (cmb_Gerencia.Items.Count < 1)
        {
            MostrarMensaje("Seleccione Gerencia", true);            
            return false;
        }


        if (cmb_Zona.Items.Count < 1)
        {
            MostrarMensaje("Seleccione Zona", true);
            return false;
        }


        if (txt_NOMBRE.Text == "")
        {
            MostrarMensaje("Ingrese Sectorista.", true);
            Cursor_Control(txt_NOMBRE);
            return false;
        }


        if (txt_CodigoInterno.Text.Trim().Length > 0)
        {
            if (Util.esNumero(txt_CodigoInterno.Text) == false)
            {
                MostrarMensaje("Ingrese Valores Numericos.", true);
                Cursor_Control(txt_CodigoInterno);
                return false;
            }
        }

        #endregion para_Todo
        #region para_Modificar
        string estado = (String)ViewState["estado"];
        if (estado == "modificar")
        {
            if (txt_ID.Text.Length < 1)
            {
                MostrarMensaje(Mensaje.M_CODIGO_INVALIDO, true);
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
        LoSectorista ObjLo = new LoSectorista();
        try
        {
            #region Carga_Variable

            List<EnSectorista> objListEn = new List<EnSectorista>();
            EnSectorista objEn = new EnSectorista();

            objEn.NEmpresa = (String)this.Session[Global.NEmpresa].ToString();
            objEn.CodSectorista = Util.FormateaEntero(txt_ID.Text);            
            objEn.CodZona = cmb_Zona.SelectedValue.ToString();
            objEn.Sectorista = txt_NOMBRE.Text;
            objEn.CodigoInterno = Util.FormateaEntero(txt_CodigoInterno.Text);
            objEn.Estado = cmb_Estado.SelectedValue.ToString();
            objEn.CodUsuario = (String)this.Session[Global.CodUsuario].ToString();

            objListEn.Add(objEn);
            #endregion Carga_Variable

            List<EnTransaccion> RetornoT = ObjLo.Sectorista_INS(objListEn);
            msg = RetornoT[0].MENSAJE.ToString();
            str_Id = RetornoT[0].ID.ToString();
            if (msg == "exito")
            {
                mstrId = str_Id;
                ViewState.Add("id", mstrId);
                metodo_Consulta();
                MostrarMensaje(Mensaje.M_REGISTRO_CORRECTO, false);
                upControles.Update();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void Modificar()
    {
        try
        {
            string msg = "";
            #region Carga_Variable

            List<EnSectorista> objListEn = new List<EnSectorista>();
            EnSectorista objEn = new EnSectorista();

            objEn.NEmpresa = (String)this.Session[Global.NEmpresa].ToString();
            objEn.CodSectorista = Util.FormateaEntero(txt_ID.Text);
            objEn.CodZona = cmb_Zona.SelectedValue.ToString();
            objEn.Sectorista = txt_NOMBRE.Text;
            objEn.CodigoInterno = Util.FormateaEntero(txt_CodigoInterno.Text);
            objEn.Estado = cmb_Estado.SelectedValue.ToString();
            objEn.CodUsuario = (String)this.Session[Global.CodUsuario].ToString();

            objListEn.Add(objEn);
            #endregion Carga_Variable
            LoSectorista ObjLo = new LoSectorista();
            msg = ObjLo.Sectorista_UPD(objListEn);
            if (msg == "exito")
            {
                metodo_Consulta();
                Master.MostrarMensaje(Mensaje.M_OPERACION_SATISFACTORIA, TipoMensaje.Exito);
                upControles.Update();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void Anular()
    {
        

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
    #region Accesos
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
    #endregion Accesos

}    
