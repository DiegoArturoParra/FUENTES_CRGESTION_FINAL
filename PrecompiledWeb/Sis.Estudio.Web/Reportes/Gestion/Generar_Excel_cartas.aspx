﻿<%@ page language="C#" autoeventwireup="true" inherits="Reportes_Gestion_Generar_Excel_cartas, App_Web_x3dakkpr" stylesheettheme="Standard" %>

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
                <asp:BoundColumn DataField="IDREG_GESTION_COBRANZA" HeaderText="IDREG_GESTION_COBRANZA"></asp:BoundColumn>
                <asp:BoundColumn DataField="CODIGOCLIENTE" HeaderText="CODIGOCLIENTE"></asp:BoundColumn>
                <asp:BoundColumn DataField="DNI" HeaderText="DNI"></asp:BoundColumn>
                
                <asp:BoundColumn DataField="RAZONSOCIAL" HeaderText="NOMBRE"></asp:BoundColumn>
                <asp:BoundColumn DataField="PRODUCTO" HeaderText="PRODUCTO"></asp:BoundColumn>
                <asp:BoundColumn DataField="SUBPRODUCTO" HeaderText="SUBPRODUCTO"></asp:BoundColumn>
                <asp:BoundColumn DataField="Descripcion_direccion" HeaderText="Descripcion_direccion"></asp:BoundColumn>

                     <asp:BoundColumn DataField="Referencia_direccion" HeaderText="Referencia_direccion"></asp:BoundColumn>

                <asp:BoundColumn DataField="NroTelefonico" HeaderText="NroTelefonico"></asp:BoundColumn>
                 <asp:BoundColumn DataField="" HeaderText="CodigoResultado"></asp:BoundColumn>
                  <asp:BoundColumn DataField="" HeaderText="CodigoClasificacion"></asp:BoundColumn>
                
                
            </Columns>
        </asp:DataGrid>  
    </div>
    </form>
</body>
</html>
