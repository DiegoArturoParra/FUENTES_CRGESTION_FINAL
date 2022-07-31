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

public partial class Resultados_ProcesosMasivos_Excel : System.Web.UI.Page
{
    #region Definiciones

   

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








    }
    private void ResponseExcel()
    {
        DataSet ds = new DataSet();
        ds = ReturnDataSet();

        dg.DataSource = ds.Tables[0];
        dg.DataBind();
        Exportar();
     
    }

    void SaveFile(HttpPostedFile file)
    {
        // Specify the path to save the uploaded file to.
        string savePath = "c:\\temp\\uploads\\";

        // Get the name of the file to upload.
        string fileName = FileUpload1.FileName;

        // Create the path and file name to check for duplicates.
        string pathToCheck = savePath + fileName;

        // Create a temporary file name to use for checking duplicates.
        string tempfileName = "";

        // Check to see if a file already exists with the
        // same name as the file to upload.        
        if (System.IO.File.Exists(pathToCheck))
        {
            int counter = 2;
            while (System.IO.File.Exists(pathToCheck))
            {
                // if a file with this name already exists,
                // prefix the filename with a number.
                tempfileName = counter.ToString() + fileName;
                pathToCheck = savePath + tempfileName;
                counter++;
            }

            fileName = tempfileName;

            //// Notify the user that the file name was changed.
            //UploadStatusLabel.Text = "A file with the same name already exists." +
            //    "<br />Your file was saved as " + fileName;
        }
        //else
        //{
        //    // Notify the user that the file was saved successfully.
        //    UploadStatusLabel.Text = "Your file was uploaded successfully.";
        //}

        // Append the name of the file to upload to the path.
        savePath += fileName;

        // Call the SaveAs method to save the uploaded
        // file to the specified directory.
        FileUpload1.SaveAs(savePath);

    }



    private void Exportar()
    {
        //********************************************************************************
        //** Exportar : Ejecuta la  Exportatacion a documento Excel.
        //********************************************************************************
        //export to excel

        string strFichero;
        strFichero = "TABLA_DE_CODIGOS.xls";
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
        
        ListEnGS_Gestion_Cobranza.Add(objEnGS_Gestion_Cobranza);
        dt = objLoGS_Gestion_Cobranza.GS_GestionCobranza_ExportarResultados_Masivos(ListEnGS_Gestion_Cobranza);

        ds.Tables.Add(dt.Copy());
        ds.Tables[0].TableName = "DTModeloCarta";
        return ds;
    }
    #endregion Funciones
    protected void dg_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}