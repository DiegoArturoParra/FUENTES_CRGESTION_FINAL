<%@ page language="C#" masterpagefile="~/Master/Plantilla.master" autoeventwireup="true" inherits="Advertencia, App_Web_j4zv4f42" stylesheettheme="Standard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DefaultContent" runat="Server">
    <link href="Estilo/Estilo.css" rel="stylesheet" type="text/css" />
    <asp:UpdatePanel ID="upLogin" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <img src="imagenes/icon-unplugged.png" style="text-align:center" />
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>