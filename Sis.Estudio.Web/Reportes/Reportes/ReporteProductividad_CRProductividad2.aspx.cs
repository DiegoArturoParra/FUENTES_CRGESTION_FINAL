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

public partial class Reportes_Reportes_ReporteProductividad_CRProductividad2 : System.Web.UI.Page
{
    #region Contadores
    //contadores GestionesLlamadas
    int cantidadClasificaciones = 0;
    int contadorClasificaciones = 0;
    int ejecutado = 0;
    int cantCD = 0;
    int cantCI = 0;
    int cantNC = 0;
    int filaBaseGestiones = 0;
    string filaBaseGestionesSTR = "";
    string cd = "";
    string ci = "";
    string nc = "";
    #endregion Contadores
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
        #region Fechas
        int[] CodigosGestiones = new int[] { 1, 3, 4, 5, 6, 7 };
        string fechaReporte = (String)Request["fecha"];
        string[] fechaReporteArray = fechaReporte.Split('/');
        int diaFechaReporte = int.Parse(fechaReporteArray[0].ToString());
        int mesFechaReporte = int.Parse(fechaReporteArray[1].ToString());
        int anioFechaReporte = int.Parse(fechaReporteArray[2].ToString());
        var fechaDateTime = new DateTime(anioFechaReporte, mesFechaReporte, diaFechaReporte);

        var culturaGb = new CultureInfo("en-GB");
        var culturaEs = new CultureInfo("es-MX");

        string[,] fechas = new string[31, 2];

        //Acumuladores
        int acumuladorFilas;


        //Llenar array con todas las fechas desde que inició el mes en curso hasta la fecha seleccionada.
        for (int i = 1; i < diaFechaReporte + 1; i++)
        {
            DateTime fechaMes = new DateTime(anioFechaReporte, mesFechaReporte, i);
            string strFechaMes = fechaMes.ToString(culturaGb);
            string[] diaHoraMes = strFechaMes.Split(' ');
            string diaMes = diaHoraMes[0];
            diaHoraMes = diaMes.Split('/');
            strFechaMes = diaHoraMes[2].ToString() + "-" + diaHoraMes[1].ToString() + "-" + diaHoraMes[0].ToString();
            string diaSemana = fechaMes.ToString("ddd", culturaEs);
            fechas[i - 1, 0] = strFechaMes;
            fechas[i - 1, 1] = diaSemana;

        }
        #endregion Fechas
        #region ConfigurarExcel
        Excel.Application archivoExcel = default(Excel.Application);
        Excel.Workbook libroExcel = default(Excel.Workbook);
        Excel.Worksheet hojaExcel = default(Excel.Worksheet);
        Excel.Worksheet hojaExcel2 = default(Excel.Worksheet);

        Excel.Borders bordes;
        Excel.Border borde;

        archivoExcel = new Excel.Application();
        archivoExcel.Visible = true;

        libroExcel = archivoExcel.Workbooks.Add();
        hojaExcel = (Excel.Worksheet)libroExcel.Worksheets[2];
        hojaExcel2 = (Excel.Worksheet)libroExcel.Worksheets[1];
        hojaExcel.Visible = Excel.XlSheetVisibility.xlSheetVisible;

        Excel.Range rango;
        #endregion ConfigurarExcel
        #region DeclararDataSets
        //Grupo 1
        DataSet dsLlamadas = new DataSet();
        DataSet dsLlamadaAval = new DataSet();
        DataSet dsCampo = new DataSet();
        DataSet dsCartaCobranza = new DataSet();
        DataSet dsSMS = new DataSet();
        DataSet dsIVR = new DataSet();
        DataSet dsCorreo = new DataSet();

        //Grupo 2
        DataSet dsLlamadaDelCliente = new DataSet();
        DataSet dsLlamadaDelAval = new DataSet();
        DataSet dsCartaDelCliente = new DataSet();
        DataSet dsVisitaDelCliente = new DataSet();
        //dsGestiones = ReturnDataSet(CodigosGestiones);

