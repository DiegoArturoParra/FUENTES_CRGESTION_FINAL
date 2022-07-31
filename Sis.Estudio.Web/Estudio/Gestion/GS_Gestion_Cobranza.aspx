<%@ Page Title="" Language="C#" MasterPageFile="~/Master/GCCeem.master" AutoEventWireup="true"
    CodeFile="GS_Gestion_Cobranza.aspx.cs" Inherits="Estudio_Gestion_GS_Gestion_Cobranza" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="GMDatePicker" Namespace="GrayMatterSoft" TagPrefix="cc2" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="cc3" %>
<%@ MasterType VirtualPath="~/Master/GCCeem.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="DefaultContent" runat="Server">
    <script type="text/javascript">


        function SelectAllCheckboxes(spanChk) {
            var oItem = spanChk.children;
            var theBox = (spanChk.type == "checkbox") ? spanChk : spanChk.children.item[0];
            xState = theBox.checked;

            elm = theBox.form.elements;
            for (i = 0; i < elm.length; i++) {
                if (elm[i].type == "checkbox" && elm[i].id != theBox.id) {
                    if (elm[i].checked != xState) {
                        elm[i].click();
                    }
                }
            }
        }
        function Enter_Buscar(evt) {
        }

        function Valida_Todos() {

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

            <div class="form-group col-md-6">
                <div class="rounded" style="min-height: 90px;">
                    <div class="form-row col-md-5">
                        <label for="inputEmail4">Estado Action Plan:</label>
                    </div>
                    <div class="form-row col-md-7">
                        <asp:DropDownList ID="cmb_Estado" runat="server" TabIndex="6" Width="100%" 
                            onselectedindexchanged="cmb_Estado_SelectedIndexChanged" 
                            AutoPostBack="True">
                        </asp:DropDownList>
                    </div>
                    <div class="form-row col-md-5">
                        <label for="inputEmail4">Action Plan:</label>
                    </div>
                    <div class="form-row col-md-7">
                        <asp:DropDownList ID="cmb_CodTipoGestion" runat="server" TabIndex="6" 
                            Width="100%" onselectedindexchanged="cmb_CodTipoGestion_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
                    </div>
                    <div class="form-row col-md-5">
                        <label for="inputEmail4">Creación de Action Plan:</label>
                    </div>
                    <div class="form-row col-md-7">
                        Del
                        <asp:TextBox ID="txt_FECHAINI" runat="server" Enabled="false" Height="18px" MaxLength="10"
                            TabIndex="5" Width="30%" OnTextChanged="txt_FECHAINI_TextChanged" AutoPostBack="true"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="imgCal1"
                            TargetControlID="txt_FECHAINI" />
                        <asp:ImageButton ID="imgCal1" runat="Server" AlternateText="Mostrar calendario" ImageUrl="~/imagenes/Calendar.png" />
                        &nbsp;al
                        <asp:TextBox ID="txt_FECHAFIN" runat="server" Enabled="false" Height="18px" MaxLength="10"
                            TabIndex="5" Width="30%" OnTextChanged="txt_FECHAFIN_TextChanged" AutoPostBack="true"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="imgCal2"
                            TargetControlID="txt_FECHAFIN" />
                        <asp:ImageButton ID="imgCal2" runat="Server" AlternateText="Mostrar calendario" ImageUrl="~/imagenes/Calendar.png" OnClick="imgCal2_Click" />
                    </div>
                </div>
            </div>
            <div class="form-group col-md-4">
                <div class="rounded" style="min-height: 90px;">
                    <div class="form-row col-md-5">
                        <label for="inputEmail4">Nro documento:</label>
                    </div>
                    <div class="form-row col-md-7">
                        <asp:TextBox ID="txt_documento" runat="server" Width="100%" MaxLength="20" OnTextChanged="txt_documento_TextChanged"
                        placeholder="Ingrese el DNI"></asp:TextBox>
                    </div>
                    <div class="form-row col-md-5">
                        <label for="inputEmail4">Cliente:</label>
                    </div>
                    <div class="form-row col-md-7">
                        <asp:TextBox ID="txt_nombres" runat="server" Width="100%" MaxLength="50" OnTextChanged="txt_nombres_TextChanged"
                        placeholder="Ingrese Nombre o Apellido"></asp:TextBox>
                    </div>
                    <div class="form-row col-md-5">
                        <label for="inputEmail4">Dias mora</label>
                    </div>
                    <div class="form-row col-md-7">
                        <asp:TextBox ID="txt_dias_mora" runat="server" Width="48%" placeholder="Desde"></asp:TextBox>
                        <asp:TextBox ID="txt_dias_mora_hasta" runat="server" Width="49%" placeholder="Hasta"></asp:TextBox>
<%--                        <asp:RegularExpressionValidator ID="rexNombre" runat="server" ControlToValidate="txt_dias_mora"
                            Display="Dynamic" ErrorMessage="Debe ingresar números" ValidationExpression=".{,}">*</asp:RegularExpressionValidator>--%>
                    </div>
                </div>
            </div>
            <div class="form-group col-md-2">
                <div class="rounded" style="min-height: 90px;">
                    <table style="margin:auto; text-align:center; height:70px;">
                        <tr>
                            <td>
                                <asp:Button ID="btnBuscar" runat="server" class="btn btn-primary" Width="100%" OnClick="btnBuscar_Click" Text="Buscar" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnNuevo" runat="server" class="btn btn-primary" Width="100%" OnClick="btnNuevo_Click" Text="Action Plan Inbound"/>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>

            <table id="Grid" border="0" width="100%">
                <tr>
                    <td align="center" style="width: 100%;padding: 0px 15px;">
                        <asp:GridView ID="gv" runat="server" Width="100%" EnableTheming="True" AutoGenerateColumns="False"
                            AllowSorting="True" AllowPaging="True" Style="text-align: center" ViewStateMode="Enabled"
                            BackColor="#999999" OnPageIndexChanging="gv_PageIndexChanging" 
                            OnPageIndexChanged="gv_PageIndexChanged" 
                            onselectedindexchanged="gv_SelectedIndexChanged" BorderColor="#CCCCCC" PageSize="15">
                            <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="White" 
                                ForeColor="#000066" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" 
                                BackColor="#2F63CB" />
                            <Columns>
                                <%--1--%>
                                <%--<asp:TemplateField ShowHeader="False">
                                    <ItemStyle Width="1%"></ItemStyle>
                                    <HeaderStyle Width="1%" CssClass=""></HeaderStyle>
                                    <ItemTemplate>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:BoundField DataField="dFechaRegistra" HeaderText="Fecha de Generación AP" SortExpression="">
                                    <ItemStyle Width="8%" HorizontalAlign="Left" Height="15px" Font-Bold="False" CssClass=""></ItemStyle>
                                    <HeaderStyle Width="8%" CssClass="" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <%-- 2 --%>
                                <asp:BoundField DataField="nIdGestionCobranza" HeaderText="IdReg_G_Cob." SortExpression="">
                                    <ItemStyle Width="0%" HorizontalAlign="Left" Height="15px" Font-Bold="False" CssClass="hidden">
                                    </ItemStyle>
                                    <HeaderStyle Width="0%" CssClass="hidden" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <%-- 3 --%>
                                <asp:BoundField DataField="cAsesor" HeaderText="Asesor" SortExpression="">
                                    <ItemStyle Width="0%" HorizontalAlign="Left" Height="15px" Font-Bold="False" CssClass="hidden"></ItemStyle>
                                    <ControlStyle Font-Names="Trebuchet MS" />
                                    <HeaderStyle Width="0%" CssClass="hidden" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <%-- 4 --%>
                                <%--<asp:BoundField DataField="FechaRegistra" HeaderText="Fecha de Creación" SortExpression="">
                                    <ItemStyle Width="11%" HorizontalAlign="Left" Height="15px" Font-Bold="False" CssClass=""></ItemStyle>
                                    <HeaderStyle Width="11%" CssClass="" Height="22px"></HeaderStyle>
                                </asp:BoundField>--%>
                                <asp:BoundField DataField="cEjecutor" HeaderText="Gestionado Por" SortExpression="">
                                    <ItemStyle Width="7%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="7%" CssClass="" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <%-- 5 --%>
                                <asp:BoundField DataField="cTipoGestion" HeaderText="Tipo Action Plan"
                                    SortExpression="">
                                    <ItemStyle Width="11%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="11%" CssClass="" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <%-- 6 --%>
                                <asp:BoundField DataField="cRazonSocial" HeaderText="Cliente / Aval" SortExpression="">
                                    <ItemStyle Width="15%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="15%" CssClass="" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <%-- 7 --%>
                                <asp:BoundField DataField="cProducto" HeaderText="Producto" SortExpression="">
                                    <ItemStyle Width="5%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="5%" CssClass="" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <%--<asp:BoundField DataField="SubProducto" HeaderText="SubProducto" SortExpression="">
                                    <ItemStyle Width="8%" HorizontalAlign="Left" Height="15px" Font-Bold="False" CssClass="hidden"></ItemStyle>
                                    <HeaderStyle Width="8%" CssClass="hidden" Height="22px"></HeaderStyle>
                                </asp:BoundField>--%>
                                <%-- 8 --%>
                                <asp:BoundField DataField="nTramo" HeaderText="Tramo" SortExpression="">
                                    <ItemStyle Width="3%" HorizontalAlign="center" Height="15px" Font-Bold="False" CssClass=""></ItemStyle>
                                    <HeaderStyle Width="3%" CssClass="" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <%-- 9 --%>
                                <asp:BoundField DataField="nDiasMora" HeaderText="D&iacute;as de mora" SortExpression="">
                                    <ItemStyle Width="4%" HorizontalAlign="center" Height="15px" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="4%" CssClass="" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <%-- 10 --%>
                                <asp:BoundField DataField="cEjecutado" HeaderText="Clasificación de AP" SortExpression="">
                                    <ItemStyle Width="9%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="9%" CssClass="" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <%-- 11 --%>
                                <asp:BoundField DataField="cClaseGestion" HeaderText="Resultado Clasificación" SortExpression="">
                                    <ItemStyle Width="9%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="9%" CssClass="" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <%-- 12 --%>
                                <asp:BoundField HeaderText="Comentarios" SortExpression="" DataField="cDetalleContactabilidad">
                                    <ItemStyle Width="9%" HorizontalAlign="center" Height="15px" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="9%" CssClass="" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <%-- 13 --%>
                                <asp:BoundField DataField="nIdEjecutor" HeaderText="CodEjecutado" SortExpression="">
                                    <ItemStyle Width="0%" HorizontalAlign="Left" Height="15px" Font-Bold="False" CssClass="hidden">
                                    </ItemStyle>
                                    <HeaderStyle Width="0%" CssClass="hidden" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <%-- 14 --%>
                                <asp:BoundField DataField="dFechaModifica" HeaderText="Ejecutado" SortExpression="">
                                    <ItemStyle Width="8%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="8%" CssClass="" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <%-- 15 --%>
                                <asp:BoundField DataField="cEjecutor" HeaderText="Ejecutores" SortExpression="">
                                    <ItemStyle Width="0%" HorizontalAlign="Left" Height="15px" Font-Bold="False" CssClass="hidden">
                                    </ItemStyle>
                                    <HeaderStyle Width="0%" Height="22px" CssClass="hidden"></HeaderStyle>
                                </asp:BoundField>
                                <%-- 16 --%>
                                <asp:BoundField DataField="cCampaña" HeaderText="Campaña" SortExpression="">
                                    <ItemStyle Width="0%" HorizontalAlign="Left" Height="15px" Font-Bold="False" CssClass="hidden"></ItemStyle>
                                    <HeaderStyle Width="0%" CssClass="hidden" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <%-- 17 --%>
                                <asp:BoundField DataField="nIdGestionCobranza">
                                    <ItemStyle CssClass="hidden"></ItemStyle>
                                    <HeaderStyle CssClass="hidden"></HeaderStyle>
                                </asp:BoundField>
                                <%-- 18 --%>
                                <asp:BoundField DataField="nIdEstadoGestion" HeaderText="Estado" SortExpression="">
                                    <ItemStyle Width="3%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="3%" CssClass="" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <%-- 19 --%>
                                <asp:BoundField DataField="nIdClaseGestion">
                                    <ItemStyle CssClass="hidden"></ItemStyle>
                                    <HeaderStyle CssClass="hidden"></HeaderStyle>
                                </asp:BoundField>
                                <%-- 20 --%>
                                <asp:BoundField DataField="" HeaderText="Ver Ficha" SortExpression="">
                                    <ItemStyle Width="4%" HorizontalAlign="Center" Height="15px" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="4%" CssClass="" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <%-- 21 --%>
                                <asp:BoundField DataField="nIdCliente">
                                    <ItemStyle CssClass="hidden"></ItemStyle>
                                    <HeaderStyle CssClass="hidden"></HeaderStyle>
                                </asp:BoundField>
                                <%-- 22 --%>
                                <asp:TemplateField HeaderText="Select">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chkAll" onclick="javascript:SelectAllCheckboxes(this);" Checked="true" runat="server"
                                            Height="15px"></asp:CheckBox>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkPermiso" runat="server" Checked="true" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%-- 23 --%>
                                <asp:BoundField DataField="nIdTipoGestion" HeaderText="CodTipoGestion" SortExpression="">
                                    <ItemStyle CssClass="hidden" Width="0%"></ItemStyle>
                                    <HeaderStyle Width="0%" CssClass="hidden" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <%-- 24 --%>
                                <asp:BoundField DataField="" HeaderText="Gestionar" SortExpression="">
                                    <ItemStyle Width="10%" HorizontalAlign="Center" Height="15px" 
                                    Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <%-- 25 --%>
                                <asp:BoundField DataField="cUsuarioRecuperador" HeaderText="Gestionado Por" SortExpression="">
                                    <ItemStyle Width="0%" HorizontalAlign="Left" Height="15px" Font-Bold="False" CssClass="hidden"></ItemStyle>
                                    <HeaderStyle Width="0%" CssClass="hidden" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                            </Columns>
                            <PagerSettings NextPageText="-&amp;gt;" />
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
                            <SelectedRowStyle CssClass="selectedrow" BackColor="#669999"></SelectedRowStyle>
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
