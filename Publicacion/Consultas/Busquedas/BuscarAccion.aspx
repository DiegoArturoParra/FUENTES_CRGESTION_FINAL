<%@ page title="" language="C#" masterpagefile="~/Master/Popup.master" autoeventwireup="true" inherits="Consultas_Busquedas_BuscarAccion, App_Web_fhace2t1" stylesheettheme="Standard" %>
<%@ Register Assembly="GMDatePicker" Namespace="GrayMatterSoft" TagPrefix="cc2" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="cc3" %>
<%@ MasterType VirtualPath="~/Master/Popup.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="DefaultContent" runat="Server">
    <script language="javascript">
        function Enter_Buscar(evt) {
            if (event.keyCode == 13) {
                document.getElementById("ctl00_DefaultContent_btnBuscar").click();
                return false;
            }
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
                                                <td style="width: 20%; height: 17px">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 5%; text-align: right" valign="middle">
                                                </td>
                                                <td style="width: 5%; text-align: left" valign="middle">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 25%">
                                                    <asp:Label ID="lblPaginado" runat="server">Paginado</asp:Label>&nbsp;<asp:DropDownList
                                                        ID="ddlPaginado" runat="server" AutoPostBack="True" Font-Size="Small"
                                                        OnSelectedIndexChanged="ddlPaginado_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 20%; text-align: left">
                                                    <asp:Label ID="lblPaginaIr" runat="server">Ir a </asp:Label>&nbsp;<asp:DropDownList ID="ddlPaginaIr"
                                                        runat="server" AutoPostBack="True" Font-Size="Small" OnSelectedIndexChanged="ddlPaginaIr_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 15%" align="right">
                                                    <asp:Button ID="btn_SELECCIONAR" runat="server" Height="25px" 
                                                        OnClick="btn_SELECCIONAR_Click" Text="Seleccionar" Width="80px" />
                                                </td>
                                                <td style="width: 5%">
                                                    <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" TabIndex="1"
                                                        Text="Buscar" Width="65px" />
                                                </td>
                                                <td style="width: 5%">
                                                    <asp:Button ID="btnLimpiar" runat="server" CausesValidation="False" OnClick="btnLimpiar_Click"
                                                        Text="Limpiar" Width="65px" />
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <table class="cabeceraScroll" style="width: 100%">
                                        <tr>
                                            <td style="height: 32px">
                                                <table align="center" border="0" cellpadding="0" cellspacing="0" 
                                                    class="cabeceraScroll" width="800px">
                                                    <tr>
                                                        <td align="left" style="width: 331px">
                                                            Buscar por Nombre:</td>
                                                        <td align="left" width="">
                                                            <asp:TextBox ID="txt_NOMBRE" runat="server" 
                                                                onkeydown="return Enter_Buscar(event)" Width="90%"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="rexCodigo" runat="server" 
                                                                ControlToValidate="txt_NOMBRE" Display="Dynamic" 
                                                                ErrorMessage="Debe ingresar por lo menos 3 caracteres." 
                                                                ValidationExpression=".{3,}">*</asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 331px">
                                                            Buscar por Descripción:</td>
                                                        <td align="left" width="">
                                                            <asp:TextBox ID="txt_DESCRIPCION" runat="server" 
                                                                onkeydown="return Enter_Buscar(event)" style="margin-bottom: 0px" Width="90%"></asp:TextBox>
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
                                        AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True">
                                        <PagerSettings PreviousPageText="&amp;lt;Anterior" Mode="NextPreviousFirstLast" LastPageText="Ultimo&amp;gt;&amp;gt;"
                                            FirstPageText="&amp;lt;&amp;lt;Primero" NextPageText="Siguiente&amp;gt;"></PagerSettings>
                                        <Columns>
                                            <asp:TemplateField ShowHeader="False">
                                                <ItemStyle Width="1%"></ItemStyle>
                                                <HeaderStyle Width="1%" CssClass=""></HeaderStyle>
                                                <ItemTemplate>

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="IdAccion" HeaderText="Codigo" SortExpression="IdAccion">
                                                <ItemStyle Width="19%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                                <HeaderStyle Width="19%" CssClass="" Height="22px"></HeaderStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="IdAccion">
                                                <ItemStyle CssClass="hidden"></ItemStyle>
                                                <HeaderStyle CssClass="hidden"></HeaderStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre">
                                                <ItemStyle Width="40%" HorizontalAlign="Left" VerticalAlign="Middle" Font-Bold="False">
                                                </ItemStyle>
                                                <HeaderStyle Width="40%" CssClass=""></HeaderStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion">
                                                <ItemStyle Width="40%" HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                                <HeaderStyle Width="40%" CssClass=""></HeaderStyle>
                                            </asp:BoundField>
                                        </Columns>
                                        <RowStyle Font-Size="8pt" ></RowStyle>
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
                                        <SelectedRowStyle CssClass="selectedrow"></SelectedRowStyle>
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
                            &nbsp;
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