        //Llenando DataSets Grupo 1
        dsLlamadas = ReturnDataSet(1, fechas[0, 0]);
        dsLlamadaAval = ReturnDataSet(2, fechas[0, 0]);
        dsCampo = ReturnDataSet(3, fechas[0, 0]);
        dsCartaCobranza = ReturnDataSet(4, fechas[0, 0]);
        dsSMS = ReturnDataSet(5, fechas[0, 0]);
        dsIVR = ReturnDataSet(6, fechas[0, 0]);
        dsCorreo = ReturnDataSet(7, fechas[0, 0]);

        //Llenando DataSets Grupo 2
        dsLlamadaDelCliente = ReturnDataSet(8, fechas[0, 0]);
        dsLlamadaDelAval = ReturnDataSet(9, fechas[0, 0]);
        dsCartaDelCliente = ReturnDataSet(10, fechas[0, 0]);
        dsVisitaDelCliente = ReturnDataSet(11, fechas[0, 0]);
        #endregion
        #region Cabecera1
        rango = (Excel.Range)hojaExcel.Cells[1, 2];
        System.Drawing.Image logo = System.Drawing.Image.FromFile(Server.MapPath("~/imagenes/gestionInfLogo3.png"));
        hojaExcel.Shapes.AddPicture(Server.MapPath("~/imagenes/gestionInfLogo3.png"), MsoTriState.msoFalse, MsoTriState.msoCTrue, float.Parse(rango.Left.ToString()), float.Parse(rango.Top.ToString()), logo.Width, logo.Height);
        rango.RowHeight = 75;

        rango = hojaExcel.Range["A1:B1"];
        rango.ColumnWidth = 4.14;
        rango = hojaExcel.Range["C1"];
        rango.ColumnWidth = 40;

        rango = hojaExcel.Range["B2:C2"];
        rango.Merge();
        rango.Value = "DÍA-MES";
        rango.Interior.ColorIndex = 23;
        rango.Font.Bold = true;
        rango.Font.Size = 13;
        rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
        rango.BorderAround2();
        rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
        rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

        rango = hojaExcel.Range["B3:C3"];
        rango.Merge();
        rango.Value = "GESTIONES REALIZADAS";
        rango.Interior.ColorIndex = 40;
        rango.Font.Bold = true;
        rango.Font.Size = 14;
        rango.Font.Italic = true;
        rango.BorderAround2();
        rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
        rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

        //Insertar Fechas
        for (int i = 1; i < diaFechaReporte + 1; i++)
        {
            rango = (Excel.Range)hojaExcel.Cells[2, i + 3];
            rango.Value = fechas[i - 1, 1];
            rango.Interior.ColorIndex = 15;
            rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

            rango = (Excel.Range)hojaExcel.Cells[3, i + 3];
            rango.Value = fechas[i - 1, 0];
            rango.Interior.ColorIndex = 15;
            rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
        }
        #endregion Cabecera1

        #region Cabecera2
        rango = (Excel.Range)hojaExcel2.Cells[1, 2];
        System.Drawing.Image logo2 = System.Drawing.Image.FromFile(Server.MapPath("~/imagenes/gestionInfLogo3.png"));
        hojaExcel2.Shapes.AddPicture(Server.MapPath("~/imagenes/gestionInfLogo3.png"), MsoTriState.msoFalse, MsoTriState.msoCTrue, float.Parse(rango.Left.ToString()), float.Parse(rango.Top.ToString()), logo2.Width, logo2.Height);
        rango.RowHeight = 75;

        rango = hojaExcel2.Range["A1:B1"];
        rango.ColumnWidth = 4.14;
        rango = hojaExcel2.Range["C1"];
        rango.ColumnWidth = 40;

        rango = hojaExcel2.Range["B2:C2"];
        rango.Merge();
        rango.Value = "DÍA-MES";
        rango.Interior.ColorIndex = 23;
        rango.Font.Bold = true;
        rango.Font.Size = 13;
        rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
        rango.BorderAround2();
        rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
        rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

        rango = hojaExcel2.Range["B3:C3"];
        rango.Merge();
        rango.Value = "GESTIONES REALIZADAS";
        rango.Interior.ColorIndex = 40;
        rango.Font.Bold = true;
        rango.Font.Size = 14;
        rango.Font.Italic = true;
        rango.BorderAround2();
        rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
        rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

