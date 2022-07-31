<%@ page title="" language="C#" masterpagefile="~/Master/Ceem.master" autoeventwireup="true" inherits="Estudio_Gestion_GS_Programacion_Visitas, App_Web_0nt2mo3d" stylesheettheme="Standard" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="GMDatePicker" Namespace="GrayMatterSoft" TagPrefix="cc2" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="cc3" %>
<%@ MasterType VirtualPath="~/Master/Ceem.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="DefaultContent" runat="Server">
    <script language="javascript">
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
                    <tr class="Etiqueta">
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
        <td align="left" style="height: 28px; width: 594px;">
            &nbsp;</td>
        <td style="width: 185px; height: 28px">
            &nbsp;</td>
        <td style="height: 28px; width: 141px;">
            &nbsp;&nbsp;
        </td>
        <td style="height: 28px;">

            <asp:HiddenField ID="hd_Distrito" runat="server"></asp:HiddenField>
            <asp:HiddenField ID="hd_TotalDistrito" runat="server"></asp:HiddenField>
            <asp:HiddenField ID="hd_MontoCuota" runat="server"></asp:HiddenField>


            <asp:Button ID="btnBuscar" runat="server" CausesValidation="False" 
                OnClick="btnBuscar_Click" style="height: 26px" Text="Buscar" 
                Width="120px" BackColor="#1F529E" ForeColor="White" />
            <asp:Button ID="btnProgramar" runat="server" CausesValidation="False" 
                style="height: 26px" Text="Programar / Reprogamar" 
                Width="160px" onclick="btnProgramar_Click" BackColor="#1F529E" 
                ForeColor="White" />
            <asp:Button ID="btnReasignar" runat="server" BackColor="#1F529E" 
                ForeColor="White" onclick="btnReasignar_Click" Text="Reasignar" Width="100px" />
            <asp:Button ID="btnFormato1" runat="server" BackColor="#1F529E" 
                CausesValidation="False" ForeColor="White" OnClick="btnFormato1_Click" 
                Text="Modelo Carta 1" Width="100px" />
            <asp:Button ID="btnFormato2" runat="server" BackColor="#1F529E" 
                CausesValidation="False" ForeColor="White" 
                Text="Modelo Carta 2" Width="100px" onclick="btnFormato2_Click" />
            <asp:Button ID="btnFormato3" runat="server" BackColor="#1F529E" 
                CausesValidation="False" ForeColor="White" 
                Text="Modelo Carta 3" Width="100px" onclick="btnFormato3_Click" />
            <asp:Button ID="btnFormato4" runat="server" BackColor="#1F529E" 
                CausesValidation="False" ForeColor="White" 
                Text="Modelo Carta 4" Width="100px" onclick="btnFormato4_Click" />


            <asp:Button ID="btnFormato5" runat="server" BackColor="#1F529E" 
                CausesValidation="False" ForeColor="White" 
                Text="Modelo Carta 5" Width="100px" onclick="btnFormato5_Click" />

            <asp:Button ID="btnResumen" runat="server" BackColor="#1F529E" 
                CausesValidation="False" ForeColor="White" 
                Text="Ver Resumen" Width="100px" onclick="btnPanelDetalle_Click" />


                
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
                                                        <td align="left" style="width: 282px">
                                                            Fecha de Registro del Action PLAN:</td>
                                                        <td align="left" width="">
                                                            Del
                                                            <asp:TextBox ID="txt_FECHAINI" runat="server" Enabled="false" Height="18px" 
                                                                MaxLength="10" TabIndex="5" Width="150px"></asp:TextBox>
                                                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" 
                                                                PopupButtonID="imgCal1" TargetControlID="txt_FECHAINI" />
                                                            <asp:ImageButton ID="imgCal1" runat="Server" AlternateText="Mostrar calendario" 
                                                                ImageUrl="~/imagenes/Calendar.png" />
                                                            &nbsp;al
                                                            <asp:TextBox ID="txt_FECHAFIN" runat="server" Enabled="false" Height="18px" 
                                                                MaxLength="10" TabIndex="5" Width="150px"></asp:TextBox>
                                                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" 
                                                                PopupButtonID="imgCal2" TargetControlID="txt_FECHAFIN" />
                                                            <asp:ImageButton ID="imgCal2" runat="Server" AlternateText="Mostrar calendario" 
                                                                ImageUrl="~/imagenes/Calendar.png" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 282px">
                                                            Jerarquía:</td>
                                                        <td align="left" width="">
                                                            <asp:TextBox ID="txt_desc_jerarquia" runat="server" Width="100%" Enabled=false></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 282px">
                                                            Asesor:&nbsp; </td>
                                                        <td align="left" width="">
                                                            <asp:TextBox ID="txt_asesor" runat="server" Width="100%" Enabled=false></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 282px">
                                                            Tipo:</td>
                                                        <td align="left" width="">
                                                            <asp:DropDownList ID="cmb_CodTipoGestion" runat="server" TabIndex="6" 
                                                                Width="100%" Enabled="False" >
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 282px">
                                                            Seleccione Asesor a reasignar:</td>

                                                        <td align="left" width="">
                                                            <asp:DropDownList ID="cmb_Asesores" runat="server" TabIndex="6" Width="100%">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 282px">
                                                            Monto mayor a:</td>
                                                        <td align="left" width="">
                                                            <asp:TextBox ID="txtMontoCuota" runat="server" Width="400px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 282px">
                                                            Dias atraso:</td>
                                                        <td align="left" width="">
                                                            <asp:TextBox ID="txtDiasMora" runat="server" Width="400px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 282px">
                                                            Distrito:</td>
                                                        <td align="left" width="">
                                                            <asp:TextBox ID="txtDistrito" runat="server" Width="400px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 282px">
                                                            Tipo Domicilo:</td>
                                                        <td align="left" width="">
                                                            <asp:DropDownList ID="cmb_TipoDir" runat="server" 
                                                                TabIndex="6" Width="100%">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 282px">
                                                            Por convenio:</td>
                                                        <td align="left" width="">
                                                            <asp:DropDownList ID="cmb_convenio" runat="server" TabIndex="6" Width="100%">
                                                                <asp:ListItem Value="T">--</asp:ListItem>
                                                                <asp:ListItem Value="S">Si</asp:ListItem>
                                                                <asp:ListItem Value="N">No</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 282px">
                                                            Solo los que tienen teléfono:</td>
                                                        <td align="left" width="">

                                                            <asp:DropDownList ID="cmb_telefonosi" runat="server" TabIndex="6" Width="100%">
                                                                <asp:ListItem Value="T">--</asp:ListItem>
                                                                <asp:ListItem Value="S">Si</asp:ListItem>
                                                                <asp:ListItem Value="N">No</asp:ListItem>
                                                            </asp:DropDownList>


                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 282px">
                                                            Descripci&oacute;n de Carga Masiva:</td>
                                                        <td align="left" width="">                                                            

                                                            <asp:DropDownList ID="cmb_DesCargaMasiva" runat="server" TabIndex="6" Width="100%">
                                                            </asp:DropDownList>

                                                         </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 282px">
                                                            &nbsp;</td>
                                                        <td align="left" width="">
                                                        <div id="divDetalle" style="position: relative; z-index: 50">
                                                            <div style="position: absolute; left: 10px; top: 30px; z-index: 500000;"></div>
                                                            <div style="position: absolute; left: 50%; top: 50%; margin-top: -40px; margin-left: -300px;
                                                            text-align: left; z-index: 50000;">
                                                            <asp:Panel ID="PanelDetalle" runat="server" CssClass="st_PanelPopupAjax01" Width="600"
                                                                Height="250" Visible="false">
                                                                <table cellspacing="0" width="100%" border="0">
                                                                    <tr>
                                                                        <td class="encebezadotabla-2" style="width: 98%">
                                                                            <asp:Label ID="Label1" runat="server" Text="RESUMEN"></asp:Label>
                                                                        </td>
                                                                        <td align="right" style="width: 2%" valign="top">
                                                                            <asp:ImageButton ID="btnCerrarPopDetalle" runat="server" ImageUrl="../../imagenes/cerrar.gif"
                                                                            ToolTip="Cerrar Ventana" Visible="true" Height="17" Width="17" ImageAlign="Top"
                                                                            OnClick="btnCerrarPopDetalle_Click"></asp:ImageButton>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <div style="height: 5px">
                                                                </div>
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        <table cellspacing="0" width="600px" border="0">
                                                                <tr id="Grid_Resumen">
                                                                    <td style="width: 600px" align="left">
                                                                        <asp:Panel ID="pnl_gridresumen" runat="server" Height="200px" Width="600px" ScrollBars="Vertical">
                                                                        <asp:GridView ID="gv_Resumen" runat="server" Width="100%" 
                                                                            EnableTheming="True" AutoGenerateColumns="False"
                                                                            AllowSorting="True" PageSize="5" 
                                                                            >
                                                                            <PagerSettings PreviousPageText="&amp;lt;Anterior" Mode="NextPreviousFirstLast" LastPageText="Ultimo&amp;gt;&amp;gt;"
                                                                                FirstPageText="&amp;lt;&amp;lt;Primero" NextPageText="Siguiente&amp;gt;"></PagerSettings>
                                                                            <Columns>
                                                                      
                                                                                <asp:BoundField DataField="Distrito" HeaderText="Distrito" HeaderStyle-CssClass="labelTexto">
                                                                                    <ItemStyle HorizontalAlign="Left" Height="40%" Font-Bold="False" CssClass="labelTexto"></ItemStyle>
                                                                                    <HeaderStyle Height="40%"></HeaderStyle>
                                                                                </asp:BoundField>
                                                
                                                                                <asp:BoundField DataField="TotalDistrito" HeaderText="Total Distrito" HeaderStyle-CssClass="labelTexto">
                                                                                    <ItemStyle HorizontalAlign="Left" Height="40%" Font-Bold="False" CssClass="labelTexto"></ItemStyle>
                                                                                    <HeaderStyle Height="40%"></HeaderStyle>
                                                                                </asp:BoundField>
                                                
                                                                                <asp:BoundField DataField="MontoCuota" HeaderText="Monto Cuota" HeaderStyle-CssClass="labelTexto">
                                                                                    <ItemStyle HorizontalAlign="Center" Height="20%" Font-Bold="False" CssClass="labelTexto"></ItemStyle>
                                                                                    <HeaderStyle Height="20%"></HeaderStyle>
                                                                                </asp:BoundField>
                                               
                                                                            </Columns>
                                                                            <RowStyle Font-Names="Times New Roman" Font-Size="10px"></RowStyle>
                                                                            <SelectedRowStyle CssClass="selectedrow"></SelectedRowStyle>
                                                                            <AlternatingRowStyle />
                                                                            <PagerStyle HorizontalAlign="Center" />
                                                                        </asp:GridView>
                                                                        </asp:Panel>

                                                                    </td>
                                                                </tr>
             
                                                                <tr id="CantRegResumen">
                                                                    <td class="pagerstyle" style="height: 30px; text-align: center">
                                                                        <asp:Label ID="lbl_CantRegResumen" runat="server"></asp:Label>&nbsp;                                                                        
                                                                    </td>
                                                                </tr>
                                    
                                                            </table>
                                                            </asp:Panel>
                                                        </div>
                                                        </div>                                                            
                                                            
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>


                                    <asp:GridView ID="gv" runat="server" Width="100%" EnableTheming="True"  
                                        AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True" 
                                        style="text-align: center" ViewStateMode="Enabled" BackColor="#999999" 
                                        onpageindexchanging="gv_PageIndexChanging" PageSize="40"  >
                                            <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
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

                                            <asp:BoundField DataField="IdReg_Gestion_Cobranza" HeaderText="IdReg_Gestion_Cobranza" SortExpression="">
                                                <ItemStyle  CssClass="Hidden"></ItemStyle>
                                                <HeaderStyle CssClass="Hidden" ></HeaderStyle>
                                            </asp:BoundField>

                                            <asp:BoundField DataField="Asesores" HeaderText="Asesores" SortExpression="">
                                                <ItemStyle Width="7%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                                <HeaderStyle Width="7%" CssClass="" Height="22px"></HeaderStyle>
                                            </asp:BoundField>

                                            <asp:BoundField DataField="FechaRegistra" HeaderText="F.Registra" SortExpression="" DataFormatString="{0:d}">
                                                <ItemStyle Width="5%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                                <HeaderStyle Width="5%" CssClass="" Height="22px"></HeaderStyle>
                                            </asp:BoundField>

                                            <asp:BoundField DataField="FechaVisita" HeaderText="F.Visita" SortExpression="" DataFormatString="{0:d}">
                                                <ItemStyle Width="5%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                                <HeaderStyle Width="5%" CssClass="" Height="22px"></HeaderStyle>
                                            </asp:BoundField>

                                            <asp:BoundField DataField="Dir" HeaderText="Direcci&oacute;n" SortExpression="">
                                                <ItemStyle Width="34%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                                <HeaderStyle Width="34%" CssClass="" Height="22px"></HeaderStyle>
                                            </asp:BoundField>

                                            <asp:BoundField DataField="ubigeo" HeaderText="Ubigeo" SortExpression="">
                                                <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                                <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                                            </asp:BoundField>

                                            <asp:BoundField DataField="RazonSocial" HeaderText="Raz&oacute;n Social" SortExpression="">
                                                <ItemStyle Width="15%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                                <HeaderStyle Width="15%" CssClass="" Height="22px"></HeaderStyle>
                                            </asp:BoundField>

                                            <asp:BoundField DataField="Producto" HeaderText="Producto" SortExpression="">
                                                <ItemStyle Width="8%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                                <HeaderStyle Width="8%" CssClass="" Height="22px"></HeaderStyle>
                                            </asp:BoundField>

                                            <asp:BoundField DataField="SubProducto" HeaderText="SubProducto" SortExpression="">
                                                <ItemStyle Width="7%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                                <HeaderStyle Width="7%" CssClass="" Height="22px"></HeaderStyle>
                                            </asp:BoundField>

                                            <asp:BoundField DataField="dias_mora" HeaderText="D.Mora" SortExpression="">
                                                <ItemStyle Width="3%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                                <HeaderStyle Width="3%" CssClass="" Height="22px"></HeaderStyle>
                                            </asp:BoundField>

                                            <asp:BoundField DataField="desc_ejecutores" HeaderText="Ejecutor" SortExpression="">
                                                <ItemStyle Width="3%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                                <HeaderStyle Width="3%" CssClass="" Height="22px"></HeaderStyle>
                                            </asp:BoundField>


                                            <asp:TemplateField HeaderText="Select">
                                                <HeaderTemplate>
                                                <asp:CheckBox id="chkAll" onclick="javascript:SelectAllCheckboxes(this);" runat="server"></asp:CheckBox> 
                                                </HeaderTemplate>

                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkPermiso" runat="server" />
                                                </ItemTemplate>

                                                <ItemStyle Width="2%" ></ItemStyle>
                                                <HeaderStyle Width="2%"></HeaderStyle>


                                            </asp:TemplateField>
                                        </Columns>
                                        <RowStyle></RowStyle>
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
                                        <SelectedRowStyle CssClass="selectedrow"></SelectedRowStyle>
                                        <AlternatingRowStyle  />
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

