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

public partial class Reportes_Reportes_ReporteGestionEjecutoresC : System.Web.UI.Page
{
    #region Definiciones
    dsGestionEjecutores dsReporte = new dsGestionEjecutores();
    rptReporteGestionEjecutores rptReporte = new rptReporteGestionEjecutores();

    #endregion Definiciones
    #region Eventos
    protected void Page_Load(object sender, EventArgs e)
    {
        //****************************************************************************************
        //* Nomre       : Page_Load
        //* DescripcioN :
        //****************************************************************************************

        string str_tiporeporte = (String)Request["tiporerporte"];

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


        string str_Periodo = "";

        string str_nempresa = (String)Request["nempresa"];
        string str_codusureg = (String)Request["codusureg"];
        string str_sw = (String)Request["sw"];
        string str_fechaini = (String)Request["fechaini"];
        string str_fechafin = (String)Request["fechafin"];
        string str_idstgescob = (String)Request["idstgescob"];
        string str_codtges = (String)Request["codtges"];
        string str_anio = (String)Request["anio"];
        string str_mes = (String)Request["mes"];
        string str_asesor = (String)Request["asesor"];


        #region Periodo
        if (str_sw == "1")
        {
            str_Periodo = str_anio + " - " + str_mes;
        }
        else
        {
            str_Periodo = "Del : " + str_fechaini.Trim() + " al : " + str_fechafin.Trim();
        }


        #endregion Periodo


        ParameterDiscreteValue p1 = new ParameterDiscreteValue();
        ParameterDiscreteValue p2 = new ParameterDiscreteValue();
        ParameterDiscreteValue p3 = new ParameterDiscreteValue();
        ParameterDiscreteValue p4 = new ParameterDiscreteValue();
        ParameterDiscreteValue p5 = new ParameterDiscreteValue();

        p1.Value = "REPORTE GESTION DE ASESORES";
        p2.Value = str_asesor;
        p3.Value = str_Periodo;

        dsReporte.Merge(ReturnDataSet(), false, System.Data.MissingSchemaAction.Ignore);
        rptReporte.SetDataSource(dsReporte);

        rptReporte.SetParameterValue("titulo", p1);
        rptReporte.SetParameterValue("asesor", p2);
        rptReporte.SetParameterValue("periodo", p3);


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

        //string str_codidenest = (String)this.Session["codidenest"];
        string str_nempresa = (String)Request["nempresa"];
        string str_codusureg = (String)Request["codusureg"];
        string str_sw = (String)Request["sw"];
        string str_fechaini = (String)Request["fechaini"];
        string str_fechafin = (String)Request["fechafin"];
        string str_idstgescob = (String)Request["idstgescob"];
        string str_codtges = (String)Request["codtges"];
        string str_anio = (String)Request["anio"];
        string str_mes = (String)Request["mes"];
        string str_asesor = (String)Request["asesor"];

        objEntidad.NEMPRESA = str_nempresa;
        objEntidad.CodUsuarioRegistra = str_codusureg;
        objEntidad.sw = str_sw;
        objEntidad.fecha_ini = str_fechaini;
        objEntidad.fecha_fin = str_fechafin;
        objEntidad.Id_Estado_Gestion_Cobranza = str_idstgescob;
        objEntidad.CodTipoGestion = str_codtges;
        objEntidad.anio = str_anio.Trim();
        objEntidad.mes = str_mes.Trim();

        ListEntidad.Add(objEntidad);

        dt = objLogica.RPT_Gestion_Ejecutores(ListEntidad);

        ds.Tables.Add(dt.Copy());
        ds.Tables[0].TableName = "DTGestionEjecutores";

        return ds;

    }
    #endregion Funciones
}