        //Insertar Fechas
        for (int i = 1; i < diaFechaReporte + 1; i++)
        {
            rango = (Excel.Range)hojaExcel2.Cells[2, i + 3];
            rango.Value = fechas[i - 1, 1];
            rango.Interior.ColorIndex = 15;
            rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

            rango = (Excel.Range)hojaExcel2.Cells[3, i + 3];
            rango.Value = fechas[i - 1, 0];
            rango.Interior.ColorIndex = 15;
            rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
        }
        #endregion Cabecera2


        filaBaseGestiones = 4;
        MostrarResultados(hojaExcel, dsLlamadas, fechas, diaFechaReporte, 1, 1, 2, 3, 1);
        MostrarResultados(hojaExcel, dsLlamadaAval, fechas, diaFechaReporte, 2, 4, 5, 6, 1);
        MostrarResultados(hojaExcel, dsCampo, fechas, diaFechaReporte, 3, 7, 8, 9, 1);
        MostrarResultados(hojaExcel, dsCartaCobranza, fechas, diaFechaReporte, 4, 10, 11, 0, 1);
        MostrarResultados(hojaExcel, dsSMS, fechas, diaFechaReporte, 5, 12, 13, 0, 1);
        MostrarResultados(hojaExcel, dsIVR, fechas, diaFechaReporte, 6, 14, 15, 0, 1);
        MostrarResultados(hojaExcel, dsCorreo, fechas, diaFechaReporte, 7, 16, 17, 0, 1);

        filaBaseGestiones = 4;
        MostrarResultados(hojaExcel2, dsLlamadas, fechas, diaFechaReporte, 1, 1, 2, 3, 2);
        MostrarResultados(hojaExcel2, dsLlamadaAval, fechas, diaFechaReporte, 2, 4, 5, 6, 2);
        MostrarResultados(hojaExcel2, dsCampo, fechas, diaFechaReporte, 3, 7, 8, 9, 2);
        MostrarResultados(hojaExcel2, dsCartaCobranza, fechas, diaFechaReporte, 4, 10, 11, 0, 2);
        MostrarResultados(hojaExcel2, dsSMS, fechas, diaFechaReporte, 5, 12, 13, 0, 2);
        MostrarResultados(hojaExcel2, dsIVR, fechas, diaFechaReporte, 6, 14, 15, 0, 2);
        MostrarResultados(hojaExcel2, dsCorreo, fechas, diaFechaReporte, 7, 16, 17, 0, 2);

        #region Cabecera_hoja1

        filaBaseGestiones = filaBaseGestiones + 1;
        filaBaseGestionesSTR = filaBaseGestiones.ToString();
        rango = hojaExcel.Range["B" + filaBaseGestionesSTR + ":C" + filaBaseGestionesSTR];
        rango.Merge();
        rango.Value = "DÍA-MES";
        rango.Interior.ColorIndex = 23;
        rango.Font.Bold = true;
        rango.Font.Size = 13;
        rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
        rango.BorderAround2();
        rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
        rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

        //h2
        rango = hojaExcel2.Range["B" + filaBaseGestionesSTR + ":C" + filaBaseGestionesSTR];
        rango.Merge();
        rango.Value = "DÍA-MES";
        rango.Interior.ColorIndex = 23;
        rango.Font.Bold = true;
        rango.Font.Size = 13;
        rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
        rango.BorderAround2();
        rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
        rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

        //h1
        filaBaseGestiones++;
        filaBaseGestionesSTR = filaBaseGestiones.ToString();
        rango = hojaExcel.Range["B" + filaBaseGestionesSTR + ":C" + filaBaseGestionesSTR];
        rango.Merge();
        rango.Value = "GESTIONES RECIBIDAS";
        rango.Interior.ColorIndex = 40;
        rango.Font.Bold = true;
        rango.Font.Size = 14;
        rango.Font.Italic = true;
        rango.BorderAround2();
        rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
        rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

        //h2
        rango = hojaExcel2.Range["B" + filaBaseGestionesSTR + ":C" + filaBaseGestionesSTR];
        rango.Merge();
        rango.Value = "GESTIONES RECIBIDAS";
        rango.Interior.ColorIndex = 40;
        rango.Font.Bold = true;
        rango.Font.Size = 14;
        rango.Font.Italic = true;
        rango.BorderAround2();
        rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
        rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

        filaBaseGestiones++;
        filaBaseGestionesSTR = filaBaseGestiones.ToString();

