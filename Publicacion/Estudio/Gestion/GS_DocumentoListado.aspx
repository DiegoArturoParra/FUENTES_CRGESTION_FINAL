<%@ page language="C#" masterpagefile="~/Master/Popup.master" autoeventwireup="true" inherits="Estudio_Gestion_GS_DocumentoListado, App_Web_hhkm3gt1" stylesheettheme="Standard" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="GMDatePicker" Namespace="GrayMatterSoft" TagPrefix="cc2" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="cc3" %>
<%@ MasterType VirtualPath="~/Master/Popup.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DefaultContent" runat="server">
    <script type="text/javascript">

    </script>

    <table id="tbContenedor" style="width:100%; border:0px;" cellpadding="0" cellspacing="0">
        <tr>
            <td style="width: 100%">
                <table id="tbContenedorDatos" cellpadding="0" cellspacing="0" style="width: 100%">
                    <tr class="">
                        <td align="center" style="width: 100%">
                            <asp:UpdatePanel ID="upBotonera" runat="server" UpdateMode="Conditional">
                                <contenttemplate>
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
                                </contenttemplate>
                            </asp:UpdatePanel>
                            <asp:UpdatePanel ID="upGvUsuario" runat="server" UpdateMode="Conditional">
                                <contenttemplate>
                                    <table id="tbToolbarSuperior" cellpadding="0" cellspacing="0" class="cabeceraScroll" 
                                        style="width: 100%">
                                        <tbody>
                                            <tr>
                                                <td>

                                                    <table border="0" cellpadding="0" cellspacing="0" class="cabeceraScroll" style="width: 100%">
                                                      <tr>
                                                        <td style="height: 28px; width: 348px;">
                                                            <table cellpadding="1" cellspacing="0" class="clsToolbar" width="120px">
                                                                <tr>
                                                                    <td style="text-align: center" valign="middle" width="10">
                                                                        <asp:Image ID="imgGrip" runat="server" ImageUrl="~/Imagenes/toolbar.grip.gif" />
                                                                    </td>
                                                                    <td width="23">
                                                                        &nbsp;</td>
                                                                    <td style="text-align: center" valign="middle" width="10">
                                                                        <asp:Image ID="imgSeparator" runat="server" 
                                                                            ImageUrl="~/Imagenes/toolbar.grip.gif" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <%--<td style="height: 28px; width: 382px;">
                                                            <asp:CheckBox ID="chk_TODOS" runat="server" 
                                                                ToolTip="Imprime o Exporta Todos los registros (puede demorar varios minutos)" />
                                                            Mostrar / Exportar Todos</td>--%>
                                                        <td style="width: 249px; height: 28px">
                                                            <asp:Label ID="lblPaginado" runat="server">Paginado</asp:Label>&nbsp;&nbsp;
                                                            <asp:DropDownList ID="ddlPaginado" runat="server" AutoPostBack="True" 
                                                                Font-Size="Small" OnSelectedIndexChanged="ddlPaginado_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                          </td>
                                                        <td style="height: 28px; width: 298px;">
                                                            <asp:Label ID="lblPaginaIr" runat="server">Ir a </asp:Label>&nbsp;&nbsp;
                                                            <asp:DropDownList ID="ddlPaginaIr" runat="server" AutoPostBack="True" 
                                                                Font-Size="Small" Height="16px" 
                                                                OnSelectedIndexChanged="ddlPaginaIr_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                          </td>
                                                        <td style="height: 28px;">
                                                            &nbsp;</td>
                                                      </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <%--<table class="cabeceraScroll" style="width: 100%" > 
                                        <tr>
                                            <td style="height: 32px">   
                                            <table width="40%" border="0" cellpadding="0" cellspacing="0"  class="cabeceraScroll"  align=center>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblTipoDocumento" runat="server">Tipo de Documento: </asp:Label>&nbsp;&nbsp;
                                                        <asp:DropDownList ID="cboTipoDocumento" runat="server" AutoPostBack="True" 
                                                            Font-Size="Small" OnSelectedIndexChanged="cboTipoDocumento_SelectedIndexChanged" >
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                            </table>
                                            </td>
                                        </tr>
                                    </table>--%>
                                    <asp:GridView ID="gv" runat="server" Width="100%" EnableTheming="True" OnSorting="gv_Sorting"
                                        OnRowDataBound="gv_RowDataBound" OnPageIndexChanging="gv_PageIndexChanging" 
                                        AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                                        <FooterStyle BackColor="White" ForeColor="#000066" />
                                        <HeaderStyle BackColor="#2F63CB" Font-Bold="True" ForeColor="White" />
                                        <PagerSettings PreviousPageText="&amp;lt;Anterior" LastPageText="Ultimo&amp;gt;&amp;gt;"
                                            FirstPageText="&amp;lt;&amp;lt;Primero" NextPageText="Siguiente&amp;gt;"></PagerSettings>
                                        <Columns>

                                            
                                            <asp:BoundField DataField="nombre" HeaderText="Nombre" SortExpression="nombre">
                                                <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Middle" Font-Bold="False">
                                                </ItemStyle>
                                                <HeaderStyle Width="10%" CssClass=""></HeaderStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Descripcion" HeaderText="Descripción" SortExpression="Descripcion">
                                                <ItemStyle Width="70%" HorizontalAlign="Left" VerticalAlign="Middle" Font-Bold="False">
                                                </ItemStyle>
                                                <HeaderStyle Width="70%" CssClass=""></HeaderStyle>
                                            </asp:BoundField>

                                            <asp:BoundField DataField="Pie" HeaderText="Pie" SortExpression="Pie">
                                                <ItemStyle Width="20%" HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                                <HeaderStyle Width="20%" CssClass=""></HeaderStyle>
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
                                </contenttemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%; text-align: center">
                            <asp:UpdateProgress ID="uprogGvUsuario" runat="server" AssociatedUpdatePanelID="upGvUsuario"
                                DisplayAfter="250">
                                <progresstemplate>
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
                                </progresstemplate>
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