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

public partial class Estudio_Gestion_01FrmDatosCliente : System.Web.UI.Page
{
    #region Eventos
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Inicio();                               
                //btn_Calcular.Attributes.Add("onClick", "document.getElementById('hdnContinuar').value = confirm('Se procesará el cálculo, ¿Desea continuar?');");                
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
    protected void btn_Modificar_Click(object sender, EventArgs e)
    {
        Response.Redirect("01FrmDatosClienteDet.aspx");
    }

    #endregion Botones
    #endregion Eventos
    #region Metodos
    protected void Inicio()
    {
        try
        {       
            MostrarDatos((String)this.Session[Global.CodCliente]);
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
                lbl_CodigoCliente.Text = dt.Rows[0]["CodigoCliente"].ToString();
                lbl_CodigoSBS.Text = dt.Rows[0]["CodigoSBS"].ToString();
                lbl_DNI.Text = dt.Rows[0]["DNI"].ToString();
                lbl_RUC.Text = dt.Rows[0]["RUC"].ToString();

                lbl_ApePat.Text = dt.Rows[0]["ApePat"].ToString();
                lbl_ApeMat.Text = dt.Rows[0]["ApeMat"].ToString();
                lbl_Nombres.Text = dt.Rows[0]["Nombres"].ToString();

                lbl_TipoPersona.Text = dt.Rows[0]["TipoPersona"].ToString();
                lbl_StatusLab.Text = dt.Rows[0]["StatusLab"].ToString();               
                lbl_RazonSocial.Text = dt.Rows[0]["RazonSocial"].ToString();

                lbl_Profesion.Text = dt.Rows[0]["Profesion"].ToString();
                lbl_EstCivil.Text = dt.Rows[0]["EstCivil"].ToString();

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
}