<%@ page title="" language="C#" masterpagefile="~/Master/Ceem.master" autoeventwireup="true" inherits="Mantenimientos_Seguridad_MantPerfil, App_Web_nroguq4s" stylesheettheme="Standard" %>

<%@ Register Assembly="GMDatePicker" Namespace="GrayMatterSoft" TagPrefix="cc2" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="cc3" %>
<%@ MasterType VirtualPath="~/Master/Ceem.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="DefaultContent" runat="Server">
    <script language="javascript">
        function Enter_Buscar(evt) {
            if (event.keyCode == 13) {
                document.getElementById("ctl00_DefaultContent_btnBuscar").click();
                return false;
            }
        }

        function Valida_Todos() {
            if ($get('<%= chk_TODOS.ClientID %>').checked == true) {
                document.getElementById('hdnContinuar').value = confirm(' La operación puede demorar dependiendo de la cantidad de Registros, ¿Desea continuar?');
            }
        }

    </script>
    <table id="tbContenedor" width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td style="width: 100%">
                <table id="tbContenedorDatos" cellpadding="0" cellspacing="0" style="width: 100%">
                    <tr class="">
                        <td align="center" style="width: 100%">
                            <asp:UpdatePanel ID="upBotonera" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <table cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tr>
                                            <td class="altoverow" style="text-align: center">
                                                <asp:ValidationSummary ID="vsError" runat="server" HeaderText="No puede realizar esta Operación:"
                                                    ShowMessageBox="True" ShowSummary="False" />
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
    <td style="height: 28px; width: 348px;">
        <table cellpadding="1" cellspacing="0" class="clsToolbar" width="120px">
            <tr>
                <td style="text-align: center" valign="middle" width="10">
                    <asp:Image ID="imgGrip" runat="server" ImageUrl="~/Imagenes/toolbar.grip.gif" />
                </td>
                <td width="23">
                    <asp:ImageButton ID="btnAgregar" runat="server" 
                        ImageUrl="~/Imagenes/agregar_disabled.png" onclick="btnAgregar_Click" />
                </td>
                <td width="23">
                    <asp:ImageButton ID="btnModificar" runat="server" 
                        ImageUrl="~/Imagenes/modificar_disabled.png" onclick="btnModificar_Click" />
                </td>
                <td width="23">
                    <asp:ImageButton ID="btnConsultar" runat="server" 
                        ImageUrl="~/Imagenes/consultar_disabled.png" onclick="btnConsultar_Click" />
                </td>
                <td width="23">
                    <asp:ImageButton ID="btnEliminar" runat="server" 
                        ImageUrl="~/Imagenes/eliminar_disabled.png" onclick="btnEliminar_Click" />
                </td>
                <td width="23">
                    <asp:ImageButton ID="btnExcel" runat="server" 
                        ImageUrl="~/Imagenes/excel_disabled.png" onclick="btnExcel_Click" 
                        onclientclick="Valida_Todos()" />
                </td>
                <td width="23">
                    <asp:ImageButton ID="btnImprimir" runat="server" 
                        ImageUrl="~/Imagenes/imprimir_disabled.png" onclick="btnImprimir_Click" 
                        onclientclick="Valida_Todos()" />
                </td>
                <td width="23">
                    <asp:ImageButton ID="btnSalir" runat="server" 
                        ImageUrl="~/imagenes/salir_disabled.png" onclick="btnSalir_Click" Visible=false />
                </td>
                <td style="text-align: center" valign="middle" width="10">
                    <asp:Image ID="imgSeparator" runat="server" 
                        ImageUrl="~/Imagenes/toolbar.grip.gif" />
                </td>
            </tr>
        </table>
      </td>
    <td style="height: 28px; width: 382px;">
        <asp:CheckBox ID="chk_TODOS" runat="server" 
            ToolTip="Imprime o Exporta Todos los registros (puede demorar varios minutos)" />
        Mostrar / Exportar Todos</td>
    <td style="width: 249px; height: 28px">
        <asp:Label ID="lblPaginado" runat="server">Paginado</asp:Label>&nbsp;&nbsp;
        <asp:DropDownList ID="ddlPaginado" runat="server" AutoPostBack="True" 
            Font-Size="Small" OnSelectedIndexChanged="ddlPaginado_SelectedIndexChanged">
        </asp:DropDownList>
      </td>
    <td style="height: 28px; width: 298px;">
        <asp:Label ID="lblPaginaIr" runat="server">Ir a </asp:Label>&nbsp;&nbsp;
        <asp:DropDownList ID="ddlPaginaIr" runat="server" AutoPostBack="True" 
            Font-Size="Small" Height="16px" 
            OnSelectedIndexChanged="ddlPaginaIr_SelectedIndexChanged">
        </asp:DropDownList>
      </td>
    <td style="height: 28px;">
        <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" 
            onclientclick="Valida_Todos()" TabIndex="1" Text="Buscar" Width="65px" />
        <asp:Button ID="btnLimpiar" runat="server" CausesValidation="False" 
            OnClick="btnLimpiar_Click" Text="Limpiar" Width="65px" />
      </td>
  </tr>
