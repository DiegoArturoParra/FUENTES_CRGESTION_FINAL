<%@ control language="C#" autoeventwireup="true" inherits="WebUserControl_WUCCabecera, App_Web_o4pvqxxv" %>
<style type="text/css">
    .auto-style1 {
        width: 578px;
    }
</style>
<table width="100%" border="0" cellspacing="0" cellpadding="0" style="height:65px;">
    <tr style="height:65px;">
        <td width="100%" style="height:65px; margin-top:0px;">
            <table border="0" class="cabecera">
                <tr class="cabecera">                    
                    <td colspan="2">
                        <asp:DropDownList ID="cmb_MODULO" runat="server" AutoPostBack="True" Width=""
                            OnSelectedIndexChanged="cmb_MODULO_SelectedIndexChanged" Visible="False">
                            <asp:ListItem Value="False">Ir al Modulo</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Label ID="ltwelcome" Text="Usuario: " runat="server" SkinID="labeltextoblanco" />
                        <asp:Label ID="ltusuario" runat="server" SkinID="labeltextoblanco" />
                        <br />
                        <asp:Label ID="txlPerfil" Text="Perfil: " runat="server" SkinID="labeltextoblanco" />
                        <asp:Label ID="txcPerfil" runat="server" SkinID="labeltextoblanco" />
                    </td>
                </tr>
                <tr class="menu">
                    <td class="menuIzq">
                        <asp:Menu ID="mnuPrincipal" runat="server" SkinID="_menuExito" Orientation="Horizontal" OnMenuItemClick="mnuPrincipal_MenuItemClick" StaticPopOutImageTextFormatString="False">
                        </asp:Menu>
                    </td>
                    <td class="menuDer">
                        <asp:LinkButton ID="lkb_CambiarPass" runat="server" SkinID="linkbutton" OnClick="lkb_CambiarPass_Click">► Actualizar Contrase&ntilde;a</asp:LinkButton>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblAyuda" runat="server" SkinID="labeltextonegro" Style=""
                            Font-Underline="False" Visible="False">► Ayuda</asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:LinkButton ID="linkCerrar" runat="server" SkinID="linkbutton" message="Se cerrar&aacute; la sesi&oacute;n,  &iquest;Desea continuar?"
                            OnClientClick='return confirm(this.getAttribute("message"));' OnClick="linkCerrar_Click">► Cerrar Sesi&oacute;n</asp:LinkButton>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
