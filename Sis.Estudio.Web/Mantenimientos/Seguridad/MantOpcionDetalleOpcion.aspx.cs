using System;
using System.Drawing;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.IO;
using Sis.Estudio.Entity;
using Sis.Estudio.Logic.MSSQL.Seguridad;
public partial class Mantenimientos_Seguridad_MantOpcionDetalleOpcion : System.Web.UI.Page
{
    public string mstrEstado;
    #region Eventos
    protected void Page_Load(object sender, EventArgs e)
    {
        #region windows_mod
        Response.Expires = 0;
        Response.AddHeader("pragma", "no-cache");
        Response.AddHeader("cache-control", "private");
        Response.CacheControl = "no-cache";
        #endregion windows_mod
        if (!IsPostBack)
        {
            Master.TituloModulo = "Detalle Opcion";
            InicioOperacion();
        }
    }
    protected void btn_GRABAR_Click(object sender, EventArgs e)
    {
        //****************************************************************************************
        //* Nomre       :btnGrabar_Click 
        //* DescripcioN :
        //****************************************************************************************
        Master.OcultarMensaje();
        #region Sesion
        string cempresa = (String)this.Session["cempresa"]; ;
        if (cempresa == "" || cempresa == null)
        {
            this.Session.Abandon();
            Response.Redirect("../Login.aspx?rd=0");
            return;
        }
        #endregion Sesion
        string str_continuar = Request.Form["hdnContinuar"];
        if (str_continuar == "")
        {
            return;
        }
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
            Master.MostrarMensaje(Mensaje.M_OPERACION_CANCELADA, TipoMensaje.Advertencia);
        }
    }
    protected void btn_SALIR_Click(object sender, EventArgs e)
    {
        StringBuilder sb1 = new StringBuilder();
        sb1.Append("<script>");
        sb1.Append("window.returnValue = 1;");
        sb1.Append("window.close();");
        sb1.Append("</script>");
        ScriptManager.RegisterStartupScript(this, typeof(Page), "", sb1.ToString(), false);
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
            string str_idModulo = "";
            string str_idmenu = "";

            if (Request["str_estado"] != null)
            {
                str_Estado = Request["str_estado"];
            }

            if (str_Estado == "n")
            {
                #region idmodulo
                if (Request["idmodulo"] != null)
                {
                    str_idModulo = Request["idmodulo"];
                    hd_IDMODULO.Value = str_idModulo;
                    txt_DESMODULO.Text = Request["desmodulo"];
                    hd_IDMENU.Value = Request["idmenu"];

                }
                #endregion idmodulo
                metodo_agregar();
            }
            else if (str_Estado == "m")
            {
                str_ID = Request["id"];

                hd_ID.Value = str_ID;
                txt_ID.Text = str_ID;
                MostrarDatos(str_ID);
                metodo_modificar();
            }
        }
        catch (Exception ex)
        {
            Master.MostrarMensaje(ex.Message, TipoMensaje.Advertencia, ex);
        }
    }

    protected void metodo_agregar()
    {
        try
        {

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
            EnableControl(true);
            LimpiarControles();
            Cursor_Control(txt_NOMBRE);
        }
        catch (Exception ex)
        {
            Master.MostrarMensaje(ex.Message, TipoMensaje.Advertencia, ex);
        }
    }
    protected void metodo_modificar()
    {
        try
        {

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
            EnableControl(true);
            Cursor_Control(txt_NOMBRE);
        }
        catch (Exception ex)
        {
            Master.MostrarMensaje(ex.Message, TipoMensaje.Advertencia, ex);
        }
    }
    protected void LimpiarControles()
    {
        //****************************************************************************************
        //* Nomre       : LimpiarControles() 
        //* DescripcioN : limpia controles.
        //****************************************************************************************        
        txt_NOMBRE.Text = String.Empty;

    }
    protected void MostrarDatos(string str_ID)
    {
        //****************************************************************************************
        //* Nombre      : MostrarDatos
        //* DescripcioN :
        //*                                                                     
        //****************************************************************************************
        try
        {
            Master.OcultarMensaje();

            LimpiarControles();
            DataTable dt = new DataTable();


            LoOpcion objLoOpcion = new LoOpcion();
            List<EnOpcion> ListEnOpcion = new List<EnOpcion>();
            EnOpcion objEnOpcion = new EnOpcion();

            objEnOpcion.CEmpresa = (String)this.Session["cempresa"];
            objEnOpcion.IdOpcion = str_ID;

            ListEnOpcion.Add(objEnOpcion);

            dt = objLoOpcion.MostrarDatos_Opcion(ListEnOpcion);

            if (dt.Rows.Count > 0)
            {
                #region CONTROLES_MANTENIMIENTO
                txt_DESMODULO.Text = dt.Rows[0]["DesModulo"].ToString();
                txt_NOMBRE.Text = dt.Rows[0]["Nombre"].ToString();
                txt_DESCRIPCION.Text = dt.Rows[0]["Url"].ToString().Trim();
                hd_IDMODULO.Value = dt.Rows[0]["IdModulo"].ToString();
                txt_TOPLISTADO.Text = dt.Rows[0]["TopListado"].ToString();
                #endregion CONTROLES_MANTENIMIENTO
                #region CONTROLES_INFORMATIVOS

                #endregion CONTROLES_INFORMATIVOS
            }

            upControles.Update();

        }
        catch (Exception excp)
        {
            throw excp;
        }
    }
    protected void Cursor_Control(TextBox Nombre_Control)
    {
        //****************************************************************************************
        //* Nomre       : SetFocus()                         NSE 04/DICIEMBRE/2009
        //****************************************************************************************
        try
        {
            ScriptManager scriptManager1 = ScriptManager.GetCurrent(this.Page);
            scriptManager1.SetFocus(Nombre_Control);
        }
        catch
        {
            return;
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

        txt_NOMBRE.Enabled = dato;
        txt_DESCRIPCION.Enabled = dato;

        //==== botones ====//   
        //panelbtnBuscaBanco.Visible = dato;	    //Los controles panel contienen un control boton html por lo tanto se usa la propiedad visible

        upControles.Update();
    }
    #endregion Metodos
    #region funciones
    private bool Valida_Datos()
    {
        //****************************************************************************************
        //* Nomre       : Valida_Datos
        //* DescripcioN :
        //****************************************************************************************

        //if (hd_ID.Value == "")
        //{
        //    Master.MostrarMensaje(Mensaje.M_VALIDACION_DEFINICION_ID, TipoMensaje.Advertencia);
        //    return false;
        //}


        return true;
    }
    #endregion funciones
    #region Datos
    private void Grabar()
    {
        //****************************************************************************************
        //* Nomre       : Grabar
        //* DescripcioN :
        //****************************************************************************************

        LoOpcion objLoOpcion = new LoOpcion();
        string msg = "";
        string Exito = "";
        try
        {
            #region Carga_Variable
            List<EnOpcion> ListEnOpcion = new List<EnOpcion>();
            EnOpcion objEnOpcion = new EnOpcion();
            

            objEnOpcion.IdModulo = hd_IDMODULO.Value; // IdModulo                
            objEnOpcion.CEmpresa =  (String)this.Session["cempresa"];
            objEnOpcion.Nombre = txt_NOMBRE.Text.Trim();
            objEnOpcion.url = txt_DESCRIPCION.Text.Trim();            
            objEnOpcion.CodUsuario = (String)this.Session["codusuario"];
            objEnOpcion.IdOpcionPadre =  hd_IDMENU.Value;
            objEnOpcion.TopListado = txt_TOPLISTADO.Text.Trim();

            ListEnOpcion.Add(objEnOpcion);
            #endregion Carga_Variable

            msg = objLoOpcion.Insertar_OpcionOpcion(ListEnOpcion);


            if (msg == "") { Exito = FlagsPrograma.FLG_VALOREXITOSI; } else { Master.MostrarMensaje(msg, TipoMensaje.Error, msg); Exito = FlagsPrograma.FLG_VALOREXITONO; return; }

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
            EnableControl(false);

            //MostrarDatos("2", "0");
            Master.MostrarMensaje(Mensaje.M_REGISTRO_CORRECTO, TipoMensaje.Exito);
            upControles.Update();
        }
    }

    private void Modificar()
    {
        //****************************************************************************************
        //* Nomre       : Grabar
        //* DescripcioN :
        //****************************************************************************************
        LoOpcion objLoOpcion = new LoOpcion();
        string msg = "";
        string Exito = "";
        try
        {
            #region Carga_Variable            
            List<EnOpcion> ListEnOpcion = new List<EnOpcion>();
            EnOpcion objEnOpcion = new EnOpcion();
       
            objEnOpcion.IdModulo = hd_IDMODULO.Value; // IdModulo
            objEnOpcion.CEmpresa = (String)this.Session["cempresa"];
            objEnOpcion.Nombre = txt_NOMBRE.Text.Trim();
            objEnOpcion.url = txt_DESCRIPCION.Text.Trim();
            objEnOpcion.CodUsuario = (String)this.Session["codusuario"];
            objEnOpcion.IdOpcion = hd_ID.Value;
            objEnOpcion.TopListado = txt_TOPLISTADO.Text.Trim();

            ListEnOpcion.Add(objEnOpcion);
            #endregion Carga_Variable

            msg = objLoOpcion.Modifica_OpcionOpcion(ListEnOpcion);
            if (msg == "") { Exito = FlagsPrograma.FLG_VALOREXITOSI; } else { Master.MostrarMensaje(msg, TipoMensaje.Error, msg); Exito = FlagsPrograma.FLG_VALOREXITONO; return; }

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
            EnableControl(false);

            //MostrarDatos("2", "0");
            Master.MostrarMensaje("El registro se Actualizó Correctamente.", TipoMensaje.Exito);
            upControles.Update();
        }
    }



    #endregion Datos
}