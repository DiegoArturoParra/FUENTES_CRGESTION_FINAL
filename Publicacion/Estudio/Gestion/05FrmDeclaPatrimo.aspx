<%@ page title="" language="C#" masterpagefile="~/Master/Ficha.master" autoeventwireup="true" inherits="Estudio_Gestion_05FrmDeclaPatrimo, App_Web_hhkm3gt1" stylesheettheme="Standard" %>
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
                    <td style="width: 60%;" valign="top">
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
                                    <ItemStyle HorizontalAlign="Left" Height="15px" Font-Bold="False" 
                                        CssClass="hidden"></ItemStyle>
                                    <HeaderStyle Height="23px" CssClass="hidden"></HeaderStyle>
                                </asp:BoundField>                                
                                
                                <asp:BoundField DataField="IdReg" HeaderText="Codigo">
                                    <ItemStyle Width="9%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="9%" Height="23px"></HeaderStyle>
                                </asp:BoundField>
                                                                
                                <asp:BoundField DataField="TipoBien" HeaderText="TipoBien">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="PorPropiedad" HeaderText="%Propiedad">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                </asp:BoundField>


                                <asp:BoundField DataField="ValorComercial" HeaderText="ValorComercial">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                </asp:BoundField>


                                <asp:BoundField DataField="Moneda" HeaderText="Moneda">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                </asp:BoundField>
                     
                                <asp:BoundField DataField="PartidaRegistral" HeaderText="PartidaRegistral">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="DatosBien" HeaderText="DatosBien">
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
                                        <tr id="IdReg" class="hidden">
                                            <td class="celda-titulo" style="width: 30%; text-align: right;">
                                                ID&nbsp;
                                            </td>
                                            <td style="text-align: left; width: 70%;">
                                                <asp:TextBox ID="txt_IdReg" runat="server" ForeColor="Black" Height="18px"
                                                    MaxLength="10"  TabIndex="1" 
                                                    Width="98%"></asp:TextBox>
                                            </td>
                                        </tr>

                                        <tr id="TipoBien">
                                            <td class="celda-titulo" style="width: 30%; text-align: right;">
                                                Tipo del Bien&nbsp;
                                            </td>
                                            <td style="text-align: left; width: 70%;">
                                                <asp:DropDownList ID="cmb_TipoBien" runat="server" AutoPostBack="True" TabIndex="1"
                                                Width="90%" >
                                                </asp:DropDownList>
                                            </td>
                                        </tr>


                                        <tr id="Propiedad">
                                            <td class="celda-titulo" style="width: 30%; text-align: right;">
                                                % Propiedad&nbsp;
                                            </td>
                                            <td style="text-align: left; width: 70%;">
                                                <asp:TextBox ID="txt_PorPropiedad" runat="server" ForeColor="Black" Height="18px"
                                                    MaxLength="10"  TabIndex="1" 
                                                    Width="98%"></asp:TextBox>
                                            </td>
                                        </tr>
                                        
                                        <tr id="RUC">
                                            <td class="celda-titulo" style="width: 30%; text-align: right;">
                                                Valor Comercial&nbsp;
                                            </td>
                                            <td style="text-align: left; width: 70%;">
                                                <asp:TextBox ID="txt_ValorComercial" runat="server" ForeColor="Black" Height="18px"
                                                    MaxLength="50"  TabIndex="1" 
                                                    Width="98%"></asp:TextBox>
                                            </td>
                                        </tr>
                                        
                                        <tr id="Cargo">
                                            <td class="celda-titulo" style="width: 30%; text-align: right;">
                                                Moneda&nbsp;
                                            </td>
                                            <td style="text-align: left; width: 70%;">
                                                <asp:TextBox ID="txt_Moneda" runat="server" ForeColor="Black" Height="18px"
                                                    MaxLength="50"  TabIndex="1" 
                                                    Width="98%"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr id="FechaIngreso">
                                            <td class="celda-titulo" style="width: 30%; text-align: right;">
                                                Partida Registral&nbsp;
                                            </td>
                                            <td style="text-align: left; width: 70%;">
                                                <asp:TextBox ID="txt_PartidaRegistral" runat="server" ForeColor="Black" Height="18px"
                                                    MaxLength="50"  TabIndex="1" 
                                                    Width="98%"></asp:TextBox>
                                            </td>
                                        </tr>


                                        <tr id="Sueldo">
                                            <td class="celda-titulo" style="width: 30%; text-align: right;">
                                                Datos del Bien&nbsp;
                                            </td>
                                            <td style="text-align: left; width: 70%;">
                                                <asp:TextBox ID="txt_DatosBien" runat="server" ForeColor="Black" Height="50px"
                                                    MaxLength="2000"  TabIndex="1" 
                                                    Width="98%" TextMode="MultiLine"></asp:TextBox>
                                            </td>
                                        </tr>

                                        <tr id="Obs">
                                            <td class="celda-titulo" style="width: 30%; text-align: right;">
                                                Observación&nbsp;
                                            </td>
                                            <td style="text-align: left; width: 70%;">
                                                <asp:TextBox ID="txt_Observacion" runat="server" ForeColor="Black" Height="30px"
                                                    MaxLength="200"  TabIndex="1" 
                                                    Width="98%" TextMode="MultiLine"></asp:TextBox>
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
                                        OnClick="btn_Agregar_Click" BackColor="#000080" ForeColor="White" />
                                    &nbsp;<asp:Button ID="btn_Modificar" runat="server" Text="Modificar"
                                        Width="100px" OnClick="btn_Modificar_Click" BackColor="#000080" 
                                        ForeColor="White" />
                                    &nbsp;&nbsp;<asp:Button ID="btn_Grabar" runat="server" 
                                        Text="Grabar" Width="100px" onclick="btn_Grabar_Click" BackColor="#000080" 
                                        ForeColor="White" />
                                    &nbsp;<asp:Button ID="btn_Cancelar" runat="server"
                                        Text="Cancelar" Width="100px" onclick="btn_Cancelar_Click" 
                                        BackColor="#000080" ForeColor="White" />
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
