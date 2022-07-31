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

using System.Text;
using System.Data.SqlClient;
using System.IO;

using CrystalDecisions.Web;
using CrystalDecisions.Shared;

using System.ServiceModel;
using AjaxControlToolkit;
using System.Xml;
using System.Xml.Xsl;
using Sis.Estudio.Entity;
using Sis.Estudio.Logic.MSSQL.Estudio;
using System.Threading;

public partial class Estudio_Reportes_ContencionTramoC : System.Web.UI.Page
{

    #region Declaracion
    dsContencionTramo dsReporte = new dsContencionTramo();
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
        //Thread.Sleep(2000);
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


            dsReporte.Merge(ReturnDataSet(), false, System.Data.MissingSchemaAction.Ignore);
            CrystalReportSource1.ReportDocument.SetDataSource(dsReporte);

            p1.Value = (String)Request["tramodes"].ToString().Trim();            
            p2.Value = (String)Request["anio"].ToString().Trim();

            CrystalReportSource1.ReportDocument.SetParameterValue("tramodes", p1);            
            CrystalReportSource1.ReportDocument.SetParameterValue("anio", p2);



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

            string str_anio = (String)Request["anio"].ToString().Trim();

            #region Carga_Variable
            List<EnContencionTramo> objListEn = new List<EnContencionTramo>();
            EnContencionTramo objEn = new EnContencionTramo();
            objEn.NEMPRESA = (String)this.Session[Global.NEmpresa].ToString();
            objEn.Tramo = str_tramocod.Trim();
            objEn.Anio = str_anio.Trim();
            objListEn.Add(objEn);
            #endregion Carga_Variable
            #region Logica
            LoContencionTramo objLogica = new LoContencionTramo();
            dt = objLogica.ContencionTramo_RPT(objListEn);
            #endregion Logica

            ds.Tables.Add(dt.Copy());
            ds.Tables[0].TableName = "RPT_Contencion";
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion Funciones

}