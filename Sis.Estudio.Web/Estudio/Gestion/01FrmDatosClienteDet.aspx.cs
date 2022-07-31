using System;
using acetsoft;
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
using Sis.Estudio.Logic.MSSQL.Estudio;
using Sis.Estudio.Entity;

public partial class Estudio_Gestion_01FrmDatosClienteDet : System.Web.UI.Page
{

    #region Eventos
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Inicio();
                btn_Grabar.Attributes.Add("onClick", "document.getElementById('hdnContinuar').value = confirm('¿Se guardara el registro, ¿Desea continuar?');");
            }
        }
        catch (Exception ex)
        {
            Master.MostrarMensaje(ex.Message.ToString(), TipoMensaje.Error);            
        }
    }
    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        #region Redim
        string idifame = AcetPanel.DatosCliente.iframe_id;
        #region ResizeFicha
        StringBuilder sb = new StringBuilder();
        sb.Append("<script>");
        sb.Append("ResizeFicha('" + idifame + "');");
        sb.Append("</script>");
        ScriptManager.RegisterStartupScript(this, typeof(Page), "", sb.ToString(), false);
        #endregion ResizeFicha
        #endregion Redim
    }
    #region Botones
    protected void btn_Grabar_Click(object sender, EventArgs e)
    {
        try
        {

            Master.OcultarMensaje();
            bool continuar;
            bool.TryParse(Request.Form["hdnContinuar"], out continuar);
            if (continuar)
            {
                if (Valida_Datos() == false)  //VALIDA
                {
                    return;
                }
                //string estado = (String)ViewState["estado"];
                //if (estado == "agregar")
                //{
                //    Graba();  // GRABA
                //}

                //if (estado == "modificar")
                //{
                //    Modifica();  // ACTUALIZA
                //}

                Modifica();

            }
            else
            {
                Master.MostrarMensaje(Mensaje.M_OPERACION_CANCELADA, TipoMensaje.Advertencia);
            }

        }
        catch (Exception ex)
        {
            Master.MostrarMensaje(ex.Message.ToString(), TipoMensaje.Error);
        }
    }
    protected void btn_Retornar_Click(object sender, EventArgs e)
    {
        Response.Redirect("01FrmDatosCliente.aspx");
    }
    #endregion Botones

    #region Combos
    protected void cmb_TipoPersona_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void cmb_EstadoCivil_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void cmb_StatusLaboral_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    #endregion Combos

    #endregion Eventos
    #region Metodos
    protected void Inicio()
    {
        try
        {
            Combo_TipoPersona();
            Combo_EstadoCivil();
            Combo_StatusLaboral();

            MostrarDatos((String)this.Session[Global.CodCliente]);
            
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void Combo_TipoPersona()
    {
        DataTable dt = new DataTable();
        try
        {
            cmb_TipoPersona.Items.Clear();

            LoAplicacion objLo = new LoAplicacion();
            dt = objLo.Aplicacion_TipoPersona_Lista();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["CodTipoPersona"].ToString().Trim();
                lista.Text = dt.Rows[i]["TipoPersona"].ToString().Trim();
                
                cmb_TipoPersona.Items.Add(lista);
                
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void Combo_EstadoCivil()
    {
        DataTable dt = new DataTable();
        try
        {
            cmb_EstadoCivil.Items.Clear();
            LoAplicacion objLo = new LoAplicacion();
            dt = objLo.Aplicacion_EstadoCivil_Lista();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["CodEstCivil"].ToString().Trim();
                lista.Text = dt.Rows[i]["EstCivil"].ToString().Trim();

                cmb_EstadoCivil.Items.Add(lista);

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void Combo_StatusLaboral()
    {
        DataTable dt = new DataTable();
        try
        {


            cmb_StatusLaboral.Items.Clear();

            LoAplicacion objLo = new LoAplicacion();
            dt = objLo.Aplicacion_StatusLaboral_Lista();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["CodStatusLab"].ToString().Trim();
                lista.Text = dt.Rows[i]["StatusLab"].ToString().Trim();

                cmb_StatusLaboral.Items.Add(lista);

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void MostrarDatos(string str_Codigo)
    {
        DataTable dt = new DataTable();
        try
        {
            Master.OcultarMensaje();
            

            #region Validacion
            if (str_Codigo.Trim().Length < 1)
            {
                return;
            }
            #endregion Validacion

            #region Carga_Variable
            List<EnDatosCliente> List = new List<EnDatosCliente>();
            EnDatosCliente objEn = new EnDatosCliente();
            objEn.NEMPRESA = (String)this.Session[Global.NEmpresa];
            objEn.CodigoCliente = str_Codigo;
            List.Add(objEn);
            #endregion Carga_Variable

            LoDatosCliente objLo = new LoDatosCliente();

            dt = objLo.DatosCliente_Lista_Reg(List);

            if (dt.Rows.Count > 0)
            {
                #region CONTROLES_MANTENIMIENTO
                txt_CodigoCliente.Text = dt.Rows[0]["CodigoCliente"].ToString();
                txt_CodigoSBS.Text = dt.Rows[0]["CodigoSBS"].ToString();
                txt_DNI.Text = dt.Rows[0]["DNI"].ToString();
                txt_RUC.Text = dt.Rows[0]["RUC"].ToString();

                txt_ApePat.Text = dt.Rows[0]["ApePat"].ToString();
                txt_ApeMat.Text = dt.Rows[0]["ApeMat"].ToString();
                txt_Nombres.Text = dt.Rows[0]["Nombres"].ToString();

                cmb_TipoPersona.SelectedValue = dt.Rows[0]["TipoPersona"].ToString();
                cmb_StatusLaboral.SelectedValue = dt.Rows[0]["CodStatusLab"].ToString();

                txt_RazonSocial.Text = dt.Rows[0]["RazonSocial"].ToString();

                txt_Profesion.Text = dt.Rows[0]["Profesion"].ToString();
                cmb_EstadoCivil.SelectedValue = dt.Rows[0]["CodEstCivil"].ToString();

                #endregion CONTROLES_MANTENIMIENTO

                #region CONTROLES_INFORMATIVOS
                #endregion CONTROLES_INFORMATIVOS
            }
        }
        catch (Exception excp)
        {
            throw excp;
        }
    }
    #endregion Metodos
    #region Datos
    private void Modifica()
    {
        try
        {
            string msg = "";
            #region Carga_Variable

            List<EnDatosCliente> List = new List<EnDatosCliente>();
            EnDatosCliente objEn= new EnDatosCliente();
            objEn.NEMPRESA = (String)Session[Global.NEmpresa].ToString();
            objEn.CodigoCliente = (String)Session[Global.CodCliente].ToString();

            objEn.CodigoSBS = txt_CodigoSBS.Text.Trim();
            objEn.DNI = txt_DNI.Text.Trim();
            objEn.RUC = txt_RUC.Text.Trim();
            objEn.ApePat = txt_ApePat.Text.Trim();
            objEn.ApeMat = txt_ApeMat.Text.Trim();
            objEn.Nombres = txt_Nombres.Text.Trim();
            objEn.CodTipoPersona = cmb_TipoPersona.SelectedValue.Trim();
            objEn.CodStatusLab = cmb_StatusLaboral.SelectedValue.Trim();
            objEn.RazonSocial = txt_RazonSocial.Text.Trim();
            objEn.Profesion = txt_Profesion.Text.Trim();
            objEn.CodEstCivil = cmb_EstadoCivil.SelectedValue.Trim();

            List.Add(objEn);
            #endregion Carga_Variable

            LoDatosCliente objLo = new LoDatosCliente();
            msg = objLo.DatosCliente_UPD(List);

            if (msg == "exito")
            {
                Master.MostrarMensaje(Mensaje.M_OPERACION_SATISFACTORIA, TipoMensaje.Exito);

            }
        }

        catch (Exception ex)
        {
            throw ex;
        }
    }    
    #endregion Datos
    #region funciones
    private bool Valida_Datos()
    {
        //string estado = (String)ViewState["estado"];
        //if (estado == "modificar")
        //{
        //    if (hd_Codigo.Value == "")
        //    {
        //        Master.MostrarMensaje(Mensaje.M_VALIDACION_DEFINICION_ID, TipoMensaje.Advertencia);
        //        return false;
        //    }
        //}

        //if (txt_IdGrupo1.Text.Trim().Length > 0)
        //{
        //    //if (Util.esNumero(txt_IdTipoControl.Text.Trim()) == false)
        //    //{
        //    //    Master.MostrarMensaje("Ingrese Numeros", TipoMensaje.Advertencia);
        //    //    Cursor_Control(txt_IdTipoControl);
        //    //    return false;
        //    //}
        //}

        return true;
    }
    #endregion funciones

}