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

public partial class Estudio_Reportes_ReporteRecuperacionGestionAsesores_Nivel2C : System.Web.UI.Page
{
    #region Definiciones
    dsRecuperacionGestionAsesores_Nivel2 dsReporte = new dsRecuperacionGestionAsesores_Nivel2();
    rptReporteRecuperacionGestionAsesores_Nivel2 rptReporte = new rptReporteRecuperacionGestionAsesores_Nivel2();

    #endregion Definiciones
    #region Eventos
    protected void Page_Load(object sender, EventArgs e)
    {
        //****************************************************************************************
        //* Nomre       : Page_Load
        //* DescripcioN :
        //****************************************************************************************

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
    #endregion Eventos
    #region Metodos


    private void ResponsePDF()
    {


        dsReporte.Merge(ReturnDataSet(), false, System.Data.MissingSchemaAction.Ignore);
        rptReporte.SetDataSource(dsReporte);

        string str_nempresa = (String)Request["nempresa"];
        string str_codusureg = (String)Session["codusuario"].ToString();

        string str_anio = (String)Request["anio"];
        string str_mes = (String)Request["mes"];

        string str_rangodias = (String)Request["rangodias"];



        ParameterDiscreteValue p1 = new ParameterDiscreteValue();
        ParameterDiscreteValue p2 = new ParameterDiscreteValue();
        ParameterDiscreteValue p3 = new ParameterDiscreteValue();
        ParameterDiscreteValue p4 = new ParameterDiscreteValue();
        ParameterDiscreteValue p5 = new ParameterDiscreteValue();






        p1.Value = (String)Request["nempresa"].ToString().Trim();
        p2.Value = (String)Request["codusureg"].ToString().Trim();
        p3.Value = (String)Request["anio"].ToString().Trim();
        p4.Value = (String)Request["mes"].ToString().Trim();
        p5.Value = (String)Request["rangodias"].ToString().Trim();


        dsReporte.Merge(ReturnDataSet(), false, System.Data.MissingSchemaAction.Ignore);
        rptReporte.SetDataSource(dsReporte);




        System.IO.MemoryStream mystream = new System.IO.MemoryStream();
        mystream = (System.IO.MemoryStream)(rptReporte.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat));
        HttpContext.Current.Response.ClearContent();
        HttpContext.Current.Response.ClearHeaders();
        HttpContext.Current.Response.ContentType = "application/pdf";
        HttpContext.Current.Response.AddHeader("Content-Disposition", "inline; filename=Report.pdf");

        HttpContext.Current.Response.BinaryWrite(mystream.ToArray());
        HttpContext.Current.Response.End();

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
        strFichero = "Reporte.xls";
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
    private void ClearControls(Control control)
    {
        //********************************************************************************
        //**  ClearControls :  Ejecuta la limpieza de controles.
        //********************************************************************************
        for (int i = control.Controls.Count - 1; i >= 0; i--)
        {
            ClearControls(control.Controls[i]);
        }
        if (!(control is TableCell))
        {
            if (control.GetType().GetProperty("SelectedItem") != null)
            {
                LiteralControl literal = new LiteralControl();
                control.Parent.Controls.Add(literal);
                try
                {
                    literal.Text = (string)control.GetType().GetProperty("SelectedItem").GetValue(control, null);
                }
                catch
                {
                }
                control.Parent.Controls.Remove(control);
            }
            else
                if (control.GetType().GetProperty("Text") != null)
                {
                    LiteralControl literal = new LiteralControl();
                    control.Parent.Controls.Add(literal);
                    literal.Text = (string)control.GetType().GetProperty("Text").GetValue(control, null);
                    control.Parent.Controls.Remove(control);
                }
        }
        return;
    }
    #endregion Metodos
    #region Funciones
    private DataSet ReturnDataSet()
    {
        //****************************************************************************************
        //* Nomre       : ReturnDataSet
        //* DescripcioN :
        //****************************************************************************************
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        LoGS_Reportes objLogica = new LoGS_Reportes();
        EnGS_Reportes objEntidad = new EnGS_Reportes();
        List<EnGS_Reportes> ListEntidad = new List<EnGS_Reportes>();


        string str_nempresa = (String)Request["nempresa"];
        string str_codusureg = (String)Session["codusuario"].ToString();

        string str_anio = (String)Request["anio"];
        string str_mes = (String)Request["mes"];

        string str_rangodias = (String)Request["rangodias"];


        objEntidad.NEMPRESA = str_nempresa;
        objEntidad.CodUsuarioRegistra = str_codusureg;


        objEntidad.anio = str_anio.Trim();
        objEntidad.mes = str_mes.Trim();
        objEntidad.RangoDias = str_rangodias.Trim();

        ListEntidad.Add(objEntidad);

        dt = objLogica.RPT_Recuperacion_Ejecutores_Nivel2(ListEntidad);

        ds.Tables.Add(dt.Copy());
        ds.Tables[0].TableName = "RPT_Recuperacion_sp_Ejecutores_Nivel2";

        return ds;

    }
    #endregion Funciones
    protected void CrystalReportViewer1_Init(object sender, EventArgs e)
    {

    }
    protected void dg_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}