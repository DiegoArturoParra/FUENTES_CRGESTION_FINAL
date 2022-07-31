using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;
using System.IO;

using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Drawing;
using System.Text;
using System.Xml.Linq;
using Sis.Estudio.Entity;
using Sis.Estudio.Logic.MSSQL.Gestion;

public partial class Reportes_Gestion_GestionesInternas_Excel_GestionesUsuario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string str_tiporeporte = (String)Request["tiporeporte"];

        if (str_tiporeporte == "pdf")
        {
            ResponsePDF();
        }
        else if (str_tiporeporte == "excel")
        {
            ResponseExcel();

        }
    }
    private void ResponsePDF()
    {

    }

    private void ResponseExcel()
    {
        DataSet ds = new DataSet();
        ds = ReturnDataSet();
        dg.DataSource = ds.Tables[0];
        dg.DataBind();
        Exportar();
    }

    private void Exportar()
    {
        //********************************************************************************
        //** Exportar : Ejecuta la  Exportatacion a documento Excel.
        //********************************************************************************
        //export to excel

        string strFichero;
        strFichero = "ReporteGestionesInternas.xls";
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-Excel";
        Response.AppendHeader("content-disposition", "inline; filename=" + strFichero);

        Response.Charset = "UTF-8";
        Response.ContentEncoding = Encoding.Default;

        //Response.Charset = "";
        this.EnableViewState = false;
        System.IO.StringWriter oStringWriter = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter oHtmlTextWriter = new System.Web.UI.HtmlTextWriter(oStringWriter);
        //this.ClearControls(dg);
        dg.RenderControl(oHtmlTextWriter);
        Response.Write(oStringWriter.ToString());
        Response.End();
    }

    private DataSet ReturnDataSet()
    {
        //****************************************************************************************
        //* Nomre       : ReturnDataSet
        //* DescripcioN :
        //****************************************************************************************
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        LoGS_Gestion_Cobranza ObjLoGS_Gestion_Cobranza = new LoGS_Gestion_Cobranza();
        EnGS_Gestion_Cobranza ObjEnGS_Gestion_Cobranza = new EnGS_Gestion_Cobranza();
        List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza = new List<EnGS_Gestion_Cobranza>();

        string str_IdReg_Gestion_Cobranza = (String)Request["IdReg_Gestion_Cobranza"].ToString().Trim();

        ObjEnGS_Gestion_Cobranza.IdReg_Gestion_Cobranza = str_IdReg_Gestion_Cobranza;

        /*Modif. Gestiones Internas 15/06/17*/
        string cempresa = (String)this.Session["cempresa"];
        ObjEnGS_Gestion_Cobranza.nEmpresa = cempresa;
        /*Fin Modif.*/

        ListEnGS_Gestion_Cobranza.Add(ObjEnGS_Gestion_Cobranza);
        dt = ObjLoGS_Gestion_Cobranza.GS_Gestion_Cobranza_GestionesInternas_Registro(ListEnGS_Gestion_Cobranza);


        ds.Tables.Add(dt.Copy());
        ds.Tables[0].TableName = "DTModeloCarta";
        return ds;



    }


    protected void dg_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}