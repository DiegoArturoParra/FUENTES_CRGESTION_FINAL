<%@ page title="" language="C#" masterpagefile="~/Master/Ficha.master" autoeventwireup="true" inherits="Estudio_Gestion_06FrmProduClienteDet, App_Web_kou4i3xh" stylesheettheme="Standard" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/Master/Ficha.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../javascript/jquery-2.1.1.min.js" type="text/javascript"></script>
    <script src="../../javascript/jsUpdateProgress.js" type="text/javascript"></script>
    <script type="text/javascript">
        var ModalProgress = '<%= ModalProgress.ClientID %>';
    </script>
    <script src="../../javascript/jsUpdateProgress.js" type="text/javascript"></script>
    <input id="hdnContinuar" name="hdnContinuar" style="width: 80px; height: 10px" type="hidden" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <contenttemplate>
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td class="encebezadotabla-3" style="width: 98%; text-align:center">
                    Detalle Producto
                </td>
            </tr>
            </table>
            <table width="100%" border="0" cellpadding="0" cellspacing="0">         
                <tr>
                    <td style="width: 60%;" valign="top">
                        <asp:GridView ID="gv" runat="server" Width="100%" EnableTheming="True" AutoGenerateColumns="False"
                            AllowSorting="True" PageSize="20" OnSelectedIndexChanged="gv_SelectedIndexChanged">
                            <PagerSettings PreviousPageText="&amp;lt;Anterior" Mode="NextPreviousFirstLast" LastPageText="Ultimo&amp;gt;&amp;gt;"
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
                                                                
                                <asp:BoundField DataField="Producto" HeaderText="Producto">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="SubProducto" HeaderText="SubProd">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="SaldoCapital" HeaderText="SaldoCapital">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="Moneda" HeaderText="Moneda">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                </asp:BoundField>
                     
                                <asp:BoundField DataField="CalifRiesgo" HeaderText="Calif_Riesgo">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="PorProvision" HeaderText="%Prov">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="Sectorista" HeaderText="Sectorista">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="Zona" HeaderText="Zona">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="Gerencia" HeaderText="Gerente">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="DiasMora" HeaderText="DiasMora">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                </asp:BoundField>
                   
                            </Columns>
                            <RowStyle Font-Names="Times New Roman" Font-Size="12px"></RowStyle>
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
                            <SelectedRowStyle CssClass="selectedrow"></SelectedRowStyle>
                            <AlternatingRowStyle />
                            <PagerStyle CssClass="BarraPie" HorizontalAlign="Center" />
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
                    <td style="width: 40%;" valign="top">
                        <table width="100%" >
                            <tr>
                                <td style="width: 100%;" align="center">
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
                                                Producto&nbsp;
                                            </td>
                                            <td style="text-align: left; width: 70%;">
                                                <asp:DropDownList ID="cmb_Producto" runat="server" AutoPostBack="True" TabIndex="1"
                                                Width="90%" onselectedindexchanged="cmb_Producto_SelectedIndexChanged" >
                                                </asp:DropDownList>
                                            </td>
                                        </tr>

                                                 
                                        <tr id="SubProducto">
                                            <td class="celda-titulo" style="width: 30%; text-align: right;">
                                                Sub-Producto&nbsp;
                                            </td>
                                            <td style="text-align: left; width: 70%;">
                                                <asp:DropDownList ID="cmb_SubProducto" runat="server" AutoPostBack="True" TabIndex="1"
                                                Width="90%" >
                                                </asp:DropDownList>
                                            </td>
                                        </tr>

                                        <tr id="CodigoInterno">
                                            <td class="celda-titulo" style="width: 30%; text-align: right;">
                                                Codigo Interno&nbsp;
                                            </td>
                                            <td style="text-align: left; width: 70%;">
                                                <asp:TextBox ID="txt_CodigoInterno" runat="server" ForeColor="Black" Height="18px"
                                                    MaxLength="50"  TabIndex="1" 
                                                    Width="98%"></asp:TextBox>
                                            </td>
                                        </tr>


                                        <tr id="SaldoCapital">
                                            <td class="celda-titulo" style="width: 30%; text-align: right;">
                                                Saldo Capital&nbsp;
                                            </td>
                                            <td style="text-align: left; width: 70%;">
                                                <asp:TextBox ID="txt_SaldoCapital" runat="server" ForeColor="Black" Height="18px"
                                                    MaxLength="50"  TabIndex="1" 
                                                    Width="98%"></asp:TextBox>
                                            </td>
                                        </tr>
                                        
                                        <tr id="Cargo">
                                            <td class="celda-titulo" style="width: 30%; text-align: right;">
                                                Moneda&nbsp;
                                            </td>
                                            <td style="text-align: left; width: 70%;">
                                                <asp:DropDownList ID="cmb_Moneda" runat="server" AutoPostBack="True" TabIndex="1"
                                                Width="90%" >
                                                </asp:DropDownList>

                                            </td>
                                        </tr>
                                        <tr id="CalificacionRiesgo">
                                            <td class="celda-titulo" style="width: 30%; text-align: right;">
                                                Calificación Riesgo&nbsp;
                                            </td>
                                            <td style="text-align: left; width: 70%;">
                                                <asp:TextBox ID="txt_CalifRiesgo" runat="server" ForeColor="Black" Height="18px"
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

                                        <tr id="Sucursal">
                                            <td class="celda-titulo" style="width: 30%; text-align: right;">
                                               Sucursal&nbsp;
                                            </td>
                                            <td style="text-align: left; width: 70%;">
                                                <asp:DropDownList ID="cmb_Sucursal" runat="server" AutoPostBack="True" TabIndex="1"
                                                Width="90%" >
                                                </asp:DropDownList>
                                            </td>
                                        </tr>

                                        <tr id="Gerente">
                                            <td class="celda-titulo" style="width: 30%; text-align: right;">
                                               Gerente&nbsp;
                                            </td>
                                            <td style="text-align: left; width: 70%;">
                                                <asp:DropDownList ID="cmb_Gerente" runat="server" AutoPostBack="True" TabIndex="1"
                                                Width="90%" onselectedindexchanged="cmb_Gerente_SelectedIndexChanged" >
                                                </asp:DropDownList>
                                            </td>
                                        </tr>

                                        <tr id="Zona">
                                            <td class="celda-titulo" style="width: 30%; text-align: right;">
                                               Zona&nbsp;
                                            </td>
                                            <td style="text-align: left; width: 70%;">
                                                <asp:DropDownList ID="cmb_Zona" runat="server" AutoPostBack="True" TabIndex="1"
                                                Width="90%" onselectedindexchanged="cmb_Zona_SelectedIndexChanged" >
                                                </asp:DropDownList>
                                            </td>
                                        </tr>

                                        <tr id="Sectorista">
                                            <td class="celda-titulo" style="width: 30%; text-align: right;">
                                               Sectorista&nbsp;
                                            </td>
                                            <td style="text-align: left; width: 70%;">
                                                <asp:DropDownList ID="cmb_Sectorista" runat="server" AutoPostBack="True" TabIndex="1"
                                                Width="90%" >
                                                </asp:DropDownList>
                                            </td>
                                        </tr>


                                        <tr id="DiasMora">
                                            <td class="celda-titulo" style="width: 30%; text-align: right;">
                                               Dias Mora&nbsp;
                                            </td>
                                            <td style="text-align: left; width: 70%;">
                                                <asp:TextBox ID="txt_DiasMora" runat="server" ForeColor="Black" Height="18px"
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
                                                                                                      
                                        <tr id="Estado">
                                            <td class="celda-titulo" style="width: 30%; text-align: right;">
                                                Estado&nbsp;
                                            </td>
                                            <td style="text-align: left; width: 70%;">
                                                <asp:DropDownList ID="cmb_Estado" runat="server" AutoPostBack="True" TabIndex="1"
                                                Width="90%" >
                                                    <asp:ListItem Value="s">Habilitado</asp:ListItem>
                                                    <asp:ListItem Value="n">Inactivo</asp:ListItem>
                                                </asp:DropDownList>
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
                            </tr>
                        </table>
                        <table width="100%" cellpadding="1" cellspacing="0" border="0">
                            <tr>
                                <td style="text-align: center;">
                                    &nbsp;<asp:Button ID="btn_Agregar" runat="server" Text="Agregar" Width="100px" 
                                        OnClick="btn_Agregar_Click" BackColor="#1F529E" ForeColor="White" />
                                    &nbsp;<asp:Button ID="btn_Modificar" runat="server" Text="Modificar"
                                        Width="100px" OnClick="btn_Modificar_Click" BackColor="#1F529E" 
                                        ForeColor="White" />
                                    &nbsp;&nbsp;<asp:Button ID="btn_Grabar" runat="server" 
                                        Text="Grabar" Width="100px" onclick="btn_Grabar_Click" BackColor="#1F529E" 
                                        ForeColor="White" />
                                    &nbsp;<asp:Button ID="btn_Cancelar" runat="server"
                                        Text="Cancelar" Width="100px" onclick="btn_Cancelar_Click" 
                                        BackColor="#1F529E" ForeColor="White" />
                                    &nbsp;<asp:Button ID="btn_Retornar" runat="server"
                                        Text="Retornar" Width="100px" onclick="btn_Retornar_Click" 
                                        BackColor="#1F529E" ForeColor="White"  />
                                </td>
                            </tr>
                        </table>
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


