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
using System.Threading;
using Sis.Estudio.Entity;
using Sis.Estudio.Logic.MSSQL.Funcionabilidad;
using Sis.Estudio.Logic.MSSQL.Seguridad;
using Sis.Estudio.Logic.MSSQL.Gestion;
using IABaseWeb;



public partial class Mantenimientos_Seguridad_MantUsuarioDetalle : BaseMantDetalle
{
    #region Declaraciones
    public string mstrId;
    private const string PaginaRetorno = "MantUsuario.aspx";
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

            this.Master.TituloModulo = "Detalle Usuario";
            G_idopcion = OpcionModulo.MantUsuario;

            #region accesos
            Accesos();
            #endregion accesos

            btnAgregar.Visible = false;
            btnModificar.Visible = false;
            btnConsultar.Visible = false;
            btnEliminar.Visible = false;

            //CargaComboJerarquiaA();

            CargaComboEjecutores();

            CargaComboEmpresa();

            Botonera("consulta");
            EnableControl(false);
            strEmpresa = (String)this.Session["cempresa"];
            InicioOperacion();
            //====================== Funcionabilidad JavaScript de botones j. Aroni E.=============================================//
            btnGrabar.Attributes.Add("onClick", "document.getElementById('hdnContinuar').value = confirm('Los datos se guardarán, ¿Desea continuar?');");
            //btnEliminar.Attributes.Add("onClick", "document.getElementById('hdnContinuar').value = confirm('¿Se anulará El registro, ¿Desea continuar?');");
            btn_MODIFICARPASS.Attributes.Add("onClick", "document.getElementById('hdnContinuar').value = confirm('Se modificara la contraseña, ¿Desea continuar?');");
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
            //MostrarMensaje("No se Puede agregar Nuevos Registros", true);
            //return;

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

        #region valida_estado
        string estado = (String)ViewState["estado"];
        if (estado == "agregar")
        {
            return;
        }
        #endregion valida_estado
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
        //****************************************************************************************
        //* Nomre       : btnCancelar_Click
        //* DescripcioN :
        //****************************************************************************************
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
        Response.Redirect("MantUsuario.aspx");
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


