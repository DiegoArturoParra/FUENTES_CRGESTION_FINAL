using System;
using System.ComponentModel;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;
/// <summary>
/// Descripción breve de rptReporteGestionEjecutoresNivel1
/// </summary>
public class rptReporteGestionEjecutoresNivel1 : ReportClass
{
	public rptReporteGestionEjecutoresNivel1()
    {

    }

    public override string ResourceName
    {
        get
        {
            return "RPT_Gestion_Ejecutores_Nivel1.rpt";
        }
        set
        {
            // Do nothing
        }
    }
}