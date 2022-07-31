<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReporteGestionEjecutoresC.aspx.cs"
    Inherits="Reportes_Reportes_ReporteGestionEjecutoresC" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
            Font-Names="Times New Roman" Font-Italic="False" Font-Bold="False" CellPadding="4"
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
                <asp:BoundColumn DataField="Titulo" HeaderText="Titulo"></asp:BoundColumn>
                <asp:BoundColumn DataField="CodTipoGestion" HeaderText="CodTipoGestion"></asp:BoundColumn>
                <asp:BoundColumn DataField="TipoGestion" HeaderText="TipoGestion"></asp:BoundColumn>
                <asp:BoundColumn DataField="TotalTipoGestion" HeaderText="TotalTipoGestion"></asp:BoundColumn>
                <asp:BoundColumn DataField="CodEjecutado" HeaderText="CodEjecutado"></asp:BoundColumn>
                <asp:BoundColumn DataField="Ejecutado" HeaderText="Ejecutado"></asp:BoundColumn>
                <asp:BoundColumn DataField="TotalEjecutado" HeaderText="TotalEjecutado"></asp:BoundColumn>
                <asp:BoundColumn DataField="Resultado" HeaderText="Resultado"></asp:BoundColumn>
                <asp:BoundColumn DataField="CodClaseGestion" HeaderText="CodClaseGestion"></asp:BoundColumn>
                <asp:BoundColumn DataField="TotalResultado" HeaderText="TotalResultado"></asp:BoundColumn>
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
    </div>
    </form>
</body>
</html>
