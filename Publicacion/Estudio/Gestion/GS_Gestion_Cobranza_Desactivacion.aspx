<%@ page title="" language="C#" masterpagefile="~/Master/GCCeem.master" autoeventwireup="true" inherits="Estudio_Gestion_GS_Gestion_Cobranza_Desactivacion, App_Web_hhkm3gt1" stylesheettheme="Standard" %>

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



            
            <div class="form-group col-md-7">
                <div class="rounded" style="min-height: 150px;">

                    <div class="form-row col-md-5">
                        <label for="inputEmail4">DNI:</label>
                    </div>
                    <div class="form-row col-md-7">
                        <asp:TextBox ID="txt_documento" runat="server" Width="100%" MaxLength="20"></asp:TextBox>
                    </div>
                    <div class="form-row col-md-5">
                        <label for="inputEmail4">Nombres:</label>
                    </div>
                    <div class="form-row col-md-7">
                        <asp:TextBox ID="txt_nombres" runat="server" Width="100%" MaxLength="50"></asp:TextBox>
                    </div>
                    <div class="form-row col-md-5">
                        <label for="inputEmail4">Dias mora:</label>
                    </div>
                    <div class="form-row col-md-7">
                        De:
                        <asp:TextBox ID="txt_dias_mora" runat="server" Width="29%"></asp:TextBox>
                        Hasta:
                        <asp:TextBox ID="txt_dias_mora_hasta" runat="server" Width="29%"></asp:TextBox>
                    </div>
               <%-- </div>
            </div>
            
            <div class="form-group col-md-4">
                <div class="rounded" style="min-height: 100px;">--%>

                    <div class="form-row col-md-5">
                        <label for="inputEmail4">Estado:</label>
                    </div>
                    <div class="form-row col-md-7">
                        <asp:DropDownList ID="cmb_Estado" runat="server" TabIndex="6" Width="100%" 
                            onselectedindexchanged="cmb_Estado_SelectedIndexChanged" 
                            AutoPostBack="True">
                        </asp:DropDownList>
                    </div>
                    <div class="form-row col-md-5">
                        <label for="inputEmail4">Tipo Gestión:</label>
                    </div>
                    <div class="form-row col-md-7">
                        <asp:DropDownList ID="cmb_CodTipoGestion" runat="server" TabIndex="6" 
                            Width="100%" onselectedindexchanged="cmb_CodTipoGestion_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
                    </div>
                    <div class="form-row col-md-5">
                        <label for="inputEmail4">Generación del Action Plan:</label>
                    </div>
                    <div class="form-row col-md-7">
                        Del
                        <asp:TextBox ID="txt_FECHAINI" runat="server" Enabled="false" Height="18px" MaxLength="10"
                            TabIndex="5" Width="30%"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="imgCal1"
                            TargetControlID="txt_FECHAINI" />
                        <asp:ImageButton ID="imgCal1" runat="Server" AlternateText="Mostrar calendario" ImageUrl="~/imagenes/Calendar.png" />
                        &nbsp;al
                        <asp:TextBox ID="txt_FECHAFIN" runat="server" Enabled="false" Height="18px" MaxLength="10"
                            TabIndex="5" Width="30%"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="imgCal2"
                            TargetControlID="txt_FECHAFIN" />
                        <asp:ImageButton ID="imgCal2" runat="Server" AlternateText="Mostrar calendario" ImageUrl="~/imagenes/Calendar.png" />
                    </div>
                </div>
            </div>
            
            <div class="form-group col-md-5">
                <div class="rounded" style="min-height: 150px;">

                    <div class="form-row col-md-4">
                        <label for="inputEmail4">Zona:</label>
                    </div>
                    <div class="form-row col-md-8">
                        <asp:DropDownList ID="cmb_JerarquiaB" runat="server" TabIndex="6" Width="100%" 
                            AutoPostBack="True" 
                            onselectedindexchanged="cmb_JerarquiaB_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <div class="form-row col-md-4">
                        <label for="inputEmail4">Agencia:</label>
                    </div>
                    <div class="form-row col-md-8">
                        <asp:DropDownList ID="cmb_JerarquiaC" runat="server" AutoPostBack="True" TabIndex="6" Width="100%" 
                            onselectedindexchanged="cmb_JerarquiaC_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <div class="form-row col-md-4">
                        <label for="inputEmail4">Asesor:</label>
                    </div>
                    <div class="form-row col-md-8">
                        <asp:DropDownList ID="cmb_JerarquiaD" runat="server" AutoPostBack="True" TabIndex="6" Width="100%" 
                            onselectedindexchanged="cmb_JerarquiaD_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <div class="form-group col-md-12">
                    </div>
                    <div class="form-row col-md-6 text-right">
                        <asp:Button ID="btnBuscar" runat="server" class="btn btn-primary" OnClick="btnBuscar_Click" Text="Buscar" Width="60%" />
                    </div>
                    <div class="form-row col-md-6">
                        <asp:Button ID="btnDesactivar" runat="server" class="btn btn-primary" OnClick="btnDesactivar_Click" Text="Desactivar" Width="60%" />
                    </div>
                </div>
            </div>
            <%--<div class="form-group col-md-1">
                <div class="rounded" style="min-height: 100px;">
                    <table style="margin:auto; text-align:center; height:80px; width:100%; border-spacing:5px" >
                        <tr>
                            <td>
                                
                            </td>
                        </tr>
                        <tr>
                            <td>
                                
                                
                            </td>
                        </tr>
                    </table>
                </div>
            </div>--%>
            
            <table id="Grid" border="0" width="100%">
                <tr>
                    <td align="center" style="width: 100%;">
                        <asp:GridView ID="gv" runat="server" Width="100%" EnableTheming="True" AutoGenerateColumns="False"
                            AllowSorting="True" AllowPaging="True" Style="text-align: center" ViewStateMode="Enabled"
                            BackColor="#999999" OnPageIndexChanging="gv_PageIndexChanging" 
                            OnPageIndexChanged="gv_PageIndexChanged" 
                            onselectedindexchanged="gv_SelectedIndexChanged" BorderColor="#CCCCCC">
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
                                <asp:BoundField DataField="FechaRegistra" HeaderText="Fecha de Creación" SortExpression="">
                                    <ItemStyle Width="11%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="11%" CssClass="" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <%-- 2 --%>
                                <asp:BoundField DataField="IdReg_Gestion_Cobranza" HeaderText="IdReg_G_Cob." SortExpression="">
                                    <ItemStyle Width="6%" HorizontalAlign="Left" Height="15px" Font-Bold="False" CssClass="hidden">
                                    </ItemStyle>
                                    <HeaderStyle Width="6%" CssClass="hidden" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <%-- 3 --%>
                                <asp:BoundField DataField="Asesores" HeaderText="Asesores" SortExpression="">
                                    <ItemStyle Width="4%" HorizontalAlign="Left" Height="15px" Font-Bold="False" CssClass="hidden"></ItemStyle>
                                    <ControlStyle Font-Names="Trebuchet MS" />
                                    <HeaderStyle Width="4%" CssClass="hidden" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <%-- 4 --%>
                                <%--<asp:BoundField DataField="FechaRegistra" HeaderText="Fecha de Creación" SortExpression="">
                                    <ItemStyle Width="11%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="11%" CssClass="hidden" Height="22px"></HeaderStyle>
                                </asp:BoundField>--%>
                                <asp:BoundField DataField="Recuperador" HeaderText="Gestionado Por" SortExpression="">
                                    <ItemStyle Width="11%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="11%" CssClass="" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <%-- 5 --%>
                                <asp:BoundField DataField="Descripcion_TipoGestion" HeaderText="Tipo de Gesti&oacute;n"
                                    SortExpression="">
                                    <ItemStyle Width="15%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="15%" CssClass="" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <%-- 6 --%>
                                <asp:BoundField DataField="RazonSocial" HeaderText="Raz&oacute;n Social / Nombres" SortExpression="">
                                    <ItemStyle Width="18%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="18%" CssClass="" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <%-- 7 --%>
                                <asp:BoundField DataField="Producto" HeaderText="Producto" SortExpression="">
                                    <ItemStyle Width="6%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="6%" CssClass="" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <%--<asp:BoundField DataField="SubProducto" HeaderText="SubProducto" SortExpression="">
                                    <ItemStyle Width="8%" HorizontalAlign="Left" Height="15px" Font-Bold="False" CssClass="hidden"></ItemStyle>
                                    <HeaderStyle Width="8%" CssClass="hidden" Height="22px"></HeaderStyle>
                                </asp:BoundField>--%>
                                <%-- 8 --%>
                                <asp:BoundField DataField="Tramo" HeaderText="Tramo" SortExpression="">
                                    <ItemStyle Width="4%" HorizontalAlign="center" Height="15px" Font-Bold="False" CssClass=""></ItemStyle>
                                    <HeaderStyle Width="4%" CssClass="" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <%-- 9 --%>
                                <asp:BoundField DataField="dias_mora" HeaderText="D&iacute;as de mora" SortExpression="">
                                    <ItemStyle Width="6%" HorizontalAlign="center" Height="15px" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="6%" CssClass="" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <%-- 10 --%>
                                <asp:BoundField DataField="comentario" HeaderText="Comentario" SortExpression="">
                                    <ItemStyle Width="10%" HorizontalAlign="center" Height="15px" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <%-- 11 --%>
                                <asp:BoundField DataField="Descripcion_ClaseGestion" HeaderText="Resultado" SortExpression="">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <%-- 12 --%>
                                <asp:BoundField DataField="FechaResultado" HeaderText="Fecha de Resultado" SortExpression="">
                                    <ItemStyle Width="11%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="11%" CssClass="" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <%-- 13 --%>
                                <asp:BoundField DataField="CodEjecutado" HeaderText="CodEjecutado" SortExpression="">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False" CssClass="hidden">
                                    </ItemStyle>
                                    <HeaderStyle Width="10%" CssClass="hidden" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <%-- 14 --%>
                                <asp:BoundField DataField="Descripcion_Ejecutado" HeaderText="Clasificación" SortExpression="">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <%-- 15 --%>
                                <asp:BoundField DataField="desc_ejecutores" HeaderText="Ejecutores" SortExpression="">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False" CssClass="hidden">
                                    </ItemStyle>
                                    <HeaderStyle Width="10%" Height="22px" CssClass="hidden"></HeaderStyle>
                                </asp:BoundField>
                                <%-- 16 --%>
                                <asp:BoundField DataField="desc_campaña" HeaderText="Campaña" SortExpression="">
                                    <ItemStyle Width="8%" HorizontalAlign="Left" Height="15px" Font-Bold="False" CssClass="hidden"></ItemStyle>
                                    <HeaderStyle Width="8%" CssClass="hidden" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <%-- 17 --%>
                                <asp:BoundField DataField="id_estado_gestion_cobranza">
                                    <ItemStyle CssClass="hidden"></ItemStyle>
                                    <HeaderStyle CssClass="hidden"></HeaderStyle>
                                </asp:BoundField>
                                <%-- 18 --%>
                                <asp:BoundField DataField="" HeaderText="Estado" SortExpression="">
                                    <ItemStyle Width="6%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="6%" CssClass="" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <%-- 19 --%>
                                <asp:BoundField DataField="CodCLaseGestion">
                                    <ItemStyle CssClass="hidden"></ItemStyle>
                                    <HeaderStyle CssClass="hidden"></HeaderStyle>
                                </asp:BoundField>
                                <%-- 20 --%>
                                <asp:BoundField DataField="" HeaderText="Ver Ficha" SortExpression="">
                                    <ItemStyle Width="12%" HorizontalAlign="Center" Height="15px" 
                                    Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="12%" CssClass="" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <%-- 21 --%>
                                <asp:BoundField DataField="CodigoCliente">
                                    <ItemStyle CssClass="hidden"></ItemStyle>
                                    <HeaderStyle CssClass="hidden"></HeaderStyle>
                                </asp:BoundField>
                                <%-- 22 --%>
                                <asp:TemplateField HeaderText="Select">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chkAll" onclick="javascript:SelectAllCheckboxes(this);" runat="server"
                                            Height="15px"></asp:CheckBox>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkPermiso" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%-- 23 --%>
                                <asp:BoundField DataField="CodTipoGestion" HeaderText="CodTipoGestion" SortExpression="">
                                    <ItemStyle CssClass="hidden" Width="10%"></ItemStyle>
                                    <HeaderStyle Width="10%" CssClass="hidden" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <%-- 24 --%>
                                <asp:BoundField DataField="" HeaderText="Evaluar" SortExpression="">
                                    <ItemStyle Width="10%" HorizontalAlign="Center" Height="15px" 
                                    Font-Bold="False" CssClass="hidden"></ItemStyle>
                                    <HeaderStyle Width="10%" CssClass="hidden" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <%-- 25 --%>
                                <asp:BoundField DataField="CodUsuario_Recuperador" HeaderText="Gestionado Por" SortExpression="">
                                    <ItemStyle Width="11%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="11%" CssClass="hidden" Height="22px"></HeaderStyle>
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
