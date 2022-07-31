<%@ page language="C#" masterpagefile="~/Master/Ceem.master" autoeventwireup="true" inherits="Estudio_Reportes_RPT_GestionCampo, App_Web_ttsq0jlp" stylesheettheme="Standard" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="GMDatePicker" Namespace="GrayMatterSoft" TagPrefix="cc2" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="cc3" %>
<%@ MasterType VirtualPath="~/Master/Ceem.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="DefaultContent" runat="Server">
    <script type="text/javascript">
    </script>
    <asp:UpdatePanel ID="upGvUsuario" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="form-group col-md-2">
            </div>
            <div class="form-group col-md-6">
                <div class="rounded" style="min-height: 80px;">
                    <div class="form-row col-md-4" style ="height:19px;">
                        <label for="inputEmail4">Asesor:</label>
                    </div>
                    <div class="form-row col-md-8">
                        <asp:DropDownList ID="cmb_Asesores" runat="server" TabIndex="6" Width="100%" AutoPostBack="true" Height="20px">
                        </asp:DropDownList>
                    </div>
                    <div class="form-row col-md-4">
                        <label for="inputEmail4">Periodo:</label>
                    </div>
                    <div class="form-row col-md-8">
                            Desde <asp:TextBox ID="txt_FECHAINI" runat="server" Height="20px" MaxLength="10" TabIndex="5" Width="30%"></asp:TextBox>
                            <asp:ImageButton runat="Server" ID="imgCal1" ImageUrl="~/Imagenes/Calendar.png" AlternateText="Click to show calendar" />
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_FECHAINI"
                                PopupButtonID="imgCal1" Format="dd/MM/yyyy" />

                            hasta
                            <asp:TextBox ID="txt_FECHAFIN" runat="server" Height="20px" MaxLength="10" TabIndex="6" Width="30%"></asp:TextBox>
                            <asp:ImageButton runat="Server" ID="imgCal2" ImageUrl="~/Imagenes/Calendar.png" AlternateText="Click to show calendar" />
                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_FECHAFIN"
                                PopupButtonID="imgCal2" Format="dd/MM/yyyy" />

                    </div>
                </div>
            </div>
            <div class="form-group col-md-2">
                <div class="rounded" style="min-height: 80px;">
                    <div class="form-group col-md-12">
                        <asp:Button ID="btn_Excel" runat="server" class="btn btn-primary" OnClick="btn_Excel_Click" Text="Excel" Width="100%" />
                    </div>
                    <div class="form-group col-md-12">
                        <asp:Button ID="btn_Imprimir" runat="server" class="btn btn-primary" OnClick="btn_Imprimir_Click" Text="Imprimir" Width="100%" />
                        <asp:HiddenField ID="HD_Continuar" runat="server" />
                        <input id="hdnContinuar" name="hdnContinuar" style="width: 80px; height: 10px" type="hidden" />
                    </div>
                </div>
            </div>
            <div class="form-group col-md-2">
            </div>

            <table id="Borde" border="0" cellpadding="0" cellspacing="0" class="pagerstyle" style="width: 100%">
                <tr>
                    <td align="left" style="height: 1px; width: 100%;">
                        &nbsp;
                    </td>
                </tr>
            </table>
            <asp:GridView ID="gv" runat="server" Width="100%" EnableTheming="True" AutoGenerateColumns="False"
                AllowSorting="True" PageSize="20" 
                OnRowDataBound="gv_RowDataBound" >
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
