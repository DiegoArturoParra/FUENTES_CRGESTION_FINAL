<%@ page title="" language="C#" masterpagefile="~/Master/Ficha.master" autoeventwireup="true" inherits="Estudio_Gestion_08FrmGaranxProduc, App_Web_m4xi2a1f" stylesheettheme="Standard" %>
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
                                onclick="btn_RefreshProducto_Click" BackColor="#000080" ForeColor="White"></asp:Button>
                    </td>
                </tr>
                <tr id="TituloProd">
                <td class="encebezadotabla-3" style="width: 100%; text-align:center; background-color:#006699; color:white;">
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
                            OnSelectedIndexChanged="gv_SelectedIndexChanged" ShowHeader="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
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
                                                                
                                <asp:BoundField DataField="Producto" HeaderText="Producto">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="SubProducto" HeaderText="SubProd">
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
                </tr>
            </table>


                                                    
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="encebezadotabla-3" style="width: 98%; text-align:center">
                    GARANTIA POR PRODUCTO
                    </td>
                </tr>


   
            </table>
      
                            
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="width: 100%; vertical-align: top;">
                        
                        <asp:GridView ID="gv_Garantia" runat="server" Width="100%" EnableTheming="True" AutoGenerateColumns="False"
                        AllowSorting="True" PageSize="20" OnSelectedIndexChanged="gv_SelectedIndexChanged" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                        <PagerSettings PreviousPageText="&amp;lt;Anterior" LastPageText="Ultimo&amp;gt;&amp;gt;"
                            FirstPageText="&amp;lt;&amp;lt;Primero" NextPageText="Siguiente&amp;gt;"></PagerSettings>                                    
                        
                        <Columns>
                                                                                                              
                                    <asp:BoundField DataField="IdReg" HeaderText="">
                                    <ItemStyle HorizontalAlign="Left" Font-Bold="False" 
                                        CssClass="hidden"></ItemStyle>
                                    <HeaderStyle CssClass="hidden"></HeaderStyle>
                                    </asp:BoundField>

                                    <asp:BoundField DataField="IdRegProductos" HeaderText="">
                                    <ItemStyle HorizontalAlign="Left" Font-Bold="False" 
                                        CssClass="hidden"></ItemStyle>
                                    <HeaderStyle CssClass="hidden"></HeaderStyle>
                                    </asp:BoundField>
                                                       
                                    <asp:BoundField DataField="Garantia" HeaderText="Tipo Garantia">
                                    <ItemStyle Width="10%" HorizontalAlign="Left"  Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%" ></HeaderStyle>
                                    </asp:BoundField>

                                    <asp:BoundField DataField="TipoBien" HeaderText="Tipo Bien">
                                    <ItemStyle Width="10%" HorizontalAlign="Left"  Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%" ></HeaderStyle>
                                    </asp:BoundField>

                                    <asp:BoundField DataField="TipoBien" HeaderText="Tipo Bien">
                                    <ItemStyle Width="10%" HorizontalAlign="Left"  Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%" ></HeaderStyle>
                                    </asp:BoundField>

                                    <asp:BoundField DataField="DescripBien" HeaderText="Descrip Bien">
                                    <ItemStyle Width="10%" HorizontalAlign="Left"  Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%" ></HeaderStyle>
                                    </asp:BoundField>            
                                                        
                                    <asp:BoundField DataField="Telefonos" HeaderText="Telefonos">
                                    <ItemStyle Width="10%" HorizontalAlign="Left"  Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%" ></HeaderStyle>
                                    </asp:BoundField>  
                            
                                    <asp:BoundField DataField="Propietarios" HeaderText="Propietarios">
                                    <ItemStyle Width="10%" HorizontalAlign="Left"  Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%" ></HeaderStyle>
                                    </asp:BoundField>  
                            
                                    <asp:BoundField DataField="NombreGarante" HeaderText="Nombre Garante">
                                    <ItemStyle Width="10%" HorizontalAlign="Left"  Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%" ></HeaderStyle>
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
                                    <asp:Label ID="Label2" runat="server" Text="0"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        
                    </td>
                </tr>
                <tr>
                    <td style="width: 100%;" bgcolor="#c0c0c0">                    
                    </td>
                </tr>
                <tr id="botoneraGarantia">
                    <td  style="text-align:right;">
                            <asp:Button ID="btn_MantGarantia" runat="server" Text="Mantenimiento" 
                                onclick="btn_MantGarantia_Click" BackColor="#000080" ForeColor="White" 
                                 ></asp:Button>
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




