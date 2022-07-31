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
using Sis.Estudio.Logic.MSSQL.Gestion;
using Microsoft.Office.Core;
using System.Windows.Forms;
using System.Globalization;

public partial class Reportes_Reportes_ReporteGerencial_RollRates_Tramo : System.Web.UI.Page
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

    private void Exportar()
    {
        int tramosReglasGestiones=6;//crear método que extraiga de la bd

        Excel.Application archivoExcel = default(Excel.Application);
        Excel.Workbook libroExcel = default(Excel.Workbook);
        Excel.Worksheet hojaExcel = default(Excel.Worksheet);

        archivoExcel = new Excel.Application();
        archivoExcel.Visible = true;

        libroExcel = archivoExcel.Workbooks.Add();
        hojaExcel = (Excel.Worksheet)libroExcel.Worksheets[1];
        hojaExcel.Visible = Excel.XlSheetVisibility.xlSheetVisible;

        hojaExcel.Activate();

        DataSet ds = new DataSet();

        Excel.Range rango;
        //Título
        rango = hojaExcel.Range["A1:A1,A"+(tramosReglasGestiones+6).ToString()+":A"+(tramosReglasGestiones+6).ToString()];
        rango.Value = "Roll Rates";
        rango.Font.Bold = true;
        rango.Font.Size = 11;
        rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
        rango.Interior.ColorIndex = 33;
        rango.ColumnWidth = 17;
        rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
        rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

        //Cabeceras
        ds=ReturnDataSet(1);
        int int_mes_inicial = int.Parse(Request["mesInicial"]);
        int int_mes_final = int.Parse(Request["mesFinal"]);

        int rangoMes = ds.Tables[0].Rows.Count;//int_mes_final-int_mes_inicial+1;
        int columnaPromedio = rangoMes + 2;

        rango = hojaExcel.Range["A2:A2,A" + (tramosReglasGestiones + 7).ToString() + ":A" + (tramosReglasGestiones + 7).ToString()];
        rango.Value = "Vigentes";
        rango.Font.Bold = false;
        rango.Font.Size = 11;
        rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
        rango.ColumnWidth = 10.71;
        rango.RowHeight = 25;
        rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
        rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
        
        for (int i = 2; i < rangoMes+2; i++)
        {
            rango = (Excel.Range)hojaExcel.Cells[1, i];
            rango.Value = Mes(int_mes_inicial + i - 2);//ds.Tables[0].Rows[i-2].ItemArray[4];
            rango.Font.Bold = true;
            rango.Font.Size = 11;
            rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
            rango.Interior.ColorIndex = 33;
            rango.ColumnWidth = 10.71;
            rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
        }
        for (int i = 2; i < tramosReglasGestiones+3; i++)
		{
            rango = (Excel.Range)hojaExcel.Cells[tramosReglasGestiones + 6, i];
            rango.Value = Mes(int_mes_final+i-1);
            rango.Font.Bold = true;
            rango.Font.Size = 11;
            rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
            rango.Interior.ColorIndex = 33;
            rango.ColumnWidth = 10.71;
            rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
        }

        rango = (Excel.Range)hojaExcel.Cells[1, rangoMes+2];
        rango.Value = "Promedio";
        rango.Font.Bold = true;
        rango.Font.Size = 11;
        rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
        rango.Interior.ColorIndex = 33;
        rango.ColumnWidth = 20;
        rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
        rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

        rango = (Excel.Range)hojaExcel.Cells[tramosReglasGestiones+6, tramosReglasGestiones+3];
        rango.Value = "Pérdida Estimada";
        rango.Font.Bold = true;
        rango.Font.Size = 11;
        rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
        rango.Interior.ColorIndex = 41;
        rango.ColumnWidth = 20;
        rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
        rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

        //Insertar Primer Mes (luego se oculta)
        float totalCarteraPrimerMes = 0;
        ds = ReturnDataSetVigentes(int_mes_inicial);
        for (int i = 0; i < tramosReglasGestiones+1; i++)
        {
            rango = (Excel.Range)hojaExcel.Cells[2 + i, 2];
            rango.Value = ds.Tables[0].Rows[i].ItemArray[1];
            rango.Font.Bold = false;
            rango.Font.Size = 11;
            rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
            rango.ColumnWidth = 10.71;
            rango.RowHeight = 25;
            rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            totalCarteraPrimerMes = totalCarteraPrimerMes + float.Parse(ds.Tables[0].Rows[i].ItemArray[1].ToString());
        }

        rango = (Excel.Range)hojaExcel.Cells[tramosReglasGestiones + 3, 1];
        rango.Value = "Total Cartera";
        rango.Font.Bold = true;
        rango.Font.Size = 11;
        rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
        rango.ColumnWidth = 20;
        rango.RowHeight = 25;
        rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
        rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
        rango = (Excel.Range)hojaExcel.Cells[tramosReglasGestiones + 3, 2];

        rango.Value = totalCarteraPrimerMes;
        rango.Font.Bold = true;
        rango.Font.Size = 11;
        rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
        rango.ColumnWidth = 10.71;
        rango.RowHeight = 25;
        rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
        rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

        //Insertando Datos Parte 1
        for (int i = 1; i < tramosReglasGestiones + 1; i++)
        {
            ds = ReturnDataSet(i);
            rango = (Excel.Range)hojaExcel.Cells[2 + i, 1];
            rango.Value = "Tramo " + i.ToString();
            rango.Font.Bold = false;
            rango.Font.Size = 11;
            rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
            rango.ColumnWidth = 20;
            rango.RowHeight = 25;
            rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            for (int j = 0; j < rangoMes; j++)
            {
                rango = (Excel.Range)hojaExcel.Cells[2 + i, j + 2];
                rango.Value = ds.Tables[0].Rows[j].ItemArray[7];
                rango.Style = "Percent";
                rango.Font.Bold = false;
                rango.Font.Size = 11;
                rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
                rango.ColumnWidth = 10.71;
                rango.RowHeight = 20;
                rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            }
            string formula = "=AVERAGE(B" + (i + 2).ToString() + ":" + Columna(rangoMes + 1) + (i + 2).ToString() + ")";
            rango = (Excel.Range)hojaExcel.Cells[2 + i, rangoMes + 2];
            rango.Value = formula;
            rango.Style = "Percent";
            rango.Font.Bold = false;
            rango.Font.Size = 11;
            rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
            rango.ColumnWidth = 20;
            rango.RowHeight = 20;
            rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            ds.Clear();
        }

        //Insertando Datos Parte 2
        ds.Clear();
        int int_mes_prediccion;
        int_mes_prediccion = int_mes_final + 1;
        
        ds = ReturnDataSetVigentes(int_mes_prediccion);
        for (int i = 0; i < tramosReglasGestiones + 1; i++)
        {
            rango = (Excel.Range)hojaExcel.Cells[tramosReglasGestiones + 7 + i, 2];
            rango.Value = ds.Tables[0].Rows[i].ItemArray[1];
            rango.Font.Bold = false;
            rango.Font.Size = 11;
            rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
            rango.ColumnWidth = 20;
            rango.RowHeight = 25;
            rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            for (int j = 0; j < i; j++)
            {
                rango = (Excel.Range)hojaExcel.Cells[tramosReglasGestiones + 7 + i, 3 + j];
                string formulaPrediccion = "="+Columna(2+j)+(tramosReglasGestiones+6+i).ToString()+"*"+Columna(rangoMes+2)+(2+i).ToString();
                rango.Value = formulaPrediccion;
                rango.NumberFormat = "0.00";
                rango.Font.Bold = false;
                rango.Font.Size = 11;
                rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
                rango.ColumnWidth = 10.71;
                rango.RowHeight = 25;
                rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                //System.Drawing.Image flechaRollRates = System.Drawing.Image.FromFile(Server.MapPath("~/imagenes/flechaRollRates.png"));
                //hojaExcel.Shapes.AddPicture(Server.MapPath("~/imagenes/flechaRollRates.png"), MsoTriState.msoFalse, MsoTriState.msoCTrue,1f, 1f, flechaRollRates.Width, flechaRollRates.Height);
            }
        }
        ds.Clear();
        for (int i = 1; i < tramosReglasGestiones + 1; i++)
        {
            ds = ReturnDataSet(i);
            rango = (Excel.Range)hojaExcel.Cells[tramosReglasGestiones + 7 + i, 1];
            rango.Value = "Tramo " + i.ToString();
            rango.Font.Bold = false;
            rango.Font.Size = 11;
            rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
            rango.ColumnWidth = 20;
            rango.RowHeight = 25;
            rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
        }

        string formulaTotalCartera = "";
        rango = (Excel.Range)hojaExcel.Cells[2 * tramosReglasGestiones + 8, 1];
        rango.Value = "Total Cartera";
        rango.Font.Bold = true;
        rango.Font.Size = 11;
        rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
        rango.ColumnWidth = 20;
        rango.RowHeight = 25;
        rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
        rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
        formulaTotalCartera = "=SUM(B" + (tramosReglasGestiones + 7).ToString() + ":B" + (2 * tramosReglasGestiones + 7).ToString() + ")";
        rango = (Excel.Range)hojaExcel.Cells[2 * tramosReglasGestiones + 8, 2];
        rango.Value = formulaTotalCartera;
        rango.Font.Bold = true;
        rango.Font.Size = 11;
        rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
        rango.ColumnWidth = 20;
        rango.RowHeight = 25;
        rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
        rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

        rango = (Excel.Range)hojaExcel.Cells[2*tramosReglasGestiones + 7, tramosReglasGestiones + 3];
        string formulaPerdida = "";
        formulaPerdida = "=SUM(C" + (2 * tramosReglasGestiones + 7).ToString() + ":" + Columna(tramosReglasGestiones + 2) + (2 * tramosReglasGestiones + 7).ToString();
        rango.Value = formulaPerdida;
        rango.Font.Bold = true;
        rango.Font.Size = 13;
        rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
        rango.ColumnWidth = 20;
        rango.RowHeight = 25;
        rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
        rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

        rango = (Excel.Range)hojaExcel.Cells[2 * tramosReglasGestiones + 8, tramosReglasGestiones + 3];
        formulaPerdida = "=" + Columna(tramosReglasGestiones + 3) + (2 * tramosReglasGestiones + 7).ToString() + "/" + "B" + (tramosReglasGestiones + 7).ToString();
        rango.Value = formulaPerdida;
        rango.Style = "Percent";
        rango.Font.Bold = true;
        rango.Font.Size = 13;
        rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
        rango.ColumnWidth = 20;
        rango.RowHeight = 25;
        rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
        rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

        for (int i = 1; i < tramosReglasGestiones+1; i++)
        {
            //System.Drawing.Image flechaRollRates = System.Drawing.Image.FromFile(Server.MapPath("~/imagenes/flechaRollRates.png"));
            //hojaExcel.Shapes.AddPicture(Server.MapPath("~/imagenes/flechaRollRates.png"), MsoTriState.msoFalse, MsoTriState.msoCTrue,210+75*i, 25*(tramosReglasGestiones+5+i), flechaRollRates.Width, flechaRollRates.Height);
            rango = (Excel.Range)hojaExcel.Cells[tramosReglasGestiones + 6 + i, 2 + i];
            System.Drawing.Image flechaRollRates = System.Drawing.Image.FromFile(Server.MapPath("~/imagenes/flechaRollRates.png"));
            hojaExcel.Shapes.AddPicture(Server.MapPath("~/imagenes/flechaRollRates.png"), MsoTriState.msoFalse, MsoTriState.msoCTrue, float.Parse(rango.Left.ToString()), float.Parse(rango.Top.ToString()), flechaRollRates.Width, flechaRollRates.Height);
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
        hojaExcel.SaveAs("RollRates-" + strFecha);
        libroExcel.Save();
    }

    private string Columna(int columnaInt)
    {
        string columna = "";
        switch (columnaInt)
        {
            case 1:
                columna = "A";
                break;
            case 2:
                columna = "B";
                break;
            case 3:
                columna = "C";
                break;
            case 4:
                columna = "D";
                break;
            case 5:
                columna = "E";
                break;
            case 6:
                columna = "F";
                break;
            case 7:
                columna = "G";
                break;
            case 8:
                columna = "H";
                break;
            case 9:
                columna = "I";
                break;
            case 10:
                columna = "J";
                break;
            case 11:
                columna = "K";
                break;
            case 12:
                columna = "L";
                break;
            case 13:
                columna = "M";
                break;
            case 14:
                columna = "N";
                break;
            case 15:
                columna = "O";
                break;
            case 16:
                columna = "P";
                break;
            case 17:
                columna = "Q";
                break;
            case 18:
                columna = "R";
                break;
            case 19:
                columna = "S";
                break;
            case 20:
                columna = "T";
                break;
            case 21:
                columna = "U";
                break;
            case 22:
                columna = "V";
                break;
            case 23:
                columna = "W";
                break;
            case 24:
                columna = "X";
                break;
            case 25:
                columna = "Y";
                break;
            case 26:
                columna = "Z";
                break;
            default:
                break;
        }
        
        return columna;
    }

    private string Mes(int mesInt) 
    {
        int resto = -1;
        if (mesInt<=12) resto = mesInt;
        else resto = mesInt%12;
        string mes = "";
        switch (resto)
        {
            case 1:
                mes = "Enero";
                break;
            case 2:
                mes = "Febrero";
                break;
            case 3:
                mes = "Marzo";
                break;
            case 4:
                mes = "Abril";
                break;
            case 5:
                mes = "Mayo";
                break;
            case 6:
                mes = "Junio";
                break;
            case 7:
                mes = "Julio";
                break;
            case 8:
                mes = "Agosto";
                break;
            case 9:
                mes = "Septiembre";
                break;
            case 10:
                mes = "Octubre";
                break;
            case 11:
                mes = "Noviembre";
                break;
            case 12:
                mes = "Diciembre";
                break;

            default:
                break;
        }
        return mes;
    }

    private DataSet ReturnDataSet(int Tramo)
    {
        DataSet ds = new DataSet();
        System.Data.DataTable dt = new System.Data.DataTable();

        LoRPT_BaseContencion objLogica = new LoRPT_BaseContencion();
        EnRPT_BaseContencion objEntidad = new EnRPT_BaseContencion();
        List<EnRPT_BaseContencion> ListEntidad = new List<EnRPT_BaseContencion>();

        string str_nempresa = (String)Request["nempresa"];
        string str_anio = (String)Request["anioInicial"];
        string str_anio_final = (String)Request["anioFinal"];
        string str_mes_inicial = (String)Request["mesInicial"];
        string str_mes_final = (String)Request["mesFinal"];
        string str_tramo = Tramo.ToString();

        objEntidad.NEmpresa = str_nempresa;
        objEntidad.AnioIntInicio = str_anio;
        objEntidad.AnioIntFin = str_anio_final;
        objEntidad.Tramo = str_tramo;
        objEntidad.MesIntInicio = str_mes_inicial;
        objEntidad.MesIntFin = str_mes_final;

        ListEntidad.Add(objEntidad);

        dt = objLogica.RPT_BaseContencion_ObtenerRollRatesTramo(ListEntidad);

        ds.Tables.Add(dt.Copy());
        ds.Tables[0].TableName = "DTGerenciaReportes";

        return ds;
    }

    private DataSet ReturnDataSetVigentes(int mesFinal)//falta completar, llenar objeto...
    {
        DataSet ds = new DataSet();
        System.Data.DataTable dt = new System.Data.DataTable();

        LoGS_BaseReportes objLogica = new LoGS_BaseReportes();
        EnRPT_BaseContencion objEntidad = new EnRPT_BaseContencion();
        List<EnRPT_BaseContencion> ListEntidad = new List<EnRPT_BaseContencion>();

        string str_nempresa = (String)Request["nempresa"];
        string str_anio_final = (String)Request["anioFinal"];
        //string str_mes_final = (String)Request["mesFinal"];
        string str_mes_final = mesFinal.ToString();

        objEntidad.NEmpresa = str_nempresa;
        objEntidad.AnioIntFin = str_anio_final;
        objEntidad.MesIntFin = str_mes_final;

        ListEntidad.Add(objEntidad);

        dt = objLogica.GS_CargaBaseReporte_SaldoVigentesTramo(ListEntidad);

        ds.Tables.Add(dt.Copy());
        ds.Tables[0].TableName = "DTGerenciaReportes";

        return ds;
    }
}