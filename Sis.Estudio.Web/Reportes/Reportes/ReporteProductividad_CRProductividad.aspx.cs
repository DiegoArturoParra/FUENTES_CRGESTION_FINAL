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

public partial class Reportes_Reportes_ReporteProductividad_CRProductividad : System.Web.UI.Page
{
    //Variables Globales
    DataSet ldsResultado;
    DataSet dsGrupos = new DataSet();
    DataSet dsTipoGestiones = new DataSet();
    DataSet dsEjecutados = new DataSet();
    DataSet dsClasificaciones = new DataSet();
    string fechaReporte = "";


    protected void Page_Load(object sender, EventArgs e)
    {
        string fechaReporte = (String)Request["fecha"];
        string[] fechaReporteArray = fechaReporte.Split('/');
        int diaFechaReporte = int.Parse(fechaReporteArray[0].ToString());
        dsGrupos = ObtenerGrupos(fechaReporte);                                 //RPT_CRProductividad_Grupos
        dsTipoGestiones = ObtenerTipoGestionXGrupo(fechaReporte, 0);            //RPT_CRProductividad_TipoGestionesXGrupo
        dsEjecutados = ObtenerResultadoXTipoGestion(fechaReporte, 0);           //RPT_CRProductividad_EjecutadoXTipoGestion
        dsClasificaciones = ObtenerClasificacionXResultado(fechaReporte, 0);    //RPT_CRProductividad_ClaseGestionesXEjecutado
        Exportar();

        //ldsResultado =

        this.mxCrearHojasParaLibroExcel(fechaReporte);
    }

    protected void mxCrearHojasParaLibroExcel(string fechaReporte)
    {

        this.mxObtenerResultadoReporteProductividad(fechaReporte);

    }

    private void Exportar()
    {
        //Culturas:
        var culturaGb = new CultureInfo("en-GB");
        var culturaEs = new CultureInfo("es-MX");

        //Cofigurar Archivo.
        #region ConfigurarDocumento
        Excel.Application archivoExcel = default(Excel.Application);
        Excel.Workbook libroExcel = default(Excel.Workbook);
        archivoExcel = new Excel.Application();
        libroExcel = archivoExcel.Workbooks.Add();
        //archivoExcel.Visible = true;
        #endregion ConfigurarDocumento

        Resumen(libroExcel);
        GestionesRealizadas(libroExcel);
        GestionesRecibidas(libroExcel);
        CuadroPorcentual(libroExcel);
        //Guardar Archivo.
        #region GuardarDocumento
        DateTime fecha = DateTime.Now;
        string strFecha = fecha.ToString(culturaGb);
        string[] diaHora = strFecha.Split(' ');
        string dia = diaHora[0];
        string hora = diaHora[1];
        diaHora = dia.Split('/');
        strFecha = diaHora[0].ToString() + diaHora[1].ToString() + diaHora[2].ToString();
        diaHora = hora.Split(':');
        strFecha = strFecha + "-" + diaHora[0].ToString() + diaHora[1].ToString() + diaHora[2].ToString();

        //// do the work
        string path = "C:/EXCEL/";
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        string name = path + "CRProductividad-" + strFecha + ".xls";
        archivoExcel.Save(name);
        //return File(name, "Application/x-msexcel");
        //libroExcel.Save(name);
        //libroExcel.Save();
        libroExcel.Close();
        mxDescargarReporteProductividad(name);


        #endregion GuardarDocumento
    }



