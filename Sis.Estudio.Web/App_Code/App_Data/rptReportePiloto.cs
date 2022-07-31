using System;
using System.ComponentModel;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;

/// <summary>
/// Descripción breve de rptReportePiloto
/// </summary>
public class rptReportePiloto:ReportClass
{
	public rptReportePiloto()
            {
    }
 public override string ResourceName
    {
        get
        {
            return "ReportePiloto.rpt";
        }
        set
        {
            // Do nothing
        }
    }
          }
    
