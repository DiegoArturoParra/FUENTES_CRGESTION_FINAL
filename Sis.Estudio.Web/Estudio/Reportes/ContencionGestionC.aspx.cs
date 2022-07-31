using System;
using System.Drawing;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using CrystalDecisions.Web;
using CrystalDecisions.Shared;

using System.Text;
using System.Data.SqlClient;
using System.IO;

using System.ServiceModel;
using AjaxControlToolkit;
using System.Xml;
using System.Xml.Xsl;
using Sis.Estudio.Entity;
using Sis.Estudio.Logic.MSSQL.Estudio;
using System.Threading;

public partial class Estudio_Reportes_ContencionGestionC : System.Web.UI.Page
{
    #region Declaracion

    dsContencionGestion dsReporte = new dsContencionGestion();
    #endregion Declaracion

    #region Eventos
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Reporte();
        }
    }
    protected void btnEjecuta_Click(object sender, EventArgs e)
    {
        Thread.Sleep(2000);
        Reporte();
    }

    #endregion Eventos

    #region Metodos
    protected void Reporte()
    {
        try
        {

            ParameterDiscreteValue p1 = new ParameterDiscreteValue();
            ParameterDiscreteValue p2 = new ParameterDiscreteValue();
            ParameterDiscreteValue p3 = new ParameterDiscreteValue();
            ParameterDiscreteValue p4 = new ParameterDiscreteValue();


            dsReporte.Merge(ReturnDataSet(), false, System.Data.MissingSchemaAction.Ignore);
            CrystalReportSource1.ReportDocument.SetDataSource(dsReporte);


            p1.Value = (String)Request["tramodes"].ToString().Trim();
            p2.Value = (String)Request["agenciades"].ToString().Trim();
            p3.Value = (String)Request["anio"].ToString().Trim();
            p4.Value = (String)Request["gestiondes"].ToString().Trim();


            CrystalReportSource1.ReportDocument.SetParameterValue("tramodes", p1);
            CrystalReportSource1.ReportDocument.SetParameterValue("agenciades", p2);
            CrystalReportSource1.ReportDocument.SetParameterValue("anio", p3);
            CrystalReportSource1.ReportDocument.SetParameterValue("gestiondes", p4);





        }
        catch (FaultException e)
        {
            throw e;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion Metodos

    #region Funciones
    private DataSet ReturnDataSet()
    {
        try
        {

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            string str_tramocod = (String)Request["tramocod"].ToString().Trim();
            string str_tramodes = (String)Request["tramodes"].ToString().Trim();

            string str_agenciacod = (String)Request["agenciacod"].ToString().Trim();
            string str_agenciades = (String)Request["agenciades"].ToString().Trim();

            string str_anio = (String)Request["anio"].ToString().Trim();

            string str_gestioncod = (String)Request["gestioncod"].ToString().Trim();
            string str_gestiondes = (String)Request["gestiondes"].ToString().Trim();
  
            #region Carga_Variable
            List<EnContencionGestion> objListEn = new List<EnContencionGestion>();
            EnContencionGestion objEn = new EnContencionGestion();            
            objEn.NEMPRESA = (String)this.Session[Global.NEmpresa].ToString();
            objEn.Tramo = str_tramocod.Trim();
            objEn.CodSucursal = str_agenciacod.Trim();
            objEn.Anio = str_anio.Trim();
            objEn.CodTipoGestion = str_gestioncod.Trim();
            objListEn.Add(objEn);
            
            #endregion Carga_Variable
            #region Logica

            LoContencionGestion objLogica = new LoContencionGestion();
            dt = objLogica.ContencionGestion_RPT(objListEn);
            #endregion Logica

            ds.Tables.Add(dt.Copy());
            ds.Tables[0].TableName = "RPT_ContencionGestion";
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion Funciones
}