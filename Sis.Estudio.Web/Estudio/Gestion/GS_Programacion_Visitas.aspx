<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Ceem.master" AutoEventWireup="true"
    CodeFile="GS_Programacion_Visitas.aspx.cs" Inherits="Estudio_Gestion_GS_Programacion_Visitas" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="GMDatePicker" Namespace="GrayMatterSoft" TagPrefix="cc2" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="cc3" %>
<%@ MasterType VirtualPath="~/Master/Ceem.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="DefaultContent" runat="Server">
    <script src="../../javascript/jquery-2.1.1.min.js"></script>
    <script type="text/javascript">
        function fnAbrirPopUpFiltro() {
            var options = 'width=700,height=500,top=80,left=400,scrollbars=YES,menubar=NO,titlebar= NO,status=NO,toolbar=NO';
            window.open('../../Consultas/Busquedas/Filtro.aspx', 'Proveedores', options);
        }
        function Enter_Buscar(evt) {
        }

        function Valida_Todos() {
        }

        function Valida_Texto(texto) {
            if (texto == '') {
                return false;
            }
            else {
                return true;
            }
        }

        function DetResumen() {
            if (Valida_Texto($get('<%= hd_Distrito.ClientID %>').value) == false) {
                alert('0 Registros para mostrar. ');
                return;
            }

            var str_distrito = "?distrito=" + $get('<%= hd_Distrito.ClientID %>').value;
            var str_totaldistrito = "&totaldistrito=" + $get('<%= hd_TotalDistrito.ClientID %>').value;
            var str_montocuota = "&montocuota=" + $get('<%= hd_MontoCuota.ClientID %>').value;

            var argsValores = str_distrito + str_totaldistrito + str_montocuota;
            var prmsValores;
            var returnValue;

            prmsValores = "dialogWidth:690px;dialogHeight:340px;center:yes;scrollbars=yes;help=no;status=no;toolbar=no";
            returnValue = window.showModalDialog("GS_Programacion_VisitasDetResumen.aspx" + argsValores, "NewWin", prmsValores);
        }


        function SelectAllCheckboxes(spanChk) {
            var oItem = spanChk.children;
            var theBox = (spanChk.type == "checkbox") ? spanChk : spanChk.children.item[0];
            xState = theBox.checked;

            elm = theBox.form.elements;
            for (i = 0; i < elm.length; i++)
                if (elm[i].type == "checkbox" && elm[i].id != theBox.id) {
                    if (elm[i].checked != xState)
                        elm[i].click();
                }
        }

    </script>
    <table id="tbContenedor" width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td style="width: 100%">
                <table id="tbContenedorDatos" cellpadding="0" cellspacing="0" style="width: 100%">
                    <tr>
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
                                                    <asp:HiddenField ID="hd_Distrito" runat="server"></asp:HiddenField>
                                                    <asp:HiddenField ID="hd_TotalDistrito" runat="server"></asp:HiddenField>
                                                    <asp:HiddenField ID="hd_MontoCuota" runat="server"></asp:HiddenField>
                                                 </td>
                                            </tr>
                                        </tbody>
                                    </table>

                                    
                                    <div class="form-group col-md-2">
                                    </div>
                                    
                                    <div class="form-group col-md-6">
                                        <div class="rounded" style="min-height: 100px;">
                                            <div class="form-group col-md-3">
                                                <label for="inputEmail4">Asignar a:</label>
                                            </div>
                                            <div class="form-group col-md-6">
                                                <asp:DropDownList ID="cmb_Asesores" runat="server" TabIndex="6" Width="100%">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="form-group col-md-3">
                                                <asp:Button ID="btnReasignar" runat="server" onclick="btnReasignar_Click" Text="Reasignar" Width="100%" class="btn btn-primary" /><br />
                                            </div>

                                            <div class="form-group col-md-3">
                                                <label for="inputEmail4">Modelo carta:</label>
                                            </div>
                                            <div class="form-group col-md-6">
                                                <asp:DropDownList ID="cmb_Carta" runat="server" TabIndex="6" Width="100%" AutoPostBack="true" CssClass="selectpicker">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="form-group col-md-3">
                                                <asp:Button ID="btnFormatoCarta" runat="server" CausesValidation="False" onclick="btnFormatoCarta_Click" Text="Carta" Width="100%" class="btn btn-primary" />
                                            </div>
                                        </div>
                                    </div>
                                    
                                    <div class="form-group col-md-2">
                                        <div class="rounded" style="min-height: 100px;">
                                            <table style="margin:auto; text-align:center; height:80px; width:100%">
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnFiltrar" runat="server" CausesValidation="False" OnClick="btnFiltrar_Click" Text="Filtro avanzado" Width="80%" class="btn btn-primary" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnResumen" runat="server" CausesValidation="False" onclick="btnPanelDetalle_Click" Text="Ver Resumen" Width="80%" class="btn btn-primary" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnProgramar" runat="server" CausesValidation="False" onclick="btnProgramar_Click" Text="Programar/Reprogamar" Width="80%" class="btn btn-primary" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                    
                                    <div class="form-group col-md-2">
                                    </div>

                                    <table class="cabeceraScroll" style="width: 100%">
                                        <tr>
                                            <td style="width: 40%;">
                                            </td>

                                            <td style="width: 40%">
                                                <%--<table align="center" border="0" cellpadding="0" cellspacing="0" 
                                                    class="cabeceraScroll" style="width: 90%;">
                                                    <tr>
                                                        <td colspan="2" style="width: 45%; height:25px;">

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 45%; height:25px;">
                                                            Dias atraso:</td>
                                                        <td align="left" style="height:25px;">
                                                            <asp:TextBox ID="txtDiasMora" runat="server" Width="100%"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 45%">
                                                            Distrito:</td>
                                                        <td align="left" width="">
                                                            <asp:TextBox ID="txtDistrito" runat="server" Width="100%"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 45%; height:25px;">
                                                            Tipo Domicilo:</td>
                                                        <td align="left" style="height:25px;">
                                                            <asp:DropDownList ID="cmb_TipoDir" runat="server" 
                                                                TabIndex="6" Width="100%">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 45%; height:25px;">
                                                            Por convenio:</td>
                                                        <td align="left" style="height:25px;">
                                                            <asp:DropDownList ID="cmb_convenio" runat="server" TabIndex="6" Width="100%">
                                                                <asp:ListItem Value="T">--</asp:ListItem>
                                                                <asp:ListItem Value="S">Si</asp:ListItem>
                                                                <asp:ListItem Value="N">No</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 45%; height:25px;">
                                                            Solo los que tienen teléfono:</td>
                                                        <td align="left" style="height:25px;">

                                                            <asp:DropDownList ID="cmb_telefonosi" runat="server" TabIndex="6" Width="100%">
                                                                <asp:ListItem Value="T">--</asp:ListItem>
                                                                <asp:ListItem Value="S">Si</asp:ListItem>
                                                                <asp:ListItem Value="N">No</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 45%; height:25px;">
                                                            Descripci&oacute;n de Carga Masiva:</td>
                                                        <td align="left" style="height:25px;">                                                            
                                                            <asp:DropDownList ID="cmb_DesCargaMasiva" runat="server" TabIndex="6" Width="100%">
                                                            </asp:DropDownList>
                                                         </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 45%; height:25px;">
                                                            &nbsp;</td>
                                                        <td align="left" style="width: 45%; height:25px;">
                                                                                                                 
                                                            
                                                        </td>
                                                    </tr>
                                                </table>--%>
                                            </td>
                                            <!-- -->
                                            <td style="width: 40%">
                                                <%--<table align="center" border="0"  cellpadding="0" cellspacing="0"
                                                    class="cabeceraScroll" style="width: 90%;">
                                                    <tr>
                                                        <td colspan="2" style="height:25px;">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="height:25px;">
                                                            &nbsp;</td>
                                                    </tr>
                                                    
                                                    <tr>
                                                        <td style="width: 45%; height:25px;" colspan="2">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 45%; height:25px;" colspan="2">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 45%; height:25px;" colspan="2">
                                                            &nbsp;</td>
                                                        
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 45%; height:25px;" colspan="2">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 45%; height:25px;">
                                                            </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="width: 45%; height:25px;">
                                                                                                                                            
                                                        </td>
                                                    </tr>
                                                </table>--%>
                                            </td>

                                        </tr>
                                    </table>


                                    


                                    <asp:GridView ID="gv" runat="server" Width="100%" EnableTheming="True"  
                                        AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True" 
                                        style="text-align: center" ViewStateMode="Enabled" BackColor="White" 
                                        onpageindexchanging="gv_PageIndexChanging" PageSize="40" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" >
                                            <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="White" ForeColor="#000066" />
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass ="encebezadotabla-3" Font-Bold="True" ForeColor="Black" />
                                        <Columns>

                                            <asp:TemplateField ShowHeader="False">
                                                <ItemStyle  CssClass="Hidden"></ItemStyle>
                                                <HeaderStyle CssClass="Hidden" ></HeaderStyle>
                                                <ItemTemplate>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:BoundField DataField="" HeaderText="#" SortExpression="">
                                                <ItemStyle Width="1%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                                <HeaderStyle Width="1%" CssClass="" Height="22px"></HeaderStyle>
                                            </asp:BoundField>

                                            <asp:BoundField DataField="nIdGestionCobranza" HeaderText="Codigo" SortExpression="">
                                                <ItemStyle  CssClass="Hidden"></ItemStyle>
                                                <HeaderStyle CssClass="Hidden" ></HeaderStyle>
                                            </asp:BoundField>

                                            <asp:BoundField DataField="cAsesor" HeaderText="Asesores" SortExpression="">
                                                <ItemStyle Width="7%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                                <HeaderStyle Width="7%" CssClass="" Height="22px"></HeaderStyle>
                                            </asp:BoundField>

                                            <asp:BoundField DataField="dFechaRegistra" HeaderText="F.Registra" SortExpression="" DataFormatString="{0:d}">
                                                <ItemStyle Width="5%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                                <HeaderStyle Width="5%" CssClass="" Height="22px"></HeaderStyle>
                                            </asp:BoundField>

                                            <asp:BoundField DataField="dFechaVisita" HeaderText="F.Visita" SortExpression="" DataFormatString="{0:d}">
                                                <ItemStyle Width="5%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                                <HeaderStyle Width="5%" CssClass="" Height="22px"></HeaderStyle>
                                            </asp:BoundField>

                                            <asp:BoundField DataField="cDireccion" HeaderText="Direcci&oacute;n" SortExpression="">
                                                <ItemStyle Width="34%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                                <HeaderStyle Width="34%" CssClass="" Height="22px"></HeaderStyle>
                                            </asp:BoundField>

                                            <asp:BoundField DataField="cUbigeo" HeaderText="Ubigeo" SortExpression="">
                                                <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                                <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                                            </asp:BoundField>

                                            <asp:BoundField DataField="cRazonSocial" HeaderText="Raz&oacute;n Social" SortExpression="">
                                                <ItemStyle Width="15%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                                <HeaderStyle Width="15%" CssClass="" Height="22px"></HeaderStyle>
                                            </asp:BoundField>

                                            <asp:BoundField DataField="cProducto" HeaderText="Producto" SortExpression="">
                                                <ItemStyle Width="8%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                                <HeaderStyle Width="8%" CssClass="" Height="22px"></HeaderStyle>
                                            </asp:BoundField>

                                            <asp:BoundField DataField="cSubProducto" HeaderText="SubProducto" SortExpression="">
                                                <ItemStyle Width="7%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                                <HeaderStyle Width="7%" CssClass="" Height="22px"></HeaderStyle>
                                            </asp:BoundField>

                                            <asp:BoundField DataField="nMontoCuota" HeaderText="Deuda" />

                                            <asp:BoundField DataField="nDiasMora" HeaderText="D.Mora" SortExpression="">
                                                <ItemStyle Width="3%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                                <HeaderStyle Width="3%" CssClass="" Height="22px"></HeaderStyle>
                                            </asp:BoundField>

                                            <asp:BoundField DataField="cEjecutor" HeaderText="Ejecutor" SortExpression="">
                                                <ItemStyle Width="3%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                                <HeaderStyle Width="3%" CssClass="" Height="22px"></HeaderStyle>
                                            </asp:BoundField>

                                            <asp:BoundField DataField="nIdTipoGestion" HeaderText="CodTipoGestion" SortExpression="">
                                                <ItemStyle CssClass="hidden" Width="1%"></ItemStyle>
                                                <HeaderStyle Width="1%" CssClass="hidden" Height="22px"></HeaderStyle>
                                            </asp:BoundField>

                                            <asp:TemplateField HeaderText="Select">
                                                <HeaderTemplate>
                                                <asp:CheckBox id="chkAll" onclick="javascript:SelectAllCheckboxes(this);" Checked="true" runat="server"></asp:CheckBox> 
                                                </HeaderTemplate>

                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkPermiso" Checked="true" runat="server" />
                                                </ItemTemplate>

                                                <ItemStyle Width="2%" ></ItemStyle>
                                                <HeaderStyle Width="2%"></HeaderStyle>


                                            </asp:TemplateField>
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
                                    <asp:Panel ID="PanelDetalle" runat="server" CssClass="st_PanelPopupAjax01" Height="250" Visible="false" Width="600">
                                        <table border="0" cellspacing="0" width="100%">
                                            <tr>
                                                <td class="encebezadotabla-2" style="width: 98%">
                                                    <asp:Label ID="Label1" runat="server" Text="RESUMEN"></asp:Label>
                                                </td>
                                                <td align="right" style="width: 2%" valign="top">
                                                    <asp:ImageButton ID="btnCerrarPopDetalle" runat="server" Height="17" ImageAlign="Top" ImageUrl="../../imagenes/cerrar.gif" OnClick="btnCerrarPopDetalle_Click" ToolTip="Cerrar Ventana" Visible="true" Width="17" />
                                                </td>
                                            </tr>
                                        </table>
                                        <div style="height: 5px">
                                        </div>
                                        <table border="0" cellspacing="0" width="600px">
                                            <tr id="Grid_Resumen">
                                                <td align="left" style="width: 600px">
                                                    <asp:Panel ID="pnl_gridresumen" runat="server" Height="200px" ScrollBars="Vertical" Width="600px">
                                                        <asp:GridView ID="gv_Resumen" runat="server" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" EnableTheming="True" PageSize="5" Width="100%">
                                                            <FooterStyle BackColor="White" ForeColor="#000066" />
                                                            <HeaderStyle BackColor="#2F63CB" Font-Bold="True" ForeColor="White" />
                                                            <PagerSettings FirstPageText="&amp;lt;&amp;lt;Primero" LastPageText="Ultimo&amp;gt;&amp;gt;" NextPageText="Siguiente&amp;gt;" PreviousPageText="&amp;lt;Anterior" />
                                                            <Columns>
                                                                <asp:BoundField DataField="cDistrito" HeaderStyle-CssClass="labelTexto" HeaderText="Distrito">
                                                                <ItemStyle CssClass="labelTexto" Font-Bold="False" Height="40%" HorizontalAlign="Left" />
                                                                <HeaderStyle Height="40%" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="nTotalDistrito" HeaderStyle-CssClass="labelTexto" HeaderText="Total Distrito">
                                                                <ItemStyle CssClass="labelTexto" Font-Bold="False" Height="40%" HorizontalAlign="Left" />
                                                                <HeaderStyle Height="40%" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="nMontoCuota" HeaderStyle-CssClass="labelTexto" HeaderText="Monto Cuota">
                                                                <ItemStyle CssClass="labelTexto" Font-Bold="False" Height="20%" HorizontalAlign="Center" />
                                                                <HeaderStyle Height="20%" />
                                                                </asp:BoundField>
                                                            </Columns>
                                                            <RowStyle Font-Names="Trebuchet MS" Font-Size="10px" ForeColor="#000066" />
                                                            <SelectedRowStyle BackColor="#669999" CssClass="selectedrow" Font-Bold="True" ForeColor="White" />
                                                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                                                        </asp:GridView>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr id="CantRegResumen">
                                                <td class="pagerstyle" style="height: 30px; text-align: center">
                                                    <asp:Label ID="lbl_CantRegResumen" runat="server"></asp:Label>
                                                    &nbsp; </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
