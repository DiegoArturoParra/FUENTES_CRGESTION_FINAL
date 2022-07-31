using IABaseWeb;
using Sis.Estudio.Entity;
using Sis.Estudio.Logic.MSSQL.Estudio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Estudio_Maestros_ColumnaDet : BaseMantDetalle
{
    #region Declaraciones
    private const string PaginaRetorno = "Columna.aspx";
    //public string mstrEstado;
    public string mstrId;
    //string strEmpresa;

    #endregion  Declaraciones
    #region Eventos
    private List<EnColumna> lstColumna = null;
    private EnColumna loEnColumna = null;
    private string estado, loMensaje = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        //****************************************************************************************
        //* Nomre       : Page_Load
        //* DescripcioN :
        //****************************************************************************************
        if (!IsPostBack)
        {

            G_idopcion = OpcionModulo.Columna;
            this.Master.TituloModulo = "Detalle de Columnas de Trabajo";

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
            estado = (String)ViewState["estado"];
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
            estado = (String)ViewState["estado"];
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
            estado = (String)ViewState["estado"];
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

                estado = (String)ViewState["estado"];
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

            this.CargarCombo_TablaTrabajo();

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

    protected void CargarCombo_TablaTrabajo()
    {
        DataTable ldtTablaTrabajo = new DataTable();
        ListItem lista = new ListItem();
        try
        {

            cbbNombreTabla.Items.Clear();
            #region Carga_Variable
            List<EnColumna> lstEntColumna = new List<EnColumna>();
            EnColumna objEntColumna = new EnColumna();
            objEntColumna.nEmpresa = (String)this.Session[Global.NEmpresa].ToString();
            lstEntColumna.Add(objEntColumna);
            #endregion Carga_Variable
            LoColumna loTablaTrabajo = new LoColumna();
            ldtTablaTrabajo = loTablaTrabajo.TablaTrabajo_Listar(lstEntColumna);

            lista.Value = "-1";
            lista.Text = "--Seleccionar--";
            cbbNombreTabla.Items.Add(lista);

            for (int i = 0; i < ldtTablaTrabajo.Rows.Count; i++)
            {
                lista = new ListItem();
                lista.Value = ldtTablaTrabajo.Rows[i]["nIdTabla"].ToString().Trim();
                lista.Text = ldtTablaTrabajo.Rows[i]["cNombreTabla"].ToString().Trim();
                cbbNombreTabla.Items.Add(lista);
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

            List<EnColumna> lstEnColumna = new List<EnColumna>();
            EnColumna loEnColumna = new EnColumna();

            loEnColumna.nEmpresa = (String)this.Session[Global.NEmpresa].ToString();
            loEnColumna.nIdColumna = str_ID;
            loEnColumna.nIdUser = (String)this.Session[Global.CodUsuario].ToString();

            lstEnColumna.Add(loEnColumna);
            #endregion Carga_Variable

            LoColumna loLoColumna = new LoColumna();

            dt = loLoColumna.mxColumnaTrabajo_ListarXRegistro(lstEnColumna);
            if (dt.Rows.Count > 0)
            {
                #region CONTROLES_MANTENIMIENTO
                txcIdColumna.Text = dt.Rows[0]["nIdcolumna"].ToString();
                txcNombreColumna.Text = dt.Rows[0]["cNombreColumna"].ToString();
                txcValorDefecto.Text = dt.Rows[0]["cValor"].ToString();
                txcOrden.Text = dt.Rows[0]["nOrden"].ToString();
                txcDescripcion.Text = dt.Rows[0]["cDescripcion"].ToString();
                txnLongitud.Text = Convert.ToString(Convert.ToInt32(Decimal.Parse(dt.Rows[0]["nLongDato"].ToString())));
                cbbNombreTabla.SelectedValue = dt.Rows[0]["nIdTabla"].ToString();
                cbbTipoDato.SelectedValue = dt.Rows[0]["cTipoDato"].ToString();

                ckbActivo.Checked = Convert.ToBoolean(dt.Rows[0]["lActivo"]) ? true : false;
                ckbVisible.Checked = Convert.ToBoolean(dt.Rows[0]["lVisible"]) ? true : false;
                ckbObligatorio.Checked = Convert.ToBoolean(dt.Rows[0]["lObligatorio"]) ? true : false;


                #endregion CONTROLES_MANTENIMIENTO
                #region CONTROLES_INFORMATIVOS
                //lbl_CODUSUARIOREGISTRA.Text = dt.Rows[0]["CODUSUARIOREGISTRA"].ToString();
                //lbl_FECHAREGISTRA.Text = dt.Rows[0]["FECHAREGISTRA"].ToString();
                //lbl_ESTADOREGISTRA.Text = "";

                //lbl_CODUSUARIOMODIFICA.Text = dt.Rows[0]["CODUSUARIOMODIFICA"].ToString();
                //lbl_FECHAMODIFICA.Text = dt.Rows[0]["FECHAMODIFICA"].ToString();
                //lbl_ESTADOMODIFICA.Text = "";

                //lbl_CODUSUARIOANULA.Text = dt.Rows[0]["CODUSUARIOANULA"].ToString();
                //lbl_FECHAANULA.Text = dt.Rows[0]["FECHAANULA"].ToString();
                //lbl_ESTADOANULA.Text = dt.Rows[0]["Estado"].ToString();

                #endregion CONTROLES_INFORMATIVOS

                mstrId = txcIdColumna.Text.Trim();
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

        mstrEstado = "agregar";
        ViewState.Add("estado", mstrEstado);
        Botonera("mantenimiento");
        EnableControl(true);
        LimpiarControles();
        Cursor_Control(txcNombreColumna);

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
        Cursor_Control(txcNombreColumna);
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
        txcIdColumna.Enabled = dato;
        cbbNombreTabla.Enabled = dato;
        txcNombreColumna.Enabled = dato;
        txcValorDefecto.Enabled = dato;
        txcOrden.Enabled = dato;
        txcDescripcion.Enabled = dato;
        cbbTipoDato.Enabled = dato;
        txnLongitud.Enabled = dato;

        ckbActivo.Enabled = dato;

        //cmb_Estado.Enabled = dato;

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
        txcIdColumna.Text = String.Empty;
        txcNombreColumna.Text = String.Empty;

        txcValorDefecto.Text = String.Empty;
       
        txcValorDefecto .Text = String.Empty;
        txcOrden.Text = String.Empty;
        txcDescripcion.Text = String.Empty;

        txnLongitud.Text = String.Empty;


        cbbNombreTabla.SelectedValue = "-1";
        cbbTipoDato.SelectedValue = "-1";

        ckbActivo.Checked = true;
        ckbVisible.Checked = true;
        ckbObligatorio.Checked = false;


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
        if (txcNombreColumna.Text == "")
        {
            MostrarMensaje("Ingrese Producto.", true);
            Cursor_Control(txcNombreColumna);
            return false;
        }

        if (txcValorDefecto.Text.Trim().Length > 0)
        {
            if (Util.esNumero(txcValorDefecto.Text) == false)
            {
                MostrarMensaje("Ingrese Valores Numericos.", true);
                Cursor_Control(txcValorDefecto);
                return false;
            }
        }

        #endregion para_Todo
        #region para_Modificar
        estado = (String)ViewState["estado"];
        if (estado == "modificar")
        {
            if (txcIdColumna.Text.Length < 1)
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
    private List<EnColumna> mxAsignarValoresFormulario()
    {
        lstColumna = new List<EnColumna>();
        EnColumna loEnColumna = new EnColumna();

        #region Carga_Variable
        loEnColumna.nEmpresa = (String)this.Session[Global.NEmpresa].ToString();
        loEnColumna.nIdColumna = estado == "agregar" ? null : Util.FormateaEntero(txcIdColumna.Text);
        loEnColumna.nIdUser = Util.FormateaEntero((String)this.Session[Global.CodUsuario].ToString());
        loEnColumna.nIdTabla = Util.FormateaEntero(cbbNombreTabla.SelectedValue.ToString());
        loEnColumna.cNombreColumna = txcNombreColumna.Text;
        loEnColumna.cValor = txcValorDefecto.Text;
        loEnColumna.lActivo = ckbActivo.Checked ? "true" : "false";
        loEnColumna.lVisible = ckbVisible.Checked ? "true" : "false";
        loEnColumna.nOrden = Util.FormateaEntero(txcOrden.Text);
        loEnColumna.cDescripcion = txcDescripcion.Text;
        loEnColumna.lModificable = "true";
        loEnColumna.lCampoOrigen = "false";
        loEnColumna.cTipoCampo = "Texto";
        loEnColumna.cTipoDato = cbbTipoDato.SelectedValue;
        loEnColumna.nLongDato = Util.FormateaEntero(Decimal.Parse(txnLongitud.Text).ToString());
        loEnColumna.lObligatorio = ckbObligatorio.Checked ? "true" : "false";

        lstColumna.Add(loEnColumna);

        return lstColumna;

        #endregion Carga_Variable
    }
    private void Grabar()
    {
        //****************************************************************************************
        //* Nomre       : Grabar
        //* DescripcioN :
        //****************************************************************************************
        string str_Id = "";
        string msg = "";
        string Exito = "";
        LoColumna loLoColumna = new LoColumna();
        try
        {


            List<EnTransaccion> RetornoT = loLoColumna.Columna_INS(mxAsignarValoresFormulario());
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

            LoColumna loLoColumna = new LoColumna();
            msg = loLoColumna.mxColumna_UPD(mxAsignarValoresFormulario());
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

    
    #region CreacionColumnas

    private void mxCrearColumnas()
    {
        try
        {
            loMensaje = string.Empty;

            LoColumna loLoColumna = new LoColumna();
            loMensaje = loLoColumna.mxColumna_UPD(mxAsignarValoresFormulario());
            if (loMensaje == "exito")
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



    #endregion CreacionColumnas


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