<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProcesosMasivos_Excel_Whatsapp.aspx.cs" Inherits="Reportes_Gestion_ProcesosMasivos_Excel_Whatsapp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <br />
            <br />
            <asp:DataGrid ID="dg" runat="server" Width="329px" SelectedIndex="3" PageSize="3"
                HorizontalAlign="Left" Height="127px" GridLines="Vertical" ForeColor="#FFFFCC"
                Font-Underline="False" Font-Strikeout="False" Font-Size="X-Small" Font-Overline="False"
                Font-Names="Trebuchet MS" Font-Italic="False" Font-Bold="False" CellPadding="4"
                BorderWidth="1px" BorderStyle="None" BorderColor="#DEDFDE" BackColor="White"
                AutoGenerateColumns="False">
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
                    <asp:BoundColumn DataField="NroTelefonico" HeaderText="NRO_TELEFONICO"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Descripcion_carta" HeaderText="MENSAJE"></asp:BoundColumn>
                </Columns>
            </asp:DataGrid>
        </div>
    </form>
</body>
</html>
