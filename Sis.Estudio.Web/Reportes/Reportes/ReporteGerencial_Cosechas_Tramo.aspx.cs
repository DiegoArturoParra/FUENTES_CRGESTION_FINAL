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


public partial class Reportes_Reportes_ReporteGerencial_Cosechas_Tramo : System.Web.UI.Page
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
        int tramo = int.Parse(Request["tramo"].ToString()); 

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

        DataSet dsSaldos = new DataSet();
        dsSaldos = ReturnDataSetSaldos(tramo);
        DataSet dsCosechas = new DataSet();
        dsCosechas = ReturnDataSetCosechas(tramo);

        int cantidadCosechas = dsSaldos.Tables[0].Rows.Count;
        int filaCabeceraPorcentajes = cantidadCosechas + 6;
        //Estructura
        //Título
        rango = hojaExcel.Range["A1:" + Columna(cantidadCosechas + 3).ToString()+"1"];
        rango.Merge();
        rango.Value = "Tramo " + tramo.ToString();
        rango.Font.Bold = true;
        rango.Font.Size = 14;
        rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
        rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

        //Formato Cabeceras
        rango = hojaExcel.Range["A2:" + Columna(cantidadCosechas + 3) + "2,A" + filaCabeceraPorcentajes.ToString() + ":" + Columna(cantidadCosechas + 3)+filaCabeceraPorcentajes.ToString()];
        rango.Font.Bold = true;
        rango.Font.Size = 11;
        rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
        rango.Interior.ColorIndex = 33;
        rango.ColumnWidth = 15;
        rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
        rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

        rango = hojaExcel.Range["A2:A2,A" + filaCabeceraPorcentajes + ":A" + filaCabeceraPorcentajes];
        rango.Value = "Año";
        rango = hojaExcel.Range["B2:B2,B" + filaCabeceraPorcentajes + ":B" + filaCabeceraPorcentajes];
        rango.Value = "Cosechas";
        rango = hojaExcel.Range["C2:C2,C" + filaCabeceraPorcentajes + ":C" + filaCabeceraPorcentajes];
        rango.Value = "Saldos";
        for (int i = 1 ; i < cantidadCosechas+1; i++)
        {
            rango = (Excel.Range)hojaExcel.Cells[2, i + 3];
            rango.Value = "Mes" + i.ToString();
            rango = (Excel.Range)hojaExcel.Cells[filaCabeceraPorcentajes, i + 3];
            rango.Value = "Mes" + i.ToString();  
        }

        for (int i = 0; i < cantidadCosechas; i++)
        {
            rango = (Excel.Range)hojaExcel.Cells[3 + i, 1];
            rango.Value = dsSaldos.Tables[0].Rows[i].ItemArray[0];
            rango = (Excel.Range)hojaExcel.Cells[3 + i, 2];
            rango.Value = Mes(dsSaldos.Tables[0].Rows[i].ItemArray[1].ToString());
            rango = (Excel.Range)hojaExcel.Cells[3 + i, 3];
            rango.Value = dsSaldos.Tables[0].Rows[i].ItemArray[3];

            rango = (Excel.Range)hojaExcel.Cells[filaCabeceraPorcentajes + 1 + i, 1];
            rango.Value = dsSaldos.Tables[0].Rows[i].ItemArray[0];
            rango = (Excel.Range)hojaExcel.Cells[filaCabeceraPorcentajes + 1 + i, 2];
            rango.Value = Mes(dsSaldos.Tables[0].Rows[i].ItemArray[1].ToString());
            rango = (Excel.Range)hojaExcel.Cells[filaCabeceraPorcentajes + 1 + i, 3];
            rango.Value = dsSaldos.Tables[0].Rows[i].ItemArray[3];
        }

        int cantidadMesesPorCosecha = 0;
        int contador = 0;
        int fase = 0;
        for (int i = 1; i < cantidadCosechas+1; i++)
        {
            cantidadMesesPorCosecha = cantidadCosechas+1 - i;
            for (int j = 1; j < cantidadMesesPorCosecha+1; j++)
            {
                rango = (Excel.Range)hojaExcel.Cells[i + 2, j + 3];
                rango.Value = dsCosechas.Tables[0].Rows[j + fase-1].ItemArray[6];
                contador++;
            }
            fase = fase + contador;
            contador = 0;
        }

        contador = 0;
        fase = 0;
        string formula = "";
        for (int i = 1; i < cantidadCosechas + 1; i++)
        {
            cantidadMesesPorCosecha = cantidadCosechas + 1 - i;
            for (int j = 1; j < cantidadMesesPorCosecha + 1; j++)
            {
                rango = (Excel.Range)hojaExcel.Cells[i + filaCabeceraPorcentajes, j + 3];
                formula = "="+ Columna(j+3) + (i + 2).ToString() + "/C" + (i + filaCabeceraPorcentajes).ToString();
                rango.Value = formula;
                rango.Style="percent";
                contador++;
            }
            fase = fase + contador;
            contador = 0;
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
        hojaExcel.SaveAs("MoraPorCosechas-" + strFecha);
        libroExcel.Save();

    }

    private DataSet ReturnDataSetSaldos(int Tramo)
    {
        DataSet ds = new DataSet();
        System.Data.DataTable dt = new System.Data.DataTable();

        LoGS_BaseReportes objLogica = new LoGS_BaseReportes();
        EnGS_BaseReportes objEntidad = new EnGS_BaseReportes();
        List<EnGS_BaseReportes> ListEntidad = new List<EnGS_BaseReportes>();

        string str_nempresa = (String)Request["nempresa"];
        string str_anio = (String)Request["anioInicial"];
        string str_anio_final = (String)Request["anioFinal"];
        string str_mes_inicial = (String)Request["mesInicial"];
        string str_mes_final = (String)Request["mesFinal"];
        string str_tramo = Tramo.ToString();

        objEntidad.NEmpresa = str_nempresa;
        objEntidad.Anio = str_anio;
        objEntidad.AnioFin = str_anio_final;
        objEntidad.Tramo = str_tramo;
        objEntidad.Mes = str_mes_inicial;
        objEntidad.MesFin = str_mes_final;

        ListEntidad.Add(objEntidad);

        dt = objLogica.RPT_BaseReporte_ObtenerSaldosMes_Tramo(ListEntidad);

        ds.Tables.Add(dt.Copy());
        ds.Tables[0].TableName = "DTGerenciaReportes";

        return ds;
    }

    private DataSet ReturnDataSetCosechas(int Tramo)
    {
        DataSet ds = new DataSet();
        System.Data.DataTable dt = new System.Data.DataTable();

        LoGS_BaseReportes objLogica = new LoGS_BaseReportes();
        EnGS_BaseReportes objEntidad = new EnGS_BaseReportes();
        List<EnGS_BaseReportes> ListEntidad = new List<EnGS_BaseReportes>();

        string str_nempresa = (String)Request["nempresa"];
        string str_anio = (String)Request["anioInicial"];
        string str_anio_final = (String)Request["anioFinal"];
        string str_mes_inicial = (String)Request["mesInicial"];
        string str_mes_final = (String)Request["mesFinal"];
        string str_tramo = Tramo.ToString();

        objEntidad.NEmpresa = str_nempresa;
        objEntidad.Anio = str_anio;
        objEntidad.AnioFin = str_anio_final;
        objEntidad.Tramo = str_tramo;
        objEntidad.Mes = str_mes_inicial;
        objEntidad.MesFin = str_mes_final;

        ListEntidad.Add(objEntidad);

        dt = objLogica.RPT_BaseReporte_ObtenerCosechas_Tramo(ListEntidad);

        ds.Tables.Add(dt.Copy());
        ds.Tables[0].TableName = "DTGerenciaReportes";

        return ds;
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

    private string Mes(string mes)
    {
        switch (mes)
        {
            case "01":
                mes = "Enero";
                break;
            case "02":
                mes = "Febrero";
                break;
            case "03":
                mes = "Marzo";
                break;
            case "04":
                mes = "Abril";
                break;
            case "05":
                mes = "Mayo";
                break;
            case "06":
                mes = "Junio";
                break;
            case "07":
                mes = "Julio";
                break;
            case "08":
                mes = "Agosto";
                break;
            case "09":
                mes = "Septiembre";
                break;
            case "10":
                mes = "Octubre";
                break;
            case "11":
                mes = "Noviembre";
                break;
            case "12":
                mes = "Diciembre";
                break;

            default:
                break;
        }
        return mes;
    }

}