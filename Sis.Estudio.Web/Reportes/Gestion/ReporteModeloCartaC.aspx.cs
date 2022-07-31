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

public partial class Reportes_Gestion_ReporteModeloCartaC : System.Web.UI.Page
{
    #region Definiciones

    dsModeloCarta dsReporte = new dsModeloCarta();
    rptReporteModeloCarta rptReporte = new rptReporteModeloCarta();

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
        ParameterDiscreteValue p2 = new ParameterDiscreteValue();

        p1.Value = (String)Request["IdReg_Gestion_Cobranza"].ToString().Trim();
        p2.Value = "Lima " + DateTime.Now.Day + " de " + Util.mes_en_letras(DateTime.Now.Month) + " del " + DateTime.Now.Year;

        dsReporte.Merge(ReturnDataSet(), false, System.Data.MissingSchemaAction.Ignore);
        rptReporte.SetDataSource(dsReporte);

        rptReporte.SetParameterValue("IdReg_Gestion_Cobranza", p1);
        rptReporte.SetParameterValue("fecha_actual", p2);

        System.IO.MemoryStream mystream = new System.IO.MemoryStream();
        mystream = (System.IO.MemoryStream)(rptReporte.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat));
        HttpContext.Current.Response.ClearContent();
        HttpContext.Current.Response.ClearHeaders();
        HttpContext.Current.Response.ContentType = "application/pdf";
        HttpContext.Current.Response.AddHeader("Content-Disposition", "inline; filename=Report.pdf");

        //rptReporte.PrintToPrinter(1, false, 0, 1);
        HttpContext.Current.Response.BinaryWrite(mystream.ToArray());
        //HttpContext.Current.Response.End();

    }
    private void ResponseExcel()
    {
        DataSet ds = new DataSet();
        ds = ReturnDataSet();

        if (ds != null)
        {
            dg.DataSource = ds.Tables[0];
            dg.DataBind();
            Exportar();
            return;
        }

    }
    private void Exportar()
    {
        //********************************************************************************
        //** Exportar : Ejecuta la  Exportatacion a documento Excel.
        //********************************************************************************

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

        LoGS_Gestion_Cobranza objLoGS_Gestion_Cobranza = new LoGS_Gestion_Cobranza();
        EnGS_Gestion_Cobranza objEnGS_Gestion_Cobranza = new EnGS_Gestion_Cobranza();
        List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza = new List<EnGS_Gestion_Cobranza>();

        string str_IdReg_Gestion_Cobranza = (String)Request["IdReg_Gestion_Cobranza"].ToString().Trim();
        //int str_Num_carta = int.Parse((String)Request["Num_carta"].ToString().Trim());
        string str_Id_carta = (String)Request["Id_carta"].ToString().Trim();
        string str_CodUsuario = (String)Request["CodUsuario"].ToString().Trim();

        objEnGS_Gestion_Cobranza.IdReg_Gestion_Cobranza = str_IdReg_Gestion_Cobranza;
        //objEnGS_Gestion_Cobranza.Num_carta = str_Num_carta;
        objEnGS_Gestion_Cobranza.id_carta = str_Id_carta;
        objEnGS_Gestion_Cobranza.CodUsuario = str_CodUsuario;


        ListEnGS_Gestion_Cobranza.Add(objEnGS_Gestion_Cobranza);
        dt = objLoGS_Gestion_Cobranza.GS_Gestion_Cobranza_Carta_Reg(ListEnGS_Gestion_Cobranza);
        ds.Tables.Add(dt.Copy());
        ds.Tables[0].TableName = "DTModeloCarta";
        return ds;
    }
    #endregion Funciones
}