<%@ page title="" language="C#" masterpagefile="~/Master/Public.master" autoeventwireup="true" inherits="Login, App_Web_yp1m0qma" stylesheettheme="Standard" %>
<%@ MasterType VirtualPath="~/Master/Public.master"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="DefaultContent" runat="Server">
    <link href="Estilo/Estilo.css" rel="stylesheet" type="text/css" />
    <asp:UpdatePanel ID="upLogin" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table width="739" height="487" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="login">
                        <table width="100%" height="252" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td width="48%" rowspan="5">
                                    &nbsp;
                                </td>
                                <td colspan="2" valign="middle" style="height: 143px">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td width="14%" valign="middle">
                                    &nbsp;
                                    <asp:Label ID="lblusuario" runat="server" SkinID="labeltextoblanco">Usuario</asp:Label>
                                </td>
                                <td height="22" valign="middle" class="style1" style="text-align: left">
                                    <asp:TextBox ID="txtUserName" runat="server" MaxLength="25" Width="140px">admin</asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserName"
                                        Display="Dynamic" ErrorMessage="*" ForeColor="White"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td valign="middle">
                                    &nbsp;
                                    <asp:Label ID="lblclave" runat="server" SkinID="labeltextoblanco">Contraseña</asp:Label>
                                </td>
                                <td height="22" valign="middle" class="style1" style="text-align: left">
                                    <asp:TextBox ID="txtPassword" runat="server" MaxLength="15" TextMode="Password" Width="140px">admin</asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword"
                                        Display="Dynamic" ErrorMessage="*" ForeColor="White"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td height="19" colspan="2" valign="bottom">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td valign="middle">
                                    &nbsp;
                                </td>
                                <td valign="middle" class="style1" style="text-align: left">
                                    &nbsp;<asp:ImageButton ID="btnLogin" runat="server" ImageUrl="imagenes/btningresar1.png"
                                        onmouseover="javascript:this.src='imagenes/btningresar2.png';this.style.cursor='hand'"
                                        onmouseout="javascript:this.src='imagenes/btningresar1.png';" Height="46px" Width="140px"
                                        OnClick="btnLogin_Click" />
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td>
                                    <div align="center">
                                        <asp:Label ID="lblMensaje" runat="server" SkinID="labeltextoblanco"></asp:Label>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div align="center">
                                        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                            <ProgressTemplate>
                                                <br />
                                                <span style="color: #ffffff; font-size: 10pt; font-family: Arial;">Procesando tu solicitud..<br />
                                                    <img id="img2" src="Imagenes/cargando.gif" style="width: 25px; height: 24px" />
                                                    <br />
                                                </span>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>


