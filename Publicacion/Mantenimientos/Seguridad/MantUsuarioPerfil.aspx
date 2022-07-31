<%@ page title="" language="C#" masterpagefile="~/Master/Ceem.master" autoeventwireup="true" inherits="Mantenimientos_Seguridad_MantUsuarioPerfil, App_Web_nroguq4s" stylesheettheme="Standard" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/Master/Ceem.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="DefaultContent" runat="Server">

    <script type="text/javascript">
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

        function FocoOn(control) {
            control.className = 'CajaTextoFoco';
        }

        function FocoOff(control) {
            control.className = 'CajaTexto';
        }

        //****************************************************************************************
        //* Nomre       :SiguienteObjeto() 
        //* DescripcioN :				NSE AGOSTO - 2009
        //****************************************************************************************
        function SiguienteObjeto() {
            if (event.keyCode == 13) event.keyCode = 9;
        }

        function Control_Locked(evt) {
            return false
        }

        function CargaPerfil(cod, des) {
            $get('<%= hd_idperfil.ClientID %>').value = cod;
            document.getElementById("ctl00_DefaultContent_btn_GrabarUsuarioPerfil").click();

            return;
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
                                                            <td  width="1px" >
                                                                <asp:ImageButton ID="btnAgregar" runat="server" 
                                                                    ImageUrl="~/Imagenes/agregar_disabled.png" 
                                                                    onclick="btnAgregar_Click" />                                                                
                                                            </td>

                                                            <td width="1px" >
                                                                <asp:ImageButton ID="btnEliminar" runat="server" 
                                                                    ImageUrl="~/Imagenes/eliminar_disabled.png" 
                                                                    onclick="btnEliminar_Click"  />                                                                
                                                            </td>

                                                            <td width="1px" >
                                                                <asp:ImageButton ID="btnSalir" runat="server" 
                                                                    ImageUrl="~/Imagenes/salir_disabled.png" 
                                                                    onclick="btnSalir_Click" />                                                                
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
                                                    &nbsp;</td>
                                                <td style="width: 20%; text-align: left">
                                                </td>
                                                <td style="width: 15%">
                                                </td>
                                                <td style="width: 5%">
                                                    &nbsp;</td>
                                                <td style="width: 5%">
                                                    &nbsp;</td>
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
                    </td>
                    <td style="width: 10%">
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btn_GrabarUsuarioPerfil" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnSalir" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
        
    <table width="100%" cellpadding="0" cellspacing="0" class="BarraControles">
    <tr>
    <td>
                            <asp:Button ID="btn_REFRESCAR" runat="server" OnClick="btn_REFRESCAR_Click" 
                            Text="Refrescar" Width="1px" Height="1px" CssClass="hidden" />

                            <asp:Button ID="btn_GrabarUsuarioPerfil" runat="server" OnClick="btn_GrabarUsuarioPerfil_Click" 
                            Text="Refrescar" Width="1px" Height="1px" CssClass="hidden" />

                            <input id="hdnContinuar" name="hdnContinuar" style="width: 80px; height: 10px" type="hidden" />
    </td>
    </tr>
    </table>
                
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <asp:UpdatePanel ID="up_GV" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>



                        <asp:GridView ID="gv" runat="server" Width="100%" EnableTheming="True" OnSorting="gv_Sorting"
                            OnRowDataBound="gv_RowDataBound" 
                            OnPageIndexChanging="gv_PageIndexChanging"
                            AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True" OnSelectedIndexChanged="gv_SelectedIndexChanged"
                            PageSize="20" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <HeaderStyle BackColor="#2F63CB" Font-Bold="True" ForeColor="White" />
                            <PagerSettings PreviousPageText="&amp;lt;Anterior" LastPageText="Ultimo&amp;gt;&amp;gt;"
                                FirstPageText="&amp;lt;&amp;lt;Primero" NextPageText="Siguiente&amp;gt;"></PagerSettings>
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemStyle Width="1%"></ItemStyle>
                                    <HeaderStyle Width="1%"></HeaderStyle>
                                    <ItemTemplate>

                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="IdUsuarioPerfil">
                                    <ItemStyle Width="9%" HorizontalAlign="Left" Height="15px" 
                                    Font-Bold="False" CssClass="hidden"></ItemStyle>
                                    <HeaderStyle Width="9%" Height="23px" CssClass="hidden"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="IdPerfil">
                                    <ItemStyle CssClass="hidden"></ItemStyle>
                                    <HeaderStyle CssClass="hidden"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="DesModulo" HeaderText="Modulo">
                                    <HeaderStyle Width="20%" Height="23px" />
                                    <ItemStyle Font-Bold="False" HorizontalAlign="Left" VerticalAlign="Middle" 
                                    Width="20%" Height="15px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DesPerfil" HeaderText="Perfil">
                                    <ItemStyle Width="60%" HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="60%"></HeaderStyle>
                                </asp:BoundField>
                                
                            </Columns>
                            <RowStyle Font-Names="Trebuchet MS" Font-Size="11px" ForeColor="#000066" ></RowStyle>
                            <EmptyDataTemplate>
                                <table id="tbSinDatos">
                                    <tbody>
                                        <tr>
                                            <td style="width: 10%">
                                                            <img src="../../Imagenes/imgWarning.png" style="width:25px; height:24px" />
                                            </td>
                                            <td style="width: 5%">
                                            </td>
                                            <td style="width: 85%">
                                                <asp:Label ID="lblSinDatos" runat="server" Text="No se encontraron Datos..." CssClass="labeltextonegro"></asp:Label>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </EmptyDataTemplate>
                            <SelectedRowStyle Font-Bold="True" CssClass="selectedrow" BackColor="#669999" ForeColor="White"></SelectedRowStyle>
                            <PagerStyle CssClass="BarraPie" HorizontalAlign="Left" BackColor="White" ForeColor="#000066" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                        </asp:GridView>



                        <table cellpadding="0" cellspacing="0" style="width: 100%">
                            <tr>
                                <td  class="pagerstyle" style="height: 30px; text-align: center">
                                    &nbsp;
                                    <asp:Label ID="lblCantidad" runat="server" Text="Label" CssClass="" ></asp:Label>
                                    <asp:Label ID="lblPaginaGrilla" runat="server" Text="Label" Visible="False"  CssClass="" ></asp:Label>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                        <asp:HiddenField ID="hfOrden" runat="server"></asp:HiddenField>
                        <asp:HiddenField ID="hd_idusuario" runat="server" />
                        <asp:HiddenField ID="hd_idperfil" runat="server" />
                        <asp:HiddenField ID="hd_IdOpcionMenu" runat="server" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>        
    </asp:Content>


