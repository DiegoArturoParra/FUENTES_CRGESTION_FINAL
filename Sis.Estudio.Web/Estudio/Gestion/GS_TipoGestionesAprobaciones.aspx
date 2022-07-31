<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Ceem.master" AutoEventWireup="true"     CodeFile="GS_TipoGestionesAprobaciones.aspx.cs" Inherits="Estudio_Gestion_GS_TipoGestionesAprobaciones" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="GMDatePicker" Namespace="GrayMatterSoft" TagPrefix="cc2" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="cc3" %>
<%@ MasterType VirtualPath="~/Master/Ceem.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="DefaultContent" runat="Server">
    <script type="text/javascript">
        function Enter_Buscar(evt) {
        }

        function Valida_Todos() {

        }


        function SelectAllCheckboxes(spanChk) {
            var oItem = spanChk.children;
            var theBox = (spanChk.type == "checkbox") ? spanChk : spanChk.children.item[0];
            xState = theBox.checked;

            elm = theBox.form.elements;
            for (i = 0; i < elm.length; i++)
                if (elm[i].type == "checkbox" && elm[i].id != theBox.id) {
                    if (elm[i].checked != xState)
                        elm[i].click();
                }
            }


        function SelectAllCheckboxes2(spanChk) {
            var oItem = spanChk.children;
            var theBox = (spanChk.type == "checkbox") ? spanChk : spanChk.children.item[0];
            xState = theBox.checked;

            elm = theBox.form.elements;
            for (i = 0; i < elm.length; i++)
                if (elm[i].type == "checkbox" && elm[i].id != theBox.id) {
                    if (elm[i].checked != xState)
                        elm[i].click();
                }
            }



    </script>
    <asp:UpdatePanel ID="upGvUsuario" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table id="Mensaje" cellpadding="0" cellspacing="0" width="100%" class="cabeceraScroll">
                <tr>
                    <td class="altoverow" style="text-align: center">
                        <asp:ValidationSummary ID="vsError" runat="server" HeaderText="No puede realizar esta Operación:"
                            ShowMessageBox="True" ShowSummary="False" CssClass="Etiqueta" />
                        <asp:Label ID="lblMensaje" runat="server" CssClass="Etiqueta" ForeColor="Red"></asp:Label><input
                            id="hdnContinuar" name="hdnContinuar" style="width: 80px; height: 10px" type="hidden" />
                    </td>
                </tr>
            </table>
            <table id="Botones" border="0" cellpadding="0" cellspacing="0" class="cabeceraScroll"
                width="100%">
                <tr>
                    <td align="left" style="width: 100%;" rowspan="2">
                        <asp:Button ID="btnBuscar" runat="server" BackColor="#000080" BorderStyle="Ridge"
                            CausesValidation="False" Font-Names="Trebuchet MS" Font-Size="9pt" ForeColor="White"
                            Height="25px" OnClick="btnBuscar_Click" Text="Buscar" Width="90px" 
                            Visible="False" />
                        <asp:Button ID="btnDesactivar" runat="server" BackColor="#000080" BorderStyle="Ridge"
                            Font-Names="Trebuchet MS" Font-Size="9pt" ForeColor="White" Height="25px" OnClick="btnDesactivar_Click"
                            Text="Grabar" Width="90px" />
                    </td>
                </tr>
            </table>
            <table id="ControlesSuperior" border="0" cellpadding="0" cellspacing="0" class="cabeceraScroll" width="100%">
                <tr>
                    <td align="center" style="width: 100%;">
                        <table id="Controles" align="center" border="0" cellpadding="0" cellspacing="0" class="cabeceraScroll"
                            width="800px">
                            <tr>
                                <td align="left" style="width: 331px">
                                    Jerarquía Nivel A:</td>
                                <td align="left" width="">
                                    <asp:DropDownList ID="cmb_JerarquiaA" runat="server" TabIndex="6" Width="100%" 
                                        AutoPostBack="True" 
                                        onselectedindexchanged="cmb_JerarquiaA_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 331px">
                                    Jerarquía Nivel B:</td>
                                <td align="left" width="">
                                    <asp:DropDownList ID="cmb_JerarquiaB" runat="server" AutoPostBack="True" 
                                        onselectedindexchanged="cmb_JerarquiaB_SelectedIndexChanged" TabIndex="6" 
                                        Width="100%">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 331px">
                                    Jerarquía Nivel C:</td>
                                <td align="left" width="">
                                    <asp:DropDownList ID="cmb_JerarquiaC" runat="server" AutoPostBack="True" TabIndex="6" Width="100%" 
                                        onselectedindexchanged="cmb_JerarquiaC_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table id="Grid" border="0" width="100%">
                <tr>
                    <td align="center" style="width: 100%;">
                        <asp:GridView ID="gv" runat="server" Width="100%" EnableTheming="True" AutoGenerateColumns="False"
                            AllowSorting="True" AllowPaging="True" Style="text-align: center" ViewStateMode="Enabled"
                            BackColor="White" OnPageIndexChanging="gv_PageIndexChanging" 
                            OnPageIndexChanged="gv_PageIndexChanged" PageSize="50" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                            <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="White" ForeColor="#000066" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#2F63CB" Font-Bold="True" ForeColor="White" />
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemStyle Width="1%"></ItemStyle>
                                    <HeaderStyle Width="1%" CssClass=""></HeaderStyle>
                                    <ItemTemplate>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:BoundField DataField="CodTipoGestionAprob" HeaderText="CodTipoGestionAprob" SortExpression="">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                           <asp:BoundField DataField="Cod_Jerarquia" HeaderText="Cod_Jerarquia" SortExpression="">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                           <asp:BoundField DataField="CodTipoGestion" HeaderText="CodTipoGestion" SortExpression="">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="nEmpresa" HeaderText="nEmpresa" SortExpression="">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Nivel" HeaderText="Nivel" SortExpression="">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion"
                                    SortExpression="">
                                    <ItemStyle Width="50%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="70%" CssClass="" Height="22px"></HeaderStyle>
                                </asp:BoundField>

                                <asp:TemplateField HeaderText="Select">
                                <HeaderTemplate>
                                <asp:CheckBox ID="chkAll" onclick="javascript:SelectAllCheckboxes(this);" runat="server"
                                Height="15px"></asp:CheckBox>Permiso
                                </HeaderTemplate>
                                <ItemTemplate>
                                <asp:CheckBox ID="chkPermiso" runat="server" />
                                </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Select2">
                                <HeaderTemplate>
                                <asp:CheckBox ID="chkAll2" onclick="javascript:SelectAllCheckboxes2(this);" runat="server"
                                Height="15px"></asp:CheckBox>Correo
                                </HeaderTemplate>
                                <ItemTemplate>
                                <asp:CheckBox ID="chkPermiso2" runat="server" />
                                </ItemTemplate>
                                </asp:TemplateField>

                      <asp:BoundField DataField="Aprobacion" HeaderText="Aprobacion"
                                    SortExpression="">
                                    <ItemStyle Width="50%" HorizontalAlign="Left" Height="15px" Font-Bold="False"  CssClass="hidden"></ItemStyle>
                                    <HeaderStyle Width="70%" Height="22px"  CssClass="hidden"></HeaderStyle>
                                </asp:BoundField>

                      <asp:BoundField DataField="Correo" HeaderText="Correo"
                                    SortExpression="">
                                    <ItemStyle Width="50%" HorizontalAlign="Left" Height="15px" Font-Bold="False"  CssClass="hidden"></ItemStyle>
                                    <HeaderStyle Width="70%" Height="22px"  CssClass="hidden"></HeaderStyle>
                                </asp:BoundField>


                            </Columns>
                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                            <RowStyle ForeColor="#000066"></RowStyle>
                            <EmptyDataTemplate>
                                <table id="tbSinDatos">
                                    <tbody>
                                        <tr>
                                            <td style="width: 10%">
                                                <img src="../../Imagenes/imgWarning.png" style="width: 25px; height: 24px" />
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
                            <SelectedRowStyle CssClass="selectedrow" BackColor="#669999" Font-Bold="True" ForeColor="White"></SelectedRowStyle>
                            <AlternatingRowStyle />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            <table id="Contador" cellpadding="0" cellspacing="0" style="width: 100%; text-align: center;">
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
    <asp:UpdateProgress ID="uprogGvUsuario" runat="server" AssociatedUpdatePanelID="upGvUsuario"
        DisplayAfter="250">
        <ProgressTemplate>
            <asp:Panel ID="pnlGvCargando" runat="server" SkinID="PanelCargando" Width="100px">
                <table id="tbGvCargando" cellpadding="1" cellspacing="1" style="width: 100%">
                    <tr>
                        <td style="width: 50%; text-align: center">
                            <asp:Label ID="lblGvCargando" runat="server" Style="cursor: pointer" Text="Cargando..."
                                CssClass="modalPopup"></asp:Label>
                        </td>
                        <td style="width: 50%; text-align: justify">
                            <asp:Image runat="server" ID="Progres" ImageUrl="~/imagenes/loading.gif" Style="vertical-align: middle"
                                alt="Procesando&#8230;" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
