<%@ page title="" language="C#" masterpagefile="~/Master/Ficha.master" autoeventwireup="true" inherits="Estudio_Gestion_07FrmClieProdAval, App_Web_kou4i3xh" stylesheettheme="Standard" %>
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
            <table width="30%" border="0" cellpadding="0" cellspacing="0">
                <tr id="Botones">
                    <td  style="text-align:left;">
                            <asp:Button ID="btn_RefreshProducto" runat="server" Text="Refrescar" 
                                onclick="btn_RefreshProducto_Click" BackColor="#1F529E" ForeColor="White"></asp:Button>
                    </td>
                </tr>
                <tr id="TituloProd">
                <td class="encebezadotabla-3" style="width: 100%; text-align:center">
                PRODUCTO DEL CLIENTE
                </td>
                </tr>
            </table>
            <table width="30%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="width: 100%;" valign="top">
                        <asp:GridView ID="gv" runat="server" skinId="Mini" Width="100%" 
                            EnableTheming="True" AutoGenerateColumns="False"
                            AllowSorting="True" PageSize="20" 
                            OnSelectedIndexChanged="gv_SelectedIndexChanged" ShowHeader="False">
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
                </tr>
            </table>


            <table width="100%" >
                 <tr>
                    <td style="width: 100%;" bgcolor="#c0c0c0">                    
                    </td>
                </tr>
            </table>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr id="Titulo_Aval">
                    <td class="encebezadotabla-3" style="width: 98%; text-align:center">
                    DATOS DEL AVAL/FIADOR
                    </td>
                </tr>
                <tr id="GridAval">
                    <td style="width: 100%;" valign="top">
                        <asp:GridView ID="gv_Aval" runat="server" Width="100%" EnableTheming="True" AutoGenerateColumns="False"
                            AllowSorting="True" PageSize="20" 
                            onselectedindexchanged="gv_Aval_SelectedIndexChanged" >
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
                                                                
                                <asp:BoundField DataField="DNI" HeaderText="DNI">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="Nombres" HeaderText="Nombres">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="StatusLab" HeaderText="StatusLab">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="Telefonos" HeaderText="Telefonos">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                </asp:BoundField>
                     
                                <asp:BoundField DataField="Observacion" HeaderText="Observacion">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="Estado" HeaderText="Estado">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                </asp:BoundField>                              
                            </Columns>

                            <RowStyle Font-Names=" Times New Roman" Font-Size="12px"></RowStyle>
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
                                    <asp:Label ID="Label1" runat="server" Text="0"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <asp:HiddenField ID="hd_IdRegProdAval" runat="server" />
                    </td>                    
                </tr>
                <tr id="BotonesAval">
                    <td  style="text-align:right;">
                            <asp:Button ID="btn_MantAval" runat="server" Text="Mantenimiento" 
                                onclick="btn_MantAval_Click" BackColor="#1F529E" ForeColor="White" ></asp:Button>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="width: 50%;" valign="top">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr  id="Titulo_avalPatri">
                    <td class="encebezadotabla-3" style="width: 98%; text-align:center">
                    AVAL-DECLARACION PATRIMONIAL
                    </td>
                    </tr>


                    <tr id="grid_avalPatri">
                    <td style="width: 100%;" valign="top">
                        <asp:GridView ID="gv_AvalPatri" runat="server" Width="100%" EnableTheming="True" AutoGenerateColumns="False"
                            AllowSorting="True" PageSize="20" >
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
                                    <asp:Label ID="Label4" runat="server" Text="0"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <asp:HiddenField ID="hd_IdRegAvalPatri" runat="server" />
                    </td>                    
                    </tr>
                    <tr id="botonera_AvalPatri">
                    <td  style="text-align:right;">
                            <asp:Button ID="btn_MantAvalPatri" runat="server" Text="Mantenimiento" 
                                onclick="btn_MantAvalPatri_Click" BackColor="#1F529E" ForeColor="White" ></asp:Button>
                    </td>
                    </tr>
                    </table>


                    </td>
                    <td style="width: 50%;" valign="top">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr  id="Titulo_avalDireccion">
                        <td class="encebezadotabla-3" style="width: 98%; text-align:center">
                        AVAL-DIRECCION
                        </td>
                        </tr>

                        <tr id="grid_avalDireccion">
                            <td style="width: 100%;" valign="top">
                                <asp:GridView ID="gv_AvalDireccion" runat="server" Width="100%" EnableTheming="True" AutoGenerateColumns="False"
                                    AllowSorting="True" PageSize="20" >
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
                                
                                
                                        <asp:BoundField DataField="TipoDir" HeaderText="Tipo Dir">
                                            <ItemStyle Width="10%" HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                            <HeaderStyle Width="10%"></HeaderStyle>
                                        </asp:BoundField>

                                        <asp:BoundField DataField="Dir" HeaderText="Dirección">
                                            <ItemStyle Width="30%" HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                            <HeaderStyle Width="30%"></HeaderStyle>
                                        </asp:BoundField>

                                        <asp:BoundField DataField="ubigeo" HeaderText="Ubigeo">
                                            <ItemStyle Width="10%" HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                            <HeaderStyle Width="10%"></HeaderStyle>
                                        </asp:BoundField>

                                        <asp:BoundField DataField="Referencia" HeaderText="Referencia">
                                            <ItemStyle Width="10%" HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                            <HeaderStyle Width="10%"></HeaderStyle>
                                        </asp:BoundField>

                                        <asp:BoundField DataField="FechaRegistra" HeaderText="Registro" 
                                            DataFormatString="{0:d}">
                                            <ItemStyle Width="10%" HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                            <HeaderStyle Width="10%"></HeaderStyle>
                                        </asp:BoundField>

                                        <asp:BoundField DataField="GeoX" HeaderText="Geo Ref">
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
                                            <asp:Label ID="Label5" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <asp:HiddenField ID="hd_IdRegAvalDirec" runat="server" />
                            </td>                    
                        </tr>
                        <tr id="botonera_avaldireccion">
                            <td  style="text-align:right;">
                                    <asp:Button ID="btn_MantAvalDirec" runat="server" Text="Mantenimiento" 
                                        onclick="btn_MantAvalDirec_Click" BackColor="#1F529E" ForeColor="White" ></asp:Button>
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






