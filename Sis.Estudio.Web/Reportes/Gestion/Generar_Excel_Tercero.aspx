<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Generar_Excel_Tercero.aspx.cs" Inherits="Reportes_Gestion_Generar_Excel_Tercero" %>

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
                <asp:BoundColumn DataField="IdReg" HeaderText="IdReg"></asp:BoundColumn>
                <asp:BoundColumn DataField="CodigoCliente" HeaderText="CodigoCliente"></asp:BoundColumn>
                <asp:BoundColumn DataField="DNI" HeaderText="DNI"></asp:BoundColumn>
                
                <asp:BoundColumn DataField="RUC" HeaderText="RUC"></asp:BoundColumn>
                <asp:BoundColumn DataField="ApePat" HeaderText="ApePat"></asp:BoundColumn>
                <asp:BoundColumn DataField="ApeMat" HeaderText="ApeMat"></asp:BoundColumn>
                <asp:BoundColumn DataField="Nombres" HeaderText="Nombres"></asp:BoundColumn>

                     <asp:BoundColumn DataField="SG_Documento" HeaderText="SG_Documento"></asp:BoundColumn>

                <asp:BoundColumn DataField="Dir" HeaderText="Dir"></asp:BoundColumn>
                 <asp:BoundColumn DataField="Distrito" HeaderText="Distrito"></asp:BoundColumn>
                  <asp:BoundColumn DataField="Dato" HeaderText="Dato"></asp:BoundColumn>
                
                
                <asp:BoundColumn DataField="GeoX" HeaderText="GeoX"></asp:BoundColumn>
                <asp:BoundColumn DataField="GeoY" HeaderText="GeoY"></asp:BoundColumn>
                <asp:BoundColumn DataField="CodProducto" HeaderText="CodProducto"></asp:BoundColumn>
                <asp:BoundColumn DataField="Producto" HeaderText="Producto"></asp:BoundColumn>
                <asp:BoundColumn DataField="NroCuotas" HeaderText="NroCuotas"></asp:BoundColumn>
                <asp:BoundColumn DataField="FechaVencimiento" HeaderText="FechaVencimiento"></asp:BoundColumn>
                <asp:BoundColumn DataField="FechaPago" HeaderText="FechaPago"></asp:BoundColumn>
                <asp:BoundColumn DataField="MontoCuota" HeaderText="MontoCuota"></asp:BoundColumn>
                <asp:BoundColumn DataField="SaldoCapital" HeaderText="SaldoCapital"></asp:BoundColumn>
                <asp:BoundColumn DataField="Moneda" HeaderText="Moneda"></asp:BoundColumn>
                <asp:BoundColumn DataField="MontoDesemb" HeaderText="MontoDesemb"></asp:BoundColumn>
                <asp:BoundColumn DataField="TotCuotasPact" HeaderText="TotCuotasPact"></asp:BoundColumn>
                <asp:BoundColumn DataField="MontoCuota" HeaderText="MontoCuota"></asp:BoundColumn>
                <asp:BoundColumn DataField="CodigoSBS" HeaderText="CodigoSBS"></asp:BoundColumn>
                <asp:BoundColumn DataField="CodUsuario_Asesores" HeaderText="CodUsuario_Asesores"></asp:BoundColumn>
                <asp:BoundColumn DataField="Asesor" HeaderText="Asesor"></asp:BoundColumn>
                <asp:BoundColumn DataField="dias_mora" HeaderText="dias_mora"></asp:BoundColumn>
                <asp:BoundColumn DataField="Tramo" HeaderText="Tramo"></asp:BoundColumn>
                <asp:BoundColumn DataField="CodCalificacionSBS" HeaderText="CodCalificacionSBS"></asp:BoundColumn>
                
                
            </Columns>
        </asp:DataGrid>  
    </div>
    </form>
</body>
</html>
