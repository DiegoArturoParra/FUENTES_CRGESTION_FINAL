using System;
using System.ComponentModel;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;
/// <summary>
/// Descripción breve de rptReporteGestionEjecutoresNivel2
/// </summary>
public class rptReporteGestionEjecutoresNivel2 : ReportClass
{
	public rptReporteGestionEjecutoresNivel2()
    {

    }

    public override string ResourceName
    {
        get
        {
            return "RPT_Gestion_Ejecutores_Nivel2.rpt";
        }
        set
        {
            // Do nothing
        }
    }
}