<table border="0" cellspacing="0" cellpadding="0" style="width: 1000px" align="center">
  <tr>
    <td valign="top">
    
                                    <asp:GridView ID="gv1" runat="server" AllowPaging="True" AllowSorting="True" 
                                        AutoGenerateColumns="False" EnableTheming="True" PageSize="20" 
                                        Width="150px" BorderColor="Gray">
                                      

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
                                        <RowStyle />
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
                                        <SelectedRowStyle CssClass="selectedrow" />
                                        <AlternatingRowStyle />
                                    </asp:GridView>

    </td>
    <td valign="top">
    
                                    <asp:GridView ID="gv2" runat="server" AllowPaging="True" AllowSorting="True" 
                                        AutoGenerateColumns="False" EnableTheming="True" PageSize="20" 
                                        Width="150px" BorderColor="Gray">
                                      
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
                                        <RowStyle />
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
                                        <SelectedRowStyle CssClass="selectedrow" />
                                        <AlternatingRowStyle />
                                    </asp:GridView>
    
    
    </td>
    <td valign="top">


                            <asp:GridView ID="gv3" runat="server" AllowPaging="True" AllowSorting="True" 
                                AutoGenerateColumns="False" EnableTheming="True" PageSize="20" 
                                Width="150px" BorderColor="Gray">
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
                                <RowStyle />
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
                                <SelectedRowStyle CssClass="selectedrow" />
                                <AlternatingRowStyle />
                            </asp:GridView>


      </td>
    <td valign="top">


                            <asp:GridView ID="gv4" runat="server" AllowPaging="True" AllowSorting="True" 
                                AutoGenerateColumns="False" EnableTheming="True" PageSize="20" 
                                Width="150px" BorderColor="Gray">
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
                                <RowStyle />
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
                                <SelectedRowStyle CssClass="selectedrow" />
                                <AlternatingRowStyle />
                            </asp:GridView>



      </td>
    <td valign="top">


                            <asp:GridView ID="gv5" runat="server" AllowPaging="True" AllowSorting="True" 
                                AutoGenerateColumns="False" EnableTheming="True" PageSize="20" 
                                Width="150px" BorderColor="Gray">
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
                                <RowStyle />
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
                                <SelectedRowStyle CssClass="selectedrow" />
                                <AlternatingRowStyle />
                            </asp:GridView>


      </td>
    <td valign="top">



                                <asp:GridView ID="gv6" runat="server" AllowPaging="True" AllowSorting="True" 
                                    AutoGenerateColumns="False" EnableTheming="True" PageSize="20" 
                                    Width="150px" BorderColor="Gray">
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
                                    <RowStyle />
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
                                    <SelectedRowStyle CssClass="selectedrow" />
                                    <AlternatingRowStyle />
                                </asp:GridView>



      </td>
    <td valign="top">


                                    <asp:GridView ID="gv7" runat="server" AllowPaging="True" AllowSorting="True" 
                                        AutoGenerateColumns="False" EnableTheming="True" PageSize="20" 
                                        Width="150px" BorderColor="Gray">
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
                                        <RowStyle />
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
                                        <SelectedRowStyle CssClass="selectedrow" />
                                        <AlternatingRowStyle />
                                    </asp:GridView>



      </td>
  </tr>
</table>

                                </contenttemplate>
                                <triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnBuscar" EventName="Click" />
                                </triggers>
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
