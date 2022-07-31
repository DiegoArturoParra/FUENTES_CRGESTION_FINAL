<%@ page title="" language="C#" masterpagefile="~/Master/Ficha.master" autoeventwireup="true" inherits="Estudio_Gestion_06FrmProduCliente, App_Web_hhkm3gt1" stylesheettheme="Standard" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/Master/Ficha.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../javascript/jquery-2.1.1.min.js" type="text/javascript"></script>
    <script src="../../javascript/jsUpdateProgress.js" type="text/javascript"></script>
    <script type="text/javascript">
        var ModalProgress = '<%= ModalProgress.ClientID %>';

        function Control_Numero(evt) {
            if (event.keyCode == 13) event.keyCode = 9;
            var charCode = evt.keyCode

            if ((charCode > 45 && charCode < 58) || (charCode > 95 && charCode < 106) || (charCode > 32 && charCode < 41) || (charCode == 8) || (charCode == 9) || (charCode == 17) || (charCode == 27))
                return true
            else
                return false
        }

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

    </script>
    <script src="../../javascript/jsUpdateProgress.js" type="text/javascript"></script>
    <input id="hdnContinuar" name="hdnContinuar" style="width: 80px; height: 10px" type="hidden" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <contenttemplate>
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
            <td class="encebezadotabla-3" style="width: 98%; text-align:center">
            PRODUCTO DEL CLIENTE
            </td>
            </tr>
            </table>
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="width: 100%;" valign="top">
                        <asp:GridView ID="gv" runat="server" Width="100%" EnableTheming="True" AutoGenerateColumns="False"
                            AllowSorting="True" PageSize="20" OnSelectedIndexChanged="gv_SelectedIndexChanged" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                            <PagerSettings PreviousPageText="&amp;lt;Anterior" LastPageText="Ultimo&amp;gt;&amp;gt;"
                                FirstPageText="&amp;lt;&amp;lt;Primero" NextPageText="Siguiente&amp;gt;"></PagerSettings>
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemStyle Width="1%"></ItemStyle>
                                    <HeaderStyle Width="1%"></HeaderStyle>
                                    <ItemTemplate>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:BoundField DataField="IdReg" HeaderText="">
                                    <ItemStyle HorizontalAlign="Center" Height="15px" Font-Bold="False" 
                                        CssClass="hidden"></ItemStyle>
                                    <HeaderStyle Height="23px" CssClass="hidden"></HeaderStyle>
                                </asp:BoundField>                                
                                
                                <asp:BoundField DataField="CodigoCliente" HeaderText="Codigo">
                                    <ItemStyle Width="8%" HorizontalAlign="Center" Height="15px" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="8%" Height="23px"></HeaderStyle>
                                </asp:BoundField>
                                                                
                                <asp:BoundField DataField="Producto" HeaderText="Producto">
                                    <ItemStyle Width="10%" HorizontalAlign="Center" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="SubProducto" HeaderText="Sub Producto">
                                    <ItemStyle Width="10%" HorizontalAlign="Center" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="SaldoCapital" HeaderText="Saldo Capital">
                                    <ItemStyle Width="10%" HorizontalAlign="Center" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="Moneda" HeaderText="Moneda">
                                    <ItemStyle Width="8%" HorizontalAlign="Center" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="8%"></HeaderStyle>
                                </asp:BoundField>
                     
                                <asp:BoundField DataField="CalifRiesgo" HeaderText="Calificación de Riesgo">
                                    <ItemStyle Width="8%" HorizontalAlign="Center" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="8%"></HeaderStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="PorProvision" HeaderText="% Provisión">
                                    <ItemStyle Width="10%" HorizontalAlign="Center" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="Sectorista" HeaderText="Sectorista">
                                    <ItemStyle Width="10%" HorizontalAlign="Center" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="Zona" HeaderText="Zona">
                                    <ItemStyle Width="10%" HorizontalAlign="Center" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="Gerencia" HeaderText="Gerente">
                                    <ItemStyle Width="10%" HorizontalAlign="Center" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="diasmorosos" HeaderText="Días de mora">
                                    <ItemStyle Width="10%" HorizontalAlign="Center" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                </asp:BoundField>
                   
                            </Columns>
                            <RowStyle Font-Names="Trebuchet MS" Font-Size="12px" ForeColor="#000066"></RowStyle>
                            <EmptyDataTemplate>
                                <table id="tbSinDatos">
                                    <tbody>
                                        <tr>
                                            <td style="width: 10%">
                                                <asp:Image runat="server" ID="imgWarning" ImageUrl="~/imagenes/Mensajes/alerta.jpg" />
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
                            <PagerStyle CssClass="BarraPie" HorizontalAlign="Left" BackColor="White" ForeColor="#000066" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                        </asp:GridView>
                        <table cellpadding="0" cellspacing="0" style="width: 100%">
                            <tr>
                                <td class="GridViewPie" style="text-align: center">
                                    <asp:Label ID="lbl_Cantidad" runat="server" Text="0"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <asp:HiddenField ID="hd_Codigo" runat="server" />
                    </td>                    
                </tr>
                <tr id="Botones">
                    <td  style="text-align:right;">
                            <asp:Button ID="btn_MantProducto" runat="server" Text="Mantenimiento" 
                                onclick="btn_MantProducto_Click" BackColor="#000080" ForeColor="White"></asp:Button>
                    </td>
                </tr>
            </table>
            <table width="100%" >
                 <tr>
                    <td style="width: 100%;" bgcolor="#c0c0c0">                    
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="width: 40%;" valign="top">
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td class="encebezadotabla-3" style="width: 98%; text-align:center">
                                            DETALLE DEL PRODUCTO
                                            </td>
                                        </tr>
                                    </table>
                                    <table cellpadding="1" cellspacing="0" border="0" style="width: 100%">
                                        <tr id="IdReg">
                                            <td class="celda-titulo" style="width: 30%; text-align: right;">
                                                Codigo&nbsp;
                                            </td>
                                            <td style="text-align: left; width: 70%;">
                                                <asp:TextBox ID="txt_IdReg" runat="server" ForeColor="Black" Height="18px"
                                                    MaxLength="10"  TabIndex="1" 
                                                    Width="98%"></asp:TextBox>
                                            </td>
                                        </tr>
                                       
                                        <tr id="Producto">
                                            <td class="celda-titulo" style="width: 30%; text-align: right;">
                                                Tipo Producto&nbsp;
                                            </td>
                                            <td style="text-align: left; width: 70%;">
                                                <asp:TextBox ID="txt_Producto" runat="server" ForeColor="Black" Height="18px"
                                                    MaxLength="50"  TabIndex="1" 
                                                    Width="98%"></asp:TextBox>

                                            </td>
                                        </tr>

                                        <tr id="MontoDesemb">
                                            <td class="celda-titulo" style="width: 30%; text-align: right;">
                                               Monto Desembolsado&nbsp;
                                            </td>
                                            <td style="text-align: left; width: 70%;">
                                                <asp:TextBox ID="txt_MontoDesemb" runat="server" ForeColor="Black" Height="18px"
                                                    MaxLength="50"  TabIndex="1" 
                                                    Width="98%"></asp:TextBox>
                                            </td>
                                        </tr>

                                        <tr id="TEA">
                                            <td class="celda-titulo" style="width: 30%; text-align: right;">
                                               T.E.A.&nbsp;
                                            </td>
                                            <td style="text-align: left; width: 70%;">
                                                <asp:TextBox ID="txt_TEA" runat="server" ForeColor="Black" Height="18px"
                                                    MaxLength="50"  TabIndex="1" 
                                                    Width="98%"></asp:TextBox>
                                            </td>
                                        </tr>

                                        <tr id="TotCuotasPact">
                                            <td class="celda-titulo" style="width: 30%; text-align: right;">
                                               Total de Cuotas Pactadas&nbsp;
                                            </td>
                                            <td style="text-align: left; width: 70%;">
                                                <asp:TextBox ID="txt_TotCuotasPact" runat="server" ForeColor="Black" Height="18px"
                                                    MaxLength="50"  TabIndex="1" 
                                                    Width="98%"></asp:TextBox>
                                            </td>
                                        </tr>

                                        <tr id="DeuCapitalActual">
                                            <td class="celda-titulo" style="width: 30%; text-align: right;">
                                                Deuda Capital Actual&nbsp;
                                            </td>
                                            <td style="text-align: left; width: 70%;">
                                                <asp:TextBox ID="txt_DeuCapitalActual" runat="server" ForeColor="Black" Height="18px"
                                                    MaxLength="50"  TabIndex="1" 
                                                    Width="98%"></asp:TextBox>
                                            </td>
                                        </tr>

                                        <tr id="CuotasPag">
                                            <td class="celda-titulo" style="width: 30%; text-align: right;">
                                                Cuotas Pagadas&nbsp;
                                            </td>
                                            <td style="text-align: left; width: 70%;">
                                                <asp:TextBox ID="txt_CuotasPag" runat="server" ForeColor="Black" Height="18px"
                                                    MaxLength="50"  TabIndex="1" 
                                                    Width="98%"></asp:TextBox>
                                            </td>
                                        </tr>
                          
                                        <tr id="CuotasVen">
                                            <td class="celda-titulo" style="width: 30%; text-align: right;">
                                                Cuotas Vencidas&nbsp;
                                            </td>
                                            <td style="text-align: left; width: 70%;">
                                                <asp:TextBox ID="txt_CuotasVen" runat="server" ForeColor="Black" Height="18px"
                                                    MaxLength="50"  TabIndex="1" 
                                                    Width="98%"></asp:TextBox>
                                            </td>
                                        </tr>

                                        <tr id="Provisiones">
                                            <td class="celda-titulo" style="width: 30%; text-align: right;">
                                               % Provisiones&nbsp;
                                            </td>
                                            <td style="text-align: left; width: 70%;">
                                                <asp:TextBox ID="txt_PorProvision" runat="server" ForeColor="Black" Height="18px"
                                                    MaxLength="50"  TabIndex="1" 
                                                    Width="98%"></asp:TextBox>
                                            </td>
                                        </tr>
                      
                                        <tr id="dias_mora">
                                            <td class="celda-titulo" style="width: 30%; text-align: right;">
                                               Dias Mora&nbsp;
                                            </td>
                                            <td style="text-align: left; width: 70%;">
                                                <asp:TextBox ID="txt_dias_mora" runat="server" ForeColor="Black" Height="18px"
                                                    MaxLength="50"  TabIndex="1" 
                                                    Width="98%"></asp:TextBox>
                                            </td>
                                        </tr>
                                        
                                        <tr id="FecVenCuotasMasVenc">
                                            <td class="celda-titulo" style="width: 30%; text-align: right;">
                                              Fecha Vcto de la Cuota mas Antigua&nbsp;
                                            </td>
                                            <td style="text-align: left; width: 70%;">
                                                <asp:TextBox ID="txt_FecVenCuotasMasVenc" runat="server" ForeColor="Black" Height="18px"
                                                    MaxLength="50"  TabIndex="1" 
                                                    Width="98%"></asp:TextBox>
                                            </td>
                                        </tr>

                                        <tr id="MontoCuota">
                                            <td class="celda-titulo" style="width: 30%; text-align: right;">
                                               Monto de la Cuota&nbsp;
                                            </td>
                                            <td style="text-align: left; width: 70%;">
                                                <asp:TextBox ID="txt_MontoCuota" runat="server" ForeColor="Black" Height="18px"
                                                    MaxLength="50"  TabIndex="1" 
                                                    Width="98%"></asp:TextBox>
                                            </td>
                                        </tr>
                                                        
                                        <tr id="INTComp">
                                            <td class="celda-titulo" style="width: 30%; text-align: right;">
                                              Interes Compesatorio&nbsp;
                                            </td>
                                            <td style="text-align: left; width: 70%;">
                                                <asp:TextBox ID="txt_INTComp" runat="server" ForeColor="Black" Height="18px"
                                                    MaxLength="50"  TabIndex="1" 
                                                    Width="98%"></asp:TextBox>
                                            </td>
                                        </tr>                                                        
                                                                    
                                        <tr id="INTMor">
                                            <td class="celda-titulo" style="width: 30%; text-align: right;">
                                              Interes Moratorio&nbsp;
                                            </td>
                                            <td style="text-align: left; width: 70%;">
                                                <asp:TextBox ID="txt_INTMor" runat="server" ForeColor="Black" Height="18px"
                                                    MaxLength="50"  TabIndex="1" 
                                                    Width="98%"></asp:TextBox>
                                            </td>
                                        </tr>                                                                    
                                                                                                      
                                        <tr id="Estado">
                                            <td class="celda-titulo" style="width: 30%; text-align: right;">
                                                Estado&nbsp;
                                            </td>
                                            <td style="text-align: left; width: 70%;">
                                                <asp:TextBox ID="txt_Estado" runat="server" ForeColor="Black" Height="18px"
                                                    MaxLength="50"  TabIndex="1" 
                                                    Width="98%"></asp:TextBox>
                                            </td>
                                        </tr>

                                        <tr id="espacio">
                                            <td  style="width: 30%; text-align: right;">
                                                &nbsp;
                                            </td>
                                            <td style="text-align: left; width: 70%;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>

                    </td>
                    <td style="width: 60%;" valign="top">
                        <table cellpadding="1" cellspacing="0" border="0" style="width: 100%">                                    
                            <tr>
                                <td class="encebezadotabla-3" style="width: 98%; text-align:center">
                                GASTOS
                                </td>
                            </tr>                                   
                            <tr id="gastos">
                                <td  style="width: 100%; text-align: center;">
                            <asp:GridView ID="gv_Gastos" runat="server" Width="100%" EnableTheming="True" AutoGenerateColumns="False"
                            AllowSorting="True" PageSize="20" 
                                        onselectedindexchanged="gv_Gastos_SelectedIndexChanged" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" >
                                <FooterStyle BackColor="White" ForeColor="#000066" />
                                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                            <PagerSettings PreviousPageText="&amp;lt;Anterior" LastPageText="Ultimo&amp;gt;&amp;gt;"
                                FirstPageText="&amp;lt;&amp;lt;Primero" NextPageText="Siguiente&amp;gt;"></PagerSettings>
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemStyle Width="1%"></ItemStyle>
                                    <HeaderStyle Width="1%"></HeaderStyle>
                                    <ItemTemplate>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:BoundField DataField="IdReg_ClienteGastos" HeaderText="">
                                    <ItemStyle HorizontalAlign="Left" Height="15px" Font-Bold="False" 
                                        CssClass="hidden"></ItemStyle>
                                    <HeaderStyle Height="23px" CssClass="hidden"></HeaderStyle>
                                </asp:BoundField>                                
                                
                                <asp:BoundField DataField="IdReg_ClienteGastos" HeaderText="Codigo">
                                    <ItemStyle Width="9%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="9%" Height="23px"></HeaderStyle>
                                </asp:BoundField>
                                                                
                                <asp:BoundField DataField="Fecha" HeaderText="Fecha">
                                    <ItemStyle Width="10%" HorizontalAlign="Center" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="RazonSocial" HeaderText="RazonSocial">
                                    <ItemStyle Width="10%" HorizontalAlign="Center" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="Monto" HeaderText="Monto">
                                    <ItemStyle Width="10%" HorizontalAlign="Center" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="tipo_tramite" HeaderText="TipoTramite">
                                    <ItemStyle Width="10%" HorizontalAlign="Center" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                </asp:BoundField>
                     
                                <asp:BoundField DataField="Observacion" HeaderText="Observacion">
                                    <ItemStyle Width="10%" HorizontalAlign="Center" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="FechaRendicion" HeaderText="FechaRendicion">
                                    <ItemStyle Width="10%" HorizontalAlign="Center" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="SAnulad" HeaderText="Estado">
                                    <ItemStyle Width="10%" HorizontalAlign="Center" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                </asp:BoundField>
                   
                            </Columns>
                            <RowStyle Font-Names="Trebuchet MS" Font-Size="12px" ForeColor="#000066"></RowStyle>
                            <EmptyDataTemplate>
                                <table id="tbSinDatos">
                                    <tbody>
                                        <tr>
                                            <td style="width: 10%">
                                                <asp:Image runat="server" ID="imgWarning" ImageUrl="~/imagenes/Mensajes/alerta.jpg" />
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
                            <PagerStyle CssClass="BarraPie" HorizontalAlign="Left" BackColor="White" ForeColor="#000066" />
                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                <SortedDescendingHeaderStyle BackColor="#00547E" />
                        </asp:GridView>
                                </td>                                
                            </tr>                        
                            <tr>
                                <td class="encebezadotabla-3" style="width: 98%; text-align:center">
                                    <table border="0" cellpadding="1" cellspacing="0" style="width: 100%">
                                        <tr ID="IdReg0">
                                            <td class="celda-titulo" style="width: 30%; text-align: right;">
                                                ID&nbsp;
                                            </td>
                                            <td style="text-align: left; width: 70%;">
                                                <asp:TextBox ID="txt_IdReg_ClienteGastos" runat="server" Enabled="False" 
                                                    ForeColor="Black" Height="18px" MaxLength="10" TabIndex="1" Width="98%"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr ID="Empresa">
                                            <td class="celda-titulo" style="width: 30%; text-align: right;">
                                                Fecha&nbsp;
                                            </td>
                                            <td style="text-align: left; width: 70%;">
                                                &nbsp;<asp:TextBox ID="txt_Fecha_gastos" runat="server" 
                                                    Height="18px" MaxLength="10" TabIndex="5" Width="150px" Enabled="false"></asp:TextBox>

                                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" 
                                                    PopupButtonID="imgCal1" TargetControlID="txt_Fecha_gastos" />
                                                <asp:ImageButton ID="imgCal1" runat="Server" AlternateText="Mostrar calendario" 
                                                    ImageUrl="~/imagenes/Calendar.png" />
                                                &nbsp;</td>
                                        </tr>
                                        <tr ID="RUC">
                                            <td class="celda-titulo" style="width: 30%; text-align: right;">
                                                RUC&nbsp;
                                            </td>
                                            <td style="text-align: left; width: 70%;">
                                                <asp:TextBox ID="txt_ruc_gastos" runat="server" ForeColor="Black" Height="18px" 
                                                    MaxLength="11" TabIndex="1" Width="98%"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr ID="Cargo">
                                            <td class="celda-titulo" style="width: 30%; text-align: right; height: 20px;">
                                                Razón Social&nbsp;
                                            </td>
                                            <td style="text-align: left; width: 70%; height: 20px;">
                                                <asp:TextBox ID="txt_RazonSocial" runat="server" ForeColor="Black" 
                                                    Height="18px" MaxLength="60" TabIndex="1" Width="98%"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr ID="FechaIngreso">
                                            <td class="celda-titulo" style="width: 30%; text-align: right;">
                                                Monto</td>
                                            <td style="text-align: left; width: 70%;">
                                                <asp:TextBox ID="txt_Monto" runat="server" ForeColor="Black" Height="18px" 
                                                    MaxLength="50"  onkeydown="return Control_Numero(event)"  TabIndex="1" Width="98%"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr ID="SitLab">
                                            <td class="celda-titulo" style="width: 30%; text-align: right;">
                                                TipoTramite</td>
                                            <td style="text-align: left; width: 70%;">
                                                <asp:DropDownList ID="cmb_tipo_tramite" runat="server" AutoPostBack="True" 
                                                    TabIndex="1" Width="90%">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr ID="Sueldo">
                                            <td class="celda-titulo" style="width: 30%; text-align: right;">
                                                Observacion&nbsp;
                                            </td>
                                            <td style="text-align: left; width: 70%;">
                                                <asp:TextBox ID="txt_Observacion_gastos" runat="server" ForeColor="Black" 
                                                    Height="18px" MaxLength="200" TabIndex="1" Width="98%"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="celda-titulo" style="width: 30%; text-align: right;">
                                                FechaRendición&nbsp;
                                            </td>
                                            <td style="text-align: left; width: 70%;">
                                                <asp:TextBox ID="txt_FechaRendicion" runat="server" 
                                                    Height="18px" MaxLength="10" TabIndex="5" Width="150px" Enabled="false"></asp:TextBox>
                                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" 
                                                    PopupButtonID="imgCal2" TargetControlID="txt_FechaRendicion" />
                                                <asp:ImageButton ID="imgCal2" runat="Server" AlternateText="Mostrar calendario" 
                                                    ImageUrl="~/imagenes/Calendar.png" />
                                            </td>
                                        </tr>
                                        <tr ID="espacio0">
                                            <td style="width: 30%; text-align: right;">
                                                &nbsp;
                                            </td>
                                            <td style="text-align: left; width: 70%;">
                                                <table border="0" cellpadding="1" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td style="text-align: center; width: 306px;">
                                                            &nbsp;<asp:Button ID="btn_Agregar_Gastos" runat="server" BackColor="#000080" 
                                                                ForeColor="White" Text="Agregar" Width="100px" 
                                                                onclick="btn_Agregar_Gastos_Click" />
                                                            &nbsp;<asp:Button ID="btn_Modificar_Gastos" runat="server" BackColor="#000080" 
                                                                ForeColor="White" Text="Modificar" Width="100px" 
                                                                onclick="btn_Modificar_Gastos_Click" />
                                                            &nbsp;&nbsp;<asp:Button ID="btn_Grabar_Gastos" runat="server" BackColor="#000080" 
                                                                ForeColor="White" Text="Grabar" Width="100px" 
                                                                onclick="btn_Grabar_Gastos_Click" />
                                                            &nbsp;<asp:Button ID="btn_Cancelar_Gastos" runat="server" BackColor="#000080" 
                                                                ForeColor="White" Text="Cancelar" Width="100px" 
                                                                onclick="btn_Cancelar_Gastos_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>                        
                            <tr>
                                <td class="encebezadotabla-3" style="width: 98%; text-align: center">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="encebezadotabla-3" style="width: 98%; text-align: center">
                                    GESTION COBRANZA
                                </td>
                            </tr>
                            <tr id="cobranzas" class="GridViewCabecera">
                                <td  style="width: 100%; text-align: center; font-size: 10px;">
                                <asp:GridView ID="gv_GC" runat="server" 
                                        Width="100%"  EnableTheming="True" AutoGenerateColumns="False"
                            AllowSorting="True" PageSize="20" onselectedindexchanged="gv_GC_SelectedIndexChanged" 
                                        Height="110px" style="margin-top: 20px" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" >
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                            <PagerSettings PreviousPageText="&amp;lt;Anterior" LastPageText="Ultimo&amp;gt;&amp;gt;"
                                FirstPageText="&amp;lt;&amp;lt;Primero" NextPageText="Siguiente&amp;gt;"></PagerSettings>
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemStyle Width="1%" CssClass="GridViewCabecera"></ItemStyle>
                                    <HeaderStyle Width="1%"></HeaderStyle>
                                    <ItemTemplate>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                                       
                                
                               
                                <asp:BoundField DataField="IdReg" HeaderText="Codigo" Visible="False">
                                    <ItemStyle Width="9%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="9%" Height="23px"></HeaderStyle>
                                </asp:BoundField>
                                                                
                                <asp:BoundField DataField="AsesorComercial" HeaderText="Asesor Responsable">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="Resultado" HeaderText="Resultado">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="Detalle" HeaderText="Detalle">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                </asp:BoundField>

                                 <asp:BoundField DataField="Comentario" HeaderText="Comentario">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                </asp:BoundField>
                     
                                <%--<asp:BoundField DataField="TipoAgencia" HeaderText="Gestor de Cobranza">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                </asp:BoundField>--%>

     
                                <asp:BoundField DataField="Estado" HeaderText="Estado">
                                    <ItemStyle Width="8%" HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="8%"></HeaderStyle>
                                </asp:BoundField>
                   
                                <asp:BoundField DataField="nIdEstado">
                                <HeaderStyle Width="2%" />
                                <ItemStyle Width="2%" />
                                </asp:BoundField>
                   
                            </Columns>
                            <RowStyle Font-Names="Trebuchet MS" Font-Size="4px" ForeColor="#000066"></RowStyle>
                            <EmptyDataTemplate>
                                <table id="tbSinDatos">
                                    <tbody>
                                        <tr>
                                            <td style="width: 10%">
                                                <asp:Image runat="server" ID="imgWarning" ImageUrl="~/imagenes/Mensajes/alerta.jpg" />
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
                            <PagerStyle CssClass="BarraPie" HorizontalAlign="Left" BackColor="White" ForeColor="#000066" />
                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                        </asp:GridView>                                    
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table width="100%" >
                 <tr>
                    <td style="width: 100%;" bgcolor="#c0c0c0">                    
                    </td>
                </tr>
            </table>


            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr  id="Titulo_Cronograma">
                <td class="encebezadotabla-3" style="width: 98%; text-align:center">
                CRONOGRAMA DE PAGO
                </td>
                </tr>

                <tr id="Tr1">
                    <td style="width: 100%;" valign="top">
                        <asp:GridView ID="gv_Cronograma" runat="server" Width="100%" EnableTheming="True" AutoGenerateColumns="False"
                            AllowSorting="True" PageSize="20" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" >
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                            <PagerSettings PreviousPageText="&amp;lt;Anterior" LastPageText="Ultimo&amp;gt;&amp;gt;"
                                FirstPageText="&amp;lt;&amp;lt;Primero" NextPageText="Siguiente&amp;gt;"></PagerSettings>

                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemStyle Width="1%"></ItemStyle>
                                    <HeaderStyle Width="1%"></HeaderStyle>
                                    <ItemTemplate>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:BoundField DataField="IdReg" HeaderText="">
                                    <ItemStyle HorizontalAlign="Left" Height="15px" Font-Bold="False" 
                                        CssClass="hidden"></ItemStyle>
                                    <HeaderStyle Height="23px" CssClass="hidden"></HeaderStyle>
                                </asp:BoundField>                                
                                
                                <asp:BoundField DataField="IdReg" HeaderText="Codigo">
                                    <ItemStyle Width="9%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="9%" Height="23px"></HeaderStyle>
                                </asp:BoundField>
                                                                
                                <asp:BoundField DataField="NroCuotas" HeaderText="NroCuotas">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="FechaVencimiento" HeaderText="FechaVencimiento">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="FechaPago" HeaderText="FechaPago">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="MontoCuota" HeaderText="MontoCuota">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                </asp:BoundField>
                     
                                <asp:BoundField DataField="CodEstadoCronograma" HeaderText="CodEstadoCronograma">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="Capital" HeaderText="Capital">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="Interes" HeaderText="Interes">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="SaldoCapital" HeaderText="SaldoCapital">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="CodCalificacionSBS" HeaderText="CodCalificacionSBS">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                </asp:BoundField>
                                                              
                            </Columns>
                            

                            <RowStyle Font-Names="Trebuchet MS" Font-Size="12px" ForeColor="#000066"></RowStyle>
                            <EmptyDataTemplate>
                                <table id="tbSinDatos">
                                    <tbody>
                                        <tr>
                                            <td style="width: 10%">
                                                <asp:Image runat="server" ID="imgWarning" ImageUrl="~/imagenes/Mensajes/alerta.jpg" />
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
                            <PagerStyle CssClass="BarraPie" HorizontalAlign="Left" BackColor="White" ForeColor="#000066" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                        </asp:GridView>
                        <table cellpadding="0" cellspacing="0" style="width: 100%">
                            <tr>
                                <td class="GridViewPie" style="text-align: center">
                                    <asp:Label ID="Label3" runat="server" Text="0"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <asp:HiddenField ID="HiddenField2" runat="server" />
                    </td>                    
                </tr>
                <tr id="Tr2">
                    <td  style="text-align:right;">
                            <asp:Button ID="btn_MantCronograma" runat="server" Text="Mantenimiento" 
                                onclick="btn_MantCronograma_Click" BackColor="#000080" ForeColor="White" ></asp:Button>
                    </td>
                </tr>
            </table>
            <table width="100%" >
                 <tr>
                    <td style="width: 100%;" bgcolor="#c0c0c0">                    
                    </td>
                </tr>
            </table>



            


                        
   

        </contenttemplate>
    </asp:UpdatePanel>
    <asp:Panel ID="panelUpdateProgress" runat="server" CssClass="updateProgress">
        <asp:UpdateProgress ID="UpdateProg1" DisplayAfter="0" runat="server">
            <progresstemplate>
                <div style="position: relative; top: 50%; text-align: center;">
                    <asp:Image runat="server" ID="Progres" ImageUrl="~/imagenes/loading.gif" Style="vertical-align: middle"
                        alt="Procesando…" />
                    <asp:Label runat="server" ID="lblprogres" ForeColor="White" Text="Procesando…"></asp:Label>
                </div>
            </progresstemplate>
        </asp:UpdateProgress>
    </asp:Panel>
    <cc1:ModalPopupExtender ID="ModalProgress" runat="server" TargetControlID="panelUpdateProgress"
        BackgroundCssClass="modalBackground" PopupControlID="panelUpdateProgress">
    </cc1:ModalPopupExtender>
</asp:Content>
