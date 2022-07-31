<%@ page language="C#" autoeventwireup="true" inherits="Estudio_Reportes_ReporteRecuperacionGestionAsesores_Nivel3C, App_Web_r2n2tuxx" stylesheettheme="Standard" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
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

  <br />
        <br />
        <br />
    
  
 
           <asp:DataGrid ID="dg" runat="server" Width="514px" SelectedIndex="3" PageSize="3"
            HorizontalAlign="Left" Height="194px"
            Font-Underline="False" Font-Strikeout="False" Font-Size="X-Small" Font-Overline="False"
            Font-Names="Times New Roman" Font-Italic="False" Font-Bold="False" CellPadding="3"
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
           <asp:BoundColumn DataField="DeuInicio" HeaderText="Deuda Inicio"></asp:BoundColumn>
                <asp:BoundColumn DataField="DeuActual" HeaderText="Deuda Actual"></asp:BoundColumn>
                <asp:BoundColumn DataField="ProvInicio" HeaderText="Provision Inicial"></asp:BoundColumn>
                <asp:BoundColumn DataField="ProvActual" HeaderText="Provision Actual"></asp:BoundColumn>

<asp:BoundColumn DataField="Nivel4" HeaderText="Nivel4"></asp:BoundColumn>
<asp:BoundColumn DataField="cliente" HeaderText="CLIENTE"></asp:BoundColumn>
<asp:BoundColumn DataField="Producto" HeaderText="PRODUCTO"></asp:BoundColumn>
<asp:BoundColumn DataField="TotGestEje" HeaderText="Total Gestion Ejecutada"></asp:BoundColumn>
<asp:BoundColumn DataField="TotDeuda" HeaderText="DEUDA"></asp:BoundColumn>
<asp:BoundColumn DataField="r1" HeaderText="r1"></asp:BoundColumn>
<asp:BoundColumn DataField="r2" HeaderText="r2"></asp:BoundColumn>
<asp:BoundColumn DataField="r3" HeaderText="r3"></asp:BoundColumn>
<asp:BoundColumn DataField="r4" HeaderText="r4"></asp:BoundColumn>
<asp:BoundColumn DataField="r5" HeaderText="r5"></asp:BoundColumn>
<asp:BoundColumn DataField="r6" HeaderText="r6"></asp:BoundColumn>
<asp:BoundColumn DataField="r7" HeaderText="r7"></asp:BoundColumn>
<asp:BoundColumn DataField="r8" HeaderText="r8"></asp:BoundColumn>
<asp:BoundColumn DataField="r9" HeaderText="r9"></asp:BoundColumn>
<asp:BoundColumn DataField="r10" HeaderText="r10"></asp:BoundColumn>
<asp:BoundColumn DataField="r11" HeaderText="r11"></asp:BoundColumn>
<asp:BoundColumn DataField="r12" HeaderText="r12"></asp:BoundColumn>
<asp:BoundColumn DataField="r13" HeaderText="r13"></asp:BoundColumn>
<asp:BoundColumn DataField="r14" HeaderText="r14"></asp:BoundColumn>
<asp:BoundColumn DataField="r15" HeaderText="r15"></asp:BoundColumn>
<asp:BoundColumn DataField="r16" HeaderText="r16"></asp:BoundColumn>
<asp:BoundColumn DataField="r17" HeaderText="r17"></asp:BoundColumn>
<asp:BoundColumn DataField="r18" HeaderText="r18"></asp:BoundColumn>
<asp:BoundColumn DataField="r19" HeaderText="r19"></asp:BoundColumn>
<asp:BoundColumn DataField="r20" HeaderText="r20"></asp:BoundColumn>
<asp:BoundColumn DataField="r21" HeaderText="r21"></asp:BoundColumn>
<asp:BoundColumn DataField="r22" HeaderText="r22"></asp:BoundColumn>
<asp:BoundColumn DataField="r23" HeaderText="r23"></asp:BoundColumn>
<asp:BoundColumn DataField="r24" HeaderText="r24"></asp:BoundColumn>
<asp:BoundColumn DataField="r25" HeaderText="r25"></asp:BoundColumn>
<asp:BoundColumn DataField="r26" HeaderText="r26"></asp:BoundColumn>
<asp:BoundColumn DataField="r27" HeaderText="r27"></asp:BoundColumn>
<asp:BoundColumn DataField="r28" HeaderText="r28"></asp:BoundColumn>
<asp:BoundColumn DataField="r29" HeaderText="r29"></asp:BoundColumn>
<asp:BoundColumn DataField="r30" HeaderText="r30"></asp:BoundColumn>
<asp:BoundColumn DataField="r31" HeaderText="r31"></asp:BoundColumn>
<asp:BoundColumn DataField="TotRecup" HeaderText="TOTAL"></asp:BoundColumn>

            </Columns>
         

        </asp:DataGrid>
        
   <div style="width: 254px">
                <cr:crystalreportsource ID="CrystalReportSource1" runat="server">
                    <Report FileName="ReporteRecuperacionGestionAsesores_Nivel3.rpt">
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
