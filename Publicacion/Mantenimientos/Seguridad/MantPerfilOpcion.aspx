<%@ page title="" language="C#" masterpagefile="~/Master/Ceem.master" autoeventwireup="true" inherits="Mantenimientos_Seguridad_MantPerfilOpcion, App_Web_nroguq4s" stylesheettheme="Standard" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="RJS.Web.WebControl.PopCalendar" Namespace="RJS.Web.WebControl" TagPrefix="rjs" %>
<%@ MasterType VirtualPath="~/Master/Ceem.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="DefaultContent" runat="Server">
    <script language="javascript">

        //****************************************************************************************
        //* Nomre       :SiguienteObjeto() 
        //* DescripcioN :				ARONI ESLAVA JHONNY AGOSTO - 2009
        //****************************************************************************************
        function SiguienteObjeto() {
            if (event.keyCode == 13) event.keyCode = 9;
        }

        function Control_Decimal(ctrl, evt) {
            if (event.keyCode == 13) event.keyCode = 9;
            var charCode = evt.keyCode
            var FIND = "."
            var x = ctrl.value
            var y = x.indexOf(FIND)

            if ((charCode > 45 && charCode < 58) || (charCode > 95 && charCode < 106) || (charCode > 32 && charCode < 41) || (charCode == 8) || (charCode == 9) || (charCode == 17) || (charCode == 27) || (charCode == 110) || (charCode == 190)) {
                if ((charCode == 110) || (charCode == 190)) {
                    if (y < 0) {
                        if (x.length > 0)
                            return true
                        else
                            return false
                    }
                    else
                        return false
                }
                else
                    return true;
            }
            else
                return false;
        }


        function Control_Numero(evt) {
            if (event.keyCode == 13) event.keyCode = 9;
            var charCode = evt.keyCode

            if ((charCode > 45 && charCode < 58) || (charCode > 95 && charCode < 106) || (charCode > 32 && charCode < 41) || (charCode == 8) || (charCode == 9) || (charCode == 17) || (charCode == 27))
                return true
            else
                return false
        }

        function Control_Locked(evt) {
            return false
        }

        function Control_Caracter(evt) {
            if (event.keyCode == 13) event.keyCode = 9;
            var charCode = evt.keyCode

            if (charCode == 219)
                return false
            else
                return true
        }


        function TreeViewPostBack() {
            var o = window.event.srcElement;
            if (o.tagName == "INPUT" && o.type == "checkbox") {
                document.getElementById("ctl00_DefaultContent_btnActualizarOpciones").click();
            }
        }
		

    </script>
    <asp:UpdatePanel ID="upBotonera" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table id="tbToolbarSuperior" cellpadding="0" cellspacing="0" class="cabeceraScroll"
                style="width: 100%">
                <tbody>
                    <tr>
                        <td style="width: 20%">
                            <table class="clsToolbar" cellspacing="0" cellpadding="1" width="60px">
                                <tr>
                                    <td valign="middle" width="10" style="text-align: center">
                                        <asp:Image ID="imgGrip" runat="server" ImageUrl="~/Imagenes/toolbar.grip.gif">
                                        </asp:Image>
                                    </td>
                                    <td width="1px">
                                        <asp:ImageButton ID="btnGrabar" runat="server" ImageUrl="~/Imagenes/grabar_disabled.png"
                                            OnClick="btnGrabar_Click" />
                                    </td>
                                    <td width="1px">
                                        <asp:ImageButton ID="btnSalir" runat="server" ImageUrl="~/Imagenes/salir_disabled.png"
                                            OnClick="btnSalir_Click" />
                                    </td>
                                    <td valign="middle" width="10" style="text-align: center">
                                        <asp:Image ID="imgSeparator" runat="server" ImageUrl="~/Imagenes/toolbar.grip.gif">
                                        </asp:Image>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 5%; text-align: right" valign="middle">
                        </td>
                        <td style="width: 5%; text-align: left" valign="middle">
                            &nbsp;
                        </td>
                        <td style="width: 25%">
                            &nbsp;
                        </td>
                        <td style="width: 20%; text-align: left">
                        </td>
                        <td style="width: 15%">
                        </td>
                        <td style="width: 5%">
                            &nbsp;
                        </td>
                        <td style="width: 5%">
                            &nbsp;
                        </td>
                    </tr>
                </tbody>
            </table>
            <table width="100%" class="">
                <tr>
                    <td style="width: 10%">
                    </td>
                    <td style="width: 80%; text-align: center;">
                        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                            <ProgressTemplate>
                                <strong><span style="color: #993366; background-color: lightyellow; font-size: 10pt;
                                    font-family: Tahoma;">Procesando tu solicitud..<br />
                                    <img id="img2" src="../../Imagenes/cargando.gif" style="width: 25px; height: 24px" />
                                    <br />
                                </span></strong>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:Label ID="lblMensaje" runat="server" CssClass="Etiqueta" ForeColor="Red"></asp:Label>
                        <input style="width: 80px; height: 10px" id="hdnContinuar" type="hidden" name="hdnContinuar" />
                    </td>
                    <td style="width: 10%">
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnGrabar" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnSalir" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="upControles" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table width="100%" border="0" class="CeldaCabeceraEtiqueta">
                <tbody>
                    <tr>
                        <td class="altoverow" style="height: 18px">
                            <table align="center" border="0" cellpadding="4" cellspacing="1" width="800px">
                                <tbody>
                                    <tr>
                                        <td class="CeldaCabeceraEtiqueta" 
                                            style="width: 23%; text-align: left; height: 7px;" valign="top">
                                            <asp:Label ID="lbl_FECHAREGISTRA16" runat="server" CssClass="labeltextonegro" 
                                                Text="Código:"></asp:Label>
                                        </td>
                                        <td class="CeldaCabeceraControl" style="text-align: left; height: 7px;" 
                                            valign="top">
                                            <asp:TextBox ID="txt_IDPERFIL" runat="server" CssClass="CajaTextoDisable" 
                                                ForeColor="Black" MaxLength="10" onkeydown="return Control_Locked(event);" 
                                                Width="99%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="labeltextonegro" style="width: 23%; text-align: left;" valign="top">
                                            <asp:Label ID="lbl_FECHAREGISTRA19" runat="server" CssClass="labeltextonegro" 
                                                Text="Modulo:"></asp:Label>
                                        </td>
                                        <td class="CeldaCabeceraControl" style="text-align: left;" valign="top">
                                            <asp:TextBox ID="txt_DESMODULO" runat="server" CssClass="CajaTextoDisable" 
                                                ForeColor="Black" MaxLength="10" onkeydown="return Control_Locked(event);" 
                                                Width="99%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="labeltextonegro" style="width: 23%; text-align: left;" valign="top">
                                            <asp:Label ID="lbl_FECHAREGISTRA17" runat="server" CssClass="Item" 
                                                Text="Nombre:"></asp:Label>
                                        </td>
                                        <td class="CeldaCabeceraControl" style="text-align: left;" valign="top">
                                            <asp:TextBox ID="txt_NOMBRE" runat="server" CssClass="CajaTexto" 
                                                ForeColor="Black" MaxLength="50" onkeydown="return Control_Locked(event);" 
                                                TabIndex="1" Width="99%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="CeldaCabeceraEtiqueta" style="text-align: left; width: 23%;" 
                                            valign="top">
                                        </td>
                                        <td class="CeldaCabeceraControl" style="text-align: left;" 
                                            valign="top">
                                            <asp:Label ID="lbl_FECHAREGISTRA18" runat="server" CssClass="labeltextonegro" 
                                                Text="Estructura:"></asp:Label>
                                            <asp:TreeView ID="tvOpciones" runat="server" 
                                                BorderStyle="Solid" BorderWidth="0px" ImageSet="News" 
                                                OnTreeNodeCheckChanged="tvOpciones_TreeNodeCheckChanged" ShowCheckBoxes="All" 
                                                ShowLines="True" SkipLinkText="" Width="100%" 
                                                LineImagesFolder="~/TreeLineImages">
                                                <ParentNodeStyle CssClass="labeltextoblanco" />
                                                <HoverNodeStyle Font-Underline="True" />
                                                <RootNodeStyle Font-Bold="True" CssClass="labeltextoblanco"  ForeColor="#000000" />
                                                <LeafNodeStyle Font-Bold="False" CssClass="labeltextoblanco" ForeColor="#333333" />
                                                <NodeStyle Font-Bold="True" CssClass="labeltextoblanco"   ForeColor="#666666" />
                                            </asp:TreeView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="CeldaCabeceraEtiqueta" style="width: 23%; text-align: left;" 
                                            valign="top">
                                            <asp:LinkButton ID="lbtnDeshacerCambios" runat="server" Enabled="False" SkinID="linkbutton"  
                                                OnClick="lbtnDeshacerCambios_Click" Visible="False">&#9658; Deshacer Cambios</asp:LinkButton>
                                        </td>
                                        <td class="CeldaCabeceraControl" style="text-align: left;" valign="top">
                                            <asp:HiddenField ID="hd_IDMODULO" runat="server" />
                                            <asp:Button ID="btnActualizarOpciones" runat="server" CssClass="hidden" 
                                                OnClick="btnActualizarOpciones_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="CeldaCabeceraEtiqueta" colspan="2" style="text-align: center;" 
                                            valign="top">
                                            <asp:Label ID="lblSinDatosOpcion" runat="server" CssClass="Etiqueta" 
                                                Text="No se encontraron Opciones para este Módulo"></asp:Label>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    
</asp:Content>


