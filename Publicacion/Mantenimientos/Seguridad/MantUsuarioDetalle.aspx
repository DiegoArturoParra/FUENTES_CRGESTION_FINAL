<%@ page title="" language="C#" masterpagefile="~/Master/Ceem.master" autoeventwireup="true" inherits="Mantenimientos_Seguridad_MantUsuarioDetalle, App_Web_nroguq4s" stylesheettheme="Standard" %>

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

        function Valida_Texto(texto) {
            if (texto == '') {
                return false;
            }
            else {
                return true;
            }
        }




        function ValidaEliminacion() {

            if (Valida_Texto($get('<%= hd_IDUSUARIO.ClientID %>').value) == false) {
                return;
            }
            document.getElementById('hdnContinuar').value = confirm('¿Se anulará El registro, ¿Desea continuar?');
        }



    </script>
    <asp:UpdatePanel ID="upBotonera" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table id="tbToolbarSuperior" cellpadding="0" cellspacing="0" class="cabeceraScroll"
                style="width: 100%">
                <tbody>
                    <tr>
                        <td style="width: 20%">
                            <table class="clsToolbar" cellspacing="0" cellpadding="1" width="120px">
                                <tr>
                                    <td valign="middle" width="10" style="text-align: center">
                                        <asp:Image ID="imgGrip" runat="server" ImageUrl="~/Imagenes/toolbar.grip.gif"></asp:Image>
                                    </td>
                                    <td width="0px">
                                        <asp:ImageButton ID="btnAgregar" runat="server" ImageUrl="~/Imagenes/agregar_disabled.png"
                                            OnClick="btnAgregar_Click" />
                                    </td>
                                    <td width="1px">
                                        <asp:ImageButton ID="btnModificar" runat="server" ImageUrl="~/Imagenes/modificar_disabled.png"
                                            OnClick="btnModificar_Click" />
                                    </td>
                                    <td width="23">
                                        <asp:ImageButton ID="btnConsultar" runat="server" ImageUrl="~/Imagenes/consultar_disabled.png"
                                            OnClick="btnConsultar_Click" />
                                    </td>
                                    <td width="1px">
                                        <asp:ImageButton ID="btnEliminar" runat="server" ImageUrl="~/Imagenes/eliminar_disabled.png"
                                            OnClick="btnEliminar_Click" OnClientClick="ValidaEliminacion()" />
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
                        <td class="CeldaCabeceraEtiqueta" style="text-align: right; " valign="top" 
                            colspan="4">
                            <table align="center" border="0" cellpadding="4" cellspacing="1" width="800px">
                                <tbody>
                                    <tr>
                                        <td class="CeldaCabeceraEtiqueta" 
                                            style="width: 23%; text-align: left; height: 7px;" valign="top">
                                            <asp:Label ID="lbl_FECHAREGISTRA16" runat="server" CssClass="labeltextonegro" 
                                                Text="Login:"></asp:Label>
                                        </td>
                                        <td class="CeldaCabeceraControl" style="text-align: left; height: 7px;" 
                                            valign="top">
                                            <asp:TextBox ID="txt_LOGIN" runat="server" MaxLength="15" 
                                                onkeydown="return SiguienteObjeto()" 
                                                Width="100%" AutoCompleteType="Disabled" CssClass="CajaTexto" 
                                                 TabIndex="3"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="labeltextonegro" style="width: 23%; text-align: left;" valign="top">
                                            <asp:Label ID="lbl_FECHAREGISTRA17" runat="server" CssClass="Item" 
                                                Text="Paterno:"></asp:Label>
                                        </td>
                                        <td class="CeldaCabeceraControl" style="text-align: left;" valign="top">
                                            <asp:TextBox ID="txt_paterno" runat="server" 
                                                AutoCompleteType="Disabled" CssClass="CajaTexto" MaxLength="120" 
                                                
                                                onkeydown="return SiguienteObjeto()" TabIndex="4" Width="100%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="labeltextonegro" style="width: 23%; text-align: left;" valign="top">
                                            <asp:Label ID="lbl_FECHAREGISTRA21" runat="server" CssClass="Item" 
                                                Text="Materno:"></asp:Label>
                                        </td>
                                        <td class="CeldaCabeceraControl" style="text-align: left;" valign="top">
                                            <asp:TextBox ID="txt_materno" runat="server" AutoCompleteType="Disabled" 
                                                CssClass="CajaTexto" MaxLength="120" 
                                                
                                                onkeydown="return SiguienteObjeto()" TabIndex="4" Width="100%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="labeltextonegro" style="width: 23%; text-align: left;" valign="top">
                                            <asp:Label ID="lbl_FECHAREGISTRA22" runat="server" CssClass="Item" 
                                                Text="Nombre:"></asp:Label>
                                        </td>
                                        <td class="CeldaCabeceraControl" style="text-align: left;" valign="top">
                                            <asp:TextBox ID="txt_nombre1" runat="server" AutoCompleteType="Disabled" 
                                                CssClass="CajaTexto" MaxLength="120" 
                                                
                                                onkeydown="return SiguienteObjeto()" TabIndex="4" Width="100%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="CeldaCabeceraEtiqueta" style="width: 23%; text-align: left;" 
                                            valign="top">
                                            <asp:Label ID="lbl_FECHAREGISTRA29" runat="server" CssClass="labeltextonegro" 
                                                Text="Empresa:"></asp:Label>
                                        </td>
                                        <td class="CeldaCabeceraControl" style="text-align: left;" valign="top">
                                            <asp:DropDownList ID="cmb_Empresa" runat="server" TabIndex="6" Width="100%">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="CeldaCabeceraEtiqueta" style="width: 23%; text-align: left;" 
                                            valign="top">
                                            <asp:Label ID="lbl_FECHAREGISTRA18" runat="server" CssClass="labeltextonegro" 
                                                Text="Email:"></asp:Label>
                                        </td>
                                        <td class="CeldaCabeceraControl" style="text-align: left;" valign="top">
                                            <asp:TextBox ID="txt_EMAIL" runat="server" AutoCompleteType="Disabled" 
                                                CssClass="CajaTexto" MaxLength="100" onkeydown="return SiguienteObjeto()" 
                                                TabIndex="5" Width="100%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="CeldaCabeceraEtiqueta" style="width: 23%; text-align: left;" 
                                            valign="top">
                                            <asp:Label ID="lbl_FECHAREGISTRA23" runat="server" CssClass="labeltextonegro" 
                                                Text="Documento de Identidad:"></asp:Label>
                                        </td>
                                        <td class="CeldaCabeceraControl" style="text-align: left;" valign="top">
                                            <asp:TextBox ID="txt_dni" runat="server" AutoCompleteType="Disabled" 
                                                CssClass="CajaTexto" MaxLength="100" onkeydown="return SiguienteObjeto()" 
                                                TabIndex="5" Width="100%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="CeldaCabeceraEtiqueta" style="width: 23%; text-align: left;" 
                                            valign="top">
                                            <asp:Label ID="lbl_FECHAREGISTRA28" runat="server" CssClass="labeltextonegro" 
                                                Text="Ejecutores:"></asp:Label>
                                        </td>
                                        <td class="CeldaCabeceraControl" style="text-align: left;" valign="top">
                                            <asp:DropDownList ID="cmb_Ejecutores" runat="server"   AutoPostBack="True" 
                                                onselectedindexchanged="cmb_Ejecutores_SelectedIndexChanged" TabIndex="6" 
                                                Width="100%">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="CeldaCabeceraEtiqueta" style="width: 23%; text-align: left;" 
                                            valign="top">
                                            <asp:Label ID="lbl_FECHAREGISTRA24" runat="server" CssClass="labeltextonegro" 
                                                Text="Jerarquia Nivel A:"></asp:Label>
                                        </td>
                                        <td class="CeldaCabeceraControl" style="text-align: left;" valign="top">
                                            <asp:DropDownList ID="cmb_JerarquiaA" runat="server" AutoPostBack="True" 
                                                onselectedindexchanged="cmb_JerarquiaA_SelectedIndexChanged" TabIndex="6" 
                                                Width="100%">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="CeldaCabeceraEtiqueta" style="width: 23%; text-align: left;" 
                                            valign="top">
                                            <asp:Label ID="lbl_FECHAREGISTRA25" runat="server" CssClass="labeltextonegro" 
                                                Text="Jerarquia Nivel B:"></asp:Label>
                                        </td>
                                        <td class="CeldaCabeceraControl" style="text-align: left;" valign="top">
                                            <asp:DropDownList ID="cmb_JerarquiaB" runat="server" AutoPostBack="True" 
                                                onselectedindexchanged="cmb_JerarquiaB_SelectedIndexChanged" TabIndex="6" 
                                                Width="100%">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="CeldaCabeceraEtiqueta" style="width: 23%; text-align: left;" 
                                            valign="top">
                                            <asp:Label ID="lbl_FECHAREGISTRA26" runat="server" CssClass="labeltextonegro" 
                                                Text="Jerarquia Nivel C:"></asp:Label>
                                        </td>
                                        <td class="CeldaCabeceraControl" style="text-align: left;" valign="top">
                                            <asp:DropDownList ID="cmb_JerarquiaC" runat="server"  AutoPostBack="True" 
                                                onselectedindexchanged="cmb_JerarquiaC_SelectedIndexChanged" TabIndex="6" 
                                                Width="100%">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="CeldaCabeceraEtiqueta" style="width: 23%; text-align: left;" 
                                            valign="top">
                                            <asp:Label ID="lbl_FECHAREGISTRA27" runat="server" CssClass="labeltextonegro" 
                                                Text="Jerarquia Nivel D:"></asp:Label>
                                        </td>
                                        <td class="CeldaCabeceraControl" style="text-align: left;" valign="top">
                                            <asp:DropDownList ID="cmb_JerarquiaD" runat="server" TabIndex="6" Width="100%">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="CeldaCabeceraEtiqueta" style="width: 23%; text-align: left;" 
                                            valign="top">
                                            <asp:Label ID="lbl_FECHAREGISTRA19" runat="server" CssClass="labeltextonegro" 
                                                Text="Estado:"></asp:Label>
                                        </td>
                                        <td class="CeldaCabeceraControl" style="text-align: left;" valign="top">
                                            <asp:DropDownList ID="cmb_SBLOQUEADO" runat="server" TabIndex="6" Width="100%">
                                                <asp:ListItem Value="N">HABILITADO</asp:ListItem>
                                                <asp:ListItem Value="S">BLOQUEADO</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="CeldaCabeceraEtiqueta" style="width: 23%; text-align: left;" 
                                            valign="top">
                                            <asp:Label ID="lbl_PASSWORD1" runat="server" CssClass="labeltextonegro" 
                                                Text="Contraseña:"></asp:Label>
                                        </td>
                                        <td class="CeldaCabeceraControl" style="text-align: left;" valign="top">
                                            <asp:TextBox ID="txt_PASSWORD1" runat="server" AutoCompleteType="Disabled" 
                                                CssClass="CajaTexto" MaxLength="256" onkeydown="return SiguienteObjeto()" 
                                                TabIndex="7" TextMode="Password" Width="100%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="CeldaCabeceraEtiqueta" style="width: 23%; text-align: left;" 
                                            valign="top">
                                            <asp:Label ID="lbl_PASSWORD2" runat="server" CssClass="labeltextonegro" 
                                                Text="Confirmación:"></asp:Label>
                                        </td>
                                        <td class="CeldaCabeceraControl" style="text-align: left;" valign="top">
                                            <asp:TextBox ID="txt_PASSWORD2" runat="server" AutoCompleteType="Disabled" 
                                                CssClass="CajaTexto" MaxLength="256" onkeydown="return SiguienteObjeto()" 
                                                TabIndex="8" TextMode="Password" Width="100%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="CeldaCabeceraEtiqueta" style="width: 23%; text-align: left;" 
                                            valign="top">
                                            <asp:LinkButton ID="lkb_Perfil" runat="server" BorderStyle="Outset" 
                                                BorderWidth="0px" OnClick="lkb_Perfil_Click" ViewStateMode="Enabled" SkinID="linkbutton">&#9658; Asignar Perfiles</asp:LinkButton>
                                        </td>
                                        <td class="CeldaCabeceraControl" style="text-align: left;" valign="top">
                                            &nbsp;</td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="CeldaCabeceraEtiqueta" style="text-align: right; " 
                            valign="top" colspan="4">
                            <asp:HiddenField ID="hd_IDUSUARIO" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="CeldaCabeceraEtiqueta" colspan="4" style="text-align: right; " 
                            valign="top">
                            