    private void mxDescargarReporteProductividad(string pcName)
    {
        //string name = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".xls";
        string lcNomArchivo = pcName;
        string lcArcDestino = "ReporteProductividad.xls";
        this.mxDescargarArchivo(lcNomArchivo, lcArcDestino);
    }
    private void mxDescargarArchivo(string pcNomArchivo, string pcArcDestino)
    {
        if (!string.IsNullOrEmpty(pcNomArchivo))
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=" + pcArcDestino);
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.xls";
            Response.TransmitFile(pcNomArchivo);
            Response.End();
        }
    }

    //public FilePathResult GetFile()
    //{
    //    string name = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".xls";
    //    // do the work
    //    xlWorksheet.Save(name);
    //    return File(name, "Application/x-msexcel");
    //}
 

    private void Resumen(Excel.Workbook libroExcel)
    {
        //Configuración de la primera hoja.
        Excel.Worksheet resumenExcel = new Excel.Worksheet();
        resumenExcel = (Excel.Worksheet)libroExcel.Worksheets.Add();
        resumenExcel = (Excel.Worksheet)libroExcel.Worksheets[1];
        resumenExcel.Visible = Excel.XlSheetVisibility.xlSheetVisible;
        resumenExcel.Name = "RESUMEN";
        int fila, filaDSGrupo, filaDSTipoGestion, filaDSEjecutado, filaDSClasificacion;
        int codigoGrupo = 0;
        int codigoTipoGestion = 0;
        int codigoEjecutado = 0;
        int cantTipoGestion = dsTipoGestiones.Tables[0].Rows.Count;
        int cantEjecutados = 0;
        int cantClasificaciones = 0;
        int[] resultados = new int[3];

        MostrarEncabezado(resumenExcel);
        fila = 7;
        for (int i = 1; i < 3; i++)
        {
            resultados = MostrarGrupos(resumenExcel, dsGrupos, i, fila, 1);
            fila = resultados[0];
            codigoGrupo = resultados[1];
            cantTipoGestion = resultados[2];
            filaDSTipoGestion = FilaDS(dsTipoGestiones, codigoGrupo, 't');
            for (int j = 0; j < cantTipoGestion; j++)
            {
                resultados = MostrarTipoGestiones(resumenExcel, dsTipoGestiones, codigoGrupo, j + filaDSTipoGestion, fila, 1);
                fila = resultados[0];
                codigoTipoGestion = resultados[1];
                cantEjecutados = resultados[2];
                filaDSEjecutado = FilaDS(dsEjecutados, codigoTipoGestion, 'e');
                for (int k = 0; k < cantEjecutados; k++)
                {
                    resultados = MostrarEjecutados(resumenExcel, dsEjecutados, codigoTipoGestion, k + filaDSEjecutado, fila, 1);
                    fila = resultados[0];
                    codigoEjecutado = resultados[1];
                    cantClasificaciones = resultados[2];
                    filaDSClasificacion = FilaDS(dsClasificaciones, codigoEjecutado, 'c');
                }
            }
        }
    }
    private void GestionesRealizadas(Excel.Workbook libroExcel)
    {
        //Configuración de la segunda hoja.
        Excel.Worksheet realizadasExcel = new Excel.Worksheet();
        realizadasExcel = (Excel.Worksheet)libroExcel.Worksheets[2];
        realizadasExcel.Visible = Excel.XlSheetVisibility.xlSheetVisible;
        realizadasExcel.Name = "GESTIONES REALIZADAS";
        int fila, filaDSGrupo, filaDSTipoGestion, filaDSEjecutado, filaDSClasificacion;
        int codigoGrupo = 0;
        int codigoTipoGestion = 0;
        int codigoEjecutado = 0;
        int cantTipoGestion = dsTipoGestiones.Tables[0].Rows.Count;
        int cantEjecutados = 0;
        int cantClasificaciones = 0;
        int[] resultados = new int[3];

        MostrarEncabezado(realizadasExcel);
        fila = 7;
        resultados = MostrarGrupos(realizadasExcel, dsGrupos, 1, fila, 1);
        fila = resultados[0];
        codigoGrupo = resultados[1];
        cantTipoGestion = resultados[2];
        filaDSTipoGestion = FilaDS(dsTipoGestiones, codigoGrupo, 't');
        for (int i = 0; i < cantTipoGestion; i++)
        {
            resultados = MostrarTipoGestiones(realizadasExcel, dsTipoGestiones, codigoGrupo, i + filaDSTipoGestion, fila, 1);
            fila = resultados[0];
            codigoTipoGestion = resultados[1];
            cantEjecutados = resultados[2];
            filaDSEjecutado = FilaDS(dsEjecutados, codigoTipoGestion, 'e');
            for (int j = 0; j < cantEjecutados; j++)
            {
                resultados = MostrarEjecutados(realizadasExcel, dsEjecutados, codigoTipoGestion, j + filaDSEjecutado, fila, 1);
                fila = resultados[0];
                codigoEjecutado = resultados[1];
                cantClasificaciones = resultados[2];
                filaDSClasificacion = FilaDS(dsClasificaciones, codigoEjecutado, 'c');
                for (int k = 0; k < cantClasificaciones; k++)
                {
                    resultados = MostrarClasificaciones(realizadasExcel, dsClasificaciones, codigoEjecutado, k + filaDSClasificacion, fila, 1);
                    fila = resultados[0];
                }
            }
        }
    }
    private void GestionesRecibidas(Excel.Workbook libroExcel)
    {
        //Configuración de la segunda hoja.
        Excel.Worksheet recibidasExcel = new Excel.Worksheet();
        recibidasExcel = (Excel.Worksheet)libroExcel.Worksheets[3];
        recibidasExcel.Visible = Excel.XlSheetVisibility.xlSheetVisible;
        recibidasExcel.Name = "GESTIONES RECIBIDAS";
        int fila, filaDSGrupo, filaDSTipoGestion, filaDSEjecutado, filaDSClasificacion;
        int codigoGrupo = 0;
        int codigoTipoGestion = 0;
        int codigoEjecutado = 0;
        int cantTipoGestion = dsTipoGestiones.Tables[0].Rows.Count;
        int cantEjecutados = 0;
        int cantClasificaciones = 0;
        int[] resultados = new int[3];

        MostrarEncabezado(recibidasExcel);
        fila = 7;
        resultados = MostrarGrupos(recibidasExcel, dsGrupos, 2, fila, 1);
        fila = resultados[0];
        codigoGrupo = resultados[1];
        cantTipoGestion = resultados[2];
        filaDSTipoGestion = FilaDS(dsTipoGestiones, codigoGrupo, 't');
        for (int i = 0; i < cantTipoGestion; i++)
        {
            resultados = MostrarTipoGestiones(recibidasExcel, dsTipoGestiones, codigoGrupo, i + filaDSTipoGestion, fila, 1);
            fila = resultados[0];
            codigoTipoGestion = resultados[1];
            cantEjecutados = resultados[2];
            filaDSEjecutado = FilaDS(dsEjecutados, codigoTipoGestion, 'e');
            for (int j = 0; j < cantEjecutados; j++)
            {
                resultados = MostrarEjecutados(recibidasExcel, dsEjecutados, codigoTipoGestion, j + filaDSEjecutado, fila, 1);
                fila = resultados[0];
                codigoEjecutado = resultados[1];
                cantClasificaciones = resultados[2];
                filaDSClasificacion = FilaDS(dsClasificaciones, codigoEjecutado, 'c');
                for (int k = 0; k < cantClasificaciones; k++)
                {
                    resultados = MostrarClasificaciones(recibidasExcel, dsClasificaciones, codigoEjecutado, k + filaDSClasificacion, fila, 1);
                    fila = resultados[0];
                }
            }
        }
    }
    private void CuadroPorcentual(Excel.Workbook libroExcel)
    {
        //Configuración de la segunda hoja.
        Excel.Worksheet porcentualExcel = new Excel.Worksheet();
        porcentualExcel = (Excel.Worksheet)libroExcel.Worksheets[4];
        //porcentualExcel = (Excel.Worksheet)libroExcel.Worksheets[1];
        porcentualExcel.Visible = Excel.XlSheetVisibility.xlSheetVisible;
        porcentualExcel.Name = "CUADRO PORCENTUAL";
        int fila, filaDSGrupo, filaDSTipoGestion, filaDSEjecutado, filaDSClasificacion;
        int codigoGrupo = 0;
        int codigoTipoGestion = 0;
        int codigoEjecutado = 0;
        int cantTipoGestion = dsTipoGestiones.Tables[0].Rows.Count;
        int cantEjecutados = 0;
        int cantClasificaciones = 0;
        int[] resultados = new int[3];

        MostrarEncabezado(porcentualExcel);
        fila = 7;
        for (int i = 1; i < 3; i++)
        {
            resultados = MostrarGruposCuadroPorcentual(porcentualExcel, dsGrupos, i, fila, 1);
            fila = resultados[0];
            codigoGrupo = resultados[1];
            cantTipoGestion = resultados[2];
            filaDSTipoGestion = FilaDS(dsTipoGestiones, codigoGrupo, 't');
            for (int j = 0; j < cantTipoGestion; j++)
            {
                resultados = MostrarTipoGestionesCuadroPorcentual(porcentualExcel, dsTipoGestiones, codigoGrupo, j + filaDSTipoGestion, fila, 1);
                fila = resultados[0];
                codigoTipoGestion = resultados[1];
                cantEjecutados = resultados[2];
                filaDSEjecutado = FilaDS(dsEjecutados, codigoTipoGestion, 'e');
                for (int k = 0; k < cantEjecutados; k++)
                {
                    resultados = MostrarEjecutadosCuadroPorcentual(porcentualExcel, dsEjecutados, codigoTipoGestion, k + filaDSEjecutado, fila, 1);
                    fila = resultados[0];
                    codigoEjecutado = resultados[1];
                    cantClasificaciones = resultados[2];
                    filaDSClasificacion = FilaDS(dsClasificaciones, codigoEjecutado, 'c');
                }
            }
        }
        #region PorcentualAnterior
        //MostrarEncabezado(porcentualExcel);
        //fila = 7;
        //resultados = MostrarGruposCuadroPorcentual(porcentualExcel, dsGrupos, 1, fila, 1);
        //fila = resultados[0];
        //codigoGrupo = resultados[1];
        //cantTipoGestion = resultados[2];
        //filaDSTipoGestion = FilaDS(dsTipoGestiones, codigoGrupo, 't');
        //int columna = 1;
        //for (int i = 0; i < 4; i++)
        //{
        //    fila = 11;
        //    resultados = MostrarTipoGestionesCuadroPorcentual(porcentualExcel, dsTipoGestiones, codigoGrupo, i + filaDSTipoGestion, fila, columna);
        //    fila = resultados[0];
        //    codigoTipoGestion = resultados[1];
        //    cantEjecutados = resultados[2];
        //    filaDSEjecutado = FilaDS(dsEjecutados, codigoTipoGestion, 'e');
        //    for (int j = 0; j < cantEjecutados; j++)
        //    {
        //        resultados = MostrarEjecutadosCuadroPorcentual(porcentualExcel, dsEjecutados, codigoTipoGestion, j + filaDSEjecutado, fila, columna);
        //        fila = resultados[0];
        //        codigoEjecutado = resultados[1];
        //        cantClasificaciones = resultados[2];
        //        filaDSClasificacion = FilaDS(dsClasificaciones, codigoEjecutado, 'c');
        //        for (int k = 0; k < cantClasificaciones; k++)
        //        {
        //            resultados = MostrarClasificacionesCuadroPorcentual(porcentualExcel, dsClasificaciones, codigoEjecutado, k + filaDSClasificacion, fila, columna);
        //            fila = resultados[0];
        //        }
        //    }
        //    columna = columna + 8;
        //}
        //columna = columna - 8;

        //for (int i = 4; i < cantTipoGestion; i++)
        //{
        //    resultados = MostrarTipoGestionesCuadroPorcentual(porcentualExcel, dsTipoGestiones, codigoGrupo, i + filaDSTipoGestion, fila, columna);
        //    fila = resultados[0];
        //    codigoTipoGestion = resultados[1];
        //    cantEjecutados = resultados[2];
        //    filaDSEjecutado = FilaDS(dsEjecutados, codigoTipoGestion, 'e');
        //    for (int j = 0; j < cantEjecutados; j++)
        //    {
        //        resultados = MostrarEjecutadosCuadroPorcentual(porcentualExcel, dsEjecutados, codigoTipoGestion, j + filaDSEjecutado, fila, columna);
        //        fila = resultados[0];
        //        codigoEjecutado = resultados[1];
        //        cantClasificaciones = resultados[2];
        //        filaDSClasificacion = FilaDS(dsClasificaciones, codigoEjecutado, 'c');
        //        for (int k = 0; k < cantClasificaciones; k++)
        //        {
        //            resultados = MostrarClasificacionesCuadroPorcentual(porcentualExcel, dsClasificaciones, codigoEjecutado, k + filaDSClasificacion, fila, columna);
        //            fila = resultados[0];
        //        }
        //    }
        //    //fila = fila + 1;
        //}
        #endregion PorcentualAnterior
        
    }
    private void MostrarEncabezado(Excel.Worksheet hojaExcel)
    {
        DataSet dsDatosUsuario = new DataSet();
        dsDatosUsuario = ObtenerDatosAsesor();
        Excel.Range rango;
        Excel.Range rango1;
        System.Drawing.Image logo = System.Drawing.Image.FromFile(Server.MapPath("~/imagenes/CRProductividadLogo.png"));
        //Conversión de Píxeles a Points: pixel/69*72
        hojaExcel.Shapes.AddPicture(Server.MapPath("~/imagenes/CRProductividadLogo.png"), MsoTriState.msoFalse, MsoTriState.msoCTrue, 620, 0, (logo.Width) / 96 * 80, (logo.Height) / 96 * 80);
        rango = (Excel.Range)hojaExcel.Columns[1];
        rango1 = (Excel.Range)hojaExcel.Columns[2];
        rango.ColumnWidth=double.Parse(rango1.Width.ToString())/15;//En Points

        rango = (Excel.Range)hojaExcel.Range["B1:J2"];
        rango.Merge();
        rango.Value = "REPORTE DE PRODUCTIVIDAD CR";
        rango.Font.Bold = true;
        rango.Font.Size = 24;
        rango.Interior.Color = System.Drawing.Color.FromArgb(218, 238, 243);

        rango = (Excel.Range)hojaExcel.Range["B3:D3"];
        rango.Merge();
        rango.Value = "ZONA: "+dsDatosUsuario.Tables[0].Rows[0].ItemArray[0].ToString();
        rango.Font.Bold = true;
        rango.Font.Size = 14;
        rango.Interior.Color = System.Drawing.Color.FromArgb(235, 241, 222);

        rango = (Excel.Range)hojaExcel.Range["E3:G3"];
        rango.Merge();
        rango.Value = "AGENCIA: " + dsDatosUsuario.Tables[0].Rows[0].ItemArray[2].ToString();
        rango.Font.Bold = true;
        rango.Font.Size = 14;
        rango.Interior.Color = System.Drawing.Color.FromArgb(242, 220, 219);

        rango = (Excel.Range)hojaExcel.Range["H3:J3"];
        rango.Merge();
        rango.Value = "ASESOR: " + dsDatosUsuario.Tables[0].Rows[0].ItemArray[4].ToString();
        rango.Font.Bold = true;
        rango.Font.Size = 14;
        rango.Interior.Color = System.Drawing.Color.FromArgb(238, 236, 225);

        rango = (Excel.Range)hojaExcel.Range["B4:D4"];
        rango.Merge();
        rango.Value = "JEFE ZONAL";
        rango.Font.Bold = true;
        rango.Font.Size = 12;
        rango.Interior.Color = System.Drawing.Color.FromArgb(235, 241, 222);

        rango = (Excel.Range)hojaExcel.Range["E4:G4"];
        rango.Merge();
        rango.Value = "ADMINISTRADOR";
        rango.Font.Bold = true;
        rango.Font.Size = 12;
        rango.Interior.Color = System.Drawing.Color.FromArgb(242, 220, 219);

        rango = (Excel.Range)hojaExcel.Range["H4:J4"];
        rango.Merge();
        rango.Value = "FECHA";
        rango.Font.Bold = true;
        rango.Font.Size = 12;
        rango.Interior.Color = System.Drawing.Color.FromArgb(238, 236, 225);

        rango = (Excel.Range)hojaExcel.Range["B5:D5"];
        rango.Merge();
        rango.Value = dsDatosUsuario.Tables[0].Rows[0].ItemArray[1].ToString();
        rango.Font.Bold = true;
        rango.Font.Size = 11;

        rango = (Excel.Range)hojaExcel.Range["E5:G5"];
        rango.Merge();
        rango.Value = dsDatosUsuario.Tables[0].Rows[0].ItemArray[3].ToString();
        rango.Font.Bold = true;
        rango.Font.Size = 11;

        rango = (Excel.Range)hojaExcel.Range["H5:J5"];
        rango.Merge();
        rango.Value = (String)Request["fecha"]; ;
        rango.Font.Bold = true;
        rango.Font.Size = 11;

        rango = (Excel.Range)hojaExcel.Range["B1:J5"];
        rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
        rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
        Excel.Borders bordes = rango.Borders;
        bordes.LineStyle = Excel.XlLineStyle.xlContinuous;
    }

    private int[] MostrarGrupos(Excel.Worksheet hojaExcel, DataSet dsGrupos, int filaGrupo, int fila, int columna)
    {
        //Configuración.
        string fechaReporte = (String)Request["fecha"];
        string[] fechaReporteArray = fechaReporte.Split('/');
        int diaFechaReporte = int.Parse(fechaReporteArray[0].ToString());
        Excel.Range rango;
        string[,] fechas = new string[31, 2];
        GenerarFechas(fechas);
        string str_rango = "";
        int[] resultados = new int[3];

        //Llenar datos.
        str_rango = ObtenerRango(fila, columna, 1, 5);
        rango = hojaExcel.Range[str_rango];
        rango.Merge();
        rango.Value = "DÍA-MES";
        DarFormatoRango(rango, false, false, false, 23, -1, -1, -1);
        DarFormatoTexto(rango, 13, true, false, "White");

        str_rango = ObtenerRango(fila, columna + 5, 2, 1);
        rango = hojaExcel.Range[str_rango];
        rango.Merge();
        rango.Value = "TOTALES";
        DarFormatoRango(rango, false, false, false, 15, -1, -1, -1);
        DarFormatoTexto(rango, 12, true, false, "Black");

        //Insertar Descripción de Grupos.
        str_rango = ObtenerRango(fila + 1, columna, 2, 5);
        rango = hojaExcel.Range[str_rango];
        rango.Merge();
        rango.Value = dsGrupos.Tables[0].Rows[filaGrupo-1].ItemArray[2].ToString();
        DarFormatoTexto(rango, 14, true, true, "Black");
        DarFormatoRango(rango, false, false, false, -1, 255, 255, 255);

        //Insertar Fechas:
        for (int i = 1; i < diaFechaReporte + 1; i++)
        {
            rango = (Excel.Range)hojaExcel.Cells[fila, i + 6];
            rango.Value = fechas[i - 1, 1];
            rango.Interior.ColorIndex = 15;

            rango = (Excel.Range)hojaExcel.Cells[fila + 1, i + 6];
            rango.Value = fechas[i - 1, 0];
            rango.Interior.ColorIndex = 15;
        }

        //Insertar Totales.
        str_rango = ObtenerRango(fila + 2, columna + 5, 1, 1);
        rango = hojaExcel.Range[str_rango];
        rango.Value = dsGrupos.Tables[0].Rows[filaGrupo - 1].ItemArray[34].ToString();

        //Inserta Conteo de Gestiones según Grupo por día. 
        for (int i = 1; i < diaFechaReporte + 1; i++)
        {
            rango = (Excel.Range)hojaExcel.Cells[fila + 2, i + 6];
            rango.Value = dsGrupos.Tables[0].Rows[filaGrupo - 1].ItemArray[i + 2].ToString();
        }

        //Dar formato al bloque (bordes y centrado)
        str_rango = ObtenerRango(fila, columna, 3, diaFechaReporte + 6);
        rango = hojaExcel.Range[str_rango];
        DarFormatoRango(rango, true, true, true, -1, -1, -1, -1);

        fila = fila + 3;
        resultados[0] = fila;//Fila Actual
        resultados[1] = int.Parse(dsGrupos.Tables[0].Rows[filaGrupo - 1].ItemArray[1].ToString());//Código del grupo de la fila actual
        resultados[2] = CantidadTipoGestionesXGrupo(resultados[1]);//Cantidad de Gestiones por código de grupo de la fila actual
        return resultados;
    }
    private int[] MostrarTipoGestiones(Excel.Worksheet hojaExcel, DataSet dsTipoGestiones, int grupo, int filaTipoGest, int fila, int columna)
    {
        //Configuración.
        string fechaReporte = (String)Request["fecha"];
        string[] fechaReporteArray = fechaReporte.Split('/');
        int diaFechaReporte = int.Parse(fechaReporteArray[0].ToString());
        string str_rango = "";
        Excel.Range rango;
        int[] resultados = new int[3];

        //Inserta Orden.
        str_rango = ObtenerRango(fila, columna, 1, 1);
        rango = hojaExcel.Range[str_rango];
        rango.Value = dsTipoGestiones.Tables[0].Rows[filaTipoGest].ItemArray[0].ToString();

        //Inserta Descripción del Tipo de Gestión.
        str_rango = ObtenerRango(fila, columna+1, 1, 4);
        rango = hojaExcel.Range[str_rango];
        rango.Merge();
        rango.Value = dsTipoGestiones.Tables[0].Rows[filaTipoGest].ItemArray[3].ToString();

        //Inserta Totales de Tipo de Gestión.
        str_rango = ObtenerRango(fila, columna + 5, 1, 1);
        rango = hojaExcel.Range[str_rango];
        rango.Value = dsTipoGestiones.Tables[0].Rows[filaTipoGest].ItemArray[35].ToString();

        //Dar formato.
        str_rango = ObtenerRango(fila, columna, 1, 6);
        rango = hojaExcel.Range[str_rango];
        DarFormatoRango(rango, false, false, false, -1, 83, 141, 213);
        DarFormatoTexto(rango, 12, true, false, "Black");

        //Inserta Conteo de Gestiones según Tipo Gestión por día.
        for (int i = 1; i < diaFechaReporte + 1; i++)
        {
            rango = (Excel.Range)hojaExcel.Cells[fila, i + 6];
            rango.Value = dsTipoGestiones.Tables[0].Rows[filaTipoGest].ItemArray[i + 3].ToString();
            DarFormatoRango(rango, false, false, false, -1, 83, 141, 213);
            DarFormatoTexto(rango, 11, false, false, "Black");
        }
        //Dar formato al bloque (bordes y centrado)
        str_rango = ObtenerRango(fila, columna, 1, diaFechaReporte + 6);
        rango = hojaExcel.Range[str_rango];
        DarFormatoRango(rango, true, true, true, -1, -1, -1, -1);

        fila = fila + 1;
        resultados[0] = fila;//Fila Actual
        resultados[1] = int.Parse(dsTipoGestiones.Tables[0].Rows[filaTipoGest].ItemArray[2].ToString());//Código del Tipo de Gestión de la fila actual
        resultados[2] = CantidadEjecutadosXTipoGestion(resultados[1]);//Cantidad de Ejecutados por código del Tipo de Gestión de la fila actual
        return resultados;
    }
    private int[] MostrarEjecutados(Excel.Worksheet hojaExcel, DataSet dsEjecutados, int tipoGest, int filaEjecutado, int fila, int columna)
    {
        //Configuración
        string fechaReporte = (String)Request["fecha"];
        string[] fechaReporteArray = fechaReporte.Split('/');
        int diaFechaReporte = int.Parse(fechaReporteArray[0].ToString());
        string str_rango = "";
        Excel.Range rango;
        int[] resultados = new int[3];

        //Inserta Descripción del Tipo de Gestión.
        str_rango = ObtenerRango(fila, columna, 1, 5);
        rango = hojaExcel.Range[str_rango];
        rango.Merge();
        rango.Value = dsEjecutados.Tables[0].Rows[filaEjecutado].ItemArray[4].ToString();

        //Inserta Totales de Tipo de Gestión.
        str_rango = ObtenerRango(fila, columna + 5, 1, 1);
        rango = hojaExcel.Range[str_rango];
        rango.Value = dsEjecutados.Tables[0].Rows[filaEjecutado].ItemArray[36].ToString();

        //Dar formato.
        str_rango = ObtenerRango(fila, columna, 1, 6);
        rango = hojaExcel.Range[str_rango];
        DarFormatoRango(rango, false, false, false, -1, 141, 180, 226);
        DarFormatoTexto(rango, 12, true, false, "Black");

        //Inserta Conteo de Gestiones según Tipo Gestión por día.
        for (int i = 1; i < diaFechaReporte + 1; i++)
        {
            rango = (Excel.Range)hojaExcel.Cells[fila, i + 6];
            rango.Value = dsEjecutados.Tables[0].Rows[filaEjecutado].ItemArray[i + 4].ToString();
            DarFormatoRango(rango, false, false, false, -1, 141, 180, 226);
            DarFormatoTexto(rango, 11, false, false, "Black");
        }
        //Dar formato al bloque (bordes y centrado)
        str_rango = ObtenerRango(fila, columna, 1, diaFechaReporte + 6);
        rango = hojaExcel.Range[str_rango];
        DarFormatoRango(rango, true, true, true, -1, -1, -1, -1);

        fila = fila + 1;
        resultados[0] = fila;//Fila Actual
        resultados[1] = int.Parse(dsEjecutados.Tables[0].Rows[filaEjecutado].ItemArray[3].ToString());//Código del Ejecutado de la fila actual
        resultados[2] = CantidadClasificacionesXEjecutado(resultados[1]);//Cantidad de Clasificaciones por código del Ejecutado de la fila actual
        return resultados;

    }
    private int[] MostrarClasificaciones(Excel.Worksheet hojaExcel, DataSet dsClasificaciones, int ejecutado, int filaClasif, int fila, int columna)
    {
        //Configuración.
        string fechaReporte = (String)Request["fecha"];
        string[] fechaReporteArray = fechaReporte.Split('/');
        int diaFechaReporte = int.Parse(fechaReporteArray[0].ToString());
        string str_rango = "";
        Excel.Range rango;
        int[] resultados = new int[3];

        //Inserta Orden.
        str_rango = ObtenerRango(fila, columna, 1, 1);
        rango = hojaExcel.Range[str_rango];
        rango.Value = dsClasificaciones.Tables[0].Rows[filaClasif].ItemArray[0].ToString();

        //Inserta Descripción del Tipo de Gestión.
        str_rango = ObtenerRango(fila, columna + 1, 1, 4);
        rango = hojaExcel.Range[str_rango];
        rango.Merge();
        rango.Value = dsClasificaciones.Tables[0].Rows[filaClasif].ItemArray[5].ToString();

        //Inserta Totales de Tipo de Gestión.
        str_rango = ObtenerRango(fila, columna + 5, 1, 1);
        rango = hojaExcel.Range[str_rango];
        rango.Value = dsClasificaciones.Tables[0].Rows[filaClasif].ItemArray[37].ToString();

        //Dar formato.
        str_rango = ObtenerRango(fila, columna, 1, 5);
        rango = hojaExcel.Range[str_rango];
        DarFormatoRango(rango, false, false, false, -1, 197, 217, 241);
        DarFormatoTexto(rango, 12, true, false, "Black");

        str_rango = ObtenerRango(fila, columna + 5, 1, 1);
        rango = hojaExcel.Range[str_rango];
        DarFormatoRango(rango, false, false, false, -1, 217, 217, 217);
        DarFormatoTexto(rango, 12, true, false, "Black");

        //Inserta Conteo de Gestiones según Tipo Gestión por día.
        for (int i = 1; i < diaFechaReporte + 1; i++)
        {
            rango = (Excel.Range)hojaExcel.Cells[fila, i + 6];
            rango.Value = dsClasificaciones.Tables[0].Rows[filaClasif].ItemArray[i + 5].ToString();
            if (i % 2 == 0)
            {
                DarFormatoRango(rango, false, false, false, -1, 217, 217, 217);
            }
            DarFormatoTexto(rango, 11, false, false, "Black");
        }
        //Dar formato al bloque (bordes y centrado)
        str_rango = ObtenerRango(fila, columna, 1, diaFechaReporte + 6);
        rango = hojaExcel.Range[str_rango];
        DarFormatoRango(rango, true, true, true, -1, -1, -1, -1);

        fila = fila + 1;//dsClasificaciones.Tables[0].Rows.Count;
        resultados[0] = fila;//Fila Actual
        resultados[1] = int.Parse(dsClasificaciones.Tables[0].Rows[filaClasif].ItemArray[4].ToString());//Código de la Clasificación de la fila actual
        resultados[2] = dsClasificaciones.Tables[0].Rows.Count;
        return resultados;
    }

    private int[] MostrarGruposCuadroPorcentual(Excel.Worksheet hojaExcel, DataSet dsGrupos, int filaGrupo, int fila, int columna)
    {
        //Configuración.
        string fechaReporte = (String)Request["fecha"];
        string[] fechaReporteArray = fechaReporte.Split('/');
        int diaFechaReporte = int.Parse(fechaReporteArray[0].ToString());
        Excel.Range rango;
        string[,] fechas = new string[31, 2];
        GenerarFechas(fechas);
        string str_rango = "";
        int[] resultados = new int[3];

        //Llenar datos.
        str_rango = ObtenerRango(fila, columna, 1, 5);
        rango = hojaExcel.Range[str_rango];
        rango.Merge();
        rango.Value = "DÍA-MES";
        DarFormatoRango(rango, false, false, false, 23, -1, -1, -1);
        DarFormatoTexto(rango, 13, true, false, "White");

        str_rango = ObtenerRango(fila, columna + 5, 2, 1);
        rango = hojaExcel.Range[str_rango];
        rango.Merge();
        rango.Value = "TOTALES";
        DarFormatoRango(rango, false, false, false, 15, -1, -1, -1);
        DarFormatoTexto(rango, 12, true, false, "Black");

        //Insertar Descripción de Grupos.
        str_rango = ObtenerRango(fila + 1, columna, 2, 5);
        rango = hojaExcel.Range[str_rango];
        rango.Merge();
        rango.Value = dsGrupos.Tables[0].Rows[filaGrupo - 1].ItemArray[2].ToString();
        DarFormatoTexto(rango, 14, true, true, "Black");
        DarFormatoRango(rango, false, false, false, -1, 255, 255, 255);

        //Insertar Totales.
        str_rango = ObtenerRango(fila + 2, columna + 5, 1, 1);
        rango = hojaExcel.Range[str_rango];
        rango.Value = dsGrupos.Tables[0].Rows[filaGrupo - 1].ItemArray[34].ToString();

        //Dar formato al bloque (bordes y centrado)
        str_rango = ObtenerRango(fila, columna, 3, 6);
        rango = hojaExcel.Range[str_rango];
        DarFormatoRango(rango, true, true, true, -1, -1, -1, -1);

        fila = fila + 3;
        resultados[0] = fila;//Fila Actual
        resultados[1] = int.Parse(dsGrupos.Tables[0].Rows[filaGrupo - 1].ItemArray[1].ToString());//Código del grupo de la fila actual
        resultados[2] = CantidadTipoGestionesXGrupo(resultados[1]);//Cantidad de Gestiones por código de grupo de la fila actual
        return resultados;
    }
    private int[] MostrarTipoGestionesCuadroPorcentual(Excel.Worksheet hojaExcel, DataSet dsTipoGestiones, int grupo, int filaTipoGest, int fila, int columna)
    {
        //Configuración.
        string fechaReporte = (String)Request["fecha"];
        string[] fechaReporteArray = fechaReporte.Split('/');
        int diaFechaReporte = int.Parse(fechaReporteArray[0].ToString());
        string str_rango = "";
        Excel.Range rango;
        int[] resultados = new int[3];

        //Inserta Orden.
        str_rango = ObtenerRango(fila, columna, 1, 1);
        rango = hojaExcel.Range[str_rango];
        rango.Value = dsTipoGestiones.Tables[0].Rows[filaTipoGest].ItemArray[0].ToString();

        //Inserta Descripción del Tipo de Gestión.
        str_rango = ObtenerRango(fila, columna + 1, 1, 4);
        rango = hojaExcel.Range[str_rango];
        rango.Merge();
        rango.Value = dsTipoGestiones.Tables[0].Rows[filaTipoGest].ItemArray[3].ToString();

        //Inserta Totales de Tipo de Gestión.
        str_rango = ObtenerRango(fila, columna + 5, 1, 1);
        rango = hojaExcel.Range[str_rango];
        rango.Value = dsTipoGestiones.Tables[0].Rows[filaTipoGest].ItemArray[35].ToString();

        //Inserta % Totales de Tipo de Gestión.
        int totalGrupo = int.Parse(dsGrupos.Tables[0].Rows[0].ItemArray[34].ToString());
        int totalTipoGestion = int.Parse(dsTipoGestiones.Tables[0].Rows[filaTipoGest].ItemArray[35].ToString());
        float porcentaje = 0;
        if (totalGrupo != 0)
        {
            porcentaje = (totalTipoGestion * 100 / totalGrupo);

        }
        str_rango = ObtenerRango(fila, columna + 6, 1, 1);
        rango = hojaExcel.Range[str_rango];
        rango.Value = (porcentaje).ToString()+"%";

        //Dar formato.
        str_rango = ObtenerRango(fila, columna, 1, 7);
        rango = hojaExcel.Range[str_rango];
        DarFormatoRango(rango, false, false, false, -1, 83, 141, 213);
        DarFormatoTexto(rango, 12, true, false, "Black");

        //Dar formato al bloque (bordes y centrado)
        str_rango = ObtenerRango(fila, columna, 1, 6);
        rango = hojaExcel.Range[str_rango];
        DarFormatoRango(rango, true, true, true, -1, -1, -1, -1);

        fila = fila + 1;
        resultados[0] = fila;//Fila Actual
        resultados[1] = int.Parse(dsTipoGestiones.Tables[0].Rows[filaTipoGest].ItemArray[2].ToString());//Código del Tipo de Gestión de la fila actual
        resultados[2] = CantidadEjecutadosXTipoGestion(resultados[1]);//Cantidad de Ejecutados por código del Tipo de Gestión de la fila actual
        return resultados;
    }
    private int[] MostrarEjecutadosCuadroPorcentual(Excel.Worksheet hojaExcel, DataSet dsEjecutados, int tipoGest, int filaEjecutado, int fila, int columna)
    {
        //Configuración
        string fechaReporte = (String)Request["fecha"];
        string[] fechaReporteArray = fechaReporte.Split('/');
        int diaFechaReporte = int.Parse(fechaReporteArray[0].ToString());
        string str_rango = "";
        Excel.Range rango;
        int[] resultados = new int[3];

        //Inserta Descripción del Tipo de Gestión.
        str_rango = ObtenerRango(fila, columna, 1, 5);
        rango = hojaExcel.Range[str_rango];
        rango.Merge();
        rango.Value = dsEjecutados.Tables[0].Rows[filaEjecutado].ItemArray[4].ToString();

        //Inserta Totales de Tipo de Gestión.
        str_rango = ObtenerRango(fila, columna + 5, 1, 1);
        rango = hojaExcel.Range[str_rango];
        rango.Value = dsEjecutados.Tables[0].Rows[filaEjecutado].ItemArray[36].ToString();

        //Inserta % Totales de Tipo de Gestión.
        int filaDSTG = 0;
        for (int i = 0; i < dsTipoGestiones.Tables[0].Rows.Count; i++)
        {
            if (int.Parse(dsTipoGestiones.Tables[0].Rows[i].ItemArray[2].ToString())==tipoGest)
            {
                filaDSTG = int.Parse(dsTipoGestiones.Tables[0].Rows[i].ItemArray[0].ToString());
            }
        }
        int totalTipoGestion = int.Parse(dsTipoGestiones.Tables[0].Rows[filaDSTG - 1].ItemArray[35].ToString());
        int totalEjecutado = int.Parse(dsEjecutados.Tables[0].Rows[filaEjecutado].ItemArray[36].ToString());
        
        float porcentaje = 0;
        if (totalTipoGestion != 0)
        {
            porcentaje = (totalEjecutado * 100 / totalTipoGestion);
        }
        str_rango = ObtenerRango(fila, columna + 6, 1, 1);
        rango = hojaExcel.Range[str_rango];
        rango.Value = (porcentaje).ToString() + "%";

        //Dar formato.
        str_rango = ObtenerRango(fila, columna, 1, 6);
        rango = hojaExcel.Range[str_rango];
        DarFormatoRango(rango, false, false, false, -1, 141, 180, 226);
        DarFormatoTexto(rango, 12, true, false, "Black");

        //Dar formato al bloque (bordes y centrado)
        str_rango = ObtenerRango(fila, columna, 1, 6);
        rango = hojaExcel.Range[str_rango];
        DarFormatoRango(rango, true, true, true, -1, -1, -1, -1);

        fila = fila + 1;
        resultados[0] = fila;//Fila Actual
        resultados[1] = int.Parse(dsEjecutados.Tables[0].Rows[filaEjecutado].ItemArray[3].ToString());//Código del Ejecutado de la fila actual
        resultados[2] = CantidadClasificacionesXEjecutado(resultados[1]);//Cantidad de Clasificaciones por código del Ejecutado de la fila actual
        return resultados;
    }
    private int[] MostrarClasificacionesCuadroPorcentual(Excel.Worksheet hojaExcel, DataSet dsClasificaciones, int ejecutado, int filaClasif, int fila, int columna)
    {
        //Configuración.
        string fechaReporte = (String)Request["fecha"];
        string[] fechaReporteArray = fechaReporte.Split('/');
        int diaFechaReporte = int.Parse(fechaReporteArray[0].ToString());
        string str_rango = "";
        Excel.Range rango;
        int[] resultados = new int[3];

        //Inserta Orden.
        str_rango = ObtenerRango(fila, columna, 1, 1);
        rango = hojaExcel.Range[str_rango];
        rango.Value = dsClasificaciones.Tables[0].Rows[filaClasif].ItemArray[0].ToString();

        //Inserta Descripción del Tipo de Gestión.
        str_rango = ObtenerRango(fila, columna + 1, 1, 4);
        rango = hojaExcel.Range[str_rango];
        rango.Merge();
        rango.Value = dsClasificaciones.Tables[0].Rows[filaClasif].ItemArray[5].ToString();

        //Inserta Totales de Tipo de Gestión.
        str_rango = ObtenerRango(fila, columna + 5, 1, 1);
        rango = hojaExcel.Range[str_rango];
        rango.Value = dsClasificaciones.Tables[0].Rows[filaClasif].ItemArray[37].ToString();

        //Inserta % Totales de Tipo de Gestión.
        int filaDSC = 0;
        for (int i = 0; i < dsEjecutados.Tables[0].Rows.Count; i++)
        {
            if (int.Parse(dsEjecutados.Tables[0].Rows[i].ItemArray[3].ToString()) == ejecutado)
            {
                filaDSC = int.Parse(dsEjecutados.Tables[0].Rows[i].ItemArray[0].ToString());
            }
        }
        int totalEjecutado = int.Parse(dsEjecutados.Tables[0].Rows[filaDSC - 1].ItemArray[36].ToString());
        int totalClasificacion = int.Parse(dsClasificaciones.Tables[0].Rows[filaClasif].ItemArray[37].ToString());
        float porcentaje = 0;
        if (totalEjecutado!=0)
        {
            porcentaje = (totalClasificacion / totalEjecutado) * 100 ;
        }
        
        str_rango = ObtenerRango(fila, columna + 6, 1, 1);
        rango = hojaExcel.Range[str_rango];
        rango.Value = (porcentaje).ToString() + "%";

        //Dar formato.
        str_rango = ObtenerRango(fila, columna, 1, 5);
        rango = hojaExcel.Range[str_rango];
        DarFormatoRango(rango, false, false, false, -1, 197, 217, 241);
        DarFormatoTexto(rango, 12, true, false, "Black");

        str_rango = ObtenerRango(fila, columna + 5, 1, 1);
        rango = hojaExcel.Range[str_rango];
        DarFormatoRango(rango, false, false, false, -1, 217, 217, 217);
        DarFormatoTexto(rango, 12, true, false, "Black");

        //Dar formato al bloque (bordes y centrado)
        str_rango = ObtenerRango(fila, columna, 1, 6);
        rango = hojaExcel.Range[str_rango];
        DarFormatoRango(rango, true, true, true, -1, -1, -1, -1);

        fila = fila + 1;//dsClasificaciones.Tables[0].Rows.Count;
        resultados[0] = fila;//Fila Actual
        resultados[1] = int.Parse(dsClasificaciones.Tables[0].Rows[filaClasif].ItemArray[4].ToString());//Código de la Clasificación de la fila actual
        resultados[2] = dsClasificaciones.Tables[0].Rows.Count;
        return resultados;
    }

    private void DarFormatoRango(Excel.Range rango,bool borde,bool centVert, bool centHoriz, int index, int r, int g, int b)
    {
        if (centVert)
        {
            rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
        }
        if (centHoriz)
        {
            rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
        }
        if (borde)
        {
            Excel.Borders bordes = rango.Borders;
            bordes.LineStyle = Excel.XlLineStyle.xlContinuous;
        }
        if (index!=-1)
        {
            rango.Interior.ColorIndex = index;
        }
        if (r != -1 && g !=-1 && b!=-1)
        {
            rango.Interior.Color = System.Drawing.Color.FromArgb(r, g, b);
        }
    }

    private void DarFormatoTexto(Excel.Range rango, int tamanio, bool bold, bool cursiva, string color)
    {
        if (tamanio!=-1)
        {
            rango.Font.Size = tamanio;
        }
        if (bold)
        {
            rango.Font.Bold = bold;
        }
        if (cursiva)
        {
            rango.Font.Italic = cursiva;
        }
        if (color.Length>0)
        {
            switch (color.ToLower())
            {
                case "white":
                    rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
                    break;
                case "black":
                    rango.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
                    break;
                default:
                    break;
            }
        }
    }
    
    private string ObtenerRango(int fila, int columna, int alto, int ancho)
    {
        return Columna(columna) + fila.ToString() + ":" + Columna(columna + ancho - 1) + (fila + alto - 1).ToString();
    }

    private void GenerarFechas(string[,] fechas)
    {
        //La matriz fechas es un Tipo de Referencia
        //Culturas:
        var culturaGb = new CultureInfo("en-GB");
        var culturaEs = new CultureInfo("es-MX");

        string fechaReporte = (String)Request["fecha"];
        string[] fechaReporteArray = fechaReporte.Split('/');
        int diaFechaReporte = int.Parse(fechaReporteArray[0].ToString());
        int mesFechaReporte = int.Parse(fechaReporteArray[1].ToString());
        int anioFechaReporte = int.Parse(fechaReporteArray[2].ToString());
        var fechaDateTime = new DateTime(anioFechaReporte, mesFechaReporte, diaFechaReporte);

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
    }



    private DataSet mxObtenerResultadoReporteProductividad(string plcFechaResultado)
    {
        string lcEmpresa, ldFechaResultado, lcJerarquiaA, lcJerarquiaB, lcJerarquiaC, lcJerarquiaD, lcCodAsesor;
        lcEmpresa = ldFechaResultado = lcJerarquiaA = lcJerarquiaB = lcJerarquiaC = lcJerarquiaD = lcCodAsesor = string.Empty;
        ldsResultado = new DataSet();
        LoGS_Gestion_Cobranza objLogica = new LoGS_Gestion_Cobranza();
        EnGS_Gestion_Cobranza objEntidad = new EnGS_Gestion_Cobranza();
        List<EnGS_Gestion_Cobranza> ListEntidad = new List<EnGS_Gestion_Cobranza>();


        lcEmpresa = (String)Request["nempresa"];
        ldFechaResultado = plcFechaResultado;
        lcJerarquiaB = (String)Request["jerarquiab"];
        lcJerarquiaC = (String)Request["jerarquiac"];
        lcJerarquiaD = (String)Request["jerarquiad"];
        lcCodAsesor = (String)Request["codasesor"];
        objEntidad.nEmpresa = lcEmpresa;

        objEntidad.FechaResultado = ldFechaResultado;
        objEntidad.cod_jerarquiaB = lcJerarquiaB;
        objEntidad.cod_jerarquiaC = lcJerarquiaC;
        objEntidad.cod_jerarquiaD = lcJerarquiaD;
        objEntidad.CodUsuario_Asesores = lcCodAsesor;

        ListEntidad.Add(objEntidad);
        ldsResultado = objLogica.mxObtenerResultadoReporteProductividad(ListEntidad);

        return ldsResultado;
    }


    private DataSet ObtenerGrupos(string fecha)
    {
        DataSet ds = new DataSet();
        System.Data.DataTable dt = new System.Data.DataTable();

        LoGS_Gestion_Cobranza objLogica = new LoGS_Gestion_Cobranza();
        EnGS_Gestion_Cobranza objEntidad = new EnGS_Gestion_Cobranza();
        List<EnGS_Gestion_Cobranza> ListEntidad = new List<EnGS_Gestion_Cobranza>();

        string str_nempresa = (String)Request["nempresa"];
        string str_fecha = fecha;
        string str_jerarquia_b = (String)Request["jerarquiab"];
        string str_jerarquia_c = (String)Request["jerarquiac"];
        //string str_jerarquia_d = (String)Request["jerarquiad"];
        string str_cod_asesor = (String)Request["codasesor"];
        objEntidad.nEmpresa = str_nempresa;
        objEntidad.FechaResultado = str_fecha;
        objEntidad.cod_jerarquiaB = str_jerarquia_b;
        objEntidad.cod_jerarquiaC = str_jerarquia_c;
        //objEntidad.cod_jerarquiaD = str_jerarquia_d;
        objEntidad.CodUsuario_Asesores = str_cod_asesor;
        ListEntidad.Add(objEntidad);
        dt = objLogica.RPT_CRProductividad_Grupos(ListEntidad);
        ds.Tables.Add(dt.Copy());
        ds.Tables[0].TableName = "DTGestiones";

        return ds;
    }
    private DataSet ObtenerTipoGestionXGrupo(string fecha, int CodGrupo)
    {
        DataSet ds = new DataSet();
        System.Data.DataTable dt = new System.Data.DataTable();

        LoGS_Gestion_Cobranza objLogica = new LoGS_Gestion_Cobranza();
        EnGS_Gestion_Cobranza objEntidad = new EnGS_Gestion_Cobranza();
        List<EnGS_Gestion_Cobranza> ListEntidad = new List<EnGS_Gestion_Cobranza>();

        string str_nempresa = (String)Request["nempresa"];
        string str_fecha = fecha;
        string str_jerarquia_b = (String)Request["jerarquiab"];
        string str_jerarquia_c = (String)Request["jerarquiac"];
        //string str_jerarquia_d = (String)Request["jerarquiad"];
        string str_cod_asesor = (String)Request["codasesor"];
        string str_codgrupo = CodGrupo.ToString();
        objEntidad.nEmpresa = str_nempresa;
        objEntidad.FechaResultado = str_fecha;
        objEntidad.cod_jerarquiaB = str_jerarquia_b;
        objEntidad.cod_jerarquiaC = str_jerarquia_c;
        //objEntidad.cod_jerarquiaD = str_jerarquia_d;
        objEntidad.CodUsuario_Asesores = str_cod_asesor;
        objEntidad.Grupo = str_codgrupo;
        ListEntidad.Add(objEntidad);
        dt = objLogica.RPT_CRProductividad_TipoGestionesXGrupo(ListEntidad);
        ds.Tables.Add(dt.Copy());
        ds.Tables[0].TableName = "DTGestiones";

        return ds;
    }
    private DataSet ObtenerResultadoXTipoGestion(string fecha, int CodTipoGestion)
    {
        DataSet ds = new DataSet();
        System.Data.DataTable dt = new System.Data.DataTable();

        LoGS_Gestion_Cobranza objLogica = new LoGS_Gestion_Cobranza();
        EnGS_Gestion_Cobranza objEntidad = new EnGS_Gestion_Cobranza();
        List<EnGS_Gestion_Cobranza> ListEntidad = new List<EnGS_Gestion_Cobranza>();

        string str_nempresa = (String)Request["nempresa"];
        string str_fecha = fecha;
        string str_jerarquia_b = (String)Request["jerarquiab"];
        string str_jerarquia_c = (String)Request["jerarquiac"];
        //string str_jerarquia_d = (String)Request["jerarquiad"];
        string str_cod_asesor = (String)Request["codasesor"];
        string str_codtipogestion = CodTipoGestion.ToString();
        objEntidad.nEmpresa = str_nempresa;
        objEntidad.FechaResultado = str_fecha;
        objEntidad.cod_jerarquiaB = str_jerarquia_b;
        objEntidad.cod_jerarquiaC = str_jerarquia_c;
        //objEntidad.cod_jerarquiaD = str_jerarquia_d;
        objEntidad.CodUsuario_Asesores = str_cod_asesor;
        objEntidad.CodTipoGestion = str_codtipogestion;
        ListEntidad.Add(objEntidad);
        dt = objLogica.RPT_CRProductividad_EjecutadoXTipoGestion(ListEntidad);
        ds.Tables.Add(dt.Copy());
        ds.Tables[0].TableName = "DTGestiones";

        return ds;
    }
    private DataSet ObtenerClasificacionXResultado(string fecha, int CodEjecutado)
    {
        DataSet ds = new DataSet();
        System.Data.DataTable dt = new System.Data.DataTable();

        LoGS_Gestion_Cobranza objLogica = new LoGS_Gestion_Cobranza();
        EnGS_Gestion_Cobranza objEntidad = new EnGS_Gestion_Cobranza();
        List<EnGS_Gestion_Cobranza> ListEntidad = new List<EnGS_Gestion_Cobranza>();

        string str_nempresa = (String)Request["nempresa"];
        string str_fecha = fecha;
        string str_jerarquia_b = (String)Request["jerarquiab"];
        string str_jerarquia_c = (String)Request["jerarquiac"];
        //string str_jerarquia_d = (String)Request["jerarquiad"];
        string str_cod_asesor = (String)Request["codasesor"];
        string str_codejecutado = CodEjecutado.ToString();
        objEntidad.nEmpresa = str_nempresa;
        objEntidad.FechaResultado = str_fecha;
        objEntidad.cod_jerarquiaB = str_jerarquia_b;
        objEntidad.cod_jerarquiaC = str_jerarquia_c;
        //objEntidad.cod_jerarquiaD = str_jerarquia_d;
        objEntidad.CodUsuario_Asesores = str_cod_asesor;
        objEntidad.CodEjecutado = str_codejecutado;
        ListEntidad.Add(objEntidad);
        dt = objLogica.RPT_CRProductividad_ClaseGestionesXEjecutado(ListEntidad);
        ds.Tables.Add(dt.Copy());
        ds.Tables[0].TableName = "DTGestiones";

        return ds; 
    }
    private DataSet ObtenerDatosAsesor()
    {
        DataSet ds = new DataSet();
        System.Data.DataTable dt = new System.Data.DataTable();

        LoGS_Gestion_Cobranza objLogica = new LoGS_Gestion_Cobranza();
        EnGS_Gestion_Cobranza objEntidad = new EnGS_Gestion_Cobranza();
        List<EnGS_Gestion_Cobranza> ListEntidad = new List<EnGS_Gestion_Cobranza>();

        string str_nempresa = (String)Request["nempresa"];
        string str_jerarquia_b = (String)Request["jerarquiab"];
        string str_jerarquia_c = (String)Request["jerarquiac"];
        //string str_jerarquia_d = (String)Request["jerarquiad"];
        string str_cod_asesor = (String)Request["codasesor"];

        objEntidad.nEmpresa = str_nempresa;
        objEntidad.cod_jerarquiaB = str_jerarquia_b;
        objEntidad.cod_jerarquiaC = str_jerarquia_c;
        //objEntidad.cod_jerarquiaD = str_jerarquia_d;
        objEntidad.CodUsuario_Asesores = str_cod_asesor;

        ListEntidad.Add(objEntidad);
        dt = objLogica.RPT_CRProductividad_UsuariosXJerarquia(ListEntidad);
        ds.Tables.Add(dt.Copy());
        ds.Tables[0].TableName = "DTGestiones";

        return ds;
    }

    private int CantidadTipoGestionesXGrupo(int grupo)
    {
        int cantidad = 0;
        DataSet ds = new DataSet();
        System.Data.DataTable dt = new System.Data.DataTable();

        LoGS_Gestion_Cobranza objLogica = new LoGS_Gestion_Cobranza();
        EnGS_Gestion_Cobranza objEntidad = new EnGS_Gestion_Cobranza();
        List<EnGS_Gestion_Cobranza> ListEntidad = new List<EnGS_Gestion_Cobranza>();

        string str_codgrupo = grupo.ToString();
        objEntidad.Grupo = str_codgrupo;
        ListEntidad.Add(objEntidad);
        dt = objLogica.GS_Cantidad_TipoGestionesXGrupo(ListEntidad);
        ds.Tables.Add(dt.Copy());
        ds.Tables[0].TableName = "DTGestiones";

        cantidad = int.Parse(ds.Tables[0].Rows[0].ItemArray[0].ToString());

        return cantidad;
    }
    private int CantidadEjecutadosXTipoGestion(int codTipoGestion)
    {
        int cantidad = 0;
        DataSet ds = new DataSet();
        System.Data.DataTable dt = new System.Data.DataTable();

        LoGS_Gestion_Cobranza objLogica = new LoGS_Gestion_Cobranza();
        EnGS_Gestion_Cobranza objEntidad = new EnGS_Gestion_Cobranza();
        List<EnGS_Gestion_Cobranza> ListEntidad = new List<EnGS_Gestion_Cobranza>();

        string str_codTipoGestion = codTipoGestion.ToString();
        objEntidad.CodTipoGestion = str_codTipoGestion;
        ListEntidad.Add(objEntidad);
        dt = objLogica.GS_Cantidad_EjecutadosXTipoGestion(ListEntidad);
        ds.Tables.Add(dt.Copy());
        ds.Tables[0].TableName = "DTGestiones";

        cantidad = int.Parse(ds.Tables[0].Rows[0].ItemArray[0].ToString());

        return cantidad;
    }
    private int CantidadClasificacionesXEjecutado(int codEjecutado)
    {
        int cantidad = 0;
        DataSet ds = new DataSet();
        System.Data.DataTable dt = new System.Data.DataTable();

        LoGS_Gestion_Cobranza objLogica = new LoGS_Gestion_Cobranza();
        EnGS_Gestion_Cobranza objEntidad = new EnGS_Gestion_Cobranza();
        List<EnGS_Gestion_Cobranza> ListEntidad = new List<EnGS_Gestion_Cobranza>();

        string str_codejecutado = codEjecutado.ToString();
        objEntidad.CodEjecutado = str_codejecutado;
        ListEntidad.Add(objEntidad);
        dt = objLogica.GS_Cantidad_ClasificacionesXEjecutado(ListEntidad);
        ds.Tables.Add(dt.Copy());
        ds.Tables[0].TableName = "DTGestiones";

        cantidad = int.Parse(ds.Tables[0].Rows[0].ItemArray[0].ToString());

        return cantidad;
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
            case 36:
                columna = "AJ";
                break;
            case 37:
                columna = "AK";
                break;
            case 38:
                columna = "AL";
                break;
            case 39:
                columna = "AM";
                break;
            case 40:
                columna = "AN";
                break;
            case 41:
                columna = "AO";
                break;
            case 42:
                columna = "AP";
                break;
            case 43:
                columna = "AQ";
                break;
            case 44:
                columna = "AR";
                break;
            case 45:
                columna = "AS";
                break;
            case 46:
                columna = "AT";
                break;
            case 47:
                columna = "AU";
                break;
            case 48:
                columna = "AV";
                break;
            case 49:
                columna = "AW";
                break;
            case 50:
                columna = "AX";
                break;
            case 51:
                columna = "AY";
                break;
            case 52:
                columna = "AZ";
                break;
            default:
                break;
        }

        return columna;
    }

    private int FilaDS(DataSet ds, int codigo, char tipo)
    {
        int i = 0;
        int columna = 0;
        switch (tipo)
        {
            case 'g'://grupos
            case 't'://tipogestiones
                columna = 1;
                break;
            case 'e'://ejecutados
                columna = 2;
                break;
            case 'c'://clasificaciones
                columna = 3;
                break;
            default:
                break;
        }
        while (int.Parse(ds.Tables[0].Rows[i].ItemArray[columna].ToString())!=codigo)
        {
            i++;
        }

        return i;
    }
}