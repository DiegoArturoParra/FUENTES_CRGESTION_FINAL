<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GestionesInternas_Excel_GestionesUsuario.aspx.cs" 
    Inherits="Reportes_Gestion_GestionesInternas_Excel_GestionesUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Gestiones Internas del Usuario</title>
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
                <%--<asp:BoundColumn DataField="IDREG_GESTION_COBRANZA" HeaderText="IDREG_GESTION_COBRANZA"></asp:BoundColumn>--%>
                <asp:BoundColumn DataField="DNI" HeaderText="DNI"></asp:BoundColumn>
                <asp:BoundColumn DataField="RUC" HeaderText="RUC"></asp:BoundColumn>
                <asp:BoundColumn DataField="RazonSocial" HeaderText="Razón Social"></asp:BoundColumn>
                <asp:BoundColumn DataField="Producto" HeaderText="Producto"></asp:BoundColumn>
                <asp:BoundColumn DataField="SubProducto" HeaderText="Sub-Producto"></asp:BoundColumn>
                <asp:BoundColumn DataField="DiasMora" HeaderText="Días Mora"></asp:BoundColumn>
                <asp:BoundColumn DataField="FechaTomaControl" HeaderText="FechaTomaControl"></asp:BoundColumn>
                <asp:BoundColumn DataField="FechaLimite" HeaderText="FechaLimite"></asp:BoundColumn>
                <asp:BoundColumn DataField="Responsable" HeaderText="Responsable"></asp:BoundColumn>
                <asp:BoundColumn DataField="CodUsuarioNuevo" HeaderText="CodUsuarioNuevo"></asp:BoundColumn>
                <asp:BoundColumn DataField="CodEstadoInterno" HeaderText="CodEstadoInterno"></asp:BoundColumn>
                
            </Columns>
        </asp:DataGrid> 
    </div>
    </form>
</body>
</html>
