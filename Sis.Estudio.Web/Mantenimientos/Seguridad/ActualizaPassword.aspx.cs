using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Reflection;
using System.Drawing;
using System.Text;
using System.Xml.Linq;
using System.IO;
using System.Data.SqlClient;
using IABaseWeb;
using Sis.Estudio.Logic.MSSQL.Seguridad;
using Sis.Estudio.Entity;



public partial class Mantenimientos_Seguridad_ActualizaPassword : System.Web.UI.Page
{
    #region Declaraciones
    //private string PaginaDetalle = "SGOCierreDetalle.aspx";
    private const string PaginaRetorno = "";
    #endregion  Declaraciones
    #region Eventos_Form

    #region Seleccionar
    protected override void Render(System.Web.UI.HtmlTextWriter writer)
    {
        base.Render(writer);
    }
    #endregion Seleccionar

    protected void Page_Load(object sender, EventArgs e)
    {

        //IABaseAsginaControles();
        //btnBuscar.Focus();
        if (!Page.IsPostBack)
        {
            //G_idopcion = OpcionModulo.MantModulo;
            this.Master.TituloModulo = "Cambio de Contraseña";
            #region accesos
            //Accesos();
            #endregion accesos
            btnProcesar.Attributes.Add("onClick", "document.getElementById('hdnContinuar').value = confirm('¿Se Cambiará la contraseña, ¿Desea continuar?');");
            //Cargar_Modulos();
            #region accesos
            //Accesos();
            #endregion accesos
            //ConfiguracionInicial();

        }
        //upBotonera.Update();
    }
    #endregion Eventos_Form
    #region ToolBar
    protected void btnProcesar_Click(object sender, EventArgs e)
    {


        bool continuar;
        bool.TryParse(Request.Form["hdnContinuar"], out continuar);
        if (continuar)
        {

                Procesar();

        }
        else
        {
            Master.MostrarMensaje(Mensaje.M_OPERACION_CANCELADA, TipoMensaje.Advertencia);
        }


    }




    #endregion ToolBar
    #region Limpiar_Filtro

    #endregion Limpiar_Filtro
    #region Datos


    private void Procesar()
    {
        
        
        //****************************************************************************************
        //* Nomre       : Grabar
        //* DescripcioN :
        //****************************************************************************************
       if (txt_clavenueva.Text == "" || txt_clavenueva2.Text == "" || txt_clave.Text == ""){
           
           Master.MostrarMensaje("Deben ingresar todos los campos.", TipoMensaje.Advertencia);

       }else{
                if (txt_clavenueva.Text == txt_clavenueva2.Text)
                {

                                    LoUsuario objLoUsuario = new LoUsuario();

                                    string msg = "";
                                    string Exito = "";
                                    try
                                    {
                                        #region Carga_Variable

                                        List<EnUsuario> ListEnUsuario = new List<EnUsuario>();
                                        EnUsuario objEnUsuario = new EnUsuario();

                                        objEnUsuario.login3 = (String)this.Session["login"];
                                        objEnUsuario.Password = txt_clave.Text.ToString();
                                        objEnUsuario.PasswordNuevo = txt_clavenueva.Text.ToString();
                                        objEnUsuario.id = (String)this.Session["codusuario"];




                                        ListEnUsuario.Add(objEnUsuario);
                                        #endregion Carga_Variable
                                        msg = objLoUsuario.Modifica_Password(ListEnUsuario);

                                        if (msg == "") { Exito = FlagsPrograma.FLG_VALOREXITOSI; } else { Master.MostrarMensaje(msg, TipoMensaje.Error, msg); Exito = FlagsPrograma.FLG_VALOREXITONO; return; }

                                        Exito = FlagsPrograma.FLG_VALOREXITOSI;
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
                                        Master.MostrarMensaje(Mensaje.M_PROCESO_CORRECTO, TipoMensaje.Exito);
                                    }

                }else{
                    Master.MostrarMensaje("Las contraseñas no coinciden.", TipoMensaje.Advertencia);
                }
       }


}

    #endregion Datos
    #region Metodos
    
    private string AccionStore()
    {
        string str_retorno;
        /* if (chk_TODOS.Checked)
         {
             str_retorno = AccionListado.Todos.ToString();
         }
         else
         {*/
        /*
        if (txt_login.Text.Length < 1)
        {*/
            str_retorno = AccionListado.Top.ToString();
        /*}
        else
        {
            str_retorno = AccionListado.Filtrado.ToString();
        }
         * */
        /*}*/

        return str_retorno;

    }



    #endregion Metodos
    #region UpdatePanel

    #endregion UpdatePanel
    #region AsignaControles
    #endregion AsignaControles
    #region AccesosAccion

    #endregion AccesosAccion

    #region Modulo

    #endregion Modulo

    #region Procedimientos
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
        
    }
    #endregion Procedimientos

    #region AccesosAccion
    protected void BloqueaAcciones()
    {
        try
        {

        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message.ToString(), true);
        }

    }
    protected void ActivaAccionesComunes()
    {

    }
    protected void ActivaAccion(string accion)
    {
        try
        {
            switch (accion)
            {

                case Accion.ExportaExcel:
                    //Propiedades_Boton(btnExcel, "excel");
                    break;

                case Accion.Imprimir:
                   //Propiedades_Boton(btnImprimir, "imprimir");
                    break;

            }
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message.ToString(), true);
        }
    }
    protected void Propiedades_Boton(ImageButton btn, string nombre)
    {
        btn.Enabled = true;
        btn.Attributes.Add("onMouseOver", "src='" + "../../Imagenes/" + nombre + "_over.png " + "'");
        btn.Attributes.Add("onMouseOut", "src='" + "../../Imagenes/" + nombre + "_out.png " + "'");
        btn.ImageUrl = "~/Imagenes/" + nombre + "_out.png";
        btn.ToolTip = nombre;
    }
    #endregion AccesosAccion            

}