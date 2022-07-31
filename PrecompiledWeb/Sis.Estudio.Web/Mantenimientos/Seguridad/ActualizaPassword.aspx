<%@ page title="" language="C#" masterpagefile="~/Master/Ceem.master" autoeventwireup="true" inherits="Mantenimientos_Seguridad_ActualizaPassword, App_Web_ovdm0cuh" stylesheettheme="Standard" %>


<%@ Register Assembly="GMDatePicker" Namespace="GrayMatterSoft" TagPrefix="cc2" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="cc3" %>
<%@ MasterType VirtualPath="~/Master/Ceem.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DefaultContent" Runat="Server">
    <script language="javascript">
        function Enter_Buscar(evt) {
        }

        function Valida_Todos() {

        }

    </script>
    <table id="tbContenedor" width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td style="width: 100%">
                <table id="tbContenedorDatos" cellpadding="0" cellspacing="0" style="width: 100%">
                    <tr class="Etiqueta">
                        <td align="center" style="width: 100%">
                            <asp:UpdatePanel ID="upBotonera" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <table cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tr>
                                            <td class="altoverow" style="text-align: center">
                                                <asp:ValidationSummary ID="vsError" runat="server" HeaderText="No puede realizar esta Operación:"
                                                    ShowMessageBox="True" ShowSummary="False" CssClass="Etiqueta" />
                                                <asp:Label ID="lblMensaje" runat="server" CssClass="Etiqueta" ForeColor="Red"></asp:Label><input
                                                    id="hdnContinuar" name="hdnContinuar" style="width: 80px; height: 10px" type="hidden" />
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:UpdatePanel ID="upGvUsuario" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <table id="tbToolbarSuperior" cellpadding="0" cellspacing="0" class="cabeceraScroll" 
                                        style="width: 100%">
                                        <tbody>
                                            <tr>
                                                <td>

<table border="0" cellpadding="0" cellspacing="0" class="cabeceraScroll" style="width: 100%">
    <tr>
        <td align="left" style="height: 28px; width: 723px;">
            &nbsp;</td>
        <td align="left" style="height: 28px; width: 164px;">
            <asp:Label ID="lblPaginado0" runat="server">Contraseña Actual:</asp:Label>
            &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;</td>
        <td style="width: 312px; height: 28px">
            <asp:TextBox ID="txt_clave" runat="server" 
                onkeydown="return Enter_Buscar(event)" TextMode="Password" Width="300px"  
                maxlength="15"></asp:TextBox>
        </td>
        <td style="height: 28px; width: 141px;">
            &nbsp;&nbsp;
        </td>
        <td style="height: 28px;">
            &nbsp;</td>
    </tr>
    <tr>
        <td align="left" style="height: 28px; width: 723px;">
            &nbsp;</td>
        <td align="left" style="height: 28px; width: 164px;">
            <asp:Label ID="lblPaginado1" runat="server">Nueva Contraseña:</asp:Label>
        </td>
        <td style="width: 312px; height: 28px">
            <asp:TextBox ID="txt_clavenueva" runat="server" 
                onkeydown="return Enter_Buscar(event)" TextMode="Password" Width="300px" 
                MaxLength="15"></asp:TextBox>
        </td>
        <td style="height: 28px; width: 141px;">
            &nbsp;</td>
        <td style="height: 28px;">
            &nbsp;</td>
    </tr>
    <tr>
        <td align="left" style="height: 28px; width: 723px;">
            &nbsp;</td>
        <td align="left" style="height: 28px; width: 164px;">
            <asp:Label ID="lblPaginado2" runat="server">Repetir Contraseña:</asp:Label>
        </td>
        <td style="width: 312px; height: 28px">
            <asp:TextBox ID="txt_clavenueva2" runat="server" 
                onkeydown="return Enter_Buscar(event)" TextMode="Password" Width="300px" 
                MaxLength="15"></asp:TextBox>
        </td>
        <td style="height: 28px; width: 141px;">
            &nbsp;</td>
        <td style="height: 28px;">
            &nbsp;</td>
    </tr>
    <tr>
        <td align="left" style="height: 28px; width: 723px;">
            &nbsp;</td>
        <td align="left" style="height: 28px; width: 164px;">
            &nbsp;</td>
        <td style="width: 312px; height: 28px; text-align: left;">
            <asp:Button ID="btnProcesar" runat="server" CausesValidation="False" 
                OnClick="btnProcesar_Click" style="height: 26px" Text="Cambiar" Width="120px" />
        </td>
        <td style="height: 28px; width: 141px;">
            &nbsp;</td>
        <td style="height: 28px;">
            &nbsp;</td>
    </tr>
</table>

                                                        
                                                        </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <table class="cabeceraScroll" style="width: 100%"  
                                        <tr>
                                        </tr>
                                        <tr>
                                            <td style="height: 32px">
                                                
                                                &nbsp;</td>
                                        </tr>
                                    </table>




















                                    <table cellpadding="0" cellspacing="0" style="width: 100%; text-align: center;">
                                        <tr>
                                            <td class="pagerstyle" style="height: 30px; text-align: center">
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnProcesar" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%; text-align: center">
                            <asp:UpdateProgress ID="uprogGvUsuario" runat="server" AssociatedUpdatePanelID="upGvUsuario"
                                DisplayAfter="250">
                                <ProgressTemplate>
                                    <asp:Panel ID="pnlGvCargando" runat="server" SkinID="PanelCargando" Width="100px">
                                        <table id="tbGvCargando" cellpadding="1" cellspacing="1" style="width: 100%">
                                            <tbody>
                                                <tr>
                                                    <td style="width: 50%; text-align: center">
                                                        <asp:Label ID="lblGvCargando" runat="server" Style="cursor: pointer" Text="Cargando..."
                                                            CssClass="modalPopup"></asp:Label>
                                                    </td>
                                                    <td style="width: 50%; text-align: justify">
                                                        <asp:Image ID="imgCargando" runat="server" ImageUrl="../../Imagenes/cargando.gif" Width="25px" Height="24px" />
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </asp:Panel>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 100%">
            </td>
        </tr>
    </table>
</asp:Content>



