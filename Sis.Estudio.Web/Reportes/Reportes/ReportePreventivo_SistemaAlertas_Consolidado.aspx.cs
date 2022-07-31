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
using Excel = Microsoft.Office.Interop.Excel;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Drawing;
using System.Text;
using System.Xml.Linq;
using Sis.Estudio.Entity;
using Sis.Estudio.Logic.MSSQL.Gestion;
using Sis.Estudio.Logic.MSSQL.Reportes;
using Microsoft.Office.Core;
using System.Windows.Forms;
using System.Globalization;


public partial class Reportes_Reportes_ReportePreventivo_SistemaAlertas_Consolidado : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string str_tiporeporte = (String)Request["tiporeporte"];
        if (str_tiporeporte == "excel")
        {
            ResponseExcel();
        }
    }

    private void ResponseExcel()
    {
        DataSet ds = new DataSet();
        ds = ReturnDataSet();

        //dg.DataSource = ds.Tables[0];
        //dg.DataBind();
        Exportar(ds);
    }

    private void Exportar(DataSet ds)
    {
        //string strFichero;
        //strFichero = "Reporte" + DateTime.Now + ".xls";
        //Response.Clear();
        //Response.Buffer = true;
        //Response.ContentType = "application/vnd.ms-Excel";
        //Response.AppendHeader("content-disposition", "inline; filename=" + strFichero);

        //Response.Charset = "UTF-8";
        //Response.ContentEncoding = Encoding.Default;

        ////Response.Charset = "";
        //this.EnableViewState = false;
        //System.IO.StringWriter oStringWriter = new System.IO.StringWriter();
        //System.Web.UI.HtmlTextWriter oHtmlTextWriter = new System.Web.UI.HtmlTextWriter(oStringWriter);
        ////this.ClearControls(dg);
        ////dg.RenderControl(oHtmlTextWriter);
        //Response.Write(oStringWriter.ToString());
        //Response.End();
        //Microsoft.Office.Interop.Excel._Application excel = default(Microsoft.Office.Interop.Excel._Application);

        Excel.Application archivoExcel = default(Excel.Application);
        Excel.Workbook libroExcel = default(Excel.Workbook);
        Excel.Worksheet hojaExcel = default(Excel.Worksheet);

        archivoExcel = new Excel.Application();
        archivoExcel.Visible = true;

        libroExcel = archivoExcel.Workbooks.Add();
        hojaExcel = (Excel.Worksheet)libroExcel.Worksheets[1];
        hojaExcel.Visible = Excel.XlSheetVisibility.xlSheetVisible;

        hojaExcel.Activate();

        Excel.Range rango;
        
        //Título
        rango=hojaExcel.Range["A2:A3"];
        rango.Merge();
        rango.Value = "Sistema de Alertas";
        rango.Font.Bold = true;
        rango.Font.Size = 11;
        rango.Font.Color=System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
        rango.Interior.ColorIndex = 23;
        rango.ColumnWidth = 29.57;
        rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
        rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
        
        //Cabeceras
        rango = hojaExcel.Range["C2:D2"];
        rango.Merge();
        rango.Value = "Mes Actual";
        rango.Font.Bold = true;
        rango.Font.Size = 11;
        rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
        rango.Interior.ColorIndex = 23;
        rango.ColumnWidth = 12.57;
        rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
        rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

        rango = (Excel.Range)hojaExcel.Cells[3, 3];
        rango.Value = "Cantidad";
        rango.Font.Bold = false;
        rango.Font.Size = 11;
        rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
        rango.Interior.ColorIndex = 33;
        rango.ColumnWidth = 12.57;
        rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
        rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

        rango = (Excel.Range)hojaExcel.Cells[3, 4];
        rango.Value = "Saldos";
        rango.Font.Bold = false;
        rango.Font.Size = 11;
        rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
        rango.Interior.ColorIndex = 33;
        rango.ColumnWidth = 12.57;
        rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
        rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

        rango = hojaExcel.Range["F2:G2"];
        rango.Merge();
        rango.Value = "Mes Anterior";
        rango.Font.Bold = true;
        rango.Font.Size = 11;
        rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
        rango.Interior.ColorIndex = 23;
        rango.ColumnWidth = 12.57;
        rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
        rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

        rango = (Excel.Range)hojaExcel.Cells[3, 6];
        rango.Value = "Cantidad";
        rango.Font.Bold = false;
        rango.Font.Size = 11;
        rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
        rango.Interior.ColorIndex = 33;
        rango.ColumnWidth = 12.57;
        rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
        rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

        rango = (Excel.Range)hojaExcel.Cells[3, 7];
        rango.Value = "Saldos";
        rango.Font.Bold = false;
        rango.Font.Size = 11;
        rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
        rango.Interior.ColorIndex = 33;
        rango.ColumnWidth = 12.57;
        rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
        rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

        rango = hojaExcel.Range["I2:J2"];
        rango.Merge();
        rango.Value = "Año Anterior";
        rango.Font.Bold = true;
        rango.Font.Size = 11;
        rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
        rango.Interior.ColorIndex = 23;
        rango.ColumnWidth = 12.57;
        rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
        rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

        rango = (Excel.Range)hojaExcel.Cells[3, 9];
        rango.Value = "Prom. Mes 6";
        rango.Font.Bold = false;
        rango.Font.Size = 11;
        rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
        rango.Interior.ColorIndex = 33;
        rango.ColumnWidth = 12.57;
        rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
        rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

        rango = (Excel.Range)hojaExcel.Cells[3, 10];
        rango.Value = "Prom. Mes 12";
        rango.Font.Bold = false;
        rango.Font.Size = 11;
        rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
        rango.Interior.ColorIndex = 33;
        rango.ColumnWidth = 12.57;
        rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
        rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

        rango = (Excel.Range)hojaExcel.Cells[2,12];
        rango.Interior.ColorIndex = 23;
        rango.ColumnWidth = 12.57;

        rango = (Excel.Range)hojaExcel.Cells[3, 12];
        rango.Value = "Tendencia";
        rango.Font.Bold = false;
        rango.Font.Size = 11;
        rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
        rango.Interior.ColorIndex = 33;
        rango.ColumnWidth = 12.57;
        rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
        rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;


        //Columnas separadoras en blanco
        rango = (Excel.Range)hojaExcel.Columns[2];
        rango.ColumnWidth = 0.67;
        rango = (Excel.Range)hojaExcel.Columns[5];
        rango.ColumnWidth = 0.67;
        rango = (Excel.Range)hojaExcel.Columns[8];
        rango.ColumnWidth = 0.67;
        rango = (Excel.Range)hojaExcel.Columns[11];
        rango.ColumnWidth = 0.92;

        //Items
        rango = (Excel.Range)hojaExcel.Cells[5, 1];
        rango.Value = "Primera Cuota Impaga";
        rango.Font.Bold = false;
        rango.Font.Size = 11;
        rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
        rango.ColumnWidth = 29.57; ;
        rango.RowHeight = 30;
        rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

        rango = (Excel.Range)hojaExcel.Cells[7, 1];
        rango.Value = "Con dos o más Créditos";
        rango.Font.Bold = false;
        rango.Font.Size = 11;
        rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
        rango.ColumnWidth = 29.57;
        rango.RowHeight = 30;
        rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

        rango = (Excel.Range)hojaExcel.Cells[9, 1];
        rango.Value = "Deuda menor a S/.100";
        rango.Font.Bold = false;
        rango.Font.Size = 11;
        rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
        rango.ColumnWidth = 29.57;
        rango.RowHeight = 30;
        rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

        rango = (Excel.Range)hojaExcel.Cells[11, 1];
        rango.Value = "Sobregiros en TC";
        rango.Font.Bold = false;
        rango.Font.Size = 11;
        rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
        rango.ColumnWidth = 29.57;
        rango.RowHeight = 30;
        rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

        rango = (Excel.Range)hojaExcel.Cells[13, 1];
        rango.Value = "Con línea disponible sin bloqueo";
        rango.Font.Bold = false;
        rango.Font.Size = 11;
        rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
        rango.ColumnWidth = 29.57;
        rango.RowHeight = 30;
        rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

        rango = (Excel.Range)hojaExcel.Cells[15, 1];
        rango.Value = "Hipotecario vencido sin garantía";
        rango.Font.Bold = false;
        rango.Font.Size = 11;
        rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
        rango.ColumnWidth = 29.57;
        rango.RowHeight = 30;
        rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

        //Pies
        rango = (Excel.Range)hojaExcel.Cells[17, 1];
        rango.Value = "Total";
        rango.Font.Bold = true;
        rango.Font.Size = 11;
        rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
        rango.Interior.ColorIndex = 37;
        rango.ColumnWidth = 29.57;
        rango.RowHeight = 30;
        rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
        rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

        rango = hojaExcel.Range["C17:D17"];
        rango.Font.Bold = true;
        rango.Font.Size = 11;
        rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
        rango.Interior.ColorIndex = 37;
        rango.ColumnWidth = 12.57;
        rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
        rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

        rango = hojaExcel.Range["F17:G17"];
        rango.Font.Bold = true;
        rango.Font.Size = 11;
        rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
        rango.Interior.ColorIndex = 37;
        rango.ColumnWidth = 12.57;
        rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
        rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

        rango = hojaExcel.Range["I17:J17"];
        rango.Font.Bold = true;
        rango.Font.Size = 11;
        rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
        rango.Interior.ColorIndex = 37;
        rango.ColumnWidth = 12.57;
        rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
        rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

        rango = (Excel.Range)hojaExcel.Cells[17, 12];
        rango.Font.Bold = true;
        rango.Font.Size = 11;
        rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
        rango.Interior.ColorIndex = 37;
        rango.ColumnWidth = 12.57;
        rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
        rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

        rango = hojaExcel.Range["C5:j15"];
        rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
        

        //Llenando Datos
        hojaExcel.Cells[5, 3] = ds.Tables[0].Rows[0].ItemArray[0];
        hojaExcel.Cells[5, 4] = ds.Tables[0].Rows[1].ItemArray[0];
        hojaExcel.Cells[5, 6] = ds.Tables[0].Rows[2].ItemArray[0];
        hojaExcel.Cells[5, 7] = ds.Tables[0].Rows[3].ItemArray[0];
        hojaExcel.Cells[5, 9] = ds.Tables[0].Rows[4].ItemArray[0];
        hojaExcel.Cells[5, 10] = ds.Tables[0].Rows[5].ItemArray[0];

        hojaExcel.Cells[7, 3] = ds.Tables[0].Rows[0].ItemArray[1];
        hojaExcel.Cells[7, 4] = ds.Tables[0].Rows[1].ItemArray[1];
        hojaExcel.Cells[7, 6] = ds.Tables[0].Rows[2].ItemArray[1];
        hojaExcel.Cells[7, 7] = ds.Tables[0].Rows[3].ItemArray[1];
        hojaExcel.Cells[7, 9] = ds.Tables[0].Rows[4].ItemArray[1];
        hojaExcel.Cells[7, 10] = ds.Tables[0].Rows[5].ItemArray[1];

        hojaExcel.Cells[9, 3] = ds.Tables[0].Rows[0].ItemArray[2];
        hojaExcel.Cells[9, 4] = ds.Tables[0].Rows[1].ItemArray[2];
        hojaExcel.Cells[9, 6] = ds.Tables[0].Rows[2].ItemArray[2];
        hojaExcel.Cells[9, 7] = ds.Tables[0].Rows[3].ItemArray[2];
        hojaExcel.Cells[9, 9] = ds.Tables[0].Rows[4].ItemArray[2];
        hojaExcel.Cells[9, 10] = ds.Tables[0].Rows[5].ItemArray[2];

        hojaExcel.Cells[11, 3] = ds.Tables[0].Rows[0].ItemArray[3];
        hojaExcel.Cells[11, 4] = ds.Tables[0].Rows[1].ItemArray[3];
        hojaExcel.Cells[11, 6] = ds.Tables[0].Rows[2].ItemArray[3];
        hojaExcel.Cells[11, 7] = ds.Tables[0].Rows[3].ItemArray[3];
        hojaExcel.Cells[11, 9] = ds.Tables[0].Rows[4].ItemArray[3];
        hojaExcel.Cells[11, 10] = ds.Tables[0].Rows[5].ItemArray[3];

        hojaExcel.Cells[13, 3] = ds.Tables[0].Rows[0].ItemArray[4];
        hojaExcel.Cells[13, 4] = ds.Tables[0].Rows[1].ItemArray[4];
        hojaExcel.Cells[13, 6] = ds.Tables[0].Rows[2].ItemArray[4];
        hojaExcel.Cells[13, 7] = ds.Tables[0].Rows[3].ItemArray[4];
        hojaExcel.Cells[13, 9] = ds.Tables[0].Rows[4].ItemArray[4];
        hojaExcel.Cells[13, 10] = ds.Tables[0].Rows[5].ItemArray[4];

        hojaExcel.Cells[15, 3] = ds.Tables[0].Rows[0].ItemArray[5];
        hojaExcel.Cells[15, 4] = ds.Tables[0].Rows[1].ItemArray[5];
        hojaExcel.Cells[15, 6] = ds.Tables[0].Rows[2].ItemArray[5];
        hojaExcel.Cells[15, 7] = ds.Tables[0].Rows[3].ItemArray[5];
        hojaExcel.Cells[15, 9] = ds.Tables[0].Rows[4].ItemArray[5];
        hojaExcel.Cells[15, 10] = ds.Tables[0].Rows[5].ItemArray[5];

        string formula1 = "=SUM(C5:C15)";
        string formula2 = "=SUM(D5:D15)";
        string formula3 = "=SUM(F5:F15)";
        string formula4 = "=SUM(G5:G15)";
        string formula5 = "=SUM(I5:I15)";
        string formula6 = "=SUM(J5:J15)";
        string formula7 = "=SUM(L5:L15)";

        hojaExcel.Cells[17, 3] = formula1;
        hojaExcel.Cells[17, 4] = formula2;
        hojaExcel.Cells[17, 6] = formula3;
        hojaExcel.Cells[17, 7] = formula4;
        hojaExcel.Cells[17, 9] = formula5;
        hojaExcel.Cells[17, 10] = formula6;
        hojaExcel.Cells[17, 12] = formula7;

        //Tendencias
        //InsertarTendencia(hojaExcel,"D5","G5",)
        InsertarTendencia(hojaExcel, "D5", "G5", "L5");
        InsertarTendencia(hojaExcel, "D7", "G7", "L7");
        InsertarTendencia(hojaExcel, "D9", "G9", "L9");
        InsertarTendencia(hojaExcel, "D11", "G11", "L11");
        InsertarTendencia(hojaExcel, "D13", "G13", "L13");
        InsertarTendencia(hojaExcel, "D15", "G15", "L15");

        rango = hojaExcel.Range["L5:L15"];
        rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
        rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

        //Guardando el documento
        DateTime fecha = DateTime.Now;
        var cultura = new CultureInfo("en-GB");
        string strFecha = fecha.ToString(cultura);
        string[] diaHora = strFecha.Split(' ');
        string dia = diaHora[0];
        string hora = diaHora[1];
        diaHora = dia.Split('/');
        strFecha = diaHora[0].ToString() + diaHora[1].ToString() + diaHora[2].ToString();
        diaHora = hora.Split(':');
        strFecha = strFecha + "-" + diaHora[0].ToString() + diaHora[1].ToString() + diaHora[2].ToString();
        hojaExcel.SaveAs("TableroAlertas-" + strFecha);
        libroExcel.Save();
    }

    private DataSet ReturnDataSet()
    {
        DataSet ds = new DataSet();
        System.Data.DataTable dt = new System.Data.DataTable();

        LoGS_BaseReportes objLogica = new LoGS_BaseReportes();
        EnGS_BaseReportes objEntidad = new EnGS_BaseReportes();
        List<EnGS_BaseReportes> ListEntidad = new List<EnGS_BaseReportes>();

        //string str_codidenest = (String)this.Session["codidenest"];
        string str_nempresa = (String)Request["nempresa"];
        string str_anio = (String)Request["anio"];
        string str_mes = (String)Request["mes"];

        objEntidad.NEmpresa = str_nempresa;
        objEntidad.Anio = str_anio;
        objEntidad.Mes = str_mes;

        ListEntidad.Add(objEntidad);

        dt = objLogica.RPT_Prevencion_SistemaAlertas_Consolidado(ListEntidad);

        ds.Tables.Add(dt.Copy());
        ds.Tables[0].TableName = "DTGestionEjecutores";

        return ds;

    }

    //private void InsertarTendencia(Excel.Worksheet hojaExcel,string celdaActual,string celdaAnterior,int fila,int columna)
    private void InsertarTendencia(Excel.Worksheet hojaExcel, string celdaActual, string celdaAnterior, string celdaTendencia)
    {
        double valorActual = 0;
        double valorAnterior = 0;
        Excel.Range rango;

        valorActual = double.Parse(hojaExcel.get_Range(celdaActual).Value2.ToString());
        valorAnterior = double.Parse(hojaExcel.get_Range(celdaAnterior).Value2.ToString());
        if (valorActual > (valorAnterior*1.05))
        {
            //rango = (Excel.Range)hojaExcel.Cells[fila, columna];
            rango = hojaExcel.Range[celdaTendencia + ":" + celdaTendencia];
            System.Drawing.Image flechaAlertas = System.Drawing.Image.FromFile(Server.MapPath("~/imagenes/flechaArriba.png"));
            hojaExcel.Shapes.AddPicture(Server.MapPath("~/imagenes/flechaArriba.png"), MsoTriState.msoFalse, MsoTriState.msoCTrue, float.Parse((float.Parse(rango.Left.ToString())+20).ToString()), float.Parse((float.Parse(rango.Top.ToString())+5).ToString()), flechaAlertas.Width, flechaAlertas.Height);
        }
        else if (valorActual < (valorAnterior*0.95))
        {
            //rango = (Excel.Range)hojaExcel.Cells[fila, columna];
            rango = hojaExcel.Range[celdaTendencia + ":" + celdaTendencia];
            System.Drawing.Image flechaAlertas = System.Drawing.Image.FromFile(Server.MapPath("~/imagenes/flechaAbajo.png"));
            hojaExcel.Shapes.AddPicture(Server.MapPath("~/imagenes/flechaAbajo.png"), MsoTriState.msoFalse, MsoTriState.msoCTrue, float.Parse((float.Parse(rango.Left.ToString()) + 20).ToString()), float.Parse((float.Parse(rango.Top.ToString()) + 6).ToString()), flechaAlertas.Width, flechaAlertas.Height);
        }
        else
        {
            //rango = (Excel.Range)hojaExcel.Cells[fila, columna];
            rango = hojaExcel.Range[celdaTendencia + ":" + celdaTendencia];
            System.Drawing.Image flechaAlertas = System.Drawing.Image.FromFile(Server.MapPath("~/imagenes/flechaLado.png"));
            hojaExcel.Shapes.AddPicture(Server.MapPath("~/imagenes/flechaLado.png"), MsoTriState.msoFalse, MsoTriState.msoCTrue, float.Parse((float.Parse(rango.Left.ToString()) + 24).ToString()), float.Parse((float.Parse(rango.Top.ToString()) + 1).ToString()), flechaAlertas.Width, flechaAlertas.Height);
        }    
    }
}