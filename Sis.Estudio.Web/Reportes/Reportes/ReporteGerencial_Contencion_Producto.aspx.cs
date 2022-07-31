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
using Sis.Estudio.Logic.MSSQL.Reportes;
using System.Globalization;
using Sis.Estudio.Logic.MSSQL.Gestion;
using Microsoft.Office.Core;
using System.Windows.Forms;

public partial class Reportes_Reportes_ReporteGerencial_Contencion_Producto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string str_tiporeporte = (String)Request["tiporeporte"];
        if (str_tiporeporte == "excel")
        {
            //ResponseExcel();
            Exportar();
        }
    }

    //private void ResponseExcel()
    //{
    //    DataSet ds = new DataSet();
    //    ds = ReturnDataSet();

    //    //dg.DataSource = ds.Tables[0];
    //    //dg.DataBind();
    //    Exportar(ds);
    //}

    private void Exportar()
    {
        Excel.Application archivoExcel = default(Excel.Application);
        Excel.Workbook libroExcel = default(Excel.Workbook);
        Excel.Worksheet hojaExcel = default(Excel.Worksheet);

        archivoExcel = new Excel.Application();
        archivoExcel.Visible = true;

        libroExcel = archivoExcel.Workbooks.Add();
        hojaExcel = (Excel.Worksheet)libroExcel.Worksheets[1];
        //hojaExcel.Visible = Excel.XlSheetVisibility.xlSheetVisible;

        //hojaExcel.Activate();

        Excel.Range rango;

        //Título
        rango = hojaExcel.Range["C1:R1"];
        rango.Merge();
        rango.Value = "Contenciones por Producto";
        rango.Font.Bold = true;
        rango.Font.Size = 14;
        rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
        rango.Interior.ColorIndex = 23;
        rango.ColumnWidth = 29.57;
        rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
        rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

        //Cabeceras
        rango = hojaExcel.Range["C3:C4,C14:C15,C25:C26,C36:C37,C47:C48,C58:C59"];
        rango.Merge();
        //rango.Value = "1er Tramo";
        rango.Font.Bold = true;
        rango.Font.Size = 14;
        rango.Font.Underline = true;
        rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
        rango.Interior.ColorIndex = 23;
        rango.ColumnWidth = 12.57;
        rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
        rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

        rango = hojaExcel.Range["E3:P3,E14:P14,E25:P25,E36:P36,E47:P47,E58:P58"];
        rango.Merge();
        rango.Value = "2016";
        rango.Font.Bold = true;
        rango.Font.Size = 14;
        rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
        rango.Interior.ColorIndex = 10;
        rango.ColumnWidth = 12.57;
        rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
        rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

        rango = hojaExcel.Range["C3:C4"];
        rango.Value = "1er Tramo";
        rango = hojaExcel.Range["C14:C15"];
        rango.Value = "2do Tramo";
        rango = hojaExcel.Range["C25:C26"];
        rango.Value = "3er Tramo";
        rango = hojaExcel.Range["C36:C37"];
        rango.Value = "4to Tramo";
        rango = hojaExcel.Range["C47:C48"];
        rango.Value = "5to Tramo";
        rango = hojaExcel.Range["C58:C59"];
        rango.Value = "6to Tramo";

        for (int i = 4; i < 59; i=i+11 )
        {
            rango = (Excel.Range)hojaExcel.Cells[i, 5];
            rango.Value = "Enero";
            rango.Font.Bold = false;
            rango.Font.Size = 11;
            rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
            rango.Interior.ColorIndex = 24;
            rango.ColumnWidth = 12.57;
            rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

            rango = (Excel.Range)hojaExcel.Cells[i, 6];
            rango.Value = "Febrero";
            rango.Font.Bold = false;
            rango.Font.Size = 11;
            rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
            rango.Interior.ColorIndex = 24;
            rango.ColumnWidth = 12.57;
            rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

            rango = (Excel.Range)hojaExcel.Cells[i, 7];
            rango.Value = "Marzo";
            rango.Font.Bold = false;
            rango.Font.Size = 11;
            rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
            rango.Interior.ColorIndex = 24;
            rango.ColumnWidth = 12.57;
            rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

            rango = (Excel.Range)hojaExcel.Cells[i, 8];
            rango.Value = "Abril";
            rango.Font.Bold = false;
            rango.Font.Size = 11;
            rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
            rango.Interior.ColorIndex = 24;
            rango.ColumnWidth = 12.57;
            rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

            rango = (Excel.Range)hojaExcel.Cells[i, 9];
            rango.Value = "Mayo";
            rango.Font.Bold = false;
            rango.Font.Size = 11;
            rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
            rango.Interior.ColorIndex = 24;
            rango.ColumnWidth = 12.57;
            rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

            rango = (Excel.Range)hojaExcel.Cells[i, 10];
            rango.Value = "Junio";
            rango.Font.Bold = false;
            rango.Font.Size = 11;
            rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
            rango.Interior.ColorIndex = 24;
            rango.ColumnWidth = 12.57;
            rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

            rango = (Excel.Range)hojaExcel.Cells[i, 11];
            rango.Value = "Julio";
            rango.Font.Bold = false;
            rango.Font.Size = 11;
            rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
            rango.Interior.ColorIndex = 24;
            rango.ColumnWidth = 12.57;
            rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

            rango = (Excel.Range)hojaExcel.Cells[i, 12];
            rango.Value = "Agosto";
            rango.Font.Bold = false;
            rango.Font.Size = 11;
            rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
            rango.Interior.ColorIndex = 24;
            rango.ColumnWidth = 12.57;
            rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

            rango = (Excel.Range)hojaExcel.Cells[i, 13];
            rango.Value = "Septiembre";
            rango.Font.Bold = false;
            rango.Font.Size = 11;
            rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
            rango.Interior.ColorIndex = 24;
            rango.ColumnWidth = 12.57;
            rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

            rango = (Excel.Range)hojaExcel.Cells[i, 14];
            rango.Value = "Octubre";
            rango.Font.Bold = false;
            rango.Font.Size = 11;
            rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
            rango.Interior.ColorIndex = 24;
            rango.ColumnWidth = 12.57;
            rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

            rango = (Excel.Range)hojaExcel.Cells[i, 15];
            rango.Value = "Noviembre";
            rango.Font.Bold = false;
            rango.Font.Size = 11;
            rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
            rango.Interior.ColorIndex = 24;
            rango.ColumnWidth = 12.57;
            rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

            rango = (Excel.Range)hojaExcel.Cells[i, 16];
            rango.Value = "Diciembre";
            rango.Font.Bold = false;
            rango.Font.Size = 11;
            rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
            rango.Interior.ColorIndex = 24;
            rango.ColumnWidth = 12.57;
            rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
        }

        for (int i = 3; i <= 58; i = i + 11) {
            rango = hojaExcel.Range["R" + i.ToString() + ":R" + (i+1).ToString()];
            rango.Merge();
            rango.Value = "Tendencia";
            rango.Font.Bold = true;
            rango.Font.Size = 11;
            rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
            rango.Interior.ColorIndex = 24;
            rango.ColumnWidth = 12.57;
            rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
        }

        //Columnas separadoras en blanco
        rango = (Excel.Range)hojaExcel.Columns[1];
        rango.ColumnWidth = 5;
        rango = (Excel.Range)hojaExcel.Columns[2];
        rango.ColumnWidth = 5;
        rango = (Excel.Range)hojaExcel.Columns[4];
        rango.ColumnWidth = 5;
        rango = (Excel.Range)hojaExcel.Columns[17];
        rango.ColumnWidth = 5;

        //Items
        for (int i = 6; i <= 61; i = i + 11) {
            rango = (Excel.Range)hojaExcel.Cells[i, 3];
            rango.Value = "Tarjetas";
            rango.Font.Bold = false;
            rango.Font.Size = 11;
            rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
            rango.Interior.ColorIndex = 24;
            rango.ColumnWidth = 15;
            rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
            rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

            rango = (Excel.Range)hojaExcel.Cells[i+1, 3];
            rango.Value = "Efectivo";
            rango.Font.Bold = false;
            rango.Font.Size = 11;
            rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
            rango.Interior.ColorIndex = 24;
            rango.ColumnWidth = 15;
            rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
            rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

            rango = (Excel.Range)hojaExcel.Cells[i+2, 3];
            rango.Value = "Convenios";
            rango.Font.Bold = false;
            rango.Font.Size = 11;
            rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
            rango.Interior.ColorIndex = 24;
            rango.ColumnWidth = 15;
            rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
            rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

            rango = (Excel.Range)hojaExcel.Cells[i+3, 3];
            rango.Value = "Vehicular";
            rango.Font.Bold = false;
            rango.Font.Size = 11;
            rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
            rango.Interior.ColorIndex = 24;
            rango.ColumnWidth = 15;
            rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
            rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

            rango = (Excel.Range)hojaExcel.Cells[i+4, 3];
            rango.Value = "Hipotecario";
            rango.Font.Bold = false;
            rango.Font.Size = 11;
            rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
            rango.Interior.ColorIndex = 24;
            rango.ColumnWidth = 15;
            rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
            rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
        }

        rango = hojaExcel.Range["E6:R10,E17:R21,E28:R32,E39:R43,E50:R54,E61:R65"];
        rango.NumberFormat = "0.00";
        rango.Style = "Percent";
        rango.RowHeight = 30;
        //Llenando Datos
        //Modificar para que sea dinámico
        DataSet ds = new DataSet();
        int str_mes_inicial = int.Parse(Request["mesInicial"]); 
        int str_mes_final = int.Parse(Request["mesfinal"]);
        int contFilaTramo = 5;
        double promedio = 0;
        double mesActual = 0;
        //TRAMO1
        //ds = ReturnDataSet(1);
        for (int contTramo = 1; contTramo < 7; contTramo++)
        {
            for (int i = 1; i < 6; i++)
            {
                ds = ReturnDataSet(i, contTramo);
                int cont = 0;
                for (int j = str_mes_inicial; j < str_mes_final + 1; j++)
                {
                    hojaExcel.Cells[i + contFilaTramo, j + 4] = ds.Tables[0].Rows[cont].ItemArray[8];
                    rango = (Excel.Range)hojaExcel.Cells[i + contFilaTramo, j + 4];
                    if (j < str_mes_final)
                    {
                        promedio = promedio + double.Parse(ds.Tables[0].Rows[cont].ItemArray[8].ToString());
                    }
                    if (j == str_mes_final - 1)
                    {
                        promedio = promedio / j;
                        mesActual = double.Parse(ds.Tables[0].Rows[cont + 1].ItemArray[8].ToString());
                        InsertarTendencia(hojaExcel, promedio, mesActual, i + contFilaTramo, 18);
                    }

                    cont++;
                }
                promedio = 0;
                mesActual = 0;
            }
            contFilaTramo = contFilaTramo + 11;
        }
        


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
        hojaExcel.SaveAs("IndicadorContencion-" + strFecha);
        libroExcel.Save();
    }

    private DataSet ReturnDataSet(int TipoCredito,int Tramo)
    {
        DataSet ds = new DataSet();
        System.Data.DataTable dt = new System.Data.DataTable();

        LoRPT_BaseContencion objLogica = new LoRPT_BaseContencion();
        EnRPT_BaseContencion objEntidad = new EnRPT_BaseContencion();
        List<EnRPT_BaseContencion> ListEntidad = new List<EnRPT_BaseContencion>();

        //string str_codidenest = (String)this.Session["codidenest"];
        string str_nempresa = (String)Request["nempresa"];
        string str_anio = (String)Request["anio"];
        string str_mes_inicial = (String)Request["mesInicial"];
        string str_mes_final = (String)Request["mesfinal"];
        string str_tramo = Tramo.ToString();
        string str_tipo_producto = TipoCredito.ToString();

        objEntidad.NEmpresa = str_nempresa;
        objEntidad.Anio = str_anio;
        objEntidad.MesIntInicio = str_mes_inicial;
        objEntidad.MesIntFin = str_mes_final;
        objEntidad.Tramo = str_tramo;
        objEntidad.TipoCredito = str_tipo_producto;
        
        ListEntidad.Add(objEntidad);

        dt = objLogica.RPT_BaseContencion_ObtenerContencionProducto(ListEntidad);

        ds.Tables.Add(dt.Copy());
        ds.Tables[0].TableName = "DTGestionEjecutores";

        return ds;

    }

    private void InsertarTendencia(Excel.Worksheet hojaExcel, double promedio, double mesActual, int fila, int columna)
    {
        double valorActual = 0;
        double valorAnterior = 0;
        Excel.Range rango;

        valorActual = mesActual;
        valorAnterior = promedio;
        if (valorActual > (valorAnterior))
        {
            rango = (Excel.Range)hojaExcel.Cells[fila, columna];
            System.Drawing.Image flechaAlertas = System.Drawing.Image.FromFile(Server.MapPath("~/imagenes/flechaArriba.png"));
            hojaExcel.Shapes.AddPicture(Server.MapPath("~/imagenes/flechaArriba.png"), MsoTriState.msoFalse, MsoTriState.msoCTrue, float.Parse((float.Parse(rango.Left.ToString()) + 20).ToString()), float.Parse((float.Parse(rango.Top.ToString()) + 5).ToString()), flechaAlertas.Width, flechaAlertas.Height);
        }
        else if (valorActual < (valorAnterior))
        {
            rango = (Excel.Range)hojaExcel.Cells[fila, columna];
            System.Drawing.Image flechaAlertas = System.Drawing.Image.FromFile(Server.MapPath("~/imagenes/flechaAbajo.png"));
            hojaExcel.Shapes.AddPicture(Server.MapPath("~/imagenes/flechaAbajo.png"), MsoTriState.msoFalse, MsoTriState.msoCTrue, float.Parse((float.Parse(rango.Left.ToString()) + 20).ToString()), float.Parse((float.Parse(rango.Top.ToString()) + 6).ToString()), flechaAlertas.Width, flechaAlertas.Height);
        }
        else
        {
            rango = (Excel.Range)hojaExcel.Cells[fila, columna];
            System.Drawing.Image flechaAlertas = System.Drawing.Image.FromFile(Server.MapPath("~/imagenes/flechaLado.png"));
            hojaExcel.Shapes.AddPicture(Server.MapPath("~/imagenes/flechaLado.png"), MsoTriState.msoFalse, MsoTriState.msoCTrue, float.Parse((float.Parse(rango.Left.ToString()) + 24).ToString()), float.Parse((float.Parse(rango.Top.ToString()) + 1).ToString()), flechaAlertas.Width, flechaAlertas.Height);
        }
    }
}