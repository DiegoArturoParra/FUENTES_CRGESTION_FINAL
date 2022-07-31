<%@ Page Title="" Language="C#" MasterPageFile="~/Master/GCCeem.master" AutoEventWireup="true"     CodeFile="GS_Reasignacion_Cartera_Interna.aspx.cs" Inherits="Estudio_Gestion_GS_Reasignacion_Cartera_Interna" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="GMDatePicker" Namespace="GrayMatterSoft" TagPrefix="cc2" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="cc3" %>
<%@ MasterType VirtualPath="~/Master/GCCeem.master" %>
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
            
            
            <div class="form-group col-md-1">
            </div>
            <div class="form-group col-md-7">
                <div class="rounded" style="min-height: 190px;">
                    <div class="form-row col-md-4">
                        <label for="inputEmail4">Documento de identidad:</label>
                    </div>
                    <div class="form-row col-md-8">
                        <asp:TextBox ID="txt_documento" runat="server" Width="100%" MaxLength="20"></asp:TextBox>
                    </div>
                    <div class="form-row col-md-4">
                        <label for="inputEmail4">Nombres:</label>
                    </div>
                    <div class="form-row col-md-8">
                        <asp:TextBox ID="txt_nombres" runat="server" Width="100%" MaxLength="50"></asp:TextBox>
                    </div>
                    <div class="form-row col-md-4">
                        <label for="inputEmail4">Dias de mora:</label>
                    </div>
                    <div class="form-row col-md-8">
                        Desde: 
                        <asp:TextBox ID="txt_dias_mora" runat="server" Width="37%"></asp:TextBox>
                        <%--<asp:RegularExpressionValidator ID="rexNombre" runat="server" ControlToValidate="txt_dias_mora"
                            Display="Dynamic" ErrorMessage="Debe ingresar por lo menos 3 caracteres." ValidationExpression=".{3,}">*</asp:RegularExpressionValidator>--%>
                        Hasta: 
                        <asp:TextBox ID="txt_dias_mora_hasta" runat="server" Width="37%"></asp:TextBox>
                    </div>
                    <div class="form-row col-md-4">
                        <label for="inputEmail4">Tipo de Gestión:</label>
                    </div>
                    <div class="form-row col-md-8">
                        <asp:TextBox ID="txt_TipoGestion" runat="server" Width="100%" MaxLength="50"></asp:TextBox>
                    </div>
                    <div class="form-row col-md-4">
                        <label for="inputEmail4">Registro del Action Plan:</label>
                    </div>
                    <div class="form-group col-md-8">
                        Del
                        <asp:TextBox ID="txt_FECHAINI" runat="server" Enabled="false" Height="18px" MaxLength="10"
                            TabIndex="5" Width="38%"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="imgCal1"
                            TargetControlID="txt_FECHAINI" />
                        <asp:ImageButton ID="imgCal1" runat="Server" AlternateText="Mostrar calendario" ImageUrl="~/imagenes/Calendar.png" />
                        &nbsp;al
                        <asp:TextBox ID="txt_FECHAFIN" runat="server" Enabled="false" Height="18px" MaxLength="10"
                            TabIndex="5" Width="38%"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="imgCal2"
                            TargetControlID="txt_FECHAFIN" />
                        <asp:ImageButton ID="imgCal2" runat="Server" AlternateText="Mostrar calendario" ImageUrl="~/imagenes/Calendar.png" />
                    </div><br />
                    <div class="form-row col-md-4">
                        <label for="inputEmail4">Agente:</label>
                    </div>
                    <div class="form-row col-md-8">
                        <asp:DropDownList ID="cmb_Agente" runat="server" TabIndex="6" Width="100%">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="form-group col-md-2">
                <div class="rounded" style="min-height: 190px;">
                    <div class="form-row col-md-12">

                        <table style="margin:auto; text-align:center; height:190px; width:100%">
                            <tr>
                                <td>
                                    <asp:Button ID="btnBuscar" runat="server" class="btn btn-primary" OnClick="btnBuscar_Click" Text="Buscar" Width="100%" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="btnReasignar" runat="server" class="btn btn-primary" OnClick="btnReasignar_Click" Text="Reasignar" Width="100%" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="btnModificar" runat="server" class="btn btn-primary" OnClick="btnModificar_Click" Text="Evaluar" Width="100%" Visible="False" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="btnConsultar" runat="server" class="btn btn-primary" OnClick="btnConsultar_Click" Text="Consultar" Width="100%" Visible="False" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="btnNuevo" runat="server" class="btn btn-primary" OnClick="btnNuevo_Click" Text="Nuevo Action Plan" Width="100%" Visible="False" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="btnDesactivar" runat="server" class="btn btn-primary" OnClick="btnDesactivar_Click" Text="Desactivar" Width="100%" Visible="False" />
                                </td>
                            </tr>
                        </table>

                    </div>
                </div>
            </div>
            <div class="form-group col-md-2">
            </div>
            <table id="Grid" border="0" width="100%">
                <tr>
                    <td align="center" style="width: 100%;">
                        <asp:GridView ID="gv" runat="server" Width="100%" EnableTheming="True" AutoGenerateColumns="False"
                            AllowSorting="True" AllowPaging="True" Style="text-align: center" ViewStateMode="Enabled"
                            BackColor="White" OnPageIndexChanging="gv_PageIndexChanging" 
                            OnPageIndexChanged="gv_PageIndexChanged" PageSize="40" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                            <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="White" ForeColor="#000066" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#2F63CB" Font-Bold="True" ForeColor="White" />
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemStyle Width="1%"></ItemStyle>
                                    <HeaderStyle Width="1%" CssClass=""></HeaderStyle>
                                    <ItemTemplate>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="IdReg_Gestion_Cobranza" HeaderText="IdReg_G_Cob." SortExpression="">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False" CssClass="hidden">
                                    </ItemStyle>
                                    <HeaderStyle Width="10%" CssClass="hidden" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Asesores" HeaderText="Asesores" SortExpression="">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="FechaRegistra" HeaderText="Fec. Registra" SortExpression="">
                                    <ItemStyle Width="8%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="8%" CssClass="" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Descripcion_TipoGestion" HeaderText="Desc_TipoGestion"
                                    SortExpression="">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="RazonSocial" HeaderText="RazonSocial/Nombres" SortExpression="">
                                    <ItemStyle Width="15%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="15%" CssClass="" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Producto" HeaderText="Producto" SortExpression="">
                                    <ItemStyle Width="8%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="8%" CssClass="" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="SubProducto" HeaderText="SubProducto" SortExpression="">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="dias_mora" HeaderText="Dias mora" SortExpression="">
                                    <ItemStyle Width="3%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="3%" CssClass="" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Descripcion_ClaseGestion" HeaderText="Resultado" SortExpression="">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="FechaResultado" HeaderText="Ejecutado" SortExpression="">
                                    <ItemStyle Width="8%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="8%" CssClass="" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="CodEjecutado" HeaderText="CodEjecutado" SortExpression="">
                                    <ItemStyle Width="0%" HorizontalAlign="Left" Height="15px" Font-Bold="False" CssClass="hidden">
                                    </ItemStyle>
                                    <HeaderStyle Width="0%" CssClass="hidden" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Descripcion_Ejecutado" HeaderText="Clasificación" SortExpression="">
                                    <ItemStyle Width="8%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="8%" CssClass="" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="desc_ejecutores" HeaderText="Ejecutores" SortExpression="">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False" CssClass="hidden">
                                    </ItemStyle>
                                    <HeaderStyle Width="10%" Height="22px" CssClass="hidden"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Obs" HeaderText="Obs" SortExpression="">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="id_estado_gestion_cobranza">
                                    <ItemStyle CssClass="hidden"></ItemStyle>
                                    <HeaderStyle CssClass="hidden"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="" HeaderText="Estado" SortExpression="">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"  CssClass="hidden"></ItemStyle>
                                    <HeaderStyle Width="10%" CssClass="hidden" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="CodCLaseGestion">
                                    <ItemStyle CssClass="hidden"></ItemStyle>
                                    <HeaderStyle CssClass="hidden"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="" HeaderText="Ver Ficha" SortExpression="">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"  CssClass="hidden" ></ItemStyle>
                                    <HeaderStyle Width="10%" CssClass="hidden" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="CodigoCliente">
                                    <ItemStyle CssClass="hidden"></ItemStyle>
                                    <HeaderStyle CssClass="hidden"></HeaderStyle>
                                </asp:BoundField>

                                <asp:TemplateField HeaderText="Select">
                                <HeaderTemplate>
                                <asp:CheckBox ID="chkAll" onclick="javascript:SelectAllCheckboxes(this);" Checked="true" runat="server"
                                Height="15px"></asp:CheckBox>
                                </HeaderTemplate>
                                <ItemTemplate>
                                <asp:CheckBox ID="chkPermiso" Checked="true" runat="server" />
                                </ItemTemplate>
                                </asp:TemplateField>


                                <asp:BoundField DataField="CodTipoGestion" HeaderText="CodTipoGestion" SortExpression="">
                                    <ItemStyle CssClass="hidden" Width="10%"></ItemStyle>
                                    <HeaderStyle Width="10%" CssClass="hidden" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="" HeaderText="Evaluar" SortExpression="">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"  CssClass="hidden"></ItemStyle>
                                    <HeaderStyle Width="10%" CssClass="hidden" Height="22px"></HeaderStyle>
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



