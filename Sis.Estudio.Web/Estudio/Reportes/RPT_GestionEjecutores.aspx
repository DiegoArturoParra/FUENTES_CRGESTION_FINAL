<%@ Page Language="C#" MasterPageFile="~/Master/Ceem.master" AutoEventWireup="true"
    CodeFile="RPT_GestionEjecutores.aspx.cs" Inherits="Estudio_Reportes_RPT_GestionEjecutores" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="GMDatePicker" Namespace="GrayMatterSoft" TagPrefix="cc2" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="cc3" %>
<%@ MasterType VirtualPath="~/Master/Ceem.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="DefaultContent" runat="Server">
    <script type="text/javascript">
    </script>
    <asp:UpdatePanel ID="upGvUsuario" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table id="Botones" border="0" cellpadding="0" cellspacing="0" class="cabeceraScroll"
                width="100%">
                <tr>
                    <td align="left" style="width: 100%;" >
                        <asp:Button ID="btn_Excel" runat="server" BackColor="#000080" BorderStyle="Ridge"
                            CausesValidation="False" Font-Names="Trebuchet MS" Font-Size="9pt" ForeColor="White"
                            Height="25px" OnClick="btn_Excel_Click" Text="Excel" Width="90px" />
                        <asp:Button ID="btn_Imprimir" runat="server" BackColor="#000080" BorderStyle="Ridge"
                            CausesValidation="False" Font-Names="Trebuchet MS" Font-Size="9pt" ForeColor="White"
                            Height="25px" OnClick="btn_Imprimir_Click" Text="Imprimir" Width="90px" />


                        <asp:HiddenField ID="HD_Continuar" runat="server" />

                        <input id="hdnContinuar" name="hdnContinuar" style="width: 80px; height: 10px" type="hidden" />
                    </td>
                </tr>
            </table>
            <table id="ControlesSuperior" border="0" cellpadding="0" cellspacing="0" class="cabeceraScroll" width="100%">
                <tr>
                    <td align="center" style="width: 100%;">
                        <table id="Controles"  align="center" border="0" cellpadding="1" cellspacing="1"
                            width="800px">
                            <tr id="asesor">
                                <td class="labeltextonegro" style="width: 35%; text-align: left;" valign="top">
                                    ASESOR:&nbsp;
                                </td>
                                <td class="" style="width: 65%; text-align: left;" valign="top">
                                    <asp:Label ID="lbl_Asesor" runat="server" Text="Asesor"></asp:Label>
                                </td>
                            </tr>
                            <tr id="SW">
                                <td class="labeltextonegro" style="text-align: left;" valign="middle">
                                    PERIODO:&nbsp;
                                </td>
                                <td class="" style="text-align: left;" valign="top">
                                    <asp:DropDownList ID="cmb_TipoSW" runat="server" Font-Size="Small" TabIndex="3" Width="100%"
                                        AutoPostBack="True" OnSelectedIndexChanged="cmb_TipoSW_SelectedIndexChanged">
                                        <asp:ListItem Value="1">Año-Mes</asp:ListItem>
                                        <asp:ListItem Value="0">Rango Fecha</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr id="AnioMes">
                                <td class="labeltextonegro" style="text-align: right;" valign="middle">
                                    &nbsp;
                                </td>
                                <td class="" valign="top">
                                    <div id="Div1">
                                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td style="width: 10%; text-align: left;">
                                                    <asp:Label ID="lbl_Anio" runat="server" Text="Año:" Font-Size="X-Small"></asp:Label>
                                                </td>
                                                <td style="width: 30%; text-align: left;">
                                                    <asp:DropDownList ID="cmb_Anio" runat="server" Font-Size="Small" TabIndex="3" 
                                                        Width="98%" onselectedindexchanged="cmb_Anio_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 10%; text-align: left;">
                                                </td>
                                                <td style="width: 10%; text-align: left;">
                                                    <asp:Label ID="lbl_Mes" runat="server" Text="Mes:" Font-Size="X-Small"></asp:Label>
                                                </td>
                                                <td style="width: 30%; text-align: left;">
                                                    <asp:DropDownList ID="cmb_Mes" runat="server" Font-Size="Small" TabIndex="3" Width="98%">
                                                        <asp:ListItem Value="1">Enero</asp:ListItem>
                                                        <asp:ListItem Value="2">Febrero</asp:ListItem>
                                                        <asp:ListItem Value="3">Marzo</asp:ListItem>
                                                        <asp:ListItem Value="4">Abril</asp:ListItem>
                                                        <asp:ListItem Value="5">Mayo</asp:ListItem>
                                                        <asp:ListItem Value="6">Junio</asp:ListItem>
                                                        <asp:ListItem Value="7">Julio</asp:ListItem>
                                                        <asp:ListItem Value="8">Agosto</asp:ListItem>
                                                        <asp:ListItem Value="9">Septiembre</asp:ListItem>
                                                        <asp:ListItem Value="10">Octubre</asp:ListItem>
                                                        <asp:ListItem Value="11">Noviembre</asp:ListItem>
                                                        <asp:ListItem Value="12">Diciembre</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 10%; text-align: left;">
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                            <tr id="RangoFecha">
                                <td class="labeltextonegro" style="text-align: right;" valign="middle">
                                </td>
                                <td class="" style="text-align: left;" valign="top">
                                    <div id="DivPer">
                                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td style="width: 10%; text-align: left;">
                                                    <asp:Label ID="lbl_Inicio" runat="server" Text="Inicio:" Font-Size="X-Small"></asp:Label>
                                                </td>
                                                <td style="width: 30%; text-align: left;">
                                                    <asp:TextBox ID="txt_FECHAINI" runat="server" Height="20px" MaxLength="10" TabIndex="5"
                                                        Width="98%"></asp:TextBox>
                                                </td>
                                                <td style="width: 10%; text-align: left;">
                                                    <asp:ImageButton runat="Server" ID="imgCal1" ImageUrl="~/Imagenes/Calendar.png" AlternateText="Click to show calendar" />
                                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_FECHAINI"
                                                        PopupButtonID="imgCal1" Format="dd/MM/yyyy" />
                                                </td>
                                                <td style="width: 10%; text-align: left;">
                                                    <asp:Label ID="lbl_Final" runat="server" Text="Final:" Font-Size="X-Small"></asp:Label>
                                                </td>
                                                <td style="width: 30%; text-align: left;">
                                                    <asp:TextBox ID="txt_FECHAFIN" runat="server" Height="20px" MaxLength="10" TabIndex="6"
                                                        Width="98%"></asp:TextBox>
                                                </td>
                                                <td style="width: 10%; text-align: left;">
                                                    <asp:ImageButton runat="Server" ID="imgCal2" ImageUrl="~/Imagenes/Calendar.png" AlternateText="Click to show calendar" />
                                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_FECHAFIN"
                                                        PopupButtonID="imgCal2" Format="dd/MM/yyyy" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                            <tr id="EstadoAction">
                                <td class="labeltextonegro" style="text-align: left;" valign="middle">
                                    ESTADO ACTION PLAN:&nbsp;
                                </td>
                                <td class="" style="text-align: left;" valign="top">
                                    <asp:DropDownList ID="cmb_EstadoGestion" runat="server" Font-Size="Small" TabIndex="3"
                                        Width="100%">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr id="TipoGestion">
                                <td class="labeltextonegro" style="text-align: left;" valign="middle">
                                    TIPO DE GESTION:&nbsp;
                                </td>
                                <td class="" style="text-align: left;" valign="top">
                                    <asp:DropDownList ID="cmb_TipoGestion" runat="server" Font-Size="Small" TabIndex="3"
                                        Width="100%">
                                    </asp:DropDownList>
                                </td>
                            </tr>

                        </table>
                    </td>
                </tr>
            </table>
            <table id="Borde" border="0" cellpadding="0" cellspacing="0" class="pagerstyle" style="width: 100%">
                <tr>
                    <td align="left" style="height: 1px; width: 100%;">
                        &nbsp;
                    </td>
                </tr>
            </table>
            <asp:GridView ID="gv" runat="server" Width="100%" EnableTheming="True" AutoGenerateColumns="False"
                AllowSorting="True" PageSize="20" OnSelectedIndexChanged="gv_SelectedIndexChanged"
                OnRowDataBound="gv_RowDataBound">
                <PagerSettings PreviousPageText="&amp;lt;Anterior" Mode="NextPreviousFirstLast" LastPageText="Ultimo&amp;gt;&amp;gt;"
                    FirstPageText="&amp;lt;&amp;lt;Primero" NextPageText="Siguiente&amp;gt;"></PagerSettings>
                <Columns>
                    <asp:BoundField DataField="TipoGestion" HeaderText="TipoGestion">
                        <ItemStyle Font-Bold="False" Height="15px" HorizontalAlign="Left"></ItemStyle>
                        <HeaderStyle CssClass="" Height="22px" Width="5%"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="Ejecutado" HeaderText="Ejecutado">
                        <ItemStyle Font-Bold="False" Height="15px" HorizontalAlign="Left"></ItemStyle>
                        <HeaderStyle CssClass="" Height="22px" Width="5%"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="Resultado" HeaderText="Resultado">
                        <ItemStyle Font-Bold="False" Height="15px" HorizontalAlign="Left"></ItemStyle>
                        <HeaderStyle CssClass="" Height="22px" Width="5%"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="TotalResultado" HeaderText="TotalResultado">
                        <ItemStyle Font-Bold="False" Height="15px" HorizontalAlign="Left"></ItemStyle>
                        <HeaderStyle CssClass="" Height="22px" Width="5%"></HeaderStyle>
                    </asp:BoundField>
                </Columns>
                <RowStyle></RowStyle>
                <EmptyDataTemplate>
                    <table id="tbSinDatos">
                        <tbody>
                            <tr>
                                <td style="width: 10%">
                                    <img src="../../Imagenes/imgWarning.png" style="width: 25px; height: 24px" />
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
            </asp:GridView>
            <table id="Contador" cellpadding="0" cellspacing="0" style="width: 100%; text-align: center;">
                <tr>
                    <td class="pagerstyle" style="height: 0px; text-align: center">
                        <asp:Label ID="lblCantidad" runat="server"></asp:Label>
                        <asp:Label ID="lblPaginaGrilla" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <asp:HiddenField ID="hfOrden" runat="server"></asp:HiddenField>
        </ContentTemplate>
    </asp:UpdatePanel>
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
                                <asp:Image ID="imgCargando" runat="server" ImageUrl="../../Imagenes/cargando.gif"
                                    Width="25px" Height="24px" />
                            </td>
                        </tr>
                    </tbody>
                </table>
            </asp:Panel>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
