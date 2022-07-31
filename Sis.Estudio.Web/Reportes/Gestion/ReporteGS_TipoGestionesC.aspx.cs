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

public partial class Reportes_Gestion_ReporteGS_TipoGestionesC : System.Web.UI.Page
{
    #region Definiciones

    dsGS_TipoGestiones dsReporte = new dsGS_TipoGestiones();
    rptReporteGS_TipoGestiones rptReporte = new rptReporteGS_TipoGestiones();

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

        ParameterDiscreteValue p1 = new ParameterDiscreteValue();



        p1.Value = (String)Request["descripcion"].ToString().Trim();
        

        dsReporte.Merge(ReturnDataSet(), false, System.Data.MissingSchemaAction.Ignore);
        rptReporte.SetDataSource(dsReporte);

        rptReporte.SetParameterValue("descripcion", p1);

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

        LoGS_TipoGestiones objLoGS_TipoGestiones = new LoGS_TipoGestiones();
        EnGS_TipoGestiones objEnGS_TipoGestiones = new EnGS_TipoGestiones();
        List<EnGS_TipoGestiones> ListEnGS_TipoGestiones = new List<EnGS_TipoGestiones>();

        string str_descripcion = (String)Request["descripcion"].ToString().Trim();

        objEnGS_TipoGestiones.Descripcion = str_descripcion;


        ListEnGS_TipoGestiones.Add(objEnGS_TipoGestiones);

        dt = objLoGS_TipoGestiones.GS_TipoGestiones_Lista(ListEnGS_TipoGestiones);

        ds.Tables.Add(dt.Copy());
        ds.Tables[0].TableName = "DTGS_TipoGestiones";
        return ds;
    }
    #endregion Funciones
}