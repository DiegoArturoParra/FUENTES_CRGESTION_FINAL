<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ContencionClasificacionC.aspx.cs" Inherits="Estudio_Reportes_ContencionClasificacionC" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>

    <style type="text/css">
        .modalBackground
        {
            background-color: Black;
            filter: alpha(opacity=70);
            opacity: 0.7;
        }
        
        .updateProgress
        {		
	        position: absolute;
	        width: 180px;
	        height: 65px;
        }
    </style>

</head>
<body>






    <form id="form1" runat="server">

            
            <div>
                <cr:crystalreportsource ID="CrystalReportSource1" runat="server">
                    <Report FileName="ContencionClasificacion.rpt">
                    </Report>
                </cr:crystalreportsource>    
            </div>

            <cr:crystalreportviewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"
                    EnableDatabaseLogonPrompt="False"
                HasCrystalLogo="False" HasToggleGroupTreeButton="False" 
                Height="1202px" ReportSourceID="CrystalReportSource1" 
            Width="868px" ToolPanelView="None" DisplayStatusbar="False" 
                EnableTheming="False" HasDrilldownTabs="False" HasSearchButton="False" 
                HasToggleParameterPanelButton="False" EnableToolTips="False" 
                HasDrillUpButton="False" HasGotoPageButton="False" HasRefreshButton="True"/>
                



    </form>





</body>
</html>

