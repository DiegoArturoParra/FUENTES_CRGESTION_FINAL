<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Resultados_ProcesosMasivos_Excel.aspx.cs" Inherits="Resultados_ProcesosMasivos_Excel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>FileUpload.SaveAs Method Example</title>
</head>
<body>


    <form id="form1" runat="server">
    <div>
        <br />
        <br />
        <br />

        
<asp:FileUpload ID="FileUpload1" runat="server" />


        <asp:DataGrid ID="dg" runat="server" Width="329px" SelectedIndex="3" PageSize="3"
            HorizontalAlign="Left" Height="127px" GridLines="Vertical" ForeColor="#FFFFCC"
            Font-Underline="False" Font-Strikeout="False" Font-Size="X-Small" Font-Overline="False"
            Font-Names="Trebuchet MS" Font-Italic="False" Font-Bold="False" CellPadding="4"
            BorderWidth="1px" BorderStyle="None" BorderColor="#DEDFDE" BackColor="White"
            AutoGenerateColumns="False" 
            onselectedindexchanged="dg_SelectedIndexChanged">
            <FooterStyle BackColor="#CCCC99" />
            <SelectedItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" Mode="NumericPages" />
            <AlternatingItemStyle BackColor="White" />
            <ItemStyle BackColor="#F0F0F0" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                Font-Strikeout="False" Font-Underline="False" ForeColor="Black" />
            <HeaderStyle BackColor="MidnightBlue" Font-Bold="True" Font-Italic="False" Font-Names="Arial"
                Font-Overline="False" Font-Size="X-Small" Font-Strikeout="False" Font-Underline="False"
                ForeColor="White" />
            <Columns>
                <asp:BoundColumn DataField="ACTION_PLAN" HeaderText="ACTION PLAN"></asp:BoundColumn>
                <asp:BoundColumn DataField="COD_AP" HeaderText="CODIGO AP"></asp:BoundColumn>
                <asp:BoundColumn DataField="CLASIFICACION" HeaderText="CLASIFICACION"></asp:BoundColumn>
                <asp:BoundColumn DataField="COD_CLASIFICACION" HeaderText="CODIGO CLASIF."></asp:BoundColumn>
                <asp:BoundColumn DataField="RESULTADO" HeaderText="RESULTADO"></asp:BoundColumn>
                <asp:BoundColumn DataField="COD_RESULTADO" HeaderText="CODIGO RESULT."></asp:BoundColumn>
            </Columns>
        </asp:DataGrid>        
    </div>
    </form>
</body>
</html>