</table>
                                                   
                                                   
                                                   </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <table class="cabeceraScroll" style="width: 100%">
                                        <tr>
                                            <td style="height: 32px">
                                                <table border="0" cellpadding="0" cellspacing="0" class="cabeceraScroll"   align=center
                                                    width="800px">
                                                    <tr>
                                                        <td align="left" style="width: 331px">
                                                            Seleccionar Modulo:</td>
                                                        <td align="left" width="">
                                                            <asp:DropDownList ID="cmb_MODULO" runat="server" AutoPostBack="True"  Font-Size="Small"  
                                                                OnSelectedIndexChanged="cmb_MODULO_SelectedIndexChanged" TabIndex="3" 
                                                                Width="400px">
                                                                <asp:ListItem Value="False">MODULOS</asp:ListItem>
                                                                <asp:ListItem Value="True">BLOQUEADO</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 331px">
                                                            Buscar por Perfil:</td>
                                                        <td align="left" width="">
                                                            <asp:TextBox ID="txt_NOMBRE" runat="server" 
                                                                onkeydown="return Enter_Buscar(event)" style="margin-bottom: 0px" Width="400px"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="rexCodigo" runat="server" 
                                                                ControlToValidate="txt_NOMBRE" Display="Dynamic" 
                                                                ErrorMessage="Debe ingresar por lo menos 3 caracteres." 
                                                                ValidationExpression=".{3,}">*</asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 331px">
                                                            Buscar por Descripción de Perfil:</td>
                                                        <td align="left" width="">
                                                            <asp:TextBox ID="txt_DESCRIPCION" runat="server" 
                                                                onkeydown="return Enter_Buscar(event)" Width="400px"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="rexNombre" runat="server" 
                                                                ControlToValidate="txt_DESCRIPCION" Display="Dynamic" 
                                                                ErrorMessage="Debe ingresar por lo menos 3 caracteres." 
                                                                ValidationExpression=".{3,}">*</asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>













                                    <asp:GridView ID="gv" runat="server" Width="100%" EnableTheming="True" OnSorting="gv_Sorting"
                                        OnRowDataBound="gv_RowDataBound" OnPageIndexChanging="gv_PageIndexChanging" 
                                        AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                                        <FooterStyle BackColor="White" ForeColor="#000066" />
                                        <HeaderStyle BackColor="#2F63CB" Font-Bold="True" ForeColor="White" />
                                        <PagerSettings PreviousPageText="&amp;lt;Anterior" LastPageText="Ultimo&amp;gt;&amp;gt;"
                                            FirstPageText="&amp;lt;&amp;lt;Primero" NextPageText="Siguiente&amp;gt;"></PagerSettings>
                                        <Columns>

                                            <asp:TemplateField ShowHeader="False">
                                                <ItemStyle Width="1%"></ItemStyle>
                                                <HeaderStyle Width="1%" CssClass=""></HeaderStyle>
                                                <ItemTemplate>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:BoundField DataField="IdPerfil">
                                                <ItemStyle CssClass="hidden"></ItemStyle>
                                                <HeaderStyle CssClass="hidden"></HeaderStyle>
                                            </asp:BoundField>

                                            <asp:BoundField DataField="IdModulo">
                                                <HeaderStyle CssClass="hidden" />
                                                <ItemStyle CssClass="hidden" />
                                            </asp:BoundField>

                                            <asp:BoundField DataField="DesModulo" HeaderText="Modulo" SortExpression="DesModulo">
                                                <ItemStyle Width="19%" HorizontalAlign="Left" VerticalAlign="Middle" Font-Bold="False">
                                                </ItemStyle>
                                                <HeaderStyle Width="19%" CssClass=""></HeaderStyle>
                                            </asp:BoundField>


                                            <asp:BoundField DataField="Nombre" HeaderText="Perfil" SortExpression="Nombre">
                                                <ItemStyle Width="40%" HorizontalAlign="Left" VerticalAlign="Middle" Font-Bold="False">
                                                </ItemStyle>
                                                <HeaderStyle Width="40%" CssClass=""></HeaderStyle>
                                            </asp:BoundField>

                                            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion Perfil" SortExpression="Descripcion">
                                                <ItemStyle Width="40%" HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                                <HeaderStyle Width="40%" CssClass=""></HeaderStyle>
                                            </asp:BoundField>


                                        </Columns>
                                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                        <RowStyle ForeColor="#000066"></RowStyle>
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
                                        <SelectedRowStyle CssClass="selectedrow" BackColor="#669999" Font-Bold="True" ForeColor="White"></SelectedRowStyle>
                                        <AlternatingRowStyle />
                                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                                    </asp:GridView>














                                    <table cellpadding="0" cellspacing="0" style="width: 100%; text-align: center;">
                                        <tr>
                                            <td class="pagerstyle" style="height: 30px; text-align: center">
                                                <asp:Label ID="lblCantidad" runat="server"></asp:Label>&nbsp;
                                                <asp:Label ID="lblPaginaGrilla" runat="server"></asp:Label>&nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:HiddenField ID="hfOrden" runat="server"></asp:HiddenField>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnBuscar" EventName="Click" />
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
