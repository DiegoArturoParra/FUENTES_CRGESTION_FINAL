<%@ page title="" language="C#" masterpagefile="~/Master/Ficha.master" autoeventwireup="true" inherits="Estudio_Gestion_01FrmDatosClienteDet, App_Web_hhkm3gt1" stylesheettheme="Standard" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/Master/Ficha.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../javascript/jquery-2.1.1.min.js" type="text/javascript"></script>
    <script src="../../javascript/jsUpdateProgress.js" type="text/javascript"></script>
    <script type="text/javascript">
        var ModalProgress = '<%= ModalProgress.ClientID %>';
    </script>
    <input id="hdnContinuar" name="hdnContinuar" style="width: 80px; height: 10px" type="hidden" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <contenttemplate>
    <table width="100%" border="0" cellspacing="0">
        <tbody>
            <tr>
                <td bgcolor="#c0c0c0" colspan="8">
                </td>
            </tr>
            <tr id="CodigoCliente">
                <td class="celda-titulo" style="width: 15%; height: 18px; text-align: right">
                    Código Cliente :
                </td>
                <td style="width: 15%; height: 18px; text-align: left">
                    <asp:TextBox Width="90%" ID="txt_CodigoCliente" runat="server" SkinID="Disabled"></asp:TextBox>
                </td>
                <td style="width: 5%; height: 18px; text-align: center">
                    &nbsp;
                </td>
                <td class="celda-titulo" style="width: 15%; height: 18px; text-align: right">
                    Tipo Persona :
                </td>
                <td style="width: 15%; height: 18px; text-align: left">
                    <asp:DropDownList ID="cmb_TipoPersona" runat="server" AutoPostBack="True" TabIndex="1"
                        Width="90%" OnSelectedIndexChanged="cmb_TipoPersona_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td style="width: 5%; height: 18px; text-align: center">
                    &nbsp;
                </td>
                <td class="celda-titulo" style="width: 15%; height: 18px; text-align: right">
                    Status Laboral :
                </td>
                <td style="width: 15%; height: 18px; text-align: left">
                    <asp:DropDownList ID="cmb_StatusLaboral" runat="server" AutoPostBack="True" TabIndex="1"
                        Width="90%" OnSelectedIndexChanged="cmb_StatusLaboral_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr id="CodigoSBS">
                <td class="celda-titulo" style="width: 15%; height: 18px; text-align: right">
                    Código SBS :
                </td>
                <td style="width: 15%; height: 18px; text-align: left">
                    <asp:TextBox Width="90%" ID="txt_CodigoSBS" runat="server" ></asp:TextBox>
                </td>
                <td style="width: 5%; height: 18px; text-align: center">
                    &nbsp;
                </td>
                <td class="celda-titulo" style="width: 15%; height: 18px; text-align: right">
                    RUC :
                </td>
                <td style="width: 15%; height: 18px; text-align: left">
                    <asp:TextBox Width="90%" ID="txt_RUC" runat="server"></asp:TextBox>
                </td>
                <td style="width: 5%; height: 18px; text-align: center">
                    &nbsp;
                </td>
                <td class="celda-titulo" style="width: 15%; height: 18px; text-align: right">
                    Razón Social :
                </td>
                <td style="width: 15%; height: 18px; text-align: left">
                    <asp:TextBox Width="90%" ID="txt_RazonSocial" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr id="DNI">
                <td class="celda-titulo" style="width: 15%; height: 18px; text-align: right">
                    DNI :
                </td>
                <td style="width: 15%; height: 18px; text-align: left">
                    <asp:TextBox Width="90%" ID="txt_DNI" runat="server"></asp:TextBox>
                </td>
                <td style="width: 5%; height: 18px; text-align: center">
                    &nbsp;
                </td>
                <td class="celda-titulo" style="width: 15%; height: 18px; text-align: right">
                    Estado Civil :
                </td>
                <td style="width: 15%; height: 18px; text-align: left">
                    <asp:DropDownList ID="cmb_EstadoCivil" runat="server" AutoPostBack="True" TabIndex="1"
                        Width="90%" OnSelectedIndexChanged="cmb_EstadoCivil_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td style="width: 5%; height: 18px; text-align: center">
                    &nbsp;
                </td>
                <td class="celda-titulo" style="width: 15%; height: 18px; text-align: right">
                    Profesión :
                </td>
                <td style="width: 15%; height: 18px; text-align: left">
                    <asp:TextBox Width="90%" ID="txt_Profesion" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr id="ApellidoPaterno">
                <td class="celda-titulo" style="width: 15%; height: 18px; text-align: right">
                    Apellido Paterno :
                </td>
                <td style="width: 15%; height: 18px; text-align: left">
                    <asp:TextBox Width="90%" ID="txt_ApePat" runat="server"></asp:TextBox>
                </td>
                <td style="width: 5%; height: 18px; text-align: center">
                    &nbsp;
                </td>
                <td class="celda-titulo" style="width: 15%; height: 18px; text-align: right">
                    Apellido Materno :
                </td>
                <td style="width: 15%; height: 18px; text-align: left">
                    <asp:TextBox Width="90%" ID="txt_ApeMat" runat="server"></asp:TextBox>
                </td>
                <td style="width: 5%; height: 18px; text-align: center">
                    &nbsp;
                </td>
                <td class="celda-titulo" style="width: 15%; height: 18px; text-align: right">
                    Nombres :
                </td>
                <td style="width: 15%; height: 18px; text-align: left">
                    <asp:TextBox Width="90%" ID="txt_Nombres" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td bgcolor="#c0c0c0" colspan="8">
                </td>
            </tr>
            <tr id="Botones">
                <td colspan="8" style="text-align: center">
                    <asp:Button ID="btn_Grabar" runat="server" Text="Grabar" Width="100px" 
                        OnClick="btn_Grabar_Click" BackColor="#000080" ForeColor="White">
                    </asp:Button>
                    <asp:Button ID="btn_Retornar" runat="server" Text="Regresar" Width="100px" 
                        OnClick="btn_Retornar_Click" BackColor="#000080" ForeColor="White">
                    </asp:Button>
                </td>
            </tr>
        </tbody>
    </table>
    </contenttemplate>
    </asp:UpdatePanel>
    <asp:Panel ID="panelUpdateProgress" runat="server" CssClass="updateProgress">
        <asp:UpdateProgress ID="UpdateProg1" DisplayAfter="0" runat="server">
            <progresstemplate>
            <div style="position: relative; top: 50%; text-align: center;">
                            <asp:Image runat="server" ID="Progres" ImageUrl="~/imagenes/loading.gif" Style="vertical-align: middle"
                    alt="Procesando…" />
                        <asp:Label runat="server" ID="lblprogres" ForeColor="White" Text="Procesando…"></asp:Label>
            </div>
        </progresstemplate>
        </asp:UpdateProgress>
    </asp:Panel>
    <cc1:ModalPopupExtender ID="ModalProgress" runat="server" TargetControlID="panelUpdateProgress"
        BackgroundCssClass="modalBackground" PopupControlID="panelUpdateProgress">
    </cc1:ModalPopupExtender>
</asp:Content>