<table border="0" cellspacing="0" cellpadding="0" style="width: 1000px" align="center">
  <tr>
    <td valign="top">
    
                                    <asp:GridView ID="gv1" runat="server" AllowPaging="True" AllowSorting="True" 
                                        AutoGenerateColumns="False" EnableTheming="True" PageSize="20" 
                                        Width="150px" BorderColor="#CCCCCC" BackColor="White" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                                      

                                        <Columns>

                                           
                                            <asp:BoundField DataField="estado1">
                                            <ItemStyle CssClass="hidden" />
                                            <HeaderStyle CssClass="hidden" />
                                            </asp:BoundField>
                                            
                                            <asp:BoundField DataField="fecha1" HeaderText="Primer Dia" SortExpression="">
                                            <ItemStyle Font-Bold="False" Height="15px" HorizontalAlign="Center" Width="100%" />
                                            <HeaderStyle CssClass="" Height="22px" Width="100%" />
                                            </asp:BoundField>

                                        </Columns>
                                        <FooterStyle BackColor="White" ForeColor="#000066" />
                                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                        <RowStyle ForeColor="#000066" />
                                        <EmptyDataTemplate>
                                            <table ID="tbSinDatos2">
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 10%">
                                                            <img src="../../Imagenes/imgWarning.png" style="width:25px; height:24px" />
                                                        </td>
                                                        <td style="width: 5%">
                                                        </td>
                                                        <td style="width: 85%">
                                                            <asp:Label ID="lblSinDatos2" runat="server" CssClass="labeltextonegro" 
                                                                Text="No se encontraron Datos..."></asp:Label>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </EmptyDataTemplate>
                                        <SelectedRowStyle CssClass="selectedrow" BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                        <AlternatingRowStyle />
                                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                                    </asp:GridView>

    </td>
    <td valign="top">
    
                                    <asp:GridView ID="gv2" runat="server" AllowPaging="True" AllowSorting="True" 
                                        AutoGenerateColumns="False" EnableTheming="True" PageSize="20" 
                                        Width="150px" BorderColor="#CCCCCC" BackColor="White" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                                      
                                        <Columns>

                                            
                                            <asp:BoundField DataField="estado2">
                                            <ItemStyle CssClass="hidden" />
                                            <HeaderStyle CssClass="hidden" />
                                            </asp:BoundField>
                                            
                                            <asp:BoundField DataField="fecha2" HeaderText="Segundo Dia" SortExpression="">
                                            <ItemStyle Font-Bold="False" Height="15px" HorizontalAlign="Center" Width="100%" />
                                            <HeaderStyle CssClass="" Height="22px" Width="100%" />
                                            </asp:BoundField>

                                        </Columns>
                                        <FooterStyle BackColor="White" ForeColor="#000066" />
                                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                        <RowStyle ForeColor="#000066" />
                                        <EmptyDataTemplate>
                                            <table ID="tbSinDatos2">
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 10%">
                                                            <img src="../../Imagenes/imgWarning.png" style="width:25px; height:24px" />
                                                        </td>
                                                        <td style="width: 5%">
                                                        </td>
                                                        <td style="width: 85%">
                                                            <asp:Label ID="lblSinDatos2" runat="server" CssClass="labeltextonegro" 
                                                                Text="No se encontraron Datos..."></asp:Label>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </EmptyDataTemplate>
                                        <SelectedRowStyle CssClass="selectedrow" BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                        <AlternatingRowStyle />
                                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                                    </asp:GridView>
    
    
    </td>
    <td valign="top">


                            <asp:GridView ID="gv3" runat="server" AllowPaging="True" AllowSorting="True" 
                                AutoGenerateColumns="False" EnableTheming="True" PageSize="20" 
                                Width="150px" BorderColor="#CCCCCC" BackColor="White" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                                <Columns>
                                    <asp:BoundField DataField="estado3">
                                    <ItemStyle CssClass="hidden" />
                                    <HeaderStyle CssClass="hidden" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="fecha3" HeaderText="Tercer Dia" SortExpression="">
                                    <ItemStyle Font-Bold="False" Height="15px" HorizontalAlign="Center" 
                                        Width="100%" />
                                    <HeaderStyle CssClass="" Height="22px" Width="100%" />
                                    </asp:BoundField>
                                </Columns>
                                <FooterStyle BackColor="White" ForeColor="#000066" />
                                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                <RowStyle ForeColor="#000066" />
                                <EmptyDataTemplate>
                                    <table ID="tbSinDatos3">
                                        <tbody>
                                            <tr>
                                                <td style="width: 10%">
                                                    <img src="../../Imagenes/imgWarning.png" style="width:25px; height:24px" />
                                                </td>
                                                <td style="width: 5%">
                                                </td>
                                                <td style="width: 85%">
                                                    <asp:Label ID="lblSinDatos3" runat="server" CssClass="labeltextonegro" 
                                                        Text="No se encontraron Datos..."></asp:Label>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </EmptyDataTemplate>
                                <SelectedRowStyle CssClass="selectedrow" BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                <AlternatingRowStyle />
                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                <SortedDescendingHeaderStyle BackColor="#00547E" />
                            </asp:GridView>


      </td>
    <td valign="top">


                            <asp:GridView ID="gv4" runat="server" AllowPaging="True" AllowSorting="True" 
                                AutoGenerateColumns="False" EnableTheming="True" PageSize="20" 
                                Width="150px" BorderColor="#CCCCCC" BackColor="White" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                                <Columns>
                                    <asp:BoundField DataField="estado4">
                                    <ItemStyle CssClass="hidden" />
                                    <HeaderStyle CssClass="hidden" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="fecha4" HeaderText="Cuarto Dia" SortExpression="">
                                    <ItemStyle Font-Bold="False" Height="15px" HorizontalAlign="Center" 
                                        Width="100%" />
                                    <HeaderStyle CssClass="" Height="22px" Width="100%" />
                                    </asp:BoundField>
                                </Columns>
                                <FooterStyle BackColor="White" ForeColor="#000066" />
                                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                <RowStyle ForeColor="#000066" />
                                <EmptyDataTemplate>
                                    <table ID="tbSinDatos4">
                                        <tbody>
                                            <tr>
                                                <td style="width: 10%">
                                                    <img src="../../Imagenes/imgWarning.png" style="width:25px; height:24px" />
                                                </td>
                                                <td style="width: 5%">
                                                </td>
                                                <td style="width: 85%">
                                                    <asp:Label ID="lblSinDatos4" runat="server" CssClass="labeltextonegro" 
                                                        Text="No se encontraron Datos..."></asp:Label>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </EmptyDataTemplate>
                                <SelectedRowStyle CssClass="selectedrow" BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                <AlternatingRowStyle />
                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                <SortedDescendingHeaderStyle BackColor="#00547E" />
                            </asp:GridView>



      </td>
    <td valign="top">


                            <asp:GridView ID="gv5" runat="server" AllowPaging="True" AllowSorting="True" 
                                AutoGenerateColumns="False" EnableTheming="True" PageSize="20" 
                                Width="150px" BorderColor="#CCCCCC" BackColor="White" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                                <Columns>
                                    <asp:BoundField DataField="estado5">
                                    <ItemStyle CssClass="hidden" />
                                    <HeaderStyle CssClass="hidden" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="fecha5" HeaderText="Quinto Dia" SortExpression="">
                                    <ItemStyle Font-Bold="False" Height="15px" HorizontalAlign="Center" 
                                        Width="100%" />
                                    <HeaderStyle CssClass="" Height="22px" Width="100%" />
                                    </asp:BoundField>
                                </Columns>
                                <FooterStyle BackColor="White" ForeColor="#000066" />
                                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                <RowStyle ForeColor="#000066" />
                                <EmptyDataTemplate>
                                    <table ID="tbSinDatos7">
                                        <tbody>
                                            <tr>
                                                <td style="width: 10%">
                                                    <img src="../../Imagenes/imgWarning.png" style="width:25px; height:24px" />
                                                </td>
                                                <td style="width: 5%">
                                                </td>
                                                <td style="width: 85%">
                                                    <asp:Label ID="lblSinDatos6" runat="server" CssClass="labeltextonegro" 
                                                        Text="No se encontraron Datos..."></asp:Label>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </EmptyDataTemplate>
                                <SelectedRowStyle CssClass="selectedrow" BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                <AlternatingRowStyle />
                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                <SortedDescendingHeaderStyle BackColor="#00547E" />
                            </asp:GridView>


      </td>
    <td valign="top">



                                <asp:GridView ID="gv6" runat="server" AllowPaging="True" AllowSorting="True" 
                                    AutoGenerateColumns="False" EnableTheming="True" PageSize="20" 
                                    Width="150px" BorderColor="#CCCCCC" BackColor="White" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                                    <Columns>
                                        <asp:BoundField DataField="estado6">
                                        <ItemStyle CssClass="hidden" />
                                        <HeaderStyle CssClass="hidden" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="fecha6" HeaderText="Sexto Dia" SortExpression="">
                                        <ItemStyle Font-Bold="False" Height="15px" HorizontalAlign="Center" 
                                            Width="100%" />
                                        <HeaderStyle CssClass="" Height="22px" Width="100%" />
                                        </asp:BoundField>
                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                    <RowStyle ForeColor="#000066" />
                                    <EmptyDataTemplate>
                                        <table ID="tbSinDatos5">
                                            <tbody>
                                                <tr>
                                                    <td style="width: 10%">
                                                        <img src="../../Imagenes/imgWarning.png" style="width:25px; height:24px" />
                                                    </td>
                                                    <td style="width: 5%">
                                                    </td>
                                                    <td style="width: 85%">
                                                        <asp:Label ID="lblSinDatos4" runat="server" CssClass="labeltextonegro" 
                                                            Text="No se encontraron Datos..."></asp:Label>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </EmptyDataTemplate>
                                    <SelectedRowStyle CssClass="selectedrow" BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <AlternatingRowStyle />
                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                                </asp:GridView>



      </td>
    <td valign="top">


                                    <asp:GridView ID="gv7" runat="server" AllowPaging="True" AllowSorting="True" 
                                        AutoGenerateColumns="False" EnableTheming="True" PageSize="20" 
                                        Width="150px" BorderColor="#CCCCCC" BackColor="White" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                                        <Columns>
                                            <asp:BoundField DataField="estado7">
                                            <ItemStyle CssClass="hidden" />
                                            <HeaderStyle CssClass="hidden" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="fecha7" HeaderText="Septimo Dia" SortExpression="">
                                            <ItemStyle Font-Bold="False" Height="15px" HorizontalAlign="Center" 
                                                Width="100%" />
                                            <HeaderStyle CssClass="" Height="22px" Width="100%" />
                                            </asp:BoundField>
                                        </Columns>
                                        <FooterStyle BackColor="White" ForeColor="#000066" />
                                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                        <RowStyle ForeColor="#000066" />
                                        <EmptyDataTemplate>
                                            <table ID="tbSinDatos6">
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 10%">
                                                            <img src="../../Imagenes/imgWarning.png" style="width:25px; height:24px" />
                                                        </td>
                                                        <td style="width: 5%">
                                                        </td>
                                                        <td style="width: 85%">
                                                            <asp:Label ID="lblSinDatos5" runat="server" CssClass="labeltextonegro" 
                                                                Text="No se encontraron Datos..."></asp:Label>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </EmptyDataTemplate>
                                        <SelectedRowStyle CssClass="selectedrow" BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                        <AlternatingRowStyle />
                                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                                    </asp:GridView>



      </td>
  </tr>
</table>

                                </contenttemplate>
                                <%--<triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnBuscar" EventName="Click" />
                                </triggers>--%>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr class="Etiqueta">
                        <td align="center" style="width: 100%">
                            &nbsp;
                        </td>
                    </tr>
                    <tr class="Etiqueta">
                        <td align="center" style="width: 100%">
                            &nbsp;
                        </td>
                    </tr>
                    <tr class="Etiqueta">
                        <td align="center" style="width: 100%">
                            &nbsp;
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
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 100%">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 100%">
                &nbsp;
            </td>
        </tr>
    </table>


</asp:Content>
