<%@ control language="C#" autoeventwireup="true" inherits="WebUserControl_WUCCabecera, App_Web_dlgnf4pc" %>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td width="" height="200" class="lateralizq">
            &nbsp;
        </td>
        <td width="1500px">
            <table width="100%"  height="200" border="0" cellpadding="0" cellspacing="0" class="cabecera">
                <tr>
                    <td colspan="2">
                        &nbsp;
                    </td>
                    <td width="25%" height="97">
                        <asp:DropDownList ID="cmb_MODULO" runat="server" AutoPostBack="True" Width="100px"
                            OnSelectedIndexChanged="cmb_MODULO_SelectedIndexChanged" Visible="False">
                            <asp:ListItem Value="False">Ir al Modulo</asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td width="4%" rowspan="2">
                        &nbsp;
                    </td>
                    <td style="padding-top: 30px;">
                        <asp:Label ID="ltwelcome" Text="Bienvenido(a): " runat="server" SkinID="labeltextonegro" />
                        <asp:Label ID="ltusuario" runat="server" SkinID="labeltextonegro" />

              
                        
                    </td>
                 
         
                    <td  height="30" align="left" style="padding-top: 25px;">

                    
                          
                            &nbsp;&nbsp;&nbsp;&nbsp;
                    
                       
                        <asp:LinkButton ID="lkb_CambiarPass" runat="server" SkinID="linkbutton" OnClick="lkb_CambiarPass_Click">► Cambiar Password</asp:LinkButton>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblAyuda" runat="server" SkinID="labeltextonegro" Style="cursor: hand;"
                            Font-Underline="False" Visible="False">► Ayuda</asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:LinkButton ID="linkCerrar" runat="server" SkinID="linkbutton" message="Se cerrar&aacute; la sesi&oacute;n,  &iquest;Desea continuar?"
                            OnClientClick='return confirm(this.getAttribute("message"));' OnClick="linkCerrar_Click">► Cerrar</asp:LinkButton>
                    </td>

                    
                </tr>
              
                <tr>
                    <td width="71%" height="20">
                        <asp:Menu ID="mnuPrincipal" runat="server" SkinID="_menuExito" Orientation="Horizontal">
                        </asp:Menu>
                    </td>
                    <td height="20">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="3" height="10">
                        &nbsp;
                    </td>
                </tr>
            </table>
        </td>
        <td width="" class="lateralder">
            &nbsp;
        </td>
    </tr>
</table>
