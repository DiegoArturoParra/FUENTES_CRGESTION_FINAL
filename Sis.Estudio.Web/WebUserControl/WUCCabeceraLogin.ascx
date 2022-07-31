<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WUCCabeceraLogin.ascx.cs"
    Inherits="WebUserControl_WUCCabeceraLogin" %>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <%--<td width="" height="100" class="lateralizq">
            &nbsp;
        </td>--%>
        <td width="100%">
            <table width="100%" height="100" border="0" cellpadding="0" cellspacing="0" class="cabecera">
                <%--<tr>
                    <td colspan="2">
                        &nbsp;
                    </td>
                    <td width="25%" height="97">
                        &nbsp;
                    </td>
                </tr>--%>
                <tr>
                    <td width="4%" rowspan="2">
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td height="23" align="left">
                        <asp:LinkButton ID="LKB_Login" runat="server" SkinID="linkbutton" OnClick="LKB_Login_Click">► Iniciar sesión</asp:LinkButton>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblAyuda" runat="server" SkinID="labeltextonegro" Style="cursor: hand;"
                            Font-Underline="False" Visible="False">► Ayuda</asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:LinkButton ID="linkCerrar" runat="server" SkinID="linkbutton" message="Se cerrar&aacute; la sesi&oacute;n,  &iquest;Desea continuar?"
                            OnClientClick='return confirm(this.getAttribute("message"));' OnClick="linkCerrar_Click">► Cerrar</asp:LinkButton>
                    </td>
                </tr>
                <%--<tr>
                    <td width="71%" height="20">
                        &nbsp;
                    </td>
                    <td height="20">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="3" height="10">
                        &nbsp;
                    </td>
                </tr>--%>
            </table>
        </td>
        <%--<td width="" class="lateralder">
            &nbsp;
        </td>--%>
    </tr>
</table>
