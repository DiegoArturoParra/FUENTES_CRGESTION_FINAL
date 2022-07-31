<%@ page title="" language="C#" masterpagefile="~/Master/Ficha.master" autoeventwireup="true" inherits="Consultas_Busquedas_Filtro, App_Web_fhace2t1" stylesheettheme="Standard" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/Master/Ficha.Master" %>
<%@ Register Src="../../WebUserControl/WUCDateTimePicker.ascx" TagName="WUCDateTimePicker" TagPrefix="DateTime" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../javascript/jquery-2.1.1.min.js" type="text/javascript"></script>
    <script src="../../javascript/jsUpdateProgress.js" type="text/javascript"></script>

    
    
    <script type="text/javascript" src="../../funciones/bootstrap.min.js"></script>
    <script type="text/javascript" src="../../funciones/bootstrap-datetimepicker.min.js"></script>
    <script type="text/javascript" src="../../funciones/bootstrap-datetimepicker.es-PE.js"></script>


    <script type="text/javascript">
        var ModalProgress = '<%= ModalProgress.ClientID %>';
        var jsCerrarVentana = '';
        function fnRefrescarPaginaPadre() {
            jsCerrarVentana = '<%= llCerrarVentana %>';
            if (jsCerrarVentana == 'True') {
                window.opener.location.reload();
                window.close();
            }
        }
        //$('#dtpFecha').DateTimePickerNew({
        //    format: 'dd/MM/yyyy hh:mm:ss',
        //    language: 'es-PE'
        //});
    </script>
    <script src="../../javascript/jsUpdateProgress.js" type="text/javascript"></script>
    
    <input id="hdnContinuar" name="hdnContinuar" style="width: 80px; height: 10px" type="hidden" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <contenttemplate>

            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="text-align: center;"><br/>
                        &nbsp;<asp:Button ID="btnFiltrar" runat="server" class="btn btn-primary" OnClick="btnFiltrar_Click" Text="Filtrar" Width="100px" />
                        &nbsp;<asp:Button ID="btnLimpiar" runat="server" class="btn btn-primary" Text="Limpiar" Width="100px" OnClick="btnLimpiar_Click" />
                        <br />
                        <asp:LinkButton ID="lnkAvanzado" runat="server" OnClick="lnkAvanzado_Click">Busqueda avanzada...</asp:LinkButton>
                        <br/>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td class="encebezadotabla-3" style="width: 60%; text-align:center">
                        Filtro gestión visita de campo
                    </td>
                    <td colspan="2" style="width: 40%;" valign="top"></td>
                </tr>

                <tr>
                    <td style="width: 100%;" valign="top">
                        <asp:GridView ID="gv" runat="server" Width="100%" EnableTheming="True" AutoGenerateColumns="False"
                            AllowSorting="True" PageSize="20" OnRowDataBound="gv_RowDataBound"
                            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                            <PagerSettings PreviousPageText="&amp;lt;Anterior" LastPageText="Ultimo&amp;gt;&amp;gt;"
                                FirstPageText="&amp;lt;&amp;lt;Primero" NextPageText="Siguiente&amp;gt;"></PagerSettings>
                            <Columns>
                                <%--<asp:TemplateField HeaderText="Columna">
                                    <ItemTemplate>
                                    <asp:DropDownList DataSource='<%# mxColumnaTrabajo_LlenarDropDownList() %>' DataTextField="nIdColumna" DataValueField="cNombreColumna" ID="ddlColumna" runat="server">
                                    </asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                
                                <asp:TemplateField HeaderText="Condición">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlCondicion" runat="server" style="width: 35px;">
                                        </asp:DropDownList></ItemTemplate>  
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="(">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtSeparaIni" runat="server" Text="" style="width: 15px;"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Columna">  
                                    <ItemTemplate>  
                                        <asp:DropDownList ID="ddlColumna" runat="server" OnSelectedIndexChanged="ddlColumna_SelectedIndexChanged" AutoPostBack="true"
                                            style="max-height:100px; overflow:auto;">
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Lógica búsqueda">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlTipo" runat="server" style="width: 150px;">
                                        </asp:DropDownList> 
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Valor">
                                    <ItemTemplate>
                                        <script type="text/javascript">
                                            function getDateTimePicker() {
                                                $('.dtpFecha').DateTimePickerNew({
                                                    format: 'dd/MM/yyyy hh:mm:ss',
                                                    language: 'es-PE'
                                                });
                                            }
                                            $('.dtpFecha').DateTimePickerNew({
                                                format: 'dd/MM/yyyy hh:mm:ss',
                                                language: 'es-PE'
                                            });
                                        </script>
                                        <asp:TextBox ID="txtValor" runat="server" Text=""></asp:TextBox>
                                        <DateTime:WUCDateTimePicker ID="dtpFecha" class="dtpFecha" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText=")">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtSeparaFin" runat="server" Text="" style="width: 15px;"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
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
                        <%--<table cellpadding="0" cellspacing="0" style="width: 100%">
                            <tr>
                                <td class="GridViewPie" style="text-align: center">
                                    <asp:Label ID="lbl_Cantidad" runat="server" Text="0"></asp:Label>
                                </td>
                            </tr>
                        </table>--%>
                        <asp:HiddenField ID="hd_Codigo" runat="server" />
                        <asp:HiddenField ID="hd_IdRegProdAval" runat="server" />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center;">
                        <br/><br/>
                        <p>
                            <b>Fije las Condiciones de la Busqueda para Restringir la Lista.</b></p>
                        <p>
                            * Puede utilizar filtros &quot;O&quot; introduciendo varios elementos en el tercer campo.<br />
                            * Puede incorporar hasta 10 articulos, separados por comas. Ejm: item1,item2,item3
                        </p>
                        <br/>
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