<table width="400px" border="0" cellspacing="0" cellpadding="0" align="center">
  <tr>
    <td>
	
                            <asp:Panel ID="pnlExistenciaUsuario" runat="server" Visible="False" Width="18%">
                                <table cellpadding="1" cellspacing="1" >
                                    <tr>
                                        <td >
                                            <asp:Image ID="imgExistenciaUsuario" runat="server" style="width: 25px; height: 24px" ImageUrl="../../Imagenes/ayuda.png" />
                                        </td>
                                        <td style="text-align: left">
                                            <asp:Label ID="lblExistenciaUsuario" runat="server"  CssClass="Etiqueta" ForeColor="Red"
                                                Width="26%"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <asp:HiddenField ID="hd_USUARIOVALIDO" runat="server" />
                            </asp:Panel>
                            <asp:UpdateProgress ID="uprogUsuario" runat="server" AssociatedUpdatePanelID="upControles"
                                DisplayAfter="250">
                                <ProgressTemplate>
                                    <asp:Panel ID="pnlVerificando" runat="server" SkinID="PanelCargando" Width="100px">
                                        <table id="tbGvCargando" cellpadding="1" cellspacing="1">
                                            <tbody>
                                                <tr>
                                                    <td >
                                                        <asp:Label ID="lblVerificando" runat="server" CssClass="Etiqueta" ForeColor="Red" Style="cursor: pointer"
                                                            Text="Verificando..."></asp:Label>
                                                    </td>
                                                    <td style="text-align: justify">
                                                        <asp:Image ID="imgVerificando" runat="server" ImageUrl="../../Imagenes/cargando.gif" style="width: 25px; height: 24px" />
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </asp:Panel>
                                    &nbsp;
                                </ProgressTemplate>
                            </asp:UpdateProgress>

	
	</td>
  </tr>
