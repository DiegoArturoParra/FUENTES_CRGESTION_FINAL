<%@ page title="" language="C#" masterpagefile="~/Master/Ceem.master" autoeventwireup="true" inherits="Mantenimientos_Seguridad_MantOpcion, App_Web_nroguq4s" enableeventvalidation="true" stylesheettheme="Standard" %>
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

        function Menu(tipo) {
            if (tipo == "m") {
                if (Valida_Texto($get('<%= hd_IdOpcionMenu.ClientID %>').value) == false) {
                    alert('Seleccione un Registro para Modificar.');
                    return;
                }
            }
            var str_estado = "?str_estado=" + tipo;
            var str_id = "&id=" + $get('<%= hd_IdOpcionMenu.ClientID %>').value;
            var str_idmodulo = "&idmodulo=" + $get('<%= hd_idmodulo.ClientID %>').value;
            var str_desmodulo = "&desmodulo=" + $get('<%= hd_desmodulo.ClientID %>').value;

            var argsValores = str_estado + str_id + str_idmodulo + str_desmodulo;
            var prmsValores;
            var returnValue;
            prmsValores = "dialogWidth:690px;dialogHeight:340px;center:yes;scrollbars=yes;help=no;status=no;toolbar=no";
            returnValue = window.showModalDialog("MantOpcionDetalle.aspx" + argsValores, "NewWin", prmsValores);

            if (returnValue != null) {
                $get('<%= btn_REFRESCAR.ClientID %>').click();
            }
            if (returnValue == null) {
                document.getElementById("ctl00_DefaultContent_btn_REFRESCAR").click();
            }
        }

        function Opcion(tipo) {
            if (tipo == "m") {
                if (Valida_Texto($get('<%= hd_IdOpcionOpcion.ClientID %>').value) == false) {
                    alert('Seleccione un Registro para Modificar.');
                    return;
                }
            }
            var str_estado = "?str_estado=" + tipo;
            var str_id = "&id=" + $get('<%= hd_IdOpcionOpcion.ClientID %>').value;
            var str_idmenu = "&idmenu=" + $get('<%= hd_IdOpcionMenu.ClientID %>').value;
            var str_idmodulo = "&idmodulo=" + $get('<%= hd_idmodulo.ClientID %>').value;
            var str_desmodulo = "&desmodulo=" + $get('<%= hd_desmodulo.ClientID %>').value;

            var argsValores = str_estado + str_id + str_idmenu + str_idmodulo + str_desmodulo;
            var prmsValores;
            var returnValue;
            prmsValores = "dialogWidth:690px;dialogHeight:340px;center:yes;scrollbars=yes;help=no;status=no;toolbar=no";
            returnValue = window.showModalDialog("MantOpcionDetalleOpcion.aspx" + argsValores, "NewWin", prmsValores);

            if (returnValue != null) {
                $get('<%= btn_REFRESCAR2.ClientID %>').click();
            }
            if (returnValue == null) {
                document.getElementById("ctl00_DefaultContent_btn_REFRESCAR2").click();
            }
        }



        function CargaAccion(cod, des) {

            $get('<%= hd_IdAccion.ClientID %>').value = cod;

            document.getElementById("ctl00_DefaultContent_btn_GrabarAccion").click();

            return;
        }
                       
    </script>
    <table width="100%" cellpadding="0" cellspacing="0" class="BarraControles">
        <tr>
            <td>
                <asp:Button ID="btn_REFRESCAR" runat="server" OnClick="btn_REFRESCAR_Click" Text="Refrescar"
                    Width="1px" Height="1px" CssClass="hidden" />
                <asp:Button ID="btn_REFRESCAR2" runat="server" OnClick="btn_REFRESCAR2_Click" Text="Refrescar"
                    Width="1px" Height="1px" CssClass="hidden" />
                <asp:Button ID="btn_GrabarAccion" runat="server" OnClick="btn_GrabarAccion_Click"
                    Text="Refrescar" Width="1px" Height="1px" CssClass="hidden" />
            </td>
        </tr>
    </table>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table width="100%" cellpadding="0" cellspacing="0" class="BarraControles" border="0">
                <tr>
                    <td style="width: 100%; text-align: center;" colspan="5">
                        <br />
                        <asp:Label ID="lbl_TITULOA" runat="server" CssClass="labeltextonegro" Text="Menu" Width="100%"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                                            &nbsp;</td>
                    <td style="width: 0%;">
                        &nbsp;
                    </td>
                    <td style="width: 10%; text-align: right;">
                        <asp:Label ID="lbl_Modulo0" runat="server" CssClass="labeltextonegro" Text="Modulo :"
                            Width="80%"></asp:Label>
                        &nbsp;
                    </td>
                    <td style="width: 12%; text-align: left;">
                        <asp:DropDownList ID="cmb_MODULO" runat="server" AutoPostBack="True" TabIndex="3" Font-Size="Small"
                            Width="99%" OnSelectedIndexChanged="cmb_MODULO_SelectedIndexChanged">
                            <asp:ListItem Value="False">SELECCIONAR</asp:ListItem>
                        </asp:DropDownList>

                    </td>
                    <td style="width: 82%; text-align: right;">

                        &nbsp;&nbsp;<asp:Button ID="btn_IMPRIMIR" runat="server" OnClick="btn_IMPRIMIR_Click"
                            Text="Imprimir" Width="100px"  BackColor="#000080" ForeColor="White"/>
                                            <asp:Button ID="btn_MenuBajar" runat="server" OnClick="btn_MenuBajar_Click" 
                            OnClientClick="" Text="&#9650; Mover" Width="100px"  BackColor="#000080" ForeColor="White"/>
                        <asp:Button ID="btn_MenuSubir" runat="server" OnClick="btn_MenuSubir_Click" 
                            OnClientClick="" Text="&#9660; Mover" Width="100px"  BackColor="#000080" ForeColor="White"/>
                        <asp:Button ID="btn_NUEVO" runat="server" OnClick="btn_NUEVO_Click" OnClientClick="Menu('n')"
                            Text="Agregar" Width="100px"  BackColor="#000080" ForeColor="White"/>
                        &nbsp;<asp:Button ID="btn_MODIFICAR" runat="server" OnClick="btn_MODIFICAR_Click"
                            OnClientClick="Menu('m')" Text="Modificar" Width="100px"  BackColor="#000080" ForeColor="White"/>
                        &nbsp;<asp:Button ID="btn_ELIMINAR" runat="server" OnClick="btn_ELIMINAR_Click" Text="Eliminar"
                            Width="100px"  BackColor="#000080" ForeColor="White"/>
                        <asp:Button ID="btn_SALIR" runat="server" OnClick="btn_SALIR_Click" Text="Salir"
                            Width="100px"  BackColor="#000080" ForeColor="White"/>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <asp:UpdatePanel ID="up_GV" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:GridView ID="gv" runat="server" Width="100%" EnableTheming="True" OnSorting="gv_Sorting"
                            OnRowDataBound="gv_RowDataBound" OnPageIndexChanging="gv_PageIndexChanging" 
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
                                <asp:BoundField DataField="IdOpcion">
                                    <ItemStyle Width="9%" HorizontalAlign="Left" Height="15px" Font-Bold="False" CssClass="hidden">
                                    </ItemStyle>
                                    <HeaderStyle Width="9%" Height="23px" CssClass="hidden"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="IdModulo">
                                    <ItemStyle CssClass="hidden"></ItemStyle>
                                    <HeaderStyle CssClass="hidden"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Nombre" HeaderText="Menú">
                                    <HeaderStyle Width="20%" Height="23px" />
                                    <ItemStyle Font-Bold="False" HorizontalAlign="Left" VerticalAlign="Middle" Width="20%"
                                        Height="15px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion">
                                    <ItemStyle Width="60%" HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="60%"></HeaderStyle>
                                </asp:BoundField>
                            </Columns>
                            <RowStyle Font-Names="Trebuchet MS" Font-Size="12px" ForeColor="#000066" ></RowStyle>
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
                                                <asp:Label ID="lblSinDatos" runat="server" Text="No se encontraron Datos..."  CssClass="labeltextonegro"></asp:Label>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </EmptyDataTemplate>
                            <SelectedRowStyle  CssClass="selectedrow" BackColor="#669999" Font-Bold="True" ForeColor="White"></SelectedRowStyle>
                            <AlternatingRowStyle />
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
                                    <asp:Label ID="lblCantidad" runat="server" Text="Label" CssClass=""></asp:Label>
                                    <asp:Label ID="lblPaginaGrilla" runat="server" Text="Label" Visible="False"  CssClass=""></asp:Label>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                        <asp:HiddenField ID="hfOrden" runat="server"></asp:HiddenField>
                        <asp:HiddenField ID="hd_IdOpcionMenu" runat="server" />
                        <asp:HiddenField ID="hd_idmodulo" runat="server" />
                        <asp:HiddenField ID="hd_desmodulo" runat="server" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td style="width: 100%">
                <asp:UpdatePanel ID="up_GV2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table width="100%" class="BarraControles">
                            <tr>
                                <td style="width: 35%; text-align: center" colspan="5">
                                    <asp:Label ID="lbl_TITULOB" runat="server" CssClass="labeltextonegro" Text="Opciones"
                                        Width="100%"></asp:Label><br />
                                    <input id="hdnContinuar" name="hdnContinuar" style="width: 80px; height: 10px" type="hidden" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td style="width: 4%;">
                                    &nbsp;
                                </td>
                                <td style="width: 4%;">
                                </td>
                                <td style="width: 10%; text-align: left;">
                                </td>
                                <td style="width: 82%; text-align: right;">
                                    <asp:Button ID="btn_OpcionBajar" runat="server" OnClientClick="" Text="&#9650; Mover"
                                        Width="100px" OnClick="btn_OpcionBajar_Click"  ForeColor="White" BackColor="#000080"/>
                                    <asp:Button ID="btn_OpcionSubir" runat="server" OnClick="btn_OpcionSubir_Click" 
                                        OnClientClick="" Text="&#9660; Mover" Width="100px"  ForeColor="White" BackColor="#000080"/>
                                    <asp:Button ID="btn_NUEVO2" runat="server" OnClick="btn_NUEVO2_Click" 
                                        OnClientClick="Opcion('n')" Text="Agregar" Width="100px"  ForeColor="White" BackColor="#000080"/>
                                    <asp:Button ID="btn_MODIFICAR4" runat="server" OnClick="btn_MODIFICAR2_Click" OnClientClick="Opcion('m')"
                                        Text="Modificar" Width="100px"  ForeColor="White" BackColor="#000080"/>
                                    <asp:Button ID="btn_ELIMINAR2" runat="server" OnClick="btn_ELIMINAR2_Click" Text="Eliminar"
                                        Width="100px"  ForeColor="White" BackColor="#000080"/>
                                </td>
                            </tr>
                        </table>




                        <asp:GridView ID="gv2" runat="server" Width="100%" EnableTheming="True" OnSorting="gv_Sorting"
                            OnRowDataBound="gv_RowDataBound1" OnPageIndexChanging="gv_PageIndexChanging1"
                           AutoGenerateColumns="False" AllowSorting="True"
                            AllowPaging="True" OnSelectedIndexChanged="gv_SelectedIndexChanged1" PageSize="40"
                            DataKeyNames="IdOpcion" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <HeaderStyle BackColor="#2F63CB" Font-Bold="True" ForeColor="White" />
                            <PagerSettings FirstPageText="&amp;lt;&amp;lt;Primero" LastPageText="Ultimo&amp;gt;&amp;gt;" NextPageText="Siguiente&amp;gt;" PreviousPageText="&amp;lt;Anterior" />
                            <RowStyle  Font-Names="Trebuchet MS" Font-Size="12px" ForeColor="#000066"  />
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemStyle Width="1%"></ItemStyle>
                                    <HeaderStyle Width="1%"></HeaderStyle>
                                    <ItemTemplate>
                                   
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="IdOpcion">
                                    <ItemStyle Width="9%" HorizontalAlign="Left" Height="15px" Font-Bold="False" CssClass="hidden">
                                    </ItemStyle>
                                    <HeaderStyle Width="9%" Height="22px" CssClass="hidden"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="IdOpcionPadre">
                                    <ItemStyle CssClass="hidden"></ItemStyle>
                                    <HeaderStyle CssClass="hidden"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="IdModulo">
                                    <ItemStyle Width="15%" HorizontalAlign="Center" VerticalAlign="Middle" Font-Bold="False"
                                        CssClass="hidden"></ItemStyle>
                                    <HeaderStyle Width="15%" CssClass="hidden"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Nombre" HeaderText="Opción">
                                    <HeaderStyle Width="20%" Height="23px" />
                                    <ItemStyle Font-Bold="False" HorizontalAlign="Left" Width="20%" Height="15px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Url" HeaderText="Url">
                                    <HeaderStyle Width="60%" />
                                    <ItemStyle Width="60%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NumOrdenHijo">
                                    <HeaderStyle Width="20%" CssClass="hidden" />
                                    <ItemStyle Width="20%" HorizontalAlign="Right" CssClass="hidden" />
                                </asp:BoundField>
                            </Columns>
                            <PagerStyle CssClass="BarraPie" HorizontalAlign="Left" BackColor="White" ForeColor="#000066" />
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
                                                <asp:Label ID="lblSinDatos" runat="server" Text="EL ITEM SELECCIONADO NO TIENE REGISTROS ASIGNADOS"
                                                    CssClass="labeltextonegro"></asp:Label>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </EmptyDataTemplate>
                            <SelectedRowStyle CssClass="selectedrow" BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                        </asp:GridView>




                        <table cellpadding="0" cellspacing="0" style="width: 100%">
                            <tr>
                                <td  class="pagerstyle" style="height: 30px; text-align: center">
                                    &nbsp; &nbsp;<asp:Label ID="lblCantidad2" runat="server" Text="0" Font-Bold="True" CssClass=""></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <asp:HiddenField ID="hd_IdOpcionOpcion" runat="server" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <table width="100%" border="0">
        <tr>
            <td bgcolor="#c0c0c0">
            </td>
        </tr>
    </table>
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td style="width: 100%">
                <asp:UpdatePanel ID="up_GV3" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table width="100%" class="BarraControles">
                            <tr>
                                <td style="width: 35%; text-align: center" colspan="5">
                                    <asp:Label ID="lblTitulo3" runat="server" CssClass="labeltextonegro" Text="Acciones"
                                        Width="100%"></asp:Label><br />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td style="width: 4%;">
                                    &nbsp;
                                </td>
                                <td style="width: 4%;">
                                </td>
                                <td style="width: 10%; text-align: left;">
                                </td>
                                <td style="width: 82%; text-align: right;">
                                    <asp:Button ID="btn_NUEVO3" runat="server" Text="Agregar" Width="100px" OnClick="btn_NUEVO3_Click"
                                          ForeColor="White" BackColor="#000080"/>
                                    <asp:Button ID="btn_ELIMINAR3" runat="server" OnClick="btn_ELIMINAR3_Click" Text="Eliminar"
                                        Width="100px"  ForeColor="White" BackColor="#000080"/>
                                </td>
                            </tr>
                        </table>
                        <asp:GridView ID="gv3" runat="server" Width="100%" EnableTheming="True" OnSorting="gv3_Sorting"
                            OnRowDataBound="gv3_RowDataBound" OnPageIndexChanging="gv3_PageIndexChanging"
                            AutoGenerateColumns="False" AllowSorting="True"
                            AllowPaging="True" OnSelectedIndexChanged="gv3_SelectedIndexChanged" PageSize="20" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <HeaderStyle BackColor="#2F63CB" Font-Bold="True" ForeColor="White" />
                            <PagerSettings FirstPageText="&amp;lt;&amp;lt;Primero" LastPageText="Ultimo&amp;gt;&amp;gt;" NextPageText="Siguiente&amp;gt;" PreviousPageText="&amp;lt;Anterior" />
                            <RowStyle  Font-Names="Trebuchet MS" Font-Size="12px" ForeColor="#000066" />
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemStyle Width="1%"></ItemStyle>
                                    <HeaderStyle Width="1%"></HeaderStyle>
                                    <ItemTemplate>


                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="idOpcionAccion">
                                    <ItemStyle Width="9%" HorizontalAlign="Left" Height="15px" Font-Bold="False" CssClass="hidden">
                                    </ItemStyle>
                                    <HeaderStyle Width="9%" Height="22px" CssClass="hidden"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="IdOpcion">
                                    <ItemStyle CssClass="hidden"></ItemStyle>
                                    <HeaderStyle CssClass="hidden"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="IdAccion">
                                    <ItemStyle Width="15%" HorizontalAlign="Center" VerticalAlign="Middle" Font-Bold="False"
                                        CssClass="hidden"></ItemStyle>
                                    <HeaderStyle Width="15%" CssClass="hidden"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Nombre" HeaderText="Acción">
                                    <HeaderStyle Width="20%" Height="23px" />
                                    <ItemStyle Font-Bold="False" HorizontalAlign="Left" Width="20%" Height="15px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion">
                                    <HeaderStyle Width="60%" />
                                    <ItemStyle Font-Bold="False" Width="60%" HorizontalAlign="Left" />
                                </asp:BoundField>
                            </Columns>
                            <PagerStyle CssClass="BarraPie" HorizontalAlign="Left" BackColor="White" ForeColor="#000066" />
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
                                                <asp:Label ID="lblSinDatos" runat="server" Text="EL ITEM SELECCIONADO NO TIENE REGISTROS ASIGNADOS"
                                                     CssClass="labeltextonegro"></asp:Label>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </EmptyDataTemplate>
                            <SelectedRowStyle CssClass="selectedrow" BackColor="#669999" Font-Bold="True" ForeColor="White"/>
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                        </asp:GridView>
                        <table cellpadding="0" cellspacing="0" style="width: 100%">
                            <tr>
                                <td  class="pagerstyle" style="height: 30px; text-align: center">
                                    &nbsp; &nbsp;<asp:Label ID="lblCantidad3" runat="server" Text="0" Font-Bold="True" CssClass=""></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <asp:HiddenField ID="hd_IdOpcionAccion" runat="server" />
                        <asp:HiddenField ID="hd_IdAccion" runat="server" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>


