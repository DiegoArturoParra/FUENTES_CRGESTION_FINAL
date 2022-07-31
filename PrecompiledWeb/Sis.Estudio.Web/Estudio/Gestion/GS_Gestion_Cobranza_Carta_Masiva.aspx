<%@ page title="" language="C#" masterpagefile="~/Master/Ceem.master" autoeventwireup="true" inherits="Estudio_Gestion_GS_Gestion_Cobranza_Carta_Masiva, App_Web_0nt2mo3d" stylesheettheme="Standard" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="GMDatePicker" Namespace="GrayMatterSoft" TagPrefix="cc2" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="cc3" %>
<%@ MasterType VirtualPath="~/Master/Ceem.master" %>



<asp:Content ID="Content1" ContentPlaceHolderID="DefaultContent" runat="Server">


  <script src="../../funciones/jquery-1.4.1.js" type="text/javascript"></script>
<script  src="../../funciones/jquery.dataTables.js" type="text/javascript" ></script>

<script>
    $(document).ready(function () {
        $('#example').DataTable();
    });
    </script>

    <script type="text/javascript">
        function Enter_Buscar(evt) {
        }

        function Valida_Todos() {

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

	
				

					<div class="account"></div>
				</div>

				<div id="ad"></div>
			</div>
            <div id="Div1"></div>
			</div>

			




    <asp:UpdatePanel ID="upGvUsuario" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table id="TMensaje" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td class="altoverow" style="text-align: center">
                        <asp:ValidationSummary ID="vsError" runat="server" HeaderText="No puede realizar esta Operación:"
                            ShowMessageBox="True" ShowSummary="False" CssClass="Etiqueta" />
                        <asp:Label ID="lblMensaje" runat="server" CssClass="Etiqueta" ForeColor="Red"></asp:Label><input
                            id="hdnContinuar" name="hdnContinuar" style="width: 80px; height: 10px" type="hidden" />
                    </td>
                </tr>
            </table>
            <table id="TBotones" border="0" cellpadding="0" cellspacing="0" class="cabeceraScroll"
                width="100%">
                <tr>
                    <td align="left" style="width: 70%;">
                        <asp:Button ID="btnBuscar" runat="server" BackColor="#1F529E" BorderStyle="Ridge"
                            CausesValidation="False" Font-Names="Times New Roman" Font-Size="9pt" ForeColor="White"
                            Height="25px" OnClick="btnBuscar_Click" Text="Buscar" Width="90px" />

                        <asp:Button ID="btnCarta" runat="server" BackColor="#1F529E" CausesValidation="False"
                            ForeColor="White" OnClick="btnCarta_Click" Text="Carta" Width="90px" BorderStyle="Ridge"
                            Font-Names="Time new Roman" Font-Size="9pt" Height="25px" />

                            
                        <asp:Button ID="btnGenerarExcel" runat="server" BackColor="#1F529E" CausesValidation="False"
                            ForeColor="White" OnClick="btnGeneraExcel_Click" Text="Generar Excel Cartas" 
                            Width="160px" BorderStyle="Ridge"
                            Font-Names="Times New Roman" Font-Size="9pt" Height="25px" 
                            style="margin-left: 3px" />

                        <asp:Button ID="btnIVR" runat="server" BackColor="#1F529E" BorderStyle="Ridge"
                            CausesValidation="False" Font-Names="Times New Roman" Font-Size="9pt" ForeColor="White"
                            Height="25px" OnClick="btnIVR_Click" Text="IVR" Width="90px" />


                        <asp:Button ID="btnCorreo" runat="server" BackColor="#1F529E" BorderStyle="Ridge"
                            CausesValidation="False" Font-Names="Times New Roman" Font-Size="9pt" ForeColor="White"
                            Height="25px" OnClick="btnCorreo_Click" Text="Correo" Width="90px" />


                        <asp:Button ID="btnSMS" runat="server" BackColor="#1F529E" BorderStyle="Ridge"
                            CausesValidation="False" Font-Names="Times New Roman" Font-Size="9pt" ForeColor="White"
                            Height="25px" OnClick="btnSMS_Click" Text="SMS" Width="140px" />


                    </td>
                </tr>
            </table>
            <table id="ControlesSuperior" border="0" cellpadding="0" cellspacing="0" class="cabeceraScroll"
                width="100%">
                <tr>
                    <td align="center" style="width: 100%;">
                        <table id="Controles" align="center" border="0" cellpadding="0" cellspacing="0" class="cabeceraScroll"
                            width="800px">
                            <tr id="Documento" >
                                <td align="left" style="width: 331px">
                                    Documento de identidad:
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txt_documento" runat="server" Width="400px" MaxLength="20"></asp:TextBox>
                                </td>
                            </tr>
                            <tr id="Nombres">
                                <td align="left" style="width: 331px">
                                    Nombres:
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txt_nombres" runat="server" Width="400px" MaxLength="50"></asp:TextBox>
                                </td>
                            </tr>
                            <tr id="DiasMora">
                                <td align="left" style="width: 331px">
                                    Dias de mora:
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txt_dias_mora" runat="server" Width="400px"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="rexNombre" runat="server" ControlToValidate="txt_dias_mora"
                                        Display="Dynamic" ErrorMessage="Debe ingresar por lo menos 3 caracteres." ValidationExpression=".{3,}">*</asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr id="Estado">
                                <td align="left" style="width: 331px">
                                    Estado:
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="cmb_Estado" runat="server" TabIndex="6" Width="400px" 
                                        AutoPostBack="True">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr id="TipoGestion">
                                <td align="left" style="width: 331px">
                                    Tipo de Gestión:
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="cmb_CodTipoGestion" runat="server" TabIndex="6" 
                                        Width="400px" 
                                        onselectedindexchanged="cmb_CodTipoGestion_SelectedIndexChanged" 
                                        AutoPostBack="True">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr id="Carta">
                                <td align="left" style="width: 331px">
                                    Documento:
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="cmb_Carta" runat="server" TabIndex="6" Width="400px" 
                                        onselectedindexchanged="cmb_Carta_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr id="Fecha">
                                <td align="left" style="width: 331px">
                                    Fecha de Registro del Action Plan:
                                </td>
                                <td align="left" valign="middle">
                                    Del
                                    <asp:TextBox ID="txt_FECHAINI" runat="server" Enabled="false" Height="18px" MaxLength="10"
                                        TabIndex="5" Width="150px"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="imgCal1"
                                        TargetControlID="txt_FECHAINI" />
                                    <asp:ImageButton ID="imgCal1" runat="Server" AlternateText="Mostrar calendario" ImageUrl="~/imagenes/Calendar.png" />
                                    &nbsp;al
                                    <asp:TextBox ID="txt_FECHAFIN" runat="server" Enabled="false" Height="18px" MaxLength="10"
                                        TabIndex="5" Width="150px"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="imgCal2"
                                        TargetControlID="txt_FECHAFIN" />
                                    <asp:ImageButton ID="imgCal2" runat="Server" AlternateText="Mostrar calendario" ImageUrl="~/imagenes/Calendar.png" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <asp:GridView ID="gv" runat="server" Width="95%" EnableTheming="True" AutoGenerateColumns="False"
                AllowSorting="True" AllowPaging="True" Style="text-align: center" ViewStateMode="Enabled"
                BackColor="#999999" OnPageIndexChanging="gv_PageIndexChanging" OnPageIndexChanged="gv_PageIndexChanged"
                PageSize="40" onselectedindexchanged="gv_SelectedIndexChanged">
                <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <Columns>
                    <asp:TemplateField ShowHeader="False">
                        <ItemStyle Width="1%"></ItemStyle>
                        <HeaderStyle Width="1%" CssClass=""></HeaderStyle>
                        <ItemTemplate>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="IdReg_Gestion_Cobranza" HeaderText="IdReg_G_Cob." SortExpression="">
                        <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False" CssClass="hidden">
                        </ItemStyle>
                        <HeaderStyle Width="10%" CssClass="hidden" Height="22px"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="Asesores" HeaderText="Asesores" SortExpression="">
                        <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                        <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="FechaRegistra" HeaderText="FechaReg." SortExpression="">
                        <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                        <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="Descripcion_TipoGestion" HeaderText="Desc_TipoGestion"
                        SortExpression="">
                        <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                        <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="RazonSocial" HeaderText="RazonSocial/Nombres" SortExpression="">
                        <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                        <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="Producto" HeaderText="Producto" SortExpression="">
                        <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                        <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="SubProducto" HeaderText="SubProducto" SortExpression="">
                        <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                        <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="dias_mora" HeaderText="Dias_mora" SortExpression="">
                        <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                        <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="Descripcion_ClaseGestion" HeaderText="Resultado" SortExpression="">
                        <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                        <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="FechaResultado" HeaderText="FechaResu." SortExpression="">
                        <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                        <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="CodEjecutado" HeaderText="CodEjecutado" SortExpression="">
                        <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False" CssClass="hidden">
                        </ItemStyle>
                        <HeaderStyle Width="10%" CssClass="hidden" Height="22px"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="Descripcion_Ejecutado" HeaderText="Clasificación" SortExpression="">
                        <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                        <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="desc_ejecutores" HeaderText="Ejecutores" SortExpression="">
                        <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False" CssClass="hidden">
                        </ItemStyle>
                        <HeaderStyle Width="10%" Height="22px" CssClass="hidden"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="desc_campaña" HeaderText="desc_campaña" SortExpression="">
                        <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                        <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="id_estado_gestion_cobranza">
                        <ItemStyle CssClass="hidden"></ItemStyle>
                        <HeaderStyle CssClass="hidden"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="" HeaderText="Estado" SortExpression="">
                        <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                        <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="CodCLaseGestion">
                        <ItemStyle CssClass="hidden"></ItemStyle>
                        <HeaderStyle CssClass="hidden"></HeaderStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="" HeaderText="Ver Ficha" SortExpression="">
                        <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                        <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="CodigoCliente">
                        <ItemStyle CssClass="hidden"></ItemStyle>
                        <HeaderStyle CssClass="hidden"></HeaderStyle>
                    </asp:BoundField>

                    <asp:TemplateField HeaderText="Select">
                        <HeaderTemplate>
                            <asp:CheckBox ID="chkAll" onclick="javascript:SelectAllCheckboxes(this);" runat="server"
                                Height="15px"></asp:CheckBox>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkPermiso" runat="server" />
                        </ItemTemplate>
                       </asp:TemplateField>

                    <asp:BoundField DataField="CodTipoGestion" HeaderText="CodTipoGestion" SortExpression="">
                        <ItemStyle CssClass="hidden" Width="10%"></ItemStyle>
                        <HeaderStyle Width="10%" CssClass="hidden" Height="22px"></HeaderStyle>
                    </asp:BoundField>

                </Columns>
                <RowStyle></RowStyle>
                <EmptyDataTemplate>
                    <table id="tbSinDatos">
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
                    </table>
                </EmptyDataTemplate>
                <SelectedRowStyle CssClass="selectedrow"></SelectedRowStyle>
                <AlternatingRowStyle />
            </asp:GridView>
            <table id="Contador" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td class="pagerstyle" style="height: 30px; text-align: center">
                        <asp:Label ID="lblCantidad" runat="server"></asp:Label>&nbsp;
                        <asp:Label ID="lblPaginaGrilla" runat="server"></asp:Label>&nbsp;
                    </td>
                </tr>
            </table>
            <asp:HiddenField ID="hfOrden" runat="server"></asp:HiddenField>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnBuscar" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="uprogGvUsuario" runat="server" AssociatedUpdatePanelID="upGvUsuario"
        DisplayAfter="250">
        <ProgressTemplate>
            <asp:Panel ID="pnlGvCargando" runat="server" SkinID="PanelCargando" Width="100px">
                <table id="tbGvCargando" cellpadding="1" cellspacing="1" style="width: 100%">
                    <tr>
                        <td style="width: 50%; text-align: center">
                            <asp:Label ID="lblGvCargando" runat="server" Style="cursor: pointer" Text="Cargando..."
                                CssClass="modalPopup"></asp:Label>
                        </td>
                        <td style="width: 50%; text-align: justify">
                            <asp:Image runat="server" ID="Progres" ImageUrl="~/imagenes/loading.gif" Style="vertical-align: middle"
                                alt="Procesando&#8230;" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
