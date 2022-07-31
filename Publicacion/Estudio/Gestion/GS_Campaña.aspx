<%@ page title="" language="C#" masterpagefile="~/Master/Ceem.master" autoeventwireup="true" inherits="Estudio_Gestion_GS_Campaña, App_Web_5d2q0ozo" stylesheettheme="Standard" %>

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

        function Control_Numero(evt) {
            if (event.keyCode == 13) event.keyCode = 9;
            var charCode = evt.keyCode

            if ((charCode > 45 && charCode < 58) || (charCode > 95 && charCode < 106) || (charCode > 32 && charCode < 41) || (charCode == 8) || (charCode == 9) || (charCode == 17) || (charCode == 27))
                return true
            else
                return false
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
                Width="120px" BackColor="#000080" ForeColor="White" />
            <asp:Button ID="btnGrabar" runat="server" CausesValidation="False" 
                 style="height: 26px" Text="Grabar" Width="120px" 
                onclick="btnGrabar_Click" BackColor="#000080" ForeColor="White" />
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
                                                        <td style="text-align: center;" bgcolor="#CCCCCC" colspan="3">
                                                            Registro de Campaña</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 155px">
                                                            Descripción de Campaña:</td>
                                                        <td align="left" style="width: 303px">
                                                            <asp:TextBox ID="txt_desc_campaña" runat="server"  MaxLength="5000" 
                                                                Width="92%" ></asp:TextBox>
                                                        </td>
                                                        <td align="left" rowspan="2" width="">
                                                            <asp:GridView ID="gv2" runat="server" AllowPaging="True" AllowSorting="True" 
                                                                AutoGenerateColumns="False" BorderColor="#CCCCCC" BorderWidth="1px" 
                                                                EnableTheming="True" Height="228px" HorizontalAlign="Center" 
                                                                style="text-align: center" ViewStateMode="Enabled" Width="303px" 
                                                                PageSize="50" BackColor="White" BorderStyle="None" CellPadding="3">
                                                                <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="White" ForeColor="#000066" />
                                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#2F63CB" Font-Bold="True" ForeColor="White" />
                                                                <PagerSettings FirstPageText="&amp;lt;&amp;lt;Primero" 
                                                                    LastPageText="Ultimo&amp;gt;&amp;gt;" 
                                                                    NextPageText="Siguiente&amp;gt;" PreviousPageText="&amp;lt;Anterior" />
                                                                <Columns>

                                                                    <asp:BoundField DataField="CodTipoGestion" HeaderText="Codigo">
                                                                    <ItemStyle Font-Bold="False" Height="15px" HorizontalAlign="Left" Width="30%" />
                                                                    <HeaderStyle CssClass="" Height="22px" Width="30%" />
                                                                    </asp:BoundField>
                                                                    
                                                                    <asp:BoundField DataField="Descripcion" HeaderText="Descripción">
                                                                    <ItemStyle Font-Bold="False" Height="15px" HorizontalAlign="Left" Width="70%" />
                                                                    <HeaderStyle CssClass="" Height="22px" Width="70%" />
                                                                    </asp:BoundField>
                                                                    
                                                                    <asp:BoundField DataField="chk">
                                                                    <ItemStyle CssClass="hidden" />
                                                                    <HeaderStyle CssClass="hidden" />
                                                                    </asp:BoundField>
                                                                    
                                                                    <asp:TemplateField HeaderText="Select">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="chkPermiso" runat="server" />
                                                                        </ItemTemplate>
                                                                        <HeaderTemplate>
                                                                        </HeaderTemplate>
                                                                    </asp:TemplateField>

                                                                </Columns>
                                                                <EmptyDataTemplate>
                                                                    <table ID="tbSinDatos1">
                                                                        <tbody>
                                                                            <tr>
                                                                                <td style="width: 10%">
                                                                                    <img src="http://localhost:6722/Sis.SgoAdm.Web/Imagenes/imgWarning.png" style="width:25px; height:24px" />
                                                                                </td>
                                                                                <td style="width: 5%">
                                                                                </td>
                                                                                <td style="width: 85%">
                                                                                    <asp:Label ID="lblSinDatos1" runat="server" CssClass="labeltextonegro" 
                                                                                        Text="No se encontraron Datos..."></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                </EmptyDataTemplate>
                                                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                                <RowStyle ForeColor="#000066" />
                                                                <SelectedRowStyle CssClass="selectedrow" BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                                <SortedDescendingHeaderStyle BackColor="#00547E" />
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 155px">
                                                            Condición de Campaña:</td>
                                                        <td align="left" style="width: 303px">
                                                            <asp:TextBox ID="txt_condicion_campaña" runat="server" CssClass="CajaTexto" 
                                                                ForeColor="Black" Height="221px" MaxLength="5000" TabIndex="1" 
                                                                TextMode="MultiLine" Width="93%"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="3">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" bgcolor="#CCCCCC" colspan="3" 
                                                            style="text-align: center; height: 20px;">
                                                            Filtro de Búqueda</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 155px">
                                                            Deuda en dias:</td>
                                                        <td align="left" width="" colspan="2">
                                                            <asp:DropDownList ID="cmb_condicion_dias" runat="server" TabIndex="6" 
                                                                Width="100px">
                                                                <asp:ListItem Value="=">Igual</asp:ListItem>
                                                                <asp:ListItem Value="&gt;">Mayor</asp:ListItem>
                                                                <asp:ListItem Value="&lt;">Menor</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:TextBox ID="txt_dias_deuda" runat="server" 
                                                                onkeydown="return Control_Numero(event)" Width="200px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 155px">
                                                            Monto Capital:</td>
                                                        <td align="left" width="" colspan="2">
                                                      <asp:DropDownList ID="cmb_condicion_capital" runat="server" TabIndex="6" Width="100px">
                                                                                                        <asp:ListItem Value="=">Igual</asp:ListItem>
                                                                                                        <asp:ListItem Value=">">Mayor</asp:ListItem>
                                                                                                        <asp:ListItem Value="<">Menor</asp:ListItem>
                                                                                                    </asp:DropDownList>

                                                            <asp:TextBox ID="txt_capital" runat="server" Width="200px" onkeydown="return Control_Numero(event)"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 155px">
                                                            Saldo Capital:</td>
                                                        <td align="left" width="" colspan="2">

                                                      <asp:DropDownList ID="cmb_condicion_saldocapital" runat="server" TabIndex="6" Width="100px">
                                                                                                        <asp:ListItem Value="=">Igual</asp:ListItem>
                                                                                                        <asp:ListItem Value=">">Mayor</asp:ListItem>
                                                                                                        <asp:ListItem Value="<">Menor</asp:ListItem>
                                                                                                    </asp:DropDownList>

                                                            <asp:TextBox ID="txt_saldo_capital" runat="server" Width="200px" onkeydown="return Control_Numero(event)"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 155px">
                                                            Calificación SBS:</td>
                                                        <td align="left" width="" colspan="2">
                                                            <asp:DropDownList ID="cmb_CalificacionSBS" runat="server" TabIndex="6" 
                                                                Width="100%">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 155px">
                                                            Estado de Dirección:</td>
                                                        <td align="left" width="" colspan="2">
                                                            <asp:DropDownList ID="cmb_EstadoDir" runat="server" TabIndex="6" Width="100%">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>


                                    <asp:GridView ID="gv" runat="server" Width="100%" EnableTheming="True" 
                                        
                                        AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True" 
                                        style="text-align: center" ViewStateMode="Enabled" 
                                        BackColor="White" onpageindexchanging="gv_PageIndexChanging" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" >
                                            <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="White" ForeColor="#000066" />
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#2F63CB" Font-Bold="True" ForeColor="White" />
                                        <Columns>




                                            <asp:TemplateField ShowHeader="False">
                                                <ItemStyle Width="1%"></ItemStyle>
                                                <HeaderStyle Width="1%" CssClass=""></HeaderStyle>
                                                <ItemTemplate>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:BoundField DataField="" HeaderText=" #Nro. " SortExpression="">
                                                <ItemStyle Width="5%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                                <HeaderStyle Width="5%" CssClass="" Height="22px"></HeaderStyle>
                                            </asp:BoundField>

                                            <asp:BoundField DataField="IdReg" HeaderText="IdReg" SortExpression="">
                                                <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                                <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                                            </asp:BoundField>

                                            <asp:BoundField DataField="IdRegProductos" HeaderText="IdRegProductos" SortExpression="">
                                                <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                                <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                                            </asp:BoundField>

                                            <asp:BoundField DataField="CodigoCliente" HeaderText="CodigoCliente" SortExpression="">
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

                                            <asp:BoundField DataField="NroCuotas" HeaderText="NroCuotas" SortExpression="">
                                                <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                                <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                                            </asp:BoundField>

                                            <asp:BoundField DataField="FechaVencimiento" HeaderText="FechaVencimiento" SortExpression="">
                                                <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                                <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                                            </asp:BoundField>

                                            <asp:BoundField DataField="FechaPago" HeaderText="FechaPago" SortExpression="">
                                                <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                                <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                                            </asp:BoundField>

                                            <asp:BoundField DataField="dias_deuda" HeaderText="dias_deuda" SortExpression="">
                                                <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                                <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                                            </asp:BoundField>

                                            <asp:BoundField DataField="MontoCuota" HeaderText="MontoCuota" SortExpression="">
                                                <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                                <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                                            </asp:BoundField>

                                            <asp:BoundField DataField="Capital" HeaderText="Capital" SortExpression="">
                                                <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                                <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                                            </asp:BoundField>

                                            <asp:BoundField DataField="Interes" HeaderText="Interes" SortExpression="">
                                                <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                                <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                                            </asp:BoundField>

                                            <asp:BoundField DataField="SaldoCapital" HeaderText="SaldoCapital" SortExpression="">
                                                <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                                <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                                            </asp:BoundField>

                                            <asp:BoundField DataField="CalificacionSBS" HeaderText="CalificacionSBS" SortExpression="">
                                                <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                                <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
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



