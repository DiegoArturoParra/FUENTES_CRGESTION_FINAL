<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RPT_Gestion_Ejecutores_Nivel2C.aspx.cs" Inherits="Estudio_Reportes_RPT_Gestion_Ejecutores_Nivel2C" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        #form1
        {
            text-align: left;
        }
    </style>
    </head>
<body>

    <form id="form1" runat="server">
 
        <asp:DataGrid ID="dg" runat="server" Width="366px" SelectedIndex="3" PageSize="3"
            HorizontalAlign="Left" Height="194px"
            Font-Underline="False" Font-Strikeout="False" Font-Size="X-Small" Font-Overline="False"
            Font-Names="Trebuchet MS" Font-Italic="False" Font-Bold="False" CellPadding="3"
            AutoGenerateColumns="False" onselectedindexchanged="dg_SelectedIndexChanged" 
               style="margin-top: 119px; margin-right: 224px;" ShowFooter="True" 
          AllowSorting="True" BackColor="White" BorderColor="#999999" BorderStyle="None" 
               BorderWidth="1px" GridLines="Vertical">

                            
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <SelectedItemStyle Font-Bold="True" BackColor="#008A8C" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" 
                   Mode="NumericPages" />
            <ItemStyle ForeColor="Black" BackColor="#EEEEEE" />

            
            <HeaderStyle BackColor="#000084" Font-Bold="True" Font-Names="Arial" Font-Size="X-Small"
                ForeColor="White" />
            
         
               <AlternatingItemStyle BackColor="#DCDCDC" />
            <Columns>
                <asp:BoundColumn DataField="Nivel3" HeaderText="Nivel3"></asp:BoundColumn>
                      <asp:BoundColumn DataField="Nivel4" HeaderText="Nivel4"></asp:BoundColumn>
                <asp:BoundColumn DataField="Titulo" HeaderText="Titulo"></asp:BoundColumn>
             


                        <asp:BoundColumn DataField="TipoGestion" HeaderText="TipoGestion"></asp:BoundColumn>
                  <asp:BoundColumn DataField="Ejecutado" HeaderText="Ejecutado"></asp:BoundColumn>
                              <asp:BoundColumn DataField="Resultado" HeaderText="Resultado"></asp:BoundColumn>

                <asp:BoundColumn DataField="D1" HeaderText="D1"></asp:BoundColumn>
                <asp:BoundColumn DataField="D2" HeaderText="D2"></asp:BoundColumn>
                <asp:BoundColumn DataField="D3" HeaderText="D3"></asp:BoundColumn>
                <asp:BoundColumn DataField="D4" HeaderText="D4"></asp:BoundColumn>
                <asp:BoundColumn DataField="D5" HeaderText="D5"></asp:BoundColumn>
                <asp:BoundColumn DataField="D6" HeaderText="D6"></asp:BoundColumn>
                <asp:BoundColumn DataField="D7" HeaderText="D7"></asp:BoundColumn>
                <asp:BoundColumn DataField="D8" HeaderText="D8"></asp:BoundColumn>
                <asp:BoundColumn DataField="D9" HeaderText="D9"></asp:BoundColumn>
                <asp:BoundColumn DataField="D10" HeaderText="D10"></asp:BoundColumn>
                <asp:BoundColumn DataField="D11" HeaderText="D11"></asp:BoundColumn>
                <asp:BoundColumn DataField="D12" HeaderText="D12"></asp:BoundColumn>
                <asp:BoundColumn DataField="D13" HeaderText="D13"></asp:BoundColumn>
                <asp:BoundColumn DataField="D14" HeaderText="D14"></asp:BoundColumn>
                <asp:BoundColumn DataField="D15" HeaderText="D15"></asp:BoundColumn>
                <asp:BoundColumn DataField="D16" HeaderText="D16"></asp:BoundColumn>
                <asp:BoundColumn DataField="D17" HeaderText="D17"></asp:BoundColumn>
                <asp:BoundColumn DataField="D18" HeaderText="D18"></asp:BoundColumn>
                <asp:BoundColumn DataField="D19" HeaderText="D19"></asp:BoundColumn>
                <asp:BoundColumn DataField="D20" HeaderText="D20"></asp:BoundColumn>
                <asp:BoundColumn DataField="D21" HeaderText="D21"></asp:BoundColumn>
                <asp:BoundColumn DataField="D22" HeaderText="D22"></asp:BoundColumn>
                <asp:BoundColumn DataField="D23" HeaderText="D23"></asp:BoundColumn>
                <asp:BoundColumn DataField="D24" HeaderText="D24"></asp:BoundColumn>
                <asp:BoundColumn DataField="D25" HeaderText="D25"></asp:BoundColumn>
                <asp:BoundColumn DataField="D26" HeaderText="D26"></asp:BoundColumn>
                <asp:BoundColumn DataField="D27" HeaderText="D27"></asp:BoundColumn>
                <asp:BoundColumn DataField="D28" HeaderText="D28"></asp:BoundColumn>
                <asp:BoundColumn DataField="D29" HeaderText="D29"></asp:BoundColumn>
                <asp:BoundColumn DataField="D30" HeaderText="D30"></asp:BoundColumn>
                <asp:BoundColumn DataField="D31" HeaderText="D31"></asp:BoundColumn>
               

            </Columns>
        </asp:DataGrid>


      <div style="width: 254px">
                <cr:crystalreportsource ID="CrystalReportSource1" runat="server">
                    <Report FileName="RPT_Gestion_Ejecutores_Nivel2.rpt">
                    </Report>
                </cr:crystalreportsource>    
            </div>
            
           <br />
        

        
            <cr:crystalreportviewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"
                    EnableDatabaseLogonPrompt="False"
                HasCrystalLogo="False" HasToggleGroupTreeButton="False" 
                Height="1202px" ReportSourceID="CrystalReportSource1" 
            Width="868px" ToolPanelView="None" DisplayStatusbar="False" 
                EnableTheming="True" HasDrilldownTabs="False" HasSearchButton="False" 
                HasToggleParameterPanelButton="False"/>

            <asp:Panel ID="Panel1" runat="server">
           </asp:Panel>


    </form>
</body>
</html>
