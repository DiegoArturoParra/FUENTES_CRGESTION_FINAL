
<%@ page title="" language="C#" masterpagefile="~/Master/Ceem.master" autoeventwireup="true" inherits="Estudio_Gestion_GS_Busqueda_Campaña, App_Web_0nt2mo3d" stylesheettheme="Standard" %>

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
                                    <table id="tbToolbarSuperior" cellpadding="0" cellspacing="0" class="cabeceraScroll" 
                                        style="width: 100%">
                                        <tbody>
                                            <tr>
                                                <td>

<table border="0" cellpadding="0" cellspacing="0" class="cabeceraScroll" style="width: 100%">
    <tr>
        <td align="left" style="height: 28px; width: 594px;">
            &nbsp;</td>
        <td style="width: 185px; height: 28px">
            &nbsp;</td>
        <td style="height: 28px; width: 141px;">
            &nbsp;&nbsp;
        </td>
        <td style="height: 28px;">
            <asp:Button ID="btnBuscar" runat="server" CausesValidation="False" 
                OnClick="btnBuscar_Click" style="height: 26px" Text="Buscar" 
                Width="120px" BackColor="#1F529E" ForeColor="White" />
            <asp:Button ID="btnProcesar" runat="server" CausesValidation="False" 
                OnClick="btnProcesar_Click" style="height: 26px" Text="Procesar" 
                Width="100px" BackColor="#1F529E" ForeColor="White" />
            <asp:Button ID="btnAnular" runat="server" CausesValidation="False" 
                 Text="Anulaciones" Width="120px" 
                style="height: 26px" onclick="btnAnular_Click" BackColor="#1F529E" 
                ForeColor="White" />
        </td>
    </tr>
</table>

                                                        
                                                        </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <table class="cabeceraScroll" style="width: 100%"  
                                        <tr>
                                        </tr>
                                        <tr>
                                            <td style="height: 32px">
                                                
                                                <table align="center" border="0" cellpadding="0" cellspacing="0" 
                                                    class="cabeceraScroll" width="800px">
                                                    <tr>
                                                        <td align="left" style="width: 331px">
                                                            Dias de mora:</td>
                                                        <td align="left" width="">
                                                            <asp:TextBox ID="txt_dias_mora" runat="server" 
                                                                Width="400px"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="rexNombre" runat="server" 
                                                                ControlToValidate="txt_dias_mora" Display="Dynamic" 
                                                                ErrorMessage="Debe ingresar por lo menos 3 caracteres." 
                                                                ValidationExpression=".{3,}">*</asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 331px">
                                                            Tipo de Gestión:</td>
                                                        <td align="left" width="">
                                                            <asp:DropDownList ID="cmb_CodTipoGestion" runat="server" TabIndex="6" 
                                                                Width="100%">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 331px">
                                                            Fecha de Registro del Action Plan:</td>
                                                        <td align="left" width="">
                                                            Del
                                                            <asp:TextBox ID="txt_FECHAINI" runat="server" Enabled="false" Height="18px" 
                                                                MaxLength="10" TabIndex="5" Width="150px"></asp:TextBox>
                                                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" 
                                                                PopupButtonID="imgCal1" TargetControlID="txt_FECHAINI" />
                                                            <asp:ImageButton ID="imgCal1" runat="Server" AlternateText="Mostrar calendario" 
                                                                ImageUrl="~/imagenes/Calendar.png" />
                                                            &nbsp;al
                                                            <asp:TextBox ID="txt_FECHAFIN" runat="server" Enabled="false" Height="18px" 
                                                                MaxLength="10" TabIndex="5" Width="150px"></asp:TextBox>
                                                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" 
                                                                PopupButtonID="imgCal2" TargetControlID="txt_FECHAFIN" />
                                                            <asp:ImageButton ID="imgCal2" runat="Server" AlternateText="Mostrar calendario" 
                                                                ImageUrl="~/imagenes/Calendar.png" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>


                                    <asp:GridView ID="gv" runat="server" Width="100%" EnableTheming="True" 
                                        
                                        AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True" 
                                        PageSize="20">
                                        <PagerSettings PreviousPageText="&amp;lt;Anterior" Mode="NextPreviousFirstLast" LastPageText="Ultimo&amp;gt;&amp;gt;"
                                            FirstPageText="&amp;lt;&amp;lt;Primero" NextPageText="Siguiente&amp;gt;"></PagerSettings>
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


                                            <asp:BoundField DataField="FechaRegistra" HeaderText="FechaReg" SortExpression="">
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


                                            <asp:BoundField DataField="FechaResultado" HeaderText="FechaResul." SortExpression="">
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
                                        <RowStyle></RowStyle>
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
                                        <SelectedRowStyle CssClass="selectedrow"></SelectedRowStyle>
                                        <AlternatingRowStyle  />
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



