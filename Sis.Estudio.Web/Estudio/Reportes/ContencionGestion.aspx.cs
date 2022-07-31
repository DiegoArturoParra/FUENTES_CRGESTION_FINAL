using System;
using System.Drawing;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Text;
using System.Data.SqlClient;
using System.IO;

using System.ServiceModel;
using AjaxControlToolkit;
using System.Xml;
using System.Xml.Xsl;
using Sis.Estudio.Entity;
using Sis.Estudio.Logic.MSSQL.Estudio;
public partial class Estudio_Reportes_ContencionGestion : System.Web.UI.Page
{
    #region Eventos
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Master.TituloModulo = "CONTENCIÓN TIPO DE GESTIÓN DE MOROSIDAD";
                InicioOperacion();
            }
        }
        catch (Exception ex)
        {
            Master.MostrarMensaje(ex.Message, TipoMensaje.Advertencia, ex);
        }
    }
    #region Botones
    protected void btn_Consultar_Click(object sender, EventArgs e)
    {
        try
        {

            if (Valida_Datos() == true)
            {
                Exportar();
            }

        }
        catch (Exception ex)
        {
            Master.MostrarMensaje(ex.Message.ToString(), TipoMensaje.Error);
        }
    }

    #endregion Botones
    #region Combo
    protected void cmb_Tramo_SelectedIndexChanged1(object sender, EventArgs e)
    {
        try
        {
            Master.OcultarMensaje();
            //LimpiarGrid();
        }
        catch (Exception ex)
        {
            Master.MostrarMensaje(ex.Message.ToString(), TipoMensaje.Error);
        }
    }
    protected void cmb_Agencia_SelectedIndexChanged1(object sender, EventArgs e)
    {
        try
        {
            Master.OcultarMensaje();
            //LimpiarGrid();
        }
        catch (Exception ex)
        {
            Master.MostrarMensaje(ex.Message.ToString(), TipoMensaje.Error);
        }
    }    
    protected void cmb_anio_SelectedIndexChanged1(object sender, EventArgs e)
    {
        try
        {
            Master.OcultarMensaje();
            //LimpiarGrid();
        }
        catch (Exception ex)
        {
            Master.MostrarMensaje(ex.Message.ToString(), TipoMensaje.Error);
        }
    }
    protected void cmb_TipoGestion_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Master.OcultarMensaje();
            //LimpiarGrid();
        }
        catch (Exception ex)
        {
            Master.MostrarMensaje(ex.Message.ToString(), TipoMensaje.Error);
        }
    }

   
    #endregion Combo
    #region Grid

    #endregion Grid

    #endregion Eventos
    #region Metodos
    protected void InicioOperacion()
    {
        try
        {
            Combo_Tramo();
            combo_Agencia();
            combo_Anio();
            combo_TipoGestion();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void Combo_Tramo()
    {
        DataTable dt;
        try
        {
            cmb_Tramo.Items.Clear();
            #region validacion
            #endregion validacion

            #region Carga_Variable
            List<EnContencionTramo> objListEn = new List<EnContencionTramo>();
            EnContencionTramo objEn = new EnContencionTramo();
            objEn.NEMPRESA = (String)this.Session[Global.NEmpresa].ToString();
            objListEn.Add(objEn);
            #endregion Carga_Variable
            #region Logica
            LoContencionTramo objLogica = new LoContencionTramo();
            dt = objLogica.ContencionTramo_Tramos_Lista(objListEn);
            #endregion Logica
            #region Todos
            ListItem listaTodos = new ListItem();
            listaTodos.Value = "0";
            listaTodos.Text = "-- Seleccione --";
            cmb_Tramo.Items.Add(listaTodos);
            #endregion Todos
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["Tramo"].ToString().Trim();
                lista.Text = dt.Rows[i]["Descrip"].ToString().Trim();
                cmb_Tramo.Items.Add(lista);
            }
        }
        catch (FaultException e)
        {
            throw e;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void combo_Agencia()
    {
        DataTable dt;
        try
        {

            cmb_Agencia.Items.Clear();
            #region validacion
            #endregion validacion

            #region Carga_Variable

            List<EnContencionGestion> objListEn = new List<EnContencionGestion>();
            EnContencionGestion objEn = new EnContencionGestion();
            objEn.NEMPRESA = (String)this.Session[Global.NEmpresa].ToString();
            objListEn.Add(objEn);
            #endregion Carga_Variable
            #region Logica

            LoContencionGestion objLogica = new LoContencionGestion();
            dt = objLogica.ContencionGestion_Sucursal_Listar(objListEn);
            #endregion Logica
            #region Todos
            ListItem listaTodos = new ListItem();
            listaTodos.Value = "0";
            listaTodos.Text = "-- Todos --";

            cmb_Agencia.Items.Add(listaTodos);
            #endregion Todos
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["CodSucursal"].ToString().Trim();
                lista.Text = dt.Rows[i]["Sucursal"].ToString().Trim();
                cmb_Agencia.Items.Add(lista);
            }
        }
        catch (FaultException e)
        {
            throw e;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    protected void combo_Anio()
    {
        DataTable dt;
        try
        {

            cmb_anio.Items.Clear();
            #region validacion
            #endregion validacion

            #region Carga_Variable
            List<EnContencionTramo> objListEn = new List<EnContencionTramo>();
            EnContencionTramo objEn = new EnContencionTramo();
            objEn.NEMPRESA = (String)this.Session[Global.NEmpresa].ToString();
            objListEn.Add(objEn);
            #endregion Carga_Variable
            #region Logica
            LoContencionTramo objLogica = new LoContencionTramo();
            dt = objLogica.ContencionTramo_Anios_Lista(objListEn);
            #endregion Logica
            #region Todos
            ListItem listaTodos = new ListItem();
            listaTodos.Value = "0";
            listaTodos.Text = "-- Seleccione --";
            cmb_anio.Items.Add(listaTodos);
            #endregion Todos
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["anio"].ToString().Trim();
                lista.Text = dt.Rows[i]["anio"].ToString().Trim();
                cmb_anio.Items.Add(lista);
            }
        }
        catch (FaultException e)
        {
            throw e;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    protected void combo_TipoGestion()
    {
        DataTable dt;
        try
        {


            cmb_TipoGestion.Items.Clear();
            #region validacion
            #endregion validacion

            #region Carga_Variable

            List<EnContencionGestion> objListEn = new List<EnContencionGestion>();
            EnContencionGestion objEn = new EnContencionGestion();
            objEn.NEMPRESA = (String)this.Session[Global.NEmpresa].ToString();
            objListEn.Add(objEn);
            #endregion Carga_Variable
            #region Logica

            LoContencionGestion objLogica = new LoContencionGestion();
            dt = objLogica.ContencionGestion_Listar();
            #endregion Logica
            #region Todos
            ListItem listaTodos = new ListItem();
            listaTodos.Value = "0";
            listaTodos.Text = "-- Seleccione --";

            cmb_TipoGestion.Items.Add(listaTodos);
            #endregion Todos
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["CodTipoGestion"].ToString().Trim();
                lista.Text = dt.Rows[i]["Descripcion"].ToString().Trim();
                cmb_TipoGestion.Items.Add(lista);
            }

        }
        catch (FaultException e)
        {
            throw e;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
   
    private void Exportar()
    {
        try
        {
            string str_Parametros = "";

            string str_tramo = "?tramo=" + cmb_Tramo.SelectedValue.Trim();
            string str_agencia = "&agencia=" + cmb_Agencia.SelectedValue.Trim();
            string str_anio = "&anio=" + cmb_anio.SelectedValue.Trim();

            string str_tramocod = "?tramocod=" + cmb_Tramo.SelectedValue.Trim();
            string str_tramodes = "&tramodes=" + cmb_Tramo.SelectedItem.Text.Trim();

            string str_agenciacod = "&agenciacod=" + cmb_Agencia.SelectedValue.Trim();
            string str_agenciades = "&agenciades=" + cmb_Agencia.SelectedItem.Text.Trim();

            string str_gestioncod = "&gestioncod=" + cmb_TipoGestion.SelectedValue.Trim();
            string str_gestiondes = "&gestiondes=" + cmb_TipoGestion.SelectedItem.Text.Trim();

            str_Parametros = str_tramocod + str_tramodes + str_agenciacod + str_agenciades + str_anio + str_gestioncod + str_gestiondes;
                                 
            string CONFIG = "'resizable = yes, scrollbars = yes, toolbar=no, height = 700, width = 900,left=200,top=100,status=yes, location=no, menubar=no'";
            StringBuilder sb = new StringBuilder();
            sb.Append("<script>var win=window.open('ContencionGestionC.aspx" + str_Parametros + "', 'Reporte', " + CONFIG + ");</script>");
            ScriptManager.RegisterStartupScript(this, typeof(Page), "ReporteAccion", sb.ToString(), false);
        }
        catch (Exception excp)
        {
            //MostrarMensaje(excp.ToString(), true);
        }
    }
    #endregion Metodos
    #region funciones
    private bool Valida_Datos()
    {

        if (cmb_Tramo.SelectedValue.ToString() == "0")
        {
            Master.MostrarMensaje("Seleccione un Tipo de Tramo", TipoMensaje.Advertencia);
            return false;
        }
        if (cmb_anio.SelectedValue.ToString() == "0")
        {
            Master.MostrarMensaje("Seleccione un Año", TipoMensaje.Advertencia);
            return false;
        }

        return true;
    }
    #endregion funciones    

}