﻿using System;
using System.ComponentModel;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;

/// <summary>
/// 
/// breve de rptReporteGestionEjecutores
/// </summary>
public class rptReporteGestionEjecutores : ReportClass
{
	public rptReporteGestionEjecutores()
	{

	}

    public override string ResourceName
    {
        get
        {
            return "ReporteGestionEjecutores.rpt";
        }
        set
        {
            // Do nothing
        }
    }

    [Browsable(false)]
    [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
    public CrystalDecisions.CrystalReports.Engine.Section Section1
    {
        get
        {
            return this.ReportDefinition.Sections[0];
        }
    }

    [Browsable(false)]
    [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
    public CrystalDecisions.CrystalReports.Engine.Section Section2
    {
        get
        {
            return this.ReportDefinition.Sections[1];
        }
    }

    [Browsable(false)]
    [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
    public CrystalDecisions.CrystalReports.Engine.Section Section3
    {
        get
        {
            return this.ReportDefinition.Sections[2];
        }
    }

    [Browsable(false)]
    [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
    public CrystalDecisions.CrystalReports.Engine.Section Section4
    {
        get
        {
            return this.ReportDefinition.Sections[3];
        }
    }

    [Browsable(false)]
    [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
    public CrystalDecisions.CrystalReports.Engine.Section Section5
    {
        get
        {
            return this.ReportDefinition.Sections[4];
        }
    }
}


[System.Drawing.ToolboxBitmapAttribute(typeof(CrystalDecisions.Shared.ExportOptions), "report.bmp")]
public class CachedrptReporteGestionEjecutores : Component, ICachedReport
{
    public CachedrptReporteGestionEjecutores()
    {

    }

    public virtual bool IsCacheable
    {
        get
        {
            return true;
        }
        set
        {
            // 
        }
    }

    public virtual bool ShareDBLogonInfo
    {
        get
        {
            return false;
        }
        set
        {
            // 
        }
    }

    public virtual System.TimeSpan CacheTimeOut
    {
        get
        {
            return CachedReportConstants.DEFAULT_TIMEOUT;
        }
        set
        {
            // 
        }
    }

    public virtual CrystalDecisions.CrystalReports.Engine.ReportDocument CreateReport()
    {
        rptReporteGestionEjecutores rpt = new rptReporteGestionEjecutores();
        rpt.Site = this.Site;
        return rpt;
    }

    public virtual string GetCustomizedCacheKey(RequestContext request)
    {
        String key = null;
        // // The following is the code used to generate the default
        // // cache key for caching report jobs in the ASP.NET Cache.
        // // Feel free to modify this code to suit your needs.
        // // Returning key == null causes the default cache key to
        // // be generated.
        // 
        // key = RequestContext.BuildCompleteCacheKey(
        //     request,
        //     null,       // sReportFilename
        //     this.GetType(),
        //     this.ShareDBLogonInfo );
        return key;
    }

}