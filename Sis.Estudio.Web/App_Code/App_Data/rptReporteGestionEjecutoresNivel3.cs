using System;
using System.ComponentModel;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;
/// <summary>
/// Descripción breve de rptReporteGestionEjecutoresNivel3
/// </summary>
public class rptReporteGestionEjecutoresNivel3:ReportClass
{
	public rptReporteGestionEjecutoresNivel3()
	{

	}

    public override string ResourceName
    {
        get
        {
            return "RPT_Gestion_Ejecutores_Nivel3.rpt";
        }
        set
        {
            // Do nothing
        }
    }
}