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
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Drawing;
using System.Text;
using System.Xml.Linq;
using Sis.Estudio.Entity;
using Sis.Estudio.Logic.MSSQL.Gestion;


public partial class Reportes_Gestion_ProcesosMasivos_Excel_Whatsapp : System.Web.UI.Page
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
    private void Exportar()
    {
        //********************************************************************************
        //** Exportar : Ejecuta la  Exportatacion a documento Excel.
        //********************************************************************************
        //export to excel

        string strFichero;
        var culturaGb = new CultureInfo("en-GB");
        DateTime fecha = DateTime.Now;
        string strFecha = fecha.ToString(culturaGb);
        string[] diaHora = strFecha.Split(' ');
        string dia = diaHora[0];
        string hora = diaHora[1];
        diaHora = dia.Split('/');
        strFecha = diaHora[0].ToString() + diaHora[1].ToString() + diaHora[2].ToString();
        diaHora = hora.Split(':');
        strFecha = strFecha + "-" + diaHora[0].ToString() + diaHora[1].ToString() + diaHora[2].ToString();
        strFichero = "ENVIO_Whatsapp_" + strFecha + ".xls";
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
        string str_Id_carta = (String)Request["Id_carta"];
        string str_Cod_usuario = (String)Request["CodUsuario"];    

        objEnGS_Gestion_Cobranza.IdReg_Gestion_Cobranza = str_IdReg_Gestion_Cobranza;
        objEnGS_Gestion_Cobranza.id_carta = str_Id_carta;
        objEnGS_Gestion_Cobranza.CodUsuario = str_Cod_usuario;

        ListEnGS_Gestion_Cobranza.Add(objEnGS_Gestion_Cobranza);
        dt = objLoGS_Gestion_Cobranza.GS_Gestion_Cobranza_Whatsapp_Reg(ListEnGS_Gestion_Cobranza);

        ds.Tables.Add(dt.Copy());
        ds.Tables[0].TableName = "DTModeloCarta";
        return ds;
    }
    #endregion Funciones
}