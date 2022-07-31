<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReporteGestionCampo.aspx.cs"
    Inherits="Reportes_Reportes_ReporteGestionCampo" %>

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
                <asp:BoundColumn DataField="SG_Documento" HeaderText="NUM-CTA"></asp:BoundColumn>
                <asp:BoundColumn DataField="DNI" HeaderText="Doc"></asp:BoundColumn>
                <asp:BoundColumn DataField="Nombre" HeaderText="NOMBRE_CLIENTE"></asp:BoundColumn>
                <asp:BoundColumn DataField="SaldoCapital" HeaderText="Mora_Saldo_Facturado"></asp:BoundColumn>
                <asp:BoundColumn DataField="Estatus" HeaderText="Estatus"></asp:BoundColumn>
                <asp:BoundColumn DataField="f_tramo_atraso" HeaderText="Tramo_Mora"></asp:BoundColumn>
                <asp:BoundColumn DataField="cmc_estatus" HeaderText="SEGMENTO_SAL_CAPITAL"></asp:BoundColumn>
                <asp:BoundColumn DataField="Dir" HeaderText="DIRECCION_DOMICILIO"></asp:BoundColumn>
                <asp:BoundColumn DataField="Referencia" HeaderText="REF_DIR_DOMICILIO"></asp:BoundColumn>
                <asp:BoundColumn DataField="Distrito" HeaderText="Dir_Dom_Dist"></asp:BoundColumn>
                <asp:BoundColumn DataField="Descripcion" HeaderText="CLASIFICACION"></asp:BoundColumn>
                <asp:BoundColumn DataField="comentario" HeaderText="COMENTARIO"></asp:BoundColumn>
                <asp:BoundColumn DataField="FechaVisita" HeaderText="FECHA VISITA"></asp:BoundColumn>
                <asp:BoundColumn DataField="Gestor" HeaderText="NOMBRE DEL GESTOR"></asp:BoundColumn>
                <asp:BoundColumn DataField="Telefonos" HeaderText="TELEFONOS"></asp:BoundColumn>
                
            </Columns>
        </asp:DataGrid>
    </div>
    </form>
</body>
</html>