        int filaHoja2 = filaBaseGestiones;
        string filaHoja2STR = filaBaseGestionesSTR;

        //Insertar Fechas
        for (int i = 1; i < diaFechaReporte + 1; i++)
        {
            rango = (Excel.Range)hojaExcel.Cells[filaBaseGestiones - 2, i + 3];
            rango.Value = fechas[i - 1, 1];
            rango.Interior.ColorIndex = 15;
            rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

            rango = (Excel.Range)hojaExcel.Cells[filaBaseGestiones - 1, i + 3];
            rango.Value = fechas[i - 1, 0];
            rango.Interior.ColorIndex = 15;
            rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
        }
        #endregion Cabecera_hoja1

        #region Cabecera_hoja2

        //Insertar Fechas
        for (int i = 1; i < diaFechaReporte + 1; i++)
        {
            rango = (Excel.Range)hojaExcel2.Cells[filaBaseGestiones - 2, i + 3];
            rango.Value = fechas[i - 1, 1];
            rango.Interior.ColorIndex = 15;
            rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

            rango = (Excel.Range)hojaExcel2.Cells[filaBaseGestiones - 1, i + 3];
            rango.Value = fechas[i - 1, 0];
            rango.Interior.ColorIndex = 15;
            rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
        }
        #endregion Cabecera_hoja2

        MostrarResultados(hojaExcel, dsLlamadaDelCliente, fechas, diaFechaReporte, 1, 18, 0, 0, 1);
        MostrarResultados(hojaExcel, dsLlamadaDelAval, fechas, diaFechaReporte, 2, 19, 0, 0, 1);
        MostrarResultados(hojaExcel, dsCartaDelCliente, fechas, diaFechaReporte, 3, 20, 0, 0, 1);
        MostrarResultados(hojaExcel, dsVisitaDelCliente, fechas, diaFechaReporte, 4, 21, 0, 0, 1);

        filaBaseGestiones++;
        filaBaseGestionesSTR = filaBaseGestiones.ToString();

        filaBaseGestiones = filaHoja2;
        filaBaseGestionesSTR = filaHoja2STR;

        MostrarResultados(hojaExcel2, dsLlamadaDelCliente, fechas, diaFechaReporte, 1, 18, 0, 0, 2);
        MostrarResultados(hojaExcel2, dsLlamadaDelAval, fechas, diaFechaReporte, 2, 19, 0, 0, 2);
        MostrarResultados(hojaExcel2, dsCartaDelCliente, fechas, diaFechaReporte, 3, 20, 0, 0, 2);
        MostrarResultados(hojaExcel2, dsVisitaDelCliente, fechas, diaFechaReporte, 4, 21, 0, 0, 2);

        #region Llamadas
        ////Insertar Gestiones Realizadas
        ////Insertar Clasifica
        //filaBaseGestiones = 4;

        //rango = (Excel.Range)hojaExcel.Cells[filaBaseGestiones, 2];
        //rango.Value = "1";
        //rango.BorderAround2();
        //rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
        //rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

        //rango = (Excel.Range)hojaExcel.Cells[filaBaseGestiones, 3];
        //rango.Value = dsLlamadas.Tables[0].Rows[1].ItemArray[2];
        //rango.BorderAround2();

        //rango = hojaExcel.Range["B" + filaBaseGestiones + ":C" + filaBaseGestiones];
        //rango.Interior.ColorIndex = 43;
        //rango.Font.Bold = true;
        //rango.Font.Size = 12;
        //rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
        //rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

        ////Insertar Clasificaciones
        //for (int i = 0; i < cantidadClasificaciones; i++)
        //{
        //    rango = (Excel.Range)hojaExcel.Cells[5 + i, 3];
        //    rango.Value = dsLlamadas.Tables[0].Rows[i].ItemArray[4];
        //    rango.ColumnWidth = 40;
        //    rango.Interior.ColorIndex = 45;
        //}

