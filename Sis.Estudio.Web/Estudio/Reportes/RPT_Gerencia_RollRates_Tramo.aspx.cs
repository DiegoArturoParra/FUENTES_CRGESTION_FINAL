using Sis.Estudio.Entity;
using Sis.Estudio.Logic.MSSQL.Reportes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;  

public partial class Estudio_Reportes_RPT_Gerencia_RollRates_Tramo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
        scriptManager.RegisterPostBackControl(this.btn_Excel);

        btn_Excel.Focus();
        if (!Page.IsPostBack)
        {

            this.Master.TituloModulo = "Reporte Gerencial: Indicador Roll Rates";
            Inicio();
            //fillGrid();
        } 
    }
    //protected void fillGrid()
    //{
    //    //HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        

    //    DataTable d1 = new DataTable();
    //    d1.Columns.Add("Id");
    //    d1.Columns.Add("Name");
    //    d1.Columns.Add("Pais");
    //    d1.Rows.Add("1", "bb", "Peru");
    //    d1.Rows.Add("2", "Cc", "Peru");
    //    d1.Rows.Add("3", "AA", "Peru");
    //    gv.DataSource = d1;
    //    gv.DataBind();
    //    gv.AllowPaging = false;
    //}
    private void Inicio()
    {
        Cargar_Modulos();
    }

    protected void Cargar_Modulos()
    {
        Cargar_Anio();
        //Cargar_Mes_Inicial();
        //Cargar_Mes_Final();
        //Cargar_Tramo();
        //Cargar_Producto();
        //Cargar_Zona();
    }

    protected void Cargar_Anio()
    {
        DataTable dt = new DataTable();
        try
        {
            LoRPT_BaseContencion objLoRPT_BaseContencion = new LoRPT_BaseContencion();
            EnRPT_BaseContencion objEnRPT_BaseContencion = new EnRPT_BaseContencion();
            List<EnRPT_BaseContencion> ListEnRPT_BaseContencion = new List<EnRPT_BaseContencion>();

            objEnRPT_BaseContencion.NEmpresa = (String)this.Session["cempresa"];
            ListEnRPT_BaseContencion.Add(objEnRPT_BaseContencion);

            cmb_Anio.Items.Clear();
            cmb_Anio_Fin.Items.Clear();
            dt = objLoRPT_BaseContencion.RPT_BaseContencion_ObtenerAnio(ListEnRPT_BaseContencion);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["IdAnio"].ToString().Trim();
                lista.Text = dt.Rows[i]["Año"].ToString().Trim();
                cmb_Anio.Items.Add(lista);
                cmb_Anio_Fin.Items.Add(lista);
            }

        }
        catch (Exception excp)
        {
            throw excp;
        }
    }

    protected void Cargar_Mes_Inicial()
    {
        DataTable dt = new DataTable();

        try
        {
            LoRPT_BaseContencion objLoRPT_BaseContencion = new LoRPT_BaseContencion();
            EnRPT_BaseContencion objEnRPT_BaseContencion = new EnRPT_BaseContencion();
            List<EnRPT_BaseContencion> ListEnRPT_BaseContencion = new List<EnRPT_BaseContencion>();

            objEnRPT_BaseContencion.NEmpresa = (String)this.Session["cempresa"];
            objEnRPT_BaseContencion.AnioInt = cmb_Anio.SelectedItem.Value.ToString().Trim();
            ListEnRPT_BaseContencion.Add(objEnRPT_BaseContencion);

            cmb_mes_Inicial.Items.Clear();

            dt = objLoRPT_BaseContencion.RPT_BaseContencion_ObtenerMes(ListEnRPT_BaseContencion);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["IdMes"].ToString().Trim();
                lista.Text = dt.Rows[i]["Mes"].ToString().Trim();
                cmb_mes_Inicial.Items.Add(lista);
            }
        }
        catch (Exception excp)
        {
            throw excp;
        }
    }

    protected void Cargar_Mes_Final()
    {
        DataTable dt = new DataTable();

        try
        {
            LoRPT_BaseContencion objLoRPT_BaseContencion = new LoRPT_BaseContencion();
            EnRPT_BaseContencion objEnRPT_BaseContencion = new EnRPT_BaseContencion();
            List<EnRPT_BaseContencion> ListEnRPT_BaseContencion = new List<EnRPT_BaseContencion>();

            objEnRPT_BaseContencion.NEmpresa = (String)this.Session["cempresa"];
            objEnRPT_BaseContencion.AnioInt = cmb_Anio.SelectedItem.Value.ToString().Trim();
            objEnRPT_BaseContencion.MesIntInicio = cmb_mes_Inicial.SelectedItem.Value.ToString().Trim();
            ListEnRPT_BaseContencion.Add(objEnRPT_BaseContencion);

            cmb_mes_Final.Items.Clear();

            dt = objLoRPT_BaseContencion.RPT_BaseContencion_ObtenerMesFinal(ListEnRPT_BaseContencion);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["IdMes"].ToString().Trim();
                lista.Text = dt.Rows[i]["Mes"].ToString().Trim();
                cmb_mes_Final.Items.Add(lista);
            }
        }
        catch (Exception excp)
        {
            throw excp;
        }
    }

    protected void btn_Excel_Click(object sender, EventArgs e)
    {
        
        //Response.ClearContent();
        //Response.AppendHeader("content-disposition", "attachment;filename=EmployeeDetails.xls");
        //Response.ContentType = "application/excel";

        //StringWriter stringwriter = new StringWriter();
        //HtmlTextWriter htmtextwriter = new HtmlTextWriter(stringwriter);

        //gv.HeaderRow.Style.Add("background-color", "#ffffff");
        //gv.HeaderRow.Style.Add("color", "#000000");
        

        //foreach (TableCell tableCell in gv.HeaderRow.Cells)
        //{
        //    tableCell.Style["background-color"] = "#ffffff";
        //}

        //foreach (GridViewRow gridviewrow in gv.Rows)
        //{
        //    gridviewrow.BackColor = System.Drawing.Color.White;
        //    gridviewrow.ForeColor = System.Drawing.Color.Black;
        //    foreach (TableCell gridviewrowtablecell in gridviewrow.Cells)
        //    {
        //        gridviewrowtablecell.Style["background-color"] = "#ffffff";
        //    }
        //}

        //gv.RenderControl(htmtextwriter);
        //Response.Write(stringwriter.ToString());
        //Response.End();

        mxDescargarReporteRoolRates();

    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }
    
    private void Exportar(string Formato)
    {
        try
        {
            string str_parametros = "";
            string str_tiporeporte = "?tiporeporte=" + Formato;
            string str_nempresa = "&nempresa=" + (String)Session[Global.NEmpresa].ToString();
            string str_anio = "&anioInicial=" + cmb_Anio.SelectedValue.ToString();
            string str_anio_final = "&anioFinal=" + cmb_Anio.SelectedValue.ToString();
            string str_mes = "&mesInicial=" + cmb_mes_Inicial.SelectedValue.ToString();
            string str_mes_final = "&mesFinal=" + cmb_mes_Final.SelectedValue.ToString();
            //string str_tramo = "&mes=" + cmb_mes_Final.SelectedValue.ToString();
            //string str_zona = "&mes=" + cmb_mes_Final.SelectedValue.ToString();
            //string str_producto = "&mes=" + cmb_mes_Final.SelectedValue.ToString();

            str_parametros = str_tiporeporte + str_nempresa + str_anio + str_anio_final + str_mes + str_mes_final;

            string CONFIG = "'resizable = yes, scrollbars = yes, toolbar=no, height = 500, width = 800,left=200,top=100,status=yes, location=no, menubar=no'";

            StringBuilder sb = new StringBuilder();
            sb.Append("<script>var win=window.open('../../Reportes/Reportes/ReporteGerencial_RollRates_Tramo.aspx" + str_parametros + "', 'ReporteGerencial_RollRates_Tramo', " + CONFIG + ");</script>");
            ScriptManager.RegisterStartupScript(this, typeof(Page), "ReporteAccion", sb.ToString(), false);
        }
        catch (Exception excp)
        {
            Master.MostrarMensaje(excp.ToString(), TipoMensaje.Error);
        }
    }
    protected void btn_Imprimir_Click(object sender, EventArgs e)
    {

    }
    protected void cmb_Anio_SelectedIndexChanged(object sender, EventArgs e)
    {
        Cargar_Mes_Inicial();
    }
    protected void cmb_mes_Inicial_SelectedIndexChanged(object sender, EventArgs e)
    {
        Cargar_Mes_Final();
    }
    //protected void btnExportar_Click(object sender, EventArgs e)
    //{
    //    //this.ExportarExcel();
    //}
    private void ExportarExcel()
    {
        try
        {
            string rutaPlantilla = "D:\\CRGESTION\\FUENTES\\FUENTES_CRGESTION\\Sis.Estudio.Web\\ReportesGerencialesModelo\\RollRates-Template.xlsx";
            string rutaGuardado = "D:\\CRGESTION\\FUENTES\\FUENTES_CRGESTION\\Sis.Estudio.Web\\ReportesGerencialesModelo\\RollRates-CopiaBarata.xls";

            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook _libroExcel = null;
            Excel.Worksheet _HojaExcel = null;
            Excel.Range _Rango = null;
            object misValue = System.Reflection.Missing.Value;
            _libroExcel = xlApp.Workbooks.Open(rutaPlantilla, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue);
            _libroExcel = xlApp.ActiveWorkbook;
            _HojaExcel = (Excel.Worksheet)_libroExcel.Worksheets.Item[1];
            //_libroExcel.Worksheets[1].Copy(_libroExcel.Worksheets[_libroExcel.Sheets.Count]);
            xlApp.ScreenUpdating = false;
            xlApp.DisplayAlerts = false;
            try
            {
                xlApp.ScreenUpdating = false;
                _Rango = (Excel.Range)_HojaExcel.Cells.Range["D5"];
                _Rango.Value2 = "Prueba escritura DATUM";
                _Rango = (Excel.Range)_HojaExcel.Cells.Range["E5"];
                _Rango.Value2 = "D";
                _Rango = (Excel.Range)_HojaExcel.Cells.Range["F5"];
                _Rango.Value2 = "0.14";
                _Rango = (Excel.Range)_HojaExcel.Cells.Range["G5"];
                _Rango.Value2 = "0.01";
                _Rango = (Excel.Range)_HojaExcel.Cells.Range["H5"];
                _Rango.Value2 = "-0.01";
                _Rango = (Excel.Range)_HojaExcel.Cells.Range["I5"];
                _Rango.Value2 = "0.12";
                _HojaExcel.Columns.EntireColumn.AutoFit();
                xlApp.ScreenUpdating = true;
                _libroExcel.SaveAs(rutaGuardado, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                _libroExcel.Close(true, misValue, misValue);
                xlApp.Quit();
                //MessageBox.Show("Datos Exportados" + rutaPlantilla);
            }
            catch (System.Exception ex)
            {
                //MessageBox.Show(ex.Message + "\\n\\n=======  Error al escribir el excel:  ======\\n\\n" + ex.StackTrace);
            }
            finally
            {
                releaseObject(_Rango);
                releaseObject(_HojaExcel);
                releaseObject(_libroExcel);
                releaseObject(xlApp);
                //Process process =new  Process.GetProcesses();
                //foreach (var p in process)
                //{
                //    if ((p!=null && (p.ProcessName == "EXCEL")))
                //    {
                //        p.Kill();
                //    }
                //}
                var processes = from p in Process.GetProcessesByName("EXCEL")
                                select p;

                foreach (var process in processes)
                {
                    if ((process != null && (process.ProcessName == "EXCEL")))
                    {
                        process.Kill();
                    }
                }
            }
        }
        catch (System.Exception exl)
        {
            //MessageBox.Show(exl.Message + "\\n\\n=======   Error al abrir el archivo  ======\\n\\n" + exl.StackTrace);
        }
    }
    private void releaseObject(object obj)
    {
        try
        {
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
            obj = null;
        }
        catch (System.Exception ex)
        {
            obj = null;
            //MessageBox.Show("Error al limpiar memoria \\n" + ex.ToString());
        }
        finally
        {
            if ((obj != null))
            {
                int pos = GC.GetGeneration(obj);
                GC.Collect(pos);
            }
            else
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
    }
    protected void btnDescarga_Click(object sender, EventArgs e)
    {
        

    }
    private void mxDescargarReporteRoolRates()
    {
        string lcNomArchivo = "..\\..\\ReportesGerencialesModelo\\RollRatesTemplate.xls";
        string lcArcDestino = "ReporteRollRates.xls";
        this.mxDescargarArchivo(lcNomArchivo, lcArcDestino);
    }
    private void mxDescargarArchivo(string pcNomArchivo, string lcArcDestino)
    {
        if (!string.IsNullOrEmpty(pcNomArchivo))
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=" + lcArcDestino);
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.xls";
            Response.TransmitFile(pcNomArchivo);
            Response.End();
        }
    }
}