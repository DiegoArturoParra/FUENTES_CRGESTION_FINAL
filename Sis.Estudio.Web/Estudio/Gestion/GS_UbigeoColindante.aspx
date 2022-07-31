<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Ceem.master" AutoEventWireup="true" CodeFile="GS_UbigeoColindante.aspx.cs" Inherits="Estudio_Gestion_GS_UbigeoColindante" %>

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
        <td style="height: 28px; width: 93px;">
            &nbsp;&nbsp;
        </td>
        <td style="height: 28px;">
            <asp:Button ID="btnBuscar" runat="server" CausesValidation="False" 
                OnClick="btnBuscar_Click" style="height: 26px" Text="Buscar" 
                Width="120px" BackColor="#000080" ForeColor="White" />
            <asp:Button ID="btnEliminar" runat="server" CausesValidation="False" 
               style="height: 26px" Text="Eliminar" Width="120px" 
                onclick="btnEliminar_Click" BackColor="#000080" ForeColor="White" />
            <asp:Button ID="btnAgregar" runat="server" CausesValidation="False" 
                style="height: 26px" Text="Agregar" 
                Width="120px" onclick="btnAgregar_Click" BackColor="#000080" 
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
                                                        <td align="left" style="text-align: center;" bgcolor="#CCCCCC" colspan="2">
                                                            Ubigeo Central</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 282px">
                                                            Departamento:</td>
                                                        <td align="left" width="">
                                                            <asp:DropDownList ID="cmb_Departamento_central" runat="server" TabIndex="6" 
                                                                Width="100%"   AutoPostBack="True"  
                                                                onselectedindexchanged="cmb_Departamento_central_SelectedIndexChanged" 
                                                                style="height: 22px">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 282px">
                                                            Provincia:</td>
                                                        <td align="left" width="">
                                                            <asp:DropDownList ID="cmb_Provincia_central" runat="server" TabIndex="6" 
                                                                Width="100%"     AutoPostBack="True"  
                                                                onselectedindexchanged="cmb_Provincia_central_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 282px">
                                                            Distrito:</td>
                                                        <td align="left" width="">
                                                            <asp:DropDownList ID="cmb_Distrito_central" runat="server" TabIndex="6" 
                                                                Width="100%">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 282px">
                                                            &nbsp;</td>
                                                        <td align="left" width="">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="text-align: center;" bgcolor="#CCCCCC" colspan="2">
                                                            Ubigeo Colindante</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 282px">
                                                            Departamento:</td>
                                                        <td align="left" width="">
                                                            <asp:DropDownList ID="cmb_Departamento_colindante" runat="server" 
                                                                TabIndex="6"    AutoPostBack="True"  
                                                                Width="100%" 
                                                                onselectedindexchanged="cmb_Departamento_colindante_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 282px">
                                                            Provincia:</td>
                                                        <td align="left" width="">
                                                            <asp:DropDownList ID="cmb_Provincia_colindante" runat="server" TabIndex="6"   AutoPostBack="True"  
                                                                Width="100%" 
                                                                onselectedindexchanged="cmb_Provincia_colindante_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 282px">
                                                            Distrito:</td>
                                                        <td align="left" width="">
                                                            <asp:DropDownList ID="cmb_Distrito_colindante" runat="server" TabIndex="6" 
                                                                Width="100%">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 282px">
                                                            &nbsp;</td>
                                                        <td align="left" width="">
                                                            &nbsp;</td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>


                                    <asp:GridView ID="gv" runat="server" Width="100%" EnableTheming="True" 
                                        
                                        AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True" 
                                        PageSize="20" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                                        <FooterStyle BackColor="White" ForeColor="#000066" />
                                        <HeaderStyle BackColor="#2F63CB" Font-Bold="True" ForeColor="White" />
                                        <PagerSettings PreviousPageText="&amp;lt;Anterior" LastPageText="Ultimo&amp;gt;&amp;gt;"
                                            FirstPageText="&amp;lt;&amp;lt;Primero" NextPageText="Siguiente&amp;gt;"></PagerSettings>
                                        <Columns>




                                            <asp:TemplateField ShowHeader="False">
                                                <ItemStyle Width="1%"></ItemStyle>
                                                <HeaderStyle Width="1%" CssClass=""></HeaderStyle>
                                                <ItemTemplate>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:BoundField DataField="id" HeaderText="id" SortExpression="">
                                                <ItemStyle Width="5%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                                <HeaderStyle Width="5%" CssClass="" Height="22px"></HeaderStyle>
                                            </asp:BoundField>

                                            <asp:BoundField DataField="ubigeo_central" HeaderText="ubigeo_central" SortExpression="">
                                                <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                                <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                                            </asp:BoundField>

                                            <asp:BoundField DataField="ubigeo_alrededor" HeaderText="ubigeo_alrededor" SortExpression="">
                                                <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                                <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                                            </asp:BoundField>

                                            <asp:BoundField DataField="departamento" HeaderText="departamento" SortExpression="">
                                                <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                                <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                                            </asp:BoundField>

                                            <asp:BoundField DataField="provincia" HeaderText="provincia" SortExpression="">
                                                <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                                <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                                            </asp:BoundField>

                                            <asp:BoundField DataField="distrito" HeaderText="distrito" SortExpression="">
                                                <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                                <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                                            </asp:BoundField>

                                            <asp:BoundField DataField="distrito_alrededor" HeaderText="distrito_alrededor" SortExpression="">
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
                                    <br />













                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnBuscar" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr class="Etiqueta">
                        <td align="center" style="width: 100%">
                            &nbsp;</td>
                    </tr>
                    <tr class="Etiqueta">
                        <td align="center" style="width: 100%">
                            &nbsp;</td>
                    </tr>
                    <tr class="Etiqueta">
                        <td align="center" style="width: 100%">
                            &nbsp;</td>
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
                            
                            
                            
                            
                            
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 100%">


                                    &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 100%">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>