            dt = objLoUsuario.GS_Ejecutores_Combo2();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["id_ejecutores"].ToString().Trim();
                lista.Text = dt.Rows[i]["desc_ejecutores"].ToString().Trim();
                cmb_Ejecutores.Items.Add(lista);
            }

        }
        catch (Exception excp)
        {
            throw excp;
        }
    }


    protected void CargaComboJerarquiaA_Ejecutores()
    {
        DataTable dt = new DataTable();
        LoGS_JerarquiaA objLoGS_JerarquiaA = new LoGS_JerarquiaA();
        try
        {
            EnGS_JerarquiaA objEnGS_JerarquiaA = new EnGS_JerarquiaA();
            List<EnGS_JerarquiaA> ListEnGS_JerarquiaA = new List<EnGS_JerarquiaA>();
            cmb_JerarquiaA.Items.Clear();

            objEnGS_JerarquiaA.nempresa = (String)this.Session["cempresa"];
            objEnGS_JerarquiaA.id_ejecutores =cmb_Ejecutores.SelectedValue.ToString();

            ListEnGS_JerarquiaA.Add(objEnGS_JerarquiaA);

            dt = objLoGS_JerarquiaA.GS_JerarquiaA_Ejecutores_Combo(ListEnGS_JerarquiaA);

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


    protected void btn_CODUSUARIO_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            limpiarMensaje();
            if (txt_LOGIN.Text.Length < 3)
            {
                MostrarMensaje("Escriba un usuario Correcto", true);
                Cursor_Control(txt_LOGIN);
                return;
            }

            System.Threading.Thread.Sleep(500);
            pnlExistenciaUsuario.Visible = true;
            if (!VerificaExistenciaUsuario())
            {
                imgExistenciaUsuario.ImageUrl = "~/Imagenes/Botones/imgEstadoOk.jpg";
                lblExistenciaUsuario.Text = "Usuario Válido"; lblExistenciaUsuario.ForeColor = System.Drawing.Color.DarkBlue;
                hd_USUARIOVALIDO.Value = "1";
            }
            else
            {
                imgExistenciaUsuario.ImageUrl = "~/Imagenes/Botones/imgEstadoNotOk.jpg";
                lblExistenciaUsuario.Text = "El Usuario ya Existe"; lblExistenciaUsuario.ForeColor = System.Drawing.Color.Red;
                hd_USUARIOVALIDO.Value = "0";
            }
        }

        catch (Exception excp)
        {
            MostrarMensaje(excp.ToString(), true);
        }
    }
    protected void Image1_Click(object sender, ImageClickEventArgs e)
    {
        limpiarMensaje();
        Bloqueo_personalizado();
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
            string str_IdUsuario = "";
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
                str_IdUsuario = Request["IdUsuario"];
                str_TIPO = "1";
                hd_IDUSUARIO.Value = str_IdUsuario;
                mstrId = str_IdUsuario;
                ViewState.Add("id", mstrId);
                MostrarDatos(str_TIPO, str_IdUsuario);
                metodo_modificar();
            }
            else if (str_Estado == "c")
            {
                str_IdUsuario = Request["IdUsuario"];
                mstrId = str_IdUsuario;
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
        #region ValidaEstado
        //string estado = (String)ViewState["estado"];
        //if (estado == "consulta")
        //{
        //    return;
        //}
        #endregion ValidaEstado
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
        Controles_Password("C");
        lkb_Perfil.Enabled = true;
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
        Controles_Password("N");
        lkb_Perfil.Enabled = false;
        Cursor_Control(txt_LOGIN);

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
        Controles_Password("M");

        //txt_LOGIN.Enabled = false;

        lkb_Perfil.Enabled = true;
        //MostrarMensaje("Solo se Modifica Estado de Usuario y el password.", true);
        Cursor_Control(txt_LOGIN);
    }
    #endregion Metodos
    #region Procedimientos
    protected void MostrarDatos(string str_TIPO, string str_IdUsuario)
    {
        //****************************************************************************************
        //* Nombre      : MostrarDatos
        //* DescripcioN :
        //*
        //****************************************************************************************
        try
        {
            limpiarMensaje();
            LimpiarControles();
            DataTable dt = new DataTable();

            LoUsuario objLoUsuario = new LoUsuario();
            List<EnUsuario> ListEnUsuario = new List<EnUsuario>();
            EnUsuario objEnUsuario = new EnUsuario();


            objEnUsuario.CEmpresa = (String)this.Session["cempresa"];
            objEnUsuario.Tipo = str_TIPO;
            objEnUsuario.codUsuario = str_IdUsuario;
            ListEnUsuario.Add(objEnUsuario);

            dt = objLoUsuario.CargaDatosUsuario(ListEnUsuario);

            if (dt.Rows.Count > 0)
            {
                //========= CONTROLES DE MANTENIMIENTO j. Aroni E.=========//

                hd_IDUSUARIO.Value = dt.Rows[0]["IDUSUARIO"].ToString();
                txt_LOGIN.Text = dt.Rows[0]["Login3"].ToString();
                txt_paterno.Text = dt.Rows[0]["paterno"].ToString();
                txt_materno.Text = dt.Rows[0]["materno"].ToString();
                txt_nombre1.Text = dt.Rows[0]["nombre1"].ToString();
                cmb_SBLOQUEADO.SelectedValue = dt.Rows[0]["SBLOQUEADO"].ToString();
                txt_EMAIL.Text = dt.Rows[0]["Email"].ToString();
                txt_dni.Text = dt.Rows[0]["dni"].ToString();

                cmb_Empresa.SelectedValue = dt.Rows[0]["CEmpresa"].ToString();

                CargaComboJerarquiaB_consulta(dt.Rows[0]["cod_jerarquiaA"].ToString());
                CargaComboJerarquiaC_consulta(dt.Rows[0]["cod_jerarquiaB"].ToString());
                CargaComboJerarquiaD_consulta(dt.Rows[0]["cod_jerarquiaC"].ToString());

                cmb_JerarquiaA.SelectedValue = dt.Rows[0]["cod_jerarquiaA"].ToString();
                cmb_JerarquiaB.SelectedValue = dt.Rows[0]["cod_jerarquiaB"].ToString();
                cmb_JerarquiaC.SelectedValue = dt.Rows[0]["cod_jerarquiaC"].ToString();
                cmb_JerarquiaD.SelectedValue = dt.Rows[0]["cod_jerarquiaD"].ToString();

                cmb_Ejecutores.SelectedValue = dt.Rows[0]["id_ejecutores"].ToString();

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

                mstrId = hd_IDUSUARIO.Value;
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

    private void EnableControl(bool dato)
    {
        //********************************************************************************
        //**  EnableControl  : Cambia el estado de los controles.
        //**                   Bloquea desbloquea controles :
        //********************************************************************************
        //==== controles de ingreso ====//        
        txt_LOGIN.Enabled = dato;
        txt_paterno.Enabled = dato;
        txt_materno.Enabled = dato;
        txt_nombre1.Enabled = dato;
        txt_dni.Enabled = dato;
        cmb_Empresa.Enabled = dato;
        //txt_CODIGOSAP.Enabled = dato;
        txt_EMAIL.Enabled = dato;

        cmb_SBLOQUEADO.Enabled = dato;
        txt_PASSWORD1.Enabled = dato;
        txt_PASSWORD2.Enabled = dato;


        cmb_JerarquiaA.Enabled = dato;
        cmb_JerarquiaB.Enabled = dato;
        cmb_JerarquiaC.Enabled = dato;
        cmb_JerarquiaD.Enabled = dato;

        cmb_Ejecutores.Enabled = dato;

        //==== botones ====//   


        #region personalizado
        string estado = (String)ViewState["estado"];
        if (estado == "modificar" && dato == true)
        {
            //txt_LOGIN.Enabled = false;
        }

        #endregion personalizado

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
                lkb_Perfil.Visible = false;


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
                    lkb_Perfil.Visible = true;

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
        hd_IDUSUARIO.Value = String.Empty;
        txt_LOGIN.Text = String.Empty;
        txt_paterno.Text = String.Empty;
        txt_materno.Text = String.Empty;
        txt_nombre1.Text = String.Empty;
        txt_dni.Text = String.Empty;

        txt_PASSWORD1.Text = String.Empty;
        txt_PASSWORD2.Text = String.Empty;
        lbl_CODUSUARIOREGISTRA.Text = String.Empty;
        lbl_FECHAREGISTRA.Text = String.Empty;
        lbl_ESTADOREGISTRA.Text = String.Empty;
        lbl_CODUSUARIOMODIFICA.Text = String.Empty;
        lbl_FECHAMODIFICA.Text = String.Empty;
        lbl_ESTADOMODIFICA.Text = String.Empty;
        lbl_CODUSUARIOANULA.Text = String.Empty;
        lbl_FECHAANULA.Text = String.Empty;
        lbl_ESTADOANULA.Text = String.Empty;
        pnlExistenciaUsuario.Visible = false;
        hd_USUARIOVALIDO.Value = String.Empty;
        txt_EMAIL.Text = String.Empty;

        cmb_SBLOQUEADO.SelectedValue = "N";

        cmb_JerarquiaA.SelectedValue = "0";
        cmb_JerarquiaB.SelectedValue = "0";
        cmb_JerarquiaC.SelectedValue = "0";
        cmb_JerarquiaD.SelectedValue = "0";

    }
    #endregion Procedimientos
    #region Funciones
    private bool Valida_Datos()
    {

        #region para_agregar
        string estado = (String)ViewState["estado"];
        if (estado == "agregar")
        {



            if (txt_LOGIN.Text == "")
            {
                MostrarMensaje("Ingrese Codigo de Usuario.", true);
                Cursor_Control(txt_LOGIN);
                return false;
            }

            //if (hd_USUARIOVALIDO.Value == "")
            //{
            //    MostrarMensaje("validar el Codigo de Usuario. (clik en el boton Verificar Usuario)", true);
            //    hd_USUARIOVALIDO.Value = "";
            //    upControles.Update();
            //    Cursor_Control(txt_LOGIN);
            //    return false;
            //}

            //if (hd_USUARIOVALIDO.Value == "0")
            //{
            //    MostrarMensaje("El codigo de Usuario ya existe.", true);
            //    hd_USUARIOVALIDO.Value = "";
            //    upControles.Update();
            //    Cursor_Control(txt_LOGIN);
            //    return false;
            //}

            //if (txt_CODPERSONAL.Text.Length > 1)
            //{
            //    if (txt_CODPERSONAL.Text.Length < 12)
            //    {
            //        MostrarMensaje("El Codigo de Personal es de 12 caracteres.", true);
            //        Cursor_Control(txt_CODPERSONAL);
            //        return false;
            //    }

            //    if (txt_DESPERSONAL.Text == "")
            //    {
            //        MostrarMensaje("Ingrese Codigo de Personal Correcto.", true);
            //        Cursor_Control(txt_CODPERSONAL);
            //        return false;
            //    }
            //}


            if (cmb_SBLOQUEADO.SelectedValue == "0")
            {
                MostrarMensaje("Seleccione el estado", true);
                cmb_SBLOQUEADO.Focus();
                //Cursor_Control(cmb_SBLOQUEADO);
                return false;
            }

            if (txt_PASSWORD1.Text.Length < 5)
            {
                MostrarMensaje("Ingrese Password correctamente. ( mas de 5 caracteres)", true);
                Cursor_Control(txt_PASSWORD1);
                return false;
            }

            if (txt_PASSWORD2.Text.Length < 5)
            {
                MostrarMensaje("Ingrese Password correctamente. ( mas de 5 caracteres)", true);
                Cursor_Control(txt_PASSWORD2);
                return false;
            }

            if (txt_PASSWORD1.Text != txt_PASSWORD2.Text)
            {
                MostrarMensaje("Confirmacion de Password no coincide.", true);
                Cursor_Control(txt_PASSWORD2);
                return false;
            }



        }

        #endregion para_agregar

        #region para_Todo

        if (cmb_Ejecutores.SelectedValue == "0")
        {
            MostrarMensaje("Seleccione Ejecutor", true);
            cmb_Ejecutores.Focus();
            //Cursor_Control(cmb_SBLOQUEADO);
            return false;
        }

        #endregion para_Todo

        return true;
    }
    private bool VerificaExistenciaUsuario()
    {
        bool lblExiste = false;
        LoUsuario objLoUsuario = new LoUsuario();
        DataTable dt;
        try
        {

            List<EnUsuario> ListEnUsuario = new List<EnUsuario>();
            EnUsuario objEnusario = new EnUsuario();

            objEnusario.login3 = txt_LOGIN.Text.ToUpper().Trim();
            objEnusario.CEmpresa = (String)this.Session["cempresa"];
            ListEnUsuario.Add(objEnusario);

            dt = objLoUsuario.VerificiaLogin(ListEnUsuario);

            if (dt.Rows.Count > 0)
                lblExiste = true;
            else
            {
                lblExiste = false;
            }
        }
        catch (Exception ex)
        {
            Util.MensajeModal(ex.Message, this);
        }
        return lblExiste;
    }
    #endregion Funciones
    #region Custom
    private void Controles_Password(string strEstado)
    {
        //****************************************************************************************
        //* Nomre       : Controles_Password
        //* DescripcioN : establece estado de controles para password
        //****************************************************************************************
        switch (strEstado)
        {
            case "N":

                Panel2.Enabled = false;
                Panel1.Enabled = false;
                Panel2.Height = 0;
                //lbl_MP.Visible = false;
                Image1.Enabled = false;
                Image1.Height = 0;



                lbl_PASSWORD1.Visible = true;
                lbl_PASSWORD2.Visible = true;
                txt_PASSWORD1.Visible = true;
                txt_PASSWORD2.Visible = true;

                upBotonera.Update();
                upControles.Update();

                break;
            case "M":

                Panel2.Enabled = true;
                Panel1.Enabled = true;
                Panel2.Height = 30;
                //lbl_MP.Visible = true;
                Image1.Enabled = true;
                Image1.Height = 12;

                lbl_PASSWORD1.Visible = false;
                lbl_PASSWORD2.Visible = false;
                txt_PASSWORD1.Visible = false;
                txt_PASSWORD2.Visible = false;

                upBotonera.Update();
                upControles.Update();
                break;

            case "C":

                Panel2.Enabled = false;
                Panel1.Enabled = false;
                Panel2.Height = 0;
                //lbl_MP.Visible = false;
                Image1.Enabled = false;
                Image1.Height = 0;

                lbl_PASSWORD1.Visible = false;
                lbl_PASSWORD2.Visible = false;
                txt_PASSWORD1.Visible = false;
                txt_PASSWORD2.Visible = false;

                upBotonera.Update();
                upControles.Update();
                break;
        }
    }
    private void Bloqueo_personalizado()
    {
        #region Swich
        if (hd_MODIFICAPASS.Value == "N")
        { hd_MODIFICAPASS.Value = "S"; }
        else
        { hd_MODIFICAPASS.Value = "N"; }
        #endregion Swich

        #region Habilita
        if (hd_MODIFICAPASS.Value == "N")
        {
            btnAgregar.Enabled = true;
            btnGrabar.Enabled = true;
            btnEliminar.Enabled = true;
            btnModificar.Enabled = true;
            btnConsultar.Enabled = true;
            btnSalir.Enabled = true;
            cmb_Empresa.Enabled = true;

            txt_LOGIN.Enabled = true;
            txt_paterno.Enabled = true;
            txt_materno.Enabled = true;
            txt_nombre1.Enabled = true;
            txt_dni.Enabled = true;
            cmb_SBLOQUEADO.Enabled = true;
            txt_EMAIL.Enabled = true;
            lkb_Perfil.Enabled = true;
        }
        else if (hd_MODIFICAPASS.Value == "S")
        {
            btnAgregar.Enabled = false;
            btnGrabar.Enabled = false;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
            btnConsultar.Enabled = false;
            btnSalir.Enabled = false;

            /*
            txt_LOGIN.Enabled = false;
            txt_NOMBRESUSUARIOS.Enabled = false;
            cmb_SBLOQUEADO.Enabled = false;
            txt_EMAIL.Enabled = false;
            lkb_Perfil.Enabled = false;
             */ 
        }
        #endregion Habilita
        upBotonera.Update();
        upControles.Update();
    }
    #endregion Custom
    #region Datos
    protected ArrayList Cargar_Variables(ArrayList arrParametros)
    {


        //****************************************************************************************
        //* Nomre       : Cargar_Variables
        //* DescripcioN :
        //****************************************************************************************

        arrParametros.Add(txt_LOGIN.Text.Trim());
        arrParametros.Add((String)this.Session["cempresa"]);
        arrParametros.Add(txt_paterno.Text.Trim());

        arrParametros.Add(EncriptaCadena(txt_PASSWORD1.Text.ToUpper()));
        arrParametros.Add(cmb_SBLOQUEADO.SelectedValue.ToString());

        arrParametros.Add(txt_EMAIL.Text.Trim());
        arrParametros.Add((String)this.Session["codusuario"]);
        return arrParametros;

    }
    protected ArrayList Cargar_VariablesMod(ArrayList arrParametros)
    {
        //****************************************************************************************
        //* Nomre       : Cargar_Variables
        //* DescripcioN :
        //****************************************************************************************

        arrParametros.Add(hd_IDUSUARIO.Value);
        arrParametros.Add((String)this.Session["cempresa"]);
        arrParametros.Add(txt_paterno.Text.Trim());

        arrParametros.Add(cmb_SBLOQUEADO.SelectedValue.ToString());

        arrParametros.Add(txt_EMAIL.Text.Trim());
        arrParametros.Add((String)this.Session["codusuario"]);
        return arrParametros;
    }
    private void Grabar()
    {
        //MostrarMensaje("Datos de Solo lectura", true);

        //****************************************************************************************
        //* Nomre       : Grabar
        //* DescripcioN :
        //****************************************************************************************
        string str_Id = "";
        string msg = "";
        string Exito = "";

        string comboNivelA = "";
        string comboNivelB = "";
        string comboNivelC = "";
        string comboNivelD = "";

        LoUsuario ObjLoUsuario = new LoUsuario();
        try
        {
            #region Cargar_Variables
            EnUsuario objEnUsuario = new EnUsuario();
            List<EnUsuario> ListEnUsuario = new List<EnUsuario>();

            objEnUsuario.login3 = txt_LOGIN.Text.Trim();
            objEnUsuario.Sbloqueado = cmb_SBLOQUEADO.SelectedValue.ToString();
            objEnUsuario.codUsuario = (String)this.Session["codusuario"];
            objEnUsuario.email = txt_EMAIL.Text.Trim();
            objEnUsuario.paterno = txt_paterno.Text.Trim();
            objEnUsuario.materno = txt_materno.Text.Trim();
            objEnUsuario.nombre1 = txt_nombre1.Text.Trim();
            objEnUsuario.dni = txt_dni.Text.Trim();
            objEnUsuario.Password = txt_PASSWORD1.Text.Trim();

            objEnUsuario.CEmpresa = cmb_Empresa.SelectedValue.ToString(); //(String)this.Session["cempresa"];

            if (cmb_JerarquiaA.SelectedValue.ToString() == "") { comboNivelA = "0"; } else { comboNivelA = cmb_JerarquiaA.SelectedValue.ToString();}
            if (cmb_JerarquiaB.SelectedValue.ToString() == "") { comboNivelB = "0"; } else { comboNivelB = cmb_JerarquiaB.SelectedValue.ToString(); }
            if (cmb_JerarquiaC.SelectedValue.ToString() == "") { comboNivelC = "0"; } else { comboNivelC = cmb_JerarquiaC.SelectedValue.ToString(); }
            if (cmb_JerarquiaD.SelectedValue.ToString() == "") { comboNivelD = "0"; } else { comboNivelD = cmb_JerarquiaD.SelectedValue.ToString(); }


            objEnUsuario.cod_jerarquiaA = comboNivelA;
            objEnUsuario.cod_jerarquiaB = comboNivelB;
            objEnUsuario.cod_jerarquiaC = comboNivelC;
            objEnUsuario.cod_jerarquiaD = comboNivelD;

            objEnUsuario.id_ejecutores = cmb_Ejecutores.SelectedValue.ToString();




            ListEnUsuario.Add(objEnUsuario);
            #endregion Cargar_Variables

            List<EnTransaccion> RetornoT = ObjLoUsuario.Insertar_Usuario(ListEnUsuario);

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

        string comboNivelA = "";
        string comboNivelB = "";
        string comboNivelC = "";
        string comboNivelD = "";

        LoUsuario objLoUsuario = new LoUsuario();

        try
        {

            #region Carga_Variables
            List<EnUsuario> ListEnUsuario = new List<EnUsuario>();
            EnUsuario objEnUsuario = new EnUsuario();

            objEnUsuario.login3 = txt_LOGIN.Text.Trim();
            objEnUsuario.id = hd_IDUSUARIO.Value;
            objEnUsuario.CEmpresa = cmb_Empresa.SelectedValue.ToString();  //(String)this.Session["cempresa"];
            objEnUsuario.Sbloqueado = cmb_SBLOQUEADO.SelectedValue.ToString();
            objEnUsuario.codUsuario = (String)this.Session["codusuario"];
            objEnUsuario.email = txt_EMAIL.Text.Trim();
            objEnUsuario.paterno = txt_paterno.Text.Trim();
            objEnUsuario.materno = txt_materno.Text.Trim();
            objEnUsuario.nombre1 = txt_nombre1.Text.Trim();
            objEnUsuario.dni = txt_dni.Text.Trim();

            if (cmb_JerarquiaA.SelectedValue.ToString() == "") { comboNivelA = "0"; } else { comboNivelA = cmb_JerarquiaA.SelectedValue.ToString(); }
            if (cmb_JerarquiaB.SelectedValue.ToString() == "") { comboNivelB = "0"; } else { comboNivelB = cmb_JerarquiaB.SelectedValue.ToString(); }
            if (cmb_JerarquiaC.SelectedValue.ToString() == "") { comboNivelC = "0"; } else { comboNivelC = cmb_JerarquiaC.SelectedValue.ToString(); }
            if (cmb_JerarquiaD.SelectedValue.ToString() == "") { comboNivelD = "0"; } else { comboNivelD = cmb_JerarquiaD.SelectedValue.ToString(); }


            objEnUsuario.cod_jerarquiaA = comboNivelA;
            objEnUsuario.cod_jerarquiaB = comboNivelB;
            objEnUsuario.cod_jerarquiaC = comboNivelC;
            objEnUsuario.cod_jerarquiaD = comboNivelD;

            objEnUsuario.id_ejecutores = cmb_Ejecutores.SelectedValue.ToString();

            ListEnUsuario.Add(objEnUsuario);
            #endregion Carga_Variables

            msg = objLoUsuario.Modifica_Usuario(ListEnUsuario); // Modifica


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
        MostrarMensaje("El registro No se puede Anular.", true);
    }
    #endregion Datos
    #region Modificar_Password
    private bool Valida_ModificaPass()
    {
        if (txt_MODIFICAPASS1.Text.Length < 5)
        {
            MostrarMensaje("Ingrese Password correctamente. ( mas de 5 caracteres)", true);
            Cursor_Control(txt_MODIFICAPASS1);
            return false;
        }

        if (txt_MODIFICAPASS2.Text.Length < 5)
        {
            MostrarMensaje("Ingrese Password correctamente. ( mas de 5 caracteres)", true);
            Cursor_Control(txt_MODIFICAPASS2);
            return false;
        }

        if (txt_MODIFICAPASS1.Text != txt_MODIFICAPASS2.Text)
        {
            MostrarMensaje("Confirmacion de Password no coincide.", true);
            Cursor_Control(txt_MODIFICAPASS2);
            return false;
        }
        return true;
    }
    protected void btn_MODIFICARPASS_Click(object sender, EventArgs e)
    {
        //****************************************************************************************
        //* Nomre       :btn_MODIFICARPASS_Click 
        //* DescripcioN :
        //****************************************************************************************
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
        bool continuar;
        bool.TryParse(Request.Form["hdnContinuar"], out continuar);
        if (continuar)
        {
            //VALIDACION
            if (Valida_ModificaPass() == false)  //VALIDA
            {
                return;
            }
            Modifica_Password();  // Modifica Password                
        }
        else
        {
            MostrarMensaje(Mensaje.M_OPERACION_CANCELADA, true);
        }
    }
    protected void btn_CANCELAMODIFICARPASS_Click(object sender, EventArgs e)
    {
        this.cpeDemo.Collapsed = true;
        this.cpeDemo.ClientState = "true";
        Bloqueo_personalizado();
        limpiarMensaje();
    }
    private void Modifica_Password()
    {
        //****************************************************************************************
        //* Nomre       : Modificar()
        //* DescripcioN :
        //****************************************************************************************
        LoUsuario objLoUsuario = new LoUsuario();
        string msg = "";
        string Exito = "";
        try
        {
            #region carga_variables
            EnUsuario objEnUsuario = new EnUsuario();
            List<EnUsuario> ListEnUsuario = new List<EnUsuario>();
            objEnUsuario.id = hd_IDUSUARIO.Value;
            objEnUsuario.login3 = txt_LOGIN.Text.Trim();
            objEnUsuario.CEmpresa = (String)this.Session["cempresa"];
            objEnUsuario.Password = EncriptaCadena(txt_MODIFICAPASS1.Text.Trim());
            objEnUsuario.PasswordNuevo = EncriptaCadena(txt_MODIFICAPASS2.Text.Trim());
            objEnUsuario.codUsuario = (String)this.Session["codusuario"];
            ListEnUsuario.Add(objEnUsuario);
            #endregion carga_variables
            msg = objLoUsuario.Actualizar_Password_Administrador(ListEnUsuario); // Modifica Pssword                       
            if (msg == "")
            {
                Exito = "si";
            }
        }
        catch (SqlException ex)
        {
            msg = HttpUtility.HtmlEncode(ex.Message);
            MostrarMensaje(msg, true);
            Exito = "no";
        }
        catch (Exception ex)
        {
            msg = HttpUtility.HtmlEncode(ex.Message);
            MostrarMensaje(msg, true);
            Exito = "no";
        }
        if (Exito == "si")
        {
            MostrarMensaje(" El Password se Modificó Correctamente.", false);
            this.cpeDemo.Collapsed = true;
            this.cpeDemo.ClientState = "true";
            Bloqueo_personalizado();
            upControles.Update();

        }
    }
    #endregion Modificar_Password
    #region Perfiles
    protected void cmb_IDPERFIL_SelectedIndexChanged(object sender, EventArgs e)
    {

        upControles.Update();
    }
    protected void lkb_Perfil_Click(object sender, EventArgs e)
    {

        if (hd_IDUSUARIO.Value == "")
        {
            MostrarMensaje("Debe grabar el Registro.", true);
            return;
        }

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


        string str_idUsuario = hd_IDUSUARIO.Value;
        string str_estadon = "&estado=" + str_paramestado;
        Response.Redirect("MantUsuarioPerfil.aspx?idusuario=" + str_idUsuario + str_estadon);
    }
    #endregion Perfiles

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
    #region MD5
    private string EncriptaCadena(string cadena)
    {
        try
        {
            LoEncripta Encrypta = new LoEncripta();
            string ce = "";
            ce = Encrypta.Cl_Encripta(cadena);
            return ce;
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message.ToString(), true);
            return "servicio caido";
        }
    }
    #endregion MD5


    protected void cmb_Ejecutores_SelectedIndexChanged(object sender, EventArgs e)
    {
        cmb_JerarquiaB.Items.Clear();
        cmb_JerarquiaC.Items.Clear();
        cmb_JerarquiaD.Items.Clear();
        CargaComboJerarquiaA_Ejecutores();
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
                lista.Value = dt.Rows[i]["cEmpresa_char"].ToString().Trim();
                lista.Text = dt.Rows[i]["dEmpresa"].ToString().Trim();
                cmb_Empresa.Items.Add(lista);
            }
        }
        catch (Exception excp)
        {
            throw excp;
        }
    }

}