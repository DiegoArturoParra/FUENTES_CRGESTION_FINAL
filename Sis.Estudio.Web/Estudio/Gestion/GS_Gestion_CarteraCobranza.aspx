<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Ceem.master" AutoEventWireup="true" CodeFile="GS_Gestion_CarteraCobranza.aspx.cs" Inherits="Estudio_Gestion_GS_Gestion_CarteraCobranza" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="GMDatePicker" Namespace="GrayMatterSoft" TagPrefix="cc2" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="cc3" %>
<%@ MasterType VirtualPath="~/Master/Ceem.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DefaultContent" Runat="Server">
    <script language="javascript">
        function Enter_Buscar(evt) {
        }

        function Valida_Todos() {

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
                                                    ShowMessageBox="True" ShowSummary="False" CssClass="Etiqueta" />
                                                <asp:Label ID="lblMensaje" runat="server" CssClass="Etiqueta" ForeColor="Red"></asp:Label><input
                                                    id="hdnContinuar" name="hdnContinuar" style="width: 80px; height: 10px" type="hidden" />
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:UpdatePanel ID="upGvUsuario" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>


                                    
            <div class="form-group col-md-5">
                <div class="rounded" style="min-height: 140px;">

                    <div class="form-row col-md-4">
                        <label for="inputEmail4">Dias de mora:</label>
                    </div>
                    <div class="form-row col-md-8">
                        <asp:TextBox ID="txt_dias_mora" runat="server" Width="100%"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="rexNombre" runat="server" ControlToValidate="txt_dias_mora" Display="Dynamic" 
                            ErrorMessage="Debe ingresar por lo menos 3 caracteres." ValidationExpression=".{3,}">*</asp:RegularExpressionValidator>
                    </div>
                    <div class="form-row col-md-4">
                        <label for="inputEmail4">Tipo de Gestión:</label>
                    </div>
                    <div class="form-row col-md-8">
                        <asp:DropDownList ID="cmb_CodTipoGestion" runat="server" TabIndex="6" 
                            Width="100%">
                        </asp:DropDownList>
                    </div>
                    <div class="form-row col-md-4">
                        <label for="inputEmail4">Jerarquía:</label>
                    </div>
                    <div class="form-row col-md-8">
                        <asp:TextBox ID="txt_desc_jerarquia" runat="server" Enabled="false" Width="100%"></asp:TextBox>
                    </div>
                    <div class="form-row col-md-4">
                        <label for="inputEmail4">Asesor:</label>
                    </div>
                    <div class="form-row col-md-8">
                        <asp:TextBox ID="txt_asesor" runat="server" Enabled="false" Width="100%"></asp:TextBox>
                    </div>
                    <div class="form-row col-md-4">
                        <label for="inputEmail4">Registro Action Plan:</label>
                    </div>
                    <div class="form-row col-md-8">
                        Del
                        <asp:TextBox ID="txt_FECHAINI" runat="server" Enabled="false" Height="18px" MaxLength="10" TabIndex="5" Width="30%"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="imgCal1" TargetControlID="txt_FECHAINI" />
                        <asp:ImageButton ID="imgCal1" runat="Server" AlternateText="Mostrar calendario" ImageUrl="~/imagenes/Calendar.png" />
                        &nbsp;al
                        <asp:TextBox ID="txt_FECHAFIN" runat="server" Enabled="false" Height="18px" MaxLength="10" TabIndex="5" Width="30%"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="imgCal2" TargetControlID="txt_FECHAFIN" />
                        <asp:ImageButton ID="imgCal2" runat="Server" AlternateText="Mostrar calendario" ImageUrl="~/imagenes/Calendar.png" />
                    </div>
                </div>
            </div>
                                    
            <div class="form-group col-md-5">
                <div class="rounded" style="min-height: 140px;">

                    <div class="form-row col-md-5">
                        <label for="inputEmail4">Jerarquía Nivel A:</label>
                    </div>
                    <div class="form-row col-md-7">
                        <asp:DropDownList ID="cmb_JerarquiaA" runat="server" AutoPostBack="True" 
                            onselectedindexchanged="cmb_JerarquiaA_SelectedIndexChanged" TabIndex="6" 
                            Width="100%">
                        </asp:DropDownList>
                    </div>
                    <div class="form-row col-md-5">
                        <label for="inputEmail4">Jerarquía Nivel B:</label>
                    </div>
                    <div class="form-row col-md-7">
                        <asp:DropDownList ID="cmb_JerarquiaB" runat="server" AutoPostBack="True" 
                            onselectedindexchanged="cmb_JerarquiaB_SelectedIndexChanged" TabIndex="6" 
                            Width="100%">
                        </asp:DropDownList>
                    </div>
                    <div class="form-row col-md-5">
                        <label for="inputEmail4">Jerarquía Nivel C:</label>
                    </div>
                    <div class="form-row col-md-7">
                        <asp:DropDownList ID="cmb_JerarquiaC" runat="server" AutoPostBack="True" 
                            onselectedindexchanged="cmb_JerarquiaC_SelectedIndexChanged" TabIndex="6" 
                            Width="100%">
                        </asp:DropDownList>
                    </div>
                    <div class="form-row col-md-5">
                        <label for="inputEmail4">Jerarquía Nivel D:</label>
                    </div>
                    <div class="form-row col-md-7">
                        <asp:DropDownList ID="cmb_JerarquiaD" runat="server" TabIndex="6" Width="100%">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="form-group col-md-2">
                <div class="rounded" style="min-height: 140px;">
                    <table style="margin:auto; text-align:center; height:120px; width:100%; border-spacing:5px" >
                        <tr>
                            <td>
                                <asp:Button ID="btnBuscar" runat="server" class="btn btn-primary" CausesValidation="False" OnClick="btnBuscar_Click" Width="95%" Text="Filtro avanzado" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnConsultar" runat="server" class="btn btn-primary" CausesValidation="False" onclick="btnConsultar_Click" Width="95%" Text="Consultar" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>


                                    <asp:GridView ID="gv" runat="server" Width="100%" EnableTheming="True" 
                                        
                                        AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True" 
                                        style="text-align: center; margin-top: 0px;" ViewStateMode="Enabled" 
                                        BackColor="White" onpageindexchanging="gv_PageIndexChanging" 
                                        onpageindexchanged="gv_PageIndexChanged" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3"  >
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
                                                <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                                <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                                            </asp:BoundField>


                                            <asp:BoundField DataField="Asesores" HeaderText="Asesores" SortExpression="">
                                                <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                                <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                                            </asp:BoundField>


                                            <asp:BoundField DataField="FechaRegistra" HeaderText="FechaReg." SortExpression="">
                                                <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                                <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                                            </asp:BoundField>


                                            <asp:BoundField DataField="Descripcion_TipoGestion" HeaderText="Desc_TipoGestion" SortExpression="">
                                                <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                                <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                                            </asp:BoundField>

                                            <asp:BoundField DataField="RazonSocial" HeaderText="RazonSocial" SortExpression="">
                                                <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                                <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                                            </asp:BoundField>


                                            <asp:BoundField DataField="Producto" HeaderText="Producto" SortExpression="">
                                                <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                                <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                                            </asp:BoundField>


                                            <asp:BoundField DataField="SubProducto" HeaderText="SubProducto" SortExpression="">
                                                <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                                <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                                            </asp:BoundField>


                                            <asp:BoundField DataField="dias_mora" HeaderText="Dias_mora" SortExpression="">
                                                <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                                <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                                            </asp:BoundField>

                                            <asp:BoundField DataField="Descripcion_ClaseGestion" HeaderText="Resultado" SortExpression="">
                                                <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                                <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                                            </asp:BoundField>


                                            <asp:BoundField DataField="FechaResultado" HeaderText="FechaResu." SortExpression="">
                                                <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                                <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                                            </asp:BoundField>


                                            <asp:BoundField DataField="CodEjecutado" HeaderText="CodEjecutado" SortExpression="">
                                                <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                                <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                                            </asp:BoundField>


                                            <asp:BoundField DataField="Descripcion_Ejecutado" HeaderText="Desc_Ejecutado" SortExpression="">
                                                <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                                <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                                            </asp:BoundField>


                                            <asp:BoundField DataField="desc_ejecutores" HeaderText="Ejecutores" SortExpression="">
                                                <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                                <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                                            </asp:BoundField>

                                            <asp:BoundField DataField="desc_campaña" HeaderText="desc_campaña" SortExpression="">
                                                <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                                <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                                            </asp:BoundField>

                                                <asp:BoundField DataField="id_estado_gestion_cobranza">
                                                    <ItemStyle CssClass="hidden"></ItemStyle>
                                                    <HeaderStyle CssClass="hidden"></HeaderStyle>
                                                </asp:BoundField>


                                            <asp:BoundField DataField="" HeaderText="Estado" SortExpression="">
                                                <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                                <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                                            </asp:BoundField>

                                                <asp:BoundField DataField="CodCLaseGestion">
                                                    <ItemStyle CssClass="hidden"></ItemStyle>
                                                    <HeaderStyle CssClass="hidden"></HeaderStyle>
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
                                            <PagerSettings FirstPageText="" LastPageText="" NextPageText="" 
                                                PreviousPageText="" />
                                        <SelectedRowStyle CssClass="selectedrow" BackColor="#669999" Font-Bold="True" ForeColor="White"></SelectedRowStyle>
                                        <AlternatingRowStyle  />
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
                                                        <asp:Image runat="server" ID="Progres" ImageUrl="~/imagenes/loading.gif" Style="vertical-align: middle"  alt="Procesando&#8230;" />
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