        ////Insertar Conteo de Clasificaciones día a día
        //for (int i = 1; i < diaFechaReporte + 1; i++)
        //{
        //    dsLlamadas = ReturnDataSet(1, fechas[i - 1, 0]);
        //    for (int j = 0; j < cantidadClasificaciones; j++)
        //    {
        //        rango = (Excel.Range)hojaExcel.Cells[4 + j + 1, 3 + i];
        //        rango.Value = dsLlamadas.Tables[0].Rows[j].ItemArray[5];
        //        if (i % 2 == 0)
        //        {
        //            rango.Interior.ColorIndex = 24;
        //        }
        //        if ((4 + j + 1) == cantCD + 4 || (4 + j + 1) == (cantCD + 4 + cantCI))// || (4 + j + 1) == (cantCD + 4 + cantCI + cantNC))                   
        //        {
        //            rango.Rows.Cells.Borders.Item[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
        //        }
        //    }
        //}
        //filaBaseGestiones = 4 + cantidadClasificaciones;
        #endregion Llamadas



        #region GuardarDocumento
        hojaExcel.Name = "DETALLE";
        hojaExcel2.Name = "RESUMEN";
        //Guardando el documento
        DateTime fecha = DateTime.Now;
        //var cultura = new CultureInfo("en-GB");
        string strFecha = fecha.ToString(culturaGb);
        string[] diaHora = strFecha.Split(' ');
        string dia = diaHora[0];
        string hora = diaHora[1];
        diaHora = dia.Split('/');
        strFecha = diaHora[0].ToString() + diaHora[1].ToString() + diaHora[2].ToString();
        diaHora = hora.Split(':');
        strFecha = strFecha + "-" + diaHora[0].ToString() + diaHora[1].ToString() + diaHora[2].ToString();
        //hojaExcel.SaveAs("CRProductividad-" + strFecha);
        //hojaExcel2.SaveAs("CRProductividad-" + strFecha);
        libroExcel.SaveAs("CRProductividad-" + strFecha);
        #endregion GuardarDocumento

    }


    private DataSet ReturnDataSet(int codigoGestion, string fecha)
    {
        DataSet ds = new DataSet();
        System.Data.DataTable dt = new System.Data.DataTable();

        LoGS_Gestion_Cobranza objLogica = new LoGS_Gestion_Cobranza();
        EnGS_Gestion_Cobranza objEntidad = new EnGS_Gestion_Cobranza();
        List<EnGS_Gestion_Cobranza> ListEntidad = new List<EnGS_Gestion_Cobranza>();

        string str_nempresa = (String)Request["nempresa"];
        string str_fecha = fecha;
        string str_codTipoGestion = codigoGestion.ToString();
        string str_jerarquia_b = (String)Request["jerarquiab"];
        string str_jerarquia_c = (String)Request["jerarquiac"];
        string str_jerarquia_d = (String)Request["jerarquiad"];
        objEntidad.nEmpresa = str_nempresa;
        objEntidad.FechaResultado = str_fecha;
        objEntidad.CodTipoGestion = str_codTipoGestion;
        objEntidad.cod_jerarquiaB = str_jerarquia_b;
        objEntidad.cod_jerarquiaC = str_jerarquia_c;
        objEntidad.cod_jerarquiaD = str_jerarquia_d;
        ListEntidad.Add(objEntidad);
        dt = objLogica.RPT_CRProductividad_Gestiones(ListEntidad);
        ds.Tables.Add(dt.Copy());
        ds.Tables[0].TableName = "DTGestiones";

        return ds;
    }

    private void MostrarResultados(Excel._Worksheet hojaExcel, DataSet ds, string[,] fechas, int diaFechaReporte, int orden, int ejecutadoCD, int ejecutadoCI, int ejecutadoNC, int hoja)
    {
        Excel.Range rango;
        cantidadClasificaciones = ds.Tables[0].Rows.Count;
        contadorClasificaciones = 0;
        ejecutado = 0;
        cantCD = 0;
        cantCI = 0;
        cantNC = 0;

        filaBaseGestiones++;

        while (contadorClasificaciones < cantidadClasificaciones)
        {
            ejecutado = int.Parse(ds.Tables[0].Rows[contadorClasificaciones].ItemArray[6].ToString());
            if (ejecutado == ejecutadoCD)
            {
                cantCD++;
                if (cd == "") cd = ds.Tables[0].Rows[contadorClasificaciones].ItemArray[7].ToString();
            }
            else if (ejecutado == ejecutadoCI)
            {
                cantCI++;
                if (ci == "") ci = ds.Tables[0].Rows[contadorClasificaciones].ItemArray[7].ToString();
            }
            else if (ejecutado == ejecutadoNC)
            {
                cantNC++;
                if (nc == "") nc = ds.Tables[0].Rows[contadorClasificaciones].ItemArray[7].ToString();
            }
            contadorClasificaciones++;
        }

        #region Ejecutado
        //filaBaseGestionesSTR = filaBaseGestiones.ToString();
        //rango = hojaExcel.Range["B" + filaBaseGestionesSTR + ":B" + (cantCD + filaBaseGestiones - 1).ToString()];
        //rango.Merge();
        //rango.Value = cd;
        //rango.BorderAround2();

        //rango = hojaExcel.Range["B" + (cantCD + filaBaseGestiones).ToString() + ":B" + (cantCD + filaBaseGestiones + cantCI -1).ToString()];
        //rango.Merge();
        //rango.Value = ci;
        //rango.BorderAround2();

        //rango = hojaExcel.Range["B" + (cantCD + filaBaseGestiones + cantCI).ToString() + ":B" + (cantCD + filaBaseGestiones + cantCI + cantNC - 1).ToString()];
        //rango.Merge();
        //rango.Value = nc;
        //rango.BorderAround2();

        //rango = hojaExcel.Range["B" + filaBaseGestionesSTR + ":B" + (cantCD + filaBaseGestiones + cantCI + cantNC - 1).ToString()];
        //rango.Orientation = 90;
        //rango.ColumnWidth = 6.14;
        //rango.WrapText = true;
        //rango.Font.Bold = true;
        //rango.Font.Size = 11;
        //rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
        //rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
        //rango.Interior.ColorIndex = 27;
        #endregion Ejecutado

        //Data
        rango = (Excel.Range)hojaExcel.Cells[filaBaseGestiones - 1, 2];
        rango.Value = orden.ToString();
        rango.Font.Bold = true;
        rango.BorderAround2();
        rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
        rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

        rango = (Excel.Range)hojaExcel.Cells[filaBaseGestiones - 1, 3];
        rango.Value = ds.Tables[0].Rows[0].ItemArray[2];
        rango.BorderAround2();

        rango = hojaExcel.Range["B" + (filaBaseGestiones - 1).ToString() + ":C" + (filaBaseGestiones - 1).ToString()];
        rango.Interior.ColorIndex = 43;
        rango.Font.Bold = true;
        rango.Font.Size = 12;
        rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
        rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;



        //Insertar Clasificaciones
        int codTipoGestion = 0;
        string formula = "";
        string columna = "";
        int filaCD = 0;
        int filaCI = 0;
        int filaNC = 0;
        string celdaCD = "";
        string celdaCI = "";
        string celdaNC = "";
        //Insertar CD
        if (cantCD != 0)
        {
            rango = hojaExcel.Range["B" + (filaBaseGestiones).ToString() + ":C" + (filaBaseGestiones).ToString()];
            rango.Merge();
            rango.Value = ds.Tables[0].Rows[0].ItemArray[7].ToString();
            rango.Font.Size = 12;
            rango.Font.Bold = true;
            rango.Interior.ColorIndex = 27;
            rango.BorderAround2();
            rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            filaBaseGestiones++;
            filaBaseGestionesSTR = filaBaseGestiones.ToString();

            for (int i = 0; i < cantCD; i++)
            {
                rango = (Excel.Range)hojaExcel.Cells[filaBaseGestiones + i, 2];
                rango.Value = (i + 1).ToString();
                rango.Font.Size = 11;
                rango.Font.Bold = true;
                rango.Interior.ColorIndex = 45;
                rango.BorderAround2();
                rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                rango = (Excel.Range)hojaExcel.Cells[filaBaseGestiones + i, 3];
                rango.Value = ds.Tables[0].Rows[i].ItemArray[4];
                rango.ColumnWidth = 40;
                rango.Interior.ColorIndex = 45;
                rango.BorderAround2();

                if (hoja == 2)
                {
                    Excel.Range fila = rango.EntireRow;
                    fila.Hidden = true;
                }
            }

            //Insertar Conteo de Clasificaciones día a día
            codTipoGestion = 0;
            for (int i = 1; i < diaFechaReporte + 1; i++)
            {
                filaCD = filaBaseGestiones - 1;
                //Consolidado Tipo Gestión
                rango = (Excel.Range)hojaExcel.Cells[filaBaseGestiones - 2, 3 + i];
                rango.Interior.ColorIndex = 43;


                //Consolidado Contactabilidad
                columna = Columna(i + 3);
                rango = (Excel.Range)hojaExcel.Cells[filaBaseGestiones - 1, 3 + i];
                formula = "=SUM(" + columna + filaBaseGestiones.ToString() + ":" + columna + (filaBaseGestiones + cantCD - 1).ToString() + ")";
                rango.Value = formula;
                rango.Interior.ColorIndex = 27;
                rango.Font.Bold = true;

                codTipoGestion = int.Parse(ds.Tables[0].Rows[0].ItemArray[1].ToString());
                ds = ReturnDataSet(codTipoGestion, fechas[i - 1, 0]);
                for (int j = 0; j < cantCD; j++)
                {
                    rango = (Excel.Range)hojaExcel.Cells[filaBaseGestiones + j, 3 + i];
                    rango.Value = ds.Tables[0].Rows[j].ItemArray[5];
                    if (i % 2 == 0)
                    {
                        rango.Interior.ColorIndex = 24;
                    }
                }
            }
            filaBaseGestiones = filaBaseGestiones + cantCD;
            filaBaseGestionesSTR = filaBaseGestiones.ToString();
        }


        //Insertar CI
        if (cantCI != 0)
        {
            rango = hojaExcel.Range["B" + (filaBaseGestiones).ToString() + ":C" + (filaBaseGestiones).ToString()];
            rango.Merge();
            rango.Value = ds.Tables[0].Rows[0 + cantCD].ItemArray[7].ToString();
            rango.Font.Size = 12;
            rango.Font.Bold = true;
            rango.Interior.ColorIndex = 27;
            rango.BorderAround2();
            rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            filaBaseGestiones++;
            filaBaseGestionesSTR = filaBaseGestiones.ToString();

            for (int i = 0; i < cantCI; i++)
            {
                rango = (Excel.Range)hojaExcel.Cells[filaBaseGestiones + i, 2];
                rango.Value = (i + 1).ToString();
                rango.Font.Size = 11;
                rango.Font.Bold = true;
                rango.Interior.ColorIndex = 45;
                rango.BorderAround2();
                rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                rango = (Excel.Range)hojaExcel.Cells[filaBaseGestiones + i, 3];
                rango.Value = ds.Tables[0].Rows[i + cantCD].ItemArray[4];
                rango.ColumnWidth = 40;
                rango.Interior.ColorIndex = 45;
                rango.BorderAround2();

                if (hoja == 2)
                {
                    Excel.Range fila = rango.EntireRow;
                    fila.Hidden = true;
                }
            }

            //Insertar Conteo de Clasificaciones día a día
            codTipoGestion = 0;
            for (int i = 1; i < diaFechaReporte + 1; i++)
            {
                filaCI = filaBaseGestiones - 1;
                //Consolidado Contactabilidad
                rango = (Excel.Range)hojaExcel.Cells[filaBaseGestiones - 1, 3 + i];
                columna = Columna(i + 3);
                formula = "=SUM(" + columna + (filaBaseGestiones).ToString() + ":" + columna + (filaBaseGestiones + cantCI - 1).ToString() + ")";
                rango.Value = formula;
                rango.Interior.ColorIndex = 27;
                rango.Font.Bold = true;

                codTipoGestion = int.Parse(ds.Tables[0].Rows[0].ItemArray[1].ToString());
                ds = ReturnDataSet(codTipoGestion, fechas[i - 1, 0]);
                for (int j = 0; j < cantCI; j++)
                {
                    rango = (Excel.Range)hojaExcel.Cells[filaBaseGestiones + j, 3 + i];
                    rango.Value = ds.Tables[0].Rows[j + cantCD].ItemArray[5];
                    if (i % 2 == 0)
                    {
                        rango.Interior.ColorIndex = 24;
                    }
                }
            }
            filaBaseGestiones = filaBaseGestiones + cantCI;
            filaBaseGestionesSTR = filaBaseGestiones.ToString();
        }


        //Insertar NC
        if (cantNC != 0)
        {
            rango = hojaExcel.Range["B" + (filaBaseGestiones).ToString() + ":C" + (filaBaseGestiones).ToString()];
            rango.Merge();
            rango.Value = ds.Tables[0].Rows[0 + cantCD + cantCI].ItemArray[7].ToString();
            rango.Font.Size = 12;
            rango.Font.Bold = true;
            rango.Interior.ColorIndex = 27;
            rango.BorderAround2();
            rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            filaBaseGestiones++;
            filaBaseGestionesSTR = filaBaseGestiones.ToString();

            for (int i = 0; i < cantNC; i++)
            {
                rango = (Excel.Range)hojaExcel.Cells[filaBaseGestiones + i, 2];
                rango.Value = (i + 1).ToString();
                rango.Font.Size = 11;
                rango.Font.Bold = true;
                rango.Interior.ColorIndex = 45;
                rango.BorderAround2();
                rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                if (hoja == 2)
                {
                    Excel.Range fila = rango.EntireRow;
                    fila.Hidden = true;
                }

                rango = (Excel.Range)hojaExcel.Cells[filaBaseGestiones + i, 3];
                rango.Value = ds.Tables[0].Rows[i + cantCD + cantCI].ItemArray[4];
                rango.ColumnWidth = 40;
                rango.Interior.ColorIndex = 45;
                rango.BorderAround2();

                if (hoja == 2)
                {
                    Excel.Range fila = rango.EntireRow;
                    fila.Hidden = true;//rango.Hidden=true;
                }
            }

            //Insertar Conteo de Clasificaciones día a día
            codTipoGestion = 0;
            for (int i = 1; i < diaFechaReporte + 1; i++)
            {
                filaNC = filaBaseGestiones - 1;
                //Consolidado Contactabilidad
                rango = (Excel.Range)hojaExcel.Cells[filaBaseGestiones - 1, 3 + i];
                columna = Columna(i + 3);
                formula = "=SUM(" + columna + (filaBaseGestiones).ToString() + ":" + columna + (filaBaseGestiones + cantNC - 1).ToString() + ")";
                rango.Value = formula;
                rango.Interior.ColorIndex = 27;
                rango.Font.Bold = true;

                codTipoGestion = int.Parse(ds.Tables[0].Rows[0 + cantCD + cantCI].ItemArray[1].ToString());
                ds = ReturnDataSet(codTipoGestion, fechas[i - 1, 0]);
                for (int j = 0; j < cantNC; j++)
                {
                    rango = (Excel.Range)hojaExcel.Cells[filaBaseGestiones + j, 3 + i];
                    rango.Value = ds.Tables[0].Rows[j + cantCD + cantCI].ItemArray[5];
                    if (i % 2 == 0)
                    {
                        rango.Interior.ColorIndex = 24;
                    }
                    if (hoja == 2)
                    {
                        Excel.Range fila = rango.EntireRow;
                        fila.Hidden = true;
                    }
                }
            }
            filaBaseGestiones = filaBaseGestiones + cantNC;
            filaBaseGestionesSTR = filaBaseGestiones.ToString();
        }

        for (int i = 1; i < diaFechaReporte + 1; i++)
        {
            columna = Columna(i + 3);
            if (filaCD == 0)
            {
                celdaCD = "";
            }
            else
            {
                celdaCD = columna + filaCD.ToString();
            }
            if (filaCI == 0)
            {
                celdaCI = "";
            }
            else
            {
                celdaCI = "," + columna + filaCI.ToString();
            }
            if (filaNC == 0)
            {
                celdaNC = "";
            }
            else
            {
                celdaNC = "," + columna + filaNC.ToString();
            }
            rango = (Excel.Range)hojaExcel.Cells[filaCD - 1, 3 + i];
            formula = "=SUM(" + celdaCD + celdaCI + celdaNC + ")";
            rango.Value = formula;
        }
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
            case 27:
                columna = "AA";
                break;
            case 28:
                columna = "AB";
                break;
            case 29:
                columna = "AC";
                break;
            case 30:
                columna = "AD";
                break;
            case 31:
                columna = "AE";
                break;
            case 32:
                columna = "AF";
                break;
            case 33:
                columna = "AG";
                break;
            case 34:
                columna = "AH";
                break;
            case 35:
                columna = "AI";
                break;
            default:
                break;
        }

        return columna;
    }


    
}