</table>




                 
                            
                            </td>
                    </tr>
                    <tr>
                        <td class="CeldaCabeceraEtiqueta" style="text-align: right; " valign="top" 
                            colspan="4">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="CeldaCabeceraEtiqueta" style="text-align: right; " 
                            valign="top" colspan="4">
                            <table align="center" border="0" cellpadding="4" cellspacing="1" width="800px">
                                <tbody>
                                    <tr bgcolor="#cccccc">
                                        <td class="CeldaCabeceraEtiqueta" 
                                            style="text-align: left; height: 7px; background-color:#000080" valign="top">
                                            <asp:Panel ID="Panel2" runat="server" CssClass="BarraCollaps" Height="18px" 
                                                Width="100%">
                                                <asp:Label ID="lbl_MP" runat="server" CssClass="labeltextonegro" 
                                                    Font-Bold="True" Font-Size="Small" ForeColor="white" Height="18px" 
                                                    Width="95%" BackColor="#000080">Modificar Password</asp:Label>
                                                <asp:ImageButton ID="Image1" runat="server" AlternateText="(Show Details...)" 
                                                    ImageUrl="~/Imagenes/expand_blue.jpg" OnClick="Image1_Click" />
                                                &nbsp;</asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="CeldaCabeceraEtiqueta" 
                                            style="text-align: left; height: 7px;" valign="top">
                                            <asp:Panel ID="Panel1" runat="server" CssClass="collapsePanel" Height="0" 
                                                Width="100%">
                                                <table width="100%">
                                                    <tr>
                                                        <td colspan="2" style="text-align: left; height: 22px;">
                                                            <asp:HiddenField ID="hd_MODIFICAPASS" runat="server" Value="N" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 18%; text-align: left; height: 22px;">
                                                            <asp:Label ID="lbl_PASSWORD3" runat="server" CssClass="labeltextonegro" 
                                                                Text="Contraseña:"></asp:Label>
                                                        </td>
                                                        <td style="width: 60%; height: 22px;">
                                                            <asp:TextBox ID="txt_MODIFICAPASS1" runat="server" AutoCompleteType="Disabled" 
                                                                CssClass="CajaTexto" MaxLength="20" onkeydown="return SiguienteObjeto()" 
                                                                TabIndex="9" TextMode="Password" Width="80%"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 18%; height: 22px; text-align: left">
                                                            <asp:Label ID="lbl_PASSWORD4" runat="server" CssClass="labeltextonegro" 
                                                                Text="Confirmación:"></asp:Label>
                                                            &nbsp;</td>
                                                        <td style="width: 60%; height: 22px">
                                                            <asp:TextBox ID="txt_MODIFICAPASS2" runat="server" AutoCompleteType="Disabled" 
                                                                CssClass="CajaTexto" MaxLength="20" onkeydown="return SiguienteObjeto()" 
                                                                TabIndex="10" TextMode="Password" Width="80%"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="text-align: center">
                                                            &nbsp;<asp:Button ID="btn_MODIFICARPASS" runat="server" 
                                                                OnClick="btn_MODIFICARPASS_Click" Text="Grabar" Width="70px" BackColor="#000080" ForeColor="White"/>
                                                            <asp:Button ID="btn_CANCELAMODIFICARPASS" runat="server" 
                                                                OnClick="btn_CANCELAMODIFICARPASS_Click" Text="Cancelar" Width="70px"  BackColor="#000080" ForeColor="White"/>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="CeldaCabeceraEtiqueta" style="text-align: right; width: 166px;" valign="top">
                        </td>
                        <td valign="top">
                            <cc1:CollapsiblePanelExtender ID="cpeDemo" runat="Server" CollapseControlID="Image1"
                                ExpandControlID="Image1" Collapsed="true" CollapsedImage="~/Imagenes/expand_blue.jpg"
                                CollapsedText="Modificar Password" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                ExpandedText="Ocultar detalles" ImageControlID="Image1" SuppressPostBack="false"
                                TargetControlID="Panel1" TextLabelID="lbl_MP" Enabled="True">
                            </cc1:CollapsiblePanelExtender>
                            <asp:Label ID="lbl_ESTADOREGISTRA" runat="server" CssClass="Item" 
                                Text="Estado_creacion"></asp:Label>
                            <asp:Label ID="lbl_ESTADOMODIFICA" runat="server" CssClass="Item" 
                                Text="estado_modificacion"></asp:Label>
                            <asp:Label ID="lbl_ESTADOANULA" runat="server" CssClass="Item" 
                                Text="estado_anulacion"></asp:Label>
                        </td>
                        <td style="width: 10%" valign="top">
                        </td>
                        <td class="CeldaCabeceraEtiqueta" style="width: 20%">
                            &nbsp;
                        </td>
                    </tr>
                </tbody>
            </table>






            <table width="100%" border="0">
                <tbody>
                    <tr>
                        <td class="CeldaCabeceraEtiqueta">
                            <table align="center" border="0" cellpadding="0" cellspacing="2" class="" 
                                width="800px">
                                <tbody>
                                    <tr bgcolor="#000080">
                                        <td class="" colspan="3" style="text-align: center;" valign="top">
                                            <asp:Label ID="lbl_FECHAREGISTRA20" runat="server" CssClass="labeltextoblanco" 
                                                Text="Auditoría de Cambios"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr bgcolor="#cccccc">
                                        <td class="" style="width: 8%; text-align: left; " valign="">
                                            &nbsp;<asp:Label ID="lbl_FECHAREGISTRA3" runat="server" CssClass="labeltextonegro" 
                                                Text="Usuario"></asp:Label>
                                        </td>
                                        <td class="" style="width: 18%; text-align: left;" valign="">
                                            &nbsp;<asp:Label ID="lbl_FECHAREGISTRA8" runat="server" CssClass="labeltextonegro" 
                                                Text="Estado"></asp:Label>
                                        </td>
                                        <td class="" style="width: 9%; text-align: left;" valign="">
                                            &nbsp;<asp:Label ID="lbl_FECHAREGISTRA4" runat="server" CssClass="labeltextonegro" 
                                                Text="Fecha"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr bgcolor="#ffffff">
                                        <td class="" style="width: 8%; text-align: left;" valign="">
                                            &nbsp;<asp:Label ID="lbl_FECHAREGISTRA6" runat="server" CssClass="labeltextonegro" 
                                                Text="Modificación"></asp:Label>
                                        </td>
                                        <td class="" style="width: 18%; text-align: left;" valign="">
                                            &nbsp;<asp:Label ID="lbl_CODUSUARIOMODIFICA" runat="server" 
                                                CssClass="labeltextonegro" Text="usuario_modificación"></asp:Label>
                                        </td>
                                        <td class="" style="width: 9%; text-align: left;" valign="">
                                            &nbsp;<asp:Label ID="lbl_FECHAMODIFICA" runat="server" CssClass="labeltextonegro" 
                                                Text="fecha_modificacion"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr bgcolor="#ffffff">
                                        <td class="" style="width: 8%; text-align: left;" valign="">
                                            &nbsp;<asp:Label ID="lbl_FECHAREGISTRA5" runat="server" CssClass="labeltextonegro" 
                                                Text="Creación"></asp:Label>
                                        </td>
                                        <td class="" style="width: 18%; text-align: left;" valign="">
                                            &nbsp;<asp:Label ID="lbl_CODUSUARIOREGISTRA" runat="server" 
                                                CssClass="labeltextonegro" Text="usuario creacion"></asp:Label>
                                        </td>
                                        <td class="" style="width: 9%; text-align: left;" valign="">
                                            &nbsp;<asp:Label ID="lbl_FECHAREGISTRA" runat="server" CssClass="labeltextonegro" 
                                                Text="fecha creacion"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr bgcolor="#ffffff">
                                        <td class="" style="width: 8%; text-align: left;" valign="">
                                            &nbsp;<asp:Label ID="lbl_FECHAREGISTRA7" runat="server" CssClass="labeltextonegro" 
                                                Text="Anulación"></asp:Label>
                                        </td>
                                        <td class="" style="width: 18%; text-align: left;" valign="">
                                            &nbsp;<asp:Label ID="lbl_CODUSUARIOANULA" runat="server" CssClass="labeltextonegro" 
                                                Text="usuario anulacion"></asp:Label>
                                        </td>
                                        <td class="" style="width: 9%; text-align: left;" valign="">
                                            &nbsp;<asp:Label ID="lbl_FECHAANULA" runat="server" CssClass="labeltextonegro" 
                                                Text="fecha anulacion"></asp:Label>
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
