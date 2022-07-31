using System;
using System.Text;
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
using CrystalDecisions.Web;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.ServiceModel;
using AjaxControlToolkit;
using System.Xml;
using System.Xml.Xsl;
using Sis.Estudio.Entity;
using Sis.Estudio.Logic.MSSQL.Estudio;
using System.Threading;
using Sis.Estudio.Logic.MSSQL.Gestion;
using System.Linq;
using System.Reflection;

public partial class Estudio_Reportes_RPT_Gestion_Ejecutores_Nivel3C : System.Web.UI.Page
{
    dsGestionEjecutoresNivel3 dsReporte = new dsGestionEjecutoresNivel3();
    rptReporteGestionEjecutoresNivel3 rptReporte = new rptReporteGestionEjecutoresNivel3();
    protected void Page_Load(object sender, EventArgs e)
   {
        //****************************************************************************************
        //* Nomre       : Page_Load
        //* DescripcioN :
        //****************************************************************************************
       string str_tiporeporte = (String)Request["tiporeporte"];
       {
          
       }
       if (str_tiporeporte == "pdf")
       {
           
           ResponsePDF();
       }
       else if (str_tiporeporte == "excel")
       {
           ResponseExcel();
       }
   }

    #region Metodos
    private void ResponsePDF()
    {

        try
        {

            dsReporte.Merge(ReturnDataSet(), false, System.Data.MissingSchemaAction.Ignore);
            CrystalReportSource1.ReportDocument.SetDataSource(dsReporte);


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
        ParameterDiscreteValue p6 = new ParameterDiscreteValue();
        ParameterDiscreteValue p7 = new ParameterDiscreteValue();
        ParameterDiscreteValue p8 = new ParameterDiscreteValue();
        ParameterDiscreteValue p9 = new ParameterDiscreteValue();


        dsReporte.Merge(ReturnDataSet(), false, System.Data.MissingSchemaAction.Ignore);
        rptReporte.SetDataSource(dsReporte);




        p1.Value = (String)Request["nempresa"].ToString().Trim();
        p2.Value = (String)Request["codusureg"].ToString().Trim();
        p3.Value = (String)Request["sw"].ToString().Trim();
        p4.Value = (String)Request["fechaini"].ToString().Trim();
        p5.Value = (String)Request["fechafin"].ToString().Trim();
        p6.Value = (String)Request["idstgescob"].ToString().Trim();
        p7.Value = (String)Request["codtges"].ToString().Trim();
        p8.Value = (String)Request["anio"].ToString().Trim();
        p9.Value = (String)Request["mes"].ToString().Trim();





        System.IO.MemoryStream mystream = new System.IO.MemoryStream();
        mystream = (System.IO.MemoryStream)(rptReporte.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat));
        HttpContext.Current.Response.ClearContent();
        HttpContext.Current.Response.ClearHeaders();
        HttpContext.Current.Response.ContentType = "application/pdf";
        HttpContext.Current.Response.AddHeader("Content-Disposition", "inline; filename=Report.pdf");

        HttpContext.Current.Response.BinaryWrite(mystream.ToArray());
        HttpContext.Current.Response.End();


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

        dt = objLogica.RPT_Gestion_Ejecutores_Nivel3(ListEntidad);

        ds.Tables.Add(dt.Copy());
        ds.Tables[0].TableName = "RPT_Gestion_sp_Ejecutores_Nivel3";

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



